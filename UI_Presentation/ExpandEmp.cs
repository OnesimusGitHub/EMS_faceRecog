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
    public partial class ExpandEmp : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True");

        public ExpandEmp()
        {
            InitializeComponent();
        }
        public static bool isView = false;
        public static bool med = false;
        public static bool pol = false;
        public static bool brgyy = false;
        public static bool pag = false;
        public static bool ssss = false;
        public static bool phil = false;
        public static bool driv = false;
        public static bool curr = false;
        public static bool res = false;
        public static bool app = false;
        private void button3_Click(object sender, EventArgs e)
        {
            EmpPro empPro = new EmpPro();
            empPro.Show();
            this.Close();
        }

        private void ExpandEmp_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            if (UserControl1.person == true)
            {

                getDetail();
                showAttend();
                CalculateDuration();
            }

        }
        private void getDetail()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            label47.Text = get.eid;
            label12.Text = get.empid;
            label13.Text = get.empFN;
            label60.Text = get.empLN;
            label14.Text = get.position;
            label28.Text = get.gender;
            label29.Text = get.religion;
            label30.Text = get.dob;
            label31.Text = get.contact;
            label32.Text = get.email;
            label33.Text = get.civilstat;
            label34.Text = get.citizenship;
            label35.Text = get.lang;

            label36.Text = get.FatherFN;
            label62.Text = get.FatherLN;
            label37.Text = get.MotherFN;
            label64.Text = get.MotherLN;
            label38.Text = get.fatherO;
            label39.Text = get.motherO;
            label42.Text = get.Fcontact;
            label41.Text = get.Mcontact;
            label40.Text = get.pce;
            pictureBox1.ImageLocation = get.image;
            pictureBox2.ImageLocation = get.medical;
            pictureBox3.ImageLocation = get.policeC;
            pictureBox4.ImageLocation = get.brgyC;
            pictureBox5.ImageLocation = get.pagibig;
            pictureBox9.ImageLocation = get.sss;
            pictureBox8.ImageLocation = get.philhealth;
            pictureBox7.ImageLocation = get.driverLic;
            pictureBox11.ImageLocation = get.res;
            pictureBox6.ImageLocation = get.curriculum;
            pictureBox10.ImageLocation = get.applicationlet;
            label49.Text = get.DateHired;
            label55.Text = get.Eaddress;
            label54.Text = get.department;
        }


        private void CalculateDuration()
        {
            // Parse the date from label49
            DateTime dateHired;
            if (DateTime.TryParse(label49.Text, out dateHired))
            {
                // Calculate the duration
                TimeSpan duration = DateTime.Now - dateHired;

                // Display the duration in label50
                label50.Text = $"Joined {duration.Days} days ago";
            }
            else
            {
                label50.Text = "Invalid date in label49";
            }
        }

        public void showAttend()
        {
            connect.Open();
            string query = "SELECT CONCAT(tbl_eInf.empFname, ' ', tbl_eInf.empLname) AS empname, tbl_empattend.LOG_DATE, tbl_empattend.TIME_IN, tbl_empattend.TI_STATUS, tbl_empattend.TIME_OUT, tbl_empattend.TO_STATUS " +
               "FROM tbl_empattend " +
               "INNER JOIN tbl_eInf ON tbl_empattend.empid = tbl_eInf.empId " +
               "WHERE tbl_empattend.empid = @empid";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@empid", label12.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connect.Close();
        }


        public static string pubId;

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            med = true;
            pubId = label47.Text;
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Form3.medical == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label47.Text);
                label1.Text = get.empname;
                label2.Text = get.position;
                label47.Text = get.eid;
                pictureBox1.ImageLocation = get.image;
                Form3.medical = false;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer2.Start();
            pol = true;
            pubId = label47.Text;
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Form3.police == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label47.Text);
                label1.Text = get.empname;
                label2.Text = get.position;
                label47.Text = get.eid;
                pictureBox1.ImageLocation = get.image;
                Form3.police = false;

            }

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            timer3.Start();
            brgyy = true;
            pubId = label47.Text;
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Form3.brgy == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label47.Text);
                label1.Text = get.empname;
                label2.Text = get.position;
                label47.Text = get.eid;
                pictureBox1.ImageLocation = get.image;
                Form3.brgy = false;

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            timer4.Start();
            pag = true;
            pubId = label47.Text;
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (Form3.pagibig == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label47.Text);
                label1.Text = get.empname;
                label2.Text = get.position;
                label47.Text = get.eid;
                pictureBox1.ImageLocation = get.image;
                Form3.pagibig = false;

            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            timer5.Start();
            ssss = true;
            pubId = label47.Text;
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (Form3.sss == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label47.Text);
                label1.Text = get.empname;
                label2.Text = get.position;
                label47.Text = get.eid;
                pictureBox1.ImageLocation = get.image;
                Form3.sss = false;

            }
            else
            {
                timer5.Stop();
            }



        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            timer6.Start();
            phil = true;
            pubId = label47.Text;
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (Form3.philhealth == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label47.Text);
                label1.Text = get.empname;
                label2.Text = get.position;
                label47.Text = get.eid;
                pictureBox1.ImageLocation = get.image;
                Form3.philhealth = false;

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            timer7.Start();
            driv = true;
            pubId = label47.Text;
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (Form3.driver == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label47.Text);
                label1.Text = get.empname;
                label2.Text = get.position;
                label47.Text = get.eid;
                pictureBox1.ImageLocation = get.image;
                Form3.driver = false;

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            timer8.Start();
            curr = true;
            pubId = label47.Text;
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            if (Form3.curriculum == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label47.Text);
                label1.Text = get.empname;
                label2.Text = get.position;
                label47.Text = get.eid;
                pictureBox1.ImageLocation = get.image;
                Form3.curriculum = false;

            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            timer9.Start();
            res = true;
            pubId = label47.Text;
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (Form3.resume == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label47.Text);
                label1.Text = get.empname;
                label2.Text = get.position;
                label47.Text = get.eid;
                pictureBox1.ImageLocation = get.image;
                Form3.resume = false;

            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            timer10.Start();
            app = true;
            pubId = label47.Text;
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            if (Form3.appletter == true)
            {
                ClassCard get = new ClassCard();
                get.getDetails(label47.Text);
                label1.Text = get.empname;
                label2.Text = get.position;
                label47.Text = get.eid;
                pictureBox1.ImageLocation = get.image;
                Form3.appletter = false;

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            connect.Open();
            string query = "SELECT CONCAT(tbl_eInf.empFname, ' ', tbl_eInf.empLname) AS empname, tbl_empattend.LOG_DATE,  tbl_empattend.TIME_IN, tbl_empattend.TI_STATUS," +
                " tbl_empattend.TIME_OUT, tbl_empattend.TO_STATUS, tbl_empattend.TOTAL_HOURS FROM tbl_empattend INNER JOIN tbl_eInf " +
                "ON tbl_empattend.empid = tbl_eInf.empId WHERE tbl_empattend.empid = @empid AND YEAR(tbl_empattend.LOG_DATE) = YEAR(GETDATE()) AND MONTH(tbl_empattend.LOG_DATE) = MONTH(GETDATE());";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@empid", label12.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connect.Close();
        }

        

        private void button4_Click_1(object sender, EventArgs e)
        {
            Evaluation eval = new Evaluation();
            eval.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            connect.Open();
            string query = "SELECT CONCAT(tbl_eInf.empFname, ' ', tbl_eInf.empLname) AS empname,tbl_empattend.LOG_DATE, tbl_empattend.TIME_IN, tbl_empattend.TI_STATUS, tbl_empattend.TIME_OUT, tbl_empattend.TO_STATUS,tbl_empattend.TOTAL_HOURS FROM tbl_empattend INNER JOIN " +
                "tbl_eInf ON tbl_empattend.empid = tbl_eInf.empId WHERE tbl_empattend.empid = @empid AND CONVERT(DATE, tbl_empattend.LOG_DATE) = CAST(GETDATE() AS DATE);";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@empid", label12.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connect.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            connect.Open();
            string query = "SELECT CONCAT(tbl_eInf.empFname, ' ', tbl_eInf.empLname) AS empname, tbl_empattend.LOG_DATE,  tbl_empattend.TIME_IN, tbl_empattend.TI_STATUS, tbl_empattend.TIME_OUT, tbl_empattend.TO_STATUS, tbl_empattend.TOTAL_HOURS" +
                " FROM tbl_empattend INNER JOIN tbl_eInf ON tbl_empattend.empid = tbl_eInf.empId WHERE tbl_empattend.empid = @empid AND CONVERT(DATE, tbl_empattend.LOG_DATE) BETWEEN DATEADD(DAY, -6, CAST(GETDATE() AS DATE)) AND CAST(GETDATE() AS DATE);";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@empid", label12.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connect.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                timer11.Start();
                label51.Visible = true;
                label52.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label51.Visible = false;
                label52.Visible = false;
                timer11.Stop();
                showAttend();
            }
        }



        private void SearchAttendanceBetweenDates()
        {

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            // Log the start and end dates
            Console.WriteLine($"Start Date: {startDate}, End Date: {endDate}");

            try
            {
                connect.Open();
                string query = "SELECT CONCAT(tbl_eInf.empFname, ' ', tbl_eInf.empLname) AS empname, tbl_empattend.LOG_DATE, tbl_empattend.TIME_IN, tbl_empattend.TI_STATUS, tbl_empattend.TIME_OUT, tbl_empattend.TO_STATUS, tbl_empattend.TOTAL_HOURS " +
                               "FROM tbl_empattend " +
                               "INNER JOIN tbl_eInf ON tbl_empattend.empid = tbl_eInf.empId " +
                               "WHERE tbl_empattend.empid = @empid AND tbl_empattend.LOG_DATE BETWEEN @startDate AND @endDate";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@empid", label12.Text);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                // Log the number of rows retrieved
                Console.WriteLine($"Number of rows retrieved: {dataTable.Rows.Count}");
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                connect.Close();
            }
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            SearchAttendanceBetweenDates();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Attendance_Report form
            Attendance_Report reportForm = new Attendance_Report();

            // Pass the data from the DataGridView to the DataGridView in Attendance_Report
            DataTable dataTable = (DataTable)dataGridView1.DataSource;

            // Get the employee details
            string empName = label13.Text;
            string empId = label12.Text;
            string empTitle = label14.Text;
            string empDepartment = label54.Text;
            Image empImage = pictureBox1.Image;

            reportForm.SetData(dataTable, empName, empId, empTitle, empDepartment, empImage);

            // Show the Attendance_Report form
            reportForm.ShowDialog();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
