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
    [C_Global.CModuleAttribute("在线时间查询", "FrmMinidanceTime", "在线时间查询", "SDO Group")]
    public partial class FrmMinidanceTime : Form
    {
        public FrmMinidanceTime()
        {
            InitializeComponent();
        }

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;

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
            FrmMinidanceTime mModuleFrm = new FrmMinidanceTime();
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
            this.Text = config.ReadConfigValue("MSDO", "FMI_UI_SDOLogintxt");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "LR_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "FM_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "FM_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnClose");

            //this.lblstartime.Text = config.ReadConfigValue("MSDO", "FM_UI_lblstartime");
            //this.lblendtime.Text = config.ReadConfigValue("MSDO", "FM_UI_lblendtime");
            //this.GrpResult.Text = config.ReadConfigValue("MSDO", "LR_UI_GrpResult");
            //this.LblPage.Text = config.ReadConfigValue("MSDO", "LR_UI_LblPage");

        }
        #endregion


        private void GetServerIp()
        {
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            this.backgroundWorkerLoad.RunWorkerAsync(mContent);


        }

        private void backgroundWorkerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txtTime.Text = "";

            //int noticeMin = Convert.ToInt32((DptEnd.Value - DptStart.Value).TotalMinutes);
            //if (noticeMin <= 0)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checktime"));
            //    return;
            //}

            if (TxtAccount.Text.Trim().Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);


                this.backgroundWorkerSearch.RunWorkerAsync(mContent);
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
            }
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_MiniDancerTime_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnSearch.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                txtTime.Text = "玩家" + mResult[0, 0].oContent.ToString().Trim() + "在线时间为" + transHour(int.Parse(mResult[0, 1].oContent.ToString()));
            }
        }

        private string transHour(int num)
        {
            string strtime = null;
            int inthour;
            int intmin;
            //int intsec;
            inthour = num / 60;
            intmin = num % 60;
            //intsec = num % 3600 % 60;

            strtime = inthour.ToString() + "小时" + intmin.ToString() + "分";
            return strtime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void FrmMinidanceTime_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            GetServerIp();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }









    }
}