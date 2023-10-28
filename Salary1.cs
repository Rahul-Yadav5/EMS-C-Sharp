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
    public partial class Salary1 : Form
    {
        public Salary1()
        {
            InitializeComponent();
        }
        private void Empfatch()
        {
            try
            {

                string MyConnection2 = "server=localhost;user id=root;database=ems_db";
                //Display query
                string Query = "select * from employees Where EmpId='" + EmpId.Text + "'";
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
                    //EmpId.Text = dr["EmpId"].ToString();
                    EmpName.Text = dr["EmpName"].ToString();
                     EmpPos.Text = dr["EmpPos"].ToString();
                   


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Salary1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EmpName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmpId.Clear();
            EmpName.Clear();
            WorkDay.Clear();
            EmpPos.Clear();
            Slip.Clear();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Empfatch();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        int Dailybase,total;
        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpPos.Text == "")
            {
                MessageBox.Show("Select An Employee");
            }
            else if (WorkDay.Text == "" || Convert.ToInt32(WorkDay.Text) > 28)
            {
                MessageBox.Show("Enter A Valid Number Of Days");
            }
            else
            {
                if (EmpPos.Text == "Manager")
                {
                    Dailybase = 1500;
                }
                else if (EmpPos.Text == "Senior Developper")
                {
                    Dailybase = 1350;
                }
                else if (EmpPos.Text == "Junior Developper ")
                {
                    Dailybase = 1400;
                }
                else if (EmpPos.Text == "Accountant ")
                {
                    Dailybase = 1350;
                }
                else if (EmpPos.Text == "Receptionist ")
                {
                    Dailybase = 1300;
                }else
                { 
                    Dailybase=1000;
                }
                total = Dailybase * Convert.ToInt32(WorkDay.Text);
                Slip.Text = "Employee Id:" + EmpId.Text + "\n" + "Employee Name:"+ EmpName.Text + "\n" + "Days Worked: "+ WorkDay.Text + "\n" + "Employee Position:" + EmpPos.Text + "\n" + "Daily Salary:" + Dailybase + "\n" + "Total Amount Rs:" + total;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("======SALARY DOCUMENT=====", new Font("century Gothics", 20, FontStyle.Bold), Brushes.Red, new Point(180));
            e.Graphics.DrawString("Employee ID:" + EmpId.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 100));
            e.Graphics.DrawString("Employee Name :" + EmpName.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 145));
            e.Graphics.DrawString("Employee Position:" + EmpPos.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 280));
            e.Graphics.DrawString("Worked Days:" + WorkDay.Text, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 190));
            e.Graphics.DrawString("Daily Pay:" + Dailybase, new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 235));
            e.Graphics.DrawString("Total Salary :" + total , new Font("century Gothics", 25, FontStyle.Regular), Brushes.Blue, new Point(10, 325));
           
            e.Graphics.DrawString("======Empisofts=====", new Font("century Gothics", 20, FontStyle.Bold), Brushes.Red, new Point(180, 500));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
