using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace UI_Presentation
{
    public partial class EmpInfo : Form
    {
        MaterialSkinManager skinmanager;
        public const string CLOUDNAME = "dxfv8ppsu";
        public const string API_KEY = "917128836932341";
        public const string API_SECRET = "kucO-ABWzygenB8xIHJ-Ju5yPDs";
        public Cloudinary cloud;
        string imagepath, medicalpath, policepath, brgypath, pagibigpath, respath, curriculumpath, applicationpath, ssspath, philpath, driverpath, imagelink, medicalimg, policeCimg, brgyCimg, Pagibigimg, resimg, curriculumimg, applicationletimg, sssimg, philimg, driverimg;

        public EmpInfo()
        {
            InitializeComponent();
            textBox9.KeyPress += TextBox_KeyPress;
            textBox9.TextChanged += TextBox_TextChanged;
            textBox14.KeyPress += TextBox_KeyPress;
            textBox14.TextChanged += TextBox_TextChanged;
            textBox13.KeyPress += TextBox_KeyPress;
            textBox13.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control characters
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length > 11)
            {
                // Limit the length to 11 digits
                textBox.Text = textBox.Text.Substring(0, 11);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }





        [Obsolete]
        private void cloudinaryStorage()
        {




            Account acc = new Account(CLOUDNAME, API_KEY, API_SECRET);
            cloud = new Cloudinary(acc);

            if (!string.IsNullOrEmpty(imagepath) && imagepath != imagelink)
            {
                uploadImg(imagepath);
            }
            else if (string.IsNullOrEmpty(imagelink) && !update)
            {
                MessageBox.Show("Image path is not set.");
            }

            if (!string.IsNullOrEmpty(medicalpath) && medicalpath != medicalimg)
            {
                uploadImgM(medicalpath);
            }
            else if (string.IsNullOrEmpty(medicalimg) && !update)
            {
                MessageBox.Show("Medical image path is not set.");
            }

            if (!string.IsNullOrEmpty(policepath) && policepath != policeCimg)
            {
                uploadImgP(policepath);
            }
            else if (string.IsNullOrEmpty(policeCimg) && !update)
            {
                MessageBox.Show("Police image path is not set.");
            }

            if (!string.IsNullOrEmpty(brgypath) && brgypath != brgyCimg)
            {
                uploadImgB(brgypath);
            }
            else if (string.IsNullOrEmpty(brgyCimg) && !update)
            {
                MessageBox.Show("Barangay image path is not set.");
            }

            if (!string.IsNullOrEmpty(pagibigpath) && pagibigpath != Pagibigimg)
            {
                uploadImgPA(pagibigpath);
            }
            else if (string.IsNullOrEmpty(Pagibigimg) && !update)
            {
                MessageBox.Show("Pagibig image path is not set.");
            }

            if (!string.IsNullOrEmpty(ssspath) && ssspath != sssimg)
            {
                uploadImgSS(ssspath);
            }
            else if (string.IsNullOrEmpty(sssimg) && !update)
            {
                MessageBox.Show("SSS image path is not set.");
            }

            if (!string.IsNullOrEmpty(philpath) && philpath != philimg)
            {
                uploadImgPH(philpath);
            }
            else if (string.IsNullOrEmpty(philimg) && !update)
            {
                MessageBox.Show("Philhealth image path is not set.");
            }

            if (!string.IsNullOrEmpty(driverpath) && driverpath != driverimg)
            {
                uploadImgDL(driverpath);
            }
            else if (string.IsNullOrEmpty(driverimg) && !update)
            {
                MessageBox.Show("Driver License image path is not set.");
            }

            if (!string.IsNullOrEmpty(respath) && respath != resimg)
            {
                uploadImgRES(respath);
            }
            else if (string.IsNullOrEmpty(resimg) && !update)
            {
                MessageBox.Show("Resume image path is not set.");
            }

            if (!string.IsNullOrEmpty(curriculumpath) && curriculumpath != curriculumimg)
            {
                uploadImgCV(curriculumpath);
            }
            else if (string.IsNullOrEmpty(curriculumimg) && !update)
            {
                MessageBox.Show("Curriculum Vitae image path is not set.");
            }

            if (!string.IsNullOrEmpty(applicationpath) && applicationpath != applicationletimg)
            {
                uploadImgAP(applicationpath);
            }
            else if (string.IsNullOrEmpty(applicationletimg) && !update)
            {
                MessageBox.Show("Application Letter image path is not set.");
            }
            else if (string.IsNullOrEmpty(medicalimg))
            {
                MessageBox.Show("Medical image path is not set.");
            }

            if (!string.IsNullOrEmpty(policepath) && policepath != policeCimg)
            {
                uploadImgP(policepath);
            }
            else if (string.IsNullOrEmpty(policeCimg))
            {
                MessageBox.Show("Police image path is not set.");
            }

            if (!string.IsNullOrEmpty(brgypath) && brgypath != brgyCimg)
            {
                uploadImgB(brgypath);
            }
            else if (string.IsNullOrEmpty(brgyCimg))
            {
                MessageBox.Show("Barangay image path is not set.");
            }

            if (!string.IsNullOrEmpty(pagibigpath) && pagibigpath != Pagibigimg)
            {
                uploadImgPA(pagibigpath);
            }
            else if (string.IsNullOrEmpty(Pagibigimg))
            {
                MessageBox.Show("Pagibig image path is not set.");
            }

            if (!string.IsNullOrEmpty(ssspath) && ssspath != sssimg)
            {
                uploadImgSS(ssspath);
            }
            else if (string.IsNullOrEmpty(sssimg))
            {
                MessageBox.Show("SSS image path is not set.");
            }

            if (!string.IsNullOrEmpty(philpath) && philpath != philimg)
            {
                uploadImgPH(philpath);
            }
            else if (string.IsNullOrEmpty(philimg))
            {
                MessageBox.Show("Philhealth image path is not set.");
            }

            if (!string.IsNullOrEmpty(driverpath) && driverpath != driverimg)
            {
                uploadImgDL(driverpath);
            }
            else if (string.IsNullOrEmpty(driverimg))
            {
                MessageBox.Show("Driver License image path is not set.");
            }

            if (!string.IsNullOrEmpty(respath) && respath != resimg)
            {
                uploadImgRES(respath);
            }
            else if (string.IsNullOrEmpty(resimg))
            {
                MessageBox.Show("Resume image path is not set.");
            }

            if (!string.IsNullOrEmpty(curriculumpath) && curriculumpath != curriculumimg)
            {
                uploadImgCV(curriculumpath);
            }
            else if (string.IsNullOrEmpty(curriculumimg))
            {
                MessageBox.Show("Curriculum Vitae image path is not set.");
            }

            if (!string.IsNullOrEmpty(applicationpath) && applicationpath != applicationletimg)
            {
                uploadImgAP(applicationpath);
            }
            else if (string.IsNullOrEmpty(applicationletimg))
            {
                MessageBox.Show("Application Letter image path is not set.");
            }

        }

        [Obsolete]

        private void uploadImgAP(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            applicationletimg = res.Uri.ToString();

        }

        [Obsolete]

        private void uploadImgCV(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            curriculumimg = res.Uri.ToString();

        }

        [Obsolete]

        private void uploadImgRES(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            resimg = res.Uri.ToString();

        }



        [Obsolete]

        private void uploadImgDL(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            driverimg = res.Uri.ToString();

        }



        [Obsolete]

        private void uploadImgPH(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            philimg = res.Uri.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label30.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox9.Image = new Bitmap(openFileDialog.FileName);
                medicalpath = openFileDialog.FileName;
            }
        }

    
        [Obsolete]

        private void uploadImgSS(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            sssimg = res.Uri.ToString();

        }

        private void EmpInfo_Load(object sender, EventArgs e)
        {
            
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            if (UserControl1.view == true)
            {
                getDetail();
                update = true;
                button4.Text = "UPDATE";
                timer1.Enabled = false;

            }
            else
            {


                button4.Text = "SAVE";
                update = false;
            }
        }

        [Obsolete]

        private void uploadImgPA(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            Pagibigimg = res.Uri.ToString();

        }



        [Obsolete]

        private void uploadImgM(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            medicalimg = res.Uri.ToString();

        }

        [Obsolete]

        private void uploadImgP(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            policeCimg = res.Uri.ToString();

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox10.Image = new Bitmap(openFileDialog.FileName);
                policepath = openFileDialog.FileName;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox12.Image = new Bitmap(openFileDialog.FileName);
                brgypath = openFileDialog.FileName;
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox11.Image = new Bitmap(openFileDialog.FileName);
                pagibigpath = openFileDialog.FileName;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox13.Image = new Bitmap(openFileDialog.FileName);
                ssspath = openFileDialog.FileName;
            }
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox28.Image = new Bitmap(openFileDialog.FileName);
                philpath = openFileDialog.FileName;
            }
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox27.Image = new Bitmap(openFileDialog.FileName);
                driverpath = openFileDialog.FileName;
            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox19.Image = new Bitmap(openFileDialog.FileName);
                respath = openFileDialog.FileName;
            }
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox25.Image = new Bitmap(openFileDialog.FileName);
                curriculumpath = openFileDialog.FileName;
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox24.Image = new Bitmap(openFileDialog.FileName);
                applicationpath = openFileDialog.FileName;
            }
        }

        private void label37_Click(object sender, EventArgs e)
        {
            DashForm emps = new DashForm();
            emps.Show();
            this.Close();
        }

        private void label36_Click(object sender, EventArgs e)
        {
            EmpPro emps = new EmpPro();
            emps.Show();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            LeaveForm emps = new LeaveForm();
            emps.Show();
            this.Close();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            WelcomeForm emps = new WelcomeForm();
            emps.Show();
            this.Close();
        }

        private void label39_Click(object sender, EventArgs e)
        {
            AdminSett adminSett = new AdminSett();
            adminSett.ShowDialog();
            
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (AdminSett.Deleted == true)
            {
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox8.Image = new Bitmap(openFileDialog.FileName);
                imagepath = openFileDialog.FileName;
            }
        }

        [Obsolete]

        private void uploadImgB(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            brgyCimg = res.Uri.ToString();

        }

        [Obsolete]

        private void uploadImg(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var res = cloud.Upload(uploadParams);
            imagelink = res.Uri.ToString();

        }




        [Obsolete]
        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            cloudinaryStorage();
        }


        bool update = false;
        public static bool refresh = false;
        public static bool isUpdate = false;



        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            if (update == false)
            {
                if (!string.IsNullOrEmpty(imagelink))
                {
                    ClassCard save = new ClassCard();
                    save.empid = textBox4.Text;
                    save.empFN = textBox2.Text;
                    save.empLN = textBox1.Text;
                    save.position = textBox3.Text;
                    save.image = imagelink;
                    save.gender = (string)comboBox1.SelectedItem;
                    save.religion = textBox7.Text;
                    save.dob = dateTimePicker1.Text;
                    save.contact = textBox9.Text;
                    save.email = textBox5.Text;
                    save.civilstat = (string)comboBox2.SelectedItem;
                    save.citizenship = textBox6.Text;
                    save.lang = textBox8.Text;
                    save.FatherFN = textBox16.Text;
                    save.FatherLN =textBox18.Text;
                    save.MotherLN = textBox17.Text;
                    save.MotherFN = textBox10.Text;
                    save.fatherO = textBox12.Text;
                    save.motherO = textBox11.Text;
                    save.Fcontact = textBox14.Text;
                    save.Mcontact = textBox13.Text;
                    save.pce = (string)comboBox3.SelectedItem;
                    save.medical = medicalimg;
                    save.policeC = policeCimg;
                    save.brgyC = brgyCimg;
                    save.pagibig = Pagibigimg;
                    save.sss = sssimg;
                    save.philhealth = philimg;
                    save.driverLic = driverimg;
                    save.res = resimg;
                    save.curriculum = curriculumimg;
                    save.applicationlet = applicationletimg;
                    save.DateHired = DateTime.Now.ToString("MMMM dd, yyyy");
                    save.Eaddress = textBox15.Text;
                    save.department = (string)comboBox4.SelectedItem;
                    save.Save();
                    refresh = true;
                }
                else
                {
                    MessageBox.Show("Image upload failed. Data not saved.");
                }
            }
            else
            {
                ClassCard up = new ClassCard();
                if (UserControl1.pubId != null && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
                {
                    up.update(textBox4.Text, textBox2.Text, textBox1.Text, textBox3.Text, imagelink, UserControl1.pubId, comboBox1.SelectedItem.ToString(), textBox7.Text, dateTimePicker1.Text, textBox9.Text, textBox5.Text, comboBox2.SelectedItem.ToString(), textBox6.Text, textBox8.Text, textBox16.Text, textBox18.Text, textBox12.Text, textBox10.Text, textBox17.Text, textBox11.Text, textBox13.Text, textBox14.Text, comboBox3.SelectedItem.ToString(), textBox15.Text, comboBox4.SelectedItem.ToString()) ;
                    up.updateEreq(textBox4.Text, medicalimg, policeCimg, brgyCimg, Pagibigimg, sssimg, philimg, driverimg, resimg, curriculumimg, applicationletimg);
                    isUpdate = true;
                    refresh = true;

                }

                else
                {
                    MessageBox.Show("Some required fields are missing.");
                }


            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (UserControl1.view == true)
            {

                imagelink = pictureBox8.ImageLocation;
                medicalimg = pictureBox9.ImageLocation;
                policeCimg = pictureBox10.ImageLocation;
                brgyCimg = pictureBox12.ImageLocation;
                Pagibigimg = pictureBox11.ImageLocation;
                sssimg = pictureBox13.ImageLocation;
                philimg = pictureBox28.ImageLocation;
                driverimg = pictureBox27.ImageLocation;
                resimg = pictureBox19.ImageLocation;
                curriculumimg = pictureBox25.ImageLocation;
                applicationletimg = pictureBox24.ImageLocation;

            }

            if (!backgroundWorker1.IsBusy)
            {

                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Processing. Please wait.");
            }
        }

    

        private void getDetail()
        {
            ClassCard get = new ClassCard();
            get.getDetails(UserControl1.pubId);
            textBox4.Text = get.empid;
            textBox2.Text = get.empFN;
            textBox1.Text = get.empLN;
            textBox3.Text = get.position;
            comboBox1.SelectedItem = get.gender;
            textBox7.Text = get.religion;
            dateTimePicker1.Text = get.dob;
            textBox9.Text = get.contact;
            textBox5.Text = get.email;
            comboBox2.SelectedItem = get.civilstat;
            textBox6.Text = get.citizenship;
            textBox8.Text = get.lang;
            textBox16.Text = get.FatherFN;
            textBox18.Text = get.FatherLN;
            textBox10.Text = get.MotherFN;
            textBox17.Text = get.MotherLN;
            textBox12.Text = get.fatherO;
            textBox11.Text = get.motherO;
            textBox14.Text = get.Fcontact;
            textBox13.Text = get.Mcontact;
            comboBox3.SelectedItem = get.pce;
            pictureBox8.ImageLocation = get.image;
            pictureBox9.ImageLocation = get.medical;
            pictureBox10.ImageLocation = get.policeC;
            pictureBox12.ImageLocation = get.brgyC;
            pictureBox11.ImageLocation = get.pagibig;
            pictureBox13.ImageLocation = get.sss;
            pictureBox28.ImageLocation = get.philhealth;
            pictureBox27.ImageLocation = get.driverLic;
            pictureBox19.ImageLocation = get.res;
            pictureBox25.ImageLocation = get.curriculum;
            pictureBox24.ImageLocation = get.applicationlet;
            label30.Text = get.DateHired;
            textBox15.Text = get.Eaddress;
            comboBox4.SelectedItem = get.department;

        }


        private void pictureBox8_Click(object sender, EventArgs e)
        {

            

        }
        








        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            EmpInfo mps = new EmpInfo();
            mps.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
           
        }



















































        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
