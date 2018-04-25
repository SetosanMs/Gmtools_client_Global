using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C_Event;
using C_Global;
using M_Audition;

namespace M_AU
{
    [C_Global.CModuleAttribute("��ѯ����̺��ȡ�ʸ�", "FrmItem", "��ѯ����̺��ȡ�ʸ�", "9YOU Group")]
    //������lnczly1����
    public partial class FrmItem : Form
    {
        public FrmItem()
        {
            InitializeComponent();
            btnCancle.Enabled = false;
            grvResult.DataSource = null;
        }

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
            FrmItem mModuleFrm = new FrmItem();
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

        #region
        private CSocketEvent m_ClientEvent = null;
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            grvResult.DataSource = null;
            btnSearch.Enabled = txtUserName.Enabled = false;
            btnCancle.Enabled = false;

            if (txtUserName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("�û�������Ϊ�գ�");

                this.Cursor = Cursors.Default;
                btnSearch.Enabled = txtUserName.Enabled = true;
            }
            else
            {
                btnCancle.Enabled = true;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

                mContent[0].eName = CEnum.TagName.CARD_username;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = txtUserName.Text.Trim();

                if (bwSearch.IsBusy)
                {
                    MessageBox.Show("���ڲ�����ֹ��ѯ������");
                }
                else
                {
                    bwSearch.RunWorkerAsync(mContent);
                }
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (bwSearch.IsBusy)
            {
                bwSearch.CancelAsync();                
            }

            if (!bwSearch.IsBusy)
            {
                MessageBox.Show("����ȡ����ѯ������");

                btnCancle.Enabled = false;
                grvResult.DataSource = null;
                btnSearch.Enabled = txtUserName.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            else
            {
                btnCancle.Enabled = true;
            }
        }

        private void bwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_DanceItem_Qualification_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void bwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int pg = 0;
            btnSearch.Enabled = txtUserName.Enabled = true;
            this.Cursor = Cursors.Default;
            btnCancle.Enabled = false;
            try
            {
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    this.txtUserName.Clear();
                    btnCancle.Enabled = false;
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    Operation_Card.BuildDataTable(m_ClientEvent, mResult, this.grvResult, out pg);
                }
            }
            catch
            {
                MessageBox.Show("���������쳣��");
            }
        }
    }
}