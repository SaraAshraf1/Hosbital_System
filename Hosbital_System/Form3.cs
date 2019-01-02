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
    public partial class Form3 : Form
    {
        DataGridView dv;
        doctor obj = new doctor();
        public Form3( )
        {
            InitializeComponent();
            
        }

       
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Normal_patient n=new Normal_patient();
            n.Excute_strategy(dataGridView1);
            
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 neew = new Form1();
            neew.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
           obj.show(dataGridView2);
          
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 neew = new Form1();
            neew.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Emergency_patient e1 = new Emergency_patient();
            e1.Excute_strategy(dataGridView1);
            
        }
    }
}
