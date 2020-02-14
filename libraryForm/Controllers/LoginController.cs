using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Login()
        {
            LoginValidation validation = new LoginValidation();

            if (validation.validate(this.username, this.password))
                return true;

            return false;
        }
    }
}
