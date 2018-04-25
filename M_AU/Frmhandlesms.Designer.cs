namespace M_Audition
{
    partial class Frmhandlesms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.lblIDOrNick = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dgAccountInfo = new System.Windows.Forms.DataGridView();
            this.dpDGAccountInfo = new DividerPanel.DividerPanel();
            this.DivPage = new DividerPanel.DividerPanel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.dpModi = new DividerPanel.DividerPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlayerID = new System.Windows.Forms.TextBox();
            this.btnModiCancel = new System.Windows.Forms.Button();
            this.btnModiApply = new System.Windows.Forms.Button();
            this.lblcellphone = new System.Windows.Forms.Label();
            this.backgroundWorkerSerch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerAdd = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).BeginInit();
            this.dpDGAccountInfo.SuspendLayout();
            this.DivPage.SuspendLayout();
            this.dpModi.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Controls.Add(this.lblIDOrNick);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "玩家角色信息查询";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "查询类别:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(589, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(508, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(215, 35);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(183, 21);
            this.txtAccount.TabIndex = 3;
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Items.AddRange(new object[] {
            "激活查询",
            "休闲查询",
            "双倍查询"});
            this.cbxServerIP.Location = new System.Drawing.Point(18, 35);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(183, 20);
            this.cbxServerIP.TabIndex = 2;
            this.cbxServerIP.SelectedIndexChanged += new System.EventHandler(this.cbxServerIP_SelectedIndexChanged);
            // 
            // lblIDOrNick
            // 
            this.lblIDOrNick.AutoSize = true;
            this.lblIDOrNick.Location = new System.Drawing.Point(213, 20);
            this.lblIDOrNick.Name = "lblIDOrNick";
            this.lblIDOrNick.Size = new System.Drawing.Size(47, 12);
            this.lblIDOrNick.TabIndex = 1;
            this.lblIDOrNick.Text = "手机号:";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(861, 105);
            this.dividerPanel1.TabIndex = 4;
            // 
            // dgAccountInfo
            // 
            this.dgAccountInfo.AllowUserToAddRows = false;
            this.dgAccountInfo.AllowUserToDeleteRows = false;
            this.dgAccountInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccountInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAccountInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAccountInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAccountInfo.Location = new System.Drawing.Point(0, 30);
            this.dgAccountInfo.MultiSelect = false;
            this.dgAccountInfo.Name = "dgAccountInfo";
            this.dgAccountInfo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccountInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgAccountInfo.RowTemplate.Height = 23;
            this.dgAccountInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAccountInfo.Size = new System.Drawing.Size(861, 268);
            this.dgAccountInfo.TabIndex = 0;
            this.dgAccountInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAccountInfo_CellClick);
            // 
            // dpDGAccountInfo
            // 
            this.dpDGAccountInfo.AllowDrop = true;
            this.dpDGAccountInfo.Controls.Add(this.dgAccountInfo);
            this.dpDGAccountInfo.Controls.Add(this.DivPage);
            this.dpDGAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpDGAccountInfo.Location = new System.Drawing.Point(0, 105);
            this.dpDGAccountInfo.Name = "dividerPanel3";
            this.dpDGAccountInfo.Size = new System.Drawing.Size(861, 298);
            this.dpDGAccountInfo.TabIndex = 6;
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
            this.DivPage.Size = new System.Drawing.Size(861, 30);
            this.DivPage.TabIndex = 15;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(622, 9);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(95, 12);
            this.LblPage.TabIndex = 3;
            this.LblPage.Text = "请选择查看页数:";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(733, 5);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(107, 20);
            this.CmbPage.TabIndex = 2;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
            // 
            // dpModi
            // 
            this.dpModi.AllowDrop = true;
            this.dpModi.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dpModi.Controls.Add(this.textBox1);
            this.dpModi.Controls.Add(this.label1);
            this.dpModi.Controls.Add(this.txtPlayerID);
            this.dpModi.Controls.Add(this.btnModiCancel);
            this.dpModi.Controls.Add(this.btnModiApply);
            this.dpModi.Controls.Add(this.lblcellphone);
            this.dpModi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dpModi.Location = new System.Drawing.Point(0, 403);
            this.dpModi.Name = "dividerPanel5";
            this.dpModi.Size = new System.Drawing.Size(861, 179);
            this.dpModi.TabIndex = 7;
            this.dpModi.Paint += new System.Windows.Forms.PaintEventHandler(this.dpModi_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(351, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(109, 21);
            this.textBox1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "用户名:";
            // 
            // txtPlayerID
            // 
            this.txtPlayerID.Location = new System.Drawing.Point(351, 38);
            this.txtPlayerID.Name = "txtPlayerID";
            this.txtPlayerID.ReadOnly = true;
            this.txtPlayerID.Size = new System.Drawing.Size(109, 21);
            this.txtPlayerID.TabIndex = 14;
            // 
            // btnModiCancel
            // 
            this.btnModiCancel.Location = new System.Drawing.Point(391, 110);
            this.btnModiCancel.Name = "btnModiCancel";
            this.btnModiCancel.Size = new System.Drawing.Size(67, 23);
            this.btnModiCancel.TabIndex = 11;
            this.btnModiCancel.Text = "取消";
            this.btnModiCancel.UseVisualStyleBackColor = true;
            this.btnModiCancel.Click += new System.EventHandler(this.btnModiCancel_Click);
            // 
            // btnModiApply
            // 
            this.btnModiApply.Location = new System.Drawing.Point(300, 110);
            this.btnModiApply.Name = "btnModiApply";
            this.btnModiApply.Size = new System.Drawing.Size(67, 23);
            this.btnModiApply.TabIndex = 9;
            this.btnModiApply.Text = "修改";
            this.btnModiApply.UseVisualStyleBackColor = true;
            this.btnModiApply.Click += new System.EventHandler(this.btnModiApply_Click);
            // 
            // lblcellphone
            // 
            this.lblcellphone.AutoSize = true;
            this.lblcellphone.Location = new System.Drawing.Point(298, 41);
            this.lblcellphone.Name = "lblcellphone";
            this.lblcellphone.Size = new System.Drawing.Size(47, 12);
            this.lblcellphone.TabIndex = 0;
            this.lblcellphone.Text = "手机号:";
            // 
            // backgroundWorkerSerch
            // 
            this.backgroundWorkerSerch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSerch_DoWork);
            this.backgroundWorkerSerch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSerch_RunWorkerCompleted);
            // 
            // backgroundWorkerPageChanged
            // 
            this.backgroundWorkerPageChanged.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPageChanged_DoWork);
            this.backgroundWorkerPageChanged.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPageChanged_RunWorkerCompleted);
            // 
            // backgroundWorkerAdd
            // 
            this.backgroundWorkerAdd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAdd_DoWork);
            this.backgroundWorkerAdd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAdd_RunWorkerCompleted);
            // 
            // Frmhandlesms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 582);
            this.Controls.Add(this.dpDGAccountInfo);
            this.Controls.Add(this.dpModi);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "Frmhandlesms";
            this.Text = "Frmhandlesms";
            this.Load += new System.EventHandler(this.Frmhandlesms_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dividerPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).EndInit();
            this.dpDGAccountInfo.ResumeLayout(false);
            this.DivPage.ResumeLayout(false);
            this.DivPage.PerformLayout();
            this.dpModi.ResumeLayout(false);
            this.dpModi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Label lblIDOrNick;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.DataGridView dgAccountInfo;
        private DividerPanel.DividerPanel dpDGAccountInfo;
        private DividerPanel.DividerPanel dpModi;
        private System.Windows.Forms.TextBox txtPlayerID;
        private System.Windows.Forms.Button btnModiCancel;
        private System.Windows.Forms.Button btnModiApply;
        private System.Windows.Forms.Label lblcellphone;
        private DividerPanel.DividerPanel DivPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSerch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAdd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;

    }
}