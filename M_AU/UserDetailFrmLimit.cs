using System;
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
    [C_Global.CModuleAttribute("9YOU用户信息", "UserDetailFrmLimit", "注册用户管理工具 -- 9YOU用户信息", "AU Group")]
    public partial class UserDetailFrmLimit : Form
    {
        private CSocketEvent m_ClientEvent = null;

        public UserDetailFrmLimit()
        {
            InitializeComponent();
        }

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
            UserDetailFrmLimit mModuleFrm = new UserDetailFrmLimit();
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

        #region 变量

        C_Global.CEnum.Message_Body[,] modiInfoResult = null;

        CEnum.Message_Body[,] mResult = null;
        CEnum.Message_Body[,] stopResult = null;
        private string strDance = null;
        bool isTokenUser = false;
        bool isPad = false;
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
            this.Text = config.ReadConfigValue("MAU", "UD_UI_Frmname_power");
            this.BtnSearch.Text = config.ReadConfigValue("MAU", "UD_UI_BtnSearch");
            this.LblID.Text = config.ReadConfigValue("MAU", "UD_UI_LblID");
            this.GrpResult.Text = config.ReadConfigValue("MAU", "UD_UI_GrpResult");
            this.BtnReset.Text = config.ReadConfigValue("MAU", "UD_UI_BtnReset");
            this.GrpSearch.Text = config.ReadConfigValue("MAU", "UD_UI_GrpSearch");
            this.LblUser.Text = config.ReadConfigValue("MAU", "UD_UI_LblUser");
            this.btnResetV.Text = config.ReadConfigValue("MAU", "UD_UI_btnResetV");
            this.buttonResetMailBox.Text = config.ReadConfigValue("MAU", "UD_UI_buttonResetMailBox");
            this.buttonResetRealName.Text = config.ReadConfigValue("MAU", "UD_UI_buttonResetRealName");
            this.buttonResetPhone.Text = config.ReadConfigValue("MAU", "UD_UI_buttonResetPhone");
            this.buttonResetRegBox.Text = config.ReadConfigValue("MAU", "UD_UI_buttonResetRegBox");
            this.buttonUnlock.Text = config.ReadConfigValue("MAU", "UD_UI_buttonUnlock");

            this.btnRestIDCode.Text = config.ReadConfigValue("MAU", "UD_UI_btnRestIDCode");
            this.groupBox1.Text = config.ReadConfigValue("MAU", "UD_UI_groupBox1");
            this.btnStop.Text = config.ReadConfigValue("MAU", "UD_UI_btnStop");
            this.label1.Text = config.ReadConfigValue("MAU", "UD_UI_label1");
            this.tabPageBasic.Text = config.ReadConfigValue("MAU", "UD_UI_tabPageBasic");
            this.tabPageDetail.Text = config.ReadConfigValue("MAU", "UD_UI_tabPageDetail");
            this.buttonQA.Text = config.ReadConfigValue("MAU", "UD_UI_buttonQA");
            this.buttonSaveAS.Text = config.ReadConfigValue("MAU", "QC_UI_buttonSaveAS");
        }


        #endregion


        #region 操作
        /// <summary>
        /// 修改玩家信息
        /// </summary>
        private void ResetIDCard()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = mResult[0, 1].oContent.ToString();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                lock (typeof(C_Event.CSocketEvent))
                {
                    modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINFO_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
                }

                if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgidfail"));
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgidsucc"));
                    ReadInfo();
                    return;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void ResetVerify()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = mResult[0, 1].oContent.ToString();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                lock (typeof(C_Event.CSocketEvent))
                {
                    modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERSECURE_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
                }


                if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgcodefail"));
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                {

                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgcodesuce"));
                    ReadInfo();

                    return;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        private void ReadInfo()
        {
            try
            {
                mResult = null;
                int PageCount = 0;
                PnlResult.Controls.Clear();
                dgvResult.DataSource = null;
                CEnum.Message_Body[,] basicInfo = null;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.CARD_username;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtID.Text;

                mContent[1].eName = CEnum.TagName.CARD_nickname;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtUser.Text;

                mContent[2].eName = CEnum.TagName.CARD_ActionType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = 1;

                this.backgroundWorkerSearch.RunWorkerAsync(mContent);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USER_QUERY, mContent);
                //}

                //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                //    return;
                //}
                //else
                //{
                //    EnableBtnControl();

                //    TxtID.Enabled = false;
                //    TxtUser.Enabled = false;

                //    btnRestIDCode.Enabled = true;
                //    btnResetV.Enabled = true;

                //    //LabelTextBox[] lblTextBoxArray = new LabelTextBox[mResult.GetLength(1)];

                //    Operation_Audition.BuildDataTable(m_ClientEvent, mResult, dgvResult, out PageCount);
                //}

            }
            catch (Exception ex)
            {

            }
        }

        //重置密保邮箱
        private void ResetMailBox()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = ((DataTable)dgvResult.DataSource).Rows[0][1].ToString();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.CARD_cardtype;
                messageBody[2].oContent = "protectedEmail";

                lock (typeof(C_Event.CSocketEvent))
                {
                    modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINFO_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
                }

                if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgMailBoxfail"));
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgMailBoxsucc"));
                    //ReadInfo();
                    tabControlResult.SelectedIndex = 0;
                    return;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        //重置真实姓名
        private void ResetRealName()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = ((DataTable)dgvResult.DataSource).Rows[0][1].ToString();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.CARD_cardtype;
                messageBody[2].oContent = "realname";

                lock (typeof(C_Event.CSocketEvent))
                {
                    modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINFO_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
                }

                if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgNamefail"));
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgNamesucc"));
                    tabControlResult.SelectedIndex = 0;
                    //ReadInfo();
                    return;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        //重置电话
        private void ResetPhone()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = ((DataTable)dgvResult.DataSource).Rows[0][1].ToString();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.CARD_cardtype;
                messageBody[2].oContent = "phone";

                lock (typeof(C_Event.CSocketEvent))
                {
                    modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINFO_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
                }

                if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgPhonefail"));
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgPhonesucc"));
                    tabControlResult.SelectedIndex = 0;
                    //ReadInfo();
                    return;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        //重置注册邮箱
        private void ResetEMail()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = ((DataTable)dgvResult.DataSource).Rows[0][1].ToString();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.CARD_cardtype;
                messageBody[2].oContent = "email";

                lock (typeof(C_Event.CSocketEvent))
                {
                    modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINFO_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
                }

                if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgEmailfail"));
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgEmailsucc"));
                    tabControlResult.SelectedIndex = 0;
                    //ReadInfo();
                    return;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        //重置身份证
        private void ResetID()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = ((DataTable)dgvResult.DataSource).Rows[0][1].ToString();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.CARD_cardtype;
                messageBody[2].oContent = "IDCard";

                lock (typeof(C_Event.CSocketEvent))
                {
                    modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINFO_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
                }

                if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgidfail"));
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgidsucc"));
                    tabControlResult.SelectedIndex = 0;
                    //ReadInfo();
                    return;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        //重置安全码
        private void ResetCode()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = ((DataTable)dgvResult.DataSource).Rows[0][1].ToString();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.CARD_cardtype;
                messageBody[2].oContent = "secureCode";

                lock (typeof(C_Event.CSocketEvent))
                {
                    modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINFO_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
                }

                if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgCodefail"));
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgCodesucc"));
                    tabControlResult.SelectedIndex = 0;
                    //ReadInfo();
                    return;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        //重置问题与答案
        private void ResetQA()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = mResult[0, 1].oContent.ToString();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.CARD_cardtype;
                messageBody[2].oContent = "qa";

                lock (typeof(C_Event.CSocketEvent))
                {
                    modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINFO_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);
                }

                if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(modiInfoResult[0, 0].oContent.ToString());
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgQAfail"));
                    return;
                }

                if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgQAsucc"));
                    ReadInfo();
                    return;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region XXH
        private void DisableBtnControl()
        {
            btnResetV.Enabled = false;
            btnRestIDCode.Enabled = false;
            btnStop.Enabled = false;
            buttonResetMailBox.Enabled = false;
            buttonResetRealName.Enabled = false;
            buttonResetPhone.Enabled = false;
            buttonResetRegBox.Enabled = false;
            buttonUnlock.Enabled = false;
            buttonQA.Enabled = false;
        }

        private void EnableBtnControl()
        {
            btnResetV.Enabled = true;
            btnRestIDCode.Enabled = true;
            btnStop.Enabled = true;
            buttonResetMailBox.Enabled = true;
            buttonResetRealName.Enabled = true;
            buttonResetPhone.Enabled = true;
            buttonResetRegBox.Enabled = true;
            buttonUnlock.Enabled = true;
            buttonQA.Enabled = true;
        }
        #endregion



        private void BtnSearch_Click(object sender, EventArgs e)
        {



        }

        private void Frm_YOU_UserDetail_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            foreach (Control m in PnlResult.Controls.Find("LabelTextBox", true))
            {
                m.Dispose();
            }

            DisableBtnControl();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {



        }

        private void btnResetV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否" + btnResetV.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //ResetVerify();
                this.ResetCode();
            }
            else
            {
                return;
            }
        }

        private void btnRestIDCode_Click(object sender, EventArgs e)
        {
            //ResetIDCard();
            if (MessageBox.Show("是否" + btnRestIDCode.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.ResetID();
            }
            else
            {
                return;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgBaninfo"));
                textBox1.Focus();
                return;
            }

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.CARD_username;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtID.Text;

            mContent[1].eName = CEnum.TagName.UserByID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[2].eName = CEnum.TagName.SDO_REASON;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = textBox1.Text;

            mContent[3].eName = CEnum.TagName.CARD_cardtype;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[3].oContent = "lock";

            lock (typeof(C_Event.CSocketEvent))
            {
                stopResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERLOCK_UPDATE, mContent);
            }

            if (stopResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(stopResult[0, 0].oContent.ToString());
                return;
            }

            if (stopResult[0, 0].oContent.ToString().ToUpper().Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopfail"));
            }
            if (stopResult[0, 0].oContent.ToString().ToUpper().Equals("SUCCESS"))
            {

                foreach (Control m in PnlResult.Controls.Find("LabelTextBox", true))
                {
                    m.Dispose();
                }

                TxtID.Enabled = true;
                TxtUser.Enabled = true;

                btnRestIDCode.Enabled = false;
                btnResetV.Enabled = false;

                DisableBtnControl();


                MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopsucc"));


            }
        }

        private void buttonResetMailBox_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否" + buttonResetMailBox.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.ResetMailBox();
            }
            else
            {
                return;
            }
        }

        private void buttonResetRealName_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否" + buttonResetRealName.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.ResetRealName();
            }
            else
            {
                return;
            }
        }

        private void buttonResetPhone_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否" + buttonResetPhone.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.ResetPhone();
            }
            else
            {
                return;
            }
        }

        private void buttonResetQA_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否" + buttonQA.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.ResetQA();
            }
            else
            {
                return;
            }
        }

        private void buttonResetRegBox_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否" + buttonResetRegBox.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.ResetEMail();
            }
            else
            {
                return;
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_MsgBaninfo"));
                textBox1.Focus();
                return;
            }

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.CARD_username;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtID.Text;

            mContent[1].eName = CEnum.TagName.UserByID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[2].eName = CEnum.TagName.SDO_REASON;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = textBox1.Text;

            mContent[3].eName = CEnum.TagName.CARD_cardtype;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[3].oContent = "unlock";

            lock (typeof(C_Event.CSocketEvent))
            {
                stopResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERLOCK_UPDATE, mContent);
            }

            if (stopResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(stopResult[0, 0].oContent.ToString());
                return;
            }

            if (stopResult[0, 0].oContent.ToString().ToUpper().Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopfail"));
            }
            if (stopResult[0, 0].oContent.ToString().ToUpper().Equals("SUCCESS"))
            {

                foreach (Control m in PnlResult.Controls.Find("LabelTextBox", true))
                {
                    m.Dispose();
                }

                TxtID.Enabled = true;
                TxtUser.Enabled = true;

                btnRestIDCode.Enabled = false;
                btnResetV.Enabled = false;

                DisableBtnControl();


                MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopsucc"));
            }
        }

        private void tabControlResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlResult.SelectedTab == tabPageDetail)
            {
                buttonSaveAS.Enabled = false;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.CARD_username;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtID.Text;

                mContent[1].eName = CEnum.TagName.CARD_nickname;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtUser.Text;

                mContent[2].eName = CEnum.TagName.CARD_ActionType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = 1;

                PnlResult.Controls.Clear();
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERINFO_QUERY, mContent);
                }

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_DetailFailed"));
                    return;
                }
                else
                {
                    buttonSaveAS.Enabled = true;
                    Operation_Card.SaveTxt(config, mResult, this.Name, "GLOBAL");
                    for (int i = 0; i < mResult.GetLength(1); i++)
                    {
                        LabelTextBox mDisplay = new LabelTextBox(false);
                        //lblTextBoxArray[0] = mDisplay;

                        mDisplay.Parent = PnlResult;
                        mDisplay.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
                        mDisplay.Width = 222;

                        //mDisplay.Visible = false;

                        if (i % 2 == 0)
                        {
                            mDisplay.Top = 15 * i + 30;
                            mDisplay.Left = 44;
                        }
                        else
                        {
                            mDisplay.Top = 15 * (i - 1) + 30;
                            mDisplay.Left = mDisplay.Width + 111;
                        }

                        mDisplay.LabelText = config.ReadConfigValue("GLOBAL", mResult[0, i].eName.ToString()) + "：";
                        // mDisplay.LabelText = this.m_ClientEvent.DecodeFieldName(mResult[0, i].eName) + "：";
                        mDisplay.TextBoxText = mResult[0, i].oContent.ToString();

                    }

                    /*
                    for (int i = 0; i < lblTextBoxArray.Length; i++)
                    {
                        lblTextBoxArray[i].IsVisable = true;
                    }
                    */
                    //foreach (Control m in PnlResult.Controls.Find("LabelTextBox", true))
                    //{
                    //m.Visible = true;
                    //}


                    PnlResult.Visible = true;

                    for (int i = 0; i < PnlResult.Controls.Count; i++)
                    {
                        if (PnlResult.Controls[i].GetType() == typeof(LabelTextBox))
                        {
                            LabelTextBox mControls = (LabelTextBox)PnlResult.Controls[i];
                            mControls.ReadOnly = true;
                            mControls.IsVisable = true;
                        }
                    }
                }
            }
        }

        private void buttonSaveAS_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            if (TxtID.Text.Trim().Length <= 0 && TxtUser.Text.Trim().Length <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msginfo"));
                return;
            }
            BtnSearch.Enabled = false;
            Cursor = Cursors.WaitCursor;
            strDance = TxtID.Text.ToString();
            DisableBtnControl();

            ReadInfo();
        }

        private void BtnReset_Click_1(object sender, EventArgs e)
        {
            foreach (Control m in PnlResult.Controls.Find("LabelTextBox", true))
            {
                m.Dispose();
            }

            TxtID.Enabled = true;
            TxtUser.Enabled = true;

            btnRestIDCode.Enabled = false;
            btnResetV.Enabled = false;
            buttonSaveAS.Enabled = false;

            DisableBtnControl();
        }

        private void buttonSaveAS_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad", AppDomain.CurrentDomain.BaseDirectory+this.Name + ".txt");
            }
            catch
            {

            }
        }

        private void tabControlResult_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tabControlResult.SelectedTab == tabPageDetail)
            {
                buttonSaveAS.Enabled = false;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.CARD_username;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtID.Text;

                mContent[1].eName = CEnum.TagName.CARD_nickname;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtUser.Text;

                mContent[2].eName = CEnum.TagName.CARD_ActionType;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = 1;

                PnlResult.Controls.Clear();
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERINFO_QUERY, mContent);
                }

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_DetailFailed"));
                    return;
                }
                else
                {
                    buttonSaveAS.Enabled = true;
                    Operation_Card.SaveTxt(config, mResult, this.Name, "GLOBAL");
                    for (int i = 0; i < mResult.GetLength(1); i++)
                    {
                        LabelTextBox mDisplay = new LabelTextBox(false);
                        //lblTextBoxArray[0] = mDisplay;

                        mDisplay.Parent = PnlResult;
                        mDisplay.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
                        mDisplay.Width = 222;

                        //mDisplay.Visible = false;

                        if (i % 2 == 0)
                        {
                            mDisplay.Top = 15 * i + 30;
                            mDisplay.Left = 44;
                        }
                        else
                        {
                            mDisplay.Top = 15 * (i - 1) + 30;
                            mDisplay.Left = mDisplay.Width + 111;
                        }

                        mDisplay.LabelText = config.ReadConfigValue("GLOBAL", mResult[0, i].eName.ToString()) + "：";
                        // mDisplay.LabelText = this.m_ClientEvent.DecodeFieldName(mResult[0, i].eName) + "：";
                        mDisplay.TextBoxText = mResult[0, i].oContent.ToString();

                    }

                    /*
                    for (int i = 0; i < lblTextBoxArray.Length; i++)
                    {
                        lblTextBoxArray[i].IsVisable = true;
                    }
                    */
                    //foreach (Control m in PnlResult.Controls.Find("LabelTextBox", true))
                    //{
                    //m.Visible = true;
                    //}


                    PnlResult.Visible = true;

                    for (int i = 0; i < PnlResult.Controls.Count; i++)
                    {
                        if (PnlResult.Controls[i].GetType() == typeof(LabelTextBox))
                        {
                            LabelTextBox mControls = (LabelTextBox)PnlResult.Controls[i];
                            mControls.ReadOnly = true;
                            mControls.IsVisable = true;
                        }
                    }
                }
            }
        }

        private void UserDetailFrmLimit_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            foreach (Control m in PnlResult.Controls.Find("LabelTextBox", true))
            {
                m.Dispose();
            }

            DisableBtnControl();
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USER_QUERY, (CEnum.Message_Body[])e.Argument);

                if (mResult[0, 0].eName != CEnum.TagName.ERROR_Msg)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.TOKEN_provide;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = "viewTokenUser";

                    mContent[1].eName = CEnum.TagName.TOKEN_Type;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = "username";


                    mContent[2].eName = CEnum.TagName.TOKEN_code;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = mResult[0, 1].oContent;

                    mContent[3].eName = CEnum.TagName.TOKEN_Start;
                    mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                    mContent[3].oContent = new DateTime(2001, 1, 1);

                    mContent[4].eName = CEnum.TagName.TOKEN_End;
                    mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                    mContent[4].oContent = DateTime.Now;

                    mContent[5].eName = CEnum.TagName.PageSize;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = 10;

                    mContent[6].eName = CEnum.TagName.Index;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = 1;

                    mContent[7].eName = CEnum.TagName.TOKEN_authType;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = "";

                    e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERTOKEN_QUERY, mContent);

                    isTokenUser = (((CEnum.Message_Body[,])e.Result)[0, 0].eName == CEnum.TagName.ERROR_Msg) ? false : true;
                }

                if (mResult[0, 0].eName != CEnum.TagName.ERROR_Msg)
                {
                    CEnum.Message_Body[] mContent1 = new CEnum.Message_Body[1];

                    mContent1[0].eName = CEnum.TagName.CARD_username;
                    mContent1[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent1[0].oContent = strDance;

                    stopResult = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_DanceItem_Qualification_QUERY, mContent1);
                    isPad = (stopResult[0, 0].eName == CEnum.TagName.ERROR_Msg) ? false : true;
                }
            }


        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            Cursor = Cursors.Default;
            int PageCount = 0;

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                EnableBtnControl();

                TxtID.Enabled = false;
                TxtUser.Enabled = false;

                btnRestIDCode.Enabled = true;
                btnResetV.Enabled = true;

                //LabelTextBox[] lblTextBoxArray = new LabelTextBox[mResult.GetLength(1)];

                Operation_Audition.BuildDataTable(m_ClientEvent, mResult, dgvResult, out PageCount);
                DataTable dt = (DataTable)dgvResult.DataSource;
                if (isTokenUser)
                {
                    dt.Columns.Add(config.ReadConfigValue("MAU", "UD_UI_isTokenUser"));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][8] = config.ReadConfigValue("MAU", "UD_UI_YES");
                    }
                }
                else
                {
                    dt.Columns.Add(config.ReadConfigValue("MAU", "UD_UI_isTokenUser"));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][8] = config.ReadConfigValue("MAU", "UD_UI_NO");
                    }
                }

                if (isPad)
                {
                    dt.Columns.Add(config.ReadConfigValue("MAU", "UD_UI_ispad"));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][9] = config.ReadConfigValue("MAU", "UD_UI_YES");
                    }
                }
                else
                {
                    dt.Columns.Add(config.ReadConfigValue("MAU", "UD_UI_ispad"));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][9] = config.ReadConfigValue("MAU", "UD_UI_NO");
                    }
                }
                dgvResult.DataSource = dt;
            }
        }

    }
}