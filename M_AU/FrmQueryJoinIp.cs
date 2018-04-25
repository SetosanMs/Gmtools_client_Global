using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using M_Audition;
using C_Global;
using C_Event;
using Language;

namespace M_AU
{
    [C_Global.CModuleAttribute("JoinIp", "FrmQueryJoinIp", "Join_pc_ip信息", "AU Group")]
    public partial class FrmQueryJoinIp : Form
    {
        public FrmQueryJoinIp()
        {
            InitializeComponent();
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;
        private CEnum.Message_Body[,] mServerInfo = null;
        C_Global.CEnum.Message_Body[,] doResult = null;    //玩家信息列表
        private CSocketEvent tmp_ClientEvent = null;
        private bool bFirst = false;
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


        }


                #endregion
       
        private void FrmQueryJoinIp_Load(object sender, EventArgs e)
        {   
            IntiFontLib();
            PnlPage.Visible = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_AU");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_Audition.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_Audition.BuildCombox(mServerInfo, CmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "LO_Code_Msg1"));
                return;
            }

            BtnSearch.Enabled = false;
            Cursor = Cursors.WaitCursor;
            RoleInfoView.DataSource = null;

            C_Global.CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.AU_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            mContent[1].eName = C_Global.CEnum.TagName.AU_PcIP;
            mContent[1].oContent = TxtAccount.Text.Trim();

            mContent[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            mContent[2].eName = C_Global.CEnum.TagName.Index;
            mContent[2].oContent = 1;

            mContent[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            mContent[3].eName = C_Global.CEnum.TagName.PageSize;
            mContent[3].oContent = Operation_Audition.iPageSize;


            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text));

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_JOINPCIP_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                BtnSearch.Enabled = true;
                Cursor = Cursors.Default;
                int pg = 0;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    pg = 0;
                    //显示内容
                    Operation_Audition.BuildDataTable(m_ClientEvent, mResult, RoleInfoView, out pg);

                    if (pg <= 0)
                    {
                        PnlPage.Visible = false;
                    }
                    else
                    {
                        for (int i = 0; i < pg; i++)
                        {
                            CmbPage.Items.Add(i + 1);
                        }

                        CmbPage.SelectedIndex = 0;
                        bFirst = true;
                        PnlPage.Visible = true;
                    }
                }
            }
            catch
            {

            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Audition.GetResult(tmp_ClientEvent, CEnum.ServiceKey.AU_JOINPCIP_QUERY, (CEnum.Message_Body[])e.Argument);
            }

        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.CmbPage.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            int pg = 0;
            //显示内容
            Operation_Audition.BuildDataTable(m_ClientEvent, mResult, RoleInfoView, out pg);
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (bFirst)
            {
                this.CmbPage.Enabled = false;


                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.AU_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_Audition.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                mContent[1].eName = C_Global.CEnum.TagName.AU_PcIP;
                mContent[1].oContent = TxtAccount.Text.Trim();

                mContent[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mContent[2].eName = C_Global.CEnum.TagName.Index;
                mContent[2].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Audition.iPageSize + 1;

                mContent[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mContent[3].eName = C_Global.CEnum.TagName.PageSize;
                mContent[3].oContent = Operation_Audition.iPageSize;

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);
            }
        }
    }
}