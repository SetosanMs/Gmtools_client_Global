namespace M_o2jam_2
{
    partial class PartInfo
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
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbtnNick = new System.Windows.Forms.RadioButton();
            this.rbtnAccount = new System.Windows.Forms.RadioButton();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtAorN = new System.Windows.Forms.TextBox();
            this.lblAorN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.tabResult = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.dpInfoContain = new System.Windows.Forms.Panel();
            this.lblExp = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.ComboBox();
            this.lblSex = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblLost = new System.Windows.Forms.TextBox();
            this.lblDraw = new System.Windows.Forms.TextBox();
            this.lblWin = new System.Windows.Forms.TextBox();
            this.lblGameCount = new System.Windows.Forms.TextBox();
            this.lblG = new System.Windows.Forms.TextBox();
            this.lblMCash = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richInfo = new System.Windows.Forms.RichTextBox();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabEdit.SuspendLayout();
            this.dpInfoContain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(561, 86);
            this.dividerPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.rbtnNick);
            this.groupBox1.Controls.Add(this.rbtnAccount);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.txtAorN);
            this.groupBox1.Controls.Add(this.lblAorN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxServerIP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(412, 28);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbtnNick
            // 
            this.rbtnNick.AutoSize = true;
            this.rbtnNick.Location = new System.Drawing.Point(86, 58);
            this.rbtnNick.Name = "rbtnNick";
            this.rbtnNick.Size = new System.Drawing.Size(71, 16);
            this.rbtnNick.TabIndex = 5;
            this.rbtnNick.Text = "昵称查询";
            this.rbtnNick.UseVisualStyleBackColor = true;
            this.rbtnNick.CheckedChanged += new System.EventHandler(this.rbtnNick_CheckedChanged);
            // 
            // rbtnAccount
            // 
            this.rbtnAccount.AutoSize = true;
            this.rbtnAccount.Checked = true;
            this.rbtnAccount.Location = new System.Drawing.Point(9, 58);
            this.rbtnAccount.Name = "rbtnAccount";
            this.rbtnAccount.Size = new System.Drawing.Size(71, 16);
            this.rbtnAccount.TabIndex = 4;
            this.rbtnAccount.TabStop = true;
            this.rbtnAccount.Text = "帐号查询";
            this.rbtnAccount.UseVisualStyleBackColor = true;
            this.rbtnAccount.CheckedChanged += new System.EventHandler(this.rbtnAccount_CheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(331, 28);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "确定";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtAorN
            // 
            this.txtAorN.Location = new System.Drawing.Point(170, 30);
            this.txtAorN.Name = "txtAorN";
            this.txtAorN.Size = new System.Drawing.Size(155, 21);
            this.txtAorN.TabIndex = 0;
            // 
            // lblAorN
            // 
            this.lblAorN.AutoSize = true;
            this.lblAorN.Location = new System.Drawing.Point(168, 16);
            this.lblAorN.Name = "lblAorN";
            this.lblAorN.Size = new System.Drawing.Size(65, 12);
            this.lblAorN.TabIndex = 2;
            this.lblAorN.Text = "帐号查询：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器：";
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Location = new System.Drawing.Point(9, 31);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(142, 20);
            this.cbxServerIP.TabIndex = 0;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 96);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(561, 10);
            this.dividerPanel2.TabIndex = 1;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.tabInfo);
            this.tabResult.Controls.Add(this.tabEdit);
            this.tabResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResult.Location = new System.Drawing.Point(10, 106);
            this.tabResult.Name = "tabResult";
            this.tabResult.SelectedIndex = 0;
            this.tabResult.Size = new System.Drawing.Size(561, 359);
            this.tabResult.TabIndex = 2;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.richInfo);
            this.tabInfo.Location = new System.Drawing.Point(4, 21);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(553, 334);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "人物信息";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.dpInfoContain);
            this.tabEdit.Location = new System.Drawing.Point(4, 21);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(553, 334);
            this.tabEdit.TabIndex = 1;
            this.tabEdit.Text = "修改信息";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // dpInfoContain
            // 
            this.dpInfoContain.Controls.Add(this.lblExp);
            this.dpInfoContain.Controls.Add(this.lblLevel);
            this.dpInfoContain.Controls.Add(this.lblSex);
            this.dpInfoContain.Controls.Add(this.button2);
            this.dpInfoContain.Controls.Add(this.button1);
            this.dpInfoContain.Controls.Add(this.lblLost);
            this.dpInfoContain.Controls.Add(this.lblDraw);
            this.dpInfoContain.Controls.Add(this.lblWin);
            this.dpInfoContain.Controls.Add(this.lblGameCount);
            this.dpInfoContain.Controls.Add(this.lblG);
            this.dpInfoContain.Controls.Add(this.lblMCash);
            this.dpInfoContain.Controls.Add(this.lblNick);
            this.dpInfoContain.Controls.Add(this.lblAccount);
            this.dpInfoContain.Controls.Add(this.label13);
            this.dpInfoContain.Controls.Add(this.label12);
            this.dpInfoContain.Controls.Add(this.label11);
            this.dpInfoContain.Controls.Add(this.label10);
            this.dpInfoContain.Controls.Add(this.label9);
            this.dpInfoContain.Controls.Add(this.label8);
            this.dpInfoContain.Controls.Add(this.label7);
            this.dpInfoContain.Controls.Add(this.label6);
            this.dpInfoContain.Controls.Add(this.label5);
            this.dpInfoContain.Controls.Add(this.label4);
            this.dpInfoContain.Controls.Add(this.label3);
            this.dpInfoContain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpInfoContain.Location = new System.Drawing.Point(3, 3);
            this.dpInfoContain.Name = "dpInfoContain";
            this.dpInfoContain.Size = new System.Drawing.Size(547, 328);
            this.dpInfoContain.TabIndex = 0;
            // 
            // lblExp
            // 
            this.lblExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblExp.FormattingEnabled = true;
            this.lblExp.Location = new System.Drawing.Point(127, 219);
            this.lblExp.Name = "lblExp";
            this.lblExp.Size = new System.Drawing.Size(100, 20);
            this.lblExp.TabIndex = 85;
            // 
            // lblLevel
            // 
            this.lblLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblLevel.FormattingEnabled = true;
            this.lblLevel.Location = new System.Drawing.Point(127, 188);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(100, 20);
            this.lblLevel.TabIndex = 84;
            // 
            // lblSex
            // 
            this.lblSex.FormattingEnabled = true;
            this.lblSex.Location = new System.Drawing.Point(127, 95);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(100, 20);
            this.lblSex.TabIndex = 83;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(233, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 82;
            this.button2.Text = "确认";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 81;
            this.button1.Text = "修改该玩家信息";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblLost
            // 
            this.lblLost.Location = new System.Drawing.Point(410, 124);
            this.lblLost.Name = "lblLost";
            this.lblLost.Size = new System.Drawing.Size(100, 21);
            this.lblLost.TabIndex = 80;
            // 
            // lblDraw
            // 
            this.lblDraw.Location = new System.Drawing.Point(410, 94);
            this.lblDraw.Name = "lblDraw";
            this.lblDraw.Size = new System.Drawing.Size(100, 21);
            this.lblDraw.TabIndex = 79;
            // 
            // lblWin
            // 
            this.lblWin.Location = new System.Drawing.Point(410, 65);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(100, 21);
            this.lblWin.TabIndex = 78;
            // 
            // lblGameCount
            // 
            this.lblGameCount.Location = new System.Drawing.Point(410, 37);
            this.lblGameCount.Name = "lblGameCount";
            this.lblGameCount.Size = new System.Drawing.Size(100, 21);
            this.lblGameCount.TabIndex = 77;
            // 
            // lblG
            // 
            this.lblG.Location = new System.Drawing.Point(127, 128);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(100, 21);
            this.lblG.TabIndex = 76;
            // 
            // lblMCash
            // 
            this.lblMCash.Location = new System.Drawing.Point(127, 155);
            this.lblMCash.Name = "lblMCash";
            this.lblMCash.Size = new System.Drawing.Size(100, 21);
            this.lblMCash.TabIndex = 75;
            // 
            // lblNick
            // 
            this.lblNick.Location = new System.Drawing.Point(127, 66);
            this.lblNick.Name = "lblNick";
            this.lblNick.ReadOnly = true;
            this.lblNick.Size = new System.Drawing.Size(100, 21);
            this.lblNick.TabIndex = 74;
            // 
            // lblAccount
            // 
            this.lblAccount.Location = new System.Drawing.Point(127, 39);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(100, 21);
            this.lblAccount.TabIndex = 73;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(327, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 72;
            this.label13.Text = "失败的局数：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(327, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 71;
            this.label12.Text = "平局的局数：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(327, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 70;
            this.label11.Text = "胜利的局数：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(327, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 69;
            this.label10.Text = "游戏总局数：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 68;
            this.label9.Text = "经验：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(72, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 67;
            this.label8.Text = "等级：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 66;
            this.label7.Text = "久游休闲币：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 65;
            this.label6.Text = "游戏币：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 64;
            this.label5.Text = "性别：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 63;
            this.label4.Text = "呢称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 62;
            this.label3.Text = "玩家ID：";
            // 
            // richInfo
            // 
            this.richInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richInfo.Location = new System.Drawing.Point(3, 3);
            this.richInfo.Name = "richInfo";
            this.richInfo.ReadOnly = true;
            this.richInfo.Size = new System.Drawing.Size(547, 328);
            this.richInfo.TabIndex = 0;
            this.richInfo.Text = "";
            // 
            // PartInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 475);
            this.Controls.Add(this.tabResult);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "PartInfo";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "人物角色资料[超级乐者]";
            this.Load += new System.EventHandler(this.PartInfo_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabResult.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabEdit.ResumeLayout(false);
            this.dpInfoContain.ResumeLayout(false);
            this.dpInfoContain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtAorN;
        private System.Windows.Forms.Label lblAorN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.RadioButton rbtnNick;
        private System.Windows.Forms.RadioButton rbtnAccount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabResult;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.Panel dpInfoContain;
        private System.Windows.Forms.ComboBox lblExp;
        private System.Windows.Forms.ComboBox lblLevel;
        private System.Windows.Forms.ComboBox lblSex;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox lblLost;
        private System.Windows.Forms.TextBox lblDraw;
        private System.Windows.Forms.TextBox lblWin;
        private System.Windows.Forms.TextBox lblGameCount;
        private System.Windows.Forms.TextBox lblG;
        private System.Windows.Forms.TextBox lblMCash;
        private System.Windows.Forms.TextBox lblNick;
        private System.Windows.Forms.TextBox lblAccount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richInfo;
    }
}