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

namespace M_AU
{
    [C_Global.CModuleAttribute("MSN查询", "FrmQueryMsnName", "劲舞团", "AU")]
    public partial class FrmQueryMsnName : Form
    {
        public FrmQueryMsnName()
        {
            InitializeComponent();
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

        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        C_Global.CEnum.Message_Body[,] accountResult = null;    //帐号检索结果
        ConfigValue config = null;
        string _ServerIP = null;    //服务器ip

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
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_AU");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 4;

                lock (typeof(C_Event.CSocketEvent))
                {
                    serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                }
                //检测状态

                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    //游戏列表为空错误信息
                    //MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表

                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.CmbServer.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }
                CmbServer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmQueryMsnName_Load(object sender, EventArgs e)
        {
           
            InitializeServerIP();
            IntiFontLib();
        }

        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MAU", "QM_UI_QueryMsn");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "LR_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MAU", "QM_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MAU", "QM_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MAU", "UA_UI_btnSearch");
            this.BtnClear.Text = config.ReadConfigValue("MAU", "UA_UI_btnClear");
            this.label1.Text = config.ReadConfigValue("MAU", "QM_UI_label1");
            this.label2.Text = config.ReadConfigValue("MAU", "QM_UI_label2");



        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.txtname.Text = "";
            this.txttitle.Text = "";

            #region IP检索

            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.CmbServer.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            if (TxtAccount.Text.Trim().Length > 0)
            {

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
                messageBody[1].oContent = TxtAccount.Text.Trim();

                CEnum.Message_Body[,] mResult = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_MESSENGER_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
                }
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                else
                {
                    this.txtname.Text = mResult[0, 0].oContent.ToString();
                    this.txttitle.Text = mResult[0, 1].oContent.ToString();
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg9"));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            #region IP检索

            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.CmbServer.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            if (TxtAccount.Text.Trim().Length > 0)
            {

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
                messageBody[1].oContent = TxtAccount.Text.Trim();

                CEnum.Message_Body[,] mResult = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_MESSENGER_UPDATE, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);
                }
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show("清空昵称失败");
                    return;
                }

                else
                {
                    MessageBox.Show("清空昵称成功");
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg9"));
            }

        }
    }
}