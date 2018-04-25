namespace M_SDO
{
    partial class FrmQueryUserPadInfo
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.chkCode = new System.Windows.Forms.CheckBox();
            this.chkKeyID = new System.Windows.Forms.CheckBox();
            this.txtKeyOrCode = new System.Windows.Forms.TextBox();
            this.lblKeyOrCode = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.GrpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.GrdResult);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 92);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(711, 388);
            this.GrpResult.TabIndex = 12;
            this.GrpResult.TabStop = false;
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
            this.GrdResult.Size = new System.Drawing.Size(705, 368);
            this.GrdResult.TabIndex = 8;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.btnQuery);
            this.GrpSearch.Controls.Add(this.chkCode);
            this.GrpSearch.Controls.Add(this.chkKeyID);
            this.GrpSearch.Controls.Add(this.txtKeyOrCode);
            this.GrpSearch.Controls.Add(this.lblKeyOrCode);
            this.GrpSearch.Controls.Add(this.BtnClose);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(711, 92);
            this.GrpSearch.TabIndex = 11;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(243, 32);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // chkCode
            // 
            this.chkCode.AutoSize = true;
            this.chkCode.Location = new System.Drawing.Point(80, 59);
            this.chkCode.Name = "chkCode";
            this.chkCode.Size = new System.Drawing.Size(60, 16);
            this.chkCode.TabIndex = 13;
            this.chkCode.Text = "激活码";
            this.chkCode.UseVisualStyleBackColor = true;
            this.chkCode.Click += new System.EventHandler(this.chkCode_Click);
            // 
            // chkKeyID
            // 
            this.chkKeyID.AutoSize = true;
            this.chkKeyID.Checked = true;
            this.chkKeyID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeyID.Location = new System.Drawing.Point(14, 59);
            this.chkKeyID.Name = "chkKeyID";
            this.chkKeyID.Size = new System.Drawing.Size(60, 16);
            this.chkKeyID.TabIndex = 12;
            this.chkKeyID.Text = "序列号";
            this.chkKeyID.UseVisualStyleBackColor = true;
            this.chkKeyID.Click += new System.EventHandler(this.chkKeyID_Click);
            // 
            // txtKeyOrCode
            // 
            this.txtKeyOrCode.Location = new System.Drawing.Point(14, 32);
            this.txtKeyOrCode.Name = "txtKeyOrCode";
            this.txtKeyOrCode.Size = new System.Drawing.Size(198, 21);
            this.txtKeyOrCode.TabIndex = 11;
            // 
            // lblKeyOrCode
            // 
            this.lblKeyOrCode.AutoSize = true;
            this.lblKeyOrCode.Location = new System.Drawing.Point(12, 17);
            this.lblKeyOrCode.Name = "lblKeyOrCode";
            this.lblKeyOrCode.Size = new System.Drawing.Size(53, 12);
            this.lblKeyOrCode.TabIndex = 10;
            this.lblKeyOrCode.Text = "序列号：";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.Location = new System.Drawing.Point(324, 32);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // FrmQueryUserPadInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 480);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmQueryUserPadInfo";
            this.Text = "FrmQueryUserPadInfo";
            this.Load += new System.EventHandler(this.FrmQueryUserPadInfo_Load);
            this.GrpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.DataGridView GrdResult;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.CheckBox chkCode;
        private System.Windows.Forms.CheckBox chkKeyID;
        private System.Windows.Forms.TextBox txtKeyOrCode;
        private System.Windows.Forms.Label lblKeyOrCode;
    }
}