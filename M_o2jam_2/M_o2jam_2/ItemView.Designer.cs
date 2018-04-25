namespace M_o2jam_2
{
    partial class ItemView
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
            this.dgBodyCotain = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.dividerPanel6 = new DividerPanel.DividerPanel();
            this.dividerPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBodyCotain)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.groupBox1);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(601, 83);
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
            this.groupBox1.Size = new System.Drawing.Size(601, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(412, 28);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "重置";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbtnNick
            // 
            this.rbtnNick.AutoSize = true;
            this.rbtnNick.Enabled = false;
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
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.dividerPanel2.Location = new System.Drawing.Point(10, 93);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(601, 10);
            this.dividerPanel2.TabIndex = 1;
            // 
            // dgBodyCotain
            // 
            this.dgBodyCotain.AllowUserToAddRows = false;
            this.dgBodyCotain.AllowUserToDeleteRows = false;
            this.dgBodyCotain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBodyCotain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBodyCotain.Location = new System.Drawing.Point(5, 19);
            this.dgBodyCotain.Name = "dgBodyCotain";
            this.dgBodyCotain.ReadOnly = true;
            this.dgBodyCotain.RowTemplate.Height = 23;
            this.dgBodyCotain.Size = new System.Drawing.Size(262, 321);
            this.dgBodyCotain.TabIndex = 0;
            this.dgBodyCotain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBodyCotain_CellClick);
            this.dgBodyCotain.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgBodyCotain_ColumnHeaderMouseClick);
            this.dgBodyCotain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgBodyCotain_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgBodyCotain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(10, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(272, 345);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "身上道具：";
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.BorderSide = System.Windows.Forms.Border3DSide.Right;
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.dividerPanel3.Location = new System.Drawing.Point(282, 103);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Size = new System.Drawing.Size(10, 345);
            this.dividerPanel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(301, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "操作：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "当前道具：";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(303, 154);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dividerPanel6
            // 
            this.dividerPanel6.AllowDrop = true;
            this.dividerPanel6.BorderSide = System.Windows.Forms.Border3DSide.Bottom;
            this.dividerPanel6.Location = new System.Drawing.Point(340, 104);
            this.dividerPanel6.Name = "dividerPanel6";
            this.dividerPanel6.Size = new System.Drawing.Size(266, 10);
            this.dividerPanel6.TabIndex = 14;
            // 
            // ItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 458);
            this.Controls.Add(this.dividerPanel6);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "ItemView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "身上道具[超级乐者]";
            this.Load += new System.EventHandler(this.ItemView_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBodyCotain)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DividerPanel.DividerPanel dividerPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbtnNick;
        private System.Windows.Forms.RadioButton rbtnAccount;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtAorN;
        private System.Windows.Forms.Label lblAorN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxServerIP;
        private DividerPanel.DividerPanel dividerPanel2;
        private System.Windows.Forms.DataGridView dgBodyCotain;
        private System.Windows.Forms.GroupBox groupBox2;
        private DividerPanel.DividerPanel dividerPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDel;
        private DividerPanel.DividerPanel dividerPanel6;
    }
}