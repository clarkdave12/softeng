using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace libraryForm.Validations
{
    class AddStudentValidations
    {
        public static bool Validate(string studentNumber, string firstName, string lastName, string middleInitials, int gender, string courseCode)
        {
            if (studentNumber == "")
            {
                MessageBox.Show("Please enter a student number");
                return false;
            }
            else if(firstName == "")
            {
                MessageBox.Show("Please enter a first name");
                return false;
            }
            else if(lastName == "")
            {
                MessageBox.Show("Please enter a last name");
                return false;
            }
            else if(middleInitials == "")
            {
                MessageBox.Show("Please enter a middle initials");
                return false;
            }
            else if(gender < 0)
            {
                MessageBox.Show("Please choose a gender");
                return false;
            }
            else if(courseCode == "")
            {
                MessageBox.Show("Please choose a course");
                return false;
            }
            else if(CheckStudentNumber(studentNumber))
            {
                MessageBox.Show("This student number is already registered");
                return false;
            }
                

            return true;
        }

        // check if the student number is already registered
        public static bool CheckStudentNumber(string studentNumber)
        {
            Connection.OpenConnection();

            using (SqlCommand cmd = Connection.conn.CreateCommand())
            {
                cmd.CommandText = "SELECT count(*) FROM cl_students WHERE student_id=@studentNumber";
                cmd.Parameters.AddWithValue("@studentNumber", SqlDbType.VarChar).Value = studentNumber;

                if (Connection.conn.State == ConnectionState.Closed)
                    Connection.conn.Open();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        if(Convert.ToInt32(reader[0].ToString()) > 0)
                        {
                            Connection.conn.Close();
                            return true;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                Connection.conn.Close();
            }

            return false;
        }
    }
}
