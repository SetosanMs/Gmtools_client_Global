namespace M_Audition
{
    partial class UserDetailFrmLimit
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
            this.PnlResult = new System.Windows.Forms.Panel();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRestIDCode = new System.Windows.Forms.Button();
            this.btnResetV = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.LblUser = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.LblID = new System.Windows.Forms.Label();
            this.buttonSaveAS = new System.Windows.Forms.Button();
            this.GrpResult.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.PnlResult);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 168);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(547, 277);
            this.GrpResult.TabIndex = 19;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "查询结果";
            // 
            // PnlResult
            // 
            this.PnlResult.AutoScroll = true;
            this.PnlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlResult.Location = new System.Drawing.Point(3, 17);
            this.PnlResult.Name = "PnlResult";
            this.PnlResult.Size = new System.Drawing.Size(541, 257);
            this.PnlResult.TabIndex = 0;
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
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(547, 168);
            this.GrpSearch.TabIndex = 18;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Location = new System.Drawing.Point(405, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 112);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "描述：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 44);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 62);
            this.textBox1.TabIndex = 13;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(7, 0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(128, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停封该帐号";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRestIDCode);
            this.groupBox1.Controls.Add(this.btnResetV);
            this.groupBox1.Location = new System.Drawing.Point(249, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 89);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能操作";
            this.groupBox1.Visible = false;
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
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(146, 86);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 9;
            this.BtnReset.Text = "重    置";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(146, 41);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查    找";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtUser
            // 
            this.TxtUser.Location = new System.Drawing.Point(19, 88);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.Size = new System.Drawing.Size(121, 21);
            this.TxtUser.TabIndex = 7;
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(17, 28);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(53, 12);
            this.LblUser.TabIndex = 6;
            this.LblUser.Text = "用户名：";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(19, 43);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(121, 21);
            this.TxtID.TabIndex = 3;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(17, 73);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(53, 12);
            this.LblID.TabIndex = 2;
            this.LblID.Text = "昵  称：";
            // 
            // buttonSaveAS
            // 
            this.buttonSaveAS.Enabled = false;
            this.buttonSaveAS.Location = new System.Drawing.Point(146, 129);
            this.buttonSaveAS.Name = "buttonSaveAS";
            this.buttonSaveAS.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAS.TabIndex = 15;
            this.buttonSaveAS.Text = "另存文本";
            this.buttonSaveAS.Click += new System.EventHandler(this.buttonSaveAS_Click);
            // 
            // UserDetailFrmLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 445);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "UserDetailFrmLimit";
            this.Text = "9you用户信息(限制)";
            this.Load += new System.EventHandler(this.UserDetailFrmPower_Load);
            this.GrpResult.ResumeLayout(false);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.Panel PnlResult;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRestIDCode;
        private System.Windows.Forms.Button btnResetV;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtUser;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.Button buttonSaveAS;
    }
}