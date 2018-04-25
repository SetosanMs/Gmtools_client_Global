using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using C_Global;
using C_Event;
using Language;
namespace M_SDO
{
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("玩家消费信息", "Frm_SDO_Shopping", "SDO管理工具 -- 玩家消费信息", "SDO Group")]
    public partial class Frm_SDO_Shopping : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        private string _ServerIP;

        public Frm_SDO_Shopping()
        {
            InitializeComponent();
            Frm_SDO_Shopping.CheckForIllegalCrossThreadCalls = false;
        }

        #region 自定义调用事件
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            Frm_SDO_Shopping mModuleFrm = new Frm_SDO_Shopping();
            mModuleFrm.m_ClientEvent = (CSocketEvent)oEvent;
            if (oParent != null)
            {
                mModuleFrm.MdiParent = (Form)oParent;
                mModuleFrm.Show();
            }
            else
            {
                mModuleFrm.ShowDialog();
            }

            return mModuleFrm;
        }
        #endregion

        private void Frm_SDO_Shopping_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            //服务器列表
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 3;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);

            //mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);

            //CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            ////货币类型
            //CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Mtype"));
            //CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Gtype"));
            //CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Jifen"));
            //CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Alltype"));

            //CmbType.SelectedIndex = 0;

            //PnlPage.Visible = false;
            //LblTotal.Text = "";
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
            this.Text = config.ReadConfigValue("MSDO", "SP_UI_SdoShopping");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "SP_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "SP_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "SP_UI_LblAccount");
            this.LblDate.Text = config.ReadConfigValue("MSDO", "SP_UI_LblDate");
            this.LblLink.Text = config.ReadConfigValue("MSDO", "SP_UI_LblLink");
            this.LblType.Text = config.ReadConfigValue("MSDO", "SP_UI_LblType");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "SP_UI_BtnSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "SP_UI_BtnClose");
            this.GrpResult.Text = config.ReadConfigValue("MSDO", "SP_UI_GrpResult");
            this.LblPage.Text = config.ReadConfigValue("MSDO", "SP_UI_LblPage");
            this.lblItem.Text = config.ReadConfigValue("MSDO", "TD_UI_itemname");
        }


        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {

            if (CmbServer.Text == ""||this.backgroundWorkerPageChanged.IsBusy)
            {
                return;
            }
            PnlPage.Visible = false;
            GrdResult.DataSource = null;
            CmbPage.Items.Clear();
            LblTotal.Text = "";
            if(checkBox1.Checked)
            {
                SearchTrade();
            }
            else
            {
                SearchShoping();
            }




            //}
            //else
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "SP_Code_Msginfo"));
            //}
        }

        private void SearchTrade()
        {
            GrdResult.DataSource = null;
            CmbPage.Items.Clear();
            PnlPage.Visible = false;

            if (TxtAccount.Text.Trim().Length > 0 || txtItemname.Text.Trim().Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SDO_SendUserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text.Trim();

                mContent[1].eName = CEnum.TagName.SDO_ReceiveNick;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = txtItemname.Text.Trim();

                mContent[2].eName = CEnum.TagName.SDO_ServerIP;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = Operation_SDO.iPageSize;

                this.backgroundWorkerTrade.RunWorkerAsync(mContent);
            }
        }
        private void SearchShoping()
        {
            ArrayList paramList = new ArrayList();
            //if (TxtAccount.Text.Trim().Length > 0)
            //{
            this.BtnSearch.Enabled = false;
            this.Cursor = Cursors.AppStarting;
            GrdResult.DataSource = null;

            CEnum.Message_Body[] mContent1 = new CEnum.Message_Body[8];

            mContent1[0].eName = CEnum.TagName.SDO_Account;
            mContent1[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent1[0].oContent = TxtAccount.Text;

            mContent1[1].eName = CEnum.TagName.SDO_ServerIP;
            mContent1[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent1[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);
            this._ServerIP = mContent1[1].oContent.ToString();

            mContent1[2].eName = CEnum.TagName.SDO_MoneyType;
            mContent1[2].eTag = CEnum.TagFormat.TLV_INTEGER;

            if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Mtype"))
                mContent1[2].oContent = 1;
            else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Gtype"))
                mContent1[2].oContent = 0;
            else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Jifen"))
                mContent1[2].oContent = 4;
            else
                mContent1[2].oContent = 2;

            mContent1[3].eName = CEnum.TagName.SDO_BeginTime;
            mContent1[3].eTag = CEnum.TagFormat.TLV_DATE;
            mContent1[3].oContent = DtpBegin.Value;

            mContent1[4].eName = CEnum.TagName.SDO_EndTime;
            mContent1[4].eTag = CEnum.TagFormat.TLV_DATE;
            mContent1[4].oContent = DtpEnd.Value;

            mContent1[5].eName = CEnum.TagName.Index;
            mContent1[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent1[5].oContent = 1;

            mContent1[6].eName = CEnum.TagName.PageSize;
            mContent1[6].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent1[6].oContent = Operation_SDO.iPageSize;

            mContent1[7].eName = CEnum.TagName.SDO_ItemName;
            mContent1[7].eTag = CEnum.TagFormat.TLV_STRING;
            mContent1[7].oContent = txtItemname.Text.Trim();



            //合计
            CEnum.Message_Body[] mContent2 = new CEnum.Message_Body[5];

            mContent2[0].eName = CEnum.TagName.SDO_Account;
            mContent2[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent2[0].oContent = TxtAccount.Text;

            mContent2[1].eName = CEnum.TagName.SDO_ServerIP;
            mContent2[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent2[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent2[2].eName = CEnum.TagName.SDO_MoneyType;
            mContent2[2].eTag = CEnum.TagFormat.TLV_INTEGER;

            if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Mtype"))
                mContent2[2].oContent = 1;
            else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Gtype"))
                mContent2[2].oContent = 0;
            else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Jifen"))
                mContent2[2].oContent = 4;
            else
                mContent2[2].oContent = 2;

            mContent2[3].eName = CEnum.TagName.SDO_BeginTime;
            mContent2[3].eTag = CEnum.TagFormat.TLV_DATE;
            mContent2[3].oContent = DtpBegin.Value;

            mContent2[4].eName = CEnum.TagName.SDO_EndTime;
            mContent2[4].eTag = CEnum.TagFormat.TLV_DATE;
            mContent2[4].oContent = DtpEnd.Value;

            paramList.Add(this.m_ClientEvent);
            paramList.Add(CEnum.ServiceKey.SDO_CONSUME_QUERY);
            paramList.Add(mContent1);
            paramList.Add(this.m_ClientEvent);
            paramList.Add(CEnum.ServiceKey.SDO_USERCONSUMESUM_QUERY);
            paramList.Add(mContent2);

            this.backgroundWorkerSearch.RunWorkerAsync(paramList);
        }
        //private void search()
        //{
        //    GrdResult.DataSource = null;
        //    CmbPage.Items.Clear();
        //    LblTotal.Text = "";


        //    if (TxtAccount.Text.Trim().Length > 0)
        //    {
        //        GrdResult.DataSource = null;

        //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[7];

        //        mContent[0].eName = CEnum.TagName.SDO_Account;
        //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[0].oContent = TxtAccount.Text;

        //        mContent[1].eName = CEnum.TagName.SDO_ServerIP;
        //        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);
        //        this._ServerIP = mContent[1].oContent.ToString();

        //        mContent[2].eName = CEnum.TagName.SDO_MoneyType;
        //        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

        //        if (CmbType.Text == "Ｍ币")
        //            mContent[2].oContent = 1;
        //        else if (CmbType.Text == "Ｇ币")
        //            mContent[2].oContent = 0;
        //        else if (CmbType.Text == "积分")
        //            mContent[2].oContent = 4;
        //        else
        //            mContent[2].oContent = 2;

        //        mContent[3].eName = CEnum.TagName.SDO_BeginTime;
        //        mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
        //        mContent[3].oContent = DtpBegin.Value;

        //        mContent[4].eName = CEnum.TagName.SDO_EndTime;
        //        mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
        //        mContent[4].oContent = DtpEnd.Value;

        //        mContent[5].eName = CEnum.TagName.Index;
        //        mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
        //        mContent[5].oContent = 1;

        //        mContent[6].eName = CEnum.TagName.PageSize;
        //        mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
        //        mContent[6].oContent = Operation_SDO.iPageSize;

        //        CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_CONSUME_QUERY, mContent);

        //        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
        //        {
        //            MessageBox.Show(mResult[0, 0].oContent.ToString());
        //            return;
        //        }

        //        Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

        //        if (iPageCount <= 0)
        //        {
        //            PnlPage.Visible = false;
        //        }
        //        else
        //        {
        //            for (int i = 0; i < iPageCount; i++)
        //            {
        //                CmbPage.Items.Add(i + 1);
        //            }

        //            CmbPage.SelectedIndex = 0;
        //            bFirst = true;
        //            PnlPage.Visible = true;
        //        }

        //        //合计
        //        mContent = new CEnum.Message_Body[5];

        //        mContent[0].eName = CEnum.TagName.SDO_Account;
        //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[0].oContent = TxtAccount.Text;

        //        mContent[1].eName = CEnum.TagName.SDO_ServerIP;
        //        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

        //        mContent[2].eName = CEnum.TagName.SDO_MoneyType;
        //        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

        //        if (CmbType.Text == "Ｍ币")
        //            mContent[2].oContent = 1;
        //        else if (CmbType.Text == "Ｇ币")
        //            mContent[2].oContent = 0;
        //        else if (CmbType.Text == "积分")
        //            mContent[2].oContent = 4;
        //        else
        //            mContent[2].oContent = 2;

        //        mContent[3].eName = CEnum.TagName.SDO_BeginTime;
        //        mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
        //        mContent[3].oContent = DtpBegin.Value;

        //        mContent[4].eName = CEnum.TagName.SDO_EndTime;
        //        mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
        //        mContent[4].oContent = DtpEnd.Value;

        //        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
        //        {
        //            MessageBox.Show(mResult[0, 0].oContent.ToString());
        //            return;
        //        }

        //        mResult = Operation_SDO.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_USERCONSUMESUM_QUERY, mContent);

        //        LblTotal.Text = "合计：" + mResult[0, 0].oContent.ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("请输入玩家帐号！");
        //    }
        //}

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                if (checkBox1.Checked)
                {
                    CmbPage.Enabled = false;
                    Cursor = Cursors.AppStarting;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.SDO_SendUserID;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = TxtAccount.Text;

                    mContent[1].eName = CEnum.TagName.SDO_ReceiveNick;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = txtItemname.Text;

                    mContent[2].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[3].eName = CEnum.TagName.Index;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_SDO.iPageSize + 1;

                    mContent[4].eName = CEnum.TagName.PageSize;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = Operation_SDO.iPageSize;

                    this.backgroundWorkerTradePage.RunWorkerAsync(mContent);
                }
                else
                {
                    this.CmbPage.Enabled = false;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.SDO_Account;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = TxtAccount.Text;

                    mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[2].eName = CEnum.TagName.SDO_MoneyType;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;

                    if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Mtype"))
                        mContent[2].oContent = 1;
                    else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Gtype"))
                        mContent[2].oContent = 0;
                    else if (CmbType.Text == config.ReadConfigValue("MSDO", "SP_Code_Jifen"))
                        mContent[2].oContent = 4;
                    else
                        mContent[2].oContent = 2;

                    mContent[3].eName = CEnum.TagName.SDO_BeginTime;
                    mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                    mContent[3].oContent = DtpBegin.Value;

                    mContent[4].eName = CEnum.TagName.SDO_EndTime;
                    mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                    mContent[4].oContent = DtpEnd.Value;

                    mContent[5].eName = CEnum.TagName.Index;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_SDO.iPageSize + 1; ;

                    mContent[6].eName = CEnum.TagName.PageSize;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = Operation_SDO.iPageSize;

                    mContent[7].eName = CEnum.TagName.SDO_ItemName;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = txtItemname.Text.Trim();

                    this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);
                }

                //CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_CONSUME_QUERY, mContent);

                //Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
            }
        }

        private void GrpSearch_Enter(object sender, EventArgs e)
        {

        }

        private void GrdResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GrdResult_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int selectRow = e.RowIndex;


                BrowseDaysLimit browseDaysLimit = new BrowseDaysLimit(int.Parse(GrdResult[config.ReadConfigValue("MSDO", "SP_Code_Msginfo1"), e.RowIndex].Value.ToString()), _ServerIP, MousePosition.X, MousePosition.Y);
                browseDaysLimit.CreateModule(null, m_ClientEvent);

            }
            catch
            {
            }
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            //货币类型
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Mtype"));
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Gtype"));
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Jifen"));
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "SP_Code_Alltype"));

            CmbType.SelectedIndex = 0;

            PnlPage.Visible = false;
            LblTotal.Text = "";
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList paramList = (ArrayList)e.Argument;
            lock (typeof(C_Event.CSocketEvent))
            {
                object o1 = Operation_SDO.GetResult(tmp_ClientEvent, (CEnum.ServiceKey)paramList[1], (CEnum.Message_Body[])paramList[2]);
                object o2 = Operation_SDO.GetResult(tmp_ClientEvent, (CEnum.ServiceKey)paramList[4], (CEnum.Message_Body[])paramList[5]);
                paramList.Clear();
                paramList.Add(o1);
                paramList.Add(o2);
            }
            e.Result = paramList;
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //this.Activate();
                ArrayList result = (ArrayList)e.Result;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])result[0];
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    this.BtnSearch.Enabled = true;
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    throw new Exception();
                }
                lock (typeof(Operation_SDO))
                {
                    Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
                }

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

                mResult = (CEnum.Message_Body[,])result[1];
                LblTotal.Text = config.ReadConfigValue("MSDO", "SP_Code_Sum") + mResult[0, 0].oContent.ToString();
                this.BtnSearch.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_CONSUME_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbPage.Enabled = true;
            Cursor = Cursors.Default;
            Operation_SDO.BuildDataTable(this.m_ClientEvent, (CEnum.Message_Body[,])e.Result, GrdResult, out iPageCount);
        }


        private void backgroundWorkerTrade_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_ITEMSHOP_TRADE_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerTrade_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnSearch.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

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

        private void backgroundWorkerTradePage_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_ITEMSHOP_TRADE_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerTradePage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbPage.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DtpBegin.Enabled = false;
                DtpEnd.Enabled = false;
                CmbType.Enabled = false;
                LblAccount.Text = config.ReadConfigValue("MSDO", "TD_UI_label1");
                lblItem.Text = config.ReadConfigValue("MSDO", "TD_UI_LblAccount");
                checkBox1.Text = config.ReadConfigValue("MSDO", "TD_UI_msgCon");
            }
            else
            {
                DtpBegin.Enabled = true;
                DtpEnd.Enabled = true;
                CmbType.Enabled = true;
                LblAccount.Text = config.ReadConfigValue("MSDO", "TD_UI_accont");
                lblItem.Text = config.ReadConfigValue("MSDO", "TD_UI_itemname");
                checkBox1.Text = config.ReadConfigValue("MSDO", "TD_UI_msgTra");
            }
        }






    }
}