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

namespace M_Audition
{
    [C_Global.CModuleAttribute("跳舞毯查询", "FrmQueryPadItemInfo", "超级舞者", "SDO")]
    public partial class FrmQueryPadItemInfo : Form
    {
        public FrmQueryPadItemInfo()
        {
            InitializeComponent();
        }

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

        C_Global.CEnum.Message_Body[,] doResult = null;    //玩家信息列表

        #endregion

        private int RolePage = 0;

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
            this.Text = config.ReadConfigValue("MSDO", "FQP_UI_Frmtxt");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnClose");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "IC_UI_BtnSearch");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "IC_UI_LblAccount");
            this.lblstartime.Text = config.ReadConfigValue("MSDO", "FQP_UI_lblstartime");
            //this.label1.Text = config.ReadConfigValue("MSDO", "BT_UI_label1");
            //this.label2.Text = config.ReadConfigValue("MSDO", "BT_UI_label2");
            //this.label3.Text = config.ReadConfigValue("MSDO", "BT_UI_label3");
        }
        #endregion

        private void FrmQueryPadItemInfo_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ReadKeyWords()
        {
            try
            {

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = TxtAccount.Text.Trim();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_TIMESTAMP;
                messageBody[1].eName = C_Global.CEnum.TagName.CARD_PayStartDate;
                messageBody[1].oContent = Convert.ToDateTime(DptStart.Text); ;


                doResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_DanceItem_QUERY, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);

                if (doResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(doResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_Card.BuildDataTable(m_ClientEvent, doResult, this.GrdResult, out RolePage);

                }
            }
            catch
            { }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GrdResult.DataSource = null;
                if (TxtAccount.Text.Trim().Length > 0)
                {
                    ReadKeyWords();
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
                }
            }

            catch
            { }
        }


    }
}