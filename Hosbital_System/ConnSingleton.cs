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
   public class ConnSingleton
    {
       private static ConnSingleton dbInstance;
       private readonly SqlConnection conn = new SqlConnection("Data Source=DESKTOP-J2F795J\\SQLEXPRESS;Initial Catalog=hospital_system;Integrated Security=True");
        private ConnSingleton()
        {
        }
        public static ConnSingleton getDbInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new ConnSingleton();
            }
            return dbInstance;
        }
        public SqlConnection GetDBConnection()
        {
            try
            {
                conn.Open();
            }
            catch (SqlException e)
            {
            }
            return conn;
        }
        public SqlConnection CloseConnection()
        {
            try
            {
                conn.Close();
            }
            catch (SqlException e)
            {
            }
            return conn;
        }
    }
}
