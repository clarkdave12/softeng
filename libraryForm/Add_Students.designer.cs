namespace libraryForm
{
    partial class Add_Students
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Students));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.studnumbox = new MetroFramework.Controls.MetroTextBox();
            this.lastNameBox = new MetroFramework.Controls.MetroTextBox();
            this.gendercom = new MetroFramework.Controls.MetroComboBox();
            this.addbtn = new MetroFramework.Controls.MetroButton();
            this.cancelbtn = new MetroFramework.Controls.MetroButton();
            this.firstNameBox = new MetroFramework.Controls.MetroTextBox();
            this.midNameBox = new MetroFramework.Controls.MetroTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.course = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-10, -11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(597, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // studnumbox
            // 
            // 
            // 
            // 
            this.studnumbox.CustomButton.Image = null;
            this.studnumbox.CustomButton.Location = new System.Drawing.Point(262, 1);
            this.studnumbox.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.studnumbox.CustomButton.Name = "";
            this.studnumbox.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.studnumbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.studnumbox.CustomButton.TabIndex = 1;
            this.studnumbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.studnumbox.CustomButton.UseSelectable = true;
            this.studnumbox.CustomButton.Visible = false;
            this.studnumbox.Lines = new string[0];
            this.studnumbox.Location = new System.Drawing.Point(64, 214);
            this.studnumbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.studnumbox.MaxLength = 32767;
            this.studnumbox.Name = "studnumbox";
            this.studnumbox.PasswordChar = '\0';
            this.studnumbox.PromptText = "Student Number (e.g. 2019500500)";
            this.studnumbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.studnumbox.SelectedText = "";
            this.studnumbox.SelectionLength = 0;
            this.studnumbox.SelectionStart = 0;
            this.studnumbox.ShortcutsEnabled = true;
            this.studnumbox.Size = new System.Drawing.Size(296, 35);
            this.studnumbox.TabIndex = 1;
            this.studnumbox.UseSelectable = true;
            this.studnumbox.WaterMark = "Student Number (e.g. 2019500500)";
            this.studnumbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.studnumbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.studnumbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.studnumbox_KeyDown);
            // 
            // lastNameBox
            // 
            // 
            // 
            // 
            this.lastNameBox.CustomButton.Image = null;
            this.lastNameBox.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.lastNameBox.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastNameBox.CustomButton.Name = "";
            this.lastNameBox.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.lastNameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.lastNameBox.CustomButton.TabIndex = 1;
            this.lastNameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lastNameBox.CustomButton.UseSelectable = true;
            this.lastNameBox.CustomButton.Visible = false;
            this.lastNameBox.Lines = new string[0];
            this.lastNameBox.Location = new System.Drawing.Point(64, 258);
            this.lastNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastNameBox.MaxLength = 32767;
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.PasswordChar = '\0';
            this.lastNameBox.PromptText = "Last Name";
            this.lastNameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lastNameBox.SelectedText = "";
            this.lastNameBox.SelectionLength = 0;
            this.lastNameBox.SelectionStart = 0;
            this.lastNameBox.ShortcutsEnabled = true;
            this.lastNameBox.Size = new System.Drawing.Size(160, 35);
            this.lastNameBox.TabIndex = 2;
            this.lastNameBox.UseSelectable = true;
            this.lastNameBox.WaterMark = "Last Name";
            this.lastNameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.lastNameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // gendercom
            // 
            this.gendercom.FormattingEnabled = true;
            this.gendercom.ItemHeight = 23;
            this.gendercom.Location = new System.Drawing.Point(64, 452);
            this.gendercom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gendercom.Name = "gendercom";
            this.gendercom.Size = new System.Drawing.Size(180, 29);
            this.gendercom.TabIndex = 8;
            this.gendercom.UseSelectable = true;
            this.gendercom.DropDown += new System.EventHandler(this.gendercom_DropDown);
            this.gendercom.DropDownClosed += new System.EventHandler(this.gendercom_DropDownClosed);
            // 
            // addbtn
            // 
            this.addbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addbtn.Location = new System.Drawing.Point(64, 518);
            this.addbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(156, 51);
            this.addbtn.TabIndex = 11;
            this.addbtn.Text = "Add Student";
            this.addbtn.UseSelectable = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click_1);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(230, 518);
            this.cancelbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(156, 51);
            this.cancelbtn.TabIndex = 12;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseSelectable = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // firstNameBox
            // 
            // 
            // 
            // 
            this.firstNameBox.CustomButton.Image = null;
            this.firstNameBox.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.firstNameBox.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstNameBox.CustomButton.Name = "";
            this.firstNameBox.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.firstNameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.firstNameBox.CustomButton.TabIndex = 1;
            this.firstNameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.firstNameBox.CustomButton.UseSelectable = true;
            this.firstNameBox.CustomButton.Visible = false;
            this.firstNameBox.Lines = new string[0];
            this.firstNameBox.Location = new System.Drawing.Point(234, 258);
            this.firstNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstNameBox.MaxLength = 32767;
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.PasswordChar = '\0';
            this.firstNameBox.PromptText = "First Name";
            this.firstNameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.firstNameBox.SelectedText = "";
            this.firstNameBox.SelectionLength = 0;
            this.firstNameBox.SelectionStart = 0;
            this.firstNameBox.ShortcutsEnabled = true;
            this.firstNameBox.Size = new System.Drawing.Size(234, 35);
            this.firstNameBox.TabIndex = 3;
            this.firstNameBox.UseSelectable = true;
            this.firstNameBox.WaterMark = "First Name";
            this.firstNameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.firstNameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // midNameBox
            // 
            // 
            // 
            // 
            this.midNameBox.CustomButton.Image = null;
            this.midNameBox.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.midNameBox.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.midNameBox.CustomButton.Name = "";
            this.midNameBox.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.midNameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.midNameBox.CustomButton.TabIndex = 1;
            this.midNameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.midNameBox.CustomButton.UseSelectable = true;
            this.midNameBox.CustomButton.Visible = false;
            this.midNameBox.Lines = new string[0];
            this.midNameBox.Location = new System.Drawing.Point(477, 258);
            this.midNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.midNameBox.MaxLength = 32767;
            this.midNameBox.Name = "midNameBox";
            this.midNameBox.PasswordChar = '\0';
            this.midNameBox.PromptText = "M.I.";
            this.midNameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.midNameBox.SelectedText = "";
            this.midNameBox.SelectionLength = 0;
            this.midNameBox.SelectionStart = 0;
            this.midNameBox.ShortcutsEnabled = true;
            this.midNameBox.Size = new System.Drawing.Size(62, 35);
            this.midNameBox.TabIndex = 4;
            this.midNameBox.UseSelectable = true;
            this.midNameBox.WaterMark = "M.I.";
            this.midNameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.midNameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.course);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(64, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 90);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course";
            // 
            // course
            // 
            this.course.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.course.Enabled = false;
            this.course.Location = new System.Drawing.Point(3, 37);
            this.course.Name = "course";
            this.course.Size = new System.Drawing.Size(177, 26);
            this.course.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(186, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add_Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(567, 606);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.midNameBox);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.gendercom);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.studnumbox);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(589, 662);
            this.MinimumSize = new System.Drawing.Size(589, 662);
            this.Name = "Add_Students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Student";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Add_Students_FormClosed);
            this.Shown += new System.EventHandler(this.Add_Students_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox studnumbox;
        private MetroFramework.Controls.MetroTextBox lastNameBox;
        private MetroFramework.Controls.MetroComboBox gendercom;
        private MetroFramework.Controls.MetroButton addbtn;
        private MetroFramework.Controls.MetroButton cancelbtn;
        private MetroFramework.Controls.MetroTextBox firstNameBox;
        private MetroFramework.Controls.MetroTextBox midNameBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox course;
    }
}