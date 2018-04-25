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
    [C_Global.CModuleAttribute("9YOU令牌", "FrmToken", "9YOU令牌", "9YOU Group")]
    public partial class FrmToken : Form
    {
        public FrmToken()
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
            FrmToken mModuleFrm = new FrmToken();
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
            this.Text = config.ReadConfigValue("MAU", "FT_UI_Text");
            this.TpgLock.Text = config.ReadConfigValue("MAU", "FT_UI_TpgLock");
            this.TpgUnlock.Text = config.ReadConfigValue("MAU", "FT_UI_TpgUnlock");
            //this.TpgSysPwd.Text = config.ReadConfigValue("MAU", "FT_UI_TpgSysPwd");
            this.GroupLock.Text = config.ReadConfigValue("MAU", "FT_UI_GroupLock");
            this.labelName.Text = config.ReadConfigValue("MAU", "FT_UI_labelName");
            this.labelESN.Text = config.ReadConfigValue("MAU", "FT_UI_labelESN");
            this.labelserviceNo.Text = config.ReadConfigValue("MAU", "FT_UI_labelserviceNo");
            this.radioButton1.Text = config.ReadConfigValue("MAU", "FT_UI_radioButton1");
            this.radioButton2.Text = config.ReadConfigValue("MAU", "FT_UI_radioButton2");
            this.richTextBox1.Text = config.ReadConfigValue("MAU", "FT_UI_richTextBox1");
            this.buttonLock.Text = config.ReadConfigValue("MAU", "FT_UI_buttonLock");
            this.buttonCancel.Text = config.ReadConfigValue("MAU", "FT_UI_buttonCancel");

            this.GroupUnlock.Text = config.ReadConfigValue("MAU", "FT_UI_GroupLock");
            this.label3.Text = config.ReadConfigValue("MAU", "FT_UI_labelName");
            this.label1.Text = config.ReadConfigValue("MAU", "FT_UI_labelESN");
            this.label2.Text = config.ReadConfigValue("MAU", "FT_UI_label2");
            //this.label4.Text = config.ReadConfigValue("MAU", "FT_UI_labelESN");
            //this.label5.Text = config.ReadConfigValue("MAU", "FT_UI_label2");
            this.buttonUnlock.Text = config.ReadConfigValue("MAU", "FT_UI_buttonUnlock");
            this.button1.Text = config.ReadConfigValue("MAU", "FT_UI_buttonCancel");
            this.richTextBox2.Text = config.ReadConfigValue("MAU", "FT_UI_richTextBox2");
        }
        #endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().Length > 0 &&
                this.textBox2.Text.Trim().Length > 0 &&
                this.textBox3.Text.Trim().Length > 0 &&
                (this.radioButton1.Checked || this.radioButton2.Checked)
                )
            {
                buttonLock.Enabled = false;
                Cursor = Cursors.WaitCursor;
                
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.UserByID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[1].eName = CEnum.TagName.TOKEN_username;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = textBox1.Text.Trim();

                mContent[2].eName = CEnum.TagName.TOKEN_esn;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = textBox2.Text.Trim();

                mContent[3].eName = CEnum.TagName.TOKEN_service;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = textBox3.Text.Trim();

                mContent[4].eName = CEnum.TagName.TOKEN_code;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = radioButton1.Checked ? "4" : "5";

                mContent[5].eName = CEnum.TagName.CARD_address;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = Operation_Card.ReturnClientIp();

                this.backgroundWorkerLock.RunWorkerAsync(mContent);
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg1"));
                return;
            }
        }

        private void backgroundWorkerLock_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERTOKEN_CLOSE, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerLock_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonLock.Enabled = true;
            Cursor = Cursors.Default;

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                if(mResult[0,0].oContent.ToString() == "FAILURE")
                    MessageBox.Show(config.ReadConfigValue("MAU","UD_Code_Msgopfail"));
                else 
                    MessageBox.Show(config.ReadConfigValue("MAU","UD_Code_Msgopsucc"));

            }
        }

        private void FrmToken_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            if (this.textBox4.Text.Trim() != "" &&
                this.textBox6.Text.Trim() != "")
            {
                buttonUnlock.Enabled = false;
                Cursor = Cursors.WaitCursor;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.UserByID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[1].eName = CEnum.TagName.TOKEN_username;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = textBox6.Text.Trim();

                mContent[2].eName = CEnum.TagName.TOKEN_esn;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = textBox4.Text.Trim();

                mContent[3].eName = CEnum.TagName.TOKEN_dpsw;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = textBox5.Text.Trim();

                mContent[4].eName = CEnum.TagName.CARD_address;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = Operation_Card.ReturnClientIp();

                this.backgroundWorkerUnlock.RunWorkerAsync(mContent);
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg1"));
                return;
            }
        }

        private void backgroundWorkerUnlock_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERTOKEN_OPEN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerUnlock_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonUnlock.Enabled = true;
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



        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox10.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.textBox10.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg1"));
                return;
            }
            else
            {
                button6.Enabled = false;
                Cursor = Cursors.WaitCursor;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.UserByID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[1].eName = CEnum.TagName.TOKEN_username;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = textBox10.Text.Trim();

                mContent[2].eName = CEnum.TagName.CARD_address;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = Operation_Card.ReturnClientIp();


                this.backgroundWorkerUnban.RunWorkerAsync(mContent);
            }
        }

        private void backgroundWorkerUnban_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERTOKEN_RELEASE, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerUnban_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button6.Enabled = true;
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

        //private void btncanel_Click(object sender, EventArgs e)
        //{
        //    textBox7.Text = "";
        //    textBox8.Text = "";

        //}

    //    private void btnsyspwd_Click(object sender, EventArgs e)
    //    {
    //        if (this.textBox7.Text.Trim() != "" &&
    //this.textBox8.Text.Trim() != "")
    //        {
    //            btnsyspwd.Enabled = false;
    //            Cursor = Cursors.WaitCursor;

    //            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

    //            mContent[0].eName = CEnum.TagName.UserByID;
    //            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
    //            mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


    //            mContent[1].eName = CEnum.TagName.TOKEN_esn;
    //            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
    //            mContent[1].oContent = textBox7.Text.Trim();

    //            mContent[2].eName = CEnum.TagName.TOKEN_dpsw;
    //            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
    //            mContent[2].oContent = textBox8.Text.Trim();

    //            mContent[3].eName = CEnum.TagName.CARD_address;
    //            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
    //            mContent[3].oContent = Operation_Card.ReturnClientIp();

    //            this.backgroundWorkerSysPwd.RunWorkerAsync(mContent);
    //        }
    //        else
    //        {
    //            MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg1"));
    //            return;
    //        }
    //    }

        private void backgroundWorkerSysPwd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_TOKENPASSWD_SYNC, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSysPwd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //btnsyspwd.Enabled = true;
            //Cursor = Cursors.Default;
            //CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}
            //else
            //{
            //    if (mResult[0, 0].oContent.ToString() == "FAILURE")
            //        MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopfail"));
            //    else
            //        MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopsucc"));

            //}
        }
    }
}