namespace libraryForm
{
    partial class EditUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditUsers));
            this.updateUserBtn = new MetroFramework.Controls.MetroButton();
            this.confirmpwBox = new MetroFramework.Controls.MetroTextBox();
            this.newpwBox = new MetroFramework.Controls.MetroTextBox();
            this.nameBox = new MetroFramework.Controls.MetroTextBox();
            this.cancelLbl = new System.Windows.Forms.Label();
            this.oldpwBox = new MetroFramework.Controls.MetroTextBox();
            this.searchbox = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // updateUserBtn
            // 
            this.updateUserBtn.Location = new System.Drawing.Point(27, 202);
            this.updateUserBtn.Name = "updateUserBtn";
            this.updateUserBtn.Size = new System.Drawing.Size(104, 33);
            this.updateUserBtn.TabIndex = 6;
            this.updateUserBtn.Text = "Update";
            this.updateUserBtn.UseSelectable = true;
            this.updateUserBtn.Click += new System.EventHandler(this.updateUserBtn_Click);
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
            this.confirmpwBox.Enabled = false;
            this.confirmpwBox.Lines = new string[0];
            this.confirmpwBox.Location = new System.Drawing.Point(27, 149);
            this.confirmpwBox.MaxLength = 32767;
            this.confirmpwBox.Name = "confirmpwBox";
            this.confirmpwBox.PasswordChar = '●';
            this.confirmpwBox.PromptText = "Confirm New Password";
            this.confirmpwBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.confirmpwBox.SelectedText = "";
            this.confirmpwBox.SelectionLength = 0;
            this.confirmpwBox.SelectionStart = 0;
            this.confirmpwBox.ShortcutsEnabled = true;
            this.confirmpwBox.Size = new System.Drawing.Size(138, 23);
            this.confirmpwBox.TabIndex = 5;
            this.confirmpwBox.UseSelectable = true;
            this.confirmpwBox.UseSystemPasswordChar = true;
            this.confirmpwBox.WaterMark = "Confirm New Password";
            this.confirmpwBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.confirmpwBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.confirmpwBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.confirmpwBox_KeyDown);
            // 
            // newpwBox
            // 
            // 
            // 
            // 
            this.newpwBox.CustomButton.Image = null;
            this.newpwBox.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.newpwBox.CustomButton.Name = "";
            this.newpwBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.newpwBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.newpwBox.CustomButton.TabIndex = 1;
            this.newpwBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.newpwBox.CustomButton.UseSelectable = true;
            this.newpwBox.CustomButton.Visible = false;
            this.newpwBox.Enabled = false;
            this.newpwBox.Lines = new string[0];
            this.newpwBox.Location = new System.Drawing.Point(27, 120);
            this.newpwBox.MaxLength = 32767;
            this.newpwBox.Name = "newpwBox";
            this.newpwBox.PasswordChar = '●';
            this.newpwBox.PromptText = "New Password";
            this.newpwBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.newpwBox.SelectedText = "";
            this.newpwBox.SelectionLength = 0;
            this.newpwBox.SelectionStart = 0;
            this.newpwBox.ShortcutsEnabled = true;
            this.newpwBox.Size = new System.Drawing.Size(138, 23);
            this.newpwBox.TabIndex = 4;
            this.newpwBox.UseSelectable = true;
            this.newpwBox.UseSystemPasswordChar = true;
            this.newpwBox.WaterMark = "New Password";
            this.newpwBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.newpwBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.nameBox.Enabled = false;
            this.nameBox.Lines = new string[0];
            this.nameBox.Location = new System.Drawing.Point(27, 62);
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
            // cancelLbl
            // 
            this.cancelLbl.AutoSize = true;
            this.cancelLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelLbl.ForeColor = System.Drawing.Color.Red;
            this.cancelLbl.Location = new System.Drawing.Point(6, 36);
            this.cancelLbl.Name = "cancelLbl";
            this.cancelLbl.Size = new System.Drawing.Size(17, 16);
            this.cancelLbl.TabIndex = 18;
            this.cancelLbl.Text = "X";
            this.cancelLbl.Visible = false;
            this.cancelLbl.Click += new System.EventHandler(this.cancelLbl_Click);
            // 
            // oldpwBox
            // 
            // 
            // 
            // 
            this.oldpwBox.CustomButton.Image = null;
            this.oldpwBox.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.oldpwBox.CustomButton.Name = "";
            this.oldpwBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.oldpwBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.oldpwBox.CustomButton.TabIndex = 1;
            this.oldpwBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.oldpwBox.CustomButton.UseSelectable = true;
            this.oldpwBox.CustomButton.Visible = false;
            this.oldpwBox.Enabled = false;
            this.oldpwBox.Lines = new string[0];
            this.oldpwBox.Location = new System.Drawing.Point(27, 91);
            this.oldpwBox.MaxLength = 32767;
            this.oldpwBox.Name = "oldpwBox";
            this.oldpwBox.PasswordChar = '●';
            this.oldpwBox.PromptText = "Old Password";
            this.oldpwBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.oldpwBox.SelectedText = "";
            this.oldpwBox.SelectionLength = 0;
            this.oldpwBox.SelectionStart = 0;
            this.oldpwBox.ShortcutsEnabled = true;
            this.oldpwBox.Size = new System.Drawing.Size(138, 23);
            this.oldpwBox.TabIndex = 3;
            this.oldpwBox.UseSelectable = true;
            this.oldpwBox.UseSystemPasswordChar = true;
            this.oldpwBox.WaterMark = "Old Password";
            this.oldpwBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.oldpwBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // searchbox
            // 
            // 
            // 
            // 
            this.searchbox.CustomButton.BackColor = System.Drawing.Color.Transparent;
            this.searchbox.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.searchbox.CustomButton.Location = new System.Drawing.Point(114, 2);
            this.searchbox.CustomButton.Name = "";
            this.searchbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.searchbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.searchbox.CustomButton.TabIndex = 1;
            this.searchbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.searchbox.CustomButton.UseSelectable = true;
            this.searchbox.CustomButton.UseVisualStyleBackColor = false;
            this.searchbox.DisplayIcon = true;
            this.searchbox.Lines = new string[0];
            this.searchbox.Location = new System.Drawing.Point(27, 30);
            this.searchbox.MaxLength = 32767;
            this.searchbox.Name = "searchbox";
            this.searchbox.PasswordChar = '\0';
            this.searchbox.PromptText = "Username";
            this.searchbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchbox.SelectedText = "";
            this.searchbox.SelectionLength = 0;
            this.searchbox.SelectionStart = 0;
            this.searchbox.ShortcutsEnabled = true;
            this.searchbox.ShowButton = true;
            this.searchbox.ShowClearButton = true;
            this.searchbox.Size = new System.Drawing.Size(138, 26);
            this.searchbox.TabIndex = 1;
            this.searchbox.UseSelectable = true;
            this.searchbox.WaterMark = "Username";
            this.searchbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.searchbox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.searchbox_ButtonClick);
            this.searchbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchbox_KeyDown);
            // 
            // EditUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(204, 258);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.oldpwBox);
            this.Controls.Add(this.cancelLbl);
            this.Controls.Add(this.updateUserBtn);
            this.Controls.Add(this.confirmpwBox);
            this.Controls.Add(this.newpwBox);
            this.Controls.Add(this.nameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(220, 297);
            this.MinimumSize = new System.Drawing.Size(220, 297);
            this.Name = "EditUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Users";
            this.Load += new System.EventHandler(this.EditUsers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton updateUserBtn;
        private MetroFramework.Controls.MetroTextBox confirmpwBox;
        private MetroFramework.Controls.MetroTextBox newpwBox;
        private MetroFramework.Controls.MetroTextBox nameBox;
        private System.Windows.Forms.Label cancelLbl;
        private MetroFramework.Controls.MetroTextBox oldpwBox;
        private MetroFramework.Controls.MetroTextBox searchbox;
    }
}