namespace M_GM
{
    partial class FrmResetStatics
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
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.userID = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.beginDate = new System.Windows.Forms.DateTimePicker();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerLoad = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel3.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.userID);
            this.dividerPanel3.Controls.Add(this.button1);
            this.dividerPanel3.Controls.Add(this.label1);
            this.dividerPanel3.Controls.Add(this.endDate);
            this.dividerPanel3.Controls.Add(this.label2);
            this.dividerPanel3.Controls.Add(this.label4);
            this.dividerPanel3.Controls.Add(this.beginDate);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel3.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.dividerPanel3.Size = new System.Drawing.Size(608, 96);
            this.dividerPanel3.TabIndex = 1;
            // 
            // userID
            // 
            this.userID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userID.FormattingEnabled = true;
            this.userID.Location = new System.Drawing.Point(92, 62);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(133, 20);
            this.userID.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 17;
            this.button1.Text = "查看";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "GM帐号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // endDate
            // 
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(92, 37);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(133, 21);
            this.endDate.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "开始日期：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "结束日期：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // beginDate
            // 
            this.beginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.beginDate.Location = new System.Drawing.Point(92, 8);
            this.beginDate.Name = "beginDate";
            this.beginDate.Size = new System.Drawing.Size(133, 21);
            this.beginDate.TabIndex = 14;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.richTextBoxResult);
            this.groupBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxResult.Location = new System.Drawing.Point(0, 96);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(608, 315);
            this.groupBoxResult.TabIndex = 2;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "查询结果";
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxResult.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxResult.Location = new System.Drawing.Point(3, 17);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.ReadOnly = true;
            this.richTextBoxResult.Size = new System.Drawing.Size(602, 295);
            this.richTextBoxResult.TabIndex = 0;
            this.richTextBoxResult.Text = "";
            // 
            // FrmResetStatics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 411);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.dividerPanel3);
            this.Name = "FrmResetStatics";
            this.Text = "9YOU重置信息统计";
            this.Load += new System.EventHandler(this.FrmResetStatics_Load);
            this.dividerPanel3.ResumeLayout(false);
            this.dividerPanel3.PerformLayout();
            this.groupBoxResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel3;
        private System.Windows.Forms.ComboBox userID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker beginDate;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoad;
    }
}