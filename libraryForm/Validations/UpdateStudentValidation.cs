using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace libraryForm.Validations
{
    class UpdateStudentValidation
    {
        public static bool Validate(string studentNumber, string firstName, string lastName, string mi, string course, string gender)
        {
            if(studentNumber == "")
            {
                MessageBox.Show("Student Number is Required");
                return false;
            }
            if(firstName == "")
            {
                MessageBox.Show("First Name Field is Required");
                return false;
            }
            if(lastName == "")
            {
                MessageBox.Show("Last Name Field is Required");
                return false;
            }
            if(mi == "")
            {
                MessageBox.Show("Middle Initials Field is Required");
                return false;
            }
            if(course == "")
            {
                MessageBox.Show("Please Select a Course");
                return false;
            }
            if(gender == "")
            {
                MessageBox.Show("Gender is Required");
                return false;
            }
            if(gender.ToLower() != "male" && gender.ToLower() != "female")
            {
                MessageBox.Show("Invalid Gender");
                return false;
            }

            return true;
        }
    }
}
