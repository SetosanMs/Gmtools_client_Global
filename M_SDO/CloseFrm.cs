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
namespace M_SDO
{
    /// <summary>
    /// Frm_SDO_Part 的摘要说明。
    /// </summary>
    [C_Global.CModuleAttribute("帐号解/封停", "Frm_SDO_Close", "SDO管理工具 -- 帐号解/封停", "SDO Group")]        
    public partial class Frm_SDO_Close : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iUserID = 0;
        private string strUserNick = null;

        private int iPageCount = 0;
        private bool bFirst = false;

        public Frm_SDO_Close()
        {
            InitializeComponent();
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
            Frm_SDO_Close mModuleFrm = new Frm_SDO_Close();
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
            this.Text = config.ReadConfigValue("MSDO", "BA_UI_SDO_Close");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "BA_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "BA_UI_LblServer");
            this.Btn_Search.Text = config.ReadConfigValue("MSDO", "BA_UI_Btn_Search");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "BA_UI_BtnClose");
            this.TpgList.Text = config.ReadConfigValue("MSDO", "BA_UI_TpgList");
            this.TpgClose.Text = config.ReadConfigValue("MSDO", "BA_UI_TpgClose");
            this.TpgOpen.Text = config.ReadConfigValue("MSDO", "BA_UI_TpgOpen");
            this.Tpgquery.Text = config.ReadConfigValue("MSDO", "BA_UI_TpgQuery");
            this.label3.Text = config.ReadConfigValue("MSDO", "BA_UI_label3");
            this.button1.Text = config.ReadConfigValue("MSDO", "BA_UI_GrpSearch");
            this.button2.Text = config.ReadConfigValue("MSDO", "BA_UI_Reset");
            this.LblPage.Text = config.ReadConfigValue("MSDO", "BA_UI_LblPage");
            this.LblNN.Text = config.ReadConfigValue("MSDO", "BA_UI_username");
            this.BtnSave.Text = config.ReadConfigValue("MSDO", "BA_UI_Release");
            this.BtnReset.Text = config.ReadConfigValue("MSDO", "BA_UI_Reset");
            this.LblMemo.Text = config.ReadConfigValue("MSDO", "BA_UI_reason");

            this.LblNick.Text = config.ReadConfigValue("MSDO", "BA_UI_LblNick");
            this.BtnPost.Text = config.ReadConfigValue("MSDO", "BA_UI_BtnPost");
            this.BtnClear.Text = config.ReadConfigValue("MSDO", "BA_UI_BtnClear");
            this.LblContent.Text = config.ReadConfigValue("MSDO", "BA_UI_LblContent");
            this.label1.Text = config.ReadConfigValue("MSDO", "BA_UI_label1");
            this.label2.Text = config.ReadConfigValue("MSDO", "BA_UI_label2");
        }
        #endregion

        private void Frm_SDO_Close_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);

            //mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);

            //CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            //LblUser.Text = "";
            //PnlInput.Visible = true;
            //GrdList.DataSource = null;
            //PnlPage.Visible = false;
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            PnlPage.Visible = false;
            LblUser.Text = "";
            PnlInput.Visible = true;
            GrdList.DataSource = null;
            Btn_Search.Enabled = false;
            bFirst = false;
            this.Cursor = Cursors.AppStarting;

            CmbPage.Items.Clear();
            TbcResult.SelectedTab = TpgList;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.Index;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = 1;

            mContent[2].eName = CEnum.TagName.PageSize;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = Operation_SDO.iPageSize;

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);

            //CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

            ////无内容显示
            //if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mGetResult[0, 0].oContent.ToString());
            //    return;
            //}

            //Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

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
            DataTable mTable = (DataTable)GrdList.DataSource;

            try
            {
                iUserID = int.Parse(mTable.Rows[e.RowIndex][0].ToString());
                strUserNick = mTable.Rows[e.RowIndex][1].ToString();
                LblUser.Text = config.ReadConfigValue("MSDO", "BA_Code_Msginfo").Replace("{Nickname}", strUserNick);
                TxtNick.Text = strUserNick;
                TbcResult.SelectedTab = TpgClose;

                CEnum.Message_Body[] mMemo = new CEnum.Message_Body[2];

                mMemo[0].eName = CEnum.TagName.SDO_ServerIP;
                mMemo[0].eTag = CEnum.TagFormat.TLV_STRING;
                mMemo[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mMemo[1].eName = CEnum.TagName.SDO_Account;
                mMemo[1].eTag = CEnum.TagFormat.TLV_STRING;
                mMemo[1].oContent = strUserNick;
                CEnum.Message_Body[,] mGetResult = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                   mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERLOCAL_BANISHMENT, mMemo);
                }

                if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    TxtMemo.Text = mGetResult[0, 0].oContent.ToString();
                }
                else
                {
                    TxtMemo.Text = mGetResult[0, 2].oContent.ToString();
                }


                if (strUserNick != null)
                {
                    PnlInput.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsginfoUser"));
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            strUserNick = TxtNick.Text.Trim();
            if (strUserNick != null && strUserNick != "")
            {
                if (MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgAccont"), config.ReadConfigValue("MSDO", "BA_Code_MsgUnlock"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.BtnSave.Enabled = false;
                    this.Cursor = Cursors.AppStarting;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];
                    mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.SDO_Account;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = strUserNick;

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    this.backgroundWorkerUnFreeze.RunWorkerAsync(mContent);

                    //CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ACCOUNT_OPEN, mContent);

                    //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //{
                    //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //    return;
                    //}

                    //if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                    //{
                    //    MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopFailure"));
                    //}
                    //else
                    //{
                    //    MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopSucces"));
                    //}

                    //PnlInput.Visible = false;

                    //mContent = new CEnum.Message_Body[3];

                    //mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    //mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    //mContent[1].eName = CEnum.TagName.Index;
                    //mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    //mContent[1].oContent = 1;

                    //mContent[2].eName = CEnum.TagName.PageSize;
                    //mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    //mContent[2].oContent = Operation_SDO.iPageSize;

                    //CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                    ////无内容显示
                    //if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //{
                    //    MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                    //    return;
                    //}

                    //Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

                    //TxtAccount.Clear();
                    //TxtContent.Clear();
                    //TxtMemo.Clear();
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopSucces"));
            }
        }

        private void BtnPost_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Trim().Length > 0)
            {
                if (MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgServer").Replace("{Server}", CmbServer.Text).Replace("{Account}", TxtAccount.Text), config.ReadConfigValue("MSDO", "BA_Code_MsgBan"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BtnPost.Enabled = false;
                    Cursor = Cursors.AppStarting;
                    
                    CEnum.Message_Body[,] mResult = null;
                    
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.SDO_Account;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = TxtAccount.Text;

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[3].eName = CEnum.TagName.SDO_REASON;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = TxtContent.Text;

                    this.backgroundWorkerFreeze.RunWorkerAsync(mContent);

                    //mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERSTOPSTATUS_QUERY, mContent);

                    //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //{
                    //    //MessageBox.Show("操作失败！");
                    //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //    return;
                    //}

                    //if (mResult[0, 0].eName == CEnum.TagName.SDO_StopStatus && mResult[0, 0].oContent.ToString() == "0")
                    //{
                    //    mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ACCOUNT_CLOSE, mContent);

                    //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //    {
                    //        //MessageBox.Show("操作失败！");
                    //        MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //        return;
                    //    }

                    //    if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                    //    //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //    {
                    //        MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopFailure"));
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopSucces"));

                    //        TxtAccount.Text = "";
                    //        TxtContent.Text = "";
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgUnoperation"));
                    //}

                    //mContent = new CEnum.Message_Body[3];

                    //mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                    //mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    //mContent[1].eName = CEnum.TagName.Index;
                    //mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    //mContent[1].oContent = 1;

                    //mContent[2].eName = CEnum.TagName.PageSize;
                    //mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    //mContent[2].oContent = Operation_SDO.iPageSize;

                    //CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                    ////无内容显示
                    //if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    //{
                    //    MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                    //    return;
                    //}

                    //Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

                    //TxtAccount.Clear();
                    //TxtContent.Clear();
                    //TxtMemo.Clear();
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsginputAccont"));
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
                this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.Index;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_SDO.iPageSize + 1;

                mContent[2].eName = CEnum.TagName.PageSize;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = Operation_SDO.iPageSize;

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);

                //CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                //Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);
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

            LblUser.Text = "";
            PnlInput.Visible = true;
            GrdList.DataSource = null;
            PnlPage.Visible = false;
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Btn_Search.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mGetResult = (CEnum.Message_Body[,])e.Result;
            //无内容显示
            if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                return;
            }

            Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

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
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.CmbPage.Enabled = true;
            Operation_SDO.BuildDataTable(this.m_ClientEvent, (CEnum.Message_Body[,])e.Result, GrdList, out iPageCount);
        }

        private void backgroundWorkerFreeze_DoWork(object sender, DoWorkEventArgs e)
        {
            CEnum.Message_Body[,] mResult;
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_MEMBERSTOPSTATUS_QUERY, (CEnum.Message_Body[])e.Argument);
            }
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                //MessageBox.Show("操作失败！");
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                e.Result = "Error";
                return;
            }
            if (mResult[0, 0].eName == CEnum.TagName.SDO_StopStatus && mResult[0, 0].oContent.ToString() == "0")
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_ACCOUNT_CLOSE, (CEnum.Message_Body[])e.Argument);
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgUnoperation"));
                e.Result = "Error";
            }
        }

        private void backgroundWorkerFreeze_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnPost.Enabled = true;
            this.Cursor = Cursors.Default;
            if (e.Result.ToString() != "Error")
            {
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    //MessageBox.Show("操作失败！");
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
                //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopFailure"));
                    return;
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopSucces"));

                    TxtAccount.Text = "";
                    TxtContent.Text = "";
                }
            }
            else
            {
                return;
            }
            this.Btn_Search_Click(null, null);
            TxtAccount.Clear();
            TxtContent.Clear();
            TxtMemo.Clear();
        }

        private void backgroundWorkerUnFreeze_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_ACCOUNT_OPEN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerUnFreeze_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnSave.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopFailure"));
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgopSucces"));
            }

            PnlInput.Visible = false;
            this.Btn_Search_Click(null, null);
            TxtAccount.Clear();
            TxtContent.Clear();
            TxtMemo.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() != "")
            {
                this.UseWaitCursor = true;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.SDO_Account;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = textBox1.Text;

                mContent[2].eName = CEnum.TagName.UserByID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[3].eName = CEnum.TagName.SDO_REASON;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = "";

                this.backgroundWorkerStatusQuery.RunWorkerAsync(mContent);
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg9"));
            }
        }

        private void backgroundWorkerStatusQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_MEMBERSTOPSTATUS_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerStatusQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            try
            {
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                }
                else if (mResult[0, 0].eName == CEnum.TagName.SDO_StopStatus && mResult[0, 0].oContent.ToString() == "1")
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msgban").Replace("{user}", textBox1.Text.Trim()));
                }
                else if (mResult[0, 0].eName == CEnum.TagName.SDO_StopStatus && mResult[0, 0].oContent.ToString() == "0")
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msgUnban").Replace("{user}", textBox1.Text.Trim()));
                }
            }
            catch
            {

            }
            finally
            {
                this.UseWaitCursor = false;
            }
               
        }
    }
}