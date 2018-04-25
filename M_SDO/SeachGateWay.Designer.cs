namespace M_SDO
{
    partial class SeachGateWay
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
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.GrdResult = new System.Windows.Forms.DataGridView();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtIP = new System.Windows.Forms.TextBox();
            this.LblIP = new System.Windows.Forms.Label();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.GrpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.GrpSearch.SuspendLayout();
            this.PnlPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.PnlPage);
            this.GrpResult.Controls.Add(this.GrdResult);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 155);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(578, 272);
            this.GrpResult.TabIndex = 7;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "搜索结果";
            // 
            // GrdResult
            // 
            this.GrdResult.AllowUserToAddRows = false;
            this.GrdResult.AllowUserToDeleteRows = false;
            this.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdResult.Location = new System.Drawing.Point(3, 17);
            this.GrdResult.Name = "GrdResult";
            this.GrdResult.ReadOnly = true;
            this.GrdResult.RowTemplate.Height = 23;
            this.GrdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdResult.Size = new System.Drawing.Size(572, 252);
            this.GrdResult.TabIndex = 8;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.BtnClose);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.TxtIP);
            this.GrpSearch.Controls.Add(this.LblIP);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(578, 155);
            this.GrpSearch.TabIndex = 6;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.Location = new System.Drawing.Point(215, 114);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(68, 23);
            this.BtnClose.TabIndex = 14;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(116, 114);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(69, 23);
            this.BtnSearch.TabIndex = 13;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtIP
            // 
            this.TxtIP.Location = new System.Drawing.Point(116, 35);
            this.TxtIP.Name = "TxtIP";
            this.TxtIP.Size = new System.Drawing.Size(167, 21);
            this.TxtIP.TabIndex = 6;
            // 
            // LblIP
            // 
            this.LblIP.AutoSize = true;
            this.LblIP.Location = new System.Drawing.Point(45, 38);
            this.LblIP.Name = "LblIP";
            this.LblIP.Size = new System.Drawing.Size(53, 12);
            this.LblIP.TabIndex = 5;
            this.LblIP.Text = "输入IP：";
            this.LblIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 17);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(572, 31);
            this.PnlPage.TabIndex = 9;
            this.PnlPage.TabStop = true;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(3, 9);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 1;
            this.LblPage.Text = "请选择查看页数：";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(110, 5);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(121, 20);
            this.CmbPage.TabIndex = 0;
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.Location = new System.Drawing.Point(116, 62);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(167, 20);
            this.CmbServer.TabIndex = 16;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(21, 68);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(77, 12);
            this.LblServer.TabIndex = 15;
            this.LblServer.Text = "选择服务器：";
            // 
            // SeachGateWay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 427);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "SeachGateWay";
            this.Text = "查询GateWay";
            this.Load += new System.EventHandler(this.SeachGateWay_Load);
            this.GrpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.DataGridView GrdResult;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtIP;
        private System.Windows.Forms.Label LblIP;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
    }
}