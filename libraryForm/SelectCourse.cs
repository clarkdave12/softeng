using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using libraryForm.Controllers;

namespace libraryForm
{
    public partial class SelectCourse : Form
    {
        private string co;

        public string c
        {
            get { return co; }
            set { co = value; }
        }

        public SelectCourse()
        {
            InitializeComponent();
            GenerateCourses();
            this.TopMost = true;
        }

        private void GenerateCourses()
        {
            List<Course> courses = CoursesController.GetCourses();

            foreach (Course course in courses)
            {
                Button btn = new Button();
                btn.Size = new Size(60, 30);
                btn.Cursor = Cursors.Hand;
                btn.Click += btn_Click;
                btn.DialogResult = DialogResult.OK;
                btn.Text = course.courseCode;
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            co = btn.Text;
            this.Close();
        }
    }
}
