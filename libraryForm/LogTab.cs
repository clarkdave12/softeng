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

using libraryForm.Controllers;
using libraryForm.Validations;

namespace libraryForm
{
    public partial class LogTab : UserControl
    {

        // Singleton Instance
        private static LogTab instance;

        public static LogTab Instance
        {
            get
            {
                if (instance == null)
                    instance = new LogTab();
                return instance;
            }
        }

        public LogTab()
        {
            InitializeComponent();
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
            string studentNumber = studNo1.Text;
            if (e.KeyCode == Keys.Enter)
            {
                if(AddStudentValidations.CheckStudentNumber(studentNumber))
                {
                    DisplayRecord(studentNumber);
                }
                else
                {
                    MessageBox.Show("Student Number not found");
                }
            }
                
        }

        private void DisplayRecord(string studentNumber)
        {
            List<Student> students = LogsController.GetStudentLog(studentNumber);

            foreach (Student student in students)
            {
                lastLogNum.Text = student.studentNumber;
                lastLogName.Text = student.lastName + ", " + student.firstName + " " + student.middleInitials;
                lastLogCourse.Text = student.course;
                lastLogGender.Text = student.gender;
                lastLogVisits.Text = student.numberOfVisits;
                lastLogLastVisit.Text = student.lastVisit;
            }

        }

        private void logButton_Click(object sender, EventArgs e)
        {
            string studentNumber = lastLogNum.Text;
            int off = LogsController.GetOffenses(studentNumber);

            if(noidCB.Checked)
            {
                if (off <= 1)
                {
                    AddLog(studentNumber);
                }
                else
                {
                    MessageBox.Show("This student Has " + off + " Offense(s)");
                }
            }
            else
            {
                AddLog(studentNumber);
            }
        }

        private void AddLog(string studentNumber)
        {
            int id = 0;

            if (noidCB.Checked)
                id = 1;
            else
                id = 0;

            if (LogsValidation.StudentValidate(studentNumber, id))
            {
                LogsController.AddLogs(studentNumber, id, "student");
            }
        }

        private void LogTab_Paint(object sender, PaintEventArgs e)
        {

        }

        private void othersButton_Click(object sender, EventArgs e)
        {
            Others form = new Others();
            form.ShowDialog();
        }

        private void DisplayLogs(string day, string month, string year, string identify)
        {
            List<Log> logs = LogsController.GetData(day, month, year, identify);

            int r = 0;
            logsRecord.Rows.Clear();

            foreach(Log log in logs)
            {
                logsRecord.Rows.Add();

                logsRecord.Rows[r].Cells[0].Value = log.label;
                logsRecord.Rows[r].Cells[1].Value = log.numberOfVisits;
                r++;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string day;
            string month;
            string year;
            string identify = "byDay";

            DateTime date = new DateTime();
            day = date.Day.ToString();
            month = date.Month.ToString();
            year = date.Year.ToString();

            DisplayLogs(day, month, year, identify);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string day = "";
            string month;
            string year;
            string identify = "byMonth";

            DateTime date = DateTime.Now;
            month = date.Month.ToString();
            year = date.Year.ToString();
            DisplayLogs(day, month, year, identify);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string day = datePicker.Value.Day.ToString();
            string month = datePicker.Value.Month.ToString();
            string year = datePicker.Value.Year.ToString();
            string identify = "byDay";

            DisplayLogs(day, month, year, identify);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string day = "0";
            string month = datePicker.Value.Month.ToString();
            string year = datePicker.Value.Year.ToString();
            string identify = "byMonth";

            DisplayLogs(day, month, year, identify);
        }
    }
}
