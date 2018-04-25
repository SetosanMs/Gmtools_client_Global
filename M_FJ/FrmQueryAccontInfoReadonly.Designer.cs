namespace M_FJ
{
    partial class FrmQueryAccontInfo
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
            this.TbcResult = new System.Windows.Forms.TabControl();
            this.TpgCharacter = new System.Windows.Forms.TabPage();
            this.RoleInfoView = new System.Windows.Forms.DataGridView();
            this.TpgItem = new System.Windows.Forms.TabPage();
            this.GrdItemResult = new System.Windows.Forms.DataGridView();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMessage = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbWareHouse = new System.Windows.Forms.ComboBox();
            this.tabshortcut = new System.Windows.Forms.TabPage();
            this.DataShortcut = new System.Windows.Forms.DataGridView();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.TxtNick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerItemShopQuery = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerMessage_Query = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerWareHouse_Query = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerGuildQuery = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRelationQuery = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSkillQuery = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerModifyRoleInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerShortCut = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.TbcResult.SuspendLayout();
            this.TpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            this.TpgItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdItemResult)).BeginInit();
            this.PnlPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabshortcut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataShortcut)).BeginInit();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbcResult
            // 
            this.TbcResult.Controls.Add(this.TpgCharacter);
            this.TbcResult.Controls.Add(this.TpgItem);
            this.TbcResult.Controls.Add(this.tabPage1);
            this.TbcResult.Controls.Add(this.tabPage2);
            this.TbcResult.Controls.Add(this.tabshortcut);
            this.TbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcResult.Location = new System.Drawing.Point(0, 147);
            this.TbcResult.Name = "TbcResult";
            this.TbcResult.SelectedIndex = 0;
            this.TbcResult.Size = new System.Drawing.Size(1016, 338);
            this.TbcResult.TabIndex = 3;
            this.TbcResult.Selected += new System.Windows.Forms.TabControlEventHandler(this.TbcResult_Selected);
            // 
            // TpgCharacter
            // 
            this.TpgCharacter.Controls.Add(this.RoleInfoView);
            this.TpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.TpgCharacter.Name = "TpgCharacter";
            this.TpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCharacter.Size = new System.Drawing.Size(1008, 313);
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
            this.RoleInfoView.Size = new System.Drawing.Size(1002, 307);
            this.RoleInfoView.TabIndex = 7;
            this.RoleInfoView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleInfoView_CellClick);
            this.RoleInfoView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleInfoView_CellDoubleClick);
            this.RoleInfoView.DataSourceChanged += new System.EventHandler(this.RoleInfoView_DataSourceChanged);
            // 
            // TpgItem
            // 
            this.TpgItem.Controls.Add(this.GrdItemResult);
            this.TpgItem.Controls.Add(this.PnlPage);
            this.TpgItem.Location = new System.Drawing.Point(4, 21);
            this.TpgItem.Name = "TpgItem";
            this.TpgItem.Padding = new System.Windows.Forms.Padding(3);
            this.TpgItem.Size = new System.Drawing.Size(1008, 313);
            this.TpgItem.TabIndex = 1;
            this.TpgItem.Text = "身上道具";
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
            this.GrdItemResult.Size = new System.Drawing.Size(1002, 276);
            this.GrdItemResult.TabIndex = 6;
            this.GrdItemResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdItemResult_CellDoubleClick);
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 3);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(1002, 31);
            this.PnlPage.TabIndex = 5;
            this.PnlPage.TabStop = true;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(5, 11);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 1;
            this.LblPage.Text = "请选择查看页数：";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(112, 7);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(121, 20);
            this.CmbPage.TabIndex = 0;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1008, 313);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "礼物盒道具";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 282);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 31);
            this.panel1.TabIndex = 8;
            this.panel1.TabStop = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请选择查看页数：";
            // 
            // cboMessage
            // 
            this.cboMessage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessage.FormattingEnabled = true;
            this.cboMessage.Location = new System.Drawing.Point(121, 6);
            this.cboMessage.Name = "cboMessage";
            this.cboMessage.Size = new System.Drawing.Size(121, 20);
            this.cboMessage.TabIndex = 0;
            this.cboMessage.SelectedIndexChanged += new System.EventHandler(this.cboMessage_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1008, 313);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "仓库道具";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 31);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1008, 282);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cmbWareHouse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 31);
            this.panel2.TabIndex = 9;
            this.panel2.TabStop = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "请选择查看页数：";
            // 
            // cmbWareHouse
            // 
            this.cmbWareHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWareHouse.FormattingEnabled = true;
            this.cmbWareHouse.Location = new System.Drawing.Point(121, 6);
            this.cmbWareHouse.Name = "cmbWareHouse";
            this.cmbWareHouse.Size = new System.Drawing.Size(121, 20);
            this.cmbWareHouse.TabIndex = 0;
            this.cmbWareHouse.SelectedIndexChanged += new System.EventHandler(this.cmbWareHouse_SelectedIndexChanged);
            // 
            // tabshortcut
            // 
            this.tabshortcut.Controls.Add(this.DataShortcut);
            this.tabshortcut.Location = new System.Drawing.Point(4, 21);
            this.tabshortcut.Name = "tabshortcut";
            this.tabshortcut.Size = new System.Drawing.Size(1008, 313);
            this.tabshortcut.TabIndex = 8;
            this.tabshortcut.Text = "快捷栏";
            this.tabshortcut.UseVisualStyleBackColor = true;
            // 
            // DataShortcut
            // 
            this.DataShortcut.AllowUserToAddRows = false;
            this.DataShortcut.AllowUserToDeleteRows = false;
            this.DataShortcut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataShortcut.Location = new System.Drawing.Point(0, 0);
            this.DataShortcut.Name = "DataShortcut";
            this.DataShortcut.ReadOnly = true;
            this.DataShortcut.RowTemplate.Height = 23;
            this.DataShortcut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataShortcut.Size = new System.Drawing.Size(1008, 313);
            this.DataShortcut.TabIndex = 9;
            this.DataShortcut.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataShortcut_CellDoubleClick);
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.TxtNick);
            this.GrpSearch.Controls.Add(this.label1);
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Controls.Add(this.TxtAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(1016, 147);
            this.GrpSearch.TabIndex = 2;
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
            // backgroundWorkerItemShopQuery
            // 
            this.backgroundWorkerItemShopQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerItemShopQuery_DoWork);
            this.backgroundWorkerItemShopQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerItemShopQuery_RunWorkerCompleted);
            // 
            // backgroundWorkerMessage_Query
            // 
            this.backgroundWorkerMessage_Query.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMessage_Query_DoWork);
            this.backgroundWorkerMessage_Query.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMessage_Query_RunWorkerCompleted);
            // 
            // backgroundWorkerWareHouse_Query
            // 
            this.backgroundWorkerWareHouse_Query.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerWareHouse_Query_DoWork);
            this.backgroundWorkerWareHouse_Query.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerWareHouse_Query_RunWorkerCompleted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "请选择查看页数：";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(121, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // backgroundWorkerGuildQuery
            // 
            this.backgroundWorkerGuildQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGuildQuery_DoWork);
            this.backgroundWorkerGuildQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerGuildQuery_RunWorkerCompleted);
            // 
            // backgroundWorkerRelationQuery
            // 
            //this.backgroundWorkerRelationQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRelationQuery_DoWork);
            //this.backgroundWorkerRelationQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRelationQuery_RunWorkerCompleted);
            // 
            // backgroundWorkerSkillQuery
            // 
            //this.backgroundWorkerSkillQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSkillQuery_DoWork);
            //this.backgroundWorkerSkillQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSkillQuery_RunWorkerCompleted);
            // 
            // backgroundWorkerModifyRoleInfo
            // 
            ////this.backgroundWorkerModifyRoleInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerModifyRoleInfo_DoWork);
            //this.backgroundWorkerModifyRoleInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerModifyRoleInfo_RunWorkerCompleted);
            // 
            // backgroundWorkerShortCut
            // 
            this.backgroundWorkerShortCut.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerShortCut_DoWork);
            this.backgroundWorkerShortCut.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerShortCut_RunWorkerCompleted);
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
            // FrmQueryAccontInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 485);
            this.Controls.Add(this.TbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmQueryAccontInfo";
            this.Text = "只读玩家帐号信息";
            this.Load += new System.EventHandler(this.FrmQueryAccontInfo_Load);
            this.TbcResult.ResumeLayout(false);
            this.TpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).EndInit();
            this.TpgItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdItemResult)).EndInit();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabshortcut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataShortcut)).EndInit();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbcResult;
        private System.Windows.Forms.TabPage TpgCharacter;
        private System.Windows.Forms.DataGridView RoleInfoView;
        private System.Windows.Forms.TabPage TpgItem;
        private System.Windows.Forms.DataGridView GrdItemResult;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.TextBox TxtNick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerItemShopQuery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMessage_Query;
        private System.ComponentModel.BackgroundWorker backgroundWorkerWareHouse_Query;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMessage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbWareHouse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGuildQuery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRelationQuery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSkillQuery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerModifyRoleInfo;
        private System.Windows.Forms.TabPage tabshortcut;
        private System.ComponentModel.BackgroundWorker backgroundWorkerShortCut;
        private System.Windows.Forms.DataGridView DataShortcut;
        private System.Windows.Forms.Button button1;
    }
}

