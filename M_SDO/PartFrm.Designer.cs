namespace M_SDO
{
    partial class Frm_SDO_Part
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
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.TbcResult = new System.Windows.Forms.TabControl();
            this.TpgCharacter = new System.Windows.Forms.TabPage();
            this.RoleInfoView = new System.Windows.Forms.DataGridView();
            this.panelRolePage = new System.Windows.Forms.Panel();
            this.labelRolePage = new System.Windows.Forms.Label();
            this.comboBoxRolePage = new System.Windows.Forms.ComboBox();
            this.TpgItem = new System.Windows.Forms.TabPage();
            this.GrdItemResult = new System.Windows.Forms.DataGridView();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerShowItem = new System.ComponentModel.BackgroundWorker();
            this.textBoxNotice = new System.Windows.Forms.TextBox();
            this.GrpSearch.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.TbcResult.SuspendLayout();
            this.TpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            this.panelRolePage.SuspendLayout();
            this.TpgItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdItemResult)).BeginInit();
            this.PnlPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.textBoxNotice);
            this.GrpSearch.Controls.Add(this.TxtNick);
            this.GrpSearch.Controls.Add(this.label1);
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(10, 10);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(631, 147);
            this.GrpSearch.TabIndex = 1;
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
            this.button1.Location = new System.Drawing.Point(186, 59);
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
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(8, 74);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(162, 21);
            this.TxtAccount.TabIndex = 6;
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
            this.BtnSearch.Location = new System.Drawing.Point(186, 29);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(67, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 157);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(631, 10);
            this.dividerPanel1.TabIndex = 3;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Controls.Add(this.TbcResult);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 167);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(631, 228);
            this.dividerPanel2.TabIndex = 4;
            // 
            // TbcResult
            // 
            this.TbcResult.Controls.Add(this.TpgCharacter);
            this.TbcResult.Controls.Add(this.TpgItem);
            this.TbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcResult.Location = new System.Drawing.Point(0, 0);
            this.TbcResult.Name = "TbcResult";
            this.TbcResult.SelectedIndex = 0;
            this.TbcResult.Size = new System.Drawing.Size(631, 228);
            this.TbcResult.TabIndex = 1;
            this.TbcResult.SelectedIndexChanged += new System.EventHandler(this.TbcResult_SelectedIndexChanged);
            // 
            // TpgCharacter
            // 
            this.TpgCharacter.Controls.Add(this.RoleInfoView);
            this.TpgCharacter.Controls.Add(this.panelRolePage);
            this.TpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.TpgCharacter.Name = "TpgCharacter";
            this.TpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCharacter.Size = new System.Drawing.Size(623, 203);
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
            this.RoleInfoView.Location = new System.Drawing.Point(3, 34);
            this.RoleInfoView.Name = "RoleInfoView";
            this.RoleInfoView.ReadOnly = true;
            this.RoleInfoView.RowTemplate.Height = 23;
            this.RoleInfoView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoleInfoView.Size = new System.Drawing.Size(617, 166);
            this.RoleInfoView.TabIndex = 7;
            this.RoleInfoView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleInfoView_CellClick);
            // 
            // panelRolePage
            // 
            this.panelRolePage.Controls.Add(this.labelRolePage);
            this.panelRolePage.Controls.Add(this.comboBoxRolePage);
            this.panelRolePage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRolePage.Location = new System.Drawing.Point(3, 3);
            this.panelRolePage.Name = "panelRolePage";
            this.panelRolePage.Size = new System.Drawing.Size(617, 31);
            this.panelRolePage.TabIndex = 6;
            this.panelRolePage.TabStop = true;
            this.panelRolePage.Visible = false;
            // 
            // labelRolePage
            // 
            this.labelRolePage.AutoSize = true;
            this.labelRolePage.Location = new System.Drawing.Point(385, 9);
            this.labelRolePage.Name = "labelRolePage";
            this.labelRolePage.Size = new System.Drawing.Size(101, 12);
            this.labelRolePage.TabIndex = 1;
            this.labelRolePage.Text = "请选择查看页数：";
            // 
            // comboBoxRolePage
            // 
            this.comboBoxRolePage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRolePage.FormattingEnabled = true;
            this.comboBoxRolePage.Location = new System.Drawing.Point(492, 5);
            this.comboBoxRolePage.Name = "comboBoxRolePage";
            this.comboBoxRolePage.Size = new System.Drawing.Size(121, 20);
            this.comboBoxRolePage.TabIndex = 0;
            this.comboBoxRolePage.SelectedIndexChanged += new System.EventHandler(this.comboBoxRolePage_SelectedIndexChanged);
            // 
            // TpgItem
            // 
            this.TpgItem.Controls.Add(this.GrdItemResult);
            this.TpgItem.Controls.Add(this.PnlPage);
            this.TpgItem.Location = new System.Drawing.Point(4, 21);
            this.TpgItem.Name = "TpgItem";
            this.TpgItem.Padding = new System.Windows.Forms.Padding(3);
            this.TpgItem.Size = new System.Drawing.Size(623, 203);
            this.TpgItem.TabIndex = 1;
            this.TpgItem.Text = "物品信息";
            this.TpgItem.UseVisualStyleBackColor = true;
            // 
            // GrdItemResult
            // 
            this.GrdItemResult.AllowUserToAddRows = false;
            this.GrdItemResult.AllowUserToDeleteRows = false;
            this.GrdItemResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdItemResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdItemResult.Location = new System.Drawing.Point(3, 34);
            this.GrdItemResult.Name = "GrdItemResult";
            this.GrdItemResult.ReadOnly = true;
            this.GrdItemResult.RowTemplate.Height = 23;
            this.GrdItemResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdItemResult.Size = new System.Drawing.Size(617, 166);
            this.GrdItemResult.TabIndex = 6;
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 3);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(617, 31);
            this.PnlPage.TabIndex = 5;
            this.PnlPage.TabStop = true;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(394, 9);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 1;
            this.LblPage.Text = "请选择查看页数：";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(501, 5);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(121, 20);
            this.CmbPage.TabIndex = 0;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
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
            // backgroundWorkerShowItem
            // 
            this.backgroundWorkerShowItem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerShowItem_DoWork);
            this.backgroundWorkerShowItem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerShowItem_RunWorkerCompleted);
            // 
            // textBoxNotice
            // 
            this.textBoxNotice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNotice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxNotice.Location = new System.Drawing.Point(273, 23);
            this.textBoxNotice.Multiline = true;
            this.textBoxNotice.Name = "textBoxNotice";
            this.textBoxNotice.ReadOnly = true;
            this.textBoxNotice.Size = new System.Drawing.Size(189, 58);
            this.textBoxNotice.TabIndex = 12;
            this.textBoxNotice.Text = "提示：\r\n要查看用户物品信息，请先单击该用户角色信息\r\n记录。";
            // 
            // Frm_SDO_Part
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 405);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.GrpSearch);
            this.Name = "Frm_SDO_Part";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "玩家角色信息[超级舞者]";
            this.Load += new System.EventHandler(this.Frm_SDO_Part_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.TbcResult.ResumeLayout(false);
            this.TpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).EndInit();
            this.panelRolePage.ResumeLayout(false);
            this.panelRolePage.PerformLayout();
            this.TpgItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdItemResult)).EndInit();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtNick;
        private System.Windows.Forms.Label label1;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.TabControl TbcResult;
        private System.Windows.Forms.TabPage TpgCharacter;
        private System.Windows.Forms.TabPage TpgItem;
        private System.Windows.Forms.DataGridView GrdItemResult;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.Windows.Forms.Panel panelRolePage;
        private System.Windows.Forms.Label labelRolePage;
        private System.Windows.Forms.ComboBox comboBoxRolePage;
        private System.Windows.Forms.DataGridView RoleInfoView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerShowItem;
        private System.Windows.Forms.TextBox textBoxNotice;
    }
}