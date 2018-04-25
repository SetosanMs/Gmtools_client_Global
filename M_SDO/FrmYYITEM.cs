using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;
using System.Text.RegularExpressions;
using Language;

namespace M_SDO
{
    [C_Global.CModuleAttribute("ҡҡ�ֵ�������", "FrmYYItem", "ҡҡ�ֵ�������", "SDO Group")]
    public partial class FrmYYItem : Form
    {
        public FrmYYItem()
        {
            InitializeComponent();
        }

        #region ����
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] serverIPResult = null; //�������ѯ���
        C_Global.CEnum.Message_Body[,] accountResult = null;
        C_Global.CEnum.Message_Body[,] itemResult = null;    //��Ʒ��ѯ���
        C_Global.CEnum.Message_Body[,] actionResult = null;  //�������
        C_Global.CEnum.Message_Body[,] delResult = null;    //�ʺŲ�ѯ���

        private string _ServerIP = null;

        private int pageIndex = 1;  //���͸��������Ŀ�ʼ����



        private int pageSize = 20;   //ÿҳ��ʾ����
        private int pageCount = 1;  //��ҳ��



        private int currPage = 0;   //��ǰҳ��

        private int selectRow = 0;  //Ĭ��ѡ�е���

        bool needReLoad = false;

        private int iType = 0;
        private int iSex = 1;//Ĭ��,����
        private int iSort = 0;

        private bool isFisrtSearch = true; //�ڵ�һ�β�ѯ�����ҳ���б�ʱ���ٴ�������ѯ,�������ô˿���




        private ActionType actionType = ActionType.New;
        private ListType listType = ListType.list;

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
            this.Text = config.ReadConfigValue("MSDO", "FYI_UI_Text");
            this.btnSearch.Text = config.ReadConfigValue("MSDO", "RE_UI_btnSearch");
            this.btnAdd.Text = config.ReadConfigValue("MSDO", "RE_UI_btnAdd");
            this.btnEdit.Text = config.ReadConfigValue("MSDO", "RE_UI_btnEdit");
            this.btnDel.Text = config.ReadConfigValue("MSDO", "RE_UI_btnDel");
            this.btnPrevPage.Text = config.ReadConfigValue("MSDO", "RE_UI_btnPrevPage");
            this.btnNextPage.Text = config.ReadConfigValue("MSDO", "RE_UI_btnNextPage");
            this.toolStripLabel1.Text = config.ReadConfigValue("MSDO", "RE_UI_toolStripLabel1");
            this.toolStripLabel2.Text = config.ReadConfigValue("MSDO", "RE_UI_toolStripLabel2");
            this.label5.Text = config.ReadConfigValue("MSDO", "RE_UI_label5");
            this.label6.Text = config.ReadConfigValue("MSDO", "RE_UI_label6");
            this.btnEditOk.Text = config.ReadConfigValue("MSDO", "RE_UI_btnEditOk");
            this.btnEditCancel.Text = config.ReadConfigValue("MSDO", "RE_UI_btnEditCancel");
            this.labelLevel.Text = config.ReadConfigValue("MSDO", "FYI_UI_labelLevel");
            this.labelLevPerc.Text = config.ReadConfigValue("MSDO", "FYI_UI_labelLevPerc");
            this.labelPerc.Text = config.ReadConfigValue("MSDO", "FYI_UI_labelPerc");
            this.label1.Text = config.ReadConfigValue("MSDO", "RE_UI_label1");
            //this.label7.Text = config.ReadConfigValue("MSDO", "RE_UI_label7");
            //this.rbtSexBoy.Text = config.ReadConfigValue("MSDO", "RE_UI_rbtSexBoy");
            //this.rbtSexGirl.Text = config.ReadConfigValue("MSDO", "RE_UI_rbtSexGirl");
            this.label2.Text = config.ReadConfigValue("MSDO", "RE_UI_label2");
            this.label3.Text = config.ReadConfigValue("MSDO", "RE_UI_label3");
            this.toolStripLabel3.Text = config.ReadConfigValue("MSDO", "RE_UI_toolStripLabel3");
        }


        #endregion

        private void FrmYYItem_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            //cbxBClass.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem"));
            cbxBClass.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem1"));
            cbxBClass.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem2"));
            btnEdit.Enabled = false;
            btnDel.Enabled = false;

            btnPrevPage.Enabled = false;
            btnNextPage.Enabled = false;

            dpEditContainer.Visible = false;

            toolStripLabel1.Enabled = false;
            toolStripLabel2.Enabled = false;
            cbxToPageIndex.Enabled = false;

            tsLblText.Text = null;

            InitializeServerIP();
        }

        /// <summary>
        /// ��ʼ����Ϸ�������б�
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                
                this.cbxServerIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_SDO");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                this.backgroundWorkerFormLoad.RunWorkerAsync(messageBody);

                //serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                ////���״̬



                //if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                //    return;
                //}

                ////��ʾ���ݵ��б�



                //for (int i = 0; i < serverIPResult.GetLength(0); i++)
                //{
                //    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                //}

                //cbxServerIP.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //���״̬


            if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                return;
            }

            //��ʾ���ݵ��б�


            for (int i = 0; i < serverIPResult.GetLength(0); i++)
            {
                this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
            }

            cbxServerIP.SelectedIndex = 0;

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(serverIPResult, cbxServerIP.Text));

        }

        private void cbxServerIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(serverIPResult, cbxServerIP.Text));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.toolStrip1.Enabled = false;
            this.Cursor = Cursors.AppStarting;

            listType = ListType.list;
            pageIndex = 1;  //���͸��������Ŀ�ʼ����



            pageSize = 20;   //ÿҳ��ʾ����
            pageCount = 1;  //��ҳ��



            currPage = 0;   //��ǰҳ��

            isFisrtSearch = true;

            btnEdit.Enabled = false;
            btnDel.Enabled = false;

            btnPrevPage.Enabled = false;
            btnNextPage.Enabled = false;

            dpEditContainer.Visible = false;

            tsLblText.Text = null;
            cbxToPageIndex.Items.Clear();

            #region ����
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO","MI_Code_MsgChooseServer"));
                return;
            }
            #endregion

            #region IP����



            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            ReadInfos();
        }

        /// <summary>
        /// ��ȡ��ҽ��׼�¼
        /// </summary>
        private void ReadInfos()
        {
            this.toolStrip1.Enabled = false;
            this.Cursor = Cursors.AppStarting;

            dgInfoList.DataSource = null;
            selectRow = 0;
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                if (_ServerIP == null)
                {
                    for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                    {
                        if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                        {
                            this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                        }
                    }
                }

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.Index;
                messageBody[1].oContent = pageIndex;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[2].oContent = pageSize;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.SDO_ItemName;
                messageBody[3].oContent = "";
                ArrayList paramList = new ArrayList();
                paramList.Add("ReadInfos");
                paramList.Add(messageBody);

                this.backgroundWorkerSearch.RunWorkerAsync(paramList);

                //accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_MEDALITEM_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);


                //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    btnEdit.Enabled = false;
                //    btnDel.Enabled = false;
                //    btnNextPage.Enabled = false;
                //    btnPrevPage.Enabled = false;

                //    toolStripLabel1.Enabled = false;
                //    toolStripLabel2.Enabled = false;
                //    cbxToPageIndex.Enabled = false;

                //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                //    return;
                //}

                //pageCount = int.Parse(accountResult[0, 5].oContent.ToString());
                //tsLblText.Text = config.ReadConfigValue("MSDO", "RE_Code_MsgPage") + Convert.ToString(currPage + 1) + "/" + pageCount.ToString();

                //if (cbxToPageIndex.Items.Count == 0)
                //{
                //    for (int i = 1; i <= pageCount; i++)
                //    {
                //        cbxToPageIndex.Items.Add(i);
                //    }
                //    cbxToPageIndex.SelectedIndex = 0;
                //}
                //btnEdit.Enabled = true;
                //btnDel.Enabled = true;
                //btnNextPage.Enabled = true;
                //btnPrevPage.Enabled = true;

                //toolStripLabel1.Enabled = true;
                //toolStripLabel2.Enabled = true;
                //cbxToPageIndex.Enabled = true;

                //if (currPage == 0)
                //{
                //    btnPrevPage.Enabled = false;
                //}
                //else
                //{
                //    btnPrevPage.Enabled = true;
                //}

                //if (currPage + 1 == pageCount)
                //{
                //    btnNextPage.Enabled = false;
                //}
                //else
                //{
                //    btnNextPage.Enabled = true;
                //}

                //dgInfoList.DataSource = BrowseResultInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            if (((ArrayList)e.Argument)[0].ToString() == "ReadInfos")
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    accountResult = tmp_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_YYHAPPYITEM_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])(((ArrayList)e.Argument)[1]));
                }
            }
            else
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    accountResult = tmp_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_YYHAPPYITEM_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])(((ArrayList)e.Argument)[1]));
                }
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.toolStrip1.Enabled = true;
                this.Cursor = Cursors.Default;
                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                    btnNextPage.Enabled = false;
                    btnPrevPage.Enabled = false;

                    toolStripLabel1.Enabled = false;
                    toolStripLabel2.Enabled = false;
                    cbxToPageIndex.Enabled = false;
                    tsLblText.Text = "";
                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }

                pageCount = int.Parse(accountResult[0, 7].oContent.ToString());
                tsLblText.Text = config.ReadConfigValue("MSDO", "RE_Code_MsgPage") + Convert.ToString(currPage + 1) + "/" + pageCount.ToString();

                if (cbxToPageIndex.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPageIndex.Items.Add(i);
                    }
                    cbxToPageIndex.SelectedIndex = 0;
                }
                this.toolStrip1.Enabled = true;
                this.Cursor = Cursors.Default;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
                btnNextPage.Enabled = true;
                btnPrevPage.Enabled = true;

                toolStripLabel1.Enabled = true;
                toolStripLabel2.Enabled = true;
                cbxToPageIndex.Enabled = true;

                if (currPage == 0)
                {
                    btnPrevPage.Enabled = false;
                }
                else
                {
                    btnPrevPage.Enabled = true;
                }

                if (currPage + 1 == pageCount)
                {
                    btnNextPage.Enabled = false;
                }
                else
                {
                    btnNextPage.Enabled = true;
                }

                dgInfoList.DataSource = BrowseResultInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// ����������תװ��DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseResultInfo()
        {
            DataTable dgTable = new DataTable();
            try
            {
                dgTable.Columns.Clear();       //���ͷ��Ϣ



                dgTable.Rows.Clear();          //����м�¼





                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FYI_UI_ItemCode"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FYI_UI_ItemName"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FYI_UI_Lev"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FYI_UI_LevPerc"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FYI_UI_Perc"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FYI_UI_Times"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSDO", "FYI_UI_Days"), typeof(string));

                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow[config.ReadConfigValue("MSDO", "FYI_UI_ItemCode")] = accountResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FYI_UI_ItemName")] = accountResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FYI_UI_Lev")] = accountResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FYI_UI_LevPerc")] = accountResult[i, 3].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FYI_UI_Perc")] = accountResult[i, 4].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FYI_UI_Times")] = accountResult[i, 5].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSDO", "FYI_UI_Days")] = (accountResult[i, 6].oContent.ToString() == "-1") ? config.ReadConfigValue("MSDO", "OP_Code_DaysLimit") : accountResult[i, 6].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("�������\n" + ex.Message);
            }
            return dgTable;
        }

        /// <summary>
        /// ��ȡ��ҽ��׼�¼
        /// </summary>
        private void ReadInfosBySearch()
        {
            this.toolStrip1.Enabled = false;
            this.Cursor = Cursors.AppStarting;

            dgInfoList.DataSource = null;
            selectRow = 0;
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                if (_ServerIP == null)
                {
                    for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                    {
                        if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                        {
                            this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                        }
                    }
                }

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[1].oContent = pageSize;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.Index;
                messageBody[2].oContent = pageIndex;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.SDO_ItemName;
                messageBody[3].oContent = this.txtItemName.Text.Trim();

                ArrayList paramList = new ArrayList();
                paramList.Add("ReadInfosBySearch");
                paramList.Add(messageBody);

                this.backgroundWorkerSearch.RunWorkerAsync(paramList);

                //accountResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_MEDALITEM_OWNER_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);


                //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    btnEdit.Enabled = false;
                //    btnDel.Enabled = false;
                //    btnNextPage.Enabled = false;
                //    btnPrevPage.Enabled = false;

                //    toolStripLabel1.Enabled = false;
                //    toolStripLabel2.Enabled = false;
                //    cbxToPageIndex.Enabled = false;


                //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                //    return;
                //}


                //pageCount = int.Parse(accountResult[0, 5].oContent.ToString());
                //tsLblText.Text = config.ReadConfigValue("MSDO", "RE_Code_MsgPage") + Convert.ToString(currPage + 1) + "/" + pageCount.ToString();

                //if (cbxToPageIndex.Items.Count == 0)
                //{
                //    for (int i = 1; i <= pageCount; i++)
                //    {
                //        cbxToPageIndex.Items.Add(i);
                //    }
                //    cbxToPageIndex.SelectedIndex = 0;
                //}
                //btnEdit.Enabled = true;
                //btnDel.Enabled = true;
                //btnNextPage.Enabled = true;
                //btnPrevPage.Enabled = true;

                //toolStripLabel1.Enabled = true;
                //toolStripLabel2.Enabled = true;
                //cbxToPageIndex.Enabled = true;

                //if (currPage == 0)
                //{
                //    btnPrevPage.Enabled = false;
                //}
                //else
                //{
                //    btnPrevPage.Enabled = true;
                //}

                //if (currPage + 1 == pageCount)
                //{
                //    btnNextPage.Enabled = false;
                //}
                //else
                //{
                //    btnNextPage.Enabled = true;
                //}

                //dgInfoList.DataSource = BrowseResultInfo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            currPage -= 1;
            pageIndex = (currPage) * pageSize + 1;

            ReadInfos();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            currPage += 1;
            pageIndex = (currPage) * pageSize + 1;

            ReadInfos();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            actionType = ActionType.New;
            dpEditContainer.Visible = true;
            this.cbxItems.Text = "";
            numericLevel.Value = 0;
            numericLevPerc.Value = 1;
            numericPerc.Value = 1;
            numericTimes.Value = 0;
            numericDays.Value = 0;
            cbxBClass.Enabled = true;
            cbxSClass.Enabled = true;
            //rbtSexBoy.Enabled = true;
            //rbtSexGirl.Enabled = true;
        }

        private void dgInfoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectRow = e.RowIndex;
            dpEditContainer.Visible = false;
        }

        private void cbxToPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {

            currPage = int.Parse(cbxToPageIndex.Text) - 1;
            pageIndex = (currPage) * pageSize + 1;

            if (!isFisrtSearch)
            {
                if (listType == ListType.list)
                {
                    ReadInfos();
                }
                else
                {
                    ReadInfosBySearch();
                }
            }
            isFisrtSearch = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.txtItemName.Text == null || this.txtItemName.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgItemname"));
                this.cbxItems.Focus();
                return;
            }

            this.toolStrip1.Enabled = false;
            this.Cursor = Cursors.AppStarting;
            listType = ListType.itemNameSearch;

            pageIndex = 1;  //���͸��������Ŀ�ʼ����



            pageSize = 20;   //ÿҳ��ʾ����
            pageCount = 1;  //��ҳ��



            currPage = 0;   //��ǰҳ��

            isFisrtSearch = true;

            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnNextPage.Enabled = false;
            btnPrevPage.Enabled = false;

            toolStripLabel1.Enabled = false;
            toolStripLabel2.Enabled = false;
            cbxToPageIndex.Enabled = false;

            cbxToPageIndex.Items.Clear();

            ReadInfosBySearch();
        }

        private void btnEditOk_Click(object sender, EventArgs e)
        {
            if (actionType == ActionType.New)
            {
                if (cbxItems.Text.Trim() == "")
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msgchitem"));
                    cbxItems.Focus();
                    return;
                }
            }

            WriteRate();
        }

        private void WriteRate()
        {
            btnEditOk.Enabled = false;
            Cursor = Cursors.AppStarting;
            

            if (_ServerIP == null)
            {
                for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                {
                    if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                    {
                        this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                    }
                }
            }
            CEnum.Message_Body[] mItemContent = null;
            if (actionType == ActionType.New)
            {
                mItemContent = new CEnum.Message_Body[9];
                mItemContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mItemContent[0].oContent = _ServerIP;

                mItemContent[1].eName = CEnum.TagName.SDO_ItemName;
                mItemContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mItemContent[1].oContent = this.cbxItems.Text.Trim();

                mItemContent[2].eName = CEnum.TagName.SDO_TimesLimit;
                mItemContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[2].oContent = Convert.ToInt32(numericTimes.Value);

                mItemContent[3].eName = CEnum.TagName.SDO_DaysLimit;
                mItemContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[3].oContent = Convert.ToInt32(numericDays.Value);

                mItemContent[4].eName = CEnum.TagName.SDO_Level;
                mItemContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[4].oContent = Convert.ToInt32(numericLevel.Value);

                mItemContent[5].eName = CEnum.TagName.SDO_LevPercent;
                mItemContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[5].oContent = Convert.ToInt32(numericLevPerc.Value);

                mItemContent[6].eName = CEnum.TagName.SDO_Precent;
                mItemContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[6].oContent = Convert.ToInt32(numericPerc.Value);

                mItemContent[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mItemContent[7].eName = C_Global.CEnum.TagName.UserByID;
                mItemContent[7].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mItemContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[8].eName = CEnum.TagName.SDO_ItemCode;
                mItemContent[8].oContent = Convert.ToInt32(((ArrayList)cbxItems.Tag)[cbxItems.SelectedIndex]);
            }
            else
            {
                mItemContent = new CEnum.Message_Body[10];
                mItemContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mItemContent[0].oContent = _ServerIP;

                mItemContent[1].eName = CEnum.TagName.SDO_ItemName;
                mItemContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mItemContent[1].oContent = (this.cbxItems.Text.Trim() == "") ? ((DataTable)dgInfoList.DataSource).Rows[selectRow][1].ToString() : this.cbxItems.Text.Trim();

                mItemContent[2].eName = CEnum.TagName.SDO_ItemCodeBy;
                mItemContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[2].oContent = Convert.ToInt32(((DataTable)dgInfoList.DataSource).Rows[selectRow][0].ToString());

                mItemContent[3].eName = CEnum.TagName.SDO_TimesLimit;
                mItemContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[3].oContent = Convert.ToInt32(numericTimes.Value);

                mItemContent[4].eName = CEnum.TagName.SDO_DaysLimit;
                mItemContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[4].oContent = Convert.ToInt32(numericDays.Value);

                mItemContent[5].eName = CEnum.TagName.SDO_Level;
                mItemContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[5].oContent = Convert.ToInt32(numericLevel.Value);

                mItemContent[6].eName = CEnum.TagName.SDO_LevPercent;
                mItemContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[6].oContent = Convert.ToInt32(numericLevPerc.Value);

                mItemContent[7].eName = CEnum.TagName.SDO_Precent;
                mItemContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[7].oContent = Convert.ToInt32(numericPerc.Value);

                mItemContent[8].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mItemContent[8].eName = C_Global.CEnum.TagName.UserByID;
                mItemContent[8].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mItemContent[9].eName = CEnum.TagName.SDO_ItemCode;
                mItemContent[9].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[9].oContent =(this.cbxItems.Text.Trim() == "")?Convert.ToInt32(((DataTable)dgInfoList.DataSource).Rows[selectRow][0].ToString()): Convert.ToInt32(((ArrayList)cbxItems.Tag)[cbxItems.SelectedIndex]);
            }
            this.backgroundWorkerAdd.RunWorkerAsync(mItemContent);

            //if (actionType == ActionType.New)
            //{
            //    actionResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_MEDALITEM_CREATE, C_Global.CEnum.Msg_Category.SDO_ADMIN, mItemContent);

            //}
            //else
            //{
            //    actionResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_MEDALITEM_UPDATE, C_Global.CEnum.Msg_Category.SDO_ADMIN, mItemContent);
            //}
            ////���״̬



            //if (actionResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(actionResult[0, 0].oContent.ToString());
            //    return;
            //}

            //if (actionResult[0, 0].oContent.ToString().Equals("FAILURE"))
            //{

            //    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgcheckF"));
            //    return;
            //}

            //if (actionResult[0, 0].oContent.ToString().Equals("SUCESS"))
            //{
            //    dpEditContainer.Visible = false;
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgcheckS"));
            //    ReadInfos();
            //}

        }

        private void backgroundWorkerAdd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                if (actionType == ActionType.New)
                {
                    actionResult = tmp_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_YYHAPPYITEM_CREATE, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])e.Argument);

                }
                else
                {
                    actionResult = tmp_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_YYHAPPYITEM_UPDATE, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])e.Argument);
                }
            }
        }

        private void backgroundWorkerAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnEditOk.Enabled = true;
            Cursor = Cursors.Default;
            cbxBClass.Enabled = true;
            cbxSClass.Enabled = true;
            //rbtSexBoy.Enabled = true;
            //rbtSexGirl.Enabled = true;

            //���״̬


            if (actionResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(actionResult[0, 0].oContent.ToString());
                return;
            }

            if (actionResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {

                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgcheckF"));
                return;
            }

            if (actionResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                dpEditContainer.Visible = false;
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgcheckS"));
                ReadInfos();
            }
        }

        private void cbxBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxSClass.Items.Clear();
            //if (cbxBClass.Text == config.ReadConfigValue("MSDO", "RE_Code_Dress"))
            //{
            //    iType = 0;
            //    cbxSClass.Enabled = true;
            //    if (rbtSexBoy.Checked)

            //        cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass") });
            //    else
            //        cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_head"), config.ReadConfigValue("MSDO", "RE_Code_hair"), config.ReadConfigValue("MSDO", "RE_Code_body"), config.ReadConfigValue("MSDO", "RE_Code_leg"), config.ReadConfigValue("MSDO", "RE_Code_hand"), config.ReadConfigValue("MSDO", "RE_Code_feet"), config.ReadConfigValue("MSDO", "RE_Code_face"), config.ReadConfigValue("MSDO", "RE_Code_glass"), config.ReadConfigValue("MSDO", "RE_Code_onedress") });
            //}
            if (cbxBClass.Text == config.ReadConfigValue("MSDO", "RE_Code_Item"))
            {
                iType = 1;
                cbxSClass.Enabled = true;
                cbxSClass.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "RE_Code_eff"), config.ReadConfigValue("MSDO", "RE_Code_fitem") });
            }
            else
            {
                iType = 3;
                iSort = 0;
                cbxSClass.Enabled = false;
                ReadItems();
            }


        }
        /// <summary>
        /// ��ȡ������Ʒ
        /// </summary>
        private void ReadItems()
        {
            ArrayList itemcodes = new ArrayList();
            cbxItems.Items.Clear();
            CEnum.Message_Body[] mItemContent = new CEnum.Message_Body[4];

            if (_ServerIP == null)
            {
                for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                {
                    if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                    {
                        this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                    }
                }
            }

            mItemContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mItemContent[0].oContent = _ServerIP;

            mItemContent[1].eName = CEnum.TagName.SDO_BigType;
            mItemContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[1].oContent = iType;

            mItemContent[2].eName = CEnum.TagName.SDO_SmallType;
            mItemContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[2].oContent = iSort;

            mItemContent[3].eName = CEnum.TagName.SDO_ItemName;
            mItemContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mItemContent[3].oContent = "";
            itemResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_ITEMSHOP_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, mItemContent);

            if (itemResult[0, 0].eName != C_Global.CEnum.TagName.ERROR_Msg)
            {
                for (int i = 0; i < itemResult.GetLength(0); i++)
                {
                    cbxItems.Items.Add(itemResult[i, 3].oContent.ToString());
                    itemcodes.Add(itemResult[i, 2].oContent.ToString());
                }
                cbxItems.SelectedIndex = 0;
                cbxItems.Tag = itemcodes;
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_errMsg"));
            }


        }

        private void cbxSClass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_head").Trim())
            {
                iSort = 0;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_hair").Trim())
            {
                iSort = 1;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_body").Trim())
            {
                iSort = 2;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_leg").Trim())
            {
                iSort = 3;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_hand").Trim())
            {
                iSort = 4;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_feet").Trim())
            {
                iSort = 5;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_face").Trim())
            {
                iSort = 6;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_glass").Trim())
            {
                iSort = 7;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_onedress").Trim())
            {
                iSort = 50;
            }

            //switch (cbxSClass.Text)
            //{
            //    case "ͷ":
            //        iSort = 0;
            //        break;
            //    case "ͷ��":
            //        iSort = 1;
            //        break;
            //    case "����":
            //        iSort = 2;
            //        break;
            //    case "��":
            //        iSort = 3;
            //        break;
            //    case "��":
            //        iSort = 4;
            //        break;
            //    case "��":
            //        iSort = 5;
            //        break;
            //    case "����":
            //        iSort = 6;
            //        break;
            //    case "�۾�":
            //        iSort = 7;
            //        break;
            //    case "����ȹ":
            //        iSort = 50;
            //        break;
            //}

            if (iSex == 0)
            {
                iSort = iSort + 100;
            }

            //switch (cbxSClass.Text)
            //{
            //    case "��Ч":
            //    case "���ܵ���":
            //        iSort = 0;
            //        break;
            //}
            if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_eff").Trim())
            {
                iSort = 0;
            }
            else if (cbxSClass.Text.Trim() == config.ReadConfigValue("MSDO", "RE_Code_fitem").Trim())
            {
                iSort = 0;
            }

            ReadItems();
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            dpEditContainer.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectRow == -1)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FYI_Code_MSG1"));
                return;
            }
            else
            {
                dpEditContainer.Visible = true;
                cbxBClass.Enabled = true;
                cbxSClass.Enabled = true;
                //rbtSexBoy.Enabled = true;
                //rbtSexGirl.Enabled = true;
                actionType = ActionType.Modi;
                cbxItems.SelectedIndex = cbxItems.Items.IndexOf(((DataTable)dgInfoList.DataSource).Rows[selectRow][1].ToString());
                numericLevel.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][2].ToString());
                numericLevPerc.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][3].ToString());
                numericPerc.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][4].ToString());
                numericTimes.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][5].ToString());
                numericDays.Value = decimal.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][6].ToString());
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectRow == -1)
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FYI_Code_MSG2"));
                    return;
                }
                
                if (MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_Msginfo"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    this.toolStrip1.Enabled = false;
                    this.Cursor = Cursors.AppStarting;
                    Del();
                }
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgResult"));
            }
        }


        private void Del()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = _ServerIP;

                int _itemCode = 0;
                _itemCode = int.Parse(((DataTable)dgInfoList.DataSource).Rows[selectRow][0].ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.SDO_ItemCode;
                messageBody[1].oContent = _itemCode;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                this.backgroundWorkerDel.RunWorkerAsync(messageBody);
                
                //delResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_MEDALITEM_DELETE, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                ////���״̬



                //if (delResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(delResult[0, 0].oContent.ToString());
                //    return;
                //}

                //if (delResult[0, 0].oContent.ToString().Equals("FAILURE"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgdelF"));
                //    return;
                //}

                //if (delResult[0, 0].oContent.ToString().Equals("SUCESS"))
                //{

                //    MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgdelS"));
                //    ReadInfos();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void backgroundWorkerDel_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                delResult = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_YYHAPPYITEM_DELETE, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStrip1.Enabled = true;
            this.Cursor = Cursors.Default;
            //���״̬


            if (delResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(delResult[0, 0].oContent.ToString());
                return;
            }

            if (delResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgdelF"));
                return;
            }

            if (delResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {

                MessageBox.Show(config.ReadConfigValue("MSDO", "RE_Code_MsgdelS"));
                ReadInfos();
            }
        }

    }
}