using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI_Presentation
{
    public class ClassCard
    {

        string dbconn = "Data Source=(localdb)\\localDB1;Initial Catalog=db_ems;Integrated Security=True";

        public string empid { get; set; }
        public string empname { get; set; }
        public string empFN { get; set; }
        public string empLN { get; set; }

        public string FatherFN { get; set; }
        public string FatherLN { get; set; }
        public string MotherFN { get; set; }
        public string MotherLN { get; set; }

        public string position { get; set; }

        public string eid { get; set; }

        public string image { get; set; }

        public string medical { get; set; }

        public string gender { get; set; }

        public string religion { get; set; }
        public string dob { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public string civilstat { get; set; }
        public string citizenship { get; set; }
        public string lang { get; set; }
        public string FatherN { get; set; }
        public string MotherN { get; set; }
        public string fatherO { get; set; }
        public string motherO { get; set; }
        public string pce { get; set; }
        public string policeC { get; set; }
        public string brgyC { get; set; }
        public string pagibig { get; set; }
        public string sss { get; set; }
        public string philhealth { get; set; }
        public string driverLic { get; set; }
        public string res { get; set; }
        public string curriculum { get; set; }
        public string applicationlet { get; set; }
        public string Mcontact { get; set; }
        public string Fcontact { get; set; }

        public double q1 { get; set; }
        public double q2 { get; set; }
        public double q3 { get; set; }
        public double q4 { get; set; }
        public double q5 { get; set; }
        public double total { get; set; }
        public string remarks { get; set; }

        public string DateHired { get; set; }

        public string department { get; set; }
        public string Eaddress { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }

        public string itemName { get; set; }
        public string ExCat { get; set; }

        public double price { get; set; }

        public string DateP { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        
        public string refid { get; set; }

        public static List<ClassCard> list = new List<ClassCard>();


        public void saveItem()
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand con = conn.CreateCommand();
            string sql = "insert into tbl_companyexpense(Date_Purchased,Product_Price,Product_Name,Product_Type)values(@DatePurchased,@ProductPrice,@ProductName,@ProductType)";
            con.CommandText = sql;
            con.Parameters.AddWithValue("@DatePurchased", this.DateP);
            con.Parameters.AddWithValue("@ProductPrice", this.price);
            con.Parameters.AddWithValue("@ProductName", this.itemName);
            con.Parameters.AddWithValue("@ProductType", this.ExCat);
            con.ExecuteNonQuery();
            MessageBox.Show("Data Saved");
            con.Dispose();
            conn.Close();
        }

        public void userupdate(string username, string password, string refid)
        {
            using (SqlConnection conn = new SqlConnection(dbconn))
{
                {
                    conn.Open();
                    string sql = "UPDATE tbl_HRACC SET Password = @Password, Username = @Username WHERE recovery_code = @recovery_code";
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Password", password ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@recovery_code", refid ?? (object)DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account Updated");

            }
        }
        public void Itemupdate(string Datep, double price, string itemname, string ExCat, int IID)
        {
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();
                string sql = "UPDATE tbl_companyexpense SET Date_Purchased = @Date_Purchased, Product_Price = @Product_Price, Product_Type = @Product_Type, Product_Name= @Product_Name where IID = @IID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Date_Purchased", Datep ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Product_Name", itemname ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Product_Price", price);
                    cmd.Parameters.AddWithValue("@Product_Type", ExCat ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IID", IID);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Data Updated");
        }

        public void saveleave()
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand con = conn.CreateCommand();
            string sql = "insert into tbl_Eleave(empid,Lreason,Date_Start,Date_End,Lstatus)values(@empid,@Lreason,@Date_Start,@Date_End,@Lstatus)";
            con.CommandText = sql;
            con.Parameters.AddWithValue("@empid", this.empid);
            con.Parameters.AddWithValue("@Lreason", this.reason);
            con.Parameters.AddWithValue("@Date_Start", this.DateStart);
            con.Parameters.AddWithValue("@Date_End", this.DateEnd);
            con.Parameters.AddWithValue("@Lstatus", this.status);
            con.ExecuteNonQuery();
            MessageBox.Show("Data Saved");
            con.Dispose();
            conn.Close();
        }

        public void updatee(string empid, string reason, string DateStart, string DateEnd, string status, int Lid)
        {
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();
                string sql = "UPDATE tbl_Eleave SET Lreason = @Lreason, Date_Start = @Date_Start, Date_End= @Date_End, Lstatus = @Lstatus WHERE Lid = @Lid";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Lreason", reason ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Date_Start", DateStart ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Date_End", DateEnd ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Lstatus", status ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Lid", Lid);

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Data Updated");
        }



        public void getUDetails(string iddetails)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "select * from tbl_HRACC where Username = '" + iddetails + "'";
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Username = reader["Username"].ToString();
                Password = reader["Password"].ToString();
                refid = reader["recovery_code"].ToString();
            }
            cmd.Dispose();
            conn.Close();
            reader.Dispose();
        }

        public void saveuser()
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand con = conn.CreateCommand();
            string sql = "insert into tbl_HRACC(Username,Password,recovery_code)values(@username,@password,@recovery_code)";
            con.CommandText = sql;
            con.Parameters.AddWithValue("@username", this.Username);
            con.Parameters.AddWithValue("@password", this.Password);
            con.Parameters.AddWithValue("@recovery_code", this.refid);
            con.ExecuteNonQuery();
            MessageBox.Show("Account Created");
            con.Dispose();
            conn.Close();
        }




        public void Save()
        {
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tbl_eInf WHERE empId = @empId", conn);
                checkCmd.Parameters.AddWithValue("@empId", this.empid);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Duplicate empid. Please use a unique empid.");
                    return;
                }

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.Transaction = transaction;

                        string sql = "insert into tbl_eInf(empId,empFname,empLname,position,empImg,Egender,Ereligion,Edob,contact,Eemail,Ecivilstat,Ecitizenship,language,FatherFN,FatherLN,MotherFN,MotherLN,FatherO,MotherO,Fcontact,Mcontact,PCE,Date_Hired,Eaddress,EDepartment) " +
                                     "values (@empId,@empFname,@empLname,@position,@empImg,@Egender,@Ereligion,@Edob,@contact,@Eemail,@Ecivilstat,@Ecitizenship,@language,@FatherFN,@FatherLN,@MotherFN,@MotherLN,@FatherO,@MotherO,@Fcontact,@Mcontact,@PCE,@DateHired,@Eaddress,@Department)";

                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@empId", this.empid);
                        cmd.Parameters.AddWithValue("@empFname", this.empFN);
                        cmd.Parameters.AddWithValue("@empLname", this.empLN);
                        cmd.Parameters.AddWithValue("@position", this.position);
                        cmd.Parameters.AddWithValue("@Egender", this.gender);
                        cmd.Parameters.AddWithValue("@Ereligion", this.religion);
                        cmd.Parameters.AddWithValue("@Edob", this.dob);
                        cmd.Parameters.AddWithValue("@contact", this.contact);
                        cmd.Parameters.AddWithValue("@Eemail", this.email);
                        cmd.Parameters.AddWithValue("@Eaddress", string.IsNullOrEmpty(this.Eaddress) ? (object)DBNull.Value : this.Eaddress);
                        cmd.Parameters.AddWithValue("@Department", this.department);
                        cmd.Parameters.AddWithValue("@Ecivilstat", this.civilstat ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Ecitizenship", this.citizenship);
                        cmd.Parameters.AddWithValue("@language", this.lang);
                        cmd.Parameters.AddWithValue("@FatherFN", this.FatherFN);
                        cmd.Parameters.AddWithValue("@FatherLN", this.FatherLN);
                        cmd.Parameters.AddWithValue("@MotherFN", this.MotherFN);
                        cmd.Parameters.AddWithValue("@MotherLN", this.MotherLN);
                        cmd.Parameters.AddWithValue("@FatherO", this.fatherO);
                        cmd.Parameters.AddWithValue("@MotherO", this.motherO);
                        cmd.Parameters.AddWithValue("@PCE", this.pce ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Fcontact", this.Fcontact);
                        cmd.Parameters.AddWithValue("@Mcontact", this.Mcontact);
                        cmd.Parameters.AddWithValue("@DateHired", this.DateHired);
                        cmd.Parameters.AddWithValue("@empImg", string.IsNullOrEmpty(this.image) ? (object)DBNull.Value : this.image);

                        cmd.ExecuteNonQuery();

                        SqlCommand cmdEreq = conn.CreateCommand();
                        cmdEreq.Transaction = transaction;

                        string sqlEreq = "insert into tbl_Ereq(empId,Emedical,EpoliceC,EbrgyC,Epagibig,Esss,Ephilhealth,EdriverLic,Eres,Ecurriculum,Eapplicationlet) " +
                                         "values (@empId,@Emedical,@EpoliceC,@EbrgyC,@Epagibig,@Esss,@Ephilhealth,@EdriverLic,@Eres,@Ecurriculum,@Eapplicationlet)";

                        cmdEreq.CommandText = sqlEreq;
                        cmdEreq.Parameters.AddWithValue("@empId", this.empid);
                        cmdEreq.Parameters.AddWithValue("@Emedical", this.medical);
                        cmdEreq.Parameters.AddWithValue("@EpoliceC", this.policeC);
                        cmdEreq.Parameters.AddWithValue("@EbrgyC", this.brgyC);
                        cmdEreq.Parameters.AddWithValue("@Epagibig", this.pagibig);
                        cmdEreq.Parameters.AddWithValue("@Esss", this.sss);
                        cmdEreq.Parameters.AddWithValue("@Ephilhealth", this.philhealth);
                        cmdEreq.Parameters.AddWithValue("@EdriverLic", this.driverLic);
                        cmdEreq.Parameters.AddWithValue("@Eres", this.res);
                        cmdEreq.Parameters.AddWithValue("@Ecurriculum", this.curriculum);
                        cmdEreq.Parameters.AddWithValue("@Eapplicationlet", this.applicationlet);

                        cmdEreq.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Data Saved");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }


        public void saveeval()
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "insert into tbl_eEval(empid,empname,Q1,Q2,Q3,Q4,Q5,remarks,totalEpoints) values (@empid,@empname,@q1,@q2,@q3,@q4,@q5,@remarks,@totalEpoints)";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@empid", this.empid);
            cmd.Parameters.AddWithValue("@empname", this.empname);
            cmd.Parameters.AddWithValue("@q1", this.q1);
            cmd.Parameters.AddWithValue("@q2", this.q2);
            cmd.Parameters.AddWithValue("@q3", this.q3);
            cmd.Parameters.AddWithValue("@q4", this.q4);
            cmd.Parameters.AddWithValue("@q5", this.q5);
            cmd.Parameters.AddWithValue("@remarks", this.remarks);
            cmd.Parameters.AddWithValue("@totalEpoints", this.total);
           
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Saved");
            cmd.Dispose();
            conn.Close();
        }

        public void getlist()
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "select * from tbl_eInf";
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            list.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClassCard details = new ClassCard
                    {
                        empid = reader["empid"].ToString(),
                        empFN=reader["empFname"].ToString(),
                        empLN = reader["empLname"].ToString(),
                        position = reader["position"].ToString(),
                        image = reader["empImg"].ToString(),
                        eid = reader["Erefid"].ToString(),
                        department = reader["EDepartment"].ToString()
                    };
                    list.Add(details);
                }
                conn.Close();
                cmd.Dispose();
            }
        }


        public void getElist()
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "select * from tbl_eEval ORDER BY totalEpoints DESC;";
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            list.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClassCard details = new ClassCard
                    {
                        empid = reader["empid"].ToString(),
                        empname = reader["empname"].ToString(),
                        total = Convert.ToDouble(reader["totalEpoints"]),

                    };
                    list.Add(details);
                }
                conn.Close();
                cmd.Dispose();
            }
        }

        public void newinsertedEval()
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            string sql = "SELECT * FROM tbl_eEval ORDER BY totalEpoints DESC;";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                empid = reader["empid"].ToString();
                empname = reader["empname"].ToString();
                q1 = Convert.ToDouble(reader["Q1"]);
                q2 = Convert.ToDouble(reader["Q2"]);
                q3 = Convert.ToDouble(reader["Q3"]);
                q4 = Convert.ToDouble(reader["Q4"]);
                q5 = Convert.ToDouble(reader["Q5"]);
                total = Convert.ToDouble(reader["totalEpoints"]);
                remarks = reader["remarks"].ToString();
            }
            cmd.Dispose();
            reader.Dispose();
            conn.Close();
        }

        public void getNewInsertedData()
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            string sql = "SELECT * FROM tbl_eInf WHERE Erefid IN (SELECT MAX(Erefid) FROM tbl_eInf);";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                empid = reader["empid"].ToString();
                empFN = reader["empFname"].ToString();
                empLN = reader["empLname"].ToString();
                position = reader["position"].ToString();
                image = reader["empImg"].ToString();
                eid = reader["Erefid"].ToString();
                department = reader["EDepartment"].ToString();
            }
            cmd.Dispose();
            reader.Dispose();
            conn.Close();
        }

        public void getNewLInsertedData()
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            string sql = "SELECT * FROM tbl_Eleave WHERE Lid IN (SELECT MAX(Lid) FROM tbl_Eleave);";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                empid = reader["empid"].ToString();
                reason = reader["Lreason"].ToString();
                DateStart = reader["Date_Start"].ToString();
                DateEnd = reader["Date_End"].ToString();
                status = reader["Lstatus"].ToString();
            }
            cmd.Dispose();
            reader.Dispose();
            conn.Close();
        }


        public void delete(string iddetail)
        {
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.Transaction = transaction;

                        string sql = "delete from tbl_eInf where empid = @eid";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@eid", iddetail);
                        cmd.ExecuteNonQuery();

                        sql = "delete from tbl_empattend where empid = @eid";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        sql = "delete from tbl_eEval where empid = @eid";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        sql = "delete from tbl_Eleave where empid = @eid";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Ldelete(string iddetail)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "delete from tbl_Eleave where Lid = '" + iddetail + "'";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            MessageBox.Show("Leave Record Deleted Successfuly");
        }

        public void search(string key)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            string sql = "select * from tbl_eInf where empFname like '%' + @key + '%' or empLname like '%' + @key + '%' or position like '%' + @key + '%' or EDepartment like '%' + @key + '%' or empid like '%' +@key+'%' ";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@key", key);

            SqlDataReader reader = cmd.ExecuteReader();
            list.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClassCard card = new ClassCard
                    {
                        empid = reader["empid"].ToString(),
                        empFN = reader["empFname"].ToString(),
                        empLN = reader["empLname"].ToString(),
                        position = reader["position"].ToString(),
                        image = reader["empImg"].ToString(),
                        eid = reader["Erefid"].ToString(),
                        department = reader["EDepartment"].ToString(),
                    };
                    list.Add(card);
                }
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }

        public void searchByTitleAndDepartment(string titleKey, string departmentKey)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            string sql = "select * from tbl_eInf where 1=1";

            if (!string.IsNullOrEmpty(titleKey))
            {
                sql += " and position like '%' + @titleKey + '%'";
            }

            if (!string.IsNullOrEmpty(departmentKey))
            {
                sql += " and EDepartment like '%' + @departmentKey + '%'";
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            if (!string.IsNullOrEmpty(titleKey))
            {
                cmd.Parameters.AddWithValue("@titleKey", titleKey);
            }

            if (!string.IsNullOrEmpty(departmentKey))
            {
                cmd.Parameters.AddWithValue("@departmentKey", departmentKey);
            }

            SqlDataReader reader = cmd.ExecuteReader();
            list.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClassCard card = new ClassCard
                    {
                        empid = reader["empid"].ToString(),
                        empFN = reader["empFname"].ToString(),
                        empLN = reader["empLname"].ToString(),
                        position = reader["position"].ToString(),
                        image = reader["empImg"].ToString(),
                        eid = reader["Erefid"].ToString(),
                        department = reader["EDepartment"].ToString(),
                    };
                    list.Add(card);
                }
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }

        public void update(string empid, string empFname, string empLname, string title, string image, string eid, string gender, string religion, string dob, string contact, string email, string civilstat, string citizenship, string lang, string FatherFN, string FatherLN, string fatherO, string MotherFN,string MotherLN, string MotherO, string Mcontact, string Fcontact, string PCE, string Eaddress, string department)
        {
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();
                string sql = "UPDATE tbl_eInf SET empId = @empid, empFname = @empFname,empLname = @empLname, position = @title, empImg = @image, Egender = @gender, Ereligion = @religion, Edob = @dob, contact = @contact, " +
                    "Eemail = @Eemail, Ecivilstat = @civilstat, Ecitizenship = @citizenship, language = @lang, FatherFN = @FatherFN,FatherLN = @FatherLN,MotherFN = @MotherFN, MotherLN = @MotherLN, FatherO = @FatherO, MotherO = @MotherO, PCE = @PCE, Mcontact = @Mcontact, Fcontact = @Fcontact, Eaddress = @Eaddress, EDepartment = @EDepartment WHERE Erefid = @eid";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@empid", empid ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@empFname", empFname ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@empLname", empLname ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@title", title ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@image", image ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@eid", eid ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@gender", gender ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@religion", religion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@dob", dob ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@contact", contact ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Eemail", email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@civilstat", civilstat ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@citizenship", citizenship ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@lang", lang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FatherFN", FatherFN ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FatherLN", FatherLN ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fatherO", fatherO ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MotherFN", MotherFN ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MotherLN", MotherLN ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MotherO", MotherO ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mcontact", Mcontact ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fcontact", Fcontact ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PCE", PCE ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Eaddress", Eaddress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EDepartment", department ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            

           
        }

        public void updateEreq(string empid, string medical, string policeC, string brgyC, string pagibig, string sss, string philhealth, string driverLic, string res, string curriculum, string applicationlet)
        {
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();
                string sql = "UPDATE tbl_Ereq SET Emedical = @medical, EpoliceC = @policeC, EbrgyC = @brgyC, Epagibig = @Pagibig, Esss = @SSS, Ephilhealth = @philhealth, EdriverLic = @driverLic, Eres = @res, Ecurriculum = @curriculum, Eapplicationlet = @applicationlet WHERE empid = @empId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@empId", empid ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@medical", medical ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@policeC", policeC ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@brgyC", brgyC ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Pagibig", pagibig ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SSS", sss ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@philhealth", philhealth ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@driverLic", driverLic ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@res", res ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@curriculum", curriculum ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@applicationlet", applicationlet ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Data Updated");
        }

        public void getPDetails(string iddetails)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "select * from tbl_eInf where empId = '" + iddetails + "'";
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                image = reader["empImg"].ToString();

            }
        }

        public void getTDetails(string iddetails)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "select * from tbl_eInf where empId = '" + iddetails + "'";
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                position = reader["position"].ToString();

            }
        }

        public void getLDetailss(string iddetails)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "select * from tbl_Eleave where Lid = '" + iddetails + "'";
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                empid = reader["empid"].ToString();
                reason = reader["Lreason"].ToString();
                DateStart = reader["Date_Start"].ToString();
                DateEnd = reader["Date_End"].ToString();
                status = reader["Lstatus"].ToString();


            }
            cmd.Dispose();
            conn.Close();
            reader.Dispose();
        }

        public void getBDetailss(string iddetails)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "select * from tbl_companyexpense where IID = '" + iddetails + "'";
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                itemName = reader["Product_Name"].ToString();
                price = Convert.ToDouble(reader["Product_Price"]);
                DateP = reader["Date_Purchased"].ToString();
                ExCat = reader["Product_Type"].ToString();


            }
            cmd.Dispose();
            conn.Close();
            reader.Dispose();
        }

        public void getDetails(string iddetails)
        {
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();

                // Fetch data from tbl_eInf
                SqlCommand cmd1 = conn.CreateCommand();
                string sql1 = "select * from tbl_eInf where Erefid = @id";
                cmd1.CommandText = sql1;
                cmd1.Parameters.AddWithValue("@id", iddetails);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    empid = reader1["empId"].ToString();
                    empFN = reader1["empFname"].ToString();
                    empLN = reader1["empLname"].ToString();
                    position = reader1["position"].ToString();
                    image = reader1["empImg"].ToString();
                    eid = reader1["Erefid"].ToString();
                    gender = reader1["Egender"].ToString();
                    religion = reader1["Ereligion"].ToString();
                    dob = reader1["Edob"].ToString();
                    contact = reader1["contact"].ToString();
                    email = reader1["Eemail"].ToString();
                    civilstat = reader1["Ecivilstat"].ToString();
                    citizenship = reader1["Ecitizenship"].ToString();
                    lang = reader1["language"].ToString();
                    FatherFN = reader1["FatherFN"].ToString();
                    FatherLN = reader1["FatherLN"].ToString();
                    MotherFN = reader1["MotherFN"].ToString();
                    MotherLN = reader1["MotherLN"].ToString();
                    fatherO = reader1["FatherO"].ToString();
                    motherO = reader1["MotherO"].ToString();
                    pce = reader1["PCE"].ToString();
                    Mcontact = reader1["Mcontact"].ToString();
                    Fcontact = reader1["Fcontact"].ToString();
                    DateHired = reader1["Date_Hired"].ToString();
                    department = reader1["EDepartment"].ToString();
                    Eaddress = reader1["Eaddress"].ToString();
                }
                reader1.Close();
                cmd1.Dispose();

                // Fetch data from tbl_Ereq
                SqlCommand cmd2 = conn.CreateCommand();
                string sql2 = "select * from tbl_Ereq where empid = @empid";
                cmd2.CommandText = sql2;
                cmd2.Parameters.AddWithValue("@empid", empid);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    medical = reader2["Emedical"].ToString();
                    policeC = reader2["EpoliceC"].ToString();
                    brgyC = reader2["EbrgyC"].ToString();
                    pagibig = reader2["Epagibig"].ToString();
                    sss = reader2["Esss"].ToString();
                    philhealth = reader2["Ephilhealth"].ToString();
                    driverLic = reader2["EdriverLic"].ToString();
                    res = reader2["Eres"].ToString();
                    curriculum = reader2["Ecurriculum"].ToString();
                    applicationlet = reader2["Eapplicationlet"].ToString();
                }
                reader2.Close();
                cmd2.Dispose();
            }
        }

        public void getDetailss(string iddetails)
        {
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();

                // Fetch data from tblemf
                SqlCommand cmd1 = conn.CreateCommand();
                string sql1 = "select * from tbl_eInf where empid = @id";
                cmd1.CommandText = sql1;
                cmd1.Parameters.AddWithValue("@id", iddetails);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    empid = reader1["empid"].ToString();
                    empFN = reader1["empFname"].ToString();
                    empLN = reader1["empLname"].ToString();
                    position = reader1["position"].ToString();
                    image = reader1["empImg"].ToString();
                    eid = reader1["Erefid"].ToString();
                    gender = reader1["Egender"].ToString();
                    religion = reader1["Ereligion"].ToString();
                    dob = reader1["Edob"].ToString();
                    contact = reader1["contact"].ToString();
                    email = reader1["Eemail"].ToString();
                    civilstat = reader1["Ecivilstat"].ToString();
                    citizenship = reader1["Ecitizenship"].ToString();
                    lang = reader1["language"].ToString();
                    FatherFN = reader1["FatherFN"].ToString();
                    FatherLN = reader1["FatherLN"].ToString();
                    MotherFN = reader1["MotherFN"].ToString();
                    MotherLN = reader1["MotherLN"].ToString();
                    fatherO = reader1["FatherO"].ToString();
                    motherO = reader1["MotherO"].ToString();
                    pce = reader1["PCE"].ToString();
                    Mcontact = reader1["Mcontact"].ToString();
                    Fcontact = reader1["Fcontact"].ToString();
                    DateHired = reader1["Date_Hired"].ToString();
                    department = reader1["EDepartment"].ToString();
                    Eaddress = reader1["Eaddress"].ToString();
                }
                reader1.Close();
                cmd1.Dispose();

                // Fetch data from tbl_Ereq
                SqlCommand cmd2 = conn.CreateCommand();
                string sql2 = "select * from tbl_Ereq where empid = @empid";
                cmd2.CommandText = sql2;
                cmd2.Parameters.AddWithValue("@empid", iddetails);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    medical = reader2["Emedical"].ToString();
                    policeC = reader2["EpoliceC"].ToString();
                    brgyC = reader2["EbrgyC"].ToString();
                    pagibig = reader2["Epagibig"].ToString();
                    sss = reader2["Esss"].ToString();
                    philhealth = reader2["Ephilhealth"].ToString();
                    driverLic = reader2["EdriverLic"].ToString();
                    res = reader2["Eres"].ToString();
                    curriculum = reader2["Ecurriculum"].ToString();
                    applicationlet = reader2["Eapplicationlet"].ToString();
                }
                reader2.Close();
                cmd2.Dispose();
            }
        }

        public void getEDetails(string iddetails)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string sql = "select * from tbl_eEval where empid = '" + iddetails + "'";
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                q1 = Convert.ToDouble(reader["Q1"]);
                q2 = Convert.ToDouble(reader["Q2"]);
                q3 = Convert.ToDouble(reader["Q3"]);
                q4 = Convert.ToDouble(reader["Q4"]);
                q5 = Convert.ToDouble(reader["Q5"]);
                total = Convert.ToDouble(reader["totalEpoints"]);
                remarks = reader["remarks"].ToString();
            }
            cmd.Dispose();
            conn.Close();
            reader.Dispose();
        }


        public void eupdate(double q1, double q2, double q3, double q4, double q5, double total, string remarks, string empid)
        {
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();
                string sql = "UPDATE tbl_eEval SET Q1 = @q1, Q2 = @q2, Q3 = @q3, Q4 = @q4, Q5 = @q5, remarks = @remarks, totalEpoints = @total WHERE empid = @empid";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@q1", q1);
                    cmd.Parameters.AddWithValue("@q2", q2);
                    cmd.Parameters.AddWithValue("@q3", q3);
                    cmd.Parameters.AddWithValue("@q4", q4);
                    cmd.Parameters.AddWithValue("@q5", q5);
                    cmd.Parameters.AddWithValue("@remarks", remarks ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@empid", empid);






                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Data Updated");
        }


        public List<string> GetDistinctTitles()
        {
            List<string> titles = new List<string>();
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();
                string sql = "SELECT DISTINCT title FROM tbl_eInf";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        titles.Add(reader["position"].ToString());
                    }
                }
            }
            return titles;
        }
        public List<string> GetDistinctDepartments()
        {
            List<string> departments = new List<string>();
            using (SqlConnection conn = new SqlConnection(dbconn))
            {
                conn.Open();
                string sql = "SELECT DISTINCT EDepartment FROM tbl_eInf";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        departments.Add(reader["EDepartment"].ToString());
                    }
                }
            }
            return departments;
        }

        public void searchByTitle(string titleKey)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            string sql = "select * from tbl_eInf where Edepartment like '%' + @titleKey + '%'";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@titleKey", titleKey);
            SqlDataReader reader = cmd.ExecuteReader();
            list.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClassCard card = new ClassCard
                    {
                        empid = reader["empId"].ToString(),
                        empFN = reader["empFname"].ToString(),
                        empLN = reader["empLname"].ToString(),
                        position = reader["position"].ToString(),
                        image = reader["empImg"].ToString(),
                        eid = reader["Erefid"].ToString(),
                        department = reader["EDepartment"].ToString(),
                    };
                    list.Add(card);
                }
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }

        public void searchByDepartment(string departmentKey)
        {
            SqlConnection conn = new SqlConnection(dbconn);
            conn.Open();
            string sql = "select * from tbl_eInf where EDepartment like '%' + @departmentKey + '%'";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@departmentKey", departmentKey);
            SqlDataReader reader = cmd.ExecuteReader();
            list.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClassCard card = new ClassCard
                    {
                        empid = reader["empId"].ToString(),
                        empFN = reader["empFname"].ToString(),
                        empLN = reader["empLname"].ToString(),
                        position = reader["position"].ToString(),
                        image = reader["empImg"].ToString(),
                        eid = reader["Erefid"].ToString(),
                        department = reader["EDepartment"].ToString(),
                    };
                    list.Add(card);
                }
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }
    }

}

