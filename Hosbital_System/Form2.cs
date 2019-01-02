using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_System
{
   
    public partial class Form2 : Form
    {


        doctor obj1 = new doctor();
        patient obj2 = new patient();
        public Form2()
        {
            
            InitializeComponent();
            display();
        }
       
        
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 neew = new Form1();
            neew.Show();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
           

            string doctor_name = "";
            string type = comboBox4.SelectedItem.ToString();
            string room_num = "";
            string date = "";

           obj1.add(textBox6.Text, date, textBox5.Text, textBox8.Text, radioButton4.Checked, textBox4.Text, doctor_name, type, room_num);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
           
            string doctor_name=comboBox2.SelectedItem.ToString();
            string roomNum = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : "";
            comboBox1.Items.Remove(comboBox1.SelectedItem);
            obj2.add(textBox1.Text,dateTimePicker1.Value.ToShortDateString(), textBox2.Text, textBox7.Text, radioButton1.Checked, textBox3.Text, doctor_name, comboBox3.SelectedItem.ToString(), roomNum);

            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Form3 Girdview = new Form3();
            Girdview.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 neew = new Form1();
            neew.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Girdview = new Form3();
            Girdview.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 neew = new Form1();
            neew.Show();
        }
        void display()
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J2F795J\\SQLEXPRESS;Initial Catalog=hospital_system;Integrated Security=True");
            con.Open();
            SqlCommand sqlCmd = new SqlCommand("SELECT Name FROM Doctor_", con);

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {

                comboBox2.Items.Add(sqlReader["Name"].ToString());
            }

            sqlReader.Close();
            con.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
