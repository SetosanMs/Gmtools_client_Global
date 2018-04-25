namespace M_o2jam
{
    partial class RSBInfo
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
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.lblCount = new System.Windows.Forms.Label();
            this.cbxToPageIndex = new System.Windows.Forms.ComboBox();
            this.lblCurrPage = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRecv = new System.Windows.Forms.CheckBox();
            this.chkSend = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.chkConsumeOther = new System.Windows.Forms.CheckBox();
            this.chkConsumeMySelf = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkNick = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblAorN = new System.Windows.Forms.Label();
            this.txtAorN = new System.Windows.Forms.TextBox();
            this.dpContainer = new DividerPanel.DividerPanel();
            this.dgConsumeInfo = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerReadInfoFromDB = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel2.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dpContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Controls.Add(this.lblCount);
            this.dividerPanel2.Controls.Add(this.cbxToPageIndex);
            this.dividerPanel2.Controls.Add(this.lblCurrPage);
            this.dividerPanel2.Controls.Add(this.lblPageCount);
            this.dividerPanel2.Controls.Add(this.label2);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 164);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(594, 28);
            this.dividerPanel2.TabIndex = 6;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(261, 11);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 12);
            this.lblCount.TabIndex = 4;
            // 
            // cbxToPageIndex
            // 
            this.cbxToPageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToPageIndex.FormattingEnabled = true;
            this.cbxToPageIndex.Location = new System.Drawing.Point(172, 5);
            this.cbxToPageIndex.Name = "cbxToPageIndex";
            this.cbxToPageIndex.Size = new System.Drawing.Size(64, 20);
            this.cbxToPageIndex.TabIndex = 3;
            this.cbxToPageIndex.SelectedIndexChanged += new System.EventHandler(this.cbxToPageIndex_SelectedIndexChanged);
            // 
            // lblCurrPage
            // 
            this.lblCurrPage.AutoSize = true;
            this.lblCurrPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrPage.Location = new System.Drawing.Point(90, 12);
            this.lblCurrPage.Name = "lblCurrPage";
            this.lblCurrPage.Size = new System.Drawing.Size(11, 12);
            this.lblCurrPage.TabIndex = 2;
            this.lblCurrPage.Text = "1";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Location = new System.Drawing.Point(19, 12);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(11, 12);
            this.lblPageCount.TabIndex = 1;
            this.lblPageCount.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "共　　页，当前　　页，转到第　　　　　　页";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(594, 154);
            this.dividerPanel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRecv);
            this.groupBox1.Controls.Add(this.chkSend);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpBeginDate);
            this.groupBox1.Controls.Add(this.chkConsumeOther);
            this.groupBox1.Controls.Add(this.chkConsumeMySelf);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkNick);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.chkAccount);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.lblAorN);
            this.groupBox1.Controls.Add(this.txtAorN);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 154);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // chkRecv
            // 
            this.chkRecv.AutoSize = true;
            this.chkRecv.Location = new System.Drawing.Point(453, 76);
            this.chkRecv.Name = "chkRecv";
            this.chkRecv.Size = new System.Drawing.Size(60, 16);
            this.chkRecv.TabIndex = 16;
            this.chkRecv.Text = "接受方";
            this.chkRecv.UseVisualStyleBackColor = true;
            this.chkRecv.Click += new System.EventHandler(this.chkRecv_Click);
            // 
            // chkSend
            // 
            this.chkSend.AutoSize = true;
            this.chkSend.Location = new System.Drawing.Point(453, 54);
            this.chkSend.Name = "chkSend";
            this.chkSend.Size = new System.Drawing.Size(60, 16);
            this.chkSend.TabIndex = 15;
            this.chkSend.Text = "发送方";
            this.chkSend.UseVisualStyleBackColor = true;
            this.chkSend.Click += new System.EventHandler(this.chkSend_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "结束日期：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(204, 69);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(153, 21);
            this.dtpEndDate.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "开始日期：";
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(204, 32);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(153, 21);
            this.dtpBeginDate.TabIndex = 11;
            // 
            // chkConsumeOther
            // 
            this.chkConsumeOther.AutoSize = true;
            this.chkConsumeOther.Location = new System.Drawing.Point(375, 54);
            this.chkConsumeOther.Name = "chkConsumeOther";
            this.chkConsumeOther.Size = new System.Drawing.Size(72, 16);
            this.chkConsumeOther.TabIndex = 10;
            this.chkConsumeOther.Text = "交易记录";
            this.chkConsumeOther.UseVisualStyleBackColor = true;
            this.chkConsumeOther.Click += new System.EventHandler(this.chkConsumeOther_Click);
            // 
            // chkConsumeMySelf
            // 
            this.chkConsumeMySelf.AutoSize = true;
            this.chkConsumeMySelf.Checked = true;
            this.chkConsumeMySelf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsumeMySelf.Location = new System.Drawing.Point(375, 32);
            this.chkConsumeMySelf.Name = "chkConsumeMySelf";
            this.chkConsumeMySelf.Size = new System.Drawing.Size(72, 16);
            this.chkConsumeMySelf.TabIndex = 9;
            this.chkConsumeMySelf.Text = "消费记录";
            this.chkConsumeMySelf.UseVisualStyleBackColor = true;
            this.chkConsumeMySelf.Click += new System.EventHandler(this.chkConsumeMySelf_Click);
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
            this.chkNick.Location = new System.Drawing.Point(86, 97);
            this.chkNick.Name = "chkNick";
            this.chkNick.Size = new System.Drawing.Size(72, 16);
            this.chkNick.TabIndex = 5;
            this.chkNick.Text = "昵称查询";
            this.chkNick.UseVisualStyleBackColor = true;
            this.chkNick.Click += new System.EventHandler(this.chkNick_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(89, 119);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "重置";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Checked = true;
            this.chkAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccount.Location = new System.Drawing.Point(8, 97);
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
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(8, 119);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "查看";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblAorN
            // 
            this.lblAorN.AutoSize = true;
            this.lblAorN.Location = new System.Drawing.Point(6, 56);
            this.lblAorN.Name = "lblAorN";
            this.lblAorN.Size = new System.Drawing.Size(65, 12);
            this.lblAorN.TabIndex = 2;
            this.lblAorN.Text = "玩家帐号：";
            // 
            // txtAorN
            // 
            this.txtAorN.Location = new System.Drawing.Point(8, 70);
            this.txtAorN.Name = "txtAorN";
            this.txtAorN.Size = new System.Drawing.Size(180, 21);
            this.txtAorN.TabIndex = 3;
            // 
            // dpContainer
            // 
            this.dpContainer.AllowDrop = true;
            this.dpContainer.Controls.Add(this.dgConsumeInfo);
            this.dpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpContainer.Location = new System.Drawing.Point(10, 192);
            this.dpContainer.Name = "dividerPanel3";
            this.dpContainer.Size = new System.Drawing.Size(594, 181);
            this.dpContainer.TabIndex = 7;
            // 
            // dgConsumeInfo
            // 
            this.dgConsumeInfo.AllowUserToAddRows = false;
            this.dgConsumeInfo.AllowUserToDeleteRows = false;
            this.dgConsumeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConsumeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgConsumeInfo.Location = new System.Drawing.Point(0, 0);
            this.dgConsumeInfo.Name = "dgConsumeInfo";
            this.dgConsumeInfo.ReadOnly = true;
            this.dgConsumeInfo.RowTemplate.Height = 23;
            this.dgConsumeInfo.Size = new System.Drawing.Size(594, 181);
            this.dgConsumeInfo.TabIndex = 0;
            // 
            // backgroundWorkerReadInfoFromDB
            // 
            this.backgroundWorkerReadInfoFromDB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReadInfoFromDB_DoWork);
            this.backgroundWorkerReadInfoFromDB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReadInfoFromDB_RunWorkerCompleted);
            // 
            // RSBInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 383);
            this.Controls.Add(this.dpContainer);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "RSBInfo";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "玩家交易/消费记录[劲乐团]";
            this.Load += new System.EventHandler(this.RSBInfo_Load);
            this.dividerPanel2.ResumeLayout(false);
            this.dividerPanel2.PerformLayout();
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dpContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumeInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNick;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblAorN;
        private System.Windows.Forms.TextBox txtAorN;
        private System.Windows.Forms.CheckBox chkConsumeMySelf;
        private System.Windows.Forms.CheckBox chkConsumeOther;
        private DividerPanel.DividerPanel dpContainer;
        private System.Windows.Forms.DataGridView dgConsumeInfo;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrPage;
        private System.Windows.Forms.ComboBox cbxToPageIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.CheckBox chkRecv;
        private System.Windows.Forms.CheckBox chkSend;
        private System.Windows.Forms.Label lblCount;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReadInfoFromDB;
    }
}