using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.Sql;

namespace Hospital_System
{
    [Serializable]
    class doctor:person
    {
        ConnSingleton cs = ConnSingleton.getDbInstance();
        protected string Specialist { get; set; }
        protected string Type { get; set; }
        
        public doctor() { }
        public doctor(string name, string address, string sex, string age, string Specialist, string Type)
            : base(name, address, sex, age)
        {
            this.Specialist = Specialist;
            this.Type = Type;
        }
        

        public override void add(string name,string Date, string address, string age, bool radioButton, string Specialist, string Doctor_name, string type, string room_number)
        {

            SqlCommand adddoc = new SqlCommand(@"INSERT INTO Doctor_(Name,Address,Age,Sex,Specialist,General_doctor) VALUES (@Name,@Address,@Age,@Sex,@Specialist,@General_doctor)", cs.GetDBConnection());
            adddoc.Parameters.AddWithValue("@Name", name);
            adddoc.Parameters.AddWithValue("@Address", address);
            adddoc.Parameters.AddWithValue("@Age", age);
            if (radioButton == true)
                adddoc.Parameters.AddWithValue("@Sex", "Female");
            else
                adddoc.Parameters.AddWithValue("@Sex", "Male");
                if (type == "Specialist")
                {

                    adddoc.Parameters.AddWithValue("@General_doctor ", "false");
                    adddoc.Parameters.AddWithValue("@Specialist", Specialist);
                }

                else
                {
                    adddoc.Parameters.AddWithValue("@General_doctor ", "true");
                    adddoc.Parameters.AddWithValue("@Specialist", "Null");
                }

                adddoc.Parameters.AddWithValue("@Doctor_Name", Doctor_name);
           
            adddoc.ExecuteNonQuery();
           
            
            MessageBox.Show("Inserting success");
            cs.CloseConnection();
        }
        public override void show(DataGridView dv)
        {
           
            SqlCommand cmd = new SqlCommand("Select ID,Name,Address,Age,sex,Specialist,General_doctor from Doctor_ ORDER BY Name", cs.GetDBConnection());
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable info = new DataTable();
            info.Columns.Add("ID");
            info.Columns.Add("Name");
            info.Columns.Add("Address");
            info.Columns.Add("Age");
            info.Columns.Add("sex");
            info.Columns.Add("Specialist");
            info.Columns.Add("General_doctor");
           

            DataRow row;
            while (reader.Read())
            {
                row = info.NewRow();
                row["ID"] = reader["ID"];
                row["Name"] = reader["Name"];
                row["Address"] = reader["Address"];
                row["Age"] = reader["Age"];
                row["sex"] = reader["Sex"];
                row["Specialist"] = reader["Specialist"];
                row["General_doctor"] = reader["General_doctor"];
              
                info.Rows.Add(row);
            }
            reader.Close();
            cs.CloseConnection();
            dv.DataSource = info;
        }
        public override void Delete(DataGridView dv)
        {
            
            SqlCommand cmd = new SqlCommand();
            if (dv.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dv.SelectedRows.Count; i++)
                {

                    cmd.CommandText = "DELETE FROM Doctor_ WHERE ID=" + dv.SelectedRows[i].Cells[0].Value.ToString() + "";
                    cmd.Connection = cs.GetDBConnection();
                    cmd.ExecuteNonQuery();
                    dv.Rows.RemoveAt(dv.SelectedRows[i].Index);
                    cs.CloseConnection();
                }
               
                MessageBox.Show("Deleted");

            }
        }
        public override void Update(DataGridView dv)
        {
            SqlCommand cmd = new SqlCommand();
            int ID = 0, Age = 0; string Name = "", Address = "", Sex = "", Specialist = "", General_doctor = "";
            for (int r = 0; r < dv.Rows.Count - 1; r++)
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                ID = Int32.Parse(dv.Rows[r].Cells[0].Value.ToString());
                Name = dv.Rows[r].Cells[1].Value.ToString();
                Address = dv.Rows[r].Cells[2].Value.ToString();
                Age = Int32.Parse(dv.Rows[r].Cells[3].Value.ToString());
                Sex = dv.Rows[r].Cells[4].Value.ToString();
                Specialist = dv.Rows[r].Cells[5].Value.ToString();
                General_doctor = dv.Rows[r].Cells[6].Value.ToString();
                

                cmd.CommandText = @"UPDATE Doctor_ SET Name=@Name,Address=@Address,Age=@Age,Sex=@Sex,Specialist=@Specialist,General_doctor=@General_doctor WHERE ID=@ID";

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Sex", Sex);
                cmd.Parameters.AddWithValue("@Specialist", Specialist);
                cmd.Parameters.AddWithValue("@General_doctor", General_doctor);
              

                cmd.Connection = cs.GetDBConnection();
                cmd.ExecuteNonQuery();
                cs.CloseConnection();
                
            }
            MessageBox.Show("Updated");
           
        }
       
    }
}
