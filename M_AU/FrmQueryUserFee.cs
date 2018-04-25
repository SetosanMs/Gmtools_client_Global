//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;

//namespace M_AU
//{
//    public partial class FrmQueryUserFee : Form
//    {
//        public FrmQueryUserFee()
//        {
//            InitializeComponent();
//        }

//        private void FrmQueryUserFee_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;

using Language;

namespace M_Audition
{
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("�û���ֵ��¼", "FrmQueryUserFee", "�û���ֵ��¼[��ֵ����]", "AU Group")] 
    public partial class FrmQueryUserFee : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iSort = 1;
        private int iPageCount = 0;
        private bool bFirst = false;

        public FrmQueryUserFee()
        {
            InitializeComponent();
        }

        #region ���Կ�
        /// <summary>
        ///�����ֿ�
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// ��ʼ�����������Կ�
        /// </summary>
        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MAU", "FSC_UI_FrmQueryUserFee ");
            this.GrpSearch.Text = config.ReadConfigValue("MAU", "FSC_UI_GrpSearch");
            this.labelStartDate.Text = config.ReadConfigValue("MAU", "FSC_UI_labelStartDate");

            this.BtnSearch.Text = config.ReadConfigValue("MAU", "FSC_UI_BtnSearch");


            this.GrpResult.Text = config.ReadConfigValue("MAU", "FSC_UI_GrpResult");


        }


        #endregion

        #region �Զ�������¼�
        /// <summary>
        /// ��������еĴ���
        /// </summary>
        /// <param name="oParent">MDI ����ĸ�����</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>����еĴ���</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //������¼����
            FrmQueryUserFee mModuleFrm = new FrmQueryUserFee();
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




        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            RoleInfoView.DataSource = null;

            //��������
            if (lblAccountOrNick.Text.Trim().Length <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "CL_Code_Msginput"));
                return;
            }


            //��ʼʱ��������2005��
            if (dateTimePickerStart.Value.Year < 2005)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FSC_CODE_Msg2"));
                return;
            }

            BtnSearch.Enabled = false;
            Cursor = Cursors.AppStarting;

            //�����ѯ����
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

            mContent[0].eName = CEnum.TagName.CARD_username;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = lblAccountOrNick.Text.Trim();

            mContent[1].eName = CEnum.TagName.CARD_PayStartDate;
            mContent[1].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[1].oContent = dateTimePickerStart.Value;


            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerSearch_DoWork_1(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCARDHISTORY_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnSearch.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);
        }

        private void FrmQueryUserFee_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }



    }
}