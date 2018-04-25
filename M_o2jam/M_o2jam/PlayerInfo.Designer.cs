namespace M_o2jam
{
    partial class PlayerInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNick = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblNickOrAccount = new System.Windows.Forms.Label();
            this.txtAorN = new System.Windows.Forms.TextBox();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dpDai = new DividerPanel.DividerPanel();
            this.dgAccountInfo = new System.Windows.Forms.DataGridView();
            this.dpText = new DividerPanel.DividerPanel();
            this.linkModi = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.dpEdit = new DividerPanel.DividerPanel();
            this.txtLose = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.btnModiCancel = new System.Windows.Forms.Button();
            this.btnModiOK = new System.Windows.Forms.Button();
            this.txtDraw = new System.Windows.Forms.TextBox();
            this.txtWin = new System.Windows.Forms.TextBox();
            this.txtBattle = new System.Windows.Forms.TextBox();
            this.txtExp = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorkerReadInfoFromDB = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerWriteInfoToDB = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dpDai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).BeginInit();
            this.dpText.SuspendLayout();
            this.dpEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器：";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(634, 82);
            this.dividerPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkNick);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.chkAccount);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblNickOrAccount);
            this.groupBox1.Controls.Add(this.txtAorN);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 82);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // chkNick
            // 
            this.chkNick.AutoSize = true;
            this.chkNick.Location = new System.Drawing.Point(86, 58);
            this.chkNick.Name = "chkNick";
            this.chkNick.Size = new System.Drawing.Size(72, 16);
            this.chkNick.TabIndex = 5;
            this.chkNick.Text = "昵称查询";
            this.chkNick.UseVisualStyleBackColor = true;
            this.chkNick.Click += new System.EventHandler(this.chkNick_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(462, 29);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Checked = true;
            this.chkAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccount.Location = new System.Drawing.Point(8, 58);
            this.chkAccount.Name = "chkAccount";
            this.chkAccount.Size = new System.Drawing.Size(72, 16);
            this.chkAccount.TabIndex = 4;
            this.chkAccount.Text = "帐号查询";
            this.chkAccount.UseVisualStyleBackColor = true;
            this.chkAccount.Click += new System.EventHandler(this.chkAccount_Click);
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(8, 32);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(180, 20);
            this.cbxServerIP.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(381, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查看";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblNickOrAccount
            // 
            this.lblNickOrAccount.AutoSize = true;
            this.lblNickOrAccount.Location = new System.Drawing.Point(206, 17);
            this.lblNickOrAccount.Name = "lblNickOrAccount";
            this.lblNickOrAccount.Size = new System.Drawing.Size(65, 12);
            this.lblNickOrAccount.TabIndex = 2;
            this.lblNickOrAccount.Text = "玩家帐号：";
            // 
            // txtAorN
            // 
            this.txtAorN.Location = new System.Drawing.Point(208, 31);
            this.txtAorN.Name = "txtAorN";
            this.txtAorN.Size = new System.Drawing.Size(167, 21);
            this.txtAorN.TabIndex = 3;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 92);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(634, 10);
            this.dividerPanel2.TabIndex = 2;
            // 
            // dpDai
            // 
            this.dpDai.AllowDrop = true;
            this.dpDai.Controls.Add(this.dgAccountInfo);
            this.dpDai.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpDai.Location = new System.Drawing.Point(10, 102);
            this.dpDai.Name = "dividerPanel3";
            this.dpDai.Size = new System.Drawing.Size(634, 202);
            this.dpDai.TabIndex = 3;
            // 
            // dgAccountInfo
            // 
            this.dgAccountInfo.AllowUserToAddRows = false;
            this.dgAccountInfo.AllowUserToDeleteRows = false;
            this.dgAccountInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAccountInfo.Location = new System.Drawing.Point(0, 0);
            this.dgAccountInfo.Name = "dgAccountInfo";
            this.dgAccountInfo.ReadOnly = true;
            this.dgAccountInfo.RowTemplate.Height = 23;
            this.dgAccountInfo.Size = new System.Drawing.Size(634, 202);
            this.dgAccountInfo.TabIndex = 0;
            this.dgAccountInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAccountInfo_CellClick);
            // 
            // dpText
            // 
            this.dpText.AllowDrop = true;
            this.dpText.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpText.Controls.Add(this.linkModi);
            this.dpText.Controls.Add(this.label10);
            this.dpText.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpText.Location = new System.Drawing.Point(10, 304);
            this.dpText.Name = "dividerPanel4";
            this.dpText.Size = new System.Drawing.Size(634, 33);
            this.dpText.TabIndex = 4;
            // 
            // linkModi
            // 
            this.linkModi.AutoSize = true;
            this.linkModi.Location = new System.Drawing.Point(355, 9);
            this.linkModi.Name = "linkModi";
            this.linkModi.Size = new System.Drawing.Size(77, 12);
            this.linkModi.TabIndex = 1;
            this.linkModi.TabStop = true;
            this.linkModi.Text = "修改角色信息";
            this.linkModi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkModi_LinkClicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(497, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "如要修改玩家相关资料信息，请先在上方选择角色信息，然后点击　　　　　　　进行修改。";
            // 
            // dpEdit
            // 
            this.dpEdit.AllowDrop = true;
            this.dpEdit.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dpEdit.Controls.Add(this.txtLose);
            this.dpEdit.Controls.Add(this.label2);
            this.dpEdit.Controls.Add(this.txtLevel);
            this.dpEdit.Controls.Add(this.btnModiCancel);
            this.dpEdit.Controls.Add(this.btnModiOK);
            this.dpEdit.Controls.Add(this.txtDraw);
            this.dpEdit.Controls.Add(this.txtWin);
            this.dpEdit.Controls.Add(this.txtBattle);
            this.dpEdit.Controls.Add(this.txtExp);
            this.dpEdit.Controls.Add(this.txtG);
            this.dpEdit.Controls.Add(this.txtNick);
            this.dpEdit.Controls.Add(this.label9);
            this.dpEdit.Controls.Add(this.label8);
            this.dpEdit.Controls.Add(this.label7);
            this.dpEdit.Controls.Add(this.label6);
            this.dpEdit.Controls.Add(this.label5);
            this.dpEdit.Controls.Add(this.label4);
            this.dpEdit.Controls.Add(this.label3);
            this.dpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpEdit.Location = new System.Drawing.Point(10, 337);
            this.dpEdit.Name = "dividerPanel5";
            this.dpEdit.Size = new System.Drawing.Size(634, 263);
            this.dpEdit.TabIndex = 5;
            // 
            // txtLose
            // 
            this.txtLose.Location = new System.Drawing.Point(76, 196);
            this.txtLose.Name = "txtLose";
            this.txtLose.Size = new System.Drawing.Size(176, 21);
            this.txtLose.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "失败次数：";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(76, 62);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(176, 21);
            this.txtLevel.TabIndex = 16;
            // 
            // btnModiCancel
            // 
            this.btnModiCancel.Location = new System.Drawing.Point(157, 225);
            this.btnModiCancel.Name = "btnModiCancel";
            this.btnModiCancel.Size = new System.Drawing.Size(75, 23);
            this.btnModiCancel.TabIndex = 15;
            this.btnModiCancel.Text = "取消";
            this.btnModiCancel.UseVisualStyleBackColor = true;
            this.btnModiCancel.Click += new System.EventHandler(this.btnModiCancel_Click);
            // 
            // btnModiOK
            // 
            this.btnModiOK.Location = new System.Drawing.Point(76, 225);
            this.btnModiOK.Name = "btnModiOK";
            this.btnModiOK.Size = new System.Drawing.Size(75, 23);
            this.btnModiOK.TabIndex = 14;
            this.btnModiOK.Text = "确认";
            this.btnModiOK.UseVisualStyleBackColor = true;
            this.btnModiOK.Click += new System.EventHandler(this.btnModiOK_Click);
            // 
            // txtDraw
            // 
            this.txtDraw.Location = new System.Drawing.Point(76, 169);
            this.txtDraw.Name = "txtDraw";
            this.txtDraw.Size = new System.Drawing.Size(176, 21);
            this.txtDraw.TabIndex = 13;
            // 
            // txtWin
            // 
            this.txtWin.Location = new System.Drawing.Point(76, 142);
            this.txtWin.Name = "txtWin";
            this.txtWin.Size = new System.Drawing.Size(176, 21);
            this.txtWin.TabIndex = 12;
            // 
            // txtBattle
            // 
            this.txtBattle.Location = new System.Drawing.Point(76, 115);
            this.txtBattle.Name = "txtBattle";
            this.txtBattle.Size = new System.Drawing.Size(176, 21);
            this.txtBattle.TabIndex = 11;
            // 
            // txtExp
            // 
            this.txtExp.Location = new System.Drawing.Point(76, 88);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(176, 21);
            this.txtExp.TabIndex = 9;
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(76, 35);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(176, 21);
            this.txtG.TabIndex = 8;
            // 
            // txtNick
            // 
            this.txtNick.Enabled = false;
            this.txtNick.Location = new System.Drawing.Point(76, 8);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(176, 21);
            this.txtNick.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "平局次数：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "胜利次数：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "比赛次数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "经　　验：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "等　　级：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "G　　 币：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "玩家昵称：";
            // 
            // backgroundWorkerReadInfoFromDB
            // 
            this.backgroundWorkerReadInfoFromDB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReadInfoFromDB_DoWork);
            this.backgroundWorkerReadInfoFromDB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReadInfoFromDB_RunWorkerCompleted);
            // 
            // backgroundWorkerWriteInfoToDB
            // 
            this.backgroundWorkerWriteInfoToDB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerWriteInfoToDB_DoWork);
            this.backgroundWorkerWriteInfoToDB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerWriteInfoToDB_RunWorkerCompleted);
            // 
            // PlayerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 610);
            this.Controls.Add(this.dpEdit);
            this.Controls.Add(this.dpText);
            this.Controls.Add(this.dpDai);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "PlayerInfo";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "玩家角色信息管理[劲乐团]";
            this.Load += new System.EventHandler(this.PlayerInfo_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dpDai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).EndInit();
            this.dpText.ResumeLayout(false);
            this.dpText.PerformLayout();
            this.dpEdit.ResumeLayout(false);
            this.dpEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.TextBox txtAorN;
        private System.Windows.Forms.Label lblNickOrAccount;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.CheckBox chkNick;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dpDai;
        private System.Windows.Forms.DataGridView dgAccountInfo;
        private DividerPanel.DividerPanel dpText;
        private DividerPanel.DividerPanel dpEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDraw;
        private System.Windows.Forms.TextBox txtWin;
        private System.Windows.Forms.TextBox txtBattle;
        private System.Windows.Forms.TextBox txtExp;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Button btnModiCancel;
        private System.Windows.Forms.Button btnModiOK;
        private System.Windows.Forms.LinkLabel linkModi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.TextBox txtLose;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReadInfoFromDB;
        private System.ComponentModel.BackgroundWorker backgroundWorkerWriteInfoToDB;
    }
}

