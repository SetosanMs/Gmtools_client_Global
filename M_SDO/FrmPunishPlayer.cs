using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using C_Global;
using C_Event;
using Language;
namespace M_SDO
{
    [C_Global.CModuleAttribute("外挂惩罚", "FrmPunishPlayer", "SDO管理工具", "SDO Group")] 
    public partial class FrmPunishPlayer : Form
    {
        
        public FrmPunishPlayer()
        {
            InitializeComponent();
        }

        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] mResult = null;
        private CEnum.Message_Body[,] mItemResult = null;
        private int iPageCount = 0;
        private bool isimport = false;
        private string strip;
        private int iIndexID;
        private int iBoardID;
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
            //IntiUI();
        }

        private void IntiUI()
        {
            //this.Text = config.ReadConfigValue("MSDO", "LR_UI_SDOLogin");
            //this.GrpSearch.Text = config.ReadConfigValue("MSDO", "LR_UI_GrpSearch");
            //this.LblServer.Text = config.ReadConfigValue("MSDO", "FM_UI_LblServer");
            //this.LblAccount.Text = config.ReadConfigValue("MSDO", "FM_UI_LblAccount");
            //this.BtnSearch.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnSearch");
            //this.BtnClose.Text = config.ReadConfigValue("MSDO", "GW_UI_BtnClose");

            //this.lblstartime.Text = config.ReadConfigValue("MSDO", "FM_UI_lblstartime");
            //this.lblendtime.Text = config.ReadConfigValue("MSDO", "FM_UI_lblendtime");
            //this.GrpResult.Text = config.ReadConfigValue("MSDO", "LR_UI_GrpResult");
            //this.LblPage.Text = config.ReadConfigValue("MSDO", "LR_UI_LblPage");

        }
        #endregion
        private void buttonBat_Click(object sender, EventArgs e)
        {
            try
            {
                strip = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);
                txtUser.Text = "";
                CmbPage.Items.Clear();
                bFirst = false;
                //comboBoxAccount.Text = "";
                //comboBoxAccount.Items.Clear();

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader m_streamReader = new StreamReader(fs);
                    //使用StreamReader类来读取文件
                    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    //  从数据流中读取每一行，直到文件的最后一行

                    //string strUserid = "";
                    //string strLine = "";
                    //while (!m_streamReader.EndOfStream)
                    //{
                    //    //this.richTextBox1.Text += strLine + "\n";
                        
                    //    strLine = m_streamReader.ReadLine();
                    //    if (strLine=="")
                    //    {
                    //        continue;
                    //    }
                    //    else
                    //    {
                    //        intCount++;

                    //        strUserid += strLine.Trim() + ",";
                    //        if (intCount%10 == 0)
                    //        {

                    //        }
                    //    }
                    //    //this.comboBoxAccount.Items.Add(strLine.Trim());

                    //}
                    
                    ////关闭此StreamReader对象
                    //m_streamReader.Close();

                    //CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];
                    //mContent[0].eName = CEnum.TagName.SDO_Account;
                    //mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[0].oContent = strUserid;

                    //mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                    //mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    //mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    ////mContent[2].eName = CEnum.TagName.SDO_EndTime;
                    ////mContent[2].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    ////mContent[2].oContent = Convert.ToDateTime(DptStart.Text);

                    //mContent[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                    //mContent[2].eName = C_Global.CEnum.TagName.UserByID;
                    //mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    this.backgroundWorkPunish.RunWorkerAsync(m_streamReader);




                    
                }
            }
            catch (Exception em)
            {
                Console.WriteLine(em.Message.ToString());
                
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            dgEquipList.DataSource = null;
            DataResult.DataSource = null;
            string UserType = null;
            if(txtUser.Text == "")
            {
                UserType = "Remote";
            }
            else
            {
                UserType = "Remote";
            }
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);
            
            mContent[1].eName = CEnum.TagName.SDO_Context;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = UserType;

            mContent[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            mContent[2].eName = C_Global.CEnum.TagName.UserByID;
            mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[3].eName = CEnum.TagName.SDO_Account;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[3].oContent = txtUser.Text.Trim();

            mContent[4].eName = CEnum.TagName.Index;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = 1;

            mContent[5].eName = CEnum.TagName.PageSize;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = 250;

            mResult = null;
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_PUNISHUSER_IMPORT_QUERY, mContent);
            }
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, dgEquipList, out iPageCount);
            }
        }

        private void FrmPunishPlayer_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            checkImport.Checked = false;
            btnUpdate.Visible = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");
            this.backgroundWorkLoad.RunWorkerAsync(mContent);

        }

        private void backgroundWorkLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }



        private void backgroundWorkPunish_DoWork(object sender, DoWorkEventArgs e)
        {
            string strUserid = "";
            string strLine = "";
            int intCount = 0;
            StreamReader m_streamReader = (StreamReader)e.Argument;
            while (!m_streamReader.EndOfStream)
            {
                //this.richTextBox1.Text += strLine + "\n";

                strLine = m_streamReader.ReadLine();
                if (strLine == "")
                {
                    continue;
                }
                else
                {
                    intCount++;

                    strUserid += strLine.Trim() + ",";
                    if (intCount % 200 == 0)
                    {
                        CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];
                        mContent[0].eName = CEnum.TagName.SDO_Account;
                        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[0].oContent = strUserid;

                        mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                        mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[1].oContent = strip;

                        //mContent[2].eName = CEnum.TagName.SDO_EndTime;
                        //mContent[2].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                        //mContent[2].oContent = Convert.ToDateTime(DptStart.Text);

                        mContent[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                        mContent[2].eName = C_Global.CEnum.TagName.UserByID;
                        mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


                        lock (typeof(C_Event.CSocketEvent))
                        {
                            e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_PUNISHUSER_IMPORT, mContent);
                        }

                        strUserid = "";
                    }
                }
                //this.comboBoxAccount.Items.Add(strLine.Trim());

            }

            //关闭此StreamReader对象
            m_streamReader.Close();
            if (strUserid != "")
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];
                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = strUserid;

                mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = strip;

                //mContent[2].eName = CEnum.TagName.SDO_EndTime;
                //mContent[2].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                //mContent[2].oContent = Convert.ToDateTime(DptStart.Text);

                mContent[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mContent[2].eName = C_Global.CEnum.TagName.UserByID;
                mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


                lock (typeof(C_Event.CSocketEvent))
                {
                    e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_PUNISHUSER_IMPORT, mContent);
                }
            }
        }

        private void backgroundWorkPunish_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, DataResult, out iPageCount);
            }

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.SDO_Context;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = "Local";

                mContent[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mContent[2].eName = C_Global.CEnum.TagName.UserByID;
                mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[3].eName = CEnum.TagName.SDO_Account;
                mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[3].oContent = "";

                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = 250;

                CEnum.Message_Body[,] mResult1 = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult1 = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_PUNISHUSER_IMPORT_QUERY, mContent);
                }
                if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult1[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult1, dgEquipList, out iPageCount);

                    if (iPageCount <= 0)
                    {
                        CmbPage.Visible = false;
                    }
                    else
                    {
                        for (int i = 0; i < iPageCount; i++)
                        {
                            CmbPage.Items.Add(i + 1);
                        }

                        CmbPage.SelectedIndex = 0;
                        bFirst = true;
                        CmbPage.Visible = true;
                    }
                }


            
        }

        private void btnPunish_Click(object sender, EventArgs e)
        {
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.SDO_BeginTime;
            mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[1].oContent = Convert.ToDateTime(DptStart.Text);

            mContent[2].eName = CEnum.TagName.SDO_EndTime;
            mContent[2].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[2].oContent = Convert.ToDateTime(DptEnd.Text);

            mContent[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            mContent[3].eName = C_Global.CEnum.TagName.UserByID;
            mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            CEnum.Message_Body[,] mResult1 = null;
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult1 = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_USER_PUNISHALL, mContent);
            }
            if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult1[0, 0].oContent.ToString());
                return;
            }

            if (mResult1[0, 0].oContent.ToString() == "SUCESS")
            {
                MessageBox.Show("惩罚玩家成功");
                dgEquipList.DataSource = null;
                DataResult.DataSource = null;
            }
            else
            {
                MessageBox.Show("惩罚玩家失败");
            }
        }



        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_USER_PUNISH, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.buttonConfirm.Enabled = true;
            this.Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}
            if (mResult[0, 0].oContent.ToString() == "SUCESS")
            {
                MessageBox.Show("惩罚玩家成功");
                txtUser.Text = "";
                
            }
            else
            {
                MessageBox.Show("惩罚玩家失败");
                return;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim().Length > 0)
            {
                this.buttonConfirm.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[1].eName = CEnum.TagName.SDO_BeginTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[1].oContent = Convert.ToDateTime(DptStart.Text);

                mContent[2].eName = CEnum.TagName.SDO_EndTime;
                mContent[2].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[2].oContent = Convert.ToDateTime(DptEnd.Text);

                mContent[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                mContent[3].eName = C_Global.CEnum.TagName.UserByID;
                mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[4].eName = CEnum.TagName.SDO_Account;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = txtUser.Text;

                this.backgroundWorkerSearch.RunWorkerAsync(mContent);
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
            }
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void checkImport_CheckedChanged(object sender, EventArgs e)
        {
            if (checkImport.Checked)
            {
                btnPunish.Visible = true;
                buttonBat.Visible = true;
                buttonConfirm.Visible = false;
                txtUser.Enabled = false;
            }
            else
            {
                buttonConfirm.Visible = true;
                btnPunish.Visible = false;
                buttonBat.Visible = false;
                txtUser.Enabled = true;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgEquipList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                iIndexID = e.RowIndex;
                ItmEdit.Enabled = true;
                //DataTable mBoardInfo = (DataTable)dgEquipList.DataSource;

                //if (mBoardInfo.Rows.Count > 0)
                //{
                //    iBoardID = int.Parse(mBoardInfo.Rows[iIndexID][0].ToString());
                //}
            }
            catch
            { }
        }

        private void ItmEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Visible = true;
                DataTable mBoard = (DataTable)dgEquipList.DataSource;

                txtUser.Text = mBoard.Rows[iIndexID][0].ToString();
                DptStart.Text = mBoard.Rows[iIndexID][1].ToString();
                DptEnd.Text = mBoard.Rows[iIndexID][2].ToString();
            }
            catch
            {
 
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.btnUpdate.Enabled = false;
            this.Cursor = Cursors.AppStarting;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);


            mContent[1].eName = CEnum.TagName.SDO_BeginTime;
            mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[1].oContent = Convert.ToDateTime(DptStart.Text);

            mContent[2].eName = CEnum.TagName.SDO_EndTime;
            mContent[2].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
            mContent[2].oContent = Convert.ToDateTime(DptEnd.Text);

            mContent[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            mContent[3].eName = C_Global.CEnum.TagName.UserByID;
            mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[4].eName = CEnum.TagName.SDO_Account;
            mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[4].oContent = txtUser.Text;



            this.backgroundWorkUpdate.RunWorkerAsync(mContent);
        }

        private void backgroundWorkUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_PUNISH_UPDATE_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnUpdate.Enabled = true;
            this.Cursor = Cursors.Default;
            btnUpdate.Visible = false;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}
            if (mResult[0, 0].oContent.ToString() == "SUCESS")
            {
                MessageBox.Show("更新玩家信息成功");
                //txtUser.Text = "";
                dgEquipList.DataSource = null;
                ItmEdit.Enabled = false;

            }
            else
            {
                MessageBox.Show("更新玩家信息失败");
                return;
            }
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if(bFirst)
            {
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[1].eName = CEnum.TagName.SDO_Context;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = "Local";

            mContent[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            mContent[2].eName = C_Global.CEnum.TagName.UserByID;
            mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[3].eName = CEnum.TagName.SDO_Account;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[3].oContent = "";

            mContent[4].eName = CEnum.TagName.Index;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = (int.Parse(CmbPage.Text) - 1) * 250 + 1;

            mContent[5].eName = CEnum.TagName.PageSize;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = 250;

            CEnum.Message_Body[,] mResult1 = null;
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult1 = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_PUNISHUSER_IMPORT_QUERY, mContent);
            }

            if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult1[0, 0].oContent.ToString());
                return;
            }
            Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult1, dgEquipList, out iPageCount);

               
            }
        }
    }
}