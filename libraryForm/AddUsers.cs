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
    public partial class AddUsers : Form
    {
        public string password;
        public AddUsers()
        {
            InitializeComponent();
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            PasswordPrompt pass = new PasswordPrompt();
            pass.ShowDialog();
            if (password == pass.pw)
            {
                string access = "";
                foreach (RadioButton rad in accessPanel.Controls.OfType<RadioButton>())
                {
                    if (rad.Checked)
                    {
                        if (rad.Text.Equals("Moderator"))
                            access = "2";
                        else
                            access = "1";
                        break;
                    }
                }
                if (!string.IsNullOrWhiteSpace(nameBox.Text) && 
                    !string.IsNullOrWhiteSpace(usernameBox.Text) && 
                    !string.IsNullOrWhiteSpace(pwBox.Text) && 
                    !string.IsNullOrWhiteSpace(confirmpwBox.Text) &&
                    !string.IsNullOrWhiteSpace(access))
                {
                    bool check = false;
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM usersInfo WHERE username = '" + usernameBox.Text + "'", conn))
                        {
                            int count = (int)cmd.ExecuteScalar();
                            check = (count > 0) ? true : false;
                        }
                    }
                    if (!check)
                    {
                        using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO usersInfo (name, username, password, accessLevel) " +
                                                                                  "VALUES ('" + nameBox.Text + "', '" + usernameBox.Text + "', '" + pwBox.Text + "', '" + access + "' )", conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("User added!", "Message");
                        nameBox.Clear();
                        usernameBox.Clear();
                        pwBox.Clear();
                        confirmpwBox.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Username taken!", "Message");
                        usernameBox.Clear();
                    }
                }
            }
        }
    }
}
