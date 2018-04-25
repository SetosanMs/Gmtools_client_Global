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
using Strategy;
using System.IO;
namespace M_GM
{
    [C_Global.CModuleAttribute("notes回复", "FrmRequsetMails", "notes回复", "User Group")]
    public partial class FrmRequsetMails : Form
    {
        public FrmRequsetMails()
        {
            InitializeComponent();
        }
        public FrmRequsetMails( int _recordID, string _UID, string _subject, string _from, DateTime _senddate, string _content, int _attachmentcnt,string _Reciver)
        {
            InitializeComponent();
            this.recordID = _recordID;
            this.UID = _UID;
            this.subject = _subject;
            this.from = _from;
            this.senddate = _senddate;
            this.content = _content;
            this.attachmentcnt = _attachmentcnt;
            this.Reciver = _Reciver;
            txtSender.Text = from;

            txtSubject.Text = subject;
            txtBody.Text = content;
            txtCopyFor.Text = Reciver;

        }
        int recordID,attachmentcnt;
        string UID, subject, from, content, Reciver;
        DateTime senddate;
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

        bool isRedirect = false;
        bool isTime = false;
  
        private CSocketEvent m_ClientEvent = null;
        private C_Global.CEnum.Message_Body[,] mailInfos = null;
        private Strategy.Betweenness _returnValue = null;
        Strategy.Betweenness sysRv = new Strategy.Betweenness();
        int iPageCount = 0;
        int notes_status = 0;
        DataTable dgTable = new DataTable();
        int dgSelect = -1;  //datagridview 中选择的行号
        private Form _parent = null;
 
        private void FrmRequsetMails_Load(object sender, EventArgs e)
        {
            try
            {
                //Mail __mail = new Mail(m_ClientEvent);
                //__mail.GetMail(0, 0, 0, 0);


                panel2.Visible = false;

                if (attachmentcnt > 0)
                    ReadAttachment(UID);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadAttachment(string __uid)
        {
            try
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];
                mContent[0].eName = CEnum.TagName.NOTES_UID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = UID;


                lock (typeof(C_Event.CSocketEvent))
                {
                    mailInfos = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_ATTACHMENT_GET, C_Global.CEnum.Msg_Category.NOTES_ADMIN, mContent);
                }
                if (mailInfos[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mailInfos[0, 0].oContent.ToString());
                    return;
                }

                //if ()
                //{
                //}
                else
                {
                    //string fileAddress = "";
                    //查看目录并创建

                    if (!Directory.Exists(@".\attachment"))
                    {
                        Directory.CreateDirectory(@".\attachment");
                    }


                        for (int i = 0; i < mailInfos.GetLength(0); i++)
                        {
                            FileStream fs = new FileStream(@"attachment\" + mailInfos[i, 0].oContent.ToString(), FileMode.Create, FileAccess.Write, FileShare.None, 1024);
                            byte[] __received_attachment = (byte[])mailInfos[i, 1].oContent;
                            fs.Write(__received_attachment, 0, __received_attachment.Length);
                            fs.Close();

                            cbxAttchment.Items.Add(mailInfos[i, 0].oContent.ToString());


                            //LinkLabel __linkLabe = new LinkLabel();
                            //__linkLabe.Location = new Point(i * 10 + i * 100 + 10, 260);
                            //__linkLabe.Parent = panel2;

                            //__linkLabe.Name = __msg[i, 0].oContent.ToString();
                            //__linkLabe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);


                        }

                        cbxAttchment.SelectedIndex = 0;

                        //cbxAttchment.Visible = true;
                        //button1.Visible = true;
                        panel2.Visible = true;
                    }
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"attachment\" + cbxAttchment.Text); 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            

            FrmSendMail __mail = new FrmSendMail(recordID, UID, subject, from, senddate, content,1,txtCopyFor.Text.Trim());
            __mail.CreateModule(_parent, m_ClientEvent, sysRv);

            

        }

        private void ReadedMails(int _NotesID)
        {
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.NOTES_ID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = _NotesID;

            mContent[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            mContent[1].eName = C_Global.CEnum.TagName.UserByID;
            mContent[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[2].eName = CEnum.TagName.Status;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = 0;

            lock (typeof(C_Event.CSocketEvent))
            {
                mailInfos = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_CONTENT_UPDATE, C_Global.CEnum.Msg_Category.NOTES_ADMIN, mContent);
            }
            if (mailInfos[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                //MessageBox.Show(mailInfos[0, 0].oContent.ToString());
                //return;
            }
            //this.backgroundWorkerMailsStauas.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerMailsStauas_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                //e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_QueryDeleteItem_QUERY, (CEnum.Message_Body[])e.Argument);

                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_CONTENT_UPDATE, C_Global.CEnum.Msg_Category.NOTES_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerMailsStauas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mailInfos = (CEnum.Message_Body[,])e.Result;
            if (mailInfos[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mailInfos[0, 0].oContent.ToString());
                return;
            }
            this.Close();
        }

        private void FrmRequsetMails_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void FrmRequsetMails_FormClosing(object sender, FormClosingEventArgs e)
        {   
            
            ReadedMails(recordID);

        }
    }
}