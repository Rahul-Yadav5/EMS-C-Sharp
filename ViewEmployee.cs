using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace EMSP
{
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Empview()
        {
            try
            {

                string MyConnection2 = "server=localhost;user id=root;database=ems_db";
                //Display query
                string Query = "select * from employees Where EmpId='" + EmpIdsearch.Text + "'";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                foreach (DataRow dr in dTable.Rows)
                {
                    EmpId.Text = dr["EmpId"].ToString();
                    EmpName.Text = dr["EmpName"].ToString();
                    EmpAdd.Text = dr["EmpAdd"].ToString();
                    EmpPos.Text = dr["EmpPos"].ToString();
                    EmpDOB.Text = dr["EmpDOB"].ToString();
                    EmpPhone.Text = dr["EmpPhone"].ToString();
                    EmpEdu.Text = dr["EmpEdu"].ToString();
                    EmpGen.Text = dr["EmpGen"].ToString(); 


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        
        private void ViewEmployee_Load(object sender, EventArgs e)
        {

           




        
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Empview();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void EmpIdsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmpIdsearch.Clear();
            EmpId.Clear();
            EmpName.Clear();
            EmpAdd.Clear();
            EmpPos.ResetText();
            EmpDOB.ResetText();
            EmpPhone.Clear();
            EmpEdu.ResetText();
            EmpGen.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("======EMPLOYEE SUMMERY=====", new Font("century Gothics", 20, FontStyle.Bold), Brushes.Red, new Point(180));
            e.Graphics.DrawString("Employee ID:"+EmpId.Text , new Font("century Gothics",  25, FontStyle.Regular), Brushes.Blue, new Point(10,100));
            e.Graphics.DrawString("Employee Name :" + EmpName.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 145));
            e.Graphics.DrawString("Employee Address:" + EmpAdd.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 190));
            e.Graphics.DrawString("Employee Gender:" + EmpGen.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 235));
            e.Graphics.DrawString("Employee Position:" + EmpPos.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 280));
            e.Graphics.DrawString("Employee DOB:" + EmpDOB.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 325));
            e.Graphics.DrawString("Employee Phone:" + EmpPhone.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 370));
            e.Graphics.DrawString("Employee Education:" + EmpEdu.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 415));
            e.Graphics.DrawString("======Empisofts=====", new Font("century Gothics", 20, FontStyle.Bold), Brushes.Red, new Point(180,500));
        }

    }
}
