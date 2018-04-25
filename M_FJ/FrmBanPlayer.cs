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

namespace M_FJ
{
    [C_Global.CModuleAttribute("帐号解/封停", "FrmBanPlayer", "帐号解/封停", "FJ Group")]        
    public partial class FrmBanPlayer : Form
    {   
        public FrmBanPlayer()
        {
            InitializeComponent();
        }
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iUserID = 0;
        private string strUserNick = null;
        private string strDBip = null;
        private string strUser = null;
        private int iPageCount = 0;
        private bool bFirst = false;


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
            FrmBanPlayer mModuleFrm = new FrmBanPlayer();
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



        private void FrmBanPlayer_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 2;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_FJ");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_FJ.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_FJ.BuildCombox(mServerInfo, CmbServer);

            LblUser.Text = "";
            //PnlInput.Visible = true;
            GrdList.DataSource = null;
            PnlPage.Visible = false;
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            PnlPage.Visible = false;
            LblUser.Text = "";
            //PnlInput.Visible = true;
            GrdList.DataSource = null;
            Btn_Search.Enabled = false;
            bFirst = false;
            this.Cursor = Cursors.AppStarting;

            CmbPage.Items.Clear();
            TbcResult.SelectedTab = TpgList;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.FJ_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.Index;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = 1;

            mContent[2].eName = CEnum.TagName.PageSize;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = Operation_FJ.iPageSize;

            mContent[3].eName = CEnum.TagName.FJ_UserID;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[3].oContent = "";


            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }



        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_UserBan_Query, (CEnum.Message_Body[])e.Argument);
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

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mGetResult, GrdList, out iPageCount);

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

        private void BtnPost_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Trim().Length > 0 && TxtContent.Text.Trim().Length > 0)
            {
                if (MessageBox.Show(config.ReadConfigValue("MSDO", "BA_Code_MsgServer").Replace("{Server}", CmbServer.Text).Replace("{Account}", TxtAccount.Text), config.ReadConfigValue("MSDO", "BA_Code_MsgBan"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BtnPost.Enabled = false;
                    //Cursor = Cursors.AppStarting;
                    strDBip = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);
                    strUser = TxtAccount.Text.Trim();


                    CEnum.Message_Body[,] mResult;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = strDBip;

                    mContent[1].eName = CEnum.TagName.Index;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = 1;

                    mContent[2].eName = CEnum.TagName.PageSize;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Operation_FJ.iPageSize;

                    mContent[3].eName = CEnum.TagName.FJ_UserID;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = strUser;

                    lock (typeof(C_Event.CSocketEvent))
                    {
                        mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_UserBan_Query, mContent);
                    }
                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        CEnum.Message_Body[,] mResult1 = null;

                        CEnum.Message_Body[] mContent1 = new CEnum.Message_Body[4];
                        mContent1[0].eName = CEnum.TagName.FJ_ServerIP;
                        mContent1[0].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent1[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                        mContent1[1].eName = CEnum.TagName.FJ_UserID;
                        mContent1[1].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent1[1].oContent = TxtAccount.Text.Trim();

                        mContent1[2].eName = CEnum.TagName.UserByID;
                        mContent1[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent1[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        mContent1[3].eName = CEnum.TagName.FJ_Reason;
                        mContent1[3].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent1[3].oContent = TxtContent.Text.Trim();

                        lock (typeof(C_Event.CSocketEvent))
                        {
                            mResult1 = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_UserBan_Close, mContent1);
                        }

                        if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            //MessageBox.Show("操作失败");
                            MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgFail"));
                            BtnPost.Enabled = true;
                            return;
                        }
                        if (mResult1[0, 0].oContent.ToString() == "SUCESS")
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgSucc"));
                            BtnPost.Enabled = true;
                            TxtAccount.Text = "";
                            TxtContent.Text = "";
                        }
                        else
                        {
                            //MessageBox.Show("操作失败或输入帐号错误");
                            MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgFailorIDFail"));
                            BtnPost.Enabled = true;
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgBanedUser"));
                        BtnPost.Enabled = true;
                        return;
                    }



     

                    //this.backgroundWorkerFreeze.RunWorkerAsync(mContent);

                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "BA_Code_MsginputAccont"));
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            strUserNick = TxtNick.Text.Trim();
            if (strUserNick != "" && txtUnReason.Text.Trim()!="")
            {
                if (MessageBox.Show(config.ReadConfigValue("MFj", "BA_Code_MsgUnlock"),config.ReadConfigValue("MFj", "BA_Code_MsgAccont"),MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.BtnSave.Enabled = false;
                    this.Cursor = Cursors.AppStarting;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                    mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.FJ_UserID;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = strUserNick;

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[3].eName = CEnum.TagName.FJ_Reason;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = txtUnReason.Text.Trim();

                    this.backgroundWorkerUnFreeze.RunWorkerAsync(mContent);
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "BA_Code_MsgReason"));
            }
        }

        private void backgroundWorkerUnFreeze_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_UserBan_Open, (CEnum.Message_Body[])e.Argument);
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

            //PnlInput.Visible = false;
           
            TxtAccount.Clear();
            TxtContent.Clear();
            TxtMemo.Clear();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtAccount.Text = "";
            TxtContent.Text = "";

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            TxtNick.Text = "";
            txtUnReason.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            //Cursor = Cursors.AppStarting;
            strDBip = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);
            strUser = textBox1.Text;


            CEnum.Message_Body[,] mResult;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
            mContent[0].eName = CEnum.TagName.FJ_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = strDBip;

            mContent[1].eName = CEnum.TagName.Index;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = 1;

            mContent[2].eName = CEnum.TagName.PageSize;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = Operation_FJ.iPageSize;

            mContent[3].eName = CEnum.TagName.FJ_UserID;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[3].oContent = strUser;

            this.backgroundWorkerStatusQuery.RunWorkerAsync(mContent);

        }

        private void backgroundWorkerStatusQuery_DoWork(object sender, DoWorkEventArgs e)
        {

            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_UserBan_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerStatusQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            try
            {   

                if (textBox1.Text.Trim().Length > 0)
                {
                    this.button1.Enabled = true;

                    CEnum.Message_Body[,] mGetResult = (CEnum.Message_Body[,])e.Result;
                    //无内容显示
                    if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                        return;
                    }
                    if (mGetResult[0, 0].eName == CEnum.TagName.FJ_UserID)
                    {
                        textBox1.Text = mGetResult[0, 0].oContent.ToString();
                        textBox2.Text = mGetResult[0, 1].oContent.ToString();
                        TxtMemo.Text = mGetResult[0, 2].oContent.ToString();
                    }
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgInputid"));
                }
            }
            catch
            { }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            TxtMemo.Text = "";
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}