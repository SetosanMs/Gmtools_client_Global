namespace M_AU
{
    partial class FrmAddPcip
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtCode = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.txtExp = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelProcess = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.GrdList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtCode);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 590);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // TxtCode
            // 
            this.TxtCode.CheckOnClick = true;
            this.TxtCode.ColumnWidth = 150;
            this.TxtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCode.FormattingEnabled = true;
            this.TxtCode.HorizontalExtent = 10;
            this.TxtCode.Location = new System.Drawing.Point(3, 98);
            this.TxtCode.MultiColumn = true;
            this.TxtCode.Name = "TxtCode";
            this.TxtCode.Size = new System.Drawing.Size(150, 484);
            this.TxtCode.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 81);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(47, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "全选";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(44, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "大区列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dividerPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(156, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(772, 590);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.dividerPanel2);
            this.dividerPanel1.Controls.Add(this.GrdList);
            this.dividerPanel1.Controls.Add(this.label1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel1.Location = new System.Drawing.Point(3, 17);
            this.dividerPanel1.Name = "dpStatus";
            this.dividerPanel1.Size = new System.Drawing.Size(766, 570);
            this.dividerPanel1.TabIndex = 1;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Controls.Add(this.txtExp);
            this.dividerPanel2.Controls.Add(this.txtG);
            this.dividerPanel2.Controls.Add(this.buttonBrowse);
            this.dividerPanel2.Controls.Add(this.textBoxPath);
            this.dividerPanel2.Controls.Add(this.labelPath);
            this.dividerPanel2.Controls.Add(this.labelProcess);
            this.dividerPanel2.Controls.Add(this.progressBar1);
            this.dividerPanel2.Controls.Add(this.label4);
            this.dividerPanel2.Controls.Add(this.label3);
            this.dividerPanel2.Controls.Add(this.button1);
            this.dividerPanel2.Controls.Add(this.btnOk);
            this.dividerPanel2.Controls.Add(this.label9);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel2.Location = new System.Drawing.Point(0, 272);
            this.dividerPanel2.Name = "dpStatus";
            this.dividerPanel2.Size = new System.Drawing.Size(766, 298);
            this.dividerPanel2.TabIndex = 3;
            // 
            // txtExp
            // 
            this.txtExp.Location = new System.Drawing.Point(274, 95);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(181, 21);
            this.txtExp.TabIndex = 26;
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(274, 135);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(181, 21);
            this.txtG.TabIndex = 25;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(461, 175);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(84, 23);
            this.buttonBrowse.TabIndex = 24;
            this.buttonBrowse.Text = "浏览";
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(274, 177);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(181, 21);
            this.textBoxPath.TabIndex = 23;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPath.Location = new System.Drawing.Point(209, 180);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(59, 12);
            this.labelPath.TabIndex = 22;
            this.labelPath.Text = "文件路径:";
            this.labelPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelProcess.Location = new System.Drawing.Point(492, 98);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(65, 12);
            this.labelProcess.TabIndex = 21;
            this.labelProcess.Text = "完成进度：";
            this.labelProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(494, 113);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(197, 13);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(209, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "经验倍数:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(209, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "G币倍数:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(211, 232);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "添加记录";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 12);
            this.label9.TabIndex = 0;
            // 
            // GrdList
            // 
            this.GrdList.AllowUserToAddRows = false;
            this.GrdList.AllowUserToDeleteRows = false;
            this.GrdList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GrdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrdList.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrdList.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrdList.Location = new System.Drawing.Point(0, 0);
            this.GrdList.MultiSelect = false;
            this.GrdList.Name = "GrdList";
            this.GrdList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GrdList.RowTemplate.Height = 23;
            this.GrdList.Size = new System.Drawing.Size(766, 272);
            this.GrdList.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "文本文件|*.txt";
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.WorkerReportsProgress = true;
            this.backgroundWorkerSearch.WorkerSupportsCancellation = true;
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearch_DoWork);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            this.backgroundWorkerSearch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSearch_ProgressChanged);
            // 
            // FrmAddPcip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 590);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAddPcip";
            this.Text = "添加IP信息";
            this.Load += new System.EventHandler(this.FrmAddPcip_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.dividerPanel2.ResumeLayout(false);
            this.dividerPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox TxtCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView GrdList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelProcess;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.Windows.Forms.TextBox txtExp;
        private System.Windows.Forms.TextBox txtG;
    }
}