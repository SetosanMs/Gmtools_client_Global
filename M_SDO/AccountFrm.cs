using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Controls.LabelTextBox;
using C_Global;
using C_Event;


using Language;

namespace M_SDO
{
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("帐号信息查询", "Frm_SDO_Account", "SDO管理工具 -- 帐号信息查询", "SDO Group")]
    public partial class Frm_SDO_Account : System.Windows.Forms.Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] mItemResult = null;
        private int RolePage = 0;
        private int RoleIndex = 0;
        private int iIndexID = 0;
        private bool RoleFirst = false;
        private int iPageCount = 0;
        private bool bFirst = false;

        public Frm_SDO_Account()
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
            this.Text = config.ReadConfigValue("MSDO", "AF_UI_Caption");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "AF_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "AF_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnSearch");
            this.button1.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnReset");
            this.btnBlanketActive.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnBlanketActive");
            this.GrpResult.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpResult");
            this.labelRolePage.Text = config.ReadConfigValue("MSDO", "BA_UI_LblPage");
            this.labelNickName.Text = config.ReadConfigValue("MSDO", "AF_UI_Nickname");
            this.checkBox1.Text = config.ReadConfigValue("MSDO", "AF_UI_query");

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
            Frm_SDO_Account mModuleFrm = new Frm_SDO_Account();
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

        private void Frm_SDO_Account_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            btnBlanketActive.Enabled = false;


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


        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            /*
             * 清除上一次显示的内容
             */
            if (CmbServer.Text == "")
            {
                return;
            }

            if (this.checkBox1.Checked == false)
            {
                if (TxtAccount.Text.Trim().Length > 0)
                {
                    this.BtnSearch.Enabled = false;
                    this.btnBlanketActive.Enabled = false;
                    this.Cursor = Cursors.AppStarting;
                    this.TxtNickName.Text = "";
                    this.RoleInfoView.DataSource = null;
                    AccountDelegat mAccountDelegat = new AccountDelegat(DelegatInfo);
                    mAccountDelegat.BeginInvoke(null, null);
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_InputAccount"));
                }
            }
            else
            {

                if (this.TxtNickName.Text.Trim().Length > 0)
                {
                    this.BtnSearch.Enabled = false;
                    this.btnBlanketActive.Enabled = false;
                    this.Cursor = Cursors.AppStarting;
                    this.TxtAccount.Text = "";
                    this.RoleInfoView.DataSource = null;
                    AccountDelegat mAccountDelegat = new AccountDelegat(DelegatInfo);
                    mAccountDelegat.BeginInvoke(null, null);
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_InputNickName"));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 托管代码
        //预备托管
        private delegate void AccountDelegat();
        private void DelegatInfo()
        {
            try
            {
                BeginInvoke(new BuildAccount(AccountInfo));
            }
            catch
            {

            }
        }

        //构建信息
        private delegate void BuildAccount();
        private void AccountInfo()
        {
            //查询消息
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.SDO_Account;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;

            mContent[2].eName = CEnum.TagName.SDO_NickName;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = TxtNickName.Text;

            mContent[1].eName = CEnum.TagName.SDO_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);

            //mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ACCOUNT_QUERY, mContent);

            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //CmbServer.Enabled = false;
            //TxtAccount.Enabled = false;

            //if (mResult[0, 8].eName == C_Global.CEnum.TagName.SDO_ActiveStatus && mResult[0, 8].oContent.ToString() == "1")
            //{
            //    LblDetail.Text = config.ReadConfigValue("MSDO", "AF_Code_UserEnabledDes").Replace("{Account}", TxtAccount.Text).Replace("{Server}", CmbServer.Text);
            //}

            //if (mResult[0, 8].eName == C_Global.CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "ERROR")
            //{
            //    LblDetail.Text = config.ReadConfigValue("MSDO", "AF_Code_UserNotEnabledDes").Replace("{Account}", TxtAccount.Text).Replace("{Server}", CmbServer.Text);
            //}

            //PnlDetail.Visible = false;

            //for (int i = 0; i < mResult.GetLength(1); i++)
            //{
            //    LabelTextBox mDisplay = new LabelTextBox();
            //    mDisplay.Parent = PnlDetail;
            //    mDisplay.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
            //    mDisplay.Width = 222;

            //    if (i % 2 == 0)
            //    {
            //        mDisplay.Top = 20 * i + 30;
            //        mDisplay.Left = 44;
            //    }
            //    else
            //    {
            //        mDisplay.Top = 20 * (i - 1) + 30;
            //        mDisplay.Left = mDisplay.Width + 111;
            //    }

            //    mDisplay.LabelText = config.ReadConfigValue("GLOBAL", mResult[0, i].eName.ToString()) + ":";
            //    mDisplay.TextBoxText = mResult[0, i].oContent.ToString();

            //    if (mResult[0, i].eName == C_Global.CEnum.TagName.SDO_Ispad)
            //    {
            //        if (int.Parse(mResult[0, i].oContent.ToString()) == 0)
            //        {
            //            mDisplay.TextBoxText = config.ReadConfigValue("MSDO", "AF_Code_BlanketNotEnabled");
            //            btnBlanketActive.Text = config.ReadConfigValue("MSDO", "AF_Code_StartBlanket");
            //        }
            //        else
            //        {
            //            mDisplay.TextBoxText = config.ReadConfigValue("MSDO", "AF_Code_BlanketEnabled");
            //            btnBlanketActive.Text = config.ReadConfigValue("MSDO", "AF_Code_StopBlanket");
            //        }

            //        btnBlanketActive.Enabled = true;
            //    }

            //    if (mResult[0, i].eName == CEnum.TagName.SDO_SEX)
            //    {
            //        if (mResult[0, i].oContent.ToString().Equals("0"))
            //            mDisplay.TextBoxText = config.ReadConfigValue("MSDO", "AF_Code_Female");
            //        else
            //            mDisplay.TextBoxText = config.ReadConfigValue("MSDO", "AF_Code_Male");
            //    }

            //    if (mResult[0, i].eName == CEnum.TagName.SDO_ActiveStatus)
            //    {
            //        mDisplay.Visible = false;
            //    }
            //}

            //PnlDetail.Visible = true;

            //for (int i = 0; i < PnlDetail.Controls.Count; i++)
            //{
            //    if (PnlDetail.Controls[i].GetType() == typeof(LabelTextBox))
            //    {
            //        LabelTextBox mControls = (LabelTextBox)PnlDetail.Controls[i];
            //        mControls.ReadOnly = true;
            //    }
            //}
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_SurtToStartBlanket").Replace("{BtnStartOrStopBlanet}", btnBlanketActive.Text), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }

            this.btnBlanketActive.Enabled = false;
            this.Cursor = Cursors.AppStarting;

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];
            C_Global.CEnum.Message_Body[,] doResult = null;

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
            messageBody[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.SDO_Account;
            messageBody[1].oContent = TxtAccount.Text;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[2].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            if (mResult[0, 7].oContent.ToString() == config.ReadConfigValue("MSDO", "AF_Code_BlanketNotEnabled"))
            {
                ArrayList paramList = new ArrayList();
                paramList.Add(C_Global.CEnum.ServiceKey.SDO_MEMBERDANCE_OPEN);
                paramList.Add(C_Global.CEnum.Msg_Category.SDO_ADMIN);
                paramList.Add(messageBody);
                tmp_ClientEvent = m_ClientEvent.GetSocket(this.m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
                this.backgroundWorkerActive.RunWorkerAsync(paramList);
                
                //激活
                //doResult = m_ClientEvent.GetSocket(this.m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)).RequestResult(C_Global.CEnum.ServiceKey.SDO_MEMBERDANCE_OPEN, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);
            }
            else
            {
                ArrayList paramList = new ArrayList();
                paramList.Add(C_Global.CEnum.ServiceKey.SDO_MEMBERDANCE_CLOSE);
                paramList.Add(C_Global.CEnum.Msg_Category.SDO_ADMIN);
                paramList.Add(messageBody);
                tmp_ClientEvent = m_ClientEvent.GetSocket(this.m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
                this.backgroundWorkerActive.RunWorkerAsync(paramList);
                //停用
                //doResult = m_ClientEvent.GetSocket(this.m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)).RequestResult(C_Global.CEnum.ServiceKey.SDO_MEMBERDANCE_CLOSE, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);
            }




            //if (doResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(doResult[0, 0].oContent.ToString());
            //    return;
            //}

            //if (doResult[0, 0].oContent.ToString().Equals("FAILURE"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_Failed"));
            //    return;
            //}

            //if (doResult[0, 0].oContent.ToString().Equals("SUCESS"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_Succeed"));

            //    LblDetail.Text = "";
            //    foreach (Control m in PnlDetail.Controls.Find("LabelTextBox", true))
            //    {
            //        m.Dispose();
            //    }

            //    if (TxtAccount.Text.Trim().Length > 0)
            //    {
            //        AccountDelegat mAccountDelegat = new AccountDelegat(DelegatInfo);
            //        mAccountDelegat.BeginInvoke(null, null);
            //    }
            //    else
            //    {
            //        MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_InputAccount"));
            //    }

            //    return;
            //}


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CmbServer.Enabled = true;
            TxtAccount.Enabled = true;
            checkBox1.Enabled = true;
            TxtAccount.Clear();


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
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_ACCOUNT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                this.BtnSearch.Enabled = true;
                this.Cursor = Cursors.Default;
                return;
            }

            CmbServer.Enabled = false;
            TxtAccount.Enabled = false;
            this.checkBox1.Enabled = false;

            Operation_SDO.BuildDataTable(tmp_ClientEvent, mResult, this.RoleInfoView, out RolePage);
            //this.panelRolePage.Visible = true;
            this.panelRolePage.Enabled = true;
            this.BtnSearch.Enabled = true;
            this.Cursor = Cursors.Default;
            if (this.checkBox1.Checked == false)
            {
                for (int i = 0; i < mResult.GetLength(1); i++)
                {
                    if (mResult[0, i].eName == C_Global.CEnum.TagName.SDO_Ispad)
                    {
                        if (mResult[0, i].oContent.ToString() ==config.ReadConfigValue("MSDO",  "AF_Code_BlanketNotEnabled"))
                        {

                            btnBlanketActive.Text = config.ReadConfigValue("MSDO", "AF_Code_StartBlanket");
                        }
                        else
                        {

                            btnBlanketActive.Text = config.ReadConfigValue("MSDO", "AF_Code_StopBlanket");
                        }

                        btnBlanketActive.Enabled = true;
                    }
                }
            }
            else
            {
                btnBlanketActive.Enabled = false;
            }
            //if (this.comboBoxRolePage.Items.Count == 0)
            //{
            //    for (int i = 1; i <= RolePage; i++)
            //    {
            //        this.comboBoxRolePage.Items.Add(i);
            //    }
            //    this.comboBoxRolePage.SelectedIndex = 0;
            //    RoleFirst = true;
            //}
        }

        private void backgroundWorkerActive_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList paramList = (ArrayList)e.Argument;
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = tmp_ClientEvent.RequestResult((CEnum.ServiceKey)paramList[0], (CEnum.Msg_Category)paramList[1], (CEnum.Message_Body[])paramList[2]);
            }
        }

        private void backgroundWorkerActive_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] doResult = (CEnum.Message_Body[,])e.Result;
            this.btnBlanketActive.Enabled = true;
            this.Cursor = Cursors.Default;
            if (doResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(doResult[0, 0].oContent.ToString());
                return;
            }

            if (doResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_Failed"));
                return;
            }

            if (doResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_Succeed"));
                this.BtnSearch_Click(null, null);
            }
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void comboBoxRolePage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoleFirst)
            {
                RoleIndex = (int.Parse(this.comboBoxRolePage.Text) - 1) * 10 + 1;
                this.panelRolePage.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                this.AccountInfo();
            }
        }

        private void buttonNickName_Click(object sender, EventArgs e)
        {
            /*
             * 清除上一次显示的内容
             */
            if (CmbServer.Text == "")
            {
                return;
            }

            if (TxtNickName.Text.Trim().Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                this.TxtAccount.Text = "";
                this.RoleInfoView.DataSource = null;
                this.AccountInfo();
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_InputAccount"));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                TxtAccount.Text = "";
                TxtAccount.Enabled = false;
            }
            else
            {
                TxtAccount.Enabled = true;
            }
        }

    }
}