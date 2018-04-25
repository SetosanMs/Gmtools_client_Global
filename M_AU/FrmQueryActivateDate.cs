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
    [C_Global.CModuleAttribute("���Ƽ����ѯ", "FrmQueryActivateDate", "���Ƽ����ѯ", "AU Group")]
    public partial class FrmQueryActivateDate : Form
    {
        public FrmQueryActivateDate()
        {
            InitializeComponent();
        }

        private CSocketEvent m_ClientEvent = null;

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
            FrmQueryActivateDate mModuleFrm = new FrmQueryActivateDate();
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
            this.Text = config.ReadConfigValue("MAU", "FAT_UI_txt");
            //this.GrpSearch.Text = config.ReadConfigValue("MAU", "BR_UI_GrpResult");
            this.button1.Text = config.ReadConfigValue("MAU", "BR_UI_button1");
            this.LblAccount.Text = config.ReadConfigValue("MAU", "FAT_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MAU", "BR_UI_BtnSearch");
          

        }


        #endregion
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //��������
            if (TxtAccount.Text.Trim().Length <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "BR_CODE_InputUserESN"));
                return;
            }
            BtnSearch.Enabled = false;
            Cursor = Cursors.AppStarting;
            
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];
            mContent[0].eName = CEnum.TagName.TOKEN_esn;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text.Trim();

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void FrmQueryActivateDate_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERACTIVETOKEN_QUERY, (CEnum.Message_Body[])e.Argument);
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
            int iPageCount = 0;
            //CmbServer.Enabled = false;
            Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GrdResult.DataSource = null;
            TxtAccount.Text = "";
        }
    }
}