namespace M_Audition
{
    partial class FrmMBuyLogDetail
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
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.GrdResult = new System.Windows.Forms.DataGridView();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.DataBuyDetail = new System.Windows.Forms.DataGridView();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dividerPanel4 = new DividerPanel.DividerPanel();
            this.dividerPanel5 = new DividerPanel.DividerPanel();
            this.dividerPanel6 = new DividerPanel.DividerPanel();
            this.backgroundWorkerLoad = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.dividerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataBuyDetail)).BeginInit();
            this.dividerPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Controls.Add(this.GrdResult);
            this.dividerPanel2.Location = new System.Drawing.Point(12, 0);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(817, 186);
            this.dividerPanel2.TabIndex = 42;
            this.dividerPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.dividerPanel2_Paint);
            // 
            // GrdResult
            // 
            this.GrdResult.AllowUserToAddRows = false;
            this.GrdResult.AllowUserToDeleteRows = false;
            this.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdResult.Location = new System.Drawing.Point(0, 3);
            this.GrdResult.Name = "GrdResult";
            this.GrdResult.ReadOnly = true;
            this.GrdResult.RowTemplate.Height = 23;
            this.GrdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdResult.Size = new System.Drawing.Size(682, 92);
            this.GrdResult.TabIndex = 21;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.DataBuyDetail);
            this.dividerPanel1.Location = new System.Drawing.Point(12, 192);
            this.dividerPanel1.Name = "dividerPanel2";
            this.dividerPanel1.Size = new System.Drawing.Size(817, 187);
            this.dividerPanel1.TabIndex = 43;
            // 
            // DataBuyDetail
            // 
            this.DataBuyDetail.AllowUserToAddRows = false;
            this.DataBuyDetail.AllowUserToDeleteRows = false;
            this.DataBuyDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBuyDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataBuyDetail.Location = new System.Drawing.Point(0, 0);
            this.DataBuyDetail.Name = "DataBuyDetail";
            this.DataBuyDetail.ReadOnly = true;
            this.DataBuyDetail.RowTemplate.Height = 23;
            this.DataBuyDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataBuyDetail.Size = new System.Drawing.Size(817, 187);
            this.DataBuyDetail.TabIndex = 21;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.dataGridView2);
            this.dividerPanel3.Location = new System.Drawing.Point(12, 385);
            this.dividerPanel3.Name = "dividerPanel2";
            this.dividerPanel3.Size = new System.Drawing.Size(817, 207);
            this.dividerPanel3.TabIndex = 44;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(817, 207);
            this.dataGridView2.TabIndex = 21;
            // 
            // dividerPanel4
            // 
            this.dividerPanel4.AllowDrop = true;
            this.dividerPanel4.Location = new System.Drawing.Point(12, 598);
            this.dividerPanel4.Name = "dividerPanel2";
            this.dividerPanel4.Size = new System.Drawing.Size(817, 132);
            this.dividerPanel4.TabIndex = 45;
            // 
            // dividerPanel5
            // 
            this.dividerPanel5.AllowDrop = true;
            this.dividerPanel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.dividerPanel5.Location = new System.Drawing.Point(851, 0);
            this.dividerPanel5.Name = "dividerPanel2";
            this.dividerPanel5.Size = new System.Drawing.Size(177, 742);
            this.dividerPanel5.TabIndex = 46;
            // 
            // dividerPanel6
            // 
            this.dividerPanel6.AllowDrop = true;
            this.dividerPanel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dividerPanel6.Location = new System.Drawing.Point(1028, 0);
            this.dividerPanel6.Name = "dividerPanel2";
            this.dividerPanel6.Size = new System.Drawing.Size(10, 742);
            this.dividerPanel6.TabIndex = 47;
            // 
            // backgroundWorkerLoad
            // 
            this.backgroundWorkerLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoad_DoWork);
            this.backgroundWorkerLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoad_RunWorkerCompleted);
            // 
            // FrmMBuyLogDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 742);
            this.Controls.Add(this.dividerPanel5);
            this.Controls.Add(this.dividerPanel6);
            this.Controls.Add(this.dividerPanel4);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.dividerPanel2);
            this.Name = "FrmMBuyLogDetail";
            this.Text = "FrmMBuyLogDetail";
            this.Load += new System.EventHandler(this.FrmMBuyLogDetail_Load);
            this.dividerPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.dividerPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataBuyDetail)).EndInit();
            this.dividerPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel3;
        private DividerPanel.DividerPanel dividerPanel4;
        private DividerPanel.DividerPanel dividerPanel5;
        private DividerPanel.DividerPanel dividerPanel6;
        private System.Windows.Forms.DataGridView GrdResult;
        private System.Windows.Forms.DataGridView DataBuyDetail;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoad;
    }
}