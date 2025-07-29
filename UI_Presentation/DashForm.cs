using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI_Presentation
{
    public partial class DashForm : Form
    {
        public DashForm()
        {
            InitializeComponent();
           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            WelcomeForm form2 = new WelcomeForm();
            form2.Show();
            this.Close();
        }
        public static bool isView = false;


        private void getUDetails()
        {
            ClassCard get = new ClassCard();
            get.getUDetails(AdminLogin.reference);
            label2.Text = get.Username;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EmpPro emps = new EmpPro();
            emps.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            EmployeeProfile mps = new EmployeeProfile();
            mps.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DashForm emps = new DashForm();
            emps.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            payroll emps = new payroll();
            emps.Show();
            this.Close();
        }


        private void initDetails()
        {
            ClassCard get = new ClassCard();
            get.getElist();

        }

        int i;
        private void loadCards()
        {
            foreach (ClassCard data in ClassCard.list)
            {
                i++;
                LeadBoards cards = new LeadBoards();
                cards.cardDetails(data);
                flowLayoutPanel1.Controls.Add(cards);
            }

        }
        bool viewing = false;
        private void DashForm_Load(object sender, EventArgs e)
        {
            initDetails();
            loadCards();
            LoadChartData();
            LoadChartDatas();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            AdminSett.Deleted = false;


            if (AdminLogin.viewD == true)
            {
               getUDetails();
                viewing = true;


            }
            else
            {
                getUDetails();
            }
        }




        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (Evaluation.refesh == true)
            {
                LeadBoards card = new LeadBoards();
                flowLayoutPanel1.Controls.Add(card);
                Evaluation.refesh = false;

            }
        }


        private void timer2_Tick_1(object sender, EventArgs e)
        {
            try
            {
                // Get the count of new hires
                int newHires = GetNewHiresCount();

                // Update the label or textbox
                label4.Text = $"New Hires This Month: {newHires}";
            }
            catch (Exception ex)
            {
                // Handle exceptions and show an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private int GetNewHiresCount()
        {
            string connectionString = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";
            string query = @"SELECT COUNT(*) FROM tbl_eInf WHERE Date_Hired >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND Date_Hired < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }



        private int GetCount()
        {
            string connectionString = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";
            string query = @"
                SELECT COUNT(*) FROM tbl_eInf";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }


        private void timer3_Tick_1(object sender, EventArgs e)
        {
            try
            {
                // Get the count of new hires
                int newHires = GetCount();

                // Update the label or textbox
                label3.Text = $"Total Employees: {newHires}";
            }
            catch (Exception ex)
            {
                // Handle exceptions and show an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadChartData()
        {
            // Connection string to your database
            string connectionString = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";
            string query = "SELECT EDepartment, COUNT(*) AS Count FROM tbl_eInf GROUP BY EDepartment;";

            // Using ADO.NET to fetch data
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind data to the chart
                        chart1.Series.Clear();
                        Series series = new Series("Status Count")
                        {
                            ChartType = SeriesChartType.Pie // Change to Bar, Column, etc., if needed
                        };

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string status = row["EDepartment"].ToString();
                            int count = Convert.ToInt32(row["Count"]);
                            DataPoint point = new DataPoint();
                            point.AxisLabel = status;
                            point.YValues = new double[] { count };
                            point.Label = null; // Remove the label from the pie chart
                            point.LegendText = $"{status} ({count})"; // Include count in the legend
                            series.Points.Add(point);
                        }

                        chart1.Series.Add(series);
                        chart1.Titles.Add("Employee Status Distribution");

                        // Disable labels on the series
                        series.IsValueShownAsLabel = false;
                        series.LabelForeColor = Color.Transparent;

                        // Add a legend to display the labels and values on the right
                        Legend legend = new Legend
                        {
                            Docking = Docking.Right,
                            IsTextAutoFit = true
                        };
                        chart1.Legends.Clear();
                        chart1.Legends.Add(legend);

                        // Adjust the size of the chart area and move the pie chart to the left
                        chart1.ChartAreas[0].Position = new ElementPosition(0, 0, 100, 100);
                        chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(10, 25, 50, 50); // Move the pie chart to the left and make it smaller
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            CompanyExpenses good = new CompanyExpenses();
            this.Hide();
            good.Show();
        }
        private void LoadChartDatas()
        {
            // Connection string - update with your database details
            string connectionString = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";
            string query = "SELECT Date_Purchased, Product_Price, Product_Name FROM tbl_companyexpense";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind data to the chart
                    chart2.DataSource = dataTable;

                    // Configure the chart
                    chart2.Series.Clear();
                    Series series = new Series("Expense Price")
                    {
                        XValueMember = "Date_Purchased",     // X-axis (dates)
                        YValueMembers = "Product_Price",   // Y-axis (price)
                        ChartType = SeriesChartType.Line // Choose chart type (e.g., Line, Bar, etc.)
                    };

                    chart2.Series.Add(series);

                    // Set additional chart properties
                    chart1.ChartAreas[0].AxisX.Title = "Date_Purchased";
                    chart1.ChartAreas[0].AxisY.Title = "Product_Price";

                    chart2.DataBind();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            EmpPro emps = new EmpPro();
            emps.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

            Form background = new Form();
            try
            {
                // Check if the UserControl1 is currently displayed
                if (flowLayoutPanel1.Controls.Count > 0 && flowLayoutPanel1.Controls[0] is UserControl1)
                {
                    UserControl1 userControl1 = (UserControl1)flowLayoutPanel1.Controls[0];
                    // Set the view flag to false in UserControl1
                    UserControl1.view = false;
                }

                // Hide the current form
                this.Hide();

                // Show the save version of Form2
                using (EmpInfo frm2Save = new EmpInfo())
                {
                    frm2Save.ShowDialog(); // Use ShowDialog to keep the current form hidden until EmpInfo is closed
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                background.Dispose();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            LeaveForm emps = new LeaveForm();
            emps.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            WelcomeForm emps = new WelcomeForm();
            emps.Show();
            this.Hide();
        }

        private void chart2_Click_1(object sender, EventArgs e)
        {
            CompanyExpenses good = new CompanyExpenses();
            this.Hide();
            good.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            AdminSett adminSett = new AdminSett();
            adminSett.Show();
            
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (AdminSett.Deleted == true)
            {
                this.Close();
            }
        }
    }
}
