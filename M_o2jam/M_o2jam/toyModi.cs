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
    [C_Global.CModuleAttribute("玩家身上/礼物合装备管理", "toyModi", "玩家身上/礼物合装备管理", "o2jam")]
    public partial class toyModi : Form
    {
        public toyModi()
        {
            InitializeComponent();
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;
        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        C_Global.CEnum.Message_Body[,] toysResult = null;    //帐号信息
        
        C_Global.CEnum.Message_Body[,] equipInfoResult = null;    //帐号信息

        C_Global.CEnum.Message_Body[,] delEquipResult = null;    //帐号信息
        string _ServerIP = null;    //服务器ip
        int dgSelectColumn = -1;       //datagrid选择的列

        DataTable dgTable = new DataTable();

        NowView nowView = NowView.EQUIP;


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
                string currUserAccount = txtAorN.Text.ToString();
                btnSearch.Enabled = false;
                Cursor = Cursors.WaitCursor;
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.o2jam_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.o2jam_UserID;
                messageBody[1].oContent = txtAorN.Text;

                this.backgroundWorkerReadInfoFromDB.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    toysResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_ITEM_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                //}

                //if (toysResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(toysResult[0, 0].oContent.ToString());
                //    return;
                //}

                //if (nowView == NowView.EQUIP)
                //{
                //    dgInfos.DataSource = BrowseResultInfo();
                //}
                //else
                //{
                //    dgInfos.DataSource = BrowseBagInfo();
                //}
                //tabControl1.Visible = true;

                ////dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源
                ////dpDai.Visible = true;                          //显示datagrid容器
                ////dpText.Visible = true;                         //显示文本提示
            }
            catch
            {
            }
        }

        /// <summary>
        /// 读取装备信息
        /// </summary>
        private void ReadEuipInfo(int equipID, int equipPos)
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.o2jam_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.o2jam_ITEM_INDEX_ID;
                messageBody[1].oContent = equipID;

                lock (typeof(C_Event.CSocketEvent))
                {
                    equipInfoResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_ITEMNAME_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                }

                
                if (equipInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(equipInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (nowView == NowView.EQUIP)
                {
                    lblPos.Text = "装备" + equipPos.ToString();
                }
                else
                {
                    lblPos.Text = "礼物包" + equipPos.ToString();
                }
                lblEquipName.Text = equipInfoResult[0, 1].oContent.ToString();

                ShowEdit();
            }
            catch
            {
            }
        }


        /// <summary>
        /// 读取装备信息
        /// </summary>
        private void DelEquipInPos(int equipID, int equipPos)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.o2jam_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.o2jam_ITEM_INDEX_ID;
                messageBody[1].oContent = equipID;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.o2jam_POSITION;
                messageBody[2].oContent = equipPos;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.o2jam_TypeFlag;
                messageBody[4].oContent = nowView == NowView.EQUIP ? 1 : 2; //１为ｅｑｕｉｐ删除，２为ｂａｇ删除

                
                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.o2jam_USER_INDEX_ID;
                messageBody[5].oContent = int.Parse(toysResult[0,0].oContent.ToString());

                this.backgroundWorkerDelEquipInPos.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    delEquipResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_ITEM_UPDATE, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                //}


                //if (delEquipResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(delEquipResult[0, 0].oContent.ToString());
                //    return;
                //}

                //if (delEquipResult[0, 0].oContent.ToString().Equals("FAILURE"))
                //{
                //    HideEdit();
                //    MessageBox.Show("删除装备失败");

                //    return;
                //}

                //if (delEquipResult[0, 0].oContent.ToString().Equals("SUCESS"))
                //{
                //    HideEdit();
                //    linkView.Enabled = false;
                //    dgSelectColumn = -1;
                //    ReadInfoFromDB();
                //    MessageBox.Show("删除装备成功");
                    
                //    return;
                //}

                
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



                DataRow dgRow = dgTable.NewRow();
                for (int i = 1; i < 17; i++)
                {
                    dgTable.Columns.Add("装备" + i, typeof(string));

                    

                    if (toysResult[0, i].eName != CEnum.TagName.o2jam_ITEM_INDEX_ID)
                    {
                        dgRow["装备" + i] = toysResult[0, i].oContent.ToString() == "0" ? "空" : "满";
                    }

                    
                }
                dgTable.Rows.Add(dgRow);
            }
            catch(Exception e)
            {
            }
            return dgTable;
        }


        /// <summary>
        /// 将返回数据转装成DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseBagInfo()
        {
            try
            {
                dgTable.Columns.Clear();       //清空头信息
                dgTable.Rows.Clear();          //清空行记录



                DataRow dgRow = dgTable.NewRow();
                for (int i = 1; i < 31; i++)
                {
                    dgTable.Columns.Add("包裹" + i, typeof(string));



                    if (toysResult[0, i].eName != CEnum.TagName.o2jam_ITEM_INDEX_ID)
                    {
                        dgRow["包裹" + i] = toysResult[0, i + 16].oContent.ToString() == "0" ? "空" : "满";
                    }


                }
                dgTable.Rows.Add(dgRow);
            }
            catch
            {
            }
            return dgTable;
        }

        private void ShowEdit()
        {
            label2.Visible = true;
            dividerPanel6.Visible = true;
            label3.Visible = true;
            lblPos.Visible = true;
            label4.Visible = true;
            lblEquipName.Visible = true;
            lnkDel.Visible = true;
        }

        private void HideEdit()
        {
            label2.Visible = false;
            dividerPanel6.Visible = false;
            label3.Visible = false;
            lblPos.Visible = false;
            label4.Visible = false;
            lblEquipName.Visible = false;
            lnkDel.Visible = false;
        }
        #endregion

        private void toyModi_Load(object sender, EventArgs e)
        {
            HideEdit();
            tabControl1.Visible = false;

            InitializeServerIP();
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            lblAorN.Text = "玩家帐号：";
            chkNick.Checked = false;
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            lblAorN.Text = "玩家昵称";
            chkAccount.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region 内容检测
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show("请选择服务器");
                return;
            }
            /*
            if (!chkAccount.Checked && !chkNick.Checked)
            {
                MessageBox.Show("请选择一种查询方式：\n1.玩家帐号\n2.玩家昵称");
                return;
            }
            */
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

            dgInfos.DataSource = null;

            ReadInfoFromDB();
        }

        private void dgInfos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HideEdit();
            try
            {
                dgSelectColumn = e.ColumnIndex + 1;
                if (dgInfos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "空")
                {
                    linkView.Enabled = false;
                }
                else
                {
                    linkView.Enabled = true;

                }
            }
            catch
            {
            }
        }

        private void linkView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int equipID = 0;
            if (nowView == NowView.BAG)
            {
                int bagColum = dgSelectColumn + 16;
                equipID = int.Parse(toysResult[0, bagColum].oContent.ToString());
            }
            else
            {
                equipID = int.Parse(toysResult[0, dgSelectColumn].oContent.ToString());
            }
            ReadEuipInfo(equipID, dgSelectColumn);
        }

        private void lnkDel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("确认删除？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
            {
                int equipID = 0;
                if (nowView == NowView.BAG)
                {
                    int bagColum = dgSelectColumn + 16;
                    equipID = int.Parse(toysResult[0, bagColum].oContent.ToString());
                }
                else
                {
                    equipID = int.Parse(toysResult[0, dgSelectColumn].oContent.ToString());
                }
                DelEquipInPos(equipID, dgSelectColumn);
            }

            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            txtAorN.Clear();
            HideEdit();
            dgInfos.DataSource = null;
        }

        private void itcBox_ITC_CLICIK(object sender)
        {
            nowView = NowView.BAG;
            dgSelectColumn = -1;
            linkView.Enabled = false;
            itcBody.ITXT_ForeColor = System.Drawing.Color.Black;
            itcBox.ITXT_ForeColor = System.Drawing.Color.Red;
            dgInfos.DataSource = null;
            HideEdit();
            dgInfos.DataSource = BrowseBagInfo();
        }

        private void itcBody_ITC_CLICIK(object sender)
        {
            nowView = NowView.EQUIP;
            dgSelectColumn = -1;
            linkView.Enabled = false;
            itcBody.ITXT_ForeColor = System.Drawing.Color.Red;
            itcBox.ITXT_ForeColor = System.Drawing.Color.Black;
            dgInfos.DataSource = null;
            HideEdit();
            dgInfos.DataSource = BrowseResultInfo();

        }

        private void backgroundWorkerReadInfoFromDB_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                toysResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_ITEM_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReadInfoFromDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            Cursor = Cursors.Default;
            if (toysResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(toysResult[0, 0].oContent.ToString());
                return;
            }

            if (nowView == NowView.EQUIP)
            {
                dgInfos.DataSource = BrowseResultInfo();
            }
            else
            {
                dgInfos.DataSource = BrowseBagInfo();
            }
            tabControl1.Visible = true;

            //dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源

            //dpDai.Visible = true;                          //显示datagrid容器
            //dpText.Visible = true;                         //显示文本提示
        }

        private void backgroundWorkerDelEquipInPos_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                delEquipResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_ITEM_UPDATE, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerDelEquipInPos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;

            if (delEquipResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(delEquipResult[0, 0].oContent.ToString());
                return;
            }

            if (delEquipResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                HideEdit();
                MessageBox.Show("删除装备失败");

                return;
            }

            if (delEquipResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                HideEdit();
                linkView.Enabled = false;
                dgSelectColumn = -1;
                ReadInfoFromDB();
                MessageBox.Show("删除装备成功");

                return;
            }
        }
    }

    enum NowView
    {
        EQUIP,
        BAG
    }
}