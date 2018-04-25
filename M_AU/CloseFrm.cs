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

namespace M_Audition
{
    /// <summary>
    /// Frm_SDO_Part 的摘要说明。
    /// </summary>
    [C_Global.CModuleAttribute("帐号解/封停", "Frm_AU_Close", "AU管理工具 -- 帐号解/封停", "AU Group")]
    public partial class Frm_AU_Close : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iUserID = 0;
        private string strUserNick = null;

        private int iPageCount = 0;
        private bool bFirst = false;

        public Frm_AU_Close()
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
            this.Text = config.ReadConfigValue("MAU", "BU_UI_frmname");
            this.GrpSearch.Text = config.ReadConfigValue("MAU", "BU_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MAU", "BU_UI_LblServer");
            this.Btn_Search.Text = config.ReadConfigValue("MAU", "BU_UI_Btn_Search");
            this.BtnClose.Text = config.ReadConfigValue("MAU", "BU_UI_BtnClose");
            this.GrpResult.Text = config.ReadConfigValue("MAU", "BU_UI_GrpResult");
            this.LblPage.Text = config.ReadConfigValue("MAU", "BU_UI_LblPage");
            this.LblNN.Text = config.ReadConfigValue("MAU", "BU_UI_username");

            this.label1.Text = config.ReadConfigValue("MAU", "BU_UI_bandate");
            this.LblMemo.Text = config.ReadConfigValue("MAU", "BU_UI_reason");
            this.BtnSave.Text = config.ReadConfigValue("MAU", "BU_UI_BtnSave");
            this.BtnReset.Text = config.ReadConfigValue("MAU", "BU_UI_BtnReset");
            this.LblNick.Text = config.ReadConfigValue("MAU", "BU_UI_LblNick");
            this.LblContent.Text = config.ReadConfigValue("MAU", "BU_UI_LblContent");
            this.BtnPost.Text = config.ReadConfigValue("MAU", "BU_UI_BtnPost");
            this.BtnClear.Text = config.ReadConfigValue("MAU", "BU_UI_BtnClear");
            this.TpgList.Text = config.ReadConfigValue("MAU", "BU_UI_TpgList");
            this.TpgClose.Text = config.ReadConfigValue("MAU", "BU_UI_TpgClose");
            this.TpgOpen.Text = config.ReadConfigValue("MAU", "BU_UI_TpgOpen");
            this.Tpgquary.Text = config.ReadConfigValue("MAU", "BU_UI_Tpgquary");

            this.label3.Text = config.ReadConfigValue("MAU", "BU_UI_username");
            this.button1.Text = config.ReadConfigValue("MAU", "BU_UI_Btn_Search");
            this.button2.Text = config.ReadConfigValue("MAU", "BU_UI_BtnClear");
            //this.label4.Text = config.ReadConfigValue("MAU", "BU_UI_LblServer");

        }


        #endregion

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
            Frm_AU_Close mModuleFrm = new Frm_AU_Close();
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

        private void Frm_SDO_Close_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 2;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_AU");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);

            //mServerInfo = Operation_Audition.GetServerList(this.m_ClientEvent, mContent);

            //CmbServer = Operation_Audition.BuildCombox(mServerInfo, CmbServer);

            //LblUser.Text = "";
            //PnlInput.Visible = true;
            //GrdList.DataSource = null;
            //PnlPage.Visible = false;
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            LblUser.Text = "";
            PnlInput.Visible = true;
            GrdList.DataSource = null;

            CmbPage.Items.Clear();
            TbcResult.SelectedTab = TpgList;

            bFirst = false;
            Btn_Search.Enabled = false;
            Cursor = Cursors.AppStarting;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.AU_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.Index;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = 1;

            mContent[2].eName = CEnum.TagName.PageSize;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = Operation_Audition.iPageSize;

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);

            //CEnum.Message_Body[,] mGetResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, mContent);

            ////无内容显示
            //if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mGetResult[0, 0].oContent.ToString());
            //    return;
            //}

            //Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

            //if (iPageCount <= 0)
            //{
            //    PnlPage.Visible = false;
            //}
            //else
            //{
            //    for (int i = 0; i < iPageCount; i++)
            //    {
            //        CmbPage.Items.Add(i+1);
            //    }

            //    CmbPage.SelectedIndex = 0;
            //    bFirst = true;
            //    PnlPage.Visible = true;
            //}
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrdList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //return;
            
            DataTable mTable = (DataTable)GrdList.DataSource;

            try
            {
                //iUserID = int.Parse(mTable.Rows[e.RowIndex][0].ToString());
                strUserNick = mTable.Rows[e.RowIndex][0].ToString();
                LblUser.Text = config.ReadConfigValue("MAU", "BU_Code_lbltxt") + strUserNick;
                TxtNick.Text = strUserNick;
                TbcResult.SelectedTab = TpgClose;

                CEnum.Message_Body[] mMemo = new CEnum.Message_Body[3];

                mMemo[0].eName = CEnum.TagName.AU_ServerIP;
                mMemo[0].eTag = CEnum.TagFormat.TLV_STRING;
                mMemo[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                mMemo[1].eName = CEnum.TagName.AU_ACCOUNT;
                mMemo[1].eTag = CEnum.TagFormat.TLV_STRING;
                mMemo[1].oContent = strUserNick;

                mMemo[2].eName = CEnum.TagName.UserByID;
                mMemo[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mMemo[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                lock (typeof(C_Event.CSocketEvent))
                {
                    CEnum.Message_Body[,] mGetResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNTLOCAL_QUERY, mMemo);


                    if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        TxtMemo.Text = mGetResult[0, 0].oContent.ToString();
                        label2.Text = config.ReadConfigValue("MAU", "BU_Code_unknow");
                    }
                    else
                    {
                        label2.Text = mGetResult[0, 4].oContent.ToString();
                        TxtMemo.Text = mGetResult[0, 3].oContent.ToString();
                    }
                }


                if (strUserNick != null)
                {
                    PnlInput.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msgchooseuser"));
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            strUserNick = TxtNick.Text.Trim();
            if (strUserNick != null)
            {
                if (MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg2"), config.ReadConfigValue("MAU", "BU_Code_msg1"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                    ArrayList paramList = new ArrayList();
                    CEnum.Message_Body[,] mResult = null;

                    CEnum.Message_Body[] mContent = null;
                    //mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    //mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    //mContent[1].eName = CEnum.TagName.AU_ACCOUNT;
                    //mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[1].oContent = strUserNick;

                    //mContent[2].eName = CEnum.TagName.UserByID;
                    //mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    //mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    //mContent[3].eName = CEnum.TagName.AU_Reason;
                    //mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[3].oContent = TxtContent.Text;

                    //paramList.Add(mContent);

                    //lock (typeof(C_Event.CSocketEvent))
                    //{
                    //    mResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNT_QUERY, mContent);
                    //} 

                    //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //{
                    //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //    return;
                    //}

                    //if (mResult[0, 0].eName == CEnum.TagName.Status)
                    //{
                    //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //    return;
                    //}
                    BtnSave.Enabled = false;
                    TbcResult.Enabled = false;
                    Cursor = Cursors.AppStarting; 

                    mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    //mContent[1].eName = CEnum.TagName.AU_UserNick;
                    //mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[1].oContent = mResult[0, 2].oContent.ToString();

                    mContent[1].eName = CEnum.TagName.UserByID;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[2].eName = CEnum.TagName.AU_Reason;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = TxtContent.Text;

                    mContent[3].eName = CEnum.TagName.AU_ACCOUNT;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = strUserNick;

                    paramList.Add(mContent);

                    //mResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNT_BANISHMENT_QUERY, mContent);

                    //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //{
                    //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //    return;
                    //}

                    //if (mResult[0, 0].eName == CEnum.TagName.AU_STOPSTATUS && mResult[0, 0].oContent.ToString() == "1")
                    //{

                    //    mResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNT_OPEN, mContent);

                    //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //    {
                    //        MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //        return;
                    //    }

                    //    if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                    //    {
                    //        MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg1"));
                    //    }
                    //    else
                    //    {
                    //        GrdList.DataSource = null;
                    //        MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_suces"));
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg3"));
                    //}

                    //PnlInput.Visible = false;

                    mContent = new CEnum.Message_Body[3];

                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Operation_Audition.iPageSize;

                    paramList.Add(mContent);
                    tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));

                    this.backgroundWorkerSave.RunWorkerAsync(paramList);

                    //CEnum.Message_Body[,] mGetResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, mContent);

                    ////无内容显示
                    //if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //{
                    //    MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                    //    return;
                    //}

                    //Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

                    //TxtAccount.Clear();
                    //TxtContent.Clear();
                    //TxtMemo.Clear();
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg3"));
            }
        }

        private void BtnPost_Click(object sender, EventArgs e)
        {
            if (TxtContent.Text == "" || TxtContent.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_banreason"));
                return;
            }
            if (TxtAccount.Text.Trim().Length > 0)
            {
                if (MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_baninfo").Replace("{ip}", this.CmbServer.Text.Trim()).Replace("{user}", TxtAccount.Text), config.ReadConfigValue("MAU", "BU_Code_baninfo1"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                   //"确定要将" + cbBoxserver.Text.Trim() + "玩家" + TxtAccount.Text + "的帐号封停么?"
                    CEnum.Message_Body[,] mResult = null;
                    ArrayList paramList = new ArrayList();
                    
                    CEnum.Message_Body[] mContent = null;
                    //mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    //mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    //mContent[1].eName = CEnum.TagName.AU_ACCOUNT;
                    //mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[1].oContent = TxtAccount.Text;

                    //mContent[2].eName = CEnum.TagName.UserByID;
                    //mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    //mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    //mContent[3].eName = CEnum.TagName.AU_Reason;
                    //mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[3].oContent = TxtContent.Text;

                    //paramList.Add(mContent);

                    //lock (typeof(C_Event.CSocketEvent))
                    //{
                    //    mResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNT_QUERY, mContent);
                    //} 

                    //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //{
                    //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //    return;
                    //}

                    //if (mResult[0, 0].eName == CEnum.TagName.Status)
                    //{
                    //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //    return;
                    //}
                    BtnPost.Enabled = false;
                    TbcResult.Enabled = false;
                    Cursor = Cursors.AppStarting;

                    mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    //mContent[1].eName = CEnum.TagName.AU_UserNick;
                    //mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[1].oContent = mResult[0,2].oContent.ToString();

                    mContent[1].eName = CEnum.TagName.UserByID;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[2].eName = CEnum.TagName.AU_Reason;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = TxtContent.Text;

                    mContent[3].eName = CEnum.TagName.AU_ACCOUNT;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = TxtAccount.Text;

                    paramList.Add(mContent);

                    ////有问题
                    //mResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNT_BANISHMENT_QUERY, mContent);

                    //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //{
                    //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //    return;
                    //}

                    //if (mResult[0, 0].eName == CEnum.TagName.AU_STOPSTATUS && mResult[0, 0].oContent.ToString() == "0")
                    //{
                    //    mResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNT_CLOSE, mContent);

                    //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //    {
                    //        //MessageBox.Show("操作失败！");
                    //        MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //        return;
                    //    }
                    //    if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                    //    {
                    //        MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg6"));
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg7"));
                    //    }

                    //    TxtAccount.Text = "";
                    //    TxtContent.Text = "";
                    //}
                    //else
                    //{
                    //    MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg8"));
                    //}

                    mContent = new CEnum.Message_Body[3];

                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Operation_Audition.iPageSize;

                    paramList.Add(mContent);
                    tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));
                    this.backgroundWorkerPost.RunWorkerAsync(paramList);

                    //CEnum.Message_Body[,] mGetResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, mContent);

                    ////无内容显示
                    //if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //{
                    //    MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                    //    return;
                    //}

                    //Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

                    //TxtAccount.Clear();
                    //TxtContent.Clear();
                    //TxtMemo.Clear();
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg9"));
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtAccount.Text = "";
            TxtContent.Text = "";
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //TxtMemo.Text = "";
            TxtNick.Clear();
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                CmbPage.Enabled = false;
                Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.AU_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.Index;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Audition.iPageSize + 1;

                mContent[2].eName = CEnum.TagName.PageSize;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = Operation_Audition.iPageSize;

                tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);

                //CEnum.Message_Body[,] mGetResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, mContent);

                //Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);
            }
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_Audition.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_Audition.BuildCombox(mServerInfo, CmbServer);
           // cbBoxserver = Operation_Audition.BuildCombox(mServerInfo, cbBoxserver);

            LblUser.Text = "";
            PnlInput.Visible = true;
            GrdList.DataSource = null;
            PnlPage.Visible = false;
            
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Btn_Search.Enabled = true;
            Cursor = Cursors.Default;

            CEnum.Message_Body[,] mGetResult = (CEnum.Message_Body[,])e.Result;
            //无内容显示
            if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

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

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbPage.Enabled = true;
            Cursor = Cursors.Default;
            Operation_Audition.BuildDataTable(this.m_ClientEvent, (CEnum.Message_Body[,])e.Result, GrdList, out iPageCount);
        }

        private void backgroundWorkerSave_DoWork(object sender, DoWorkEventArgs e)
        {
            CEnum.Message_Body[,] mResult = null;
            //lock (typeof(C_Event.CSocketEvent))
            //{
            //    mResult = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_QUERY, (CEnum.Message_Body[])(((ArrayList)e.Argument)[0]));
            //}
            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //if (mResult[0, 0].eName == CEnum.TagName.Status)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_BANISHMENT_QUERY, (CEnum.Message_Body[])(((ArrayList)e.Argument)[0]));
            }

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResult[0, 0].eName == CEnum.TagName.AU_STOPSTATUS && mResult[0, 0].oContent.ToString() == "1")
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_OPEN, (CEnum.Message_Body[])(((ArrayList)e.Argument)[0]));
                }

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    lock (typeof(C_Event.CSocketEvent))
                    {
                        e.Result = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, (CEnum.Message_Body[])(((ArrayList)e.Argument)[1]));
                    }
                    return;
                }

                if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg1"));
                }
                else
                {
                    GrdList.DataSource = null;
                    MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_suces"));
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg3"));
            }

            lock (typeof(C_Event.CSocketEvent))
            {
               e.Result = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, (CEnum.Message_Body[])(((ArrayList)e.Argument)[1]));
            }
            
        }

        private void backgroundWorkerSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSave.Enabled = true;
            TbcResult.Enabled = true;
            Cursor = Cursors.Default;
            PnlInput.Visible = false;
            CEnum.Message_Body[,] mGetResult = (CEnum.Message_Body[,])e.Result;

            //无内容显示
            if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

            TxtAccount.Clear();
            TxtContent.Clear();
            TxtMemo.Clear();
            TbcResult.SelectedTab = TpgList;
        }

        private void backgroundWorkerPost_DoWork(object sender, DoWorkEventArgs e)
        {
            CEnum.Message_Body[,] mResult = null;
            //lock (typeof(C_Event.CSocketEvent))
            //{
            //    mResult = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_QUERY, (CEnum.Message_Body[])(((ArrayList)e.Argument)[0]));
            //}
            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //if (mResult[0, 0].eName == CEnum.TagName.Status)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //有问题

            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_BANISHMENT_QUERY, (CEnum.Message_Body[])(((ArrayList)e.Argument)[0]));
            } 

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResult[0, 0].eName == CEnum.TagName.AU_STOPSTATUS && mResult[0, 0].oContent.ToString() == "0")
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNT_CLOSE, (CEnum.Message_Body[])(((ArrayList)e.Argument)[0]));
                } 

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    //MessageBox.Show("操作失败！");
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    lock (typeof(C_Event.CSocketEvent))
                    {
                        e.Result = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, (CEnum.Message_Body[])(((ArrayList)e.Argument)[1]));
                    } 
                    return;
                }
                if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg6"));
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg7"));
                }

                //TxtAccount.Text = "";
                //TxtContent.Text = "";
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg8"));
            }

            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_ACCOUNTREMOTE_QUERY, (CEnum.Message_Body[])(((ArrayList)e.Argument)[1]));
            } 
        }

        private void backgroundWorkerPost_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnPost.Enabled = true;
            TbcResult.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] mGetResult = (CEnum.Message_Body[,])e.Result;

            //无内容显示
            if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Audition.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

            TxtAccount.Clear();
            TxtContent.Clear();
            TxtMemo.Clear();
            TbcResult.SelectedTab = TpgList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            if (textBox1.Text!="" && textBox1.Text!=null)
            {
            //CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            //mContent[0].eName = CEnum.TagName.AU_ServerIP;
            //mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

            //mContent[1].eName = CEnum.TagName.AU_ACCOUNT;
            //mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            //mContent[1].oContent = textBox1.Text.Trim();

            //CEnum.Message_Body[,] mGetResult = null;
            //lock (typeof(C_Event.CSocketEvent))
            //{
            //    mGetResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNT_QUERY, mContent);
            //}
            //if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mGetResult[0, 0].oContent.ToString());
            //    return;
            //}
    

            CEnum.Message_Body[] msContent = new CEnum.Message_Body[2];
            msContent[0].eName = CEnum.TagName.AU_ServerIP;
            msContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            msContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

            msContent[1].eName = CEnum.TagName.AU_ACCOUNT;
            msContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            msContent[1].oContent = textBox1.Text.Trim();

            //msContent[2].eName = CEnum.TagName.AU_UserNick;
            //msContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //msContent[2].oContent = mGetResult[0, 2].oContent.ToString().Trim();

            CEnum.Message_Body[,] mResult = null;
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Audition.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.AU_ACCOUNT_BANISHMENT_QUERY, msContent);
            }
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResult[0, 0].oContent.ToString() == "1")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msgban").Replace("{user}", textBox1.Text.Trim()));
                    //"玩家"+textBox1.Text.Trim()+"帐号已经被封停");
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msgUnban").Replace("{user}", textBox1.Text.Trim()));
            }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg9"));
            }
        }

        private void TbcResult_Selected(object sender, TabControlEventArgs e)
        {

        }




    }
}