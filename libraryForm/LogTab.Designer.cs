namespace libraryForm
{
    partial class LogTab
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
            this.midTopPanel = new System.Windows.Forms.Panel();
            this.loginLbl = new System.Windows.Forms.Label();
            this.noidCB = new System.Windows.Forms.CheckBox();
            this.studNo1 = new System.Windows.Forms.TextBox();
            this.logButton = new MetroFramework.Controls.MetroButton();
            this.othersButton = new MetroFramework.Controls.MetroButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.logsRecord = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfVisits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.weeklyComTip = new System.Windows.Forms.ToolTip(this.components);
            this.monthlyComTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lastLog = new System.Windows.Forms.Label();
            this.logLastVisit = new System.Windows.Forms.Label();
            this.logVisits = new System.Windows.Forms.Label();
            this.logGender = new System.Windows.Forms.Label();
            this.logCourse = new System.Windows.Forms.Label();
            this.logName = new System.Windows.Forms.Label();
            this.logNum = new System.Windows.Forms.Label();
            this.lastLogLastVisit = new System.Windows.Forms.TextBox();
            this.lastLogVisits = new System.Windows.Forms.TextBox();
            this.lastLogGender = new System.Windows.Forms.TextBox();
            this.lastLogCourse = new System.Windows.Forms.TextBox();
            this.lastLogName = new System.Windows.Forms.TextBox();
            this.lastLogNum = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.midTopPanel.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logsRecord)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // midTopPanel
            // 
            this.midTopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(149)))), ((int)(((byte)(218)))));
            this.midTopPanel.Controls.Add(this.loginLbl);
            this.midTopPanel.Controls.Add(this.noidCB);
            this.midTopPanel.Controls.Add(this.studNo1);
            this.midTopPanel.Controls.Add(this.logButton);
            this.midTopPanel.Controls.Add(this.othersButton);
            this.midTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.midTopPanel.Location = new System.Drawing.Point(0, 0);
            this.midTopPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.midTopPanel.Name = "midTopPanel";
            this.midTopPanel.Size = new System.Drawing.Size(658, 295);
            this.midTopPanel.TabIndex = 127;
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.BackColor = System.Drawing.Color.Transparent;
            this.loginLbl.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLbl.ForeColor = System.Drawing.Color.White;
            this.loginLbl.Location = new System.Drawing.Point(164, 22);
            this.loginLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(328, 65);
            this.loginLbl.TabIndex = 123;
            this.loginLbl.Text = "Student Log-In";
            // 
            // noidCB
            // 
            this.noidCB.AutoSize = true;
            this.noidCB.BackColor = System.Drawing.Color.Transparent;
            this.noidCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noidCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(18)))));
            this.noidCB.Location = new System.Drawing.Point(476, 117);
            this.noidCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.noidCB.Name = "noidCB";
            this.noidCB.Size = new System.Drawing.Size(71, 24);
            this.noidCB.TabIndex = 121;
            this.noidCB.Text = "No ID";
            this.noidCB.UseVisualStyleBackColor = false;
            this.noidCB.CheckedChanged += new System.EventHandler(this.noidCB_CheckedChanged);
            // 
            // studNo1
            // 
            this.studNo1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.studNo1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.studNo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studNo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.studNo1.Location = new System.Drawing.Point(192, 115);
            this.studNo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.studNo1.Name = "studNo1";
            this.studNo1.Size = new System.Drawing.Size(268, 28);
            this.studNo1.TabIndex = 122;
            this.studNo1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.studNo1_KeyDown);
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(192, 171);
            this.logButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logButton.MaximumSize = new System.Drawing.Size(132, 45);
            this.logButton.MinimumSize = new System.Drawing.Size(132, 45);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(132, 45);
            this.logButton.TabIndex = 12;
            this.logButton.Text = "Log Entry";
            this.logButton.UseSelectable = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // othersButton
            // 
            this.othersButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.othersButton.Location = new System.Drawing.Point(333, 171);
            this.othersButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.othersButton.MaximumSize = new System.Drawing.Size(128, 45);
            this.othersButton.MinimumSize = new System.Drawing.Size(128, 45);
            this.othersButton.Name = "othersButton";
            this.othersButton.Size = new System.Drawing.Size(128, 45);
            this.othersButton.TabIndex = 83;
            this.othersButton.Text = "Others";
            this.othersButton.UseSelectable = true;
            this.othersButton.Click += new System.EventHandler(this.othersButton_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.panel3);
            this.panel9.Controls.Add(this.panel2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(658, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(866, 1048);
            this.panel9.TabIndex = 134;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.logsRecord);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(866, 884);
            this.panel3.TabIndex = 1;
            // 
            // logsRecord
            // 
            this.logsRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logsRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.label,
            this.numberOfVisits});
            this.logsRecord.Location = new System.Drawing.Point(32, 33);
            this.logsRecord.Name = "logsRecord";
            this.logsRecord.RowTemplate.Height = 28;
            this.logsRecord.Size = new System.Drawing.Size(793, 758);
            this.logsRecord.TabIndex = 0;
            // 
            // label
            // 
            this.label.HeaderText = "Label";
            this.label.Name = "label";
            // 
            // numberOfVisits
            // 
            this.numberOfVisits.HeaderText = "Number of Visit";
            this.numberOfVisits.Name = "numberOfVisits";
            this.numberOfVisits.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.datePicker);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(866, 164);
            this.panel2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(710, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "This Month";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(533, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "TODAY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.lastLog);
            this.panel1.Controls.Add(this.logLastVisit);
            this.panel1.Controls.Add(this.logVisits);
            this.panel1.Controls.Add(this.logGender);
            this.panel1.Controls.Add(this.logCourse);
            this.panel1.Controls.Add(this.logName);
            this.panel1.Controls.Add(this.logNum);
            this.panel1.Controls.Add(this.lastLogLastVisit);
            this.panel1.Controls.Add(this.lastLogVisits);
            this.panel1.Controls.Add(this.lastLogGender);
            this.panel1.Controls.Add(this.lastLogCourse);
            this.panel1.Controls.Add(this.lastLogName);
            this.panel1.Controls.Add(this.lastLogNum);
            this.panel1.Location = new System.Drawing.Point(85, 315);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 640);
            this.panel1.TabIndex = 135;
            // 
            // lastLog
            // 
            this.lastLog.AutoSize = true;
            this.lastLog.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLog.ForeColor = System.Drawing.Color.White;
            this.lastLog.Location = new System.Drawing.Point(124, 17);
            this.lastLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastLog.Name = "lastLog";
            this.lastLog.Size = new System.Drawing.Size(256, 45);
            this.lastLog.TabIndex = 100;
            this.lastLog.Text = "Last Logged User";
            // 
            // logLastVisit
            // 
            this.logLastVisit.AutoSize = true;
            this.logLastVisit.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logLastVisit.ForeColor = System.Drawing.Color.White;
            this.logLastVisit.Location = new System.Drawing.Point(76, 511);
            this.logLastVisit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logLastVisit.Name = "logLastVisit";
            this.logLastVisit.Size = new System.Drawing.Size(74, 19);
            this.logLastVisit.TabIndex = 99;
            this.logLastVisit.Text = "LAST VISIT";
            // 
            // logVisits
            // 
            this.logVisits.AutoSize = true;
            this.logVisits.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logVisits.ForeColor = System.Drawing.Color.White;
            this.logVisits.Location = new System.Drawing.Point(76, 431);
            this.logVisits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logVisits.Name = "logVisits";
            this.logVisits.Size = new System.Drawing.Size(103, 19);
            this.logVisits.TabIndex = 98;
            this.logVisits.Text = "LIBRARY VISITS";
            // 
            // logGender
            // 
            this.logGender.AutoSize = true;
            this.logGender.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logGender.ForeColor = System.Drawing.Color.White;
            this.logGender.Location = new System.Drawing.Point(76, 354);
            this.logGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logGender.Name = "logGender";
            this.logGender.Size = new System.Drawing.Size(61, 19);
            this.logGender.TabIndex = 97;
            this.logGender.Text = "GENDER";
            // 
            // logCourse
            // 
            this.logCourse.AutoSize = true;
            this.logCourse.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logCourse.ForeColor = System.Drawing.Color.White;
            this.logCourse.Location = new System.Drawing.Point(76, 271);
            this.logCourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logCourse.Name = "logCourse";
            this.logCourse.Size = new System.Drawing.Size(61, 19);
            this.logCourse.TabIndex = 96;
            this.logCourse.Text = "COURSE";
            // 
            // logName
            // 
            this.logName.AutoSize = true;
            this.logName.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logName.ForeColor = System.Drawing.Color.White;
            this.logName.Location = new System.Drawing.Point(76, 186);
            this.logName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logName.Name = "logName";
            this.logName.Size = new System.Drawing.Size(48, 19);
            this.logName.TabIndex = 95;
            this.logName.Text = "NAME";
            // 
            // logNum
            // 
            this.logNum.AutoSize = true;
            this.logNum.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logNum.ForeColor = System.Drawing.Color.White;
            this.logNum.Location = new System.Drawing.Point(76, 103);
            this.logNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logNum.Name = "logNum";
            this.logNum.Size = new System.Drawing.Size(95, 19);
            this.logNum.TabIndex = 94;
            this.logNum.Text = "STUDENT NO.";
            // 
            // lastLogLastVisit
            // 
            this.lastLogLastVisit.Enabled = false;
            this.lastLogLastVisit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLogLastVisit.Location = new System.Drawing.Point(81, 535);
            this.lastLogLastVisit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastLogLastVisit.Name = "lastLogLastVisit";
            this.lastLogLastVisit.Size = new System.Drawing.Size(336, 29);
            this.lastLogLastVisit.TabIndex = 93;
            // 
            // lastLogVisits
            // 
            this.lastLogVisits.Enabled = false;
            this.lastLogVisits.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLogVisits.Location = new System.Drawing.Point(81, 455);
            this.lastLogVisits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastLogVisits.Name = "lastLogVisits";
            this.lastLogVisits.Size = new System.Drawing.Size(336, 29);
            this.lastLogVisits.TabIndex = 91;
            // 
            // lastLogGender
            // 
            this.lastLogGender.Enabled = false;
            this.lastLogGender.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLogGender.Location = new System.Drawing.Point(81, 377);
            this.lastLogGender.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastLogGender.Name = "lastLogGender";
            this.lastLogGender.Size = new System.Drawing.Size(336, 29);
            this.lastLogGender.TabIndex = 89;
            // 
            // lastLogCourse
            // 
            this.lastLogCourse.Enabled = false;
            this.lastLogCourse.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLogCourse.Location = new System.Drawing.Point(81, 294);
            this.lastLogCourse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastLogCourse.Name = "lastLogCourse";
            this.lastLogCourse.Size = new System.Drawing.Size(336, 29);
            this.lastLogCourse.TabIndex = 86;
            // 
            // lastLogName
            // 
            this.lastLogName.Enabled = false;
            this.lastLogName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLogName.Location = new System.Drawing.Point(81, 209);
            this.lastLogName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastLogName.Name = "lastLogName";
            this.lastLogName.Size = new System.Drawing.Size(336, 29);
            this.lastLogName.TabIndex = 85;
            // 
            // lastLogNum
            // 
            this.lastLogNum.Enabled = false;
            this.lastLogNum.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLogNum.ForeColor = System.Drawing.Color.Black;
            this.lastLogNum.HideSelection = false;
            this.lastLogNum.Location = new System.Drawing.Point(81, 128);
            this.lastLogNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lastLogNum.Name = "lastLogNum";
            this.lastLogNum.Size = new System.Drawing.Size(336, 29);
            this.lastLogNum.TabIndex = 84;
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "";
            this.datePicker.Location = new System.Drawing.Point(7, 77);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(296, 26);
            this.datePicker.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 118);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 31);
            this.button3.TabIndex = 3;
            this.button3.Text = "Custom Day";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(159, 117);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 31);
            this.button4.TabIndex = 4;
            this.button4.Text = "Custom Month";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // LogTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.midTopPanel);
            this.Controls.Add(this.panel9);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LogTab";
            this.Size = new System.Drawing.Size(1524, 1048);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LogTab_Paint);
            this.midTopPanel.ResumeLayout(false);
            this.midTopPanel.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logsRecord)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel midTopPanel;
        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.CheckBox noidCB;
        private System.Windows.Forms.TextBox studNo1;
        private MetroFramework.Controls.MetroButton logButton;
        private MetroFramework.Controls.MetroButton othersButton;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ToolTip weeklyComTip;
        private System.Windows.Forms.ToolTip monthlyComTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lastLog;
        private System.Windows.Forms.Label logLastVisit;
        private System.Windows.Forms.Label logVisits;
        private System.Windows.Forms.Label logGender;
        private System.Windows.Forms.Label logCourse;
        private System.Windows.Forms.Label logName;
        private System.Windows.Forms.Label logNum;
        private System.Windows.Forms.TextBox lastLogLastVisit;
        private System.Windows.Forms.TextBox lastLogVisits;
        private System.Windows.Forms.TextBox lastLogGender;
        private System.Windows.Forms.TextBox lastLogCourse;
        private System.Windows.Forms.TextBox lastLogName;
        private System.Windows.Forms.TextBox lastLogNum;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView logsRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn label;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfVisits;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}
