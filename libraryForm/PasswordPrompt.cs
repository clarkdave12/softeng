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
    public partial class PasswordPrompt : Form
    {
        public string pw;
            public PasswordPrompt()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox1.Text) && e.KeyCode == Keys.Enter)
            {
                pw = textBox1.Text;
                Close();
            }
        }
    }
}
