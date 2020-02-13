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
using System.IO;
using MetroFramework;

namespace libraryForm
{
    public partial class Form10 : Form
    {
        public string username;
        public string name;
        public string password;
        public string accessLvl;
        Form upstud;
        public Form10()
        {
            InitializeComponent();
            gradelvcom.DropDownStyle = ComboBoxStyle.DropDownList;
            sectcom.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public bool checkifdbexists(string dbname)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=master;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            { 
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM sysdatabases WHERE name = @dbname", conn))
                {
                    conn.Open();
                  cmd.Parameters.AddWithValue("@dbname", dbname);
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
        public void nosound(Button btnname, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnname.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
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
        public bool checkiftableexists(string tablename)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
      /*  public bool checkSY()
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=SJAB_DB;Trusted_Connection=True;"))
            {
                int count;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [Pert_Docs]", conn))
                {
                    count = (int)cmd.ExecuteScalar();
                }
                if (count == 0)
                {
                    DialogResult result = MessageBox.Show("No School Year found, add one now?", "Message", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                 //       addsy sy = new addsy();
                        sy.ShowDialog();
                        if (sy.syAdd)
                            return true;
                        else
                            return false; 
                    }
                    else
                        return false;
                }
                else
                    return true;
            }
        } */
        public void gradelvcomrefresh(MetroFramework.Controls.MetroComboBox com)
        {
            if (checkiftableexists("Grade_Section"))
            {
                if (checkiftablehasrows("Grade_Section"))
                {
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Grade_Level FROM Grade_Section", conn))
                        {
                            int ctr = 1;
                            conn.Open();
                            SqlDataReader read = cmd.ExecuteReader();
                            com.Items.Clear();
                            com.Items.Insert(0, "All Grade Levels ");
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
        public void sectcomrefresh(MetroFramework.Controls.MetroComboBox com)
        {
            string gradelv = "";
            if (checkiftablehasrows("Grade_Section"))
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Section FROM Grade_Section WHERE Grade_Level = '" + gradelvcom.Text + "'", conn))
                    {
                        int ctr = 1;
                        conn.Open();
                        SqlDataReader read = cmd.ExecuteReader();
                        com.Items.Clear();
                        com.Items.Insert(0, "All Sections ");
                        while (read.Read())
                        {
                            com.Items.Insert(ctr, read[0].ToString());
                            ctr++;
                        }
                    }
                }
            }
        }

        private void docs_click(int category)
        {
         //   docslist doc = new docslist();
            int count = 0;
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT School_Year FROM Pert_Docs", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                    }
                }
            }
        }


        Label getContWeek;
        private void RefreshWeeklyStats(string week)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                int i = 0;

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM weeklyStats WHERE weekLength = '" + week +"'", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    while (i < courseLim)
                    {
                       // MessageBox.Show(week);
                        getContWeek = this.Controls.Find(course[i] + "week", true).FirstOrDefault() as Label;
                        getContWeek.Text = reader[i + 2].ToString();
                        i++;
                    }
                }
            }
        }
        private void RefreshMonthlyStats(string month)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                int i = 0;

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM monthlyStats WHERE monthYear = '" + month + "'", conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    while (i < courseLim)
                    {
                        getContWeek = this.Controls.Find(course[i] + "month", true).FirstOrDefault() as Label;
                        getContWeek.Text = reader[i + 2].ToString();
                        i++;
                    }
                    reader.Close();
                }
            }
        }
        private void RefreshDailyStats(string day)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                int i = 0;

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dailyStats WHERE  date = '" + day + "'", conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    while (i < courseLim)
                    {
                        getContWeek = this.Controls.Find(course[i] + "today", true).FirstOrDefault() as Label;
                        getContWeek.Text = reader[i + 2].ToString();
                        i++;
                    }
                    reader.Close();
                }
            }
        }
        private void RefreshDailyBookStats(string day)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                int i = 2;

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dailyBookStats WHERE Date = '" + day + "'", conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    foreach (Label lab in booksPanel.Controls.OfType<Label>().OrderBy(d=>d.TabIndex))
                    {
                        if (i == booksLim)
                            break;
                        lab.Text = reader[i].ToString();
                        i++;
                    }
                    reader.Close();
                }
            }
        }
        private void RefreshWeeklyBookStats(string week)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                int i = 2;

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM weeklyBookStats WHERE weekLength = '" + week + "'", conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    foreach (Label lab in booksPanel.Controls.OfType<Label>().OrderBy(d => d.TabIndex))
                    {
                        if (i == booksLim)
                            break;
                        lab.Text = reader[i].ToString();
                        i++;
                    }
                    reader.Close();
                }
            }
        }
        private void RefreshMonthlyBookStats(string month)
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                int i = 2;

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM monthlyBookStats WHERE monthYear = '" + month + "'", conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    foreach (Label lab in booksPanel.Controls.OfType<Label>().OrderBy(d => d.TabIndex))
                    {
                        if (i == booksLim)
                            break;
                        lab.Text = reader[i].ToString();
                        i++;
                    }
                    reader.Close();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void gradelvcom_DropDown(object sender, EventArgs e)
        {
            if (gradelvcom.Text.Equals("All Grade Levels "))
            {
                gradelvcomrefresh(gradelvcom);
            }
        }

        private void gradelvcom_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gradelvcom.Text))
            {
                comholder(gradelvcom, "All Grade Levels ");
            }
        }

        private void sectcom_DropDown(object sender, EventArgs e)
        {
            if (sectcom.Text.Equals("All Sections "))
            {
                sectcom.Items.Clear();
                if (gradelvcom.Text != "All Grade Levels ")
                {
                    sectcomrefresh(sectcom);
                }
            }
        }

        private void sectcom_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sectcom.Text))
            {
                comholder(sectcom, "All Sections ");
            }
        }
        public void search()
        {
            string[] studentIDs;
            viewgrid.Rows.Clear();
            int i=0;
            if (!string.IsNullOrWhiteSpace(searchbox.Text))
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentinfo", conn))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        studentIDs = new string[count];
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT studentID FROM studentinfo", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int c1 = 0;
                        while (reader.Read())
                        {
                            studentIDs[c1] = reader[0].ToString();
                            c1++;
                        }
                        reader.Close();
                    }
                    int c = 0;
                    foreach (string ID in studentIDs)
                    {
                        if (ID.Contains(searchbox.Text.ToUpper().Trim()))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM studentinfo WHERE [studentID] = '" + ID + "'", conn))
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
                                    viewgrid.Rows[c].Cells[5].Value = reader[5].ToString();
                                    viewgrid.Rows[c].Cells[6].Value = reader[6].ToString();
                                    viewgrid.Rows[c].Cells[7].Value = reader[7].ToString();
                                    viewgrid.Rows[c].Cells[8].Value = reader[8].ToString();
                                    viewgrid.Rows[c].Cells[9].Value = reader[9].ToString();
                                    viewgrid.Rows[c].Cells[10].Value = reader[10].ToString();
                                    c++;
                                }
                                reader.Close();
                            }
                        }
                    }
                }
            }
            /*
            else if (string.IsNullOrWhiteSpace(searchbox.Text) && gradelvcom.Text != "All Grade Levels ")
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\sqlexpress;database=SJAB_DB;Trusted_Connection=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Stud_Profiles WHERE [Grade_Level] = '" + gradelvcom.Text + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            viewgrid.Rows.Add();
                            viewgrid.Rows[i].Cells[0].Value = reader[0].ToString();
                            viewgrid.Rows[i].Cells[1].Value = reader[1].ToString();
                            viewgrid.Rows[i].Cells[2].Value = reader[2].ToString();
                            viewgrid.Rows[i].Cells[3].Value = reader[3].ToString();
                            viewgrid.Rows[i].Cells[4].Value = reader[4].ToString();
                            viewgrid.Rows[i].Cells[5].Value = reader[5].ToString();
                            viewgrid.Rows[i].Cells[6].Value = reader[6].ToString();
                            viewgrid.Rows[i].Cells[7].Value = reader[7].ToString();
                            i++;
                        }
                    }
                }
            }
            else if (string.IsNullOrWhiteSpace(searchbox.Text))
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\sqlexpress;database=SJAB_DB;Trusted_Connection=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Stud_Profiles", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            viewgrid.Rows.Add();
                            viewgrid.Rows[i].Cells[0].Value = reader[0].ToString();
                            viewgrid.Rows[i].Cells[1].Value = reader[1].ToString();
                            viewgrid.Rows[i].Cells[2].Value = reader[2].ToString();
                            viewgrid.Rows[i].Cells[3].Value = reader[3].ToString();
                            viewgrid.Rows[i].Cells[4].Value = reader[4].ToString();
                            viewgrid.Rows[i].Cells[5].Value = reader[5].ToString();
                            viewgrid.Rows[i].Cells[6].Value = reader[6].ToString();
                            viewgrid.Rows[i].Cells[7].Value = reader[7].ToString();
                            i++;
                        }
                    }
                }
            }
            else if (!string.IsNullOrWhiteSpace(searchbox.Text) && sectcom.Text != "All Sections ")
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\sqlexpress;database=SJAB_DB;Trusted_Connection=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Stud_Profiles WHERE [Grade_Level] = '"+gradelvcom.Text+"' AND [Section] = '"+sectcom.Text+"' AND [Student_Num] = '"+searchbox.Text+"'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            viewgrid.Rows.Add();
                            viewgrid.Rows[i].Cells[0].Value = reader[0].ToString();
                            viewgrid.Rows[i].Cells[1].Value = reader[1].ToString();
                            viewgrid.Rows[i].Cells[2].Value = reader[2].ToString();
                            viewgrid.Rows[i].Cells[3].Value = reader[3].ToString();
                            viewgrid.Rows[i].Cells[4].Value = reader[4].ToString();
                            viewgrid.Rows[i].Cells[5].Value = reader[5].ToString();
                            viewgrid.Rows[i].Cells[6].Value = reader[6].ToString();
                            viewgrid.Rows[i].Cells[7].Value = reader[7].ToString();
                            i++;
                        }
                    }
                }
            }
            else if (!string.IsNullOrWhiteSpace(searchbox.Text) && gradelvcom.Text != "All Grade Levels ")
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\sqlexpress;database=SJAB_DB;Trusted_Connection=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Stud_Profiles WHERE [Grade_Level] = '" + gradelvcom.Text + "' AND [Student_Num] = '" + searchbox.Text + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            viewgrid.Rows.Add();
                            viewgrid.Rows[i].Cells[0].Value = reader[0].ToString();
                            viewgrid.Rows[i].Cells[1].Value = reader[1].ToString();
                            viewgrid.Rows[i].Cells[2].Value = reader[2].ToString();
                            viewgrid.Rows[i].Cells[3].Value = reader[3].ToString();
                            viewgrid.Rows[i].Cells[4].Value = reader[4].ToString();
                            viewgrid.Rows[i].Cells[5].Value = reader[5].ToString();
                            viewgrid.Rows[i].Cells[6].Value = reader[6].ToString();
                            viewgrid.Rows[i].Cells[7].Value = reader[7].ToString();
                            i++;
                        }
                    }
                }
            }
            else if (!string.IsNullOrWhiteSpace(searchbox.Text))
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\sqlexpress;database=SJAB_DB;Trusted_Connection=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Stud_Profiles WHERE [Student_Num] = '" + searchbox.Text + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            viewgrid.Rows.Add();
                            viewgrid.Rows[i].Cells[0].Value = reader[0].ToString();
                            viewgrid.Rows[i].Cells[1].Value = reader[1].ToString();
                            viewgrid.Rows[i].Cells[2].Value = reader[2].ToString();
                            viewgrid.Rows[i].Cells[3].Value = reader[3].ToString();
                            viewgrid.Rows[i].Cells[4].Value = reader[4].ToString();
                            viewgrid.Rows[i].Cells[5].Value = reader[5].ToString();
                            viewgrid.Rows[i].Cells[6].Value = reader[6].ToString();
                            viewgrid.Rows[i].Cells[7].Value = reader[7].ToString();
                            i++;
                        }
                    }
                }
            }*/
        }

        private void searchbox_ButtonClick(object sender, EventArgs e)
        {
            search();
        }

        private void gradelvcom_SelectedIndexChanged(object sender, EventArgs e)
        {
            comholder(sectcom, "All Sections ");
        }

        private void searchbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {
          /*  Profile profile = new Profile();
            int count = viewgrid.Rows.Count;
            if (count > 1)
            {
                int row = viewgrid.CurrentCell.RowIndex;
                if (!string.IsNullOrWhiteSpace(viewgrid.Rows[row].Cells[0].Value.ToString()))
                {
                    profile.studnum = viewgrid.Rows[row].Cells[0].Value.ToString();
                    profile.studname = viewgrid.Rows[row].Cells[1].Value.ToString();
                    profile.gradesect = viewgrid.Rows[row].Cells[2].Value.ToString() + " - " + viewgrid.Rows[row].Cells[3].Value.ToString();
                    profile.bday = viewgrid.Rows[row].Cells[4].Value.ToString();
                    profile.sex = viewgrid.Rows[row].Cells[5].Value.ToString();
                    profile.address = viewgrid.Rows[row].Cells[6].Value.ToString();
                    profile.contact = viewgrid.Rows[row].Cells[7].Value.ToString();
                    profile.ShowDialog(); */
                }

        string[] course;
        int courseLim;
        int booksLim;
        private void Form1_Shown(object sender, EventArgs e)
        {
            ta.SelectedTab = tab1;
           // weeklyCom.auto
            if (!checkifdbexists("Library"))
            {
                using(SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=master;User ID=sa;Password=bsusclibrary;Trusted_Connection=true;"))
                {
                    using(SqlCommand cmd = new SqlCommand("CREATE DATABASE Library", conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New database created!", "Welcome");
                    }
                }
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE studentInfo(studentID VARCHAR(100) NOT NULL, " +
                                                                                    "lName VARCHAR(100), " +
                                                                                    "fName VARCHAR(100), " +
                                                                                    "mName VARCHAR(100), " +
                                                                                    "course VARCHAR(100), " +
                                                                                    "yearSection VARCHAR(100), " +
                                                                                    "birthday VARCHAR(100) DEFAULT 'Unknown', " +
                                                                                    "gender VARCHAR(100), " +
                                                                                    "contact VARCHAR(100) DEFAULT '8-7000', " +
                                                                                    "libraryVisits INT DEFAULT 0, " +
                                                                                    "lastVisit VARCHAR(100), " +
                                                                                    "PRIMARY KEY(studentID))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE othersInfo(visitID INT IDENTITY(1,1)," +
                                                                                    "fullName VARCHAR(100), " +
                                                                                    "department VARCHAR(100) DEFAULT 'Guest', " +
                                                                                    "PRIMARY KEY(visitID))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE usersInfo(userID INT IDENTITY(1,1)," +
                                                                                    "name VARCHAR(100), " +
                                                                                    "username VARCHAR(100), " +
                                                                                    "password VARCHAR(100), " +
                                                                                    "accessLevel VARCHAR(100) DEFAULT '1', " +
                                                                                    "secretQ VARCHAR(100) DEFAULT 'none', " +
                                                                                    "secretA VARCHAR(100) DEFAULT 'none', " +
                                                                                    "PRIMARY KEY(userID))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO usersInfo(name, username, password) " +
                                                                          "VALUES('Admin', 'admin', 'admin')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            if(!checkiftableexists("weeklyStats"))
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE dailyStats(dayNumber INT IDENTITY(1,1), " +
                                                                                    "Date VARCHAR(100) NOT NULL, " +
                                                                                    "IT INT DEFAULT 0, " +
                                                                                    "HM INT DEFAULT 0, " +
                                                                                    "MM INT DEFAULT 0, " +
                                                                                    "FM INT DEFAULT 0, " +
                                                                                    "BE INT DEFAULT 0, " +
                                                                                    "ENTREP INT DEFAULT 0, " +
                                                                                    "TOURISM INT DEFAULT 0, " +
                                                                                    "COMTECH INT DEFAULT 0, " +
                                                                                    "DDGT INT DEFAULT 0, " +
                                                                                    "EXT INT DEFAULT 0, " +
                                                                                    "FSM INT DEFAULT 0, " +
                                                                                    "BEED INT DEFAULT 0, " +
                                                                                    "MATH INT DEFAULT 0, " +
                                                                                    "ENG INT DEFAULT 0, " +
                                                                                    "FIL INT DEFAULT 0, " +
                                                                                    "SOCSCI INT DEFAULT 0, " +
                                                                                    "SCI INT DEFAULT 0, " +
                                                                                    "GBA INT DEFAULT 0, " +
                                                                                    "Faculty INT DEFAULT 0, " +
                                                                                    "Others INT DEFAULT 0, " +
                                                                                    "dayEnd VARCHAR(100) NOT NULL, " +
                                                                                    "PRIMARY KEY(dayNumber))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE weeklyStats(weekNumber INT IDENTITY(1,1), " +
                                                                                    "weekLength VARCHAR(100) NOT NULL, " +
                                                                                    "IT INT DEFAULT 0, " +
                                                                                    "HM INT DEFAULT 0, " +
                                                                                    "MM INT DEFAULT 0, " +
                                                                                    "FM INT DEFAULT 0, " +
                                                                                    "BE INT DEFAULT 0, " +
                                                                                    "ENTREP INT DEFAULT 0, " +
                                                                                    "TOURISM INT DEFAULT 0, " +
                                                                                    "COMTECH INT DEFAULT 0, " +
                                                                                    "DDGT INT DEFAULT 0, " +
                                                                                    "EXT INT DEFAULT 0, " +
                                                                                    "FSM INT DEFAULT 0, " +
                                                                                    "BEED INT DEFAULT 0, " +
                                                                                    "MATH INT DEFAULT 0, " +
                                                                                    "ENG INT DEFAULT 0, " +
                                                                                    "FIL INT DEFAULT 0, " +
                                                                                    "SOCSCI INT DEFAULT 0, " +
                                                                                    "SCI INT DEFAULT 0, " +
                                                                                    "GBA INT DEFAULT 0, " +
                                                                                    "Faculty INT DEFAULT 0, " +
                                                                                    "Others INT DEFAULT 0, " +
                                                                                    "weekEnd VARCHAR(100), " +
                                                                                    "PRIMARY KEY(weekNumber))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE monthlyStats(monthNumber INT IDENTITY(1,1), " +
                                                                                    "monthYear VARCHAR(100) NOT NULL, " +
                                                                                    "IT INT DEFAULT 0, " +
                                                                                    "HM INT DEFAULT 0, " +
                                                                                    "MM INT DEFAULT 0, " +
                                                                                    "FM INT DEFAULT 0, " +
                                                                                    "BE INT DEFAULT 0, " +
                                                                                    "ENTREP INT DEFAULT 0, " +
                                                                                    "TOURISM INT DEFAULT 0, " +
                                                                                    "COMTECH INT DEFAULT 0, " +
                                                                                    "DDGT INT DEFAULT 0, " +
                                                                                    "EXT INT DEFAULT 0, " +
                                                                                    "FSM INT DEFAULT 0, " +
                                                                                    "BEED INT DEFAULT 0, " +
                                                                                    "MATH INT DEFAULT 0, " +
                                                                                    "ENG INT DEFAULT 0, " +
                                                                                    "FIL INT DEFAULT 0, " +
                                                                                    "SOCSCI INT DEFAULT 0, " +
                                                                                    "SCI INT DEFAULT 0, " +
                                                                                    "GBA INT DEFAULT 0, " +
                                                                                    "Faculty INT DEFAULT 0, " +
                                                                                    "Others INT DEFAULT 0, " +
                                                                                    "monthEnd VARCHAR(100), " +
                                                                                    "PRIMARY KEY(monthNumber))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE dailyBookStats(recordNumber INT IDENTITY(1,1), " +
                                                                                    "Date VARCHAR(100) NOT NULL, " +
                                                                                    "GenReF_A INT DEFAULT 0, " +
                                                                                    "Philo_B_BJ INT DEFAULT 0, " +
                                                                                    "History_C_F INT DEFAULT 0, " +
                                                                                    "SocSci_H_HA INT DEFAULT 0, " +
                                                                                    "Economics_HB_HJ INT DEFAULT 0, " +
                                                                                    "Sociology_HM_HX INT DEFAULT 0, " +
                                                                                    "Geography_G INT DEFAULT 0, " +
                                                                                    "PolSci_J_K INT DEFAULT 0, " +
                                                                                    "Education_L INT DEFAULT 0, " +
                                                                                    "Music_M INT DEFAULT 0, " +
                                                                                    "FineArts_N INT DEFAULT 0, " +
                                                                                    "LanguageLit_P_PZ INT DEFAULT 0, " +
                                                                                    "Sciences_Q INT DEFAULT 0, " +
                                                                                    "Medicine_R INT DEFAULT 0, " +
                                                                                    "Agriculture_S INT DEFAULT 0, " +
                                                                                    "Technology_T INT DEFAULT 0, " +
                                                                                    "LibSci_Z INT DEFAULT 0, " +
                                                                                    "Periodicals INT DEFAULT 0, " +
                                                                                    "AV_Materials INT DEFAULT 0, " +
                                                                                    "Thesis INT DEFAULT 0, " +
                                                                                    "Fiction INT DEFAULT 0, " +
                                                                                    "Filipiniana INT DEFAULT 0, " +
                                                                                    "dayEnd VARCHAR(100), " +
                                                                                    "PRIMARY KEY(recordNumber))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE weeklyBookStats(recordNumber INT IDENTITY(1,1), " +
                                                                                    "weekLength VARCHAR(100) NOT NULL, " +
                                                                                    "GenReF_A INT DEFAULT 0, " +
                                                                                    "Philo_B_BJ INT DEFAULT 0, " +
                                                                                    "History_C_F INT DEFAULT 0, " +
                                                                                    "SocSci_H_HA INT DEFAULT 0, " +
                                                                                    "Economics_HB_HJ INT DEFAULT 0, " +
                                                                                    "Sociology_HM_HX INT DEFAULT 0, " +
                                                                                    "Geography_G INT DEFAULT 0, " +
                                                                                    "PolSci_J_K INT DEFAULT 0, " +
                                                                                    "Education_L INT DEFAULT 0, " +
                                                                                    "Music_M INT DEFAULT 0, " +
                                                                                    "FineArts_N INT DEFAULT 0, " +
                                                                                    "LanguageLit_P_PZ INT DEFAULT 0, " +
                                                                                    "Sciences_Q INT DEFAULT 0, " +
                                                                                    "Medicine_R INT DEFAULT 0, " +
                                                                                    "Agriculture_S INT DEFAULT 0, " +
                                                                                    "Technology_T INT DEFAULT 0, " +
                                                                                    "LibSci_Z INT DEFAULT 0, " +
                                                                                    "Periodicals INT DEFAULT 0, " +
                                                                                    "AV_Materials INT DEFAULT 0, " +
                                                                                    "Thesis INT DEFAULT 0, " +
                                                                                    "Fiction INT DEFAULT 0, " +
                                                                                    "Filipiniana INT DEFAULT 0, " +
                                                                                    "weekEnd VARCHAR(100), " +
                                                                                    "PRIMARY KEY(recordNumber))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE monthlyBookStats(recordNumber INT IDENTITY(1,1), " +
                                                                                    "monthYear VARCHAR(100) NOT NULL, " +
                                                                                    "GenReF_A INT DEFAULT 0, " +
                                                                                    "Philo_B_BJ INT DEFAULT 0, " +
                                                                                    "History_C_F INT DEFAULT 0, " +
                                                                                    "SocSci_H_HA INT DEFAULT 0, " +
                                                                                    "Economics_HB_HJ INT DEFAULT 0, " +
                                                                                    "Sociology_HM_HX INT DEFAULT 0, " +
                                                                                    "Geography_G INT DEFAULT 0, " +
                                                                                    "PolSci_J_K INT DEFAULT 0, " +
                                                                                    "Education_L INT DEFAULT 0, " +
                                                                                    "Music_M INT DEFAULT 0, " +
                                                                                    "FineArts_N INT DEFAULT 0, " +
                                                                                    "LanguageLit_P_PZ INT DEFAULT 0, " +
                                                                                    "Sciences_Q INT DEFAULT 0, " +
                                                                                    "Medicine_R INT DEFAULT 0, " +
                                                                                    "Agriculture_S INT DEFAULT 0, " +
                                                                                    "Technology_T INT DEFAULT 0, " +
                                                                                    "LibSci_Z INT DEFAULT 0, " +
                                                                                    "Periodicals INT DEFAULT 0, " +
                                                                                    "AV_Materials INT DEFAULT 0, " +
                                                                                    "Thesis INT DEFAULT 0, " +
                                                                                    "Fiction INT DEFAULT 0, " +
                                                                                    "Filipiniana INT DEFAULT 0, " +
                                                                                    "monthEnd VARCHAR(100), " +
                                                                                    "PRIMARY KEY(recordNumber))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE borrowedBooks(borrowNumber INT IDENTITY(1,1), " +
                                                                                    "Date VARCHAR(100) NOT NULL, " +
                                                                                    "lName VARCHAR(100) NOT NULL, " +
                                                                                    "fName VARCHAR(100) NOT NULL, " +
                                                                                    "mName VARCHAR(100) NOT NULL, " +
                                                                                    "Course VARCHAR(100) DEFAULT 'None', " +
                                                                                    "YearSec VARCHAR(100) DEFAULT 'None', " +
                                                                                    "Title VARCHAR(100) NOT NULL, " +
                                                                                    "Barcode VARCHAR(100) NOT NULL, " +
                                                                                    "AccessionNum VARCHAR(100) NOT NULL, " +
                                                                                    "CallNum VARCHAR(100) NOT NULL, " +
                                                                                    "Lender VARCHAR(100) DEFAULT 'Unknown', " +
                                                                                    "returnBy VARCHAR(100) NOT NULL, " +
                                                                                    "Status VARCHAR(100) NOT NULL, " +
                                                                                    "Borrower VARCHAR(100) DEFAULT 'Unknown', " +
                                                                                    "PRIMARY KEY(borrowNumber))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            int days = 0;
            string weekStart = DateTime.Now.ToString("dd MMM yyyy");
            string monthYear = DateTime.Now.ToString("MMMM-yyyy");
            int day = int.Parse(DateTime.Now.ToString("dd"));
            int year = int.Parse(DateTime.Now.ToString("yyyy"));
            int month = int.Parse(DateTime.Now.ToString("MM"));
            int daysInMonth = DateTime.DaysInMonth(year, month);
            string ttime = DateTime.Now.ToString("dddd");
            switch (ttime)
            {
                case "Monday":
                    days = 7;
                    break;
                case "Tuesday":
                    days = 6;
                    break;
                case "Wednesday":
                    days = 5;
                    break;
                case "Thursday":
                    days = 4;
                    break;
                case "Friday":
                    days = 3;
                    break;
                case "Saturday":
                    days = 2;
                    break;
                default:
                    break;
            }
            string newWeekEnd = DateTime.Now.AddDays(days).ToString("dd MMM yyyy");
            string weekLength = weekStart + " - " + newWeekEnd;
            newWeekEnd += " 12:00:00 AM";
            string dayEnd = DateTime.Now.ToString("dd MMM yyyy");
            dayEnd += " 11:59:00 PM";
            string date = DateTime.Now.ToString("dd-MM-y");
            int daysLeft = (daysInMonth - day);
            DateTime dateMonthEnd = DateTime.Now.AddDays(daysLeft);
            string newMonthEnd = dateMonthEnd.ToString("dd MMM yyyy");
            newMonthEnd += " 11:59:00 PM";
            DateTime weekEnd;
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                bool check2;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM weeklyStats", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    check2 = (count > 0) ? true : false;

                }
                if (check2)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM weeklyStats ORDER BY weekNumber DESC", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        weekEnd = DateTime.Parse(reader[22].ToString());
                        reader.Close();
                    }
                    if (DateTime.Now > weekEnd)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO weeklyStats (weekLength, weekEnd) VALUES ('" + weekLength + "', '" + newWeekEnd + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO weeklyBookStats (weekLength, weekEnd) VALUES ('" + weekLength + "', '" + newWeekEnd + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO weeklyStats (weekLength, weekEnd) VALUES ('" + weekLength + "', '" + newWeekEnd + "')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO weeklyBookStats (weekLength, weekEnd) VALUES ('" + weekLength + "', '" + newWeekEnd + "')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM dailyStats", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    check2 = (count > 0) ? true : false;

                }
                if (check2)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dailyStats ORDER BY dayNumber DESC", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        weekEnd = DateTime.Parse(reader[22].ToString());
                        reader.Close();
                    }
                    if (DateTime.Now > weekEnd)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO dailyStats (Date, dayEnd) VALUES ('" + date + "','" + dayEnd + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO dailyBookStats (Date, dayEnd) VALUES ('" + date + "','" + dayEnd + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO dailyStats (Date, dayEnd) VALUES ('" + date + "','" + dayEnd + "')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO dailyBookStats (Date, dayEnd) VALUES ('" + date + "','" + dayEnd + "')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM monthlyStats", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    check2 = (count > 0) ? true : false;

                }
                DateTime monthEnd;
                if (check2)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM monthlyStats ORDER BY monthNumber DESC", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        monthEnd = DateTime.Parse(reader[22].ToString());
                        reader.Close();
                    }
                    if (DateTime.Now > monthEnd)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO monthlyStats (monthYear, monthEnd) VALUES ('" + monthYear + "', '" + newMonthEnd + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO monthlyBookStats (monthYear, monthEnd) VALUES ('" + monthYear + "', '" + newMonthEnd + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO monthlyStats (monthYear, monthEnd) VALUES ('" + monthYear + "', '" + newMonthEnd + "')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO monthlyBookStats (monthYear, monthEnd) VALUES ('" + monthYear + "', '" + newMonthEnd + "')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }


            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                bool check2;
                conn.Open();
                int i = 2;
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.columns WHERE TABLE_NAME = 'dailyBookStats'", conn))
                {
                    booksLim = (int)cmd.ExecuteScalar();
                    booksLim = booksLim - 1;
                }
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentinfo", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    check2 = (count > 0) ? true : false;
                }
                i = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.columns WHERE TABLE_NAME = 'weeklyStats'", conn))
                {
                    courseLim = (int)cmd.ExecuteScalar();
                    courseLim = courseLim - 3;
                    course = new string[courseLim];
                }
                using (SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME FROM information_schema.columns WHERE TABLE_NAME = 'weeklyStats'", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (i < 2 || i == courseLim + 2)
                        {
                            i++;
                            continue;
                        }
                        course[i - 2] = reader[0].ToString();
                        i++;
                    }
                    reader.Close();
                    i = 0;
                }

                Label getContTotal;
                while (i < courseLim)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT libraryVisits FROM studentinfo WHERE course = '" + course[i] + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int totalVisits = 0;
                        while (reader.Read())
                        {
                            totalVisits += int.Parse(reader[0].ToString());
                        }
                        getContTotal = this.Controls.Find(course[i] + "total", true).FirstOrDefault() as Label;
                        getContTotal.Text = totalVisits.ToString();
                        reader.Close();
                        i++;
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM othersInfo", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    Otherstotal.Text = count.ToString();
                }

            }

            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT date FROM [dailyStats] ORDER BY dayNumber DESC", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dailyCom.Items.Add(reader[0].ToString());
                    }
                    dailyCom.SelectedIndex = 0;
                    reader.Close();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT date FROM [dailyBookStats] ORDER BY recordNumber DESC", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dailyBooksCom.Items.Add(reader[0].ToString());
                    }
                    booksDatesRad.Checked = true;
                    dailyBooksCom.SelectedIndex = 0;
                    reader.Close();
                    booksDatesRad.Checked = true;
                }
                using (SqlCommand cmd = new SqlCommand("SELECT weekLength FROM [weeklyStats] ORDER BY weekNumber DESC", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        weeklyCom.Items.Add(reader[0].ToString());
                    }
                    weeklyCom.SelectedIndex = 0;
                    reader.Close();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT monthYear FROM [monthlyStats] ORDER BY monthNumber DESC", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        monthlyCom.Items.Add(reader[0].ToString());
                    }
                    monthlyCom.SelectedIndex = 0;
                    reader.Close();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT name FROM [usersInfo] WHERE username ='" + username + "'", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    name = reader[0].ToString();
                    welcome.Text = "Welcome " + name + "!";
                }
            }


        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }
        private void v_Click(object sender, EventArgs e)
        {
            Add_Students addStud = new Add_Students();
            addStud.Show(); 
        }


        private void metroButton2_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            bool check;
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentinfo WHERE studentID = '" + studNo.Text + "'", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    check = (count > 0) ? true : false;
                }
                if (check)
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE studentinfo SET libraryVisits = libraryVisits + 1, lastVisit = '" + date + "' WHERE  studentID = '" + studNo.Text + "'", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    string loginCourse;
                    using (SqlCommand cmd = new SqlCommand("SELECT course FROM studentinfo WHERE studentID = '" + studNo.Text + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        loginCourse = reader[0].ToString();
                        reader.Close();
                    }
                    string today = DateTime.Now.ToString("dddd");
                    if (!today.Equals("Sunday"))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE dailyStats SET " + loginCourse + " = " + loginCourse + " + 1 WHERE dayNumber = (SELECT MAX(dayNumber) FROM dailyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE weeklyStats SET " + loginCourse + " = " + loginCourse + " + 1 WHERE weekNumber = (SELECT MAX(weekNumber) FROM weeklyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE monthlyStats SET " + loginCourse + " = " + loginCourse + " + 1 WHERE monthNumber = (SELECT MAX(monthNumber) FROM monthlyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT libraryVisits FROM studentinfo WHERE course = '" + loginCourse + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int totalVisits = 0;
                        while (reader.Read())
                        {
                            totalVisits += int.Parse(reader[0].ToString());
                        }
                        Label getContTotal = this.Controls.Find(loginCourse + "total", true).FirstOrDefault() as Label;
                        getContTotal.Text = totalVisits.ToString();
                        reader.Close();
                    }
                    if (dailyCom.SelectedIndex == 0)
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT " + loginCourse + " FROM dailyStats WHERE dayNumber = (SELECT MAX(dayNumber) FROM dailyStats)", conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            Label getContWeek = this.Controls.Find(loginCourse + "today", true).FirstOrDefault() as Label;
                            getContWeek.Text = reader[0].ToString();
                            reader.Close();
                        }
                    }
                    if (weeklyCom.SelectedIndex == 0)
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT " + loginCourse + " FROM weeklyStats WHERE weekNumber = (SELECT MAX(weekNumber) FROM weeklyStats)", conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            Label getContWeek = this.Controls.Find(loginCourse + "week", true).FirstOrDefault() as Label;
                            getContWeek.Text = reader[0].ToString();
                            reader.Close();
                        }
                    }
                    if (monthlyCom.SelectedIndex == 0)
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT " + loginCourse + " FROM monthlyStats WHERE monthNumber = (SELECT MAX(monthNumber) FROM monthlyStats)", conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            Label getContWeek = this.Controls.Find(loginCourse + "month", true).FirstOrDefault() as Label;
                            getContWeek.Text = reader[0].ToString();
                            reader.Close();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM studentInfo WHERE studentID = '" + studNo.Text + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        lastLog.Visible = true;
                        logName.Visible = true;
                        logNum.Visible = true;
                        logCourse.Visible = true;
                        logYearSec.Visible = true;
                        logBirthday.Visible = true;
                        logGender.Visible = true;
                        logContact.Visible = true;
                        lastLogBirthday.Visible = true;
                        lastLogContact.Visible = true;
                        lastLogCourse.Visible = true;
                        lastLogGender.Visible = true;
                        lastLogName.Visible = true;
                        lastLogNum.Visible = true;
                        lastLogYearSec.Visible = true;
                        lastLogNum.Text = reader[0].ToString();
                        lastLogName.Text = reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString();
                        lastLogCourse.Text = reader[4].ToString();
                        lastLogYearSec.Text = reader[5].ToString();
                        lastLogBirthday.Text = reader[6].ToString();
                        lastLogGender.Text = reader[7].ToString();
                        lastLogContact.Text = reader[8].ToString();
                    }
                    studNo.Clear();

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(studNo.Text))
                    {
                        DialogResult dialog = MessageBox.Show("Student Number not found. Register new student?", "Not Found", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            Add_Students addStud = new Add_Students();
                            addStud.newStudNo = studNo.Text;
                            addStud.Show();
                        }
                    }
                }
            }
        }
        private void metroLabel8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logNum_Click(object sender, EventArgs e)
        {

        }


        private void studNo_KeyDown(object sender, KeyEventArgs e)
        {
            nosound(logButton, e);
            if(e.KeyCode==Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void dailyCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDailyStats(dailyCom.Text);
        }

        private void weeklyCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            weeklyComTip.SetToolTip(weeklyCom, weeklyCom.Text);
            RefreshWeeklyStats(weeklyCom.Text);
        }

        private void monthlyCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthlyComTip.SetToolTip(monthlyCom, monthlyCom.Text);
            RefreshMonthlyStats(monthlyCom.Text);
        }
        private void weeklyCom_DropDown(object sender, EventArgs e)
        {
            Graphics g = weeklyCom.CreateGraphics();
            Font font = weeklyCom.Font;
            weeklyCom.DropDownWidth = (int)g.MeasureString(weeklyCom.Text, font).Width + 45;
        }
        private void othersButton_Click(object sender, EventArgs e)
        {
            Others other = new Others();
            other.ShowDialog();
            if (dailyCom.SelectedIndex == 0)
            {
                RefreshDailyStats(dailyCom.Text);
            }
            if (weeklyCom.SelectedIndex == 0)
            {
                RefreshWeeklyStats(weeklyCom.Text);
            }
            if (monthlyCom.SelectedIndex == 0)
            {
                RefreshMonthlyStats(monthlyCom.Text);
            }
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM othersInfo", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    Otherstotal.Text = count.ToString();
                }
            }
        }

        private void booksDatesRad_CheckedChanged(object sender, EventArgs e)
        {
            if (booksDatesRad.Checked)
            {
                int i = 0;
                dailyBooksCom.Items.Clear();
                dailyBooksCom.Width = 135;
                while (i < dailyCom.Items.Count)
                {
                    dailyBooksCom.Items.Add(dailyCom.Items[i].ToString());
                    i++;
                }
                dailyBooksCom.SelectedIndex = 0;
            }
        }
        private void booksWeeksRad_CheckedChanged(object sender, EventArgs e)
        {
            if (booksWeeksRad.Checked)
            {
                int i = 0;
                dailyBooksCom.Items.Clear();
                dailyBooksCom.Width = 185;
                while (i < weeklyCom.Items.Count)
                {
                    dailyBooksCom.Items.Add(weeklyCom.Items[i].ToString());
                    i++;
                }
                dailyBooksCom.SelectedIndex = 0;
            }
        }

        private void booksMonthsRad_CheckedChanged(object sender, EventArgs e)
        {
            if (booksMonthsRad.Checked)
            {
                int i = 0;
                dailyBooksCom.Items.Clear();
                dailyBooksCom.Width = 135;
                while (i < monthlyCom.Items.Count)
                {
                    dailyBooksCom.Items.Add(monthlyCom.Items[i].ToString());
                    i++;
                }
                dailyBooksCom.SelectedIndex = 0;
            }
        }
        Label bookStats;
        private void UpdateStatValues(string category)
        {
            if (dailyBooksCom.SelectedIndex == 0)
            {
                if (booksDatesRad.Checked)
                {
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT " + category + " FROM dailyBookStats WHERE recordNumber = (SELECT MAX(recordNumber) FROM dailyBookStats)", conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            bookStats = booksPanel.Controls.Find(category + "lab", true).FirstOrDefault() as Label;
                            bookStats.Text = reader[0].ToString();
                        }
                    }
                }
                else if (booksWeeksRad.Checked)
                {
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT " + category + " FROM weeklyBookStats WHERE recordNumber = (SELECT MAX(recordNumber) FROM weeklyBookStats)", conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            bookStats = booksPanel.Controls.Find(category + "lab", true).FirstOrDefault() as Label;
                            bookStats.Text = reader[0].ToString();
                        }
                    }
                }
                else if (booksMonthsRad.Checked)
                {
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT " + category + " FROM monthlyBookStats WHERE recordNumber = (SELECT MAX(recordNumber) FROM monthlyBookStats)", conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            bookStats = booksPanel.Controls.Find(category + "lab", true).FirstOrDefault() as Label;
                            bookStats.Text = reader[0].ToString();
                        }
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "GenReF_A";
            books.ShowDialog();
            UpdateStatValues("GenReF_A");
        }

        private void Bbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Philo_B_BJ";
            books.ShowDialog();
            UpdateStatValues("Philo_B_BJ");
        }

        private void Cbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "History_C_F";
            books.ShowDialog();
            UpdateStatValues("History_C_F");
        }

        private void HAbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "SocSci_H_HA";
            books.ShowDialog();
            UpdateStatValues("SocSci_H_HA");
        }

        private void HJbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Economics_HB_HJ";
            books.ShowDialog();
            UpdateStatValues("Economics_HB_HJ");
        }

        private void HXbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Sociology_HM_HX";
            books.ShowDialog();
            UpdateStatValues("Sociology_HM_HX");
        }

        private void Gbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Geography_G";
            books.ShowDialog();
            UpdateStatValues("Geography_G");
        }

        private void Jbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "PolSci_J_K";
            books.ShowDialog();
            UpdateStatValues("PolSci_J_K");
        }

        private void Lbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Education_L";
            books.ShowDialog();
            UpdateStatValues("Education_L");
        }

        private void Mbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Music_M";
            books.ShowDialog();
            UpdateStatValues("Music_M");
        }

        private void Nbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "FineArts_N";
            books.ShowDialog();
            UpdateStatValues("FineArts_N");
        }

        private void PZbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "LanguageLit_P_PZ";
            books.ShowDialog();
            UpdateStatValues("LanguageLit_P_PZ");
        }

        private void Qbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Sciences_Q";
            books.ShowDialog();
            UpdateStatValues("Sciences_Q");
        }

        private void Rbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Medicine_R";
            books.ShowDialog();
            UpdateStatValues("Medicine_R");
        }

        private void Sbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Agriculture_S";
            books.ShowDialog();
            UpdateStatValues("Agriculture_S");
        }

        private void Tbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Technology_T";
            books.ShowDialog();
            UpdateStatValues("Technology_T");
        }

        private void Zbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "LibSci_Z";
            books.ShowDialog();
            UpdateStatValues("LibSci_Z");
        }

        private void Perbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Periodicals";
            books.ShowDialog();
            UpdateStatValues("Periodicals");
        }

        private void AVbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "AV_Materials";
            books.ShowDialog();
            UpdateStatValues("AV_Materials");
        }

        private void Thesisbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Thesis";
            books.ShowDialog();
            UpdateStatValues("Thesis");
        }

        private void Fictionbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Fiction";
            books.ShowDialog();
            UpdateStatValues("Fiction");
        }

        private void Filbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Filipiniana";
            books.ShowDialog();
            UpdateStatValues("Filipiniana");
        }

        private void dailyBooksCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (booksDatesRad.Checked)
            {
                RefreshDailyBookStats(dailyBooksCom.Text);
            }
            else if (booksWeeksRad.Checked)
            {
             //   MessageBox.Show(dailyBooksCom.Text);
                RefreshWeeklyBookStats(dailyBooksCom.Text);
            }
            else if (booksMonthsRad.Checked)
            {
                RefreshMonthlyBookStats(dailyBooksCom.Text);
            } 
        }

        private void editStudBtn_Click(object sender, EventArgs e)
        {
            Edit_Students edit = new Edit_Students();
            edit.Show();
        }
        List<string> ll = new List<string>();
        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            if (borrower.Equals("Student"))
            {
                if (!string.IsNullOrWhiteSpace(borrowLName.Text) &&
                    !string.IsNullOrWhiteSpace(borrowFName.Text) &&
                    !string.IsNullOrWhiteSpace(borrowMName.Text) &&
                    !string.IsNullOrWhiteSpace(borrowCourseCom.Text) &&
                    !string.IsNullOrWhiteSpace(borrowYearSec.Text) &&
                    !string.IsNullOrWhiteSpace(borrowTitle.Text) &&
                    !string.IsNullOrWhiteSpace(borrowBar.Text) &&
                    !string.IsNullOrWhiteSpace(borrowAccess.Text) &&
                    !string.IsNullOrWhiteSpace(borrowCall.Text) &&
                    studRad && bookRadCheck)
                {
                    string date = DateTime.Now.ToString("dd-MM-yyyy");
                    DateTime returnTime = new DateTime();
                    if (bookRad.Checked)
                    {
                        returnTime = DateTime.Now.AddDays(1);
                    }
                    else
                        returnTime = DateTime.Now.AddDays(7);

                    string returnBy = returnTime.ToString("dd MMM yyyy") + " 10:00:00 AM";
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO borrowedBooks (Date, " +
                                                                                          "lName, " +
                                                                                          "fName, " +
                                                                                          "mName, " +
                                                                                          "Course," +
                                                                                          "YearSec," +
                                                                                          "Title," +
                                                                                          "Barcode," +
                                                                                          "AccessionNum," +
                                                                                          "CallNum," +
                                                                                          "Lender," +
                                                                                          "returnBy," +
                                                                                          "Status," +
                                                                                          "Borrower)" +
                                                                                   "VALUES('" + date + "'," +
                                                                                          "'" + borrowLName.Text + "'," +
                                                                                          "'" + borrowFName.Text + "'," +
                                                                                          "'" + borrowMName.Text + "'," +
                                                                                          "'" + borrowCourseCom.Text + "'," +
                                                                                          "'" + borrowYearSec.Text + "'," +
                                                                                          "'" + borrowTitle.Text + "'," +
                                                                                          "'" + borrowBar.Text + "'," +
                                                                                          "'" + borrowAccess.Text + "'," +
                                                                                          "'" + borrowCall.Text + "'," +
                                                                                          "'" + name + "'," +
                                                                                          "'" + returnBy + "'," +
                                                                                          "'Borrowed'," +
                                                                                          "'" + borrower + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Book borrow successful!");
                        BorrowRefresh();
                    }
                }
            }
            else if (borrower.Equals("Faculty"))
            {
                if (!string.IsNullOrWhiteSpace(borrowLName.Text) &&
                    !string.IsNullOrWhiteSpace(borrowFName.Text) &&
                    !string.IsNullOrWhiteSpace(borrowMName.Text) &&
                    !string.IsNullOrWhiteSpace(borrowTitle.Text) &&
                    !string.IsNullOrWhiteSpace(borrowBar.Text) &&
                    !string.IsNullOrWhiteSpace(borrowAccess.Text) &&
                    !string.IsNullOrWhiteSpace(borrowCall.Text) &&
                    studRad && bookRadCheck)
                {
                    string date = DateTime.Now.ToString("dd-MM-yyyy");
                    DateTime returnTime = new DateTime();
                    if (bookRad.Checked)
                    {
                        returnTime = DateTime.Now.AddDays(1);
                    }
                    else
                        returnTime = DateTime.Now.AddDays(7);

                    string returnBy = returnTime.ToString("dd MMM yyyy") + " 10:00:00 AM";
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO borrowedBooks (Date, " +
                                                                                          "lName, " +
                                                                                          "fName, " +
                                                                                          "mName, " +
                                                                                          "Title," +
                                                                                          "Barcode," +
                                                                                          "AccessionNum," +
                                                                                          "CallNum," +
                                                                                          "Lender," +
                                                                                          "returnBy," +
                                                                                          "Status," +
                                                                                          "Borrower)" +
                                                                                   "VALUES('" + date + "'," +
                                                                                          "'" + borrowLName.Text + "'," +
                                                                                          "'" + borrowFName.Text + "'," +
                                                                                          "'" + borrowMName.Text + "'," +
                                                                                          "'" + borrowTitle.Text + "'," +
                                                                                          "'" + borrowBar.Text + "'," +
                                                                                          "'" + borrowAccess.Text + "'," +
                                                                                          "'" + borrowCall.Text + "'," +
                                                                                          "'" + name + "'," +
                                                                                          "'" + returnBy + "'," +
                                                                                          "'Borrowed'," +
                                                                                          "'" + borrower + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Book borrow successful!");
                        BorrowRefresh();
                    }
                }
            }

        }
        Random R = new Random();
        List<GroupBox> grr = new List<GroupBox>();
        private void metroButton3_Click(object sender, EventArgs e)
        {
            BorrowRefresh();
            // this moves the new one to the top!
            // this is just for fun:
            //p.Paint += (ss, ee) => { ee.Graphics.DrawString(p.Name, Font, Brushes.White, 22, 11); };

        }
        private void BorrowRefresh()
        {
            using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                int ii = 0;
                mainP.Controls.Clear();
                grr.Clear();
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM borrowedBooks WHERE Status='Borrowed'", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GroupBox p = new GroupBox();
                        p.ForeColor = Color.White;
                        p.Name = "groupB-" + (ii + 1);
                        p.BackColor = Color.FromArgb(123, R.Next(222), R.Next(222));
                        p.Size = new Size(mainP.Width - 17, 130);
                        grr.Add(p);
                        mainP.Controls.Add(grr[ii]);
                        if (ii == 0)
                            grr[ii].Location = new Point(0, 0);
                        else
                        {
                            grr[ii].Location = new Point(0, grr[ii - 1].Bottom);
                        }
                        grr[ii].Text = reader[7].ToString();

                        Graphics g = CreateGraphics();

                        Label borrowID = new Label();
                        borrowID.Name = "borrowID" + (int.Parse(reader[0].ToString()));
                        grr[ii].Controls.Add(borrowID);
                        borrowID.Location = new Point(385, 21);
                        borrowID.Width = 100;
                        borrowID.Text = "BorrowID: " + int.Parse(reader[0].ToString());

                        Button returnB = new Button();
                        returnB.Name = "returnB-" + (int.Parse(reader[0].ToString()));
                        grr[ii].Controls.Add(returnB);
                        returnB.BackColor = Color.White;
                        returnB.ForeColor = Color.Black;
                        returnB.SetBounds(385, 36, 65, 30);
                        returnB.Text = "Return";
                        returnB.BringToFront();
                        returnB.Click += new EventHandler(returnButton_click);


                        Label lname = new Label();
                        lname.Name = "lname" + (ii + 1);
                        grr[ii].Controls.Add(lname);
                        lname.Location = new Point(15, 21);
                        SizeF size = g.MeasureString("Name: " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString(), lname.Font);
                        lname.Width = (int)size.Width;
                        lname.Text = "Name: " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString();

                        if (reader[14].ToString().Equals("Student"))
                        {
                            Label course = new Label();
                            course.Name = "course" + (ii + 1);
                            grr[ii].Controls.Add(course);
                            course.Location = new Point(215, 21);
                            course.Text = reader[5].ToString() + " - " + reader[6].ToString();
                        }

                        Label barcode = new Label();
                        barcode.Name = "barcode" + (ii + 1);
                        grr[ii].Controls.Add(barcode);
                        barcode.Location = new Point(15, 41);
                        size = g.MeasureString("Barcode: " + reader[8].ToString(), barcode.Font);
                        barcode.Width = 100;
                        barcode.Text = "Barcode: " + reader[8].ToString();
                        barcode.BringToFront();

                        Label accessNum = new Label();
                        accessNum.Name = "accessNum" + (ii + 1);
                        grr[ii].Controls.Add(accessNum);
                        accessNum.Location = new Point(15, 61);
                        size = g.MeasureString("Accession Number: " + reader[9].ToString(), barcode.Font);
                        accessNum.Width = (int)size.Width;
                        accessNum.Text = "Accession Number: " + reader[9].ToString();
                        accessNum.BringToFront();

                        Label callNum = new Label();
                        callNum.Name = "callNum" + (ii + 1);
                        grr[ii].Controls.Add(callNum);
                        callNum.Location = new Point(15, 81);
                        size = g.MeasureString("Call Number: " + reader[10].ToString(), barcode.Font);
                        callNum.Width = (int)size.Width;
                        callNum.Text = "Call Number: " + reader[10].ToString();
                        callNum.BringToFront();

                        Label lender = new Label();
                        lender.Name = "lender" + (ii + 1);
                        grr[ii].Controls.Add(lender);
                        lender.Location = new Point(215, 41);
                        size = g.MeasureString("Lender: " + reader[11].ToString(), barcode.Font);
                        lender.Width = (int)size.Width;
                        lender.Text = "Lender: " + reader[11].ToString();
                        lender.BringToFront();

                        Label date = new Label();
                        date.Name = "date" + (ii + 1);
                        grr[ii].Controls.Add(date);
                        date.Location = new Point(215, 61);
                        size = g.MeasureString("Date Borrowed: " + reader[1].ToString(), barcode.Font);
                        date.Width = (int)size.Width;
                        date.Text = "Date Borrowed: " + reader[1].ToString();
                        date.BringToFront();

                        if (reader[14].ToString().Equals("Student"))
                        {
                            Label returnBy = new Label();
                            returnBy.Name = "returnBy" + (ii + 1);
                            grr[ii].Controls.Add(returnBy);
                            returnBy.Location = new Point(215, 81);
                            size = g.MeasureString("Return On or Before: " + reader[12].ToString(), barcode.Font);
                            returnBy.Width = (int)size.Width;
                            returnBy.Text = "Return On or Before: " + reader[12].ToString();
                            returnBy.BringToFront();
                        }

                        Label status = new Label();
                        status.Name = "status" + (ii + 1);
                        grr[ii].Controls.Add(status);
                        status.Location = new Point(15, 101);
                        size = g.MeasureString("Status: " + reader[13].ToString(), barcode.Font);
                        status.Width = (int)size.Width;
                        status.Text = "Status: " + reader[13].ToString();
                        status.BringToFront();
                        mainP.Invalidate();

                        if (reader[14].ToString().Equals("Student"))
                        {
                            DateTime returnDate = DateTime.Parse(reader[12].ToString());
                            int fineAmount = 0;
                            if (DateTime.Now > returnDate)
                            {
                                TimeSpan overdue = DateTime.Now - returnDate;
                                int days = ((int)overdue.TotalMinutes / 60) / 24 + 1;
                                fineAmount = days * 10;
                            }

                            Label fine = new Label();
                            fine.Name = "fine" + (ii + 1);
                            grr[ii].Controls.Add(fine);
                            fine.Location = new Point(215, 101);
                            fine.Width = 100;
                            fine.Text = "Fine: " + fineAmount.ToString() + " PESOS";
                            fine.BringToFront();
                        }
                        ii++;
                        mainP.Invalidate();
                    }
                }
            }
            int x = 0;
        }
        private void returnButton_click(Object sender, EventArgs e)
        {
            Button button = sender as Button;
            string[] num = button.Name.Split('-');
            PasswordPrompt pass = new PasswordPrompt();
            pass.ShowDialog();
            if (password == pass.pw)
            {
                using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE borrowedBooks SET Status = 'Returned' WHERE borrowNumber =" + int.Parse(num[1]), conn))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Book returned!");
                        BorrowRefresh();
                    }
                }
            }
            else
                MessageBox.Show("Incorrect Password!");

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tab1.Hide();
            tab2.Hide();
            tab3.Hide();
            tab4.Hide();
            //timer interval
            t.Interval = 1000;  //in milliseconds

            t.Tick += new EventHandler(this.t_Tick);

            //start timer when form loads
            t.Start();  //this will use t_Tick() method
        }
        Timer t = new Timer();


        //timer eventhandler
        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            //padding leading zero
            if (hh < 10)
            {
                hoursLab.Text = "0" + hh.ToString();
            }
            else
            {
                hoursLab.Text = hh.ToString();
            }

            if (mm < 10)
            {
                minutesLab.Text = "0" + mm.ToString();
            }
            else
            {
                minutesLab.Text = mm.ToString();
            }

            if (ss < 10)
            {
                secondsLab.Text = "0" + ss.ToString();
            }
            else
            {
                secondsLab.Text = ss.ToString();
            }

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            AddUsers addU = new AddUsers();
            addU.password = password;
            addU.Show();
        }
        bool studRad = false;
        bool bookRadCheck = false;
        string borrower;
        private void studentRad_CheckedChanged(object sender, EventArgs e)
        {
            if (studentRad.Checked)
            {
                borrower = "Student";
                studRad = true;
                borrowFName.Enabled = true;
                borrowLName.Enabled = true;
                borrowMName.Enabled = true;
                borrowCourseCom.Enabled = true;
                int i2 = 0;
                while (i2 < courseLim - 2)
                {
                    borrowCourseCom.Items.Add(course[i2]);
                    i2++;
                }
                borrowYearSec.Enabled = true;
                borrowTitle.Enabled = true;
                borrowBar.Enabled = true;
                borrowAccess.Enabled = true;
                borrowCall.Enabled = true;
                panel3.Enabled = true;
                borrowBookBtn.Enabled = true;

            }
        }

        private void facultyRad_CheckedChanged(object sender, EventArgs e)
        {
            if (facultyRad.Checked)
            {
                borrower = "Faculty";
                studRad = true;
                borrowFName.Enabled = true;
                borrowLName.Enabled = true;
                borrowMName.Enabled = true;
                borrowYearSec.Enabled = false;
                borrowCourseCom.Enabled = false;
                borrowYearSec.Clear();
                borrowCourseCom.Items.Clear();
                borrowTitle.Enabled = true;
                borrowBar.Enabled = true;
                borrowAccess.Enabled = true;
                borrowCall.Enabled = true;
                panel3.Enabled = true;
                borrowBookBtn.Enabled = true;
            }
        }

        private void bookRad_CheckedChanged(object sender, EventArgs e)
        {
            if (bookRad.Checked)
            {
                bookRadCheck = true;
            }
        }

        private void fictionRad_CheckedChanged(object sender, EventArgs e)
        {
            if (fictionRad.Checked)
            {
                bookRadCheck = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tab2.Hide();
            tab3.Hide();
            tab4.Hide();
            tab1.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            tab1.Hide();
            tab3.Hide();
            tab4.Hide();
            tab2.Show();
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            tab1.Hide();
            tab2.Hide();
            tab4.Hide();
            tab3.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tab1.Hide();
            tab3.Hide();
            tab2.Hide();
            tab4.Show();
        }
    }
}

