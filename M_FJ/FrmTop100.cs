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

namespace M_FJ
{
    [C_Global.CModuleAttribute("玩家排行榜", "FrmTop100", "玩家排行榜", "FJ Group")] 
    public partial class FrmTop100 : Form
    {   
        public FrmTop100()
        {
            InitializeComponent();
        }
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;

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
            FrmTop100 mModuleFrm = new FrmTop100();
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
            this.Text = config.ReadConfigValue("MFj", "BA_Txt");
            this.GrpSearch.Text = config.ReadConfigValue("MFj", "BA_Txt");
            this.LblServer.Text = config.ReadConfigValue("MFj", "BA_UI_LblServer");
            this.BtnSearch.Text = config.ReadConfigValue("MFj", "BA_UI_Btn_Search");
            this.BtnClear.Text = config.ReadConfigValue("MFj", "BA_UI_BtnClose");
            this.label1.Text = config.ReadConfigValue("MFj", "BA_UI_type");

            
        }
        #endregion
        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmTop100_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            comboBox1.Items.Add(config.ReadConfigValue("MFj", "BA_CodeLeavel"));
            comboBox1.Items.Add(config.ReadConfigValue("MFj", "BA_CodeG"));
            
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
            if (comboBox1.Text.Length > 0)
            {
                BtnSearch.Enabled = false;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

                mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.Index;
                mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[1].oContent = 1;

                mContent[2].eName = CEnum.TagName.PageSize;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = 100;

                mContent[3].eName = CEnum.TagName.FJ_Max;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = ReturnType(comboBox1.Text.Trim());


                this.backgroundWorkerSearch.RunWorkerAsync(mContent);

            }
            else
            {
                MessageBox.Show("请输入查询类型");
            }
        }

        private int ReturnType(string strType)
        {
            int intType = 0;
            if (strType == config.ReadConfigValue("MFj", "BA_CodeLeavel"))
            {
                intType = 1;
            }
            else if (strType == config.ReadConfigValue("MFj", "BA_CodeG"))
            {
                intType = 2;
            }

            return intType;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_PlayerLevelMoney_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            CEnum.Message_Body[,] mGetResult = (CEnum.Message_Body[,])e.Result;
            //无内容显示
            if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                return;
            }


            Operation_FJ.BuildDataTable(this.m_ClientEvent, mGetResult, RoleInfoView, out iPageCount);

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
                PnlPage.Visible = false;
            }
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
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

            //LblUser.Text = "";
            //PnlInput.Visible = true;
            RoleInfoView.DataSource = null;
            PnlPage.Visible = false;
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }
    }
}