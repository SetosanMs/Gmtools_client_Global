namespace M_AU
{
    partial class GetHistoryPWD
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
            this.groupBoxOption = new System.Windows.Forms.GroupBox();
            this.radioButtonGame = new System.Windows.Forms.RadioButton();
            this.radioButtonPWD = new System.Windows.Forms.RadioButton();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.LblUser = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.comboBoxGame = new System.Windows.Forms.ComboBox();
            this.GrpSearch.SuspendLayout();
            this.groupBoxOption.SuspendLayout();
            this.GrpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.groupBoxOption);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.LblUser);
            this.GrpSearch.Controls.Add(this.TxtID);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(686, 151);
            this.GrpSearch.TabIndex = 17;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // groupBoxOption
            // 
            this.groupBoxOption.Controls.Add(this.comboBoxGame);
            this.groupBoxOption.Controls.Add(this.radioButtonGame);
            this.groupBoxOption.Controls.Add(this.radioButtonPWD);
            this.groupBoxOption.Location = new System.Drawing.Point(26, 77);
            this.groupBoxOption.Name = "groupBoxOption";
            this.groupBoxOption.Size = new System.Drawing.Size(228, 64);
            this.groupBoxOption.TabIndex = 9;
            this.groupBoxOption.TabStop = false;
            this.groupBoxOption.Text = "选项";
            // 
            // radioButtonGame
            // 
            this.radioButtonGame.AutoSize = true;
            this.radioButtonGame.Location = new System.Drawing.Point(6, 42);
            this.radioButtonGame.Name = "radioButtonGame";
            this.radioButtonGame.Size = new System.Drawing.Size(95, 16);
            this.radioButtonGame.TabIndex = 1;
            this.radioButtonGame.TabStop = true;
            this.radioButtonGame.Text = "已激活的游戏";
            this.radioButtonGame.UseVisualStyleBackColor = true;
            this.radioButtonGame.CheckedChanged += new System.EventHandler(this.radioButtonGame_CheckedChanged);
            // 
            // radioButtonPWD
            // 
            this.radioButtonPWD.AutoSize = true;
            this.radioButtonPWD.Location = new System.Drawing.Point(6, 20);
            this.radioButtonPWD.Name = "radioButtonPWD";
            this.radioButtonPWD.Size = new System.Drawing.Size(71, 16);
            this.radioButtonPWD.TabIndex = 0;
            this.radioButtonPWD.TabStop = true;
            this.radioButtonPWD.Text = "历史密码";
            this.radioButtonPWD.UseVisualStyleBackColor = true;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(179, 44);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 8;
            this.BtnSearch.Text = "查    找";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(24, 31);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(53, 12);
            this.LblUser.TabIndex = 6;
            this.LblUser.Text = "用户名：";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(26, 46);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(121, 21);
            this.TxtID.TabIndex = 3;
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.dgvResult);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 151);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(686, 315);
            this.GrpResult.TabIndex = 18;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "查询结果";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 17);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResult.Size = new System.Drawing.Size(680, 295);
            this.dgvResult.TabIndex = 0;
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // comboBoxGame
            // 
            this.comboBoxGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGame.Enabled = false;
            this.comboBoxGame.FormattingEnabled = true;
            this.comboBoxGame.Location = new System.Drawing.Point(107, 38);
            this.comboBoxGame.Name = "comboBoxGame";
            this.comboBoxGame.Size = new System.Drawing.Size(108, 20);
            this.comboBoxGame.TabIndex = 2;
            // 
            // GetHistoryPWD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 466);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "GetHistoryPWD";
            this.Text = "获取用户历史密码&激活的游戏";
            this.Load += new System.EventHandler(this.GetHistoryPWD_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.groupBoxOption.ResumeLayout(false);
            this.groupBoxOption.PerformLayout();
            this.GrpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.GroupBox groupBoxOption;
        private System.Windows.Forms.RadioButton radioButtonGame;
        private System.Windows.Forms.RadioButton radioButtonPWD;
        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.Windows.Forms.ComboBox comboBoxGame;
    }
}