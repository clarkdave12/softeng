using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace libraryForm
{
    public partial class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            AutoSize = false; //Allows you to change height to have bottom padding
            BackColor = Color.White;
            ForeColor = Color.FromArgb(25, 25, 18);
            Font = new Font("Arial", 9F);
            Size = new Size(179, 21);
            TextAlign = HorizontalAlignment.Center;
            Controls.Add(new Label()
            { Height = 4, Dock = DockStyle.Bottom, BackColor = Color.FromArgb(107, 95, 231) });
        }
    }
}
