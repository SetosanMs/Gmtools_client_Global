using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using C_Event;
using C_Global;
using C_Socket;

using DividerPanel;

using Language;

namespace M_GM
{
	/// <summary>
	/// NewUser ��ժҪ˵����
    /// 
    /// ����Ա��Ϊ��0,1,2 ����
    /// 0: ��ͨ����Ա
    /// 1: ��������Ա��
    /// 2: ���ż������Ա
	/// </summary>
	[C_Global.CModuleAttribute("GM�û����", "NewUser", "���GM�û���Ϣ", "User Group")]
	public class NewUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnAddUser;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TextBox txtConfirm;
		private System.Windows.Forms.TextBox txtPasswd;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox userStatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtRealName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox department;
		private DividerPanel.DividerPanel dividerPanel1;
		private DividerPanel.DividerPanel dividerPanel2;
        private CheckBox chkSystmeAdmin;
        private CheckBox chkDeptAdmin;
        private BackgroundWorker backgroundWorkerBtnOK;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NewUser()
		{
			InitializeComponent();
		}

		public NewUser(C_Global.CEnum.Message_Body[,] userInfos)
		{
			InitializeComponent();
			
			this.userInfos = userInfos;
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.userStatus = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.ComboBox();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.chkSystmeAdmin = new System.Windows.Forms.CheckBox();
            this.chkDeptAdmin = new System.Windows.Forms.CheckBox();
            this.backgroundWorkerBtnOK = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(293, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "ȡ��";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(200, 16);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 33;
            this.btnAddUser.Text = "ȷ��";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // userStatus
            // 
            this.userStatus.Location = new System.Drawing.Point(16, 272);
            this.userStatus.Name = "userStatus";
            this.userStatus.Size = new System.Drawing.Size(88, 24);
            this.userStatus.TabIndex = 46;
            this.userStatus.Text = "ͣ�ø��ʻ�";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "ʹ��ʱЧ��";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 240);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(280, 21);
            this.dateTimePicker1.TabIndex = 43;
            this.dateTimePicker1.Value = new System.DateTime(2006, 2, 23, 9, 55, 50, 703);
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(88, 128);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(280, 21);
            this.txtConfirm.TabIndex = 42;
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(88, 96);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.Size = new System.Drawing.Size(280, 21);
            this.txtPasswd.TabIndex = 41;
            // 
            // txtRealName
            // 
            this.txtRealName.Location = new System.Drawing.Point(88, 168);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(280, 21);
            this.txtRealName.TabIndex = 40;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(88, 64);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(280, 21);
            this.txtUser.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 38;
            this.label1.Text = "ȷ�����룺";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "�ܡ����룺";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "��ʵ������";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "�� �� ����";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(384, 16);
            this.label3.TabIndex = 61;
            this.label3.Text = "������ʺ�Ϊ��ϵͳ������Ϸ���ã����������Ϻ����ÿ���Ȩ��";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "���ڲ��ţ�";
            // 
            // department
            // 
            this.department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.department.Location = new System.Drawing.Point(88, 200);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(280, 20);
            this.department.TabIndex = 65;
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.dividerPanel1.BorderSide = System.Windows.Forms.Border3DSide.Bottom;
            this.dividerPanel1.Controls.Add(this.label3);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(0, 0);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(386, 48);
            this.dividerPanel1.TabIndex = 66;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel2.Controls.Add(this.btnAddUser);
            this.dividerPanel2.Controls.Add(this.btnClose);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dividerPanel2.Location = new System.Drawing.Point(0, 323);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(386, 48);
            this.dividerPanel2.TabIndex = 67;
            // 
            // chkSystmeAdmin
            // 
            this.chkSystmeAdmin.AutoSize = true;
            this.chkSystmeAdmin.Location = new System.Drawing.Point(16, 301);
            this.chkSystmeAdmin.Name = "chkSystmeAdmin";
            this.chkSystmeAdmin.Size = new System.Drawing.Size(108, 16);
            this.chkSystmeAdmin.TabIndex = 68;
            this.chkSystmeAdmin.Text = "ϵͳ��������Ա";
            this.chkSystmeAdmin.UseVisualStyleBackColor = true;
            this.chkSystmeAdmin.Click += new System.EventHandler(this.chkSystmeAdmin_Click);
            // 
            // chkDeptAdmin
            // 
            this.chkDeptAdmin.AutoSize = true;
            this.chkDeptAdmin.Location = new System.Drawing.Point(130, 301);
            this.chkDeptAdmin.Name = "chkDeptAdmin";
            this.chkDeptAdmin.Size = new System.Drawing.Size(108, 16);
            this.chkDeptAdmin.TabIndex = 69;
            this.chkDeptAdmin.Text = "���ż������Ա";
            this.chkDeptAdmin.UseVisualStyleBackColor = true;
            this.chkDeptAdmin.Click += new System.EventHandler(this.chkDeptAdmin_Click);
            // 
            // backgroundWorkerBtnOK
            // 
            this.backgroundWorkerBtnOK.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBtnOK_DoWork);
            this.backgroundWorkerBtnOK.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBtnOK_RunWorkerCompleted);
            // 
            // NewUser
            // 
            this.AcceptButton = this.btnAddUser;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(386, 371);
            this.Controls.Add(this.chkDeptAdmin);
            this.Controls.Add(this.chkSystmeAdmin);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.department);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.txtRealName);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewUser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�û����";
            this.Load += new System.EventHandler(this.NewUser_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region �¼�
		/// <summary>
		/// �����û�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddUser_Click(object sender, System.EventArgs e)
		{
			#region ���
			if (this.txtUser.Text == null || this.txtUser.Text == "")
			{
                MessageBox.Show(config.ReadConfigValue("MGM", "NU_Code_InputAccount"));
				this.txtUser.Focus();
				return;
			}

			if (this.txtPasswd.Text == null || this.txtPasswd.Text == "")
			{
                MessageBox.Show(config.ReadConfigValue("MGM", "NU_Code_InputPwd"));
				this.txtPasswd.Focus();
				return;
			}

			if (this.txtConfirm.Text == null || this.txtConfirm.Text == "")
			{
                MessageBox.Show(config.ReadConfigValue("MGM", "Nu_Code_InputConfPwd"));
				this.txtConfirm.Focus();
				return;
			}

			if (this.txtRealName.Text == null || this.txtRealName.Text == "")
			{
                MessageBox.Show(config.ReadConfigValue("MGM", "Nu_Code_InputRealName"));
				this.txtRealName.Focus();
				return;
			}

			if (this.department.Text == null || this.department.Text == "")
			{
                MessageBox.Show(config.ReadConfigValue("MGM", "Nu_Code_ChooseDepartment"));
				this.department.Focus();
				return;
			}

			if (this.txtPasswd.Text.Trim() != this.txtConfirm.Text.Trim())
			{
                MessageBox.Show(config.ReadConfigValue("MGM", "Nu_Code_PwdErr"));
				this.txtConfirm.Focus();
				return;
			}

			if (IsExistUserName(this.txtUser.Text.ToString().Trim()))
			{
                MessageBox.Show(config.ReadConfigValue("MGM", "Nu_Code_AccountExistErr"));
				this.txtUser.Focus();
				return;
			}
			#endregion

            btnAddUser.Enabled = false;
            Cursor = Cursors.AppStarting;

			C_Global.CEnum.Message_Body[,] resultMsgBody = null;

			C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[8];
			messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
			messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
			messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

			messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
			messageBody[1].eName = C_Global.CEnum.TagName.UserName;
			messageBody[1].oContent = this.txtUser.Text.ToString().Trim();

			messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
			messageBody[2].eName = C_Global.CEnum.TagName.PassWord;
			messageBody[2].oContent = this.txtPasswd.Text.ToString().Trim();

			messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
			messageBody[3].eName = C_Global.CEnum.TagName.Limit;
			messageBody[3].oContent = Convert.ToDateTime(this.dateTimePicker1.Text);


			messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
			messageBody[4].eName = C_Global.CEnum.TagName.User_Status;
			messageBody[4].oContent = this.userStatus.Checked ? 0 : 1;

			messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
			messageBody[5].eName = C_Global.CEnum.TagName.RealName;
			messageBody[5].oContent = this.txtRealName.Text.Trim();

			messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
			messageBody[6].eName = C_Global.CEnum.TagName.DepartID;
			messageBody[6].oContent = GetDepartmentID(this.department.SelectedItem.ToString().Trim());

            messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[7].eName = C_Global.CEnum.TagName.SysAdmin;
            messageBody[7].oContent = chkSystmeAdmin.Checked ? 1 : chkDeptAdmin.Checked ? 2 : 0;

			try
			{
                this.backgroundWorkerBtnOK.RunWorkerAsync(messageBody);
                //    resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_CREATE,C_Global.CEnum.Msg_Category.USER_ADMIN,messageBody);

            //    try
            //    {
            //        int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
            //        for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
            //        {
            //            ((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex)).RequestResult(C_Global.CEnum.ServiceKey.USER_CREATE, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);
            //        }
            //    }
            //    catch { }
            //    //���״̬
            //    if (resultMsgBody[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(resultMsgBody[0,0].oContent.ToString());
            //        //Application.Exit();
            //        return;
            //    }

            //    if(resultMsgBody[0,0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
            //    {
            //        MessageBox.Show(config.ReadConfigValue("MGM", "Nu_Code_NewAccountSucceed"));
            //        this.Close();	
            //    }
            }
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// �رմ���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void NewUser_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();

			//����
            lock (typeof(C_Event.CSocketEvent))
            {
                departmentMsg = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.DEPART_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, null);
            }
			//���״̬
			if (departmentMsg[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
			{
				MessageBox.Show(departmentMsg[0,0].oContent.ToString());
				return;
			}

			for(int i=0;i<departmentMsg.GetLength(0);i++)
			{
				department.Items.Add(departmentMsg[i,1].oContent.ToString().Trim());

                /*
                 * ʹ�����:Ȩ��ģ��
                 * ����:��½�ʺ�Ϊ���ż�������ʱֻ��Ϊ�䱾��������ʺ�,���Բ���Ӧ�޶���,����ѡ��
                 */
                if (int.Parse(m_ClientEvent.GetInfo("SysAdminValue").ToString()) == 2)
                {
                    if (int.Parse(m_ClientEvent.GetInfo("UserInDepart").ToString()) == int.Parse(departmentMsg[i, 0].oContent.ToString()))
                    {
                        department.SelectedIndex = i;
                    }
                    department.Enabled = false;
                }
			}

            dateTimePicker1.Value = DateTime.Now.AddMonths(3);

            if (int.Parse(m_ClientEvent.GetInfo("SysAdminValue").ToString()) == 0)
            {
                chkDeptAdmin.Visible = false;
                chkSystmeAdmin.Visible = false;
            }
            if (int.Parse(m_ClientEvent.GetInfo("SysAdminValue").ToString()) == 2)
            {
                chkSystmeAdmin.Visible = false;
                chkDeptAdmin.Visible = false;
            }
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

		#region ����
		private CSocketEvent m_ClientEvent = null;
		ArrayList moduleIDs = new ArrayList();
		private C_Global.CEnum.Message_Body[,] departmentMsg = null;
		private C_Global.CEnum.Message_Body[,] userInfos = null;
		#endregion

		#region �Զ��庯��
		/// <summary>
		/// ��ȡ����id
		/// </summary>
		/// <param name="DepartmentName"></param>
		/// <returns></returns>
		private int GetDepartmentID(string DepartmentName)
		{
			int returnValue = 0;
			for(int i=0;i<departmentMsg.GetLength(0);i++)
			{
				if(departmentMsg[i,1].oContent.ToString().Trim() == DepartmentName)
				{
					returnValue = int.Parse(departmentMsg[i,0].oContent.ToString());
				}
			}
			return returnValue;
		}

		/// <summary>
		/// ���ע���û����Ƿ����
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		private bool IsExistUserName(string userName)
		{
			bool returnValue = false;
            if (userInfos != null && userInfos[0,0].eName != CEnum.TagName.ERROR_Msg)
            {
                for (int i = 0; i < userInfos.GetLength(0); i++)
                {
                    if (userInfos[i, 1].oContent.ToString().Trim().Equals(userName))
                    {
                        returnValue = true;
                    }
                }
            }
			return returnValue;
		}
		#endregion

        private void chkSystmeAdmin_Click(object sender, EventArgs e)
        {
            chkDeptAdmin.Checked = false;
        }

        private void chkDeptAdmin_Click(object sender, EventArgs e)
        {
            chkSystmeAdmin.Checked = false;
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
            this.Text = config.ReadConfigValue("MGM", "NU_UI_Caption");

            this.label3.Text = config.ReadConfigValue("MGM", "NU_UI_Description");

            this.label8.Text = config.ReadConfigValue("MGM", "NU_UI_Account");
            this.label6.Text = config.ReadConfigValue("MGM", "NU_UI_Pwd");
            this.label1.Text = config.ReadConfigValue("MGM", "NU_UI_ConfirmPwd");
            this.label7.Text = config.ReadConfigValue("MGM", "NU_UI_RealName");
            this.label4.Text = config.ReadConfigValue("MGM", "NU_UI_Department");
            this.label2.Text = config.ReadConfigValue("MGM", "NU_UI_TimeLimit");
            this.userStatus.Text = config.ReadConfigValue("MGM", "NU_UI_StopAccount");

            this.chkSystmeAdmin.Text = config.ReadConfigValue("MGM", "NU_UI_SysAdmin");
            this.chkDeptAdmin.Text = config.ReadConfigValue("MGM", "NU_UI_DepartAdmin");
            this.btnAddUser.Text = config.ReadConfigValue("MGM", "NU_UI_BtnApply");
            this.btnClose.Text = config.ReadConfigValue("MGM", "NU_UI_BtnCancel");

        }


        #endregion

        private void backgroundWorkerBtnOK_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_CREATE, C_Global.CEnum.Msg_Category.USER_ADMIN, (CEnum.Message_Body[])e.Argument);
                try
                {
                    int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
                    for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
                    {
                        ((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex)).RequestResult(C_Global.CEnum.ServiceKey.USER_CREATE, C_Global.CEnum.Msg_Category.USER_ADMIN, (CEnum.Message_Body[])e.Argument);
                    }
                }
                catch { }
            }
        }

        private void backgroundWorkerBtnOK_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAddUser.Enabled = true;
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
                MessageBox.Show(config.ReadConfigValue("MGM", "Nu_Code_NewAccountSucceed"));
                this.Close();
            }
        }
		
	}
}
