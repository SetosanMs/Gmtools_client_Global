using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using C_Global;
using C_Event;

using Language;

namespace M_SOCCER
{
    [C_Global.CModuleAttribute("封停帐号", "FrmBanAccounts", "劲爆足球", "soccer")]
    public partial class FrmBanAccounts : Form
    {
        public FrmBanAccounts()
        {
            InitializeComponent();
        }

        #region 语言库
        /// <summary>
        ///　文字库
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// 初始化华文字语言库
        /// </summary>
        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_FrmBanAccounts");
            this.btnUnbanAccount.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_btnUnbanAccount");
            this.btnModiCancel.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_btnModiCancel");
            this.btnbanAccount.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_btnbanAccount");
            this.label11.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_label11");
            this.label2.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_label2");
            this.label3.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_label3");
            this.groupBox1.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_groupBox1");
            //this.chkAccount.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_chkAccount");
            //this.label4.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_label4");
            this.btnCancel.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_btnCancel");
            this.btnSearch.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_btnSearch");
            this.lblIDOrNick.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_lblIDOrNick");
            this.label1.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_label1");
            this.LblPage.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_LblPage");
            this.LblReason.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_LblReason"); 
        }


        #endregion

        #region 调用函数
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
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

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        C_Global.CEnum.Message_Body[,] accountResult = null;   //帐号检索结果
        C_Global.CEnum.Message_Body[,] UnaccountResult = null;   //帐号检索结果
        private CSocketEvent tmp_ClientEvent = null;
        string currUserAccount = null;      
        int currSelectPSTID = 0; //在修改的玩家id
      
        bool blChkAccount = false;
        bool blChkNick = false;
        string _ServerIP = null;    //服务器ip
        DataTable dgTable = new DataTable();
        private bool bFirst = false;

        #endregion

        /// <summary>
        /// 帐号查询　方式失效
        /// </summary>
        private void DisableAccountSearch()
        {
            //txtAccount.Clear();
            //txtAccount.Enabled = false;
            //chkAccount.Checked = false;
        }

        /// <summary>
        /// 昵称查询　方式失效
        /// </summary>
        private void DisableNickSearch()
        {
            //txtAccount.Clear();
            //txtAccount.Enabled = false;
            //chkNick.Checked = false;
        }

        /// <summary>
        /// 启用　帐号查询方式
        /// </summary>
        private void EnableAccountSearch()
        {
            lblIDOrNick.Text = config.ReadConfigValue("MSOCCER", "FBA_UI_lblIDOrNick");
            //chkAccount.Checked = true;
            //chkNick.Checked = false;
            //chkAllPlayer.Checked = false;
            txtAccount.Enabled = true;
        }

        /// <summary>
        /// 启用　昵称查询
        /// </summary>
        private void EnableNickSearch()
        {
            lblIDOrNick.Text = config.ReadConfigValue("MSOCCER", "FBA_Code_NickName");
            //chkAccount.Checked = false;
            //chkNick.Checked = true;
            //chkAllPlayer.Checked = false;
            txtAccount.Enabled = true;
        }

        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.cbxServerIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_Soccer");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                this.backgroundWorkerFormLoad.RunWorkerAsync(messageBody);
                //    serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                

                ////检测状态


                //if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                //    //Application.Exit();
                //    return;
                //}

                ////显示内容到列表


                //for (int i = 0; i < serverIPResult.GetLength(0); i++)
                //{
                //    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                //}

                //this.cbxServerIP.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void chkNick_Click(object sender, EventArgs e)
        {
            //if (chkNick.Checked)
            //{
            //    EnableNickSearch();
            //}
            //else
            //{
            //    DisableNickSearch();
            //}
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            //if (chkAccount.Checked)
            //{
            //    EnableAccountSearch();
            //}
            //else
            //{
            //    DisableAccountSearch();
            //}
        }

        private void FrmBanCharacters_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeServerIP();
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            btnUnbanAccount.Visible = false;
            btnbanAccount.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text=="")
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_InputAccount"));
                return;
            }
            BanAccounts();


            #region IP检索


            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            //dpDGAccountInfo.Visible = false;    //隐藏datagrid容器
            //dpNoteText.Visible = false;         //隐藏信息提示
            //dgAccountInfo.DataSource = null;    //设置datagrid为空

            //blChkAccount = chkAccount.Checked;  //表示是否选中帐号
            //blChkNick = chkNick.Checked;        //表示是否选中昵称
        }

        //private void ReadFromAccount()
        //{
        //    currUserAccount = txtAccount.Text.ToString();

        //    C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];
        //    messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
        //    messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
        //    messageBody[0].oContent = _ServerIP;

        //    messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
        //    messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
        //    messageBody[1].oContent = currUserAccount;


        //    messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
        //    messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
        //    messageBody[2].oContent = GetCRAction();

        //    accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

        //    if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
        //    {
        //        MessageBox.Show(accountResult[0, 0].oContent.ToString());
        //        return;
        //    }

        //    dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源


        //    //dpDataGrid.Visible = true;                          //显示datagrid容器
        //    dpNoteText.Visible = true;                          //显示文本提示
        //}

        private void BanAccounts()
        {

            //if (txtAccount.Text == null || txtAccount.Text == "")
            //{
            //    MessageBox.Show("请输入要封停玩家帐号");
            //    return;
            //}
            #region IP检索


            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            btnSearch.Enabled = false;
            Cursor = Cursors.AppStarting;
            currUserAccount = txtAccount.Text.ToString();

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            messageBody[0].oContent = _ServerIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
            messageBody[1].oContent = currUserAccount;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
            messageBody[2].oContent = "1";

            messageBody[3].eName = CEnum.TagName.Index;
            messageBody[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            messageBody[3].oContent = 1;

            messageBody[4].eName = CEnum.TagName.PageSize;
            messageBody[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            messageBody[4].oContent = Operation_Soccer.iPageSize;

            this.backgroundWorkerSearch.RunWorkerAsync(messageBody);

            //accountResult = null;
            //accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_ACCOUNTSTATE_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

            //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
            //    return;
            //}
            //dgAccountInfo.DataSource = null;
            //dgAccountInfo.DataSource = BrowseResultInfo();
            //dpNoteText.Visible = true;                          //显示文本提示
            //CmbPage.Items.Clear();
            //int pageCount = int.Parse(accountResult[0, 4].oContent.ToString());
            //if (pageCount <= 0)
            //{
            //    DivPage.Visible = false;
            //}
            //else
            //{
            //    for (int i = 0; i < pageCount; i++)
            //    {
            //        CmbPage.Items.Add(i + 1);
            //    }

            //    CmbPage.SelectedIndex = 0;
            //    bFirst = true;
            //    DivPage.Visible = true;
            //    dpNoteText.Visible = true;
            //}
        }
        //private string GetCRAction()
        //{
        //    //string returnValue = "";
        //    //if (chkAccount.Checked)
        //    //    returnValue = "uID";
        //    //if (chkNick.Checked)
        //    //    returnValue = "cName";
        //    //return returnValue;
        //}

        private DataTable BrowseResultInfo()
        {
            
            try
            {
                dgTable = new DataTable();
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_ID"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Account"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_RegDate"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Status"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Reason"), typeof(string));
                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_ID")] = accountResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Account")] = accountResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_RegDate")] = accountResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Status")] = accountResult[i, 3].oContent.ToString() == "0" ? config.ReadConfigValue("MSOCCER", "FBA_Code_Freezed") : config.ReadConfigValue("MSOCCER", "FBA_Code_NotFreeze");
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Reason")] = accountResult[i, 4].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        private void UnBanAccounts()
        {
            #region IP检索


            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion
            //currUserAccount = this.txtAccount.Text.Trim();

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            messageBody[0].oContent = _ServerIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
            messageBody[1].oContent = this.txtAccount.Text;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
            messageBody[2].oContent = 1;

            messageBody[3].eName = CEnum.TagName.Index;
            messageBody[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            messageBody[3].oContent = 1;

            messageBody[4].eName = CEnum.TagName.PageSize;
            messageBody[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            messageBody[4].oContent = Operation_Soccer.iPageSize;

            messageBody[5].eName = CEnum.TagName.Soccer_deleted_date;
            messageBody[5].eTag = CEnum.TagFormat.TLV_STRING;
            messageBody[5].oContent = "gmtools";
            lock (typeof(C_Event.CSocketEvent))
            {
                UnaccountResult = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERSTATE_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);
            }
            if (UnaccountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(UnaccountResult[0, 0].oContent.ToString());
                return;
            }
            dgAccountInfo.DataSource = null;
            dgAccountInfo.DataSource = ResultInfo();      //设置datagrid数据源
            CmbPage.Items.Clear();
            int pageCount = int.Parse(UnaccountResult[0, 6].oContent.ToString());
            if (pageCount <= 0)
            {
                DivPage.Visible = false;
            }
            else
            {
                for (int i = 0; i < pageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }

                CmbPage.SelectedIndex = 0;
                bFirst = true;
                DivPage.Visible = true;
                dpNoteText.Visible = true;  
            }
            
        }
        private DataTable ResultInfo()
        {
            try
            {
                dgTable = new DataTable();
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_ID"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Account"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Role"), typeof(string));

                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Sex"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_CreateDate"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_FreezeDate"), typeof(string));

                for (int i = 0; i < UnaccountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_ID")] = UnaccountResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Account")] = UnaccountResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Role")] = UnaccountResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Sex")] = UnaccountResult[i, 3].oContent.ToString() == "F" ? config.ReadConfigValue("MSOCCER", "FBA_Code_Female") : config.ReadConfigValue("MSOCCER", "FBA_Code_Male");
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_CreateDate")] = UnaccountResult[i, 4].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_FreezeDate")] = UnaccountResult[i, 5].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }
        private string Returnpostion(string postion)
        {
            string StrPostion = "";
            switch (postion)
            {
                case "0":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Midfield");
                    break;
                case "1":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_GoalKeeper");
                    break;
                case "2":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Forward");
                    break;
                case "3":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Guard");
                    break;
                default:
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Other");
                    break;
            }
            return StrPostion;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //dpDataGrid.Visible = false;     //隐藏datagrid容器 
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            dgAccountInfo.DataSource = null;
            txtAccount.Clear();
        }

        private void btnModiApply_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            DivPage.Visible = false;        //隐藏分页显示
            dgAccountInfo.DataSource = null;
            txtAccount.Clear();
            btnSearch.Visible = true;
           // btnbanQuary.Visible = false;
            btnbanAccount.Visible = true;
            btnUnbanAccount.Visible = false;
            richTextBox1.Clear();
        }


        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
                messageBody[1].oContent = currUserAccount;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
                messageBody[2].oContent = "1";

                messageBody[3].eName = CEnum.TagName.Index;
                messageBody[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Soccer.iPageSize + 1;

                messageBody[4].eName = CEnum.TagName.PageSize;
                messageBody[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].oContent = Operation_Soccer.iPageSize;

                CEnum.Message_Body[,] mResult = null;
                mResult = Operation_Soccer.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SOCCER_ACCOUNTSTATE_QUERY, messageBody);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                dgAccountInfo.DataSource = null;
                dgAccountInfo.DataSource = ReturnPageResult(mResult);

            
            }
        }
        private DataTable ReturnPageResult(CEnum.Message_Body[,] PageResult)
        {
            try
            {
                dgTable = new DataTable();
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_ID"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Account"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_RegDate"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Status"), typeof(string));

                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Reason"), typeof(string));

                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_ID")] = PageResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Account")] = PageResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_RegDate")] = PageResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Status")] = PageResult[i, 3].oContent.ToString() == "0" ? config.ReadConfigValue("MSOCCER", "FBA_Code_Freezed") : config.ReadConfigValue("MSOCCER", "FBA_Code_NotFreeze");

                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Reason")] = PageResult[i, 4].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        private void chkNick_Click_1(object sender, EventArgs e)
        {
            //if (chkNick.Checked)
            //{
            //    EnableNickSearch();
            //}
            //else
            //{
            //    DisableNickSearch();
            //}
        }

        private void chkAccount_Click_1(object sender, EventArgs e)
        {
            //if (chkAccount.Checked)
            //{
            //    EnableAccountSearch();
            //}
            //else
            //{
            //    DisableAccountSearch();
            //}
        }

        private void btnbanQuary_Click(object sender, EventArgs e)
        {
            UnBanAccounts();
        }

        private void checkStauas_Click_1(object sender, EventArgs e)
        {
            //if (checkStauas.Checked)
            //{
            //    btnSearch.Visible = false;
            //    btnbanQuary.Visible = true;
            //    btnbanAccount.Visible = false;
            //    btnUnbanAccount.Visible = true;

            //    dpNoteText.Visible = false;     //隐藏信息提示
            //    dpModi.Visible = false;         //隐藏信息修改
            //    DivPage.Visible = false;        //隐藏分页显示
            //    dgAccountInfo.DataSource = null;
            //    txtAccount.Clear();


            //}
            //else
            //{
            //    btnSearch.Visible = true;
            //    btnbanQuary.Visible = false;
            //    btnbanAccount.Visible = true;
            //    btnUnbanAccount.Visible = false;

            //    dpNoteText.Visible = false;     //隐藏信息提示
            //    dpModi.Visible = false;         //隐藏信息修改
            //    DivPage.Visible = false;        //隐藏分页显示
            //    dgAccountInfo.DataSource = null;
            //    txtAccount.Clear();

            //}
        }

        private void dgAccountInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUnbanAccount_Click(object sender, EventArgs e)
        {
            btnUnbanAccount.Enabled = false;
            Cursor = Cursors.AppStarting;
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            messageBody[1].oContent = _ServerIP;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.Soccer_loginId;
            messageBody[2].oContent = txtPlayerID.Text.Trim();

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[3].eName = C_Global.CEnum.TagName.Soccer_m_id;
            messageBody[3].oContent = currSelectPSTID;

            messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[4].eName = C_Global.CEnum.TagName.Soccer_m_auth;
            messageBody[4].oContent = 1;

            messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[5].eName = C_Global.CEnum.TagName.Soccer_Ban_Reason;
            messageBody[5].oContent = richTextBox1.Text.Trim();

            this.backgroundWorkerUnban.RunWorkerAsync(messageBody);

            //C_Global.CEnum.Message_Body[,] modiResult = null;
            //modiResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_ACCOUNTSTATE_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);
            //if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FBA_Code_UnFreezeSuccess").Replace("{ID}", txtPlayerID.Text.Trim()));
            //    //MessageBox.Show("解封玩家" + txtPlayerID.Text.Trim() + "帐号成功");

            //    dpNoteText.Visible = false;     //隐藏信息提示
            //    dpModi.Visible = false;         //隐藏信息修改
            //    DivPage.Visible = false;        //隐藏分页显示
            //    dgAccountInfo.DataSource = null;
            //    txtAccount.Clear();

            //}

            //if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(modiResult[0, 0].oContent.ToString());
            //    return;
            //}
        }

        private void btnbanAccount_Click(object sender, EventArgs e)
        {
            btnbanAccount.Enabled = false;
            Cursor = Cursors.AppStarting;
            if (richTextBox1.Text == "" || richTextBox1.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FBA_Code_Msgreason"));
                btnbanAccount.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }
            else
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
                messageBody[1].oContent = _ServerIP;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.Soccer_loginId;
                messageBody[2].oContent = txtPlayerID.Text.Trim();

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.Soccer_m_id;
                messageBody[3].oContent = currSelectPSTID;

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.Soccer_m_auth;
                messageBody[4].oContent = 0;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[5].eName = C_Global.CEnum.TagName.Soccer_Ban_Reason;
                messageBody[5].oContent = richTextBox1.Text.Trim();

                this.backgroundWorkerBan.RunWorkerAsync(messageBody);
            }

            //C_Global.CEnum.Message_Body[,] modiResult = null;
            //modiResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_ACCOUNTSTATE_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

            //if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FBA_Code_FreezeSuccess").Replace("{ID}", txtPlayerID.Text.Trim()));
            //    //MessageBox.Show("封停玩家" + txtPlayerID.Text.Trim() + "帐号成功");

            //    dpNoteText.Visible = false;     //隐藏信息提示
            //    dpModi.Visible = false;         //隐藏信息修改
            //    DivPage.Visible = false;        //隐藏分页显示
            //    dgAccountInfo.DataSource = null;
            //    txtAccount.Clear();

            //}

            //if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(modiResult[0, 0].oContent.ToString());
            //    return;
            //}
        }

        private void btnModiCancel_Click_1(object sender, EventArgs e)
        {
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            txtPlayerID.Clear();
            //TxtCharname.Clear();
            btnSearch.Visible = true;
            //btnbanQuary.Visible = false;
            btnbanAccount.Visible = true;
            btnUnbanAccount.Visible = false;
            richTextBox1.Clear();
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
            //检测状态


            if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                //Application.Exit();
                return;
            }

            //显示内容到列表


            for (int i = 0; i < serverIPResult.GetLength(0); i++)
            {
                this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
            }

            this.cbxServerIP.SelectedIndex = 0;
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(serverIPResult, cbxServerIP.Text.Trim()));
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                accountResult = null;
                accountResult = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_ACCOUNTSTATE_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            Cursor = Cursors.Default;
            if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(accountResult[0, 0].oContent.ToString());
                return;
            }
            dgAccountInfo.DataSource = null;
            dgAccountInfo.DataSource = BrowseResultInfo();
            dpNoteText.Visible = true;                          //显示文本提示
            CmbPage.Items.Clear();
            int pageCount = int.Parse(accountResult[0, 5].oContent.ToString());
            if (pageCount <= 0)
            {
                DivPage.Visible = false;
            }
            else
            {
                for (int i = 0; i < pageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }

                CmbPage.SelectedIndex = 0;
                bFirst = true;
                DivPage.Visible = true;
                dpNoteText.Visible = true;
            }
        }

        private void backgroundWorkerUnban_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_ACCOUNTSTATE_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerUnban_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnUnbanAccount.Enabled = true;
            Cursor = Cursors.Default;
            C_Global.CEnum.Message_Body[,] modiResult = (C_Global.CEnum.Message_Body[,])e.Result;
            if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FBA_Code_UnFreezeSuccess").Replace("{ID}", txtPlayerID.Text.Trim()));
                //MessageBox.Show("解封玩家" + txtPlayerID.Text.Trim() + "帐号成功");

                dpNoteText.Visible = false;     //隐藏信息提示
                dpModi.Visible = false;         //隐藏信息修改
                DivPage.Visible = false;        //隐藏分页显示
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();

            }

            if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(modiResult[0, 0].oContent.ToString());
                return;
            }
        }

        private void backgroundWorkerBan_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_ACCOUNTSTATE_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerBan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnbanAccount.Enabled = true;
            Cursor = Cursors.Default;
            C_Global.CEnum.Message_Body[,] modiResult = (C_Global.CEnum.Message_Body[,])e.Result;
            if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FBA_Code_FreezeSuccess").Replace("{ID}", txtPlayerID.Text.Trim()));
                //MessageBox.Show("封停玩家" + txtPlayerID.Text.Trim() + "帐号成功");

                dpNoteText.Visible = false;     //隐藏信息提示
                dpModi.Visible = false;         //隐藏信息修改
                DivPage.Visible = false;        //隐藏分页显示
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();

            }

            if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(modiResult[0, 0].oContent.ToString());
                return;
            }
        }

        private void dgAccountInfo_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //当前用户
                currSelectPSTID = int.Parse(dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_ID")].ToString());
                txtPlayerID.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_Account")].ToString();
                string StrState = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_Status")].ToString();
                if (StrState == config.ReadConfigValue("MSOCCER", "FBA_Code_NotFreeze"))
                {
                    btnbanAccount.Visible = true;
                    btnUnbanAccount.Visible = false;
                    LblReason.Visible = true;
                    richTextBox1.Visible = true;
                    richTextBox1.Clear();
                }
                else
                {
                    btnbanAccount.Visible = false;
                    btnUnbanAccount.Visible = true;
                    LblReason.Visible = false;
                    richTextBox1.Visible = false;
                    richTextBox1.Clear();
                }
                //显示修改容器
                dpModi.Visible = true;
            }
            catch
            {
            }
        }

        private void cbxServerIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(serverIPResult, cbxServerIP.Text));
        }






    }
}
