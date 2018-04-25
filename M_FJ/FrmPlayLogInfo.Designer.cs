namespace M_FJ
{
    partial class FrmPlayLogInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.TxtNick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.TxtAncont = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TbcResult = new System.Windows.Forms.TabControl();
            this.TpgCharacter = new System.Windows.Forms.TabPage();
            this.RoleInfoView = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.logInfoView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearchLog = new System.Windows.Forms.Button();
            this.TxtCharinfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbType = new System.Windows.Forms.ComboBox();
            this.lblApproach = new System.Windows.Forms.Label();
            this.dateTimePickerTimeTo = new System.Windows.Forms.DateTimePicker();
            this.LblItemName = new System.Windows.Forms.Label();
            this.LblTo = new System.Windows.Forms.Label();
            this.TxtItemName = new System.Windows.Forms.TextBox();
            this.dateTimePickerTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.LblTimeSpan = new System.Windows.Forms.Label();
            this.backgroundWorkerServerLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerType = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.TbcResult.SuspendLayout();
            this.TpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logInfoView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.TxtNick);
            this.GrpSearch.Controls.Add(this.label1);
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.TxtAncont);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(667, 159);
            this.GrpSearch.TabIndex = 3;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // TxtNick
            // 
            this.TxtNick.Location = new System.Drawing.Point(8, 116);
            this.TxtNick.Name = "TxtNick";
            this.TxtNick.Size = new System.Drawing.Size(162, 21);
            this.TxtNick.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "玩家昵称：";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(210, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(8, 32);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(162, 20);
            this.CmbServer.TabIndex = 8;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(6, 17);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(77, 12);
            this.LblServer.TabIndex = 7;
            this.LblServer.Text = "游戏服务器：";
            // 
            // TxtAncont
            // 
            this.TxtAncont.Location = new System.Drawing.Point(8, 74);
            this.TxtAncont.Name = "TxtAncont";
            this.TxtAncont.Size = new System.Drawing.Size(162, 21);
            this.TxtAncont.TabIndex = 6;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(6, 59);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(65, 12);
            this.LblAccount.TabIndex = 5;
            this.LblAccount.Text = "玩家帐号：";
            this.LblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(210, 29);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(67, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TbcResult
            // 
            this.TbcResult.Controls.Add(this.TpgCharacter);
            this.TbcResult.Controls.Add(this.tabPage1);
            this.TbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcResult.Location = new System.Drawing.Point(0, 159);
            this.TbcResult.Name = "TbcResult";
            this.TbcResult.SelectedIndex = 0;
            this.TbcResult.Size = new System.Drawing.Size(667, 292);
            this.TbcResult.TabIndex = 4;
            this.TbcResult.SelectedIndexChanged += new System.EventHandler(this.TbcResult_SelectedIndexChanged);
            // 
            // TpgCharacter
            // 
            this.TpgCharacter.Controls.Add(this.RoleInfoView);
            this.TpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.TpgCharacter.Name = "TpgCharacter";
            this.TpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCharacter.Size = new System.Drawing.Size(659, 267);
            this.TpgCharacter.TabIndex = 0;
            this.TpgCharacter.Text = "角色信息";
            this.TpgCharacter.UseVisualStyleBackColor = true;
            // 
            // RoleInfoView
            // 
            this.RoleInfoView.AllowUserToAddRows = false;
            this.RoleInfoView.AllowUserToDeleteRows = false;
            this.RoleInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleInfoView.Location = new System.Drawing.Point(3, 3);
            this.RoleInfoView.Name = "RoleInfoView";
            this.RoleInfoView.ReadOnly = true;
            this.RoleInfoView.RowTemplate.Height = 23;
            this.RoleInfoView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoleInfoView.Size = new System.Drawing.Size(653, 261);
            this.RoleInfoView.TabIndex = 7;
            this.RoleInfoView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleInfoView_CellDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.logInfoView);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(659, 267);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "日志信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // logInfoView
            // 
            this.logInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logInfoView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logInfoView.Location = new System.Drawing.Point(0, 80);
            this.logInfoView.Name = "logInfoView";
            this.logInfoView.RowTemplate.Height = 23;
            this.logInfoView.Size = new System.Drawing.Size(659, 187);
            this.logInfoView.TabIndex = 101;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearchLog);
            this.panel1.Controls.Add(this.TxtCharinfo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CmbType);
            this.panel1.Controls.Add(this.lblApproach);
            this.panel1.Controls.Add(this.dateTimePickerTimeTo);
            this.panel1.Controls.Add(this.LblItemName);
            this.panel1.Controls.Add(this.LblTo);
            this.panel1.Controls.Add(this.TxtItemName);
            this.panel1.Controls.Add(this.dateTimePickerTimeFrom);
            this.panel1.Controls.Add(this.LblTimeSpan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 74);
            this.panel1.TabIndex = 100;
            // 
            // btnSearchLog
            // 
            this.btnSearchLog.Location = new System.Drawing.Point(560, 28);
            this.btnSearchLog.Name = "btnSearchLog";
            this.btnSearchLog.Size = new System.Drawing.Size(75, 23);
            this.btnSearchLog.TabIndex = 110;
            this.btnSearchLog.Text = "查询日志";
            this.btnSearchLog.UseVisualStyleBackColor = true;
            this.btnSearchLog.Click += new System.EventHandler(this.btnSearchLog_Click);
            // 
            // TxtCharinfo
            // 
            this.TxtCharinfo.Location = new System.Drawing.Point(81, 8);
            this.TxtCharinfo.Name = "TxtCharinfo";
            this.TxtCharinfo.ReadOnly = true;
            this.TxtCharinfo.Size = new System.Drawing.Size(188, 21);
            this.TxtCharinfo.TabIndex = 109;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 108;
            this.label2.Text = "玩家角色:";
            // 
            // CmbType
            // 
            this.CmbType.FormattingEnabled = true;
            this.CmbType.Location = new System.Drawing.Point(59, 37);
            this.CmbType.Name = "CmbType";
            this.CmbType.Size = new System.Drawing.Size(121, 20);
            this.CmbType.TabIndex = 107;
            // 
            // lblApproach
            // 
            this.lblApproach.AutoSize = true;
            this.lblApproach.Location = new System.Drawing.Point(12, 41);
            this.lblApproach.Name = "lblApproach";
            this.lblApproach.Size = new System.Drawing.Size(41, 12);
            this.lblApproach.TabIndex = 106;
            this.lblApproach.Text = "途径：";
            // 
            // dateTimePickerTimeTo
            // 
            this.dateTimePickerTimeTo.Location = new System.Drawing.Point(405, 35);
            this.dateTimePickerTimeTo.Name = "dateTimePickerTimeTo";
            this.dateTimePickerTimeTo.Size = new System.Drawing.Size(112, 21);
            this.dateTimePickerTimeTo.TabIndex = 105;
            this.dateTimePickerTimeTo.Value = new System.DateTime(2007, 10, 9, 0, 0, 0, 0);
            this.dateTimePickerTimeTo.ValueChanged += new System.EventHandler(this.dateTimePickerTimeTo_ValueChanged);
            // 
            // LblItemName
            // 
            this.LblItemName.AutoSize = true;
            this.LblItemName.Location = new System.Drawing.Point(306, 12);
            this.LblItemName.Name = "LblItemName";
            this.LblItemName.Size = new System.Drawing.Size(65, 12);
            this.LblItemName.TabIndex = 100;
            this.LblItemName.Text = "物品名称：";
            // 
            // LblTo
            // 
            this.LblTo.AutoSize = true;
            this.LblTo.Location = new System.Drawing.Point(359, 39);
            this.LblTo.Name = "LblTo";
            this.LblTo.Size = new System.Drawing.Size(29, 12);
            this.LblTo.TabIndex = 104;
            this.LblTo.Text = "到：";
            // 
            // TxtItemName
            // 
            this.TxtItemName.Location = new System.Drawing.Point(405, 8);
            this.TxtItemName.Name = "TxtItemName";
            this.TxtItemName.Size = new System.Drawing.Size(100, 21);
            this.TxtItemName.TabIndex = 101;
            // 
            // dateTimePickerTimeFrom
            // 
            this.dateTimePickerTimeFrom.Location = new System.Drawing.Point(245, 35);
            this.dateTimePickerTimeFrom.Name = "dateTimePickerTimeFrom";
            this.dateTimePickerTimeFrom.Size = new System.Drawing.Size(108, 21);
            this.dateTimePickerTimeFrom.TabIndex = 103;
            this.dateTimePickerTimeFrom.Value = new System.DateTime(2007, 10, 9, 0, 0, 0, 0);
            this.dateTimePickerTimeFrom.ValueChanged += new System.EventHandler(this.dateTimePickerTimeFrom_ValueChanged);
            // 
            // LblTimeSpan
            // 
            this.LblTimeSpan.AutoSize = true;
            this.LblTimeSpan.Location = new System.Drawing.Point(186, 40);
            this.LblTimeSpan.Name = "LblTimeSpan";
            this.LblTimeSpan.Size = new System.Drawing.Size(53, 12);
            this.LblTimeSpan.TabIndex = 102;
            this.LblTimeSpan.Text = "时间段：";
            // 
            // backgroundWorkerServerLoad
            // 
            this.backgroundWorkerServerLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerServerLoad_DoWork);
            this.backgroundWorkerServerLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerServerLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerType
            // 
            this.backgroundWorkerType.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerType_DoWork);
            this.backgroundWorkerType.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerType_RunWorkerCompleted);
            // 
            // FrmPlayLogInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 451);
            this.Controls.Add(this.TbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmPlayLogInfo";
            this.Text = "玩家日志信息";
            this.Load += new System.EventHandler(this.FrmPlayLogInfo_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.TbcResult.ResumeLayout(false);
            this.TpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logInfoView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.TextBox TxtNick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.TextBox TxtAncont;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TabControl TbcResult;
        private System.Windows.Forms.TabPage TpgCharacter;
        private System.Windows.Forms.DataGridView RoleInfoView;
        private System.Windows.Forms.TabPage tabPage1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerServerLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimeTo;
        private System.Windows.Forms.Label LblItemName;
        private System.Windows.Forms.Label LblTo;
        private System.Windows.Forms.TextBox TxtItemName;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimeFrom;
        private System.Windows.Forms.Label LblTimeSpan;
        private System.Windows.Forms.DataGridView logInfoView;
        private System.Windows.Forms.Label lblApproach;
        private System.Windows.Forms.ComboBox CmbType;
        private System.Windows.Forms.TextBox TxtCharinfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerType;
    }
}