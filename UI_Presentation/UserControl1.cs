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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }



        private void UserControl1_Load(object sender, EventArgs e)
        {
            if (EmpInfo.refresh == true)
            {
                displayNew();
            }

        }
        public void searchResult()
        {

            ClassCard get = new ClassCard();
            get.search(EmpPro.searchKey);
            label1.Text = $"{get.empFN} {get.empLN}";
            label2.Text = get.position;
            label3.Text = get.empid;
            pictureBox1.ImageLocation = get.image;
            label4.Text = get.eid;
            label5.Text = get.department;
        }
        public void cardDetails(ClassCard e)
        {
            label1.Text = $"{e.empFN} {e.empLN}";
            label2.Text = e.position;
            label3.Text = e.empid;
            pictureBox1.ImageLocation = e.image;
            label4.Text = e.eid;
            label5.Text = e.department;


        }
        public void displayNew()
        {
            ClassCard get = new ClassCard();
            get.getNewInsertedData();
            pictureBox1.ImageLocation = get.image;
            label1.Text = $"{get.empFN} {get.empLN}";
            label2.Text = get.position;
            label3.Text = get.empid;
            label4.Text = get.eid;
            label5.Text = get.department;
        }
        public static bool view = false;
        public static string pubId;
        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            view = true;
            pubId = label4.Text;
            EmpInfo frm2 = new EmpInfo();
            frm2.Show();
           
        }



        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(pictureBox2, 0, pictureBox2.Height);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (EmpInfo.isUpdate == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label4.Text);
                label1.Text = $"{get.empFN} {get.empLN}";
                label2.Text = get.position;
                label4.Text = get.eid;
                label5.Text = get.department;
                pictureBox1.ImageLocation = get.image;
                EmpInfo.isUpdate = false;

            }

        }

        public static bool isDeleted = false;
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            

        }

        public static bool person = false;
        private void viewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            timer2.Start();
            person = true;
            pubId = label4.Text;
            ExpandEmp frm2 = new ExpandEmp();
            frm2.Show();
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (ExpandEmp.isView == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label4.Text);
                label1.Text = $"{get.empFN} {get.empLN}";
                label2.Text = get.position;
                label4.Text = get.eid;
                label5.Text = get.department;
                pictureBox1.ImageLocation = get.image;
                ExpandEmp.isView = false;

            }
            else
            {

                

                timer2.Stop();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer2.Start();
            person = true;
            pubId = label4.Text;
            ExpandEmp frm2 = new ExpandEmp();
            frm2.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDeleted = true;
            ClassCard get = new ClassCard();
            get.delete(label3.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
