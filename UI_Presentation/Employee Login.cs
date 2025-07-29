using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Presentation
{
    public partial class Employee_Login : Form
    {
        public Employee_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
            EmployeeProfile form2 = new EmployeeProfile();
            form2.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeLoginForm_Click(object sender, EventArgs e)
        {

        }

        private void Employee_Login_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            WelcomeForm form2 = new WelcomeForm();
            form2.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Face form2 = new Face();
            form2.Show();
            this.Hide();
        }
    }
}
