namespace M_Audition
{
    partial class FrmShopGBuylog
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
            this.PnlSum = new System.Windows.Forms.Panel();
            this.LblSum = new System.Windows.Forms.Label();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.lblstarttime = new System.Windows.Forms.Label();
            this.lblendtime = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.CmbSort = new System.Windows.Forms.ComboBox();
            this.LblSort = new System.Windows.Forms.Label();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.GrpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.PnlSum.SuspendLayout();
            this.PnlPage.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.GrdResult);
            this.GrpResult.Controls.Add(this.PnlSum);
            this.GrpResult.Controls.Add(this.PnlPage);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 190);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(853, 392);
            this.GrpResult.TabIndex = 19;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "查询结果";
            // 
            // GrdResult
            // 
            this.GrdResult.AllowUserToAddRows = false;
            this.GrdResult.AllowUserToDeleteRows = false;
            this.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdResult.Location = new System.Drawing.Point(3, 52);
            this.GrdResult.Name = "GrdResult";
            this.GrdResult.ReadOnly = true;
            this.GrdResult.RowTemplate.Height = 23;
            this.GrdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdResult.Size = new System.Drawing.Size(847, 302);
            this.GrdResult.TabIndex = 20;
            this.GrdResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdResult_CellDoubleClick);
            // 
            // PnlSum
            // 
            this.PnlSum.Controls.Add(this.LblSum);
            this.PnlSum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlSum.Location = new System.Drawing.Point(3, 354);
            this.PnlSum.Name = "PnlSum";
            this.PnlSum.Size = new System.Drawing.Size(847, 35);
            this.PnlSum.TabIndex = 19;
            // 
            // LblSum
            // 
            this.LblSum.AutoSize = true;
            this.LblSum.Location = new System.Drawing.Point(31, 12);
            this.LblSum.Name = "LblSum";
            this.LblSum.Size = new System.Drawing.Size(0, 12);
            this.LblSum.TabIndex = 0;
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 17);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(847, 35);
            this.PnlPage.TabIndex = 0;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(9, 11);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 3;
            this.LblPage.Text = "请选择查看页数：";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(115, 8);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(121, 20);
            this.CmbPage.TabIndex = 2;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.lblstarttime);
            this.GrpSearch.Controls.Add(this.lblendtime);
            this.GrpSearch.Controls.Add(this.dateTimePickerEnd);
            this.GrpSearch.Controls.Add(this.dateTimePickerStart);
            this.GrpSearch.Controls.Add(this.BtnReset);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.TxtName);
            this.GrpSearch.Controls.Add(this.LblName);
            this.GrpSearch.Controls.Add(this.CmbSort);
            this.GrpSearch.Controls.Add(this.LblSort);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(853, 190);
            this.GrpSearch.TabIndex = 18;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // lblstarttime
            // 
            this.lblstarttime.AutoSize = true;
            this.lblstarttime.Location = new System.Drawing.Point(47, 98);
            this.lblstarttime.Name = "lblstarttime";
            this.lblstarttime.Size = new System.Drawing.Size(65, 12);
            this.lblstarttime.TabIndex = 16;
            this.lblstarttime.Text = "开始时间：";
            // 
            // lblendtime
            // 
            this.lblendtime.AutoSize = true;
            this.lblendtime.Location = new System.Drawing.Point(47, 133);
            this.lblendtime.Name = "lblendtime";
            this.lblendtime.Size = new System.Drawing.Size(65, 12);
            this.lblendtime.TabIndex = 15;
            this.lblendtime.Text = "结束时间：";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(118, 129);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(121, 21);
            this.dateTimePickerEnd.TabIndex = 14;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(118, 94);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(121, 21);
            this.dateTimePickerStart.TabIndex = 13;
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(414, 129);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 9;
            this.BtnReset.Text = "重    置";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(298, 129);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查    找";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(118, 20);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(121, 21);
            this.TxtName.TabIndex = 3;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(47, 23);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(65, 12);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "用 户 名：";
            // 
            // CmbSort
            // 
            this.CmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSort.FormattingEnabled = true;
            this.CmbSort.Location = new System.Drawing.Point(118, 56);
            this.CmbSort.Name = "CmbSort";
            this.CmbSort.Size = new System.Drawing.Size(121, 20);
            this.CmbSort.TabIndex = 1;
            // 
            // LblSort
            // 
            this.LblSort.AutoSize = true;
            this.LblSort.Location = new System.Drawing.Point(23, 56);
            this.LblSort.Name = "LblSort";
            this.LblSort.Size = new System.Drawing.Size(89, 12);
            this.LblSort.TabIndex = 0;
            this.LblSort.Text = "查询用户类型：";
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // FrmShopGBuylog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 582);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmShopGBuylog";
            this.Text = "FrmShopBuylog";
            this.Load += new System.EventHandler(this.FrmShopBuylog_Load);
            this.GrpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.PnlSum.ResumeLayout(false);
            this.PnlSum.PerformLayout();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.DataGridView GrdResult;
        private System.Windows.Forms.Panel PnlSum;
        private System.Windows.Forms.Label LblSum;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Label lblstarttime;
        private System.Windows.Forms.Label lblendtime;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.ComboBox CmbSort;
        private System.Windows.Forms.Label LblSort;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
    }
}