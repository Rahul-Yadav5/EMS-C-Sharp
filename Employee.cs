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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
             
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            gridview(); 
                    
        }

        private void EmpDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
              if (EmpId.Text != "" && EmpName.Text != "" && EmpAdd.Text != "" && EmpPos.Text != "" && EmpDOB.Text != "" && EmpEdu.Text != "" && EmpPhone.Text != "" && EmpGen.Text != "")
            {
                try
                {
                    //This is my connection string i have assigned the database file address path
                    string MyConnection2 = "server=localhost;user id=root;database=ems_db";
                    //This is my insert query in which i am taking input from the user through windows forms
                    string Query = "insert into employees (EmpId,EmpName,EmpAdd,EmpPos,EmpDOB,EmpEdu,EmpPhone,EmpGen) values('" + this.EmpId.Text + "','" + this.EmpName.Text + "','" + this.EmpAdd.Text + "','" + this.EmpPos.SelectedItem.ToString() + "','" + this.EmpDOB.Text + "','" + this.EmpEdu.SelectedItem.ToString() + "','" + this.EmpPhone.Text + "','" + this.EmpGen.SelectedItem.ToString() + "');";
                    //This is  MySqlConnection here i have created the object and pass my connection string.
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    //This is command class which will handle the query and connection object.
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                    MessageBox.Show("Save Data");
                    while (MyReader2.Read())
                    {
                    }
                    gridview();
                    MyConn2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } 
            else
            {
                MessageBox.Show("Missing Information");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path
                string MyConnection2 = "server=localhost;user id=root;database=ems_db";
                //This is my update query in which i am taking input from the user through windows forms and update the record.
                string Query = "update employees set EmpId='" + this.EmpId.Text + "',EmpName='" + this.EmpName.Text + "',EmpAdd='" + this.EmpAdd.Text + "',EmpPos='" + this.EmpPos.Text + "',EmpDOB='" + this.EmpDOB.Text + "',EmpDOB='" + this.EmpDOB.Text + "',EmpPhone='" + this.EmpPhone.Text + "',EmpEdu='" + this.EmpEdu.Text + "',EmpGen='" + this.EmpGen.Text + "' where id='" + this.id.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                gridview();
                MyConn2.Close();//Connection closed here
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
              try
            {
                string MyConnection2 = "server=localhost;user id=root;database=ems_db";
                string Query = "delete from employees where Id='" + this.id.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Deleted");
                while (MyReader2.Read())
                {
                }
                gridview();
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridview()
        {
            try
            {
                string MyConnection2 = "server=localhost;user id=root;database=ems_db";
                //Display query
                string Query = "select * from employees;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.
                                                   // MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             dataGridView1.CurrentRow.Selected = true;
            id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            EmpId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            EmpName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            EmpAdd.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            EmpPos.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            EmpDOB.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            EmpPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            EmpEdu.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            EmpGen.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmpId.Clear();
            EmpName.Clear();
            EmpAdd.Clear();
            EmpPos.ResetText();
            EmpDOB.ResetText();
            EmpPhone.Clear();
            EmpEdu.ResetText();
             EmpGen.ResetText();
        }

        private void EmpName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void EmpPos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
