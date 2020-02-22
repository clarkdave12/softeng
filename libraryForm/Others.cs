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

using libraryForm.Controllers;

namespace libraryForm
{
    public partial class Others : Form
    {
        public Others()
        {
            InitializeComponent();
            this.TopMost = true;
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
            string department = "";
            string label = "";
            
            if (facultySelect.Checked)
            {
                label = "faculty";
                department = deptCom.SelectedItem.ToString();
            }
            else if (othersSelect.Checked)
            {
                label = "outside";
            }

            string fullName = nameBox.Text;
            

            LogsController.AddLogs(fullName, department, label, "others");
        }
    }
}
