using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace libraryForm
{
    class Connection
    {
        public static SqlConnection conn = null;

        public static void OpenConnection()
        {
            conn = new SqlConnection("Data Source=(Local)\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");
            conn.Open();
        }

        public static void CloseConnection()
        {
            conn.Close();
        }
    }
}
