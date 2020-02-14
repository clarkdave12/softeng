namespace libraryForm
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.UserName = new MetroFramework.Controls.MetroTextBox();
            this.Password = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.forgotpasslab = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserName
            // 
            // 
            // 
            // 
            this.UserName.CustomButton.Image = null;
            this.UserName.CustomButton.Location = new System.Drawing.Point(159, 2);
            this.UserName.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserName.CustomButton.Name = "";
            this.UserName.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.UserName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UserName.CustomButton.TabIndex = 1;
            this.UserName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UserName.CustomButton.UseSelectable = true;
            this.UserName.CustomButton.Visible = false;
            this.UserName.Lines = new string[0];
            this.UserName.Location = new System.Drawing.Point(148, 269);
            this.UserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserName.MaxLength = 32767;
            this.UserName.Name = "UserName";
            this.UserName.PasswordChar = '\0';
            this.UserName.PromptText = "Enter Username";
            this.UserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UserName.SelectedText = "";
            this.UserName.SelectionLength = 0;
            this.UserName.SelectionStart = 0;
            this.UserName.ShortcutsEnabled = true;
            this.UserName.Size = new System.Drawing.Size(195, 38);
            this.UserName.TabIndex = 0;
            this.UserName.UseSelectable = true;
            this.UserName.WaterMark = "Enter Username";
            this.UserName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UserName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.metroTextBox1_KeyDown);
            // 
            // Password
            // 
            // 
            // 
            // 
            this.Password.CustomButton.Image = null;
            this.Password.CustomButton.Location = new System.Drawing.Point(159, 2);
            this.Password.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Password.CustomButton.Name = "";
            this.Password.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.Password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Password.CustomButton.TabIndex = 1;
            this.Password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Password.CustomButton.UseSelectable = true;
            this.Password.CustomButton.Visible = false;
            this.Password.Lines = new string[0];
            this.Password.Location = new System.Drawing.Point(148, 317);
            this.Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Password.MaxLength = 32767;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '●';
            this.Password.PromptText = "Enter Password";
            this.Password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Password.SelectedText = "";
            this.Password.SelectionLength = 0;
            this.Password.SelectionStart = 0;
            this.Password.ShortcutsEnabled = true;
            this.Password.Size = new System.Drawing.Size(195, 38);
            this.Password.TabIndex = 1;
            this.Password.UseSelectable = true;
            this.Password.UseSystemPasswordChar = true;
            this.Password.WaterMark = "Enter Password";
            this.Password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-14, -3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(513, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // forgotpasslab
            // 
            this.forgotpasslab.AutoSize = true;
            this.forgotpasslab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgotpasslab.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotpasslab.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.forgotpasslab.Location = new System.Drawing.Point(183, 363);
            this.forgotpasslab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.forgotpasslab.Name = "forgotpasslab";
            this.forgotpasslab.Size = new System.Drawing.Size(122, 17);
            this.forgotpasslab.TabIndex = 4;
            this.forgotpasslab.Text = "Forgot Password?";
            this.forgotpasslab.Visible = false;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(148, 410);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(195, 41);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(477, 506);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.forgotpasslab);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(499, 562);
            this.MinimumSize = new System.Drawing.Size(499, 562);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library";
            this.Shown += new System.EventHandler(this.Login_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox UserName;
        private MetroFramework.Controls.MetroTextBox Password;
        private MetroFramework.Controls.MetroButton loginbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label forgotpasslab;
        private System.Windows.Forms.Button LoginButton;
    }
}