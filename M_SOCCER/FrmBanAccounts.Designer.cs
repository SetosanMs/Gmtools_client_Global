namespace M_SOCCER
{
    partial class FrmBanAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.lblIDOrNick = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DivPage = new DividerPanel.DividerPanel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.dpDGAccountInfo = new DividerPanel.DividerPanel();
            this.dgAccountInfo = new System.Windows.Forms.DataGridView();
            this.dpNoteText = new DividerPanel.DividerPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpModi = new DividerPanel.DividerPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.LblReason = new System.Windows.Forms.Label();
            this.btnUnbanAccount = new System.Windows.Forms.Button();
            this.btnbanAccount = new System.Windows.Forms.Button();
            this.txtPlayerID = new System.Windows.Forms.TextBox();
            this.btnModiCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUnban = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBan = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.DivPage.SuspendLayout();
            this.dpDGAccountInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).BeginInit();
            this.dpNoteText.SuspendLayout();
            this.dpModi.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(739, 78);
            this.dividerPanel1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Controls.Add(this.lblIDOrNick);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(559, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(436, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "帐号查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(227, 34);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(182, 21);
            this.txtAccount.TabIndex = 3;
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(18, 35);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(182, 20);
            this.cbxServerIP.TabIndex = 2;
            this.cbxServerIP.SelectedIndexChanged += new System.EventHandler(this.cbxServerIP_SelectedIndexChanged);
            // 
            // lblIDOrNick
            // 
            this.lblIDOrNick.AutoSize = true;
            this.lblIDOrNick.Location = new System.Drawing.Point(225, 20);
            this.lblIDOrNick.Name = "lblIDOrNick";
            this.lblIDOrNick.Size = new System.Drawing.Size(65, 12);
            this.lblIDOrNick.TabIndex = 1;
            this.lblIDOrNick.Text = "玩家帐号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器：";
            // 
            // DivPage
            // 
            this.DivPage.AllowDrop = true;
            this.DivPage.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.DivPage.Controls.Add(this.LblPage);
            this.DivPage.Controls.Add(this.CmbPage);
            this.DivPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.DivPage.Location = new System.Drawing.Point(0, 0);
            this.DivPage.Name = "dividerPanel4";
            this.DivPage.Size = new System.Drawing.Size(739, 29);
            this.DivPage.TabIndex = 14;
            this.DivPage.Visible = false;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(485, 6);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 3;
            this.LblPage.Text = "请选择查看页数：";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(592, 3);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(121, 20);
            this.CmbPage.TabIndex = 2;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
            // 
            // dpDGAccountInfo
            // 
            this.dpDGAccountInfo.AllowDrop = true;
            this.dpDGAccountInfo.Controls.Add(this.dgAccountInfo);
            this.dpDGAccountInfo.Controls.Add(this.dpNoteText);
            this.dpDGAccountInfo.Controls.Add(this.DivPage);
            this.dpDGAccountInfo.Location = new System.Drawing.Point(2, 84);
            this.dpDGAccountInfo.Name = "dividerPanel3";
            this.dpDGAccountInfo.Size = new System.Drawing.Size(739, 214);
            this.dpDGAccountInfo.TabIndex = 17;
            // 
            // dgAccountInfo
            // 
            this.dgAccountInfo.AllowUserToAddRows = false;
            this.dgAccountInfo.AllowUserToDeleteRows = false;
            this.dgAccountInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccountInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgAccountInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAccountInfo.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAccountInfo.Location = new System.Drawing.Point(0, 0);
            this.dgAccountInfo.MultiSelect = false;
            this.dgAccountInfo.Name = "dgAccountInfo";
            this.dgAccountInfo.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccountInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgAccountInfo.RowTemplate.Height = 23;
            this.dgAccountInfo.Size = new System.Drawing.Size(739, 168);
            this.dgAccountInfo.TabIndex = 17;
            this.dgAccountInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAccountInfo_CellClick_1);
            // 
            // dpNoteText
            // 
            this.dpNoteText.AllowDrop = true;
            this.dpNoteText.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpNoteText.Controls.Add(this.label2);
            this.dpNoteText.Controls.Add(this.label3);
            this.dpNoteText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dpNoteText.Location = new System.Drawing.Point(0, 168);
            this.dpNoteText.Name = "dividerPanel4";
            this.dpNoteText.Size = new System.Drawing.Size(739, 46);
            this.dpNoteText.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "请选择玩家角色后修改玩家相关信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(0, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "提醒：";
            // 
            // dpModi
            // 
            this.dpModi.AllowDrop = true;
            this.dpModi.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dpModi.Controls.Add(this.richTextBox1);
            this.dpModi.Controls.Add(this.LblReason);
            this.dpModi.Controls.Add(this.btnUnbanAccount);
            this.dpModi.Controls.Add(this.btnbanAccount);
            this.dpModi.Controls.Add(this.txtPlayerID);
            this.dpModi.Controls.Add(this.btnModiCancel);
            this.dpModi.Controls.Add(this.label11);
            this.dpModi.Location = new System.Drawing.Point(2, 313);
            this.dpModi.Name = "dividerPanel5";
            this.dpModi.Size = new System.Drawing.Size(739, 159);
            this.dpModi.TabIndex = 18;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(413, 15);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(245, 62);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "";
            // 
            // LblReason
            // 
            this.LblReason.AutoSize = true;
            this.LblReason.Location = new System.Drawing.Point(332, 18);
            this.LblReason.Name = "LblReason";
            this.LblReason.Size = new System.Drawing.Size(65, 12);
            this.LblReason.TabIndex = 18;
            this.LblReason.Text = "封停原因：";
            // 
            // btnUnbanAccount
            // 
            this.btnUnbanAccount.Location = new System.Drawing.Point(121, 99);
            this.btnUnbanAccount.Name = "btnUnbanAccount";
            this.btnUnbanAccount.Size = new System.Drawing.Size(94, 21);
            this.btnUnbanAccount.TabIndex = 17;
            this.btnUnbanAccount.Text = "确认解封";
            this.btnUnbanAccount.UseVisualStyleBackColor = true;
            this.btnUnbanAccount.Visible = false;
            this.btnUnbanAccount.Click += new System.EventHandler(this.btnUnbanAccount_Click);
            // 
            // btnbanAccount
            // 
            this.btnbanAccount.Location = new System.Drawing.Point(121, 99);
            this.btnbanAccount.Name = "btnbanAccount";
            this.btnbanAccount.Size = new System.Drawing.Size(94, 21);
            this.btnbanAccount.TabIndex = 16;
            this.btnbanAccount.Text = "确认停封";
            this.btnbanAccount.UseVisualStyleBackColor = true;
            this.btnbanAccount.Click += new System.EventHandler(this.btnbanAccount_Click);
            // 
            // txtPlayerID
            // 
            this.txtPlayerID.Location = new System.Drawing.Point(121, 16);
            this.txtPlayerID.Name = "txtPlayerID";
            this.txtPlayerID.ReadOnly = true;
            this.txtPlayerID.Size = new System.Drawing.Size(137, 21);
            this.txtPlayerID.TabIndex = 14;
            // 
            // btnModiCancel
            // 
            this.btnModiCancel.Location = new System.Drawing.Point(413, 99);
            this.btnModiCancel.Name = "btnModiCancel";
            this.btnModiCancel.Size = new System.Drawing.Size(94, 21);
            this.btnModiCancel.TabIndex = 11;
            this.btnModiCancel.Text = "取消";
            this.btnModiCancel.UseVisualStyleBackColor = true;
            this.btnModiCancel.Click += new System.EventHandler(this.btnModiCancel_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "玩家帐号：";
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // backgroundWorkerUnban
            // 
            this.backgroundWorkerUnban.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUnban_DoWork);
            this.backgroundWorkerUnban.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUnban_RunWorkerCompleted);
            // 
            // backgroundWorkerBan
            // 
            this.backgroundWorkerBan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBan_DoWork);
            this.backgroundWorkerBan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBan_RunWorkerCompleted);
            // 
            // FrmBanAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 469);
            this.Controls.Add(this.dpModi);
            this.Controls.Add(this.dpDGAccountInfo);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "FrmBanAccounts";
            this.Text = "解封/封停帐号[劲爆足球]";
            this.Load += new System.EventHandler(this.FrmBanCharacters_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DivPage.ResumeLayout(false);
            this.DivPage.PerformLayout();
            this.dpDGAccountInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).EndInit();
            this.dpNoteText.ResumeLayout(false);
            this.dpNoteText.PerformLayout();
            this.dpModi.ResumeLayout(false);
            this.dpModi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Label lblIDOrNick;
        private System.Windows.Forms.Label label1;
        private DividerPanel.DividerPanel DivPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private DividerPanel.DividerPanel dpDGAccountInfo;
        private DividerPanel.DividerPanel dpModi;
        private System.Windows.Forms.TextBox txtPlayerID;
        private System.Windows.Forms.Button btnModiCancel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnUnbanAccount;
        private System.Windows.Forms.Button btnbanAccount;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUnban;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBan;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label LblReason;
        private System.Windows.Forms.DataGridView dgAccountInfo;
        private DividerPanel.DividerPanel dpNoteText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}