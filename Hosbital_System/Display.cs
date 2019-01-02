using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace Hospital_System
{
    
   abstract class Display //------------------------------------->strategy 
    {
        abstract public void display( DataGridView dv);
       
    }
    class Display_Normal:Display
    {
        
        public override void display(DataGridView  dv)
        {
            ConnSingleton cs = ConnSingleton.getDbInstance();
            SqlCommand cmd = new SqlCommand("Select * from patient_ ORDER BY Name", cs.GetDBConnection());
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable info = new DataTable();
            info.Columns.Add("ID");
            info.Columns.Add("Name");
            info.Columns.Add("Address");
            info.Columns.Add("Age");
            info.Columns.Add("sex");
            info.Columns.Add("Date");
            
            info.Columns.Add("Doctor_Name");
            info.Columns.Add("Disease_description");
            info.Columns.Add("Room_Number");

            DataRow row;
            while (reader.Read())
            {
               
                if (reader["Room_Number"].ToString() != "NULL      ")
                {
                    row = info.NewRow();
                    row["ID"] = reader["ID"];
                    row["Name"] = reader["Name"];
                    row["Address"] = reader["Address"];
                    row["Age"] = reader["Age"];
                    row["sex"] = reader["Sex"];
                    row["Doctor_Name"] = reader["Doctor_Name"];
                    row["Disease_description"] = reader["Disease_description"];
                    row["Date"] = reader["Date"];
                    row["Room_Number"] = reader["Room_Number"];
               
                    info.Rows.Add(row);
                }
                
            }
            reader.Close();
            cs.CloseConnection();
            dv.DataSource = info;// <-------
          

        }
        
    }
    class Display_Emer:Display
    {
        public override void display( DataGridView dv)
        {     
            ConnSingleton cs = ConnSingleton.getDbInstance();
            SqlCommand cmd = new SqlCommand("Select * from patient_ ORDER BY Name", cs.GetDBConnection());
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable info = new DataTable();
            info.Columns.Add("ID");
            info.Columns.Add("Name");
            info.Columns.Add("Address");
            info.Columns.Add("Age");
            info.Columns.Add("sex");
            info.Columns.Add("Date");
            info.Columns.Add("Doctor_Name");
            info.Columns.Add("Disease_description");

            DataRow row;
            while (reader.Read())
            {
                
                if (reader["Room_Number"].ToString() == "NULL      ")
                {
                    row = info.NewRow();
                    row["ID"] = reader["ID"];
                    row["Name"] = reader["Name"];
                    row["Address"] = reader["Address"];
                    row["Age"] = reader["Age"];
                    row["sex"] = reader["Sex"];
                    row["Doctor_Name"] = reader["Doctor_Name"];
                    row["Disease_description"] = reader["Disease_description"];
                    row["Date"] = reader["Date"];
                    info.Rows.Add(row);
                }
            }
            reader.Close();
            cs.CloseConnection();
            dv.DataSource = info;
        }
    }
}
