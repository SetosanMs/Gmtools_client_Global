namespace M_Audition
{
    partial class FrmLockAccont
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
            this.LblStatus = new System.Windows.Forms.Label();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LblServer = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.GrpResult.SuspendLayout();
            this.PnlDetail.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.PnlDetail);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 49);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(617, 347);
            this.GrpResult.TabIndex = 7;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "搜索结果";
            // 
            // PnlDetail
            // 
            this.PnlDetail.AutoScroll = true;
            this.PnlDetail.Controls.Add(this.LblStatus);
            this.PnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDetail.Location = new System.Drawing.Point(3, 17);
            this.PnlDetail.Name = "PnlDetail";
            this.PnlDetail.Size = new System.Drawing.Size(611, 327);
            this.PnlDetail.TabIndex = 0;
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(65, 37);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(0, 12);
            this.LblStatus.TabIndex = 0;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(617, 49);
            this.GrpSearch.TabIndex = 6;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(488, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(15, 22);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(71, 12);
            this.LblServer.TabIndex = 7;
            this.LblServer.Text = "ESN序列号：";
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(92, 17);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(138, 21);
            this.TxtAccount.TabIndex = 6;
            this.TxtAccount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtAccount_KeyUp);
            this.TxtAccount.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TxtAccount_MouseUp);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(382, 15);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(79, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // FrmLockAccont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 396);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmLockAccont";
            this.Text = "查询ESN状态";
            this.Load += new System.EventHandler(this.FrmLockAccont_Load);
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
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Button BtnSearch;
    }
}