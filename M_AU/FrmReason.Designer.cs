namespace M_Audition
{
    partial class FrmReason
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TBCResult = new System.Windows.Forms.TabControl();
            this.TbgUser = new System.Windows.Forms.TabPage();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.groupReasonByUser = new System.Windows.Forms.GroupBox();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TbgCard = new System.Windows.Forms.TabPage();
            this.groupReasonByCard = new System.Windows.Forms.GroupBox();
            this.dgvCard = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioCard = new System.Windows.Forms.RadioButton();
            this.radioUser = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelCard = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.backgroundWorkerSearchByUser = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerByCard = new System.ComponentModel.BackgroundWorker();
            this.TBCResult.SuspendLayout();
            this.TbgUser.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.groupReasonByUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.GrpSearch.SuspendLayout();
            this.TbgCard.SuspendLayout();
            this.groupReasonByCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCard)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBCResult
            // 
            this.TBCResult.Controls.Add(this.TbgUser);
            this.TBCResult.Controls.Add(this.TbgCard);
            this.TBCResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBCResult.Location = new System.Drawing.Point(0, 0);
            this.TBCResult.Name = "TBCResult";
            this.TBCResult.SelectedIndex = 0;
            this.TBCResult.Size = new System.Drawing.Size(574, 398);
            this.TBCResult.TabIndex = 0;
            // 
            // TbgUser
            // 
            this.TbgUser.Controls.Add(this.dividerPanel2);
            this.TbgUser.Controls.Add(this.dividerPanel1);
            this.TbgUser.Controls.Add(this.GrpSearch);
            this.TbgUser.Location = new System.Drawing.Point(4, 21);
            this.TbgUser.Name = "TbgUser";
            this.TbgUser.Padding = new System.Windows.Forms.Padding(3);
            this.TbgUser.Size = new System.Drawing.Size(566, 373);
            this.TbgUser.TabIndex = 0;
            this.TbgUser.Text = "查询用户被封停原因";
            this.TbgUser.UseVisualStyleBackColor = true;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Controls.Add(this.groupReasonByUser);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel2.Location = new System.Drawing.Point(3, 122);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(560, 248);
            this.dividerPanel2.TabIndex = 6;
            // 
            // groupReasonByUser
            // 
            this.groupReasonByUser.Controls.Add(this.dgvUser);
            this.groupReasonByUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupReasonByUser.Location = new System.Drawing.Point(0, 0);
            this.groupReasonByUser.Name = "groupReasonByUser";
            this.groupReasonByUser.Size = new System.Drawing.Size(560, 248);
            this.groupReasonByUser.TabIndex = 1;
            this.groupReasonByUser.TabStop = false;
            this.groupReasonByUser.Text = "封停原因";
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(3, 17);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersWidth = 60;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.Size = new System.Drawing.Size(554, 228);
            this.dgvUser.TabIndex = 1;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(3, 112);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(560, 10);
            this.dividerPanel1.TabIndex = 5;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(3, 3);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(560, 109);
            this.GrpSearch.TabIndex = 4;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(8, 42);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(139, 21);
            this.TxtAccount.TabIndex = 6;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(6, 27);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(65, 12);
            this.LblAccount.TabIndex = 5;
            this.LblAccount.Text = "玩家帐号：";
            this.LblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(8, 80);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TbgCard
            // 
            this.TbgCard.Controls.Add(this.groupReasonByCard);
            this.TbgCard.Controls.Add(this.groupBox1);
            this.TbgCard.Location = new System.Drawing.Point(4, 21);
            this.TbgCard.Name = "TbgCard";
            this.TbgCard.Padding = new System.Windows.Forms.Padding(3);
            this.TbgCard.Size = new System.Drawing.Size(566, 373);
            this.TbgCard.TabIndex = 1;
            this.TbgCard.Text = "查询卡被封停原因";
            this.TbgCard.UseVisualStyleBackColor = true;
            // 
            // groupReasonByCard
            // 
            this.groupReasonByCard.Controls.Add(this.dgvCard);
            this.groupReasonByCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupReasonByCard.Location = new System.Drawing.Point(3, 112);
            this.groupReasonByCard.Name = "groupReasonByCard";
            this.groupReasonByCard.Size = new System.Drawing.Size(560, 258);
            this.groupReasonByCard.TabIndex = 6;
            this.groupReasonByCard.TabStop = false;
            this.groupReasonByCard.Text = "封停原因";
            // 
            // dgvCard
            // 
            this.dgvCard.AllowUserToAddRows = false;
            this.dgvCard.AllowUserToDeleteRows = false;
            this.dgvCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCard.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCard.Location = new System.Drawing.Point(3, 17);
            this.dgvCard.Name = "dgvCard";
            this.dgvCard.ReadOnly = true;
            this.dgvCard.RowHeadersWidth = 60;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCard.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCard.RowTemplate.Height = 23;
            this.dgvCard.Size = new System.Drawing.Size(554, 238);
            this.dgvCard.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioCard);
            this.groupBox1.Controls.Add(this.radioUser);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.labelCard);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 109);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索条件";
            // 
            // radioCard
            // 
            this.radioCard.AutoSize = true;
            this.radioCard.Location = new System.Drawing.Point(6, 69);
            this.radioCard.Name = "radioCard";
            this.radioCard.Size = new System.Drawing.Size(71, 16);
            this.radioCard.TabIndex = 15;
            this.radioCard.TabStop = true;
            this.radioCard.Text = "根据卡号";
            this.radioCard.UseVisualStyleBackColor = true;
            this.radioCard.CheckedChanged += new System.EventHandler(this.radioCard_CheckedChanged);
            // 
            // radioUser
            // 
            this.radioUser.AutoSize = true;
            this.radioUser.Location = new System.Drawing.Point(6, 30);
            this.radioUser.Name = "radioUser";
            this.radioUser.Size = new System.Drawing.Size(71, 16);
            this.radioUser.TabIndex = 14;
            this.radioUser.TabStop = true;
            this.radioUser.Text = "根据用户";
            this.radioUser.UseVisualStyleBackColor = true;
            this.radioUser.CheckedChanged += new System.EventHandler(this.radioUser_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(83, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(139, 21);
            this.textBox2.TabIndex = 13;
            // 
            // labelCard
            // 
            this.labelCard.AutoSize = true;
            this.labelCard.Location = new System.Drawing.Point(81, 54);
            this.labelCard.Name = "labelCard";
            this.labelCard.Size = new System.Drawing.Size(41, 12);
            this.labelCard.TabIndex = 12;
            this.labelCard.Text = "卡号：";
            this.labelCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 21);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "玩家帐号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(249, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "搜索";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // backgroundWorkerSearchByUser
            // 
            this.backgroundWorkerSearchByUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearchByUser_DoWork);
            this.backgroundWorkerSearchByUser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearchByUser_RunWorkerCompleted);
            // 
            // backgroundWorkerByCard
            // 
            this.backgroundWorkerByCard.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerByCard_DoWork);
            this.backgroundWorkerByCard.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerByCard_RunWorkerCompleted);
            // 
            // FrmReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 398);
            this.Controls.Add(this.TBCResult);
            this.Name = "FrmReason";
            this.Text = "封停原因";
            this.Load += new System.EventHandler(this.FrmReason_Load);
            this.TBCResult.ResumeLayout(false);
            this.TbgUser.ResumeLayout(false);
            this.dividerPanel2.ResumeLayout(false);
            this.groupReasonByUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.TbgCard.ResumeLayout(false);
            this.groupReasonByCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCard)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TBCResult;
        private System.Windows.Forms.TabPage TbgUser;
        private System.Windows.Forms.TabPage TbgCard;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.GroupBox groupReasonByUser;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.GroupBox groupReasonByCard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioCard;
        private System.Windows.Forms.RadioButton radioUser;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelCard;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearchByUser;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.DataGridView dgvCard;
        private System.ComponentModel.BackgroundWorker backgroundWorkerByCard;
    }
}