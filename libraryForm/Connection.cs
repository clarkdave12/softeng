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

        public void OpenConnection()
        {
            conn = new SqlConnection("Data Source=(LocalDb)\\LocalDB;Initial Catalog=master;Integrated Security=True");
            conn.Open();
        }

        public void CloseConnection()
        {
            conn.Close();
        }
    }
}
