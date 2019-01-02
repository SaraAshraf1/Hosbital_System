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
using System.Data;
namespace Hospital_System
{ 
    
    public partial class Form4 : Form
    {

        doctor obj1 = new doctor();
        patient obj2 = new patient();
        

        
        public Form4()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Normal_patient n = new Normal_patient();
            n.Excute_strategy(dataGridView1);
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
           

           obj1.show(dataGridView2);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
           obj2.Delete(dataGridView1);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
          

            obj1.Delete(dataGridView2);
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
           
            obj2.Update(dataGridView1);
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
           

           obj1.Update(dataGridView2);
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 neew = new Form1();
            neew.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 neew = new Form1();
            neew.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Emergency_patient e1 = new Emergency_patient();
            e1.Excute_strategy(dataGridView1);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
       
    }
}
