using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Data.SqlClient;

using libraryForm.Controllers;

namespace libraryForm
{
    public partial class Login : Form
    {
        Form1 main = new Form1();
        public Login()
        {
            InitializeComponent();
        }

        public void nosound(MetroFramework.Controls.MetroButton btnname, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnname.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        
        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            nosound(loginbtn, e);
        }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            nosound(loginbtn, e);
        }

        string realUser, realPass, realName;
        string accessLvl = "";

        private void loginbtn_Click(object sender, EventArgs e)
        {
            
            if (true)
            {
                //using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            //    using (SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\LocalDB;Initial Catalog=master;Integrated Security=false"))
            //    {
            //        conn.Open();
            //        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [usersInfo] WHERE username = '" + userBox.Text  + "'", conn))
            //        {
            //            int count = (int)cmd.ExecuteScalar();
            //            userExist = count > 0 ? true : false;
            //        }
            //        if (userExist)
            //        {
            //            using (SqlCommand cmd = new SqlCommand("SELECT name, password, accessLevel FROM [usersInfo] WHERE username = '" + userBox.Text + "'", conn))
            //            {
            //                SqlDataReader reader = cmd.ExecuteReader();
            //                reader.Read();
            //                realUser = userBox.Text;
            //                realName = reader[0].ToString();
            //                realPass = reader[1].ToString();
            //                accessLvl = reader[2].ToString();
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    realUser = "admin";
            //    realPass = "admin";
            //    accessLvl = "1";
            //}
            //if (!string.IsNullOrWhiteSpace(userBox.Text) && !string.IsNullOrWhiteSpace(passBox.Text) && userExist)
            //{
            //    if (realUser.Equals(userBox.Text) && realPass.Equals(passBox.Text))
            //    {
            //        main.name = realName;
            //        main.username = realUser;
            //        main.password = realPass;
            //        main.accessLvl = accessLvl;
            //        Hide();
            //        main.Show();
            //    }
            //    else
            //        MessageBox.Show("Incorrect Username or Password", "Message");
            }
        }

        private void Login_Shown(object sender, EventArgs e)
        {

            // using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            //using (SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\LocalDB;Initial Catalog=master;Integrated Security=false"))
            //{
            //    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.tables WHERE table_name = 'usersInfo'", conn))
            //    {
            //        try
            //        {
            //            conn.Open();
            //            int count = (int)cmd.ExecuteScalar();
            //            if (count > 0)
            //            {
            //                check = true;
            //                forgotpasslab.Visible = true;
            //            }
            //            else
            //            {
            //                check = false;
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Error connecting to server", "Error Occured");
            //        }
            //    }
            //}
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
