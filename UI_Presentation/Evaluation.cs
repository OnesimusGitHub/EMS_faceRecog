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
    public partial class Evaluation : Form
    {
        public Evaluation()
        {
            InitializeComponent();
        }

        private void Evaluation_Load(object sender, EventArgs e)
        {
            getDetails();
            getEDetails();
            checkComboBoxes();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void getDetails()
        {

            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            label1.Text = $"{get.empFN} {get.empLN}";
            label2.Text = get.position;
            label3.Text = get.empid;
            pictureBox1.ImageLocation = get.image;

        }

        private void getEDetails()
        {

            ClassCard get = new ClassCard();
            get.getEDetails(label3.Text);

            comboBox1.Text = get.q1.ToString();
            comboBox2.Text = get.q2.ToString();
            comboBox3.Text = get.q3.ToString();
            comboBox4.Text = get.q4.ToString();
            comboBox5.Text = get.q5.ToString();
            label16.Text = get.total.ToString();
            textBox1.Text = get.remarks;
        }

        private void calcueva()
        {
            double q1, q2, q3, q4, q5;


            q1 = Convert.ToDouble(comboBox1.SelectedItem);
            q2 = Convert.ToDouble(comboBox2.SelectedItem);
            q3 = Convert.ToDouble(comboBox3.SelectedItem);
            q4 = Convert.ToDouble(comboBox4.SelectedItem);
            q5 = Convert.ToDouble(comboBox5.SelectedItem);


            double total = (q1 + q2 + q3 + q4 + q5) / 5;


            label16.Text = total.ToString("F2");
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            calcueva();
        }
        public static bool refesh = false;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "Submit")
            {
                ClassCard save = new ClassCard();
                save.empname = label1.Text;
                save.position = label2.Text;
                save.empid = label3.Text;
                save.total = Convert.ToDouble(label16.Text);
                save.q1 = Convert.ToDouble(comboBox1.SelectedItem);
                save.q2 = Convert.ToDouble(comboBox2.SelectedItem);
                save.q3 = Convert.ToDouble(comboBox3.SelectedItem);
                save.q4 = Convert.ToDouble(comboBox4.SelectedItem);
                save.q5 = Convert.ToDouble(comboBox5.SelectedItem);
                save.total = Convert.ToDouble(label16.Text);
                save.remarks = textBox1.Text;
                save.saveeval();
                this.Close();
                refesh = true;
            }
            else
            {
                ClassCard upd = new ClassCard();
                upd.eupdate(Convert.ToDouble(comboBox1.SelectedItem), Convert.ToDouble(comboBox2.SelectedItem), Convert.ToDouble(comboBox3.SelectedItem), Convert.ToDouble(comboBox4.SelectedItem), Convert.ToDouble(comboBox5.SelectedItem), Convert.ToDouble(label16.Text), textBox1.Text, label3.Text);
                refesh = true;
            }
        }



        private void checkComboBoxes()
        {


            if (comboBox1.Text == "0" ||
                comboBox2.Text == "0" ||
                comboBox3.Text == "0" ||
                comboBox4.Text == "0" ||
                comboBox5.Text == "0")
            {
                button1.Text = "Submit";
            }
            else
            {
                button1.Text = "Update";


            }
        }
    }
}
