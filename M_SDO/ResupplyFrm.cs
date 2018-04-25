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
    [C_Global.CModuleAttribute("���Ǳ�", "Frm_SDO_Resupply", "SDO������ -- ���Ǳ�", "SDO Group")]
    public partial class Frm_SDO_Resupply : Form
    {
        private long iTotal = 0;
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        
        public Frm_SDO_Resupply()
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
            Frm_SDO_Resupply mModuleFrm = new Frm_SDO_Resupply();
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
            this.Text = config.ReadConfigValue("MSDO", "SG_UI_SdoResupply");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "SG_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "SG_UI_LblServer");
            this.label1.Text = config.ReadConfigValue("MSDO", "SG_UI_label1");

            this.LblMoney.Text = config.ReadConfigValue("MSDO", "SG_UI_LblMoney");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "SG_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "SG_UI_BtnSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "SG_UI_BtnClose");
            this.button1.Text = config.ReadConfigValue("MSDO", "SG_UI_button1");
        
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

                //CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_USERGCASH_QUERY, mContent);

                //try
                //{
                //    LblMoney.Text = config.ReadConfigValue("MSDO", "SG_Code_lbltxtg") + mResult[0, 0].oContent.ToString();
                //    iTotal = Convert.ToInt64(mResult[0, 0].oContent.ToString());
                //}
                //catch(Exception ex)
                //{
                //    MessageBox.Show("�����쳣������ѯ������Ա��");
                //    return;
                //}

                //TxtAccount.Enabled = false;
                //BtnSearch.Enabled = false;
                //BtnClose.Enabled = true;
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SG_Code_MsgAccont"));
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(TxtMoeny.Text.Trim());
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SG_Code_MsgSupplyg"));
                return;
            }

            this.BtnClose.Enabled = false;
            this.Cursor = Cursors.AppStarting;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.SDO_Account;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;

            mContent[1].eName = CEnum.TagName.SDO_GCash;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = int.Parse(TxtMoeny.Text.Trim());

            mContent[2].eName = CEnum.TagName.SDO_ServerIP;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[3].eName = CEnum.TagName.UserByID;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            this.backgroundWorkerAdd.RunWorkerAsync(mContent);

            //CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_USERGCASH_UPDATE, mContent);

            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //if (mResult[0, 0].oContent.Equals("FAILURE"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "SG_Code_MsgUpfail"));
            //}
            //else
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "SG_Code_MsgUpsucces"));
            //}

            ////LblMoney.Text = "��ǰG�ҽ�" + Convert.ToString(int.Parse(TxtMoeny.Text.Trim()) + iTotal);

            //LblMoney.Text = config.ReadConfigValue("MSDO", "SG_Code_lbltxtg");
            //BtnSearch.Enabled = true;
            //BtnClose.Enabled = false;
            //TxtAccount.Enabled = true;
            //TxtAccount.Clear();
            //TxtMoeny.Clear();
        }

        private void Frm_SDO_Resupply_Load(object sender, EventArgs e)
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

            //BtnClose.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnClose.Enabled = false;
            TxtAccount.Clear();
            TxtAccount.Enabled = true;
            BtnSearch.Enabled = true;
            TxtMoeny.Clear();
            LblMoney.Text = config.ReadConfigValue("MSDO", "SG_Code_lbltxtg");
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

            BtnClose.Enabled = false;

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
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_USERGCASH_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnSearch.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            try
            {
                LblMoney.Text = config.ReadConfigValue("MSDO", "SG_Code_lbltxtg") + mResult[0, 0].oContent.ToString();
                iTotal = Convert.ToInt64(mResult[0, 0].oContent.ToString());
            }
            catch
            {
                MessageBox.Show("�����쳣������ѯ������Ա��");
                return;
            }

            TxtAccount.Enabled = false;
            BtnSearch.Enabled = false;
            BtnClose.Enabled = true;
        }

        private void backgroundWorkerAdd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_USERGCASH_UPDATE, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnClose.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SG_Code_MsgUpfail"));
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "SG_Code_MsgUpsucces"));
            }

            //LblMoney.Text = "��ǰG�ҽ�" + Convert.ToString(int.Parse(TxtMoeny.Text.Trim()) + iTotal);

            LblMoney.Text = config.ReadConfigValue("MSDO", "SG_Code_lbltxtg");
            BtnSearch.Enabled = true;
            BtnClose.Enabled = false;
            TxtAccount.Enabled = true;
            TxtAccount.Clear();
            TxtMoeny.Clear();
        }
    }
}