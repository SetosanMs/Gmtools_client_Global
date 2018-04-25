using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using C_Global;
using C_Event;

using Language;

namespace M_GM
{
	/// <summary>
	/// NewModule ��ժҪ˵����
	/// </summary>
	[C_Global.CModuleAttribute("��Ϸģ�����", "NewModule", "�����Ϸģ��", "User Group")]
	public class NewModule : System.Windows.Forms.Form
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NewModule()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		public NewModule(bool isModify,C_Global.CEnum.Message_Body[] requestMsgBody)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
			this.isModify = isModify;
			this.requestMsgBody = requestMsgBody;
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.backgroundWorkerBtnOK = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(285, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "ȡ��";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "ȷ��";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(108, 168);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(252, 21);
            this.textBox3.TabIndex = 27;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(108, 136);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(252, 21);
            this.textBox2.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 21);
            this.textBox1.TabIndex = 25;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "11",
            "22",
            "33",
            "44"});
            this.comboBox1.Location = new System.Drawing.Point(108, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(252, 20);
            this.comboBox1.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 23;
            this.label4.Text = "�衡������";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "ģ��������";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "ģ�����ƣ�";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "������Ϸ��";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.dividerPanel1.BorderSide = System.Windows.Forms.Border3DSide.Bottom;
            this.dividerPanel1.Controls.Add(this.label5);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(370, 48);
            this.dividerPanel1.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "������Ϸ��ӵ��ģ��";
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel2.Controls.Add(this.button2);
            this.dividerPanel2.Controls.Add(this.button1);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dividerPanel2.Location = new System.Drawing.Point(0, 199);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(370, 48);
            this.dividerPanel2.TabIndex = 31;
            // 
            // backgroundWorkerBtnOK
            // 
            this.backgroundWorkerBtnOK.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBtnOK_DoWork);
            this.backgroundWorkerBtnOK.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBtnOK_RunWorkerCompleted);
            // 
            // NewModule
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(370, 247);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewModule";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ģ������";
            this.Load += new System.EventHandler(this.NewModule_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region ���ú���
		/// <summary>
		/// ��������еĴ���
		/// </summary>
		/// <param name="oParent">MDI ����ĸ�����</param>
		/// <param name="oSocket">Socket</param>
		/// <returns>����еĴ���</returns>
		public Form CreateModule(object oParent, object oEvent)
		{
			this.m_ClientEvent = (CSocketEvent)oEvent;

			if (oParent != null)
			{
				this.MdiParent = (Form)oParent;
				this.Show();
			}
			else
			{
				this.ShowDialog();
			}

			return this;
			
		}
		#endregion

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;

		#region ����
		private CSocketEvent m_ClientEvent = null;

		private C_Global.CEnum.Message_Body[] mMsgBody = null;
		private C_Global.CEnum.Message_Body[,] mResult = null;

		bool isModify = false;
		private DividerPanel.DividerPanel dividerPanel1;
		private System.Windows.Forms.Label label5;
		private DividerPanel.DividerPanel dividerPanel2;
        private BackgroundWorker backgroundWorkerBtnOK;					//��Ϸ�༭״̬
		C_Global.CEnum.Message_Body[] requestMsgBody = null;	//�༭ʱ���͹�����ģ����Ϣ	
		#endregion

		/// <summary>
		/// ����/�༭ģ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
            button1.Enabled = false;
            Cursor = Cursors.AppStarting;
            //����
			if (!isModify)
			{
				C_Global.CEnum.Message_Body[] mMsg = new C_Global.CEnum.Message_Body[5];
				mMsg[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				mMsg[0].eName = C_Global.CEnum.TagName.UserByID;
				mMsg[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

				mMsg[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				mMsg[1].eName = C_Global.CEnum.TagName.GameID;
				mMsg[1].oContent = GMAdmin.GetContentID(mResult, comboBox1.SelectedItem.ToString());

				mMsg[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
				mMsg[2].eName = C_Global.CEnum.TagName.ModuleName;
				mMsg[2].oContent = textBox1.Text;

				mMsg[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
				mMsg[3].eName = C_Global.CEnum.TagName.ModuleClass;
				mMsg[3].oContent = textBox2.Text;

				mMsg[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
				mMsg[4].eName = C_Global.CEnum.TagName.ModuleContent;
				mMsg[4].oContent = textBox3.Text;

                this.backgroundWorkerBtnOK.RunWorkerAsync(mMsg);

                //C_Global.CEnum.Message_Body[,] mResultSave = GMAdmin.ModuleAdd(this.m_ClientEvent, mMsg);

                //try
                //{
                //    int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
                //    for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
                //    {
                //        GMAdmin.ModuleAdd((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex), mMsg);
                //    }
                //}
                //catch { }



                //if (mResultSave[0,0].oContent.Equals("SUCESS"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MGM", "NM_Code_SaveOk"));
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show(config.ReadConfigValue("MGM", "NM_Code_SaveFailed"));
                //}

			}
			else//�༭
			{
				C_Global.CEnum.Message_Body[] mMsg = new C_Global.CEnum.Message_Body[6];


				mMsg[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				mMsg[0].eName = C_Global.CEnum.TagName.UserByID;
				mMsg[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

				mMsg[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				mMsg[1].eName = C_Global.CEnum.TagName.Module_ID;
				mMsg[1].oContent = int.Parse(requestMsgBody[0].oContent.ToString());

				mMsg[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				mMsg[2].eName = C_Global.CEnum.TagName.GameID;
				mMsg[2].oContent = GMAdmin.GetContentID(mResult, comboBox1.SelectedItem.ToString());

				mMsg[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
				mMsg[3].eName = C_Global.CEnum.TagName.ModuleName;
				mMsg[3].oContent = textBox1.Text;

				mMsg[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
				mMsg[4].eName = C_Global.CEnum.TagName.ModuleClass;
				mMsg[4].oContent = textBox2.Text;

				mMsg[5].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
				mMsg[5].eName = C_Global.CEnum.TagName.ModuleContent;
				mMsg[5].oContent = textBox3.Text;

                this.backgroundWorkerBtnOK.RunWorkerAsync(mMsg);

                //C_Global.CEnum.Message_Body[,] mResultSave = GMAdmin.ModuleModi(this.m_ClientEvent, mMsg);

                //try
                //{
                //     int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
                //    for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
                //    {
                //        GMAdmin.ModuleModi((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex), mMsg);
                //    }
                //}
                //catch { }

                //if (mResultSave[0,0].oContent.Equals("SUCESS"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MGM", "NM_Code_SaveOk"));
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show(config.ReadConfigValue("MGM", "NM_Code_SaveFailed"));
                //}
			}
		}

		private void NewModule_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();
			//���
			if (!isModify)
			{
				//��ʼ������
				comboBox1.Items.Clear();
				textBox1.Clear();
				textBox2.Clear();
				textBox3.Clear();
			
				//��ʽ��Ϣ
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, this.mMsgBody);
                }
				//���״̬
				if (mResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
				{
					MessageBox.Show(mResult[0,0].oContent.ToString());
					//Application.Exit();
					return;
				}

				comboBox1 = GMAdmin.DisplayComboBox(m_ClientEvent, comboBox1, mResult);
			}
			else//�༭
			{
				comboBox1.Items.Clear();
				textBox1.Clear();
				textBox2.Clear();
				textBox3.Clear();

                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, this.mMsgBody);
                }
				//���״̬
				if (mResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
				{
					MessageBox.Show(mResult[0,0].oContent.ToString());
					//Application.Exit();
					return;
				}
				comboBox1 = GMAdmin.DisplayComboBox(m_ClientEvent, comboBox1, mResult);
				int index = comboBox1.FindString(requestMsgBody[1].oContent.ToString().Trim());
				this.comboBox1.SelectedIndex = index;
				//this.comboBox1.Text = requestMsgBody[1].oContent.ToString().Trim();
				this.textBox1.Text = requestMsgBody[2].oContent.ToString().Trim();
				this.textBox2.Text = requestMsgBody[3].oContent.ToString().Trim();
				this.textBox3.Text = requestMsgBody[4].oContent.ToString().Trim();
			}
		}


        #region ���Կ�
        /// <summary>
        ///�����ֿ�
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// ��ʼ�����������Կ�
        /// </summary>
        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MGM", "NM_UI_Caption");

            this.label5.Text = config.ReadConfigValue("MGM", "NM_UI_Content");
            this.label1.Text = config.ReadConfigValue("MGM", "NM_UI_BelongToGAme");
            this.label2.Text = config.ReadConfigValue("MGM", "NM_UI_ModuleName");
            this.label3.Text = config.ReadConfigValue("MGM", "NM_UI_MOduleClass");
            this.label4.Text = config.ReadConfigValue("MGM", "NM_UI_Des");

            this.button1.Text = config.ReadConfigValue("MGM", "NM_UI_BtnApply");
            this.button2.Text = config.ReadConfigValue("MGM", "NM_UI_BtnCancel");
        }


        #endregion

        private void backgroundWorkerBtnOK_DoWork(object sender, DoWorkEventArgs e)
        {
            CEnum.Message_Body[] mMsg = (CEnum.Message_Body[])e.Argument;
            lock (typeof(C_Event.CSocketEvent))
            {
                if (mMsg.Length == 5)
                {
                    e.Result = GMAdmin.ModuleAdd(this.m_ClientEvent, mMsg);
                    try
                    {
                        int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
                        for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
                        {
                            GMAdmin.ModuleAdd((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex), mMsg);
                        }
                    }
                    catch { }
                }
                else
                {
                    e.Result = GMAdmin.ModuleModi(this.m_ClientEvent, mMsg);
                    try
                    {
                        int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
                        for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
                        {
                            GMAdmin.ModuleModi((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex), mMsg);
                        }
                    }
                    catch { }
                }
            }
        }

        private void backgroundWorkerBtnOK_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            Cursor = Cursors.Default;
            
            CEnum.Message_Body[,] mResultSave = (CEnum.Message_Body[,])e.Result;
            if (mResultSave[0, 0].oContent.Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "NM_Code_SaveOk"));
                this.Close();
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "NM_Code_SaveFailed"));
            }

        }
	}
}
