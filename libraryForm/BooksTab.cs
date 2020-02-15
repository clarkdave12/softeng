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
    public partial class BooksTab : UserControl
    {
        public BooksTab()
        {
            InitializeComponent();

            parent = (Form1)this.ParentForm;

            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {

                conn.Open();
                int i = 0;
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
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM information_schema.columns WHERE TABLE_NAME = 'dailyBookStats'", conn))
                {
                    booksLim = (int)cmd.ExecuteScalar();
                    booksLim = booksLim - 1;
                }
                using (SqlCommand cmd = new SqlCommand("SELECT date FROM [dailyBookStats] ORDER BY recordNumber DESC", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dailyBooksCom1.Items.Add(reader[0].ToString());
                    }
                    booksDatesRad.Checked = true;
                    dailyBooksCom1.SelectedIndex = 0;
                    reader.Close();
                    booksDatesRad.Checked = true;
                }
            }

        }

        string[] course;
        int courseLim;
        int booksLim;

        bool studRad = false;
        bool bookRadCheck = false;

        Random R = new Random();
        List<GroupBox> grr = new List<GroupBox>();
        int colorAlternate = 0;

        int fineAmount = 0;
        Form1 parent;
        string borrower;
        string weekNow, monthYearNow;
        private void BorrowRefresh()
        {
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
                        if (colorAlternate % 2 == 0)
                            p.BackColor = Color.FromArgb(127, 120, 208);
                        else
                            p.BackColor = Color.FromArgb(53, 42, 181);
                        colorAlternate++;
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
                        grr[ii].Font = new Font("Segoe UI", 8F);

                        Graphics g = CreateGraphics();

                        Label borrowID = new Label();
                        borrowID.Name = "borrowID" + (int.Parse(reader[0].ToString()));
                        grr[ii].Controls.Add(borrowID);
                        borrowID.Location = new Point(385, 21);
                        borrowID.Width = 90;
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
                        SizeF size = g.MeasureString("Name: " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString(), grr[ii].Font);
                        lname.Width = (int)size.Width + 10;
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
                        size = g.MeasureString("Barcode: " + reader[8].ToString(), grr[ii].Font);
                        barcode.Width = (int)size.Width + 10;
                        barcode.Text = "Barcode: " + reader[8].ToString();
                        barcode.BringToFront();

                        Label accessNum = new Label();
                        accessNum.Name = "accessNum" + (ii + 1);
                        grr[ii].Controls.Add(accessNum);
                        accessNum.Location = new Point(15, 61);
                        size = g.MeasureString("Accession Number: " + reader[9].ToString(), grr[ii].Font);
                        accessNum.Width = (int)size.Width + 10;
                        accessNum.Text = "Accession Number: " + reader[9].ToString();
                        accessNum.BringToFront();

                        Label callNum = new Label();
                        callNum.Name = "callNum" + (ii + 1);
                        grr[ii].Controls.Add(callNum);
                        callNum.Location = new Point(15, 81);
                        size = g.MeasureString("Call Number: " + reader[10].ToString(), grr[ii].Font);
                        callNum.Width = (int)size.Width + 10;
                        callNum.Text = "Call Number: " + reader[10].ToString();
                        callNum.BringToFront();

                        Label lender = new Label();
                        lender.Name = "lender" + (ii + 1);
                        grr[ii].Controls.Add(lender);
                        lender.Location = new Point(215, 41);
                        lender.Font = new Font("Segoe UI", 8F);
                        lender.Text = "Lender: " + reader[11].ToString();
                        size = g.MeasureString(lender.Text, lender.Font);
                        lender.Width = (int)size.Width + 10;
                        lender.BringToFront();

                        Label date = new Label();
                        date.Name = "date" + (ii + 1);
                        grr[ii].Controls.Add(date);
                        date.Location = new Point(215, 61);
                        size = g.MeasureString("Date Borrowed: " + reader[1].ToString(), grr[ii].Font);
                        date.Width = (int)size.Width + 10;
                        date.Text = "Date Borrowed: " + reader[1].ToString();
                        date.BringToFront();

                        if (reader[14].ToString().Equals("Student"))
                        {
                            Label returnBy = new Label();
                            returnBy.Name = "returnBy" + (ii + 1);
                            grr[ii].Controls.Add(returnBy);
                            returnBy.Location = new Point(215, 81);
                            size = g.MeasureString("Return On or Before: " + reader[12].ToString(), grr[ii].Font);
                            returnBy.Width = (int)size.Width + 10;
                            returnBy.Text = "Return On or Before: " + reader[12].ToString();
                            returnBy.BringToFront();
                        }

                        Label status = new Label();
                        status.Name = "status" + (ii + 1);
                        grr[ii].Controls.Add(status);
                        status.Location = new Point(15, 101);
                        size = g.MeasureString("Status: " + reader[13].ToString(), grr[ii].Font);
                        status.Width = (int)size.Width + 10;
                        status.Text = "Status: " + reader[13].ToString();
                        status.BringToFront();
                        mainP.Invalidate();

                        if (reader[14].ToString().Equals("Student"))
                        {
                            DateTime returnDate = DateTime.Parse(reader[12].ToString());
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
                        lender.BringToFront();
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
            if (parent.password == pass.pw)
            {
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE borrowedBooks SET Status = 'Returned' WHERE borrowNumber =" + int.Parse(num[1]), conn))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Book returned!");
                        BorrowRefresh();
                    }
                    using (SqlCommand cmd = new SqlCommand("UPDATE borrowedBooks SET FineAccumulated = " + fineAmount + " WHERE borrowNumber =" + int.Parse(num[1]), conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    fineAmount = 0;
                }
            }
            else
                MessageBox.Show("Incorrect Password!");

        }
        private void RefreshDailyBookStats(string day)
        {
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
              
                int i = 2;

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dailyBookStats WHERE Date = '" + day + "'", conn))
                {
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
        private void RefreshWeeklyBookStats(string week)
        {
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                int i = 2;

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM weeklyBookStats WHERE weekLength = '" + week + "'", conn))
                {
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
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                int i = 2;

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM monthlyBookStats WHERE monthYear = '" + month + "'", conn))
                {
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
        private void borrowBookBtn_Click(object sender, EventArgs e)
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

                    string returnBy = returnTime.ToString("dd MMM yyyy") + " 12:00:00 PM";
                    using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
                                                                                          "Borrower," +
                                                                                          "DateReturned)" +
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
                                                                                          "'" + parent.name + "'," +
                                                                                          "'" + returnBy + "'," +
                                                                                          "'Borrowed'," +
                                                                                          "'" + borrower + "'," +
                                                                                          "'" + DateTime.Now.ToString() + "')", conn))
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
                    using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
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
                                                                                          "Borrower," +
                                                                                          "DateReturned)" +
                                                                                   "VALUES('" + date + "'," +
                                                                                          "'" + borrowLName.Text + "'," +
                                                                                          "'" + borrowFName.Text + "'," +
                                                                                          "'" + borrowMName.Text + "'," +
                                                                                          "'" + borrowTitle.Text + "'," +
                                                                                          "'" + borrowBar.Text + "'," +
                                                                                          "'" + borrowAccess.Text + "'," +
                                                                                          "'" + borrowCall.Text + "'," +
                                                                                          "'" + parent.name + "'," +
                                                                                          "'" + returnBy + "'," +
                                                                                          "'Borrowed'," +
                                                                                          "'" + borrower + "'," +
                                                                                          "'" + DateTime.Now.ToString() + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Book borrow successful!");
                        BorrowRefresh();
                    }
                }
            }
        }

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
        Label bookStats;
        private void UpdateStatValues(string category)
        {
            if (booksDatesRad.Checked)
            {
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT " + category + " FROM dailyBookStats WHERE Date = '" + dailyBooksCom1.Text + "'", conn))
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
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT " + category + " FROM weeklyBookStats WHERE weekLength = '" + dailyBooksCom1.Text + "'", conn))
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
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT " + category + " FROM monthlyBookStats WHERE monthYear = = '" + dailyBooksCom1.Text + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        bookStats = booksPanel.Controls.Find(category + "lab", true).FirstOrDefault() as Label;
                        bookStats.Text = reader[0].ToString();
                    }
                }
            }

        }
        private void GetWeekMonth()
        {
            DateTime dateSelected, weekStart, weekEnd;
            string monthNow, yearNow;
            string[] monthYear;
            string[] weekLength;
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT dayEnd FROM dailyBookStats WHERE Date = '" + dailyBooksCom1.Text + "'", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    dateSelected = DateTime.Parse(reader[0].ToString());
                    monthNow = dateSelected.ToString("MMMM");
                    yearNow = dateSelected.ToString("yyyy");
                    reader.Close();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT weekLength FROM weeklyBookStats", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        weekLength = reader[0].ToString().Split('-');
                        weekLength[0] = weekLength[0].Trim() + " 12:00:00 AM";
                        weekLength[1] = weekLength[1].Trim() + " 11:59:59 PM";
                        weekStart = DateTime.Parse(weekLength[0]);
                        weekEnd = DateTime.Parse(weekLength[1]);
                        if (dateSelected >= weekStart && dateSelected <= weekEnd)
                        {
                            weekNow = reader[0].ToString();
                            break;
                        }
                    }
                    reader.Close();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT monthYear FROM monthlyBookStats", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        monthYear = reader[0].ToString().Split('-');
                        if (monthNow.Equals(monthYear[0]) && yearNow.Equals(monthYear[1]))
                        {
                            monthYearNow = reader[0].ToString();
                            break;
                        }
                    }
                    reader.Close();
                }
            }
        }
        private void Abtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "GenReF_A";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("GenReF_A");
        }

        private void Bbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Philo_B_BJ";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Philo_B_BJ");
        }

        private void Cbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "History_C_F";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("History_C_F");
        }

        private void HAbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "SocSci_H_HA";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("SocSci_H_HA");
        }

        private void HJbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Economics_HB_HJ";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Economics_HB_HJ");
        }

        private void HXbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Sociology_HM_HX";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Sociology_HM_HX");
        }

        private void Gbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Geography_G";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Geography_G");
        }

        private void Jbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "PolSci_J_K";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("PolSci_J_K");
        }

        private void Lbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Education_L";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Education_L");
        }

        private void Mbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Music_M";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Music_M");
        }

        private void Nbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "FineArts_N";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("FineArts_N");
        }

        private void Sbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Agriculture_S";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Agriculture_S");
        }

        private void Qbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Sciences_Q";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Sciences_Q");
        }

        private void Rbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Medicine_R";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Medicine_R");
        }

        private void Tbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Technology_T";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Technology_T");
        }

        private void Zbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "LibSci_Z";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("LibSci_Z");
        }

        private void Perbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Periodicals";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Periodicals");
        }

        private void AVbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "AV_Materials";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("AV_Materials");
        }

        private void Thesisbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Thesis";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Thesis");
        }

        private void Fictionbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Fiction";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Fiction");
        }

        private void Filbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "Filipiniana";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("Filipiniana");
        }

        private void booksDatesRad_CheckedChanged(object sender, EventArgs e)
        {
            if (booksDatesRad.Checked)
            {
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT date FROM [dailyStats] ORDER BY dayNumber DESC", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            dailyBooksCom1.Items.Add(reader[0].ToString());
                        }
                        dailyBooksCom1.SelectedIndex = 0;
                        reader.Close();
                    }
                }
            }
        }

        private void booksWeeksRad_CheckedChanged(object sender, EventArgs e)
        {
            if (booksWeeksRad.Checked)
            {
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT weekLength FROM [weeklyStats] ORDER BY weekNumber DESC", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            dailyBooksCom1.Items.Add(reader[0].ToString());
                        }
                        dailyBooksCom1.SelectedIndex = 0;
                        reader.Close();
                    }
                }
            }
        }

        private void booksMonthsRad_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT monthYear FROM [monthlyStats] ORDER BY monthNumber DESC", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dailyBooksCom1.Items.Add(reader[0].ToString());
                    }
                    dailyBooksCom1.SelectedIndex = 0;
                    reader.Close();
                }
            }

        }

        private void datesBtn_Click(object sender, EventArgs e)
        {
            booksDatesRad.Checked = true;
            booksLbl.Text = "Date";
            booksLbl.Focus();
        }

        private void weeksBtn_Click(object sender, EventArgs e)
        {
            booksWeeksRad.Checked = true;
            booksLbl.Text = "Week";
            booksLbl.Focus();
        }

        private void monthsBtn_Click(object sender, EventArgs e)
        {
            booksMonthsRad.Checked = true;
            booksLbl.Text = "Month";
            booksLbl.Focus();
        }

        private void dailyBooksCom1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (booksDatesRad.Checked)
            {
                RefreshDailyBookStats(dailyBooksCom1.Text);
            }
            else if (booksWeeksRad.Checked)
            {
                //   MessageBox.Show(dailyBooksCom1.Text);
                RefreshWeeklyBookStats(dailyBooksCom1.Text);
            }
            else if (booksMonthsRad.Checked)
            {
                RefreshMonthlyBookStats(dailyBooksCom1.Text);
            }
        }

        private void PZbtn_Click(object sender, EventArgs e)
        {
            InputBookStats books = new InputBookStats();
            books.category = "LanguageLit_P_PZ";
            if (dailyBooksCom1.SelectedIndex != 0 && booksDatesRad.Checked)
            {
                GetWeekMonth();
                books.dateSelected = dailyBooksCom1.Text;
                books.weekSelected = weekNow;
                books.monthSelected = monthYearNow;
                books.today = false;
                books.ShowDialog();
            }
            else
            {
                books.today = true;
                books.ShowDialog();
            }
            UpdateStatValues("LanguageLit_P_PZ");
        }


    }
}
