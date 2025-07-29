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
    public partial class payroll : Form
    {
        public payroll()
        {
            InitializeComponent();
        }

        private void payroll_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");

        }

        private void button5_Click(object sender, EventArgs e)
        {

            DashForm emps = new DashForm();
            emps.Show();
            this.Close();
        }
    }
}
