using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


using libraryForm.Validations;

namespace libraryForm.Controllers
{
    class LoginController
    {
        private string username = null;
        private string password = null;

        public LoginController(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public static bool Login()
        {
            string username = "test";
            string pass = "123";

            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UserLogin";
                    cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.AddWithValue("@pass", SqlDbType.VarChar).Value = pass;

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    try
                    {
                        int userCount = (int) cmd.ExecuteScalar();
                        conn.Close();
                        return true;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    conn.Close();
                    return false;
                }
        }
    }
}
