namespace M_o2jam_2
{
    partial class Consume
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
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxSearchType = new System.Windows.Forms.ComboBox();
            this.rbtnNick = new System.Windows.Forms.RadioButton();
            this.rbtnAccount = new System.Windows.Forms.RadioButton();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtAorN = new System.Windows.Forms.TextBox();
            this.lblAorN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.dpPageView = new DividerPanel.DividerPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxToPageIndex = new System.Windows.Forms.ComboBox();
            this.lblCurrPage = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dpInfoView = new DividerPanel.DividerPanel();
            this.dgInfoList = new System.Windows.Forms.DataGridView();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dpPageView.SuspendLayout();
            this.dpInfoView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInfoList)).BeginInit();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(589, 164);
            this.dividerPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbxSearchType);
            this.groupBox1.Controls.Add(this.rbtnNick);
            this.groupBox1.Controls.Add(this.rbtnAccount);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.txtAorN);
            this.groupBox1.Controls.Add(this.lblAorN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 164);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(185, 74);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 21);
            this.dtpEnd.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "结束时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "开始时间：";
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(185, 30);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(200, 21);
            this.dtpBegin.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "查询方式：";
            // 
            // cbxSearchType
            // 
            this.cbxSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchType.FormattingEnabled = true;
            this.cbxSearchType.Location = new System.Drawing.Point(10, 75);
            this.cbxSearchType.Name = "cbxSearchType";
            this.cbxSearchType.Size = new System.Drawing.Size(169, 20);
            this.cbxSearchType.TabIndex = 11;
            // 
            // rbtnNick
            // 
            this.rbtnNick.AutoSize = true;
            this.rbtnNick.Enabled = false;
            this.rbtnNick.Location = new System.Drawing.Point(87, 144);
            this.rbtnNick.Name = "rbtnNick";
            this.rbtnNick.Size = new System.Drawing.Size(71, 16);
            this.rbtnNick.TabIndex = 5;
            this.rbtnNick.TabStop = true;
            this.rbtnNick.Text = "昵称查询";
            this.rbtnNick.UseVisualStyleBackColor = true;
            this.rbtnNick.CheckedChanged += new System.EventHandler(this.rbtnNick_CheckedChanged);
            // 
            // rbtnAccount
            // 
            this.rbtnAccount.AutoSize = true;
            this.rbtnAccount.Checked = true;
            this.rbtnAccount.Location = new System.Drawing.Point(10, 144);
            this.rbtnAccount.Name = "rbtnAccount";
            this.rbtnAccount.Size = new System.Drawing.Size(71, 16);
            this.rbtnAccount.TabIndex = 4;
            this.rbtnAccount.TabStop = true;
            this.rbtnAccount.Text = "帐号查询";
            this.rbtnAccount.UseVisualStyleBackColor = true;
            this.rbtnAccount.CheckedChanged += new System.EventHandler(this.rbtnAccount_CheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(418, 31);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "确定";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtAorN
            // 
            this.txtAorN.Location = new System.Drawing.Point(10, 117);
            this.txtAorN.Name = "txtAorN";
            this.txtAorN.Size = new System.Drawing.Size(169, 21);
            this.txtAorN.TabIndex = 0;
            // 
            // lblAorN
            // 
            this.lblAorN.AutoSize = true;
            this.lblAorN.Location = new System.Drawing.Point(8, 103);
            this.lblAorN.Name = "lblAorN";
            this.lblAorN.Size = new System.Drawing.Size(65, 12);
            this.lblAorN.TabIndex = 2;
            this.lblAorN.Text = "帐号查询：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器：";
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(9, 31);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(170, 20);
            this.cbxServerIP.TabIndex = 0;
            // 
            // dpPageView
            // 
            this.dpPageView.AllowDrop = true;
            this.dpPageView.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpPageView.Controls.Add(this.label3);
            this.dpPageView.Controls.Add(this.cbxToPageIndex);
            this.dpPageView.Controls.Add(this.lblCurrPage);
            this.dpPageView.Controls.Add(this.lblPageCount);
            this.dpPageView.Controls.Add(this.label2);
            this.dpPageView.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpPageView.Location = new System.Drawing.Point(10, 174);
            this.dpPageView.Name = "dividerPanel2";
            this.dpPageView.Size = new System.Drawing.Size(589, 31);
            this.dpPageView.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "合计：";
            // 
            // cbxToPageIndex
            // 
            this.cbxToPageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToPageIndex.FormattingEnabled = true;
            this.cbxToPageIndex.Location = new System.Drawing.Point(197, 7);
            this.cbxToPageIndex.Name = "cbxToPageIndex";
            this.cbxToPageIndex.Size = new System.Drawing.Size(73, 20);
            this.cbxToPageIndex.TabIndex = 3;
            this.cbxToPageIndex.SelectedIndexChanged += new System.EventHandler(this.cbxToPageIndex_SelectedIndexChanged);
            // 
            // lblCurrPage
            // 
            this.lblCurrPage.AutoSize = true;
            this.lblCurrPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrPage.Location = new System.Drawing.Point(106, 13);
            this.lblCurrPage.Name = "lblCurrPage";
            this.lblCurrPage.Size = new System.Drawing.Size(23, 12);
            this.lblCurrPage.TabIndex = 2;
            this.lblCurrPage.Text = "100";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Location = new System.Drawing.Point(15, 13);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(23, 12);
            this.lblPageCount.TabIndex = 1;
            this.lblPageCount.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "共     页，当前第     页，转到第              页";
            // 
            // dpInfoView
            // 
            this.dpInfoView.AllowDrop = true;
            this.dpInfoView.Controls.Add(this.dgInfoList);
            this.dpInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpInfoView.Location = new System.Drawing.Point(10, 205);
            this.dpInfoView.Name = "dividerPanel3";
            this.dpInfoView.Size = new System.Drawing.Size(589, 145);
            this.dpInfoView.TabIndex = 2;
            // 
            // dgInfoList
            // 
            this.dgInfoList.AllowUserToAddRows = false;
            this.dgInfoList.AllowUserToDeleteRows = false;
            this.dgInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInfoList.Location = new System.Drawing.Point(0, 0);
            this.dgInfoList.Name = "dgInfoList";
            this.dgInfoList.ReadOnly = true;
            this.dgInfoList.RowTemplate.Height = 23;
            this.dgInfoList.Size = new System.Drawing.Size(589, 145);
            this.dgInfoList.TabIndex = 0;
            // 
            // Consume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 360);
            this.Controls.Add(this.dpInfoView);
            this.Controls.Add(this.dpPageView);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "Consume";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "玩家消费记录";
            this.Load += new System.EventHandler(this.GiftBox_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dpPageView.ResumeLayout(false);
            this.dpPageView.PerformLayout();
            this.dpInfoView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInfoList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnNick;
        private System.Windows.Forms.RadioButton rbtnAccount;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtAorN;
        private System.Windows.Forms.Label lblAorN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private DividerPanel.DividerPanel dpPageView;
        private DividerPanel.DividerPanel dpInfoView;
        private System.Windows.Forms.DataGridView dgInfoList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxToPageIndex;
        private System.Windows.Forms.Label lblCurrPage;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxSearchType;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label3;
    }
}