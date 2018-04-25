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
	/// FrmNotesProcess ��ժҪ˵����
	/// </summary>
	
	public class NotesProcess : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbTransMan;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private Label label2;
        private TextBox txtReason;
        private BackgroundWorker backgroundWorkerBtnOK;	//�༭ʱ���͹�����ģ����Ϣ	
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NotesProcess()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}
		public NotesProcess(int notesID)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
			this.notesID = notesID;

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
            this.label1 = new System.Windows.Forms.Label();
            this.cbTransMan = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.backgroundWorkerBtnOK = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ת������";
            // 
            // cbTransMan
            // 
            this.cbTransMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransMan.Location = new System.Drawing.Point(14, 25);
            this.cbTransMan.Name = "cbTransMan";
            this.cbTransMan.Size = new System.Drawing.Size(512, 20);
            this.cbTransMan.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "ȷ��";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(97, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "ȡ��";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "����(100���ַ���)��";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(12, 71);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(514, 285);
            this.txtReason.TabIndex = 5;
            // 
            // backgroundWorkerBtnOK
            // 
            this.backgroundWorkerBtnOK.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBtnOK_DoWork);
            this.backgroundWorkerBtnOK.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBtnOK_RunWorkerCompleted);
            // 
            // NotesProcess
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(538, 397);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbTransMan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotesProcess";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notes ����";
            this.Load += new System.EventHandler(this.FrmNotesProcess_Load);
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
			//ModiUserPwd modi = new ModiUserPwd();
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

		#region ����
		private CSocketEvent m_ClientEvent = null;
		private C_Global.CEnum.Message_Body[,] mResult = null;
		private int notesID = 0;
		#endregion

		#region �¼�

		/// <summary>
		/// �����ʼ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmNotesProcess_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();

			//��ʽ��Ϣ
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_QUERY_ALL, C_Global.CEnum.Msg_Category.USER_ADMIN, null);
            }
			//���״̬
			if (mResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
			{
				MessageBox.Show(mResult[0,0].oContent.ToString());
				//Application.Exit();
				return;
			}
			for(int i=0;i<mResult.GetLength(0);i++)
			{
				cbTransMan.Items.Add(mResult[i,6].oContent.ToString().Trim());
			}
		}

		/// <summary>
		/// ȷ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
            if (cbTransMan.Text == null || cbTransMan.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "NP_Code_ChoosePeople"));
                return;
            }

            if (txtReason.Text.Length > 100)
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "NP_Code_CharLimit"));
                return;
            }

			C_Global.CEnum.Message_Body[,] resultMsgBody = null;
            button1.Enabled = false;
            Cursor = Cursors.AppStarting;
			try
			{
				C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];

				messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
				messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

				messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[1].eName = C_Global.CEnum.TagName.Process_Man;
				messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

				messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
				messageBody[2].eName = C_Global.CEnum.TagName.Process_Date;
				messageBody[2].oContent = DateTime.Now;

				messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[3].eName = C_Global.CEnum.TagName.Transmit_Man;
				messageBody[3].oContent = GetUserID(this.cbTransMan.SelectedItem.ToString().Trim());

				messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[4].eName = C_Global.CEnum.TagName.Letter_ID;
				messageBody[4].oContent = notesID;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[5].eName = C_Global.CEnum.TagName.Process_Reason;
                messageBody[5].oContent = txtReason.Text;

                this.backgroundWorkerBtnOK.RunWorkerAsync(messageBody);


                //resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_LETTER_PROCESS,C_Global.CEnum.Msg_Category.NOTES_ADMIN,messageBody);
                ////���״̬
                //if (resultMsgBody[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(resultMsgBody[0,0].oContent.ToString());
                //    //Application.Exit();
                //    return;
                //}

                //if(resultMsgBody[0,0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MGM", "NP_Code_Succeed"));
                //    this.Close();	
                //}

                //if (resultMsgBody[0, 0].oContent.ToString().Trim().ToUpper().Equals("FAILURE"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MGM", "NP_Code_Failed"));
                //    this.Close();
                //}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		#endregion

		#region �Զ��庯��
		private int GetUserID(string userName)
		{
			int returnValue = 0;
			for(int i=0;i<mResult.GetLength(0);i++)
			{
				if(mResult[i,6].oContent.ToString().Trim() == userName)
				{
					returnValue = int.Parse(mResult[i,0].oContent.ToString());
				}
			}
			return returnValue;
		}
		#endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.Text = config.ReadConfigValue("MGM", "NP_UI_Caption");


            this.label1.Text = config.ReadConfigValue("MGM", "NP_UI_TransferTo");
            this.label2.Text = config.ReadConfigValue("MGM", "NP_UI_Description");
            this.button1.Text = config.ReadConfigValue("MGM", "NP_UI_BtnApply");
            this.button2.Text = config.ReadConfigValue("MGM", "NP_UI_BtnCancel");
        }


        #endregion

        private void backgroundWorkerBtnOK_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_LETTER_PROCESS, C_Global.CEnum.Msg_Category.NOTES_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerBtnOK_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] resultMsgBody = (CEnum.Message_Body[,])e.Result;

            //���״̬
            if (resultMsgBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(resultMsgBody[0, 0].oContent.ToString());
                //Application.Exit();
                return;
            }

            if (resultMsgBody[0, 0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "NP_Code_Succeed"));
                this.Close();
            }

            if (resultMsgBody[0, 0].oContent.ToString().Trim().ToUpper().Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "NP_Code_Failed"));
                this.Close();
            }
        }
		
	}
}
