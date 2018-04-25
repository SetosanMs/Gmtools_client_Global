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
using M_Audition;

using Language;
namespace M_AU
{
    [C_Global.CModuleAttribute("玩家结婚券状况", "FrmSearchMarry", "玩家结婚券状况", "SDO Group")]
    public partial class FrmSearchMarry : Form
    {

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] mItemResult = null;
        //private int RolePage = 0;
        //private int RoleIndex = 0;
        //private int iIndexID = 0;
        //private bool RoleFirst = false;
        //private int iPageCount = 0;
        //private bool bFirst = false;

        DataTable dgTable = new DataTable();
        public FrmSearchMarry()
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
            this.Text = config.ReadConfigValue("MAU", "FSM_UI_Text");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "AF_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "AF_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnSearch");
            this.button1.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnReset");
            this.GrpResult.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpResult");

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
            FrmSearchMarry mModuleFrm = new FrmSearchMarry();
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
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            /*
             * 清除上一次显示的内容
             */
            if (CmbServer.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "LO_Code_Msg1"));
                return;
            }

            BtnSearch.Enabled = false;
            Cursor = Cursors.WaitCursor;
            RoleInfoView.DataSource = null;

            C_Global.CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.AU_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            mContent[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
            mContent[1].oContent = chkAccount.Checked ? lblAccountOrNick.Text.Trim() : "";

            mContent[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            mContent[2].eName = C_Global.CEnum.TagName.AU_UserNick;
            mContent[2].oContent = chkNick.Checked ? lblAccountOrNick.Text.Trim() : "";

            mContent[3].eName = CEnum.TagName.AU_City;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[3].oContent = CmbServer.Text.Trim();

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblAccountOrNick.Text = "";
            RoleInfoView.DataSource = null;
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_WEDDINGGROUND_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                int pg = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    RoleInfoView.DataSource = BrowsePartResultInfo(mResult);
                }
            }
            catch
            {

            }
        }
        private DataTable BrowsePartResultInfo(CEnum.Message_Body[,] StrmResult)
        {
            dgTable.Columns.Clear();       //清空头信息

            dgTable.Rows.Clear();          //清空行记录


            dgTable.Columns.Add(config.ReadConfigValue("MAU", "FSM_Code_txtnickame"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "FSM_Code_txtuserId"), typeof(string));
            dgTable.Columns.Add(config.ReadConfigValue("MAU", "FMS_Code_UseTime"), typeof(string));




            for (int i = 0; i < StrmResult.GetLength(0); i++)
            {
                DataRow dgRow = dgTable.NewRow();
                dgRow[config.ReadConfigValue("MAU", "FSM_Code_txtnickame")] = StrmResult[i, 0].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "FSM_Code_txtuserId")] = StrmResult[i, 1].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "FMS_Code_UseTime")] = StrmResult[i, 2].oContent.ToString();

                dgTable.Rows.Add(dgRow);
            }
            return dgTable;
        }
        private void chkAccount_Click(object sender, EventArgs e)
        {
            chkNick.Checked = false;
            LblAccount.Text = config.ReadConfigValue("MAU", "UA_Code_txtusername");
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            chkAccount.Checked = false;
            LblAccount.Text = config.ReadConfigValue("MAU", "UA_Code_txtnickname");
        }


        private void CmbServer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void FrmSearchMarry_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_AU");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
        }
























    }
}