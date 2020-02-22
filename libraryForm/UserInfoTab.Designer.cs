namespace libraryForm
{
    partial class UserInfoTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.courseButton = new System.Windows.Forms.Button();
            this.coursebox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.midNameBox = new MetroFramework.Controls.MetroTextBox();
            this.firstNameBox = new MetroFramework.Controls.MetroTextBox();
            this.lastNameBox = new MetroFramework.Controls.MetroTextBox();
            this.editStudNo = new MetroFramework.Controls.MetroTextBox();
            this.addbtn = new MetroFramework.Controls.MetroButton();
            this.gendercom = new MetroFramework.Controls.MetroComboBox();
            this.searchbox = new MetroFramework.Controls.MetroTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.deleteStudbtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.visitBtn = new System.Windows.Forms.Button();
            this.focusHere = new System.Windows.Forms.Label();
            this.clipPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.studentsRecord = new System.Windows.Forms.DataGridView();
            this.studentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleInitials = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfVisits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyStudentNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel31.SuspendLayout();
            this.panel2.SuspendLayout();
            this.clipPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentsRecord)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(149)))), ((int)(((byte)(218)))));
            this.panel31.Controls.Add(this.panel2);
            this.panel31.Controls.Add(this.label27);
            this.panel31.Controls.Add(this.label26);
            this.panel31.Controls.Add(this.label25);
            this.panel31.Controls.Add(this.label23);
            this.panel31.Controls.Add(this.label4);
            this.panel31.Controls.Add(this.midNameBox);
            this.panel31.Controls.Add(this.firstNameBox);
            this.panel31.Controls.Add(this.lastNameBox);
            this.panel31.Controls.Add(this.editStudNo);
            this.panel31.Controls.Add(this.addbtn);
            this.panel31.Controls.Add(this.gendercom);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel31.ForeColor = System.Drawing.Color.White;
            this.panel31.Location = new System.Drawing.Point(1137, 0);
            this.panel31.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(387, 1048);
            this.panel31.TabIndex = 129;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.courseButton);
            this.panel2.Controls.Add(this.coursebox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(49, 372);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 90);
            this.panel2.TabIndex = 102;
            // 
            // courseButton
            // 
            this.courseButton.AutoSize = true;
            this.courseButton.BackColor = System.Drawing.Color.White;
            this.courseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.courseButton.Enabled = false;
            this.courseButton.FlatAppearance.BorderSize = 0;
            this.courseButton.ForeColor = System.Drawing.Color.Black;
            this.courseButton.Location = new System.Drawing.Point(186, 37);
            this.courseButton.Name = "courseButton";
            this.courseButton.Size = new System.Drawing.Size(110, 30);
            this.courseButton.TabIndex = 2;
            this.courseButton.Text = "Select";
            this.courseButton.UseVisualStyleBackColor = false;
            this.courseButton.Click += new System.EventHandler(this.courseButton_Click);
            // 
            // coursebox
            // 
            this.coursebox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.coursebox.Enabled = false;
            this.coursebox.Location = new System.Drawing.Point(3, 37);
            this.coursebox.Name = "coursebox";
            this.coursebox.Size = new System.Drawing.Size(177, 26);
            this.coursebox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Course";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(62, 45);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(247, 45);
            this.label27.TabIndex = 101;
            this.label27.Text = "Edit Student Info";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(45, 245);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(92, 20);
            this.label26.TabIndex = 99;
            this.label26.Text = "First Name";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(254, 180);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 20);
            this.label25.TabIndex = 98;
            this.label25.Text = "M.I.";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(45, 180);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(91, 20);
            this.label23.TabIndex = 97;
            this.label23.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(45, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 96;
            this.label4.Text = "Student Number";
            // 
            // midNameBox
            // 
            // 
            // 
            // 
            this.midNameBox.CustomButton.Image = null;
            this.midNameBox.CustomButton.Location = new System.Drawing.Point(40, 1);
            this.midNameBox.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.midNameBox.CustomButton.Name = "";
            this.midNameBox.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.midNameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.midNameBox.CustomButton.TabIndex = 1;
            this.midNameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.midNameBox.CustomButton.UseSelectable = true;
            this.midNameBox.CustomButton.Visible = false;
            this.midNameBox.Enabled = false;
            this.midNameBox.Lines = new string[0];
            this.midNameBox.Location = new System.Drawing.Point(252, 202);
            this.midNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.midNameBox.MaxLength = 32767;
            this.midNameBox.Name = "midNameBox";
            this.midNameBox.PasswordChar = '\0';
            this.midNameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.midNameBox.SelectedText = "";
            this.midNameBox.SelectionLength = 0;
            this.midNameBox.SelectionStart = 0;
            this.midNameBox.ShortcutsEnabled = true;
            this.midNameBox.Size = new System.Drawing.Size(74, 35);
            this.midNameBox.TabIndex = 46;
            this.midNameBox.UseSelectable = true;
            this.midNameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.midNameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // firstNameBox
            // 
            // 
            // 
            // 
            this.firstNameBox.CustomButton.Image = null;
            this.firstNameBox.CustomButton.Location = new System.Drawing.Point(242, 1);
            this.firstNameBox.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstNameBox.CustomButton.Name = "";
            this.firstNameBox.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.firstNameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.firstNameBox.CustomButton.TabIndex = 1;
            this.firstNameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.firstNameBox.CustomButton.UseSelectable = true;
            this.firstNameBox.CustomButton.Visible = false;
            this.firstNameBox.Enabled = false;
            this.firstNameBox.Lines = new string[0];
            this.firstNameBox.Location = new System.Drawing.Point(50, 266);
            this.firstNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstNameBox.MaxLength = 32767;
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.PasswordChar = '\0';
            this.firstNameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.firstNameBox.SelectedText = "";
            this.firstNameBox.SelectionLength = 0;
            this.firstNameBox.SelectionStart = 0;
            this.firstNameBox.ShortcutsEnabled = true;
            this.firstNameBox.Size = new System.Drawing.Size(276, 35);
            this.firstNameBox.TabIndex = 45;
            this.firstNameBox.UseSelectable = true;
            this.firstNameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.firstNameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lastNameBox
            // 
            // 
            // 
            // 
            this.lastNameBox.CustomButton.Image = null;
            this.lastNameBox.CustomButton.Location = new System.Drawing.Point(160, 1);
            this.lastNameBox.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastNameBox.CustomButton.Name = "";
            this.lastNameBox.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.lastNameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.lastNameBox.CustomButton.TabIndex = 1;
            this.lastNameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lastNameBox.CustomButton.UseSelectable = true;
            this.lastNameBox.CustomButton.Visible = false;
            this.lastNameBox.Enabled = false;
            this.lastNameBox.Lines = new string[0];
            this.lastNameBox.Location = new System.Drawing.Point(50, 202);
            this.lastNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastNameBox.MaxLength = 32767;
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.PasswordChar = '\0';
            this.lastNameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lastNameBox.SelectedText = "";
            this.lastNameBox.SelectionLength = 0;
            this.lastNameBox.SelectionStart = 0;
            this.lastNameBox.ShortcutsEnabled = true;
            this.lastNameBox.Size = new System.Drawing.Size(194, 35);
            this.lastNameBox.TabIndex = 44;
            this.lastNameBox.UseSelectable = true;
            this.lastNameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.lastNameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // editStudNo
            // 
            // 
            // 
            // 
            this.editStudNo.CustomButton.BackColor = System.Drawing.Color.Transparent;
            this.editStudNo.CustomButton.Image = null;
            this.editStudNo.CustomButton.Location = new System.Drawing.Point(238, 2);
            this.editStudNo.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editStudNo.CustomButton.Name = "";
            this.editStudNo.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.editStudNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.editStudNo.CustomButton.TabIndex = 1;
            this.editStudNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.editStudNo.CustomButton.UseSelectable = true;
            this.editStudNo.CustomButton.UseVisualStyleBackColor = false;
            this.editStudNo.CustomButton.Visible = false;
            this.editStudNo.Enabled = false;
            this.editStudNo.Lines = new string[0];
            this.editStudNo.Location = new System.Drawing.Point(50, 135);
            this.editStudNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editStudNo.MaxLength = 32767;
            this.editStudNo.Name = "editStudNo";
            this.editStudNo.PasswordChar = '\0';
            this.editStudNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.editStudNo.SelectedText = "";
            this.editStudNo.SelectionLength = 0;
            this.editStudNo.SelectionStart = 0;
            this.editStudNo.ShortcutsEnabled = true;
            this.editStudNo.Size = new System.Drawing.Size(276, 40);
            this.editStudNo.TabIndex = 42;
            this.editStudNo.UseSelectable = true;
            this.editStudNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.editStudNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // addbtn
            // 
            this.addbtn.Enabled = false;
            this.addbtn.Location = new System.Drawing.Point(50, 642);
            this.addbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(156, 51);
            this.addbtn.TabIndex = 41;
            this.addbtn.Text = "Update";
            this.addbtn.UseSelectable = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // gendercom
            // 
            this.gendercom.Enabled = false;
            this.gendercom.FormattingEnabled = true;
            this.gendercom.ItemHeight = 23;
            this.gendercom.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.gendercom.Location = new System.Drawing.Point(50, 575);
            this.gendercom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gendercom.Name = "gendercom";
            this.gendercom.Size = new System.Drawing.Size(180, 29);
            this.gendercom.TabIndex = 40;
            this.gendercom.UseSelectable = true;
            // 
            // searchbox
            // 
            // 
            // 
            // 
            this.searchbox.CustomButton.BackColor = System.Drawing.Color.Transparent;
            this.searchbox.CustomButton.Image = null;
            this.searchbox.CustomButton.Location = new System.Drawing.Point(234, 2);
            this.searchbox.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchbox.CustomButton.Name = "";
            this.searchbox.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.searchbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.searchbox.CustomButton.TabIndex = 1;
            this.searchbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.searchbox.CustomButton.UseSelectable = true;
            this.searchbox.CustomButton.UseVisualStyleBackColor = false;
            this.searchbox.DisplayIcon = true;
            this.searchbox.Lines = new string[0];
            this.searchbox.Location = new System.Drawing.Point(22, 78);
            this.searchbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchbox.MaxLength = 32767;
            this.searchbox.Name = "searchbox";
            this.searchbox.PasswordChar = '\0';
            this.searchbox.PromptText = "Student Number or Name";
            this.searchbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchbox.SelectedText = "";
            this.searchbox.SelectionLength = 0;
            this.searchbox.SelectionStart = 0;
            this.searchbox.ShortcutsEnabled = true;
            this.searchbox.ShowButton = true;
            this.searchbox.ShowClearButton = true;
            this.searchbox.Size = new System.Drawing.Size(272, 40);
            this.searchbox.TabIndex = 128;
            this.searchbox.UseSelectable = true;
            this.searchbox.WaterMark = "Student Number or Name";
            this.searchbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.searchbox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.searchbox_ButtonClick);
            this.searchbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchbox_KeyDown_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(303, 78);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 40);
            this.button1.TabIndex = 130;
            this.button1.Text = "Add Record";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteStudbtn
            // 
            this.deleteStudbtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteStudbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteStudbtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deleteStudbtn.FlatAppearance.BorderSize = 0;
            this.deleteStudbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteStudbtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteStudbtn.ForeColor = System.Drawing.Color.Black;
            this.deleteStudbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteStudbtn.Location = new System.Drawing.Point(458, 78);
            this.deleteStudbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteStudbtn.Name = "deleteStudbtn";
            this.deleteStudbtn.Size = new System.Drawing.Size(153, 40);
            this.deleteStudbtn.TabIndex = 131;
            this.deleteStudbtn.Text = "Delete Record";
            this.deleteStudbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteStudbtn.UseVisualStyleBackColor = false;
            this.deleteStudbtn.Click += new System.EventHandler(this.deleteStudbtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.copyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.copyBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.copyBtn.FlatAppearance.BorderSize = 0;
            this.copyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyBtn.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyBtn.ForeColor = System.Drawing.Color.Black;
            this.copyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copyBtn.Location = new System.Drawing.Point(620, 78);
            this.copyBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(153, 40);
            this.copyBtn.TabIndex = 135;
            this.copyBtn.Text = "Copy Student No.";
            this.copyBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.copyBtn.UseVisualStyleBackColor = false;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // visitBtn
            // 
            this.visitBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.visitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.visitBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.visitBtn.FlatAppearance.BorderSize = 0;
            this.visitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visitBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitBtn.ForeColor = System.Drawing.Color.Black;
            this.visitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.visitBtn.Location = new System.Drawing.Point(987, 78);
            this.visitBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.visitBtn.Name = "visitBtn";
            this.visitBtn.Size = new System.Drawing.Size(130, 40);
            this.visitBtn.TabIndex = 134;
            this.visitBtn.Text = "Visit History";
            this.visitBtn.UseVisualStyleBackColor = false;
            this.visitBtn.Click += new System.EventHandler(this.visitBtn_Click);
            // 
            // focusHere
            // 
            this.focusHere.AutoSize = true;
            this.focusHere.BackColor = System.Drawing.Color.Transparent;
            this.focusHere.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusHere.ForeColor = System.Drawing.Color.White;
            this.focusHere.Location = new System.Drawing.Point(16, 8);
            this.focusHere.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.focusHere.Name = "focusHere";
            this.focusHere.Size = new System.Drawing.Size(397, 55);
            this.focusHere.TabIndex = 133;
            this.focusHere.Text = "View Student Records";
            // 
            // clipPanel
            // 
            this.clipPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.clipPanel.Controls.Add(this.label1);
            this.clipPanel.Location = new System.Drawing.Point(586, 31);
            this.clipPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clipPanel.Name = "clipPanel";
            this.clipPanel.Size = new System.Drawing.Size(208, 34);
            this.clipPanel.TabIndex = 136;
            this.clipPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(10, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 28);
            this.label1.TabIndex = 102;
            this.label1.Text = "Added to clipboard!";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.studentsRecord);
            this.panel1.Location = new System.Drawing.Point(15, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 632);
            this.panel1.TabIndex = 137;
            // 
            // studentsRecord
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.studentsRecord.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.studentsRecord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.studentsRecord.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.studentsRecord.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.studentsRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentNumber,
            this.firstName,
            this.lastName,
            this.middleInitials,
            this.course,
            this.gender,
            this.numberOfVisits,
            this.lastVisit});
            this.studentsRecord.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.studentsRecord.DefaultCellStyle = dataGridViewCellStyle2;
            this.studentsRecord.Location = new System.Drawing.Point(0, 0);
            this.studentsRecord.Name = "studentsRecord";
            this.studentsRecord.ReadOnly = true;
            this.studentsRecord.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.studentsRecord.RowHeadersWidth = 20;
            this.studentsRecord.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.studentsRecord.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.studentsRecord.RowTemplate.Height = 28;
            this.studentsRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studentsRecord.Size = new System.Drawing.Size(1115, 632);
            this.studentsRecord.TabIndex = 0;
            // 
            // studentNumber
            // 
            this.studentNumber.HeaderText = "Student Number";
            this.studentNumber.Name = "studentNumber";
            this.studentNumber.ReadOnly = true;
            // 
            // firstName
            // 
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            // 
            // lastName
            // 
            this.lastName.HeaderText = "Last Name";
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            // 
            // middleInitials
            // 
            this.middleInitials.HeaderText = "M.I.";
            this.middleInitials.Name = "middleInitials";
            this.middleInitials.ReadOnly = true;
            // 
            // course
            // 
            this.course.HeaderText = "Course";
            this.course.Name = "course";
            this.course.ReadOnly = true;
            // 
            // gender
            // 
            this.gender.HeaderText = "Gender";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // numberOfVisits
            // 
            this.numberOfVisits.HeaderText = "Number Of Visits";
            this.numberOfVisits.Name = "numberOfVisits";
            this.numberOfVisits.ReadOnly = true;
            this.numberOfVisits.Visible = false;
            // 
            // lastVisit
            // 
            this.lastVisit.HeaderText = "Last Visits";
            this.lastVisit.Name = "lastVisit";
            this.lastVisit.ReadOnly = true;
            this.lastVisit.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyStudentNoToolStripMenuItem,
            this.updateRecordToolStripMenuItem,
            this.deleteRecordToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(226, 116);
            // 
            // copyStudentNoToolStripMenuItem
            // 
            this.copyStudentNoToolStripMenuItem.Name = "copyStudentNoToolStripMenuItem";
            this.copyStudentNoToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.copyStudentNoToolStripMenuItem.Text = "Copy Student No.";
            this.copyStudentNoToolStripMenuItem.Click += new System.EventHandler(this.copyStudentNoToolStripMenuItem_Click);
            // 
            // updateRecordToolStripMenuItem
            // 
            this.updateRecordToolStripMenuItem.Name = "updateRecordToolStripMenuItem";
            this.updateRecordToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.updateRecordToolStripMenuItem.Text = "Update Record";
            this.updateRecordToolStripMenuItem.Click += new System.EventHandler(this.updateRecordToolStripMenuItem_Click);
            // 
            // deleteRecordToolStripMenuItem
            // 
            this.deleteRecordToolStripMenuItem.Name = "deleteRecordToolStripMenuItem";
            this.deleteRecordToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.deleteRecordToolStripMenuItem.Text = "Delete Record";
            this.deleteRecordToolStripMenuItem.Click += new System.EventHandler(this.deleteRecordToolStripMenuItem_Click);
            // 
            // UserInfoTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(120)))), ((int)(((byte)(208)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clipPanel);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deleteStudbtn);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.visitBtn);
            this.Controls.Add(this.focusHere);
            this.Controls.Add(this.panel31);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserInfoTab";
            this.Size = new System.Drawing.Size(1524, 1048);
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.clipPanel.ResumeLayout(false);
            this.clipPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentsRecord)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroTextBox midNameBox;
        private MetroFramework.Controls.MetroTextBox firstNameBox;
        private MetroFramework.Controls.MetroTextBox lastNameBox;
        private MetroFramework.Controls.MetroTextBox editStudNo;
        private MetroFramework.Controls.MetroButton addbtn;
        private MetroFramework.Controls.MetroComboBox gendercom;
        private MetroFramework.Controls.MetroTextBox searchbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button deleteStudbtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button visitBtn;
        private System.Windows.Forms.Label focusHere;
        private System.Windows.Forms.Panel clipPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView studentsRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleInitials;
        private System.Windows.Forms.DataGridViewTextBoxColumn course;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfVisits;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastVisit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button courseButton;
        public System.Windows.Forms.TextBox coursebox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyStudentNoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRecordToolStripMenuItem;
    }
}
