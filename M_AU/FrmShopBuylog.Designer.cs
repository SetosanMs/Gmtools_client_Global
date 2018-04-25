namespace M_Audition
{
    partial class FrmShopBuylog
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
            this.TbcResult = new System.Windows.Forms.TabControl();
            this.TpgCharacter = new System.Windows.Forms.TabPage();
            this.GrdResult = new System.Windows.Forms.DataGridView();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.PnlSum = new System.Windows.Forms.Panel();
            this.LblSum = new System.Windows.Forms.Label();
            this.TpgItem = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnSupply = new System.Windows.Forms.Button();
            this.BtnRepeat = new System.Windows.Forms.Button();
            this.BtnRefundment = new System.Windows.Forms.Button();
            this.dividerPanel5 = new DividerPanel.DividerPanel();
            this.DataBuyDetail = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DataBuyresult = new System.Windows.Forms.DataGridView();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.textBoxDetail = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
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
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorkerLoad = new System.ComponentModel.BackgroundWorker();
            this.GrpResult.SuspendLayout();
            this.TbcResult.SuspendLayout();
            this.TpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.PnlPage.SuspendLayout();
            this.PnlSum.SuspendLayout();
            this.TpgItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataBuyDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataBuyresult)).BeginInit();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.TbcResult);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 184);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(1036, 498);
            this.GrpResult.TabIndex = 19;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "查询结果";
            // 
            // TbcResult
            // 
            this.TbcResult.Controls.Add(this.TpgCharacter);
            this.TbcResult.Controls.Add(this.TpgItem);
            this.TbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcResult.Location = new System.Drawing.Point(3, 17);
            this.TbcResult.Name = "TbcResult";
            this.TbcResult.SelectedIndex = 0;
            this.TbcResult.Size = new System.Drawing.Size(1030, 478);
            this.TbcResult.TabIndex = 5;
            // 
            // TpgCharacter
            // 
            this.TpgCharacter.Controls.Add(this.GrdResult);
            this.TpgCharacter.Controls.Add(this.PnlPage);
            this.TpgCharacter.Controls.Add(this.PnlSum);
            this.TpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.TpgCharacter.Name = "TpgCharacter";
            this.TpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCharacter.Size = new System.Drawing.Size(1022, 453);
            this.TpgCharacter.TabIndex = 0;
            this.TpgCharacter.Text = "购买记录";
            this.TpgCharacter.UseVisualStyleBackColor = true;
            // 
            // GrdResult
            // 
            this.GrdResult.AllowUserToAddRows = false;
            this.GrdResult.AllowUserToDeleteRows = false;
            this.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdResult.Location = new System.Drawing.Point(3, 38);
            this.GrdResult.Name = "GrdResult";
            this.GrdResult.ReadOnly = true;
            this.GrdResult.RowTemplate.Height = 23;
            this.GrdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdResult.Size = new System.Drawing.Size(1016, 377);
            this.GrdResult.TabIndex = 20;
            this.GrdResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdResult_CellDoubleClick);
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 3);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(1016, 35);
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
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
            // 
            // PnlSum
            // 
            this.PnlSum.Controls.Add(this.LblSum);
            this.PnlSum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlSum.Location = new System.Drawing.Point(3, 415);
            this.PnlSum.Name = "PnlSum";
            this.PnlSum.Size = new System.Drawing.Size(1016, 35);
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
            // TpgItem
            // 
            this.TpgItem.Controls.Add(this.label4);
            this.TpgItem.Controls.Add(this.label3);
            this.TpgItem.Controls.Add(this.label2);
            this.TpgItem.Controls.Add(this.button1);
            this.TpgItem.Controls.Add(this.BtnSupply);
            this.TpgItem.Controls.Add(this.BtnRepeat);
            this.TpgItem.Controls.Add(this.BtnRefundment);
            this.TpgItem.Controls.Add(this.dividerPanel5);
            this.TpgItem.Controls.Add(this.DataBuyDetail);
            this.TpgItem.Controls.Add(this.dataGridView2);
            this.TpgItem.Controls.Add(this.DataBuyresult);
            this.TpgItem.Location = new System.Drawing.Point(4, 21);
            this.TpgItem.Name = "TpgItem";
            this.TpgItem.Padding = new System.Windows.Forms.Padding(3);
            this.TpgItem.Size = new System.Drawing.Size(1041, 464);
            this.TpgItem.TabIndex = 1;
            this.TpgItem.Text = "购买明细";
            this.TpgItem.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 54;
            this.label4.Text = "[游戏]用户仓库道具状态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 53;
            this.label3.Text = "[游戏]购买道具记录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 52;
            this.label2.Text = "[商城]购买记录";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(863, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 26);
            this.button1.TabIndex = 51;
            this.button1.Text = "异常购买补发";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnSupply
            // 
            this.BtnSupply.Location = new System.Drawing.Point(863, 236);
            this.BtnSupply.Name = "BtnSupply";
            this.BtnSupply.Size = new System.Drawing.Size(121, 26);
            this.BtnSupply.TabIndex = 50;
            this.BtnSupply.Text = "允许用户重新领取";
            this.BtnSupply.UseVisualStyleBackColor = true;
            this.BtnSupply.Click += new System.EventHandler(this.BtnSupply_Click);
            // 
            // BtnRepeat
            // 
            this.BtnRepeat.Location = new System.Drawing.Point(863, 159);
            this.BtnRepeat.Name = "BtnRepeat";
            this.BtnRepeat.Size = new System.Drawing.Size(121, 26);
            this.BtnRepeat.TabIndex = 49;
            this.BtnRepeat.Text = "重复购买退款";
            this.BtnRepeat.UseVisualStyleBackColor = true;
            this.BtnRepeat.Click += new System.EventHandler(this.BtnRepeat_Click);
            // 
            // BtnRefundment
            // 
            this.BtnRefundment.Location = new System.Drawing.Point(863, 88);
            this.BtnRefundment.Name = "BtnRefundment";
            this.BtnRefundment.Size = new System.Drawing.Size(121, 26);
            this.BtnRefundment.TabIndex = 48;
            this.BtnRefundment.Text = "错误购买退款";
            this.BtnRefundment.UseVisualStyleBackColor = true;
            this.BtnRefundment.Click += new System.EventHandler(this.BtnRefundment_Click);
            // 
            // dividerPanel5
            // 
            this.dividerPanel5.AllowDrop = true;
            this.dividerPanel5.Location = new System.Drawing.Point(825, 3);
            this.dividerPanel5.Name = "dividerPanel2";
            this.dividerPanel5.Size = new System.Drawing.Size(10, 742);
            this.dividerPanel5.TabIndex = 47;
            // 
            // DataBuyDetail
            // 
            this.DataBuyDetail.AllowUserToAddRows = false;
            this.DataBuyDetail.AllowUserToDeleteRows = false;
            this.DataBuyDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBuyDetail.Location = new System.Drawing.Point(6, 201);
            this.DataBuyDetail.Name = "DataBuyDetail";
            this.DataBuyDetail.ReadOnly = true;
            this.DataBuyDetail.RowTemplate.Height = 23;
            this.DataBuyDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataBuyDetail.Size = new System.Drawing.Size(813, 130);
            this.DataBuyDetail.TabIndex = 24;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 366);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(813, 130);
            this.dataGridView2.TabIndex = 23;
            // 
            // DataBuyresult
            // 
            this.DataBuyresult.AllowUserToAddRows = false;
            this.DataBuyresult.AllowUserToDeleteRows = false;
            this.DataBuyresult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBuyresult.Location = new System.Drawing.Point(6, 37);
            this.DataBuyresult.Name = "DataBuyresult";
            this.DataBuyresult.ReadOnly = true;
            this.DataBuyresult.RowTemplate.Height = 23;
            this.DataBuyresult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataBuyresult.Size = new System.Drawing.Size(813, 130);
            this.DataBuyresult.TabIndex = 22;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.textBoxDetail);
            this.GrpSearch.Controls.Add(this.labelDescription);
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
            this.GrpSearch.Size = new System.Drawing.Size(1036, 184);
            this.GrpSearch.TabIndex = 18;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // textBoxDetail
            // 
            this.textBoxDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDetail.ForeColor = System.Drawing.Color.Red;
            this.textBoxDetail.Location = new System.Drawing.Point(378, 20);
            this.textBoxDetail.Multiline = true;
            this.textBoxDetail.Name = "textBoxDetail";
            this.textBoxDetail.ReadOnly = true;
            this.textBoxDetail.Size = new System.Drawing.Size(236, 76);
            this.textBoxDetail.TabIndex = 18;
            this.textBoxDetail.Text = "道具价格类似100(5)这样的格式代表价值100M币和5积分\r\n\r\n查询开始时间不得早于2007年4月21日";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDescription.Location = new System.Drawing.Point(295, 20);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(77, 14);
            this.labelDescription.TabIndex = 17;
            this.labelDescription.Text = "温馨提示：";
            // 
            // lblstarttime
            // 
            this.lblstarttime.AutoSize = true;
            this.lblstarttime.Location = new System.Drawing.Point(47, 83);
            this.lblstarttime.Name = "lblstarttime";
            this.lblstarttime.Size = new System.Drawing.Size(65, 12);
            this.lblstarttime.TabIndex = 16;
            this.lblstarttime.Text = "开始时间：";
            // 
            // lblendtime
            // 
            this.lblendtime.AutoSize = true;
            this.lblendtime.Location = new System.Drawing.Point(47, 115);
            this.lblendtime.Name = "lblendtime";
            this.lblendtime.Size = new System.Drawing.Size(65, 12);
            this.lblendtime.TabIndex = 15;
            this.lblendtime.Text = "结束时间：";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(118, 111);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(121, 21);
            this.dateTimePickerEnd.TabIndex = 14;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(118, 79);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(121, 21);
            this.dateTimePickerStart.TabIndex = 13;
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(419, 102);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 9;
            this.BtnReset.Text = "重    置";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(297, 102);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查    找";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(118, 18);
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
            this.CmbSort.Location = new System.Drawing.Point(118, 49);
            this.CmbSort.Name = "CmbSort";
            this.CmbSort.Size = new System.Drawing.Size(121, 20);
            this.CmbSort.TabIndex = 1;
            // 
            // LblSort
            // 
            this.LblSort.AutoSize = true;
            this.LblSort.Location = new System.Drawing.Point(23, 52);
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
            // backgroundWorkerPageChanged
            // 
            this.backgroundWorkerPageChanged.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerPageChanged.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPageChanged_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // FrmShopBuylog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 682);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmShopBuylog";
            this.Text = "FrmShopBuylog";
            this.Load += new System.EventHandler(this.FrmShopBuylog_Load);
            this.GrpResult.ResumeLayout(false);
            this.TbcResult.ResumeLayout(false);
            this.TpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.PnlSum.ResumeLayout(false);
            this.PnlSum.PerformLayout();
            this.TpgItem.ResumeLayout(false);
            this.TpgItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataBuyDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataBuyresult)).EndInit();
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
        private System.Windows.Forms.TextBox textBoxDetail;
        private System.Windows.Forms.Label labelDescription;
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
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.Windows.Forms.TabControl TbcResult;
        private System.Windows.Forms.TabPage TpgCharacter;
        private System.Windows.Forms.TabPage TpgItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataBuyDetail;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView DataBuyresult;
        private DividerPanel.DividerPanel dividerPanel5;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoad;
        private System.Windows.Forms.Button BtnSupply;
        private System.Windows.Forms.Button BtnRepeat;
        private System.Windows.Forms.Button BtnRefundment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}