namespace M_o2jam_2
{
    partial class GiftGoxView
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
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelGift = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnSendView = new System.Windows.Forms.Button();
            this.txtAorN = new System.Windows.Forms.TextBox();
            this.lblAorN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.dpTop = new DividerPanel.DividerPanel();
            this.cbxToPageIndex = new System.Windows.Forms.ComboBox();
            this.dpRight = new DividerPanel.DividerPanel();
            this.dgGiftCotain = new System.Windows.Forms.DataGridView();
            this.dpRR = new DividerPanel.DividerPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRecvUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorkerDelItem = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSendItem = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dpTop.SuspendLayout();
            this.dpRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGiftCotain)).BeginInit();
            this.dpRR.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(678, 62);
            this.dividerPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelGift);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.btnSendView);
            this.groupBox1.Controls.Add(this.txtAorN);
            this.groupBox1.Controls.Add(this.lblAorN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(678, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // btnDelGift
            // 
            this.btnDelGift.Location = new System.Drawing.Point(574, 28);
            this.btnDelGift.Name = "btnDelGift";
            this.btnDelGift.Size = new System.Drawing.Size(75, 23);
            this.btnDelGift.TabIndex = 8;
            this.btnDelGift.Text = "删除";
            this.btnDelGift.UseVisualStyleBackColor = true;
            this.btnDelGift.Click += new System.EventHandler(this.btnDelGift_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(412, 28);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "重置";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(331, 28);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "确定";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnSendView
            // 
            this.btnSendView.Location = new System.Drawing.Point(493, 28);
            this.btnSendView.Name = "btnSendView";
            this.btnSendView.Size = new System.Drawing.Size(75, 23);
            this.btnSendView.TabIndex = 9;
            this.btnSendView.Text = "赠送道具";
            this.btnSendView.UseVisualStyleBackColor = true;
            this.btnSendView.Click += new System.EventHandler(this.btnSendView_Click);
            // 
            // txtAorN
            // 
            this.txtAorN.Location = new System.Drawing.Point(170, 30);
            this.txtAorN.Name = "txtAorN";
            this.txtAorN.Size = new System.Drawing.Size(155, 21);
            this.txtAorN.TabIndex = 0;
            // 
            // lblAorN
            // 
            this.lblAorN.AutoSize = true;
            this.lblAorN.Location = new System.Drawing.Point(168, 16);
            this.lblAorN.Name = "lblAorN";
            this.lblAorN.Size = new System.Drawing.Size(65, 12);
            this.lblAorN.TabIndex = 2;
            this.lblAorN.Text = "帐号查询：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器：";
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(9, 31);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(142, 20);
            this.cbxServerIP.TabIndex = 0;
            // 
            // dpTop
            // 
            this.dpTop.AllowDrop = true;
            this.dpTop.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpTop.Controls.Add(this.cbxToPageIndex);
            this.dpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpTop.Location = new System.Drawing.Point(10, 72);
            this.dpTop.Name = "dividerPanel2";
            this.dpTop.Size = new System.Drawing.Size(678, 34);
            this.dpTop.TabIndex = 2;
            // 
            // cbxToPageIndex
            // 
            this.cbxToPageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToPageIndex.FormattingEnabled = true;
            this.cbxToPageIndex.Location = new System.Drawing.Point(0, 8);
            this.cbxToPageIndex.Name = "cbxToPageIndex";
            this.cbxToPageIndex.Size = new System.Drawing.Size(355, 20);
            this.cbxToPageIndex.TabIndex = 7;
            this.cbxToPageIndex.SelectedIndexChanged += new System.EventHandler(this.cbxToPageIndex_SelectedIndexChanged);
            // 
            // dpRight
            // 
            this.dpRight.AllowDrop = true;
            this.dpRight.Controls.Add(this.dgGiftCotain);
            this.dpRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpRight.Location = new System.Drawing.Point(10, 106);
            this.dpRight.Name = "dpRight";
            this.dpRight.Size = new System.Drawing.Size(355, 436);
            this.dpRight.TabIndex = 3;
            // 
            // dgGiftCotain
            // 
            this.dgGiftCotain.AllowUserToAddRows = false;
            this.dgGiftCotain.AllowUserToDeleteRows = false;
            this.dgGiftCotain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGiftCotain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgGiftCotain.Location = new System.Drawing.Point(0, 0);
            this.dgGiftCotain.Name = "dgGiftCotain";
            this.dgGiftCotain.ReadOnly = true;
            this.dgGiftCotain.RowTemplate.Height = 23;
            this.dgGiftCotain.Size = new System.Drawing.Size(355, 436);
            this.dgGiftCotain.TabIndex = 0;
            this.dgGiftCotain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgGiftCotain_CellClick);
            this.dgGiftCotain.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgGiftCotain_ColumnHeaderMouseClick);
            this.dgGiftCotain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgGiftCotain_MouseUp);
            // 
            // dpRR
            // 
            this.dpRR.AllowDrop = true;
            this.dpRR.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpRR.Controls.Add(this.groupBox2);
            this.dpRR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpRR.Location = new System.Drawing.Point(365, 106);
            this.dpRR.Name = "dividerPanel2";
            this.dpRR.Size = new System.Drawing.Size(323, 436);
            this.dpRR.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtItemName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtContent);
            this.groupBox2.Controls.Add(this.txtTitle);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtRecvUser);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(7, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 404);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "赠送：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(94, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "赠送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(13, 285);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(289, 21);
            this.txtItemName.TabIndex = 9;
            this.txtItemName.DoubleClick += new System.EventHandler(this.txtItemName_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "道具(双击输入框)：";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(13, 125);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(289, 139);
            this.txtContent.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(13, 82);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(289, 21);
            this.txtTitle.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "内容：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "标题：";
            // 
            // txtRecvUser
            // 
            this.txtRecvUser.Location = new System.Drawing.Point(13, 43);
            this.txtRecvUser.Name = "txtRecvUser";
            this.txtRecvUser.ReadOnly = true;
            this.txtRecvUser.Size = new System.Drawing.Size(289, 21);
            this.txtRecvUser.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "接收人：";
            // 
            // backgroundWorkerDelItem
            // 
            this.backgroundWorkerDelItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDelItem_DoWork);
            this.backgroundWorkerDelItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDelItem_RunWorkerCompleted);
            // 
            // backgroundWorkerSendItem
            // 
            this.backgroundWorkerSendItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSendItem_DoWork);
            this.backgroundWorkerSendItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSendItem_RunWorkerCompleted);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // GiftGoxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 552);
            this.Controls.Add(this.dpRR);
            this.Controls.Add(this.dpRight);
            this.Controls.Add(this.dpTop);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "GiftGoxView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "玩家礼物盒[超级乐者]";
            this.Load += new System.EventHandler(this.GiftGoxView_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dpTop.ResumeLayout(false);
            this.dpRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgGiftCotain)).EndInit();
            this.dpRR.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtAorN;
        private System.Windows.Forms.Label lblAorN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private DividerPanel.DividerPanel dpTop;
        private DividerPanel.DividerPanel dpRight;
        private System.Windows.Forms.ComboBox cbxToPageIndex;
        private System.Windows.Forms.DataGridView dgGiftCotain;
        private DividerPanel.DividerPanel dpRR;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRecvUser;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDelGift;
        private System.Windows.Forms.Button btnSendView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDelItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSendItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
    }
}