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
using MetroFramework;
using System.Threading;

namespace libraryForm
{
    public partial class Edit_Students : Form
    {
        public Edit_Students()
        {
            InitializeComponent();
        }
        public void comholder(MetroFramework.Controls.MetroComboBox box, string text)
        {
            if (box.Text != text)
            {
                box.Items.Clear();
                box.Items.Insert(0, text);
                box.SelectedIndex = 0;
            }
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
        public bool checkiftableexists(string dbname, string tablename)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.tables WHERE table_name ='" + tablename + "'", conn))
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    bool check;
                    if (count > 0)
                        check = true;
                    else
                        check = false;
                    return check;
                }
            }
        }
        public bool checkiftablehasrows(string tablename)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [" + tablename + "]", conn))
                {
                    conn.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    bool check = read.HasRows;
                    return check;
                }
            }
        }
        public bool checkifrecordexists(string tablename, string columnname, string recordname)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [" + tablename + "] WHERE [" + columnname + "] ='" + recordname + "'", conn))
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    bool check;
                    if (count > 0)
                        check = true;
                    else
                        check = false;
                    return check;
                }
            }
        }

        public async Task delayed()
        {
            await Task.Delay(2000);
        }

        private void Add_Students_Shown(object sender, EventArgs e)
        {
            
        }

        private void gendercom_DropDown(object sender, EventArgs e)
        {
            if (gendercom.Text.Equals("Sex "))
            {
                gendercom.Items.Clear();
                gendercom.Items.Insert(0, "Male");
                gendercom.Items.Insert(1, "Female");
            }
        }

        private void gendercom_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gendercom.Text))
            {
                comholder(gendercom, "Sex ");
            }
        }


        private void studnumbox_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                e.KeyCode == Keys.Decimal || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                //   MetroFramework.MetroMessageBox.Show(this, "Only numerical digits allowed!");
            } */
            nosound(addbtn, e);
        }
        string updateCourse;
        private void addbtn_Click(object sender, EventArgs e)
        {
            updateCourse="";
            foreach (RadioButton rad in coursePanel.Controls.OfType<RadioButton>())
            {
                if (rad.Checked)
                {
                    updateCourse = rad.Text;
                    break;
                }
            }
            /*
            bool existingID;
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentInfo WHERE studentID = '" + searchbox.Text + "'", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    existingID = count > 0 ? true : false;
                }
            } */
            if (!string.IsNullOrWhiteSpace(lastNameBox.Text) &&
                !string.IsNullOrWhiteSpace(firstNameBox.Text) &&
                !string.IsNullOrWhiteSpace(midNameBox.Text) && 
                !string.IsNullOrWhiteSpace(updateCourse) &&
                !string.IsNullOrWhiteSpace(gendercom.Text))
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE studentInfo SET lName ='" + lastNameBox.Text + "', " +
                                                                                  "fName ='" + firstNameBox.Text + "', " +
                                                                                  "mName ='" + midNameBox.Text + "', " +
                                                                                  "course = '" + updateCourse + "', " +
                                                                                  "gender = '" + gendercom.Text + "' " +
                                                                                  "WHERE studentID = '" + searchbox.Text + "'", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Student Updated!", "Message");
                cancelLbl_Click(sender, e);

            }
            else if (!string.IsNullOrWhiteSpace(lastNameBox.Text) &&
                !string.IsNullOrWhiteSpace(firstNameBox.Text) &&
                !string.IsNullOrWhiteSpace(updateCourse) &&
                !string.IsNullOrWhiteSpace(gendercom.Text))
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE studentInfo SET lName ='" + lastNameBox.Text + "', " +
                                                                                  "fName ='" + firstNameBox.Text + "', " +
                                                                                  "mName =' ', " +
                                                                                  "course = '" + updateCourse + "', " +
                                                                                  "gender = '" + gendercom.Text + "' " +
                                                                                  "WHERE studentID = '" + searchbox.Text + "'", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Student Updated!", "Message");
                cancelLbl_Click(sender, e);
            }
            else
                MessageBox.Show("Please fill all fields!", "Message");
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            Close();
        }






        private void contactbox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                e.KeyCode == Keys.Decimal || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                //   MetroFramework.MetroMessageBox.Show(this, "Only numerical digits allowed!");
            }
            nosound(addbtn, e);
        }

        private void searchbox_ButtonClick(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                int count;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentInfo WHERE studentID = '" + searchbox.Text + "'", conn))
                {
                    count = (int)cmd.ExecuteScalar();
                }
                if (count == 1)
                {
                    lastNameBox.Enabled = true;
                    firstNameBox.Enabled = true;
                    midNameBox.Enabled = true;
                    coursePanel.Enabled = true;
                    gendercom.Enabled = true;
                    searchbox.Enabled = false;
                    cancelLbl.Visible = true;
                    addbtn.Enabled = true;

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM studentInfo WHERE studentID = '" + searchbox.Text + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        lastNameBox.Text = reader[1].ToString();
                        firstNameBox.Text = reader[2].ToString();
                        midNameBox.Text = reader[3].ToString();
                        foreach (RadioButton rad in coursePanel.Controls.OfType<RadioButton>())
                        {
                            if(rad.Text.Equals(reader[4].ToString().Trim()))
                            {
                                rad.Checked = true;
                                break;
                            }
                        }
                        gendercom.Items.Clear();
                        gendercom.Items.Insert(0, "Male");
                        gendercom.Items.Insert(1, "Female");
                        gendercom.SelectedIndex = gendercom.Items.IndexOf(reader[7].ToString());
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
        private void cancelLbl_Click(object sender, EventArgs e)
        {
            searchbox.Enabled = true;
            searchbox.Clear();
            searchbox.Clear();
            lastNameBox.Clear();
            firstNameBox.Clear();
            midNameBox.Clear();
            foreach (RadioButton rad in coursePanel.Controls.OfType<RadioButton>())
            {
                if (rad.Checked)
                {
                    rad.Checked = false;
                    break;
                }
            }
            gendercom.Items.Clear();
            cancelLbl.Visible = false;
            lastNameBox.Enabled = false;
            firstNameBox.Enabled = false;
            midNameBox.Enabled = false;
            coursePanel.Enabled = false;
            gendercom.Enabled = false;
            addbtn.Enabled = false;
        }

        private void Edit_Students_Load(object sender, EventArgs e)
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
                    using (SqlCommand cmd = new SqlCommand("SELECT studentID FROM studentInfo", conn))
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

        private void searchbox_Click(object sender, EventArgs e)
        {

        }
    }
}
