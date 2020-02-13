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
    public partial class EditUsers : Form
    {
        public EditUsers()
        {
            InitializeComponent();
        }

        private void EditUsers_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection src = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                conn.Open();
                int count;
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentInfo", conn))
                {
                    count = (int)cmd.ExecuteScalar();
                }
                if (count > 0)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT username FROM usersInfo", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            src.Add(reader[0].ToString());
                        }
                    }
                }
            }
            searchbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            searchbox.AutoCompleteCustomSource = src;
            searchbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        string pw;
        private void usernameSearch()
        {
        }

        private void updateUserBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBox.Text) &&
                oldpwBox.Text.Equals(pw) &&
                !string.IsNullOrWhiteSpace(newpwBox.Text) &&
                newpwBox.Text.Equals(confirmpwBox.Text))
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE usersInfo SET name ='" + nameBox.Text + "', " +
                                                                                  "password ='" + confirmpwBox.Text + "' " +
                                                                                  "WHERE username = '" + searchbox.Text + "'", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("User Updated!", "Message");
                cancelLbl_Click(sender, e);

            }
            else
                MessageBox.Show("Incomplete fields", "Message");
        }
        private void cancelLbl_Click(object sender, EventArgs e)
        {
            searchbox.Enabled = true;
            searchbox.Clear();
            nameBox.Clear();
            oldpwBox.Clear();
            newpwBox.Clear();
            confirmpwBox.Clear();
            cancelLbl.Visible = false;
            nameBox.Enabled = false;
            oldpwBox.Enabled = false;
            newpwBox.Enabled = false;
            confirmpwBox.Enabled = false;
        }

        private void searchbox_ButtonClick(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                int count;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM usersInfo WHERE username = '" + searchbox.Text + "'", conn))
                {
                    count = (int)cmd.ExecuteScalar();
                }
                if (count == 1)
                {
                    nameBox.Enabled = true;
                    oldpwBox.Enabled = true;
                    newpwBox.Enabled = true;
                    confirmpwBox.Enabled = true;
                    searchbox.Enabled = false;
                    cancelLbl.Visible = true;

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM usersInfo WHERE username = '" + searchbox.Text + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        nameBox.Text = reader[1].ToString();
                        pw = reader[3].ToString();
                    }
                }
                else
                    MessageBox.Show("Invalid Student Number!");
            }
        }

        private void searchbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchbox_ButtonClick(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void confirmpwBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateUserBtn.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
