namespace M_Audition
{
    partial class QueryCardInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.TpgResult = new System.Windows.Forms.TabControl();
            this.tabPageList = new System.Windows.Forms.TabPage();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.tabPageErr = new System.Windows.Forms.TabPage();
            this.dataGridViewError = new System.Windows.Forms.DataGridView();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.labelProcess = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.checkBoxBat = new System.Windows.Forms.CheckBox();
            this.buttonSaveAS = new System.Windows.Forms.Button();
            this.txtcardnum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LblCardnum = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtPwd = new System.Windows.Forms.TextBox();
            this.LblPwd = new System.Windows.Forms.Label();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dividerPanel2.SuspendLayout();
            this.GrpResult.SuspendLayout();
            this.TpgResult.SuspendLayout();
            this.tabPageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.tabPageErr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewError)).BeginInit();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Controls.Add(this.GrpResult);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel2.Location = new System.Drawing.Point(0, 200);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(701, 295);
            this.dividerPanel2.TabIndex = 6;
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.TpgResult);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(0, 0);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(701, 295);
            this.GrpResult.TabIndex = 1;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "搜索结果";
            // 
            // TpgResult
            // 
            this.TpgResult.Controls.Add(this.tabPageList);
            this.TpgResult.Controls.Add(this.tabPageErr);
            this.TpgResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TpgResult.Location = new System.Drawing.Point(3, 17);
            this.TpgResult.Name = "TpgResult";
            this.TpgResult.SelectedIndex = 0;
            this.TpgResult.Size = new System.Drawing.Size(695, 275);
            this.TpgResult.TabIndex = 0;
            // 
            // tabPageList
            // 
            this.tabPageList.Controls.Add(this.dataGridViewResult);
            this.tabPageList.Location = new System.Drawing.Point(4, 21);
            this.tabPageList.Name = "tabPageList";
            this.tabPageList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageList.Size = new System.Drawing.Size(687, 250);
            this.tabPageList.TabIndex = 0;
            this.tabPageList.Text = "列表";
            this.tabPageList.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.AllowUserToAddRows = false;
            this.dataGridViewResult.AllowUserToDeleteRows = false;
            this.dataGridViewResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewResult.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.ReadOnly = true;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewResult.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewResult.RowTemplate.Height = 23;
            this.dataGridViewResult.Size = new System.Drawing.Size(681, 244);
            this.dataGridViewResult.TabIndex = 1;
            // 
            // tabPageErr
            // 
            this.tabPageErr.Controls.Add(this.dataGridViewError);
            this.tabPageErr.Location = new System.Drawing.Point(4, 21);
            this.tabPageErr.Name = "tabPageErr";
            this.tabPageErr.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageErr.Size = new System.Drawing.Size(687, 250);
            this.tabPageErr.TabIndex = 1;
            this.tabPageErr.Text = "错误列表";
            this.tabPageErr.UseVisualStyleBackColor = true;
            // 
            // dataGridViewError
            // 
            this.dataGridViewError.AllowUserToAddRows = false;
            this.dataGridViewError.AllowUserToDeleteRows = false;
            this.dataGridViewError.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewError.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewError.Name = "dataGridViewError";
            this.dataGridViewError.ReadOnly = true;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewError.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewError.RowTemplate.Height = 23;
            this.dataGridViewError.Size = new System.Drawing.Size(681, 244);
            this.dataGridViewError.TabIndex = 0;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 190);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(701, 10);
            this.dividerPanel1.TabIndex = 5;
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.labelProcess);
            this.GrpSearch.Controls.Add(this.progressBar1);
            this.GrpSearch.Controls.Add(this.buttonBrowse);
            this.GrpSearch.Controls.Add(this.textBoxPath);
            this.GrpSearch.Controls.Add(this.labelPath);
            this.GrpSearch.Controls.Add(this.checkBoxBat);
            this.GrpSearch.Controls.Add(this.buttonSaveAS);
            this.GrpSearch.Controls.Add(this.txtcardnum);
            this.GrpSearch.Controls.Add(this.button1);
            this.GrpSearch.Controls.Add(this.LblCardnum);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.TxtPwd);
            this.GrpSearch.Controls.Add(this.LblPwd);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(0, 0);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(701, 190);
            this.GrpSearch.TabIndex = 4;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "搜索条件";
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelProcess.Location = new System.Drawing.Point(483, 127);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(65, 12);
            this.labelProcess.TabIndex = 19;
            this.labelProcess.Text = "完成进度：";
            this.labelProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(485, 142);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(197, 13);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 18;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Enabled = false;
            this.buttonBrowse.Location = new System.Drawing.Point(343, 136);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 17;
            this.buttonBrowse.Text = "浏览";
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Enabled = false;
            this.textBoxPath.Location = new System.Drawing.Point(114, 138);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(197, 21);
            this.textBoxPath.TabIndex = 16;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPath.Location = new System.Drawing.Point(49, 141);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(65, 12);
            this.labelPath.TabIndex = 15;
            this.labelPath.Text = "文件路径：";
            this.labelPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxBat
            // 
            this.checkBoxBat.AutoSize = true;
            this.checkBoxBat.Location = new System.Drawing.Point(69, 108);
            this.checkBoxBat.Name = "checkBoxBat";
            this.checkBoxBat.Size = new System.Drawing.Size(96, 16);
            this.checkBoxBat.TabIndex = 14;
            this.checkBoxBat.Text = "是否批量导入";
            this.checkBoxBat.UseVisualStyleBackColor = true;
            this.checkBoxBat.CheckedChanged += new System.EventHandler(this.checkBoxBat_CheckedChanged);
            // 
            // buttonSaveAS
            // 
            this.buttonSaveAS.Enabled = false;
            this.buttonSaveAS.Location = new System.Drawing.Point(485, 32);
            this.buttonSaveAS.Name = "buttonSaveAS";
            this.buttonSaveAS.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAS.TabIndex = 13;
            this.buttonSaveAS.Text = "另存文本";
            this.buttonSaveAS.Click += new System.EventHandler(this.buttonSaveAS_Click);
            // 
            // txtcardnum
            // 
            this.txtcardnum.Location = new System.Drawing.Point(114, 32);
            this.txtcardnum.Name = "txtcardnum";
            this.txtcardnum.Size = new System.Drawing.Size(197, 21);
            this.txtcardnum.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblCardnum
            // 
            this.LblCardnum.AutoSize = true;
            this.LblCardnum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCardnum.Location = new System.Drawing.Point(67, 35);
            this.LblCardnum.Name = "LblCardnum";
            this.LblCardnum.Size = new System.Drawing.Size(41, 12);
            this.LblCardnum.TabIndex = 7;
            this.LblCardnum.Text = "卡号：";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(343, 32);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "搜索";
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtPwd
            // 
            this.TxtPwd.Location = new System.Drawing.Point(114, 69);
            this.TxtPwd.Name = "TxtPwd";
            this.TxtPwd.Size = new System.Drawing.Size(197, 21);
            this.TxtPwd.TabIndex = 6;
            // 
            // LblPwd
            // 
            this.LblPwd.AutoSize = true;
            this.LblPwd.Location = new System.Drawing.Point(67, 72);
            this.LblPwd.Name = "LblPwd";
            this.LblPwd.Size = new System.Drawing.Size(41, 12);
            this.LblPwd.TabIndex = 5;
            this.LblPwd.Text = "密码：";
            this.LblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.WorkerReportsProgress = true;
            this.backgroundWorkerSearch.WorkerSupportsCancellation = true;
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            this.backgroundWorkerSearch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSearch_ProgressChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "文本文件|*.txt";
            // 
            // QueryCardInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 495);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.GrpSearch);
            this.Name = "QueryCardInfo";
            this.Text = "点卡查询记录";
            this.Load += new System.EventHandler(this.QueryCardInfo_Load);
            this.dividerPanel2.ResumeLayout(false);
            this.GrpResult.ResumeLayout(false);
            this.TpgResult.ResumeLayout(false);
            this.tabPageList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.tabPageErr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewError)).EndInit();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.GroupBox GrpResult;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblCardnum;
        private System.Windows.Forms.TextBox TxtPwd;
        private System.Windows.Forms.Label LblPwd;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox txtcardnum;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.Windows.Forms.Button buttonSaveAS;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.CheckBox checkBoxBat;
        private System.Windows.Forms.TabControl TpgResult;
        private System.Windows.Forms.TabPage tabPageList;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.TabPage tabPageErr;
        private System.Windows.Forms.DataGridView dataGridViewError;
        private System.Windows.Forms.Label labelProcess;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonBrowse;
    }
}