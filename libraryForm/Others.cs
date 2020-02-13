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

namespace libraryForm
{
    public partial class Others : Form
    {
        public Others()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        bool faculty;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (facultySelect.Checked)
            {
                faculty = true;
                nameBox.Enabled = true;
                deptCom.Enabled = true;
                logButton.Enabled = true;
            }
        }

        private void othersSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (othersSelect.Checked)
            {
                faculty = false;
                nameBox.Enabled = true;
                deptCom.Enabled = false;
                logButton.Enabled = true;
            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            if (faculty)
            {
                if (!string.IsNullOrWhiteSpace(nameBox.Text) && !string.IsNullOrWhiteSpace(deptCom.Text))
                {
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO othersInfo (fullName, department) VALUES " +
                                                                                     "('" + nameBox.Text + "', '" + deptCom.Text + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE dailyStats SET Faculty = Faculty + 1 WHERE dayNumber = (SELECT MAX(dayNumber) FROM dailyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE weeklyStats SET Faculty = Faculty + 1 WHERE weekNumber = (SELECT MAX(weekNumber) FROM weeklyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE monthlyStats SET Faculty = Faculty + 1 WHERE monthNumber = (SELECT MAX(monthNumber) FROM monthlyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Guest logged!");
                    this.Close();
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(nameBox.Text))
                {
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO othersInfo (fullName) VALUES " +
                                                                                     "('" + nameBox.Text + "')", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE dailyStats SET Others = Others + 1 WHERE dayNumber = (SELECT MAX(dayNumber) FROM dailyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE weeklyStats SET Others = Others + 1 WHERE weekNumber = (SELECT MAX(weekNumber) FROM weeklyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE monthlyStats SET Others = Others + 1 WHERE monthNumber = (SELECT MAX(monthNumber) FROM monthlyStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Guest logged!");
                    this.Close();
                }
            }
        }
    }
}
