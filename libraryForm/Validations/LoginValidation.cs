using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForm.Validations
{
    class LoginValidation
    {
        public bool validate(string username, string password)
        {
            // Look for the database account records
            if (!username.Equals("test") && !password.Equals("test"))
                return false;

            return true;
        }
    }
}
