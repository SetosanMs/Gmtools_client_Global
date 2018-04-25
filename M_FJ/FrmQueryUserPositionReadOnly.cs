using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using C_Controls.LabelTextBox;
using C_Global;
using C_Event;
using Language;

namespace M_FJ
{
    [C_Global.CModuleAttribute("只读玩家地图信息", "FrmQueryUserPositionReadOnly", "只读玩家地图信息", "9youGroup")]    
    public partial class FrmQueryUserPosition : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] AreaResult = null;
        //private CEnum.Message_Body[,] mItemResult = null;
        private int iPageCount = 0;
        private string strCharinfo = null;
        private string strXpostion = null;
        private string strYpostion = null;
        private string strUserId = null;
        private bool bFirst = false;
        public FrmQueryUserPosition()
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
            FrmQueryUserPosition mModuleFrm = new FrmQueryUserPosition();
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
            //this.Text = config.ReadConfigValue("MSDO", "CI_UI_Frm_SDO_Part");
            //this.GrpSearch.Text = config.ReadConfigValue("MSDO", "CI_UI_GrpSearch");
            //this.LblServer.Text = config.ReadConfigValue("MSDO", "CI_UI_LblServer");
            //this.LblAccount.Text = config.ReadConfigValue("MSDO", "CI_UI_LblAccount");
            //this.label1.Text = config.ReadConfigValue("MSDO", "CI_UI_label1");
            //this.TpgCharacter.Text = config.ReadConfigValue("MSDO", "CI_UI_TpgCharacter");
            //this.TpgItem.Text = config.ReadConfigValue("MSDO", "CI_UI_TpgItem");
            //this.BtnSearch.Text = config.ReadConfigValue("MSDO", "CI_UI_BtnSearch");
            //this.button1.Text = config.ReadConfigValue("MSDO", "CI_UI_button1");
            //this.LblPage.Text = config.ReadConfigValue("MSDO", "CI_UI_LblPage");
            //this.labelRolePage.Text = config.ReadConfigValue("MSDO", "CI_UI_LblPage");
            //this.textBoxNotice.Text = config.ReadConfigValue("MSDO", "CI_UI_Notice");
        }


        #endregion

        private void FrmQueryUserPosition_Load(object sender, EventArgs e)
        {
            IntiFontLib();
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

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }

            GrdItemResult.DataSource = null;
            if (TxtAccount.Text.Trim().Length > 0 || TxtNick.Text.Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.Cursor = Cursors.AppStarting;
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
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_PlayPosition_Query, (CEnum.Message_Body[])e.Argument);
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

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, GrdItemResult, out iPageCount);
        }

        private void GrdItemResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                strUserId = ((DataTable)this.GrdItemResult.DataSource).Rows[e.RowIndex][0].ToString();
                strCharinfo = ((DataTable)this.GrdItemResult.DataSource).Rows[e.RowIndex][1].ToString();
                strXpostion = ((DataTable)this.GrdItemResult.DataSource).Rows[e.RowIndex][3].ToString();
                strYpostion = ((DataTable)this.GrdItemResult.DataSource).Rows[e.RowIndex][4].ToString();
                TbcResult.SelectedIndex = 1;

                //txtUserID.Text = strUserId;
                //txtCharname.Text = strCharinfo;
                //txtX.Text = strXpostion;
                //txtY.Text = strYpostion;
                

            }
            else
            {
                strCharinfo = null;
                strXpostion = null;
                strYpostion = null;

                return;
            }
        }

        private void txtY_MouseLeave(object sender, EventArgs e)
        {

        }

        private void txtY_KeyUp(object sender, KeyEventArgs e)
        {
            //string txt = txtY.Text.Trim();
            //Regex rx = new Regex(@"[^\d]");
            //txtY.Text = rx.Replace(txt, "");



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtX_KeyUp(object sender, KeyEventArgs e)
        {
            //string txt = txtX.Text.Trim();
            //Regex rx = new Regex(@"[^\d]");
            //txtX.Text = rx.Replace(txt, "");
        }

        //private void btnMod_Click(object sender, EventArgs e)
        //{
        //    if (txtMap.Text.Trim().Length <= 0)
        //    {

        //        MessageBox.Show("请先查询要传送的地图");

        //    }
        //    else
        //    {
        //        CEnum.Message_Body[] mContent1 = new CEnum.Message_Body[7];

        //        mContent1[0].eName = CEnum.TagName.FJ_XPosition;
        //        mContent1[0].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent1[0].oContent = txtX.Text;

        //        mContent1[1].eName = CEnum.TagName.FJ_YPosition;
        //        mContent1[1].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent1[1].oContent = txtY.Text;



        //        mContent1[2].eName = CEnum.TagName.FJ_ServerIP;
        //        mContent1[2].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent1[2].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

        //        mContent1[3].eName = CEnum.TagName.UserByID;
        //        mContent1[3].eTag = CEnum.TagFormat.TLV_INTEGER;
        //        mContent1[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

        //        mContent1[4].eName = CEnum.TagName.FJ_UserNick;
        //        mContent1[4].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent1[4].oContent = txtCharname.Text;

        //        mContent1[5].eName = CEnum.TagName.FJ_UserID;
        //        mContent1[5].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent1[5].oContent = txtUserID.Text;

        //        mContent1[6].eName = CEnum.TagName.FJ_ZPosition;
        //        mContent1[6].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent1[6].oContent = txtZ.Text;

        //        backgroundWorkerUpdate.RunWorkerAsync(mContent1);
        //    }
        //}

        //private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    lock (typeof(C_Event.CSocketEvent))
        //    {
        //        e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_PlayPosition_Update, (CEnum.Message_Body[])e.Argument);
        //    }
        //}

        //private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{

        //    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
        //    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
        //    {
        //        MessageBox.Show(mResult[0, 0].oContent.ToString());
        //        return;
        //    }
        //    if (mResult[0, 0].oContent.ToString() == "SUCCESS")
        //    {
        //        MessageBox.Show("传送成功");
        //        TbcResult.SelectedIndex = 0;
        //        txtUserID.Text = "";
        //        txtCharname.Text = "";
        //        txtX.Text = "";
        //        txtY.Text = "";
        //        txtZ.Text = "";
        //        txtMap.Text = "";
        //    }
        //    else
        //    {
        //        MessageBox.Show("传送失败");
        //        return;
        //    }
        //}

        //private void BtnQueryMap_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtUserID.Text.Trim().Length <= 0)
        //        {
        //            return;
        //        }
        //        if (txtCharname.Text.Trim().Length <= 0)
        //        {
        //            return;
        //        }

        //        //float a = float.Parse(txtX.Text);
        //        //float b = float.Parse(txtY.Text);

        //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

        //        mContent[0].eName = CEnum.TagName.FJ_XPosition;
        //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[0].oContent = "";

        //        mContent[1].eName = CEnum.TagName.FJ_YPosition;
        //        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
        //        mContent[1].oContent = "";

                
        //        lock (typeof(C_Event.CSocketEvent))
        //        {
        //            AreaResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_MAP_Query, mContent);
        //        }

        //        if (AreaResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
        //        {
        //            MessageBox.Show(AreaResult[0, 0].oContent.ToString());
        //            return;
        //        }
        //        else if (AreaResult[0, 0].eName == CEnum.TagName.FJ_Map)
        //        {
        //            //txtMap.Text = mResult[0, 0].oContent.ToString();

        //            txtMap = Operation_FJ.BuildAreaCombox(AreaResult, txtMap);

        //            bFirst = true;
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("坐标值有误");
        //    }
        //}

        //private void txtMap_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (bFirst)
        //        {
        //            txtX.Text = AreaResult[Operation_FJ.GetAreaID(AreaResult, txtMap.Text.Trim()), 1].oContent.ToString();
        //            txtY.Text = AreaResult[Operation_FJ.GetAreaID(AreaResult, txtMap.Text.Trim()), 2].oContent.ToString();
        //            txtZ.Text = AreaResult[Operation_FJ.GetAreaID(AreaResult, txtMap.Text.Trim()), 3].oContent.ToString();
        //        }

        //    }

        //    catch
        //    {
 
        //    }
        //}
    }
}