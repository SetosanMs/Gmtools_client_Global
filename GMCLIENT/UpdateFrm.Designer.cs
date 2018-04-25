namespace GMCLIENT
{
    partial class UpdateFrm
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
            this.UdProgressBar = new System.Windows.Forms.ProgressBar();
            this.UdLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxUpdateInfo = new System.Windows.Forms.TextBox();
            this.checkBoxAutoLogin = new System.Windows.Forms.CheckBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UdProgressBar
            // 
            this.UdProgressBar.Location = new System.Drawing.Point(11, 28);
            this.UdProgressBar.Name = "UdProgressBar";
            this.UdProgressBar.Size = new System.Drawing.Size(479, 15);
            this.UdProgressBar.TabIndex = 1;
            // 
            // UdLabel
            // 
            this.UdLabel.AutoSize = true;
            this.UdLabel.Location = new System.Drawing.Point(9, 52);
            this.UdLabel.Name = "UdLabel";
            this.UdLabel.Size = new System.Drawing.Size(0, 12);
            this.UdLabel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "系统发现新组件，正在下载中...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxUpdateInfo
            // 
            this.textBoxUpdateInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUpdateInfo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxUpdateInfo.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUpdateInfo.Location = new System.Drawing.Point(11, 103);
            this.textBoxUpdateInfo.Multiline = true;
            this.textBoxUpdateInfo.Name = "textBoxUpdateInfo";
            this.textBoxUpdateInfo.ReadOnly = true;
            this.textBoxUpdateInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxUpdateInfo.Size = new System.Drawing.Size(476, 175);
            this.textBoxUpdateInfo.TabIndex = 7;
            // 
            // checkBoxAutoLogin
            // 
            this.checkBoxAutoLogin.AutoSize = true;
            this.checkBoxAutoLogin.Checked = true;
            this.checkBoxAutoLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoLogin.Enabled = false;
            this.checkBoxAutoLogin.Location = new System.Drawing.Point(265, 296);
            this.checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            this.checkBoxAutoLogin.Size = new System.Drawing.Size(114, 16);
            this.checkBoxAutoLogin.TabIndex = 8;
            this.checkBoxAutoLogin.Text = "自动重启GMTools";
            this.checkBoxAutoLogin.UseVisualStyleBackColor = true;
            // 
            // buttonDone
            // 
            this.buttonDone.Enabled = false;
            this.buttonDone.Location = new System.Drawing.Point(412, 288);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(72, 30);
            this.buttonDone.TabIndex = 9;
            this.buttonDone.Text = "完成";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // UpdateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 327);
            this.ControlBox = false;
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.checkBoxAutoLogin);
            this.Controls.Add(this.textBoxUpdateInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UdLabel);
            this.Controls.Add(this.UdProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateFrm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统升级...";
            this.Load += new System.EventHandler(this.UpdateFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar UdProgressBar;
        private System.Windows.Forms.Label UdLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxUpdateInfo;
        private System.Windows.Forms.CheckBox checkBoxAutoLogin;
        private System.Windows.Forms.Button buttonDone;
    }
}