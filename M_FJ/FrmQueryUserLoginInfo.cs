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

namespace M_FJ
{
    [C_Global.CModuleAttribute("玩家登录记录", "FrmQueryUserLoginInfo", "玩家登录记录", "Gmtools Group")]     
    public partial class FrmQueryUserLoginInfo : Form
    {
        public FrmQueryUserLoginInfo()
        {
            InitializeComponent();
        }

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        string userAccount = null;
        int currDgSelectRow = 0;    //玩家信息datagrid 中当前选中的行
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
            FrmQueryUserLoginInfo mModuleFrm = new FrmQueryUserLoginInfo();
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


        private void FrmQueryUserLoginInfo_Load(object sender, EventArgs e)
        {
            //IntiFontLib();
            PnlPage.Visible = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_FJ");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_FJ.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_FJ.BuildCombox(mServerInfo, CmbServer);

            PnlPage.Visible = false;
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                //CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                //mContent[0].eName = CEnum.TagName.FJ_UserID;
                //mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                //mContent[0].oContent = TxtAccount.Text;

                //mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                //mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                //mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                //mContent[2].eName = CEnum.TagName.Index;
                //mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                //mContent[2].oContent = 1;

                //mContent[3].eName = CEnum.TagName.PageSize;
                //mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                //mContent[3].oContent = Operation_FJ.iPageSize;

                //mContent[4].eName = CEnum.TagName.FJ_StartTime;
                //mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                //mContent[4].oContent = DtpBegin.Value;

                //mContent[5].eName = CEnum.TagName.FJ_EndTime;
                //mContent[5].eTag = CEnum.TagFormat.TLV_DATE;
                //mContent[5].oContent = DtpEnd.Value;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.FJ_UserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.FJ_UserNick;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = "";

                this.backgroundWorkerSearch.RunWorkerAsync(mContent);
            }
            else
            {
                MessageBox.Show("请输入玩家帐号");
            }
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_CharacterInfo_Query, (CEnum.Message_Body[])e.Argument);
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

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);

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

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                this.CmbPage.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.FJ_UserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.Index;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_FJ.iPageSize + 1;

                mContent[3].eName = CEnum.TagName.PageSize;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = Operation_FJ.iPageSize;

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);


            }
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Login_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.CmbPage.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mGetResult = (CEnum.Message_Body[,])e.Result;
            Operation_FJ.BuildDataTable(this.m_ClientEvent, mGetResult, GrdResult, out iPageCount);
        }

        private void TbcResult_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                CmbPage.Items.Clear();


                bFirst = false;


                if (RoleInfoView.DataSource != null)
                {
                    DataTable mTable = (DataTable)RoleInfoView.DataSource;
                    userAccount = mTable.Rows[currDgSelectRow]["角色昵称"].ToString();
                }
                else
                {
                    return;
                }
                if (userAccount != null)
                {


                    if (TbcResult.SelectedTab.Text.Equals("登陆记录"))
                    {
                        UserLoginQuery();
                    }

                }
                else
                {
                    MessageBox.Show("请选择一个玩家角色");
                }
            }
            catch
            {
                MessageBox.Show("请选择一个玩家角色");
                userAccount = null;
            }
        }

        private void UserLoginQuery()
        {
            GrdResult.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.FJ_UserNick;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = userAccount;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.Index;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = 1;

            mContent[3].eName = CEnum.TagName.PageSize;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_FJ.iPageSize;

            mContent[4].eName = CEnum.TagName.FJ_StartTime;
            mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[4].oContent = DtpBegin.Value;

            mContent[5].eName = CEnum.TagName.FJ_EndTime;
            mContent[5].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[5].oContent = DtpEnd.Value;

            this.backgroundWorkerUserQuery.RunWorkerAsync(mContent);
        }

        private void RoleInfoView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = int.Parse(e.RowIndex.ToString());
        }

        private void CmbPage_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (bFirst)
            {
                //this.CmbPage.Enabled = false;
                //this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.FJ_UserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = userAccount;

                mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.Index;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_FJ.iPageSize + 1;

                mContent[3].eName = CEnum.TagName.PageSize;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = Operation_FJ.iPageSize;

                mContent[4].eName = CEnum.TagName.FJ_StartTime;
                mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[4].oContent = DtpBegin.Value;

                mContent[5].eName = CEnum.TagName.FJ_EndTime;
                mContent[5].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[5].oContent = DtpEnd.Value;

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);
            }
        }

        private void backgroundWorkerUserQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Login_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerUserQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            PnlPage.Visible = false;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

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

        private void RoleInfoView_DataSourceChanged(object sender, EventArgs e)
        {
            if (RoleInfoView.DataSource != null)
            {
                DataTable dt = (DataTable)RoleInfoView.DataSource;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].ItemArray[2].ToString() == "是")
                    {
                        this.RoleInfoView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }

                }
            }
        }
    }
}