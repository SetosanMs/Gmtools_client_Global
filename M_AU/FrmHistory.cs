using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C_Global;
using C_Event;
using M_Audition;

namespace M_AU
{
    [C_Global.CModuleAttribute("查询重置历史", "FrmHistory", "查询重置历史", "9YOU Group")]
    public partial class FrmHistory : Form
    {
        public FrmHistory()
        {
            InitializeComponent();
            btnCancle.Enabled = false;
            grvResult.DataSource = null;

            dtpStart.Value = DateTime.Now.Add(new TimeSpan(-5, 0, 0, 0));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            btnCancle.Enabled = false;
            grvResult.DataSource = null;
            btnSearch.Enabled = txtUserName.Enabled = txtIP.Enabled = false;

            if (txtUserName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("用户名不能为空！");

                this.Cursor = Cursors.Default;
                btnSearch.Enabled = txtUserName.Enabled = txtIP.Enabled = true;
            }
            else
            {
                btnCancle.Enabled = true;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.CARD_username;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = txtUserName.Text.Trim();

                mContent[1].eName = CEnum.TagName.CARD_REGIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = txtIP.Text.Trim();

                mContent[2].eName = CEnum.TagName.CARD_START_DATE;
                mContent[2].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[2].oContent = dtpStart.Value;

                mContent[3].eName = CEnum.TagName.CARD_END_DATE;
                mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[3].oContent = dtpStop.Value;

                if (bwSearch.IsBusy)
                {
                    MessageBox.Show("现在不能中止查询操作！");
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

                MessageBox.Show("您已取消查询操作！");

                btnCancle.Enabled = false;
                grvResult.DataSource = null;
                btnSearch.Enabled = txtUserName.Enabled = txtIP.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            else
            {
                btnCancle.Enabled = true;
            }
        }

        //异步的执行
        private void bwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_RESETHISTORY_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        //执行结束
        private void bwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int pg = 0;
            btnSearch.Enabled = txtUserName.Enabled = txtIP.Enabled = true;
            this.Cursor = Cursors.Default;
            btnCancle.Enabled = false;
            try
            {
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    this.txtIP.Clear();
                    this.txtUserName.Clear();

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
                MessageBox.Show("解析数据异常！");
            }
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
            FrmHistory mModuleFrm = new FrmHistory();
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
    }
}