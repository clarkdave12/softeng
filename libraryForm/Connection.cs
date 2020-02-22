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

        public static string ConnectionString = "Data Source=(LocalDb)\\LocalDB;Initial Catalog=master;Integrated Security=True";

        public static void OpenConnection()
        {
            conn = new SqlConnection(ConnectionString);
        }

        public static void CloseConnection()
        {
            conn.Close();
        }
    }
}
