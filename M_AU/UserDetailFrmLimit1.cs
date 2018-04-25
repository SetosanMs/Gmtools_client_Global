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
    [C_Global.CModuleAttribute("9YOU用户信息", "UserDetailFrmLimit", "注册用户管理工具(高级用户) -- 9YOU用户信息", "AU Group")] 
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

        C_Global.CEnum.Message_Body[,] modiInfoResult = null;

        CEnum.Message_Body[,] mResult = null;
        CEnum.Message_Body[,] stopResult = null;

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

            this.btnRestIDCode.Text = config.ReadConfigValue("MAU", "UD_UI_btnRestIDCode");
            this.groupBox1.Text = config.ReadConfigValue("MAU", "UD_UI_groupBox1");
            this.btnStop.Text = config.ReadConfigValue("MAU", "UD_UI_btnStop");
            this.label1.Text = config.ReadConfigValue("MAU", "UD_UI_label1");
            this.buttonSaveAS.Text = config.ReadConfigValue("MAU", "QC_UI_buttonSaveAS");

        }


        #endregion

        #region XXH
        private void DisableBtnControl()
        {
            btnResetV.Enabled = false;
            btnRestIDCode.Enabled = false;
            btnStop.Enabled = false;
            buttonSaveAS.Enabled = false;
        }

        private void EnableBtnControl()
        {
            btnResetV.Enabled = true;
            btnRestIDCode.Enabled = true;
            btnStop.Enabled = true;
        }
        #endregion

         
        private void ReadInfo()
        {
            mResult = null;

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

            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERINFO_QUERY, mContent);
            }

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            TxtID.Enabled = false;
            TxtUser.Enabled = false;

            btnRestIDCode.Enabled = true;
            btnResetV.Enabled = true;

            this.buttonSaveAS.Enabled = true;
            //LabelTextBox[] lblTextBoxArray = new LabelTextBox[mResult.GetLength(1)];
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
                    mDisplay.Top = 20 * i + 30;
                    mDisplay.Left = 44;
                }
                else
                {
                    mDisplay.Top = 20 * (i - 1) + 30;
                    mDisplay.Left = mDisplay.Width + 111;
                }

                mDisplay.LabelText = config.ReadConfigValue("GLOBAL", mResult[0, i].eName.ToString()) + "：";
                // mDisplay.LabelText = this.m_ClientEvent.DecodeFieldName(mResult[0, i].eName) + "：";
                mDisplay.TextBoxText = mResult[0, i].oContent.ToString();

                EnableBtnControl();
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



        private void BtnSearch_Click(object sender, EventArgs e)
        {

            if (TxtID.Text.Trim().Length <= 0 && TxtUser.Text.Trim().Length <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msginfo"));
                return;
            }

            DisableBtnControl();

            ReadInfo();
        }

        private void UserDetailFrmPower_Load(object sender, EventArgs e)
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

            foreach (Control m in PnlResult.Controls.Find("LabelTextBox", true))
            {
                m.Dispose();
            }

            TxtID.Enabled = true;
            TxtUser.Enabled = true;

            btnRestIDCode.Enabled = false;
            btnResetV.Enabled = false;
            this.buttonSaveAS.Enabled = false;

            DisableBtnControl();
        }

        private void buttonSaveAS_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad", this.Name + ".txt");
            }
            catch
            {

            }
        }
    }
}