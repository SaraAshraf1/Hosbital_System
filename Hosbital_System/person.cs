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
    abstract class person
    {
        protected string name { get; set; }
        protected string address { get; set; }
        protected string sex { get; set; }
        protected string age { get; set; }
        public person() { }
        public person(string name, string address, string sex, string age)
        {
            this.name = name;
            this.address = address;
            this.sex = sex;
            this.age = age;
        }
        public virtual void add(string name,string Date, string address, string age, bool radioButton, string Disease_description, string Doctor_name, string type, string room_number) { }
        public virtual void show(DataGridView dv) { }
        public virtual void Delete(DataGridView dv) { }
        public virtual void Update(DataGridView dv) { }
    }
    //class Emergency_patient : patient
    //{
    //    public Emergency_patient(string name, string address, string sex, string age, string Disease_description, string Doctor_name)
    //        : base(name, address, sex, age, Disease_description, Doctor_name) { }

    //}
    //class Normal_patient : patient
    //{
    //    protected int Room_number { get; set; }
    //    public Normal_patient(string name, string address, string sex, string age, string Disease_description, string Doctor_name, int Room_number)
    //        : base(name, address, sex, age, Disease_description, Doctor_name)
    //    {
    //        this.Room_number = Room_number;
    //    }
    //}
}
