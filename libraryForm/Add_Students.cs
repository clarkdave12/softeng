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

using libraryForm.Controllers;
using libraryForm.Validations;

namespace libraryForm
{
    public partial class Add_Students : Form
    {
        public Boolean oneTime;
        public bool noID;

        public Add_Students()
        {
            InitializeComponent();
            this.TopMost = true;
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

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private int GetGender()
        {
            int g = -1;
            string gender = gendercom.SelectedItem.ToString();

            if (gender.ToUpper() == "MALE")
                g = 1;
            else if (gender.ToUpper() == "FEMALE")
                g = 0;
      
            return g;
        }

        // Adding a student method
        private void AddStudent()
        {
            string studentNumber = studnumbox.Text;
            string lastName = lastNameBox.Text;
            string firstName = firstNameBox.Text;
            string middleInitials = midNameBox.Text;
            int gender = GetGender();
            string courseCode = course.Text;

            if (AddStudentValidations.Validate(studentNumber, firstName, lastName, middleInitials, gender, courseCode))
            {
                try
                {
                    StudentsController.AddStudentRecord(studentNumber, lastName, firstName, middleInitials, gender, courseCode);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void addbtn_Click_1(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectCourse select = new SelectCourse();
            if(select.ShowDialog() == DialogResult.OK)
            {
                course.Text = select.c;
            }
        }
    }
}
