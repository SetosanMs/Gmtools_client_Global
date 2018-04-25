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

namespace M_o2jam_2
{
    [C_Global.CModuleAttribute("剔除卡号[超级乐者]", "KickCard", "剔除卡号", "o2jam2")]
    public partial class KickCard : Form
    {
        public KickCard()
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
            this.Text = config.ReadConfigValue("MBAF", "KC_UI_KickCard");
            this.btnApply.Text = config.ReadConfigValue("MBAF", "KC_UI_btnApply");
            this.lblAorN.Text = config.ReadConfigValue("MBAF", "KC_UI_lblAorN");
            this.label1.Text = config.ReadConfigValue("MBAF", "KC_UI_label1");
        }


        #endregion

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
        private CSocketEvent m_ClientEvent = null;
        private C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        private C_Global.CEnum.Message_Body[,] kickResult = null; //身上道具


        private string _ServerIP = null;    //服务器ip
        #endregion

        #region 函数
        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.cbxServerIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_O2jam2");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //检测状态
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }

                cbxServerIP.SelectedIndex = 0;
            }
            catch
            {
            }
        }






        /// <summary>
        /// 删除部位道具
        /// </summary>
        private void KickCardFromUser()
        {
            /*
             获取ip
             */
            if (_ServerIP == null || _ServerIP == "")
            {
                for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                {
                    if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                    {
                        this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                    }
                }
            }

            /*
             
             */
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[1].oContent = txtAorN.Text.Trim();

                messageBody[2].eName = CEnum.TagName.UserByID;
                messageBody[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                lock (typeof(C_Event.CSocketEvent))
                {

                    kickResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_USERLOGIN_DELETE, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }

                if (kickResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(kickResult[0, 0].oContent.ToString());
                    return;
                }

                if (kickResult[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MBAF", "KC_Code_Failed"));
                    return;
                }
                else if (kickResult[0, 0].oContent.Equals("SUCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MBAF", "KC_Code_Success"));
                    txtAorN.Clear();
                    _ServerIP = null;
                    return;
                }

            }
            catch
            {
            }

        }







        #endregion

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(config.ReadConfigValue("MBAF", "KC_Code_ConfirmRemove") + txtAorN.Text + config.ReadConfigValue("MBAF", "KC_Code_Card"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                KickCardFromUser(); 
            }
        }

        private void KickCard_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeServerIP();
        }
    }
}