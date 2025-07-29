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
    public partial class EmployeeProfile : Form
    {
        public EmployeeProfile()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeProfile_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LeaveForm form2 = new LeaveForm();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
               Employee_Login form2 = new Employee_Login();
            form2.Show();
            this.Hide();
        }
    }
}
