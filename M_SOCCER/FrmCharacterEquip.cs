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
using Language;
namespace M_SOCCER
{
    [C_Global.CModuleAttribute("玩家身上道具", "FrmCharacterEquip", "劲爆足球", "soccer")]
    public partial class FrmCharacterEquip : Form
    {
        public FrmCharacterEquip()
        {
            InitializeComponent();
        }

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] senceResult = null;
        DataTable dgTable = new DataTable();
        private int iIndexID = 0;
        private int iBoardID = -1;
        int currSelectPSTID = 0;
        bool firstLoad = true;
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
            this.Text = config.ReadConfigValue("MSOCCER", "FCE_UI_FrmName");
            this.ItmDelete.Text = config.ReadConfigValue("MSOCCER", "FCE_UI_ItmDelete");
            this.LblPage.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_LblPage");
            this.GrpSearch.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_GrpSearch");
            this.lbltype.Text = config.ReadConfigValue("MSOCCER", "FCE_UI_lbltype");
            this.label1.Text = config.ReadConfigValue("MSOCCER", "FCE_UI_label1");
            this.label2.Text = config.ReadConfigValue("MSOCCER", "FCE_UI_label2");
            this.BtnClose.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_BtnClose");
            this.BtnSearch.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_BtnSearch");
            this.LblServer.Text = config.ReadConfigValue("MSOCCER", "FCE_UI_LblServer");
            this.checkBoxQuery.Checked = true;
        }


        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            if (this.backgroundWorkFrmCharinfo.IsBusy)
            {
                return;
            }
            GrdResult.DataSource = null;
            CmbPage.Items.Clear();
            PnlPage.Visible = false;
            ItmDelete.Enabled = true;
            if (TxtReciveAccount.Text.Trim().Length == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FAA_Code_msginfo"));
            }
            else
            {
                SerchUserinfo();
            }
        }
        private void SerchUserinfo()
        {
            BtnSearch.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            bFirst = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

            mContent[0].eName = CEnum.TagName.Soccer_SenderUserName;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtReciveAccount.Text;

            mContent[1].eName = CEnum.TagName.Soccer_item_type;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = FindItemType(cbtype.Text.Trim());

            mContent[2].eName = CEnum.TagName.Soccer_ServerIP;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[3].eName = CEnum.TagName.Index;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = 1;

            mContent[4].eName = CEnum.TagName.PageSize;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = Operation_Soccer.iPageSize;

            this.backgroundWorkFrmCharinfo.RunWorkerAsync(mContent);
        }
        private int FindItemType(string strtype)
        {   
            int type = -1;
            if (strtype == config.ReadConfigValue("MSOCCER", "FCE_Code_Skill"))
            {   //"技能"
                type = 0;
            }
            else if(strtype == config.ReadConfigValue("MSOCCER", "FCE_Code_item"))
            {   //"道具"
                type = 1;
            }
            else if (strtype == config.ReadConfigValue("MSOCCER", "FCE_Code_all"))
               // "全部"
              
            {
                type = 2;
            }
            return type;
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

        private void FrmCharacterEquip_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeServerIP();
            //InitializeItem();
            PnlPage.Visible = false;
            cbtype.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_Skill"));
            cbtype.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_item"));
            cbtype.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_all"));
            cbtype.SelectedIndex = 2;
            TxtReciveAccount.Focus();
            tabPlayerControl.Visible = false;
            CmbType.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_FatGirl"));
            CmbType.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_HighGirl"));
            CmbType.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_NormalGirl"));
            CmbType.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_FatBoy"));
            CmbType.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_HighBoy"));
            CmbType.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_NormalBoy"));
            CmbType.Text = config.ReadConfigValue("MSOCCER", "FCE_Code_FatGirl");

            CmbSort.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_hair"));
            CmbSort.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_face"));
            CmbSort.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_hands"));
            CmbSort.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_upper"));
            CmbSort.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_lower"));
            CmbSort.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_feet"));
            CmbSort.Items.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_backpack"));
            //CmbSort.Text = config.ReadConfigValue("MSOCCER", "FCE_Code_hair");
            firstLoad = false;

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void InitializeItem()
        {
            CmbItem.Items.Clear();
            try
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    senceResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SOCCER_ITEM_SKILL_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, null);
                }

                if (senceResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(senceResult[0, 0].oContent.ToString());
                    return;
                }

                for (int i = 0; i < senceResult.GetLength(0); i++)
                {
                    CmbItem.Items.Add(senceResult[i, 1].oContent.ToString());
                }
                CmbItem.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.CmbServer.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_Soccer");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                this.backgroundWorkFrmLoad.RunWorkerAsync(messageBody);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorkFrmLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkFrmLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //检测状态
            this.GrdResult.Cursor = Cursors.Default;

            if (mServerInfo[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mServerInfo[0, 0].oContent.ToString());
                return;
            }

            //显示内容到列表

            for (int i = 0; i < mServerInfo.GetLength(0); i++)
            {
                this.CmbServer.Items.Add(mServerInfo[i, 1].oContent.ToString());
            }

            this.CmbServer.SelectedIndex = 0;
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void backgroundWorkFrmCharinfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Soccer.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SOCCER_ACCOUNT_ITEMSKILL_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkFrmCharinfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            this.Cursor = Cursors.Default;
            this.tabPlayerControl.Enabled = true;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            //Operation_Soccer.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
            GrdResult.DataSource = BrowseResultInfo();      //设置datagrid数据源

            CmbPage.Items.Clear();
            iPageCount = int.Parse(mResult[0, 11].oContent.ToString());
            if (iPageCount <= 0)
            {
                PnlPage.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }

                CmbPage.SelectedIndex = 0;
                bFirst = true;
                PnlPage.Visible = true;
            }
            tabPlayerControl.Visible = true;
        }

        private DataTable BrowseResultInfo()
        {
            try
            {
                dgTable = new DataTable();
                //dgTable.Columns.Add("ID");
                //dgTable.Columns.Add("玩家帐号");
                //dgTable.Columns.Add("角色名");
                //dgTable.Columns.Add("类别");
                //dgTable.Columns.Add("物品ID");
                //dgTable.Columns.Add("物品名");
                //dgTable.Columns.Add("状态");
                //dgTable.Columns.Add("购买日期");
                //dgTable.Columns.Add("失效日期");
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_ID"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_senduser"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_charname"), typeof(string));

                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_class"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_itemcode"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_itemname"), typeof(string));

                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_stuas"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_buytime"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCE_Code_deltime"), typeof(string));

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    //dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_ID")] = accountResult[i, 1].oContent.ToString();
                    //dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_FreezeDate")] = accountResult[i, 13].oContent.ToString();
                    //if (accountResult[i, 13].oContent.ToString() == "")
                    //{
                    //    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Status")] = ReturnState("OnUse");
                    //}
                    //else
                    //{
                    //    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Status")] = accountResult[i, 14].oContent.ToString();
                    //}
                    
                    //dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_reciveuser")] = mResult[i, 1].oContent.ToString();
                    //dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_itemcode")] = mResult[i, 8].oContent.ToString();
                    //dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_itemname")] = mResult[i, 2].oContent.ToString();
                    //dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_class")] = mResult[i, 3].oContent.ToString() == "1" ? config.ReadConfigValue("MSOCCER", "FPT_Code_item") : config.ReadConfigValue("MSOCCER", "FPT_Code_skill");
                    //dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_senduser")] = mResult[i, 7].oContent.ToString();
                    //dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_buytime")] = mResult[i, 5].oContent.ToString();
                    //dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_deltime")] = mResult[i, 6].oContent.ToString();
                    //dgRow["ID"] = mResult[i, 9].oContent.ToString();
                    //dgRow["玩家帐号"] = mResult[i, 1].oContent.ToString().Trim();
                    //dgRow["角色名"] = mResult[i, 10].oContent.ToString();
                    //dgRow["类别"] = mResult[i, 3].oContent.ToString() == "1" ? "道具" : "技能";
                    //dgRow["物品ID"] = mResult[i, 8].oContent.ToString();
                    //dgRow["物品名"] = mResult[i, 2].oContent.ToString();
                    //if (mResult[i, 3].oContent.ToString() == "1")
                    //{
                    //    dgRow["状态"] = mResult[i, 4].oContent.ToString() == "1" ? "装备" : "未装备";
                    //}
                    //else
                    //{
                    //    dgRow["状态"] = mResult[i, 4].oContent.ToString() == "255" ? "未装备" : mResult[i, 4].oContent.ToString();
                    //}
                    //dgRow["购买日期"] = mResult[i, 5].oContent.ToString();
                    //dgRow["失效日期"] = mResult[i, 6].oContent.ToString();

                    dgRow[config.ReadConfigValue("MSOCCER", "FCE_Code_ID")] = mResult[i, 9].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCE_Code_senduser")] = mResult[i, 1].oContent.ToString().Trim();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCE_Code_charname")] = mResult[i, 10].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCE_Code_class")] = mResult[i, 3].oContent.ToString() == "1" ? config.ReadConfigValue("MSOCCER", "FCE_Code_item") : config.ReadConfigValue("MSOCCER", "FCE_Code_Skill");
                    dgRow[config.ReadConfigValue("MSOCCER", "FCE_Code_itemcode")] = mResult[i, 8].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCE_Code_itemname")] = mResult[i, 2].oContent.ToString();
                    if (mResult[i, 3].oContent.ToString() == "1")
                    {
                        dgRow[config.ReadConfigValue("MSOCCER", "FCE_Code_stuas")] = mResult[i, 4].oContent.ToString() == "1" ? config.ReadConfigValue("MSOCCER", "FCE_Code_equip") : config.ReadConfigValue("MSOCCER", "FCE_Code_Unequip");
                    }
                    else
                    {
                        dgRow[config.ReadConfigValue("MSOCCER", "FCE_Code_stuas")] = mResult[i, 4].oContent.ToString() == "255" ? config.ReadConfigValue("MSOCCER", "FCE_Code_Unequip") : mResult[i, 4].oContent.ToString();
                    }
                    dgRow[config.ReadConfigValue("MSOCCER", "FCE_Code_buytime")] = mResult[i, 5].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_deltime")] = mResult[i, 6].oContent.ToString();

                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        private void GrdResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ItmDelete_Click(object sender, EventArgs e)
        {
            DataTable mBoard = (DataTable)GrdResult.DataSource;
            this.GrdResult.Cursor = Cursors.WaitCursor;
            int inttype = -1;
            if (mBoard.Rows[iIndexID][3].ToString().Trim().Equals(config.ReadConfigValue("MSOCCER", "FCE_Code_Skill")))
            {
                inttype = 0;
            }
            else
            {
                inttype = 1;
            }
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[7];

            mContent[0].eName = CEnum.TagName.Soccer_charidx;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = Convert.ToInt32(mBoard.Rows[iIndexID][0].ToString());

            mContent[1].eName = CEnum.TagName.Soccer_item_type;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = inttype;

            mContent[2].eName = CEnum.TagName.Soccer_idx;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = Convert.ToInt32(mBoard.Rows[iIndexID][4].ToString());

            mContent[3].eName = CEnum.TagName.Soccer_item_equip;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = FindItemEquip(mBoard.Rows[iIndexID][3].ToString(), mBoard.Rows[iIndexID][6].ToString());

            mContent[4].eName = CEnum.TagName.Soccer_deleted_date;
            mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[4].oContent = "Gmtools";

            mContent[5].eName = CEnum.TagName.UserByID;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[6].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            mContent[6].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            mContent[6].oContent = Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text);
            this.backgroundWorkDel.RunWorkerAsync(mContent);

            //mResult = Operation_Soccer.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SOCCER_ITEM_SKILL_MODIFY, (CEnum.Message_Body[])e.Argument);
        }
        private int FindItemEquip(string strItemType,string strItems)
        {   
            int intItemEquip = -1;
            if (strItemType.Equals(config.ReadConfigValue("MSOCCER", "FCE_Code_Skill")) && strItems.Equals(config.ReadConfigValue("MSOCCER", "FCE_Code_Unequip")))
            {
                intItemEquip = 255;
            }
            else if (strItemType.Equals(config.ReadConfigValue("MSOCCER", "FCE_Code_item")) && strItems.Equals(config.ReadConfigValue("MSOCCER", "FCE_Code_equip")))
            {
                intItemEquip = 1;
            }
            else if (strItemType.Equals(config.ReadConfigValue("MSOCCER", "FCE_Code_item")) && strItems.Equals(config.ReadConfigValue("MSOCCER", "FCE_Code_Unequip")))
            {
                intItemEquip = 0;
            }
            else
            {
                intItemEquip = Convert.ToInt32(strItems);
            }
            return intItemEquip;
        }

        private void backgroundWorkDel_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Soccer.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SOCCER_ITEM_SKILL_MODIFY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                this.GrdResult.Cursor = Cursors.Default;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            if (mResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCE_Code_delsucc"));
                GrdResult.DataSource = null;
                CmbPage.Items.Clear();
                PnlPage.Visible = false;
                ItmDelete.Enabled = true;
                SerchUserinfo();
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCE_Code_delfail"));
            }
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                if (this.backgroundWorkFrmCharinfo.IsBusy)
                {
                    return;
                }
                this.CmbPage.Enabled = false;
                this.GrdResult.Cursor = Cursors.WaitCursor;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.Soccer_SenderUserName;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtReciveAccount.Text;

                mContent[1].eName = CEnum.TagName.Soccer_item_type;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = FindItemType(cbtype.Text.Trim());

                mContent[2].eName = CEnum.TagName.Soccer_ServerIP;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Soccer.iPageSize + 1; ;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_Soccer.iPageSize;

                this.backgroundWorkPage.RunWorkerAsync(mContent);
            }


        }

        private void backgroundWorkPage_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Soccer.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SOCCER_ACCOUNT_ITEMSKILL_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkPage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.CmbPage.Enabled = true;
            this.GrdResult.Cursor = Cursors.Default;

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            GrdResult.DataSource = null;
            GrdResult.DataSource = BrowseResultInfo();      //设置datagrid数据源
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txttitle.Text.Trim().Length == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCE_Code_msgtitle"));
                txttitle.Focus();
                return;
            }
            if (TxtMemo.Text.Trim().Length == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCE_Code_msgMem"));
                TxtMemo.Focus();
                return;
            }
            if (currSelectPSTID == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCE_Code_msgnochar"));
                return;
            }
            if ((lstItem.SelectedIndex == -1 && checkBoxQuery.Checked)|| CmbItem.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCE_Code_msgItem"));
                return;
            }

            if (MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCE_Code_MsgsendItem"), config.ReadConfigValue("MSOCCER", "FCE_UI_groupBox3"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InsertItem();
            }
            else
            {
                return;
            }
        }
        private void InsertItem()
        {
            btnAdd.Enabled = false;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

            mContent[0].eName = CEnum.TagName.UserByID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[1].eName = CEnum.TagName.Soccer_loginId;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = txtaccont.Text.Trim();

            mContent[2].eName = CEnum.TagName.Soccer_ServerIP;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text);


            mContent[3].eName = CEnum.TagName.Soccer_charidx;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = currSelectPSTID;

            mContent[4].eName = CEnum.TagName.Soccer_charname;
            mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[4].oContent = txtchar.Text.Trim();

            if (!this.checkBoxQuery.Checked)
            {
                mContent[5].eName = CEnum.TagName.Soccer_idx;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = GetItemIdx(CmbItem.Text.Trim());
            }
            else
            {
                mContent[5].eName = CEnum.TagName.Soccer_idx;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Convert.ToInt32(((ArrayList)lstItem.Tag)[lstItem.SelectedIndex]);
            }

            mContent[6].eName = CEnum.TagName.Soccer_title;
            mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[6].oContent = txttitle.Text.Trim();

            mContent[7].eName = CEnum.TagName.Soccer_content;
            mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[7].oContent = TxtMemo.Text.Trim();
            backgroundWorkInsertItem.RunWorkerAsync(mContent);
            //lock (typeof(C_Event.CSocketEvent))
            //{ 
            //    mResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SOCCER_ITEMSHOP_INSERT, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, mContent);
            //}


        }
        private void tabPlayerControl_Selected(object sender, TabControlEventArgs e)
        {

            SendGrid.DataSource = null;
            clearTxt();
            if (tabPlayerControl.SelectedTab.Name == "tabSenditem")
            {
                ReadFromAccount();
            }
            else
            {
                return;
            }
        }


        private int GetItemIdx(string itemName)
        {
            int itemIndex = 0;
            for (int i = 0; i < senceResult.GetLength(0); i++)
            {
                if (senceResult[i, 1].oContent.ToString().Equals(itemName))
                {
                    itemIndex = int.Parse(senceResult[i, 0].oContent.ToString());
                }
            }
            return itemIndex;
        }
        

        private void ReadFromAccount()
        {

            if (TxtReciveAccount.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FAA_Code_msginfo"));
                return;
            }
            else
            {   

                BtnSearch.Enabled = false;
                tabPlayerControl.Enabled = false;
                this.SendGrid.Cursor = Cursors.WaitCursor;
                string currUserAccount = TxtReciveAccount.Text.ToString().Trim();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
                messageBody[0].oContent = Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text);

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
                messageBody[1].oContent = currUserAccount;


                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
                messageBody[2].oContent = "uID";

                this.backgroundWorkCharinfo.RunWorkerAsync(messageBody);
            }


            //accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

            //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
            //    dpNoteText.Visible = false;     //隐藏信息提示
            //    dpModi.Visible = false;         //隐藏信息修改

            //    dgAccountInfo.DataSource = null;
            //    txtAccount.Clear();
            //    return;
            //}

            //dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源


            ////dpDataGrid.Visible = true;                          //显示datagrid容器
            //dpNoteText.Visible = true;                          //显示文本提示
        }

        private void backgroundWorkCharinfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Soccer.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SOCCER_CHARACTERINFO_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void backgroundWorkCharinfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            tabPlayerControl.Enabled = true;
            this.checkBoxQuery.Checked = false;
            this.SendGrid.Cursor = Cursors.Default;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                dpNoteText.Visible = false;     //隐藏信息提示
                dpModi.Visible = false;         //隐藏信息修改

                SendGrid.DataSource = null;
                //txtAccount.Clear();
                return;
            }

            SendGrid.DataSource = CharResultInfo();      //设置datagrid数据源
          

            //dpDataGrid.Visible = true;                          //显示datagrid容器
            dpNoteText.Visible = true;                          //显示文本提示
        }
        private DataTable CharResultInfo()
        {
            try
            {
                //dgTable.Columns.Clear();       //清空头信息


                //dgTable.Rows.Clear();          //清空行记录



                dgTable = new DataTable();
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_ID"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_DeleteDate"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Account"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Role"), typeof(string));

                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Sex"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_BodyType"), typeof(string));
                //dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Position"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Gcoin"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Level"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Exp"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_TotalTimes"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Victory"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Lose"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Draw"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Quit"), typeof(string));

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_ID")] = mResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_DeleteDate")] = mResult[i, 13].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Account")] = mResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Role")] = mResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Sex")] = mResult[i, 3].oContent.ToString() == "F" ? config.ReadConfigValue("MSOCCER", "FBA_Code_Female") : config.ReadConfigValue("MSOCCER", "FBA_Code_Male");
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_BodyType")] = Returnsex( mResult[i, 14].oContent.ToString());
                    //dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Position")] = Returnpostion(accountResult[i, 4].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Gcoin")] = mResult[i, 5].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Level")] = mResult[i, 6].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Exp")] = mResult[i, 7].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_TotalTimes")] = mResult[i, 8].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Victory")] = mResult[i, 9].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Lose")] = mResult[i, 10].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Draw")] = mResult[i, 12].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Quit")] = mResult[i, 11].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        private void SendGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //当前用户
                currSelectPSTID = int.Parse(dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_ID")].ToString());
                txtaccont.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_Account")].ToString().Trim();
                txtchar.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_Role")].ToString().Trim();

                //显示修改容器
                dpModi.Visible = true;
            }
            catch
            {
            }
        }

        private void btnCannel_Click(object sender, EventArgs e)
        {
            clearTxt();
            
        }
        private void clearTxt()
        {
            currSelectPSTID = 0;
            txtaccont.Text = "";
            txtchar.Text = "";
            txttitle.Text = "";
            TxtMemo.Text = "";
            CmbItem.Text = "";
            CmbItem.Items.Clear();
            txtItemName.Text = "";
            lstItem.Items.Clear();

        }
        private void backgroundWorkInsertItem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Soccer.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SOCCER_ITEMSHOP_INSERT, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkInsertItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAdd.Enabled = true;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            if (mResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCE_Code_InsertSucc"));
                clearTxt();
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCE_Code_InsertFail"));
            }
        }

        private void GrdResult_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                iIndexID = e.RowIndex;
                DataTable mBoardInfo = (DataTable)GrdResult.DataSource;

                if (mBoardInfo.Rows.Count > 0)
                {
                    iBoardID = int.Parse(mBoardInfo.Rows[iIndexID][0].ToString());
                }
            }
            catch
            { }
        }

        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (firstLoad != true)
            {
                CmbItem.Items.Clear();
                CmbItem.Text = "";
                int intType = -1;
                string strClass = "-1";
                if (CmbType.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_FatGirl").Trim())
                {
                    intType = 0;
                }
                else if (CmbType.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_HighGirl").Trim())
                {
                    intType = 1;
                }
                else if (CmbType.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_NormalGirl").Trim())
                {
                    intType = 2;
                }
                else if (CmbType.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_FatBoy").Trim())
                {
                    intType = 8;
                }
                else if (CmbType.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_HighBoy").Trim())
                {
                    intType = 9;
                }
                else if (CmbType.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_NormalBoy").Trim())
                {
                    intType = 7;
                }

                if (CmbSort.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_hair").Trim())
                {
                    strClass = "hair";
                }
                else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_face").Trim())
                {
                    strClass = "face";
                }
                else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_hands").Trim())
                {
                    strClass = "hands";
                }
                else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_upper").Trim())
                {
                    strClass = "upper";
                }
                else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_lower").Trim())
                {
                    strClass = "lower";
                }
                else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_feet").Trim())
                {
                    strClass = "feet";
                }
                else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSOCCER", "FCE_Code_backpack").Trim())
                {
                    strClass = "backpack";
                }

                CEnum.Message_Body[] mItemContent = new CEnum.Message_Body[3];
                mItemContent[0].eName = CEnum.TagName.Soccer_ServerIP;
                mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mItemContent[0].oContent = Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text);

                mItemContent[1].eName = CEnum.TagName.Soccer_item_type;
                mItemContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[1].oContent = intType;

                mItemContent[2].eName = CEnum.TagName.Soccer_body_part;
                mItemContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mItemContent[2].oContent = strClass;



                try
                {
                    lock (typeof(C_Event.CSocketEvent))
                    {
                        senceResult = null;
                        senceResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SOCCER_ITEM_SKILL_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, mItemContent);
                    }

                    if (senceResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(senceResult[0, 0].oContent.ToString());
                        return;
                    }

                    for (int i = 0; i < senceResult.GetLength(0); i++)
                    {
                        CmbItem.Items.Add(senceResult[i, 1].oContent.ToString());
                    }
                    CmbItem.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //mItemInfo = Operation_Soccer.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_QUERY, mItemContent);
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbItem.Items.Clear();
            CmbItem.Text = "";
        }

        private void checkBoxQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQuery.Checked)
            {
                this.groupBox1.Enabled = false;
                this.groupBoxQuery.Enabled = true;
            }
            else
            {
                this.groupBox1.Enabled = true;
                this.groupBoxQuery.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            button1.Enabled = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

            mContent[0].eName = CEnum.TagName.Soccer_content;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = txtItemName.Text.Trim();

            this.backgroundWorkerBlurQuery.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerBlurQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Soccer.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SOCCER_ITEM_SKILL_BLUR_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerBlurQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ArrayList codeList = new ArrayList();
            try
            {
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    lstItem.Items.Clear();
                    lstItem.Tag = null;
                    for (int i = 0; i < mResult.GetLength(0); i++)
                    {
                        string StrPostion = null;
                        switch (mResult[i, 3].oContent.ToString())
                        {
                            case "0":
                                StrPostion = config.ReadConfigValue("MSOCCER", "FCE_Code_FatGirl");
                                break;
                            case "1":
                                StrPostion = config.ReadConfigValue("MSOCCER", "FCE_Code_HighGirl");
                                break;
                            case "2":
                                StrPostion = config.ReadConfigValue("MSOCCER", "FCE_Code_NormalGirl");
                                break;
                            case "7":
                                StrPostion = config.ReadConfigValue("MSOCCER", "FCE_Code_NormalBoy");
                                break;
                            case "8":
                                StrPostion = config.ReadConfigValue("MSOCCER", "FCE_Code_FatBoy");
                                break;
                            case "9":
                                StrPostion = config.ReadConfigValue("MSOCCER", "FCE_Code_HighBoy");
                                break;
                            default:
                                StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Other");
                                break;
                        }
                        codeList.Add(mResult[i, 0].oContent.ToString());
                        lstItem.Items.Add(mResult[i, 1].oContent.ToString() + "(" +
                            StrPostion + ")");
                    }
                    lstItem.Tag = codeList;
                }
            }
            catch
            {

            }
            finally
            {
                this.UseWaitCursor = false;
                button1.Enabled = true;
            }
        }
    }
}