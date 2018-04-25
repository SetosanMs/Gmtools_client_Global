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
    [C_Global.CModuleAttribute("Au帐号激活", "FrmActivePlayer", "劲舞团", "AU")]
    public partial class FrmActivePlayer : Form
    {
        public FrmActivePlayer()
        {
            InitializeComponent();
        }

        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        C_Global.CEnum.Message_Body[,] accountResult = null;    //帐号检索结果
        ConfigValue config = null;
        string _ServerIP = null;    //服务器ip



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
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_AU");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 2;

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


        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MAU", "QM_UI_QueryActive");
            LblServer.Text = config.ReadConfigValue("MAU", "QM_UI_LblServer");
            LblAccount.Text = config.ReadConfigValue("MAU", "QM_UI_LblAccount");

            BtnSearch.Text = config.ReadConfigValue("MAU", "QM_Code_QueryActivePlayer");
        }

        private void FrmActivePlayer_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeServerIP();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
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
                BtnSearch.Enabled = false;
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
                messageBody[1].oContent = TxtAccount.Text.Trim();

                messageBody[2].eName = CEnum.TagName.UserByID;
                messageBody[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                backgroundWorker1.RunWorkerAsync(messageBody);

               




                //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                //    return;
                //}
                //if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "SUCESS")
                //{
                //    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopsucc")); 
                //}
                //else
                //{
                //    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopfail")); 
                //}

            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BU_Code_msg9"));
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(CEnum.ServiceKey.AU_MEMBERACTIVE_CREATE, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "SUCESS")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopsucc"));
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopfail"));
            }
        }
    }
}