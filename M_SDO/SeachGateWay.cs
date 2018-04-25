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
    [C_Global.CModuleAttribute("查询GateWay", "SearchGateWay", "查询GateWay", "SDO Group")]
    public partial class SeachGateWay : Form
    {
        public SeachGateWay()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        public CSocketEvent m_ClientEvent = null;
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent tmp_ClientEvent = null;

        private int pageIndex = 1;
        private int pageSize = 30;
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
            //this.Text = config.ReadConfigValue("MGM", "BL_UI_BugList");
            //this.groupBoxBugInfo.Text = config.ReadConfigValue("MGM", "BL_UI_groupBoxBugInfo");
            //this.buttonCancel.Text = config.ReadConfigValue("MGM", "BL_UI_buttonCancel");
            //this.buttonModify.Text = config.ReadConfigValue("MGM", "BL_UI_buttonModify");
            //this.buttonReset.Text = config.ReadConfigValue("MGM", "BL_UI_buttonReset");
            //this.buttonSubmit.Text = config.ReadConfigValue("MGM", "BL_UI_buttonSubmit");
            //this.labelContent.Text = config.ReadConfigValue("MGM", "BL_UI_labelContent");
            //this.labelModule.Text = config.ReadConfigValue("MGM", "BL_UI_labelModule");
            //this.labelType.Text = config.ReadConfigValue("MGM", "BL_UI_labelType");
            //this.labelSubject.Text = config.ReadConfigValue("MGM", "BL_UI_labelSubject");
            //this.groupBoxBugView.Text = config.ReadConfigValue("MGM", "BL_UI_groupBoxBugView");
            //this.ToolStripMenuItemEdit.Text = config.ReadConfigValue("MGM", "BL_UI_ToolStripMenuItemEdit");
            //this.LblPage.Text = config.ReadConfigValue("MGM", "BL_UI_LblPage");

        }


        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (this.TxtIP.Text.Trim() == "")
            {
                MessageBox.Show("请输入IP地址!");
                return;
            }
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.SDO_Address;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = this.TxtIP.Text.Trim();

            mContent[2].eName = CEnum.TagName.PageSize;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = this.pageSize;

            mContent[3].eName = CEnum.TagName.Index;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = this.pageIndex;

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void SeachGateWay_Load(object sender, EventArgs e)
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
                e.Result = Operation_SDO.GetResult(this.tmp_ClientEvent, CEnum.ServiceKey.SDO_GATEWAY_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
        }
    }
}