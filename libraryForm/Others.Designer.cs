namespace libraryForm
{
    partial class Others
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Others));
            this.facultySelect = new System.Windows.Forms.RadioButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.othersSelect = new System.Windows.Forms.RadioButton();
            this.nameBox = new MetroFramework.Controls.MetroTextBox();
            this.deptCom = new MetroFramework.Controls.MetroComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ITtoday = new MetroFramework.Controls.MetroLabel();
            this.logButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // facultySelect
            // 
            this.facultySelect.AutoSize = true;
            this.facultySelect.BackColor = System.Drawing.Color.White;
            this.facultySelect.Location = new System.Drawing.Point(3, 0);
            this.facultySelect.Name = "facultySelect";
            this.facultySelect.Size = new System.Drawing.Size(59, 17);
            this.facultySelect.TabIndex = 0;
            this.facultySelect.TabStop = true;
            this.facultySelect.Text = "Faculty";
            this.facultySelect.UseVisualStyleBackColor = false;
            this.facultySelect.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Location = new System.Drawing.Point(-13, -180);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(307, 500);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // othersSelect
            // 
            this.othersSelect.AutoSize = true;
            this.othersSelect.BackColor = System.Drawing.Color.White;
            this.othersSelect.Location = new System.Drawing.Point(68, 0);
            this.othersSelect.Name = "othersSelect";
            this.othersSelect.Size = new System.Drawing.Size(56, 17);
            this.othersSelect.TabIndex = 7;
            this.othersSelect.TabStop = true;
            this.othersSelect.Text = "Others";
            this.othersSelect.UseVisualStyleBackColor = false;
            this.othersSelect.CheckedChanged += new System.EventHandler(this.othersSelect_CheckedChanged);
            // 
            // nameBox
            // 
            // 
            // 
            // 
            this.nameBox.CustomButton.Image = null;
            this.nameBox.CustomButton.Location = new System.Drawing.Point(159, 1);
            this.nameBox.CustomButton.Name = "";
            this.nameBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.nameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nameBox.CustomButton.TabIndex = 1;
            this.nameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nameBox.CustomButton.UseSelectable = true;
            this.nameBox.CustomButton.Visible = false;
            this.nameBox.Enabled = false;
            this.nameBox.Lines = new string[0];
            this.nameBox.Location = new System.Drawing.Point(12, 48);
            this.nameBox.MaxLength = 32767;
            this.nameBox.Name = "nameBox";
            this.nameBox.PasswordChar = '\0';
            this.nameBox.PromptText = "Name";
            this.nameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameBox.SelectedText = "";
            this.nameBox.SelectionLength = 0;
            this.nameBox.SelectionStart = 0;
            this.nameBox.ShortcutsEnabled = true;
            this.nameBox.Size = new System.Drawing.Size(181, 23);
            this.nameBox.TabIndex = 8;
            this.nameBox.UseSelectable = true;
            this.nameBox.WaterMark = "Name";
            this.nameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // deptCom
            // 
            this.deptCom.Enabled = false;
            this.deptCom.FormattingEnabled = true;
            this.deptCom.ItemHeight = 23;
            this.deptCom.Items.AddRange(new object[] {
            "IIT",
            "BM",
            "GATE"});
            this.deptCom.Location = new System.Drawing.Point(12, 92);
            this.deptCom.Name = "deptCom";
            this.deptCom.Size = new System.Drawing.Size(146, 29);
            this.deptCom.TabIndex = 9;
            this.deptCom.UseSelectable = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.facultySelect);
            this.panel1.Controls.Add(this.othersSelect);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 23);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ITtoday
            // 
            this.ITtoday.AutoSize = true;
            this.ITtoday.FontSize = MetroFramework.MetroLabelSize.Small;
            this.ITtoday.Location = new System.Drawing.Point(12, 74);
            this.ITtoday.Name = "ITtoday";
            this.ITtoday.Size = new System.Drawing.Size(69, 15);
            this.ITtoday.TabIndex = 69;
            this.ITtoday.Text = "Department";
            // 
            // logButton
            // 
            this.logButton.Enabled = false;
            this.logButton.Location = new System.Drawing.Point(12, 136);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(127, 27);
            this.logButton.TabIndex = 70;
            this.logButton.Text = "Log Entry";
            this.logButton.UseSelectable = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // Others
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 195);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.ITtoday);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.deptCom);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.pictureBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Others";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Others";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton facultySelect;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton othersSelect;
        private MetroFramework.Controls.MetroTextBox nameBox;
        private MetroFramework.Controls.MetroComboBox deptCom;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel ITtoday;
        private MetroFramework.Controls.MetroButton logButton;
    }
}