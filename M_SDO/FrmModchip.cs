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
using System.Text.RegularExpressions;
namespace M_SDO
{
    [C_Global.CModuleAttribute("大赛拼图信息设置", "FrmModchip", "大赛拼图信息设置", "SDO Group")]
    public partial class FrmModchip : Form
    {
        public FrmModchip()
        {
            InitializeComponent();
        }

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] mItemResult = null;
        private int iPageCount = 0;
        int currSelectPSTID = -1;
        DataTable dgTable = new DataTable();
        #region 自定义调用事件
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
            //IntiUI();
        }

        private void IntiUI()
        {
            //this.Text = config.ReadConfigValue("MSDO", "LR_UI_SDOLogin");
            //this.GrpSearch.Text = config.ReadConfigValue("MSDO", "LR_UI_GrpSearch");
            //this.LblServer.Text = config.ReadConfigValue("MSDO", "FM_UI_LblServer");
            //this.LblAccount.Text = config.ReadConfigValue("MSDO", "FM_UI_LblAccount");
            //this.BtnSearch.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnSearch");
            //this.BtnClose.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnClose");

            //this.lblstartime.Text = config.ReadConfigValue("MSDO", "FM_UI_lblstartime");
            //this.lblendtime.Text = config.ReadConfigValue("MSDO", "FM_UI_lblendtime");
            //this.GrpResult.Text = config.ReadConfigValue("MSDO", "LR_UI_GrpResult");
            //this.LblPage.Text = config.ReadConfigValue("MSDO", "LR_UI_LblPage");

        }
        #endregion
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void FrmModchip_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");
            this.backgroundWorkLoad.RunWorkerAsync(mContent);

        }



        private void backgroundWorkLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (CmbServer.Text.Trim().Length > 0)
            {
                QueryIteminfo();
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
            }
        }

        private void QueryIteminfo()
        {
            this.btnSearch.Enabled = false;
            this.Cursor = Cursors.AppStarting;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            mContent[1].eName = C_Global.CEnum.TagName.UserByID;
            mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_FRAGMENT_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnSearch.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, dgAccountInfo, out iPageCount);
            }
        }

        private void dgAccountInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                dgTable = (DataTable)dgAccountInfo.DataSource;
                //当前用户
                currSelectPSTID = int.Parse(dgTable.Rows[e.RowIndex]["ID"].ToString());
                txtitemname.Text = dgTable.Rows[e.RowIndex]["道具名称"].ToString().Trim();
                Txtpersent.Text = dgTable.Rows[e.RowIndex]["获得几率"].ToString().Trim();
                dpModi.Visible = true;
                dpNoteText.Visible = true;
            }
            catch
            {
            }
        }

        private void TxtCharname_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = Txtpersent.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            Txtpersent.Text = rx.Replace(txt, "");
        }

        private void btnModiApply_Click(object sender, EventArgs e)
        {
            if (Txtpersent.Text == null || Txtpersent.Text == "")
            {
                Txtpersent.Text = "0";
            }
            if (currSelectPSTID == -1)
            {
                MessageBox.Show("请先选择件物品");
                return;
            }
            btnModiApply.Enabled = false;
            Cursor = Cursors.AppStarting;
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eName = CEnum.TagName.SDO_ServerIP;
                messageBody[1].eTag = CEnum.TagFormat.TLV_STRING;
                messageBody[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.SDO_fragment_id;
                messageBody[2].oContent = currSelectPSTID;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.SDO_Precent;
                messageBody[3].oContent = int.Parse(Txtpersent.Text.Trim());

                this.backgroundWorkerUpdate.RunWorkerAsync(messageBody);
            }
            catch
            { }
        }

        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_FRAGMENT_UPDATE, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnModiApply.Enabled = true;
            this.Cursor = Cursors.Default;

            C_Global.CEnum.Message_Body[,] modiResult = (C_Global.CEnum.Message_Body[,])e.Result;

            if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(modiResult[0, 0].oContent.ToString());
                return;
            }

            if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show("修改成功");

                QueryIteminfo();          //刷新列表
                dpModi.Visible = false;     //隐藏修改容器
                dpNoteText.Visible = false;
                return;
            }
            else
            {
                MessageBox.Show("修改失败");
            }


        }

        private void btnModiCancel_Click(object sender, EventArgs e)
        {
            currSelectPSTID = -1;
            txtitemname.Text = "";
            Txtpersent.Text = "";
        }


    }
}