namespace M_SDO
{
    partial class Frm_SDO_Trade
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
            this.TxtReciveAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtSenderAccount = new System.Windows.Forms.TextBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.LblServer = new System.Windows.Forms.Label();
            this.GrpResult = new System.Windows.Forms.GroupBox();
            this.GrdResult = new System.Windows.Forms.DataGridView();
            this.PnlPage = new System.Windows.Forms.Panel();
            this.LblPage = new System.Windows.Forms.Label();
            this.CmbPage = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerPageChanged = new System.ComponentModel.BackgroundWorker();
            this.GrpSearch.SuspendLayout();
            this.GrpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).BeginInit();
            this.PnlPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpSearch
            // 
            this.GrpSearch.Controls.Add(this.TxtReciveAccount);
            this.GrpSearch.Controls.Add(this.label1);
            this.GrpSearch.Controls.Add(this.BtnClose);
            this.GrpSearch.Controls.Add(this.BtnSearch);
            this.GrpSearch.Controls.Add(this.TxtSenderAccount);
            this.GrpSearch.Controls.Add(this.LblAccount);
            this.GrpSearch.Controls.Add(this.CmbServer);
            this.GrpSearch.Controls.Add(this.LblServer);
            this.GrpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSearch.Location = new System.Drawing.Point(10, 10);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(794, 70);
            this.GrpSearch.TabIndex = 6;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "��������";
            // 
            // TxtReciveAccount
            // 
            this.TxtReciveAccount.Location = new System.Drawing.Point(159, 33);
            this.TxtReciveAccount.Name = "TxtReciveAccount";
            this.TxtReciveAccount.Size = new System.Drawing.Size(138, 21);
            this.TxtReciveAccount.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "�������ʺţ�";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.Location = new System.Drawing.Point(553, 31);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(66, 23);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.Text = "�ر�";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.AutoSize = true;
            this.BtnSearch.Location = new System.Drawing.Point(476, 31);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(67, 23);
            this.BtnSearch.TabIndex = 5;
            this.BtnSearch.Text = "����";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtSenderAccount
            // 
            this.TxtSenderAccount.Location = new System.Drawing.Point(317, 33);
            this.TxtSenderAccount.Name = "TxtSenderAccount";
            this.TxtSenderAccount.Size = new System.Drawing.Size(137, 21);
            this.TxtSenderAccount.TabIndex = 4;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(315, 19);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(77, 12);
            this.LblAccount.TabIndex = 3;
            this.LblAccount.Text = "�������ǳƣ�";
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(11, 34);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(126, 20);
            this.CmbServer.TabIndex = 2;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // LblServer
            // 
            this.LblServer.AutoSize = true;
            this.LblServer.Location = new System.Drawing.Point(9, 19);
            this.LblServer.Name = "LblServer";
            this.LblServer.Size = new System.Drawing.Size(77, 12);
            this.LblServer.TabIndex = 1;
            this.LblServer.Text = "ѡ���������";
            // 
            // GrpResult
            // 
            this.GrpResult.Controls.Add(this.GrdResult);
            this.GrpResult.Controls.Add(this.PnlPage);
            this.GrpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpResult.Location = new System.Drawing.Point(10, 80);
            this.GrpResult.Name = "GrpResult";
            this.GrpResult.Size = new System.Drawing.Size(794, 423);
            this.GrpResult.TabIndex = 8;
            this.GrpResult.TabStop = false;
            this.GrpResult.Text = "��ҽ��׼�¼";
            // 
            // GrdResult
            // 
            this.GrdResult.AllowUserToAddRows = false;
            this.GrdResult.AllowUserToDeleteRows = false;
            this.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdResult.Location = new System.Drawing.Point(3, 48);
            this.GrdResult.Name = "GrdResult";
            this.GrdResult.RowTemplate.Height = 23;
            this.GrdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrdResult.Size = new System.Drawing.Size(788, 372);
            this.GrdResult.TabIndex = 8;
            // 
            // PnlPage
            // 
            this.PnlPage.Controls.Add(this.LblPage);
            this.PnlPage.Controls.Add(this.CmbPage);
            this.PnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlPage.Location = new System.Drawing.Point(3, 17);
            this.PnlPage.Name = "PnlPage";
            this.PnlPage.Size = new System.Drawing.Size(788, 31);
            this.PnlPage.TabIndex = 7;
            this.PnlPage.TabStop = true;
            // 
            // LblPage
            // 
            this.LblPage.AutoSize = true;
            this.LblPage.Location = new System.Drawing.Point(536, 10);
            this.LblPage.Name = "LblPage";
            this.LblPage.Size = new System.Drawing.Size(101, 12);
            this.LblPage.TabIndex = 1;
            this.LblPage.Text = "��ѡ��鿴ҳ����";
            // 
            // CmbPage
            // 
            this.CmbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPage.FormattingEnabled = true;
            this.CmbPage.Location = new System.Drawing.Point(643, 6);
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
            // Frm_SDO_Trade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 513);
            this.Controls.Add(this.GrpResult);
            this.Controls.Add(this.GrpSearch);
            this.Name = "Frm_SDO_Trade";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "��ҽ��׼�¼[��������]";
            this.Load += new System.EventHandler(this.Frm_SDO_Trade_Load);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.GrpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdResult)).EndInit();
            this.PnlPage.ResumeLayout(false);
            this.PnlPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSearch;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtSenderAccount;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.ComboBox CmbServer;
        private System.Windows.Forms.Label LblServer;
        private System.Windows.Forms.GroupBox GrpResult;
        private System.Windows.Forms.TextBox TxtReciveAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PnlPage;
        private System.Windows.Forms.Label LblPage;
        private System.Windows.Forms.ComboBox CmbPage;
        private System.Windows.Forms.DataGridView GrdResult;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFormLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPageChanged;
    }
}