namespace M_o2jam
{
    partial class toyModi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(toyModi));
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkNick = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblAorN = new System.Windows.Forms.Label();
            this.txtAorN = new System.Windows.Forms.TextBox();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dividerPanel5 = new DividerPanel.DividerPanel();
            this.lblEquipName = new System.Windows.Forms.Label();
            this.lblPos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkView = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dividerPanel6 = new DividerPanel.DividerPanel();
            this.dgInfos = new System.Windows.Forms.DataGridView();
            this.lnkDel = new System.Windows.Forms.LinkLabel();
            this.dividerPanel4 = new DividerPanel.DividerPanel();
            this.itcBody = new ImageTextControl.IMGTXTCTRL();
            this.itcBox = new ImageTextControl.IMGTXTCTRL();
            this.backgroundWorkerReadInfoFromDB = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDelEquipInPos = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.dividerPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInfos)).BeginInit();
            this.dividerPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 92);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(723, 10);
            this.dividerPanel2.TabIndex = 4;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(723, 82);
            this.dividerPanel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkNick);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.chkAccount);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblAorN);
            this.groupBox1.Controls.Add(this.txtAorN);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(723, 82);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
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
            // chkNick
            // 
            this.chkNick.AutoSize = true;
            this.chkNick.Enabled = false;
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
            this.chkAccount.Enabled = false;
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
            // lblAorN
            // 
            this.lblAorN.AutoSize = true;
            this.lblAorN.Location = new System.Drawing.Point(206, 17);
            this.lblAorN.Name = "lblAorN";
            this.lblAorN.Size = new System.Drawing.Size(65, 12);
            this.lblAorN.TabIndex = 2;
            this.lblAorN.Text = "玩家帐号：";
            // 
            // txtAorN
            // 
            this.txtAorN.Location = new System.Drawing.Point(208, 31);
            this.txtAorN.Name = "txtAorN";
            this.txtAorN.Size = new System.Drawing.Size(167, 21);
            this.txtAorN.TabIndex = 3;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel3.Controls.Add(this.tabControl1);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 102);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Size = new System.Drawing.Size(723, 460);
            this.dividerPanel3.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(723, 460);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dividerPanel5);
            this.tabPage2.Controls.Add(this.dividerPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(715, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "玩家道具管理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dividerPanel5
            // 
            this.dividerPanel5.AllowDrop = true;
            this.dividerPanel5.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel5.Controls.Add(this.lblEquipName);
            this.dividerPanel5.Controls.Add(this.lblPos);
            this.dividerPanel5.Controls.Add(this.label6);
            this.dividerPanel5.Controls.Add(this.label5);
            this.dividerPanel5.Controls.Add(this.linkView);
            this.dividerPanel5.Controls.Add(this.label4);
            this.dividerPanel5.Controls.Add(this.label3);
            this.dividerPanel5.Controls.Add(this.label2);
            this.dividerPanel5.Controls.Add(this.dividerPanel6);
            this.dividerPanel5.Controls.Add(this.dgInfos);
            this.dividerPanel5.Controls.Add(this.lnkDel);
            this.dividerPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel5.Location = new System.Drawing.Point(109, 3);
            this.dividerPanel5.Name = "dividerPanel5";
            this.dividerPanel5.Size = new System.Drawing.Size(603, 429);
            this.dividerPanel5.TabIndex = 7;
            // 
            // lblEquipName
            // 
            this.lblEquipName.AutoSize = true;
            this.lblEquipName.Location = new System.Drawing.Point(69, 269);
            this.lblEquipName.Name = "lblEquipName";
            this.lblEquipName.Size = new System.Drawing.Size(0, 12);
            this.lblEquipName.TabIndex = 14;
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Location = new System.Drawing.Point(69, 245);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(0, 12);
            this.lblPos.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "装备详细信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "请选择装备列\r\n";
            // 
            // linkView
            // 
            this.linkView.AutoSize = true;
            this.linkView.Enabled = false;
            this.linkView.Location = new System.Drawing.Point(75, 175);
            this.linkView.Name = "linkView";
            this.linkView.Size = new System.Drawing.Size(29, 12);
            this.linkView.TabIndex = 11;
            this.linkView.TabStop = true;
            this.linkView.Text = "查看";
            this.linkView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkView_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "道具名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "位　　置：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "道具信息";
            // 
            // dividerPanel6
            // 
            this.dividerPanel6.AllowDrop = true;
            this.dividerPanel6.BorderSide = System.Windows.Forms.Border3DSide.Bottom;
            this.dividerPanel6.Location = new System.Drawing.Point(45, 221);
            this.dividerPanel6.Name = "dividerPanel6";
            this.dividerPanel6.Size = new System.Drawing.Size(277, 10);
            this.dividerPanel6.TabIndex = 6;
            // 
            // dgInfos
            // 
            this.dgInfos.AllowUserToAddRows = false;
            this.dgInfos.AllowUserToDeleteRows = false;
            this.dgInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInfos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgInfos.Location = new System.Drawing.Point(0, 0);
            this.dgInfos.Name = "dgInfos";
            this.dgInfos.ReadOnly = true;
            this.dgInfos.RowTemplate.Height = 23;
            this.dgInfos.Size = new System.Drawing.Size(603, 168);
            this.dgInfos.TabIndex = 0;
            this.dgInfos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInfos_CellClick);
            // 
            // lnkDel
            // 
            this.lnkDel.AutoSize = true;
            this.lnkDel.Location = new System.Drawing.Point(-2, 292);
            this.lnkDel.Name = "lnkDel";
            this.lnkDel.Size = new System.Drawing.Size(29, 12);
            this.lnkDel.TabIndex = 5;
            this.lnkDel.TabStop = true;
            this.lnkDel.Text = "删除";
            this.lnkDel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDel_LinkClicked);
            // 
            // dividerPanel4
            // 
            this.dividerPanel4.AllowDrop = true;
            this.dividerPanel4.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel4.Controls.Add(this.itcBody);
            this.dividerPanel4.Controls.Add(this.itcBox);
            this.dividerPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.dividerPanel4.Location = new System.Drawing.Point(3, 3);
            this.dividerPanel4.Name = "dividerPanel4";
            this.dividerPanel4.Size = new System.Drawing.Size(106, 429);
            this.dividerPanel4.TabIndex = 6;
            // 
            // itcBody
            // 
            this.itcBody.ControlPoint = new System.Drawing.Point(0, 0);
            this.itcBody.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itcBody.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("itcBody.IMG_SRC")));
            this.itcBody.ITXT_ForeColor = System.Drawing.Color.Red;
            this.itcBody.ITXT_MouseHoverColor = System.Drawing.Color.Blue;
            this.itcBody.ITXT_TEXT = "身上装备";
            this.itcBody.Location = new System.Drawing.Point(8, 12);
            this.itcBody.Name = "itcBody";
            this.itcBody.Size = new System.Drawing.Size(65, 13);
            this.itcBody.TabIndex = 1;
            this.itcBody.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.itcBody_ITC_CLICIK);
            // 
            // itcBox
            // 
            this.itcBox.ControlPoint = new System.Drawing.Point(0, 0);
            this.itcBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itcBox.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("itcBox.IMG_SRC")));
            this.itcBox.ITXT_ForeColor = System.Drawing.Color.Black;
            this.itcBox.ITXT_MouseHoverColor = System.Drawing.Color.Blue;
            this.itcBox.ITXT_TEXT = "礼物包";
            this.itcBox.Location = new System.Drawing.Point(8, 31);
            this.itcBox.Name = "itcBox";
            this.itcBox.Size = new System.Drawing.Size(53, 13);
            this.itcBox.TabIndex = 0;
            this.itcBox.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.itcBox_ITC_CLICIK);
            // 
            // backgroundWorkerReadInfoFromDB
            // 
            this.backgroundWorkerReadInfoFromDB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReadInfoFromDB_DoWork);
            this.backgroundWorkerReadInfoFromDB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReadInfoFromDB_RunWorkerCompleted);
            // 
            // backgroundWorkerDelEquipInPos
            // 
            this.backgroundWorkerDelEquipInPos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDelEquipInPos_DoWork);
            this.backgroundWorkerDelEquipInPos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDelEquipInPos_RunWorkerCompleted);
            // 
            // toyModi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 572);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "toyModi";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "玩家身上/礼物合装备管理[劲乐团]";
            this.Load += new System.EventHandler(this.toyModi_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dividerPanel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.dividerPanel5.ResumeLayout(false);
            this.dividerPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInfos)).EndInit();
            this.dividerPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNick;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblAorN;
        private System.Windows.Forms.TextBox txtAorN;
        private DividerPanel.DividerPanel dividerPanel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private ImageTextControl.IMGTXTCTRL itcBody;
        private ImageTextControl.IMGTXTCTRL itcBox;
        private System.Windows.Forms.LinkLabel lnkDel;
        private System.Windows.Forms.DataGridView dgInfos;
        private DividerPanel.DividerPanel dividerPanel5;
        private DividerPanel.DividerPanel dividerPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DividerPanel.DividerPanel dividerPanel6;
        private System.Windows.Forms.LinkLabel linkView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEquipName;
        private System.Windows.Forms.Label lblPos;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReadInfoFromDB;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDelEquipInPos;
    }
}