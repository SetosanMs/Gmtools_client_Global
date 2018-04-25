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
    [C_Global.CModuleAttribute("notes发信", "FrmSendMail", "notes发信", "User Group")]
    public partial class FrmSendMail : Form
    {
        public FrmSendMail()
        {
            InitializeComponent();
        }

        public FrmSendMail(int _recordID, string _UID, string _subject, string _from, DateTime _senddate, string _content,int _isnew,string _reciver)
        {
            InitializeComponent();
            this.recordID = _recordID;
            this.UID = _UID;
            this.subject = _subject;
            this.from = _from;
            this.senddate = _senddate;
            this.content = _content;
            this.isnew = _isnew;
            this.reciver = _reciver;
            txtSender.Text = _from;

            //txtSender.Text = __sender;

            //_copyfor = __supervisors;
            txtSubject.Text = "回复：" + _subject;
            txtBody.Text = "\n\n\n--------------------------------------------------------------------------------------------\n--------------------------------------------------------------------------------------------\n" + _content;
            txtCopyFor.Text = reciver;
            //_body = __body;
            //this._sender = __sender;
            //this._notes_id = __notes_id;
            //this._UID = __UID;
            //this._subject = __subject;

        }
        int recordID;
        int isnew = -1;
        string UID, subject, from, content,reciver;
        DateTime senddate;

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
        public Form CreateModule(object oParent, object oEvent, object oReturnValue)
        {
            this.m_ClientEvent = (CSocketEvent)oEvent;

            if (oParent != null)
            {
                this.MdiParent = (Form)oParent;
                this.Show();
            }
            else
            {
                if (oReturnValue != null)
                {
                    this._returnValue = (Strategy.Betweenness)oReturnValue;
                }
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterParent;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.ShowInTaskbar = false;
                this.ShowDialog();
            }

            return this;

        }
        #endregion

        #region 变量
        private CSocketEvent m_ClientEvent = null;
        private Strategy.Betweenness _returnValue = null;
        //ArrayList moduleIDs = new ArrayList();
        //private C_Global.CEnum.Message_Body[,] departmentMsg = null;
        private C_Global.CEnum.Message_Body[,] userInfos = null;

        //private Strategy.Betweenness sysRv = null;

        Strategy.Betweenness sysRv = new Strategy.Betweenness();
        TextBox _curr_textbox = new TextBox();
        #endregion


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAddress __address = new FrmAddress();
                __address.CreateModule(null, m_ClientEvent, sysRv);

                if (sysRv.RESULT == Strategy.BetweennessValue.SUCESS)
                {
                    _curr_textbox.Text = sysRv.HASHTABLE["RECEIVER"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmSendMail_Load(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = false;
            if (isnew < 0)
            {
                toolStripButton3.Visible = false;
                toolStripSeparator2.Visible = false;

            }
            else
            {
                toolStripButton3.Visible = true;
                toolStripSeparator2.Visible = true;

            }
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认发送此信件？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.toolStripButton1.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];



                mContent[0].eName = CEnum.TagName.NOTES_SUPERVISORS;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = txtCopyFor.Text;

                mContent[1].eName = CEnum.TagName.NOTES_SUBJECT;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = txtSubject.Text;

                mContent[2].eName = CEnum.TagName.NOTES_CONTENT;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = txtBody.Text;

                mContent[3].eName = CEnum.TagName.NOTES_SCRETVISORS;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = textBox1.Text;

                mContent[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mContent[4].eName = C_Global.CEnum.TagName.UserByID;
                mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[5].eName = CEnum.TagName.NOTES_RECEIVER;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = txtSender.Text;

                this.backgroundWorkerSearch.RunWorkerAsync(mContent);
            }
            else
            {
                return;
            }
        }

        private void txtCopyFor_Enter(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = true;
        }

        private void txtCopyFor_Click(object sender, EventArgs e)
        {
            try
            {   
                //if()
                //{
                 _curr_textbox = txtCopyFor;

               // }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                //e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_QueryDeleteItem_QUERY, (CEnum.Message_Body[])e.Argument);

                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_CONTENT_SEND, C_Global.CEnum.Msg_Category.NOTES_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripButton1.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                MessageBox.Show("发送成功");
                this.Close();

            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            try
            {
                _curr_textbox = textBox1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认发送此信件？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.toolStripButton3.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];



                mContent[0].eName = CEnum.TagName.NOTES_SUPERVISORS;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = txtCopyFor.Text;


                mContent[1].eName = CEnum.TagName.NOTES_CONTENT;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = txtBody.Text;

                mContent[2].eName = CEnum.TagName.NOTES_SCRETVISORS;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = textBox1.Text;

                mContent[3].eName = CEnum.TagName.NOTES_UID;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = UID;

                mContent[4].eName = CEnum.TagName.NOTES_Sender;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = txtSender.Text;

                this.backgroundWorkerSearch1.RunWorkerAsync(mContent);
            }
            else
            {
                return;
            }
        }

        private void backgroundWorkerSearch1_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                //e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_QueryDeleteItem_QUERY, (CEnum.Message_Body[])e.Argument);

                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_CONTENT_REPLAY, C_Global.CEnum.Msg_Category.NOTES_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripButton3.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                MessageBox.Show("发送成功");
                this.Close();
            }
        }

        private void txtSender_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSender.Text == "")
                {
                    _curr_textbox = txtSender;
                }
                else
                {
                    //_curr_textbox.Text =txtSender.Text.ToString() + ";" + _curr_textbox.Text.ToString();
                    //_curr_textbox = txtSender;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSender_Enter(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = true;
        }

        private void txtSender_Leave(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = false;
        }

        private void txtCopyFor_Leave(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = false;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = false;
        }

        private void txtSender_TextChanged(object sender, EventArgs e)
        {

        }
    }
}