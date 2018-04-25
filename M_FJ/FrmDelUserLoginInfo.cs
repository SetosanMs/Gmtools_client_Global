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

namespace M_FJ
{
    [C_Global.CModuleAttribute("ǿ���������", "FrmDelUserLoginInfo", "ǿ���������", "FJ Group")]
    public partial class FrmDelUserLoginInfo : Form
    {
        private CEnum.Message_Body[,] serverIPResult = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        //private CEnum.Message_Body[,] updateResult = null;    //�ʺ���Ϣ
        private string _ServerIP;

        public FrmDelUserLoginInfo()
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
            FrmDelUserLoginInfo mModuleFrm = new FrmDelUserLoginInfo();
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
            //this.Text = config.ReadConfigValue("MSDO", "LO_UI_FrmLoginoff");
            //this.GrpSearch.Text = config.ReadConfigValue("MSDO", "GW_UI_GrpSearch");
            //this.BtnClose.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnClose");
            //this.BtnFrmLoginoff.Text = config.ReadConfigValue("MSDO", "LO_UI_BtnFrmLoginoff");
            //this.LblAccount.Text = config.ReadConfigValue("MSDO", "LO_UI_LblAccount");
            //this.LblServer.Text = config.ReadConfigValue("MSDO", "LO_UI_LblServer");
        }


        #endregion

        private void FrmDelUserLoginInfo_Load(object sender, EventArgs e)
        {
            InitializeServerIP();
        }

        /// <summary>
        /// ��ʼ����Ϸ�������б�
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.cbxServerIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_FJ");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 2;

                lock (typeof(C_Event.CSocketEvent))
                {
                    serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                }

                //���״̬

                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //��ʾ���ݵ��б�

                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }
            }
            catch
            {
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLogOff_Click(object sender, EventArgs e)
        {
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show("��ѡ�������");
                return;
            }

            if (TxtAccount.Text == null || TxtAccount.Text == "")
            {
                MessageBox.Show("����������ʺ�");
                return;
            }

            #region IP����

            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            CEnum.Message_Body[] mContent1 = new CEnum.Message_Body[3];

            mContent1[0].eName = CEnum.TagName.FJ_UserID;
            mContent1[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent1[0].oContent = TxtAccount.Text.Trim();

            mContent1[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent1[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent1[1].oContent = this._ServerIP;

            mContent1[2].eName = CEnum.TagName.UserByID;
            mContent1[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent1[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            this.BtnLogOff.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            this.backgroundWorker1.RunWorkerAsync(mContent1);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Login_Out_Update, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                MessageBox.Show("����ʧ��");
                return;
            }

            else
            {
                MessageBox.Show("�����ɹ�");
            }
        }

        private void cbxServerIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(serverIPResult, cbxServerIP.Text));
        }
    }
}