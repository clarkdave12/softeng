using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace libraryForm.Controllers
{
    class CoursesController
    {
        public static List<Course> GetCourses()
        {
            List<Course> course = new List<Course>();

            Connection.OpenConnection();

            using (SqlCommand cmd = Connection.conn.CreateCommand())
            {
                cmd.CommandText = "GetCourses";
                Connection.conn.Open();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        course.Add(new Course() { 
                            courseCode = reader[0].ToString(),
                            courseName = reader[1].ToString()
                        });
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                Connection.conn.Close();
            }

            return course;
        }
    }
}
