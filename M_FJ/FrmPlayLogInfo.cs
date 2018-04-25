using System;
using System.Collections;
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
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("玩家日志信息", "FrmPlayLogInfo", " 玩家日志信息", "FJ_Group")]
    public partial class FrmPlayLogInfo : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        private string _ServerIP;
        string userAccount = null; //玩家角色名称
        private CEnum.Message_Body[,] mType= null;
      

        private CEnum.Message_Body[,] ItemBClass = null;
        private CEnum.Message_Body[,] ItemAClass = null;


        public FrmPlayLogInfo()
        {
            InitializeComponent();
            FrmPlayLogInfo.CheckForIllegalCrossThreadCalls = false;
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
            FrmPlayLogInfo mModuleFrm = new FrmPlayLogInfo();
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


        private void Frm_FJ_Item_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            //button5.Enabled = false;
            //CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            //mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            //mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            //mContent[0].oContent = 1;

            //mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            //mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //mContent[1].oContent = m_ClientEvent.GetInfo("GameID_FJ");

            //this.backgroundWorkerServerLoad.RunWorkerAsync(mContent);
            //初始化折叠按钮
         
            //this.ClbItemName.ColumnWidth = 1000;

        }
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
            this.Text = config.ReadConfigValue("MFj", "FJ_UI_FjPlayerPlayLogInfo");
            this.LblServer.Text = config.ReadConfigValue("MFj", "FJ_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MFj", "FJ_UI_LblPlayAccount");
            this.LblTimeSpan.Text = config.ReadConfigValue("MFj", "FJ_UI_LblTimeSpan");
            this.LblTo.Text = config.ReadConfigValue("MFj", "FJ_UI_LblTo");
            this.LblItemName.Text = config.ReadConfigValue("MFj", "FJ_UI_LblItemName");
            this.lblApproach.Text = config.ReadConfigValue("MFj", "FJ_UI_lblApproach");
            this.btnSearchLog.Text = config.ReadConfigValue("MFj", "FJ_UI_btnSearchLog");
            
        }


        #endregion

        private void FrmPlayLogInfo_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_FJ");

            this.backgroundWorkerServerLoad.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerServerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_FJ.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerServerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer.Items.Clear();
            for (int i = 0; i < mServerInfo.GetLength(0); i++)
            {
                CmbServer.Items.Add(mServerInfo[i, 1].oContent);
            }

            CmbServer.SelectedIndex = 0;
            bFirst = true;

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            //清除控件

            TbcResult.SelectedTab = TpgCharacter;

            this.RoleInfoView.DataSource = null;

            if (TxtAncont.Text.Trim().Length > 0 || TxtNick.Text.Trim().Length > 0)
            {
                this.BtnSearch.Enabled = false;
                PartInfo();
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
                return;
            }
        }


        private void PartInfo()
        {
            this.RoleInfoView.DataSource = null;
            CEnum.Message_Body[,] mResult = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.FJ_UserID;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAncont.Text;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.FJ_UserNick;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = TxtNick.Text;

            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_CharacterInfo_Query, mContent);
            }


            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                this.BtnSearch.Enabled = true;
                return;
            }

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);
            this.BtnSearch.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbcResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TbcResult.SelectedIndex == 1)
            {
                this.TxtCharinfo.Text = userAccount;
                tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));

                CEnum.Message_Body[] mItemSubClass = new CEnum.Message_Body[1];
                mItemSubClass[0].eName = CEnum.TagName.FJ_ServerIP;
                mItemSubClass[0].eTag = CEnum.TagFormat.TLV_STRING;
                mItemSubClass[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);
                             
                this.backgroundWorkerType.RunWorkerAsync(mItemSubClass);


            }
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && RoleInfoView.DataSource != null)
            {
                DataTable dt = ((DataTable)RoleInfoView.DataSource);
                userAccount = dt.Rows[e.RowIndex][1].ToString();
                TbcResult.SelectedIndex = 1;
                TxtCharinfo.Text = userAccount;
            }
            else
            {
                return;
            }
        }

        private void btnSearchLog_Click(object sender, EventArgs e)
        {
            if (this.TxtItemName.Text == "" || this.TxtItemName.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgInputItemName"));
                return;
            }


            CEnum.Message_Body[,] mResult = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.FJ_UserNick;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtCharinfo.Text.Trim();

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.FJ_ItemName;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = this.TxtItemName.Text.ToString();

            mContent[3].eName = CEnum.TagName.FJ_Type;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_FJ.GetItemType(mType, this.CmbType.Text.ToString());
        
            mContent[4].eName = CEnum.TagName.FJ_StartTime;//时间段开始时间
            mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[4].oContent =Convert.ToDateTime(this.dateTimePickerTimeFrom.Value.ToLongDateString());

            mContent[5].eName = CEnum.TagName.FJ_EndTime;
            mContent[5].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[5].oContent =Convert.ToDateTime(this.dateTimePickerTimeTo.Value.ToLongDateString());

            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_ItemLog_Query, mContent);
            }
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                logInfoView.DataSource = null;
                Operation_FJ.BuildDataTableItemAdd(this.m_ClientEvent, mResult, logInfoView, out iPageCount);
            }
        }

        private void backgroundWorkerType_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mType = Operation_FJ.GetResult(this.m_ClientEvent, CEnum.ServiceKey.FJ_ItemLogType_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerType_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.CmbType = Operation_FJ.BuildCombox(mType, CmbType);
        }

        private void dateTimePickerTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerTimeFrom.Value > dateTimePickerTimeTo.Value)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgTime"));
                this.dateTimePickerTimeFrom.Value = DateTime.Now;
            }
        }

        private void dateTimePickerTimeTo_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerTimeFrom.Value > dateTimePickerTimeTo.Value)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgTime"));
                this.dateTimePickerTimeFrom.Value = DateTime.Now;
            }
        }
       

    }
}