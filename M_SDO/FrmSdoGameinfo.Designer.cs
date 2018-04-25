namespace M_SDO
{
    partial class FrmSdoGameinfo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtCode = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorkAdd = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.DptGametime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDay = new System.Windows.Forms.ComboBox();
            this.DptEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DptStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGCash = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMCash = new System.Windows.Forms.TextBox();
            this.cbxScene = new System.Windows.Forms.ComboBox();
            this.cbxLevel5 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxLevel4 = new System.Windows.Forms.ComboBox();
            this.cbxLevel3 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxLevel2 = new System.Windows.Forms.ComboBox();
            this.cbxLevel1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxSong5 = new System.Windows.Forms.ComboBox();
            this.cbxSong4 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxSong3 = new System.Windows.Forms.ComboBox();
            this.cbxSong2 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbxSong1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtCode);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 500);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // TxtCode
            // 
            this.TxtCode.CheckOnClick = true;
            this.TxtCode.ColumnWidth = 150;
            this.TxtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCode.FormattingEnabled = true;
            this.TxtCode.HorizontalExtent = 10;
            this.TxtCode.Location = new System.Drawing.Point(3, 98);
            this.TxtCode.MultiColumn = true;
            this.TxtCode.Name = "TxtCode";
            this.TxtCode.Size = new System.Drawing.Size(150, 388);
            this.TxtCode.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 81);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(47, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "全选";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(44, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "大区列表";
            // 
            // backgroundWorkAdd
            // 
            this.backgroundWorkAdd.WorkerReportsProgress = true;
            this.backgroundWorkAdd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkAdd_DoWork);
            this.backgroundWorkAdd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkAdd_RunWorkerCompleted);
            this.backgroundWorkAdd.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkAdd_ProgressChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnConfirm);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.DptGametime);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbxDay);
            this.groupBox3.Controls.Add(this.DptEnd);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.DptStart);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtGCash);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtMCash);
            this.groupBox3.Controls.Add(this.cbxScene);
            this.groupBox3.Controls.Add(this.cbxLevel5);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cbxLevel4);
            this.groupBox3.Controls.Add(this.cbxLevel3);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cbxLevel2);
            this.groupBox3.Controls.Add(this.cbxLevel1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cbxSong5);
            this.groupBox3.Controls.Add(this.cbxSong4);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cbxSong3);
            this.groupBox3.Controls.Add(this.cbxSong2);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.cbxSong1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(156, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(593, 500);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(347, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(175, 431);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(85, 23);
            this.btnConfirm.TabIndex = 18;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(101, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 73;
            this.label9.Text = "比赛时间：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DptGametime
            // 
            this.DptGametime.CustomFormat = "HH:mm";
            this.DptGametime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptGametime.Location = new System.Drawing.Point(177, 65);
            this.DptGametime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DptGametime.Name = "DptGametime";
            this.DptGametime.ShowUpDown = true;
            this.DptGametime.Size = new System.Drawing.Size(257, 21);
            this.DptGametime.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 70;
            this.label3.Text = "频道开始时间：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 71;
            this.label4.Text = "频道关闭时间：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 68;
            this.label1.Text = "星期几：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxDay
            // 
            this.cbxDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDay.FormattingEnabled = true;
            this.cbxDay.Items.AddRange(new object[] {
            "星期日",
            "星期一",
            "星期二",
            "星期三",
            "星期四",
            "星期五",
            "星期六"});
            this.cbxDay.Location = new System.Drawing.Point(177, 36);
            this.cbxDay.Name = "cbxDay";
            this.cbxDay.Size = new System.Drawing.Size(257, 20);
            this.cbxDay.TabIndex = 1;
            // 
            // DptEnd
            // 
            this.DptEnd.CustomFormat = "HH:mm";
            this.DptEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptEnd.Location = new System.Drawing.Point(177, 120);
            this.DptEnd.Name = "DptEnd";
            this.DptEnd.ShowUpDown = true;
            this.DptEnd.Size = new System.Drawing.Size(257, 21);
            this.DptEnd.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 62;
            this.label5.Text = "需要收取的G币：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DptStart
            // 
            this.DptStart.CustomFormat = "HH:mm";
            this.DptStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptStart.Location = new System.Drawing.Point(177, 93);
            this.DptStart.Name = "DptStart";
            this.DptStart.ShowUpDown = true;
            this.DptStart.Size = new System.Drawing.Size(257, 21);
            this.DptStart.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 63;
            this.label6.Text = "需要收取的M币：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGCash
            // 
            this.txtGCash.Location = new System.Drawing.Point(177, 147);
            this.txtGCash.Name = "txtGCash";
            this.txtGCash.Size = new System.Drawing.Size(257, 21);
            this.txtGCash.TabIndex = 5;
            this.txtGCash.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 64;
            this.label7.Text = "所用场景：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMCash
            // 
            this.txtMCash.Location = new System.Drawing.Point(177, 175);
            this.txtMCash.Name = "txtMCash";
            this.txtMCash.Size = new System.Drawing.Size(257, 21);
            this.txtMCash.TabIndex = 6;
            this.txtMCash.Text = "0";
            // 
            // cbxScene
            // 
            this.cbxScene.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxScene.FormattingEnabled = true;
            this.cbxScene.Location = new System.Drawing.Point(177, 203);
            this.cbxScene.Name = "cbxScene";
            this.cbxScene.Size = new System.Drawing.Size(257, 20);
            this.cbxScene.TabIndex = 7;
            // 
            // cbxLevel5
            // 
            this.cbxLevel5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel5.FormattingEnabled = true;
            this.cbxLevel5.Items.AddRange(new object[] {
            "E",
            "N",
            "H"});
            this.cbxLevel5.Location = new System.Drawing.Point(347, 358);
            this.cbxLevel5.Name = "cbxLevel5";
            this.cbxLevel5.Size = new System.Drawing.Size(89, 20);
            this.cbxLevel5.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "第一场：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxLevel4
            // 
            this.cbxLevel4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel4.FormattingEnabled = true;
            this.cbxLevel4.Items.AddRange(new object[] {
            "E",
            "N",
            "H"});
            this.cbxLevel4.Location = new System.Drawing.Point(347, 326);
            this.cbxLevel4.Name = "cbxLevel4";
            this.cbxLevel4.Size = new System.Drawing.Size(89, 20);
            this.cbxLevel4.TabIndex = 15;
            // 
            // cbxLevel3
            // 
            this.cbxLevel3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel3.FormattingEnabled = true;
            this.cbxLevel3.Items.AddRange(new object[] {
            "E",
            "N",
            "H"});
            this.cbxLevel3.Location = new System.Drawing.Point(347, 296);
            this.cbxLevel3.Name = "cbxLevel3";
            this.cbxLevel3.Size = new System.Drawing.Size(89, 20);
            this.cbxLevel3.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(113, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 39;
            this.label11.Text = "第二场：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxLevel2
            // 
            this.cbxLevel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel2.FormattingEnabled = true;
            this.cbxLevel2.Items.AddRange(new object[] {
            "E",
            "N",
            "H"});
            this.cbxLevel2.Location = new System.Drawing.Point(347, 264);
            this.cbxLevel2.Name = "cbxLevel2";
            this.cbxLevel2.Size = new System.Drawing.Size(89, 20);
            this.cbxLevel2.TabIndex = 11;
            // 
            // cbxLevel1
            // 
            this.cbxLevel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLevel1.FormattingEnabled = true;
            this.cbxLevel1.Items.AddRange(new object[] {
            "E",
            "N",
            "H"});
            this.cbxLevel1.Location = new System.Drawing.Point(347, 234);
            this.cbxLevel1.Name = "cbxLevel1";
            this.cbxLevel1.Size = new System.Drawing.Size(89, 20);
            this.cbxLevel1.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(113, 299);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 41;
            this.label13.Text = "第三场：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxSong5
            // 
            this.cbxSong5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSong5.FormattingEnabled = true;
            this.cbxSong5.Location = new System.Drawing.Point(177, 358);
            this.cbxSong5.Name = "cbxSong5";
            this.cbxSong5.Size = new System.Drawing.Size(161, 20);
            this.cbxSong5.TabIndex = 16;
            // 
            // cbxSong4
            // 
            this.cbxSong4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSong4.FormattingEnabled = true;
            this.cbxSong4.Location = new System.Drawing.Point(177, 328);
            this.cbxSong4.Name = "cbxSong4";
            this.cbxSong4.Size = new System.Drawing.Size(161, 20);
            this.cbxSong4.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(113, 329);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 43;
            this.label15.Text = "第四场：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxSong3
            // 
            this.cbxSong3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSong3.FormattingEnabled = true;
            this.cbxSong3.Location = new System.Drawing.Point(177, 298);
            this.cbxSong3.Name = "cbxSong3";
            this.cbxSong3.Size = new System.Drawing.Size(161, 20);
            this.cbxSong3.TabIndex = 12;
            // 
            // cbxSong2
            // 
            this.cbxSong2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSong2.FormattingEnabled = true;
            this.cbxSong2.Location = new System.Drawing.Point(177, 264);
            this.cbxSong2.Name = "cbxSong2";
            this.cbxSong2.Size = new System.Drawing.Size(161, 20);
            this.cbxSong2.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(113, 359);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 45;
            this.label17.Text = "第五场：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxSong1
            // 
            this.cbxSong1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSong1.FormattingEnabled = true;
            this.cbxSong1.Location = new System.Drawing.Point(177, 234);
            this.cbxSong1.Name = "cbxSong1";
            this.cbxSong1.Size = new System.Drawing.Size(161, 20);
            this.cbxSong1.TabIndex = 8;
            // 
            // FrmSdoGameinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 500);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSdoGameinfo";
            this.Text = "大赛信息编辑[超级舞者]";
            this.Load += new System.EventHandler(this.FrmSdoGameinfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox TxtCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorkAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker DptGametime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDay;
        private System.Windows.Forms.DateTimePicker DptEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DptStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGCash;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMCash;
        private System.Windows.Forms.ComboBox cbxScene;
        private System.Windows.Forms.ComboBox cbxLevel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxLevel4;
        private System.Windows.Forms.ComboBox cbxLevel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxLevel2;
        private System.Windows.Forms.ComboBox cbxLevel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxSong5;
        private System.Windows.Forms.ComboBox cbxSong4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxSong3;
        private System.Windows.Forms.ComboBox cbxSong2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbxSong1;
    }
}