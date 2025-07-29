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

namespace UI_Presentation
{
    public partial class EmpPro : Form
    {
        public EmpPro()
        {
            InitializeComponent();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            UserControl1.view = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExpandEmp expand = new ExpandEmp();
            expand.Show();


        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            WelcomeForm form2 = new WelcomeForm();
            form2.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EmpPro emps = new EmpPro();
            emps.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
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

                // Show the save version of Form2
                using (EmpInfo frm2Save = new EmpInfo())
                {
                    frm2Save.ShowDialog();
                    
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
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            FilterResults();
        }

        private void EmpPro_Load(object sender, EventArgs e)
        {
            LoadTitlesIntoComboBox();
            LoadAllRecords();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void LoadAllRecords()
        {
            ClassCard classCard = new ClassCard();
            classCard.getlist(); // Get all employees

            flowLayoutPanel1.Controls.Clear();
            foreach (ClassCard data in ClassCard.list)
            {
                UserControl1 card = new UserControl1();
                card.cardDetails(data);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private void FilterResults()
        {
            string selectedTitle = comboBox1.SelectedItem?.ToString();
            string selectedDepartment = comboBox2.SelectedItem?.ToString();

            ClassCard classCard = new ClassCard();

            if (string.IsNullOrEmpty(selectedTitle) || selectedTitle == "All Positions")
            {
                selectedTitle = null;
            }

            if (string.IsNullOrEmpty(selectedDepartment) || selectedDepartment == "All Departments")
            {
                selectedDepartment = null;
            }

            if (selectedTitle == null && selectedDepartment == null)
            {
                classCard.getlist(); // Get all employees
            }
            else
            {
                classCard.searchByTitleAndDepartment(selectedTitle, selectedDepartment);
            }

            flowLayoutPanel1.Controls.Clear();
            foreach (ClassCard data in ClassCard.list)
            {
                UserControl1 card = new UserControl1();
                card.cardDetails(data);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private void LoadTitlesIntoComboBox()
        {
            string connectionString = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";
            string query = "SELECT DISTINCT position FROM tbl_eInf"; // Adjust the table name and column as necessary

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["position"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

        }

        int i;
        private void loadCards()
        {
            foreach (ClassCard data in ClassCard.list)
            {
                i++;
                UserControl1 cards = new UserControl1();
                cards.cardDetails(data);
                flowLayoutPanel1.Controls.Add(cards);
            }

        }

        private void initDetails()
        {
            ClassCard get = new ClassCard();
            get.getlist();
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {


            
      
        }

        public static string searchKey;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchKey = textBox1.Text;
                ClassCard classCard = new ClassCard();
                classCard.search(searchKey); // Perform search based on the text input

                flowLayoutPanel1.Controls.Clear();
                foreach (ClassCard data in ClassCard.list)
                {
                    UserControl1 card = new UserControl1();
                    card.cardDetails(data);
                    flowLayoutPanel1.Controls.Add(card);
                }
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            FilterResults();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchKey = textBox1.Text;
            ClassCard classCard = new ClassCard();
            classCard.search(searchKey); // Perform search based on the text input

            flowLayoutPanel1.Controls.Clear();
            foreach (ClassCard data in ClassCard.list)
            {
                UserControl1 card = new UserControl1();
                card.cardDetails(data);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
            DashForm emps = new DashForm();
            emps.Show();
            this.Close();
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

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(UserControl1.view == true)
            {
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label14_Click(object sender, EventArgs e)
        {
            WelcomeForm emps = new WelcomeForm();
            emps.Show();
            this.Hide();

        }

        private void label15_Click(object sender, EventArgs e)
        {
            AdminSett adminSett = new AdminSett();
            adminSett.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (UserControl1.isDeleted == true)
            {
                flowLayoutPanel1.Controls.Clear();
                initDetails();
                loadCards();
                UserControl1.isDeleted = false;

            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (AdminSett.Deleted == true)
            {
                this.Close();
            }
        }
    }
}
