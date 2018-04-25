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

namespace M_AU
{
    [C_Global.CModuleAttribute("获取用户历史密码&激活的游戏", "GetHistoryPWD", "获取用户历史密码&激活的游戏 -- 9YOU用户信息", "AU Group")] 
    public partial class GetHistoryPWD : Form
    {
        private CSocketEvent m_ClientEvent = null;
        int type = 0;
        int iPage = 0;
        public GetHistoryPWD()
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
            GetHistoryPWD mModuleFrm = new GetHistoryPWD();
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

        #region 变量

        C_Global.CEnum.Message_Body[,] modiInfoResult = null;

        CEnum.Message_Body[,] mResult = null;
        CEnum.Message_Body[,] stopResult = null;

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
            
            GrpSearch.Text = config.ReadConfigValue("MAU", "GHP_UI_GrpSearch");
            groupBoxOption.Text = config.ReadConfigValue("MAU", "GHP_UI_groupBoxOption");
            radioButtonGame.Text = config.ReadConfigValue("MAU", "GHP_UI_radioButtonGame");
            radioButtonPWD.Text = config.ReadConfigValue("MAU", "GHP_UI_radioButtonPWD");
            BtnSearch.Text = config.ReadConfigValue("MAU", "GHP_UI_BtnSearch");
            LblUser.Text = config.ReadConfigValue("MAU", "GHP_UI_LblUser");
            GrpResult.Text = config.ReadConfigValue("MAU", "GHP_UI_GrpResult");
            this.Text = config.ReadConfigValue("MAU", "GHP_UI_GetHistoryPWD");

            BuildCombox();

        }

        private void BuildCombox()
        {
            try
            {
                string gameList = config.ReadConfigValue("MAU", "GHP_UI_gameList");
                string gameID = config.ReadConfigValue("MAU", "GHP_UI_gameID");
                string[] games = gameList.Split(',');
                string[] gameIDs = gameID.Split(',');
                foreach (string name in games)
                {
                    comboBoxGame.Items.Add(name);
                }
                comboBoxGame.Tag = gameIDs;
                comboBoxGame.SelectedIndex = 0;
            }
            catch
            {

            }
        }
            


        #endregion

        private void GetHistoryPWD_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.dgvResult.DataSource = null;
            if (TxtID.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "GHP_CODE_ErrMsg1"));
                return;
            }
            else if (!radioButtonPWD.Checked && !radioButtonGame.Checked)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "GHP_CODE_ErrMsg2"));
                return;
            }
            //根据游戏查询激活的大区
            else if (radioButtonGame.Checked)
            {
                BtnSearch.Enabled = false;
                Cursor = Cursors.WaitCursor;
                
                CEnum.Message_Body[] messageBody = new CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = TxtID.Text.Trim();

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.GameID;
                messageBody[1].oContent = Convert.ToInt32(((string[])this.comboBoxGame.Tag)[this.comboBoxGame.SelectedIndex]);

                //messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                //messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                //messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                type = 0;
                this.backgroundWorkerSearch.RunWorkerAsync(messageBody);

            }
                //查询历史密码
            else if (radioButtonPWD.Checked)
            {
                BtnSearch.Enabled = false;
                Cursor = Cursors.WaitCursor;
                
                CEnum.Message_Body[] messageBody = new CEnum.Message_Body[1];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CARD_username;
                messageBody[0].oContent = TxtID.Text.Trim();

                //messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                //messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
                //messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                type = 1;
                this.backgroundWorkerSearch.RunWorkerAsync(messageBody);
            }
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            if (type == 0)
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    e.Result = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERINITACTIVE_QUERY, CEnum.Msg_Category.CARD_ADMIN, (CEnum.Message_Body[])e.Argument);
                }
            }
            else if (type == 1)
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    e.Result = m_ClientEvent.RequestResult(CEnum.ServiceKey.CARD_USERHISTORYPWD_QUERY, CEnum.Msg_Category.CARD_ADMIN, (CEnum.Message_Body[])e.Argument);
                }
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            Cursor = Cursors.Default;

            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResult[0, 0].oContent.ToString() == "FAILURE")
            {
                MessageBox.Show("没有符合条件数据");
                return;
            }

            if (type == 0)
            {
                BuildGameTable(mResult);
            }
            else if (type == 1)
            {
                BuildPWDTable(mResult);
            }

        }

        //构造玩家激活游戏列表
        private void BuildGameTable(CEnum.Message_Body[,] mResult)
        {
            try
            {
                DataTable mTable = new DataTable();
                mTable.Columns.AddRange(new DataColumn[] { new DataColumn(config.ReadConfigValue("MAU", "GHP_CODE_ID")), 
                    new DataColumn(config.ReadConfigValue("MAU", "GHP_CODE_Game")), 
                    new DataColumn(config.ReadConfigValue("MAU", "GHP_CODE_ActiveDate")) });
                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow row = mTable.NewRow();
                    for (int j = 0; j < mResult.GetLength(1); j++)
                    {
                        row[j] = mResult[i, j].oContent.ToString();
                    }
                    mTable.Rows.Add(row);
                }
                this.dgvResult.DataSource = mTable;
            }
            catch
            {
                this.dgvResult.DataSource = null;
            }
        }

        //构造玩家历史密码列表
        private void BuildPWDTable(CEnum.Message_Body[,] mResult)
        {
            try
            {
                DataTable mTable = new DataTable();
                mTable.Columns.AddRange(new DataColumn[] { new DataColumn(config.ReadConfigValue("MAU", "GHP_CODE_Pwd")), 
                    new DataColumn(config.ReadConfigValue("MAU", "GHP_CODE_ModiDate")), 
                    new DataColumn(config.ReadConfigValue("MAU", "GHP_CODE_Desc")),
                    new DataColumn(config.ReadConfigValue("MAU", "GHP_CODE_IP"))});
                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow row = mTable.NewRow();
                    for (int j = 0; j < mResult.GetLength(1); j++)
                    {
                        row[j] = mResult[i, j].oContent.ToString();
                    }
                    mTable.Rows.Add(row);
                }
                this.dgvResult.DataSource = mTable;
            }
            catch
            {
                this.dgvResult.DataSource = null;
            }
        }

        private void radioButtonGame_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGame.Checked)
            {
                this.comboBoxGame.Enabled = true;
            }
            else
            {
                this.comboBoxGame.Enabled = false;
            }
        }
    }
}