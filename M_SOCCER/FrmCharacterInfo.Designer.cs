namespace M_SOCCER
{
    partial class FrmCharacterInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dpDGAccountInfo = new DividerPanel.DividerPanel();
            this.dpNoteText = new DividerPanel.DividerPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgAccountInfo = new System.Windows.Forms.DataGridView();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNick = new System.Windows.Forms.CheckBox();
            this.chkAllPlayer = new System.Windows.Forms.CheckBox();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.lblIDOrNick = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpModi = new DividerPanel.DividerPanel();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtexp = new System.Windows.Forms.TextBox();
            this.lblexp = new System.Windows.Forms.Label();
            this.txtlevel = new System.Windows.Forms.TextBox();
            this.lbllevel = new System.Windows.Forms.Label();
            this.txtPlayerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCharname = new System.Windows.Forms.TextBox();
            this.btnModiCancel = new System.Windows.Forms.Button();
            this.btnModiApply = new System.Windows.Forms.Button();
            this.txtG = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBtnOK = new System.ComponentModel.BackgroundWorker();
            this.dpDGAccountInfo.SuspendLayout();
            this.dpNoteText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).BeginInit();
            this.dividerPanel2.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dpModi.SuspendLayout();
            this.SuspendLayout();
            // 
            // dpDGAccountInfo
            // 
            this.dpDGAccountInfo.AllowDrop = true;
            this.dpDGAccountInfo.Controls.Add(this.dpNoteText);
            this.dpDGAccountInfo.Controls.Add(this.dgAccountInfo);
            this.dpDGAccountInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpDGAccountInfo.Location = new System.Drawing.Point(0, 115);
            this.dpDGAccountInfo.Name = "dividerPanel3";
            this.dpDGAccountInfo.Size = new System.Drawing.Size(729, 267);
            this.dpDGAccountInfo.TabIndex = 5;
            // 
            // dpNoteText
            // 
            this.dpNoteText.AllowDrop = true;
            this.dpNoteText.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpNoteText.Controls.Add(this.label8);
            this.dpNoteText.Controls.Add(this.label7);
            this.dpNoteText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dpNoteText.Location = new System.Drawing.Point(0, 221);
            this.dpNoteText.Name = "dividerPanel4";
            this.dpNoteText.Size = new System.Drawing.Size(729, 46);
            this.dpNoteText.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-1, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(245, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "请先在上方选择玩家角色后修改玩家相关信息";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(0, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "提醒：";
            // 
            // dgAccountInfo
            // 
            this.dgAccountInfo.AllowUserToAddRows = false;
            this.dgAccountInfo.AllowUserToDeleteRows = false;
            this.dgAccountInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccountInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgAccountInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAccountInfo.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAccountInfo.Location = new System.Drawing.Point(0, 0);
            this.dgAccountInfo.MultiSelect = false;
            this.dgAccountInfo.Name = "dgAccountInfo";
            this.dgAccountInfo.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccountInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgAccountInfo.RowTemplate.Height = 23;
            this.dgAccountInfo.Size = new System.Drawing.Size(729, 267);
            this.dgAccountInfo.TabIndex = 0;
            this.dgAccountInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAccountInfo_CellClick);
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Controls.Add(this.lblPageSize);
            this.dividerPanel2.Controls.Add(this.lblPageCount);
            this.dividerPanel2.Controls.Add(this.comboBox3);
            this.dividerPanel2.Controls.Add(this.label6);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(0, 105);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dividerPanel2.Size = new System.Drawing.Size(729, 10);
            this.dividerPanel2.TabIndex = 4;
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.ForeColor = System.Drawing.Color.Blue;
            this.lblPageSize.Location = new System.Drawing.Point(89, 14);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(17, 12);
            this.lblPageSize.TabIndex = 3;
            this.lblPageSize.Text = "10";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Blue;
            this.lblPageCount.Location = new System.Drawing.Point(19, 14);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(11, 12);
            this.lblPageCount.TabIndex = 2;
            this.lblPageCount.Text = "1";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(186, 10);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(95, 20);
            this.comboBox3.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-1, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "共    页，每页    条      转到　　　　　　　　　页";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(729, 105);
            this.dividerPanel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNick);
            this.groupBox1.Controls.Add(this.chkAllPlayer);
            this.groupBox1.Controls.Add(this.chkAccount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Controls.Add(this.lblIDOrNick);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "玩家角色信息查询";
            // 
            // chkNick
            // 
            this.chkNick.AutoSize = true;
            this.chkNick.Location = new System.Drawing.Point(90, 78);
            this.chkNick.Name = "chkNick";
            this.chkNick.Size = new System.Drawing.Size(72, 16);
            this.chkNick.TabIndex = 10;
            this.chkNick.Text = "角色查询";
            this.chkNick.UseVisualStyleBackColor = true;
            this.chkNick.Click += new System.EventHandler(this.chkNick_Click);
            // 
            // chkAllPlayer
            // 
            this.chkAllPlayer.AutoSize = true;
            this.chkAllPlayer.Enabled = false;
            this.chkAllPlayer.Location = new System.Drawing.Point(168, 78);
            this.chkAllPlayer.Name = "chkAllPlayer";
            this.chkAllPlayer.Size = new System.Drawing.Size(72, 16);
            this.chkAllPlayer.TabIndex = 8;
            this.chkAllPlayer.Text = "所有玩家";
            this.chkAllPlayer.UseVisualStyleBackColor = true;
            this.chkAllPlayer.Visible = false;
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Checked = true;
            this.chkAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccount.Location = new System.Drawing.Point(18, 78);
            this.chkAccount.Name = "chkAccount";
            this.chkAccount.Size = new System.Drawing.Size(72, 16);
            this.chkAccount.TabIndex = 7;
            this.chkAccount.Text = "帐号查询";
            this.chkAccount.UseVisualStyleBackColor = true;
            this.chkAccount.Click += new System.EventHandler(this.chkAccount_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "查询方式：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(517, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(436, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(227, 34);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(164, 21);
            this.txtAccount.TabIndex = 3;
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(18, 35);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(166, 20);
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
            // dpModi
            // 
            this.dpModi.AllowDrop = true;
            this.dpModi.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dpModi.Controls.Add(this.cboPosition);
            this.dpModi.Controls.Add(this.lblPosition);
            this.dpModi.Controls.Add(this.txtexp);
            this.dpModi.Controls.Add(this.lblexp);
            this.dpModi.Controls.Add(this.txtlevel);
            this.dpModi.Controls.Add(this.lbllevel);
            this.dpModi.Controls.Add(this.txtPlayerID);
            this.dpModi.Controls.Add(this.label2);
            this.dpModi.Controls.Add(this.TxtCharname);
            this.dpModi.Controls.Add(this.btnModiCancel);
            this.dpModi.Controls.Add(this.btnModiApply);
            this.dpModi.Controls.Add(this.txtG);
            this.dpModi.Controls.Add(this.label9);
            this.dpModi.Controls.Add(this.label11);
            this.dpModi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpModi.Location = new System.Drawing.Point(0, 382);
            this.dpModi.Name = "dividerPanel5";
            this.dpModi.Size = new System.Drawing.Size(729, 131);
            this.dpModi.TabIndex = 6;
            // 
            // cboPosition
            // 
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Location = new System.Drawing.Point(431, 73);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(109, 20);
            this.cboPosition.TabIndex = 20;
            this.cboPosition.Visible = false;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(384, 75);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(41, 12);
            this.lblPosition.TabIndex = 19;
            this.lblPosition.Text = "位置：";
            this.lblPosition.Visible = false;
            // 
            // txtexp
            // 
            this.txtexp.Location = new System.Drawing.Point(217, 72);
            this.txtexp.Name = "txtexp";
            this.txtexp.Size = new System.Drawing.Size(109, 21);
            this.txtexp.TabIndex = 18;
            this.txtexp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtexp_KeyUp);
            this.txtexp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtexp_MouseUp);
            // 
            // lblexp
            // 
            this.lblexp.AutoSize = true;
            this.lblexp.Location = new System.Drawing.Point(170, 75);
            this.lblexp.Name = "lblexp";
            this.lblexp.Size = new System.Drawing.Size(41, 12);
            this.lblexp.TabIndex = 17;
            this.lblexp.Text = "经验：";
            // 
            // txtlevel
            // 
            this.txtlevel.Location = new System.Drawing.Point(431, 45);
            this.txtlevel.Name = "txtlevel";
            this.txtlevel.Size = new System.Drawing.Size(109, 21);
            this.txtlevel.TabIndex = 16;
            this.txtlevel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtlevel_KeyUp);
            this.txtlevel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtlevel_MouseUp);
            // 
            // lbllevel
            // 
            this.lbllevel.AutoSize = true;
            this.lbllevel.Location = new System.Drawing.Point(384, 47);
            this.lbllevel.Name = "lbllevel";
            this.lbllevel.Size = new System.Drawing.Size(41, 12);
            this.lbllevel.TabIndex = 15;
            this.lbllevel.Text = "级别：";
            // 
            // txtPlayerID
            // 
            this.txtPlayerID.Location = new System.Drawing.Point(217, 15);
            this.txtPlayerID.Name = "txtPlayerID";
            this.txtPlayerID.ReadOnly = true;
            this.txtPlayerID.Size = new System.Drawing.Size(109, 21);
            this.txtPlayerID.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "人物名称：";
            // 
            // TxtCharname
            // 
            this.TxtCharname.Location = new System.Drawing.Point(431, 15);
            this.TxtCharname.Name = "TxtCharname";
            this.TxtCharname.Size = new System.Drawing.Size(109, 21);
            this.TxtCharname.TabIndex = 12;
            // 
            // btnModiCancel
            // 
            this.btnModiCancel.Location = new System.Drawing.Point(431, 105);
            this.btnModiCancel.Name = "btnModiCancel";
            this.btnModiCancel.Size = new System.Drawing.Size(109, 23);
            this.btnModiCancel.TabIndex = 11;
            this.btnModiCancel.Text = "取消";
            this.btnModiCancel.UseVisualStyleBackColor = true;
            this.btnModiCancel.Click += new System.EventHandler(this.btnModiCancel_Click);
            // 
            // btnModiApply
            // 
            this.btnModiApply.Location = new System.Drawing.Point(217, 105);
            this.btnModiApply.Name = "btnModiApply";
            this.btnModiApply.Size = new System.Drawing.Size(109, 23);
            this.btnModiApply.TabIndex = 9;
            this.btnModiApply.Text = "确认";
            this.btnModiApply.UseVisualStyleBackColor = true;
            this.btnModiApply.Click += new System.EventHandler(this.btnModiApply_Click);
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(217, 45);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(109, 21);
            this.txtG.TabIndex = 8;
            this.txtG.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtG_KeyUp);
            this.txtG.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtG_MouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(170, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "G 币：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(146, 20);
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
            // backgroundWorkerBtnOK
            // 
            this.backgroundWorkerBtnOK.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBtnOK_DoWork);
            this.backgroundWorkerBtnOK.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBtnOK_RunWorkerCompleted);
            // 
            // FrmCharacterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 513);
            this.Controls.Add(this.dpModi);
            this.Controls.Add(this.dpDGAccountInfo);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "FrmCharacterInfo";
            this.Text = "玩家角色信息查询[劲爆足球]";
            this.Load += new System.EventHandler(this.FrmCharacterInfo_Load);
            this.dpDGAccountInfo.ResumeLayout(false);
            this.dpNoteText.ResumeLayout(false);
            this.dpNoteText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).EndInit();
            this.dividerPanel2.ResumeLayout(false);
            this.dividerPanel2.PerformLayout();
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dpModi.ResumeLayout(false);
            this.dpModi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dpDGAccountInfo;
        private System.Windows.Forms.DataGridView dgAccountInfo;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkNick;
        private System.Windows.Forms.CheckBox chkAllPlayer;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Label lblIDOrNick;
        private System.Windows.Forms.Label label1;
        private DividerPanel.DividerPanel dpNoteText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private DividerPanel.DividerPanel dpModi;
        private System.Windows.Forms.TextBox TxtCharname;
        private System.Windows.Forms.Button btnModiCancel;
        private System.Windows.Forms.Button btnModiApply;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlayerID;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBtnOK;
        private System.Windows.Forms.TextBox txtexp;
        private System.Windows.Forms.Label lblexp;
        private System.Windows.Forms.TextBox txtlevel;
        private System.Windows.Forms.Label lbllevel;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cboPosition;
    }
}

