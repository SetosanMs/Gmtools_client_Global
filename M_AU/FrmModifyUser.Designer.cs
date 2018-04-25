namespace M_Audition
{
    partial class FrmModifyUser
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
            this.PnlDetail = new System.Windows.Forms.Panel();
            this.LblStatus = new System.Windows.Forms.Label();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.BtnUnlock = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.LblEsn = new System.Windows.Forms.Label();
            this.Txtesn = new System.Windows.Forms.TextBox();
            this.BtnLock = new System.Windows.Forms.Button();
            this.GrpResult.SuspendLayout();
            this.PnlDetail.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.PnlDetail);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 93);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(673, 360);
            this.GrpResult.TabIndex = 9;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "搜索结果";
            // 
            // PnlDetail
            // 
            this.PnlDetail.AutoScroll = true;
            this.PnlDetail.Controls.Add(this.LblStatus);
            this.PnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDetail.Location = new System.Drawing.Point(3, 17);
            this.PnlDetail.Name = "PnlDetail";
            this.PnlDetail.Size = new System.Drawing.Size(667, 340);
            this.PnlDetail.TabIndex = 0;
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(65, 37);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(0, 12);
            this.LblStatus.TabIndex = 0;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.btnDel);
            this.GrpSearch.Controls.Add(this.BtnUnlock);
            this.GrpSearch.Controls.Add(this.lblUser);
            this.GrpSearch.Controls.Add(this.txtUser);
            this.GrpSearch.Controls.Add(this.btnclose);
            this.GrpSearch.Controls.Add(this.LblEsn);
            this.GrpSearch.Controls.Add(this.Txtesn);
            this.GrpSearch.Controls.Add(this.BtnLock);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(673, 93);
            this.GrpSearch.TabIndex = 8;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(517, 17);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(79, 23);
            this.btnDel.TabIndex = 13;
            this.btnDel.Text = "删除用户";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // BtnUnlock
            // 
            this.BtnUnlock.Location = new System.Drawing.Point(378, 49);
            this.BtnUnlock.Name = "BtnUnlock";
            this.BtnUnlock.Size = new System.Drawing.Size(79, 23);
            this.BtnUnlock.TabIndex = 12;
            this.BtnUnlock.Text = "解锁用户";
            this.BtnUnlock.Click += new System.EventHandler(this.BtnUnlock_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(88, 22);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(53, 12);
            this.lblUser.TabIndex = 11;
            this.lblUser.Text = "用户名：";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(147, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(138, 21);
            this.txtUser.TabIndex = 10;
            // 
            // btnclose
            // 
            this.btnclose.AutoSize = true;
            this.btnclose.Location = new System.Drawing.Point(517, 49);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(79, 23);
            this.btnclose.TabIndex = 9;
            this.btnclose.Text = "关闭";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // LblEsn
            // 
            this.LblEsn.AutoSize = true;
            this.LblEsn.Location = new System.Drawing.Point(70, 56);
            this.LblEsn.Name = "LblEsn";
            this.LblEsn.Size = new System.Drawing.Size(71, 12);
            this.LblEsn.TabIndex = 7;
            this.LblEsn.Text = "ESN序列号：";
            // 
            // Txtesn
            // 
            this.Txtesn.Location = new System.Drawing.Point(147, 53);
            this.Txtesn.Name = "Txtesn";
            this.Txtesn.Size = new System.Drawing.Size(138, 21);
            this.Txtesn.TabIndex = 6;
            this.Txtesn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txtesn_KeyUp);
            this.Txtesn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Txtesn_MouseUp);
            // 
            // BtnLock
            // 
            this.BtnLock.Location = new System.Drawing.Point(378, 17);
            this.BtnLock.Name = "BtnLock";
            this.BtnLock.Size = new System.Drawing.Size(79, 23);
            this.BtnLock.TabIndex = 4;
            this.BtnLock.Text = "锁定用户";
            this.BtnLock.Click += new System.EventHandler(this.BtnLock_Click);
            // 
            // FrmModifyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 453);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmModifyUser";
            this.Text = "密保用户状态修改";
            this.Load += new System.EventHandler(this.FrmModifyUser_Load);
            this.GrpResult.ResumeLayout(false);
            this.PnlDetail.ResumeLayout(false);
            this.PnlDetail.PerformLayout();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.Panel PnlDetail;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label LblEsn;
        private System.Windows.Forms.TextBox Txtesn;
        private System.Windows.Forms.Button BtnLock;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button BtnUnlock;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
    }
}