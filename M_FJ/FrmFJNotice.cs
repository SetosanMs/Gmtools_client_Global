using System;
using System.Collections;
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
    [C_Global.CModuleAttribute("公告管理系统", "FrmFJNotice", "公告管理工具", "FJ Group")] 

    public partial class FrmFJNotice : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CEnum.Message_Body[,] mChannelInfo = null;
        private CSocketEvent tmp_ClientEvent = null;
        private CEnum.Message_Body[,] BroadInfo = null;
        private CEnum.Message_Body[,] mResult = null;
        private CSocketEvent m_ClientEvent = null;
        DataTable dgTable = new DataTable();
        private bool ischeck = false;
        private bool bFirst = false;
        private int iIndexID = 0;
        private int iBoardID = -1;
        private int iPageCount = 0;
        public FrmFJNotice()
        {
            InitializeComponent();
            //DptEnd.Value.AddMinutes(10);
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
            this.Text = config.ReadConfigValue("MFj", "FN_UI_FrmNotice");
            this.lblIp.Text = config.ReadConfigValue("MFj", "FN_UI_FrmlblIp");
            lblserver.Text = config.ReadConfigValue("MFj", "FN_UI_Frmlblserver");
            btnAllselect.Text = config.ReadConfigValue("MFj", "FN_UI_FrmbtnAllselect");
            btnRecord.Text = config.ReadConfigValue("MFj", "FN_UI_FrmbtnRecord");
            lblstart.Text = config.ReadConfigValue("MFj", "FN_UI_Frmlblstart");
            lblend.Text = config.ReadConfigValue("MFj", "FN_UI_Frmlblend");

            lblinv.Text = config.ReadConfigValue("MFj", "FN_UI_Frmlblinv");
            lblConet.Text = config.ReadConfigValue("MFj", "FN_UI_FrmlblConet");
            CheckStart.Text = config.ReadConfigValue("MFj", "FN_UI_FrmCheckStart");
            CheckEnd.Text = config.ReadConfigValue("MFj", "FN_UI_FrmCheckEnd");
            lblMin.Text = config.ReadConfigValue("MFj", "FN_UI_FrmlblMin");
            btnAdd.Text = config.ReadConfigValue("MFj", "FN_UI_FrmbtnAdd");
            BtnClear.Text = config.ReadConfigValue("MFj", "FN_UI_FrmBtnClear");


        }
        #endregion
        /// <summary>
        /// 请求频道名称
        /// </summary>
        private void GetChannelList()
        {
            
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 2;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_FJ");

            lock (typeof(C_Event.CSocketEvent))
            {
                mChannelInfo = Operation_FJ.GetServerList(this.m_ClientEvent, mContent);
            }
            if (mChannelInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mChannelInfo[0, 0].oContent.ToString());
                return;
            }

            this.CmbServer = Operation_FJ.BuildCombox(mChannelInfo, CmbServer);
            bFirst = true;

            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mChannelInfo, CmbServer.Text));

        }
        /// <summary>
        /// 公告记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecord_Click(object sender, EventArgs e)

        {
            //ItmEdit.Enabled = true;
            //ItmDelete.Enabled = false;
             GrdList.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

            mContent[0].eName = CEnum.TagName.FJ_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = Operation_FJ.GetItemAddr(mChannelInfo, CmbServer.Text);

            CEnum.Message_Body[,] mResult = null;
            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_BoardList_Query, mContent);
            }
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, GrdList, out iPageCount);

        }

        /// <summary>
        /// 添加公告信息内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {

            //int vailnum = Getcishu();
            //if (vailnum <= 0)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checktime"));
            //    return;
            //}

            if(TxtConnet.Text == "" || TxtConnet.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checktext"));
                return;
            }

            if (TxtConnet.Text.Length>500)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FN_Code_MsgConnet"));
                return;
            }

            if (TxtCode.CheckedItems.Count <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checkip"));
                return;
            }

            if (MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_msgaddnotice"), config.ReadConfigValue("MSDO", "FN_Code_msgnote"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                //Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);


                CEnum.Message_Body[] mContent = new CEnum.Message_Body[7];
                if (CheckStart.Checked)
                {
                    mContent[0].eName = CEnum.TagName.FJ_StartTime;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = "";

                }
                else
                {
                    mContent[0].eName = CEnum.TagName.FJ_StartTime;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = DptStart.Text;

                }
                if (CheckEnd.Checked)
                {
                    mContent[1].eName = CEnum.TagName.FJ_EndTime;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = "";
                }
                else
                {
                    mContent[1].eName = CEnum.TagName.FJ_EndTime;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = DptEnd.Text;
                }

                    mContent[2].eName = CEnum.TagName.FJ_Interval;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = Convert.ToInt32(NumMinnute.Value);

                    mContent[3].eName = CEnum.TagName.FJ_MsgContent;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = TxtConnet.Text.Trim();

                if(ischeck == true)
                {
                    mContent[4].eName = CEnum.TagName.FJ_GSName;
                    mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[4].oContent = "";
                }
                else
                {
                    mContent[4].eName = CEnum.TagName.FJ_GSName;
                    mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[4].oContent = ReturnSeverGsname();
                }
                    mContent[5].eName = CEnum.TagName.UserByID;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());



                    mContent[6].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[6].oContent = Operation_FJ.GetItemAddr(mChannelInfo, CmbServer.Text);

                CEnum.Message_Body[,] mResult1 = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult1 = mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_BoardList_Insert, mContent);
                }
                if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult1[0, 0].oContent.ToString());
                    return;
                }

                if (mResult1[0, 0].eName == CEnum.TagName.Status && mResult1[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_addfail"));
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_addsucces"));

                    
                    GrdList.DataSource = null;
                    CEnum.Message_Body[] MBContent = new CEnum.Message_Body[1];

                    MBContent[0].eName = CEnum.TagName.FJ_ServerIP;
                    MBContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    MBContent[0].oContent = Operation_FJ.GetItemAddr(mChannelInfo, CmbServer.Text);

                    CEnum.Message_Body[,] mResult = null;
                    lock (typeof(C_Event.CSocketEvent))
                    {
                        mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_BoardList_Query, MBContent);
                    }
                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }
                    Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, GrdList, out iPageCount);

                    Setdefault();
                    
                }


            }
            

        }
        /// <summary>
        /// 恢复默认值
        /// </summary>
        private void Setdefault()
        {   
            DptStart.Value = DateTime.Now;
            DptEnd.Value = DateTime.Now;
            NumMinnute.Value = 10;
            TxtConnet.Clear();
            for (int i = 0; i < TxtCode.Items.Count; i++)
            {
                TxtCode.SetItemChecked(i, false);

            }

            ischeck = false;
            CheckStart.Checked = false;
            CheckEnd.Checked = false;

        }
        /// <summary>
        /// 返回用","分割的服务器字符串
        /// </summary>
        /// <returns>ip字符串</returns>
        private string ReturnSeverGsname()
        {
            ArrayList ServerNames = new ArrayList();
            ArrayList Serverips = new ArrayList();
            string Strseverip = null;

            for (int i = 0; i < TxtCode.CheckedItems.Count; i++)
            {

                ServerNames.Add(TxtCode.CheckedItems[i].ToString());

            }

            for (int i = 0; i < ServerNames.Count; i++)
            {
                Strseverip = ServerNames[i].ToString() + "," + Strseverip;
            }

            return Strseverip;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int Getcishu()
        {   


                int intcishu = Convert.ToInt32(NumMinnute.Value);

                int noticeMin = Convert.ToInt32((DptEnd.Value - DptStart.Value).TotalMinutes);

                int txtcishu = noticeMin / intcishu;

                return txtcishu;
 


        }
        private void btnrefush_Click(object sender, EventArgs e)
        {

        }

        private void FrmSdoNotice_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            GetChannelList();
       
        }

        
        private ArrayList ChannelIndex(string[] ChannelValue)
        {
            ArrayList channel = new ArrayList();
            for (int i = 0; i < ChannelValue.Length; i++)
            {
                int chIndex = this.TxtCode.Items.IndexOf(ChannelValue[i]);
                channel.Add(chIndex);
            }

            return channel;
        }

        private void CheckedTxt(int itemindex)
        {
            for (int i = 0; i < TxtCode.Items.Count; i++)
            {
                TxtCode.SetItemChecked(i, false);

            }

            for (int i = 0; i < TxtCode.Items.Count; i++)
            {

               if (i == itemindex)
                  {
                     TxtCode.SetItemChecked(i, true);
                  }

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (ischeck == true)
            {
                for (int i = 0; i < TxtCode.Items.Count; i++)
                {
                    TxtCode.SetItemChecked(i, false);

                }
                ischeck = false;
            }
            else if (ischeck == false)
            {
                for (int i = 0; i < TxtCode.Items.Count; i++)
                {
                    TxtCode.SetItemChecked(i, true);
                }
                ischeck = true;
            }
            
        }

        private void GrdList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMod_Click(object sender, EventArgs e)
        {
             int vailnum = Getcishu();
            if (vailnum <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checktime"));
                return;
            }
            else
            {
                //Txtcishu.Text = vailnum.ToString();
            }
            //Txtcishu.Text = Getcishu();
            if(TxtConnet.Text == "" || TxtConnet.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checktext"));
                return;
            }
            //if (//cmbStauas.Text == "" || //cmbStauas.Text == null)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checkip"));
            //    return;
            //}

            if (TxtCode.CheckedItems.Count <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_msgchoosestate"));
                return;
            }

            if (MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_msgupdatenotice"), config.ReadConfigValue("MSDO", "FN_Code_msgnote"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                //Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);
                

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.SDO_BeginTime;
                mContent[0].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[0].oContent = Convert.ToDateTime(DptStart.Text);

                mContent[1].eName = CEnum.TagName.SDO_EndTime;
                mContent[1].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                mContent[1].oContent = Convert.ToDateTime(DptEnd.Text);

                mContent[2].eName = CEnum.TagName.SDO_Interval;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = Convert.ToInt32(NumMinnute.Value);

                mContent[3].eName = CEnum.TagName.SDO_Status;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = ReturnStauas("123");

                mContent[4].eName = CEnum.TagName.SDO_BoardMessage;
                mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[4].oContent = TxtConnet.Text.Trim();

                mContent[5].eName = CEnum.TagName.SDO_ServerIP;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = ReturnSeverGsname();

                mContent[6].eName = CEnum.TagName.UserByID;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                mContent[7].eName = CEnum.TagName.SDO_TaskID;
                mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[7].oContent = iBoardID;


                CEnum.Message_Body[,] mResult1 = Operation_FJ.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,ReturnSeverGsname()), CEnum.ServiceKey.SDO_BOARDTASK_UPDATE, mContent);

                if (mResult1[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult1[0, 0].oContent.ToString());
                    return;
                }

                if (mResult1[0, 0].eName == CEnum.TagName.Status && mResult1[0, 0].oContent.Equals("FAILURE"))
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_addfail"));
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_addsucces"));

                    GrdList.DataSource = null;
                    CEnum.Message_Body[] mContent1 = null;
                    mResult = null;
                    mResult = Operation_FJ.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SDO_BOARDTASK_QUERY, mContent1);

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    //GrdList.DataSource = BrowseResultInfo();
                    Setdefault();

                    btnAdd.Enabled = true;
                    btnAdd.Visible = true;



                    lblserver.Visible = false;
                    //cmbStauas.Visible = false;

                    DptStart.Enabled = true;
                    DptEnd.Enabled = true;
                    TxtConnet.Enabled = true;
                    NumMinnute.Enabled = true;


                }
            }
        }
        private int ReturnStauas(string strStauas)
        {
           int IntStauas = -1;
            if( strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate1").Trim())
            {
                IntStauas = 0;
            }
            else if(strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate2").Trim())
            {
                IntStauas = 2;
            }
            else if (strStauas == config.ReadConfigValue("MSDO", "FN_Code_infostate").Trim())
            {
                IntStauas = 1;
            }

            return IntStauas;
        }

        private string ReturnStauas(int intStauas)
        {
            string Stauas = null;
            switch (intStauas)
            {
                case 0:
                    Stauas = config.ReadConfigValue("MSDO", "FN_Code_infostate1");
                    break;
                case 2 :
                    Stauas = config.ReadConfigValue("MSDO", "FN_Code_infostate2");
                    break;
                case 1:
                    Stauas = config.ReadConfigValue("MSDO", "FN_Code_infostate");
                    break;
            }
            return Stauas;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Setdefault();
            btnAdd.Enabled = true;
            btnAdd.Visible = true;



            lblserver.Visible = false;
            ////cmbStauas.Visible = false;

            DptStart.Enabled = true;
            DptEnd.Enabled = true;
            TxtConnet.Enabled = true;
            NumMinnute.Enabled = true;



        }

        private void GrdList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                TxtCode.Items.Clear();
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];

                mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = Operation_FJ.GetItemAddr(mChannelInfo, CmbServer.Text);

                CEnum.Message_Body[,] GsResult = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    GsResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_GS_Query, mContent);
                }
                if (GsResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(GsResult[0, 0].oContent.ToString());
                    return;
                }
                for (int i = 0; i < GsResult.GetLength(0); i++)
                {
                    TxtCode.Items.Add(GsResult[i, 0].oContent.ToString());
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckStart.Checked)
            {
                DptStart.Enabled = false;
            }
            else
            {
                DptStart.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckEnd.Checked)
            {
                DptEnd.Enabled = false;
            }
            else
            {
                DptEnd.Enabled = true;
            }
        }

        private void GrdList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    iIndexID = e.RowIndex;
            //    DataTable mBoardInfo = (DataTable)GrdList.DataSource;

            //    if (mBoardInfo.Rows.Count > 0)
            //    {
            //        iBoardID = int.Parse(mBoardInfo.Rows[iIndexID][0].ToString());
            //    }
            //    if (MessageBox.Show(config.ReadConfigValue("MFj", "FN_Code_msgaddnotice"), config.ReadConfigValue("MFj", "FN_Code_msgnote"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            //    {
            //        CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            //        mContent[0].eName = CEnum.TagName.FJ_ServerIP;
            //        mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //        mContent[0].oContent = Operation_FJ.GetItemAddr(mChannelInfo, CmbServer.Text);

            //        mContent[1].eName = CEnum.TagName.FJ_MsgID;
            //        mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[1].oContent = iBoardID;

            //        mContent[2].eName = CEnum.TagName.UserByID;
            //        mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            //        mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            //        CEnum.Message_Body[,] mResult = null;
            //        lock (typeof(C_Event.CSocketEvent))
            //        {
            //            mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_BoardList_Delete, mContent);
            //        }
            //        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //        {
            //            MessageBox.Show(mResult[0, 0].oContent.ToString());
            //            return;
            //        }
            //        if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.Equals("FAILURE"))
            //        {
            //            MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_RelateDelFailed"));
            //        }
            //        else
            //        {
            //            MessageBox.Show(config.ReadConfigValue("MFj", "FQA_Code_RelateDelSuccess"));


            //            GrdList.DataSource = null;
            //            CEnum.Message_Body[] MbContent = new CEnum.Message_Body[1];

            //            MbContent[0].eName = CEnum.TagName.FJ_ServerIP;
            //            MbContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            //            MbContent[0].oContent = Operation_FJ.GetItemAddr(mChannelInfo, CmbServer.Text);

            //            CEnum.Message_Body[,] QResult = null;
            //            lock (typeof(C_Event.CSocketEvent))
            //            {
            //                QResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_BoardList_Query, MbContent);
            //            }
            //            if (QResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //            {
            //                MessageBox.Show(QResult[0, 0].oContent.ToString());
            //                return;
            //            }
            //            Operation_FJ.BuildDataTable(this.m_ClientEvent, QResult, GrdList, out iPageCount);

                       
            //        }

            //    }

            //}
            //catch
            //{ }
        }


    }
}