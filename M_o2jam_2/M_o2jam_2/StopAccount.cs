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

namespace M_o2jam_2
{
    [C_Global.CModuleAttribute("解/停封玩家帐号[超级乐者]", "StopAccount", "解/停封玩家帐号", "o2jam2")]
    public partial class StopAccount : Form
    {
        public StopAccount()
        {
            InitializeComponent();
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
            this.Text = config.ReadConfigValue("MBAF", "SA_UI_StopAccount");
            this.groupBox1.Text = config.ReadConfigValue("MBAF", "SA_UI_groupBox1");
            this.gbxStpActView.Text = config.ReadConfigValue("MBAF", "SA_UI_gbxStpActView");
            this.button2.Text = config.ReadConfigValue("MBAF", "SA_UI_button2");
            this.button4.Text = config.ReadConfigValue("MBAF", "SA_UI_button4");
            this.button1.Text = config.ReadConfigValue("MBAF", "SA_UI_button1");
            //this.cbxToPageIndex.Text = config.ReadConfigValue("MBAF", "SA_UI_cbxToPageIndex");
            this.btnActCancel.Text = config.ReadConfigValue("MBAF", "SA_UI_btnActCancel");
            this.btnUnStpAct.Text = config.ReadConfigValue("MBAF", "SA_UI_btnUnStpAct");
            this.LblContent.Text = config.ReadConfigValue("MBAF", "SA_UI_LblContent");
            this.LblNick.Text = config.ReadConfigValue("MBAF", "SA_UI_lblActionText1") + "\r\n---------------------------------------------\r\n" + config.ReadConfigValue("MBAF", "SA_UI_lblActionText2") + "\r\n-----------" +
                "----------------------------------";
        }


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

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        private C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        private C_Global.CEnum.Message_Body[,] stopAccountResult = null;//封停帐号列表
        private C_Global.CEnum.Message_Body[,] stopActionResult = null;  //封停帐号结果
        private C_Global.CEnum.Message_Body[,] openActionResult = null;  //解封帐号结果
        private C_Global.CEnum.Message_Body[,] stopedActInfo = null;  //封停帐号详细信息
        private string _ServerIP = null;                                //服务器ip

        private int pageIndex = 1;                                      //发送给服务器的开始条数
        private int pageSize = 20;                                      //每页显示条数
        private int pageCount = 1;                                      //总页数
        private int currPage = 0;                                       //当前页数

        private int currSelLine = 0;                                    //当前选定行

        private bool needReLoad = false;

        private bool refresh = false;

        #endregion

        #region 函数
        /// <summary>
        /// 初始化游戏服务器列表
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.cbxServerIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_O2jam2");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                lock (typeof(C_Event.CSocketEvent))
                {
                    serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                }

                //检测状态
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    return;
                }

                //显示内容到列表
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }

                cbxServerIP.SelectedIndex = 0;
            }
            catch
            {
            }
        }


        /// <summary>
        /// 读取停封帐号
        /// </summary>
        private void ReadStopAccountFromDB()
        {

            dgStpActView.DataSource = null;
            /*
             获取ip
             */
            if (_ServerIP == null || _ServerIP == "")
            {
                for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                {
                    if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                    {
                        this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                    }
                }
            }

            /*
             拉数据
             */
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[1].oContent = pageSize;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.Index;
                messageBody[2].oContent = pageIndex;

                lock (typeof(C_Event.CSocketEvent))
                {
                    stopAccountResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_MEMBERBANISHMENT_QUERY, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }

                if (stopAccountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(stopAccountResult[0, 0].oContent.ToString());
                    return;
                }

                //
                cbxServerIP.Enabled = false;

                //
                dpStopActView.Visible = true;
                cbxToPageIndex.Visible = true;



                //总页数
                pageCount = int.Parse(stopAccountResult[0, 3].oContent.ToString());

                if (cbxToPageIndex.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPageIndex.Items.Add(config.ReadConfigValue("MBAF", "SA_Code_Turn") + i + config.ReadConfigValue("MBAF", "SA_Code_Page"));
                    }
                    cbxToPageIndex.SelectedIndex = 0;
                }

                /*显示信息到列表中*/
                dgStpActView.DataSource = BrowseResultInfo();
            }
            catch
            {
            }

        }

        /// <summary>
        /// 停封玩家帐号
        /// </summary>
        private void ToStopAccount()
        {
            /*
             获取ip
             */
            if (_ServerIP == null || _ServerIP == "")
            {
                for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                {
                    if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                    {
                        this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                    }
                }
            }

            /*
             拉数据
             */
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[1].oContent = TxtAccount.Text.Trim();

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.O2JAM2_REASON;
                messageBody[2].oContent = TxtContent.Text;

                messageBody[3].eName = CEnum.TagName.UserByID;
                messageBody[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                lock (typeof(C_Event.CSocketEvent))
                {
                    stopActionResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_ACCOUNT_CLOSE, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }

                if (stopActionResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(stopActionResult[0, 0].oContent.ToString());
                    return;
                }

                if (stopActionResult[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MBAF", "SA_Code_Failed"));
                    return;
                }
                else if (stopActionResult[0, 0].oContent.Equals("SUCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MBAF", "SA_Code_Success"));
                    dpActaion.Visible = false;
                    cbxToPageIndex.Visible = false;
                    dpStopActView.Visible = false;
                    TxtContent.Clear();
                    TxtAccount.Clear();
                    ReadStopAccountFromDB();
                    return;
                }

                
            }
            catch
            {
            }

        }



        private void ToUnStopAccount()
        {
            /*
             获取ip
             */
            if (_ServerIP == null || _ServerIP == "")
            {
                for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                {
                    if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                    {
                        this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                    }
                }
            }

            /*
             拉数据
             */
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[1].oContent = TxtAccount.Text.Trim();

                messageBody[2].eName = CEnum.TagName.UserByID;
                messageBody[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                lock (typeof(C_Event.CSocketEvent))
                {
                    openActionResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_ACCOUNT_OPEN, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }

                if (openActionResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(openActionResult[0, 0].oContent.ToString());
                    return;
                }

                if (openActionResult[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MBAF", "SA_Code_Failed"));
                    return;
                }
                else if (openActionResult[0, 0].oContent.Equals("SUCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MBAF", "SA_Code_Success"));
                    dpActaion.Visible = false;
                    cbxToPageIndex.Visible = false;
                    dpStopActView.Visible = false;
                    TxtAccount.Clear();
                    TxtContent.Clear();
                    ReadStopAccountFromDB();
                    return;
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "SA_Code_ClientErrorMessage") + "\n-------------------------------------\n" + ex.Message);
            }
            finally
            {
                openActionResult = null;
            }

        }


        /// <summary>
        /// 读取停封玩家信息
        /// </summary>
        private void ReadStopedInfo()
        {
            /*
             获取ip
             */
            if (_ServerIP == null || _ServerIP == "")
            {
                for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                {
                    if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                    {
                        this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                    }
                }
            }

            /*
             拉数据
             */
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[1].oContent = stopAccountResult[currSelLine,1].oContent.ToString();

                lock (typeof(C_Event.CSocketEvent))
                {
                    stopedActInfo = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_MEMBERLOCAL_BANISHMENT, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }

                if (stopedActInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(stopedActInfo[0, 0].oContent.ToString());
                    return;
                }


                
                TxtContent.Text = stopedActInfo[0, 0].oContent.ToString();               


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// 显示数据信息
        /// </summary>
        /// <returns></returns>
        
        private DataTable BrowseResultInfo()
        {
            DataTable dgTable = new DataTable();

            try
            {
                dgTable.Columns.Clear();       //清空头信息
                dgTable.Rows.Clear();          //清空行记录

                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "SA_Code_Account"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "SA_Code_FreezenDate"), typeof(string));

                for (int i = 0; i < stopAccountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow[config.ReadConfigValue("MBAF", "SA_Code_Account")] = stopAccountResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "SA_Code_FreezenDate")] = stopAccountResult[i, 2].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }
        


        #endregion

        private void StopAccount_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            dpStopActView.Visible = false;
            dpActaion.Visible = false;
            cbxToPageIndex.Visible = false;

            InitializeServerIP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dpStopActView.Visible = false;
            dpActaion.Visible = false;

            cbxToPageIndex.Items.Clear();
            pageIndex = 1;
            _ServerIP = null;
            refresh = false;
            ReadStopAccountFromDB();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LblNick.Text = config.ReadConfigValue("MBAF", "SA_Code_FreezeAccount");
            lblActionText.Text = config.ReadConfigValue("MBAF", "SA_Code_FreezeAccount") + "\n---------------------------------------------\n" + config.ReadConfigValue("MBAF", "SA_Code_InputReason") + "\n---------------------------------------------";
            btnUnStpAct.Text = config.ReadConfigValue("MBAF", "SA_Code_FreezeAccount");
            dpActaion.Visible = true;
            dpStopActView.Visible = false;
            cbxToPageIndex.Visible = false;
            cbxToPageIndex.Items.Clear();
            refresh = false;
            _ServerIP = null;
        }

        private void cbxToPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            currPage = cbxToPageIndex.SelectedIndex;
            pageIndex = (currPage) * pageSize + 1;

            if (refresh)
            {
                ReadStopAccountFromDB();
            }
            refresh = true;
        }

        private void btnUnStpAct_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text == null || TxtAccount.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "SA_Code_InputAccount"));
                TxtAccount.Focus();
            }

            if (MessageBox.Show(config.ReadConfigValue("MBAF", "SA_Code_Confirmation") + btnUnStpAct.Text + TxtAccount.Text + "?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (btnUnStpAct.Text == config.ReadConfigValue("MBAF", "SA_Code_UnFreeze"))
                {
                    ToUnStopAccount();
                }
                else
                {
                    ToStopAccount();
                }
                //(btnUnStpAct.Text == "解封帐号") ?  : ToStopAccount();
            }
        }

        private void dgStpActView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                currSelLine = e.RowIndex;

                if (currSelLine != -1)
                {
                    dpActaion.Visible = true;
                    this.LblNick.Text = config.ReadConfigValue("MBAF", "SA_Code_UnFreeze");
                    lblActionText.Text = config.ReadConfigValue("MBAF", "SA_Code_UnFreeze") + "\n---------------------------------------------\n" + config.ReadConfigValue("MBAF", "SA_Code_UnFreezeMessage") + "\n---------------------------------------------";
                    btnUnStpAct.Text = config.ReadConfigValue("MBAF", "SA_Code_UnFreeze");


                    TxtAccount.Text = stopAccountResult[currSelLine, 1].oContent.ToString();

                    ReadStopedInfo();
                }
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbxServerIP.Enabled = true;
            dpStopActView.Visible = false;
            dpActaion.Visible = false;
            cbxToPageIndex.Visible = false;
            refresh = false;
            _ServerIP = null;
        }

        private void dgStpActView_MouseUp(object sender, MouseEventArgs e)
        {
              if (needReLoad)
               {
                    dgStpActView.DataSource = BrowseResultInfo();
                    needReLoad = false;
                }
            
        }

        private void dgStpActView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            needReLoad = true;
        }

        private void btnActCancel_Click(object sender, EventArgs e)
        {
            //this.dpActaion.Visible = false;
            //this.dividerPanel2.Visible = true;
            //this.gbxStpActView.Visible = false;
        }
    }
}