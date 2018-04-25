namespace M_SDO
{
    partial class FrmOnlineTime
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
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.LblServer = new System.Windows.Forms.Label();
            this.DptStart = new System.Windows.Forms.DateTimePicker();
            this.DptEnd = new System.Windows.Forms.DateTimePicker();
            this.lblstartime = new System.Windows.Forms.Label();
            this.lblendtime = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.backgroundWorkerLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.GrpResult.SuspendLayout();
            this.PnlDetail.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.PnlDetail);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 101);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(711, 395);
            this.GrpResult.TabIndex = 9;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "搜索结果";
            // 
            // PnlDetail
            // 
            this.PnlDetail.AutoScroll = true;
            this.PnlDetail.Controls.Add(this.txtTime);
            this.PnlDetail.Controls.Add(this.lblTime);
            this.PnlDetail.Controls.Add(this.LblStatus);
            this.PnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDetail.Location = new System.Drawing.Point(3, 17);
            this.PnlDetail.Name = "PnlDetail";
            this.PnlDetail.Size = new System.Drawing.Size(705, 375);
            this.PnlDetail.TabIndex = 0;
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTime.Location = new System.Drawing.Point(96, 40);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(223, 21);
            this.txtTime.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(35, 43);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(59, 12);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "在线时间:";
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(127, 114);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(0, 12);
            this.LblStatus.TabIndex = 0;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.DptStart);
            this.GrpSearch.Controls.Add(this.DptEnd);
            this.GrpSearch.Controls.Add(this.lblstartime);
            this.GrpSearch.Controls.Add(this.lblendtime);
            this.GrpSearch.Controls.Add(this.BtnClose);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(711, 101);
            this.GrpSearch.TabIndex = 8;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAccount.Location = new System.Drawing.Point(252, 25);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(70, 14);
            this.LblAccount.TabIndex = 21;
            this.LblAccount.Text = "玩家帐号:";
            this.LblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblServer.Location = new System.Drawing.Point(13, 25);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(84, 14);
            this.LblServer.TabIndex = 20;
            this.LblServer.Text = "服务器大区:";
            this.LblServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DptStart
            // 
            this.DptStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DptStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptStart.Location = new System.Drawing.Point(99, 57);
            this.DptStart.Name = "DptStart";
            this.DptStart.ShowUpDown = true;
            this.DptStart.Size = new System.Drawing.Size(142, 21);
            this.DptStart.TabIndex = 19;
            // 
            // DptEnd
            // 
            this.DptEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DptEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptEnd.Location = new System.Drawing.Point(328, 57);
            this.DptEnd.Name = "DptEnd";
            this.DptEnd.ShowUpDown = true;
            this.DptEnd.Size = new System.Drawing.Size(142, 21);
            this.DptEnd.TabIndex = 18;
            // 
            // lblstartime
            // 
            this.lblstartime.AutoSize = true;
            this.lblstartime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblstartime.Location = new System.Drawing.Point(13, 57);
            this.lblstartime.Name = "lblstartime";
            this.lblstartime.Size = new System.Drawing.Size(70, 14);
            this.lblstartime.TabIndex = 16;
            this.lblstartime.Text = "开始时间:";
            this.lblstartime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblendtime
            // 
            this.lblendtime.AutoSize = true;
            this.lblendtime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblendtime.Location = new System.Drawing.Point(252, 59);
            this.lblendtime.Name = "lblendtime";
            this.lblendtime.Size = new System.Drawing.Size(70, 14);
            this.lblendtime.TabIndex = 17;
            this.lblendtime.Text = "结束时间:";
            this.lblendtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.Location = new System.Drawing.Point(578, 22);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(80, 23);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.Text = "关闭";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(99, 23);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(142, 20);
            this.CmbServer.TabIndex = 8;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(328, 23);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(142, 21);
            this.TxtAccount.TabIndex = 6;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(492, 22);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(80, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // backgroundWorkerLoad
            // 
            this.backgroundWorkerLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoad_DoWork);
            this.backgroundWorkerLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // FrmOnlineTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 496);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmOnlineTime";
            this.Text = "在线时间查询[SDO]";
            this.Load += new System.EventHandler(this.FrmOnlineTime_Load);
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
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.DateTimePicker DptStart;
        private System.Windows.Forms.DateTimePicker DptEnd;
        private System.Windows.Forms.Label lblstartime;
        private System.Windows.Forms.Label lblendtime;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Label LblServer;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
    }
}