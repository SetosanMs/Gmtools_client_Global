namespace M_GM
{
    partial class BugHandle
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
            this.groupBoxBugList = new System.Windows.Forms.GroupBox();
            this.GrdResult = new System.Windows.Forms.DataGridView();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.groupBoxSolution = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxSolution = new System.Windows.Forms.TextBox();
            this.labelSolution = new System.Windows.Forms.Label();
            this.textBoxModule = new System.Windows.Forms.TextBox();
            this.labelModule = new System.Windows.Forms.Label();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.labelType = new System.Windows.Forms.Label();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSubmit = new System.ComponentModel.BackgroundWorker();
            this.groupBoxBugList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.PnlPage.SuspendLayout();
            this.groupBoxSolution.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBugList
            // 
            this.groupBoxBugList.Controls.Add(this.GrdResult);
            this.groupBoxBugList.Controls.Add(this.PnlPage);
            this.groupBoxBugList.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxBugList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxBugList.Name = "groupBoxBugList";
            this.groupBoxBugList.Size = new System.Drawing.Size(629, 413);
            this.groupBoxBugList.TabIndex = 0;
            this.groupBoxBugList.TabStop = false;
            this.groupBoxBugList.Text = "问题列表";
            // 
            // GrdResult
            // 
            this.GrdResult.AllowUserToAddRows = false;
            this.GrdResult.AllowUserToDeleteRows = false;
            this.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdResult.Location = new System.Drawing.Point(3, 48);
            this.GrdResult.Name = "GrdResult";
            this.GrdResult.ReadOnly = true;
            this.GrdResult.RowTemplate.Height = 23;
            this.GrdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdResult.Size = new System.Drawing.Size(623, 362);
            this.GrdResult.TabIndex = 10;
            this.GrdResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdResult_CellClick);
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 17);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(623, 31);
            this.PnlPage.TabIndex = 8;
            this.PnlPage.TabStop = true;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(3, 9);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 1;
            this.LblPage.Text = "请选择查看页数：";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(110, 5);
            this.CmbPage.Name = "CmbPage";
            this.CmbPage.Size = new System.Drawing.Size(121, 20);
            this.CmbPage.TabIndex = 0;
            this.CmbPage.SelectedIndexChanged += new System.EventHandler(this.CmbPage_SelectedIndexChanged);
            // 
            // groupBoxSolution
            // 
            this.groupBoxSolution.Controls.Add(this.buttonCancel);
            this.groupBoxSolution.Controls.Add(this.buttonSubmit);
            this.groupBoxSolution.Controls.Add(this.textBoxSolution);
            this.groupBoxSolution.Controls.Add(this.labelSolution);
            this.groupBoxSolution.Controls.Add(this.textBoxModule);
            this.groupBoxSolution.Controls.Add(this.labelModule);
            this.groupBoxSolution.Controls.Add(this.textBoxType);
            this.groupBoxSolution.Controls.Add(this.labelType);
            this.groupBoxSolution.Controls.Add(this.textBoxSubject);
            this.groupBoxSolution.Controls.Add(this.labelSubject);
            this.groupBoxSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSolution.Location = new System.Drawing.Point(0, 413);
            this.groupBoxSolution.Name = "groupBoxSolution";
            this.groupBoxSolution.Size = new System.Drawing.Size(629, 274);
            this.groupBoxSolution.TabIndex = 1;
            this.groupBoxSolution.TabStop = false;
            this.groupBoxSolution.Text = "处理方案";
            this.groupBoxSolution.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancel.Location = new System.Drawing.Point(12, 198);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(55, 26);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Enabled = false;
            this.buttonSubmit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSubmit.Location = new System.Drawing.Point(12, 151);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(55, 26);
            this.buttonSubmit.TabIndex = 10;
            this.buttonSubmit.Text = "提交";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // textBoxSolution
            // 
            this.textBoxSolution.Location = new System.Drawing.Point(139, 96);
            this.textBoxSolution.MaxLength = 1000;
            this.textBoxSolution.Multiline = true;
            this.textBoxSolution.Name = "textBoxSolution";
            this.textBoxSolution.Size = new System.Drawing.Size(441, 128);
            this.textBoxSolution.TabIndex = 9;
            // 
            // labelSolution
            // 
            this.labelSolution.AutoSize = true;
            this.labelSolution.Location = new System.Drawing.Point(137, 81);
            this.labelSolution.Name = "labelSolution";
            this.labelSolution.Size = new System.Drawing.Size(173, 12);
            this.labelSolution.TabIndex = 8;
            this.labelSolution.Text = "处理方案（最多填写1000字）：";
            // 
            // textBoxModule
            // 
            this.textBoxModule.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxModule.ForeColor = System.Drawing.Color.Red;
            this.textBoxModule.Location = new System.Drawing.Point(12, 111);
            this.textBoxModule.MaxLength = 50;
            this.textBoxModule.Name = "textBoxModule";
            this.textBoxModule.ReadOnly = true;
            this.textBoxModule.Size = new System.Drawing.Size(107, 21);
            this.textBoxModule.TabIndex = 7;
            // 
            // labelModule
            // 
            this.labelModule.AutoSize = true;
            this.labelModule.Location = new System.Drawing.Point(12, 95);
            this.labelModule.Name = "labelModule";
            this.labelModule.Size = new System.Drawing.Size(65, 12);
            this.labelModule.TabIndex = 6;
            this.labelModule.Text = "隶属模块：";
            // 
            // textBoxType
            // 
            this.textBoxType.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxType.ForeColor = System.Drawing.Color.Red;
            this.textBoxType.Location = new System.Drawing.Point(12, 57);
            this.textBoxType.MaxLength = 50;
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.ReadOnly = true;
            this.textBoxType.Size = new System.Drawing.Size(107, 21);
            this.textBoxType.TabIndex = 5;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(12, 42);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(65, 12);
            this.labelType.TabIndex = 4;
            this.labelType.Text = "问题分类：";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxSubject.ForeColor = System.Drawing.Color.Red;
            this.textBoxSubject.Location = new System.Drawing.Point(139, 57);
            this.textBoxSubject.MaxLength = 50;
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.ReadOnly = true;
            this.textBoxSubject.Size = new System.Drawing.Size(392, 21);
            this.textBoxSubject.TabIndex = 3;
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(137, 42);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(65, 12);
            this.labelSubject.TabIndex = 2;
            this.labelSubject.Text = "问题主题：";
            // 
            // backgroundWorkerPageChanged
            // 
            this.backgroundWorkerPageChanged.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPageChanged_DoWork);
            this.backgroundWorkerPageChanged.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPageChanged_RunWorkerCompleted);
            // 
            // backgroundWorkerSubmit
            // 
            this.backgroundWorkerSubmit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSubmit_DoWork);
            this.backgroundWorkerSubmit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSubmit_RunWorkerCompleted);
            // 
            // BugHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 687);
            this.Controls.Add(this.groupBoxSolution);
            this.Controls.Add(this.groupBoxBugList);
            this.Name = "BugHandle";
            this.Text = "问题处理";
            this.Load += new System.EventHandler(this.BugHandle_Load);
            this.groupBoxBugList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.groupBoxSolution.ResumeLayout(false);
            this.groupBoxSolution.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBugList;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.DataGridView GrdResult;
        private System.Windows.Forms.GroupBox groupBoxSolution;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelSolution;
        private System.Windows.Forms.TextBox textBoxModule;
        private System.Windows.Forms.Label labelModule;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxSolution;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSubmit;
    }
}