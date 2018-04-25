using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

using C_Global;
using C_Event;

namespace FRM_MJ
{
	/// <summary>
	/// userInfoOrder ��ժҪ˵����
	/// </summary>
    [C_Global.CModuleAttribute("�ͽ�����", "userInfoOrder", "�ͽ�����", "MJ Group")]
    public class userInfoOrder : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button search;
		private System.Windows.Forms.ComboBox orderType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox userType;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listViewSortOrder;
		private System.Windows.Forms.ColumnHeader account;
		private System.Windows.Forms.ColumnHeader char_name;
		private System.Windows.Forms.ColumnHeader type_id;
		private System.Windows.Forms.ColumnHeader level;
		private System.Windows.Forms.ColumnHeader exp;
        private System.Windows.Forms.ColumnHeader money;
        private ColumnHeader id;
        private Label label3;
        private ComboBox serverIP;
        private DividerPanel.DividerPanel dividerPanel1;
        private DividerPanel.DividerPanel dividerPanel2;
        private DividerPanel.DividerPanel dividerPanel3;
        private IContainer components;

		public userInfoOrder()
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
            this.serverIP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.orderType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewSortOrder = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.account = new System.Windows.Forms.ColumnHeader();
            this.char_name = new System.Windows.Forms.ColumnHeader();
            this.type_id = new System.Windows.Forms.ColumnHeader();
            this.level = new System.Windows.Forms.ColumnHeader();
            this.exp = new System.Windows.Forms.ColumnHeader();
            this.money = new System.Windows.Forms.ColumnHeader();
            this.dividerPanel1 = new DividerPanel.DividerPanel();
            this.dividerPanel2 = new DividerPanel.DividerPanel();
            this.dividerPanel3 = new DividerPanel.DividerPanel();
            this.dividerPanel1.SuspendLayout();
            this.dividerPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverIP
            // 
            this.serverIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverIP.FormattingEnabled = true;
            this.serverIP.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.serverIP.Location = new System.Drawing.Point(81, 10);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(165, 20);
            this.serverIP.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "����";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(261, 7);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(74, 23);
            this.search.TabIndex = 4;
            this.search.Text = "�鿴";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // orderType
            // 
            this.orderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderType.Items.AddRange(new object[] {
            "��Ǯ",
            "�ȼ�"});
            this.orderType.Location = new System.Drawing.Point(81, 55);
            this.orderType.Name = "orderType";
            this.orderType.Size = new System.Drawing.Size(165, 20);
            this.orderType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "�������ͣ�";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userType
            // 
            this.userType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userType.Items.AddRange(new object[] {
            "����ְҵ",
            "սʿ",
            "��ʦ",
            "��ʿ"});
            this.userType.Location = new System.Drawing.Point(81, 33);
            this.userType.Name = "userType";
            this.userType.Size = new System.Drawing.Size(165, 20);
            this.userType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(34, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "��ɫ��";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewSortOrder
            // 
            this.listViewSortOrder.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewSortOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.account,
            this.char_name,
            this.type_id,
            this.level,
            this.exp,
            this.money});
            this.listViewSortOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSortOrder.FullRowSelect = true;
            this.listViewSortOrder.GridLines = true;
            this.listViewSortOrder.Location = new System.Drawing.Point(2, 2);
            this.listViewSortOrder.MultiSelect = false;
            this.listViewSortOrder.Name = "listViewSortOrder";
            this.listViewSortOrder.Size = new System.Drawing.Size(639, 210);
            this.listViewSortOrder.TabIndex = 7;
            this.listViewSortOrder.UseCompatibleStateImageBehavior = false;
            this.listViewSortOrder.View = System.Windows.Forms.View.Details;
            this.listViewSortOrder.SelectedIndexChanged += new System.EventHandler(this.listViewAcoount_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.Text = "���";
            this.id.Width = 49;
            // 
            // account
            // 
            this.account.Text = "�ʺ�";
            // 
            // char_name
            // 
            this.char_name.Text = "��ɫ��";
            this.char_name.Width = 105;
            // 
            // type_id
            // 
            this.type_id.Text = "��ɫ";
            // 
            // level
            // 
            this.level.Text = "�ȼ�";
            // 
            // exp
            // 
            this.exp.Text = "����ֵ";
            // 
            // money
            // 
            this.money.Text = "��Ǯ��";
            // 
            // dividerPanel1
            // 
            this.dividerPanel1.AllowDrop = true;
            this.dividerPanel1.Controls.Add(this.serverIP);
            this.dividerPanel1.Controls.Add(this.label2);
            this.dividerPanel1.Controls.Add(this.label3);
            this.dividerPanel1.Controls.Add(this.label1);
            this.dividerPanel1.Controls.Add(this.search);
            this.dividerPanel1.Controls.Add(this.userType);
            this.dividerPanel1.Controls.Add(this.orderType);
            this.dividerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel1.Location = new System.Drawing.Point(10, 10);
            this.dividerPanel1.Name = "dividerPanel1";
            this.dividerPanel1.Size = new System.Drawing.Size(643, 85);
            this.dividerPanel1.TabIndex = 6;
            // 
            // dividerPanel2
            // 
            this.dividerPanel2.AllowDrop = true;
            this.dividerPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.dividerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanel2.Location = new System.Drawing.Point(10, 95);
            this.dividerPanel2.Name = "dividerPanel2";
            this.dividerPanel2.Size = new System.Drawing.Size(643, 10);
            this.dividerPanel2.TabIndex = 7;
            // 
            // dividerPanel3
            // 
            this.dividerPanel3.AllowDrop = true;
            this.dividerPanel3.Controls.Add(this.listViewSortOrder);
            this.dividerPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dividerPanel3.Location = new System.Drawing.Point(10, 105);
            this.dividerPanel3.Name = "dividerPanel3";
            this.dividerPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.dividerPanel3.Size = new System.Drawing.Size(643, 214);
            this.dividerPanel3.TabIndex = 8;
            // 
            // userInfoOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(663, 329);
            this.Controls.Add(this.dividerPanel3);
            this.Controls.Add(this.dividerPanel2);
            this.Controls.Add(this.dividerPanel1);
            this.Name = "userInfoOrder";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "���а�";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.userInfoOrder_Load);
            this.dividerPanel1.ResumeLayout(false);
            this.dividerPanel1.PerformLayout();
            this.dividerPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        #region �Զ��庯��
        /// <summary>
        /// ��ʼ����Ϸ�������б�
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.serverIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = 2;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //���״̬
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //��ʾ���ݵ��б�
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.serverIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }
                //listViewAcoount = GMAdmin.DisplayView(m_ClientEvent, listViewAcoount, searchFrmResult,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ��ȡ���ݣ�ˢ���б�
        /// </summary>
        public void InitializeListView()
        {
            try
            {
                //��ʽ��Ϣ
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.MJ_ServerIP;
                messageBody[0].oContent = this._srhServerIP;

                searchFrmResult = m_ClientEvent.RequestResult(this._srhServiceKey, C_Global.CEnum.Msg_Category.MJ_ADMIN, messageBody);

                //���״̬
                if (searchFrmResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(searchFrmResult[0, 0].oContent.ToString());
                    this.Invoke(new EventHandler(WriteStatus));
                    return;
                }

                //ˢ���б�
                this.Invoke(new EventHandler(RefreshListContent));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ˢ���б�����
        /// </summary>
        private void RefreshListContent(object sender, System.EventArgs e)
        {
            try
            {
                //��ʾ���ݵ��б�
                string[] rowInfo = new string[7];
                for (int i = 0; i < searchFrmResult.GetLength(0); i++)
                {
                    //�б��
                    rowInfo[0] = Convert.ToString(i + 1);
                    //�ʺ�	
                    rowInfo[1] = searchFrmResult[i, 0].oContent.ToString();
                    //�ǳ�
                    rowInfo[2] = searchFrmResult[i, 1].oContent.ToString();
                    //��ɫ
                    rowInfo[3] = GetUserType(int.Parse(searchFrmResult[i, 2].oContent.ToString()));
                    //�ȼ�
                    rowInfo[4] = searchFrmResult[i, 3].oContent.ToString();
                    //����ֵ
                    rowInfo[5] = searchFrmResult[i, 4].oContent.ToString();
                    //��Ǯ��
                    rowInfo[6] = searchFrmResult[i, 5].oContent.ToString();
                    ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
                    listViewSortOrder.Items.Add(mlistViewItem);
                    listViewSortOrder.Items[i].Tag = searchFrmResult[i, 0].oContent.ToString();
                }
                this.search.Enabled = true;
                Status.WriteStatusText(_parent, "���");
            }
            catch (Exception ex)
            {
                this.search.Enabled = true;
                Status.WriteStatusText(_parent, "���");
            }
        }

        public void WriteStatus(object sender, System.EventArgs e)
        {
            this.search.Enabled = true;
            Status.WriteStatusText(_parent, "���");
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
                _parent = (Form)oParent;
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
        private C_Global.CEnum.Message_Body[,] serverIPResult = null;
        private C_Global.CEnum.Message_Body[,] searchFrmResult = null;


        private string _srhServerIP = null;
        private string _srhUserType = null;
        private string _srhOrderType = null;
        private C_Global.CEnum.ServiceKey _srhServiceKey = CEnum.ServiceKey.MJ_LEVELSORT_QUERY;

        private Form _parent = null;

        private bool threadFinish = true;
        private Thread thread1 = null;
        #endregion

        #region �Զ��庯��
        private string GetUserType(int typeID)
        {
            string returnValue = null;
            switch (typeID)
            {
                case 1:
                    returnValue = "��սʿ";
                    break;
                case 2:
                    returnValue = "Ůսʿ";
                    break;
                case 3:
                    returnValue = "�з�ʦ";
                    break;
                case 4:
                    returnValue = "Ů��ʦ";
                    break;
                case 5:
                    returnValue = "�е�ʿ";
                    break;
                case 6:
                    returnValue = "Ů��ʿ";
                    break;
            }
            return returnValue;
        }
        #endregion

        #region �¼�
        private void WJToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listViewAcoount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void userInfoOrder_Load(object sender, EventArgs e)
        {
            InitializeServerIP();
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (this.serverIP.Text == null || this.serverIP.Text == "")
            {
                MessageBox.Show("��ѡ��Ҫ�鿴������");
                return;
            }

            if (this.userType.Text == null || this.userType.Text == "")
            {
                MessageBox.Show("��ѡ���ɫ����");
                return;
            }

            if (this.orderType.Text == null || this.orderType.Text == "")
            {
                MessageBox.Show("��ѡ����������");
                return;
            }

            //���½���
            this.listViewSortOrder.Items.Clear();
            this.search.Enabled = false;
            Status.WriteStatusText(_parent, "���ڶ�ȡ\"" + this.serverIP.Text + this.userType.Text + this.orderType.Text + "\"���а�����,��ȴ�...");


            _srhUserType = this.userType.Text.Trim();
            _srhOrderType = this.orderType.Text.Trim();

            #region ��ѯ���
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.serverIP.Text.Trim()))
                {
                    this._srhServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion            

            #region ��ȡServiceKey
            switch (_srhOrderType)
            {
                case "��Ǯ":
                    switch (_srhUserType)
                    {
                        case "����ְҵ":
                            _srhServiceKey = CEnum.ServiceKey.MJ_MONEYSORT_QUERY;
                            break;
                        case "սʿ":
                            _srhServiceKey = CEnum.ServiceKey.MJ_MONEYFIGHTERSORT_QUERY;
                            break;
                        case "��ʦ":
                            _srhServiceKey = CEnum.ServiceKey.MJ_MONEYRABBISORT_QUERY;
                            break;
                        case "��ʿ":
                            _srhServiceKey = CEnum.ServiceKey.MJ_MONEYTAOISTSORT_QUERY;
                            break;
                    }
                    break;
                case "�ȼ�":
                    switch (_srhUserType)
                    {
                        case "����ְҵ":
                            _srhServiceKey = CEnum.ServiceKey.MJ_LEVELSORT_QUERY;
                            break;
                        case "սʿ":
                            _srhServiceKey = CEnum.ServiceKey.MJ_LEVELFIGHTERSORT_QUERY;
                            break;
                        case "��ʦ":
                            _srhServiceKey = CEnum.ServiceKey.MJ_LEVELRABBISORT_QUERY;
                            break;
                        case "��ʿ":
                            _srhServiceKey = CEnum.ServiceKey.MJ_LEVELTAOISTSORT_QUERY;
                            break;
                    }
                    break;
            }
            #endregion

            thread1 = new Thread(new ThreadStart(InitializeListView));
            thread1.Start();

        }
        #endregion

    }
}
