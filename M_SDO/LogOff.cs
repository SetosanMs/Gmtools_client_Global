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
    [C_Global.CModuleAttribute("ǿ���������", "LogOff", "SDO������ -- ǿ���������", "SDO Group")]
    public partial class LogOff : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;

        private string _ServerIP;
        
        public LogOff()
        {
            InitializeComponent();
        }

        #region �Զ�������¼�
        /// <summary>
        /// ��������еĴ���
        /// </summary>
        /// <param name="oParent">MDI ����ĸ�����</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>����еĴ���</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //������¼����
            LogOff mModuleFrm = new LogOff();
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

        #region ���Կ�
        /// <summary>
        ///�����ֿ�
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// ��ʼ�����������Կ�
        /// </summary>
        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MSDO", "LO_UI_LogOff");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "GW_UI_GrpSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnClose");
            this.BtnLogOff.Text = config.ReadConfigValue("MSDO", "LO_UI_BtnLogOff");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "LO_UI_LblAccount");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "LO_UI_LblServer");
        }


        #endregion

        private void LogOff_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            //�������б�
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

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
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void BtnLogOff_Click(object sender, EventArgs e)
        {
            if (this.CmbServer.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "LO_Code_Msg1"));
                return;
            }
            if (this.TxtAccount.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "LO_Code_Msg2"));
                return;
            }
            CEnum.Message_Body[] mContent1 = new CEnum.Message_Body[3];

            mContent1[0].eName = CEnum.TagName.SDO_Account;
            mContent1[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent1[0].oContent = TxtAccount.Text.Trim();

            mContent1[1].eName = CEnum.TagName.SDO_ServerIP;
            mContent1[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent1[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);
            this._ServerIP = mContent1[1].oContent.ToString();

            mContent1[2].eName = CEnum.TagName.UserByID;
            mContent1[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent1[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            this.BtnLogOff.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            this.backgroundWorkerLogOff.RunWorkerAsync(mContent1);


        }

        private void backgroundWorkerLogOff_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_USERLOGIN_DEL, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerLogOff_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            this.BtnLogOff.Enabled = true;
            this.Cursor = Cursors.Default;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_Failed"));
                return;
            }

            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_Succeed"));
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}