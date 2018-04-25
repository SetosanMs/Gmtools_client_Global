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

namespace M_GM
{
    [C_Global.CModuleAttribute("GM问题处理", "BugHandle", "GM问题处理", "User Group")]
    public partial class BugHandle : Form
    {
        public BugHandle()
        {
            InitializeComponent();
        }

        #region 变量
        public CSocketEvent m_ClientEvent = null;

        private int userID = 0;	//用户id
        private int bugID = 0;//问题id

        private bool bFirst = false;

        private int pageIndex = 1;
        private int pageSize = 20;
        ArrayList userIDs = new ArrayList();

        //private C_Global.CEnum.Message_Body[,] gameListResult = null;
        //private C_Global.CEnum.Message_Body[,] moduleListResult = null;
        //private C_Global.CEnum.Message_Body[,] userRoleResult = null;
        //private DataTable UserModule = new DataTable();

        //ArrayList moduleIDs = new ArrayList();


        #endregion

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

        #region 自定义函数
        /// <summary>
        /// Bug列表
        /// </summary>
        /// <param name="gameID"></param>
        private void InitializeBugList()
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.Index;
            messageBody[0].oContent = pageIndex;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[1].eName = C_Global.CEnum.TagName.PageSize;
            messageBody[1].oContent = pageSize;

            this.backgroundWorkerPageChanged.RunWorkerAsync(messageBody);
        }

        /// <summary>
        /// 构造DataTable
        /// </summary>
        /// <param name="mResult"></param>
        private DataTable BuildTable(C_Global.CEnum.Message_Body[,] mResult)
        {
            userIDs.Clear();
            try
            {
                DataTable mTable = new DataTable();
                for (int i = 0; i < mResult.GetLength(1); i++)
                {
                    if (mResult[0, i].eName == CEnum.TagName.User_ID)
                    {
                        continue;
                    }
                    if (mResult[0, i].eName != CEnum.TagName.PageCount)
                    {
                        mTable.Columns.Add((string)config.ReadConfigValue("MGM", mResult[0, i].eName.ToString()), typeof(string));
                    }
                }
                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow row = mTable.NewRow();
                    for (int j = 0; j < mResult.GetLength(1); j++)
                    {
                        if (mResult[i, j].eName == CEnum.TagName.Bug_Process)
                        {
                            if (mResult[i, j].oContent.ToString() == "0")
                                row[config.ReadConfigValue("MGM", mResult[i, j].eName.ToString())] = config.ReadConfigValue("MGM", "BL_Code_UnProcessed");
                            else row[config.ReadConfigValue("MGM", mResult[i, j].eName.ToString())] = config.ReadConfigValue("MGM", "BL_Code_Processed");
                            continue;
                        }
                        if (mResult[i, j].eName == CEnum.TagName.User_ID)
                        {
                            userIDs.Add(mResult[i, j].oContent.ToString());
                            continue;
                        }
                        if (mResult[i, j].eName != CEnum.TagName.PageCount)
                        {
                            row[config.ReadConfigValue("MGM", mResult[i, j].eName.ToString())] = mResult[i, j].oContent.ToString();
                        }
                    }
                    mTable.Rows.Add(row);
                }
                return mTable;
            }
            catch (Exception ex)
            {
                return null;
            }
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
            this.Text = config.ReadConfigValue("MGM", "BH_UI_BugHandle");
            this.groupBoxBugList.Text = config.ReadConfigValue("MGM", "BL_UI_groupBoxBugView");
            this.LblPage.Text = config.ReadConfigValue("MGM", "BL_UI_LblPage");
            this.groupBoxSolution.Text = config.ReadConfigValue("MGM", "BH_UI_groupBoxSolution");
            this.buttonCancel.Text = config.ReadConfigValue("MGM", "BL_UI_buttonCancel");
            this.buttonSubmit.Text = config.ReadConfigValue("MGM", "BL_UI_buttonSubmit");
            this.labelSolution.Text = config.ReadConfigValue("MGM", "BH_UI_labelSolution");
            this.labelModule.Text = config.ReadConfigValue("MGM", "BL_UI_labelModule");
            this.labelType.Text = config.ReadConfigValue("MGM", "BL_UI_labelType");
            this.labelSubject.Text = config.ReadConfigValue("MGM", "BL_UI_labelSubject");
        }


        #endregion

        private void BugHandle_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            this.groupBoxBugList.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            this.GrdResult.DataSource = null;
            this.CmbPage.Items.Clear();
            this.userID = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());
            InitializeBugList();
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GMTOOLS_BUGLIST_QUERY, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                this.groupBoxBugList.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }
            this.GrdResult.DataSource = BuildTable(mResult);
            if (CmbPage.Items.Count == 0 && int.Parse(mResult[0, 10].oContent.ToString())>0)
            {
                bFirst = false;
                this.CmbPage.Items.Clear();
                for (int i = 1; i <= int.Parse(mResult[0, 10].oContent.ToString()); i++)
                {
                    this.CmbPage.Items.Add(i.ToString());
                }
                this.CmbPage.SelectedIndex = 0;
                bFirst = true;
            }
            else if (int.Parse(mResult[0, 10].oContent.ToString()) <= 0)
            {
                this.PnlPage.Visible = false;
            }


            this.groupBoxBugList.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.backgroundWorkerSubmit.IsBusy)
            {
                return;
            }
            if (bFirst)
            {
                this.groupBoxBugList.Enabled = false;
                Cursor = Cursors.WaitCursor;
                GrdResult.DataSource = null;
                bugID = 0;
                pageIndex = (int.Parse(this.CmbPage.Text) - 1) * pageSize + 1;
                InitializeBugList();
            }
        }

        private void GrdResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                DataTable mTable = (DataTable)this.GrdResult.DataSource;
                if (mTable.Rows[e.RowIndex][7].ToString() != config.ReadConfigValue("MGM", "BL_Code_Processed"))
                {
                    this.groupBoxSolution.Visible = true;
                    this.bugID = int.Parse(mTable.Rows[e.RowIndex][0].ToString());
                    this.textBoxSubject.Text = mTable.Rows[e.RowIndex][1].ToString();
                    this.textBoxType.Text = mTable.Rows[e.RowIndex][2].ToString();
                    this.textBoxModule.Text = mTable.Rows[e.RowIndex][3].ToString();
                    this.textBoxSolution.Text = "";
                    this.buttonSubmit.Enabled = true;
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MGM", "BH_Code_Msg1"));
                    this.buttonSubmit.Enabled = false;
                }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if(this.backgroundWorkerPageChanged.IsBusy)
            {
                return;
            }
            if (bugID == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "BH_Code_Msg2"));
                return;
            }
            if (this.textBoxSolution.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "BH_Code_Msg3"));
                return;
            }
            this.buttonSubmit.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.Bug_ID;
            messageBody[0].oContent = bugID;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[1].oContent = userID;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.Bug_Result;
            messageBody[2].oContent = this.textBoxSolution.Text.Trim();

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[3].eName = C_Global.CEnum.TagName.Status;
            messageBody[3].oContent = 1;


            this.backgroundWorkerSubmit.RunWorkerAsync(messageBody);
        }

        private void backgroundWorkerSubmit_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GMTOOLS_BUGLIST_UPDATE, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSubmit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            C_Global.CEnum.Message_Body[,] mResult = (C_Global.CEnum.Message_Body[,])e.Result;
            MessageBox.Show(mResult[0, 0].oContent.ToString());
            this.groupBoxBugList.Enabled = false;
            this.GrdResult.DataSource = null;
            InitializeBugList();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.groupBoxSolution.Visible = false;
        }
    }
}