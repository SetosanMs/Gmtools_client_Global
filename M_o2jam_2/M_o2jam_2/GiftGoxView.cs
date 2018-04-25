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
    [C_Global.CModuleAttribute("玩家礼物盒[超级乐者]", "GiftGoxView", "玩家礼物盒", "o2jam2")]
    public partial class GiftGoxView : Form
    {
        public GiftGoxView()
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
            this.Text = config.ReadConfigValue("MBAF", "GGV_UI_Gift");
            this.groupBox1.Text = config.ReadConfigValue("MBAF", "GGV_UI_groupBox1");
            this.btnDelGift.Text = config.ReadConfigValue("MBAF", "GGV_UI_btnDelGift");
            this.btnCancel.Text = config.ReadConfigValue("MBAF", "GGV_UI_btnCancel");
            this.btnApply.Text = config.ReadConfigValue("MBAF", "GGV_UI_btnApply");
            this.btnSendView.Text = config.ReadConfigValue("MBAF", "GGV_UI_btnSendView");
            this.lblAorN.Text = config.ReadConfigValue("MBAF", "GGV_UI_lblAorN");
            this.label1.Text = config.ReadConfigValue("MBAF", "GGV_UI_label1");
            this.groupBox2.Text = config.ReadConfigValue("MBAF", "GGV_UI_groupBox2");
            this.button2.Text = config.ReadConfigValue("MBAF", "GGV_UI_button2");
            this.button1.Text = config.ReadConfigValue("MBAF", "GGV_UI_button1");
            this.label7.Text = config.ReadConfigValue("MBAF", "GGV_UI_label7");
            this.label5.Text = config.ReadConfigValue("MBAF", "GGV_UI_label5");
            this.label4.Text = config.ReadConfigValue("MBAF", "GGV_UI_label4");
            this.label3.Text = config.ReadConfigValue("MBAF", "GGV_UI_label3");
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
        private C_Global.CEnum.Message_Body[,] giftResult = null;       //礼物盒列表
        private C_Global.CEnum.Message_Body[,] giftSendResult = null;   //礼物赠送
        private C_Global.CEnum.Message_Body[,] giftDelResult = null;    //礼物赠送

        private int currSelLine = 0;        //当前选中的行
        private string _ServerIP = null;    //服务器ip


        private bool refresh = false;       //在也数加载到下列列表中时会激活事件


        private int pageIndex = 1;                                      //发送给服务器的开始条数
        private int pageSize = 20;                                      //每页显示条数
        private int pageCount = 1;                                      //总页数
        private int currPage = 0;                                       //当前页数

        private bool needReLoad = false;

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
                    //Application.Exit();
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
        /// 读取玩家礼物盒
        /// </summary>
        private void ReadInfoFromDB()
        {

            dgGiftCotain.DataSource = null;

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

            
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[1].oContent = txtAorN.Text.Trim();

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[2].oContent = pageSize;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.Index;
                messageBody[3].oContent = pageIndex;

                this.backgroundWorkerSearch.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    giftResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_MESSAGE_QUERY, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                //}

                //if (giftResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(giftResult[0, 0].oContent.ToString());
                //    return;
                //}

                //cbxServerIP.Enabled = false;
                //txtAorN.Enabled = false;

                

                

                //dpTop.Visible = true;
                //dpRight.Visible = true;
                //dpRight.Dock = DockStyle.Fill;
                //dpRR.Visible = false;



                ////总页数
                //pageCount = int.Parse(giftResult[0, 7].oContent.ToString());

                //if (cbxToPageIndex.Items.Count == 0)
                //{
                //    for (int i = 1; i <= pageCount; i++)
                //    {
                //        cbxToPageIndex.Items.Add(config.ReadConfigValue("MBAF", "GGV_Code_PageIndex1") + i + "/" + pageCount + config.ReadConfigValue("MBAF", "GGV_Code_PageIndex2") + i + config.ReadConfigValue("MBAF", "GGV_Code_PageIndex3"));
                //    }
                //    //if (cbxToPageIndex.Items.Count > 0)
                //    //{
                //    cbxToPageIndex.SelectedIndex = 0;
                //    //}
                //}


                ///*显示信息到列表中*/
                //dgGiftCotain.DataSource = BrowseResultInfo();
            }
            catch(Exception ex)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_ClientErrorMessage") + "\n-----------------------------------------\n" + ex.Message);
            }

        }



        private void SendItem()
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
                //动感长发_6173_0_7
                string[] itemString = txtItemName.Text.Split(new char[]{'_'});          


                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[8];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[1].oContent = txtRecvUser.Text.Trim();

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.O2JAM2_Title;
                messageBody[2].oContent = txtTitle.Text;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.O2JAM2_Context;
                messageBody[3].oContent = txtContent.Text;

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.O2JAM2_ItemCode;
                messageBody[4].oContent = int.Parse(itemString[1]);

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.O2JAM2_DayLimit;
                messageBody[5].oContent = int.Parse(itemString[3]);

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.O2JAM2_Timeslimt;
                messageBody[6].oContent = int.Parse(itemString[2]);

                messageBody[7].eName = CEnum.TagName.UserByID;
                messageBody[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[7].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                this.backgroundWorkerSendItem.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    giftSendResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_MESSAGE_CREATE, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                //}

                //if (giftSendResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(giftSendResult[0, 0].oContent.ToString());
                //    return;
                //}

                //if (giftSendResult[0, 0].oContent.Equals("FAILURE"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_Failed"));
                //    return;
                //}
                //else if (giftSendResult[0, 0].oContent.Equals("SUCESS"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_Success"));
                //    _ServerIP = null;
                //    groupBox2.Visible = false;
                //    txtRecvUser.Clear();
                //    txtTitle.Clear();
                //    txtContent.Clear();
                //    txtItemName.Clear();
                //    ReadInfoFromDB();

                //    dpRR.Visible = false;
                //    dpRight.Dock = DockStyle.Fill;
                //    return;
                //}


            }
            catch
            {
            }

        }




        /// <summary>
        /// 删除部位道具
        /// </summary>
        
        private void DelItem()
        {
            //ip
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

            
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_ItemCode;
                messageBody[1].oContent = int.Parse(giftResult[currSelLine, 0].oContent.ToString());

                messageBody[2].eName = CEnum.TagName.UserByID;
                messageBody[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[3].oContent = txtAorN.Text.Trim();

                this.backgroundWorkerDelItem.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    giftDelResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_MESSAGE_DELETE, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                //}

                //if (giftDelResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    //dpInfoContain.Visible = false;

                //    MessageBox.Show(giftDelResult[0, 0].oContent.ToString());
                //    return;
                //}

                //if (giftDelResult[0, 0].oContent.Equals("FAILURE"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_Failed"));
                //    return;
                //}
                //else if (giftDelResult[0, 0].oContent.Equals("SUCESS"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_Success"));
                //    btnDelGift.Enabled = false;
                //    ReadInfoFromDB();
                //    return;
                //}

            }
            catch
            {
            }

        }
        






        
        private DataTable BrowseResultInfo()
        {
            DataTable dgTable = new DataTable();

            try
            {
                dgTable.Columns.Clear();       //清空头信息
                dgTable.Rows.Clear();          //清空行记录

                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "GGV_Code_ItemName"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "GGV_Code_TimesLimit"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "GGV_Code_DaysLimit"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "GGV_Code_Title"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "GGV_Code_Content"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "GGV_Code_Date"), typeof(string));

                for (int i = 0; i < giftResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow[config.ReadConfigValue("MBAF", "GGV_Code_ItemName")] = giftResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "GGV_Code_TimesLimit")] = giftResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "GGV_Code_DaysLimit")] = giftResult[i, 3].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "GGV_Code_Title")] = giftResult[i, 4].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "GGV_Code_Content")] = giftResult[i, 5].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "GGV_Code_Date")] = giftResult[i, 6].oContent.ToString();
                    

                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }
        


        

        #endregion

        private void GiftGoxView_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            btnDelGift.Enabled = false;

            InitializeServerIP();
            cbxToPageIndex.Items.Clear();
            groupBox2.Visible = false;

            dpTop.Visible = false;
            dpRight.Visible = false;
            dpRR.Visible = false;

            btnDelGift.Enabled = false;

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cbxServerIP.Text == "" || cbxServerIP.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_SelectServer"));
                //MessageBox.Show("请选择服务器");
                cbxServerIP.Focus();
                return;
            }

            if (txtAorN.Text == "" || txtAorN.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_Input").Replace("{Nick}", lblAorN.Text.Substring(0, (lblAorN.Text.Length - 1))));
                //MessageBox.Show("请输入" + lblAorN.Text.Substring(0, (lblAorN.Text.Length - 1)));
                txtAorN.Focus();
                return;
            }
            btnApply.Enabled = false;
            Cursor = Cursors.WaitCursor;
            btnDelGift.Enabled = false;
            dpRR.Visible = false;
            dpRight.Visible = false;
            dpTop.Visible = false;
            refresh = false;

            cbxToPageIndex.Items.Clear();

            _ServerIP = null;

            ReadInfoFromDB();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cbxServerIP.Enabled = true;
            txtAorN.Enabled = true;
            cbxToPageIndex.Items.Clear();

            btnDelGift.Enabled = false;
            groupBox2.Visible = false;

            dpTop.Visible = false;
            dpRight.Visible = false;
            dpRR.Visible = false;

            refresh = false;

            _ServerIP　= null;
        }

        private void btnDelGift_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_ComfirmDeletion"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _ServerIP = null;
                refresh = false;
                Cursor = Cursors.WaitCursor;
                DelItem();
            }
        }

        private void btnSendView_Click(object sender, EventArgs e)
        {
            if (cbxServerIP.Text == "" || cbxServerIP.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_SelectServer"));
                cbxServerIP.Focus();
                return;
            }

            if (txtAorN.Text == "" || txtAorN.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_Input").Replace("{Nick}", lblAorN.Text.Substring(0, (lblAorN.Text.Length - 1))));
                txtAorN.Focus();
                return;
            }


            _ServerIP = null;

            cbxServerIP.Enabled = false;
            txtAorN.Enabled = false;



            dpRR.Visible = true;
            dpRight.Dock = DockStyle.Left;
            groupBox2.Visible = true;
            txtRecvUser.Clear();
            txtTitle.Clear();
            txtContent.Clear();
            txtItemName.Clear();

            txtRecvUser.Text = txtAorN.Text;
        }

        private void txtItemName_DoubleClick(object sender, EventArgs e)
        {
            if (txtRecvUser.Text == "" || txtRecvUser.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_InputReceiver"));
                txtRecvUser.Focus();
                return;
            }


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

            ////
            int x = MousePosition.X;
            int y = MousePosition.Y;
            
            ItemsShow itmInput = new ItemsShow(m_ClientEvent, _ServerIP, txtItemName,txtRecvUser.Text,x,y);
            itmInput.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Cursor = Cursors.WaitCursor;
            _ServerIP = null;
            SendItem();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            txtRecvUser.Clear();
            txtTitle.Clear();
            txtContent.Clear();
            txtItemName.Clear();
            dpRR.Visible = false;
            dpRight.Dock = DockStyle.Fill;
        }

        private void dgGiftCotain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                currSelLine = e.RowIndex;
                if (currSelLine != -1)
                {
                    btnDelGift.Enabled = true;
                }
            }
            catch
            {
            }
        }

        private void cbxToPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            currPage = cbxToPageIndex.SelectedIndex;
            pageIndex = (currPage) * pageSize + 1;

            if (refresh)
            {
                ReadInfoFromDB();
            }

            refresh = true;
        }

        private void dgGiftCotain_MouseUp(object sender, MouseEventArgs e)
        {
            if (needReLoad)
            {
                dgGiftCotain.DataSource = BrowseResultInfo();
                needReLoad = false;
            }
        }

        private void dgGiftCotain_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            needReLoad = true;
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                giftResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_MESSAGE_QUERY, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnApply.Enabled = true;
            Cursor = Cursors.Default;
            if (giftResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(giftResult[0, 0].oContent.ToString());
                return;
            }

            cbxServerIP.Enabled = false;
            txtAorN.Enabled = false;





            dpTop.Visible = true;
            dpRight.Visible = true;
            dpRight.Dock = DockStyle.Fill;
            dpRR.Visible = false;



            //总页数

            pageCount = int.Parse(giftResult[0, 7].oContent.ToString());

            if (cbxToPageIndex.Items.Count == 0)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    cbxToPageIndex.Items.Add(config.ReadConfigValue("MBAF", "GGV_Code_PageIndex1") + i + "/" + pageCount + config.ReadConfigValue("MBAF", "GGV_Code_PageIndex2") + i + config.ReadConfigValue("MBAF", "GGV_Code_PageIndex3"));
                }
                //if (cbxToPageIndex.Items.Count > 0)
                //{
                cbxToPageIndex.SelectedIndex = 0;
                //}
            }


            /*显示信息到列表中*/
            dgGiftCotain.DataSource = BrowseResultInfo();
        }

        private void backgroundWorkerDelItem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                giftDelResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_MESSAGE_DELETE, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, (CEnum.Message_Body[])e.Argument);
            }

           
        }

        private void backgroundWorkerDelItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            if (giftDelResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                //dpInfoContain.Visible = false;

                MessageBox.Show(giftDelResult[0, 0].oContent.ToString());
                return;
            }

            if (giftDelResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_Failed"));
                return;
            }
            else if (giftDelResult[0, 0].oContent.Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_Success"));
                btnDelGift.Enabled = false;
                ReadInfoFromDB();
                return;
            }
        }

        private void backgroundWorkerSendItem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                giftSendResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_MESSAGE_CREATE, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, (CEnum.Message_Body[])e.Argument);
            }

        }

        private void backgroundWorkerSendItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            Cursor = Cursors.Default;
            if (giftSendResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(giftSendResult[0, 0].oContent.ToString());
                return;
            }

            if (giftSendResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_Failed"));
                return;
            }
            else if (giftSendResult[0, 0].oContent.Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "GGV_Code_Success"));
                _ServerIP = null;
                groupBox2.Visible = false;
                txtRecvUser.Clear();
                txtTitle.Clear();
                txtContent.Clear();
                txtItemName.Clear();
                ReadInfoFromDB();

                dpRR.Visible = false;
                dpRight.Dock = DockStyle.Fill;
                return;
            }
        }


    }
}