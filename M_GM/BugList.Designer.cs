namespace M_GM
{
    partial class BugList
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
            this.groupBoxBugInfo = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.labelContent = new System.Windows.Forms.Label();
            this.comboBoxModule = new System.Windows.Forms.ComboBox();
            this.labelModule = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.groupBoxBugView = new System.Windows.Forms.GroupBox();
            this.GrdResult = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSubmit = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerModify = new System.ComponentModel.BackgroundWorker();
            this.groupBoxBugInfo.SuspendLayout();
            this.groupBoxBugView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.PnlPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBugInfo
            // 
            this.groupBoxBugInfo.Controls.Add(this.buttonCancel);
            this.groupBoxBugInfo.Controls.Add(this.buttonModify);
            this.groupBoxBugInfo.Controls.Add(this.buttonReset);
            this.groupBoxBugInfo.Controls.Add(this.buttonSubmit);
            this.groupBoxBugInfo.Controls.Add(this.textBoxContent);
            this.groupBoxBugInfo.Controls.Add(this.labelContent);
            this.groupBoxBugInfo.Controls.Add(this.comboBoxModule);
            this.groupBoxBugInfo.Controls.Add(this.labelModule);
            this.groupBoxBugInfo.Controls.Add(this.comboBoxType);
            this.groupBoxBugInfo.Controls.Add(this.labelType);
            this.groupBoxBugInfo.Controls.Add(this.textBoxSubject);
            this.groupBoxBugInfo.Controls.Add(this.labelSubject);
            this.groupBoxBugInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxBugInfo.Location = new System.Drawing.Point(0, 0);
            this.groupBoxBugInfo.Name = "groupBoxBugInfo";
            this.groupBoxBugInfo.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxBugInfo.Size = new System.Drawing.Size(609, 266);
            this.groupBoxBugInfo.TabIndex = 0;
            this.groupBoxBugInfo.TabStop = false;
            this.groupBoxBugInfo.Text = "填写问题";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancel.Location = new System.Drawing.Point(13, 184);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(59, 32);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonModify.Location = new System.Drawing.Point(13, 131);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(59, 32);
            this.buttonModify.TabIndex = 10;
            this.buttonModify.Text = "修改";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Visible = false;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonReset.Location = new System.Drawing.Point(13, 184);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(59, 32);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "重置";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSubmit.Location = new System.Drawing.Point(13, 131);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(59, 32);
            this.buttonSubmit.TabIndex = 8;
            this.buttonSubmit.Text = "提交";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // textBoxContent
            // 
            this.textBoxContent.Location = new System.Drawing.Point(149, 87);
            this.textBoxContent.MaxLength = 500;
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(388, 152);
            this.textBoxContent.TabIndex = 7;
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(147, 72);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(167, 12);
            this.labelContent.TabIndex = 6;
            this.labelContent.Text = "问题内容：（最多填写500字）";
            // 
            // comboBoxModule
            // 
            this.comboBoxModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModule.FormattingEnabled = true;
            this.comboBoxModule.Location = new System.Drawing.Point(13, 87);
            this.comboBoxModule.Name = "comboBoxModule";
            this.comboBoxModule.Size = new System.Drawing.Size(103, 20);
            this.comboBoxModule.TabIndex = 5;
            // 
            // labelModule
            // 
            this.labelModule.AutoSize = true;
            this.labelModule.Location = new System.Drawing.Point(11, 72);
            this.labelModule.Name = "labelModule";
            this.labelModule.Size = new System.Drawing.Size(65, 12);
            this.labelModule.TabIndex = 4;
            this.labelModule.Text = "隶属模块：";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(13, 39);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(103, 20);
            this.comboBoxType.TabIndex = 3;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(11, 24);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(65, 12);
            this.labelType.TabIndex = 2;
            this.labelType.Text = "问题分类：";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(149, 38);
            this.textBoxSubject.MaxLength = 50;
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(329, 21);
            this.textBoxSubject.TabIndex = 1;
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(147, 23);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(65, 12);
            this.labelSubject.TabIndex = 0;
            this.labelSubject.Text = "问题主题：";
            // 
            // groupBoxBugView
            // 
            this.groupBoxBugView.Controls.Add(this.GrdResult);
            this.groupBoxBugView.Controls.Add(this.PnlPage);
            this.groupBoxBugView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxBugView.Location = new System.Drawing.Point(0, 266);
            this.groupBoxBugView.Name = "groupBoxBugView";
            this.groupBoxBugView.Size = new System.Drawing.Size(609, 194);
            this.groupBoxBugView.TabIndex = 1;
            this.groupBoxBugView.TabStop = false;
            this.groupBoxBugView.Text = "问题列表";
            // 
            // GrdResult
            // 
            this.GrdResult.AllowUserToAddRows = false;
            this.GrdResult.AllowUserToDeleteRows = false;
            this.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdResult.ContextMenuStrip = this.contextMenuStrip;
            this.GrdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdResult.Location = new System.Drawing.Point(3, 48);
            this.GrdResult.Name = "GrdResult";
            this.GrdResult.ReadOnly = true;
            this.GrdResult.RowTemplate.Height = 23;
            this.GrdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdResult.Size = new System.Drawing.Size(603, 143);
            this.GrdResult.TabIndex = 9;
            this.GrdResult.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GrdResult_CellMouseDown);
            this.GrdResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdResult_CellClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemEdit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(123, 26);
            // 
            // ToolStripMenuItemEdit
            // 
            this.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            this.ToolStripMenuItemEdit.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuItemEdit.Text = "修改问题";
            this.ToolStripMenuItemEdit.Click += new System.EventHandler(this.ToolStripMenuItemEdit_Click);
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 17);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(603, 31);
            this.PnlPage.TabIndex = 7;
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
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
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
            // backgroundWorkerModify
            // 
            this.backgroundWorkerModify.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerModify_DoWork);
            this.backgroundWorkerModify.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerModify_RunWorkerCompleted);
            // 
            // BugList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(609, 460);
            this.Controls.Add(this.groupBoxBugView);
            this.Controls.Add(this.groupBoxBugInfo);
            this.Name = "BugList";
            this.Text = "问题提交";
            this.Load += new System.EventHandler(this.BugList_Load);
            this.groupBoxBugInfo.ResumeLayout(false);
            this.groupBoxBugInfo.PerformLayout();
            this.groupBoxBugView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBugInfo;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.ComboBox comboBoxModule;
        private System.Windows.Forms.Label labelModule;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.GroupBox groupBoxBugView;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.DataGridView GrdResult;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSubmit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEdit;
        private System.Windows.Forms.Button buttonModify;
        private System.ComponentModel.BackgroundWorker backgroundWorkerModify;
        private System.Windows.Forms.Button buttonCancel;
    }
}