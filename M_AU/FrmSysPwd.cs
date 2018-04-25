using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using C_Controls.LabelTextBox;
using C_Global;
using C_Event;
using Language;

namespace M_Audition
{
    [C_Global.CModuleAttribute("9YOU令牌", "FrmSysPwd", "9YOU令牌", "9YOU Group")]
    public partial class FrmSysPwd : Form
    {
        public FrmSysPwd()
        {
            InitializeComponent();
        }

        private CSocketEvent m_ClientEvent = null;
        private int iPage = 0;
        private int pagesize = 25;
        private bool iFirst = false;
        private bool iFirst1 = false;

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
            FrmSysPwd mModuleFrm = new FrmSysPwd();
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
            this.Text = config.ReadConfigValue("MAU", "FT_UI_TpgSysPwd");
            this.label4.Text = config.ReadConfigValue("MAU", "FT_UI_labelESN");
            this.label5.Text = config.ReadConfigValue("MAU", "FT_UI_label2");
            this.btnsyspwd.Text = config.ReadConfigValue("MAU", "FT_UI_BtnSysPwd");
            this.btncanel.Text = config.ReadConfigValue("MAU", "UA_UI_btnCancel");


        }
        #endregion
        private void FrmSysPwd_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }

        private void btncanel_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void btnsyspwd_Click(object sender, EventArgs e)
        {
            if (this.textBox7.Text.Trim() != "" &&
this.textBox8.Text.Trim() != "")
            {
                btnsyspwd.Enabled = false;
                Cursor = Cursors.WaitCursor;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.UserByID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


                mContent[1].eName = CEnum.TagName.TOKEN_esn;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = textBox7.Text.Trim();

                mContent[2].eName = CEnum.TagName.TOKEN_dpsw;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = textBox8.Text.Trim();

                mContent[3].eName = CEnum.TagName.CARD_address;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = Operation_Card.ReturnClientIp();

                this.backgroundWorkerSysPwd.RunWorkerAsync(mContent);
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg1"));
                return;
            }
        }

        private void backgroundWorkerSysPwd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_TOKENPASSWD_SYNC, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSysPwd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnsyspwd.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                if (mResult[0, 0].oContent.ToString() == "FAILURE")
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopfail"));
                else
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopsucc"));

            }
        }
    }
}