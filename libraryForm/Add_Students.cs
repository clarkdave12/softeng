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
using System.Linq;

namespace libraryForm
{
    public partial class Add_Students : Form
    {
        public Boolean oneTime;
        public bool noID;
        public Add_Students()
        {
            InitializeComponent();
        }
        public Add_Students(bool oneTime, string newStudNo, bool noID)
        {
            InitializeComponent();
            this.noID = noID;
            this.oneTime = oneTime;
            this.newStudNo = newStudNo;
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
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=" + dbname +";User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
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
        public void gradelvcomrefresh(MetroFramework.Controls.MetroComboBox com, string _SY)
        {
            bool check1;
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.tables WHERE table_name ='" + "SY" + _SY + "Grade_Section'", conn))
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                        check1 = true;
                    else
                        check1 = false;
                }
            }
            if (check1)
            {
                bool check;
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [" + "SY" + _SY + "Grade_Section]", conn))
                    {
                        conn.Open();
                        SqlDataReader read = cmd.ExecuteReader();
                        check = read.HasRows;
                    }
                }
                if (check)
                {
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Grade_Level FROM [" + "SY" + _SY + "Grade_Section]", conn))
                        {
                            int ctr = 0;
                            conn.Open();
                            SqlDataReader read = cmd.ExecuteReader();
                            com.Items.Clear();
                            while (read.Read())
                            {
                                com.Items.Insert(ctr, read[0].ToString());
                                ctr++;
                            }
                        }
                    }
                }
            }
        }
        public void sectcomrefresh(MetroFramework.Controls.MetroComboBox com, string _SY)
        {
            string gradelv = "";
            bool check;
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [" + "SY" + _SY + "Grade_Section]", conn))
                {
                    conn.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    check = read.HasRows;
                }
            }
            if (check)
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Section FROM [" + "SY" + _SY + "Grade_Section] WHERE Grade_Level = '" + "'", conn))
                    {
                        int ctr = 0;
                        conn.Open();
                        SqlDataReader read = cmd.ExecuteReader();
                        com.Items.Clear();
                        while (read.Read())
                        {
                            com.Items.Insert(ctr, read[0].ToString());
                            ctr++;
                        }
                    }
                }
            }
        }

        public string newStudNo { get; set; }
        private void Add_Students_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newStudNo))
            {
                studnumbox.Text = newStudNo;
                lastNameBox.Select();
            }
            comholder(gendercom, "Sex ");
            comholder(coursecom, "Course ");
            /*   using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
               {
                   using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT School_Year FROM Pert_Docs ORDER BY School_Year DESC", conn))
                   {
                       schoolYearCom.Items.Clear();
                       int i = 0;
                       conn.Open();
                       SqlDataReader reader = cmd.ExecuteReader();
                       while (reader.Read())
                       {
                           schoolYearCom.Items.Insert(i, reader[0].ToString());
                           i++;
                       }
                       schoolYearCom.SelectedIndex = 0;
                   }
               } */
        }
        /*
        private void gradelvcom_DropDown(object sender, EventArgs e)
        {
            if(gradelvcom.Text.Equals("Grade Level "))
            {
                gradelvcomrefresh(gradelvcom, SY);
            }
        }

        private void gradelvcom_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gradelvcom.Text))
            {
                comholder(gradelvcom, "Grade Level ");
            }
        }
         */


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
            /* if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
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
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract || studnumbox.Text.Length >=10)
            {
                if (e.KeyCode != Keys.Back)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            nosound(addbtn, e);
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            // var checkButton = this.Controls.OfType<RadioButton>().FirstOrDefault(rr => rr.Checked);
           // bool anyChecked = false;
            string addCourse = "";
            foreach (RadioButton rad in coursePanel.Controls.OfType<RadioButton>())
            {
                if(rad.Checked)
                {
                    addCourse = rad.Text;
                    break;
                }
            }
            if (!string.IsNullOrWhiteSpace(studnumbox.Text) &&
                !string.IsNullOrWhiteSpace(lastNameBox.Text) &&
                !string.IsNullOrWhiteSpace(firstNameBox.Text) &&
                !string.IsNullOrWhiteSpace(midNameBox.Text) &&
                !string.IsNullOrWhiteSpace(addCourse) &&
                !gendercom.Text.Equals("Sex") &&
                studnumbox.Text.Substring(0, 2).Equals("20"))
            {
                bool check = false;
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentinfo WHERE studentID = '" + studnumbox.Text + "'", conn))
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
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO studentinfo (studentID, lName, fName, mName, course, gender, libraryVisits, lastVisit) " +
                                                                                "VALUES ( '" + studnumbox.Text + "', '" + lastNameBox.Text + "', '" + firstNameBox.Text + "', '" + midNameBox.Text + ".','" + addCourse + "', '" + gendercom.Text + "', 1, '" + DateTime.Now.ToString("dd-MM-yyyy") + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        
                        if (oneTime)
                        {
                            using (SqlCommand cmd = new SqlCommand("UPDATE dailyStats SET " + addCourse + " = " + addCourse + " + 1 WHERE dayNumber = (SELECT MAX(dayNumber) FROM dailyStats)", conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            using (SqlCommand cmd = new SqlCommand("UPDATE weeklyStats SET " + addCourse + " = " + addCourse + " + 1 WHERE weekNumber = (SELECT MAX(weekNumber) FROM weeklyStats)", conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            using (SqlCommand cmd = new SqlCommand("UPDATE monthlyStats SET " + addCourse + " = " + addCourse + " + 1 WHERE monthNumber = (SELECT MAX(monthNumber) FROM monthlyStats)", conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            if (noID)
                            {
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO visitsLog (studentID, noID, dateTime) " +
                                                                                        "VALUES ( '" + studnumbox.Text + "',  1, '" + DateTime.Now.ToString("dd MMM yyyy - hh:mm:ss tt") + "')", conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                using (SqlCommand cmd = new SqlCommand("UPDATE studentinfo SET Offense = 1 WHERE studentID = '" + studnumbox.Text + "'", conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO visitsLog (studentID, dateTime) " +
                                                                                        "VALUES ( '" + studnumbox.Text + "', '" + DateTime.Now.ToString("dd MMM yyyy - hh:mm:ss tt") + "')", conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    MessageBox.Show("Student Added!", "Message");
                    if (oneTime)
                    {
                        if(noID)
                            MessageBox.Show("Student will not be permitted to enter next time.");
                        this.Close();
                    }
                    lastNameBox.Clear();
                    firstNameBox.Clear();
                    midNameBox.Clear();
                    studnumbox.Clear();
                    comholder(gendercom, "Sex ");
                }
                else
                {
                    MessageBox.Show("Student Number already exists!", "Message");
                    studnumbox.Clear();
                }
                
            }
            else if(!string.IsNullOrWhiteSpace(studnumbox.Text) &&
                !string.IsNullOrWhiteSpace(lastNameBox.Text) &&
                !string.IsNullOrWhiteSpace(firstNameBox.Text) &&
                gendercom.Text != "Sex " && 
                !string.IsNullOrWhiteSpace(addCourse) && 
                !string.IsNullOrWhiteSpace(gendercom.Text) &&
                studnumbox.Text.Substring(0, 2).Equals("20"))
            {
                bool check = false;
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentinfo WHERE studentID = '" + studnumbox.Text + "'", conn))
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
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO studentinfo (studentID, lName, fName, mName, course, gender, libraryVisits, lastVisit) " +
                                                                                "VALUES ( '" + studnumbox.Text + "', '" + lastNameBox.Text + "', '" + firstNameBox.Text + "', ' ','" + addCourse + "', '" + gendercom.Text + "', 1, '" + DateTime.Now.ToString("dd-MM-yyyy") + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE dailyStats SET " + addCourse + " = " + addCourse + " + 1 WHERE dayNumber = (SELECT MAX(dayNumber) FROM dailyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE weeklyStats SET " + addCourse + " = " + addCourse + " + 1 WHERE weekNumber = (SELECT MAX(weekNumber) FROM weeklyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE monthlyStats SET " + addCourse + " = " + addCourse + " + 1 WHERE monthNumber = (SELECT MAX(monthNumber) FROM monthlyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Student Added!", "Message");
                    if(oneTime)
                        this.Close();
                    lastNameBox.Clear();
                    firstNameBox.Clear();
                    midNameBox.Clear();
                    studnumbox.Clear();
                    comholder(gendercom, "Sex ");
                }
                else
                {
                    MessageBox.Show("Student Number already exists!", "Message");
                    studnumbox.Clear();
                }
            }
            else if (studnumbox.Text.Substring(0, 2) != ("20"))
            {
                MessageBox.Show("Incorrect student number format!", "Message");
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
        string SY;

        private void coursecom_DropDown(object sender, EventArgs e)
        {
            coursecom.Items.Clear();
            coursecom.Items.Add("IT");
            coursecom.Items.Add("HM");
            coursecom.Items.Add("FM");
            coursecom.Items.Add("MM");
            coursecom.Items.Add("BE");
            coursecom.Items.Add("ENTREP");
            coursecom.Items.Add("TOURISM");
            coursecom.Items.Add("COMTECH");
            coursecom.Items.Add("DDGT");
            coursecom.Items.Add("EXT");
            coursecom.Items.Add("FSM");
            coursecom.Items.Add("MATH");
            coursecom.Items.Add("ENG");
            coursecom.Items.Add("FIL");
            coursecom.Items.Add("SOCSCI");
            coursecom.Items.Add("SCI");
            coursecom.Items.Add("GBA");
           // coursecom.Items.Add("courseCode4");
        }

        private void coursecom_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(coursecom.Text))
            {
                comholder(coursecom, "Course ");
            }
        }

        private void coursecom_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void studnumbox_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(studnumbox.Text))
            {
                studnumbox.Text = "20";
            }
        }

        private void Add_Students_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
