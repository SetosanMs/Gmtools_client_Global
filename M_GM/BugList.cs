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
    [C_Global.CModuleAttribute("GM问题提交", "BugList", "GM问题提交", "User Group")]
    public partial class BugList : Form
    {
        public BugList()
        {
            InitializeComponent();
        }

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
            this.Text = config.ReadConfigValue("MGM", "BL_UI_BugList");
            this.groupBoxBugInfo.Text = config.ReadConfigValue("MGM", "BL_UI_groupBoxBugInfo");
            this.buttonCancel.Text = config.ReadConfigValue("MGM", "BL_UI_buttonCancel");
            this.buttonModify.Text = config.ReadConfigValue("MGM", "BL_UI_buttonModify");
            this.buttonReset.Text = config.ReadConfigValue("MGM", "BL_UI_buttonReset");
            this.buttonSubmit.Text = config.ReadConfigValue("MGM", "BL_UI_buttonSubmit");
            this.labelContent.Text = config.ReadConfigValue("MGM", "BL_UI_labelContent");
            this.labelModule.Text = config.ReadConfigValue("MGM", "BL_UI_labelModule");
            this.labelType.Text = config.ReadConfigValue("MGM", "BL_UI_labelType");
            this.labelSubject.Text = config.ReadConfigValue("MGM", "BL_UI_labelSubject");
            this.groupBoxBugView.Text = config.ReadConfigValue("MGM", "BL_UI_groupBoxBugView");
            this.ToolStripMenuItemEdit.Text = config.ReadConfigValue("MGM", "BL_UI_ToolStripMenuItemEdit");
            this.LblPage.Text = config.ReadConfigValue("MGM", "BL_UI_LblPage");
           
        }


        #endregion

        #region 变量
        public CSocketEvent m_ClientEvent = null;

        private int userID = 0;	//用户id

        private int gmType = 0; //用户类型

        private bool bFirst = false;

        private int pageIndex = 1;
        private int pageSize = 20;
        private int rowIndex = 0;
        private int bugID = 0;

        private C_Global.CEnum.Message_Body[,] gameListResult = null;
        private C_Global.CEnum.Message_Body[,] moduleListResult = null;
        private C_Global.CEnum.Message_Body[,] userRoleResult = null;
        private DataTable UserModule = new DataTable();
        ArrayList userIDs = new ArrayList();


        #endregion

        #region 自定义函数
        /// <summary>
        /// 游戏列表
        /// </summary>
        private void InitializeGameList(C_Global.CEnum.Message_Body[,] userRoleResult)
        {
            ArrayList GameIDList = new ArrayList();
            UserModule.Columns.Add("GameID");
            UserModule.Columns.Add("ModuleID");
            UserModule.Columns.Add("ModuleName");
            try
            {
                for (int i = 0; i < gameListResult.GetLength(0); i++)
                {
                    //当前游戏id
                    int currGameID = int.Parse(gameListResult[i, 0].oContent.ToString());
                    //当前游戏名称
                    string currGameName = gameListResult[i, 1].oContent.ToString();

                    if (userRoleResult[0, 0].eName != C_Global.CEnum.TagName.ERROR_Msg)
                    {
                        bool flag = false;
                        for (int x = 0; x < userRoleResult.GetLength(0); x++)
                        {
                            //当前用户拥有权限的游戏id
                            int currUserGameID = int.Parse(userRoleResult[x, 0].oContent.ToString());
                            //当前用户拥有权限的模块id
                            int currUserModuleID = int.Parse(userRoleResult[x, 1].oContent.ToString());
                            //添加到问题游戏
                            if (currUserGameID == currGameID)
                            {
                                flag = true;
                                DataRow newrow = UserModule.NewRow();
                                newrow["GameID"] = currGameID;
                                newrow["ModuleID"] = currUserModuleID;
                                newrow["ModuleName"] = userRoleResult[x, 3].oContent.ToString();
                                UserModule.Rows.Add(newrow);
                                //获取有权限的模块
                                //moduleIDs.Add(currUserModuleID);
                            }


                        }
                        if (flag)
                        {
                            this.comboBoxType.Items.Add(currGameName);
                            GameIDList.Add(currGameID);
                        }
                    }
                }
                comboBoxType.Tag = GameIDList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 权限列表
        /// </summary>
        /// <param name="gameID"></param>
        public void InitializeRoleList(int gameID)
        {
            comboBoxModule.Items.Clear();
            ArrayList moduleList = new ArrayList();
            DataView filterView = UserModule.DefaultView;
            filterView.RowFilter = "GameID = " + gameID.ToString();
            foreach (DataRowView rowview in filterView)
            {
                comboBoxModule.Items.Add(rowview[2].ToString());
                moduleList.Add(rowview[1].ToString());
            }
            comboBoxModule.Tag = moduleList;
        }

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
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion

        private void BugList_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            this.groupBoxBugInfo.Enabled = false;
            this.groupBoxBugView.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            this.userID = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.User_ID;
            messageBody[0].oContent = userID;

            this.backgroundWorkerFormLoad.RunWorkerAsync(messageBody);
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                gameListResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.DEPART_RELATE_GAME_QUERY, C_Global.CEnum.Msg_Category.USER_ADMIN, (CEnum.Message_Body[])e.Argument);
                //检测状态
                if (gameListResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(gameListResult[0, 0].oContent.ToString());
                    e.Cancel = true;
                    //Application.Exit();
                    return;
                }
                moduleListResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GAME_MODULE_QUERY, C_Global.CEnum.Msg_Category.GAME_ADMIN, null);
                userRoleResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.USER_MODULE_QUERY, C_Global.CEnum.Msg_Category.USER_MODULE_ADMIN, (CEnum.Message_Body[])e.Argument);

            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                //显示游戏列表
                InitializeGameList(userRoleResult);
                InitializeBugList();
            }
            this.groupBoxBugInfo.Enabled = true;
            //this.groupBoxBugView.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                InitializeRoleList(int.Parse(((ArrayList)comboBoxType.Tag)[this.comboBoxType.SelectedIndex].ToString()));
            }
            catch
            {

            }
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
                this.groupBoxBugView.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }
            this.GrdResult.DataSource = BuildTable(mResult);
            if (CmbPage.Items.Count == 0 && int.Parse(mResult[0, 10].oContent.ToString()) > 0)
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

            this.groupBoxBugView.Enabled = true;
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
                this.groupBoxBugView.Enabled = false;
                Cursor = Cursors.WaitCursor;
                GrdResult.DataSource = null;
                pageIndex = (int.Parse(this.CmbPage.Text) - 1) * pageSize + 1;
                InitializeBugList();
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorkerPageChanged.IsBusy)
            {
                return;
            }
            if (this.textBoxSubject.Text.Trim() == "" ||
                this.textBoxContent.Text.Trim() == "" ||
                this.comboBoxModule.Text.Trim() == "" ||
                this.comboBoxType.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "BL_Code_Msg1"));
                return;
            }
            buttonSubmit.Enabled = false;
            groupBoxBugView.Enabled = false;
            Cursor = Cursors.WaitCursor;
            CmbPage.Items.Clear();
            GrdResult.DataSource = null;
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[5];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = userID;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[1].eName = C_Global.CEnum.TagName.GameID;
            messageBody[1].oContent = int.Parse(((ArrayList)this.comboBoxType.Tag)[this.comboBoxType.SelectedIndex].ToString());

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[2].eName = C_Global.CEnum.TagName.Bug_Type;
            messageBody[2].oContent = int.Parse(((ArrayList)comboBoxModule.Tag)[comboBoxModule.SelectedIndex].ToString());

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[3].eName = C_Global.CEnum.TagName.Bug_Context;
            messageBody[3].oContent = this.textBoxContent.Text.Trim();

            messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[4].eName = C_Global.CEnum.TagName.Bug_Subject;
            messageBody[4].oContent = this.textBoxSubject.Text.Trim();

            this.backgroundWorkerSubmit.RunWorkerAsync(messageBody);
        }

        private void backgroundWorkerSubmit_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GMTOOLS_BUGLIST_INSERT, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSubmit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonSubmit.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            MessageBox.Show(mResult[0, 0].oContent.ToString());
            pageIndex = 1;
            InitializeBugList();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.textBoxSubject.Text = "";
            this.textBoxContent.Text= "";
            this.comboBoxModule.Text= "";
            this.comboBoxType.Text = "";
        }

        private void GrdResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataTable mTable = (DataTable)GrdResult.DataSource;
            //    if (mTable.Rows[e.RowIndex][7].ToString() == "已处理" || userIDs[e.RowIndex].ToString() != userID.ToString())
            //    {
            //        this.ToolStripMenuItemEdit.Enabled = false;
            //        //this.contextMenuStrip.Items.AddRange(new ToolStripItem[] { this.ToolStripMenuItemEdit });
            //    }
            //    else
            //    {
            //        this.ToolStripMenuItemEdit.Enabled = true;
            //        //this.contextMenuStrip.Items.AddRange(new ToolStripItem[] { this.ToolStripMenuItemEdit });
            //    }
         }

        private void GrdResult_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataTable mTable = (DataTable)GrdResult.DataSource;
            if (e.Button == MouseButtons.Right)
            {
                rowIndex = e.RowIndex;
                if (mTable.Rows[e.RowIndex][7].ToString() == config.ReadConfigValue("MGM", "BL_Code_Processed") || userIDs[e.RowIndex].ToString() != userID.ToString())
                {
                    this.ToolStripMenuItemEdit.Enabled = false;
                    //this.contextMenuStrip.Items.AddRange(new ToolStripItem[] { this.ToolStripMenuItemEdit });
                }
                else
                {
                    this.ToolStripMenuItemEdit.Enabled = true;
                    //this.contextMenuStrip.Items.AddRange(new ToolStripItem[] { this.ToolStripMenuItemEdit });
                }
            }
            
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            DataTable mTable = (DataTable)GrdResult.DataSource;
            bugID = int.Parse(mTable.Rows[rowIndex][0].ToString());
            this.textBoxSubject.Focus();
            this.textBoxSubject.Text = mTable.Rows[rowIndex][1].ToString();
            this.comboBoxType.Text = mTable.Rows[rowIndex][2].ToString();
            this.comboBoxModule.Text = mTable.Rows[rowIndex][3].ToString();
            this.textBoxContent.Text = mTable.Rows[rowIndex][4].ToString();
            this.buttonReset.Visible = false;
            this.buttonSubmit.Visible = false;
            this.buttonModify.Visible = true;
            this.buttonCancel.Visible = true;
            
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (this.textBoxSubject.Text.Trim() == "" || this.textBoxContent.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MGM", "BL_Code_Msg1"));
                return;
            }
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[7];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = userID;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[1].eName = C_Global.CEnum.TagName.GameID;
            messageBody[1].oContent = int.Parse(((ArrayList)this.comboBoxType.Tag)[this.comboBoxType.SelectedIndex].ToString());

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[2].eName = C_Global.CEnum.TagName.Bug_Type;
            messageBody[2].oContent = int.Parse(((ArrayList)comboBoxModule.Tag)[comboBoxModule.SelectedIndex].ToString());

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[3].eName = C_Global.CEnum.TagName.Bug_Context;
            messageBody[3].oContent = this.textBoxContent.Text.Trim();

            messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[4].eName = C_Global.CEnum.TagName.Bug_Subject;
            messageBody[4].oContent = this.textBoxSubject.Text.Trim();

            messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[5].eName = C_Global.CEnum.TagName.Bug_ID;
            messageBody[5].oContent = bugID;

            messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[6].eName = C_Global.CEnum.TagName.Status;
            messageBody[6].oContent = 0;

            this.buttonModify.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            this.backgroundWorkerModify.RunWorkerAsync(messageBody);
            
        }

        private void backgroundWorkerModify_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GMTOOLS_BUGLIST_UPDATE, C_Global.CEnum.Msg_Category.COMMON, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerModify_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                this.buttonModify.Enabled = true;
                this.Cursor = Cursors.Default;
                return;
            }
            else
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                this.buttonModify.Visible = false;
                this.buttonModify.Enabled = true;
                this.buttonCancel.Visible = false;
                this.buttonReset.Visible = true;
                this.buttonSubmit.Visible = true;
                this.Cursor = Cursors.Default;
                pageIndex = 1;
                this.GrdResult.DataSource = null;
                this.groupBoxBugView.Enabled = false;
                InitializeBugList();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.textBoxSubject.Text = "";
            this.textBoxContent.Text = "";
            this.comboBoxModule.Text = "";
            this.comboBoxType.Text = "";
            this.buttonModify.Visible = false;
            this.buttonCancel.Visible = false;
            this.buttonReset.Visible = true;
            this.buttonSubmit.Visible = true;
        }
    }
}
