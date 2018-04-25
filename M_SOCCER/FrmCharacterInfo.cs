using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using C_Global;
using C_Event;

using Language;

namespace M_SOCCER
{
    [C_Global.CModuleAttribute("玩家信息查询", "FrmCharacterInfo", "劲爆足球", "soccer")]
    public partial class FrmCharacterInfo : Form
    {
        public FrmCharacterInfo()
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
            this.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_FrmCharacterInfo");
            this.label8.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_label8");
            this.label7.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_label7");
            this.label6.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_label6");
            this.groupBox1.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_groupBox1");
            this.chkNick.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_chkNick");
            this.chkAllPlayer.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_chkAllPlayer");
            this.chkAccount.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_chkAccount");
            this.label4.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_label4");
            this.btnCancel.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_btnCancel");
            this.btnSearch.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_btnSearch");
            this.lblIDOrNick.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_lblIDOrNick");
            this.label1.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_label1");
            this.label2.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_label2");
            this.btnModiCancel.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_btnModiCancel");
            this.btnModiApply.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_btnModiApply");
            this.label9.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_label9");
            this.label11.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_label11"); 
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

        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        C_Global.CEnum.Message_Body[,] accountResult = null;   //帐号检索结果
        private CSocketEvent tmp_ClientEvent = null;
        string currUserAccount = null;      //在修改的玩家id
        int currSelectPSTID = 0;
        bool blChkAccount = false;
        bool blChkNick = false;
        string _ServerIP = null;    //服务器ip
        DataTable dgTable = new DataTable();

        #endregion

                /// <summary>
        /// 帐号查询　方式失效
        /// </summary>
        private void DisableAccountSearch()
        {
            //txtAccount.Clear();
            txtAccount.Enabled = false;
            chkAccount.Checked = false;
        }

        /// <summary>
        /// 昵称查询　方式失效
        /// </summary>
        private void DisableNickSearch()
        {
            //txtAccount.Clear();
            txtAccount.Enabled = false;
            chkNick.Checked = false;
        }

        /// <summary>
        /// 启用　帐号查询方式
        /// </summary>
        private void EnableAccountSearch()
        {
            lblIDOrNick.Text = config.ReadConfigValue("MSOCCER", "FCI_UI_lblIDOrNick");
            chkAccount.Checked = true;
            chkNick.Checked = false;
            chkAllPlayer.Checked = false;
            txtAccount.Enabled = true;
        }

        /// <summary>
        /// 启用　昵称查询
        /// </summary>
        private void EnableNickSearch()
        {
            lblIDOrNick.Text = config.ReadConfigValue("MSOCCER", "FBA_Code_NickName");
            chkAccount.Checked = false;
            chkNick.Checked = true;
            chkAllPlayer.Checked = false;
            txtAccount.Enabled = true;
        }

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
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_Soccer");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                this.backgroundWorkerFormLoad.RunWorkerAsync(messageBody);

                //serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                ////检测状态


                //if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                //    //Application.Exit();
                //    return;
                //}

                ////显示内容到列表


                //for (int i = 0; i < serverIPResult.GetLength(0); i++)
                //{
                //    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                //}

                //this.cbxServerIP.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void chkNick_Click(object sender, EventArgs e)
        {
            if (chkNick.Checked)
            {
                EnableNickSearch();
            }
            else
            {
                DisableNickSearch();
            }
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            if (chkAccount.Checked)
            {
                EnableAccountSearch();
            }
            else
            {
                DisableAccountSearch();
            }
        }

        private void FrmCharacterInfo_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeServerIP();
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            cboPosition.Items.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Midfield"));
            cboPosition.Items.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_GoalKeeper"));
            cboPosition.Items.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Forward"));
            cboPosition.Items.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Guard"));
            cboPosition.Items.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Other"));
            cboPosition.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region 过滤
            if (!chkAccount.Checked && !chkNick.Checked && !chkAllPlayer.Checked)
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_SearchType"));
                return;
            }
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_SelectServer"));
                return;
            }
            if ((chkAccount.Checked || chkNick.Checked) && (txtAccount.Text == null || txtAccount.Text == ""))
            {
                if (chkNick.Checked)
                {
                    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_InputNickName"));
                    return;
                }
                if (chkAccount.Checked)
                {
                    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_InputAccount"));
                    return;
                }
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

            //dpDGAccountInfo.Visible = false;    //隐藏datagrid容器
            dpNoteText.Visible = false;         //隐藏信息提示
            dgAccountInfo.DataSource = null;    //设置datagrid为空
            ReadFromAccount();

            //blChkAccount = chkAccount.Checked;  //表示是否选中帐号
            //blChkNick = chkNick.Checked;        //表示是否选中昵称
        }

        private void ReadFromAccount()
        {
            btnSearch.Enabled = false;
            Cursor = Cursors.AppStarting;
            currUserAccount = txtAccount.Text.ToString();

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            messageBody[0].oContent = _ServerIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
            messageBody[1].oContent = currUserAccount;


            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
            messageBody[2].oContent = GetCRAction();

            this.backgroundWorkerSearch.RunWorkerAsync(messageBody);

            //accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

            //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
            //    dpNoteText.Visible = false;     //隐藏信息提示
            //    dpModi.Visible = false;         //隐藏信息修改
                
            //    dgAccountInfo.DataSource = null;
            //    txtAccount.Clear();
            //    return;
            //}

            //dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源


            ////dpDataGrid.Visible = true;                          //显示datagrid容器
            //dpNoteText.Visible = true;                          //显示文本提示
        }

        private string GetCRAction()
        {
            string returnValue = "";
            if (chkAccount.Checked)
                returnValue = "uID";
            if (chkNick.Checked)
                returnValue = "cName";
            return returnValue;
        }

        private DataTable BrowseResultInfo()
        {
            try
            {
                //dgTable.Columns.Clear();       //清空头信息


                //dgTable.Rows.Clear();          //清空行记录



                dgTable = new DataTable();
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_ID"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_DeleteDate"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Account"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Role"), typeof(string));

                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_Sex"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FBA_Code_BodyType"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Position"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Gcoin"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Level"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Exp"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_TotalTimes"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Victory"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Lose"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Draw"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MSOCCER", "FCI_Code_Quit"), typeof(string));
                
                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_ID")] = accountResult[i, 1].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_DeleteDate")] = accountResult[i, 13].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Account")] = accountResult[i, 0].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Role")] = accountResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_Sex")] = accountResult[i, 3].oContent.ToString() == "F" ? config.ReadConfigValue("MSOCCER", "FBA_Code_Female") : config.ReadConfigValue("MSOCCER", "FBA_Code_Male");
                    dgRow[config.ReadConfigValue("MSOCCER", "FBA_Code_BodyType")] = Returnsex( accountResult[i,14].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Position")] = Returnpostion(accountResult[i, 4].oContent.ToString());
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Gcoin")] = accountResult[i, 5].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Level")] = accountResult[i, 6].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Exp")] = accountResult[i, 7].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_TotalTimes")] = accountResult[i, 8].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Victory")] = accountResult[i, 9].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Lose")] = accountResult[i, 10].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Draw")] = accountResult[i, 12].oContent.ToString();
                    dgRow[config.ReadConfigValue("MSOCCER", "FCI_Code_Quit")] = accountResult[i, 11].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }
        private string Returnpostion(string postion)
        {
            string StrPostion = "";
            switch (postion)
            {
                case "0":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Midfield");
                    break;
                case "1":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_GoalKeeper");
                    break;
                case "2":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Forward");
                    break;
                case "3":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Guard");
                    break;
                default:
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Other");
                    break;
            }
            return StrPostion;
        }
        private string Returnsex(string strsex)
        {
            string StrPostion = "";
            switch (strsex)
            {
                case "0":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_FatGirl");
                    break;
                case "1":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_HighGirl");
                    break;
                case "2":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_NormalGirl");
                    break;
                case "7":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_NormalBoy");
                    break;
                case "8":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_FatBoy");
                    break;
                case "9":
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_HighBoy");
                    break;
                default:
                    StrPostion = config.ReadConfigValue("MSOCCER", "FBA_Code_Other");
                    break;
            }
            return StrPostion;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //dpDataGrid.Visible = false;     //隐藏datagrid容器 
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            dgAccountInfo.DataSource = null;
            txtAccount.Clear();
        }

        private void btnModiApply_Click(object sender, EventArgs e)

        {
            if (txtlevel.Text == null || txtlevel.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_Msglevel"));
                return;
            }
            if (txtexp.Text == null || txtexp.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_MsgExp"));
                return;
            }
            if (TxtCharname.Text == null || TxtCharname.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_MsgNickname"));
                return;
            }
            if (MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_ConfirmDeletion").Replace("{Name}", txtPlayerID.Text.Trim()), config.ReadConfigValue("MSOCCER", "FCI_Code_Warning"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (txtG.Text == null || txtG.Text == "")
                {
                    txtG.Text = "0";
                }

                //修改信息
                ModiUserInfo();
            }
        }

        private void btnModiCancel_Click(object sender, EventArgs e)
        {
            dpNoteText.Visible = false;     //隐藏信息提示
            dpModi.Visible = false;         //隐藏信息修改
            txtPlayerID.Clear();
            TxtCharname.Clear();
        }
        private void ModiUserInfo()
        {
            btnModiApply.Enabled = false;
            Cursor = Cursors.AppStarting;
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[8];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
                messageBody[1].oContent = _ServerIP;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.Soccer_charidx;
                messageBody[2].oContent = currSelectPSTID;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.Soccer_charname;
                messageBody[3].oContent = TxtCharname.Text.Trim();

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.Soccer_charpos;
                messageBody[4].oContent = 9;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.Soccer_charpoint;
                messageBody[5].oContent = int.Parse(txtG.Text.Trim());

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.Soccer_charlevel;
                messageBody[6].oContent = int.Parse(txtlevel.Text.Trim());

                messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[7].eName = C_Global.CEnum.TagName.Soccer_charexp;
                messageBody[7].oContent = int.Parse(txtexp.Text.Trim());

                this.backgroundWorkerBtnOK.RunWorkerAsync(messageBody);

                //C_Global.CEnum.Message_Body[,] modiResult = null;
                //modiResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARPOINT_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

                //if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_Modify").Replace("{Name}", TxtCharname.Text.Trim()));

                //    ReadFromAccount();          //刷新列表
                //    dpModi.Visible = false;     //隐藏修改容器
                //    return;
                //}

                //if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(modiResult[0, 0].oContent.ToString());
                //    return;
                //}
            }
            catch
            {
            }
        }
        private void txtG_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtG.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtG.Text = rx.Replace(txt, "");
        }

        private void txtG_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = txtG.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtG.Text = rx.Replace(txt, "");
        }

        private void dgAccountInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //当前用户
                currSelectPSTID = int.Parse(dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_ID")].ToString());
                txtPlayerID.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_Account")].ToString().Trim();
                TxtCharname.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FBA_Code_Role")].ToString().Trim();
                //G币
                txtG.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FCI_Code_Gcoin")].ToString().Trim();
                //经验
                txtexp.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FCI_Code_Exp")].ToString().Trim();
                //级别
                txtlevel.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FCI_Code_Level")].ToString().Trim();
                cboPosition.Text = dgTable.Rows[e.RowIndex][config.ReadConfigValue("MSOCCER", "FCI_Code_Position")].ToString().Trim();
                //显示修改容器
                dpModi.Visible = true;
            }
            catch
            {
            }
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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

            this.cbxServerIP.SelectedIndex = 0;
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(serverIPResult, cbxServerIP.Text));
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                accountResult = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            this.Cursor = Cursors.Default;
            if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(accountResult[0, 0].oContent.ToString());
                dpNoteText.Visible = false;     //隐藏信息提示
                dpModi.Visible = false;         //隐藏信息修改

                dgAccountInfo.DataSource = null;
                txtAccount.Clear();
                return;
            }

            dgAccountInfo.DataSource = BrowseResultInfo();      //设置datagrid数据源


            //dpDataGrid.Visible = true;                          //显示datagrid容器
            dpNoteText.Visible = true;                          //显示文本提示

            blChkAccount = chkAccount.Checked;  //表示是否选中帐号
            blChkNick = chkNick.Checked;        //表示是否选中昵称
        }

        private void backgroundWorkerBtnOK_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = tmp_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARINFO_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerBtnOK_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnModiApply.Enabled = true;
            Cursor = Cursors.Default;
            C_Global.CEnum.Message_Body[,] modiResult = (C_Global.CEnum.Message_Body[,])e.Result;
            if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_Modify").Replace("{Name}", txtPlayerID.Text.Trim()));

                ReadFromAccount();          //刷新列表
                dpModi.Visible = false;     //隐藏修改容器
                return;
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSOCCER", "FCI_Code_Modify1").Replace("{Name}", TxtCharname.Text.Trim()));
            }

            if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(modiResult[0, 0].oContent.ToString());
                return;
            }
        }

        private void txtlevel_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtlevel.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtlevel.Text = rx.Replace(txt, "");
        }

        private void txtlevel_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = txtlevel.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtlevel.Text = rx.Replace(txt, "");
        }

        private void txtexp_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = txtexp.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtexp.Text = rx.Replace(txt, "");
        }

        private void txtexp_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = txtexp.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            txtexp.Text = rx.Replace(txt, "");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxServerIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_Soccer.GetItemAddr(serverIPResult, cbxServerIP.Text));
        }


    }
}
