using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryForm
{
    public partial class CL_MainWindow : Form
    {
        public CL_MainWindow()
        {
            InitializeComponent();
            FullScreen();
            ShowUserInfoTab();
        }

        //
        // Display windows as fullscreen
        //
        private void FullScreen()
        {
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        private void ShowUserInfoTab()
        {
            if(!mainPanel.Controls.Contains(UserInfoTab.Instance))
            {
                mainPanel.Controls.Add(UserInfoTab.Instance);
                UserInfoTab.Instance.Dock = DockStyle.Fill;
                UserInfoTab.Instance.BringToFront();
            }
            else
            {
                UserInfoTab.Instance.BringToFront();
            }
        }

        private void ShowLogTab()
        {
            if (!mainPanel.Controls.Contains(LogTab.Instance))
            {
                mainPanel.Controls.Add(LogTab.Instance);
                LogTab.Instance.Dock = DockStyle.Fill;
                LogTab.Instance.BringToFront();
            }
            else
            {
                LogTab.Instance.BringToFront();
            }
        }

        private void ShowBooksTab()
        {
            if(!mainPanel.Controls.Contains(BooksTab.Instance))
            {
                mainPanel.Controls.Add(BooksTab.Instance);
                BooksTab.Instance.Dock = DockStyle.Fill;
                BooksTab.Instance.BringToFront();
            }
            else
            {
                BooksTab.Instance.BringToFront();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LOGS_Click(object sender, EventArgs e)
        {
            ShowLogTab();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowUserInfoTab();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowBooksTab();
        }
    }
}
