namespace M_AU
{
    partial class FrmHistory
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
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblSearchDate = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpStop = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.grvResult = new System.Windows.Forms.DataGridView();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblMust01 = new System.Windows.Forms.Label();
            this.bwSearch = new System.ComponentModel.BackgroundWorker();
            this.grpSearch.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.lblMust01);
            this.grpSearch.Controls.Add(this.txtIP);
            this.grpSearch.Controls.Add(this.lblIP);
            this.grpSearch.Controls.Add(this.btnCancle);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.dtpStop);
            this.grpSearch.Controls.Add(this.lblTo);
            this.grpSearch.Controls.Add(this.dtpStart);
            this.grpSearch.Controls.Add(this.lblSearchDate);
            this.grpSearch.Controls.Add(this.txtUserName);
            this.grpSearch.Controls.Add(this.lblUserName);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Location = new System.Drawing.Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(713, 82);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "查询条件：";
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.grvResult);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(0, 82);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(713, 300);
            this.grpResult.TabIndex = 1;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "查询结果：";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(29, 26);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(65, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用 户 名：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(100, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(101, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // lblSearchDate
            // 
            this.lblSearchDate.AutoSize = true;
            this.lblSearchDate.Location = new System.Drawing.Point(29, 53);
            this.lblSearchDate.Name = "lblSearchDate";
            this.lblSearchDate.Size = new System.Drawing.Size(65, 12);
            this.lblSearchDate.TabIndex = 2;
            this.lblSearchDate.Text = "时间范围：";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(100, 49);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(131, 21);
            this.dtpStart.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(244, 53);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(11, 12);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "-";
            // 
            // dtpStop
            // 
            this.dtpStop.Location = new System.Drawing.Point(268, 49);
            this.dtpStop.Name = "dtpStop";
            this.dtpStop.Size = new System.Drawing.Size(131, 21);
            this.dtpStop.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(587, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(587, 46);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "取　消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // grvResult
            // 
            this.grvResult.AllowUserToAddRows = false;
            this.grvResult.AllowUserToDeleteRows = false;
            this.grvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvResult.Location = new System.Drawing.Point(3, 17);
            this.grvResult.Name = "grvResult";
            this.grvResult.ReadOnly = true;
            this.grvResult.RowTemplate.Height = 23;
            this.grvResult.Size = new System.Drawing.Size(707, 280);
            this.grvResult.TabIndex = 0;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(238, 26);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(23, 12);
            this.lblIP.TabIndex = 8;
            this.lblIP.Text = "IP:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(268, 22);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(131, 21);
            this.txtIP.TabIndex = 9;
            // 
            // lblMust01
            // 
            this.lblMust01.AutoSize = true;
            this.lblMust01.ForeColor = System.Drawing.Color.Red;
            this.lblMust01.Location = new System.Drawing.Point(208, 26);
            this.lblMust01.Name = "lblMust01";
            this.lblMust01.Size = new System.Drawing.Size(11, 12);
            this.lblMust01.TabIndex = 10;
            this.lblMust01.Text = "*";
            // 
            // bwSearch
            // 
            this.bwSearch.WorkerSupportsCancellation = true;
            this.bwSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSearch_DoWork);
            this.bwSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSearch_RunWorkerCompleted);
            // 
            // FrmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 382);
            this.Controls.Add(this.grpResult);
            this.Controls.Add(this.grpSearch);
            this.Name = "FrmHistory";
            this.Text = "查询玩家重置历史";
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblSearchDate;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpStop;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView grvResult;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblMust01;
        private System.ComponentModel.BackgroundWorker bwSearch;
    }
}