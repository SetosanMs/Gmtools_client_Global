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
    [C_Global.CModuleAttribute("人物角色资料[超级乐者]", "PartInfo", "人物角色资料", "o2jam2")]
    public partial class PartInfo : Form
    {
        public PartInfo()
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
            this.Text = config.ReadConfigValue("MBAF", "PI_UI_PartInfo");
            this.groupBox1.Text = config.ReadConfigValue("MBAF", "PI_UI_groupBox1");
            this.btnCancel.Text = config.ReadConfigValue("MBAF", "PI_UI_btnCancel");
            this.rbtnNick.Text = config.ReadConfigValue("MBAF", "PI_UI_rbtnNick");
            this.rbtnAccount.Text = config.ReadConfigValue("MBAF", "PI_UI_rbtnAccount");
            this.btnApply.Text = config.ReadConfigValue("MBAF", "PI_UI_btnApply");
            this.lblAorN.Text = config.ReadConfigValue("MBAF", "PI_UI_lblAorN");
            this.label1.Text = config.ReadConfigValue("MBAF", "PI_UI_label1");
            this.button2.Text = config.ReadConfigValue("MBAF", "PI_UI_button2");
            this.button1.Text = config.ReadConfigValue("MBAF", "PI_UI_button1");
            this.label13.Text = config.ReadConfigValue("MBAF", "PI_UI_label13");
            this.label12.Text = config.ReadConfigValue("MBAF", "PI_UI_label12");
            this.label11.Text = config.ReadConfigValue("MBAF", "PI_UI_label11");
            this.label10.Text = config.ReadConfigValue("MBAF", "PI_UI_label10");
            this.label9.Text = config.ReadConfigValue("MBAF", "PI_UI_label9");
            this.label8.Text = config.ReadConfigValue("MBAF", "PI_UI_label8");
            this.label7.Text = config.ReadConfigValue("MBAF", "PI_UI_label7");
            this.label6.Text = config.ReadConfigValue("MBAF", "PI_UI_label6");
            this.label5.Text = config.ReadConfigValue("MBAF", "PI_UI_label5");
            this.label4.Text = config.ReadConfigValue("MBAF", "PI_UI_label4");
            this.label3.Text = config.ReadConfigValue("MBAF", "PI_UI_label3");
            this.lblSex.Items.AddRange(new object[] {
            config.ReadConfigValue("MBAF", "PI_UI_female"),
            config.ReadConfigValue("MBAF", "PI_UI_male")});
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
        private　CSocketEvent m_ClientEvent = null;
        private　C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip列表信息
        private C_Global.CEnum.Message_Body[,] userInfoResult = null;    //用户信息
        private C_Global.CEnum.Message_Body[,] levelInfoResult = null;    //等级信息
        private C_Global.CEnum.Message_Body[,] modiResult = null;    //用户信息
        private　string _ServerIP = null;    //服务器ip



        int iLvlSelectIndex = 0;
        int iExpSelectIndex = 0;

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
        /// 读取帐号记录
        /// </summary>
        private void ReadInfoFromDB()
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
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[1].oContent = rbtnAccount.Checked ? txtAorN.Text.Trim() : "";

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.O2JAM2_UserNick;
                messageBody[2].oContent = rbtnNick.Checked ? txtAorN.Text.Trim() : "" ;

                lock (typeof(C_Event.CSocketEvent))
                {
                    userInfoResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }


                if (userInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    dpInfoContain.Visible = false;
                    richInfo.Text = "";
                    MessageBox.Show(userInfoResult[0, 0].oContent.ToString());
                    return;
                }
                richInfo.Text += label3.Text;
                richInfo.Text += userInfoResult[0, 1].oContent.ToString();
                richInfo.Text += "\r\n"+"\r\n";
                richInfo.Text += label4.Text;
                richInfo.Text += userInfoResult[0, 2].oContent.ToString();
                richInfo.Text += "\r\n" + "\r\n";
                richInfo.Text += label5.Text;
                richInfo.Text += (userInfoResult[0, 11].oContent.ToString()=="0")?config.ReadConfigValue("MBAF","PI_UI_female"):config.ReadConfigValue("MBAF","PI_UI_male");
                richInfo.Text += "\r\n" + "\r\n";
                richInfo.Text += label6.Text;
                richInfo.Text += userInfoResult[0, 9].oContent.ToString();
                richInfo.Text += "\r\n" + "\r\n";
                richInfo.Text += label7.Text;
                richInfo.Text += userInfoResult[0, 10].oContent.ToString();
                richInfo.Text += "\r\n" + "\r\n";
                richInfo.Text += label8.Text;
                richInfo.Text += userInfoResult[0, 3].oContent.ToString();
                richInfo.Text += "\r\n" + "\r\n";
                richInfo.Text += label9.Text;
                richInfo.Text += userInfoResult[0, 4].oContent.ToString();
                richInfo.Text += "\r\n" + "\r\n";
                richInfo.Text += label10.Text;
                richInfo.Text += userInfoResult[0, 5].oContent.ToString();
                richInfo.Text += "\r\n" + "\r\n";
                richInfo.Text += label11.Text;
                richInfo.Text += userInfoResult[0, 6].oContent.ToString();
                richInfo.Text += "\r\n" + "\r\n";
                richInfo.Text += label12.Text;
                richInfo.Text += userInfoResult[0, 7].oContent.ToString();
                richInfo.Text += "\r\n" + "\r\n";
                richInfo.Text += label13.Text;
                richInfo.Text += userInfoResult[0, 8].oContent.ToString();
                richInfo.Text += "\r\n" + "\r\n";


                lblAccount.Text = userInfoResult[0, 1].oContent.ToString();
                lblNick.Text = userInfoResult[0, 2].oContent.ToString();
                lblSex.SelectedIndex = int.Parse(userInfoResult[0, 11].oContent.ToString());
                lblMCash.Text = userInfoResult[0, 10].oContent.ToString();
                lblG.Text = userInfoResult[0, 9].oContent.ToString();
                //lblLevel.Text       = userInfoResult[0, 3].oContent.ToString();
                //lblExp.Text         = userInfoResult[0, 4].oContent.ToString();
                lblGameCount.Text = userInfoResult[0, 5].oContent.ToString();
                lblWin.Text = userInfoResult[0, 6].oContent.ToString();
                lblDraw.Text = userInfoResult[0, 7].oContent.ToString();
                lblLost.Text = userInfoResult[0, 8].oContent.ToString();

                try
                {
                    
                    levelInfoResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_LEVELEXP_QUERY, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, null);

                    for (int i = 0; i < levelInfoResult.GetLength(0); i++)
                    {
                        lblLevel.Items.Add(levelInfoResult[i, 0].oContent.ToString());
                        lblExp.Items.Add(levelInfoResult[i, 1].oContent.ToString());

                        if (levelInfoResult[i, 0].oContent.ToString() == userInfoResult[0, 3].oContent.ToString())
                            iLvlSelectIndex = i;
                    }

                    lblLevel.SelectedIndex = iLvlSelectIndex;

                    
                }
                catch
                {
                }



                button2.Enabled = false;

                lblAccount.Text     = userInfoResult[0, 1].oContent.ToString();
                lblNick.Text        = userInfoResult[0, 2].oContent.ToString();
                lblSex.SelectedIndex= int.Parse(userInfoResult[0, 11].oContent.ToString());
                lblMCash.Text       = userInfoResult[0, 10].oContent.ToString();
                lblG.Text           = userInfoResult[0, 9].oContent.ToString();
                //lblLevel.Text       = userInfoResult[0, 3].oContent.ToString();
                //lblExp.Text         = userInfoResult[0, 4].oContent.ToString();
                lblGameCount.Text   = userInfoResult[0, 5].oContent.ToString();
                lblWin.Text         = userInfoResult[0, 6].oContent.ToString();
                lblDraw.Text        = userInfoResult[0, 7].oContent.ToString();
                lblLost.Text        = userInfoResult[0, 8].oContent.ToString();


                lblAccount.ReadOnly = true;
                lblNick.ReadOnly = true;
                lblSex.Enabled = false;
                lblMCash.ReadOnly = true;
                lblG.ReadOnly = true;
                lblGameCount.ReadOnly = true;
                lblWin.ReadOnly = true;
                lblDraw.ReadOnly = true;
                lblLost.ReadOnly = true;

                

                dpInfoContain.Visible = true;
            }
            catch
            {
            }

        }




        private void ModiInfo()
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
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[13];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = _ServerIP;


                messageBody[1].eName = CEnum.TagName.UserByID;
                messageBody[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[2].oContent = lblAccount.Text;

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[3].eName = C_Global.CEnum.TagName.O2JAM2_UserNick;
                messageBody[3].oContent = lblAorN.Text;

                messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].eName = C_Global.CEnum.TagName.O2JAM2_Sex;
                messageBody[4].oContent = lblSex.SelectedIndex;

                messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[5].eName = C_Global.CEnum.TagName.O2JAM2_MCash;
                messageBody[5].oContent = int.Parse(lblMCash.Text);

                messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[6].eName = C_Global.CEnum.TagName.O2JAM2_GCash;
                messageBody[6].oContent = int.Parse(lblG.Text);

                messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[7].eName = C_Global.CEnum.TagName.O2JAM2_Level;
                messageBody[7].oContent = int.Parse(lblLevel.Text);

                messageBody[8].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[8].eName = C_Global.CEnum.TagName.O2JAM2_Exp;
                messageBody[8].oContent = int.Parse(lblExp.Text);

                messageBody[9].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[9].eName = C_Global.CEnum.TagName.O2JAM2_TOTAL;
                messageBody[9].oContent = int.Parse(lblGameCount.Text);

                messageBody[10].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[10].eName = C_Global.CEnum.TagName.O2JAM2_Win;
                messageBody[10].oContent = int.Parse(lblWin.Text);

                messageBody[11].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[11].eName = C_Global.CEnum.TagName.O2JAM2_Draw;
                messageBody[11].oContent = int.Parse(lblDraw.Text);

                messageBody[12].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[12].eName = C_Global.CEnum.TagName.O2JAM2_Lose;
                messageBody[12].oContent = int.Parse(lblLost.Text);




                lock (typeof(C_Event.CSocketEvent))
                {
                    modiResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_CHARACTERINFO_UPDATE, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }

                if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    //dpInfoContain.Visible = false;

                    MessageBox.Show(modiResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiResult[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MBAF", "PI_Code_Failed"));
                    return;
                }
                else if (modiResult[0, 0].oContent.Equals("SUCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MBAF", "PI_Code_Success"));
                    ReadInfoFromDB();
                    return;
                }

            }
            catch
            {
            }

        }


       
        #endregion

        private void PartInfo_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            dpInfoContain.Visible = false;
            richInfo.Text = "";

            lblAccount.Text = "";
            lblNick.Text = "";
            lblSex.Text = "";
            lblMCash.Text = "";
            lblG.Text = "";
            lblLevel.Text = "";
            lblExp.Text = "";
            lblGameCount.Text = "";
            lblWin.Text = "";
            lblDraw.Text = "";
            lblLost.Text = "";


            lblAccount.ReadOnly = true;
            lblNick.ReadOnly = true;
            lblSex.Enabled = false;
            lblMCash.ReadOnly = true;
            lblG.ReadOnly = true;
            lblGameCount.ReadOnly = true;
            lblWin.ReadOnly = true;
            lblDraw.ReadOnly = true;
            lblLost.ReadOnly = true;


            InitializeServerIP();
        }

        private void rbtnNick_CheckedChanged(object sender, EventArgs e)
        {
            lblAorN.Text = config.ReadConfigValue("MBAF", "PI_UI_rbtnNick") + ":";
        }

        private void rbtnAccount_CheckedChanged(object sender, EventArgs e)
        {
            lblAorN.Text = config.ReadConfigValue("MBAF", "PI_UI_rbtnAccount") + ":";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cbxServerIP.Text == "" || cbxServerIP.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "PI_Code_SelectServer"));
                cbxServerIP.Focus();
                return;
            }

            if (txtAorN.Text == "" || txtAorN.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "PI_Code_Input").Replace("{Nick}", lblAorN.Text.Substring(0, (lblAorN.Text.Length - 1))));
                txtAorN.Focus();
                return;
            }

            dpInfoContain.Visible = false;
            richInfo.Text = "";
            _ServerIP = null;
            ReadInfoFromDB();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblAccount.Text = "";
            lblNick.Text = "";
            lblSex.SelectedIndex = 0;
            lblMCash.Text = "";
            lblG.Text = "";
            lblLevel.Text = "";
            lblExp.Text = "";
            lblGameCount.Text = "";
            lblWin.Text = "";
            lblDraw.Text = "";
            lblLost.Text = "";

            button2.Enabled = true;
            lblNick.ReadOnly = false;
            lblSex.Enabled = false;
            //lblMCash.ReadOnly = false;
            lblG.ReadOnly = false;
            lblGameCount.ReadOnly = false;
            lblWin.ReadOnly = false;
            lblDraw.ReadOnly = false;
            lblLost.ReadOnly = false;

            dpInfoContain.Visible = false;
            richInfo.Text = "";
            rbtnAccount.Checked = true;
            lblAorN.Text = config.ReadConfigValue("MBAF", "PI_UI_rbtnAccount") + ":";
            txtAorN.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            button2.Enabled = true;
            lblNick.ReadOnly = false;
            lblSex.Enabled = true;
            //lblMCash.ReadOnly = false;
            lblG.ReadOnly = false;
            lblGameCount.ReadOnly = false;
            lblWin.ReadOnly = false;
            lblDraw.ReadOnly = false;
            lblLost.ReadOnly = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(config.ReadConfigValue("MBAF", "PI_Code_ComfirmModify") + lblAccount.Text + config.ReadConfigValue("MBAF", "PI_Code_Information"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ModiInfo();
            }
        }

        private void lblLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                for (int i = 0; i < levelInfoResult.GetLength(0); i++)
                {
                    if (lblExp.Items.Count == 0)
                        lblExp.Items.Add(levelInfoResult[i, 1].oContent.ToString());

                    if (levelInfoResult[i, 0].oContent.ToString() == lblLevel.Text)
                        iLvlSelectIndex = i;

                }

                lblExp.SelectedIndex = iLvlSelectIndex;
            }
            catch
            {
            }
        }

        private void lblExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < levelInfoResult.GetLength(0); i++)
                {
                    if (levelInfoResult[i, 1].oContent.ToString() == lblExp.Text)
                        iLvlSelectIndex = i;

                }

                lblLevel.SelectedIndex = iLvlSelectIndex;
            }
            catch
            {
            }
        }
    }
}