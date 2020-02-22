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
    class StudentsController
    {
        //
        // Add student record
        //
        public static void AddStudentRecord(string studentNumber, string lastName, string firstName, string middleInitials, int gender, string courseCode)
        {
            Connection.OpenConnection();
            
            using (SqlCommand cmd = Connection.conn.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Add_Students_StudentsInfo";

                cmd.Parameters.AddWithValue("@studentId", SqlDbType.VarChar).Value = studentNumber;
                cmd.Parameters.AddWithValue("@lastName", SqlDbType.VarChar).Value = lastName;
                cmd.Parameters.AddWithValue("@firstName", SqlDbType.VarChar).Value = firstName;
                cmd.Parameters.AddWithValue("@middleInitials", SqlDbType.VarChar).Value = middleInitials;
                cmd.Parameters.AddWithValue("@gender", SqlDbType.Bit).Value = gender;
                cmd.Parameters.AddWithValue("@courseCode", SqlDbType.VarChar).Value = courseCode;

                if (Connection.conn.State == ConnectionState.Closed)
                    Connection.conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student's record added successfully");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                Connection.conn.Close();
            }

        }

        //
        // Get students record
        //
        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            Connection.OpenConnection();

            using (SqlCommand cmd = Connection.conn.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetStudentRecords";


                if (Connection.conn.State == ConnectionState.Closed)
                    Connection.conn.Open();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        students.Add(new Student() { 
                            studentNumber = reader["student_id"].ToString(),
                            lastName = reader["last_name"].ToString(),
                            firstName = reader["first_name"].ToString(),
                            middleInitials = reader["middle_initials"].ToString(),
                            course = reader["course_code"].ToString(),
                            gender = reader["gender"].ToString()
                        });
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                Connection.conn.Close();
            }

            return students;
        }

        //
        // Method for Searching student record
        //
        public static List<Student> SearchStudent(string q)
        {
            List<Student> students = new List<Student>();

            Connection.OpenConnection();

            using (SqlCommand cmd = Connection.conn.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchStudent";

                cmd.Parameters.AddWithValue("@q", SqlDbType.VarChar).Value = q;

                if (Connection.conn.State == ConnectionState.Closed)
                    Connection.conn.Open();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        students.Add(new Student() { 
                            studentNumber = reader["student_id"].ToString(),
                            lastName = reader["last_name"].ToString(),
                            firstName = reader["first_name"].ToString(),
                            middleInitials = reader["middle_initials"].ToString(),
                            gender = reader["gender"].ToString(),
                            course = reader["course_code"].ToString()
                        });
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            Connection.conn.Close();
            return students;
        }

        //
        // Method for Updating the student record
        //
        public static void UpdateStudent(string studentNumber, string lastName, string firstName, string mi, string course, string gender)
        {
            // converting gender int bit
            int g = -1;
            if (gender.ToLower() == "male")
                g = 1;
            else
                g = 0;

            // updating formula
            Connection.OpenConnection();

            using (SqlCommand cmd = Connection.conn.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateStudent";

                cmd.Parameters.AddWithValue("@studentNumber", SqlDbType.VarChar).Value = studentNumber;
                cmd.Parameters.AddWithValue("@lastName", SqlDbType.VarChar).Value = lastName;
                cmd.Parameters.AddWithValue("@firstName", SqlDbType.VarChar).Value = firstName;
                cmd.Parameters.AddWithValue("@middleInitials", SqlDbType.VarChar).Value = mi;
                cmd.Parameters.AddWithValue("@courseCode", SqlDbType.VarChar).Value = course;
                cmd.Parameters.AddWithValue("@gender", SqlDbType.Bit).Value = g;

                if (Connection.conn.State == ConnectionState.Closed)
                    Connection.conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Record Updated Successfully");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                Connection.conn.Close();
            }

        }

        //
        // Method for deleting a student record
        //
        public static void DeleteStudent(string studentNumber)
        {
            Connection.OpenConnection();

            using (SqlCommand cmd = Connection.conn.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteStudent";

                cmd.Parameters.AddWithValue("@studentNumber", SqlDbType.VarChar).Value = studentNumber;

                if (Connection.conn.State == ConnectionState.Closed)
                    Connection.conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Record Deleted Successfully");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                Connection.conn.Close();
            }
        }

        
    }
}
