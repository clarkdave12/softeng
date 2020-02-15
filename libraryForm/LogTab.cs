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
    public partial class LogTab : UserControl
    {
        public LogTab()
        {
            InitializeComponent();
            test.Name = "studNo";
            midTopPanel.Controls.Add(test);
            test.Location = studNo1.Location;
            test.KeyDown += new KeyEventHandler(this.studNo_KeyDown);
        }
        public bool checkifdbexists(string dbname)
        {
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=master;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
        public bool checkiftableexists(string tablename)
        {
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
        public void nosound(Button btnname, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnname.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void studNo_KeyDown(object sender, KeyEventArgs e)
        {
            nosound(logButton, e);
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void RefreshWeeklyStats(string week)
        {
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                int i = 0;

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM weeklyStats WHERE weekLength = '" + week + "'", conn))
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
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
        private void RefreshTotal()
        {
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                conn.Open();
                Label getContTotal;
                int i = 0;
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
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM othersInfo WHERE department = 'Guest'", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    Otherstotal.Text = count.ToString();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM othersInfo WHERE department != 'Guest'", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    Facultytotal.Text = count.ToString();
                }
            }
        }
        private void RefreshDailyStats(string day)
        {
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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

        Label getContWeek;
        string[] course;
        int courseLim;
        int booksLim;
        MyTextBox test = new MyTextBox();
        bool noID = false;
        int newOffense = 0;
        private void noidCB_CheckedChanged(object sender, EventArgs e)
        {
            if (noidCB.Checked)
            {
                noID = true;
                newOffense = 1;
            }
            else
            {
                noID = false;
                newOffense = 0;
            }
        }

        private void studNo1_KeyDown(object sender, KeyEventArgs e)
        {
            nosound(logButton, e);
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            bool check;
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentinfo WHERE studentID = '" + test.Text + "'", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    check = (count > 0) ? true : false;
                }
                if (check)
                {
                    string loginCourse;
                    int offense;
                    using (SqlCommand cmd = new SqlCommand("SELECT course, Offense FROM studentinfo WHERE studentID = '" + test.Text + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        loginCourse = reader[0].ToString();
                        offense = int.Parse(reader[1].ToString());
                        reader.Close();
                    }
                    if ((offense == 0 && !noID) ||
                        (offense == 1 && !noID) ||
                        (offense == 0 && noID))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE studentinfo SET libraryVisits = libraryVisits + 1, lastVisit = '" + date + "', Offense = " + newOffense + " WHERE  studentID = '" + test.Text + "'", conn))
                        {
                            cmd.ExecuteNonQuery();
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
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO visitsLog (studentID, noID, dateTime) " +
                                                                                    "VALUES ( '" + test.Text + "',  " + newOffense + ", '" + DateTime.Now.ToString("dd MMM yyyy - hh:mm:ss tt") + "')", conn))
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
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM studentInfo WHERE studentID = '" + test.Text + "'", conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            lastLog.Visible = true;
                            logName.Visible = true;
                            logNum.Visible = true;
                            logCourse.Visible = true;
                            logGender.Visible = true;
                            logVisits.Visible = true;
                            logLastVisit.Visible = true;
                            lastLogCourse.Visible = true;
                            lastLogGender.Visible = true;
                            lastLogName.Visible = true;
                            lastLogNum.Visible = true;
                            lastLogVisits.Visible = true;
                            lastLogLastVisit.Visible = true;
                            lastLogNum.Text = reader[0].ToString();
                            lastLogName.Text = reader[1].ToString() + ", " + reader[2].ToString() + " " + reader[3].ToString();
                            lastLogCourse.Text = reader[4].ToString();
                            lastLogGender.Text = reader[7].ToString();
                            lastLogVisits.Text = reader[9].ToString();
                            lastLogLastVisit.Text = reader[10].ToString();
                        }
                        if (noID)
                        {
                            MessageBox.Show("Student will not be permitted to enter next time.", "No ID");
                        }
                        test.Clear();
                    }
                    else
                        MessageBox.Show("This student has a previous offense!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(test.Text))
                    {
                        DialogResult dialog = MessageBox.Show("Student Number not found. Register new student?", "Not Found", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
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
                            {
                                Add_Students addStud = new Add_Students(true, test.Text, noidCB.Checked ? true : false);
                                test.Clear();
                                addStud.Show();
                            }
                        }
                    }
                }
            }
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
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM othersInfo", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    Otherstotal.Text = count.ToString();
                }
            }
        }

        private void LogTab_Paint(object sender, PaintEventArgs e)
        {
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

        private void LogTab_Load(object sender, EventArgs e)
        {
            if (!checkifdbexists("Library"))
            {
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=master;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    using (SqlCommand cmd = new SqlCommand("CREATE DATABASE Library", conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New database created!", "Welcome");
                    }
                }
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE studentInfo(studentID VARCHAR(100) NOT NULL, " +
                                                                                    "lName VARCHAR(100), " +
                                                                                    "fName VARCHAR(100), " +
                                                                                    "mName VARCHAR(100), " +
                                                                                    "course VARCHAR(100), " +
                                                                                    "yearSection VARCHAR(100) DEFAULT 'None', " +
                                                                                    "birthday VARCHAR(100) DEFAULT 'Unknown', " +
                                                                                    "gender VARCHAR(100), " +
                                                                                    "contact VARCHAR(100) DEFAULT '8-7000', " +
                                                                                    "libraryVisits INT DEFAULT 0, " +
                                                                                    "lastVisit VARCHAR(100), " +
                                                                                    "Offense INT DEFAULT 0, " +
                                                                                    "Primary Key(studentID))", conn))
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
            if (!checkiftableexists("weeklyStats"))
            {
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
                                                                                    "DateReturned VARCHAR(100) DEFAULT 'Unknown', " +
                                                                                    "FineAccumulated INT DEFAULT 0, " +
                                                                                    "PRIMARY KEY(borrowNumber))", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            if (!checkiftableexists("visitsLog"))
            {
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CREATE TABLE visitsLog(logNumber INT IDENTITY(1,1), " +
                                                                                    "studentID VARCHAR(20) NOT NULL, " +
                                                                                    "noID BIT DEFAULT 0, " +
                                                                                    "dateTime VARCHAR(30) NOT NULL)", conn))
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
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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



            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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


            }

            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
            }
            RefreshTotal();
        }
    }
}
