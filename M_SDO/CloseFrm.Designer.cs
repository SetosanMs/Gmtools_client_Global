﻿namespace M_SDO
{
    partial class Frm_SDO_Close
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
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.TbcResult = new System.Windows.Forms.TabControl();
            this.TpgList = new System.Windows.Forms.TabPage();
            this.GrdList = new System.Windows.Forms.DataGridView();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.TpgClose = new System.Windows.Forms.TabPage();
            this.PnlInput = new System.Windows.Forms.Panel();
            this.TxtNick = new System.Windows.Forms.TextBox();
            this.LblNN = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TxtMemo = new System.Windows.Forms.TextBox();
            this.LblMemo = new System.Windows.Forms.Label();
            this.LblUser = new System.Windows.Forms.Label();
            this.TpgOpen = new System.Windows.Forms.TabPage();
            this.PnlOpen = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnPost = new System.Windows.Forms.Button();
            this.TxtContent = new System.Windows.Forms.TextBox();
            this.LblContent = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblNick = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerFreeze = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUnFreeze = new System.ComponentModel.BackgroundWorker();
            this.Tpgquery = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorkerStatusQuery = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.TbcResult.SuspendLayout();
            this.TpgList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdList)).BeginInit();
            this.PnlPage.SuspendLayout();
            this.TpgClose.SuspendLayout();
            this.PnlInput.SuspendLayout();
            this.TpgOpen.SuspendLayout();
            this.PnlOpen.SuspendLayout();
            this.Tpgquery.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.BtnClose);
            this.GrpSearch.Controls.Add(this.Btn_Search);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(10, 10);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(765, 69);
            this.GrpSearch.TabIndex = 0;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索：";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(301, 30);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 12;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(220, 30);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 23);
            this.Btn_Search.TabIndex = 11;
            this.Btn_Search.Text = "搜索";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(10, 32);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(194, 20);
            this.CmbServer.TabIndex = 10;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(8, 17);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(77, 12);
            this.LblServer.TabIndex = 9;
            this.LblServer.Text = "游戏服务器：";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 79);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(765, 10);
            this.dividerPanel1.TabIndex = 2;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Controls.Add(this.TbcResult);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 89);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(765, 340);
            this.dividerPanel2.TabIndex = 3;
            // 
            // TbcResult
            // 
            this.TbcResult.Controls.Add(this.TpgList);
            this.TbcResult.Controls.Add(this.TpgClose);
            this.TbcResult.Controls.Add(this.TpgOpen);
            this.TbcResult.Controls.Add(this.Tpgquery);
            this.TbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcResult.Location = new System.Drawing.Point(0, 0);
            this.TbcResult.Name = "TbcResult";
            this.TbcResult.SelectedIndex = 0;
            this.TbcResult.Size = new System.Drawing.Size(765, 340);
            this.TbcResult.TabIndex = 1;
            // 
            // TpgList
            // 
            this.TpgList.Controls.Add(this.GrdList);
            this.TpgList.Controls.Add(this.PnlPage);
            this.TpgList.Location = new System.Drawing.Point(4, 21);
            this.TpgList.Name = "TpgList";
            this.TpgList.Padding = new System.Windows.Forms.Padding(3);
            this.TpgList.Size = new System.Drawing.Size(757, 315);
            this.TpgList.TabIndex = 0;
            this.TpgList.Text = "停封帐号列表";
            this.TpgList.UseVisualStyleBackColor = true;
            // 
            // GrdList
            // 
            this.GrdList.AllowUserToAddRows = false;
            this.GrdList.AllowUserToDeleteRows = false;
            this.GrdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdList.Location = new System.Drawing.Point(3, 34);
            this.GrdList.MultiSelect = false;
            this.GrdList.Name = "GrdList";
            this.GrdList.ReadOnly = true;
            this.GrdList.RowTemplate.Height = 23;
            this.GrdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdList.Size = new System.Drawing.Size(751, 278);
            this.GrdList.TabIndex = 4;
            this.GrdList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdList_CellClick);
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 3);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(751, 31);
            this.PnlPage.TabIndex = 3;
            this.PnlPage.TabStop = true;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(525, 9);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 1;
            this.LblPage.Text = "请选择查看页数：";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(632, 5);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(121, 20);
            this.CmbPage.TabIndex = 0;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
            // 
            // TpgClose
            // 
            this.TpgClose.Controls.Add(this.PnlInput);
            this.TpgClose.Location = new System.Drawing.Point(4, 21);
            this.TpgClose.Name = "TpgClose";
            this.TpgClose.Padding = new System.Windows.Forms.Padding(3);
            this.TpgClose.Size = new System.Drawing.Size(757, 315);
            this.TpgClose.TabIndex = 1;
            this.TpgClose.Text = "解封操作";
            this.TpgClose.UseVisualStyleBackColor = true;
            // 
            // PnlInput
            // 
            this.PnlInput.Controls.Add(this.TxtNick);
            this.PnlInput.Controls.Add(this.LblNN);
            this.PnlInput.Controls.Add(this.BtnReset);
            this.PnlInput.Controls.Add(this.BtnSave);
            this.PnlInput.Controls.Add(this.TxtMemo);
            this.PnlInput.Controls.Add(this.LblMemo);
            this.PnlInput.Controls.Add(this.LblUser);
            this.PnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlInput.Location = new System.Drawing.Point(3, 3);
            this.PnlInput.Name = "PnlInput";
            this.PnlInput.Size = new System.Drawing.Size(751, 309);
            this.PnlInput.TabIndex = 0;
            // 
            // TxtNick
            // 
            this.TxtNick.Location = new System.Drawing.Point(15, 32);
            this.TxtNick.Name = "TxtNick";
            this.TxtNick.Size = new System.Drawing.Size(273, 21);
            this.TxtNick.TabIndex = 19;
            // 
            // LblNN
            // 
            this.LblNN.AutoSize = true;
            this.LblNN.Location = new System.Drawing.Point(13, 17);
            this.LblNN.Name = "LblNN";
            this.LblNN.Size = new System.Drawing.Size(65, 12);
            this.LblNN.TabIndex = 18;
            this.LblNN.Text = "帐号名称：";
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(388, 30);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 17;
            this.BtnReset.Text = "重置";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(307, 30);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 16;
            this.BtnSave.Text = "解封帐号";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtMemo
            // 
            this.TxtMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtMemo.Enabled = false;
            this.TxtMemo.Location = new System.Drawing.Point(13, 90);
            this.TxtMemo.Multiline = true;
            this.TxtMemo.Name = "TxtMemo";
            this.TxtMemo.ReadOnly = true;
            this.TxtMemo.Size = new System.Drawing.Size(461, 163);
            this.TxtMemo.TabIndex = 15;
            // 
            // LblMemo
            // 
            this.LblMemo.AutoSize = true;
            this.LblMemo.Location = new System.Drawing.Point(11, 74);
            this.LblMemo.Name = "LblMemo";
            this.LblMemo.Size = new System.Drawing.Size(65, 12);
            this.LblMemo.TabIndex = 14;
            this.LblMemo.Text = "封停原因：";
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(11, 17);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(0, 12);
            this.LblUser.TabIndex = 9;
            this.LblUser.Visible = false;
            // 
            // TpgOpen
            // 
            this.TpgOpen.Controls.Add(this.PnlOpen);
            this.TpgOpen.Location = new System.Drawing.Point(4, 21);
            this.TpgOpen.Name = "TpgOpen";
            this.TpgOpen.Padding = new System.Windows.Forms.Padding(3);
            this.TpgOpen.Size = new System.Drawing.Size(757, 315);
            this.TpgOpen.TabIndex = 2;
            this.TpgOpen.Text = "封停帐号";
            this.TpgOpen.UseVisualStyleBackColor = true;
            // 
            // PnlOpen
            // 
            this.PnlOpen.Controls.Add(this.label2);
            this.PnlOpen.Controls.Add(this.label1);
            this.PnlOpen.Controls.Add(this.BtnClear);
            this.PnlOpen.Controls.Add(this.BtnPost);
            this.PnlOpen.Controls.Add(this.TxtContent);
            this.PnlOpen.Controls.Add(this.LblContent);
            this.PnlOpen.Controls.Add(this.TxtAccount);
            this.PnlOpen.Controls.Add(this.LblNick);
            this.PnlOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlOpen.Location = new System.Drawing.Point(3, 3);
            this.PnlOpen.Name = "PnlOpen";
            this.PnlOpen.Size = new System.Drawing.Size(751, 309);
            this.PnlOpen.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "停封帐号前请先选择确定玩家所在的服务器";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(17, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "提醒：";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(455, 32);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 9;
            this.BtnClear.Text = "重置";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnPost
            // 
            this.BtnPost.Location = new System.Drawing.Point(374, 32);
            this.BtnPost.Name = "BtnPost";
            this.BtnPost.Size = new System.Drawing.Size(75, 23);
            this.BtnPost.TabIndex = 8;
            this.BtnPost.Text = "停封帐号";
            this.BtnPost.UseVisualStyleBackColor = true;
            this.BtnPost.Click += new System.EventHandler(this.BtnPost_Click);
            // 
            // TxtContent
            // 
            this.TxtContent.Location = new System.Drawing.Point(19, 75);
            this.TxtContent.Multiline = true;
            this.TxtContent.Name = "TxtContent";
            this.TxtContent.Size = new System.Drawing.Size(511, 114);
            this.TxtContent.TabIndex = 7;
            // 
            // LblContent
            // 
            this.LblContent.AutoSize = true;
            this.LblContent.Location = new System.Drawing.Point(17, 60);
            this.LblContent.Name = "LblContent";
            this.LblContent.Size = new System.Drawing.Size(65, 12);
            this.LblContent.TabIndex = 6;
            this.LblContent.Text = "停封原因：";
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(19, 34);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(338, 21);
            this.TxtAccount.TabIndex = 1;
            // 
            // LblNick
            // 
            this.LblNick.AutoSize = true;
            this.LblNick.Location = new System.Drawing.Point(17, 19);
            this.LblNick.Name = "LblNick";
            this.LblNick.Size = new System.Drawing.Size(101, 12);
            this.LblNick.TabIndex = 0;
            this.LblNick.Text = "请输入玩家帐号：";
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // backgroundWorkerPageChanged
            // 
            this.backgroundWorkerPageChanged.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPageChanged_DoWork);
            this.backgroundWorkerPageChanged.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPageChanged_RunWorkerCompleted);
            // 
            // backgroundWorkerFreeze
            // 
            this.backgroundWorkerFreeze.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFreeze_DoWork);
            this.backgroundWorkerFreeze.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFreeze_RunWorkerCompleted);
            // 
            // backgroundWorkerUnFreeze
            // 
            this.backgroundWorkerUnFreeze.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUnFreeze_DoWork);
            this.backgroundWorkerUnFreeze.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUnFreeze_RunWorkerCompleted);
            // 
            // Tpgquery
            // 
            this.Tpgquery.Controls.Add(this.button2);
            this.Tpgquery.Controls.Add(this.button1);
            this.Tpgquery.Controls.Add(this.textBox1);
            this.Tpgquery.Controls.Add(this.label3);
            this.Tpgquery.Location = new System.Drawing.Point(4, 21);
            this.Tpgquery.Name = "Tpgquery";
            this.Tpgquery.Size = new System.Drawing.Size(757, 315);
            this.Tpgquery.TabIndex = 3;
            this.Tpgquery.Text = "已停封帐号查询";
            this.Tpgquery.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 21);
            this.textBox1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "帐号名称：";
            // 
            // backgroundWorkerStatusQuery
            // 
            this.backgroundWorkerStatusQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerStatusQuery_DoWork);
            this.backgroundWorkerStatusQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerStatusQuery_RunWorkerCompleted);
            // 
            // Frm_SDO_Close
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 439);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.GrpSearch);
            this.Name = "Frm_SDO_Close";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "帐号解/封停[超级舞者]";
            this.Load += new System.EventHandler(this.Frm_SDO_Close_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.TbcResult.ResumeLayout(false);
            this.TpgList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdList)).EndInit();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.TpgClose.ResumeLayout(false);
            this.PnlInput.ResumeLayout(false);
            this.PnlInput.PerformLayout();
            this.TpgOpen.ResumeLayout(false);
            this.PnlOpen.ResumeLayout(false);
            this.PnlOpen.PerformLayout();
            this.Tpgquery.ResumeLayout(false);
            this.Tpgquery.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.Button BtnClose;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.TabControl TbcResult;
        private System.Windows.Forms.TabPage TpgList;
        private System.Windows.Forms.DataGridView GrdList;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.TabPage TpgClose;
        private System.Windows.Forms.Panel PnlInput;
        private System.Windows.Forms.TextBox TxtNick;
        private System.Windows.Forms.Label LblNN;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TxtMemo;
        private System.Windows.Forms.Label LblMemo;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.TabPage TpgOpen;
        private System.Windows.Forms.Panel PnlOpen;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnPost;
        private System.Windows.Forms.TextBox TxtContent;
        private System.Windows.Forms.Label LblContent;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblNick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFreeze;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUnFreeze;
        private System.Windows.Forms.TabPage Tpgquery;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorkerStatusQuery;
    }
}