namespace M_Audition
{
    partial class FrmUserCashExp
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
            this.PnlDetail = new System.Windows.Forms.Panel();
            this.LblDetail = new System.Windows.Forms.Label();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.buttonSaveAS = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.GrpResult.SuspendLayout();
            this.PnlDetail.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.PnlDetail);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 90);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(634, 339);
            this.GrpResult.TabIndex = 3;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "搜索结果";
            // 
            // PnlDetail
            // 
            this.PnlDetail.AutoScroll = true;
            this.PnlDetail.Controls.Add(this.LblDetail);
            this.PnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDetail.Location = new System.Drawing.Point(3, 17);
            this.PnlDetail.Name = "PnlDetail";
            this.PnlDetail.Size = new System.Drawing.Size(628, 319);
            this.PnlDetail.TabIndex = 0;
            this.PnlDetail.Visible = false;
            // 
            // LblDetail
            // 
            this.LblDetail.AutoSize = true;
            this.LblDetail.Location = new System.Drawing.Point(44, 9);
            this.LblDetail.Name = "LblDetail";
            this.LblDetail.Size = new System.Drawing.Size(0, 12);
            this.LblDetail.TabIndex = 0;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.buttonSaveAS);
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(634, 90);
            this.GrpSearch.TabIndex = 2;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // buttonSaveAS
            // 
            this.buttonSaveAS.Enabled = false;
            this.buttonSaveAS.Location = new System.Drawing.Point(513, 36);
            this.buttonSaveAS.Name = "buttonSaveAS";
            this.buttonSaveAS.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAS.TabIndex = 14;
            this.buttonSaveAS.Text = "另存文本";
            this.buttonSaveAS.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(416, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(93, 38);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(197, 21);
            this.TxtAccount.TabIndex = 6;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(22, 41);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(65, 12);
            this.LblAccount.TabIndex = 5;
            this.LblAccount.Text = "用 户 名：";
            this.LblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(316, 36);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // FrmUserCashExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 429);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmUserCashExp";
            this.Text = "FrmUserCashExp";
            this.Load += new System.EventHandler(this.FrmUserCashExp_Load);
            this.GrpResult.ResumeLayout(false);
            this.PnlDetail.ResumeLayout(false);
            this.PnlDetail.PerformLayout();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.Panel PnlDetail;
        private System.Windows.Forms.Label LblDetail;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button buttonSaveAS;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
    }
}