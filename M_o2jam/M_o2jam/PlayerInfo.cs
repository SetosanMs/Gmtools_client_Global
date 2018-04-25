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
    [C_Global.CModuleAttribute("玩家角色信息管理", "PlayerInfo", "玩家角色信息管理", "o2jam")]
    public partial class PlayerInfo : Form
    {
        public PlayerInfo()
        {
            InitializeComponent();
        }

        #region 变量
        private CSocketEvent m_ClientEvent = null;
        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        C_Global.CEnum.Message_Body[,] accountResult = null;    //帐号信息
        C_Global.CEnum.Message_Body[,] updateResult = null;    //帐号信息

        string _ServerIP = null;    //服务器ip
        int dgSelectRow = -1;       //datagrid选择的行

        DataTable dgTable = new DataTable();
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

                this.backgroundWorkerReadInfoFromDB.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                //}

                //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                //    return;
                //}

                ///*
                // * 如果有数据，则设置默认的选种行为第一行
                // */
                //dgSelectRow = 0;

                //dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源
                //dpDai.Visible = true;                          //显示datagrid容器
                //dpText.Visible = true;                         //显示文本提示
            }
            catch
            {
            }
        }



        /// <summary>
        /// 修改信息
        /// </summary>
        private void WriteInfoToDB()
        {
            try
            {
                string currUserAccount = txtAorN.Text.ToString();
                btnModiOK.Enabled = false;
                Cursor = Cursors.WaitCursor;
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[11];
               
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.o2jam_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.o2jam_USER_INDEX_ID;
                messageBody[1].oContent = int.Parse(accountResult[dgSelectRow,0].oContent.ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.o2jam_GEM;
                messageBody[2].oContent = int.Parse(txtG.Text);

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.o2jam_Level;
                messageBody[3].oContent = int.Parse(txtLevel.Text);

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.o2jam_Exp;
                messageBody[4].oContent = int.Parse(txtExp.Text);

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.o2jam_Battle;
                messageBody[5].oContent = int.Parse(txtBattle.Text);

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.o2jam_Draw;
                messageBody[6].oContent = int.Parse(txtDraw.Text);

                messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[7].eName = C_Global.CEnum.TagName.o2jam_Win;
                messageBody[7].oContent = int.Parse(txtWin.Text);

                messageBody[8].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[8].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[8].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[9].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[9].eName = C_Global.CEnum.TagName.o2jam_UserID;
                messageBody[9].oContent = accountResult[dgSelectRow, 1].oContent.ToString();

                messageBody[10].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[10].eName = C_Global.CEnum.TagName.o2jam_Lose;
                messageBody[10].oContent = int.Parse(txtLose.Text);

                this.backgroundWorkerWriteInfoToDB.RunWorkerAsync(messageBody);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    updateResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_CHARACTERINFO_UPDATE, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, messageBody);
                //}

                //if (updateResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(updateResult[0, 0].oContent.ToString());
                //    return;
                //}

                //if (updateResult[0, 0].oContent.ToString().Equals("SUCESS"))
                //{

                //    dpEdit.Visible = false;

                //    ReadInfoFromDB();

                //    MessageBox.Show("更新成功");
                //    return;
                //}

                //if (updateResult[0, 0].oContent.ToString().Equals("FAILURE"))
                //{
                //    dpEdit.Visible = false;

                //    MessageBox.Show("更新失败");
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

                dgTable.Columns.Add("帐号", typeof(string));
                dgTable.Columns.Add("昵称", typeof(string));
                dgTable.Columns.Add("性别", typeof(string));
                dgTable.Columns.Add("G币", typeof(string));
                dgTable.Columns.Add("M币", typeof(string));
                dgTable.Columns.Add("等级", typeof(string));
                dgTable.Columns.Add("经验", typeof(string));
                dgTable.Columns.Add("比赛次数", typeof(string));
                dgTable.Columns.Add("胜利次数", typeof(string));
                dgTable.Columns.Add("平局次数", typeof(string));
                dgTable.Columns.Add("失败次数", typeof(string));

                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    dgRow["帐号"] = accountResult[i, 1].oContent.ToString();
                    dgRow["昵称"] = accountResult[i, 2].oContent.ToString();
                    dgRow["性别"] = accountResult[i, 3].oContent.ToString() == "1" ? "男" : "女";
                    dgRow["G币"] = accountResult[i, 11].oContent.ToString();
                    dgRow["M币"] = accountResult[i, 12].oContent.ToString();
                    dgRow["等级"] = accountResult[i, 4].oContent.ToString();
                    dgRow["经验"] = accountResult[i, 5].oContent.ToString();
                    dgRow["比赛次数"] = accountResult[i, 6].oContent.ToString();
                    dgRow["胜利次数"] = accountResult[i, 7].oContent.ToString();
                    dgRow["平局次数"] = accountResult[i, 8].oContent.ToString();
                    dgRow["失败次数"] = accountResult[i, 9].oContent.ToString();

                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }
        #endregion

        private void PlayerInfo_Load(object sender, EventArgs e)
        {
            dpDai.Visible = false;
            dpText.Visible = false;
            dpEdit.Visible = false;

            InitializeServerIP();
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            chkNick.Checked = false;
            lblNickOrAccount.Text = "玩家帐号：";
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            chkAccount.Checked = false;
            lblNickOrAccount.Text = "玩家昵称：";
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

            dpDai.Visible = false;
            dpText.Visible = false;
            dpEdit.Visible = false;

            #region IP检索
            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion


            ReadInfoFromDB();
        }

        private void btnModiCancel_Click(object sender, EventArgs e)
        {
            dpEdit.Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dpDai.Visible = false;
            dpText.Visible = false;
            dpEdit.Visible = false;

            txtAorN.Text = "";
            chkAccount.Checked = true;
            chkNick.Checked = false;
            lblNickOrAccount.Text = "玩家帐号：";
            dgAccountInfo.DataSource = null;

        }

        private void dgAccountInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgSelectRow = e.RowIndex;
        }

        private void linkModi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtNick.Text = accountResult[dgSelectRow, 2].oContent.ToString();
            txtG.Text = accountResult[dgSelectRow, 11].oContent.ToString();
            txtLevel.Text = accountResult[dgSelectRow, 4].oContent.ToString();
            txtExp.Text = accountResult[dgSelectRow, 5].oContent.ToString();
            txtBattle.Text = accountResult[dgSelectRow, 6].oContent.ToString();
            txtWin.Text = accountResult[dgSelectRow, 7].oContent.ToString();
            txtDraw.Text = accountResult[dgSelectRow, 8].oContent.ToString();
            txtLose.Text = accountResult[dgSelectRow, 9].oContent.ToString();

            dpEdit.Visible = true;
        }

        private void btnModiOK_Click(object sender, EventArgs e)
        {
            WriteInfoToDB();
        }

        private void backgroundWorkerReadInfoFromDB_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerReadInfoFromDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            Cursor = Cursors.Default;
            if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(accountResult[0, 0].oContent.ToString());
                return;
            }

            /*
             * 如果有数据，则设置默认的选种行为第一行

             */
            dgSelectRow = 0;

            dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源

            dpDai.Visible = true;                          //显示datagrid容器
            dpText.Visible = true;                         //显示文本提示
        }

        private void backgroundWorkerWriteInfoToDB_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                updateResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM_CHARACTERINFO_UPDATE, C_Global.CEnum.Msg_Category.O2JAM_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerWriteInfoToDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            btnModiOK.Enabled = true;
            if (updateResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(updateResult[0, 0].oContent.ToString());
                return;
            }

            if (updateResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {

                dpEdit.Visible = false;

                ReadInfoFromDB();

                MessageBox.Show("更新成功");
                return;
            }

            if (updateResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                dpEdit.Visible = false;

                MessageBox.Show("更新失败");
                return;
            }
        }
    }
}