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
    class patient:person
    {
        ConnSingleton cs = ConnSingleton.getDbInstance();
        protected string Disease_description { get; set; }
        protected string Doctor_name { get; set; }
        public  Display displays;

        public patient() { }

        public patient(string name, string address, string sex, string age, string Disease_description, string Doctor_name)
            : base(name, address, sex, age)
        {
            this.Disease_description = Disease_description;
            this.Doctor_name = Doctor_name;

        }

        public override void add(string name,string Date, string address, string age, bool radioButton, string Disease_description, string Doctor_name, string type, string room_number)
        {

          
            SqlCommand addpatient = new SqlCommand(@"INSERT INTO patient_(Name,Address,Age,Sex,Normal_Patients, Emergency_Patient, Room_Number, Doctor_Name, Disease_description,Date) 
                                    VALUES (@Name,@Address,@Age,@Sex,@Normal_Patients,@Emergency_Patient,@Room_Number,@Doctor_Name,@Disease_description,@Date)", cs.GetDBConnection());
           
                addpatient.Parameters.AddWithValue("@Name", name);
                addpatient.Parameters.AddWithValue("@Address", address);
                addpatient.Parameters.AddWithValue("@Age", age);
                addpatient.Parameters.AddWithValue("@Disease_description", Disease_description);


                if (radioButton == true)
                    addpatient.Parameters.AddWithValue("@sex", "Female");
                else
                    addpatient.Parameters.AddWithValue("@sex", "Male");

                if (type == "Normal patients")
                {
                    addpatient.Parameters.AddWithValue("@Normal_Patients", "true");
                    addpatient.Parameters.AddWithValue("@Emergency_Patient", "false");
                    addpatient.Parameters.AddWithValue("@Room_Number", room_number);
                }

                else if (type == "Emergency patients")
                {
                    addpatient.Parameters.AddWithValue("@Emergency_Patient", "true");
                    addpatient.Parameters.AddWithValue("@Normal_Patients", "false");
                    addpatient.Parameters.AddWithValue("@Room_Number", "NULL");
                }

                addpatient.Parameters.AddWithValue("@Doctor_Name", Doctor_name);
                addpatient.Parameters.AddWithValue("@Date", Date);
           
            addpatient.ExecuteNonQuery();
            MessageBox.Show("Inserting success");
            cs.CloseConnection();
        }
    
        public override void Delete(DataGridView dv)
        {
            
            SqlCommand cmd = new SqlCommand();
            if (dv.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dv.SelectedRows.Count; i++)
                {

                    cmd.CommandText = "DELETE FROM patient_ WHERE ID=" + dv.SelectedRows[i].Cells[0].Value.ToString() + "";
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
            int ID = 0, Age = 0;
            string Room_Number = "",Date="",Name = "", Address = "", sex = "", Doctor_Name = "", Disease_description = "";
            for (int r = 0; r < dv.Rows.Count - 1; r++)
            {

                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                ID = Int32.Parse(dv.Rows[r].Cells[0].Value.ToString());
                Name = dv.Rows[r].Cells[1].Value.ToString();
                Address = dv.Rows[r].Cells[2].Value.ToString();
                Age = Int32.Parse(dv.Rows[r].Cells[3].Value.ToString());
                sex = dv.Rows[r].Cells[4].Value.ToString();
                Date = dv.Rows[r].Cells[5].Value.ToString();  
                Doctor_Name = dv.Rows[r].Cells[6].Value.ToString();
                Disease_description = dv.Rows[r].Cells[7].Value.ToString();
                if (dv.Columns.Count == 9)
                {
                    Room_Number = dv.Rows[r].Cells[8].Value.ToString();
                    cmd.CommandText = @"UPDATE patient_ SET Name=@Name,Date=@Date,Address=@Address,Age=@Age,sex=@sex,Doctor_Name=@Doctor_Name,Disease_description=@Disease_description,Room_Number=@Room_Number WHERE ID=@ID";

                }

                cmd.CommandText = @"UPDATE patient_ SET Name=@Name,Date=@Date,Address=@Address,Age=@Age,sex=@sex,Doctor_Name=@Doctor_Name,Disease_description=@Disease_description WHERE ID=@ID";

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.Parameters.AddWithValue("@Doctor_Name", Doctor_Name);
                cmd.Parameters.AddWithValue("@Disease_description", Disease_description);
                cmd.Parameters.AddWithValue("@Date", Date);
                if(Room_Number!=null)
                cmd.Parameters.AddWithValue("@Room_Number", Room_Number);
                cmd.Connection = cs.GetDBConnection();
                cmd.ExecuteNonQuery();
                cs.CloseConnection();
            }


           
            MessageBox.Show("Updated success.");
           
        }
    /*   public override void show(DataGridView dv)
        {
            
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

            info.Columns.Add("Normal_Patients");
            info.Columns.Add("Emergency_Patient");
            info.Columns.Add("Room_Number");
            info.Columns.Add("Doctor_Name");
            info.Columns.Add("Disease_description");

            DataRow row;
            while (reader.Read())
            {
                row = info.NewRow();
                row["ID"] = reader["ID"];
                row["Name"] = reader["Name"];
                row["Address"] = reader["Address"];
                row["Age"] = reader["Age"];
                row["sex"] = reader["Sex"];
                row["Normal_Patients"] = reader["Normal_Patients"];
                row["Emergency_Patient"] = reader["Emergency_Patient"];
                row["Room_Number"] = reader["Room_Number"];
                row["Doctor_Name"] = reader["Doctor_Name"];
                row["Disease_description"] = reader["Disease_description"];
                row["Date"] = reader["Date"];
                info.Rows.Add(row);
            }
            reader.Close();
            cs.CloseConnection();
            dv.DataSource = info;
        }*/
        
    }
    
    class Emergency_patient : patient
    {
     public  Emergency_patient()
        {

        }
        public Emergency_patient(string name, string address, string sex, string age, string Disease_description, string Doctor_name)
            : base(name, address, sex, age, Disease_description, Doctor_name) { }
        public void Excute_strategy(DataGridView dv)
        {
            displays = new Display_Emer();
            displays.display( dv);
   
        }
    }
    class Normal_patient : patient
    {
      
       public Normal_patient()
        {

        }
        protected int Room_number { get; set; }
        public Normal_patient(string name, string address, string sex, string age, string Disease_description, string Doctor_name, int Room_number)
            : base(name, address, sex, age, Disease_description, Doctor_name)
        {
            this.Room_number = Room_number;
        }
        public void Excute_strategy( DataGridView dv)
        {
            displays = new Display_Normal();
            displays.display( dv);
   
        }
    }

}
