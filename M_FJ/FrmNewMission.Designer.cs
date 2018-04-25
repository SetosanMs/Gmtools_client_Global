namespace M_FJ
{
    partial class FrmNewMission
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
            this.labelNick = new System.Windows.Forms.Label();
            this.textBoxNick = new System.Windows.Forms.TextBox();
            this.labelQuestID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBoxTaskID = new System.Windows.Forms.ComboBox();
            this.comboBoxTaskName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Location = new System.Drawing.Point(49, 79);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(65, 12);
            this.labelNick.TabIndex = 0;
            this.labelNick.Text = "角色名称：";
            // 
            // textBoxNick
            // 
            this.textBoxNick.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxNick.Location = new System.Drawing.Point(120, 76);
            this.textBoxNick.Name = "textBoxNick";
            this.textBoxNick.ReadOnly = true;
            this.textBoxNick.Size = new System.Drawing.Size(100, 21);
            this.textBoxNick.TabIndex = 1;
            // 
            // labelQuestID
            // 
            this.labelQuestID.AutoSize = true;
            this.labelQuestID.Location = new System.Drawing.Point(61, 44);
            this.labelQuestID.Name = "labelQuestID";
            this.labelQuestID.Size = new System.Drawing.Size(53, 12);
            this.labelQuestID.TabIndex = 2;
            this.labelQuestID.Text = "任务ID：";
            this.labelQuestID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "任务内容：";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(49, 162);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(65, 12);
            this.labelState.TabIndex = 6;
            this.labelState.Text = "任务状态：";
            // 
            // comboBoxState
            // 
            this.comboBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Items.AddRange(new object[] {
            "可接领任务",
            "未完成任务",
            "已完成任务",
            "任务失败"});
            this.comboBoxState.Location = new System.Drawing.Point(120, 159);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(121, 20);
            this.comboBoxState.TabIndex = 7;
            // 
            // buttonNew
            // 
            this.buttonNew.Enabled = false;
            this.buttonNew.Location = new System.Drawing.Point(55, 211);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(59, 23);
            this.buttonNew.TabIndex = 9;
            this.buttonNew.Text = "添加";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(185, 211);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(59, 23);
            this.buttonDel.TabIndex = 10;
            this.buttonDel.Text = "删除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(120, 211);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(59, 23);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // comboBoxTaskID
            // 
            this.comboBoxTaskID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTaskID.Enabled = false;
            this.comboBoxTaskID.FormattingEnabled = true;
            this.comboBoxTaskID.Location = new System.Drawing.Point(120, 41);
            this.comboBoxTaskID.Name = "comboBoxTaskID";
            this.comboBoxTaskID.Size = new System.Drawing.Size(121, 20);
            this.comboBoxTaskID.TabIndex = 12;
            this.comboBoxTaskID.Visible = false;
            // 
            // comboBoxTaskName
            // 
            this.comboBoxTaskName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxTaskName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTaskName.Enabled = false;
            this.comboBoxTaskName.FormattingEnabled = true;
            this.comboBoxTaskName.Location = new System.Drawing.Point(120, 117);
            this.comboBoxTaskName.Name = "comboBoxTaskName";
            this.comboBoxTaskName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxTaskName.TabIndex = 13;
            // 
            // FrmNewMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 312);
            this.Controls.Add(this.comboBoxTaskName);
            this.Controls.Add(this.comboBoxTaskID);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.comboBoxState);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelQuestID);
            this.Controls.Add(this.textBoxNick);
            this.Controls.Add(this.labelNick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmNewMission";
            this.Text = "任务信息";
            this.Load += new System.EventHandler(this.FrmNewMission_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.TextBox textBoxNick;
        private System.Windows.Forms.Label labelQuestID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxTaskID;
        private System.Windows.Forms.ComboBox comboBoxTaskName;
    }
}