using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Event;
using C_Global;

namespace M_o2jam
{
    [C_Global.CModuleAttribute("玩家交易/消费记录", "RSBInfo", "玩家交易/消费记录", "o2jam")]
    public partial class RSBInfo : Form
    {
        public RSBInfo()
        {
            InitializeComponent();
        }

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
        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        C_Global.CEnum.Message_Body[,] logInfoResult = null;    //帐号信息
        C_Global.CEnum.Message_Body[,] TCCountResult = null;    //合计
        private bool bFirst = false;
        string _ServerIP = null;    //服务器ip

        private int pageIndex = 1;  //发送给服务器的开始条数
        private int pageSize = 20;   //每页显示条数
        private int pageCount = 1;  //总页数
        private int currPage = 0;   //当前页数

        DataTable dgTable = new DataTable();
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
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_O2jam");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 3;

                lock (typeof(C_Event.CSocketEvent))
                {
                    serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                }

                //检测状态
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 读取帐号记录
        /// </summary>
        private void ReadInfoFromDB()
        {
            
            try
            {
                btnOK.Enabled = false;
                Cursor = Cursors.WaitCursor;
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[8];
                
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.o2jam_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.o2jam_UserID;
                messageBody[1].oContent = txtAorN.Text;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.o2jam_KIND;
                messageBody[2].oContent = GetActionKind();

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[3].eName = C_Global.CEnum.TagName.o2jam_BeginDate;
                messageBody[3].oContent = Convert.ToDateTime(dtpBeginDate.Text);

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[4].eName = C_Global.CEnum.TagName.o2jam_EndDate;
                messageBody[4].oContent = Convert.ToDateTime(dtpEndDate.Text);

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.O2JAM_BuyType;
                messageBody[5].oContent = chkConsumeMySelf.Checked ? 0 : 1;

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.Index;
                messageBody[6].oContent = pageIndex;

                messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[7].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[7].oContent = pageSize;

                this.backgroundWorkerReadInfoFromDB.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    logInfoResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_CONSUME_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                //    TCCountResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_CONSUME_SUM_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                //}

                //if (logInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    dgConsumeInfo.DataSource = null;
                //    dpContainer.Visible = false;
                //    lblCurrPage.Visible = false;
                //    lblPageCount.Visible = false;
                //    cbxToPageIndex.Items.Clear();
                //    cbxToPageIndex.Visible = false;
                //    label2.Visible = false;

                //    MessageBox.Show(logInfoResult[0, 0].oContent.ToString());
                //    return;
                //}

                ////总页数
                //pageCount = int.Parse(logInfoResult[0, 8].oContent.ToString());

                //lblPageCount.Text = Convert.ToString(pageCount);
                //lblCurrPage.Text = Convert.ToString(currPage + 1);

                //if (cbxToPageIndex.Items.Count == 0)
                //{
                //    for (int i = 1; i <= pageCount; i++)
                //    {
                //        cbxToPageIndex.Items.Add(i);
                //    }
                //    cbxToPageIndex.SelectedIndex = 0;
                //    bFirst = true;
                //    //cbxToPageIndex.SelectedText = Convert.ToString(currPage + 1);
                //}

                //dgConsumeInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源
                //dpContainer.Visible = true;                         //显示datagrid容器

                //lblCount.Text = "合计：　G币-" + TCCountResult[0, 0].oContent.ToString() + "    M币-" + TCCountResult[0, 1].oContent.ToString();

                //lblCurrPage.Visible = true;
                //lblPageCount.Visible = true;
                //cbxToPageIndex.Visible = true;
                //label2.Visible = true;
            }
            catch
            {
            }
            
        }


        /// <summary>
        /// 将返回数据转装成DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseResultInfo()
        {
            try
            {
                dgTable.Columns.Clear();       //清空头信息
                dgTable.Rows.Clear();          //清空行记录
                dgTable.Columns.Add("赠送人", typeof(string));
                dgTable.Columns.Add("道具名称", typeof(string));
                dgTable.Columns.Add("G币费用", typeof(string));
                dgTable.Columns.Add("M币费用", typeof(string));
                dgTable.Columns.Add("购买日期", typeof(string));
                dgTable.Columns.Add("接受人帐号", typeof(string));
                dgTable.Columns.Add("接受人昵称", typeof(string));

                for (int i = 0; i < logInfoResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow["赠送人"] = logInfoResult[i, 0].oContent.ToString();
                    dgRow["道具名称"] = logInfoResult[i, 2].oContent.ToString();
                    dgRow["G币费用"] = logInfoResult[i, 3].oContent.ToString();
                    dgRow["M币费用"] = logInfoResult[i, 4].oContent.ToString();
                    dgRow["购买日期"] = logInfoResult[i,5].oContent.ToString();
                    dgRow["接受人帐号"] = logInfoResult[i, 6].oContent.ToString();
                    dgRow["接受人昵称"] = logInfoResult[i, 7].oContent.ToString();

                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        /// <summary>
        /// 解析操作类型
        /// </summary>
        /// <returns></returns>
        private int GetActionKind()
        {
            int returnValue = 1;
            if (chkAccount.Checked)
            {
                if (chkConsumeMySelf.Checked)
                {
                    returnValue = 1;
                }
                if (chkConsumeOther.Checked && chkSend.Checked)
                {
                    returnValue = 1;
                }
                if (chkConsumeOther.Checked && chkRecv.Checked)
                {
                    returnValue = 2;
                }
            }
            if (chkNick.Checked)
            {
                if (chkConsumeOther.Checked && chkRecv.Checked)
                {
                    returnValue = 3;
                }
            }
            return returnValue;
        }

        #endregion

        private void RSBInfo_Load(object sender, EventArgs e)
        {
            dgConsumeInfo.DataSource = null;
            dpContainer.Visible = false;
            chkNick.Enabled = false;
            chkNick.Checked = false;
            chkRecv.Visible = false;
            chkRecv.Checked = false;
            chkSend.Visible = false;
            chkSend.Checked = false;
            chkConsumeMySelf.Checked = true;
            chkConsumeOther.Checked = false;
            chkAccount.Checked = true;
            chkNick.Enabled = false;
            chkNick.Checked = false;
            lblCurrPage.Visible = false;
            lblPageCount.Visible = false;
            cbxToPageIndex.Items.Clear();
            cbxToPageIndex.Visible = false;
            label2.Visible = false;

            InitializeServerIP();
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            chkNick.Checked = false;
            lblAorN.Text = "帐号查询：";
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            chkAccount.Checked = false;
            lblAorN.Text = "昵称查询：";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgConsumeInfo.DataSource = null;
            dpContainer.Visible = false;
            chkNick.Enabled = false;
            chkNick.Checked = false;
            chkRecv.Visible = false;
            chkRecv.Checked = false;
            chkSend.Visible = false;
            chkSend.Checked = false;
            chkConsumeMySelf.Checked = true;
            chkConsumeOther.Checked = false;
            chkAccount.Checked = true;
            chkNick.Enabled = false;
            chkNick.Checked = false;
            lblCurrPage.Visible = false;
            lblPageCount.Visible = false;
            cbxToPageIndex.Items.Clear();
            cbxToPageIndex.Visible = false;
            label2.Visible = false;
        }

        private void chkConsumeMySelf_Click(object sender, EventArgs e)
        {
            chkConsumeOther.Checked = false;
            chkNick.Enabled = false;
            chkNick.Checked = false;
            chkSend.Visible = false;
            chkRecv.Visible = false;
            chkSend.Checked = false;
            chkRecv.Checked = false;
        }

        private void chkConsumeOther_Click(object sender, EventArgs e)
        {
            chkConsumeMySelf.Checked = false;

            if (chkConsumeOther.Checked)
            {
                chkSend.Visible = true;
                chkRecv.Visible = true;
            }
            else
            {
                chkSend.Visible = false;
                chkRecv.Visible = false;
                chkNick.Checked = false;
                chkSend.Checked = false;
                chkRecv.Checked = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 内容检测
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show("请选择服务器");
                return;
            }

            if (!chkAccount.Checked && !chkNick.Checked)
            {
                MessageBox.Show("请选择一种查询方式：\n1.帐号查询\n2.昵称查询");
                return;
            }

            if (!chkConsumeMySelf.Checked && !chkConsumeOther.Checked)
            {
                MessageBox.Show("请选择消费类型：\n1.消费记录\n2.交易记录");
                return;
            }

            if (chkConsumeOther.Checked && !chkRecv.Checked && !chkSend.Checked)
            {
                MessageBox.Show("请选择要查询的用户是交易记录的哪一方");
                return;
            }

            if (txtAorN.Text == null || txtAorN.Text == "")
            {
                MessageBox.Show("请输入" + (chkAccount.Checked ? "玩家帐号" : "玩家昵称"));
                return;
            }

            #endregion

            #region IP检索
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion
            dgConsumeInfo.DataSource = null;
            cbxToPageIndex.Items.Clear();
            lblCount.Text = "";
            bFirst = false;
            pageIndex = 1;

            ReadInfoFromDB();
        }

        private void chkRecv_Click(object sender, EventArgs e)
        {
            chkSend.Checked = false;
            chkNick.Enabled = true;
        }

        private void chkSend_Click(object sender, EventArgs e)
        {
            chkRecv.Checked = false;
            chkNick.Enabled = false;
            chkNick.Checked = false;
        }

        private void cbxToPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                currPage = int.Parse(cbxToPageIndex.Text) - 1;
                pageIndex = (currPage) * pageSize + 1;

                ReadInfoFromDB();
            }
        }

        private void backgroundWorkerReadInfoFromDB_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                logInfoResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_CONSUME_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, (CEnum.Message_Body[])e.Argument);
                TCCountResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_CONSUME_SUM_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReadInfoFromDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOK.Enabled = true;
            Cursor = Cursors.Default;
            
            if (logInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                dgConsumeInfo.DataSource = null;
                dpContainer.Visible = false;
                lblCurrPage.Visible = false;
                lblPageCount.Visible = false;
                cbxToPageIndex.Items.Clear();
                cbxToPageIndex.Visible = false;
                label2.Visible = false;

                MessageBox.Show(logInfoResult[0, 0].oContent.ToString());
                return;
            }

            //总页数

            pageCount = int.Parse(logInfoResult[0, 8].oContent.ToString());

            lblPageCount.Text = Convert.ToString(pageCount);
            lblCurrPage.Text = Convert.ToString(currPage + 1);

            if (cbxToPageIndex.Items.Count == 0)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    cbxToPageIndex.Items.Add(i);
                }
                cbxToPageIndex.SelectedIndex = 0;
                bFirst = true;
                //cbxToPageIndex.SelectedText = Convert.ToString(currPage + 1);
            }

            dgConsumeInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源

            dpContainer.Visible = true;                         //显示datagrid容器

            lblCount.Text = "合计：　G币-" + TCCountResult[0, 0].oContent.ToString() + "    M币-" + TCCountResult[0, 1].oContent.ToString();

            lblCurrPage.Visible = true;
            lblPageCount.Visible = true;
            cbxToPageIndex.Visible = true;
            label2.Visible = true;
        }
    }
}