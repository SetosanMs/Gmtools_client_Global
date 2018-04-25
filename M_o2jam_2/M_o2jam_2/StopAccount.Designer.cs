namespace M_o2jam_2
{
    partial class StopAccount
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.gbxStpActView = new System.Windows.Forms.GroupBox();
            this.dgStpActView = new System.Windows.Forms.DataGridView();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.cbxToPageIndex = new System.Windows.Forms.ComboBox();
            this.dpStopActView = new DividerPanel.DividerPanel();
            this.dpActaion = new DividerPanel.DividerPanel();
            this.lblActionText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActCancel = new System.Windows.Forms.Button();
            this.btnUnStpAct = new System.Windows.Forms.Button();
            this.TxtContent = new System.Windows.Forms.TextBox();
            this.LblContent = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblNick = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbxStpActView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStpActView)).BeginInit();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.dpStopActView.SuspendLayout();
            this.dpActaion.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器";
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(6, 20);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(288, 20);
            this.cbxServerIP.TabIndex = 1;
            // 
            // gbxStpActView
            // 
            this.gbxStpActView.Controls.Add(this.dgStpActView);
            this.gbxStpActView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxStpActView.Location = new System.Drawing.Point(0, 0);
            this.gbxStpActView.Name = "gbxStpActView";
            this.gbxStpActView.Padding = new System.Windows.Forms.Padding(5);
            this.gbxStpActView.Size = new System.Drawing.Size(299, 331);
            this.gbxStpActView.TabIndex = 1;
            this.gbxStpActView.TabStop = false;
            this.gbxStpActView.Text = "已停封列表";
            // 
            // dgStpActView
            // 
            this.dgStpActView.AllowUserToAddRows = false;
            this.dgStpActView.AllowUserToDeleteRows = false;
            this.dgStpActView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStpActView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStpActView.Location = new System.Drawing.Point(5, 19);
            this.dgStpActView.Name = "dgStpActView";
            this.dgStpActView.ReadOnly = true;
            this.dgStpActView.RowTemplate.Height = 23;
            this.dgStpActView.Size = new System.Drawing.Size(289, 307);
            this.dgStpActView.TabIndex = 0;
            this.dgStpActView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStpActView_CellClick);
            this.dgStpActView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgStpActView_ColumnHeaderMouseClick);
            this.dgStpActView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgStpActView_MouseUp);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Controls.Add(this.button2);
            this.dividerPanel1.Controls.Add(this.button4);
            this.dividerPanel1.Controls.Add(this.button1);
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(599, 64);
            this.dividerPanel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(508, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(418, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 46);
            this.button4.TabIndex = 2;
            this.button4.Text = "停封帐号";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "显示已停封帐号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Controls.Add(this.cbxToPageIndex);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 74);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(599, 25);
            this.dividerPanel2.TabIndex = 3;
            // 
            // cbxToPageIndex
            // 
            this.cbxToPageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxToPageIndex.FormattingEnabled = true;
            this.cbxToPageIndex.Location = new System.Drawing.Point(138, 4);
            this.cbxToPageIndex.Name = "cbxToPageIndex";
            this.cbxToPageIndex.Size = new System.Drawing.Size(161, 20);
            this.cbxToPageIndex.TabIndex = 0;
            this.cbxToPageIndex.SelectedIndexChanged += new System.EventHandler(this.cbxToPageIndex_SelectedIndexChanged);
            // 
            // dpStopActView
            // 
            this.dpStopActView.AllowDrop = true;
            this.dpStopActView.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpStopActView.Controls.Add(this.gbxStpActView);
            this.dpStopActView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpStopActView.Location = new System.Drawing.Point(10, 99);
            this.dpStopActView.Name = "dividerPanel3";
            this.dpStopActView.Size = new System.Drawing.Size(299, 331);
            this.dpStopActView.TabIndex = 4;
            // 
            // dpActaion
            // 
            this.dpActaion.AllowDrop = true;
            this.dpActaion.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpActaion.Controls.Add(this.lblActionText);
            this.dpActaion.Controls.Add(this.label1);
            this.dpActaion.Controls.Add(this.btnActCancel);
            this.dpActaion.Controls.Add(this.btnUnStpAct);
            this.dpActaion.Controls.Add(this.TxtContent);
            this.dpActaion.Controls.Add(this.LblContent);
            this.dpActaion.Controls.Add(this.TxtAccount);
            this.dpActaion.Controls.Add(this.LblNick);
            this.dpActaion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpActaion.Location = new System.Drawing.Point(309, 99);
            this.dpActaion.Name = "dividerPanel4";
            this.dpActaion.Size = new System.Drawing.Size(300, 331);
            this.dpActaion.TabIndex = 5;
            // 
            // lblActionText
            // 
            this.lblActionText.AutoSize = true;
            this.lblActionText.ForeColor = System.Drawing.Color.DarkRed;
            this.lblActionText.Location = new System.Drawing.Point(13, 0);
            this.lblActionText.Name = "lblActionText";
            this.lblActionText.Size = new System.Drawing.Size(275, 48);
            this.lblActionText.TabIndex = 15;
            this.lblActionText.Text = "停封帐号\r\n---------------------------------------------\r\n请在下方输入玩家帐号及停封原因\r\n-----------" +
                "----------------------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 14;
            // 
            // btnActCancel
            // 
            this.btnActCancel.Location = new System.Drawing.Point(96, 237);
            this.btnActCancel.Name = "btnActCancel";
            this.btnActCancel.Size = new System.Drawing.Size(75, 23);
            this.btnActCancel.TabIndex = 13;
            this.btnActCancel.Text = "取消";
            this.btnActCancel.UseVisualStyleBackColor = true;
            this.btnActCancel.Click += new System.EventHandler(this.btnActCancel_Click);
            // 
            // btnUnStpAct
            // 
            this.btnUnStpAct.Location = new System.Drawing.Point(15, 237);
            this.btnUnStpAct.Name = "btnUnStpAct";
            this.btnUnStpAct.Size = new System.Drawing.Size(75, 23);
            this.btnUnStpAct.TabIndex = 12;
            this.btnUnStpAct.Text = "解封/封停帐号";
            this.btnUnStpAct.UseVisualStyleBackColor = true;
            this.btnUnStpAct.Click += new System.EventHandler(this.btnUnStpAct_Click);
            // 
            // TxtContent
            // 
            this.TxtContent.Location = new System.Drawing.Point(15, 117);
            this.TxtContent.Multiline = true;
            this.TxtContent.Name = "TxtContent";
            this.TxtContent.Size = new System.Drawing.Size(269, 114);
            this.TxtContent.TabIndex = 11;
            // 
            // LblContent
            // 
            this.LblContent.AutoSize = true;
            this.LblContent.Location = new System.Drawing.Point(13, 102);
            this.LblContent.Name = "LblContent";
            this.LblContent.Size = new System.Drawing.Size(65, 12);
            this.LblContent.TabIndex = 10;
            this.LblContent.Text = "停封原因：";
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(15, 74);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(269, 21);
            this.TxtAccount.TabIndex = 9;
            // 
            // LblNick
            // 
            this.LblNick.AutoSize = true;
            this.LblNick.Location = new System.Drawing.Point(13, 59);
            this.LblNick.Name = "LblNick";
            this.LblNick.Size = new System.Drawing.Size(65, 12);
            this.LblNick.TabIndex = 8;
            this.LblNick.Text = "玩家帐号：";
            // 
            // StopAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 440);
            this.Controls.Add(this.dpActaion);
            this.Controls.Add(this.dpStopActView);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "StopAccount";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "解/停封玩家帐号";
            this.Load += new System.EventHandler(this.StopAccount_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbxStpActView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStpActView)).EndInit();
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel2.ResumeLayout(false);
            this.dpStopActView.ResumeLayout(false);
            this.dpActaion.ResumeLayout(false);
            this.dpActaion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.GroupBox gbxStpActView;
        private System.Windows.Forms.DataGridView dgStpActView;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dpStopActView;
        private DividerPanel.DividerPanel dpActaion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtContent;
        private System.Windows.Forms.Label LblContent;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblNick;
        private System.Windows.Forms.Button btnActCancel;
        private System.Windows.Forms.Button btnUnStpAct;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActionText;
        private System.Windows.Forms.ComboBox cbxToPageIndex;
        private System.Windows.Forms.Button button2;
    }
}