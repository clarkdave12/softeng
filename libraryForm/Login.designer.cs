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
            this.userBox = new MetroFramework.Controls.MetroTextBox();
            this.passBox = new MetroFramework.Controls.MetroTextBox();
            this.loginbtn = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.forgotpasslab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userBox
            // 
            // 
            // 
            // 
            this.userBox.CustomButton.Image = null;
            this.userBox.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.userBox.CustomButton.Name = "";
            this.userBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.userBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.userBox.CustomButton.TabIndex = 1;
            this.userBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.userBox.CustomButton.UseSelectable = true;
            this.userBox.CustomButton.Visible = false;
            this.userBox.Lines = new string[0];
            this.userBox.Location = new System.Drawing.Point(99, 175);
            this.userBox.MaxLength = 32767;
            this.userBox.Name = "userBox";
            this.userBox.PasswordChar = '\0';
            this.userBox.PromptText = "Enter Username";
            this.userBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.userBox.SelectedText = "";
            this.userBox.SelectionLength = 0;
            this.userBox.SelectionStart = 0;
            this.userBox.ShortcutsEnabled = true;
            this.userBox.Size = new System.Drawing.Size(130, 25);
            this.userBox.TabIndex = 0;
            this.userBox.UseSelectable = true;
            this.userBox.WaterMark = "Enter Username";
            this.userBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.userBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.userBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.metroTextBox1_KeyDown);
            // 
            // passBox
            // 
            // 
            // 
            // 
            this.passBox.CustomButton.Image = null;
            this.passBox.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.passBox.CustomButton.Name = "";
            this.passBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.passBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passBox.CustomButton.TabIndex = 1;
            this.passBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passBox.CustomButton.UseSelectable = true;
            this.passBox.CustomButton.Visible = false;
            this.passBox.Lines = new string[0];
            this.passBox.Location = new System.Drawing.Point(99, 206);
            this.passBox.MaxLength = 32767;
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '●';
            this.passBox.PromptText = "Enter Password";
            this.passBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passBox.SelectedText = "";
            this.passBox.SelectionLength = 0;
            this.passBox.SelectionStart = 0;
            this.passBox.ShortcutsEnabled = true;
            this.passBox.Size = new System.Drawing.Size(130, 25);
            this.passBox.TabIndex = 1;
            this.passBox.UseSelectable = true;
            this.passBox.UseSystemPasswordChar = true;
            this.passBox.WaterMark = "Enter Password";
            this.passBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.passBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.metroTextBox2_KeyDown);
            // 
            // loginbtn
            // 
            this.loginbtn.Location = new System.Drawing.Point(99, 256);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(130, 26);
            this.loginbtn.TabIndex = 2;
            this.loginbtn.Text = "Login";
            this.loginbtn.UseSelectable = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(255)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(342, 143);
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
            this.forgotpasslab.Location = new System.Drawing.Point(122, 236);
            this.forgotpasslab.Name = "forgotpasslab";
            this.forgotpasslab.Size = new System.Drawing.Size(81, 12);
            this.forgotpasslab.TabIndex = 4;
            this.forgotpasslab.Text = "Forgot Password?";
            this.forgotpasslab.Visible = false;
            this.forgotpasslab.Click += new System.EventHandler(this.forgotpasslab_Click);
            this.forgotpasslab.MouseEnter += new System.EventHandler(this.forgotpasslab_MouseEnter);
            this.forgotpasslab.MouseLeave += new System.EventHandler(this.forgotpasslab_MouseLeave);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(324, 346);
            this.Controls.Add(this.forgotpasslab);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.userBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(340, 385);
            this.MinimumSize = new System.Drawing.Size(340, 385);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox userBox;
        private MetroFramework.Controls.MetroTextBox passBox;
        private MetroFramework.Controls.MetroButton loginbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label forgotpasslab;
    }
}