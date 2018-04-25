namespace M_SOCCER
{
    partial class FrmRecoveCharacter
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
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnbanQuary = new System.Windows.Forms.Button();
            this.chkNick = new System.Windows.Forms.CheckBox();
            this.chkAccount = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.lblIDOrNick = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpDGAccountInfo = new DividerPanel.DividerPanel();
            this.dgAccountInfo = new System.Windows.Forms.DataGridView();
            this.dpNoteText = new DividerPanel.DividerPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DivPage = new DividerPanel.DividerPanel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.dpModi = new DividerPanel.DividerPanel();
            this.btnOnlyChar = new System.Windows.Forms.Button();
            this.btnDelCharter = new System.Windows.Forms.Button();
            this.btnSocketcheck = new System.Windows.Forms.Button();
            this.btnRecoveCharacter = new System.Windows.Forms.Button();
            this.btnNameCheck = new System.Windows.Forms.Button();
            this.txtPlayerID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCharname = new System.Windows.Forms.TextBox();
            this.btnModiCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDel = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRecovery = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCheckNum = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCheckName = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dpDGAccountInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).BeginInit();
            this.dpNoteText.SuspendLayout();
            this.DivPage.SuspendLayout();
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
            this.dividerPanel1.Size = new System.Drawing.Size(770, 105);
            this.dividerPanel1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnbanQuary);
            this.groupBox1.Controls.Add(this.chkNick);
            this.groupBox1.Controls.Add(this.chkAccount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Controls.Add(this.lblIDOrNick);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(225, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "提醒:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "不选择查询类型则默认为查询所有玩家角色信息";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(263, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(407, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "玩家角色状态为\"OnUse\"时可删除角色　状态为\"Wait\"或\"Delete\"可恢复角色";
            // 
            // btnbanQuary
            // 
            this.btnbanQuary.Location = new System.Drawing.Point(448, 35);
            this.btnbanQuary.Name = "btnbanQuary";
            this.btnbanQuary.Size = new System.Drawing.Size(99, 23);
            this.btnbanQuary.TabIndex = 14;
            this.btnbanQuary.Text = "查询";
            this.btnbanQuary.UseVisualStyleBackColor = true;
            this.btnbanQuary.Click += new System.EventHandler(this.btnbanQuary_Click);
            // 
            // chkNick
            // 
            this.chkNick.AutoSize = true;
            this.chkNick.Location = new System.Drawing.Point(90, 73);
            this.chkNick.Name = "chkNick";
            this.chkNick.Size = new System.Drawing.Size(72, 16);
            this.chkNick.TabIndex = 12;
            this.chkNick.Text = "角色查询";
            this.chkNick.UseVisualStyleBackColor = true;
            this.chkNick.Click += new System.EventHandler(this.chkNick_Click);
            // 
            // chkAccount
            // 
            this.chkAccount.AutoSize = true;
            this.chkAccount.Checked = true;
            this.chkAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccount.Location = new System.Drawing.Point(18, 73);
            this.chkAccount.Name = "chkAccount";
            this.chkAccount.Size = new System.Drawing.Size(72, 16);
            this.chkAccount.TabIndex = 11;
            this.chkAccount.Text = "帐号查询";
            this.chkAccount.UseVisualStyleBackColor = true;
            this.chkAccount.Click += new System.EventHandler(this.chkAccount_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "查询方式：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(569, 35);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // dpDGAccountInfo
            // 
            this.dpDGAccountInfo.AllowDrop = true;
            this.dpDGAccountInfo.Controls.Add(this.dgAccountInfo);
            this.dpDGAccountInfo.Controls.Add(this.dpNoteText);
            this.dpDGAccountInfo.Controls.Add(this.DivPage);
            this.dpDGAccountInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpDGAccountInfo.Location = new System.Drawing.Point(0, 105);
            this.dpDGAccountInfo.Name = "dividerPanel3";
            this.dpDGAccountInfo.Size = new System.Drawing.Size(770, 334);
            this.dpDGAccountInfo.TabIndex = 18;
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
            this.dgAccountInfo.Size = new System.Drawing.Size(770, 264);
            this.dgAccountInfo.TabIndex = 15;
            this.dgAccountInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAccountInfo_CellClick);
            // 
            // dpNoteText
            // 
            this.dpNoteText.AllowDrop = true;
            this.dpNoteText.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpNoteText.Controls.Add(this.label2);
            this.dpNoteText.Controls.Add(this.label3);
            this.dpNoteText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dpNoteText.Location = new System.Drawing.Point(0, 294);
            this.dpNoteText.Name = "dividerPanel4";
            this.dpNoteText.Size = new System.Drawing.Size(770, 40);
            this.dpNoteText.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "请先在上方选择玩家角色后修改玩家相关信息";
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
            // DivPage
            // 
            this.DivPage.AllowDrop = true;
            this.DivPage.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.DivPage.Controls.Add(this.LblPage);
            this.DivPage.Controls.Add(this.CmbPage);
            this.DivPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.DivPage.Location = new System.Drawing.Point(0, 0);
            this.DivPage.Name = "dividerPanel4";
            this.DivPage.Size = new System.Drawing.Size(770, 30);
            this.DivPage.TabIndex = 14;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(446, 6);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 3;
            this.LblPage.Text = "请选择查看页数：";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(569, 3);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(107, 20);
            this.CmbPage.TabIndex = 2;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
            // 
            // dpModi
            // 
            this.dpModi.AllowDrop = true;
            this.dpModi.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dpModi.Controls.Add(this.btnOnlyChar);
            this.dpModi.Controls.Add(this.btnDelCharter);
            this.dpModi.Controls.Add(this.btnSocketcheck);
            this.dpModi.Controls.Add(this.btnRecoveCharacter);
            this.dpModi.Controls.Add(this.btnNameCheck);
            this.dpModi.Controls.Add(this.txtPlayerID);
            this.dpModi.Controls.Add(this.label5);
            this.dpModi.Controls.Add(this.TxtCharname);
            this.dpModi.Controls.Add(this.btnModiCancel);
            this.dpModi.Controls.Add(this.label11);
            this.dpModi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dpModi.Location = new System.Drawing.Point(0, 357);
            this.dpModi.Name = "dividerPanel5";
            this.dpModi.Size = new System.Drawing.Size(770, 160);
            this.dpModi.TabIndex = 19;
            // 
            // btnOnlyChar
            // 
            this.btnOnlyChar.Location = new System.Drawing.Point(334, 126);
            this.btnOnlyChar.Name = "btnOnlyChar";
            this.btnOnlyChar.Size = new System.Drawing.Size(136, 21);
            this.btnOnlyChar.TabIndex = 20;
            this.btnOnlyChar.Text = "恢复玩家角色";
            this.btnOnlyChar.UseVisualStyleBackColor = true;
            this.btnOnlyChar.Click += new System.EventHandler(this.btnOnlyChar_Click);
            // 
            // btnDelCharter
            // 
            this.btnDelCharter.Location = new System.Drawing.Point(168, 126);
            this.btnDelCharter.Name = "btnDelCharter";
            this.btnDelCharter.Size = new System.Drawing.Size(136, 21);
            this.btnDelCharter.TabIndex = 19;
            this.btnDelCharter.Text = "删除角色";
            this.btnDelCharter.UseVisualStyleBackColor = true;
            this.btnDelCharter.Click += new System.EventHandler(this.btnDelCharter_Click);
            // 
            // btnSocketcheck
            // 
            this.btnSocketcheck.Location = new System.Drawing.Point(524, 50);
            this.btnSocketcheck.Name = "btnSocketcheck";
            this.btnSocketcheck.Size = new System.Drawing.Size(136, 21);
            this.btnSocketcheck.TabIndex = 18;
            this.btnSocketcheck.Text = "角色个数检查";
            this.btnSocketcheck.UseVisualStyleBackColor = true;
            this.btnSocketcheck.Click += new System.EventHandler(this.btnSocketcheck_Click);
            // 
            // btnRecoveCharacter
            // 
            this.btnRecoveCharacter.Location = new System.Drawing.Point(168, 126);
            this.btnRecoveCharacter.Name = "btnRecoveCharacter";
            this.btnRecoveCharacter.Size = new System.Drawing.Size(136, 21);
            this.btnRecoveCharacter.TabIndex = 17;
            this.btnRecoveCharacter.Text = "恢复角色及初使化道具";
            this.btnRecoveCharacter.UseVisualStyleBackColor = true;
            this.btnRecoveCharacter.Click += new System.EventHandler(this.btnRecoveCharacter_Click);
            // 
            // btnNameCheck
            // 
            this.btnNameCheck.Location = new System.Drawing.Point(524, 88);
            this.btnNameCheck.Name = "btnNameCheck";
            this.btnNameCheck.Size = new System.Drawing.Size(136, 21);
            this.btnNameCheck.TabIndex = 16;
            this.btnNameCheck.Text = "角色名检查";
            this.btnNameCheck.UseVisualStyleBackColor = true;
            this.btnNameCheck.Click += new System.EventHandler(this.btnNameCheck_Click);
            // 
            // txtPlayerID
            // 
            this.txtPlayerID.Location = new System.Drawing.Point(168, 47);
            this.txtPlayerID.Name = "txtPlayerID";
            this.txtPlayerID.ReadOnly = true;
            this.txtPlayerID.Size = new System.Drawing.Size(136, 21);
            this.txtPlayerID.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "人物名称：";
            // 
            // TxtCharname
            // 
            this.TxtCharname.Location = new System.Drawing.Point(168, 84);
            this.TxtCharname.Name = "TxtCharname";
            this.TxtCharname.ReadOnly = true;
            this.TxtCharname.Size = new System.Drawing.Size(136, 21);
            this.TxtCharname.TabIndex = 12;
            // 
            // btnModiCancel
            // 
            this.btnModiCancel.Location = new System.Drawing.Point(524, 126);
            this.btnModiCancel.Name = "btnModiCancel";
            this.btnModiCancel.Size = new System.Drawing.Size(136, 21);
            this.btnModiCancel.TabIndex = 11;
            this.btnModiCancel.Text = "取消";
            this.btnModiCancel.UseVisualStyleBackColor = true;
            this.btnModiCancel.Click += new System.EventHandler(this.btnModiCancel_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(88, 50);
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
            // backgroundWorkerPageChanged
            // 
            this.backgroundWorkerPageChanged.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPageChanged_DoWork);
            this.backgroundWorkerPageChanged.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPageChanged_RunWorkerCompleted);
            // 
            // backgroundWorkerDel
            // 
            this.backgroundWorkerDel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDel_DoWork);
            this.backgroundWorkerDel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDel_RunWorkerCompleted);
            // 
            // backgroundWorkerRecovery
            // 
            this.backgroundWorkerRecovery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRecovery_DoWork);
            this.backgroundWorkerRecovery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRecovery_RunWorkerCompleted);
            // 
            // backgroundWorkerCheckNum
            // 
            this.backgroundWorkerCheckNum.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCheckNum_DoWork);
            this.backgroundWorkerCheckNum.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCheckNum_RunWorkerCompleted);
            // 
            // backgroundWorkerCheckName
            // 
            this.backgroundWorkerCheckName.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCheckName_DoWork);
            this.backgroundWorkerCheckName.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCheckName_RunWorkerCompleted);
            // 
            // FrmRecoveCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 517);
            this.Controls.Add(this.dpModi);
            this.Controls.Add(this.dpDGAccountInfo);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "FrmRecoveCharacter";
            this.Text = "玩家角色恢复及道具初始化[劲爆足球]";
            this.Load += new System.EventHandler(this.FrmRecoveCharacter_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dpDGAccountInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).EndInit();
            this.dpNoteText.ResumeLayout(false);
            this.dpNoteText.PerformLayout();
            this.DivPage.ResumeLayout(false);
            this.DivPage.PerformLayout();
            this.dpModi.ResumeLayout(false);
            this.dpModi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkNick;
        private System.Windows.Forms.CheckBox chkAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.Label lblIDOrNick;
        private System.Windows.Forms.Label label1;
        private DividerPanel.DividerPanel dpDGAccountInfo;
        private System.Windows.Forms.DataGridView dgAccountInfo;
        private DividerPanel.DividerPanel dpNoteText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DividerPanel.DividerPanel DivPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private DividerPanel.DividerPanel dpModi;
        private System.Windows.Forms.Button btnRecoveCharacter;
        private System.Windows.Forms.Button btnNameCheck;
        private System.Windows.Forms.TextBox txtPlayerID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCharname;
        private System.Windows.Forms.Button btnModiCancel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnbanQuary;
        private System.Windows.Forms.Button btnSocketcheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDelCharter;
        private System.Windows.Forms.Button btnOnlyChar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRecovery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCheckNum;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCheckName;
    }
}