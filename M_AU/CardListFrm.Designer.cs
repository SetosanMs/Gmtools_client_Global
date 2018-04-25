namespace M_Audition
{
    partial class Frm_Shop_CardList
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
            this.textBoxDetail = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.CmbSort = new System.Windows.Forms.ComboBox();
            this.LblSort = new System.Windows.Forms.Label();
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.GrdResult = new System.Windows.Forms.DataGridView();
            this.PnlSum = new System.Windows.Forms.Panel();
            this.LblSum = new System.Windows.Forms.Label();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.GrpSearch.SuspendLayout();
            this.GrpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.PnlSum.SuspendLayout();
            this.PnlPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.dateTimePickerEnd);
            this.GrpSearch.Controls.Add(this.dateTimePickerStart);
            this.GrpSearch.Controls.Add(this.textBoxDetail);
            this.GrpSearch.Controls.Add(this.labelDescription);
            this.GrpSearch.Controls.Add(this.labelStartDate);
            this.GrpSearch.Controls.Add(this.labelEndDate);
            this.GrpSearch.Controls.Add(this.BtnReset);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.TxtName);
            this.GrpSearch.Controls.Add(this.LblName);
            this.GrpSearch.Controls.Add(this.CmbSort);
            this.GrpSearch.Controls.Add(this.LblSort);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(792, 194);
            this.GrpSearch.TabIndex = 12;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // textBoxDetail
            // 
            this.textBoxDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDetail.ForeColor = System.Drawing.Color.Red;
            this.textBoxDetail.Location = new System.Drawing.Point(342, 16);
            this.textBoxDetail.Multiline = true;
            this.textBoxDetail.Name = "textBoxDetail";
            this.textBoxDetail.ReadOnly = true;
            this.textBoxDetail.Size = new System.Drawing.Size(195, 76);
            this.textBoxDetail.TabIndex = 16;
            this.textBoxDetail.Text = "此查询最多提供50条记录。如果查询不到您要的记录，请适当的缩小查询日期的范围。";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDescription.Location = new System.Drawing.Point(259, 16);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(77, 14);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Text = "温馨提示：";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(44, 88);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(65, 12);
            this.labelStartDate.TabIndex = 13;
            this.labelStartDate.Text = "开始时间：";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(44, 118);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(65, 12);
            this.labelEndDate.TabIndex = 12;
            this.labelEndDate.Text = "结束时间：";
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(361, 105);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 9;
            this.BtnReset.Text = "重    置";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(262, 105);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查    找";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(118, 47);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(121, 21);
            this.TxtName.TabIndex = 3;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(44, 51);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(65, 12);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "用 户 名：";
            // 
            // CmbSort
            // 
            this.CmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSort.FormattingEnabled = true;
            this.CmbSort.Location = new System.Drawing.Point(118, 16);
            this.CmbSort.Name = "CmbSort";
            this.CmbSort.Size = new System.Drawing.Size(121, 20);
            this.CmbSort.TabIndex = 1;
            // 
            // LblSort
            // 
            this.LblSort.AutoSize = true;
            this.LblSort.Location = new System.Drawing.Point(44, 20);
            this.LblSort.Name = "LblSort";
            this.LblSort.Size = new System.Drawing.Size(65, 12);
            this.LblSort.TabIndex = 0;
            this.LblSort.Text = "查询类型：";
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.GrdResult);
            this.GrpResult.Controls.Add(this.PnlSum);
            this.GrpResult.Controls.Add(this.PnlPage);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 194);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(792, 223);
            this.GrpResult.TabIndex = 13;
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
            this.GrdResult.Size = new System.Drawing.Size(786, 133);
            this.GrdResult.TabIndex = 3;
            // 
            // PnlSum
            // 
            this.PnlSum.Controls.Add(this.LblSum);
            this.PnlSum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlSum.Location = new System.Drawing.Point(3, 185);
            this.PnlSum.Name = "PnlSum";
            this.PnlSum.Size = new System.Drawing.Size(786, 35);
            this.PnlSum.TabIndex = 2;
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
            this.PnlPage.Size = new System.Drawing.Size(786, 35);
            this.PnlPage.TabIndex = 0;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(306, 13);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 3;
            this.LblPage.Text = "请选择查看页数：";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(413, 9);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(121, 20);
            this.CmbPage.TabIndex = 2;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
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
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(118, 114);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(121, 21);
            this.dateTimePickerEnd.TabIndex = 18;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(118, 79);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(121, 21);
            this.dateTimePickerStart.TabIndex = 17;
            // 
            // Frm_Shop_CardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 417);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "Frm_Shop_CardList";
            this.Text = "用户充值记录";
            this.Load += new System.EventHandler(this.Frm_Shop_CardList_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.GrpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.PnlSum.ResumeLayout(false);
            this.PnlSum.PerformLayout();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.Label LblSort;
        private System.Windows.Forms.ComboBox CmbSort;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DataGridView GrdResult;
        private System.Windows.Forms.Panel PnlSum;
        private System.Windows.Forms.Label LblSum;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDetail;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
    }
}