namespace M_SDO
{
    partial class Frm_SDO_Rechargeable
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
            this.BtnSearch = new System.Windows.Forms.Button();
            this.DtpEnd = new System.Windows.Forms.DateTimePicker();
            this.LblLink = new System.Windows.Forms.Label();
            this.DtpBegin = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.GrdResult = new System.Windows.Forms.DataGridView();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.LblTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.TabQueryType = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DataGrd = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerSearchNotM = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.PnlPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GrpResult.SuspendLayout();
            this.TabQueryType.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrd)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.BtnClose);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.DtpEnd);
            this.GrpSearch.Controls.Add(this.LblLink);
            this.GrpSearch.Controls.Add(this.DtpBegin);
            this.GrpSearch.Controls.Add(this.LblDate);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(10, 10);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(795, 114);
            this.GrpSearch.TabIndex = 3;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.Location = new System.Drawing.Point(360, 78);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(71, 23);
            this.BtnClose.TabIndex = 14;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(360, 33);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(72, 23);
            this.BtnSearch.TabIndex = 13;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // DtpEnd
            // 
            this.DtpEnd.Location = new System.Drawing.Point(207, 80);
            this.DtpEnd.Name = "DtpEnd";
            this.DtpEnd.Size = new System.Drawing.Size(136, 21);
            this.DtpEnd.TabIndex = 12;
            // 
            // LblLink
            // 
            this.LblLink.AutoSize = true;
            this.LblLink.Location = new System.Drawing.Point(205, 64);
            this.LblLink.Name = "LblLink";
            this.LblLink.Size = new System.Drawing.Size(29, 12);
            this.LblLink.TabIndex = 11;
            this.LblLink.Text = "到：";
            // 
            // DtpBegin
            // 
            this.DtpBegin.Location = new System.Drawing.Point(207, 36);
            this.DtpBegin.Name = "DtpBegin";
            this.DtpBegin.Size = new System.Drawing.Size(136, 21);
            this.DtpBegin.TabIndex = 10;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(205, 21);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(65, 12);
            this.LblDate.TabIndex = 9;
            this.LblDate.Text = "时间范围：";
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(10, 81);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(175, 21);
            this.TxtAccount.TabIndex = 6;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(8, 64);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(65, 12);
            this.LblAccount.TabIndex = 5;
            this.LblAccount.Text = "玩家帐号：";
            this.LblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.Location = new System.Drawing.Point(10, 36);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(175, 20);
            this.CmbServer.TabIndex = 3;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(8, 21);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(77, 12);
            this.LblServer.TabIndex = 1;
            this.LblServer.Text = "选择服务器：";
            // 
            // GrdResult
            // 
            this.GrdResult.AllowUserToAddRows = false;
            this.GrdResult.AllowUserToDeleteRows = false;
            this.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdResult.Location = new System.Drawing.Point(3, 34);
            this.GrdResult.Name = "GrdResult";
            this.GrdResult.ReadOnly = true;
            this.GrdResult.RowTemplate.Height = 23;
            this.GrdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdResult.Size = new System.Drawing.Size(775, 280);
            this.GrdResult.TabIndex = 9;
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 3);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(775, 31);
            this.PnlPage.TabIndex = 6;
            this.PnlPage.TabStop = true;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(10, 9);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 1;
            this.LblPage.Text = "请选择查看页数：";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(117, 5);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(121, 20);
            this.CmbPage.TabIndex = 0;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
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
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Location = new System.Drawing.Point(34, 11);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(0, 12);
            this.LblTotal.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblTotal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 32);
            this.panel1.TabIndex = 8;
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.TabQueryType);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(10, 124);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(795, 394);
            this.GrpResult.TabIndex = 6;
            this.GrpResult.TabStop = false;
            // 
            // TabQueryType
            // 
            this.TabQueryType.Controls.Add(this.tabPage1);
            this.TabQueryType.Controls.Add(this.tabPage2);
            this.TabQueryType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabQueryType.Location = new System.Drawing.Point(3, 17);
            this.TabQueryType.Name = "TabQueryType";
            this.TabQueryType.SelectedIndex = 0;
            this.TabQueryType.Size = new System.Drawing.Size(789, 374);
            this.TabQueryType.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GrdResult);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.PnlPage);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(781, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "充值记录";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DataGrd);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "到帐记录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DataGrd
            // 
            this.DataGrd.AllowUserToAddRows = false;
            this.DataGrd.AllowUserToDeleteRows = false;
            this.DataGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrd.Location = new System.Drawing.Point(3, 3);
            this.DataGrd.Name = "DataGrd";
            this.DataGrd.ReadOnly = true;
            this.DataGrd.RowTemplate.Height = 23;
            this.DataGrd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrd.Size = new System.Drawing.Size(775, 343);
            this.DataGrd.TabIndex = 10;
            // 
            // backgroundWorkerSearchNotM
            // 
            this.backgroundWorkerSearchNotM.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearchNotM_DoWork);
            this.backgroundWorkerSearchNotM.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearchNotM_RunWorkerCompleted);
            // 
            // Frm_SDO_Rechargeable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 528);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "Frm_SDO_Rechargeable";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "玩家充值明细[超级舞者]";
            this.Load += new System.EventHandler(this.Frm_SDO_Rechargeable_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GrpResult.ResumeLayout(false);
            this.TabQueryType.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DateTimePicker DtpEnd;
        private System.Windows.Forms.Label LblLink;
        private System.Windows.Forms.DateTimePicker DtpBegin;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.DataGridView GrdResult;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.TabControl TabQueryType;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DataGrd;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearchNotM;
    }
}