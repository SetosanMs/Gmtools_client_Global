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
	/// GameList ��ժҪ˵����
	/// </summary>
	[C_Global.CModuleAttribute("��Ϸ����", "GameList", "������Ϸ��Ϣ", "User Group")]
	public class GameList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ListView listViewGameList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
        private ImageTextControl.IMGTXTCTRL ITC_NewGame;
        private ImageTextControl.IMGTXTCTRL ITC_EditGame;
        private ImageTextControl.IMGTXTCTRL ITC_DelGame;
        private BackgroundWorker backgroundWorkerFormLoad;
        private BackgroundWorker backgroundWorkerDel;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GameList()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameList));
            this.listViewGameList = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.ITC_DelGame = new ImageTextControl.IMGTXTCTRL();
            this.ITC_EditGame = new ImageTextControl.IMGTXTCTRL();
            this.ITC_NewGame = new ImageTextControl.IMGTXTCTRL();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.backgroundWorkerFormLoad = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDel = new System.ComponentModel.BackgroundWorker();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewGameList
            // 
            this.listViewGameList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.listViewGameList.ContextMenu = this.contextMenu1;
            this.listViewGameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGameList.FullRowSelect = true;
            this.listViewGameList.GridLines = true;
            this.listViewGameList.Location = new System.Drawing.Point(2, 2);
            this.listViewGameList.MultiSelect = false;
            this.listViewGameList.Name = "listViewGameList";
            this.listViewGameList.Size = new System.Drawing.Size(544, 269);
            this.listViewGameList.TabIndex = 1;
            this.listViewGameList.UseCompatibleStateImageBehavior = false;
            this.listViewGameList.View = System.Windows.Forms.View.Details;
            this.listViewGameList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewGameList_MouseDown);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "���";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "��Ϸ����";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "����";
            this.columnHeader2.Width = 353;
            // 
            // menuItem1
            // 
            this.menuItem1.Index = -1;
            this.menuItem1.Text = "�½���Ϸ";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = -1;
            this.menuItem2.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = -1;
            this.menuItem3.Text = "ɾ��";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = -1;
            this.menuItem5.Text = "-";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = -1;
            this.menuItem6.Text = "�༭";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.ITC_DelGame);
            this.dividerPanel1.Controls.Add(this.ITC_EditGame);
            this.dividerPanel1.Controls.Add(this.ITC_NewGame);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(548, 38);
            this.dividerPanel1.TabIndex = 2;
            // 
            // ITC_DelGame
            // 
            this.ITC_DelGame.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_DelGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_DelGame.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_DelGame.IMG_SRC")));
            this.ITC_DelGame.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_DelGame.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_DelGame.ITXT_TEXT = "ɾ����Ϸ";
            this.ITC_DelGame.Location = new System.Drawing.Point(176, 10);
            this.ITC_DelGame.Name = "ITC_DelGame";
            this.ITC_DelGame.Size = new System.Drawing.Size(76, 18);
            this.ITC_DelGame.TabIndex = 2;
            this.ITC_DelGame.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_DelGame_ITC_CLICIK);
            // 
            // ITC_EditGame
            // 
            this.ITC_EditGame.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_EditGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_EditGame.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_EditGame.IMG_SRC")));
            this.ITC_EditGame.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_EditGame.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_EditGame.ITXT_TEXT = "�༭��Ϸ";
            this.ITC_EditGame.Location = new System.Drawing.Point(94, 10);
            this.ITC_EditGame.Name = "ITC_EditGame";
            this.ITC_EditGame.Size = new System.Drawing.Size(76, 18);
            this.ITC_EditGame.TabIndex = 1;
            this.ITC_EditGame.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_EditGame_ITC_CLICIK);
            // 
            // ITC_NewGame
            // 
            this.ITC_NewGame.ControlPoint = new System.Drawing.Point(0, 0);
            this.ITC_NewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ITC_NewGame.IMG_SRC = ((System.Drawing.Image)(resources.GetObject("ITC_NewGame.IMG_SRC")));
            this.ITC_NewGame.ITXT_ForeColor = System.Drawing.Color.Black;
            this.ITC_NewGame.ITXT_MouseHoverColor = System.Drawing.Color.Red;
            this.ITC_NewGame.ITXT_TEXT = "������Ϸ";
            this.ITC_NewGame.Location = new System.Drawing.Point(12, 10);
            this.ITC_NewGame.Name = "ITC_NewGame";
            this.ITC_NewGame.Size = new System.Drawing.Size(76, 18);
            this.ITC_NewGame.TabIndex = 0;
            this.ITC_NewGame.ITC_CLICIK += new ImageTextControl.ITCEventHandler(this.ITC_NewGame_ITC_CLICIK);
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 48);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(548, 10);
            this.dividerPanel2.TabIndex = 3;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.listViewGameList);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 58);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel3.Size = new System.Drawing.Size(548, 273);
            this.dividerPanel3.TabIndex = 4;
            // 
            // backgroundWorkerFormLoad
            // 
            this.backgroundWorkerFormLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFormLoad_DoWork);
            this.backgroundWorkerFormLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFormLoad_RunWorkerCompleted);
            // 
            // backgroundWorkerDel
            // 
            this.backgroundWorkerDel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDel_DoWork);
            this.backgroundWorkerDel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDel_RunWorkerCompleted);
            // 
            // GameList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(568, 341);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "GameList";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "��Ϸ�б�";
            this.Load += new System.EventHandler(this.GameList_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel3.ResumeLayout(false);
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
			GameList gameList = new GameList();
			gameList.m_ClientEvent = (CSocketEvent)oEvent;

			if (oParent != null)
			{
				gameList.MdiParent = (Form)oParent;
				gameList.Show();
			}
			else
			{
				gameList.ShowDialog();
			}

			return gameList;
			
		}
		#endregion

		#region ����
		private CSocketEvent m_ClientEvent = null;

		private C_Global.CEnum.Message_Body[,] mResult = null;
		#endregion

		#region �¼�

		/// <summary>
		/// ��ʼ������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GameList_Load(object sender, System.EventArgs e)
		{
            IntiFontLib();
			InitializeListView();
		}

		/// <summary>
		/// �½���Ϸ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
            this.NewGame();
		}

        /// <summary>
        /// ɾ����Ϸ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
            this.DelGame();
		}


		/// <summary>
		/// �޸���Ϸ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
            this.EditGame();
		}

        private void ITC_NewGame_ITC_CLICIK(object sender)
        {
            this.NewGame();
        }

        /// <summary>
        /// ����Ҽ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewGameList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //�Ҽ����
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                //����Ҽ�����
                this.contextMenu1.MenuItems.Clear();
                try
                {
                    int selectIndex = this.listViewGameList.GetItemAt(e.X, e.Y).Index;
                    this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								 this.menuItem1,
																								 this.menuItem2,
																								 this.menuItem3,
																								 this.menuItem5,
																								 this.menuItem6});
                }
                catch
                {
                    this.contextMenu1.MenuItems.Add(this.menuItem1);
                }
            }
        }
		
        #endregion

		#region �Զ��庯��
		/// <summary>
		/// ��ʼ���б�
		/// </summary>
		public void InitializeListView()
		{
			try
			{
				//listViewGameList.Columns.Clear();
				listViewGameList.Items.Clear();
			
				C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

				messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[0].eName = C_Global.CEnum.TagName.Index;
				messageBody[0].oContent = 1;

				messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
				messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
				messageBody[1].oContent = 20;

                this.backgroundWorkerFormLoad.RunWorkerAsync(messageBody);

                ////��ʽ��Ϣ
                //mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, messageBody);

                ////���״̬
                //if (mResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mResult[0,0].oContent.ToString());
                //    //Application.Exit();
                //    return;
                //}	

                ////��ʾ���ݵ��б�
                //string[] rowInfo = new string[3];
                //for (int i=0; i<mResult.GetLength(0); i++)
                //{
                //    //���
                //    rowInfo[0] = Convert.ToString(i+1);
                //    //��Ϸ����	
                //    rowInfo[1] = mResult[i,1].oContent.ToString();
                //    //����
                //    rowInfo[2] = mResult[i,2].oContent.ToString();
                //    ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                //    listViewGameList.Items.Add(mlistViewItem);
                //    listViewGameList.Items[i].Tag = mResult[i,0].oContent.ToString();				
                //}	
                ////listViewGameList = GMAdmin.DisplayView(m_ClientEvent, listViewGameList, mResult,true);
			}
			catch(Exception ex)
			{
				//MessageBox.Show(ex.Message);
			}
		}
		#endregion		

        #region �¼�����
        /// <summary>
        /// �½���Ϸ
        /// </summary>
        private void NewGame()
        {
            NewGame newGame = new NewGame();
            newGame.CreateModule(null, m_ClientEvent);
            InitializeListView();
        }

        /// <summary>
        /// �༭��Ϸ
        /// </summary>
        private void EditGame()
        {
            int selectIndex = 0;

            try
            {
                //Ҫ������Ϸ��������
                selectIndex = this.listViewGameList.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "GL_UI_ChooseGame"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                
                //Ҫ���ĵ���Ϸid
                int gameID = int.Parse(this.listViewGameList.Items[selectIndex].Tag.ToString());
                //���͵����Դ�����û���Ϣ
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    if (int.Parse(mResult[i, 0].oContent.ToString()) == gameID)
                    {
                        messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                        messageBody[0].eName = C_Global.CEnum.TagName.GameID;
                        messageBody[0].oContent = gameID;

                        messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[1].eName = C_Global.CEnum.TagName.GameName;
                        messageBody[1].oContent = mResult[i, 1].oContent.ToString().Trim();

                        messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                        messageBody[2].eName = C_Global.CEnum.TagName.GameContent;
                        messageBody[2].oContent = mResult[i, 2].oContent.ToString().Trim();

                        NewGame newGame = null;
                        try
                        {
                            newGame = new NewGame(true, messageBody);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        try
                        {
                            newGame.CreateModule(null, m_ClientEvent);
                            InitializeListView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ɾ����Ϸ
        /// </summary>
        private void DelGame()
        {
            int selectIndex = 0;

            try
            {
                //Ҫɾ������Ϸ������
                selectIndex = this.listViewGameList.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "GL_UI_ChooseGame"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                if (MessageBox.Show(config.ReadConfigValue("MGM", "GL_UI_SureToDeleteGame"), "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }

                
                //Ҫɾ������Ϸid
                int gameID = int.Parse(this.listViewGameList.Items[selectIndex].Tag.ToString());
                //ִ�в����ķ��ؽ��
                C_Global.CEnum.Message_Body[,] resultMsgBody = null;
                //���͵���Ϣ
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.GameID;
                messageBody[1].oContent = gameID;

                this.backgroundWorkerDel.RunWorkerAsync(messageBody);

                //resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_DELETE, C_Global.CEnum.Msg_Category.GAME_ADMIN, messageBody);

                //try
                //{
                //    int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
                //    for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
                //    {
                //        ((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex)).RequestResult(C_Global.CEnum.ServiceKey.GAME_DELETE, C_Global.CEnum.Msg_Category.GAME_ADMIN, messageBody);
                //    }
                //}
                //catch { }
                
                ////���״̬
                //if (resultMsgBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(resultMsgBody[0, 0].oContent.ToString());
                //    //Application.Exit();
                //    return;
                //}

                //if (resultMsgBody[0, 0].oContent.ToString().Trim().ToUpper().Equals("SUCESS"))
                //{
                //    InitializeListView();
                //    //this.listViewGameList.Items[selectIndex].Remove();
                //    MessageBox.Show(config.ReadConfigValue("MGM", "GL_UI_Succeed"));
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void ITC_EditGame_ITC_CLICIK(object sender)
        {
            this.EditGame();
        }

        private void ITC_DelGame_ITC_CLICIK(object sender)
        {
            this.DelGame();
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
            this.Text = config.ReadConfigValue("MGM", "GL_UI_Caption");

            this.ITC_NewGame.ITXT_TEXT = config.ReadConfigValue("MGM", "GL_UI_ITC_NewGame");
            this.ITC_EditGame.ITXT_TEXT = config.ReadConfigValue("MGM", "GL_UI_ITC_EditGame");

            this.ITC_DelGame.ITXT_TEXT = config.ReadConfigValue("MGM", "GL_UI_ITC_DelGame");
            this.columnHeader3.Text = config.ReadConfigValue("MGM", "GL_UI_DG_ID");

            this.columnHeader1.Text = config.ReadConfigValue("MGM", "GL_UI_DG_GameName");
            this.columnHeader2.Text = config.ReadConfigValue("MGM", "GL_UI_DG_Description");

            this.menuItem1.Text = config.ReadConfigValue("MGM", "GL_UI_ITC_NewGame");
            this.menuItem3.Text = config.ReadConfigValue("MGM", "GL_UI_ITC_DelGame");
            this.menuItem6.Text = config.ReadConfigValue("MGM", "GL_UI_ITC_EditGame");

        }


        #endregion

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //���״̬
            if (mResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                //Application.Exit();
                return;
            }

            //��ʾ���ݵ��б�
            string[] rowInfo = new string[3];
            for (int i = 0; i < mResult.GetLength(0); i++)
            {
                //���
                rowInfo[0] = Convert.ToString(i + 1);
                //��Ϸ����	
                rowInfo[1] = mResult[i, 1].oContent.ToString();
                //����
                rowInfo[2] = mResult[i, 2].oContent.ToString();
                ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                listViewGameList.Items.Add(mlistViewItem);
                listViewGameList.Items[i].Tag = mResult[i, 0].oContent.ToString();
            }
            //listViewGameList = GMAdmin.DisplayView(m_ClientEvent, listViewGameList, mResult,true);
        }

        private void backgroundWorkerDel_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {

                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_DELETE, C_Global.CEnum.Msg_Category.GAME_ADMIN, (CEnum.Message_Body[])e.Argument);

                try
                {
                    int iSrvCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());
                    for (int iSrvIndex = 1; iSrvIndex <= iSrvCount; iSrvIndex++)
                    {
                        ((CSocketEvent)m_ClientEvent.GetInfo("Server" + iSrvIndex)).RequestResult(C_Global.CEnum.ServiceKey.GAME_DELETE, C_Global.CEnum.Msg_Category.GAME_ADMIN, (CEnum.Message_Body[])e.Argument);
                    }
                }
                catch { }
            }
        }

        private void backgroundWorkerDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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
                InitializeListView();
                //this.listViewGameList.Items[selectIndex].Remove();
                MessageBox.Show(config.ReadConfigValue("MGM", "GL_UI_Succeed"));
            }
        }



    }
}
