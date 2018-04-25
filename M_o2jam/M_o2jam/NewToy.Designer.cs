namespace M_o2jam
{
    partial class NewToy
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
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.gbxItemChk = new System.Windows.Forms.GroupBox();
            this.lvItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dpContainerChk = new DividerPanel.DividerPanel();
            this.lblResultText = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnAorNChk = new System.Windows.Forms.Button();
            this.chkNick = new System.Windows.Forms.CheckBox();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.txtAorN = new System.Windows.Forms.TextBox();
            this.gbxExpire = new System.Windows.Forms.GroupBox();
            this.dtpExpire = new System.Windows.Forms.ComboBox();
            this.gbxGiftList = new System.Windows.Forms.GroupBox();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dgItemsList = new System.Windows.Forms.DataGridView();
            this.btnDel = new System.Windows.Forms.Button();
            this.gbxItemChk.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.dpContainerChk.SuspendLayout();
            this.gbxExpire.SuspendLayout();
            this.gbxGiftList.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemsList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(54, 21);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(171, 21);
            this.txtItemName.TabIndex = 1;
            // 
            // gbxItemChk
            // 
            this.gbxItemChk.Controls.Add(this.lvItems);
            this.gbxItemChk.Controls.Add(this.btnItemSearch);
            this.gbxItemChk.Controls.Add(this.txtItemName);
            this.gbxItemChk.Controls.Add(this.label1);
            this.gbxItemChk.Controls.Add(this.dividerPanel1);
            this.gbxItemChk.Location = new System.Drawing.Point(12, 245);
            this.gbxItemChk.Name = "gbxItemChk";
            this.gbxItemChk.Size = new System.Drawing.Size(340, 286);
            this.gbxItemChk.TabIndex = 2;
            this.gbxItemChk.TabStop = false;
            this.gbxItemChk.Text = "道具查询";
            // 
            // lvItems
            // 
            this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvItems.Location = new System.Drawing.Point(9, 62);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(323, 218);
            this.lvItems.TabIndex = 4;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.Click += new System.EventHandler(this.lvItems_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "道具名称";
            this.columnHeader1.Width = 278;
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(231, 20);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(75, 23);
            this.btnItemSearch.TabIndex = 2;
            this.btnItemSearch.Text = "查询";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.BorderSide = System.Windows.Forms.Border3DSide.Bottom;
            this.dividerPanel1.Location = new System.Drawing.Point(6, 46);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(329, 10);
            this.dividerPanel1.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(11, 597);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(92, 597);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "重置";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(11, 20);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(323, 20);
            this.cbxServerIP.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxServerIP);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 49);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dpContainerChk);
            this.groupBox3.Controls.Add(this.btnAorNChk);
            this.groupBox3.Controls.Add(this.chkNick);
            this.groupBox3.Controls.Add(this.chkAccount);
            this.groupBox3.Controls.Add(this.txtAorN);
            this.groupBox3.Location = new System.Drawing.Point(12, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 172);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "获增玩家：";
            // 
            // dpContainerChk
            // 
            this.dpContainerChk.AllowDrop = true;
            this.dpContainerChk.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dpContainerChk.Controls.Add(this.lblResultText);
            this.dpContainerChk.Controls.Add(this.lblResult);
            this.dpContainerChk.Location = new System.Drawing.Point(8, 65);
            this.dpContainerChk.Name = "dividerPanel1";
            this.dpContainerChk.Size = new System.Drawing.Size(329, 101);
            this.dpContainerChk.TabIndex = 4;
            // 
            // lblResultText
            // 
            this.lblResultText.AutoSize = true;
            this.lblResultText.Location = new System.Drawing.Point(1, 31);
            this.lblResultText.Name = "lblResultText";
            this.lblResultText.Size = new System.Drawing.Size(221, 48);
            this.lblResultText.TabIndex = 6;
            this.lblResultText.Text = "帐号可以使用。\r\n\r\n请在右边的道具查询中检索要赠送的道具\r\n\r\n";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(1, 10);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(65, 12);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "检测结果：";
            // 
            // btnAorNChk
            // 
            this.btnAorNChk.Location = new System.Drawing.Point(257, 20);
            this.btnAorNChk.Name = "btnAorNChk";
            this.btnAorNChk.Size = new System.Drawing.Size(75, 23);
            this.btnAorNChk.TabIndex = 3;
            this.btnAorNChk.Text = "检索";
            this.btnAorNChk.UseVisualStyleBackColor = true;
            this.btnAorNChk.Click += new System.EventHandler(this.btnAorNChk_Click);
            // 
            // chkNick
            // 
            this.chkNick.AutoSize = true;
            this.chkNick.Location = new System.Drawing.Point(86, 47);
            this.chkNick.Name = "chkNick";
            this.chkNick.Size = new System.Drawing.Size(72, 16);
            this.chkNick.TabIndex = 2;
            this.chkNick.Text = "昵称查询";
            this.chkNick.UseVisualStyleBackColor = true;
            this.chkNick.Click += new System.EventHandler(this.chkNick_Click);
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Checked = true;
            this.chkAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccount.Location = new System.Drawing.Point(8, 47);
            this.chkAccount.Name = "chkAccount";
            this.chkAccount.Size = new System.Drawing.Size(72, 16);
            this.chkAccount.TabIndex = 1;
            this.chkAccount.Text = "帐号查询";
            this.chkAccount.UseVisualStyleBackColor = true;
            this.chkAccount.Click += new System.EventHandler(this.chkAccount_Click);
            // 
            // txtAorN
            // 
            this.txtAorN.Location = new System.Drawing.Point(9, 20);
            this.txtAorN.Name = "txtAorN";
            this.txtAorN.Size = new System.Drawing.Size(242, 21);
            this.txtAorN.TabIndex = 0;
            // 
            // gbxExpire
            // 
            this.gbxExpire.Controls.Add(this.dtpExpire);
            this.gbxExpire.Location = new System.Drawing.Point(12, 538);
            this.gbxExpire.Name = "gbxExpire";
            this.gbxExpire.Size = new System.Drawing.Size(340, 53);
            this.gbxExpire.TabIndex = 12;
            this.gbxExpire.TabStop = false;
            this.gbxExpire.Text = "使用期限";
            // 
            // dtpExpire
            // 
            this.dtpExpire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dtpExpire.FormattingEnabled = true;
            this.dtpExpire.Items.AddRange(new object[] {
            "1个月",
            "3个月",
            "永久"});
            this.dtpExpire.Location = new System.Drawing.Point(9, 20);
            this.dtpExpire.Name = "dtpExpire";
            this.dtpExpire.Size = new System.Drawing.Size(323, 20);
            this.dtpExpire.TabIndex = 0;
            // 
            // gbxGiftList
            // 
            this.gbxGiftList.Controls.Add(this.dividerPanel3);
            this.gbxGiftList.Location = new System.Drawing.Point(358, 12);
            this.gbxGiftList.Name = "gbxGiftList";
            this.gbxGiftList.Size = new System.Drawing.Size(474, 579);
            this.gbxGiftList.TabIndex = 13;
            this.gbxGiftList.TabStop = false;
            this.gbxGiftList.Text = "道具列表";
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel3.Controls.Add(this.dgItemsList);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(3, 17);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.dividerPanel3.Size = new System.Drawing.Size(468, 559);
            this.dividerPanel3.TabIndex = 1;
            // 
            // dgItemsList
            // 
            this.dgItemsList.AllowUserToAddRows = false;
            this.dgItemsList.AllowUserToDeleteRows = false;
            this.dgItemsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItemsList.Location = new System.Drawing.Point(5, 5);
            this.dgItemsList.MultiSelect = false;
            this.dgItemsList.Name = "dgItemsList";
            this.dgItemsList.ReadOnly = true;
            this.dgItemsList.RowTemplate.Height = 23;
            this.dgItemsList.Size = new System.Drawing.Size(458, 549);
            this.dgItemsList.TabIndex = 0;
            this.dgItemsList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItemsList_CellClick);
            this.dgItemsList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgItemsList_ColumnHeaderMouseClick);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(358, 597);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 14;
            this.btnDel.Text = "删除道具";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // NewToy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 638);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.gbxGiftList);
            this.Controls.Add(this.gbxExpire);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbxItemChk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewToy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "道具赠送[劲乐团]";
            this.Load += new System.EventHandler(this.NewToy_Load);
            this.gbxItemChk.ResumeLayout(false);
            this.gbxItemChk.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.dpContainerChk.ResumeLayout(false);
            this.dpContainerChk.PerformLayout();
            this.gbxExpire.ResumeLayout(false);
            this.gbxGiftList.ResumeLayout(false);
            this.dividerPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItemsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.GroupBox gbxItemChk;
        private System.Windows.Forms.Button btnItemSearch;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAorNChk;
        private System.Windows.Forms.CheckBox chkNick;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.TextBox txtAorN;
        private DividerPanel.DividerPanel dpContainerChk;
        private System.Windows.Forms.Label lblResultText;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.GroupBox gbxExpire;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox gbxGiftList;
        private DividerPanel.DividerPanel dividerPanel3;
        private System.Windows.Forms.DataGridView dgItemsList;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ComboBox dtpExpire;
    }
}