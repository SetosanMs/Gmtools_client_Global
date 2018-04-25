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
    [C_Global.CModuleAttribute("身上道具[超级乐者]", "ItemView", "身上道具", "o2jam2")]
    public partial class ItemView : Form
    {
        public ItemView()
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
            this.Text = config.ReadConfigValue("MBAF", "IV_UI_ItemView");
            this.groupBox1.Text = config.ReadConfigValue("MBAF", "IV_UI_groupBox1");
            this.btnCancel.Text = config.ReadConfigValue("MBAF", "IV_UI_btnCancel");
            this.rbtnNick.Text = config.ReadConfigValue("MBAF", "IV_UI_rbtnNick");
            this.rbtnAccount.Text = config.ReadConfigValue("MBAF", "IV_UI_rbtnAccount");
            this.btnApply.Text = config.ReadConfigValue("MBAF", "IV_UI_btnApply");
            this.lblAorN.Text = config.ReadConfigValue("MBAF", "IV_UI_lblAorN");
            this.label1.Text = config.ReadConfigValue("MBAF", "IV_UI_label1");
            this.groupBox2.Text = config.ReadConfigValue("MBAF", "IV_UI_groupBox2");
            this.label2.Text = config.ReadConfigValue("MBAF", "IV_UI_label2");
            this.label3.Text = config.ReadConfigValue("MBAF", "IV_UI_label3");
            this.btnDel.Text = config.ReadConfigValue("MBAF", "IV_UI_btnDel");
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
        private C_Global.CEnum.Message_Body[,] bodyResult = null;       //身上道具
        private C_Global.CEnum.Message_Body[,] delItemResult = null; //身上道具

        private int currSelLine = 0;    //当前选中的行
       

        private string _ServerIP = null;    //服务器ip

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
        /// 读取玩家身上道具
        /// </summary>
        private void ReadInfoFromDB()
        {
            dgBodyCotain.DataSource = null;
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
             
             */
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[1].oContent = txtAorN.Text.Trim();//rbtnAccount.Checked ? txtAorN.Text.Trim() : "";

                //messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                //messageBody[2].eName = C_Global.CEnum.TagName.O2JAM2_UserNick;
                //messageBody[2].oContent = rbtnNick.Checked ? txtAorN.Text.Trim() : "";

                lock (typeof(C_Event.CSocketEvent))
                {
                    bodyResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_AVATORLIST_QUERY, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }

                if (bodyResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    //dpInfoContain.Visible = false;

                    MessageBox.Show(bodyResult[0, 0].oContent.ToString());
                    return;
                }

                cbxServerIP.Enabled = false;
                txtAorN.Enabled = false;
                btnApply.Enabled = false;
                


                /*显示信息到列表中*/
                dgBodyCotain.DataSource = BrowseResultInfo();
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
             
             */
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_ItemCode;
                messageBody[1].oContent = int.Parse(bodyResult[currSelLine,0].oContent.ToString());

                messageBody[2].eName = CEnum.TagName.UserByID;
                messageBody[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[3].oContent = txtAorN.Text.Trim();

                lock (typeof(C_Event.CSocketEvent))
                {
                    delItemResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_ITEMSHOP_DELETE, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }

                if (delItemResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    //dpInfoContain.Visible = false;

                    MessageBox.Show(delItemResult[0, 0].oContent.ToString());
                    return;
                }

                if (delItemResult[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MBAF", "IV_Code_Failed"));
                    //MessageBox.Show("操作失败");
                    return;
                }
                else if (delItemResult[0, 0].oContent.Equals("SUCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MBAF", "IV_Code_Success"));
                    //MessageBox.Show("操作成功");
                    label3.Text = config.ReadConfigValue("MBAF", "IV_UI_label3");
                    btnDel.Enabled = false;
                    ReadInfoFromDB();
                    return;
                }

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

                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "IV_Code_ItemName"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MBAF", "IV_Code_Position"), typeof(string));

                for (int i = 0; i < bodyResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow[config.ReadConfigValue("MBAF", "IV_Code_ItemName")] = bodyResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MBAF", "IV_Code_Position")] = ToPosString(int.Parse(bodyResult[i, 3].oContent.ToString()));

                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }


        private string ToPosString(int posNum)
        {
            string posString = null;

            //switch (posNum)
            //{
            //    case 1:
            //        posString = "头";
            //        break;
            //    case 2:
            //        posString = "头发";
            //        break;
            //    case 4:
            //        posString = "上身";
            //        break;
            //    case 8:
            //        posString = "下身";
            //        break;
            //    case 16:
            //        posString = "手";
            //        break;
            //    case 32:
            //        posString = "脚";
            //        break;
            //    case 64:
            //        posString = "面具";
            //        break;
            //    case 128:
            //        posString = "耳环";
            //        break;
            //    case 256:
            //        posString = "项链";
            //        break;
            //    case 512:
            //        posString = "手表";
            //        break;
            //    case 1024:
            //        posString = "乐器";
            //        break;
            //}

            switch (posNum)
            {
                case 1:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_head");
                    break;
                case 2:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_hair");
                    break;
                case 4:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_upper");
                    break;
                case 8:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_lower");
                    break;
                case 16:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_hand");
                    break;
                case 32:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_leg");
                    break;
                case 64:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_mask");
                    break;
                case 128:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_earring");
                    break;
                case 256:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_necklace");
                    break;
                case 512:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_watch");
                    break;
                case 1024:
                    posString = config.ReadConfigValue("MBAF", "IV_Code_instruments");
                    break;
            }

            return posString;
        }

        #endregion

        private void ItemView_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            label3.Text = config.ReadConfigValue("MBAF", "IV_UI_label3");
            btnDel.Enabled = false;

            InitializeServerIP();

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cbxServerIP.Text == "" || cbxServerIP.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "IV_Code_SelectServer"));
                cbxServerIP.Focus();
                return;
            }

            if (txtAorN.Text == "" || txtAorN.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "IV_Code_Input").Replace("{Nick}", lblAorN.Text.Substring(0, (lblAorN.Text.Length - 1))));
                //MessageBox.Show("请输入" + lblAorN.Text.Substring(0, (lblAorN.Text.Length - 1)));
                txtAorN.Focus();
                return;
            }

            label3.Text = config.ReadConfigValue("MBAF", "IV_UI_label3");
            btnDel.Enabled = false;

            _ServerIP = null;
            ReadInfoFromDB();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
             
             */
        }

        private void rbtnNick_CheckedChanged(object sender, EventArgs e)
        {
            lblAorN.Text = config.ReadConfigValue("MBAF", "IV_UI_rbtnNick");
        }

        private void rbtnAccount_CheckedChanged(object sender, EventArgs e)
        {
            lblAorN.Text = config.ReadConfigValue("MBAF", "IV_UI_rbtnname");
        }

        private void dgBodyCotain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                currSelLine = e.RowIndex;
                if (currSelLine != -1)
                {
                    btnDel.Enabled = true;
                    label3.Text = config.ReadConfigValue("MBAF", "IV_UI_label3") + bodyResult[currSelLine, 1].oContent;
                }
            }
            catch
            {
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(config.ReadConfigValue("MBAF", "IV_Code_ComfirmDeletion"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _ServerIP = null;
                DelItem();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            label3.Text = config.ReadConfigValue("MBAF", "IV_UI_label3");
            btnDel.Enabled = false;
            txtAorN.Enabled = true;
            txtAorN.Clear();
            cbxServerIP.Enabled = true;
            dgBodyCotain.DataSource = null;
            btnApply.Enabled = true;
            _ServerIP = null;

        }

        private void dgBodyCotain_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            needReLoad = true;
        }

        private void dgBodyCotain_MouseUp(object sender, MouseEventArgs e)
        {
            if (needReLoad)
            {
                dgBodyCotain.DataSource = BrowseResultInfo();
                needReLoad = false;
            }
        }
    }
}