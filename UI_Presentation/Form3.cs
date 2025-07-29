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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public static bool medical = false;
        public static bool police = false;
        public static bool brgy = false;
        public static bool pagibig = false;
        public static bool sss = false;
        public static bool philhealth = false;
        public static bool driver = false;
        public static bool curriculum = false;
        public static bool resume = false;
        public static bool appletter = false;
        private void Form3_Load(object sender, EventArgs e)
        {
            if (ExpandEmp.med == true)
            {
                getmed();
                medical = true;
                ExpandEmp.med = false;
            }
            if (ExpandEmp.pol == true)
            {
                getpol();
                police = true;
                ExpandEmp.pol = false;
            }
            if (ExpandEmp.brgyy == true)
            {
                getbrgy();
                brgy = true;
                ExpandEmp.brgyy = false;
            }
            if (ExpandEmp.pag == true)
            {
                getpag();
                pagibig = true;
                ExpandEmp.pag = false;
            }
            if (ExpandEmp.ssss == true)
            {
                getsss();
                sss = true;
                ExpandEmp.ssss = false;

            }
            if (ExpandEmp.phil == true)
            {
                getphil();
                philhealth = true;
                ExpandEmp.phil = false;
            }
            if (ExpandEmp.driv == true)
            {
                getdriv();
                driver = true;
                ExpandEmp.driv = false;
            }
            if (ExpandEmp.curr == true)
            {
                getcurr();
                curriculum = true;
                ExpandEmp.curr = false;
            }
            if (ExpandEmp.res == true)
            {
                getres();
                resume = true;
                ExpandEmp.res = false;
            }
            if (ExpandEmp.app == true)
            {
                getapp();
                appletter = true;
                ExpandEmp.app = false;
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void getmed()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            pictureBox1.ImageLocation = get.medical;
        }
        private void getpol()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            pictureBox1.ImageLocation = get.policeC;
        }
        private void getbrgy()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            pictureBox1.ImageLocation = get.brgyC;
        }
        private void getpag()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            pictureBox1.ImageLocation = get.pagibig;
        }

        private void getsss()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            pictureBox1.ImageLocation = get.sss;
        }

        private void getphil()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            pictureBox1.ImageLocation = get.philhealth;
        }
        private void getdriv()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            pictureBox1.ImageLocation = get.driverLic;
        }
        private void getcurr()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            pictureBox1.ImageLocation = get.curriculum;
        }
        private void getres()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            pictureBox1.ImageLocation = get.res;
        }
        private void getapp()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            pictureBox1.ImageLocation = get.applicationlet;
        }
    }
}
