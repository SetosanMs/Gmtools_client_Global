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
	/// ModiRole ��ժҪ˵����
	/// </summary>
	[C_Global.CModuleAttribute("GM�û�Ȩ���޸�", "ModiRole", "�޸�GMȨ����Ϣ", "User Group")]
	public class ModiRole : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader ColumnHeader;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView listViewGameList;
		private DividerPanel.DividerPanel dividerPanel1;
		private DividerPanel.DividerPanel dividerPanel2;
        private BackgroundWorker backgroundWorkerFormLoad;
        private BackgroundWorker backgroundWorkerBtnOK;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ModiRole()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		public ModiRole(int userID,int gmType)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
			this.userID = userID;
            this.gmType = gmType;
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
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.ColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewGameList = new System.Windows.Forms.ListView();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerBtnOK = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "��Ϸ����";
            this.columnHeader1.Width = 300;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(317, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "ȡ��";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "ȷ��";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView2
            // 
            this.listView2.CheckBoxes = true;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader});
            this.listView2.Location = new System.Drawing.Point(8, 208);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(384, 120);
            this.listView2.TabIndex = 13;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView2_ItemCheck);
            // 
            // ColumnHeader
            // 
            this.ColumnHeader.Text = "Ȩ��";
            this.ColumnHeader.Width = 259;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(384, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "��ϷȨ��";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(384, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "ָ���û����Բ�������ϷȨ��";
            // 
            // listViewGameList
            // 
            this.listViewGameList.CheckBoxes = true;
            this.listViewGameList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewGameList.Location = new System.Drawing.Point(8, 56);
            this.listViewGameList.Name = "listViewGameList";
            this.listViewGameList.Size = new System.Drawing.Size(384, 120);
            this.listViewGameList.TabIndex = 10;
            this.listViewGameList.UseCompatibleStateImageBehavior = false;
            this.listViewGameList.View = System.Windows.Forms.View.Details;
            this.listViewGameList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewGameList_ItemCheck);
            this.listViewGameList.Click += new System.EventHandler(this.listViewGameList_Click);
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
            this.dividerPanel1.Size = new System.Drawing.Size(400, 48);
            this.dividerPanel1.TabIndex = 16;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.BorderSide = System.Windows.Forms.Border3DSide.Top;
            this.dividerPanel2.Controls.Add(this.button1);
            this.dividerPanel2.Controls.Add(this.button2);
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dividerPanel2.Location = new System.Drawing.Point(0, 335);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(400, 48);
            this.dividerPanel2.TabIndex = 17;
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerBtnOK
            // 
            this.backgroundWorkerBtnOK.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBtnOK_DoWork);
            this.backgroundWorkerBtnOK.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerBtnOK_RunWorkerCompleted);
            // 
            // ModiRole
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(400, 383);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listViewGameList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModiRole";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ȩ������";
            this.Load += new System.EventHandler(this.ModiRole_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

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
		
		private int userID = 0;	//�û�id

        private int gmType = 0; //�û�����

		private C_Global.CEnum.Message_Body[,] gameListResult = null;
		private C_Global.CEnum.Message_Body[,] moduleListResult = null;
		private C_Global.CEnum.Message_Body[,] userRoleResult = null;

		ArrayList moduleIDs = new ArrayList();


		#endregion


		#region �Զ��庯��
		/// <summary>
		/// ��Ϸ�б�
		/// </summary>
		private void InitializeGameList(C_Global.CEnum.Message_Body[,] userRoleResult)
		{
			ListViewItem listViewItem;

			try
			{
				for (int i=0;i<gameListResult.GetLength(0);i++)
				{	
					//��ǰ��Ϸid
					int currGameID = int.Parse(gameListResult[i,0].oContent.ToString());
					//��ǰ��Ϸ����
					string currGameName = gameListResult[i,1].oContent.ToString();

					listViewItem = new ListViewItem(currGameName,-1);
					this.listViewGameList.Items.Add(listViewItem);
					this.listViewGameList.Items[i].Tag = currGameID;
					
					if (userRoleResult[0,0].eName != C_Global.CEnum.TagName.ERROR_Msg)
					{
						for(int x=0;x<userRoleResult.GetLength(0);x++)
						{
							//��ǰ�û�ӵ��Ȩ�޵���Ϸid
							int currUserGameID = int.Parse(userRoleResult[x,0].oContent.ToString());
							//��ǰ�û�ӵ��Ȩ�޵�ģ��id
							int currUserModuleID = int.Parse(userRoleResult[x,1].oContent.ToString());
							//�����ѡ��ģ��
							if(currUserGameID == currGameID)
							{
								listViewItem.Checked = true;
								//��ȡ��Ȩ�޵�ģ��
								moduleIDs.Add(currUserModuleID);
							}
							

						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		
		/// <summary>
		/// Ȩ���б�
		/// </summary>
		/// <param name="gameID"></param>
		public void InitializeRoleList(int gameID)
		{
			int x = 0;
			ListViewItem listViewItem;

			try
			{
				for(int i=0;i<moduleListResult.GetLength(0);i++)
				{
					if (int.Parse(moduleListResult[i,1].oContent.ToString()) == gameID)
					{
						listViewItem = new ListViewItem(moduleListResult[i,3].oContent.ToString(),-1);
						this.listView2.Items.Add(listViewItem);
						this.listView2.Items[x++].Tag = moduleListResult[i,0].oContent.ToString();
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
		

		
		/// <summary>
		/// Ȩ���б�,�����ѡ��ģ��
		/// </summary>
		/// <param name="gameID"></param>
		/// <param name="selectedModules"></param>
		public void InitializeRoleList(int gameID,ArrayList selectedModules)
		{
			
			ListViewItem listViewItem;
			
			_ROLE[] rolelist = GetRoles(gameID,moduleListResult);

			try
			{
				for(int i=0;i<rolelist.Length;i++)
				{
					listViewItem = new ListViewItem(rolelist[i].roleName,-1);
					this.listView2.Items.Add(listViewItem);
					this.listView2.Items[i].Tag = rolelist[i].roleID;
					//�����ѡ��ģ��
					for(int x=0;x<selectedModules.Count;x++)
					{
						if(int.Parse(selectedModules[x].ToString()) == rolelist[i].roleID)
						{
							listViewItem.Checked = true;
							//moduleIDs.Remove(rolelist[i].roleID);
						}
							
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}



		/// <summary>
		/// ��ȡ��Ӧ��Ϸ��ģ��Ȩ��
		/// </summary>
		/// <param name="gameID"></param>
		/// <returns></returns>
		public _ROLE[] GetRoles(int gameID,C_Global.CEnum.Message_Body[,] moduleListResult)
		{
			
			int newLength=0;

			for(int i=0;i<moduleListResult.GetLength(0);i++)
			{
				if (int.Parse(moduleListResult[i,1].oContent.ToString()) == gameID)
				{
					newLength++;
				}
			}

			_ROLE[] newRoleList = new _ROLE[newLength];

			
			//for (int i=0;i<newLength;i++)
			//{
			int rowLen = 0;
			for (int x=0;x<moduleListResult.GetLength(0);x++)
			{
				if (int.Parse(moduleListResult[x,1].oContent.ToString()) == gameID)
				{
					newRoleList[rowLen].gameID = int.Parse(moduleListResult[x,1].oContent.ToString());
					newRoleList[rowLen].roleID = int.Parse(moduleListResult[x,0].oContent.ToString());
					newRoleList[rowLen].roleName = moduleListResult[x,3].oContent.ToString();
					newRoleList[rowLen].roleClass = moduleListResult[x,4].oContent.ToString();
					newRoleList[rowLen].roleContent = moduleListResult[x,5].oContent.ToString();
					rowLen++;
				}
			}
			//}
			return newRoleList;
		}
		#endregion

		#region �¼�����
		private void listViewGameList_Click(object sender, System.EventArgs e)
		{
			try
			{
				int selectIndex = this.listViewGameList.SelectedItems[0].Index;
				int gameID = int.Parse(this.listViewGameList.Items[selectIndex].Tag.ToString());
                this.label4.Text = config.ReadConfigValue("MGM", "MR_UI_GamePower");

				if(this.listViewGameList.Items[selectIndex].Checked)
				{
					this.listView2.Items.Clear();
					InitializeRoleList(gameID,moduleIDs);
				}
				else
				{
					this.listView2.Items.Clear();
				}
			}
			catch
			{
				//MessageBox.Show(ex.Message);
			}
		}

		private void listViewGameList_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			int gameID = int.Parse(this.listViewGameList.Items[e.Index].Tag.ToString());
			//ѡ����Ϸ��ߵĸ�ѡ��
			if (e.CurrentValue.ToString().ToLower().Equals("unchecked"))
			{
				//����ģ���б�������ʾ��������
                this.label4.Text = config.ReadConfigValue("MGM", "MR_UI_GamePower");
				//�����һ��ѡ�е���Ϸģ���б�
				this.listView2.Items.Clear();
				//���뱾��ѡ����Ϸ��ģ���б�
				InitializeRoleList(gameID);
			}
			else//����ѡ��
			{
				//�����һ��ѡ�е���Ϸģ���б�
				this.listView2.Items.Clear();
				//ɾ����Ϸ��ѡ��ģ��
				_ROLE[] rolelist = GetRoles(gameID,moduleListResult);
				for(int i=0;i<rolelist.Length;i++)
					moduleIDs.Remove(rolelist[i].roleID);				
			}
		}

		/// <summary>
		/// ��������ʱ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ModiRole_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();
			//��ȡ��Ϸ�б�
            try
            {
                this.Enabled = false;
                ArrayList paramList = new ArrayList();
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.User_ID;
                messageBody[0].oContent = userID;
                paramList.Add(messageBody);
                //gameListResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.DEPART_RELATE_GAME_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);
                ////���״̬
                //if (gameListResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(gameListResult[0, 0].oContent.ToString());
                //    //Application.Exit();
                //    return;
                //}
                //��ȡģ���б�
                //moduleListResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_MODULE_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, null);
                ////���״̬
                //if (moduleListResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(moduleListResult[0, 0].oContent.ToString());
                //    //Application.Exit();
                //    return;
                //}
                //�û�ӵ��Ȩ��
                C_Global.CEnum.Message_Body[] mModuleBody = new C_Global.CEnum.Message_Body[1];
                mModuleBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mModuleBody[0].eName = C_Global.CEnum.TagName.User_ID;
                mModuleBody[0].oContent = this.userID;
                paramList.Add(mModuleBody);

                this.backgroundWorkerFormLoad.RunWorkerAsync(paramList);
                //userRoleResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_MODULE_QUERY, C_Global.CEnum.Msg_Category.USER_MODULE_ADMIN, mModuleBody);
                //���״̬
                /*
                if (userRoleResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(userRoleResult[0,0].oContent.ToString());
                    //Application.Exit();
                    return;
                }
                */
                //��ʾ��Ϸ�б�
                //InitializeGameList(userRoleResult);
                //this.listView2.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		#endregion

		private void listView2_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			int roleID = int.Parse(this.listView2.Items[e.Index].Tag.ToString());

			//ѡ���¼�
			if (e.CurrentValue.ToString().ToLower().Equals("unchecked"))
			{
				if(moduleIDs.IndexOf(roleID) == -1)
				{
					moduleIDs.Add(roleID);
				}
			}
			else//����ѡ��
			{
				moduleIDs.Remove(roleID);				
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            button1.Enabled = false;
            Cursor = Cursors.AppStarting;
            string sModuleID = "";
			for(int i=0;i<moduleIDs.Count;i++) 
			{ 
				sModuleID += moduleIDs[i].ToString() + "," ;
			}

            DefaultRoles defaultRols = new DefaultRoles(m_ClientEvent,gmType == 0 ? false : true);
            sModuleID += defaultRols.GetRoleIDString();

			//sModuleID = sModuleID.Substring(1,sModuleID.Length-1);

			C_Global.CEnum.Message_Body[,] resultMsgBody = null;

			C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];
			messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
			messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
			messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

			messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
			messageBody[1].eName = C_Global.CEnum.TagName.User_ID;
			messageBody[1].oContent = this.userID;

			messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
			messageBody[2].eName = C_Global.CEnum.TagName.ModuleList;
			messageBody[2].oContent = sModuleID;

            this.backgroundWorkerBtnOK.RunWorkerAsync(messageBody);

            //resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_MODULE_UPDATE, C_Global.CEnum.Msg_Category.USER_MODULE_ADMIN, messageBody);

            //try
            //{
            //    int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
            //    for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
            //    {
            //        ((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex)).RequestResult(C_Global.CEnum.ServiceKey.USER_MODULE_UPDATE, C_Global.CEnum.Msg_Category.USER_MODULE_ADMIN, messageBody);
            //    }
            //}
            //catch { }

            ////���״̬
            //if (resultMsgBody[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(resultMsgBody[0,0].oContent.ToString());
            //    //Application.Exit();
            //    return;
            //}
            //if(resultMsgBody[0,0].oContent.ToString().ToUpper().Equals("SUCESS"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MGM", "MR_Code_Succeed"));
            //}
            //this.Close();
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
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
            this.Text = config.ReadConfigValue("MGM", "MR_UI_Caption");

            this.label3.Text = config.ReadConfigValue("MGM", "MR_UI_Description");
            this.label4.Text = config.ReadConfigValue("MGM", "MR_UI_GamePower");

            this.columnHeader1.Text = config.ReadConfigValue("MGM", "MR_UI_LvGameName");
            this.ColumnHeader.Text = config.ReadConfigValue("MGM", "MR_UI_LvPower");

            this.button1.Text = config.ReadConfigValue("MGM", "MR_UI_BtnApply");
            this.button2.Text = config.ReadConfigValue("MGM", "MR_UI_BtnCancel");

        }


        #endregion

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                gameListResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.DEPART_RELATE_GAME_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, (CEnum.Message_Body[])(((ArrayList)e.Argument)[0]));
                //���״̬
                if (gameListResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(gameListResult[0, 0].oContent.ToString());
                    e.Cancel = true;
                    //Application.Exit();
                    return;
                }
                moduleListResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_MODULE_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, null);
                userRoleResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_MODULE_QUERY, C_Global.CEnum.Msg_Category.USER_MODULE_ADMIN, (CEnum.Message_Body[])(((ArrayList)e.Argument)[1]));

            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            if (!e.Cancelled)
            {
                //��ʾ��Ϸ�б�
                InitializeGameList(userRoleResult);
                this.listView2.Items.Clear();
            }
        }

        private void backgroundWorkerBtnOK_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_MODULE_UPDATE, C_Global.CEnum.Msg_Category.USER_MODULE_ADMIN, (CEnum.Message_Body[])e.Argument);
                try
                {
                    int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
                    for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
                    {
                        ((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex)).RequestResult(C_Global.CEnum.ServiceKey.USER_MODULE_UPDATE, C_Global.CEnum.Msg_Category.USER_MODULE_ADMIN, (CEnum.Message_Body[])e.Argument);
                    }
                }
                catch { }
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
            if (resultMsgBody[0, 0].oContent.ToString().ToUpper().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "MR_Code_Succeed"));
            }
            this.Close();
        }
	}
}
