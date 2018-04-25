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
namespace M_SDO
{
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("���״̬��Ϣ", "Frm_SDO_Status", "SDO������ -- ���״̬��Ϣ", "SDO Group")]
    public partial class Frm_SDO_Status : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        
        public Frm_SDO_Status()
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
            Frm_SDO_Status mModuleFrm = new Frm_SDO_Status();
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

        private void Frm_SDO_Status_Load(object sender, EventArgs e)
        {
            IntiFontLib();
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
            this.Text = config.ReadConfigValue("MSDO", "SS_UI_SdoStatus");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "SS_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "SS_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "SS_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "SS_UI_BtnSearch");
            this.button1.Text = config.ReadConfigValue("MSDO", "SS_UI_button1");
            this.GrpResult.Text = config.ReadConfigValue("MSDO", "SS_UI_GrpResult");
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
                BtnSearch.Enabled = false;
                Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                this.backgroundWorkerSearch.RunWorkerAsync(mContent);

                //CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_USERLOGIN_STATUS_QUERY, mContent);

                //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    LblStatus.Text = config.ReadConfigValue("MSDO", "SS_Code_UseroutLine");
                //}
                //else
                //{
                //    LblStatus.Text = config.ReadConfigValue("MSDO", "SS_Code_UseronLine").Replace("{Id}", mResult[0, 1].oContent.ToString()).Replace("{Room}", mResult[0, 2].oContent.ToString());
                //        //"��ǰ�û����ߣ�λ�ڵ� " + mResult[0, 1].oContent.ToString() + " ���������� " + mResult[0, 2].oContent.ToString() + " �����䡣";
                //}
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SS_Code_Msginfo"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_USERLOGIN_STATUS_QUERY, (CEnum.Message_Body[])e.Argument);
            }   
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                LblStatus.Text = config.ReadConfigValue("MSDO", "SS_Code_UseroutLine");
            }
            else
            {
                LblStatus.Text = config.ReadConfigValue("MSDO", "SS_Code_UseronLine").Replace("{Id}", mResult[0, 1].oContent.ToString()).Replace("{Room}", mResult[0, 2].oContent.ToString());
                //"��ǰ�û����ߣ�λ�ڵ� " + mResult[0, 1].oContent.ToString() + " ���������� " + mResult[0, 2].oContent.ToString() + " �����䡣";
            }
        }
    }
}