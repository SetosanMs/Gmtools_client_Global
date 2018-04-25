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
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("用户余额查询", "FrmUserCashExp", "用户余额查询[充值消费]", "AU Group")]
    public partial class FrmUserCashExp : Form
    {
        private CSocketEvent m_ClientEvent = null;

        public FrmUserCashExp()
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
            FrmUserCashExp mModuleFrm = new FrmUserCashExp();
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
            this.Text = config.ReadConfigValue("MAU", "FUC_UI_txt");
            this.GrpSearch.Text = config.ReadConfigValue("MAU", "BR_UI_GrpResult");
            this.button1.Text = config.ReadConfigValue("MAU", "BR_UI_button1");
            this.LblAccount.Text = config.ReadConfigValue("MAU", "BR_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MAU", "BR_UI_BtnSearch");
            this.buttonSaveAS.Text = config.ReadConfigValue("MAU", "QC_UI_buttonSaveAS");
        }


        #endregion


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            foreach (Control m in PnlDetail.Controls.Find("LabelTextBox", true))
            {
                m.Dispose();
            }

            //条件限制
            if (TxtAccount.Text.Trim().Length <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BR_CODE_InputUserName"));
                return;
            }
            BtnSearch.Enabled = false;
            Cursor = Cursors.AppStarting;
            this.buttonSaveAS.Enabled = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];
            mContent[0].eName = CEnum.TagName.SDO_Account;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text.Trim();

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_UserCashExp_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnSearch.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            //CmbServer.Enabled = false;
            TxtAccount.Enabled = false;
            this.buttonSaveAS.Enabled = true;

            //if (mResult[0, 8].eName == C_Global.CEnum.TagName.SDO_ActiveStatus && mResult[0, 8].oContent.ToString() == "1")
            //{
            //    LblDetail.Text = config.ReadConfigValue("MSDO", "AF_Code_UserEnabledDes").Replace("{Account}", TxtAccount.Text).Replace("{Server}", CmbServer.Text);
            //}

            //if (mResult[0, 8].eName == C_Global.CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "ERROR")
            //{
            //    LblDetail.Text = config.ReadConfigValue("MSDO", "AF_Code_UserNotEnabledDes").Replace("{Account}", TxtAccount.Text).Replace("{Server}", CmbServer.Text);
            //}

            PnlDetail.Visible = false;
            Operation_Card.SaveTxt(config, mResult, this.Name, "MAU");
            for (int i = 0; i < mResult.GetLength(1); i++)
            {
                LabelTextBox mDisplay = new LabelTextBox();
                mDisplay.Parent = PnlDetail;
                mDisplay.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
                mDisplay.Width = 222;

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
                mDisplay.Font = new Font("幼圆", 12);
                mDisplay.LabelText = config.ReadConfigValue("MAU", mResult[0, i].eName.ToString()) + ":";
                mDisplay.TextBoxText = mResult[0, i].oContent.ToString();
            }
            PnlDetail.Visible = true;

            for (int i = 0; i < PnlDetail.Controls.Count; i++)
            {
                if (PnlDetail.Controls[i].GetType() == typeof(LabelTextBox))
                {
                    LabelTextBox mControls = (LabelTextBox)PnlDetail.Controls[i];
                    mControls.ReadOnly = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TxtAccount.Enabled = true;
            TxtAccount.Clear();
            buttonSaveAS.Enabled = false;

            LblDetail.Text = "";
            foreach (Control m in PnlDetail.Controls.Find("LabelTextBox", true))
            {
                m.Dispose();
            }
        }


        private void buttonSaveAS_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad", AppDomain.CurrentDomain.BaseDirectory + this.Name + ".txt");
            }
            catch
            {

            }
        }

        private void FrmUserCashExp_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }











    }
}