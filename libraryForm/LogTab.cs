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
            Singleton.test.Name = "studNo";
            midTopPanel.Controls.Add(Singleton.test);
            Singleton.test.Location = studNo1.Location;
            Singleton.test.KeyDown += new KeyEventHandler(this.studNo_KeyDown);
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
            bool connOpen;
            connOpen = Connection.conn.State == ConnectionState.Closed ? false : true;
            if (!connOpen) Connection.OpenConnection();
            int i = 0;
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM weeklyStats WHERE weekLength = '" + week + "'", Connection.conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                while (i < Singleton.courseLim)
                {
                    // MessageBox.Show(week);
                    Singleton.getContWeek = this.Controls.Find(Singleton.course[i] + "week", true).FirstOrDefault() as Label;
                    Singleton.getContWeek.Text = reader[i + 2].ToString();
                    i++;
                }
            }
            if (!connOpen) Connection.CloseConnection();
        }
        private void RefreshMonthlyStats(string month)
        {
            bool connOpen;
            connOpen = Connection.conn.State == ConnectionState.Closed ? false : true;
            if (!connOpen) Connection.OpenConnection();
            
            int i = 0;
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM monthlyStats WHERE monthYear = '" + month + "'", Connection.conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                while (i < Singleton.courseLim)
                {
                    Singleton.getContWeek = this.Controls.Find(Singleton.course[i] + "month", true).FirstOrDefault() as Label;
                    Singleton.getContWeek.Text = reader[i + 2].ToString();
                    i++;
                }
                reader.Close();
            }
            if (!connOpen) Connection.CloseConnection();
        }
        private void RefreshTotal()
        {
            bool connOpen;
            connOpen = Connection.conn.State == ConnectionState.Closed ? false : true;
            if (!connOpen) Connection.OpenConnection();
            Label getContTotal;
            int i = 0;
            while (i < Singleton.courseLim)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT libraryVisits FROM studentinfo WHERE course = '" + Singleton.course[i] + "'", Connection.conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    int totalVisits = 0;
                    while (reader.Read())
                    {
                        totalVisits += int.Parse(reader[0].ToString());
                    }
                    getContTotal = this.Controls.Find(Singleton.course[i] + "total", true).FirstOrDefault() as Label;
                    getContTotal.Text = totalVisits.ToString();
                    reader.Close();
                    i++;
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM othersInfo WHERE department = 'Guest'", Connection.conn))
            {
                int count = (int)cmd.ExecuteScalar();
                Otherstotal.Text = count.ToString();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM othersInfo WHERE department != 'Guest'", Connection.conn))
            {
                int count = (int)cmd.ExecuteScalar();
                Facultytotal.Text = count.ToString();
            }
            if (!connOpen) Connection.CloseConnection();
        }
        private void RefreshDailyStats(string day)
        {
            bool connOpen;
            connOpen = Connection.conn.State == ConnectionState.Closed ? false : true;
            if (!connOpen) Connection.OpenConnection();
            int i = 0;
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dailyStats WHERE  date = '" + day + "'", Connection.conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                while (i < Singleton.courseLim)
                {
                    Singleton.getContWeek = this.Controls.Find(Singleton.course[i] + "today", true).FirstOrDefault() as Label;
                    Singleton.getContWeek.Text = reader[i + 2].ToString();
                    i++;
                }
                reader.Close();
            }
            if (!connOpen) Connection.CloseConnection();
        }

        private void noidCB_CheckedChanged(object sender, EventArgs e)
        {
            if (noidCB.Checked)
            {
                Singleton.noID= true;
                Singleton.newOffense= 1;
            }
            else
            {
                Singleton.noID= false;
                Singleton.newOffense= 0;
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
            Connection.OpenConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentinfo WHERE studentID = '" + Singleton.test.Text + "'", Connection.conn))
            {
                int count = (int)cmd.ExecuteScalar();
                check = (count > 0) ? true : false;
            }
            if (check)
            {
                string loginCourse;
                int offense;
                using (SqlCommand cmd = new SqlCommand("SELECT course, Offense FROM studentinfo WHERE studentID = '" + Singleton.test.Text + "'", Connection.conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    loginCourse = reader[0].ToString();
                    offense = int.Parse(reader[1].ToString());
                    reader.Close();
                }
                if ((offense == 0 && !Singleton.noID) ||
                    (offense == 1 && !Singleton.noID) ||
                    (offense == 0 && Singleton.noID))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE studentinfo SET libraryVisits = libraryVisits + 1, lastVisit = '" + date + "', Offense = " + Singleton.newOffense+ " WHERE  studentID = '" + Singleton.test.Text + "'", Connection.conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    string today = DateTime.Now.ToString("dddd");
                    if (!today.Equals("Sunday"))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE dailyStats SET " + loginCourse + " = " + loginCourse + " + 1 WHERE dayNumber = (SELECT MAX(dayNumber) FROM dailyStats)", Connection.conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE weeklyStats SET " + loginCourse + " = " + loginCourse + " + 1 WHERE weekNumber = (SELECT MAX(weekNumber) FROM weeklyStats)", Connection.conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE monthlyStats SET " + loginCourse + " = " + loginCourse + " + 1 WHERE monthNumber = (SELECT MAX(monthNumber) FROM monthlyStats)", Connection.conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO visitsLog (studentID, noID, dateTime) " +
                                                                                "VALUES ( '" + Singleton.test.Text + "',  " + Singleton.newOffense+ ", '" + DateTime.Now.ToString("dd MMM yyyy - hh:mm:ss tt") + "')", Connection.conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT libraryVisits FROM studentinfo WHERE course = '" + loginCourse + "'", Connection.conn))
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
                        using (SqlCommand cmd = new SqlCommand("SELECT " + loginCourse + " FROM dailyStats WHERE dayNumber = (SELECT MAX(dayNumber) FROM dailyStats)", Connection.conn))
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
                        using (SqlCommand cmd = new SqlCommand("SELECT " + loginCourse + " FROM weeklyStats WHERE weekNumber = (SELECT MAX(weekNumber) FROM weeklyStats)", Connection.conn))
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
                        using (SqlCommand cmd = new SqlCommand("SELECT " + loginCourse + " FROM monthlyStats WHERE monthNumber = (SELECT MAX(monthNumber) FROM monthlyStats)", Connection.conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            Label getContWeek = this.Controls.Find(loginCourse + "month", true).FirstOrDefault() as Label;
                            getContWeek.Text = reader[0].ToString();
                            reader.Close();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM studentInfo WHERE studentID = '" + Singleton.test.Text + "'", Connection.conn))
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
                    if (Singleton.noID)
                    {
                        MessageBox.Show("Student will not be permitted to enter next time.", "No ID");
                    }
                    Singleton.test.Clear();
                }
                else
                    MessageBox.Show("This student has a previous offense!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Singleton.test.Text))
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
                            Add_Students addStud = new Add_Students(true, Singleton.test.Text, noidCB.Checked ? true : false);
                            Singleton.test.Clear();
                            addStud.Show();
                        }
                    }
                }
            }
            Connection.CloseConnection();
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
            Connection.OpenConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM othersInfo", Connection.conn))
            {
                int count = (int)cmd.ExecuteScalar();
                Otherstotal.Text = count.ToString();
            }
            Connection.CloseConnection();
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

            Connection.OpenConnection();
            bool check2;
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM weeklyStats", Connection.conn))
            {
                int count = (int)cmd.ExecuteScalar();
                check2 = (count > 0) ? true : false;

            }
            if (check2)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM weeklyStats ORDER BY weekNumber DESC", Connection.conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    weekEnd = DateTime.Parse(reader[22].ToString());
                    reader.Close();
                }
                if (DateTime.Now > weekEnd)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO weeklyStats (weekLength, weekEnd) VALUES ('" + weekLength + "', '" + newWeekEnd + "')", Connection.conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO weeklyBookStats (weekLength, weekEnd) VALUES ('" + weekLength + "', '" + newWeekEnd + "')", Connection.conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO weeklyStats (weekLength, weekEnd) VALUES ('" + weekLength + "', '" + newWeekEnd + "')", Connection.conn))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand("INSERT INTO weeklyBookStats (weekLength, weekEnd) VALUES ('" + weekLength + "', '" + newWeekEnd + "')", Connection.conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM dailyStats", Connection.conn))
            {
                int count = (int)cmd.ExecuteScalar();
                check2 = (count > 0) ? true : false;

            }
            if (check2)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dailyStats ORDER BY dayNumber DESC", Connection.conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    weekEnd = DateTime.Parse(reader[22].ToString());
                    reader.Close();
                }
                if (DateTime.Now > weekEnd)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO dailyStats (Date, dayEnd) VALUES ('" + date + "','" + dayEnd + "')", Connection.conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO dailyBookStats (Date, dayEnd) VALUES ('" + date + "','" + dayEnd + "')", Connection.conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dailyStats (Date, dayEnd) VALUES ('" + date + "','" + dayEnd + "')", Connection.conn))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dailyBookStats (Date, dayEnd) VALUES ('" + date + "','" + dayEnd + "')", Connection.conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM monthlyStats", Connection.conn))
            {
                int count = (int)cmd.ExecuteScalar();
                check2 = (count > 0) ? true : false;

            }
            DateTime monthEnd;
            if (check2)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM monthlyStats ORDER BY monthNumber DESC", Connection.conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    monthEnd = DateTime.Parse(reader[22].ToString());
                    reader.Close();
                }
                if (DateTime.Now > monthEnd)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO monthlyStats (monthYear, monthEnd) VALUES ('" + monthYear + "', '" + newMonthEnd + "')", Connection.conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO monthlyBookStats (monthYear, monthEnd) VALUES ('" + monthYear + "', '" + newMonthEnd + "')", Connection.conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO monthlyStats (monthYear, monthEnd) VALUES ('" + monthYear + "', '" + newMonthEnd + "')", Connection.conn))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand("INSERT INTO monthlyBookStats (monthYear, monthEnd) VALUES ('" + monthYear + "', '" + newMonthEnd + "')", Connection.conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            int i = 2;
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.columns WHERE TABLE_NAME = 'dailyBookStats'", Connection.conn))
            {
                Singleton.booksLim = (int)cmd.ExecuteScalar();
                Singleton.booksLim = Singleton.booksLim - 1;
            }
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentinfo", Connection.conn))
            {
                int count = (int)cmd.ExecuteScalar();
                check2 = (count > 0) ? true : false;
            }
            i = 0;
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.columns WHERE TABLE_NAME = 'weeklyStats'", Connection.conn))
            {
                Singleton.courseLim = (int)cmd.ExecuteScalar();
                Singleton.courseLim = Singleton.courseLim - 3;
                Singleton.course = new string[Singleton.courseLim];
            }
            using (SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME FROM information_schema.columns WHERE TABLE_NAME = 'weeklyStats'", Connection.conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (i < 2 || i == Singleton.courseLim + 2)
                    {
                        i++;
                        continue;
                    }
                    Singleton.course[i - 2] = reader[0].ToString();
                    i++;
                }
                reader.Close();
                i = 0;
            }
            using (SqlCommand cmd = new SqlCommand("SELECT date FROM [dailyStats] ORDER BY dayNumber DESC", Connection.conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dailyCom.Items.Add(reader[0].ToString());
                }
                reader.Close();
                dailyCom.SelectedIndex = 0;
            }
            using (SqlCommand cmd = new SqlCommand("SELECT monthYear FROM [monthlyStats] ORDER BY monthNumber DESC", Connection.conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    monthlyCom.Items.Add(reader[0].ToString());
                }
                reader.Close();
                monthlyCom.SelectedIndex = 0;
            }
            using (SqlCommand cmd = new SqlCommand("SELECT weekLength FROM [weeklyStats] ORDER BY weekNumber DESC", Connection.conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    weeklyCom.Items.Add(reader[0].ToString());
                }
                reader.Close();
                weeklyCom.SelectedIndex = 0;
            }
            Connection.CloseConnection();
            RefreshTotal();
        }
    }
}
