using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_o2jam
{
    [C_Global.CModuleAttribute("道具赠送", "NewToy", "道具赠送", "o2jam")]
    public partial class NewToy : Form
    {
        public NewToy()
        {
            InitializeComponent();
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;
        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        C_Global.CEnum.Message_Body[,] accountResult = null;    //帐号信息
        C_Global.CEnum.Message_Body[,] itemResult = null;    //帐号信息
        C_Global.CEnum.Message_Body[,] sendResult = null;    //帐号信息
        C_Global.CEnum.Message_Body[,] giftsResult = null;      //礼物列表
        C_Global.CEnum.Message_Body[,] delResult = null;      //礼物列表

        DataTable dgTable = new DataTable();

        string _ServerIP = null;    //服务器ip
        int dgSelectRow = -1;       //datagrid选择的行
        int user_index_id = -1;     //帐号ｉｄ
        
        int user_sex = 0;
        int MCash = 0;              //道具Ｍ币价格
        int Gem = 0;                //道具Ｇ币价格

        int giftDgSelectRow = -1;   //礼物列表内选中的行


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
              
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.o2jam_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.o2jam_UserID;
                messageBody[1].oContent = chkAccount.Checked ? txtAorN.Text : "";


                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.o2jam_UserNick;
                messageBody[2].oContent = chkNick.Checked ? txtAorN.Text : "";

                lock (typeof(C_Event.CSocketEvent))
                {
                    accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                }
                dpContainerChk.Visible = true;

                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    HideControls();
                    lblResultText.Text = accountResult[0, 0].oContent.ToString() + "\n\n您不能继续下步操作\n\n请选择其他获赠帐号";

                    return;
                }

                cbxServerIP.Enabled = false;
                txtAorN.Enabled = false;
                btnAorNChk.Enabled = false;

                

                lblResultText.Text = "帐号" + txtAorN.Text + "可以使用。\n\n请继续下步操作完成道具赠送";

                user_index_id = int.Parse(accountResult[0, 0].oContent.ToString());
                user_sex = int.Parse(accountResult[0, 3].oContent.ToString());

                gbxGiftList.Visible = true; //显示玩家的礼物列表
                ReadUserGiftFromDB();

                ShowControls();
            }
            catch
            {
            }
        }


        /// <summary>
        /// 读取玩家礼物信息
        /// </summary>
        private void ReadUserGiftFromDB()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.o2jam_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.o2jam_USER_INDEX_ID;
                messageBody[1].oContent = user_index_id;

                lock (typeof(C_Event.CSocketEvent))
                {
                    giftsResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_GIFTBOX_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                }
                if (giftsResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    gbxGiftList.Visible = false;
                    return;
                }

                dgItemsList.DataSource = BrowseResultInfo();
                gbxGiftList.Visible = true;
                
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

                dgTable.Columns.Add("道具名称", typeof(string));
                dgTable.Columns.Add("G币价格", typeof(string));
                dgTable.Columns.Add("M币价格", typeof(string));
                dgTable.Columns.Add("赠送人", typeof(string));
                dgTable.Columns.Add("赠送时间", typeof(string));


                for (int i = 0; i < giftsResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow["道具名称"] = giftsResult[i, 1].oContent.ToString();
                    dgRow["G币价格"] = giftsResult[i, 2].oContent.ToString();
                    dgRow["M币价格"] = giftsResult[i, 3].oContent.ToString();
                    dgRow["赠送人"] = giftsResult[i, 4].oContent.ToString();
                    dgRow["赠送时间"] = giftsResult[i, 5].oContent.ToString();

                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
            
        }
        

        /// <summary>
        /// 道具查询
        /// </summary>
        private void ReadItems()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.o2jam_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.o2jam_ITEM_NAME;
                messageBody[1].oContent = txtItemName.Text;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.o2jam_Sex;
                messageBody[2].oContent = user_sex;

                lock (typeof(C_Event.CSocketEvent))
                {
                    itemResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_ITEMDATA_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                }
                if (itemResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(itemResult[0, 0].oContent.ToString());
                    return;
                }

                for (int i = 0; i < itemResult.GetLength(0); i++)
                {
                    lvItems.Items.Add(itemResult[i, 1].oContent.ToString());
                    lvItems.Items[i].Tag = itemResult[i, 0].oContent.ToString();
                    //显示内容到列表
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 道具查询
        /// </summary>
        private void SendGift()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[7];
                
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.o2jam_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.o2jam_WriteDate;
                messageBody[1].oContent = (dtpExpire.Text == "1个月" ? 1 : (dtpExpire.Text == "3个月" ? 3 : 0));

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.o2jam_ITEM_INDEX_ID;
                messageBody[2].oContent = int.Parse(itemResult[dgSelectRow,0].oContent.ToString());

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.o2jam_USER_INDEX_ID;
                messageBody[3].oContent = user_index_id;

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.o2jam_MCASH;
                messageBody[4].oContent = MCash;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.o2jam_GEM;
                messageBody[5].oContent = Gem;

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[6].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                lock (typeof(C_Event.CSocketEvent))
                {
                    sendResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_GIFTBOX_CREATE_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                }
                if (sendResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(sendResult[0, 0].oContent.ToString());
                    return;
                }

                if (sendResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    //HideControls();
                    cbxServerIP.Enabled = true;
                    txtAorN.Enabled = true;
                    btnAorNChk.Enabled = true;

                    //dpContainerChk.Visible = false;
                    //txtAorN.Clear();

                    //accountResult = null;    //帐号信息
                    //itemResult = null;    //帐号信息
                    sendResult = null;    //帐号信息
                    giftsResult = null;

                    //txtItemName.Clear();
                    //lvItems.Items.Clear();


                    ReadUserGiftFromDB();

                    MessageBox.Show("赠送成功");
                    return;
                }

                if (sendResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show("赠送失败");
                    return;
                }

            }
            catch
            {
            }
        }


        /// <summary>
        /// 道具查询
        /// </summary>
        private void DelGift()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.o2jam_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.o2jam_ITEM_INDEX_ID;
                messageBody[1].oContent = int.Parse(giftsResult[giftDgSelectRow,0].oContent.ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.o2jam_USER_INDEX_ID;
                messageBody[2].oContent = user_index_id;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                lock (typeof(C_Event.CSocketEvent))
                {
                    delResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_GIFTBOX_DELETE, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                }
                if (delResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(delResult[0, 0].oContent.ToString());
                    return;
                }

                if (delResult[0, 0].oContent.ToString().Equals("SUCESS"))
                {
                    btnDel.Enabled = false;
                    giftDgSelectRow = -1;

                    ReadUserGiftFromDB();
                    MessageBox.Show("删除成功");
                    return;
                }

                if (delResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show("删除失败");
                    return;
                }

            }
            catch
            {
            }
        }



        private void HideControls()
        {
            gbxExpire.Visible = false;
            gbxItemChk.Visible = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;
            btnDel.Visible = false;
        }

        private void ShowControls()
        {
            gbxExpire.Visible = true;
            gbxItemChk.Visible = true;
            btnOK.Visible = true;
            btnCancel.Visible = true;
            btnDel.Visible = true;
        }

        #endregion

        private void NewToy_Load(object sender, EventArgs e)
        {
            HideControls();
            dpContainerChk.Visible = false;
            gbxGiftList.Visible = false;
            InitializeServerIP();
        }

        private void btnAorNChk_Click(object sender, EventArgs e)
        {
            #region 内容检测
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show("请选择服务器");
                return;
            }
            if (!chkAccount.Checked && !chkNick.Checked)
            {
                MessageBox.Show("请选择一种查询方式：\n1.玩家帐号\n2.玩家昵称");
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

            HideControls();
            ReadInfoFromDB();
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == null || txtItemName.Text == "")
            {
                MessageBox.Show("请输入道具名称");
                return;
            }

            itemResult = null;    //帐号信息
            lvItems.Items.Clear();
            ReadItems();
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            chkNick.Checked = false;
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            chkAccount.Checked = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgSelectRow == -1)
            {
                MessageBox.Show("请选择要赠送道具");
                return;
            }
            if (dtpExpire.Text == null || dtpExpire.Text == "")
            {
                MessageBox.Show("请选择使用期限");
                return;
            }
            //if (giftsResult  itemResult
            int itemID = int.Parse(itemResult[dgSelectRow,0].oContent.ToString());
            
            for (int i=0;i<giftsResult.GetLength(0);i++)
            {
                if (giftsResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    break;
                }
                if (itemID == int.Parse(giftsResult[i, 0].oContent.ToString()))
                {
                    MessageBox.Show("要赠送的道具已经存在，请另外选择");
                    return;
                }
                
            }
            
            SendGift();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HideControls();
            cbxServerIP.Enabled = true;
            txtAorN.Enabled = true;
            btnAorNChk.Enabled = true;
            txtAorN.Clear();
            chkAccount.Checked = true;
            chkNick.Checked = false;
            dpContainerChk.Visible = false;
            lvItems.Items.Clear();
            txtItemName.Clear();
            btnOK.Visible = false;
            btnCancel.Visible = false;
            gbxGiftList.Visible = false;

            accountResult = null;    //帐号信息
            itemResult = null;    //帐号信息
            sendResult = null;    //帐号信息
            giftsResult = null;
        }

        private void lvItems_Click(object sender, EventArgs e)
        {
            try
            {
                dgSelectRow = this.lvItems.SelectedItems[0].Index;
                MCash = int.Parse(itemResult[dgSelectRow,4].oContent.ToString());
                Gem = int.Parse(itemResult[dgSelectRow, 3].oContent.ToString());
            }
            catch
            {
                dgSelectRow = -1;
            }
        }

        private void dgItemsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            giftDgSelectRow = e.RowIndex;
            btnDel.Enabled = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (giftDgSelectRow == -1)
            {
                MessageBox.Show("请选择要删除的道具");
                return;
            }
            DelGift();
        }

        private void dgItemsList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*
            DataView dgTableView = dgTable.DefaultView;
            string AorD = dgItemsList.SortedColumn.Index.ToString() == "1" ? "asc" : "desc";
            string sortType = dgItemsList.SortedColumn.Name + " " + AorD;
            dgTableView.Sort = sortType;
            */
        }
    }
}