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
    public partial class ItemsShow : Form
    {

        #region 变量
        private CSocketEvent m_ClientEvent = null;
        private System.Windows.Forms.TextBox result;                    //显示内容的文本框
        private string srvIP = null;                                    //服务器ｉｐ
        private C_Global.CEnum.Message_Body[,] itemsResult = null;      //道具列表信息
        private int selRow = -1;                                        //选中的行
        private string recvUser = null;
        private int xPos = 0;
        private int yPos = 0;
        #endregion

        #region 函数
        private void ReadInfoFromDB()
        {

            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.O2JAM2_ServerIP;
                messageBody[0].oContent = srvIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.O2JAM2_ItemName;
                messageBody[1].oContent = txtItemName.Text.Trim();

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.O2JAM2_UserID;
                messageBody[2].oContent = recvUser;

                lock (typeof(C_Event.CSocketEvent))
                {
                    itemsResult = m_ClientEvent.GetSocket(m_ClientEvent, srvIP).RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_ITEMSHOP_QUERY, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, messageBody);
                }

                if (itemsResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(itemsResult[0, 0].oContent.ToString());
                    
                    return;
                }

                for (int i = 0; i < itemsResult.GetLength(0); i++)
                {
                    itemslistBox.Items.Add(itemsResult[i, 1].oContent.ToString() +" "+ config.ReadConfigValue("MBAF", "IS_Code_TimeLimit") + ":" + (itemsResult[i, 4].oContent.ToString() == "0" ? config.ReadConfigValue("MBAF", "IS_Code_permanence") : itemsResult[i, 4].oContent.ToString()) +config.ReadConfigValue("MBAF", "IS_Code_Days")+ ")");
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "IS_Code_ClientErrorMessage") + "\n---------------------------------------\n" + ex.Message);
            }

        }
        #endregion


        public ItemsShow()
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
            this.Text = config.ReadConfigValue("MBAF", "IS_UI_ItemsShow");
            this.label1.Text = config.ReadConfigValue("MBAF", "IS_UI_label1");
            this.btnSearch.Text = config.ReadConfigValue("MBAF", "IS_UI_btnSearch");
            this.btnOk.Text = config.ReadConfigValue("MBAF", "IS_UI_btnOk");
            this.btnClose.Text = config.ReadConfigValue("MBAF", "IS_UI_btnClose");
        }


        #endregion

        public ItemsShow(CSocketEvent m_ClientEvent, string srvIP, System.Windows.Forms.TextBox result, string recvUser,int xPos,int yPos)
        {
            InitializeComponent();
            this.srvIP = srvIP;
            this.result = result;
            this.m_ClientEvent = m_ClientEvent;
            this.recvUser = recvUser;
            this.xPos = xPos;
            this.yPos = yPos;
        }

        private void ItemsShow_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            if (xPos > (Screen.GetWorkingArea(this).Width - this.Width))
            {
                xPos = Screen.GetWorkingArea(this).Width - this.Width;
            }
            if (yPos > (Screen.GetWorkingArea(this).Height - this.Height))
            {
                yPos = Screen.GetWorkingArea(this).Height - this.Height;
            }
            this.Location = new Point(xPos, yPos);
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == "" || txtItemName.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MBAF", "IS_Code_InputItemName"));
                txtItemName.Focus();
                return;
            }
            itemslistBox.Items.Clear();
            ReadInfoFromDB();
        }

        private void itemslistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selRow = itemslistBox.SelectedIndex;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            result.Text = itemsResult[selRow, 1].oContent.ToString() + "_" + itemsResult[selRow, 0].oContent.ToString() + "_" + itemsResult[selRow, 3].oContent.ToString() + "_" + itemsResult[selRow, 4].oContent.ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}