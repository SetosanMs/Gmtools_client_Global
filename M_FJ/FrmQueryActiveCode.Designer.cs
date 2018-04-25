namespace M_FJ
{
    partial class FrmQueryActiveCode
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
            this.checkBoxBat = new System.Windows.Forms.CheckBox();
            this.BtnClear = new System.Windows.Forms.Button();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerAccont = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerActiveCode = new System.ComponentModel.BackgroundWorker();
            this.GrpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.RoleInfoView);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 86);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(709, 341);
            this.GrpResult.TabIndex = 16;
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
            this.RoleInfoView.Size = new System.Drawing.Size(703, 321);
            this.RoleInfoView.TabIndex = 8;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.checkBoxBat);
            this.GrpSearch.Controls.Add(this.BtnClear);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(709, 86);
            this.GrpSearch.TabIndex = 15;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // checkBoxBat
            // 
            this.checkBoxBat.AutoSize = true;
            this.checkBoxBat.Location = new System.Drawing.Point(55, 54);
            this.checkBoxBat.Name = "checkBoxBat";
            this.checkBoxBat.Size = new System.Drawing.Size(84, 16);
            this.checkBoxBat.TabIndex = 28;
            this.checkBoxBat.Text = "激活码查询";
            this.checkBoxBat.UseVisualStyleBackColor = true;
            this.checkBoxBat.CheckedChanged += new System.EventHandler(this.checkBoxBat_CheckedChanged);
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
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
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
            this.LblAccount.Location = new System.Drawing.Point(53, 28);
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
            // backgroundWorkerAccont
            // 
            this.backgroundWorkerAccont.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAccont_DoWork);
            this.backgroundWorkerAccont.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAccont_RunWorkerCompleted);
            // 
            // backgroundWorkerActiveCode
            // 
            this.backgroundWorkerActiveCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerActiveCode_DoWork);
            this.backgroundWorkerActiveCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerActiveCode_RunWorkerCompleted);
            // 
            // FrmQueryActiveCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 427);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmQueryActiveCode";
            this.Text = "帐号激活码查询";
            this.Load += new System.EventHandler(this.FrmQueryActiveCode_Load);
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
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.CheckBox checkBoxBat;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAccont;
        private System.ComponentModel.BackgroundWorker backgroundWorkerActiveCode;
    }
}