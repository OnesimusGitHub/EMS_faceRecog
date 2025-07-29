using Emgu.CV.Structure;
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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");

            DashForm form2 = new DashForm();
            form2.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WelcomeForm form2 = new WelcomeForm();
            form2.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\0';
            pictureBox3.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           textBox2.PasswordChar = '*';
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        public static bool viewD = false;
        public static string reference;

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";
            string username = textBox1.Text;
            string passwordOrRefid = textBox2.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM tbl_HRACC WHERE Username=@Username AND (Password=@PasswordOrRefid OR recovery_code=@PasswordOrRefid)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordOrRefid", passwordOrRefid);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 1)
                {
                    // Login successful
                    MessageBox.Show("Login successful!");
                    timer1.Start();
                    viewD = true;
                    reference = textBox1.Text;
                    DashForm frm2 = new DashForm();
                    frm2.Show();
                    this.Hide();
                }
                else
                {
                    // Login failed
                    MessageBox.Show("Login failed. Please check your username and password or refid.");
                    label8.Visible = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM tbl_HRACC";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 0)
                {
                   
                    SignUp ee = new SignUp();
                    ee.Show();
                    this.Close();
                }
                else
                {
                   
                    MessageBox.Show("Only one admin can be registered in this system.");
                }
            }
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DashForm.isView == true)
            {
                ClassCard get = new ClassCard();
                get.getUDetails(textBox1.Text);
                textBox1.Text = get.Username;
                textBox2.Text = get.Password;
                DashForm.isView = false;
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Hide();
        }
    }
}
