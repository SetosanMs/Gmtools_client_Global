namespace M_Audition
{
    partial class Frm_YOU_UserDetail
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
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.LblID = new System.Windows.Forms.Label();
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.tabControlResult = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.tabPageDetail = new System.Windows.Forms.TabPage();
            this.PnlResult = new System.Windows.Forms.Panel();
            this.richTextBoxDetail = new System.Windows.Forms.RichTextBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.buttonSaveAS = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonQA = new System.Windows.Forms.Button();
            this.buttonResetRegBox = new System.Windows.Forms.Button();
            this.buttonResetMailBox = new System.Windows.Forms.Button();
            this.buttonResetPhone = new System.Windows.Forms.Button();
            this.btnRestIDCode = new System.Windows.Forms.Button();
            this.buttonResetRealName = new System.Windows.Forms.Button();
            this.btnResetV = new System.Windows.Forms.Button();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.LblUser = new System.Windows.Forms.Label();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.richTextNotice = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.GrpResult.SuspendLayout();
            this.tabControlResult.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.tabPageDetail.SuspendLayout();
            this.PnlResult.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(153, 48);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查    找";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(26, 50);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(121, 21);
            this.TxtID.TabIndex = 3;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(24, 80);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(53, 12);
            this.LblID.TabIndex = 2;
            this.LblID.Text = "昵  称：";
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.tabControlResult);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(10, 184);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(914, 278);
            this.GrpResult.TabIndex = 17;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "查询结果";
            // 
            // tabControlResult
            // 
            this.tabControlResult.Controls.Add(this.tabPageBasic);
            this.tabControlResult.Controls.Add(this.tabPageDetail);
            this.tabControlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlResult.Location = new System.Drawing.Point(3, 17);
            this.tabControlResult.Name = "tabControlResult";
            this.tabControlResult.SelectedIndex = 0;
            this.tabControlResult.Size = new System.Drawing.Size(908, 258);
            this.tabControlResult.TabIndex = 0;
            this.tabControlResult.SelectedIndexChanged += new System.EventHandler(this.tabControlResult_SelectedIndexChanged);
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.dgvResult);
            this.tabPageBasic.Location = new System.Drawing.Point(4, 21);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasic.Size = new System.Drawing.Size(900, 233);
            this.tabPageBasic.TabIndex = 0;
            this.tabPageBasic.Text = "用户基本信息";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 3);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(894, 227);
            this.dgvResult.TabIndex = 0;
            // 
            // tabPageDetail
            // 
            this.tabPageDetail.Controls.Add(this.PnlResult);
            this.tabPageDetail.Location = new System.Drawing.Point(4, 21);
            this.tabPageDetail.Name = "tabPageDetail";
            this.tabPageDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetail.Size = new System.Drawing.Size(783, 226);
            this.tabPageDetail.TabIndex = 1;
            this.tabPageDetail.Text = "用户详细信息";
            this.tabPageDetail.UseVisualStyleBackColor = true;
            // 
            // PnlResult
            // 
            this.PnlResult.Controls.Add(this.richTextBoxDetail);
            this.PnlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlResult.Location = new System.Drawing.Point(3, 3);
            this.PnlResult.Name = "PnlResult";
            this.PnlResult.Size = new System.Drawing.Size(777, 220);
            this.PnlResult.TabIndex = 0;
            // 
            // richTextBoxDetail
            // 
            this.richTextBoxDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDetail.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxDetail.Name = "richTextBoxDetail";
            this.richTextBoxDetail.ReadOnly = true;
            this.richTextBoxDetail.Size = new System.Drawing.Size(777, 220);
            this.richTextBoxDetail.TabIndex = 0;
            this.richTextBoxDetail.Text = "";
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(153, 93);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 9;
            this.BtnReset.Text = "重    置";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.buttonSaveAS);
            this.GrpSearch.Controls.Add(this.groupBox2);
            this.GrpSearch.Controls.Add(this.groupBox1);
            this.GrpSearch.Controls.Add(this.BtnReset);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.TxtUser);
            this.GrpSearch.Controls.Add(this.LblUser);
            this.GrpSearch.Controls.Add(this.TxtID);
            this.GrpSearch.Controls.Add(this.LblID);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(10, 10);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(914, 174);
            this.GrpSearch.TabIndex = 16;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // buttonSaveAS
            // 
            this.buttonSaveAS.Enabled = false;
            this.buttonSaveAS.Location = new System.Drawing.Point(153, 136);
            this.buttonSaveAS.Name = "buttonSaveAS";
            this.buttonSaveAS.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAS.TabIndex = 16;
            this.buttonSaveAS.Text = "另存文本";
            this.buttonSaveAS.Click += new System.EventHandler(this.buttonSaveAS_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.richTextNotice);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.labelDate);
            this.groupBox2.Controls.Add(this.buttonUnlock);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Location = new System.Drawing.Point(555, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 145);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Location = new System.Drawing.Point(124, 0);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(94, 23);
            this.buttonUnlock.TabIndex = 15;
            this.buttonUnlock.Text = "解封该帐号";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "描述：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 73);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 65);
            this.textBox1.TabIndex = 13;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(9, 0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(94, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停封该帐号";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonQA);
            this.groupBox1.Controls.Add(this.buttonResetRegBox);
            this.groupBox1.Controls.Add(this.buttonResetMailBox);
            this.groupBox1.Controls.Add(this.buttonResetPhone);
            this.groupBox1.Controls.Add(this.btnRestIDCode);
            this.groupBox1.Controls.Add(this.buttonResetRealName);
            this.groupBox1.Controls.Add(this.btnResetV);
            this.groupBox1.Location = new System.Drawing.Point(249, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 145);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能操作";
            // 
            // buttonQA
            // 
            this.buttonQA.Enabled = false;
            this.buttonQA.Location = new System.Drawing.Point(11, 105);
            this.buttonQA.Name = "buttonQA";
            this.buttonQA.Size = new System.Drawing.Size(128, 23);
            this.buttonQA.TabIndex = 16;
            this.buttonQA.Text = "重置密码问题";
            this.buttonQA.UseVisualStyleBackColor = true;
            this.buttonQA.Click += new System.EventHandler(this.buttonResetQA_Click);
            // 
            // buttonResetRegBox
            // 
            this.buttonResetRegBox.Enabled = false;
            this.buttonResetRegBox.Location = new System.Drawing.Point(157, 77);
            this.buttonResetRegBox.Name = "buttonResetRegBox";
            this.buttonResetRegBox.Size = new System.Drawing.Size(128, 23);
            this.buttonResetRegBox.TabIndex = 13;
            this.buttonResetRegBox.Text = "重置注册邮箱";
            this.buttonResetRegBox.UseVisualStyleBackColor = true;
            this.buttonResetRegBox.Click += new System.EventHandler(this.buttonResetRegBox_Click);
            // 
            // buttonResetMailBox
            // 
            this.buttonResetMailBox.Enabled = false;
            this.buttonResetMailBox.Location = new System.Drawing.Point(157, 19);
            this.buttonResetMailBox.Name = "buttonResetMailBox";
            this.buttonResetMailBox.Size = new System.Drawing.Size(128, 23);
            this.buttonResetMailBox.TabIndex = 12;
            this.buttonResetMailBox.Text = "重置密保邮箱";
            this.buttonResetMailBox.UseVisualStyleBackColor = true;
            this.buttonResetMailBox.Click += new System.EventHandler(this.buttonResetMailBox_Click);
            // 
            // buttonResetPhone
            // 
            this.buttonResetPhone.Enabled = false;
            this.buttonResetPhone.Location = new System.Drawing.Point(11, 76);
            this.buttonResetPhone.Name = "buttonResetPhone";
            this.buttonResetPhone.Size = new System.Drawing.Size(128, 23);
            this.buttonResetPhone.TabIndex = 14;
            this.buttonResetPhone.Text = "重置电话";
            this.buttonResetPhone.UseVisualStyleBackColor = true;
            this.buttonResetPhone.Click += new System.EventHandler(this.buttonResetPhone_Click);
            // 
            // btnRestIDCode
            // 
            this.btnRestIDCode.Enabled = false;
            this.btnRestIDCode.Location = new System.Drawing.Point(11, 20);
            this.btnRestIDCode.Name = "btnRestIDCode";
            this.btnRestIDCode.Size = new System.Drawing.Size(128, 23);
            this.btnRestIDCode.TabIndex = 10;
            this.btnRestIDCode.Text = "重置身份证及其类型";
            this.btnRestIDCode.UseVisualStyleBackColor = true;
            this.btnRestIDCode.Click += new System.EventHandler(this.btnRestIDCode_Click);
            // 
            // buttonResetRealName
            // 
            this.buttonResetRealName.Enabled = false;
            this.buttonResetRealName.Location = new System.Drawing.Point(157, 48);
            this.buttonResetRealName.Name = "buttonResetRealName";
            this.buttonResetRealName.Size = new System.Drawing.Size(128, 23);
            this.buttonResetRealName.TabIndex = 15;
            this.buttonResetRealName.Text = "重置真实姓名";
            this.buttonResetRealName.UseVisualStyleBackColor = true;
            this.buttonResetRealName.Click += new System.EventHandler(this.buttonResetRealName_Click);
            // 
            // btnResetV
            // 
            this.btnResetV.Enabled = false;
            this.btnResetV.Location = new System.Drawing.Point(11, 47);
            this.btnResetV.Name = "btnResetV";
            this.btnResetV.Size = new System.Drawing.Size(128, 23);
            this.btnResetV.TabIndex = 11;
            this.btnResetV.Text = "重置验证码";
            this.btnResetV.UseVisualStyleBackColor = true;
            this.btnResetV.Click += new System.EventHandler(this.btnResetV_Click);
            // 
            // TxtUser
            // 
            this.TxtUser.Location = new System.Drawing.Point(26, 95);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.Size = new System.Drawing.Size(121, 21);
            this.TxtUser.TabIndex = 7;
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(24, 35);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(53, 12);
            this.LblUser.TabIndex = 6;
            this.LblUser.Text = "用户名：";
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(7, 33);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(53, 12);
            this.labelDate.TabIndex = 16;
            this.labelDate.Text = "封停至：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(66, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 21);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // richTextNotice
            // 
            this.richTextNotice.BackColor = System.Drawing.SystemColors.Control;
            this.richTextNotice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextNotice.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.richTextNotice.Location = new System.Drawing.Point(234, 15);
            this.richTextNotice.Name = "richTextNotice";
            this.richTextNotice.ReadOnly = true;
            this.richTextNotice.Size = new System.Drawing.Size(116, 122);
            this.richTextNotice.TabIndex = 18;
            this.richTextNotice.Text = "温馨提示：如果不输入封停的日期，则系统将自动封停该帐号24小时！";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(183, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Frm_YOU_UserDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 472);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "Frm_YOU_UserDetail";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "9you用户信息";
            this.Load += new System.EventHandler(this.Frm_YOU_UserDetail_Load);
            this.GrpResult.ResumeLayout(false);
            this.tabControlResult.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.tabPageDetail.ResumeLayout(false);
            this.PnlResult.ResumeLayout(false);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.TextBox TxtUser;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonResetRegBox;
        private System.Windows.Forms.Button buttonResetMailBox;
        private System.Windows.Forms.Button buttonResetPhone;
        private System.Windows.Forms.Button btnRestIDCode;
        private System.Windows.Forms.Button buttonResetRealName;
        private System.Windows.Forms.Button btnResetV;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.TabControl tabControlResult;
        private System.Windows.Forms.TabPage tabPageBasic;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.TabPage tabPageDetail;
        private System.Windows.Forms.Panel PnlResult;
        private System.Windows.Forms.RichTextBox richTextBoxDetail;
        private System.Windows.Forms.Button buttonQA;
        private System.Windows.Forms.Button buttonSaveAS;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RichTextBox richTextNotice;
    }
}