namespace M_RC
{
    partial class FrmQueryPlayerID
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
            this.RoleInfoView = new System.Windows.Forms.DataGridView();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.TxtNickname = new System.Windows.Forms.TextBox();
            this.lblNickname = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.GrpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.RoleInfoView);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 97);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(754, 445);
            this.GrpResult.TabIndex = 18;
            this.GrpResult.TabStop = false;
            // 
            // RoleInfoView
            // 
            this.RoleInfoView.AllowUserToAddRows = false;
            this.RoleInfoView.AllowUserToDeleteRows = false;
            this.RoleInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleInfoView.Location = new System.Drawing.Point(3, 17);
            this.RoleInfoView.Name = "RoleInfoView";
            this.RoleInfoView.ReadOnly = true;
            this.RoleInfoView.RowTemplate.Height = 23;
            this.RoleInfoView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoleInfoView.Size = new System.Drawing.Size(748, 425);
            this.RoleInfoView.TabIndex = 8;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.TxtNickname);
            this.GrpSearch.Controls.Add(this.lblNickname);
            this.GrpSearch.Controls.Add(this.BtnClear);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(754, 97);
            this.GrpSearch.TabIndex = 17;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // TxtNickname
            // 
            this.TxtNickname.Location = new System.Drawing.Point(118, 57);
            this.TxtNickname.Name = "TxtNickname";
            this.TxtNickname.Size = new System.Drawing.Size(142, 21);
            this.TxtNickname.TabIndex = 11;
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Location = new System.Drawing.Point(53, 60);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(59, 12);
            this.lblNickname.TabIndex = 10;
            this.lblNickname.Text = "玩家呢称:";
            this.lblNickname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnClear
            // 
            this.BtnClear.AutoSize = true;
            this.BtnClear.Location = new System.Drawing.Point(539, 24);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(78, 23);
            this.BtnClear.TabIndex = 9;
            this.BtnClear.Text = "关闭";
            this.BtnClear.UseVisualStyleBackColor = true;
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(118, 24);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(142, 21);
            this.TxtAccount.TabIndex = 6;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(53, 30);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(59, 12);
            this.LblAccount.TabIndex = 5;
            this.LblAccount.Text = "玩家帐号:";
            this.LblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(424, 24);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(78, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // FrmQueryPlayerID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 542);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmQueryPlayerID";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmQueryPlayerID_Load);
            this.GrpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).EndInit();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.DataGridView RoleInfoView;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.TextBox TxtNickname;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
    }
}

