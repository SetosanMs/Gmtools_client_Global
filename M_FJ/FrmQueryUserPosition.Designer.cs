namespace M_FJ
{
    partial class FrmQueryUserPositionReadOnly
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
            this.TpgItem = new System.Windows.Forms.TabPage();
            this.GrdItemResult = new System.Windows.Forms.DataGridView();
            this.TpgMove = new System.Windows.Forms.TabPage();
            this.BtnQueryMap = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCharname = new System.Windows.Forms.TextBox();
            this.lblCharname = new System.Windows.Forms.Label();
            this.btnMod = new System.Windows.Forms.Button();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.TxtNick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.txtMap = new System.Windows.Forms.ComboBox();
            this.TbcResult.SuspendLayout();
            this.TpgItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdItemResult)).BeginInit();
            this.TpgMove.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbcResult
            // 
            this.TbcResult.Controls.Add(this.TpgItem);
            this.TbcResult.Controls.Add(this.TpgMove);
            this.TbcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcResult.Location = new System.Drawing.Point(0, 147);
            this.TbcResult.Name = "TbcResult";
            this.TbcResult.SelectedIndex = 0;
            this.TbcResult.Size = new System.Drawing.Size(738, 349);
            this.TbcResult.TabIndex = 5;
            // 
            // TpgItem
            // 
            this.TpgItem.Controls.Add(this.GrdItemResult);
            this.TpgItem.Location = new System.Drawing.Point(4, 21);
            this.TpgItem.Name = "TpgItem";
            this.TpgItem.Padding = new System.Windows.Forms.Padding(3);
            this.TpgItem.Size = new System.Drawing.Size(730, 324);
            this.TpgItem.TabIndex = 1;
            this.TpgItem.Text = "玩家信息";
            this.TpgItem.UseVisualStyleBackColor = true;
            // 
            // GrdItemResult
            // 
            this.GrdItemResult.AllowUserToAddRows = false;
            this.GrdItemResult.AllowUserToDeleteRows = false;
            this.GrdItemResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdItemResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdItemResult.Location = new System.Drawing.Point(3, 3);
            this.GrdItemResult.Name = "GrdItemResult";
            this.GrdItemResult.ReadOnly = true;
            this.GrdItemResult.RowTemplate.Height = 23;
            this.GrdItemResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdItemResult.Size = new System.Drawing.Size(724, 318);
            this.GrdItemResult.TabIndex = 6;
            this.GrdItemResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdItemResult_CellDoubleClick);
            // 
            // TpgMove
            // 
            this.TpgMove.Controls.Add(this.txtMap);
            this.TpgMove.Controls.Add(this.label3);
            this.TpgMove.Controls.Add(this.txtZ);
            this.TpgMove.Controls.Add(this.BtnQueryMap);
            this.TpgMove.Controls.Add(this.txtUserID);
            this.TpgMove.Controls.Add(this.lblUserID);
            this.TpgMove.Controls.Add(this.label2);
            this.TpgMove.Controls.Add(this.lblX);
            this.TpgMove.Controls.Add(this.lblY);
            this.TpgMove.Controls.Add(this.txtCharname);
            this.TpgMove.Controls.Add(this.lblCharname);
            this.TpgMove.Controls.Add(this.btnMod);
            this.TpgMove.Controls.Add(this.txtY);
            this.TpgMove.Controls.Add(this.txtX);
            this.TpgMove.Location = new System.Drawing.Point(4, 21);
            this.TpgMove.Name = "TpgMove";
            this.TpgMove.Size = new System.Drawing.Size(730, 324);
            this.TpgMove.TabIndex = 2;
            this.TpgMove.Text = "移动坐标";
            this.TpgMove.UseVisualStyleBackColor = true;
            // 
            // BtnQueryMap
            // 
            this.BtnQueryMap.AutoSize = true;
            this.BtnQueryMap.Location = new System.Drawing.Point(135, 256);
            this.BtnQueryMap.Name = "BtnQueryMap";
            this.BtnQueryMap.Size = new System.Drawing.Size(67, 23);
            this.BtnQueryMap.TabIndex = 24;
            this.BtnQueryMap.Text = "搜索";
            this.BtnQueryMap.UseVisualStyleBackColor = true;
            this.BtnQueryMap.Click += new System.EventHandler(this.BtnQueryMap_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(135, 21);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(162, 21);
            this.txtUserID.TabIndex = 23;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(61, 26);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(35, 12);
            this.lblUserID.TabIndex = 22;
            this.lblUserID.Text = "帐号:";
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "移动地区:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCharname
            // 
            this.txtCharname.Location = new System.Drawing.Point(135, 58);
            this.txtCharname.Name = "txtCharname";
            this.txtCharname.ReadOnly = true;
            this.txtCharname.Size = new System.Drawing.Size(162, 21);
            this.txtCharname.TabIndex = 16;
            // 
            // lblCharname
            // 
            this.lblCharname.AutoSize = true;
            this.lblCharname.Location = new System.Drawing.Point(61, 59);
            this.lblCharname.Name = "lblCharname";
            this.lblCharname.Size = new System.Drawing.Size(47, 12);
            this.lblCharname.TabIndex = 15;
            this.lblCharname.Text = "角色名:";
            this.lblCharname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(230, 256);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(67, 23);
            this.btnMod.TabIndex = 14;
            this.btnMod.Text = "移动";
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
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
            this.GrpSearch.Size = new System.Drawing.Size(738, 147);
            this.GrpSearch.TabIndex = 4;
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
            // backgroundWorkerUpdate
            // 
            this.backgroundWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUpdate_DoWork);
            this.backgroundWorkerUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUpdate_RunWorkerCompleted);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(135, 135);
            this.txtX.Name = "txtX";
            this.txtX.ReadOnly = true;
            this.txtX.Size = new System.Drawing.Size(162, 21);
            this.txtX.TabIndex = 12;
            this.txtX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtX_KeyUp);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(135, 175);
            this.txtY.Name = "txtY";
            this.txtY.ReadOnly = true;
            this.txtY.Size = new System.Drawing.Size(162, 21);
            this.txtY.TabIndex = 13;
            this.txtY.MouseLeave += new System.EventHandler(this.txtY_MouseLeave);
            this.txtY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtY_KeyUp);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(61, 178);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(53, 12);
            this.lblY.TabIndex = 17;
            this.lblY.Text = "Y轴坐标:";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(61, 138);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(53, 12);
            this.lblX.TabIndex = 18;
            this.lblX.Text = "X轴坐标:";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "Z轴坐标:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(135, 210);
            this.txtZ.Name = "txtZ";
            this.txtZ.ReadOnly = true;
            this.txtZ.Size = new System.Drawing.Size(162, 21);
            this.txtZ.TabIndex = 25;
            // 
            // txtMap
            // 
            this.txtMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtMap.FormattingEnabled = true;
            this.txtMap.Location = new System.Drawing.Point(135, 98);
            this.txtMap.Name = "txtMap";
            this.txtMap.Size = new System.Drawing.Size(162, 20);
            this.txtMap.TabIndex = 27;
            this.txtMap.SelectedIndexChanged += new System.EventHandler(this.txtMap_SelectedIndexChanged);
            // 
            // FrmQueryUserPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 496);
            this.Controls.Add(this.TbcResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "FrmQueryUserPosition";
            this.Text = "玩家地图信息";
            this.Load += new System.EventHandler(this.FrmQueryUserPosition_Load);
            this.TbcResult.ResumeLayout(false);
            this.TpgItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdItemResult)).EndInit();
            this.TpgMove.ResumeLayout(false);
            this.TpgMove.PerformLayout();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbcResult;
        private System.Windows.Forms.TabPage TpgItem;
        private System.Windows.Forms.DataGridView GrdItemResult;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.TextBox TxtNick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.Button BtnSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.Windows.Forms.TabPage TpgMove;
        private System.Windows.Forms.TextBox txtCharname;
        private System.Windows.Forms.Label lblCharname;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdate;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Button BtnQueryMap;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.ComboBox txtMap;

    }
}