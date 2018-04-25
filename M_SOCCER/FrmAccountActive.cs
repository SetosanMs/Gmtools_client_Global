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
    [C_Global.CModuleAttribute("帐号激活", "FrmAccountActive", "劲爆足球", "soccer")]
    public partial class FrmAccountActive : Form
    {

        public FrmAccountActive()
        {
            InitializeComponent();
        }
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;


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

                lock (typeof(C_Event.CSocketEvent))
                {
                    mServerInfo = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                }

                //检测状态


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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmAccountActive_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeServerIP();
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
            this.Text = config.ReadConfigValue("MSOCCER", "FAA_UI_FrmName");
            this.GrpResult.Text = config.ReadConfigValue("MSOCCER", "FAA_UI_GrpResult");
            this.GrpSearch.Text = config.ReadConfigValue("MSOCCER", "FAA_UI_GrpSearch");
            this.button1.Text = config.ReadConfigValue("MSOCCER", "FAA_UI_button1");
            this.BtnSearch.Text = config.ReadConfigValue("MSOCCER", "FAA_UI_BtnSearch");
            this.LblAccount.Text = config.ReadConfigValue("MSOCCER", "FAA_UI_LblAccount");
            this.LblServer.Text = config.ReadConfigValue("MSOCCER", "FAA_UI_LblServer");

        }


        #endregion
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            if (TxtAccount.Text.Trim().Length > 0)
            {
                //BtnSearch.Enabled = false;
                //Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

                mContent[0].eName = CEnum.TagName.Soccer_String;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.Soccer_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text);

                //this.backgroundWorkerSearch.RunWorkerAsync(mContent);
                CEnum.Message_Body[,] mResult = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_Soccer.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SOCCER_ACCOUNTACTIVE_QUERY, mContent);
                } 
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                if (mResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                {
                    //LblStatus.Text = "玩家" + TxtAccount.Text.Trim() + "在服务器" + CmbServer.Text.Trim()+ "已经激活";
                    LblStatus.Text = config.ReadConfigValue("MSOCCER", "FAA_Code_lbltxtsuccess").Replace("{user}", TxtAccount.Text.Trim()).Replace("{server}", CmbServer.Text.Trim());
                }
                else
                {
                    //LblStatus.Text = "玩家" + TxtAccount.Text.Trim() + "在服务器" + CmbServer.Text.Trim() + "暂时还未激活";
                    LblStatus.Text = config.ReadConfigValue("MSOCCER", "FAA_Code_lbltxtfailed").Replace("{user}", TxtAccount.Text.Trim()).Replace("{server}", CmbServer.Text.Trim());
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_InputAccount"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}