namespace M_Audition
{
    partial class FrmToken
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
            this.TBCToken = new System.Windows.Forms.TabControl();
            this.TpgUnban = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TpgLock = new System.Windows.Forms.TabPage();
            this.GroupLock = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonLock = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.labelserviceNo = new System.Windows.Forms.Label();
            this.labelESN = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.TpgUnlock = new System.Windows.Forms.TabPage();
            this.GroupUnlock = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorkerLock = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUnlock = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerView = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCurrent = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUnban = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSysPwd = new System.ComponentModel.BackgroundWorker();
            this.TBCToken.SuspendLayout();
            this.TpgUnban.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TpgLock.SuspendLayout();
            this.GroupLock.SuspendLayout();
            this.TpgUnlock.SuspendLayout();
            this.GroupUnlock.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBCToken
            // 
            this.TBCToken.Controls.Add(this.TpgUnban);
            this.TBCToken.Controls.Add(this.TpgLock);
            this.TBCToken.Controls.Add(this.TpgUnlock);
            this.TBCToken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBCToken.Location = new System.Drawing.Point(0, 0);
            this.TBCToken.Name = "TBCToken";
            this.TBCToken.SelectedIndex = 0;
            this.TBCToken.Size = new System.Drawing.Size(679, 527);
            this.TBCToken.TabIndex = 0;
            // 
            // TpgUnban
            // 
            this.TpgUnban.Controls.Add(this.groupBox2);
            this.TpgUnban.Location = new System.Drawing.Point(4, 21);
            this.TpgUnban.Name = "TpgUnban";
            this.TpgUnban.Size = new System.Drawing.Size(671, 502);
            this.TpgUnban.TabIndex = 4;
            this.TpgUnban.Text = "令牌解除绑定";
            this.TpgUnban.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(671, 132);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "请输入信息";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(118, 78);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(24, 78);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "解除绑定";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(105, 26);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(152, 21);
            this.textBox10.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "久游用户名：";
            // 
            // TpgLock
            // 
            this.TpgLock.Controls.Add(this.GroupLock);
            this.TpgLock.Location = new System.Drawing.Point(4, 21);
            this.TpgLock.Name = "TpgLock";
            this.TpgLock.Padding = new System.Windows.Forms.Padding(3);
            this.TpgLock.Size = new System.Drawing.Size(671, 502);
            this.TpgLock.TabIndex = 0;
            this.TpgLock.Text = "令牌挂失";
            this.TpgLock.UseVisualStyleBackColor = true;
            // 
            // GroupLock
            // 
            this.GroupLock.Controls.Add(this.buttonCancel);
            this.GroupLock.Controls.Add(this.buttonLock);
            this.GroupLock.Controls.Add(this.textBox3);
            this.GroupLock.Controls.Add(this.textBox2);
            this.GroupLock.Controls.Add(this.textBox1);
            this.GroupLock.Controls.Add(this.richTextBox1);
            this.GroupLock.Controls.Add(this.radioButton2);
            this.GroupLock.Controls.Add(this.radioButton1);
            this.GroupLock.Controls.Add(this.labelserviceNo);
            this.GroupLock.Controls.Add(this.labelESN);
            this.GroupLock.Controls.Add(this.labelName);
            this.GroupLock.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupLock.Location = new System.Drawing.Point(3, 3);
            this.GroupLock.Name = "GroupLock";
            this.GroupLock.Size = new System.Drawing.Size(665, 249);
            this.GroupLock.TabIndex = 0;
            this.GroupLock.TabStop = false;
            this.GroupLock.Text = "请输入信息";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(253, 214);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(66, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonLock
            // 
            this.buttonLock.Location = new System.Drawing.Point(159, 214);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(66, 23);
            this.buttonLock.TabIndex = 9;
            this.buttonLock.Text = "挂失";
            this.buttonLock.UseVisualStyleBackColor = true;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(167, 74);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(152, 21);
            this.textBox3.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(167, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(152, 21);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 21);
            this.textBox1.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.richTextBox1.Location = new System.Drawing.Point(484, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(167, 143);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "温馨提醒：挂失久游令牌后，帐号可能进入两种状态。如果您选择挂失后禁止登录帐号和游戏，则在解除挂失前都无法进入游戏；如果您选择挂失后久游令牌失效，则帐号失去久游令牌" +
                "保护，无须动态密码即可登录帐号和游戏。";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(58, 181);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(383, 16);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "令牌失效：挂失后和该久游令牌绑定的帐号仅使用普通密码验证登录";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(58, 126);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(395, 16);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "禁止登录(推荐)：挂失后和该令牌绑定帐号都不能登录，直到解除挂失";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // labelserviceNo
            // 
            this.labelserviceNo.AutoSize = true;
            this.labelserviceNo.Location = new System.Drawing.Point(60, 77);
            this.labelserviceNo.Name = "labelserviceNo";
            this.labelserviceNo.Size = new System.Drawing.Size(101, 12);
            this.labelserviceNo.TabIndex = 2;
            this.labelserviceNo.Text = "久游令牌服务号：";
            // 
            // labelESN
            // 
            this.labelESN.AutoSize = true;
            this.labelESN.Location = new System.Drawing.Point(60, 50);
            this.labelESN.Name = "labelESN";
            this.labelESN.Size = new System.Drawing.Size(101, 12);
            this.labelESN.TabIndex = 1;
            this.labelESN.Text = "久游令牌序列号：";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(84, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(77, 12);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "久游用户名：";
            // 
            // TpgUnlock
            // 
            this.TpgUnlock.Controls.Add(this.GroupUnlock);
            this.TpgUnlock.Location = new System.Drawing.Point(4, 21);
            this.TpgUnlock.Name = "TpgUnlock";
            this.TpgUnlock.Padding = new System.Windows.Forms.Padding(3);
            this.TpgUnlock.Size = new System.Drawing.Size(671, 502);
            this.TpgUnlock.TabIndex = 1;
            this.TpgUnlock.Text = "令牌解除挂失";
            this.TpgUnlock.UseVisualStyleBackColor = true;
            // 
            // GroupUnlock
            // 
            this.GroupUnlock.Controls.Add(this.button1);
            this.GroupUnlock.Controls.Add(this.buttonUnlock);
            this.GroupUnlock.Controls.Add(this.textBox4);
            this.GroupUnlock.Controls.Add(this.textBox5);
            this.GroupUnlock.Controls.Add(this.textBox6);
            this.GroupUnlock.Controls.Add(this.richTextBox2);
            this.GroupUnlock.Controls.Add(this.label1);
            this.GroupUnlock.Controls.Add(this.label2);
            this.GroupUnlock.Controls.Add(this.label3);
            this.GroupUnlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupUnlock.Location = new System.Drawing.Point(3, 3);
            this.GroupUnlock.Name = "GroupUnlock";
            this.GroupUnlock.Size = new System.Drawing.Size(665, 215);
            this.GroupUnlock.TabIndex = 1;
            this.GroupUnlock.TabStop = false;
            this.GroupUnlock.Text = "请输入信息";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Location = new System.Drawing.Point(167, 154);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(66, 23);
            this.buttonUnlock.TabIndex = 9;
            this.buttonUnlock.Text = "解除挂失";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(167, 47);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(152, 21);
            this.textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(167, 74);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(152, 21);
            this.textBox5.TabIndex = 7;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(167, 20);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(152, 21);
            this.textBox6.TabIndex = 6;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.richTextBox2.Location = new System.Drawing.Point(377, 20);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(167, 143);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "温馨提醒：解除挂失后自动恢复为绑定状态。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "久游令牌序列号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "久游动态密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "久游用户名：";
            // 
            // backgroundWorkerLock
            // 
            this.backgroundWorkerLock.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLock_DoWork);
            this.backgroundWorkerLock.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLock_RunWorkerCompleted);
            // 
            // backgroundWorkerUnlock
            // 
            this.backgroundWorkerUnlock.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUnlock_DoWork);
            this.backgroundWorkerUnlock.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUnlock_RunWorkerCompleted);
            // 
            // backgroundWorkerUnban
            // 
            this.backgroundWorkerUnban.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUnban_DoWork);
            this.backgroundWorkerUnban.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUnban_RunWorkerCompleted);
            // 
            // backgroundWorkerSysPwd
            // 
            this.backgroundWorkerSysPwd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSysPwd_DoWork);
            this.backgroundWorkerSysPwd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSysPwd_RunWorkerCompleted);
            // 
            // FrmToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 527);
            this.Controls.Add(this.TBCToken);
            this.Name = "FrmToken";
            this.Text = "9YOU令牌";
            this.Load += new System.EventHandler(this.FrmToken_Load);
            this.TBCToken.ResumeLayout(false);
            this.TpgUnban.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TpgLock.ResumeLayout(false);
            this.GroupLock.ResumeLayout(false);
            this.GroupLock.PerformLayout();
            this.TpgUnlock.ResumeLayout(false);
            this.GroupUnlock.ResumeLayout(false);
            this.GroupUnlock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TBCToken;
        private System.Windows.Forms.TabPage TpgLock;
        private System.Windows.Forms.TabPage TpgUnlock;
        private System.Windows.Forms.GroupBox GroupLock;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label labelserviceNo;
        private System.Windows.Forms.Label labelESN;
        private System.Windows.Forms.Label labelName;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLock;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUnlock;
        private System.Windows.Forms.GroupBox GroupUnlock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorkerView;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCurrent;
        private System.Windows.Forms.TabPage TpgUnban;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUnban;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSysPwd;
    }
}