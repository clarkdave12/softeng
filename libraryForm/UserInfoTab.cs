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
    public partial class UserInfoTab : UserControl
    {
        // Singleton Instance

        private static UserInfoTab instance;

        public static UserInfoTab Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserInfoTab();
                return instance;
            }
        }

        // Grid View Row index Declaration
        int index = 0;

        public UserInfoTab()
        {
            InitializeComponent();
            SetStudentRecords(StudentsController.GetStudents());
        }

        // Get Students record method
        private void SetStudentRecords(List<Student> payload)
        {
            List<Student> students = payload;

            int r = 0;
            studentsRecord.Rows.Clear();
            foreach(Student student in students)
            {
                studentsRecord.Rows.Add();
                
                studentsRecord.Rows[r].Cells[0].Value = student.studentNumber;
                studentsRecord.Rows[r].Cells[1].Value = student.lastName;
                studentsRecord.Rows[r].Cells[2].Value = student.firstName;
                studentsRecord.Rows[r].Cells[3].Value = student.middleInitials;
                studentsRecord.Rows[r].Cells[4].Value = student.course;
                studentsRecord.Rows[r].Cells[5].Value = SetGender(student.gender);
                r++;
            }
        }

        private static string SetGender(string gender)
        {
            if (gender == "True")
                return "Male";
            else
                return "Female";
        }


        public void search()
        {
            string q = searchbox.Text;

            if (q != "")
                SetStudentRecords(StudentsController.SearchStudent(q));
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
            Add_Students addStudent = new Add_Students();
            if(addStudent.ShowDialog() == DialogResult.OK)
            {
                SetStudentRecords(StudentsController.GetStudents());
            }
        }

        private void deleteStudbtn_Click(object sender, EventArgs e)
        {
            if (studentsRecord.Rows.Count >= 2)
            {
                if (studentsRecord.SelectedRows.Count == 1 && studentsRecord.CurrentRow.Cells[0].Value != null)
                {
                    int row = studentsRecord.CurrentCell.RowIndex;
                    string studNum = studentsRecord.Rows[row].Cells[0].Value.ToString();
                    string delCourse = studentsRecord.Rows[row].Cells[4].Value.ToString();
                    DialogResult dialog = new DialogResult();
                    dialog = MessageBox.Show("Confirm delete student?", "Warning", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        StudentsController.DeleteStudent(studNum);
                        searchbox_ButtonClick(null, null);
                    }
                }
                else
                    MessageBox.Show("No student selected!");
            }
            focusHere.Focus();
            SetStudentRecords(StudentsController.GetStudents());
        }

        private void searchbox_ButtonClick(object sender, EventArgs e)
        {
            search();
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            if (studentsRecord.Rows.Count >= 2)
            {
                if (studentsRecord.SelectedRows.Count == 1 && studentsRecord.CurrentRow.Cells[0].Value != null && !clipPanel.Visible)
                {
                    Clipboard.SetText(studentsRecord.CurrentRow.Cells[0].Value.ToString());
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
            if (studentsRecord.Rows.Count >= 2)
            {
                if (studentsRecord.SelectedRows.Count == 1 && studentsRecord.CurrentRow.Cells[0].Value != null)
                {
                    visitsLog visit = new visitsLog(studentsRecord.CurrentRow.Cells[0].Value.ToString(),
                                                    studentsRecord.CurrentRow.Cells[1].Value.ToString() + ", " +
                                                    studentsRecord.CurrentRow.Cells[2].Value.ToString() + " " +
                                                    studentsRecord.CurrentRow.Cells[3].Value.ToString());
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

        private string GetGender()
        {
            string g = "";
            string gender = gendercom.SelectedItem.ToString();

            if (gender.ToUpper() == "MALE")
                g = "Male";
            else if (gender.ToUpper() == "FEMALE")
                g = "Female";

            return g;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string studentNumber = editStudNo.Text;
            string lastName = lastNameBox.Text;
            string firstName = firstNameBox.Text;
            string middleInitials = midNameBox.Text;
            string course = coursebox.Text;
            string gender = GetGender();

            if(UpdateStudentValidation.Validate(studentNumber, firstName, lastName, middleInitials, course, gender))
            {
                StudentsController.UpdateStudent(studentNumber, lastName, firstName, middleInitials, course, gender);

                editStudNo.Text = "";
                lastNameBox.Text = "";
                firstNameBox.Text = "";
                midNameBox.Text = "";
                coursebox.Text = "";
                gendercom.SelectedText = "";

                lastNameBox.Enabled = false;
                firstNameBox.Enabled = false;
                midNameBox.Enabled = false;
                courseButton.Enabled = false;
                gendercom.Enabled = false;
                addbtn.Enabled = false;

                SetStudentRecords(StudentsController.GetStudents());
            }

        }

        private void courseButton_Click(object sender, EventArgs e)
        {
            SelectCourse select = new SelectCourse();
            if(select.ShowDialog() == DialogResult.OK)
            {
                coursebox.Text = select.c;
            }
        }

        private void updateRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            editStudNo.Text = this.studentsRecord.CurrentRow.Cells[0].Value.ToString();
            lastNameBox.Text = this.studentsRecord.CurrentRow.Cells[1].Value.ToString();
            firstNameBox.Text = this.studentsRecord.CurrentRow.Cells[2].Value.ToString();
            midNameBox.Text = this.studentsRecord.CurrentRow.Cells[3].Value.ToString();
            coursebox.Text = this.studentsRecord.CurrentRow.Cells[4].Value.ToString();
            string gender = this.studentsRecord.CurrentRow.Cells[5].Value.ToString();

            if (gender.ToLower() == "male")
            {
                gendercom.SelectedIndex = 0;
            }
            else
            {
                gendercom.SelectedValue = "Female";
            }

            if ((editStudNo.Text != "") && (lastNameBox.Text != "") && (firstNameBox.Text != "") && (midNameBox.Text != "") && coursebox.Text != "")
            {
                lastNameBox.Enabled = true;
                firstNameBox.Enabled = true;
                midNameBox.Enabled = true;
                courseButton.Enabled = true;
                gendercom.Enabled = true;
                addbtn.Enabled = true;
            }
        }

        private void copyStudentNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (studentsRecord.Rows.Count >= 2)
            {
                if (studentsRecord.SelectedRows.Count == 1 && studentsRecord.CurrentRow.Cells[0].Value != null && !clipPanel.Visible)
                {
                    Clipboard.SetText(studentsRecord.CurrentRow.Cells[0].Value.ToString());
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

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (studentsRecord.Rows.Count >= 2)
            {
                if (studentsRecord.SelectedRows.Count == 1 && studentsRecord.CurrentRow.Cells[0].Value != null)
                {
                    int row = studentsRecord.CurrentCell.RowIndex;
                    string studNum = studentsRecord.Rows[row].Cells[0].Value.ToString();
                    string delCourse = studentsRecord.Rows[row].Cells[4].Value.ToString();
                    DialogResult dialog = new DialogResult();
                    dialog = MessageBox.Show("Confirm delete student?", "Warning", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        StudentsController.DeleteStudent(studNum);
                        searchbox_ButtonClick(null, null);
                    }
                }
                else
                    MessageBox.Show("No student selected!");
            }
            focusHere.Focus();
            SetStudentRecords(StudentsController.GetStudents());
        }

    }
}
