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
    class LogsValidation
    {
        public static bool StudentValidate(string studentNumber, int noId)
        {
            if(studentNumber == "")
            {
                MessageBox.Show("Student Number is Required");
                return false;
            }
            if(noId != 0 && noId != 1)
            {
                MessageBox.Show("Check if the student has a Library ID");
                return false;
            }

            return true;
        }
    }
}
