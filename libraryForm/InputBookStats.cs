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
    public partial class InputBookStats : Form
    {
        public string category;
        public string dateSelected, weekSelected, monthSelected;
        public bool today;
        public InputBookStats()
        {
            InitializeComponent();
        }

        private void InputBookStats_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputBox.Text))
            {
                if (today)
                {
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE dailyBookStats SET " + category + " = " + category + " + " + int.Parse(inputBox.Text) + "  WHERE recordNumber = (SELECT MAX(recordNumber) FROM dailyBookStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE weeklyBookStats SET " + category + " = " + category + " + " + int.Parse(inputBox.Text) + "  WHERE recordNumber = (SELECT MAX(recordNumber) FROM weeklyBookStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE monthlyBookStats SET " + category + " = " + category + " + " + int.Parse(inputBox.Text) + "  WHERE recordNumber = (SELECT MAX(recordNumber) FROM monthlyBookStats)", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Close();
                    }
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection("server=Library\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;Integrated Security=false;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE dailyBookStats SET " + category + " = " + category + " + " + int.Parse(inputBox.Text) + "  WHERE Date = '" + dateSelected + "'", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE weeklyBookStats SET " + category + " = " + category + " + " + int.Parse(inputBox.Text) + "  WHERE weekLength = '" + weekSelected + "'", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE monthlyBookStats SET " + category + " = " + category + " + " + int.Parse(inputBox.Text) + "  WHERE monthYear = '" + monthSelected + "'", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Close();
                    }
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                //   MetroFramework.MetroMessageBox.Show(this, "Only numerical digits allowed!");
            }
            nosound(acceptBtn, e);
        }
    }
}
