using System;
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

namespace M_FJ
{
    [C_Global.CModuleAttribute("玩家临时密码", "FrmTempPassword", "玩家临时密码", "Group")]    
    public partial class FrmTempPassword : Form
    {
        public FrmTempPassword()
        {
            InitializeComponent();
        }

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
        private bool bFirst1 = false;
        private bool bFirst2 = false;
        int currDgSelectRow = 0;    //玩家信息datagrid 中当前选中的行
        string userAccount = null; //玩家角色名称
        string guildName = null;//角色所在帮会
        int Occupation_id = 0;
        string ServerIP = null;

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
            FrmTempPassword mModuleFrm = new FrmTempPassword();
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
            this.Text = config.ReadConfigValue("MFj", "FTP_UI_FrmTempPassword");
            this.GrpSearch.Text = config.ReadConfigValue("MFj", "FQA_UI_GrpSearch");
            this.label1.Text = config.ReadConfigValue("MFj", "FTP_UI_label1");
            this.button1.Text = config.ReadConfigValue("MFj", "FTP_UI_button1");
            this.LblServer.Text = config.ReadConfigValue("MFj", "FQA_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MFj", "FQA_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MFj", "FQA_UI_BtnSearch");
            
        }


        #endregion

        private void FrmTempPassword_Load(object sender, EventArgs e)
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

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
            ServerIP = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);   
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            //清除控件

            this.TxtTmpPwd.Text = "";

            if (TxtAccount.Text.Trim().Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.Cursor = Cursors.AppStarting;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text); 

                mContent[1].eName = CEnum.TagName.FJ_UseAccount;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtAccount.Text.Trim();

                this.backgroundWorkerSearch.RunWorkerAsync(mContent);
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
                return;
            }
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_TempPassword_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            BtnSearch.Enabled = true;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
            }
            else
            {
                this.TxtTmpPwd.Text = mResult[0, 2].oContent.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            button1.Enabled = false;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
            mContent[0].eName = CEnum.TagName.FJ_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.FJ_UseAccount;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = TxtAccount.Text.Trim();


            mContent[2].eName = CEnum.TagName.FJ_Pwd;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = this.TxtTmpPwd.Text.Trim();

            mContent[3].eName = CEnum.TagName.UserByID;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            this.backgroundWorkerModify.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerModify_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_PlayerPwd_Update, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerModify_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            button1.Enabled = true;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
            }

            if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "SUCESS")
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_UI_Msgmodsuc"));
                
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_UI_Msgmodfai"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            button2.Enabled = false;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];
            mContent[0].eName = CEnum.TagName.FJ_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.FJ_UserID;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = TxtAccount.Text.Trim();

            mContent[2].eName = CEnum.TagName.UserByID;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            this.backgroundWorkerRec.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerRec_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_PWD_Recover, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerRec_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            button2.Enabled = true;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
            }
            if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "SUCESS")
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_UI_MsgRecsuc"));
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_UI_MsgRecfai"));
            }
        }
    }
}