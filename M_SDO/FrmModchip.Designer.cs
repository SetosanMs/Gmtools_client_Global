namespace M_SDO
{
    partial class FrmModchip
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtitemname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dpModi = new DividerPanel.DividerPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Txtpersent = new System.Windows.Forms.TextBox();
            this.btnModiCancel = new System.Windows.Forms.Button();
            this.btnModiApply = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dpNoteText = new DividerPanel.DividerPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dpDGAccountInfo = new DividerPanel.DividerPanel();
            this.dgAccountInfo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.CmbServer = new System.Windows.Forms.ComboBox();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.backgroundWorkLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            this.dpModi.SuspendLayout();
            this.dpNoteText.SuspendLayout();
            this.dpDGAccountInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtitemname
            // 
            this.txtitemname.Location = new System.Drawing.Point(172, 30);
            this.txtitemname.Name = "txtitemname";
            this.txtitemname.ReadOnly = true;
            this.txtitemname.Size = new System.Drawing.Size(109, 21);
            this.txtitemname.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器大区:";
            // 
            // dpModi
            // 
            this.dpModi.AllowDrop = true;
            this.dpModi.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dpModi.Controls.Add(this.label3);
            this.dpModi.Controls.Add(this.txtitemname);
            this.dpModi.Controls.Add(this.label2);
            this.dpModi.Controls.Add(this.Txtpersent);
            this.dpModi.Controls.Add(this.btnModiCancel);
            this.dpModi.Controls.Add(this.btnModiApply);
            this.dpModi.Controls.Add(this.label11);
            this.dpModi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpModi.Location = new System.Drawing.Point(0, 339);
            this.dpModi.Name = "dividerPanel5";
            this.dpModi.Size = new System.Drawing.Size(666, 146);
            this.dpModi.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "(千分比)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "获得几率:";
            // 
            // Txtpersent
            // 
            this.Txtpersent.Location = new System.Drawing.Point(391, 30);
            this.Txtpersent.Name = "Txtpersent";
            this.Txtpersent.Size = new System.Drawing.Size(109, 21);
            this.Txtpersent.TabIndex = 12;
            this.Txtpersent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtCharname_KeyUp);
            // 
            // btnModiCancel
            // 
            this.btnModiCancel.Location = new System.Drawing.Point(401, 105);
            this.btnModiCancel.Name = "btnModiCancel";
            this.btnModiCancel.Size = new System.Drawing.Size(80, 23);
            this.btnModiCancel.TabIndex = 11;
            this.btnModiCancel.Text = "取消";
            this.btnModiCancel.UseVisualStyleBackColor = true;
            this.btnModiCancel.Click += new System.EventHandler(this.btnModiCancel_Click);
            // 
            // btnModiApply
            // 
            this.btnModiApply.Location = new System.Drawing.Point(186, 105);
            this.btnModiApply.Name = "btnModiApply";
            this.btnModiApply.Size = new System.Drawing.Size(80, 23);
            this.btnModiApply.TabIndex = 9;
            this.btnModiApply.Text = "确认";
            this.btnModiApply.UseVisualStyleBackColor = true;
            this.btnModiApply.Click += new System.EventHandler(this.btnModiApply_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(106, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "物品名:";
            // 
            // dpNoteText
            // 
            this.dpNoteText.AllowDrop = true;
            this.dpNoteText.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dpNoteText.Controls.Add(this.label8);
            this.dpNoteText.Controls.Add(this.label7);
            this.dpNoteText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dpNoteText.Location = new System.Drawing.Point(0, 221);
            this.dpNoteText.Name = "dividerPanel4";
            this.dpNoteText.Size = new System.Drawing.Size(666, 46);
            this.dpNoteText.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-1, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(209, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "请先在上方选择物品后再修改相关信息";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(0, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "提醒：";
            // 
            // dpDGAccountInfo
            // 
            this.dpDGAccountInfo.AllowDrop = true;
            this.dpDGAccountInfo.Controls.Add(this.dgAccountInfo);
            this.dpDGAccountInfo.Controls.Add(this.dpNoteText);
            this.dpDGAccountInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.dpDGAccountInfo.Location = new System.Drawing.Point(0, 72);
            this.dpDGAccountInfo.Name = "dividerPanel3";
            this.dpDGAccountInfo.Size = new System.Drawing.Size(666, 267);
            this.dpDGAccountInfo.TabIndex = 9;
            // 
            // dgAccountInfo
            // 
            this.dgAccountInfo.AllowUserToAddRows = false;
            this.dgAccountInfo.AllowUserToDeleteRows = false;
            this.dgAccountInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccountInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAccountInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAccountInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAccountInfo.Location = new System.Drawing.Point(0, 0);
            this.dgAccountInfo.MultiSelect = false;
            this.dgAccountInfo.Name = "dgAccountInfo";
            this.dgAccountInfo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccountInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgAccountInfo.RowTemplate.Height = 23;
            this.dgAccountInfo.Size = new System.Drawing.Size(666, 221);
            this.dgAccountInfo.TabIndex = 0;
            this.dgAccountInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAccountInfo_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.CmbServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(528, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(425, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // CmbServer
            // 
            this.CmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbServer.FormattingEnabled = true;
            this.CmbServer.Location = new System.Drawing.Point(91, 20);
            this.CmbServer.Name = "CmbServer";
            this.CmbServer.Size = new System.Drawing.Size(166, 20);
            this.CmbServer.TabIndex = 2;
            this.CmbServer.SelectedIndexChanged += new System.EventHandler(this.CmbServer_SelectedIndexChanged);
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Controls.Add(this.lblPageSize);
            this.dividerPanel2.Controls.Add(this.lblPageCount);
            this.dividerPanel2.Controls.Add(this.comboBox3);
            this.dividerPanel2.Controls.Add(this.label6);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(0, 62);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dividerPanel2.Size = new System.Drawing.Size(666, 10);
            this.dividerPanel2.TabIndex = 8;
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.ForeColor = System.Drawing.Color.Blue;
            this.lblPageSize.Location = new System.Drawing.Point(89, 14);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(17, 12);
            this.lblPageSize.TabIndex = 3;
            this.lblPageSize.Text = "10";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Blue;
            this.lblPageCount.Location = new System.Drawing.Point(19, 14);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(11, 12);
            this.lblPageCount.TabIndex = 2;
            this.lblPageCount.Text = "1";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(186, 10);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(95, 20);
            this.comboBox3.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-1, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "共    页，每页    条      转到　　　　　　　　　页";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(666, 62);
            this.dividerPanel1.TabIndex = 7;
            // 
            // backgroundWorkLoad
            // 
            this.backgroundWorkLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkLoad_DoWork);
            this.backgroundWorkLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkLoad_RunWorkerCompleted);
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
            // FrmModchip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 485);
            this.Controls.Add(this.dpModi);
            this.Controls.Add(this.dpDGAccountInfo);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "FrmModchip";
            this.Text = "大赛拼图信息设置[SDO]";
            this.Load += new System.EventHandler(this.FrmModchip_Load);
            this.dpModi.ResumeLayout(false);
            this.dpModi.PerformLayout();
            this.dpNoteText.ResumeLayout(false);
            this.dpNoteText.PerformLayout();
            this.dpDGAccountInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.dividerPanel2.PerformLayout();
            this.dividerPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtitemname;
        private System.Windows.Forms.Label label1;
        private DividerPanel.DividerPanel dpModi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txtpersent;
        private System.Windows.Forms.Button btnModiCancel;
        private System.Windows.Forms.Button btnModiApply;
        private System.Windows.Forms.Label label11;
        private DividerPanel.DividerPanel dpNoteText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private DividerPanel.DividerPanel dpDGAccountInfo;
        private System.Windows.Forms.DataGridView dgAccountInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox CmbServer;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private DividerPanel.DividerPanel dividerPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorkLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdate;
    }
}