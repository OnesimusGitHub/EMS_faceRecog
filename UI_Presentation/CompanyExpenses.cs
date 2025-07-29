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
    public partial class CompanyExpenses : Form
    {
        string dbconn = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";
        public CompanyExpenses()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void CompanyExpenses_Load(object sender, EventArgs e)
        {
            ReloadEx();
            DisplayNextLid();


        }

        public void ReloadEx()
        {
            try
            {
                SqlConnection connect = new SqlConnection(dbconn);

                connect.Open();


                string query = "select * from tbl_companyexpense";


                SqlCommand cmd = new SqlCommand(query, connect);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);


                DataTable dataTable = new DataTable();


                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;


                connect.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("A database error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DisplayNextLid()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(dbconn))
                {
                    connect.Open();
                    string query = "SELECT ISNULL(MAX(IID), 0) + 1 FROM tbl_companyexpense";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    int nextLid = (int)cmd.ExecuteScalar();
                    label3.Text = nextLid.ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A database error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DashForm dashForm = new DashForm();
            dashForm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClassCard save = new ClassCard();
            save.itemName = textBox1.Text;
            save.ExCat = (string)comboBox1.SelectedItem;
            save.price = Convert.ToSingle(textBox2.Text);
            save.DateP = dateTimePicker1.Value.ToString();
            save.saveItem();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ClassCard up = new ClassCard();
            up.Itemupdate(dateTimePicker1.Text, Convert.ToDouble(textBox2.Text), textBox1.Text, comboBox1.SelectedItem.ToString(), Convert.ToInt32(textBox3.Text));
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            ClassCard get = new ClassCard();
            get.getBDetailss(textBox3.Text);
            textBox1.Text = get.itemName;
            dateTimePicker1.Text = get.DateP;
            textBox2.Text = get.price.ToString();
            comboBox1.Text = get.ExCat;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            ReloadEx();
            DisplayNextLid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int IID = Convert.ToInt32(textBox3.Text); 

                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    string sql = "DELETE FROM tbl_companyexpense WHERE IID = @IID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IID", IID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified IID.");
                        }
                    }
                }
                ReloadEx(); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid IID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A database error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
