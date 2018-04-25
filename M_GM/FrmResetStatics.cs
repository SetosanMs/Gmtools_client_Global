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

namespace M_GM
{
    [C_Global.CModuleAttribute("9YOU重置信息统计", "FrmResetStatics", "9YOU重置信息统计", "User Group")]
    public partial class FrmResetStatics : Form
    {
        public FrmResetStatics()
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
        private C_Global.CEnum.Message_Body[,] GMListResult = null;
        private C_Global.CEnum.Message_Body[,] mResult = null;


        private int _userID = 0;

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
            this.Text = config.ReadConfigValue("MGM", "FRS_UI_Text");


            this.label2.Text = config.ReadConfigValue("MGM", "LOG_UI_BeginDate");
            this.label4.Text = config.ReadConfigValue("MGM", "LOG_UI_EndDate");
            this.label1.Text = config.ReadConfigValue("MGM", "LOG_UI_Account");
            this.button1.Text = config.ReadConfigValue("MGM", "LOG_UI_BtnView");
            this.groupBoxResult.Text = config.ReadConfigValue("MGM", "FRS_UI_groupBoxResult");
        }


        #endregion

        private void FrmResetStatics_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.Index;
                messageBody[0].oContent = 1;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
                messageBody[1].oContent = 1000;

                lock (typeof(C_Event.CSocketEvent))
                {
                    GMListResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, messageBody);
                }

                //检测状态

                if (GMListResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(GMListResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //显示内容到列表

                for (int i = 0; i < GMListResult.GetLength(0); i++)
                {
                    this.userID.Items.Add(GMListResult[i, 5].oContent.ToString());
                }
                userID.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.userID.Text == "" || this.userID.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "LOG_UI_ChooseGM"));
                this.userID.Focus();
                return;
            }
            richTextBoxResult.Text = "";

            #region 查询GM ID
            for (int i = 0; i < this.GMListResult.GetLength(0); i++)
            {
                if (GMListResult[i, 5].oContent.ToString().Trim().Equals(this.userID.Text.Trim()))
                {
                    this._userID = int.Parse(GMListResult[i, 0].oContent.ToString());
                }
            }
            #endregion

            try
            {
                //移除上次显示列表

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];


                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.User_ID;
                messageBody[0].oContent = _userID;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[1].eName = C_Global.CEnum.TagName.BeginTime;
                messageBody[1].oContent = Convert.ToDateTime(this.beginDate.Text);

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_DATE;
                messageBody[2].eName = C_Global.CEnum.TagName.EndTime;
                messageBody[2].oContent = Convert.ToDateTime(this.endDate.Text);


                mResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.GMTOOLS_RESETSTATICS_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //检测状态

                if (mResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    switch (mResult[i, 0].oContent.ToString())
                    {
                        case "email":
                            richTextBoxResult.Text += config.ReadConfigValue("MAU", "UD_UI_buttonResetRegBox") + ":";
                            break;
                        case "IDCard":
                            richTextBoxResult.Text += config.ReadConfigValue("MAU", "UD_UI_btnRestIDCode") + ":";
                            break;
                        case "phone":
                            richTextBoxResult.Text += config.ReadConfigValue("MAU", "UD_UI_buttonResetPhone") + ":";
                            break;
                        case "protectedEmail":
                            richTextBoxResult.Text += config.ReadConfigValue("MAU", "UD_UI_buttonResetMailBox") + ":";
                            break;
                        case "qa":
                            richTextBoxResult.Text += config.ReadConfigValue("MAU", "UD_UI_buttonResetQA") + ":";
                            break;
                        case "realname":
                            richTextBoxResult.Text += config.ReadConfigValue("MAU", "UD_UI_buttonResetRealName") + ":";
                            break;
                        case "secureCode":
                            richTextBoxResult.Text += config.ReadConfigValue("MAU", "UD_UI_btnResetV") + ":";
                            break;
                    }
                    richTextBoxResult.Text += mResult[i, 1].oContent.ToString() + config.ReadConfigValue("MGM", "FRS_UI_Times") +"\r\n\r\n";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}