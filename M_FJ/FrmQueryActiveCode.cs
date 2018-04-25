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

namespace M_FJ
{
    [C_Global.CModuleAttribute("帐号激活码查询", "FrmQueryActiveCode", "帐号激活码查询", "Group")]    
    public partial class FrmQueryActiveCode : Form
    {
        private CSocketEvent m_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        public FrmQueryActiveCode()
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
            FrmQueryActiveCode mModuleFrm = new FrmQueryActiveCode();
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
            //this.Text = config.ReadConfigValue("MSDO", "CI_UI_Frm_SDO_Part");
            //this.GrpSearch.Text = config.ReadConfigValue("MSDO", "CI_UI_GrpSearch");
            //this.LblServer.Text = config.ReadConfigValue("MSDO", "CI_UI_LblServer");
            //this.LblAccount.Text = config.ReadConfigValue("MSDO", "CI_UI_LblAccount");
            //this.label1.Text = config.ReadConfigValue("MSDO", "CI_UI_label1");
            //this.TpgCharacter.Text = config.ReadConfigValue("MSDO", "CI_UI_TpgCharacter");
            //this.TpgItem.Text = config.ReadConfigValue("MSDO", "CI_UI_TpgItem");
            //this.BtnSearch.Text = config.ReadConfigValue("MSDO", "CI_UI_BtnSearch");
            //this.button1.Text = config.ReadConfigValue("MSDO", "CI_UI_button1");
            //this.LblPage.Text = config.ReadConfigValue("MSDO", "CI_UI_LblPage");
            //this.labelRolePage.Text = config.ReadConfigValue("MSDO", "CI_UI_LblPage");
            //this.textBoxNotice.Text = config.ReadConfigValue("MSDO", "CI_UI_Notice");
        }


        #endregion
        private void checkBoxBat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBat.Checked)
            {

                LblAccount.Text = config.ReadConfigValue("MFj", "ActiveCode");
                checkBoxBat.Text = config.ReadConfigValue("MFj", "QueryPlayerAccont");

            }
            else
            {
                LblAccount.Text = config.ReadConfigValue("MFj", "PlayerAccont");
                checkBoxBat.Text = config.ReadConfigValue("MFj", "QueryActiveCode");
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text.Length<=0)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "CI_Code_inPutAccont"));
                return;
            }
            RoleInfoView.DataSource = null;
            if (!checkBoxBat.Checked)
            {
                QueryPlayerAccont();
            }
            else
            {
                QueryActiveCode();
            }
        }

        private void QueryActiveCode()
        {
            BtnSearch.Enabled = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

            mContent[0].eName = CEnum.TagName.FJ_UseActiveCode;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;


            backgroundWorkerActiveCode.RunWorkerAsync(mContent);
        }
        private void QueryPlayerAccont()
        {
            BtnSearch.Enabled = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

            mContent[0].eName = CEnum.TagName.FJ_UserID;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;


            backgroundWorkerAccont.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerAccont_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(m_ClientEvent, CEnum.ServiceKey.FJ_AccountActive_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerAccont_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);


        }

        private void backgroundWorkerActiveCode_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(m_ClientEvent, CEnum.ServiceKey.FJ_ActiveCode_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerActiveCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);


        }

        private void FrmQueryActiveCode_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }
    }
}