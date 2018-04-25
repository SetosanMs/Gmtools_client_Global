using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Controls.LabelTextBox;
using C_Global;
using C_Event;


using Language;

namespace M_Audition
{
    [C_Global.CModuleAttribute("封停原因查询", "FrmReason", "封停原因查询", "9YOU Group")]
    public partial class FrmReason : Form
    {

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] mItemResult = null;
        private int RolePage = 0;
        private int RoleIndex = 0;
        private int iIndexID = 0;
        private bool RoleFirst = false;
        private int iPageCount = 0;
        private bool bFirst = false;
        
        public FrmReason()
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
            this.Text = config.ReadConfigValue("MAU", "FR_UI_Text");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpSearch");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "AF_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnSearch");
            this.button1.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnReset");
            this.TbgCard.Text = config.ReadConfigValue("MAU", "FR_UI_TbgCard");
            this.TbgUser.Text = config.ReadConfigValue("MAU", "FR_UI_TbgUser");
            this.groupReasonByUser.Text = config.ReadConfigValue("MAU", "FR_UI_groupReasonByUser");
            this.groupReasonByCard.Text = config.ReadConfigValue("MAU", "FR_UI_groupReasonByCard");
            this.groupBox1.Text = config.ReadConfigValue("MSDO", "AF_UI_GrpSearch");
            this.radioCard.Text = config.ReadConfigValue("MAU", "FR_UI_radioCard");
            this.radioUser.Text = config.ReadConfigValue("MAU", "FR_UI_radioUser ");
            this.label1.Text = config.ReadConfigValue("MSDO", "AF_UI_LblAccount");
            this.labelCard.Text = config.ReadConfigValue("MAU", "FR_UI_labelCard");
            this.button3.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnSearch");
            this.button2.Text = config.ReadConfigValue("MSDO", "AF_UI_BtnReset");
        }


        #endregion

        #region 自定义调用事件
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            FrmReason mModuleFrm = new FrmReason();
            mModuleFrm.m_ClientEvent = (CSocketEvent)oEvent;
            if (oParent != null)
            {
                mModuleFrm.MdiParent = (Form)oParent;
                mModuleFrm.Show();
            }
            else
            {
                mModuleFrm.ShowDialog();
            }

            return mModuleFrm;
        }
        #endregion

        private void FrmReason_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            this.radioUser.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.TxtAccount.Text = "";
            this.dgvUser.DataSource = null;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FR_Code_Msg1"));
                return;
            }
            this.BtnSearch.Enabled = false;
            Cursor = Cursors.WaitCursor;
            this.dgvUser.DataSource = null;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

            mContent[0].eName = CEnum.TagName.CARD_username;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text.Trim();

            this.backgroundWorkerSearchByUser.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerSearchByUser_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERLOCK_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearchByUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnSearch.Enabled = true;
            Cursor = Cursors.Default;
            int pg = 0;

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                Operation_Card.BuildDataTable(m_ClientEvent, mResult, dgvUser, out pg);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.radioUser.Checked = true;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.dgvCard.DataSource = null;
        }

        private void radioUser_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioUser.Checked)
            {
                this.textBox2.Enabled = false;
                this.textBox1.Enabled = true;
            }
        }

        private void radioCard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioCard.Checked)
            {
                this.textBox1.Enabled = false;
                this.textBox2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.radioUser.Checked && this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FR_Code_Msg1"));
                return;
            }
            if (this.radioCard.Checked && this.textBox2.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FR_Code_Msg2"));
                return;
            }

            Cursor = Cursors.WaitCursor;
            this.button3.Enabled = false;
            this.dgvCard.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            if (this.radioUser.Checked)
            {
                mContent[0].eName = CEnum.TagName.CARD_username;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = this.textBox1.Text.Trim();

                mContent[1].eName = CEnum.TagName.CARD_cardnum;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = "";

                mContent[2].eName = CEnum.TagName.CARD_ActionType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = 1;

                this.backgroundWorkerByCard.RunWorkerAsync(mContent);
            }
            else if (this.radioCard.Checked)
            {
                mContent[0].eName = CEnum.TagName.CARD_username;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = "";

                mContent[1].eName = CEnum.TagName.CARD_cardnum;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = this.textBox2.Text.Trim();

                mContent[2].eName = CEnum.TagName.CARD_ActionType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = 2;

                this.backgroundWorkerByCard.RunWorkerAsync(mContent);
            }
        }

        private void backgroundWorkerByCard_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERCARDLOCK_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerByCard_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            this.button3.Enabled = true;
            int pg = 0;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                Operation_Card.BuildDataTable(m_ClientEvent, mResult, dgvCard, out pg);
            }
                
        }
    }
}