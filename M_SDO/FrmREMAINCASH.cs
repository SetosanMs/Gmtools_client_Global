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
    [C_Global.CModuleAttribute("玩家余额查询", "FrmREMAINCASH", "玩家余额查询", "SDO Group")]
    public partial class FrmREMAINCASH : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        private string _ServerIP;
        
        public FrmREMAINCASH()
        {
            InitializeComponent();
        }

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
            FrmREMAINCASH mModuleFrm = new FrmREMAINCASH();
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
            this.Text = config.ReadConfigValue("MSDO", "FRC_UI_Text");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "SP_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "SP_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "SP_UI_LblAccount");
            this.LblDate.Text = config.ReadConfigValue("MSDO", "SP_UI_LblDate");
            this.LblLink.Text = config.ReadConfigValue("MSDO", "SP_UI_LblLink");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "SP_UI_BtnSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "SP_UI_BtnClose");
            this.GrpResult.Text = config.ReadConfigValue("MSDO", "FRC_UI_GrpResult");
        }


        #endregion

        private void FrmREMAINCASH_Load(object sender, EventArgs e)
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            GrdResult.DataSource = null;
            if (TxtAccount.Text.Trim().Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                GrdResult.DataSource = null;

                CEnum.Message_Body[] mContent1 = new CEnum.Message_Body[4];

                mContent1[0].eName = CEnum.TagName.SDO_Account;
                mContent1[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent1[0].oContent = TxtAccount.Text;

                mContent1[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent1[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent1[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);
                this._ServerIP = mContent1[1].oContent.ToString();

                mContent1[2].eName = CEnum.TagName.SDO_BeginTime;
                mContent1[2].eTag = CEnum.TagFormat.TLV_DATE;
                mContent1[2].oContent = DtpBegin.Value;

                mContent1[3].eName = CEnum.TagName.SDO_EndTime;
                mContent1[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent1[3].oContent = DtpEnd.Value;



                this.backgroundWorkerSearch.RunWorkerAsync(mContent1);
            }
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent,CEnum.ServiceKey.SDO_REMAINCASH_QUERY , (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnSearch.Enabled = true;
            this.Cursor = Cursors.Default;
            try
            {
                //this.Activate();
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {

                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    throw new Exception();
                }
                lock (typeof(Operation_SDO))
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(config.ReadConfigValue("MSDO", "FRC_UI_Chongzhi"));
                    dt.Columns.Add(config.ReadConfigValue("MSDO", "FRC_UI_YuE"));
                    
                    for (int i = 0; i < mResult.GetLength(0); i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = mResult[0, 1].oContent;
                        dr[1] = mResult[0, 0].oContent;
                        dt.Rows.Add(dr);
                    }
                    GrdResult.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}