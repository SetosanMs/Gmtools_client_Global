namespace M_SDO
{
    partial class FrmPunishPlayer
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
            this.components = new System.ComponentModel.Container();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DptEnd = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btnPunish = new System.Windows.Forms.Button();
            this.checkImport = new System.Windows.Forms.CheckBox();
            this.DptStart = new System.Windows.Forms.DateTimePicker();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.labelEnd = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonBat = new System.Windows.Forms.Button();
            this.labelAccount = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.TbcResult = new System.Windows.Forms.TabControl();
            this.TpgInfo = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.dividerPanel6 = new DividerPanel.DividerPanel();
            this.dgEquipList = new System.Windows.Forms.DataGridView();
            this.MnuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TpgModify = new System.Windows.Forms.TabPage();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.DataResult = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorkLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkPunish = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkUpdate = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.TbcResult.SuspendLayout();
            this.TpgInfo.SuspendLayout();
            this.dividerPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipList)).BeginInit();
            this.MnuGrid.SuspendLayout();
            this.TpgModify.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataResult)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.label2);
            this.GrpSearch.Controls.Add(this.DptEnd);
            this.GrpSearch.Controls.Add(this.btnUpdate);
            this.GrpSearch.Controls.Add(this.btn_Close);
            this.GrpSearch.Controls.Add(this.btnPunish);
            this.GrpSearch.Controls.Add(this.checkImport);
            this.GrpSearch.Controls.Add(this.DptStart);
            this.GrpSearch.Controls.Add(this.txtUser);
            this.GrpSearch.Controls.Add(this.labelEnd);
            this.GrpSearch.Controls.Add(this.buttonConfirm);
            this.GrpSearch.Controls.Add(this.buttonBat);
            this.GrpSearch.Controls.Add(this.labelAccount);
            this.GrpSearch.Controls.Add(this.Btn_Search);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(667, 131);
            this.GrpSearch.TabIndex = 1;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "开始时间:";
            // 
            // DptEnd
            // 
            this.DptEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DptEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptEnd.Location = new System.Drawing.Point(89, 85);
            this.DptEnd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DptEnd.Name = "DptEnd";
            this.DptEnd.ShowUpDown = true;
            this.DptEnd.Size = new System.Drawing.Size(167, 21);
            this.DptEnd.TabIndex = 27;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(557, 18);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(74, 24);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(557, 55);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(74, 24);
            this.btn_Close.TabIndex = 25;
            this.btn_Close.Text = "关闭";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btnPunish
            // 
            this.btnPunish.Location = new System.Drawing.Point(295, 92);
            this.btnPunish.Name = "btnPunish";
            this.btnPunish.Size = new System.Drawing.Size(74, 24);
            this.btnPunish.TabIndex = 18;
            this.btnPunish.Text = "批量惩罚";
            this.btnPunish.UseVisualStyleBackColor = true;
            this.btnPunish.Click += new System.EventHandler(this.btnPunish_Click);
            // 
            // checkImport
            // 
            this.checkImport.AutoSize = true;
            this.checkImport.Checked = true;
            this.checkImport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkImport.Location = new System.Drawing.Point(297, 60);
            this.checkImport.Name = "checkImport";
            this.checkImport.Size = new System.Drawing.Size(72, 16);
            this.checkImport.TabIndex = 24;
            this.checkImport.Text = "批量导入";
            this.checkImport.UseVisualStyleBackColor = true;
            this.checkImport.CheckedChanged += new System.EventHandler(this.checkImport_CheckedChanged);
            // 
            // DptStart
            // 
            this.DptStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DptStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DptStart.Location = new System.Drawing.Point(89, 58);
            this.DptStart.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DptStart.Name = "DptStart";
            this.DptStart.ShowUpDown = true;
            this.DptStart.Size = new System.Drawing.Size(167, 21);
            this.DptStart.TabIndex = 23;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(360, 26);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(164, 21);
            this.txtUser.TabIndex = 22;
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(18, 86);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(59, 12);
            this.labelEnd.TabIndex = 20;
            this.labelEnd.Text = "结束时间:";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(295, 92);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(74, 24);
            this.buttonConfirm.TabIndex = 18;
            this.buttonConfirm.Text = "单个惩罚";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonBat
            // 
            this.buttonBat.Location = new System.Drawing.Point(393, 92);
            this.buttonBat.Name = "buttonBat";
            this.buttonBat.Size = new System.Drawing.Size(74, 24);
            this.buttonBat.TabIndex = 17;
            this.buttonBat.Text = "导入文件";
            this.buttonBat.UseVisualStyleBackColor = true;
            this.buttonBat.Click += new System.EventHandler(this.buttonBat_Click);
            // 
            // labelAccount
            // 
            this.labelAccount.AutoSize = true;
            this.labelAccount.Location = new System.Drawing.Point(295, 30);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Size = new System.Drawing.Size(59, 12);
            this.labelAccount.TabIndex = 15;
            this.labelAccount.Text = "玩家帐号:";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(557, 18);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(74, 24);
            this.Btn_Search.TabIndex = 11;
            this.Btn_Search.Text = "搜索";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(89, 27);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(167, 20);
            this.CmbServer.TabIndex = 10;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(6, 30);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(71, 12);
            this.LblServer.TabIndex = 9;
            this.LblServer.Text = "游戏服务器:";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 131);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(667, 10);
            this.dividerPanel1.TabIndex = 4;
            // 
            // TbcResult
            // 
            this.TbcResult.Controls.Add(this.TpgInfo);
            this.TbcResult.Controls.Add(this.TpgModify);
            this.TbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcResult.Location = new System.Drawing.Point(0, 141);
            this.TbcResult.Name = "TbcResult";
            this.TbcResult.SelectedIndex = 0;
            this.TbcResult.Size = new System.Drawing.Size(667, 333);
            this.TbcResult.TabIndex = 5;
            // 
            // TpgInfo
            // 
            this.TpgInfo.Controls.Add(this.label1);
            this.TpgInfo.Controls.Add(this.CmbPage);
            this.TpgInfo.Controls.Add(this.dividerPanel6);
            this.TpgInfo.Location = new System.Drawing.Point(4, 21);
            this.TpgInfo.Name = "TpgInfo";
            this.TpgInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TpgInfo.Size = new System.Drawing.Size(659, 308);
            this.TpgInfo.TabIndex = 0;
            this.TpgInfo.Text = "惩罚信息";
            this.TpgInfo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "查看页数:";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(435, 6);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(98, 20);
            this.CmbPage.TabIndex = 27;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
            // 
            // dividerPanel6
            // 
            this.dividerPanel6.AllowDrop = true;
            this.dividerPanel6.BorderSide = System.Windows.Forms.Border3DSide.Right;
            this.dividerPanel6.Controls.Add(this.dgEquipList);
            this.dividerPanel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.dividerPanel6.Location = new System.Drawing.Point(3, 3);
            this.dividerPanel6.Name = "dividerPanel6";
            this.dividerPanel6.Size = new System.Drawing.Size(357, 302);
            this.dividerPanel6.TabIndex = 4;
            // 
            // dgEquipList
            // 
            this.dgEquipList.AllowUserToAddRows = false;
            this.dgEquipList.AllowUserToDeleteRows = false;
            this.dgEquipList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEquipList.ContextMenuStrip = this.MnuGrid;
            this.dgEquipList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEquipList.Location = new System.Drawing.Point(0, 0);
            this.dgEquipList.MultiSelect = false;
            this.dgEquipList.Name = "dgEquipList";
            this.dgEquipList.ReadOnly = true;
            this.dgEquipList.RowTemplate.Height = 23;
            this.dgEquipList.Size = new System.Drawing.Size(357, 302);
            this.dgEquipList.TabIndex = 1;
            this.dgEquipList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEquipList_CellClick);
            // 
            // MnuGrid
            // 
            this.MnuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItmEdit});
            this.MnuGrid.Name = "MnuGrid";
            this.MnuGrid.Size = new System.Drawing.Size(147, 26);
            // 
            // ItmEdit
            // 
            this.ItmEdit.Enabled = false;
            this.ItmEdit.Name = "ItmEdit";
            this.ItmEdit.Size = new System.Drawing.Size(146, 22);
            this.ItmEdit.Text = "编辑该条记录";
            this.ItmEdit.Click += new System.EventHandler(this.ItmEdit_Click);
            // 
            // TpgModify
            // 
            this.TpgModify.Controls.Add(this.dividerPanel2);
            this.TpgModify.Location = new System.Drawing.Point(4, 21);
            this.TpgModify.Name = "TpgModify";
            this.TpgModify.Padding = new System.Windows.Forms.Padding(3);
            this.TpgModify.Size = new System.Drawing.Size(659, 308);
            this.TpgModify.TabIndex = 1;
            this.TpgModify.Text = "导入信息";
            this.TpgModify.UseVisualStyleBackColor = true;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.BorderSide = System.Windows.Forms.Border3DSide.Right;
            this.dividerPanel2.Controls.Add(this.DataResult);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dividerPanel2.Location = new System.Drawing.Point(3, 3);
            this.dividerPanel2.Name = "dividerPanel6";
            this.dividerPanel2.Size = new System.Drawing.Size(357, 302);
            this.dividerPanel2.TabIndex = 5;
            // 
            // DataResult
            // 
            this.DataResult.AllowUserToAddRows = false;
            this.DataResult.AllowUserToDeleteRows = false;
            this.DataResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataResult.Location = new System.Drawing.Point(0, 0);
            this.DataResult.MultiSelect = false;
            this.DataResult.Name = "DataResult";
            this.DataResult.ReadOnly = true;
            this.DataResult.RowTemplate.Height = 23;
            this.DataResult.Size = new System.Drawing.Size(357, 302);
            this.DataResult.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            // 
            // backgroundWorkLoad
            // 
            this.backgroundWorkLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkLoad_DoWork);
            this.backgroundWorkLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkLoad_RunWorkerCompleted);
            // 
            // backgroundWorkPunish
            // 
            this.backgroundWorkPunish.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkPunish_DoWork);
            this.backgroundWorkPunish.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkPunish_RunWorkerCompleted);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // backgroundWorkUpdate
            // 
            this.backgroundWorkUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkUpdate_DoWork);
            this.backgroundWorkUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkUpdate_RunWorkerCompleted);
            // 
            // FrmPunishPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 474);
            this.Controls.Add(this.TbcResult);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmPunishPlayer";
            this.Text = "外挂惩罚";
            this.Load += new System.EventHandler(this.FrmPunishPlayer_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.TbcResult.ResumeLayout(false);
            this.TpgInfo.ResumeLayout(false);
            this.TpgInfo.PerformLayout();
            this.dividerPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipList)).EndInit();
            this.MnuGrid.ResumeLayout(false);
            this.TpgModify.ResumeLayout(false);
            this.dividerPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.TabControl TbcResult;
        private System.Windows.Forms.TabPage TpgInfo;
        private System.Windows.Forms.TabPage TpgModify;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonBat;
        private System.Windows.Forms.Label labelAccount;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorkLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkPunish;
        private DividerPanel.DividerPanel dividerPanel6;
        private System.Windows.Forms.DataGridView dgEquipList;
        private System.Windows.Forms.Button btnPunish;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.DataGridView DataResult;
        private System.Windows.Forms.TextBox txtUser;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.Windows.Forms.DateTimePicker DptStart;
        private System.Windows.Forms.CheckBox checkImport;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ContextMenuStrip MnuGrid;
        private System.Windows.Forms.ToolStripMenuItem ItmEdit;
        private System.Windows.Forms.Button btnUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorkUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DptEnd;
    }
}