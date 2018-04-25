namespace M_Audition
{
    partial class FrmTokenView
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
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.labelSort = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.TpgUserData = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonView = new System.Windows.Forms.Button();
            this.comboBoxPage = new System.Windows.Forms.ComboBox();
            this.labelEnd = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.GroupView = new System.Windows.Forms.GroupBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.backgroundWorkerLock = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCurrent = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUnban = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUnlock = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerView = new System.ComponentModel.BackgroundWorker();
            this.TBCToken = new System.Windows.Forms.TabControl();
            this.TpgView = new System.Windows.Forms.TabPage();
            this.TpgUserData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.GroupView.SuspendLayout();
            this.TBCToken.SuspendLayout();
            this.TpgView.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Location = new System.Drawing.Point(196, 49);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(170, 20);
            this.comboBoxSort.TabIndex = 14;
            // 
            // labelSort
            // 
            this.labelSort.AutoSize = true;
            this.labelSort.Location = new System.Drawing.Point(125, 55);
            this.labelSort.Name = "labelSort";
            this.labelSort.Size = new System.Drawing.Size(65, 12);
            this.labelSort.TabIndex = 13;
            this.labelSort.Text = "查看类别：";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "查看令牌",
            "查看令牌用户资料"});
            this.comboBoxType.Location = new System.Drawing.Point(196, 23);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(170, 20);
            this.comboBoxType.TabIndex = 12;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(125, 26);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(65, 12);
            this.labelType.TabIndex = 11;
            this.labelType.Text = "查看类型：";
            // 
            // TpgUserData
            // 
            this.TpgUserData.Controls.Add(this.dataGridView2);
            this.TpgUserData.Controls.Add(this.groupBox1);
            this.TpgUserData.Location = new System.Drawing.Point(4, 21);
            this.TpgUserData.Name = "TpgUserData";
            this.TpgUserData.Size = new System.Drawing.Size(556, 313);
            this.TpgUserData.TabIndex = 3;
            this.TpgUserData.Text = "当前令牌用户资料";
            this.TpgUserData.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 215);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(556, 98);
            this.dataGridView2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 215);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请输入信息";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(580, 189);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(85, 20);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "结束日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "开始日期：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(197, 100);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(170, 21);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(197, 73);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(170, 21);
            this.dateTimePicker2.TabIndex = 16;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(197, 46);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(170, 21);
            this.textBox7.TabIndex = 15;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "用户名",
            "服务号",
            "序列号",
            "身份证"});
            this.comboBox2.Location = new System.Drawing.Point(197, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(170, 20);
            this.comboBox2.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "查看类别：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(301, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(197, 142);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "查看";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(300, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // buttonView
            // 
            this.buttonView.Location = new System.Drawing.Point(196, 174);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(66, 23);
            this.buttonView.TabIndex = 9;
            this.buttonView.Text = "查看";
            this.buttonView.UseVisualStyleBackColor = true;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // comboBoxPage
            // 
            this.comboBoxPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPage.FormattingEnabled = true;
            this.comboBoxPage.Location = new System.Drawing.Point(580, 189);
            this.comboBoxPage.Name = "comboBoxPage";
            this.comboBoxPage.Size = new System.Drawing.Size(85, 20);
            this.comboBoxPage.TabIndex = 20;
            this.comboBoxPage.Visible = false;
            this.comboBoxPage.SelectedIndexChanged += new System.EventHandler(this.comboBoxPage_SelectedIndexChanged);
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(125, 133);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(65, 12);
            this.labelEnd.TabIndex = 19;
            this.labelEnd.Text = "结束日期：";
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(125, 106);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(65, 12);
            this.labelStart.TabIndex = 18;
            this.labelStart.Text = "开始日期：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 221);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(786, 203);
            this.dataGridView1.TabIndex = 3;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(196, 129);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(170, 21);
            this.dateTimePickerEnd.TabIndex = 17;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(196, 102);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(170, 21);
            this.dateTimePickerStart.TabIndex = 16;
            // 
            // GroupView
            // 
            this.GroupView.Controls.Add(this.comboBoxPage);
            this.GroupView.Controls.Add(this.labelEnd);
            this.GroupView.Controls.Add(this.labelStart);
            this.GroupView.Controls.Add(this.dateTimePickerEnd);
            this.GroupView.Controls.Add(this.dateTimePickerStart);
            this.GroupView.Controls.Add(this.textBoxValue);
            this.GroupView.Controls.Add(this.comboBoxSort);
            this.GroupView.Controls.Add(this.labelSort);
            this.GroupView.Controls.Add(this.comboBoxType);
            this.GroupView.Controls.Add(this.labelType);
            this.GroupView.Controls.Add(this.button2);
            this.GroupView.Controls.Add(this.buttonView);
            this.GroupView.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupView.Location = new System.Drawing.Point(0, 0);
            this.GroupView.Name = "GroupView";
            this.GroupView.Size = new System.Drawing.Size(786, 221);
            this.GroupView.TabIndex = 2;
            this.GroupView.TabStop = false;
            this.GroupView.Text = "请输入信息";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(196, 75);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(170, 21);
            this.textBoxValue.TabIndex = 15;
            // 
            // backgroundWorkerCurrent
            // 
            this.backgroundWorkerCurrent.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCurrent_DoWork);
            this.backgroundWorkerCurrent.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCurrent_RunWorkerCompleted);
            // 
            // backgroundWorkerView
            // 
            this.backgroundWorkerView.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerView_DoWork);
            this.backgroundWorkerView.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerView_RunWorkerCompleted);
            // 
            // TBCToken
            // 
            this.TBCToken.Controls.Add(this.TpgView);
            this.TBCToken.Controls.Add(this.TpgUserData);
            this.TBCToken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBCToken.Location = new System.Drawing.Point(0, 0);
            this.TBCToken.Name = "TBCToken";
            this.TBCToken.SelectedIndex = 0;
            this.TBCToken.Size = new System.Drawing.Size(794, 449);
            this.TBCToken.TabIndex = 1;
            // 
            // TpgView
            // 
            this.TpgView.Controls.Add(this.dataGridView1);
            this.TpgView.Controls.Add(this.GroupView);
            this.TpgView.Location = new System.Drawing.Point(4, 21);
            this.TpgView.Name = "TpgView";
            this.TpgView.Size = new System.Drawing.Size(786, 424);
            this.TpgView.TabIndex = 2;
            this.TpgView.Text = "查看令牌资料";
            this.TpgView.UseVisualStyleBackColor = true;
            // 
            // FrmTokenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 449);
            this.Controls.Add(this.TBCToken);
            this.Name = "FrmTokenView";
            this.Text = "9YOU令牌查看资料";
            this.Load += new System.EventHandler(this.FrmToken_Load);
            this.TpgUserData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.GroupView.ResumeLayout(false);
            this.GroupView.PerformLayout();
            this.TBCToken.ResumeLayout(false);
            this.TpgView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Label labelSort;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.TabPage TpgUserData;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.ComboBox comboBoxPage;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.GroupBox GroupView;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLock;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCurrent;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUnban;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUnlock;
        private System.ComponentModel.BackgroundWorker backgroundWorkerView;
        private System.Windows.Forms.TabControl TBCToken;
        private System.Windows.Forms.TabPage TpgView;
    }
}