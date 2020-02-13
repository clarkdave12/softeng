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
            this.coursecom = new MetroFramework.Controls.MetroComboBox();
            this.ITselect = new System.Windows.Forms.RadioButton();
            this.HMselect = new System.Windows.Forms.RadioButton();
            this.FMselect = new System.Windows.Forms.RadioButton();
            this.MMselect = new System.Windows.Forms.RadioButton();
            this.BEselect = new System.Windows.Forms.RadioButton();
            this.ENTREPselect = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.DDGTselect = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.EXTselect = new System.Windows.Forms.RadioButton();
            this.FSMselect = new System.Windows.Forms.RadioButton();
            this.BEEDselect = new System.Windows.Forms.RadioButton();
            this.MATHselect = new System.Windows.Forms.RadioButton();
            this.ENGselect = new System.Windows.Forms.RadioButton();
            this.FILselect = new System.Windows.Forms.RadioButton();
            this.SOCSCIselect = new System.Windows.Forms.RadioButton();
            this.SCIselect = new System.Windows.Forms.RadioButton();
            this.GBAselect = new System.Windows.Forms.RadioButton();
            this.coursePanel = new System.Windows.Forms.Panel();
            this.firstNameBox = new MetroFramework.Controls.MetroTextBox();
            this.midNameBox = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.coursePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 138);
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
            this.studnumbox.CustomButton.Location = new System.Drawing.Point(175, 1);
            this.studnumbox.CustomButton.Name = "";
            this.studnumbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.studnumbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.studnumbox.CustomButton.TabIndex = 1;
            this.studnumbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.studnumbox.CustomButton.UseSelectable = true;
            this.studnumbox.CustomButton.Visible = false;
            this.studnumbox.Lines = new string[0];
            this.studnumbox.Location = new System.Drawing.Point(43, 139);
            this.studnumbox.MaxLength = 32767;
            this.studnumbox.Name = "studnumbox";
            this.studnumbox.PasswordChar = '\0';
            this.studnumbox.PromptText = "Student Number (e.g. 2019500500)";
            this.studnumbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.studnumbox.SelectedText = "";
            this.studnumbox.SelectionLength = 0;
            this.studnumbox.SelectionStart = 0;
            this.studnumbox.ShortcutsEnabled = true;
            this.studnumbox.Size = new System.Drawing.Size(197, 23);
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
            this.lastNameBox.CustomButton.Location = new System.Drawing.Point(85, 1);
            this.lastNameBox.CustomButton.Name = "";
            this.lastNameBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.lastNameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.lastNameBox.CustomButton.TabIndex = 1;
            this.lastNameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lastNameBox.CustomButton.UseSelectable = true;
            this.lastNameBox.CustomButton.Visible = false;
            this.lastNameBox.Lines = new string[0];
            this.lastNameBox.Location = new System.Drawing.Point(43, 168);
            this.lastNameBox.MaxLength = 32767;
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.PasswordChar = '\0';
            this.lastNameBox.PromptText = "Last Name";
            this.lastNameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lastNameBox.SelectedText = "";
            this.lastNameBox.SelectionLength = 0;
            this.lastNameBox.SelectionStart = 0;
            this.lastNameBox.ShortcutsEnabled = true;
            this.lastNameBox.Size = new System.Drawing.Size(107, 23);
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
            this.gendercom.Location = new System.Drawing.Point(43, 294);
            this.gendercom.Name = "gendercom";
            this.gendercom.Size = new System.Drawing.Size(121, 29);
            this.gendercom.TabIndex = 8;
            this.gendercom.UseSelectable = true;
            this.gendercom.DropDown += new System.EventHandler(this.gendercom_DropDown);
            this.gendercom.DropDownClosed += new System.EventHandler(this.gendercom_DropDownClosed);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(43, 337);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(104, 33);
            this.addbtn.TabIndex = 11;
            this.addbtn.Text = "Add Student";
            this.addbtn.UseSelectable = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(153, 337);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 33);
            this.cancelbtn.TabIndex = 12;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseSelectable = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // coursecom
            // 
            this.coursecom.FormattingEnabled = true;
            this.coursecom.ItemHeight = 23;
            this.coursecom.Location = new System.Drawing.Point(175, 294);
            this.coursecom.Name = "coursecom";
            this.coursecom.Size = new System.Drawing.Size(147, 29);
            this.coursecom.TabIndex = 15;
            this.coursecom.UseSelectable = true;
            this.coursecom.Visible = false;
            this.coursecom.DropDown += new System.EventHandler(this.coursecom_DropDown);
            this.coursecom.SelectedIndexChanged += new System.EventHandler(this.coursecom_SelectedIndexChanged);
            this.coursecom.DropDownClosed += new System.EventHandler(this.coursecom_DropDownClosed);
            // 
            // ITselect
            // 
            this.ITselect.AutoSize = true;
            this.ITselect.Location = new System.Drawing.Point(15, 3);
            this.ITselect.Name = "ITselect";
            this.ITselect.Size = new System.Drawing.Size(35, 17);
            this.ITselect.TabIndex = 16;
            this.ITselect.TabStop = true;
            this.ITselect.Text = "IT";
            this.ITselect.UseVisualStyleBackColor = true;
            // 
            // HMselect
            // 
            this.HMselect.AutoSize = true;
            this.HMselect.Location = new System.Drawing.Point(15, 26);
            this.HMselect.Name = "HMselect";
            this.HMselect.Size = new System.Drawing.Size(42, 17);
            this.HMselect.TabIndex = 17;
            this.HMselect.TabStop = true;
            this.HMselect.Text = "HM";
            this.HMselect.UseVisualStyleBackColor = true;
            // 
            // FMselect
            // 
            this.FMselect.AutoSize = true;
            this.FMselect.Location = new System.Drawing.Point(15, 48);
            this.FMselect.Name = "FMselect";
            this.FMselect.Size = new System.Drawing.Size(40, 17);
            this.FMselect.TabIndex = 18;
            this.FMselect.TabStop = true;
            this.FMselect.Text = "FM";
            this.FMselect.UseVisualStyleBackColor = true;
            // 
            // MMselect
            // 
            this.MMselect.AutoSize = true;
            this.MMselect.Location = new System.Drawing.Point(15, 71);
            this.MMselect.Name = "MMselect";
            this.MMselect.Size = new System.Drawing.Size(43, 17);
            this.MMselect.TabIndex = 19;
            this.MMselect.TabStop = true;
            this.MMselect.Text = "MM";
            this.MMselect.UseVisualStyleBackColor = true;
            // 
            // BEselect
            // 
            this.BEselect.AutoSize = true;
            this.BEselect.Location = new System.Drawing.Point(65, 3);
            this.BEselect.Name = "BEselect";
            this.BEselect.Size = new System.Drawing.Size(39, 17);
            this.BEselect.TabIndex = 20;
            this.BEselect.TabStop = true;
            this.BEselect.Text = "BE";
            this.BEselect.UseVisualStyleBackColor = true;
            // 
            // ENTREPselect
            // 
            this.ENTREPselect.AutoSize = true;
            this.ENTREPselect.Location = new System.Drawing.Point(236, 3);
            this.ENTREPselect.Name = "ENTREPselect";
            this.ENTREPselect.Size = new System.Drawing.Size(69, 17);
            this.ENTREPselect.TabIndex = 21;
            this.ENTREPselect.TabStop = true;
            this.ENTREPselect.Text = "ENTREP";
            this.ENTREPselect.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(236, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 17);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "TOURISM";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // DDGTselect
            // 
            this.DDGTselect.AutoSize = true;
            this.DDGTselect.Location = new System.Drawing.Point(65, 26);
            this.DDGTselect.Name = "DDGTselect";
            this.DDGTselect.Size = new System.Drawing.Size(56, 17);
            this.DDGTselect.TabIndex = 23;
            this.DDGTselect.TabStop = true;
            this.DDGTselect.Text = "DDGT";
            this.DDGTselect.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(184, 71);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(78, 17);
            this.radioButton3.TabIndex = 24;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "COMTECH";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // EXTselect
            // 
            this.EXTselect.AutoSize = true;
            this.EXTselect.Location = new System.Drawing.Point(65, 48);
            this.EXTselect.Name = "EXTselect";
            this.EXTselect.Size = new System.Drawing.Size(46, 17);
            this.EXTselect.TabIndex = 25;
            this.EXTselect.TabStop = true;
            this.EXTselect.Text = "EXT";
            this.EXTselect.UseVisualStyleBackColor = true;
            // 
            // FSMselect
            // 
            this.FSMselect.AutoSize = true;
            this.FSMselect.Location = new System.Drawing.Point(65, 71);
            this.FSMselect.Name = "FSMselect";
            this.FSMselect.Size = new System.Drawing.Size(47, 17);
            this.FSMselect.TabIndex = 26;
            this.FSMselect.TabStop = true;
            this.FSMselect.Text = "FSM";
            this.FSMselect.UseVisualStyleBackColor = true;
            // 
            // BEEDselect
            // 
            this.BEEDselect.AutoSize = true;
            this.BEEDselect.Location = new System.Drawing.Point(124, 3);
            this.BEEDselect.Name = "BEEDselect";
            this.BEEDselect.Size = new System.Drawing.Size(54, 17);
            this.BEEDselect.TabIndex = 27;
            this.BEEDselect.TabStop = true;
            this.BEEDselect.Text = "BEED";
            this.BEEDselect.UseVisualStyleBackColor = true;
            // 
            // MATHselect
            // 
            this.MATHselect.AutoSize = true;
            this.MATHselect.Location = new System.Drawing.Point(124, 26);
            this.MATHselect.Name = "MATHselect";
            this.MATHselect.Size = new System.Drawing.Size(56, 17);
            this.MATHselect.TabIndex = 28;
            this.MATHselect.TabStop = true;
            this.MATHselect.Text = "MATH";
            this.MATHselect.UseVisualStyleBackColor = true;
            // 
            // ENGselect
            // 
            this.ENGselect.AutoSize = true;
            this.ENGselect.Location = new System.Drawing.Point(124, 48);
            this.ENGselect.Name = "ENGselect";
            this.ENGselect.Size = new System.Drawing.Size(48, 17);
            this.ENGselect.TabIndex = 29;
            this.ENGselect.TabStop = true;
            this.ENGselect.Text = "ENG";
            this.ENGselect.UseVisualStyleBackColor = true;
            // 
            // FILselect
            // 
            this.FILselect.AutoSize = true;
            this.FILselect.Location = new System.Drawing.Point(124, 71);
            this.FILselect.Name = "FILselect";
            this.FILselect.Size = new System.Drawing.Size(40, 17);
            this.FILselect.TabIndex = 30;
            this.FILselect.TabStop = true;
            this.FILselect.Text = "FIL";
            this.FILselect.UseVisualStyleBackColor = true;
            // 
            // SOCSCIselect
            // 
            this.SOCSCIselect.AutoSize = true;
            this.SOCSCIselect.Location = new System.Drawing.Point(184, 49);
            this.SOCSCIselect.Name = "SOCSCIselect";
            this.SOCSCIselect.Size = new System.Drawing.Size(64, 17);
            this.SOCSCIselect.TabIndex = 31;
            this.SOCSCIselect.TabStop = true;
            this.SOCSCIselect.Text = "SOCSCI";
            this.SOCSCIselect.UseVisualStyleBackColor = true;
            // 
            // SCIselect
            // 
            this.SCIselect.AutoSize = true;
            this.SCIselect.Location = new System.Drawing.Point(184, 3);
            this.SCIselect.Name = "SCIselect";
            this.SCIselect.Size = new System.Drawing.Size(42, 17);
            this.SCIselect.TabIndex = 32;
            this.SCIselect.TabStop = true;
            this.SCIselect.Text = "SCI";
            this.SCIselect.UseVisualStyleBackColor = true;
            // 
            // GBAselect
            // 
            this.GBAselect.AutoSize = true;
            this.GBAselect.Location = new System.Drawing.Point(184, 26);
            this.GBAselect.Name = "GBAselect";
            this.GBAselect.Size = new System.Drawing.Size(47, 17);
            this.GBAselect.TabIndex = 33;
            this.GBAselect.TabStop = true;
            this.GBAselect.Text = "GBA";
            this.GBAselect.UseVisualStyleBackColor = true;
            // 
            // coursePanel
            // 
            this.coursePanel.Controls.Add(this.ENTREPselect);
            this.coursePanel.Controls.Add(this.radioButton1);
            this.coursePanel.Controls.Add(this.ENGselect);
            this.coursePanel.Controls.Add(this.ITselect);
            this.coursePanel.Controls.Add(this.HMselect);
            this.coursePanel.Controls.Add(this.FMselect);
            this.coursePanel.Controls.Add(this.MMselect);
            this.coursePanel.Controls.Add(this.BEselect);
            this.coursePanel.Controls.Add(this.DDGTselect);
            this.coursePanel.Controls.Add(this.radioButton3);
            this.coursePanel.Controls.Add(this.EXTselect);
            this.coursePanel.Controls.Add(this.FSMselect);
            this.coursePanel.Controls.Add(this.BEEDselect);
            this.coursePanel.Controls.Add(this.GBAselect);
            this.coursePanel.Controls.Add(this.MATHselect);
            this.coursePanel.Controls.Add(this.SCIselect);
            this.coursePanel.Controls.Add(this.FILselect);
            this.coursePanel.Controls.Add(this.SOCSCIselect);
            this.coursePanel.Location = new System.Drawing.Point(29, 197);
            this.coursePanel.Name = "coursePanel";
            this.coursePanel.Size = new System.Drawing.Size(343, 91);
            this.coursePanel.TabIndex = 5;
            // 
            // firstNameBox
            // 
            // 
            // 
            // 
            this.firstNameBox.CustomButton.Image = null;
            this.firstNameBox.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.firstNameBox.CustomButton.Name = "";
            this.firstNameBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.firstNameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.firstNameBox.CustomButton.TabIndex = 1;
            this.firstNameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.firstNameBox.CustomButton.UseSelectable = true;
            this.firstNameBox.CustomButton.Visible = false;
            this.firstNameBox.Lines = new string[0];
            this.firstNameBox.Location = new System.Drawing.Point(156, 168);
            this.firstNameBox.MaxLength = 32767;
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.PasswordChar = '\0';
            this.firstNameBox.PromptText = "First Name";
            this.firstNameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.firstNameBox.SelectedText = "";
            this.firstNameBox.SelectionLength = 0;
            this.firstNameBox.SelectionStart = 0;
            this.firstNameBox.ShortcutsEnabled = true;
            this.firstNameBox.Size = new System.Drawing.Size(156, 23);
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
            this.midNameBox.CustomButton.Location = new System.Drawing.Point(19, 1);
            this.midNameBox.CustomButton.Name = "";
            this.midNameBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.midNameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.midNameBox.CustomButton.TabIndex = 1;
            this.midNameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.midNameBox.CustomButton.UseSelectable = true;
            this.midNameBox.CustomButton.Visible = false;
            this.midNameBox.Lines = new string[0];
            this.midNameBox.Location = new System.Drawing.Point(318, 168);
            this.midNameBox.MaxLength = 32767;
            this.midNameBox.Name = "midNameBox";
            this.midNameBox.PasswordChar = '\0';
            this.midNameBox.PromptText = "M.I.";
            this.midNameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.midNameBox.SelectedText = "";
            this.midNameBox.SelectionLength = 0;
            this.midNameBox.SelectionStart = 0;
            this.midNameBox.ShortcutsEnabled = true;
            this.midNameBox.Size = new System.Drawing.Size(41, 23);
            this.midNameBox.TabIndex = 4;
            this.midNameBox.UseSelectable = true;
            this.midNameBox.WaterMark = "M.I.";
            this.midNameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.midNameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Add_Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.midNameBox);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.coursecom);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.gendercom);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.studnumbox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.coursePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 450);
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "Add_Students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Student";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Add_Students_FormClosed);
            this.Shown += new System.EventHandler(this.Add_Students_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.coursePanel.ResumeLayout(false);
            this.coursePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox studnumbox;
        private MetroFramework.Controls.MetroTextBox lastNameBox;
        private MetroFramework.Controls.MetroComboBox gendercom;
        private MetroFramework.Controls.MetroButton addbtn;
        private MetroFramework.Controls.MetroButton cancelbtn;
        private MetroFramework.Controls.MetroComboBox coursecom;
        private System.Windows.Forms.RadioButton ITselect;
        private System.Windows.Forms.RadioButton HMselect;
        private System.Windows.Forms.RadioButton FMselect;
        private System.Windows.Forms.RadioButton MMselect;
        private System.Windows.Forms.RadioButton BEselect;
        private System.Windows.Forms.RadioButton ENTREPselect;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton DDGTselect;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton EXTselect;
        private System.Windows.Forms.RadioButton FSMselect;
        private System.Windows.Forms.RadioButton BEEDselect;
        private System.Windows.Forms.RadioButton MATHselect;
        private System.Windows.Forms.RadioButton ENGselect;
        private System.Windows.Forms.RadioButton FILselect;
        private System.Windows.Forms.RadioButton SOCSCIselect;
        private System.Windows.Forms.RadioButton SCIselect;
        private System.Windows.Forms.RadioButton GBAselect;
        private System.Windows.Forms.Panel coursePanel;
        private MetroFramework.Controls.MetroTextBox firstNameBox;
        private MetroFramework.Controls.MetroTextBox midNameBox;
    }
}