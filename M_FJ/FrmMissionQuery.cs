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

namespace M_FJ
{
    [C_Global.CModuleAttribute("任务信息管理", "FrmMissionQuery", "任务信息管理", "Group")]    
    public partial class FrmMissionQuery : Form
    {
        public FrmMissionQuery()
        {
            InitializeComponent();
        }

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] mItemResult = null;
        
        private int iPageCount = 0;
        private int level = 0;

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
            this.Text = config.ReadConfigValue("MFj", "FM_UI_FrmMissionQuery");
            this.label1.Text = config.ReadConfigValue("MFj", "FM_UI_label1");
            this.button1.Text = config.ReadConfigValue("MFj", "FM_UI_button1");
            this.LblServer.Text = config.ReadConfigValue("MFj", "FM_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MFj", "FM_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MFj", "FM_UI_BtnSearch");
            this.TpgCharacter.Text = config.ReadConfigValue("MFj", "FM_UI_TpgCharacter");
            this.TpcMission.Text = config.ReadConfigValue("MFj", "FM_UI_TpcMission");
            this.label2.Text = config.ReadConfigValue("MFj", "FM_UI_label2");
        }


        #endregion

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
            FrmMissionQuery mModuleFrm = new FrmMissionQuery();
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

        private void FrmMissionQuery_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            TbcResult.TabPages.Remove(TpcMission);
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

            
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "" || this.backgroundWorkerPageChanged.IsBusy)
            {
                return;
            }
            //清除控件


            TbcResult.SelectedTab = TpgCharacter;
            if (TbcResult.TabPages.Contains(TpcMission))
            {
                TbcResult.TabPages.Remove(TpcMission);
            }

            this.RoleInfoView.DataSource = null;
            

            if (TxtAccount.Text.Trim().Length > 0 || TxtNick.Text.Trim().Length > 0)
            {
                this.BtnSearch.Enabled = false;
                //this.TbcResult.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                //RoleIndex = 1;


                PartInfo();
            }
            //else if (TxtAccount.Text.Trim().Length == 0 && TxtNick.Text.Trim().Length > 0)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
            //    return;
            //}
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
                return;
            }
        }

        private void PartInfo()
        {
            this.RoleInfoView.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.FJ_UserID;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.FJ_UserNick;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = TxtNick.Text;

            backgroundWorkerSearch.RunWorkerAsync(mContent);

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
        }

        private void RoleInfoView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != -1)
            //{
            //    TbcResult.SelectedIndex = 1;
            //    this.dgvMission.DataSource = null;
            //    this.Cursor = Cursors.WaitCursor;
            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];


            //    mContent[0].eName = CEnum.TagName.FJ_ServerIP;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            //    mContent[1].eName = CEnum.TagName.FJ_UserNick;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[1].oContent = ((DataTable)this.RoleInfoView.DataSource).Rows[e.RowIndex][1].ToString();

            //    this.backgroundWorkerMissionQuery.RunWorkerAsync(mContent);
            //}
        }

        private void backgroundWorkerMissionQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Task_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerMissionQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.RoleInfoView.Cursor = Cursors.Default;
            this.TbcResult.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            if (!TbcResult.TabPages.Contains(TpcMission))
            {
                TbcResult.TabPages.Add(TpcMission);
            }
            TbcResult.SelectedIndex = 1;
            
            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, dgvMission, out iPageCount);
            dgvMission.Columns[0].ReadOnly = true;
            dgvMission.Columns[1].ReadOnly = true;
            dgvMission.Columns[3].ReadOnly = true;
        }

        private void dgvMission_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //currDgSelectRow = e.RowIndex;
            //dgvMission.Rows[e.RowIndex].Selected = true;
        }

        private void dgvMission_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataTable dt = ((DataTable)dgvMission.DataSource);
            //    FrmNewMission fnw = new FrmNewMission(this.m_ClientEvent, 
            //        dt.Rows[e.RowIndex][0].ToString(), 
            //        Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text), 
            //        dt.Rows[e.RowIndex][1].ToString(), 
            //        dt.Rows[e.RowIndex][3].ToString(), 
            //        dt.Rows[e.RowIndex][2].ToString());

            //    fnw.ShowDialog();

            //    this.dgvMission.DataSource = null;
            //    this.Cursor = Cursors.WaitCursor;
            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];


            //    mContent[0].eName = CEnum.TagName.FJ_ServerIP;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            //    mContent[1].eName = CEnum.TagName.FJ_UserNick;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[1].oContent = ((DataTable)this.RoleInfoView.DataSource).Rows[e.RowIndex][1].ToString();

            //    this.backgroundWorkerMissionQuery.RunWorkerAsync(mContent);
            //}
        }

        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                this.level = int.Parse(((DataTable)this.RoleInfoView.DataSource).Rows[e.RowIndex][config.ReadConfigValue("GLOBAL", "FJ_Level")].ToString());
                this.TbcResult.Enabled = false;
                this.dgvMission.DataSource = null;
                Cursor = Cursors.WaitCursor;
                //TbcResult.TabPages.Remove(TpcMission);
                this.RoleInfoView.Cursor = Cursors.WaitCursor;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];


                mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.FJ_UserNick;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = ((DataTable)this.RoleInfoView.DataSource).Rows[e.RowIndex][1].ToString();

                this.backgroundWorkerMissionQuery.RunWorkerAsync(mContent);
            }
        }

        private void dgvMission_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataTable dt = ((DataTable)dgvMission.DataSource);
                FrmNewMission fnw = new FrmNewMission(this.tmp_ClientEvent,
                    dt.Rows[e.RowIndex][0].ToString(),
                    Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text),
                    dt.Rows[e.RowIndex][1].ToString(),
                    dt.Rows[e.RowIndex][3].ToString(),
                    dt.Rows[e.RowIndex][2].ToString(),
                    this.level);

                    fnw.ShowDialog();
                

                    
                    this.Cursor = Cursors.WaitCursor;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];


                    mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[1].eName = CEnum.TagName.FJ_UserNick;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = ((DataTable)this.dgvMission.DataSource).Rows[e.RowIndex][0].ToString();
                    this.dgvMission.DataSource = null;

                    this.backgroundWorkerMissionQuery.RunWorkerAsync(mContent);
                
            }
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }





    }
}