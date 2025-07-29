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
    public partial class AdminSett : Form
    {
        private DashForm dashForm;
        private EmpInfo empInfo;
        private EmpPro empPro;
        public AdminSett()
        {
            InitializeComponent();

            this.dashForm = dashForm;
            this.empInfo = empInfo;
            this.empPro = empPro;
            
        }



        private void LoadFirstAdminRecord()
        {
            string connectionString = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";
            string query = "SELECT TOP 1 * FROM tbl_HRACC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        string username = reader["Username"].ToString();
                        string password = reader["Password"].ToString();
                        string refid = reader["recovery_code"].ToString();

                       
                        textBox1.Text = username;
                        textBox2.Text = password;
                        label2.Text = refid;
                    }
                }
            }
        }

        private void AdminSett_Load(object sender, EventArgs e)
        {
            LoadFirstAdminRecord();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassCard up = new ClassCard();
            up.userupdate(textBox1.Text, textBox2.Text,label2.Text);
        }
        public static bool Deleted = false;
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";
            string query = "DELETE FROM tbl_HRACC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

            // Close the forms
            Deleted = true;

            // Show the SignUpForm
            SignUp signUpForm = new SignUp();
            signUpForm.Show();

            // Close the current form
            this.Close();
        }
        
    }
}
