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

namespace M_SDO
{
    [C_Global.CModuleAttribute("跳舞毯查询", "FrmQueryUserPadInfo", "超级舞者", "SDO")]
    public partial class FrmQueryUserPadInfo : Form
    {
        public FrmQueryUserPadInfo()
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
            this.Text = config.ReadConfigValue("MSDO", "FPI_UI_Frmtxt");
            this.lblKeyOrCode.Text = config.ReadConfigValue("MSDO", "BT_Code_KeyID");
            this.btnQuery.Text = config.ReadConfigValue("MSDO", "BT_UI_btnSearch");
            this.chkKeyID.Text = config.ReadConfigValue("MSDO", "BT_UI_chkKeyID");
            this.chkCode.Text = config.ReadConfigValue("MSDO", "BT_UI_chkCode");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnClose");
            //this.label1.Text = config.ReadConfigValue("MSDO", "BT_UI_label1");
            //this.label2.Text = config.ReadConfigValue("MSDO", "BT_UI_label2");
            //this.label3.Text = config.ReadConfigValue("MSDO", "BT_UI_label3");
        }
        #endregion

        private void FrmQueryUserPadInfo_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }


        private void chkKeyID_Click(object sender, EventArgs e)
        {
            chkCode.Checked = false;
            lblKeyOrCode.Text = config.ReadConfigValue("MSDO", "BT_Code_KeyID");
        }

        private void chkCode_Click(object sender, EventArgs e)
        {
            chkKeyID.Checked = false;
            lblKeyOrCode.Text = config.ReadConfigValue("MSDO", "BT_Code_Code");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GrdResult.DataSource = null;
            if (!chkKeyID.Checked && !chkCode.Checked)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "AF_Code_InputAccount"));
                chkCode.Focus();
                return;
            }

            if (txtKeyOrCode.Text == "" || txtKeyOrCode.Text == null)
            {
                MessageBox.Show(chkCode.Checked ? config.ReadConfigValue("MSDO", "BT_Code_InputKeyID") : config.ReadConfigValue("MSDO", "BT_Code_InputCode"));
                txtKeyOrCode.Focus();
                return;
            }
            ReadKeyWords();
        }

        private void ReadKeyWords()
        {
            try
            {
                int intType = 0;
                if (chkKeyID.Checked)
                {
                    intType = 1;
                }
                else if (chkCode.Checked)
                {
                    intType = 2;
                }

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_KeyID;
                messageBody[0].oContent = chkKeyID.Checked ? txtKeyOrCode.Text.Trim() : "";

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.SDO_KeyWord;
                messageBody[1].oContent = chkCode.Checked ? txtKeyOrCode.Text.Trim() : "";

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[2].eName = C_Global.CEnum.TagName.SDO_Type;
                messageBody[2].oContent = intType;

                doResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_PADREGIST_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                if (doResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(doResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    Operation_SDO.BuildDataTable(m_ClientEvent, doResult, this.GrdResult, out RolePage);

                }
            }
            catch
            { }
        }
    }
}