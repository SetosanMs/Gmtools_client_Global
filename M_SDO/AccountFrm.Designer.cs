namespace M_SDO
{
    partial class Frm_SDO_Account
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.TxtNickName = new System.Windows.Forms.TextBox();
            this.labelNickName = new System.Windows.Forms.Label();
            this.buttonNickName = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBlanketActive = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.RoleInfoView = new System.Windows.Forms.DataGridView();
            this.panelRolePage = new System.Windows.Forms.Panel();
            this.labelRolePage = new System.Windows.Forms.Label();
            this.comboBoxRolePage = new System.Windows.Forms.ComboBox();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerActive = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.GrpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            this.panelRolePage.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.checkBox1);
            this.GrpSearch.Controls.Add(this.TxtNickName);
            this.GrpSearch.Controls.Add(this.labelNickName);
            this.GrpSearch.Controls.Add(this.buttonNickName);
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.btnBlanketActive);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(10, 10);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(611, 109);
            this.GrpSearch.TabIndex = 0;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "模糊查询";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // TxtNickName
            // 
            this.TxtNickName.Location = new System.Drawing.Point(360, 35);
            this.TxtNickName.Name = "TxtNickName";
            this.TxtNickName.Size = new System.Drawing.Size(139, 21);
            this.TxtNickName.TabIndex = 14;
            // 
            // labelNickName
            // 
            this.labelNickName.AutoSize = true;
            this.labelNickName.Location = new System.Drawing.Point(358, 20);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(65, 12);
            this.labelNickName.TabIndex = 13;
            this.labelNickName.Text = "玩家昵称：";
            this.labelNickName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNickName
            // 
            this.buttonNickName.Location = new System.Drawing.Point(313, 80);
            this.buttonNickName.Name = "buttonNickName";
            this.buttonNickName.Size = new System.Drawing.Size(110, 23);
            this.buttonNickName.TabIndex = 12;
            this.buttonNickName.Text = "昵称模糊查询";
            this.buttonNickName.Visible = false;
            this.buttonNickName.Click += new System.EventHandler(this.buttonNickName_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnBlanketActive
            // 
            this.btnBlanketActive.Location = new System.Drawing.Point(189, 80);
            this.btnBlanketActive.Name = "btnBlanketActive";
            this.btnBlanketActive.Size = new System.Drawing.Size(103, 23);
            this.btnBlanketActive.TabIndex = 10;
            this.btnBlanketActive.Text = "激活跳舞毯";
            this.btnBlanketActive.UseVisualStyleBackColor = true;
            this.btnBlanketActive.Click += new System.EventHandler(this.button2_Click);
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(8, 35);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(197, 20);
            this.CmbServer.TabIndex = 8;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(6, 20);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(77, 12);
            this.LblServer.TabIndex = 7;
            this.LblServer.Text = "游戏服务器：";
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(215, 35);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(139, 21);
            this.TxtAccount.TabIndex = 6;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(213, 20);
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
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.RoleInfoView);
            this.GrpResult.Controls.Add(this.panelRolePage);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 0);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(611, 232);
            this.GrpResult.TabIndex = 1;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "搜索结果";
            // 
            // RoleInfoView
            // 
            this.RoleInfoView.AllowUserToAddRows = false;
            this.RoleInfoView.AllowUserToDeleteRows = false;
            this.RoleInfoView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleInfoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleInfoView.Location = new System.Drawing.Point(3, 48);
            this.RoleInfoView.Name = "RoleInfoView";
            this.RoleInfoView.ReadOnly = true;
            this.RoleInfoView.RowTemplate.Height = 23;
            this.RoleInfoView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoleInfoView.Size = new System.Drawing.Size(605, 181);
            this.RoleInfoView.TabIndex = 9;
            // 
            // panelRolePage
            // 
            this.panelRolePage.Controls.Add(this.labelRolePage);
            this.panelRolePage.Controls.Add(this.comboBoxRolePage);
            this.panelRolePage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRolePage.Location = new System.Drawing.Point(3, 17);
            this.panelRolePage.Name = "panelRolePage";
            this.panelRolePage.Size = new System.Drawing.Size(605, 31);
            this.panelRolePage.TabIndex = 8;
            this.panelRolePage.TabStop = true;
            this.panelRolePage.Visible = false;
            // 
            // labelRolePage
            // 
            this.labelRolePage.AutoSize = true;
            this.labelRolePage.Location = new System.Drawing.Point(371, 8);
            this.labelRolePage.Name = "labelRolePage";
            this.labelRolePage.Size = new System.Drawing.Size(101, 12);
            this.labelRolePage.TabIndex = 1;
            this.labelRolePage.Text = "请选择查看页数：";
            // 
            // comboBoxRolePage
            // 
            this.comboBoxRolePage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRolePage.FormattingEnabled = true;
            this.comboBoxRolePage.Location = new System.Drawing.Point(478, 4);
            this.comboBoxRolePage.Name = "comboBoxRolePage";
            this.comboBoxRolePage.Size = new System.Drawing.Size(121, 20);
            this.comboBoxRolePage.TabIndex = 0;
            this.comboBoxRolePage.SelectedIndexChanged += new System.EventHandler(this.comboBoxRolePage_SelectedIndexChanged);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 119);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(611, 10);
            this.dividerPanel1.TabIndex = 2;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Controls.Add(this.GrpResult);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 129);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(611, 232);
            this.dividerPanel2.TabIndex = 3;
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
            // backgroundWorkerActive
            // 
            this.backgroundWorkerActive.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerActive_DoWork);
            this.backgroundWorkerActive.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerActive_RunWorkerCompleted);
            // 
            // Frm_SDO_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 371);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.GrpSearch);
            this.Name = "Frm_SDO_Account";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "帐号信息查询[超级舞者]";
            this.Load += new System.EventHandler(this.Frm_SDO_Account_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.GrpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).EndInit();
            this.panelRolePage.ResumeLayout(false);
            this.panelRolePage.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.Button btnBlanketActive;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerActive;
        private System.Windows.Forms.TextBox TxtNickName;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.Button buttonNickName;
        private System.Windows.Forms.DataGridView RoleInfoView;
        private System.Windows.Forms.Panel panelRolePage;
        private System.Windows.Forms.Label labelRolePage;
        private System.Windows.Forms.ComboBox comboBoxRolePage;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}