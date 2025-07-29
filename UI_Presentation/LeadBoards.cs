using Newtonsoft.Json.Bson;
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
    public partial class LeadBoards : UserControl
    {
        public LeadBoards()
        {
            InitializeComponent();
        }

        private void LeadBoards_Load(object sender, EventArgs e)
        {
            
            
            if (Evaluation.refesh == true)
            {
                another();
                displayNew();
                newp();
            }
            else
            {
                newp();
                another();
            }
        }
        public void another()
        {
            ClassCard gett = new ClassCard();
            gett.getTDetails(label3.Text);
            label4.Text = gett.position;
        }

        
        public void displayNew()
        {
            ClassCard get = new ClassCard();
            
            
            get.newinsertedEval();
            label3.Text = get.empid;
            label1.Text = get.empname;
            label2.Text = get.total.ToString();
            

        }
        public void newp()
        {
            ClassCard gets = new ClassCard();
            gets.getPDetails(label3.Text);
            pictureBox1.ImageLocation = gets.image;
        }
        public void cardDetails(ClassCard e)
        {
            label1.Text = e.empname;
            label2.Text = e.total.ToString();
            pictureBox1.ImageLocation = e.image;
            label3.Text = e.empid;
            label4.Text = e.position;


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }






}
