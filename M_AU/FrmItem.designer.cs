namespace M_AU
{
    partial class FrmItem
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
            this.lblMust01 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.grvResult = new System.Windows.Forms.DataGridView();
            this.bwSearch = new System.ComponentModel.BackgroundWorker();
            this.grpSearch.SuspendLayout();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnCancle);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.lblMust01);
            this.grpSearch.Controls.Add(this.txtUserName);
            this.grpSearch.Controls.Add(this.lblUserName);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Location = new System.Drawing.Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(709, 55);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "查询条件：";
            // 
            // lblMust01
            // 
            this.lblMust01.AutoSize = true;
            this.lblMust01.ForeColor = System.Drawing.Color.Red;
            this.lblMust01.Location = new System.Drawing.Point(206, 24);
            this.lblMust01.Name = "lblMust01";
            this.lblMust01.Size = new System.Drawing.Size(11, 12);
            this.lblMust01.TabIndex = 13;
            this.lblMust01.Text = "*";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(98, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(101, 21);
            this.txtUserName.TabIndex = 12;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(27, 24);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(65, 12);
            this.lblUserName.TabIndex = 11;
            this.lblUserName.Text = "用 户 名：";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(568, 18);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 15;
            this.btnCancle.Text = "取　消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(479, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查　询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.grvResult);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Location = new System.Drawing.Point(0, 55);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(709, 333);
            this.grpResult.TabIndex = 2;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "查询结果：";
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
            this.grvResult.Size = new System.Drawing.Size(703, 313);
            this.grvResult.TabIndex = 0;
            // 
            // bwSearch
            // 
            this.bwSearch.WorkerSupportsCancellation = true;
            this.bwSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSearch_DoWork);
            this.bwSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSearch_RunWorkerCompleted);
            // 
            // FrmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 388);
            this.Controls.Add(this.grpResult);
            this.Controls.Add(this.grpSearch);
            this.Name = "FrmItem";
            this.Text = "查询跳舞毯领取资格";
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblMust01;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.DataGridView grvResult;
        private System.ComponentModel.BackgroundWorker bwSearch;
    }
}