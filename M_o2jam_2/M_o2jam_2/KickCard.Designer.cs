namespace M_o2jam_2
{
    partial class KickCard
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
            this.btnApply = new System.Windows.Forms.Button();
            this.txtAorN = new System.Windows.Forms.TextBox();
            this.lblAorN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(21, 134);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "确定";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtAorN
            // 
            this.txtAorN.Location = new System.Drawing.Point(21, 96);
            this.txtAorN.Name = "txtAorN";
            this.txtAorN.Size = new System.Drawing.Size(184, 21);
            this.txtAorN.TabIndex = 7;
            // 
            // lblAorN
            // 
            this.lblAorN.AutoSize = true;
            this.lblAorN.Location = new System.Drawing.Point(19, 82);
            this.lblAorN.Name = "lblAorN";
            this.lblAorN.Size = new System.Drawing.Size(65, 12);
            this.lblAorN.TabIndex = 10;
            this.lblAorN.Text = "帐号查询：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "服务器：";
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(20, 46);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(185, 20);
            this.cbxServerIP.TabIndex = 8;
            // 
            // KickCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 377);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtAorN);
            this.Controls.Add(this.lblAorN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxServerIP);
            this.Name = "KickCard";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "剔除卡号";
            this.Load += new System.EventHandler(this.KickCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtAorN;
        private System.Windows.Forms.Label lblAorN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxServerIP;
    }
}