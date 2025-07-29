using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Presentation
{
    public partial class Attendance_Report : Form
    {
        private DataTable dataTable;

        private string empName;
        private string empId;
        private string empTitle;
        private string empDepartment;
        private Image empImage;
        public Attendance_Report()
        {
            InitializeComponent();
        }

        private void Attendance_Report_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = dataTable;
        }


        public void SetData(DataTable dataTable, string empName, string empId, string empTitle, string empDepartment, Image empImage)
        {
            this.dataTable = dataTable;
            this.empName = empName;
            this.empId = empId;
            this.empTitle = empTitle;
            this.empDepartment = empDepartment;
            this.empImage = empImage;
            dataGridView1.DataSource = dataTable;

        }


        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Draw the header
            e.Graphics.DrawString("Attendance Report", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new PointF(350, 50));
            e.Graphics.DrawString($"Name: {empName}", new Font("Arial", 12), Brushes.Black, new PointF(50, 100));
            e.Graphics.DrawString($"ID: {empId}", new Font("Arial", 12), Brushes.Black, new PointF(50, 130));
            e.Graphics.DrawString($"Title: {empTitle}", new Font("Arial", 12), Brushes.Black, new PointF(50, 160));
            e.Graphics.DrawString($"Department: {empDepartment}", new Font("Arial", 12), Brushes.Black, new PointF(50, 190));

            // Draw the employee image
            if (empImage != null)
            {
                e.Graphics.DrawImage(empImage, new Rectangle(600, 100, 100, 100));
            }

            // Draw the DataGridView
            Bitmap bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            int x = (e.PageBounds.Width - dataGridView1.Width) / 2;
            int y = 250;
            e.Graphics.DrawImage(bitmap, x, y);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();

            }
        }
    }
}
