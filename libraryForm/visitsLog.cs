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

namespace libraryForm
{
    public partial class visitsLog : Form
    {
        public visitsLog()
        {
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                int i;
                List<string> ID = new List<string>();
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT studentID, noID, dateTime FROM visitsLog ORDER BY logNumber DESC", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    i = 0;
                    while (reader.Read())
                    {
                        visitsGrid.Rows.Add();
                        ID.Add(reader[0].ToString());
                        visitsGrid.Rows[i].Cells[0].Value = ID[i];
                        if (!(bool)reader["noID"])
                            visitsGrid.Rows[i].Cells[2].Value = "With ID";
                        else
                            visitsGrid.Rows[i].Cells[2].Value = "No ID";
                        string[] dateTime = reader[2].ToString().Split('-');
                        visitsGrid.Rows[i].Cells[3].Value = dateTime[0];
                        visitsGrid.Rows[i].Cells[4].Value = dateTime[1].ToUpper();
                        i++;
                    }
                    reader.Close();
                }
                i = 0;
                while (i < ID.Count)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT lName, fName, mName FROM studentInfo where studentID = '" + ID[i] + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        visitsGrid.Rows[i].Cells[1].Value = reader[0].ToString() + ", " + reader[1].ToString() + " " + reader[2].ToString();
                        reader.Close();
                    }
                    i++;
                }
            }
        }
        public visitsLog(string studentID, string name)
        {
            InitializeComponent();

            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT noID, dateTime FROM visitsLog where studentID = '" + studentID + "'", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        visitsGrid.Rows.Add();
                        visitsGrid.Rows[i].Cells[0].Value = studentID;
                        visitsGrid.Rows[i].Cells[1].Value = name;
                        if (!(bool)reader["noID"])
                            visitsGrid.Rows[i].Cells[2].Value = "With ID";
                        else
                            visitsGrid.Rows[i].Cells[2].Value = "No ID";
                        string[] dateTime = reader[1].ToString().Split('-');
                        visitsGrid.Rows[i].Cells[3].Value = dateTime[0];
                        visitsGrid.Rows[i].Cells[4].Value = dateTime[1].ToUpper();
                        i++;
                    }
                }
            }
        }
    }
}
