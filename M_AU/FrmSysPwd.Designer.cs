namespace M_Audition
{
    partial class FrmSysPwd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btncanel = new System.Windows.Forms.Button();
            this.btnsyspwd = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorkerSysPwd = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btncanel);
            this.groupBox1.Controls.Add(this.btnsyspwd);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 215);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请输入信息";
            // 
            // btncanel
            // 
            this.btncanel.Location = new System.Drawing.Point(273, 136);
            this.btncanel.Name = "btncanel";
            this.btncanel.Size = new System.Drawing.Size(66, 23);
            this.btncanel.TabIndex = 10;
            this.btncanel.Text = "取消";
            this.btncanel.UseVisualStyleBackColor = true;
            this.btncanel.Click += new System.EventHandler(this.btncanel_Click);
            // 
            // btnsyspwd
            // 
            this.btnsyspwd.Location = new System.Drawing.Point(179, 136);
            this.btnsyspwd.Name = "btnsyspwd";
            this.btnsyspwd.Size = new System.Drawing.Size(66, 23);
            this.btnsyspwd.TabIndex = 9;
            this.btnsyspwd.Text = "同步密码";
            this.btnsyspwd.UseVisualStyleBackColor = true;
            this.btnsyspwd.Click += new System.EventHandler(this.btnsyspwd_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(179, 27);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(152, 21);
            this.textBox7.TabIndex = 8;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(179, 54);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(152, 21);
            this.textBox8.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "久游令牌序列号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "久游动态密码：";
            // 
            // backgroundWorkerSysPwd
            // 
            this.backgroundWorkerSysPwd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSysPwd_DoWork);
            this.backgroundWorkerSysPwd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSysPwd_RunWorkerCompleted);
            // 
            // FrmSysPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 469);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSysPwd";
            this.Text = "FrmSysPwd";
            this.Load += new System.EventHandler(this.FrmSysPwd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btncanel;
        private System.Windows.Forms.Button btnsyspwd;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSysPwd;
    }
}