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
    public partial class Form1 : Form
    {
        public string username;
        public string name;
        public string password;
        public string accessLvl;
        public Form1()
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


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            button5.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button5.FlatAppearance.MouseOverBackColor = Color.Transparent;
            LOGS.FlatAppearance.MouseDownBackColor = Color.Transparent;
            LOGS.FlatAppearance.MouseOverBackColor = Color.Transparent;
            adminBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            adminBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;

            if (!string.IsNullOrWhiteSpace(this.name))
                welcomeLbl.Text = "Welcome " + name + "!";

            //timer interval
            t.Interval = 1000;  //in milliseconds
            t.Tick += new EventHandler(this.t_Tick);

            //start timer when form loads
            t.Start();  //this will use t_Tick() method


        }

        Timer t = new Timer();
        int fiveRefresh;

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
                fiveRefresh += 1000;
                if (fiveRefresh == 5000)
                {
                    fiveRefresh = 0;
                }
            }
        

        private void metroButton4_Click(object sender, EventArgs e)
        {
            AddUsers addU = new AddUsers();
            addU.password = password;
            addU.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Form Drop Shadow

        private const int CS_DROPSHADOW = 0x00020000;

        // Override the CreateParams property

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        //Form Dragging

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        int buttonCheck = 0;
        private void buttonDefault()
        {
            if (buttonCheck == 1)
            {
                button5.Text = button5.Text.Substring(0, button5.Text.Length - 2);
                button5.Font = new Font(button5.Font.Name, 20F);
                button5.BackColor = Color.FromArgb(62, 48, 207);
                button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(62, 48, 207);
            }
            else if (buttonCheck == 2)
            {
                LOGS.Text = LOGS.Text.Substring(0, LOGS.Text.Length - 2);
                LOGS.Font = new Font(LOGS.Font.Name, 20F);
                LOGS.BackColor = Color.FromArgb(62, 48, 207);
                LOGS.FlatAppearance.MouseOverBackColor = Color.FromArgb(62, 48, 207);
            }
            else if (buttonCheck == 3)
            {
                adminBtn.Text = adminBtn.Text.Substring(0, adminBtn.Text.Length - 2);
                adminBtn.Font = new Font(adminBtn.Font.Name, 20F);
                adminBtn.BackColor = Color.FromArgb(62, 48, 207);
                adminBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(62, 48, 207);
            }
            else if (buttonCheck == 4)
            {
                button4.Text = button4.Text.Substring(0, button4.Text.Length - 2);
                button4.Font = new Font(button4.Font.Name, 20F);
                button4.BackColor = Color.FromArgb(62, 48, 207);
                button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(62, 48, 207);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            buttonDefault();
            button5.Text += "  ";
            button5.Font = new Font(button5.Font.Name, 18F);
            button5.BackColor = Color.FromArgb(76, 62, 229);
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(76, 62, 229);
            button5.Controls.Add(panelYellow);
            panelYellow.Dock = DockStyle.Right;
            panelYellow.Visible = true;
            buttonCheck = 1;
            tab.SelectedTab = userInfoTab;
        }

        private void LOGS_Click(object sender, EventArgs e)
        {
            buttonDefault();
            LOGS.Text += "  ";
            LOGS.Font = new Font(LOGS.Font.Name, 18F);
            LOGS.BackColor = Color.FromArgb(76, 62, 229);
            LOGS.FlatAppearance.MouseOverBackColor = Color.FromArgb(76, 62, 229);
            LOGS.Controls.Add(panelYellow);
            panelYellow.Dock = DockStyle.Right;
            panelYellow.Visible = true;
            buttonCheck = 2;
            tab.ShowTab(testTab);
            tab.SelectedTab = testTab;
           // test.Focus();
        }

        private void adminBtn_Click_1(object sender, EventArgs e)
        {
            buttonDefault();
            adminBtn.Text += "  ";
            adminBtn.Font = new Font(adminBtn.Font.Name, 18F);
            adminBtn.BackColor = Color.FromArgb(76, 62, 229);
            adminBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(76, 62, 229);
            adminBtn.Controls.Add(panelYellow);
            panelYellow.Dock = DockStyle.Right;
            panelYellow.Visible = true;
            buttonCheck = 3;
            tab.ShowTab(adminTab);
            tab.SelectedTab = adminTab;
            oldpwBox.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonDefault();
            button4.Text += "  ";
            button4.Font = new Font(button4.Font.Name, 18F);
            button4.BackColor = Color.FromArgb(76, 62, 229);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(76, 62, 229);
            button4.Controls.Add(panelYellow);
            panelYellow.Dock = DockStyle.Right;
            panelYellow.Visible = true;
            buttonCheck = 4;
        }


        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateAccount_Click(object sender, EventArgs e)
        {
            MessageBox.Show(password);
            if (!string.IsNullOrWhiteSpace(nickNameBox.Text) && 
                !string.IsNullOrWhiteSpace(nameBox.Text) &&
                oldpwBox.Text.Equals(password) &&
                !string.IsNullOrWhiteSpace(newpwBox.Text))
            {
                using (SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;database=Library;User ID=sa;Password=bsusclibrary;integrated security=true;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE usersInfo SET name ='" + nickNameBox.Text + "', " +
                                                                                  "username ='" + nameBox.Text + "', " +
                                                                                  "password ='" + newpwBox.Text + "' " +
                                                                                  "WHERE username = '" + username + "'", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                username = nameBox.Text;
                MessageBox.Show("User Updated!", "Message");

            }
            else if(!oldpwBox.Equals(password))
                MessageBox.Show("Incorrect password");
            else
                MessageBox.Show("Incomplete fields");
        }
    }
}

