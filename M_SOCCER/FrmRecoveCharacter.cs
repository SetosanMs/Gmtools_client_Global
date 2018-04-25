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
    [C_Global.CModuleAttribute("玩家角色恢复", "FrmRecoveCharacter", "劲爆足球", "soccer")]
    public partial class FrmRecoveCharacter : Form
    {
        public FrmRecoveCharacter()
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
            this.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_FrmRecoveCharacter");
            this.label8.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_label8");
            this.label7.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_label7");
            this.label6.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_label6");
            this.btnbanQuary.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_btnbanQuary");
            this.chkNick.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_chkNick");
            this.chkAccount.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_chkAccount");
            this.label4.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_label4");
            this.btnCancel.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_btnCancel");
            this.lblIDOrNick.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_lblIDOrNick");
            this.label1.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_label1");
            this.label2.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_label2");
            this.label3.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_label3");
            this.LblPage.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_LblPage");
            this.btnOnlyChar.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_btnOnlyChar");
            this.btnDelCharter.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_btnDelCharter");
            this.btnSocketcheck.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_btnSocketcheck");
            this.btnRecoveCharacter.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_btnRecoveCharacter");
            this.btnNameCheck.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_btnNameCheck");
            this.label5.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_label5");
            this.btnModiCancel.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_btnModiCancel");
            this.label11.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_label11");

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
        private CSocketEvent tmp_ClientEvent = null;
        string currUserAccount = null;      //在修改的玩家id
        int currSelectPSTID = 0;
        bool blChkAccount = false;
        bool blChkNick = false;
        string _ServerIP = null;    //服务器ip
        DataTable dgTable = new DataTable();
        private bool bFirst = false;
        string sthCharMax = null;
        string sthCharCnt = null;
        string strCharName = null;
        int isAllow = -1;
        int isNameAllow = -1;
        #endregion

        /// <summary>
        /// 帐号查询　方式失效
        /// </summary>
        private void DisableAccountSearch()
        {
            txtAccount.Clear();
            txtAccount.Enabled = false;
            chkAccount.Checked = false;
        }

        /// <summary>
        /// 昵称查询　方式失效
        /// </summary>
        private void DisableNickSearch()
        {
            txtAccount.Clear();
            txtAccount.Enabled = false;
            chkNick.Checked = false;
        }

        /// <summary>
        /// 启用帐号查询方式
        /// </summary>
        private void EnableAccountSearch()
        {
            lblIDOrNick.Text = config.ReadConfigValue("MSOCCER", "FRC_UI_lblIDOrNick");
            chkAccount.Checked = true;
            chkNick.Checked = false;
            txtAccount.Enabled = true;
        }

        /// <summary>
        /// 启用玩家角色名查询
        /// </summary>
        private void EnableNickSearch()
        {
            lblIDOrNick.Text = config.ReadConfigValue("MSOCCER", "FBA_Code_NickName");
            chkAccount.Checked = false;
            chkNick.Checked = true;
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

                //serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

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
        private void FrmRecoveCharacter_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeServerIP();
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            DivPage.Visible = false;
            btnDelCharter.Visible = false;
            btnNameCheck.Visible = false;
            btnSocketcheck.Visible = false;
            btnOnlyChar.Visible = false;
            //txtAccount.Enabled = false;
        }

        private void btnbanQuary_Click(object sender, EventArgs e)
        {
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_SelectServer"));
                return;
            }
            if (chkAccount.Checked && txtAccount.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_InputAccount"));
                return;
            }
            if (chkNick.Checked && txtAccount.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_InputNickName"));
                return;
            }

            #region IP检索


            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            dpNoteText.Visible = false;         //隐藏信息提示
            dgAccountInfo.DataSource = null;    //设置datagrid为空
            ReadFromAccount();

            //blChkAccount = chkAccount.Checked;  //表示是否选中帐号
            //blChkNick = chkNick.Checked;        //表示是否选中昵称
        }

        private void ReadFromAccount()
        {
            btnbanQuary.Enabled = false;
            Cursor = Cursors.AppStarting;
            bFirst = false;
            currUserAccount = txtAccount.Text.ToString().Trim();

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            messageBody[0].oContent = _ServerIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
            messageBody[1].oContent = currUserAccount;


            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
            messageBody[2].oContent = GetCRAction();

            messageBody[3].eName = CEnum.TagName.Index;
            messageBody[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            messageBody[3].oContent = 1;

            messageBody[4].eName = CEnum.TagName.PageSize;
            messageBody[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            messageBody[4].oContent = Operation_Soccer.iPageSize;

            this.backgroundWorkerSearch.RunWorkerAsync(messageBody);

            //accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_DELETEDCHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

            //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
            //    dpNoteText.Visible = false;     //隐藏信息提示
            //    dpModi.Visible = false;         //隐藏信息修改
            //    DivPage.Visible = false;        //隐藏分页显示
            //    dgAccountInfo.DataSource = null;
            //    txtAccount.Clear();
            //    return;
            //}

            //dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源

            //CmbPage.Items.Clear();
            //int pageCount = int.Parse(accountResult[0, 15].oContent.ToString());
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
            //dpNoteText.Visible = true;                          //显示文本提示
        }

        private string GetCRAction()
        {
            string returnValue = "";
            if (chkAccount.Checked)
                returnValue = "uID";
            if (chkNick.Checked)
                returnValue = "cName";
            return returnValue;
        }

        private DataTable BrowseResultInfo()
        {
            try
            {
                dgTable = new DataTable();
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_ID"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_FreezeDate"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Status"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Account"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FRC_Code_RoleName"), typeof(string));

                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Sex"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_BodyType"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Position"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Gcoin"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Level"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Exp"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_TotalTimes"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Victory"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Lose"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Draw"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Quit"), typeof(string));

                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_ID")] = accountResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_FreezeDate")] = accountResult[i, 13].oContent.ToString();
                    if (accountResult[i, 13].oContent.ToString() == "")
                    {
                        dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Status")] = ReturnState("OnUse");
                    }
                    else
                    {
                        dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Status")] = accountResult[i, 14].oContent.ToString();
                    }
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Account")] = accountResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FRC_Code_RoleName")] = accountResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Sex")] = accountResult[i, 3].oContent.ToString() == "F" ? config.ReadConfigValue("MSOCCER", "FBA_Code_Female") : config.ReadConfigValue("MSOCCER", "FBA_Code_Male");
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_BodyType")] = Returnsex(accountResult[i, 15].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Position")] = Returnpostion(accountResult[i, 4].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Gcoin")] = accountResult[i, 5].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Level")] = accountResult[i, 6].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Exp")] = accountResult[i, 7].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_TotalTimes")] = accountResult[i, 8].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Victory")] = accountResult[i, 9].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Lose")] = accountResult[i, 10].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Draw")] = accountResult[i, 12].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Quit")] = accountResult[i, 11].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }
        private string Returnsex(string strsex)
        {
            string StrPostion = "";
            switch (strsex)
            {
                case "0":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_FatGirl");
                    break;
                case "1":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_HighGirl");
                    break;
                case "2":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_NormalGirl");
                    break;
                case "7":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_NormalBoy");
                    break;
                case "8":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_FatBoy");
                    break;
                case "9":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_HighBoy");
                    break;
                default:
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Other");
                    break;
            }
            return StrPostion;
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
        private string ReturnState(string postion)
        {
            string StrPostion = "";
            switch (postion)
            {
                case "Wait":
                    StrPostion = "Wait";
                    break;
                case "Delete":
                    StrPostion = "Delete";
                    break;
                default:
                    StrPostion = "OnUse";
                    break;
            }
            return StrPostion;
        }
        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                CmbPage.Enabled = false;
                Cursor = Cursors.AppStarting;

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
                messageBody[1].oContent = this.txtAccount.Text;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
                messageBody[2].oContent = GetCRAction();

                messageBody[3].eName = CEnum.TagName.Index;
                messageBody[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Soccer.iPageSize + 1;

                messageBody[4].eName = CEnum.TagName.PageSize;
                messageBody[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].oContent = Operation_Soccer.iPageSize;

                this.backgroundWorkerPageChanged.RunWorkerAsync(messageBody);

                //CEnum.Message_Body[,] mResult = null;
                //mResult = Operation_Soccer.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SOCCER_DELETEDCHARACTERINFO_QUERY, messageBody);

                //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                //    return;
                //}
                //dgAccountInfo.DataSource = null;
                //dgAccountInfo.DataSource = ReturnPageResult(mResult);


            }
        }

        private DataTable ReturnPageResult(CEnum.Message_Body[,] PageResult)
        {
            try
            {
                dgTable = new DataTable();
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_ID"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_FreezeDate"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Status"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Account"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FRC_Code_RoleName"), typeof(string));

                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Sex"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Position"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Gcoin"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Level"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Exp"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_TotalTimes"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Victory"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Lose"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Draw"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Quit"), typeof(string));

                for (int i = 0; i < PageResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_ID")] = PageResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_FreezeDate")] = PageResult[i, 13].oContent.ToString();
                    if (PageResult[i, 13].oContent.ToString() == "")
                    {
                        dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Status")] = ReturnState("OnUse");
                    }
                    else
                    {
                        dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Status")] = PageResult[i, 14].oContent.ToString();
                    }
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Account")] = PageResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FRC_Code_RoleName")] = PageResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Sex")] = PageResult[i, 3].oContent.ToString() == "F" ? config.ReadConfigValue("MSOCCER", "FBA_Code_Female") : config.ReadConfigValue("MSOCCER", "FBA_Code_Male");
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Position")] = Returnpostion(PageResult[i, 4].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Gcoin")] = PageResult[i, 5].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Level")] = PageResult[i, 6].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Exp")] = PageResult[i, 7].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_TotalTimes")] = PageResult[i, 8].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Victory")] = PageResult[i, 9].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Lose")] = PageResult[i, 10].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Draw")] = PageResult[i, 12].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Quit")] = PageResult[i, 11].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        private void dgAccountInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //当前用户
                if (dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_Status")].ToString() == "Wait" || dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_Status")].ToString() == "Delete")
                {
                    currSelectPSTID = int.Parse(dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_ID")].ToString());
                    txtPlayerID.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_Account")].ToString();
                    TxtCharname.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FRC_Code_RoleName")].ToString();
                    isAllow = -1;
                    isNameAllow = -1;
                    btnDelCharter.Visible = false;
                    btnRecoveCharacter.Visible = true;
                    btnNameCheck.Visible = true;
                    btnSocketcheck.Visible = true;
                    btnOnlyChar.Visible = true;
                    //显示修改容器
                    dpModi.Visible = true;

                }
                else
                {
                    currSelectPSTID = int.Parse(dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_ID")].ToString());
                    txtPlayerID.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_Account")].ToString();
                    TxtCharname.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FRC_Code_RoleName")].ToString();
                    btnDelCharter.Visible = true;
                    btnRecoveCharacter.Visible = false;
                    btnNameCheck.Visible = false;
                    btnSocketcheck.Visible = false;
                    dpModi.Visible = true;
                    btnOnlyChar.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            if (chkAccount.Checked)
            {
                EnableAccountSearch();
            }
            else
            {
                DisableAccountSearch();
            }
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            if (chkNick.Checked)
            {
                EnableNickSearch();
            }
            else
            {
                DisableNickSearch();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            DivPage.Visible = false;        //隐藏分页显示
            dgAccountInfo.DataSource = null;
            txtAccount.Clear();
            isAllow = -1;
            isNameAllow = -1;
        }

        private void btnModiCancel_Click(object sender, EventArgs e)
        {
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            txtPlayerID.Clear();
            TxtCharname.Clear();
            isAllow = -1;
            isNameAllow = -1;

        }

        private void btnSocketcheck_Click(object sender, EventArgs e)
        {
            try
            {
                btnSocketcheck.Enabled = false;
                Cursor = Cursors.AppStarting;

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.Soccer_charidx;
                messageBody[1].oContent = currSelectPSTID;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.Soccer_kind;
                messageBody[2].oContent = "socket";

                this.backgroundWorkerCheckNum.RunWorkerAsync(messageBody);

                //C_Global.CEnum.Message_Body[,] mResult = null;

                //mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARCHECK_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

                //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                //    return;
                //}

                //sthCharMax = mResult[0, 0].oContent.ToString();
                //sthCharCnt = mResult[0, 1].oContent.ToString();

                //if (int.Parse(sthCharMax) > int.Parse(sthCharCnt))
                //{
                //    isAllow = 0;
                //}
                //else
                //{
                //    isAllow = -1;
                //}

                //if (isAllow == 0)
                //{
                //    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckSuccess1"));
                //}
                //else
                //{
                //    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckFailed1"));
                //}
            }
            catch
            { }

        }

        private void btnNameCheck_Click(object sender, EventArgs e)
        {
            try
            {
                btnNameCheck.Enabled = false;
                Cursor = Cursors.AppStarting;

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.Soccer_charidx;
                messageBody[1].oContent = currSelectPSTID;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.Soccer_kind;
                messageBody[2].oContent = "name";

                this.backgroundWorkerCheckName.RunWorkerAsync(messageBody);

                //C_Global.CEnum.Message_Body[,] mResult = null;

                //mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARCHECK_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

                //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                //    return;
                //}

                //strCharName = mResult[0, 2].oContent.ToString();


                //if (int.Parse(strCharName) == 0)
                //{
                //    isNameAllow = -1;
                //}
                //else
                //{
                //    isNameAllow = 0;
                //}

                //if (isNameAllow == 0)
                //{
                //    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckSuccess2"));
                //}
                //else
                //{
                //    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckFailed2"));
                //}
            }
            catch
            { }
        }

        private void btnRecoveCharacter_Click(object sender, EventArgs e)
        {
            if (isAllow == 0 && isNameAllow == 0)
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
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
                messageBody[1].oContent = _ServerIP;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.Soccer_charidx;
                messageBody[2].oContent = currSelectPSTID;


                C_Global.CEnum.Message_Body[,] mResult = null;

                mResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARITEMS_RECOVERY_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                if (mResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckSuccess3").Replace("{Name}", TxtCharname.Text.Trim()));

                    dpNoteText.Visible = false;     //隐藏信息提示
                    dpModi.Visible = false;         //隐藏信息修改
                    DivPage.Visible = false;        //隐藏分页显示
                    dgAccountInfo.DataSource = null;
                    txtAccount.Clear();
                    isAllow = -1;
                    isNameAllow = -1;


                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_Warning"));
            }
        }

        private void btnDelCharter_Click(object sender, EventArgs e)
        {
            btnDelCharter.Enabled = false;
            Cursor = Cursors.AppStarting;
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            messageBody[1].oContent = _ServerIP;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[2].eName = C_Global.CEnum.TagName.Soccer_charidx;
            messageBody[2].oContent = currSelectPSTID;

            messageBody[3].eName = CEnum.TagName.Soccer_deleted_date;
            messageBody[3].eTag = CEnum.TagFormat.TLV_STRING;
            messageBody[3].oContent = "gmtools";

            this.backgroundWorkerDel.RunWorkerAsync(messageBody);

            //C_Global.CEnum.Message_Body[,] modiResult = null;
            //modiResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERSTATE_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);
            //if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckSuccess4").Replace("{Name}", TxtCharname.Text.Trim()));

            //    dpNoteText.Visible = false;     //隐藏信息提示
            //    dpModi.Visible = false;         //隐藏信息修改
            //    DivPage.Visible = false;        //隐藏分页显示
            //    dgAccountInfo.DataSource = null;
            //    txtAccount.Clear();

            //}

            //if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(modiResult[0, 0].oContent.ToString());
            //    dpNoteText.Visible = false;     //隐藏信息提示
            //    dpModi.Visible = false;         //隐藏信息修改
            //    DivPage.Visible = false;        //隐藏分页显示
            //    dgAccountInfo.DataSource = null;
            //    txtAccount.Clear();
            //    return;
            //}
        }

        private void btnOnlyChar_Click(object sender, EventArgs e)
        {
            if (isAllow == 0 && isNameAllow == 0)


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

                btnOnlyChar.Enabled = false;
                Cursor = Cursors.AppStarting;

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
                messageBody[1].oContent = _ServerIP;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.Soccer_charidx;
                messageBody[2].oContent = currSelectPSTID;

                messageBody[3].eName = CEnum.TagName.Soccer_deleted_date;
                messageBody[3].eTag = CEnum.TagFormat.TLV_STRING;
                messageBody[3].oContent = "";

                this.backgroundWorkerRecovery.RunWorkerAsync(messageBody);

                //C_Global.CEnum.Message_Body[,] modiResult = null;
                //modiResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERSTATE_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);
                //if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckSuccess3").Replace("{Name}", TxtCharname.Text.Trim()));

                //    dpNoteText.Visible = false;     //隐藏信息提示
                //    dpModi.Visible = false;         //隐藏信息修改
                //    DivPage.Visible = false;        //隐藏分页显示
                //    dgAccountInfo.DataSource = null;
                //    txtAccount.Clear();

                //}

                //if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(modiResult[0, 0].oContent.ToString());
                //    dpNoteText.Visible = false;     //隐藏信息提示
                //    dpModi.Visible = false;         //隐藏信息修改
                //    DivPage.Visible = false;        //隐藏分页显示
                //    dgAccountInfo.DataSource = null;
                //    txtAccount.Clear();
                //    return;
                //}
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_Warning"));
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
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(serverIPResult, cbxServerIP.Text));
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                accountResult = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_DELETEDCHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnbanQuary.Enabled = true;
            Cursor = Cursors.Default;
            if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(accountResult[0, 0].oContent.ToString());
                dpNoteText.Visible = false;     //隐藏信息提示
                dpModi.Visible = false;         //隐藏信息修改
                DivPage.Visible = false;        //隐藏分页显示
                dgAccountInfo.DataSource = null;
                //txtAccount.Clear();
                return;
            }

            dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源

            CmbPage.Items.Clear();
            int pageCount = int.Parse(accountResult[0, 16].oContent.ToString());
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
            dpNoteText.Visible = true;                          //显示文本提示

            blChkAccount = chkAccount.Checked;  //表示是否选中帐号
            blChkNick = chkNick.Checked;        //表示是否选中昵称
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_DELETEDCHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
                //Operation_Soccer.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SOCCER_DELETEDCHARACTERINFO_QUERY, (CEnum.Message_Body[])e.Argument);
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbPage.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            dgAccountInfo.DataSource = null;
            dgAccountInfo.DataSource = ReturnPageResult(mResult);
        }

        private void backgroundWorkerDel_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERSTATE_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnDelCharter.Enabled = true;
            Cursor = Cursors.Default;
            C_Global.CEnum.Message_Body[,] modiResult = (C_Global.CEnum.Message_Body[,])e.Result;
            if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckSuccess4").Replace("{Name}", TxtCharname.Text.Trim()));

                dpNoteText.Visible = false;     //隐藏信息提示
                dpModi.Visible = false;         //隐藏信息修改
                DivPage.Visible = false;        //隐藏分页显示
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();
                Cursor = Cursors.Arrow;
                btnOnlyChar.Enabled = true;

            }

            if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(modiResult[0, 0].oContent.ToString());
                dpNoteText.Visible = false;     //隐藏信息提示
                dpModi.Visible = false;         //隐藏信息修改
                DivPage.Visible = false;        //隐藏分页显示
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();
                return;
            }
        }

        private void backgroundWorkerRecovery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERSTATE_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerRecovery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            btnOnlyChar.Enabled = false;
            Cursor = Cursors.Default;
            C_Global.CEnum.Message_Body[,] modiResult = (C_Global.CEnum.Message_Body[,])e.Result;
            if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckSuccess3").Replace("{Name}", TxtCharname.Text.Trim()));

                dpNoteText.Visible = false;     //隐藏信息提示
                dpModi.Visible = false;         //隐藏信息修改
                DivPage.Visible = false;        //隐藏分页显示
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();

            }

            if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(modiResult[0, 0].oContent.ToString());
                dpNoteText.Visible = false;     //隐藏信息提示
                dpModi.Visible = false;         //隐藏信息修改
                DivPage.Visible = false;        //隐藏分页显示
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();
                return;
            }
        }

        private void backgroundWorkerCheckNum_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARCHECK_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerCheckNum_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSocketcheck.Enabled = true;
            Cursor = Cursors.Default;
            C_Global.CEnum.Message_Body[,] mResult = (C_Global.CEnum.Message_Body[,])e.Result;



            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            sthCharMax = mResult[0, 0].oContent.ToString();
            sthCharCnt = mResult[0, 1].oContent.ToString();

            if (int.Parse(sthCharMax) > int.Parse(sthCharCnt))
            {
                isAllow = 0;
            }
            else
            {
                isAllow = -1;
            }

            if (isAllow == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckSuccess1"));
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckFailed1"));
            }
        }

        private void backgroundWorkerCheckName_DoWork(object sender, DoWorkEventArgs e)
        {

            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARCHECK_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }

            
        }

        private void backgroundWorkerCheckName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnNameCheck.Enabled = true;
            Cursor = Cursors.Default;
            C_Global.CEnum.Message_Body[,] mResult = (C_Global.CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            strCharName = mResult[0, 2].oContent.ToString();


            if (int.Parse(strCharName) == 0)
            {
                isNameAllow = -1;
            }
            else
            {
                isNameAllow = 0;
            }

            if (isNameAllow == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckSuccess2"));
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FRC_Code_CheckFailed2"));
            }
        }

        private void cbxServerIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(serverIPResult, cbxServerIP.Text));
        }
    }
}