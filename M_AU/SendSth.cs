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

namespace M_AU
{
    [C_Global.CModuleAttribute("物品发送", "SendSth", "劲舞团", "AU")]
    public partial class SendSth : Form
    {
        public SendSth()
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
            this.Text = config.ReadConfigValue("MAU", "ST_UI_SendSth");
            this.groupBox3.Text = config.ReadConfigValue("MAU", "ST_UI_groupBox3");
            this.label2.Text = config.ReadConfigValue("MAU", "ST_UI_label2");
            this.btnItemTo.Text = config.ReadConfigValue("MAU", "ST_UI_btnItemTo");
            this.btnItemSearch.Text = config.ReadConfigValue("MAU", "ST_UI_btnItemSearch");
            this.label4.Text = config.ReadConfigValue("MAU", "ST_UI_label4");
            this.button3.Text = config.ReadConfigValue("MAU", "ST_UI_button3");
            this.groupBox2.Text = config.ReadConfigValue("MAU", "ST_UI_groupBox2");

            this.columnHeader1.Text = config.ReadConfigValue("MAU", "ST_UI_columnHeader1");
            this.columnHeader2.Text = config.ReadConfigValue("MAU", "ST_UI_columnHeader2");
            this.columnHeader3.Text = config.ReadConfigValue("MAU", "ST_UI_columnHeader3");
            this.groupBox1.Text = config.ReadConfigValue("MAU", "ST_UI_groupBox1");
            this.btnAccountTo.Text = config.ReadConfigValue("MAU", "ST_UI_btnAccountTo");
            this.label3.Text = config.ReadConfigValue("MAU", "ST_UI_label3");
            this.chkAccount.Text = config.ReadConfigValue("MAU", "ST_UI_chkAccount");
            this.btnSearch.Text = config.ReadConfigValue("MAU", "ST_UI_btnSearch");
            this.chkNick.Text = config.ReadConfigValue("MAU", "ST_UI_chkNick");
            this.lblAccOrNick.Text = config.ReadConfigValue("MAU", "ST_UI_lblAccOrNick");
            this.groupBox4.Text = config.ReadConfigValue("MAU", "ST_UI_groupBox4");
            this.columnHeader6.Text = config.ReadConfigValue("MAU", "ST_UI_columnHeader6");
            this.btnReset.Text = config.ReadConfigValue("MAU", "ST_UI_btnReset");
            this.btnConfrimToSend.Text = config.ReadConfigValue("MAU", "ST_UI_btnConfrimToSend");
            this.groupBox5.Text = config.ReadConfigValue("MAU", "ST_UI_groupBox5");
            this.columnHeader7.Text = config.ReadConfigValue("MAU", "ST_UI_columnHeader7");
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

        string _AccountServerIP = null;    //服务器ip
        string _ItemServerIP = null;    //服务器ip

        C_Global.CEnum.Message_Body[,] accountServerIPResult = null;    //ip列表信息
        C_Global.CEnum.Message_Body[,] itemServerIPResult = null;       //ip列表信息

        C_Global.CEnum.Message_Body[,] accountResult = null;    //玩家信息列表
        C_Global.CEnum.Message_Body[,] itemResult = null;       //道具信息列表
        C_Global.CEnum.Message_Body[,] temp_itemResult = null;  //道具信息列表
        C_Global.CEnum.Message_Body[,] sendItemsResult = null;  //物品赠送结果


        C_Global.CEnum.Message_Body[,] recvAccountList = null;  //获赠玩家列表
        C_Global.CEnum.Message_Body[,] toSendItemList = null;   //要赠送的道具列表

        int lstUser_SelectRow = 0;          //用户显示结果中选择的行
        int lstItemResult_SelectRow = 0;    //物品显示结果中选中的行


        string[,] user_Items = null;    //玩家与获得的道具信息
        int recvUserID = 0;             //lstRecvUsers中选中的用户id
        int recvUserSex = 0;            //当前选种的玩家的性别

        string sendReason = null;      //道具赠送理由

        int expire = 30;               //赠送道具的有效期限
        string strInfo = null;         //赠送的玩家及道具字符串信息　格式:usersn,account,nick,itemids
        SendAboutInfo about = new SendAboutInfo();  //赠送的道具的理由及时效

        /*
         * 选择玩家时列出上次分配的物品是会将其删除
         * 所以设置此开发，为的是，只有在点击物品列表是才可删除存储起来的已分配给玩家的道具id
         */
        bool enableRemove = false;      
        #endregion

        #region 函数
        /// <summary>
        /// 初始化帐号服务器列表
        /// </summary>
        public void InitializeAccountServerIP()
        {
            try
            {
                this.cbxServerIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_AU");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 2;

                lock (typeof(C_Event.CSocketEvent))
                {
                    accountServerIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                } 

                //检测状态

                if (accountServerIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    //游戏列表为空错误信息
                    //MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表

                for (int i = 0; i < accountServerIPResult.GetLength(0); i++)
                {
                    this.cbxServerIP.Items.Add(accountServerIPResult[i, 1].oContent.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 初始化道具所在服务器列表
        /// </summary>
        public void InitializeItemServerIP()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_AU");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 1;

                lock (typeof(C_Event.CSocketEvent))
                {
                    itemServerIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);
                }
                

                //检测状态

                if (itemServerIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取玩家帐号信息
        /// </summary>
        private void ReadUserInfo()
        {
            lstUserResult.Items.Clear();    //清空内容显示结果

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
            messageBody[0].oContent = _AccountServerIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.AU_ACCOUNT;
            messageBody[1].oContent = chkAccount.Checked ? txtAccount.Text.Trim() : "";
            
            /*
            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.AU_UserNick;
            messageBody[2].oContent = chkNick.Checked ? txtAccount.Text.Trim() : "";
            */

            this.backgroundWorkerSearch.RunWorkerAsync(messageBody);
            //accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _AccountServerIP).RequestResult(CEnum.ServiceKey.AU_ACCOUNT_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

            //if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(accountResult[0, 0].oContent.ToString());
            //    return;
            //}

            //cbxServerIP.Enabled = false;    //关闭服务器选择
            //for (int i = 0; i < accountResult.GetLength(0); i++)
            //{
            //    lstUserResult.Items.Add(accountResult[0, 2].oContent.ToString());
            //}
        }

        /// <summary>
        /// 赠送道具

        /// </summary>
        private void SendEquipment()
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
            messageBody[0].oContent = _ItemServerIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.AU_Reason;
            messageBody[1].oContent = about.REASON;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[2].eName = C_Global.CEnum.TagName.AU_Period;
            messageBody[2].oContent = about.EXPIRE;

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[3].eName = C_Global.CEnum.TagName.AU_ItemStyle;
            messageBody[3].oContent = strInfo;

            messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[4].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


            messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[5].eName = C_Global.CEnum.TagName.AU_Postion;
            messageBody[5].oContent = ReturnClass(cmbClass.Text.Trim()); ;

            this.backgroundWorkerSend.RunWorkerAsync(messageBody);

            //sendItemsResult = m_ClientEvent.GetSocket(m_ClientEvent, _ItemServerIP).RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_CREATE, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

            //if (sendItemsResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(sendItemsResult[0, 0].oContent.ToString());
            //    return;
            //}
            //if (sendItemsResult[0,0].oContent.ToString().ToUpper().Equals("SUCESS"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_Msgsendsucc"));

            //    /*
            //     * 清空公共变量的内容，防止下次赠送时数据错误
            //     * */
            //    _AccountServerIP = null;    //服务器ip
            //    _ItemServerIP = null;       //服务器ip
            //    //accountServerIPResult = null;    //ip列表信息
            //    //itemServerIPResult = null;       //ip列表信息
            //    accountResult = null;    //玩家信息列表
            //    itemResult = null;       //道具信息列表
            //    temp_itemResult = null;  //道具信息列表
            //    sendItemsResult = null;  //物品赠送结果

            //    lstUser_SelectRow = 0;          //用户显示结果中选择的行
            //    lstItemResult_SelectRow = 0;    //物品显示结果中选中的行
            //    user_Items = null;    //玩家与获得的道具信息
            //    recvUserID = 0;             //lstRecvUsers中选中的用户id
            //    sendReason = null;      //道具赠送理由

            //    expire = 30;               //赠送道具的有效期限
            //    strInfo = null;         //赠送的玩家及道具字符串信息　格式:usersn,account,nick,itemids
            //    about = new SendAboutInfo();  //赠送的道具的理由及时效


            //    cbxServerIP.Enabled = true;
            //    txtAccount.Clear();
            //    lstUserResult.Items.Clear();
            //    txtItemName.Clear();
            //    lstItemResult.Items.Clear();
            //    lstRecvUsers.Items.Clear();
            //    lstSendItem.Items.Clear();

            //    return;
            //}
        }

        /// <summary>
        /// 读取道具信息
        /// </summary>
        private void ReadItemInfo()
        {
            lstItemResult.Items.Clear();    //清空内容显示结果

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.AU_ServerIP;
            messageBody[0].oContent = _ItemServerIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.AU_ItemName;
            messageBody[1].oContent = txtItemName.Text.Trim();

            this.backgroundWorkerItemSearch.RunWorkerAsync(messageBody);

            //itemResult = m_ClientEvent.GetSocket(m_ClientEvent, _ItemServerIP).RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, messageBody);

            //if (itemResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(itemResult[0, 0].oContent.ToString());
            //    return;
            //}

            //cbxServerIP.Enabled = false;    //关闭服务器选择

            //#region 过滤结果中道具名相同项

            //for (int i = 0; i < itemResult.GetLength(0); i++)
            //{
            //    string toChkItemName = itemResult[i, 1].oContent.ToString().Trim();

            //    for (int j = i + 1; j < itemResult.GetLength(0); j++)
            //    {
            //        string beItemName = itemResult[j, 1].oContent.ToString().Trim();
            //        //当有相同名称的道具存在时
            //        if (toChkItemName == beItemName)
            //        {
            //            //检测到的相同记录数
            //            //将当前搜索到的记录的下条记录拉上来

            //            for (int k = j; k < itemResult.GetLength(0) - 1; k++)
            //            {
            //                //将行记录内的第二位遍历一遍

            //                for (int m = 0; m < itemResult.GetLength(1); m++)
            //                {
            //                    itemResult[k, m].eName = itemResult[k + 1, m].eName;
            //                    itemResult[k, m].eTag = itemResult[k + 1, m].eTag;
            //                    itemResult[k, m].oContent = itemResult[k + 1, m].oContent;
            //                }
            //            }
            //            temp_itemResult = new CEnum.Message_Body[itemResult.GetLength(0) - 1, itemResult.GetLength(1)];

            //            for (int n = 0; n < temp_itemResult.GetLength(0); n++)
            //            {
            //                for (int m = 0; m < temp_itemResult.GetLength(1); m++)
            //                {
            //                    temp_itemResult[n, m].eName = itemResult[n, m].eName;
            //                    temp_itemResult[n, m].eTag = itemResult[n, m].eTag;
            //                    temp_itemResult[n, m].oContent = itemResult[n, m].oContent;
            //                }
            //            }

            //            itemResult = temp_itemResult;

            //            //从上提上来的数据开始重新检测

            //            j -= 1;
            //        }
                    
            //    }
            //}
            //#endregion

            //for (int i = 0; i < itemResult.GetLength(0); i++)
            //{
            //    lstItemResult.Items.Add(itemResult[i, 1].oContent.ToString());
            //}
        }


        /// <summary>
        /// 将messagebody变量加入到该类型的群中

        /// </summary>
        /// <param name="body"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private C_Global.CEnum.Message_Body[,] PutIntoNewMsgBody(C_Global.CEnum.Message_Body[,] body,C_Global.CEnum.Message_Body[,] source,int sourcePos)
        {
            try
            {
                C_Global.CEnum.Message_Body[,] tempBody = null;

                if (body == null)
                {
                    body = new CEnum.Message_Body[1, source.GetLength(1)];
                    for (int j = 0; j < source.GetLength(1); j++)
                    {
                        body[0, j].eName = source[sourcePos, j].eName;
                        body[0, j].eTag = source[sourcePos, j].eTag;
                        body[0, j].oContent = source[sourcePos, j].oContent;
                    }
                }
                else
                {
                    tempBody = new CEnum.Message_Body[body.GetLength(0) + 1, body.GetLength(1)];
                    for (int i = 0; i < body.GetLength(0); i++)
                    {
                        for (int j = 0; j < body.GetLength(1); j++)
                        {
                            tempBody[i, j].eName = body[i, j].eName;
                            tempBody[i, j].eTag = body[i, j].eTag;
                            tempBody[i, j].oContent = body[i, j].oContent;
                        }
                    }

                    for (int m = 0; m < tempBody.GetLength(1); m++)
                    {
                        tempBody[tempBody.GetLength(0) - 1, m].eName = source[sourcePos, m].eName;
                        tempBody[tempBody.GetLength(0) - 1, m].eTag = source[sourcePos, m].eTag;
                        tempBody[tempBody.GetLength(0) - 1, m].oContent = source[sourcePos, m].oContent;
                    }
                    body = tempBody;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return body;
        }

        #endregion

        private void SendSth_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            InitializeAccountServerIP();
            InitializeItemServerIP();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region 检测


            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_Msgserver"));
                return;
            }

            if (!chkAccount.Checked && !chkNick.Checked)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_Msgsort"));
                chkAccount.Focus();
                return;
            }
            if (txtAccount.Text == null || txtAccount.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_Msgtxt"));
                txtAccount.Focus();
                return;
            }

            #endregion

            #region IP检索

            for (int i = 0; i < this.accountServerIPResult.GetLength(0); i++)
            {
                if (accountServerIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._AccountServerIP = accountServerIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion
            btnSearch.Enabled = false;
            Cursor = Cursors.AppStarting;
            
            ReadUserInfo();
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            chkNick.Checked = false;
            lblAccOrNick.Text = config.ReadConfigValue("MAU", "ST_Code_tname");
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            chkAccount.Checked = false;
            lblAccOrNick.Text = config.ReadConfigValue("MAU", "ST_Code_tnickname");
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            #region 检测

            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_Msgserver"));
                return;
            }
            if (txtItemName.Text == null || txtItemName.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_Msgitem"));
                return;
            }

            if (cmbClass.Text == null || cmbClass.Text == "")
            {
                MessageBox.Show("请选择一个道具的类别");
                return;
            }
            #endregion

            #region IP检索

            for (int i = 0; i < this.itemServerIPResult.GetLength(0); i++)
            {
                if (itemServerIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ItemServerIP = itemServerIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            btnItemSearch.Enabled = false;
            Cursor = Cursors.AppStarting;

            ReadItemInfo();




        }

        private void btnAccountTo_Click(object sender, EventArgs e)
        {
            if (lstUserResult.SelectedIndex == -1)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_player"));
                return;
            }

            if (recvAccountList != null)
            {
                for (int i = 0; i < recvAccountList.GetLength(0); i++)
                {
                    if (accountResult[lstUser_SelectRow, 0].oContent.ToString().Equals(recvAccountList[i, 0].oContent.ToString()))
                    {
                        MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_msg1"));
                        return;
                    }
                }
            }

            string[] rowInfo = new string[5];
            rowInfo[0] = accountResult[lstUser_SelectRow, 1].oContent.ToString();
            rowInfo[1] = accountResult[lstUser_SelectRow, 2].oContent.ToString();
            rowInfo[2] = accountResult[lstUser_SelectRow, 3].oContent.ToString() == "1" ? config.ReadConfigValue("MAU", "OP_Code_Msex") : config.ReadConfigValue("MAU", "OP_Code_Fsex");
            ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
            lstRecvUsers.Items.Add(mlistViewItem);
            lstRecvUsers.Items[lstRecvUsers.Items.Count - 1].Tag = accountResult[lstUser_SelectRow, 0].oContent.ToString();

            /*存储获赠者信息 recvAccountList*/
            recvAccountList = PutIntoNewMsgBody(recvAccountList, accountResult, lstUser_SelectRow);


        }

        private void lstUserResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUser_SelectRow = lstUserResult.SelectedIndex;
        }

        private void btnItemTo_Click(object sender, EventArgs e)
        {
            if(lstItemResult.SelectedIndex == -1)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_Msginputitem"));
                return;
            }

            if (toSendItemList != null)
            {
                for (int i = 0; i < toSendItemList.GetLength(0); i++)
                {
                    if (itemResult[lstItemResult_SelectRow, 0].oContent.ToString().Equals(toSendItemList[i, 0].oContent.ToString()))
                    {
                        MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_Msgitem1"));
                        return;
                    }
                }
            }
            enableRemove = false;
            string[] rowInfo = new string[2];
            rowInfo[0] = itemResult[lstItemResult_SelectRow, 1].oContent.ToString();
            rowInfo[1] = itemResult[lstItemResult_SelectRow, 2].oContent.ToString() == "1" ? config.ReadConfigValue("MAU", "OP_Code_Msex") : itemResult[lstItemResult_SelectRow, 2].oContent.ToString() == "0" ? config.ReadConfigValue("MAU", "OP_Code_Fsex") : config.ReadConfigValue("MAU", "ST_Code_sexinfo");
            ListViewItem mlistViewItem = new ListViewItem(rowInfo, -1);
            lstSendItem.Items.Add(mlistViewItem);
            lstSendItem.Items[lstSendItem.Items.Count - 1].Tag = itemResult[lstItemResult_SelectRow, 0].oContent.ToString();

            toSendItemList = PutIntoNewMsgBody(toSendItemList, itemResult, lstItemResult_SelectRow);
        }

        private void lstItemResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstItemResult_SelectRow = lstItemResult.SelectedIndex;
        }

        private void lstRecvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enableRemove = false;

                int selectIndex = this.lstRecvUsers.SelectedItems[0].Index;
                recvUserID = int.Parse(lstRecvUsers.Items[selectIndex].Tag.ToString());
                recvUserSex = int.Parse(recvAccountList[selectIndex, 3].oContent.ToString());

                /*
                 * 检测在存储的玩家及获赠道具（既user_Items）中是否存在
                 * 存在：把刀具列表中该玩家已经被钩选过的刀具选种
                 * 不存在：将道具列表中所有钩去掉
                 */

                if (user_Items == null)
                {
                    for (int j = 0; j < lstSendItem.Items.Count; j++)
                    {
                        lstSendItem.Items[j].Checked = false;
                    }
                }
                //遍历玩家获取数据信息
                for (int i = 0; i < user_Items.GetLength(0); i++)
                {
                    //检测是否该玩家的记录存在

                    if (user_Items[i, 0].Equals(recvUserID.ToString()))
                    {
                        //遍历道具列表
                        for (int j = 0; j < lstSendItem.Items.Count; j++)
                        {
                            //遍历玩家接受道具数据中的发送刀具信息

                            string[] items = user_Items[i,1].Split(new char[]{','});    //玩家接受的刀具编号


                            for (int k = 0; k < items.Length; k++)
                            {
                                if (lstSendItem.Items[j].Tag.ToString().Equals(items[k]))
                                {
                                    lstSendItem.Items[j].Checked = true;
                                    break;
                                }
                                else
                                {
                                    lstSendItem.Items[j].Checked = false;
                                }
                            }
                        }
                        i = user_Items.GetLength(0) - 1;    //跳出循环
                        break;
                    }
                    else
                    {
                        for (int j = 0; j < lstSendItem.Items.Count; j++)
                        {
                            lstSendItem.Items[j].Checked = false;
                        }
                        
                    }
                }
            }
            catch
            {
                //在未点钟玩家的时候会抱错
            }
        }

        private void lstSendItem_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (recvUserID == 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_msg2"));
                    return;
                }

                if (enableRemove)
                {
                    OArray array = new OArray(user_Items);

                    int itemID = int.Parse(lstSendItem.Items[e.Index].Tag.ToString());  //物品编号
                    int itemSex = int.Parse(toSendItemList[e.Index, 2].oContent.ToString());  //物品性别要求
                    //选中事件
                    if (e.CurrentValue.ToString().ToLower().Equals("unchecked"))
                    {
                        if (itemSex == recvUserSex || itemSex == 2)
                        {
                            user_Items = array.SaveArray(recvUserID.ToString(), itemID.ToString());
                        }
                        else
                        {
                            MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_msg3"));
                            enableRemove = false;
                            lstSendItem.Items[e.Index].Checked = false;
                            return;
                        }
                    }
                    else//撤销选中
                    {
                        user_Items = array.RemoveArraySecond(recvUserID.ToString(), itemID.ToString());
                    }
                }
            }
            catch
            {
            }
            
        }
                private string ReturnClass(string _strClass)
        {  
           string  myclass="";
           if(_strClass=="头发")
           {
               myclass ="hair";
           }
           else if (_strClass == "表情")
           {
               myclass = "face";
           }
           else if (_strClass == "套装")
           {
               myclass = "sets";
           }
           else if (_strClass == "裤子")
           {
               myclass = "pants";
           }
           else if (_strClass == "衣服")
           {
               myclass = "jacket";
           }
           else if (_strClass == "鞋子")
           {
               myclass = "shoes";
           }
           else if (_strClass == "宠物")
           {
               myclass = "pets";
           }
           else if (_strClass == "功能道具")
           {
               myclass = "items";
           }

           return myclass;
        }
        private void btnConfrimToSend_Click(object sender, EventArgs e)
        {
            if (user_Items == null || user_Items.GetLength(0) <=0)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_msg4"));
                return;
            }

            SendReasion sendreasion = new SendReasion(about,m_ClientEvent);
            sendreasion.ShowDialog();

            if (!sendreasion.canceled)
            {
                for (int i = 0; i < user_Items.GetLength(0); i++)
                {
                    for (int j = 0; j < recvAccountList.GetLength(0); j++)
                    {
                        if (recvAccountList[j, 0].oContent.ToString().Equals(user_Items[i, 0]))
                        {
                            strInfo += recvAccountList[j, 0].oContent.ToString() + "," + recvAccountList[j, 2].oContent.ToString().Replace(",", "，") + "," + user_Items[i, 1]+";";
                        }
                    }
                }

                btnConfrimToSend.Enabled = false;
                Cursor = Cursors.AppStarting;

                SendEquipment();
            }
        }

        private void lstSendItem_Click(object sender, EventArgs e)
        {
            enableRemove = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            /*
                 * 清空公共变量的内容，防止下次赠送时数据错误
                 * */
            _AccountServerIP = null;    //服务器ip
            _ItemServerIP = null;       //服务器ip
            //accountServerIPResult = null;    //ip列表信息
            //itemServerIPResult = null;       //ip列表信息
            accountResult = null;    //玩家信息列表
            recvAccountList = null;
            itemResult = null;       //道具信息列表
            temp_itemResult = null;  //道具信息列表
            sendItemsResult = null;  //物品赠送结果
            toSendItemList = null;

            lstUser_SelectRow = 0;          //用户显示结果中选择的行
            lstItemResult_SelectRow = 0;    //物品显示结果中选中的行
            user_Items = null;    //玩家与获得的道具信息
            recvUserID = 0;             //lstRecvUsers中选中的用户id
            sendReason = null;      //道具赠送理由

            expire = 30;               //赠送道具的有效期限
            strInfo = null;         //赠送的玩家及道具字符串信息　格式:usersn,account,nick,itemids
            about = new SendAboutInfo();  //赠送的道具的理由及时效
            cmbClass.Text = "";


            cbxServerIP.Enabled = true;
            txtAccount.Clear();
            lstUserResult.Items.Clear();
            txtItemName.Clear();
            lstItemResult.Items.Clear();
            lstRecvUsers.Items.Clear();
            lstSendItem.Items.Clear();
            cmbClass.Enabled = true;
            txtItemName.Enabled = true;
            return;
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _AccountServerIP).RequestResult(CEnum.ServiceKey.AU_ACCOUNT_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Enabled = true;
            Cursor = Cursors.Default;
            if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(accountResult[0, 0].oContent.ToString());
                return;
            }

            cbxServerIP.Enabled = false;    //关闭服务器选择
            for (int i = 0; i < accountResult.GetLength(0); i++)
            {
                lstUserResult.Items.Add(accountResult[0, 2].oContent.ToString());
            }
        }

        private void backgroundWorkerItemSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                itemResult = m_ClientEvent.GetSocket(m_ClientEvent, _ItemServerIP).RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_QUERY, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerItemSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnItemSearch.Enabled = true;
            Cursor = Cursors.Default;
            
            if (itemResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(itemResult[0, 0].oContent.ToString());
                return;
            }

            cbxServerIP.Enabled = false;    //关闭服务器选择

            #region 过滤结果中道具名相同项

            for (int i = 0; i < itemResult.GetLength(0); i++)
            {
                string toChkItemName = itemResult[i, 1].oContent.ToString().Trim();

                for (int j = i + 1; j < itemResult.GetLength(0); j++)
                {
                    string beItemName = itemResult[j, 1].oContent.ToString().Trim();
                    //当有相同名称的道具存在时
                    if (toChkItemName == beItemName)
                    {
                        //检测到的相同记录数
                        //将当前搜索到的记录的下条记录拉上来

                        for (int k = j; k < itemResult.GetLength(0) - 1; k++)
                        {
                            //将行记录内的第二位遍历一遍

                            for (int m = 0; m < itemResult.GetLength(1); m++)
                            {
                                itemResult[k, m].eName = itemResult[k + 1, m].eName;
                                itemResult[k, m].eTag = itemResult[k + 1, m].eTag;
                                itemResult[k, m].oContent = itemResult[k + 1, m].oContent;
                            }
                        }
                        temp_itemResult = new CEnum.Message_Body[itemResult.GetLength(0) - 1, itemResult.GetLength(1)];

                        for (int n = 0; n < temp_itemResult.GetLength(0); n++)
                        {
                            for (int m = 0; m < temp_itemResult.GetLength(1); m++)
                            {
                                temp_itemResult[n, m].eName = itemResult[n, m].eName;
                                temp_itemResult[n, m].eTag = itemResult[n, m].eTag;
                                temp_itemResult[n, m].oContent = itemResult[n, m].oContent;
                            }
                        }

                        itemResult = temp_itemResult;

                        //从上提上来的数据开始重新检测

                        j -= 1;
                    }

                }
            }
            #endregion

            for (int i = 0; i < itemResult.GetLength(0); i++)
            {
                lstItemResult.Items.Add(itemResult[i, 1].oContent.ToString());
            }
            cmbClass.Enabled = false;
            txtItemName.Enabled = false;
            
        }

        private void backgroundWorkerSend_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                sendItemsResult = m_ClientEvent.GetSocket(m_ClientEvent, _ItemServerIP).RequestResult(CEnum.ServiceKey.AU_ITEMSHOP_CREATE, C_Global.CEnum.Msg_Category.AU_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnConfrimToSend.Enabled = true;
            Cursor = Cursors.Default;
            if (sendItemsResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(sendItemsResult[0, 0].oContent.ToString());
                return;
            }
            if (sendItemsResult[0, 0].oContent.ToString().ToUpper().Equals("SUCESS"))
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_Msgsendsucc"));

                /*
                 * 清空公共变量的内容，防止下次赠送时数据错误
                 * */
                _AccountServerIP = null;    //服务器ip
                _ItemServerIP = null;       //服务器ip
                //accountServerIPResult = null;    //ip列表信息
                //itemServerIPResult = null;       //ip列表信息
                accountResult = null;    //玩家信息列表
                recvAccountList = null;
                itemResult = null;       //道具信息列表
                temp_itemResult = null;  //道具信息列表
                sendItemsResult = null;  //物品赠送结果
                toSendItemList = null;

                lstUser_SelectRow = 0;          //用户显示结果中选择的行
                lstItemResult_SelectRow = 0;    //物品显示结果中选中的行
                user_Items = null;    //玩家与获得的道具信息
                recvUserID = 0;             //lstRecvUsers中选中的用户id
                sendReason = null;      //道具赠送理由

                expire = 30;               //赠送道具的有效期限
                strInfo = null;         //赠送的玩家及道具字符串信息　格式:usersn,account,nick,itemids
                about = new SendAboutInfo();  //赠送的道具的理由及时效


                cbxServerIP.Enabled = true;
                txtAccount.Clear();
                lstUserResult.Items.Clear();
                txtItemName.Clear();
                lstItemResult.Items.Clear();
                lstRecvUsers.Items.Clear();
                lstSendItem.Items.Clear();
                cmbClass.Enabled = true;
                txtItemName.Enabled = true;

                return;
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_Msgsendfail"));
                _AccountServerIP = null;    //服务器ip
                _ItemServerIP = null;       //服务器ip
                //accountServerIPResult = null;    //ip列表信息
                //itemServerIPResult = null;       //ip列表信息
                accountResult = null;    //玩家信息列表
                recvAccountList = null;
                itemResult = null;       //道具信息列表
                temp_itemResult = null;  //道具信息列表
                sendItemsResult = null;  //物品赠送结果
                toSendItemList = null;

                lstUser_SelectRow = 0;          //用户显示结果中选择的行
                lstItemResult_SelectRow = 0;    //物品显示结果中选中的行
                user_Items = null;    //玩家与获得的道具信息
                recvUserID = 0;             //lstRecvUsers中选中的用户id
                sendReason = null;      //道具赠送理由

                expire = 30;               //赠送道具的有效期限
                strInfo = null;         //赠送的玩家及道具字符串信息　格式:usersn,account,nick,itemids
                about = new SendAboutInfo();  //赠送的道具的理由及时效
                cbxServerIP.Enabled = true;
                txtAccount.Clear();
                lstUserResult.Items.Clear();
                txtItemName.Clear();
                lstItemResult.Items.Clear();
                lstRecvUsers.Items.Clear();
                lstSendItem.Items.Clear();
                cmbClass.Enabled = true;
                txtItemName.Enabled = true;
            }
        }

        private void lstSendItem_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {

                if (enableRemove)
                {
                    if (recvUserID == 0)
                    {
                        MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_msg2"));
                        enableRemove = false;
                        lstSendItem.Items[e.Item.Index].Checked = !lstSendItem.Items[e.Item.Index].Checked;
                        return;
                    }

                    OArray array = new OArray(user_Items);

                    int itemID = int.Parse(lstSendItem.Items[e.Item.Index].Tag.ToString());  //物品编号
                    int itemSex = 0;  //物品性别要求
                    for (int i = 0; i < toSendItemList.GetLength(0); i++)
                    {
                        if (toSendItemList[i, 0].oContent.ToString() == itemID.ToString())
                        {
                            itemSex = int.Parse(toSendItemList[i, 2].oContent.ToString());
                            break;
                        }
                    }
                    //选中事件
                    if (e.Item.Checked == true)
                    {
                        if (itemSex == recvUserSex || itemSex == 2)
                        {
                            user_Items = array.SaveArray(recvUserID.ToString(), itemID.ToString());
                        }
                        else
                        {
                            MessageBox.Show(config.ReadConfigValue("MAU", "ST_Code_msg3"));
                            enableRemove = false;
                            lstSendItem.Items[e.Item.Index].Checked = false;
                            return;
                        }
                    }
                    else//撤销选中
                    {
                        user_Items = array.RemoveArraySecond(recvUserID.ToString(), itemID.ToString());
                    }
                }
            }
            catch
            {
            }
        }

    }
}