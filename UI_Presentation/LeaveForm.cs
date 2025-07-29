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
    public partial class LeaveForm : Form
    {
        string dbconn = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";
        public LeaveForm()
        {
            InitializeComponent();
        }
        public static string searchKey;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }


        private void button2_Click(object sender, EventArgs e)
        {
            


        }

        public void ReloadLeave()
        {
            try
            {
                SqlConnection connect = new SqlConnection(dbconn);

                connect.Open();


                string query = "select * from tbl_Eleave";


                SqlCommand cmd = new SqlCommand(query, connect);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);


                DataTable dataTable = new DataTable();


                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;


                connect.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("A database error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayNextLid()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(dbconn))
                {
                    connect.Open();
                    string query = "SELECT ISNULL(MAX(Lid), 0) + 1 FROM tbl_Eleave";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    int nextLid = (int)cmd.ExecuteScalar();
                    label16.Text = nextLid.ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A database error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LeaveForm_Load(object sender, EventArgs e)
        {
           
            ReloadLeave();
            DisplayNextLid();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        public void delete(string iddetail)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "delete from tbl_Eleave where empid = '" + iddetail + "'";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           



        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");

            this.Close();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            ReloadLeave();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ClassCard up = new ClassCard();
            up.updatee(textBox1.Text, comboBox1.SelectedItem.ToString(), dateTimePicker1.Text, dateTimePicker2.Text, comboBox2.Text.ToString(), Convert.ToInt32(textBox2.Text));

            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Approved")
            {
                SqlConnection conn = new SqlConnection(dbconn);
                conn.Open();
                SqlCommand con = conn.CreateCommand();
                string sql = "INSERT INTO tbl_empattend (empid, LOG_DATE, TIME_IN, TI_STATUS, TIME_OUT, TO_STATUS) VALUES (@empid, @logdate, @timein, @amstat, @getout, @pmstat)";
                con.CommandText = sql;
                con.Parameters.AddWithValue("@empid", textBox1.Text);
                con.Parameters.AddWithValue("@logdate", dateTimePicker1.Value.ToString());
                con.Parameters.AddWithValue("@timein", "ON LEAVE");
                con.Parameters.AddWithValue("@amstat", "ON LEAVE");
                con.Parameters.AddWithValue("@getout", "ON LEAVE");
                con.Parameters.AddWithValue("@pmstat", "ON LEAVE");
                con.ExecuteNonQuery();
                MessageBox.Show("Data Saved");
                con.Dispose();
                conn.Close();
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ClassCard save = new ClassCard();
            save.empid = textBox1.Text;
            save.DateStart = dateTimePicker1.Value.ToString();
            save.DateEnd = dateTimePicker2.Value.ToString();
            save.reason = comboBox1.SelectedItem.ToString();
            save.status = comboBox2.SelectedItem.ToString();
            save.saveleave();


            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Approved")
            {
                SqlConnection conn = new SqlConnection(dbconn);
                conn.Open();
                SqlCommand con = conn.CreateCommand();
                string sql = "INSERT INTO tbl_empattend (empid, LOG_DATE, TIME_IN, TI_STATUS, TIME_OUT, TO_STATUS) VALUES (@empid, @logdate, @timein, @amstat, @getout, @pmstat)";
                con.CommandText = sql;
                con.Parameters.AddWithValue("@empid", textBox1.Text);
                con.Parameters.AddWithValue("@logdate", dateTimePicker1.Value.ToString());
                con.Parameters.AddWithValue("@timein", "ON LEAVE");
                con.Parameters.AddWithValue("@amstat", "ON LEAVE");
                con.Parameters.AddWithValue("@getout", "ON LEAVE");
                con.Parameters.AddWithValue("@pmstat", "ON LEAVE");
                con.ExecuteNonQuery();
                MessageBox.Show("Data Saved");
                con.Dispose();
                conn.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ClassCard get = new ClassCard();
            get.Ldelete(textBox2.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DashForm form2 = new DashForm();
            form2.Show();
            this.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            ClassCard get = new ClassCard();
            get.getDetailss(textBox1.Text);
            label3.Text = $"{get.empFN} {get.empLN}";
            label5.Text = get.position;
            label7.Text = get.contact;
            label9.Text = get.Eaddress;

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            ClassCard get = new ClassCard();
            get.getLDetailss(textBox2.Text);
            textBox1.Text = get.empid;
            dateTimePicker1.Text = get.DateStart;
            dateTimePicker2.Text = get.DateEnd;
            comboBox1.Text = get.reason;
            comboBox2.Text = get.status;


        }
    }
}
