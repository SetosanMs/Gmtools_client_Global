using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Strategy;
using C_Global;
using C_Event;
using Language;

namespace M_GM
{
    [C_Global.CModuleAttribute("notes列表", "FrmNotesList", "notes列表", "User Group")]
    public partial class FrmNotesList : Form
    {
        public FrmNotesList()
        {
            InitializeComponent();
        }

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
        #region 变量
        private CSocketEvent m_ClientEvent = null;
        private C_Global.CEnum.Message_Body[,] mailInfos = null;
        private Strategy.Betweenness _returnValue = null;
        Strategy.Betweenness sysRv = new Strategy.Betweenness();
        int iPageCount = 0;
        int notes_status = 0;
        DataTable dgTable = new DataTable();
        int dgSelect = -1;  //datagridview 中选择的行号
        private Form _parent = null;
        string[,] __notes_type = new string[,]{
            {"0","未查看信件"},
            {"1","已查看信件"},

        };


        #endregion

        public void BuildCombox(string[,] arr, System.Windows.Forms.ToolStripComboBox mCmbBox)
        {
            try
            {
                mCmbBox.Items.Clear();
                if (arr != null)
                {
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        mCmbBox.Items.Add(arr[i, 1]);
                    }
                    mCmbBox.SelectedIndex = 0;
                }
                mCmbBox.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void IntiNotesType()
        {
            try
            {
                cbxNotesType.Items.Clear();
                BuildCombox(__notes_type, this.cbxNotesType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReadMails()
        {
            toolStripButton1.Enabled = false;
            if (isTime == false)
            {   

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.Index;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 1;

                mContent[1].eName = CEnum.TagName.PageSize;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = 50;

                mContent[2].eName = CEnum.TagName.Status;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = notes_status;

                this.backgroundWorkerSearch.RunWorkerAsync(mContent);

            }
        }

        private void FrmNotesList_Load(object sender, EventArgs e)
        {
            IntiNotesType();
            ReadMails();
        }

        private DataTable BrowseResultInfo()
        {
            try
            {
                //dgTable.Columns.Clear();       //清空头信息


                //dgTable.Rows.Clear();          //清空行记录



                dgTable = new DataTable();
                dgTable.Columns.Add("NOTES_ID");
                dgTable.Columns.Add("NOTES_UID");
                dgTable.Columns.Add("信件分类");
                dgTable.Columns.Add("主题");
                dgTable.Columns.Add("收件人");
                dgTable.Columns.Add("抄送人");
                dgTable.Columns.Add("时间");
                dgTable.Columns.Add("内容");
                dgTable.Columns.Add("附件数量");
                dgTable.Columns.Add("是否浏览");
                dgTable.Columns.Add("NOTES_Status");

                //dgTable.Columns.Add("内容");


                for (int i = 0; i < mailInfos.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow["NOTES_ID"] = mailInfos[i, 0].oContent.ToString();
                    dgRow["NOTES_UID"] = mailInfos[i, 2].oContent.ToString();
                    dgRow["信件分类"] = mailInfos[i, 1].oContent.ToString();
                    dgRow["主题"] = mailInfos[i, 4].oContent.ToString();
                    dgRow["收件人"] = mailInfos[i, 6].oContent.ToString();
                    dgRow["抄送人"] = mailInfos[i, 7].oContent.ToString();
                    dgRow["时间"] = mailInfos[i, 5].oContent.ToString();
                    dgRow["内容"] = mailInfos[i, 8].oContent.ToString();
                    dgRow["附件数量"] = mailInfos[i, 9].oContent.ToString();
                    dgRow["是否浏览"] = (int.Parse(mailInfos[i, 11].oContent.ToString())==0)?"未浏览":"浏览中";
                    dgRow["NOTES_Status"] = mailInfos[i, 12].oContent.ToString();


                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }
        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                //e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_QueryDeleteItem_QUERY, (CEnum.Message_Body[])e.Argument);

                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_CONTENT_GET, C_Global.CEnum.Msg_Category.NOTES_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripButton1.Enabled = true;
             mailInfos = (CEnum.Message_Body[,])e.Result;
             if (mailInfos[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mailInfos[0, 0].oContent.ToString());
                return;
            }
            iPageCount = int.Parse(mailInfos[0, 13].oContent.ToString());
            dataGV.DataSource = null;
            dataGV.DataSource = BrowseResultInfo();

            isRedirect = false;

            Strategy.HideField hideField = new Strategy.HideField();
            hideField.HideSomeFiled(dataGV);
            //DataTable dt = (DataTable)dataGV.DataSource;

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (dt.Rows[i].ItemArray[10].ToString() == "1")
            //    {
            //        this.dataGV.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            //    }

            //}

            if (iPageCount <= 0)
            {
                cbxPageIndex.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    cbxPageIndex.Items.Add(i + 1);
                }

                cbxPageIndex.SelectedIndex = 0;
                isRedirect = true;

            }

        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                //e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_QueryDeleteItem_QUERY, (CEnum.Message_Body[])e.Argument);

                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_CONTENT_GET, C_Global.CEnum.Msg_Category.NOTES_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.cbxPageIndex.Enabled = true;
                this.Cursor = Cursors.Default;

                mailInfos = (CEnum.Message_Body[,])e.Result;
                if (mailInfos[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mailInfos[0, 0].oContent.ToString());
                    return;
                }
                iPageCount = int.Parse(mailInfos[0, 10].oContent.ToString());
                dataGV.DataSource = BrowseResultInfo();
                Strategy.HideField hideField = new Strategy.HideField();
                hideField.HideSomeFiled(dataGV);
            }

            catch
            { }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {   
            //            {"0","未处理信件"},
            //{"1","已处理信件"},
            //{"2","待处理信件"}
            try
            {
                cbxPageIndex.Items.Clear();
                if (cbxNotesType.Text.Trim() == "未查看信件")
                {
                    notes_status = 0;
                }
                else if (cbxNotesType.Text.Trim() == "已查看信件")
                {
                    notes_status = 1;
                }
                dataGV.DataSource = null;
                ReadMails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgSelect = e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SendReadMails(int _NotesID)
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
                mContent[2].oContent = 1;

                this.backgroundWorkerMailsStauas.RunWorkerAsync(mContent);

        }
        private void DelReadMails(int _NotesID)
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
            mContent[2].oContent = 1;

            this.backgroundWorkerDel.RunWorkerAsync(mContent);

        }
        private void dataGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgSelect = e.RowIndex;

                if (dgSelect != -1)
                {   
                    DataTable dt = (DataTable)dataGV.DataSource;

                    int recordID = int.Parse(dt.Rows[dgSelect].ItemArray[0].ToString());
                    string UID = dt.Rows[dgSelect].ItemArray[1].ToString();
                    string subject = dt.Rows[dgSelect].ItemArray[3].ToString();
                    string from = dt.Rows[dgSelect].ItemArray[4].ToString();
                    string reciver = dt.Rows[dgSelect].ItemArray[5].ToString();
                    DateTime send_date = DateTime.Parse(dt.Rows[dgSelect].ItemArray[6].ToString());
                    string content = dt.Rows[dgSelect].ItemArray[7].ToString();
                    int attachmentcnt = int.Parse(dt.Rows[dgSelect].ItemArray[8].ToString());
                    string  NotesFlag = dt.Rows[dgSelect].ItemArray[9].ToString();

                    if (NotesFlag == "浏览中")
                    {
                        MessageBox.Show("当前信件正在被其他用户浏览 请稍候在试");
                        return;
                    }

                    SendReadMails(recordID);


                    //dgRow["NOTES_ID"] = mailInfos[i, 0].oContent.ToString();
                    //dgRow["NOTES_UID"] = mailInfos[i, 2].oContent.ToString();
                    //dgRow["主题"] = mailInfos[i, 4].oContent.ToString();
                    //dgRow["收件人"] = mailInfos[i, 6].oContent.ToString();
                    //dgRow["时间"] = mailInfos[i, 5].oContent.ToString();
                    //dgRow["内容"] = mailInfos[i, 7].oContent.ToString();
                    //dgRow["AttachmentCount"] = mailInfos[i, 8].oContent.ToString();

                    FrmRequsetMails __mail = new FrmRequsetMails(recordID, UID, subject, from, send_date, content, attachmentcnt, reciver);
                    __mail.CreateModule(_parent, m_ClientEvent, sysRv);

                    

                    if (sysRv.RESULT == Strategy.BetweennessValue.SUCESS)
                    {
                        //
                    }
                }
                else
                {
                    //MessageBox.Show(TextConst._SelectARecord);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxPageIndex_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //dgSelect = e.RowIndex;

                if (dgSelect != -1)
                {
                    DataTable dt = (DataTable)dataGV.DataSource;

                    int recordID = int.Parse(dt.Rows[dgSelect].ItemArray[0].ToString());

                    DelReadMails(recordID);
                   


                }
                else
                {
                    MessageBox.Show("请先选择一条记录");
                    return;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                //e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_QueryDeleteItem_QUERY, (CEnum.Message_Body[])e.Argument);

                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_CONTENT_UPDATE, C_Global.CEnum.Msg_Category.NOTES_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mailInfos = (CEnum.Message_Body[,])e.Result;
            if (mailInfos[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mailInfos[0, 0].oContent.ToString());
                return;
            }
            //this.Close();
        }

        private void backgroundWorkerDel_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                //e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_QueryDeleteItem_QUERY, (CEnum.Message_Body[])e.Argument);

                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_CONTENT_DELETE, C_Global.CEnum.Msg_Category.NOTES_ADMIN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mailInfos = (CEnum.Message_Body[,])e.Result;
            if (mailInfos[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mailInfos[0, 0].oContent.ToString());
                return;
            }
            else
            {
                MessageBox.Show("删除成功");
                dataGV.DataSource = null;
                ReadMails();
            }
        }

        private void cbxPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRedirect)
            {
                this.cbxPageIndex.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                //CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                //mContent[0].eName = CEnum.TagName.SDO_Account;
                //mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                //mContent[0].oContent = TxtAccount.Text;

                //mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                //mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                //mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                //mContent[2].eName = CEnum.TagName.Index;
                //mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                //mContent[2].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_SDO.iPageSize + 1;

                //mContent[3].eName = CEnum.TagName.PageSize;
                //mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                //mContent[3].oContent = Operation_SDO.iPageSize;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];
                mContent[0].eName = CEnum.TagName.Index;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = (int.Parse(cbxPageIndex.Text));

                mContent[1].eName = CEnum.TagName.PageSize;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = 50;

                mContent[2].eName = CEnum.TagName.Status;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = notes_status;

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);

                //CEnum.Message_Body[,] mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_MEMBERBANISHMENT_QUERY, mContent);

                //Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdResult, out iPageCount);
            }
        }

        private void dataGV_DataSourceChanged(object sender, EventArgs e)
        {
            if (dataGV.DataSource!=null)
            {
            DataTable dt = (DataTable)dataGV.DataSource;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[10].ToString() == "1")
                {
                    this.dataGV.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }

            }
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            try
            {
                cbxPageIndex.Items.Clear();
                cbxNotesType.Text = "未查看信件";
                if (cbxNotesType.Text.Trim() == "未查看信件")
                {
                    notes_status = 0;
                }
                else if (cbxNotesType.Text.Trim() == "已查看信件")
                {
                    notes_status = 1;
                }
                dataGV.DataSource = null;
                ReadMails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxNotesType_Click(object sender, EventArgs e)
        {

        }
    }
}