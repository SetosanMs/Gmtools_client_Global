using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;
using System.Text.RegularExpressions;
using M_Audition;

using Language;

namespace M_AU
{
    [C_Global.CModuleAttribute("用户资料查询", "UserAbout", "劲舞团", "AU")]
    public partial class UserAbout : Form
    {
        public UserAbout()
        {
            InitializeComponent();
        }

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
        C_Global.CEnum.Message_Body[,] accountResult = null;    //帐号检索结果
        C_Global.CEnum.Message_Body[,] levelResult = null;      //等级检索结果
        C_Global.CEnum.Message_Body[,] modiInfoResult = null;   //等级检索结果
        C_Global.CEnum.Message_Body[,] equipResult = null;      //玩家装备
        C_Global.CEnum.Message_Body[,] equipItemsResult = null;      //玩家装备
        C_Global.CEnum.Message_Body[,] delEquipResult = null;   //删除玩家装备返回结果

        DataTable dgTable = new DataTable();
        DataTable dgTableEquip = new DataTable();

        string _ServerIP = null;    //服务器ip
        string userAccount = null;  //修改的玩家帐号，
        int userSN = 0;             //修改的玩家的编号
        int currDgSelectRow = 0;    //玩家信息datagrid 中当前选中的行

        int currItemSelectRow = 0;  //玩家道具 datagrid 中当前选中的行
        int currDgSelectRow1 =0;
        int toDelItemID = 0;    //要删除的道具id
        private bool itemFirst = false;

        private int pageIndex = 1;  //发送给服务器的开始条数
        private int pageSize = 20;   //每页显示条数
        private int pageCount = 1;  //总页数
        private int currPage = 0;   //当前页数
        
        #endregion

        #region 函数
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
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_AU");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                lock (typeof(C_Event.CSocketEvent))
                {
                    serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                }
                //检测状态
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    //游戏列表为空错误信息
                    //MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }
                cbxServerIP.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 初始化等级及经验
        /// </summary>
        public void InitializeLevelExp()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                this.backgroundWorkerInitializeLevelExp.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    levelResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.AU_LEVELEXP_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
                //}

                ////检测状态
                //if (levelResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    return;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 修改玩家信息
        /// </summary>
        private void ModiUserInfo()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[7];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_Exp;
                messageBody[1].oContent = int.Parse(txtExp.Text.Trim());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.AU_Level;
                messageBody[2].oContent = int.Parse(cbxLevel.Text);

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.AU_Money;
                messageBody[3].oContent = int.Parse(txtMoney.Text.Trim());

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[4].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
                messageBody[4].oContent = userAccount;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.AU_UserSN;
                messageBody[5].oContent = userSN;

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[6].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                this.backgroundWorkerModiUserInfo.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    modiInfoResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_CHARACTERINFO_UPDATE, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
                //}

                //if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                //    return;
                //}

                //if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Msgmodfail").Replace("{user}",userAccount));
                //    return;
                //}

                //if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCESS"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Msgmodsuss").Replace("{user}", userAccount));
                //    ReadPartFromDB(userAccount);
                //    DisDpEdit();
                //    return;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取玩家数据
        /// </summary>
        private void ReadPartFromDB()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];
               
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
                messageBody[1].oContent = chkAccount.Checked ? txtAccount.Text.Trim() : "";

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.AU_UserNick;
                messageBody[2].oContent = chkNick.Checked ? txtAccount.Text.Trim() : "";

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.AU_Kind;
                messageBody[3].oContent = 1;

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.Index;
                messageBody[4].oContent = 1;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[5].oContent = 1;

                this.backgroundWorkerReadPartFromDB.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
                //}

                //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                //    return;
                //}

                //if (accountResult[0, 0].oContent.ToString().Equals("0"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Msgerr"));
                //    return;
                //}

                //dgPartInfoList.DataSource = BrowsePartResultInfo();//设置datagrid信息源
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取玩家数据
        /// </summary>
        private void ReadPartFromDB(string userAccount)
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
                messageBody[1].oContent = userAccount;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.AU_UserNick;
                messageBody[2].oContent = "";

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.AU_Kind;
                messageBody[3].oContent = 1;

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.Index;
                messageBody[4].oContent = 1;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[5].oContent = 1;

                this.backgroundWorkerReadPartFromDB.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
                //}
                //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                //    return;
                //}

                //dgPartInfoList.DataSource = BrowsePartResultInfo();//设置datagrid信息源
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



                private void ReadEquipDB(int userSN)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_UserSN;
                messageBody[1].oContent = userSN;

                this.backgroundWorkerReadEquipDB.RunWorkerAsync(messageBody);


            }
            catch { }
            }
        /// <summary>
        /// 获取玩家装备
        /// </summary>
        /// <param name="userAccount"></param>
        private void ReadEquipFromDB(int _userSN)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_UserSN;
                messageBody[1].oContent = _userSN;


                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.Index;
                messageBody[2].oContent = pageIndex;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[3].oContent = pageSize;

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[4].eName = C_Global.CEnum.TagName.AU_Postion;
                messageBody[4].oContent = ReturnClass(cmbClass.Text.Trim());

                this.backgroundWorkerReadEquipFromDB.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    equipResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_BYOWNER_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
                //}

                //if (equipResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(equipResult[0, 0].oContent.ToString());
                //    return;
                //}

                ////总页数
                //pageCount = int.Parse(equipResult[0, 5].oContent.ToString());
                ////显示内容
                //dgEquipList.DataSource = BrowseEquipResultInfo();

                //lblPageCount.Text = Convert.ToString(pageCount);
                //lblCurrPage.Text = Convert.ToString(currPage + 1);

                ////cbxToPageIndex.Items.Clear();
                //if (cbxToPageIndex.Items.Count == 0)
                //{
                //    for (int i = 1; i <= pageCount; i++)
                //    {
                //        cbxToPageIndex.Items.Add(i);
                //    }
                //    cbxToPageIndex.SelectedIndex = 0;
                //    itemFirst = true;
                //}
                ////cbxToPageIndex.SelectedText = Convert.ToString(currPage + 1);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 删除玩家装备
        /// </summary>
        /// <param name="userAccount"></param>
        private void DelPlayerEquip(int _userSN)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_UserSN;
                messageBody[1].oContent = _userSN;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.AU_ItemID;
                messageBody[2].oContent = toDelItemID;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[4].eName = C_Global.CEnum.TagName.AU_Postion;
                messageBody[4].oContent = ReturnClass(cmbClass.Text.Trim());

                this.backgroundWorkerDelPlayerEquip.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    delEquipResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_DELETE, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
                //}

                //if (delEquipResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(delEquipResult[0, 0].oContent.ToString());
                //    return;
                //}

                //if (delEquipResult[0, 0].oContent.ToString().Equals("FAILURE"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Delfail"));
                //    return;
                //}

                //if (delEquipResult[0, 0].oContent.ToString().Equals("SUCESS"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Delsuc"));
                //    return;
                //}

                



                ////清空要删除的道具的id
                //toDelItemID = 0;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 显示玩家信息到datagrid中
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseEquipResultInfo()
        {
            dgTableEquip.Columns.Clear();       //清空头信息
            dgTableEquip.Rows.Clear();          //清空行记录

            dgTableEquip.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_itemname"), typeof(string));
            dgTableEquip.Columns[0].MaxLength = 100;


            for (int i = 0; i < equipResult.GetLength(0); i++)
            {
                DataRow dgRow = dgTableEquip.NewRow();
                dgRow[config.ReadConfigValue("MAU", "UA_Code_itemname")] = equipResult[i, 2].oContent.ToString();
                
                dgTableEquip.Rows.Add(dgRow);
            }
            return dgTableEquip;
        }
        


        private DataTable BrowsePartResultInfo()
        {
            dgTable.Columns.Clear();       //清空头信息
            dgTable.Rows.Clear();          //清空行记录

            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_playerid"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_password"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_playeraccont"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_playernickname"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_sex"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_lasttime"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_leavel"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_exp"), typeof(string));
            //dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_location"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_Pcash"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_gold"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_coin"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "AU_RegistedTime"), typeof(string));
            
            //dgTable.Columns.Add(config.ReadConfigValue("MAU", "UA_Code_bank"), typeof(string));
            
            



            for (int i = 0; i < accountResult.GetLength(0); i++)
            {
                DataRow dgRow = dgTable.NewRow();
                dgRow[config.ReadConfigValue("MAU", "UA_Code_playerid")] = accountResult[i, 0].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "UA_Code_password")] = accountResult[i, 10].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "UA_Code_playeraccont")] = accountResult[i, 1].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "UA_Code_playernickname")] = accountResult[i, 2].oContent.ToString();

                dgRow[config.ReadConfigValue("MAU", "UA_Code_sex")] = accountResult[i, 7].oContent.ToString() == "F" ? config.ReadConfigValue("MAU", "OP_Code_Fsex") : config.ReadConfigValue("MAU", "OP_Code_Msex");
                dgRow[config.ReadConfigValue("MAU", "UA_Code_lasttime")] = accountResult[i, 8].oContent.ToString();

                dgRow[config.ReadConfigValue("MAU", "UA_Code_leavel")] = accountResult[i, 3].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "UA_Code_exp")] = accountResult[i, 4].oContent.ToString();
                //dgRow[config.ReadConfigValue("MAU", "UA_Code_location")] = accountResult[i, 5].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "UA_Code_Pcash")] = accountResult[i, 9].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "UA_Code_gold")] = accountResult[i, 6].oContent.ToString();

                dgRow[config.ReadConfigValue("MAU", "UA_Code_coin")] = accountResult[i, 5].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "AU_RegistedTime")] = accountResult[i, 11].oContent.ToString();
                //dgRow[config.ReadConfigValue("MAU", "UA_Code_bank")] = accountResult[i, 8].oContent.ToString();
               
                dgTable.Rows.Add(dgRow);
            }
            return dgTable;
        }

        /// <summary>
        /// 定位玩家等级在MessagBody中的位置
        /// </summary>
        /// <param name="Exp"></param>
        /// <returns></returns>
        private int ChkUserLevel(int pLevel)
        {
            int levelPos = 0;
            for (int i = 0; i < levelResult.GetLength(0); i++)
            {
                if (int.Parse(levelResult[i, 0].oContent.ToString()) == pLevel)
                {
                    levelPos = i;
                    break;
                }
            }
            return levelPos;
        }

        /// <summary>
        /// 获得等级对应的经验值
        /// </summary>
        /// <param name="pLevel"></param>
        /// <returns></returns>
        private int GetExpFromLevel(int pLevel)
        {
            int expValue = 0;
            for (int i = 0; i < levelResult.GetLength(0); i++)
            {
                if (int.Parse(levelResult[i, 0].oContent.ToString()) == pLevel)
                {
                    expValue = int.Parse(levelResult[i, 1].oContent.ToString());
                    break;
                }
            }
            return expValue;
        }

        /// <summary>
        /// 根据经验值获取等级
        /// </summary>
        /// <param name="pExp"></param>
        /// <returns></returns>
        private int GetLevelFromExp(int pExp)
        {
            int levelValue = 0;       //返回结果
            int currLevelExp = 0;    //当前等级经验
            int currLevel = 0;       //当前等级
            int nextLevelExp = 0;    //下一级经验值

            for (int i = 0; i < levelResult.GetLength(0); i++)
            {
                //获取下一级经验值
                if (i == levelResult.GetLength(0)-1)
                {
                    nextLevelExp = int.Parse(levelResult[i, 1].oContent.ToString());
                }
                else
                {
                    nextLevelExp = int.Parse(levelResult[i + 1, 1].oContent.ToString());
                }
                //获取当前级别经验值
                currLevelExp = int.Parse(levelResult[i, 1].oContent.ToString());
                currLevel = int.Parse(levelResult[i, 0].oContent.ToString());

                if (pExp >= currLevelExp && pExp < nextLevelExp)
                {
                    levelValue = currLevel;
                    break;
                }
            }
            return levelValue;
        }

        /// <summary>
        /// 清楚dpEdit中元素的内容及隐藏dpEdit
        /// </summary>
        private void DisDpEdit()
        {
            dpEdit.Visible = false;
            txtUserNick.Text = "";
            cbxLevel.SelectedIndex = 0;
            txtExp.Text = "";
            txtMoney.Text = "";
        }

        #endregion

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
            this.Text = config.ReadConfigValue("MAU", "UA_UI_Frmname");
            this.lblAccountOrNick.Text = config.ReadConfigValue("MAU", "UA_UI_lblAccountOrNick");
            this.btnSearch.Text = config.ReadConfigValue("MAU", "UA_UI_btnSearch");
            this.btnCancel.Text = config.ReadConfigValue("MAU", "UA_UI_btnCancel");
            this.groupBox1.Text = config.ReadConfigValue("MAU", "UA_UI_groupBox1");
            this.chkAccount.Text = config.ReadConfigValue("MAU", "UA_UI_chkAccount");
            this.chkNick.Text = config.ReadConfigValue("MAU", "UA_UI_chkNick");
            this.label6.Text = config.ReadConfigValue("MAU", "UA_UI_label6");

            //this.userInfo.Text = config.ReadConfigValue("MAU", "UA_UI_userInfo");
            this.btnModiCancel.Text = config.ReadConfigValue("MAU", "UA_UI_btnModiCancel");
            this.btnModiOk.Text = config.ReadConfigValue("MAU", "UA_UI_btnModiOk");
            this.label8.Text = config.ReadConfigValue("MAU", "UA_UI_label8");
            this.label5.Text = config.ReadConfigValue("MAU", "UA_UI_label5");
            this.label1.Text = config.ReadConfigValue("MAU", "UA_UI_label1");
            this.label4.Text = config.ReadConfigValue("MAU", "UA_UI_label4");
            this.linkEdit.Text = config.ReadConfigValue("MAU", "UA_UI_linkEdit");
            this.linkEquipment.Text = config.ReadConfigValue("MAU", "UA_UI_linkEquipment");
            this.label3.Text = config.ReadConfigValue("MAU", "UA_UI_label3");
            this.label10.Text = config.ReadConfigValue("MAU", "UA_UI_label10");
            this.label2.Text = config.ReadConfigValue("MAU", "UA_UI_label2");
            //this.equipList.Text = config.ReadConfigValue("MAU", "UA_UI_equipList");
            this.label11.Text = config.ReadConfigValue("MAU", "UA_UI_label11");
            //this.imgtxtctrl1.Text = config.ReadConfigValue("MAU", "UA_UI_imgtxtctrl1");
            this.label9.Text = config.ReadConfigValue("MAU", "UA_UI_label9");
            this.label7.Text = config.ReadConfigValue("MAU", "UA_UI_label7");
            this.label12.Text = config.ReadConfigValue("MAU", "UA_UI_label12");
            this.label13.Text = config.ReadConfigValue("MAU", "UA_UI_label13");
            this.lblTextDes.Text = config.ReadConfigValue("MAU", "UA_UI_lblTextDes");

        }


        #endregion

        private void UserAbout_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeServerIP();
            

            dpEdit.Visible = false;  //隐藏信息编辑容器
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            chkAccount.Checked = false;
            lblAccountOrNick.Text = config.ReadConfigValue("MAU", "UA_Code_txtnickname");
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            chkNick.Checked = false;
            lblAccountOrNick.Text = config.ReadConfigValue("MAU", "UA_Code_txtusername");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region 检测
            if (cbxServerIP.Text == "" || cbxServerIP.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "AI_Code_Msgserver"));
                return;
            }
            if (!chkAccount.Checked && !chkNick.Checked)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "AI_Code_Msgnickname"));
            }
            if (txtAccount.Text == "" || txtAccount.Text == null)
            {
                txtAccount.Focus();
                if (chkAccount.Checked)
                    MessageBox.Show(config.ReadConfigValue("MAU", "AI_Code_Msginputaccont"));
                if (chkNick.Checked)
                    MessageBox.Show(config.ReadConfigValue("MAU", "AI_Code_Msginputnickname"));
                return;
            }
            #endregion

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
            Cursor = Cursors.WaitCursor;
            ReadPartFromDB();
            InitializeLevelExp();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgPartInfoList.DataSource = null;   //清空显示内容
            DtItems.DataSource = null;
            dgTable.Columns.Clear();            //清空头信息
            dgTable.Rows.Clear();               //清空行记录

            /*
             * 清空上一次查询后保存在本地的数据
             * 并同显示一起清除
             * */
            equipResult = null;
            dgEquipList.DataSource = null;
            lblCurrPage.Text = "1";
            lblPageCount.Text = "1";
            cbxToPageIndex.Items.Clear();
        }

        private void dgPartInfoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cbxToPageIndex.Items.Clear();
            currDgSelectRow = int.Parse(e.RowIndex.ToString());
        }

        private void cbxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExp.Text = GetExpFromLevel(int.Parse(cbxLevel.Text)).ToString();
        }

        private void txtExp_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtExp.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtExp.Text = rx.Replace(txt, "");

            int txtExpValue = int.Parse(txtExp.Text == "" ? "0" : txtExp.Text.Trim());
            cbxLevel.SelectedIndex = ChkUserLevel(GetLevelFromExp(txtExpValue));
            txtExp.Text = txtExpValue.ToString();
        }

        private void btnModiOk_Click(object sender, EventArgs e)
        {
            btnModiOk.Enabled = false;
            Cursor = Cursors.WaitCursor;
            ModiUserInfo();
        }

        private void txtMoney_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtMoney.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtMoney.Text = rx.Replace(txt, "");
        }

        private void btnModiCancel_Click(object sender, EventArgs e)
        {
            DisDpEdit();
        }

        private void linkEquipment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dgPartInfoList.DataSource == null)
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "AI_Code_Msginfo1"));
                    return;
                }

                /*
                 * 清空上一次查询后保存在本地的数据
                 * 并同显示一起清除
                 * */
                itemFirst = false;
                equipResult = null;
                dgEquipList.DataSource = null;
                lblCurrPage.Text = "1";
                lblPageCount.Text = "1";
                cbxToPageIndex.Items.Clear();

                /*
                 * 有可能在默认情况（即显示出来的结果默认选中第一行）下，点击事件
                 * 故应在此处放置
                 * */
                userAccount = dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_playeraccont")].ToString();
                userSN = int.Parse(dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_playerid")].ToString());

                ReadEquipDB(userSN);

                //转到＂玩家身上装备＂页
                tcInfoCard.SelectedTab = tabPage1;
            }
            catch
            {
                /*
                 * 当未作查询而点击取消按钮时会出错，此处将该错误过滤
                 * */
            }
        }

        private void linkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dgPartInfoList.DataSource == null)
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Msginfo2"));
                    return;
                }

                dpEdit.Visible = true;  //显示信息编辑容器

                userAccount = dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_playeraccont")].ToString();
                userSN = int.Parse(dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_playerid")].ToString());

                #region 写信息到等级列表
                cbxLevel.Items.Clear();
                for (int i = 0; i < levelResult.GetLength(0); i++)
                {
                    cbxLevel.Items.Add(levelResult[i, 0].oContent.ToString().Trim());
                }
                #endregion

                txtUserNick.Text = dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_playernickname")].ToString();
                cbxLevel.SelectedIndex = ChkUserLevel(int.Parse(dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_leavel")].ToString()));
                txtExp.Text = dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_exp")].ToString();
                txtMoney.Text = dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_gold")].ToString();
            }
            catch
            {
            }
        }

        private void cbxToPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemFirst)
            {
                currPage = int.Parse(cbxToPageIndex.Text) - 1;
                pageIndex = (currPage) * pageSize + 1;
                ReadEquipFromDB(userSN);
            }
        }

        private void tcInfoCard_Click(object sender, EventArgs e)
        {
            try
            {
                cbxToPageIndex.Items.Clear();

                if (tcInfoCard.SelectedTab.Text.Equals("身上物品"))
                {
                    /*
                     * 清空上一次查询后保存在本地的数据
                     * 并同显示一起清除
                     * */
                    itemFirst = false;
                    equipResult = null;
                    dgEquipList.DataSource = null;
                    DtItems.DataSource = null;
                    lblCurrPage.Text = "1";
                    lblPageCount.Text = "1";
                    cbxToPageIndex.Items.Clear();

                    /*
                     * 有可能在默认情况（即显示出来的结果默认选中第一行）下，点击事件
                     * 故应在此处放置
                     * */
                    userAccount = dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_playeraccont")].ToString();
                    userSN = int.Parse(dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_playerid")].ToString());

                    //ReadEquipDB(userSN);
                }
                else if (tcInfoCard.SelectedTab.Text.Equals("物品栏"))
                {
                    itemFirst = false;
                    equipResult = null;
                    dgEquipList.DataSource = null;
                    DtItems.DataSource = null;
                    lblCurrPage.Text = "1";
                    lblPageCount.Text = "1";
                    cbxToPageIndex.Items.Clear();

                    /*
                     * 有可能在默认情况（即显示出来的结果默认选中第一行）下，点击事件
                     * 故应在此处放置
                     * */
                    userAccount = dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_playeraccont")].ToString();
                    userSN = int.Parse(dgTable.Rows[currDgSelectRow][config.ReadConfigValue("MAU", "UA_Code_playerid")].ToString());
                }
            }
            catch
            {
                /*
                 * 当未作查询而点击取消按钮时会出错，此处将该错误过滤
                 * */
            }
        }

        private void dgEquipList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currItemSelectRow = e.RowIndex;
        }

        private void imgtxtctrl1_ITC_CLICIK(object sender)
        {

        }

        private void backgroundWorkerReadPartFromDB_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReadPartFromDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                btnSearch.Enabled = true;
                Cursor = Cursors.Default;
                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }

                if (accountResult[0, 0].oContent.ToString().Equals("0"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Msgerr"));
                    return;
                }

                dgPartInfoList.DataSource = BrowsePartResultInfo();//设置datagrid信息源
            }
            catch
            { }
        }

        private void backgroundWorkerInitializeLevelExp_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                levelResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.AU_LEVELEXP_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerInitializeLevelExp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //检测状态

            if (levelResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                return;
            }
        }

        private void backgroundWorkerModiUserInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                modiInfoResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_CHARACTERINFO_UPDATE, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerModiUserInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnModiOk.Enabled = true;
            Cursor = Cursors.Default;
            if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                return;
            }

            if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Msgmodfail").Replace("{user}", userAccount));
                return;
            }

            if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Msgmodsuss").Replace("{user}", userAccount));
                ReadPartFromDB(userAccount);
                DisDpEdit();
                return;
            }
        }

        private void backgroundWorkerReadEquipFromDB_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                equipResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_GOODS_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReadEquipFromDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Default;
                if (equipResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(equipResult[0, 0].oContent.ToString());
                    return;
                }

                //总页数


                pageCount = 0;
                //显示内容
                Operation_Audition.BuildDataTable(m_ClientEvent, equipResult, dgEquipList, out pageCount);

                lblPageCount.Text = Convert.ToString(pageCount);
                lblCurrPage.Text = Convert.ToString(currPage + 1);

                //cbxToPageIndex.Items.Clear();
                if (cbxToPageIndex.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPageIndex.Items.Add(i);
                    }
                    cbxToPageIndex.SelectedIndex = 0;
                    itemFirst = true;
                }
                //cbxToPageIndex.SelectedText = Convert.ToString(currPage + 1);
            }
            catch
            { }
        }

        private void backgroundWorkerDelPlayerEquip_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                delEquipResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_DELETE, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerDelPlayerEquip_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            if (delEquipResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(delEquipResult[0, 0].oContent.ToString());
                return;
            }

            if (delEquipResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Delfail"));
                return;
            }

            if (delEquipResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Delsuc"));
                ReadEquipFromDB(userSN);
                toDelItemID = 0;
                return;
            }





            //清空要删除的道具的id
            

            
        }

        private void cbxToPageIndex_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (itemFirst)
            {
                currPage = int.Parse(cbxToPageIndex.Text) - 1;
                pageIndex = (currPage) * pageSize + 1;
                ReadEquipFromDB(userSN);
            }
        }

        private void btnSerchItems_Click(object sender, EventArgs e)
        {
            ReadEquipFromDB(userSN);
        }

        private string ReturnClass(string _strClass)
        {  
           string  myclass="";
           if(_strClass=="头发")
           {
               myclass ="hair";
           }
           else if (_strClass == "表情")
           {
               myclass = "face";
           }
           else if (_strClass == "套装")
           {
               myclass = "sets";
           }
           else if (_strClass == "裤子")
           {
               myclass = "pants";
           }
           else if (_strClass == "衣服")
           {
               myclass = "jacket";
           }
           else if (_strClass == "鞋子")
           {
               myclass = "shoes";
           }
           else if (_strClass == "宠物")
           {
               myclass = "pets";
           }
           else if (_strClass == "功能道具")
           {
               myclass = "items";
           }

           return myclass;
        }

        private void imgtxtctrl1_Load(object sender, EventArgs e)
        {

        }

        private void cbxServerIP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorkerReadEquipDB_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                equipItemsResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_BYOWNER_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReadEquipDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            if (equipItemsResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(equipItemsResult[0, 0].oContent.ToString());
                return;
            }

            //总页数


            pageCount = 0;
            //显示内容
            Operation_Audition.BuildDataTable(m_ClientEvent, equipItemsResult, DtItems, out pageCount);
        }

        private void tcInfoCard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgEquipList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow1 = int.Parse(e.RowIndex.ToString());
        }

        private void imgtxtctrl1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
* 如果在玩家身上没有道具的情况下
* 则点击删除按钮失效
* */
            if (dgEquipList.DataSource == null)
            {
                return;
            }

            if (MessageBox.Show(config.ReadConfigValue("MAU", "UA_Code_Msginfo3"), config.ReadConfigValue("MAU", "UA_Code_Msginfo4"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                /*
                 * 执行删除道具操作
                 * */
                //toDelItemID = int.Parse(equipResult[currItemSelectRow, 1].oContent.ToString());
                DataTable dt = (DataTable)dgEquipList.DataSource;
                toDelItemID = int.Parse(dt.Rows[currDgSelectRow1]["道具ID"].ToString());
                DelPlayerEquip(userSN);

                //重新显示内容

            }
        }
    }
}