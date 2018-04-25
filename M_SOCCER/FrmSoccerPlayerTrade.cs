using System;
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
    [C_Global.CModuleAttribute("玩家交易记录", "FrmSoccerPlayerTrade", "劲爆足球", "soccer")]
    public partial class FrmSoccerPlayerTrade : Form
    {
        public FrmSoccerPlayerTrade()
        {
            InitializeComponent();
        }


        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        private CEnum.Message_Body[,] mResult = null;
        DataTable dgTable = new DataTable();
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
            this.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_FrmName");
            this.GrpResult.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_GrpResult");
            this.LblPage.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_LblPage");
            this.GrpSearch.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_GrpSearch");
            this.label1.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_label1");
            this.BtnClose.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_BtnClose");
            this.BtnSearch.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_BtnSearch");
            this.LblAccount.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_LblAccount");
            this.LblServer.Text = config.ReadConfigValue("MSOCCER", "FPT_UI_LblServer");

        }


        #endregion
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

                this.backgroundWorkerFormLoad.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    mServerInfo = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                //}

                ////检测状态


                //if (mServerInfo[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mServerInfo[0, 0].oContent.ToString());
                //    return;
                //}

                ////显示内容到列表

                //for (int i = 0; i < mServerInfo.GetLength(0); i++)
                //{
                //    this.CmbServer.Items.Add(mServerInfo[i, 1].oContent.ToString());
                //}

                //this.CmbServer.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPlayerTrade_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeServerIP();
            PnlPage.Visible = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            if (this.backgroundWorkerchange.IsBusy)
            {
                return;
            }
            GrdResult.DataSource = null;
            CmbPage.Items.Clear();
            PnlPage.Visible = false;


            if (TxtSenderAccount.Text.Trim().Length > 0 || TxtReciveAccount.Text.Trim().Length > 0)
            {
                BtnSearch.Enabled = false;
                Cursor = Cursors.WaitCursor;
                bFirst = false;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.Soccer_SenderUserName;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtReciveAccount.Text;

                mContent[1].eName = CEnum.TagName.Soccer_ReceiveUserName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtSenderAccount.Text;

                mContent[2].eName = CEnum.TagName.Soccer_ServerIP;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_Soccer.iPageSize;
                this.backgroundWorkerSerch.RunWorkerAsync(mContent);
            //    lock (typeof(C_Event.CSocketEvent))
            //    {
            //        mResult = Operation_Soccer.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SOCCER_USERTRADE_QUERY, mContent);
            //    }
            //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //    {
            //        MessageBox.Show(mResult[0, 0].oContent.ToString());
            //        return;
            //    }

            //    //Operation_Soccer.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
            //    GrdResult.DataSource = BrowseResultInfo();      //设置datagrid数据源

            //    CmbPage.Items.Clear();
            //    iPageCount = int.Parse(mResult[0, 8].oContent.ToString());
            //    if (iPageCount <= 0)
            //    {
            //        PnlPage.Visible = false;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < iPageCount; i++)
            //        {
            //            CmbPage.Items.Add(i + 1);
            //        }

            //        CmbPage.SelectedIndex = 0;
            //        bFirst = true;
            //        PnlPage.Visible = true;
            //    }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_InputAccount"));
            }
        }

        private DataTable BrowseResultInfo()
        {
            try
            {
                dgTable = new DataTable();
                dgTable.Columns.Add("ID");
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_reciveuser"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_itemcode"), typeof(string));
                
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_itemname"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_class"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_senduser"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_buytime"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_deltime"), typeof(string));
  
                //dgTable.Columns.Add("赠送人帐号");
                //dgTable.Columns.Add("道具名");
                //dgTable.Columns.Add("类别");
                //dgTable.Columns.Add("接收人帐号");
                //dgTable.Columns.Add("购买日期");
                //dgTable.Columns.Add("失效日期");

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
                    dgRow["ID"] = mResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_reciveuser")] = mResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_itemcode")] = mResult[i, 8].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_itemname")] = mResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_class")] = mResult[i, 3].oContent.ToString() == "1" ? config.ReadConfigValue("MSOCCER", "FPT_Code_item") : config.ReadConfigValue("MSOCCER", "FPT_Code_skill");
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_senduser")] = mResult[i, 7].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_buytime")] = mResult[i, 5].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_deltime")] = mResult[i, 6].oContent.ToString();
                    
                    //dgRow["赠送人帐号"] = mResult[i, 1].oContent.ToString().Trim();
                    //dgRow["道具名"] = mResult[i, 2].oContent.ToString();
                    //dgRow["类别"] = mResult[i, 3].oContent.ToString() == "1" ? "道具" : "技能";
                    //dgRow["接收人帐号"] = mResult[i, 7].oContent.ToString();
                    //dgRow["购买日期"] = mResult[i, 5].oContent.ToString();
                    //dgRow["失效日期"] = mResult[i, 6].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.backgroundWorkerSerch.IsBusy)
            {
                return;
            }
            if (bFirst)
            {
                this.CmbPage.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];
                messageBody[0].eName = CEnum.TagName.Soccer_SenderUserName;
                messageBody[0].eTag = CEnum.TagFormat.TLV_STRING;
                messageBody[0].oContent = TxtReciveAccount.Text;

                messageBody[1].eName = CEnum.TagName.Soccer_ReceiveUserName;
                messageBody[1].eTag = CEnum.TagFormat.TLV_STRING;
                messageBody[1].oContent = TxtSenderAccount.Text;

                messageBody[2].eName = CEnum.TagName.Soccer_ServerIP;
                messageBody[2].eTag = CEnum.TagFormat.TLV_STRING;
                messageBody[2].oContent = Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text);

                messageBody[3].eName = CEnum.TagName.Index;
                messageBody[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Soccer.iPageSize + 1;

                messageBody[4].eName = CEnum.TagName.PageSize;
                messageBody[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].oContent = Operation_Soccer.iPageSize;
                this.backgroundWorkerchange.RunWorkerAsync(messageBody);
                //CEnum.Message_Body[,] mResult = null;
                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    mResult = Operation_Soccer.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SOCCER_USERTRADE_QUERY, messageBody);
                //}
                //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                //    return;
                //}
                //GrdResult.DataSource = null;
                //GrdResult.DataSource = ReturnPageResult(mResult);

            }
        }
        private DataTable ReturnPageResult(CEnum.Message_Body[,] PageResult)
        {
            try
            {
                dgTable = new DataTable();
                //dgTable.Columns.Add("id");
                //dgTable.Columns.Add("赠送人帐号");
                //dgTable.Columns.Add("道具名");
                //dgTable.Columns.Add("类别");
                //dgTable.Columns.Add("接收人帐号");
                //dgTable.Columns.Add("购买日期");
                //dgTable.Columns.Add("失效日期");
                dgTable.Columns.Add("ID");
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_reciveuser"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_itemcode"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_itemname"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_class"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_senduser"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_buytime"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FPT_Code_deltime"), typeof(string));

                for (int i = 0; i < PageResult.GetLength(0); i++)
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
                    //dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Account")] = accountResult[i, 0].oContent.ToString();
                    //dgRow[config.ReadConfigValue("MSOCCER", "FRC_Code_RoleName")] = accountResult[i, 2].oContent.ToString();
                    //dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Sex")] = accountResult[i, 3].oContent.ToString() == "F" ? config.ReadConfigValue("MSOCCER", "FBA_Code_Female") : config.ReadConfigValue("MSOCCER", "FBA_Code_Male");
                    //dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Position")] = Returnpostion(accountResult[i, 4].oContent.ToString());
                    //dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Gcoin")] = accountResult[i, 5].oContent.ToString();
                    //dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Level")] = accountResult[i, 6].oContent.ToString();
                    //dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Exp")] = accountResult[i, 7].oContent.ToString();
                    dgRow["ID"] = PageResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_reciveuser")] = PageResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_itemcode")] = PageResult[i, 8].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_itemname")] = PageResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_class")] = PageResult[i, 3].oContent.ToString() == "1" ? config.ReadConfigValue("MSOCCER", "FPT_Code_item") : config.ReadConfigValue("MSOCCER", "FPT_Code_skill");
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_senduser")] = PageResult[i, 7].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_buytime")] = PageResult[i, 5].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FPT_Code_deltime")] = PageResult[i, 6].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //检测状态
            Cursor = Cursors.Default;

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

        private void backgroundWorkerSerch_DoWork(object sender, DoWorkEventArgs e)
        {
             lock (typeof(C_Event.CSocketEvent))
             {
                mResult = Operation_Soccer.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SOCCER_USERTRADE_QUERY, (CEnum.Message_Body[])e.Argument);
             }
        }

        private void backgroundWorkerSerch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            Cursor = Cursors.Default;
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

        }

        private void backgroundWorkerchange_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Soccer.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SOCCER_USERTRADE_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerchange_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.CmbPage.Enabled = true;
            this.Cursor = Cursors.Default;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            GrdResult.DataSource = null;
            GrdResult.DataSource = ReturnPageResult(mResult);
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text));
        }

    }
}
