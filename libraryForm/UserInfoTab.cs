using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace libraryForm
{
    public partial class UserInfoTab : UserControl
    {
        public UserInfoTab()
        {
            InitializeComponent();
        }
        public void search()
        {
            string[] studentIDs;
            string[] studentDetails;
            viewgrid.Rows.Clear();
            int i = 0;
            if (!string.IsNullOrWhiteSpace(searchbox.Text))
            {
                Connection.OpenConnection();
                int found = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentinfo", Connection.conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    studentIDs = new string[count];
                    studentDetails = new string[count];
                }
                using (SqlCommand cmd = new SqlCommand("SELECT studentID, lName, fName FROM studentinfo", Connection.conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    int c1 = 0;
                    while (reader.Read())
                    {
                        studentIDs[c1] = reader[0].ToString();
                        studentDetails[c1] = reader[0].ToString() + "-" + reader[1].ToString() + "-" + reader[2].ToString();
                        c1++;
                    }
                    reader.Close();
                }
                int c = 0;
                foreach (string detail in studentDetails)
                {
                    if (detail.ToUpper().Contains(searchbox.Text.ToUpper().Trim()))
                    {
                        string[] details = detail.Split('-');

                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM studentinfo WHERE [studentID] = '" + details[0] + "'", Connection.conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                viewgrid.Rows.Add();
                                viewgrid.Rows[c].Cells[0].Value = reader[0].ToString();
                                viewgrid.Rows[c].Cells[1].Value = reader[1].ToString();
                                viewgrid.Rows[c].Cells[2].Value = reader[2].ToString();
                                viewgrid.Rows[c].Cells[3].Value = reader[3].ToString();
                                viewgrid.Rows[c].Cells[4].Value = reader[4].ToString();
                                viewgrid.Rows[c].Cells[5].Value = reader[7].ToString();
                                viewgrid.Rows[c].Cells[6].Value = reader[9].ToString();
                                viewgrid.Rows[c].Cells[7].Value = reader[10].ToString();
                                c++;
                                found++;
                            }
                            reader.Close();
                        }
                    }
                }
                Connection.CloseConnection();
            }
        }

        private void searchbox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            focusHere.Focus();
            Add_Students addStud = new Add_Students();
            FormCollection fc = Application.OpenForms;
            bool addStudOpen = false;

            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "Add_Students")
                {
                    addStudOpen = true;
                }
            }
            if (!addStudOpen)
                addStud.Show();
        }

        private void deleteStudbtn_Click(object sender, EventArgs e)
        {
            if (viewgrid.Rows.Count >= 2)
            {
                if (viewgrid.SelectedRows.Count == 1 && viewgrid.CurrentRow.Cells[0].Value != null)
                {
                    int row = viewgrid.CurrentCell.RowIndex;
                    string studNum = viewgrid.Rows[row].Cells[0].Value.ToString();
                    string delCourse = viewgrid.Rows[row].Cells[4].Value.ToString();
                    DialogResult dialog = new DialogResult();
                    dialog = MessageBox.Show("Confirm delete student?", "Warning", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        Connection.OpenConnection();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM studentInfo WHERE studentID = '" + studNum + "'", Connection.conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Connection.CloseConnection();
                        searchbox_ButtonClick(null, null);
                    }
                }
                else
                    MessageBox.Show("No student selected!");
            }
            focusHere.Focus();
        }

        private void searchbox_ButtonClick(object sender, EventArgs e)
        {
            search();
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            if (viewgrid.Rows.Count >= 2)
            {
                if (viewgrid.SelectedRows.Count == 1 && viewgrid.CurrentRow.Cells[0].Value != null && !clipPanel.Visible)
                {
                    Clipboard.SetText(viewgrid.CurrentRow.Cells[0].Value.ToString());
                    //  MessageBox.Show("Student number added to clipboard!");
                    clipPanel.Visible = true;
                    Singleton.clipTime = 0;
                    clipPanel.Left = copyBtn.Left - 18;
                    clipPanel.Top = copyBtn.Top - 10 - clipPanel.Height;
                    Singleton.clipNotif.Interval = 5;
                    Singleton.clipNotif.Tick += new EventHandler(clip_Tick);
                    Singleton.clipNotif.Start();
                }
            }
        }

        private void clip_Tick(object sender, EventArgs e)
        {
            Singleton.clipTime += 5;
            if (Singleton.clipTime >= 150)
            {
                Singleton.tickRepeat++;
                Singleton.clipNotif.Tick += new EventHandler(clip_Move);
            }
        }

        private void clip_Move(object sender, EventArgs e)
        {
            clipPanel.Top -= 1;
            if (Singleton.clipTime >= 250)
            {
                Singleton.clipNotif.Stop();
                Singleton.clipNotif.Tick -= clip_Tick;
                for (int i = 0; i < Singleton.tickRepeat; i++)
                {
                    Singleton.clipNotif.Tick -= new EventHandler(clip_Move);
                }
                Singleton.tickRepeat = 0;
                clipPanel.Visible = false;
            }
        }
        private void visitBtn_Click(object sender, EventArgs e)
        {
            if (viewgrid.Rows.Count >= 2)
            {
                if (viewgrid.SelectedRows.Count == 1 && viewgrid.CurrentRow.Cells[0].Value != null)
                {
                    visitsLog visit = new visitsLog(viewgrid.CurrentRow.Cells[0].Value.ToString(),
                                                    viewgrid.CurrentRow.Cells[1].Value.ToString() + ", " +
                                                    viewgrid.CurrentRow.Cells[2].Value.ToString() + " " +
                                                    viewgrid.CurrentRow.Cells[3].Value.ToString());
                    visit.Show();
                }
                else
                {
                    visitsLog visit = new visitsLog();
                    visit.Show();
                }
            }
            else
            {
                visitsLog visit = new visitsLog();
                visit.Show();
            }

        }

        private void viewgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (viewgrid.Rows.Count > 0)
            {
                if (viewgrid.CurrentRow.Cells[0].Value != null)
                {
                    editStudNo.Text = viewgrid.CurrentRow.Cells[0].Value.ToString();
                    lastNameBox.Text = viewgrid.CurrentRow.Cells[1].Value.ToString();
                    firstNameBox.Text = viewgrid.CurrentRow.Cells[2].Value.ToString();
                    midNameBox.Text = viewgrid.CurrentRow.Cells[3].Value.ToString();
                    foreach (RadioButton rad in coursePanel.Controls.OfType<RadioButton>())
                    {
                        if (rad.Text.Trim().Equals(viewgrid.CurrentRow.Cells[4].Value.ToString().Trim()))
                        {
                            rad.Checked = true;
                            break;
                        }
                    }
                    gendercom.Items.Clear();
                    gendercom.Items.Insert(0, "Male");
                    gendercom.Items.Insert(1, "Female");
                    gendercom.SelectedIndex = gendercom.Items.IndexOf(viewgrid.CurrentRow.Cells[5].Value.ToString());
                    lastNameBox.Enabled = true;
                    firstNameBox.Enabled = true;
                    midNameBox.Enabled = true;
                    coursePanel.Enabled = true;
                    gendercom.Enabled = true;
                    addbtn.Enabled = true;
                }

            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string updateCourse = "";
            foreach (RadioButton rad in coursePanel.Controls.OfType<RadioButton>())
            {
                if (rad.Checked)
                {
                    updateCourse = rad.Text;
                    break;
                }
            }
            if (!string.IsNullOrWhiteSpace(lastNameBox.Text) &&
                !string.IsNullOrWhiteSpace(firstNameBox.Text) &&
                !string.IsNullOrWhiteSpace(midNameBox.Text) &&
                lastNameBox.Text.Length > 1 &&
                firstNameBox.Text.Length > 1 &&
                !string.IsNullOrWhiteSpace(updateCourse) &&
                !string.IsNullOrWhiteSpace(gendercom.Text))
            {
                lastNameBox.Text = lastNameBox.Text.Trim();
                firstNameBox.Text = firstNameBox.Text.Trim();
                midNameBox.Text = midNameBox.Text.Trim();
                string fullFirst = " ";
                string fullLast = " ";
                if (lastNameBox.Text.Contains(" "))
                {
                    string[] splitLast = lastNameBox.Text.Split(' ');
                    for (int i = 0; i < splitLast.Length; i++)
                    {
                        splitLast[i] = splitLast[i].Substring(0, 1).ToUpper() + splitLast[i].Substring(1, splitLast[i].Length - 1).ToLower();
                        if (i == 0)
                        {
                            fullLast = splitLast[i];
                        }
                        else
                        {
                            fullLast += " " + splitLast[i];
                        }
                    }
                    lastNameBox.Text = fullLast;
                }
                else
                    lastNameBox.Text = lastNameBox.Text.Substring(0, 1).ToUpper() + lastNameBox.Text.Substring(1, lastNameBox.Text.Length - 1).ToLower();

                if (firstNameBox.Text.Contains(" "))
                {
                    string[] splitFirst = firstNameBox.Text.Split(' ');
                    for (int i = 0; i < splitFirst.Length; i++)
                    {
                        splitFirst[i] = splitFirst[i].Substring(0, 1).ToUpper() + splitFirst[i].Substring(1, splitFirst[i].Length - 1).ToLower();
                        if (i == 0)
                        {
                            fullFirst = splitFirst[i];
                        }
                        else
                        {
                            fullFirst += " " + splitFirst[i];
                        }
                    }
                    firstNameBox.Text = fullFirst;
                }
                else
                    firstNameBox.Text = firstNameBox.Text.Substring(0, 1).ToUpper() + firstNameBox.Text.Substring(1, firstNameBox.Text.Length - 1).ToLower();

                midNameBox.Text = midNameBox.Text.ToUpper();

                if (!midNameBox.Text.Substring(midNameBox.Text.Length - 1, 1).Equals("."))
                {
                    midNameBox.Text += ".";
                }
                Connection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("UPDATE studentInfo SET lName ='" + lastNameBox.Text + "', " +
                                                                              "fName ='" + firstNameBox.Text + "', " +
                                                                              "mName ='" + midNameBox.Text + "', " +
                                                                              "course = '" + updateCourse + "', " +
                                                                              "gender = '" + gendercom.Text + "' " +
                                                                              "WHERE studentID = '" + editStudNo.Text + "'", Connection.conn))
                {
                    cmd.ExecuteNonQuery();
                }
                Connection.CloseConnection();
                MessageBox.Show("Student Updated!", "Message");
            }
            else if (!string.IsNullOrWhiteSpace(lastNameBox.Text) &&
                !string.IsNullOrWhiteSpace(firstNameBox.Text) &&
                lastNameBox.Text.Length > 1 &&
                firstNameBox.Text.Length > 1 &&
                !string.IsNullOrWhiteSpace(updateCourse) &&
                !string.IsNullOrWhiteSpace(gendercom.Text))
            {
                lastNameBox.Text = lastNameBox.Text.Trim();
                firstNameBox.Text = firstNameBox.Text.Trim();
                string fullFirst = " ";
                string fullLast = " ";
                if (lastNameBox.Text.Contains(" "))
                {
                    string[] splitLast = lastNameBox.Text.Split(' ');
                    for (int i = 0; i < splitLast.Length; i++)
                    {
                        splitLast[i] = splitLast[i].Substring(0, 1).ToUpper() + splitLast[i].Substring(1, splitLast[i].Length - 1).ToLower();
                        if (i == 0)
                        {
                            fullLast = splitLast[i];
                        }
                        else
                        {
                            fullLast += " " + splitLast[i];
                        }
                    }
                    lastNameBox.Text = fullLast;
                }
                else
                    lastNameBox.Text = lastNameBox.Text.Substring(0, 1).ToUpper() + lastNameBox.Text.Substring(1, lastNameBox.Text.Length - 1).ToLower();

                if (firstNameBox.Text.Contains(" "))
                {
                    string[] splitFirst = firstNameBox.Text.Split(' ');
                    for (int i = 0; i < splitFirst.Length; i++)
                    {
                        splitFirst[i] = splitFirst[i].Substring(0, 1).ToUpper() + splitFirst[i].Substring(1, splitFirst[i].Length - 1).ToLower();
                        if (i == 0)
                        {
                            fullFirst = splitFirst[i];
                        }
                        else
                        {
                            fullFirst += " " + splitFirst[i];
                        }
                    }
                    firstNameBox.Text = fullFirst;
                }
                else
                    firstNameBox.Text = firstNameBox.Text.Substring(0, 1).ToUpper() + firstNameBox.Text.Substring(1, firstNameBox.Text.Length - 1).ToLower();

                Connection.OpenConnection();
                using (SqlCommand cmd = new SqlCommand("UPDATE studentInfo SET lName ='" + lastNameBox.Text + "', " +
                                                                              "fName ='" + firstNameBox.Text + "', " +
                                                                              "mName =' ', " +
                                                                              "course = '" + updateCourse + "', " +
                                                                              "gender = '" + gendercom.Text + "' " +
                                                                              "WHERE studentID = '" + editStudNo.Text + "'", Connection.conn))
                {
                    cmd.ExecuteNonQuery();
                }
                Connection.CloseConnection();
                MessageBox.Show("Student Updated!", "Message");
            }
            else if (firstNameBox.Text.Length < 2)
            {
                MessageBox.Show("First name must contain 2 characters or more!");
            }
            else if (lastNameBox.Text.Length < 2)
            {
                MessageBox.Show("Last name must contain 2 characters or more!");
            }
            else
                MessageBox.Show("Please fill all fields!", "Message");
        }

    }
}
