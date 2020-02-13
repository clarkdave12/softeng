namespace libraryForm
{
    partial class AddUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUsers));
            this.nameBox = new MetroFramework.Controls.MetroTextBox();
            this.usernameBox = new MetroFramework.Controls.MetroTextBox();
            this.pwBox = new MetroFramework.Controls.MetroTextBox();
            this.confirmpwBox = new MetroFramework.Controls.MetroTextBox();
            this.addUserBtn = new MetroFramework.Controls.MetroButton();
            this.accessPanel = new System.Windows.Forms.Panel();
            this.facultyRad = new System.Windows.Forms.RadioButton();
            this.studentRad = new System.Windows.Forms.RadioButton();
            this.accessPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            // 
            // 
            // 
            this.nameBox.CustomButton.Image = null;
            this.nameBox.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.nameBox.CustomButton.Name = "";
            this.nameBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.nameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nameBox.CustomButton.TabIndex = 1;
            this.nameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nameBox.CustomButton.UseSelectable = true;
            this.nameBox.CustomButton.Visible = false;
            this.nameBox.Lines = new string[0];
            this.nameBox.Location = new System.Drawing.Point(12, 33);
            this.nameBox.MaxLength = 32767;
            this.nameBox.Name = "nameBox";
            this.nameBox.PasswordChar = '\0';
            this.nameBox.PromptText = "Name";
            this.nameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameBox.SelectedText = "";
            this.nameBox.SelectionLength = 0;
            this.nameBox.SelectionStart = 0;
            this.nameBox.ShortcutsEnabled = true;
            this.nameBox.Size = new System.Drawing.Size(138, 23);
            this.nameBox.TabIndex = 2;
            this.nameBox.UseSelectable = true;
            this.nameBox.WaterMark = "Name";
            this.nameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // usernameBox
            // 
            // 
            // 
            // 
            this.usernameBox.CustomButton.Image = null;
            this.usernameBox.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.usernameBox.CustomButton.Name = "";
            this.usernameBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.usernameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.usernameBox.CustomButton.TabIndex = 1;
            this.usernameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.usernameBox.CustomButton.UseSelectable = true;
            this.usernameBox.CustomButton.Visible = false;
            this.usernameBox.Lines = new string[0];
            this.usernameBox.Location = new System.Drawing.Point(12, 62);
            this.usernameBox.MaxLength = 32767;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.PasswordChar = '\0';
            this.usernameBox.PromptText = "Username";
            this.usernameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernameBox.SelectedText = "";
            this.usernameBox.SelectionLength = 0;
            this.usernameBox.SelectionStart = 0;
            this.usernameBox.ShortcutsEnabled = true;
            this.usernameBox.Size = new System.Drawing.Size(138, 23);
            this.usernameBox.TabIndex = 3;
            this.usernameBox.UseSelectable = true;
            this.usernameBox.WaterMark = "Username";
            this.usernameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.usernameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pwBox
            // 
            // 
            // 
            // 
            this.pwBox.CustomButton.Image = null;
            this.pwBox.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.pwBox.CustomButton.Name = "";
            this.pwBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.pwBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.pwBox.CustomButton.TabIndex = 1;
            this.pwBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pwBox.CustomButton.UseSelectable = true;
            this.pwBox.CustomButton.Visible = false;
            this.pwBox.Lines = new string[0];
            this.pwBox.Location = new System.Drawing.Point(12, 91);
            this.pwBox.MaxLength = 32767;
            this.pwBox.Name = "pwBox";
            this.pwBox.PasswordChar = '●';
            this.pwBox.PromptText = "Password";
            this.pwBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pwBox.SelectedText = "";
            this.pwBox.SelectionLength = 0;
            this.pwBox.SelectionStart = 0;
            this.pwBox.ShortcutsEnabled = true;
            this.pwBox.Size = new System.Drawing.Size(138, 23);
            this.pwBox.TabIndex = 4;
            this.pwBox.UseSelectable = true;
            this.pwBox.UseSystemPasswordChar = true;
            this.pwBox.WaterMark = "Password";
            this.pwBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pwBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // confirmpwBox
            // 
            // 
            // 
            // 
            this.confirmpwBox.CustomButton.Image = null;
            this.confirmpwBox.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.confirmpwBox.CustomButton.Name = "";
            this.confirmpwBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.confirmpwBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.confirmpwBox.CustomButton.TabIndex = 1;
            this.confirmpwBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.confirmpwBox.CustomButton.UseSelectable = true;
            this.confirmpwBox.CustomButton.Visible = false;
            this.confirmpwBox.Lines = new string[0];
            this.confirmpwBox.Location = new System.Drawing.Point(12, 120);
            this.confirmpwBox.MaxLength = 32767;
            this.confirmpwBox.Name = "confirmpwBox";
            this.confirmpwBox.PasswordChar = '●';
            this.confirmpwBox.PromptText = "Confirm Password";
            this.confirmpwBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.confirmpwBox.SelectedText = "";
            this.confirmpwBox.SelectionLength = 0;
            this.confirmpwBox.SelectionStart = 0;
            this.confirmpwBox.ShortcutsEnabled = true;
            this.confirmpwBox.Size = new System.Drawing.Size(138, 23);
            this.confirmpwBox.TabIndex = 5;
            this.confirmpwBox.UseSelectable = true;
            this.confirmpwBox.UseSystemPasswordChar = true;
            this.confirmpwBox.WaterMark = "Confirm Password";
            this.confirmpwBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.confirmpwBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(12, 175);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(104, 33);
            this.addUserBtn.TabIndex = 12;
            this.addUserBtn.Text = "Add";
            this.addUserBtn.UseSelectable = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // accessPanel
            // 
            this.accessPanel.BackColor = System.Drawing.Color.White;
            this.accessPanel.Controls.Add(this.facultyRad);
            this.accessPanel.Controls.Add(this.studentRad);
            this.accessPanel.Location = new System.Drawing.Point(12, 149);
            this.accessPanel.Name = "accessPanel";
            this.accessPanel.Size = new System.Drawing.Size(172, 20);
            this.accessPanel.TabIndex = 111;
            // 
            // facultyRad
            // 
            this.facultyRad.AutoSize = true;
            this.facultyRad.Location = new System.Drawing.Point(71, 0);
            this.facultyRad.Name = "facultyRad";
            this.facultyRad.Size = new System.Drawing.Size(73, 17);
            this.facultyRad.TabIndex = 1;
            this.facultyRad.TabStop = true;
            this.facultyRad.Text = "Moderator";
            this.facultyRad.UseVisualStyleBackColor = true;
            // 
            // studentRad
            // 
            this.studentRad.AutoSize = true;
            this.studentRad.Location = new System.Drawing.Point(3, 0);
            this.studentRad.Name = "studentRad";
            this.studentRad.Size = new System.Drawing.Size(54, 17);
            this.studentRad.TabIndex = 0;
            this.studentRad.TabStop = true;
            this.studentRad.Text = "Admin";
            this.studentRad.UseVisualStyleBackColor = true;
            // 
            // AddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(204, 236);
            this.Controls.Add(this.accessPanel);
            this.Controls.Add(this.addUserBtn);
            this.Controls.Add(this.confirmpwBox);
            this.Controls.Add(this.pwBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.nameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(220, 275);
            this.MinimumSize = new System.Drawing.Size(220, 275);
            this.Name = "AddUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Users";
            this.accessPanel.ResumeLayout(false);
            this.accessPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox nameBox;
        private MetroFramework.Controls.MetroTextBox usernameBox;
        private MetroFramework.Controls.MetroTextBox pwBox;
        private MetroFramework.Controls.MetroTextBox confirmpwBox;
        private MetroFramework.Controls.MetroButton addUserBtn;
        private System.Windows.Forms.Panel accessPanel;
        private System.Windows.Forms.RadioButton facultyRad;
        private System.Windows.Forms.RadioButton studentRad;
    }
}