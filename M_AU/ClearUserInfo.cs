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
    [C_Global.CModuleAttribute("重置玩家信息", "ClearUserInfo", "重置玩家信息", "AU")]
    public partial class ClearUserInfo : Form
    {
        public ClearUserInfo()
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
            this.Text = config.ReadConfigValue("MAU", "CI_UI_ClearUserInfo");
            this.label1.Text = config.ReadConfigValue("MAU", "CI_UI_label1");
            this.btnOk.Text = config.ReadConfigValue("MAU", "CI_UI_btnOk");
            this.button1.Text = config.ReadConfigValue("MAU", "CI_UI_button1");
            this.label2.Text = config.ReadConfigValue("MAU", "CI_UI_label2");
            this.lblResultTitle.Text = config.ReadConfigValue("MAU", "CI_UI_lblResultTitle");
            
        }


        #endregion

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] modiInfoResult = null;

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

        #region 操作
        /// <summary>
        /// 修改玩家信息
        /// </summary>
        private void ResetIDCard()
        {
            try
            {
                btnOk.Enabled = false;
                Cursor = Cursors.AppStarting;
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = txtUserID.Text;

                this.backgroundWorkerResetID.RunWorkerAsync(messageBody);

                //modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINFO_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);

                //lblResult.Visible = true;
                //lblResultTitle.Visible = true;

                //if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    lblResult.Text = modiInfoResult[0, 0].oContent.ToString();
                //    return;
                //}

                //if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                //{
                //    lblResult.Text = config.ReadConfigValue("MAU", "CI_Code_MsgIDCardFail").Replace("{User}", txtUserID.Text);
                //    //lblResult.Text = "重置玩家" + txtUserID.Text + "的身份证及其类型失败";
                //    return;
                //}

                //if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                //{
                //    lblResult.Text = config.ReadConfigValue("MAU", "CI_Code_MsgIDCardSucs").Replace("{User}", txtUserID.Text);
                //    //lblResult.Text = "重置玩家" + txtUserID.Text + "的身份证及其类型成功";

                    
                //    return;
                //}

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
                button1.Enabled = false;
                Cursor = Cursors.AppStarting;
                
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = txtUserID.Text;

                this.backgroundWorkerResetCheckID.RunWorkerAsync(messageBody);

                //modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERSECURE_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, messageBody);

                //lblResult.Visible = true;
                //lblResultTitle.Visible = true;

                //if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    lblResult.Text = modiInfoResult[0, 0].oContent.ToString();
                //    return;
                //}

                //if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
                //{
                //    lblResult.Text = config.ReadConfigValue("MAU", "CI_Code_MsgVerifyFail").Replace("{User}", txtUserID.Text);
                //    return;
                //}

                //if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
                //{
                //    lblResult.Text = config.ReadConfigValue("MAU", "CI_Code_MsgVerifySucs").Replace("{User}", txtUserID.Text);


                //    return;
                //}

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void ClearUserInfo_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            lblResult.Visible = false;
            lblResultTitle.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == null || txtUserID.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "CI_Code_Msginputaccont"));
                return;
            }

            if (MessageBox.Show(config.ReadConfigValue("MAU", "CI_Code_MsgMsgIDCard"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
            {

                lblResult.Visible = false;
                lblResultTitle.Visible = false;
                ResetIDCard();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == null || txtUserID.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "CI_Code_Msginputaccont"));
                return;
            }

            if (MessageBox.Show(config.ReadConfigValue("MAU", "CI_Code_MsgVerify"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
            {

                lblResult.Visible = false;
                lblResultTitle.Visible = false;
                ResetVerify();
            }
        }

        private void backgroundWorkerResetID_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINFO_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerResetID_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOk.Enabled = true;
            Cursor = Cursors.Default;
            lblResult.Visible = true;
            lblResultTitle.Visible = true;

            if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                lblResult.Text = modiInfoResult[0, 0].oContent.ToString();
                return;
            }

            if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                lblResult.Text = config.ReadConfigValue("MAU", "CI_Code_MsgIDCardFail").Replace("{User}", txtUserID.Text);
                //lblResult.Text = "重置玩家" + txtUserID.Text + "的身份证及其类型失败";
                return;
            }

            if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
            {
                lblResult.Text = config.ReadConfigValue("MAU", "CI_Code_MsgIDCardSucs").Replace("{User}", txtUserID.Text);
                //lblResult.Text = "重置玩家" + txtUserID.Text + "的身份证及其类型成功";


                return;
            }
        }

        private void backgroundWorkerResetCheckID_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                modiInfoResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERSECURE_CLEAR, C_Global.CEnum.Msg_Category.CARD_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerResetCheckID_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            Cursor = Cursors.Default;

            lblResult.Visible = true;
            lblResultTitle.Visible = true;

            if (modiInfoResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                lblResult.Text = modiInfoResult[0, 0].oContent.ToString();
                return;
            }

            if (modiInfoResult[0, 0].oContent.ToString().Equals("FAILURE"))
            {
                lblResult.Text = config.ReadConfigValue("MAU", "CI_Code_MsgVerifyFail").Replace("{User}", txtUserID.Text);
                return;
            }

            if (modiInfoResult[0, 0].oContent.ToString().Equals("SUCCESS"))
            {
                lblResult.Text = config.ReadConfigValue("MAU", "CI_Code_MsgVerifySucs").Replace("{User}", txtUserID.Text);


                return;
            }
        }
    }
}