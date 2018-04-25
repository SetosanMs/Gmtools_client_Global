using System;
using System.Collections;
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

namespace M_FJ
{
    [C_Global.CModuleAttribute("玩家角色信息", "FrmQueryAccontInfo", "玩家角色信息", "Group")]
    public partial class FrmQueryAccontInfoReadonly : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] mItemResult = null;
        private int RolePage = 0;
        private int RoleIndex = 0;
        private int iIndexID = 0;
        private bool RoleFirst = false;
        private int iPageCount = 0;
        private bool bFirst = false;
        private bool bFirst1 = false;
        private bool bFirst2 = false;
        int currDgSelectRow = 0;    //玩家信息datagrid 中当前选中的行
        string userAccount = null; //玩家角色名称
        string guildName = null;//角色所在帮会
        ArrayList GuildList = null;
        ArrayList GuildID = null;
        int Occupation_id = 0;
        private CEnum.Message_Body[,] mGuildResult = null;
        private CEnum.Message_Body[,] mRelateResult = null;
        private CEnum.Message_Body[,] mSkillList = null;
        private CEnum.Message_Body[,] mRankList = null;
        string ServerIP = null;
        string currentUserNick = null;
        public FrmQueryAccontInfoReadonly()
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
            FrmQueryAccontInfoReadonly mModuleFrm = new FrmQueryAccontInfoReadonly();
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
            this.Text = config.ReadConfigValue("MFj", "FQA_UI_FrmQueryAccontInfo");
            this.TpgCharacter.Text = config.ReadConfigValue("MFj", "FQA_UI_FrmQueryAccontInfo");
            this.TpgItem.Text = config.ReadConfigValue("MFj", "FQA_UI_TpgItem");
            this.LblPage.Text = config.ReadConfigValue("MFj", "FQA_UI_LblPage");
            this.tabPage1.Text = config.ReadConfigValue("MFj", "FQA_UI_tabPage1");
            this.label2.Text = config.ReadConfigValue("MFj", "FQA_UI_label2");
            this.tabPage2.Text = config.ReadConfigValue("MFj", "FQA_UI_tabPage2");
            this.label4.Text = config.ReadConfigValue("MFj", "FQA_UI_label4");
            this.GrpSearch.Text = config.ReadConfigValue("MFj", "FQA_UI_GrpSearch");
            this.label1.Text = config.ReadConfigValue("MFj", "FQA_UI_label1");
            this.button1.Text = config.ReadConfigValue("MFj", "FQA_UI_button1");
            this.LblServer.Text = config.ReadConfigValue("MFj", "FQA_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MFj", "FQA_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MFj", "FQA_UI_BtnSearch");
            this.label3.Text = config.ReadConfigValue("MFj", "FQA_UI_label3");
            this.tabPageGuild.Text = config.ReadConfigValue("MFj", "FQA_UI_tabPageGuild");
            this.labelRoleName.Text = config.ReadConfigValue("MFj", "FQA_UI_labelRoleName");
            this.labelGuild.Text = config.ReadConfigValue("MFj", "FQA_UI_labelGuild");
            this.buttonAdd.Text = config.ReadConfigValue("MFj", "FQA_UI_buttonAdd");
            this.buttonQuit.Text = config.ReadConfigValue("MFj", "FQA_UI_buttonQuit");
            this.labelCurrentRoleName.Text = config.ReadConfigValue("MFj", "FQA_UI_labelCurrentRoleName");
            this.labelRelateRoleName.Text = config.ReadConfigValue("MFj", "FQA_UI_labelRelateRoleName");
            this.buttonRelateAdd.Text = config.ReadConfigValue("MFj", "FQA_UI_buttonRelateAdd");
            this.buttonRelateCancel.Text = config.ReadConfigValue("MFj", "FQA_UI_buttonRelateCancel");
            this.labelRelate.Text = config.ReadConfigValue("MFj", "FQA_UI_labelRelate");
            this.tabPageRelation.Text = config.ReadConfigValue("MFj", "FQA_UI_tabPageRelation");
            this.tabPageSkill.Text = config.ReadConfigValue("MFj", "FQA_UI_tabPageSkill");
            this.buttonNewSkill.Text = config.ReadConfigValue("MFj", "FQA_UI_buttonNewSkill");
            this.buttonSkillOK.Text = config.ReadConfigValue("MFj", "FQA_UI_buttonSkillEdit");
            this.labelSkillLevel.Text = config.ReadConfigValue("MFj", "FQA_UI_labelSkillLevel");
            this.labelSkill.Text = config.ReadConfigValue("MFj", "FQA_UI_labelSkill");
            this.tabPageModifyInfo.Text = config.ReadConfigValue("MFj", "FQA_UI_tabPageModifyInfo");
            this.labelModifyRoleName.Text = config.ReadConfigValue("MFj", "FQA_UI_labelModifyRoleName");
            this.labelModifyRank.Text = config.ReadConfigValue("MFj", "FQA_UI_labelModifyRank");
            this.labelModifyLevel.Text = config.ReadConfigValue("MFj", "FQA_UI_labelModifyLevel");
            this.labelModifyExp.Text = config.ReadConfigValue("MFj", "FQA_UI_labelModifyExp");
            this.labelModifyCash.Text = config.ReadConfigValue("MFj", "FQA_UI_labelModifyCash");
            this.labelModifyHonor.Text = config.ReadConfigValue("MFj", "FQA_UI_labelModifyHonor");
            this.buttonModifyOK.Text = config.ReadConfigValue("MFj", "FQA_UI_buttonModifyOK");
            this.buttonModifyCancel.Text = config.ReadConfigValue("MFj", "FQA_UI_buttonModifyCancel");


            this.comboBoxRelate.Items.Clear();
            this.comboBoxRelate.Items.AddRange(new object[] {
            config.ReadConfigValue("MFj", "FQA_Code_Relate0"),
            config.ReadConfigValue("MFj", "FQA_Code_Relate1"),
            config.ReadConfigValue("MFj", "FQA_Code_Relate2"),
            config.ReadConfigValue("MFj", "FQA_Code_Relate3"),
            config.ReadConfigValue("MFj", "FQA_Code_Relate4"),
            config.ReadConfigValue("MFj", "FQA_Code_Relate5")});
        }


        #endregion
        private void FrmQueryAccontInfo_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            PnlPage.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            comboBoxRelate.Tag = new int[] { 0, 1, 2, 3, 4, 5 };
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_FJ");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "" || this.backgroundWorkerPageChanged.IsBusy)
            {
                return;
            }
            //清除控件



            TbcResult.SelectedTab = TpgCharacter;


            GrdItemResult.DataSource = null;
            this.RoleInfoView.DataSource = null;
            userAccount = null;

            if (TxtAccount.Text.Trim().Length > 0 || TxtNick.Text.Trim().Length > 0)
            {
                this.BtnSearch.Enabled = false;
                //this.TbcResult.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                //RoleIndex = 1;
                RoleFirst = false;


                PartInfo();
            }
            //else if (TxtAccount.Text.Trim().Length == 0 && TxtNick.Text.Trim().Length > 0)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
            //    return;
            //}
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
                return;
            }
        }

        private void PartInfo()
        {
            this.RoleInfoView.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.FJ_UserID;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.FJ_UserNick;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = TxtNick.Text;

            backgroundWorkerSearch.RunWorkerAsync(mContent);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_FJ.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_FJ.BuildCombox(mServerInfo, CmbServer);

            PnlPage.Visible = false;

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
            ServerIP = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_CharacterInfo_Query, (CEnum.Message_Body[])e.Argument);
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

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);
        }

        private void TbcResult_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                CmbPage.Items.Clear();
                cboMessage.Items.Clear();
                cmbWareHouse.Items.Clear();

                bFirst = false;
                bFirst1 = false;
                bFirst2 = false;

                if (RoleInfoView.DataSource != null)
                {
                    DataTable mTable = (DataTable)RoleInfoView.DataSource;
                    userAccount = mTable.Rows[currDgSelectRow][config.ReadConfigValue("MFj", "FQA_Code_Nickname")].ToString();
                    guildName = mTable.Rows[currDgSelectRow][config.ReadConfigValue("MFj", "FQA_UI_GuildName")].ToString();
                    Occupation_id = int.Parse(mTable.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_Occupation_id")].ToString());
                }
                else
                {
                    this.groupBox1.Enabled = false;
                    this.groupBox2.Enabled = false;
                    return;
                }
                if (userAccount != null)
                {
                    if (TbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MFj", "FQA_UI_TpgItem")))
                    {
                        ItemShopQuery();
                    }
                    else if (TbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MFj", "FQA_UI_tabPage1")))
                    {
                        Message_Query();
                    }
                    else if (TbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MFj", "FQA_UI_tabPage2")))
                    {
                        WareHouse_Query();
                    }
                    else if (TbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MFj", "FQA_UI_tabPageGuild")))
                    {
                        Guild_Manage();
                    }
                    else if (TbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MFj", "FQA_UI_tabPageRelation")))
                    {
                        Relation_Manage();
                    }
                    else if (TbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MFj", "FQA_UI_tabPageSkill")))
                    {
                        Skill_Manage();
                    }
                    else if (TbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MFj", "FQA_UI_tabPageModifyInfo")))
                    {
                        Modify_RoleInfo();
                    }
                    else if (TbcResult.SelectedTab.Text.Equals(config.ReadConfigValue("MFj", "FQA_UI_tabshortcut")))
                    {
                        Shortcut_Manage();
                    }
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_Msg1"));
                }
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_Msg1"));
                userAccount = null;
            }

        }

        private void RoleInfoView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currDgSelectRow = int.Parse(e.RowIndex.ToString());
        }
        private void Shortcut_Manage()
        {
            TbcResult.Enabled = false;
            this.DataShortcut.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.FJ_UserNick;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = userAccount;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.Index;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = 1;

            mContent[3].eName = CEnum.TagName.PageSize;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_FJ.iPageSize;

            backgroundWorkerShortCut.RunWorkerAsync(mContent);
        }
        private void ItemShopQuery()
        {
            TbcResult.Enabled = false;
            this.GrdItemResult.DataSource = null;


            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.FJ_UserNick;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = userAccount;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.Index;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = 1;

            mContent[3].eName = CEnum.TagName.PageSize;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_FJ.iPageSize;

            backgroundWorkerItemShopQuery.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerItemShopQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_ItemShop_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerItemShopQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TbcResult.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, GrdItemResult, out iPageCount);

            if (iPageCount <= 0)
            {
                PnlPage.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }

                CmbPage.SelectedIndex = 0;
                bFirst = true;
                PnlPage.Visible = true;
            }
        }

        private void Message_Query()
        {
            TbcResult.Enabled = false;
            this.dataGridView1.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.FJ_UserNick;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = userAccount;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.Index;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = 1;

            mContent[3].eName = CEnum.TagName.PageSize;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_FJ.iPageSize;



            backgroundWorkerMessage_Query.RunWorkerAsync(mContent);
        }

        private void Guild_Manage()
        {
            if (userAccount != null)
            {
                this.TxtRoleName.Text = userAccount;
                this.TbcResult.Enabled = false;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

                mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = ServerIP;

                try
                {
                    this.backgroundWorkerGuildQuery.RunWorkerAsync(mContent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void backgroundWorkerMessage_Query_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Message_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerMessage_Query_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TbcResult.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, dataGridView1, out iPageCount);

            if (iPageCount <= 0)
            {
                panel1.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    cboMessage.Items.Add(i + 1);
                }

                cboMessage.SelectedIndex = 0;
                bFirst1 = true;
                panel1.Visible = true;
            }
        }

        private void WareHouse_Query()
        {
            TbcResult.Enabled = false;
            this.dataGridView2.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.FJ_UserNick;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = userAccount;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.Index;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = 1;

            mContent[3].eName = CEnum.TagName.PageSize;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_FJ.iPageSize;

            backgroundWorkerWareHouse_Query.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerWareHouse_Query_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_WareHouse_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerWareHouse_Query_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TbcResult.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                panel2.Visible = false;
                return;
            }

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, dataGridView2, out iPageCount);
            if (iPageCount <= 0)
            {
                panel2.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    cmbWareHouse.Items.Add(i + 1);
                }

                cmbWareHouse.SelectedIndex = 0;
                bFirst2 = true;
                panel2.Visible = true;
            }
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                this.CmbPage.Enabled = false;
                //this.Cursor = Cursors.AppStarting;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.FJ_UserNick;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = userAccount;

                mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.Index;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_FJ.iPageSize + 1; ;

                mContent[3].eName = CEnum.TagName.PageSize;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = Operation_FJ.iPageSize;

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);


            }
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_ItemShop_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.CmbPage.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, GrdItemResult, out iPageCount);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Message_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.cboMessage.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, dataGridView1, out iPageCount);
        }

        private void cboMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst1)
            {
                this.cboMessage.Enabled = false;
                //this.Cursor = Cursors.AppStarting;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.FJ_UserNick;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = userAccount;

                mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.Index;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = (int.Parse(cboMessage.Text) - 1) * Operation_FJ.iPageSize + 1; ;

                mContent[3].eName = CEnum.TagName.PageSize;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = Operation_FJ.iPageSize;

                this.backgroundWorker1.RunWorkerAsync(mContent);


            }
        }

        private void cmbWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst2)
            {
                this.cmbWareHouse.Enabled = false;
                //this.Cursor = Cursors.AppStarting;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.FJ_UserNick;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = userAccount;

                mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.Index;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = (int.Parse(cmbWareHouse.Text) - 1) * Operation_FJ.iPageSize + 1; ;

                mContent[3].eName = CEnum.TagName.PageSize;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = Operation_FJ.iPageSize;

                this.backgroundWorker2.RunWorkerAsync(mContent);


            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_WareHouse_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.cmbWareHouse.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, dataGridView1, out iPageCount);
        }

        private void RoleInfoView_DataSourceChanged(object sender, EventArgs e)
        {
            if (RoleInfoView.DataSource != null)
            {
                DataTable dt = (DataTable)RoleInfoView.DataSource;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].ItemArray[2].ToString() == config.ReadConfigValue("MFj", "AF_Code_BlanketEnabled"))
                    {
                        this.RoleInfoView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }

                }
            }
        }

        private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                using (DataTable dt = (DataTable)RoleInfoView.DataSource)
                {
                    if (dt.Rows[e.RowIndex][2].ToString() == config.ReadConfigValue("MFj", "AF_Code_BlanketEnabled"))
                    {
                        if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_Recovery_Info"), config.ReadConfigValue("MFj", "FQA_Code_Recovery_Title"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                            mContent[0].eName = CEnum.TagName.FJ_UserNick;
                            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[0].oContent = dt.Rows[e.RowIndex][1].ToString();

                            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                            mContent[2].eName = CEnum.TagName.UserByID;
                            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                            mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                            CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Recovery_Character, mContent);

                            if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                            {
                                MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                                return;
                            }
                            else if (result[0, 0].oContent.ToString() == "SUCESS")
                            {
                                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_Recovery_Success"));
                                this.BtnSearch_Click(null, null);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_Recovery_Failed"));
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_Del_Info"), config.ReadConfigValue("MFj", "FQA_Code_Del_Title"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                            mContent[0].eName = CEnum.TagName.FJ_UserNick;
                            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[0].oContent = dt.Rows[e.RowIndex][1].ToString();

                            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                            mContent[2].eName = CEnum.TagName.UserByID;
                            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                            mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                            CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Delete_Character, mContent);

                            if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                            {
                                MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                                return;
                            }
                            else if (result[0, 0].oContent.ToString() == "SUCESS")
                            {
                                MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg4"));
                                this.BtnSearch_Click(null, null);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg5"));
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void backgroundWorkerGuildQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mGuildResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Guild_QueryAll, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerGuildQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TbcResult.Enabled = true;
            this.comboBoxGuild = Operation_FJ.BuildCombox(mGuildResult, comboBoxGuild);
            this.comboBoxGuild.Tag = mGuildResult;
            if (guildName == config.ReadConfigValue("MFj", "FQA_Code_NonGuild"))
            {
                buttonAdd.Enabled = true;
                buttonQuit.Enabled = false;
                comboBoxGuild.Enabled = true;
            }
            else
            {
                buttonAdd.Enabled = false;
                buttonQuit.Enabled = true;
                comboBoxGuild.Text = guildName;
                comboBoxGuild.Enabled = false;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.TxtRoleName.Text != "")
            {
                if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_GuildADDInfo"), config.ReadConfigValue("MFj", "FQA_Code_GuildADDTitle"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                    mContent[0].eName = CEnum.TagName.FJ_UserNick;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = this.TxtRoleName.Text;

                    mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContent[3].eName = CEnum.TagName.FJ_GuidID;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(((CEnum.Message_Body[,])this.comboBoxGuild.Tag)[this.comboBoxGuild.SelectedIndex, 0].oContent.ToString());

                    CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Guild_Create, mContent);
                    if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                    }
                    else if (result[0, 0].oContent.ToString() == "SUCESS")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_GuildADDSuccess"));
                        this.comboBoxGuild.Enabled = false;
                        this.buttonAdd.Enabled = false;
                        this.buttonQuit.Enabled = true;
                    }
                    else if (result[0, 0].oContent.ToString() == "FAILURE")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_GuildADDFailed"));
                    }
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            if (this.TxtRoleName.Text != "")
            {
                if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_GuildQuitInfo"), config.ReadConfigValue("MFj", "FQA_Code_GuildQuitTitle"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                    mContent[0].eName = CEnum.TagName.FJ_UserNick;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = this.TxtRoleName.Text;

                    mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[2].eName = CEnum.TagName.UserByID;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


                    CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Guild_Delete, mContent);
                    if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                    }
                    else if (result[0, 0].oContent.ToString() == "SUCESS")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_GuildQuitSuccess"));
                        this.comboBoxGuild.Enabled = true;
                        this.comboBoxGuild.SelectedIndex = 0;
                        this.buttonQuit.Enabled = false;
                        this.buttonAdd.Enabled = true;
                    }
                    else if (result[0, 0].oContent.ToString() == "FAILURE")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_GuildQuitFailed"));
                    }
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
            }
        }

        private void Relation_Manage()
        {
            this.TbcResult.Enabled = false;
            this.dgvRelation.DataSource = null;
            this.textBoxCurrentRoleName.Text = userAccount;
            this.textBoxRelateRoleName.Text = "";
            this.comboBoxRelate.SelectedIndex = 0;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.FJ_UserNick;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = userAccount;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.FJ_Type;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = 6;

            this.backgroundWorkerRelationQuery.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerRelationQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mRelateResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_SocialRelate_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerRelationQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TbcResult.Enabled = true;
            CEnum.Message_Body[,] result = (CEnum.Message_Body[,])mRelateResult.Clone();
            if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(result[0, 0].oContent.ToString());
            }
            else
            {
                Operation_FJ.BuildDataTable(this.m_ClientEvent, result, dgvRelation, out iPageCount);
            }
        }

        private void dgvRelation_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_RelateDelInfo"), config.ReadConfigValue("MFj", "FQA_Code_RelateDelTitle"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.FJ_UserNick;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = mRelateResult[e.RowIndex, 0].oContent.ToString();

                    mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[2].eName = CEnum.TagName.FJ_Type;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(mRelateResult[e.RowIndex, 2].oContent.ToString());

                    mContent[3].eName = CEnum.TagName.FJ_RelateCHarName;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = mRelateResult[e.RowIndex, 1].oContent.ToString();

                    mContent[4].eName = CEnum.TagName.UserByID;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_SocialRelate_Delete, mContent);
                    if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(result[0, 0].oContent.ToString());
                        return;
                    }
                    else if (result[0, 0].oContent.ToString() == "SUCESS")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_RelateDelSuccess"));
                        this.Relation_Manage();
                    }
                    else if (result[0, 0].oContent.ToString() == "FAILURE")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_RelateDelFailed"));
                    }
                }
            }
        }

        private void buttonRelateAdd_Click(object sender, EventArgs e)
        {
            if (this.textBoxRelateRoleName.Text.Trim().Length == 0 || this.comboBoxRelate.SelectedIndex < 0)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_Msg2"));
                return;
            }
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

            mContent[0].eName = CEnum.TagName.FJ_UserNick;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = this.textBoxCurrentRoleName.Text;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.FJ_Type;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = ((int[])this.comboBoxRelate.Tag)[this.comboBoxRelate.SelectedIndex];

            mContent[3].eName = CEnum.TagName.FJ_RelateCHarName;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[3].oContent = this.textBoxRelateRoleName.Text;

            mContent[4].eName = CEnum.TagName.UserByID;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_SocialRelate_Create, mContent);
            if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(result[0, 0].oContent.ToString());
                return;
            }
            else if (result[0, 0].oContent.ToString() == "SUCESS")
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_RelateAddISuccess"));
                this.Relation_Manage();
            }
            else if (result[0, 0].oContent.ToString() == "FAILURE")
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_RelateAddFailed"));
            }
        }

        private void buttonRelateCancel_Click(object sender, EventArgs e)
        {
            this.textBoxRelateRoleName.Text = "";
            this.comboBoxRelate.SelectedIndex = 0;
        }

        private void Skill_Manage()
        {
            this.groupBox1.Enabled = true;
            this.TbcResult.Enabled = false;
            this.dgvSkill.DataSource = null;
            this.buttonSkillOK.Enabled = false;
            this.comboBoxSkill.Enabled = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

            mContent[0].eName = CEnum.TagName.FJ_UserNick;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = userAccount;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);


            this.backgroundWorkerSkillQuery.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerSkillQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_PlayerSkill_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSkillQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TbcResult.Enabled = true;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

            mContent[0].eName = CEnum.TagName.FJ_Occupation_id;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = Occupation_id;

            mSkillList = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_SkillList_Query, mContent);
            Operation_FJ.BuildCombox(mSkillList, this.comboBoxSkill);

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
            }
            else
                Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, dgvSkill, out iPageCount);

        }

        private void comboBoxSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.numericUpDownSkillLevel.Maximum = int.Parse(mSkillList[this.comboBoxSkill.SelectedIndex, 2].oContent.ToString());
        }

        private void dgvSkill_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvSkill.DataSource != null)
            {
                DataTable dt = (DataTable)dgvSkill.DataSource;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].ItemArray[4].ToString() == config.ReadConfigValue("MFj", "AF_Code_BlanketEnabled"))
                    {
                        this.dgvSkill.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }

                }
            }
        }

        private void dgvSkill_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            using (DataTable dt = (DataTable)dgvSkill.DataSource)
            {
                try
                {
                    this.comboBoxSkill.Enabled = false;
                    this.buttonSkillOK.Enabled = true;
                    this.buttonSkillOK.Text = config.ReadConfigValue("MFj", "FQA_UI_buttonSkillEdit");
                    this.comboBoxSkill.Text = dt.Rows[e.RowIndex][config.ReadConfigValue("GLOBAL", "FJ_Skill")].ToString();
                    this.numericUpDownSkillLevel.Value = int.Parse(dt.Rows[e.RowIndex][config.ReadConfigValue("GLOBAL", "FJ_Level")].ToString());
                }
                catch
                {

                }
            }
        }

        private void buttonNewSkill_Click(object sender, EventArgs e)
        {
            this.buttonSkillOK.Enabled = true;
            this.buttonSkillOK.Text = config.ReadConfigValue("MFj", "FQA_UI_buttonSkillOK");
            this.comboBoxSkill.Enabled = true;
            this.comboBoxSkill.SelectedIndex = 0;
            this.numericUpDownSkillLevel.Value = this.numericUpDownSkillLevel.Minimum;
        }

        private void buttonSkillOK_Click(object sender, EventArgs e)
        {
            if (this.buttonSkillOK.Text == config.ReadConfigValue("MFj", "FQA_UI_buttonSkillEdit"))
            {
                if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_SkillModifyInfo"), config.ReadConfigValue("MFj", "FQA_Code_SkillModifyTitle"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.FJ_UserNick;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = userAccount;

                    mContent[1].eName = CEnum.TagName.FJ_SkillID;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = int.Parse(mSkillList[this.comboBoxSkill.SelectedIndex, 0].oContent.ToString());

                    mContent[2].eName = CEnum.TagName.FJ_Level;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Convert.ToInt32(this.numericUpDownSkillLevel.Value);

                    mContent[3].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[4].eName = CEnum.TagName.UserByID;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_PlayerSkill_Update, mContent);

                    if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(result[0, 0].oContent.ToString());
                    }
                    else if (result[0, 0].oContent.ToString() == "SUCESS")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_SkillModifySuccess"));
                        this.Skill_Manage();
                    }
                    else if (result[0, 0].oContent.ToString() == "FAILURE")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_SkillModifyFailed"));
                    }

                }
            }
            else if (this.buttonSkillOK.Text == config.ReadConfigValue("MFj", "FQA_UI_buttonSkillOK"))
            {
                if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_SkillInsertInfo"), config.ReadConfigValue("MFj", "FQA_Code_SkillInsertTitle"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                    mContent[0].eName = CEnum.TagName.FJ_UserNick;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = userAccount;

                    mContent[1].eName = CEnum.TagName.FJ_SkillID;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = int.Parse(mSkillList[this.comboBoxSkill.SelectedIndex, 0].oContent.ToString());

                    mContent[2].eName = CEnum.TagName.FJ_Level;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Convert.ToInt32(this.numericUpDownSkillLevel.Value);

                    mContent[3].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[4].eName = CEnum.TagName.UserByID;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_PlayerSkill_Insert, mContent);

                    if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(result[0, 0].oContent.ToString());
                    }
                    else if (result[0, 0].oContent.ToString() == "SUCESS")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_SkillInsertSuccess"));
                        this.Skill_Manage();
                    }
                    else if (result[0, 0].oContent.ToString() == "FAILURE")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_SkillInsertFailed"));
                    }
                }
            }
        }

        private void dgvSkill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_SkillDelInfo"), config.ReadConfigValue("MFj", "FQA_Code_SkillDelTitle"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                    mContent[0].eName = CEnum.TagName.FJ_UserNick;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = userAccount;

                    mContent[1].eName = CEnum.TagName.FJ_SkillID;
                    mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[1].oContent = int.Parse(mSkillList[this.comboBoxSkill.SelectedIndex, 0].oContent.ToString());

                    mContent[2].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                    mContent[3].eName = CEnum.TagName.UserByID;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_PlayerSkill_Delete, mContent);

                    if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(result[0, 0].oContent.ToString());
                    }
                    else if (result[0, 0].oContent.ToString() == "SUCESS")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_SkillDelSuccess"));
                        this.Skill_Manage();
                    }
                    else if (result[0, 0].oContent.ToString() == "FAILURE")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_SkillDelFailed"));
                    }
                }
            }
        }

        private void textBoxModifyLevel_TextChanged(object sender, EventArgs e)
        {
            if (textBoxModifyLevel.Text != "")
            {
                try
                {
                    int i = int.Parse(textBoxModifyLevel.Text);
                }
                catch
                {
                    MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_MsgInvalidCast"));
                    textBoxModifyLevel.Text = "";
                }
            }
        }

        private void textBoxModifyExp_TextChanged(object sender, EventArgs e)
        {
            if (textBoxModifyExp.Text != "")
            {
                try
                {
                    int i = int.Parse(textBoxModifyExp.Text);
                }
                catch
                {
                    MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_MsgInvalidCast"));
                    textBoxModifyExp.Text = "";
                }
            }
        }

        private void textBoxModifyCash_TextChanged(object sender, EventArgs e)
        {
            if (textBoxModifyCash.Text != "")
            {
                try
                {
                    int i = int.Parse(textBoxModifyCash.Text);
                }
                catch
                {
                    MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_MsgInvalidCast"));
                    textBoxModifyCash.Text = "";
                }
            }
        }

        private void textBoxModifyHonor_TextChanged(object sender, EventArgs e)
        {
            if (textBoxModifyHonor.Text != "")
            {
                try
                {
                    int i = int.Parse(textBoxModifyHonor.Text);
                }
                catch
                {
                    MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_MsgInvalidCast"));
                    textBoxModifyHonor.Text = "";
                }
            }
        }

        private void Modify_RoleInfo()
        {
            this.groupBox2.Enabled = true;
            try
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

                mContent[0].eName = CEnum.TagName.FJ_UserNick;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = userAccount;

                mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);



                mRankList = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_Currank_Query, mContent);
                if (mRankList[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mRankList[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    Operation_FJ.BuildCombox(mRankList, this.comboBoxModifyRank);
                    using (DataTable dt = (DataTable)RoleInfoView.DataSource)
                    {
                        this.textBoxModifyRoleName.Text = userAccount;
                        this.comboBoxModifyRank.Text = dt.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_icurrank")].ToString();
                        this.textBoxModifyLevel.Text = dt.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_Level")].ToString();
                        this.textBoxModifyExp.Text = dt.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_CurExp")].ToString();
                        this.textBoxModifyCash.Text = dt.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_MCash")].ToString();
                        this.textBoxModifyHonor.Text = dt.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_ihonor")].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonModifyCancel_Click(object sender, EventArgs e)
        {
            using (DataTable dt = (DataTable)RoleInfoView.DataSource)
            {
                this.comboBoxModifyRank.Text = dt.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_icurrank")].ToString();
                this.textBoxModifyLevel.Text = dt.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_Level")].ToString();
                this.textBoxModifyExp.Text = dt.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_CurExp")].ToString();
                this.textBoxModifyCash.Text = dt.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_MCash")].ToString();
                this.textBoxModifyHonor.Text = dt.Rows[currDgSelectRow][config.ReadConfigValue("GLOBAL", "FJ_ihonor")].ToString();
            }
        }

        private void buttonModifyOK_Click(object sender, EventArgs e)
        {
            if (this.textBoxModifyRoleName.Text != "" &&
                this.comboBoxModifyRank.Text != "" &&
                this.textBoxModifyCash.Text != "" &&
                this.textBoxModifyExp.Text != "" &&
                this.textBoxModifyHonor.Text != "" &&
                this.textBoxModifyLevel.Text != "")
            {
                buttonModifyOK.Enabled = false;
                Cursor = Cursors.WaitCursor;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[9];

                mContent[0].eName = CEnum.TagName.FJ_UserNick;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = userAccount;

                mContent[1].eName = CEnum.TagName.FJ_Type;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = int.Parse(mRankList[this.comboBoxModifyRank.SelectedIndex, 0].oContent.ToString());

                mContent[2].eName = CEnum.TagName.FJ_ServerIP;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[3].eName = CEnum.TagName.UserByID;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[4].eName = CEnum.TagName.FJ_Level;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = int.Parse(this.textBoxModifyLevel.Text);

                mContent[5].eName = CEnum.TagName.FJ_CurExp;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = int.Parse(this.textBoxModifyExp.Text);

                mContent[6].eName = CEnum.TagName.FJ_MCash;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = int.Parse(this.textBoxModifyCash.Text);

                mContent[7].eName = CEnum.TagName.FJ_ihonor;
                mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[7].oContent = int.Parse(this.textBoxModifyHonor.Text);

                mContent[8].eName = CEnum.TagName.FJ_UseAccount;
                mContent[8].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[8].oContent = this.TxtAccount.Text;

                this.backgroundWorkerModifyRoleInfo.RunWorkerAsync(mContent);
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_Msg2"));
            }
        }

        private void backgroundWorkerModifyRoleInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_CharacterInfo_Update, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerModifyRoleInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonModifyOK.Enabled = true;
            Cursor = Cursors.Default;

            CEnum.Message_Body[,] result = (CEnum.Message_Body[,])e.Result;

            MessageBox.Show(result[0, 0].oContent.ToString());
        }

        private void backgroundWorkerShortCut_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_ShortCut_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerShortCut_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TbcResult.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, DataShortcut, out iPageCount);
        }

        private void GrdItemResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                using (DataTable dt = (DataTable)GrdItemResult.DataSource)
                {
                    DataTable dt2 = (DataTable)RoleInfoView.DataSource;

                    if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_DeleteItemInBody_Info"), config.ReadConfigValue("MFj", "FQA_Code_DeleteItemInBody_Title"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                        mContent[0].eName = CEnum.TagName.UserByID;
                        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);
                        

                        mContent[2].eName = CEnum.TagName.FJ_UserNick;
                        mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[2].oContent = userAccount;

                        mContent[3].eName = CEnum.TagName.FJ_ItemCode;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = 0;

                        mContent[4].eName = CEnum.TagName.FJ_ItemMark;
                        mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[4].oContent = dt.Rows[e.RowIndex][6].ToString();

                        mContent[5].eName = CEnum.TagName.FJ_Style;
                        mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[5].oContent = "body";

                        CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_ItemShop_Delete, mContent);

                        if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                            return;
                        }
                        else if (result[0, 0].oContent.ToString() == "SUCESS")
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_DeleteItemInBody_Success"));
                            this.BtnSearch_Click(null, null);
                            return;
                        }
                        else
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_DeleteItemInBody_Failed"));
                            return;
                        }
                    }
                }





            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                using (DataTable dt = (DataTable)dataGridView1.DataSource)
                {
                    DataTable dt2 = (DataTable)RoleInfoView.DataSource;
                    if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_code_DeletePackage_Info"), config.ReadConfigValue("MFj", "FQA_code_DeletePackage_Title"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                        mContent[0].eName = CEnum.TagName.UserByID;
                        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);


                        mContent[2].eName = CEnum.TagName.FJ_UserNick;
                        mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[2].oContent = userAccount;

                        mContent[3].eName = CEnum.TagName.FJ_ItemCode;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = 0;

                        mContent[4].eName = CEnum.TagName.FJ_ItemMark;
                        mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[4].oContent = dt.Rows[e.RowIndex][6].ToString();

                        mContent[5].eName = CEnum.TagName.FJ_Style;
                        mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[5].oContent = "Package";
                        CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_ItemShop_Delete, mContent);

                        if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                            return;
                        }
                        else if (result[0, 0].oContent.ToString() == "SUCESS")
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_DeletePackage_Success"));
                            this.BtnSearch_Click(null, null);
                            return;
                        }
                        else
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code-DeletePackage_Failed"));
                            return;
                        }
                    }
                }
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                using (DataTable dt = (DataTable)dataGridView2.DataSource)
                {
                    DataTable dt2 = (DataTable)RoleInfoView.DataSource;
                    if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_code_DeleteWarehouse_Info"), config.ReadConfigValue("MFj", "FQA_code_DeleteWarehouse_Title"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                        mContent[0].eName = CEnum.TagName.UserByID;
                        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);


                        mContent[2].eName = CEnum.TagName.FJ_UserNick;
                        mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[2].oContent = userAccount;

                        mContent[3].eName = CEnum.TagName.FJ_ItemCode;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent =0;

                        mContent[4].eName = CEnum.TagName.FJ_ItemMark;
                        mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[4].oContent = dt.Rows[e.RowIndex][6].ToString();


                        mContent[5].eName = CEnum.TagName.FJ_Style;
                        mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[5].oContent = "warehouse";

                        CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_ItemShop_Delete, mContent);

                        if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                            return;
                        }
                        else if (result[0, 0].oContent.ToString() == "SUCESS")
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_DeleteWarehouse_Success"));
                            this.BtnSearch_Click(null, null);
                            return;
                        }
                        else
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_DeleteWarehouse_Failed"));
                            return;
                        }
                    }
                }
            }
        }

        private void DataShortcut_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                using (DataTable dt = (DataTable)DataShortcut.DataSource)
                {
                    DataTable dt2 = (DataTable)RoleInfoView.DataSource;
                    if (MessageBox.Show(config.ReadConfigValue("MFj", "FQA_code_DeleteShortcut_Info"), config.ReadConfigValue("MFj", "FQA_code_DeleteShortcut_Title"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                        mContent[0].eName = CEnum.TagName.UserByID;
                        mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        mContent[1].eName = CEnum.TagName.FJ_ServerIP;
                        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);


                        mContent[2].eName = CEnum.TagName.FJ_UserNick;
                        mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[2].oContent = userAccount;

                        mContent[3].eName = CEnum.TagName.FJ_ItemCode;
                        mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContent[3].oContent = int.Parse(dt.Rows[e.RowIndex][0].ToString());

                        mContent[4].eName = CEnum.TagName.FJ_ItemMark;
                        mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[4].oContent = "";

                        mContent[5].eName = CEnum.TagName.FJ_Style;
                        mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[5].oContent = "shortcut";


                        CEnum.Message_Body[,] result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_ItemShop_Delete, mContent);

                        if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                            return;
                        }
                        else if (result[0, 0].oContent.ToString() == "SUCESS")
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_DeleteShortcut_Success"));
                            this.BtnSearch_Click(null, null);
                            return;
                        }
                        else
                        {
                            MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_DeleteShortcut_Failed"));
                            return;
                        }
                    }
                }
            }
        }
    }
}