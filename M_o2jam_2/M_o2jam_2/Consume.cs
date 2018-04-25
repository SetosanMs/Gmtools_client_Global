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
    [C_Global.CModuleAttribute("玩家消费记录[超级乐者]", "Consume", "玩家消费记录", "o2jam2")]
    public partial class Consume : Form
    {
        public Consume()
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
            this.Text = config.ReadConfigValue("MBAF", "CS_UI_Consume");
            this.groupBox1.Text = config.ReadConfigValue("MBAF", "CS_UI_groupBox1");
            this.label7.Text = config.ReadConfigValue("MBAF", "CS_UI_label7");
            this.label6.Text = config.ReadConfigValue("MBAF", "CS_UI_label6");
            this.label5.Text = config.ReadConfigValue("MBAF", "CS_UI_label5");
            this.rbtnNick.Text = config.ReadConfigValue("MBAF", "CS_UI_rbtnNick");
            this.rbtnAccount.Text = config.ReadConfigValue("MBAF", "CS_UI_rbtnAccount");
            this.btnApply.Text = config.ReadConfigValue("MBAF", "CS_UI_btnApply");
            this.lblAorN.Text = config.ReadConfigValue("MBAF", "CS_UI_lblAorN");
            this.label1.Text = config.ReadConfigValue("MBAF", "CS_UI_label1");
            this.label3.Text = config.ReadConfigValue("MBAF", "CS_UI_label3");
            this.label2.Text = config.ReadConfigValue("MBAF", "CS_UI_label2");
            //this.cbxSearchType.Items.Add(config.ReadConfigValue("MBAF", "CS_UI_SearchType1"));
            //this.cbxSearchType.Items.Add(config.ReadConfigValue("MBAF", "CS_UI_SearchType2"));
            //this.cbxSearchType.Items.Add(config.ReadConfigValue("MBAF", "CS_UI_SearchType3"));
            //this.cbxSearchType.Items.Add(config.ReadConfigValue("MBAF", "CS_UI_SearchType4"));
            //this.cbxSearchType.Items.Add(config.ReadConfigValue("MBAF", "CS_UI_SearchType5"));
            this.cbxSearchType.Items.AddRange(new object[]
                {
                    config.ReadConfigValue("MBAF", "CS_UI_SearchType1"),
                    config.ReadConfigValue("MBAF", "CS_UI_SearchType2"),
                    config.ReadConfigValue("MBAF", "CS_UI_SearchType3"),
                    config.ReadConfigValue("MBAF", "CS_UI_SearchType4"),
                    config.ReadConfigValue("MBAF", "CS_UI_SearchType5")
                }
                );
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
        private C_Global.CEnum.Message_Body[,] infoResult = null;       //查询到的信息
        private C_Global.CEnum.Message_Body[,] totalResult = null;       //合计
        private string _ServerIP = null;                                //服务器ip

        private int pageIndex = 1;                                      //发送给服务器的开始条数
        private int pageSize = 20;                                      //每页显示条数
        private int pageCount = 1;                                      //总页数
        private int currPage = 0;                                       //当前页数

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
                messageBody[1].oContent = 3;

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
        /// 读取玩家身上道具
        /// </summary>
        private void ReadInfoFromDB()
        {

            dgInfoList.DataSource = null;

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
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[7];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[1].oContent = txtAorN.Text.Trim();//rbtnAccount.Checked ? txtAorN.Text.Trim() : "";

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.o2jam2_consumetype;
                messageBody[2].oContent = cbxSearchType.SelectedIndex;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[3].eName = C_Global.CEnum.TagName.O2JAM2_BeginDate;
                messageBody[3].oContent = Convert.ToDateTime(dtpBegin.Text);

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[4].eName = C_Global.CEnum.TagName.O2JAM2_ENDDate;
                messageBody[4].oContent = Convert.ToDateTime(dtpEnd.Text);

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[5].oContent = pageSize;

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.Index;
                messageBody[6].oContent = pageIndex;


                lock (typeof(C_Event.CSocketEvent))
                {
                    infoResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_CONSUME_QUERY, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                    totalResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_CONSUME_SUM_QUERY, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }
                if (infoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    //dpInfoContain.Visible = false;

                    MessageBox.Show(infoResult[0, 0].oContent.ToString());
                    return;
                }

                //
                dpPageView.Visible = true;
                dpInfoView.Visible = true;

                //总页数
                pageCount = int.Parse(infoResult[0, 7].oContent.ToString());

                lblPageCount.Text = Convert.ToString(pageCount);
                lblCurrPage.Text = Convert.ToString(currPage + 1);

                if (cbxToPageIndex.Items.Count == 0)
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        cbxToPageIndex.Items.Add(i);
                    }
                    cbxToPageIndex.SelectedIndex = 0;
                    //cbxToPageIndex.SelectedText = Convert.ToString(currPage + 1);
                }

                if (infoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    
                }
                else
                {
                    label3.Text = config.ReadConfigValue("MBAF", "CS_Code_Total") + totalResult[0, 0].oContent.ToString();
                }
                

                /*显示信息到列表中*/
                dgInfoList.DataSource = BrowseResultInfo();
            }
            catch
            {
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

                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "CS_Code_ItemName"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "CS_Code_ConsumeCode"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "CS_Code_CurrencyType"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "CS_Code_Cost"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "CS_Code_Date"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "CS_Code_DateLimit"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "CS_Code_TimesLimit"), typeof(string));

                for (int i = 0; i < infoResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow[config.ReadConfigValue("MBAF", "CS_Code_ItemName")] = infoResult[i, 6].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "CS_Code_ConsumeCode")] = infoResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "CS_Code_CurrencyType")] = int.Parse(infoResult[i, 1].oContent.ToString()) == 0 ? config.ReadConfigValue("MBAF", "CS_Code_Gcoin") : config.ReadConfigValue("MBAF", "CS_Code_Mcoin");
                    dgRow[config.ReadConfigValue("MBAF", "CS_Code_Cost")] = infoResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "CS_Code_Date")] = infoResult[i, 3].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "CS_Code_DateLimit")] = infoResult[i, 4].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "CS_Code_TimesLimit")] = infoResult[i, 5].oContent.ToString();

                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }
        


        #endregion

        private void GiftBox_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            dpPageView.Visible = false;
            dpInfoView.Visible = false;
            cbxSearchType.SelectedIndex = 0;
            InitializeServerIP();
        }

        private void rbtnNick_CheckedChanged(object sender, EventArgs e)
        {
            lblAorN.Text = config.ReadConfigValue("MBAF", "CS_Code_NickSearch");
            //lblAorN.Text = "昵称查询：";
        }

        private void rbtnAccount_CheckedChanged(object sender, EventArgs e)
        {
            lblAorN.Text = config.ReadConfigValue("MBAF", "CS_Code_AccontSearch");
            //lblAorN.Text = "昵称查询：";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "CS_Code_SelectServer"));
                cbxServerIP.Focus();
                return;
            }
            if (txtAorN.Text == null || txtAorN.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "CS_Code_Input").Replace("{Nick}",lblAorN.Text.Substring(0,(lblAorN.Text.Length-1))));
                lblAorN.Focus();
                return;
            }
            dpPageView.Visible = false;
            dpInfoView.Visible = false;
            cbxToPageIndex.Items.Clear();

            _ServerIP = null;
            refresh = false;

            ReadInfoFromDB();

        }

        private void cbxToPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            currPage = int.Parse(cbxToPageIndex.Text) - 1;
            pageIndex = (currPage) * pageSize + 1;

            if (refresh)
            {
                ReadInfoFromDB();
            }
            refresh = true;
        }
    }
}