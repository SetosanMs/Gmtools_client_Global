namespace M_FJ
{
    partial class FrmMissionQuery
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
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.TxtNick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TbcResult = new System.Windows.Forms.TabControl();
            this.TpgCharacter = new System.Windows.Forms.TabPage();
            this.RoleInfoView = new System.Windows.Forms.DataGridView();
            this.TpcMission = new System.Windows.Forms.TabPage();
            this.dgvMission = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerMissionQuery = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.GrpSearch.SuspendLayout();
            this.TbcResult.SuspendLayout();
            this.TpgCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).BeginInit();
            this.TpcMission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMission)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.label2);
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
            this.GrpSearch.Size = new System.Drawing.Size(729, 147);
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
            this.button1.Location = new System.Drawing.Point(186, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
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
            // TbcResult
            // 
            this.TbcResult.Controls.Add(this.TpgCharacter);
            this.TbcResult.Controls.Add(this.TpcMission);
            this.TbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcResult.Location = new System.Drawing.Point(0, 147);
            this.TbcResult.Name = "TbcResult";
            this.TbcResult.SelectedIndex = 0;
            this.TbcResult.Size = new System.Drawing.Size(729, 312);
            this.TbcResult.TabIndex = 4;
            // 
            // TpgCharacter
            // 
            this.TpgCharacter.Controls.Add(this.RoleInfoView);
            this.TpgCharacter.Location = new System.Drawing.Point(4, 21);
            this.TpgCharacter.Name = "TpgCharacter";
            this.TpgCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.TpgCharacter.Size = new System.Drawing.Size(721, 287);
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
            this.RoleInfoView.Size = new System.Drawing.Size(715, 281);
            this.RoleInfoView.TabIndex = 7;
            this.RoleInfoView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleInfoView_CellDoubleClick);
            this.RoleInfoView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleInfoView_CellContentDoubleClick);
            // 
            // TpcMission
            // 
            this.TpcMission.Controls.Add(this.dgvMission);
            this.TpcMission.Location = new System.Drawing.Point(4, 21);
            this.TpcMission.Name = "TpcMission";
            this.TpcMission.Size = new System.Drawing.Size(721, 287);
            this.TpcMission.TabIndex = 1;
            this.TpcMission.Text = "任务信息";
            this.TpcMission.UseVisualStyleBackColor = true;
            // 
            // dgvMission
            // 
            this.dgvMission.AllowUserToAddRows = false;
            this.dgvMission.AllowUserToDeleteRows = false;
            this.dgvMission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMission.Location = new System.Drawing.Point(0, 0);
            this.dgvMission.MultiSelect = false;
            this.dgvMission.Name = "dgvMission";
            this.dgvMission.ReadOnly = true;
            this.dgvMission.RowTemplate.Height = 23;
            this.dgvMission.Size = new System.Drawing.Size(721, 287);
            this.dgvMission.TabIndex = 12;
            this.dgvMission.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMission_CellClick);
            this.dgvMission.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMission_CellDoubleClick);
            this.dgvMission.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMission_CellContentDoubleClick);
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
            // backgroundWorkerMissionQuery
            // 
            this.backgroundWorkerMissionQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMissionQuery_DoWork);
            this.backgroundWorkerMissionQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMissionQuery_RunWorkerCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "提示：要查询角色当前任务请双击其所在的单元行";
            // 
            // FrmMissionQuery
            // 
            this.AcceptButton = this.BtnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 459);
            this.Controls.Add(this.TbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmMissionQuery";
            this.Text = "任务状态修改";
            this.Load += new System.EventHandler(this.FrmMissionQuery_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.TbcResult.ResumeLayout(false);
            this.TpgCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleInfoView)).EndInit();
            this.TpcMission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMission)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.TextBox TxtNick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TabControl TbcResult;
        private System.Windows.Forms.TabPage TpgCharacter;
        private System.Windows.Forms.DataGridView RoleInfoView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.Windows.Forms.TabPage TpcMission;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMissionQuery;
        private System.Windows.Forms.DataGridView dgvMission;
        private System.Windows.Forms.Label label2;
    }
}