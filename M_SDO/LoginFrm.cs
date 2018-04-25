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
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("��ҵ�¼��¼", "Frm_SDO_Login", "SDO������ -- ��ҵ�¼��¼", "SDO Group")]      
    public partial class Frm_SDO_Login : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;

        public Frm_SDO_Login()
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
            Frm_SDO_Login mModuleFrm = new Frm_SDO_Login();
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
            this.Text = config.ReadConfigValue("MSDO", "LR_UI_SDOLogin");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "LR_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "LR_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "LR_UI_BtnSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "LR_UI_BtnClose");

            this.GrpResult.Text = config.ReadConfigValue("MSDO", "LR_UI_GrpResult");
            this.LblPage.Text = config.ReadConfigValue("MSDO", "LR_UI_LblPage");
   
        }
        #endregion


        private void LoginFrm_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 3;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);

            //mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);

            //CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            //PnlPage.Visible = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)

        {
            if (CmbServer.Text == "")
            {
                return;
            }
            PnlPage.Visible = false;
            GrdResult.DataSource = null;

            if (TxtAccount.Text.Trim().Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.Index;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = 1;

                mContent[3].eName = CEnum.TagName.PageSize;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = Operation_SDO.iPageSize;
                this.backgroundWorkerSearch.RunWorkerAsync(mContent);

                //CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_USERONLINE_QUERY, mContent);

                //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                //    return;
                //}

                //Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

                //if (iPageCount <= 0)
                //{
                //    PnlPage.Visible = false;
                //}
                //else
                //{
                //    for (int i = 0; i < iPageCount; i++)
                //    {
                //        CmbPage.Items.Add(i + 1);
                //    }

                //    CmbPage.SelectedIndex = 0;
                //    bFirst = true;
                //    PnlPage.Visible = true;
                //}
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "LR_Code_Msginfo"));
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                this.CmbPage.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.Index;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_SDO.iPageSize + 1;

                mContent[3].eName = CEnum.TagName.PageSize;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = Operation_SDO.iPageSize;

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);
                
                //CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                //Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdResult, out iPageCount);
            }
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
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_USERONLINE_QUERY, (CEnum.Message_Body[])e.Argument);
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

            Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

            if (iPageCount <= 0)
            {
                PnlPage.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }

                CmbPage.SelectedIndex = 0;
                bFirst = true;
                PnlPage.Visible = true;
            }
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_USERONLINE_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.CmbPage.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mGetResult = (CEnum.Message_Body[,])e.Result;
            Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdResult, out iPageCount);
        }
    }
}