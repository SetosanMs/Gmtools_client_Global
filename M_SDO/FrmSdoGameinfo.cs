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
using System.Text.RegularExpressions;
using Language;
namespace M_SDO
{
    [C_Global.CModuleAttribute("大赛信息编辑", "FrmSdoGameinfo", "SDO管理工具", "SDO Group")] 
    public partial class FrmSdoGameinfo : Form
    {
        public FrmSdoGameinfo()
        {
            InitializeComponent();
        }

        private CEnum.Message_Body[,] mServerInfo = null;
        private CEnum.Message_Body[,] mChannelInfo = null;
        private CEnum.Message_Body[,] BroadInfo = null;
        private CEnum.Message_Body[,] addResult = null;
        private CSocketEvent m_ClientEvent = null;
        DataTable dgTable = new DataTable();
        ArrayList ipAddress = new ArrayList();
        private bool ischeck = false;
        string ServerIP = "";
        C_Global.CEnum.Message_Body[,] musicResult = null;

        C_Global.CEnum.Message_Body[,] senceResult = null;
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

        private void FrmSdoGameinfo_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            GetChannelList();
            InitializeMusicList();
            ReadSence();
        }

        /// <summary>
        /// 请求频道名称
        /// </summary>
        private void GetChannelList()
        {

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");
            lock (typeof(C_Event.CSocketEvent))
            {
                mChannelInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);
            }
            if (mChannelInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mChannelInfo[0, 0].oContent.ToString());
                return;
            }

            for (int i = 0; i < mChannelInfo.GetLength(0); i++)
            {
                TxtCode.Items.Add(mChannelInfo[i, 1].oContent.ToString());
            }

        }
        /// <summary>
        /// 读音乐
        /// </summary>
        public void InitializeMusicList()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];


                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = "gmtools";

                /*
                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 2;
                */

                lock (typeof(C_Event.CSocketEvent))
                {
                    musicResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_MUSICDATA_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);
                }
                ////检测状态


                if (musicResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(musicResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //cbxServerIP.Enabled = false;
                //dpContent.Enabled = true;
                //btnConfirm.Enabled = true;
                //btnCancel.Enabled = true;




                for (int i = 0; i < musicResult.GetLength(0); i++)
                {
                    cbxSong1.Items.Add(musicResult[i, 1].oContent.ToString());
                    cbxSong2.Items.Add(musicResult[i, 1].oContent.ToString());
                    cbxSong3.Items.Add(musicResult[i, 1].oContent.ToString());
                    cbxSong4.Items.Add(musicResult[i, 1].oContent.ToString());
                    cbxSong5.Items.Add(musicResult[i, 1].oContent.ToString());

                }

                cbxDay.SelectedIndex = 0;
                cbxSong1.SelectedIndex = 0;
                cbxLevel1.SelectedIndex = 0;

                cbxSong2.SelectedIndex = 1;
                cbxLevel2.SelectedIndex = 0;

                cbxSong3.SelectedIndex = 2;
                cbxLevel3.SelectedIndex = 1;

                cbxSong4.SelectedIndex = 3;
                cbxLevel4.SelectedIndex = 2;

                cbxSong5.SelectedIndex = 4;
                cbxLevel5.SelectedIndex = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 读取场景
        /// </summary>
        private void ReadSence()
        {
            try
            {
                lock (typeof(C_Event.CSocketEvent))
                {
                    senceResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.SDO_CHALLENGE_SCENE_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, null);
                }

                if (senceResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(senceResult[0, 0].oContent.ToString());
                    return;
                }

                for (int i = 0; i < senceResult.GetLength(0); i++)
                {
                    cbxScene.Items.Add(senceResult[i, 1].oContent.ToString());
                }
                cbxScene.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// 获取音乐index
        /// </summary>
        /// <param name="musicName">歌曲名</param>
        /// <returns></returns>
        private int GetMusicIndex(string musicName)
        {
            int musicIndex = 0;
            for (int i = 0; i < musicResult.GetLength(0); i++)
            {
                if (musicResult[i, 1].oContent.ToString().Equals(musicName))
                {
                    musicIndex = int.Parse(musicResult[i, 0].oContent.ToString());
                }
            }
            return musicIndex;
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
        /// <summary>
        /// 返回用服务器ip
        /// </summary>
        /// <returns>ip字符串</returns>
        private ArrayList ReturnSeverip()
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
                Serverips.Add(Operation_SDO.GetItemAddr(mChannelInfo, ServerNames[i].ToString()));
            }

            //for (int i = 0; i < Serverips.Count; i++)
            //{
            //    Strseverip = Serverips[i].ToString() + "," + Strseverip;
            //}

            return Serverips;
        }

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
            this.Text = config.ReadConfigValue("MSDO", "FGI_UI_Frmname");
            this.label2.Text = config.ReadConfigValue("MSDO", "FGI_UI_label2");
            this.button2.Text = config.ReadConfigValue("MSDO", "FGI_UI_button2");
            this.label1.Text = config.ReadConfigValue("MSDO", "FGI_UI_label1");
            this.label9.Text = config.ReadConfigValue("MSDO", "FGI_UI_label9");
            this.label3.Text = config.ReadConfigValue("MSDO", "FGI_UI_label3");
            this.label4.Text = config.ReadConfigValue("MSDO", "FGI_UI_label4");
            this.label5.Text = config.ReadConfigValue("MSDO", "FGI_UI_label5");
            this.label6.Text = config.ReadConfigValue("MSDO", "FGI_UI_label6");
            this.label7.Text = config.ReadConfigValue("MSDO", "FGI_UI_label7");
            this.label8.Text = config.ReadConfigValue("MSDO", "FGI_UI_label8");
            this.label11.Text = config.ReadConfigValue("MSDO", "FGI_UI_label11");
            this.label13.Text = config.ReadConfigValue("MSDO", "FGI_UI_label13");
            this.label15.Text = config.ReadConfigValue("MSDO", "FGI_UI_label15");
            this.label17.Text = config.ReadConfigValue("MSDO", "FGI_UI_label17");
            this.btnConfirm.Text = config.ReadConfigValue("MSDO", "ME_UI_btnConfirm");
            this.btnCancel.Text = config.ReadConfigValue("MSDO", "ME_UI_btnCancel");



        }
        #endregion
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (DptGametime.Text == null || DptGametime.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgStartTime"));
                DptGametime.Focus();
                return;
            }

            if (DptStart.Text == null || DptStart.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgStartTime"));
                DptStart.Focus();
                return;
            }

            if (DptEnd.Text == null || DptEnd.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgEndTime"));
                DptEnd.Focus();
                return;
            }

            if (txtGCash.Text == null || txtGCash.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgG"));
                txtGCash.Focus();
                return;
            }

            if (txtMCash.Text == null || txtMCash.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgM"));
                txtMCash.Focus();
                return;
            }
            btnConfirm.Enabled = false;
            AddGameinfo();
            
            
        }

        private void AddGameinfo()
        {
            
            CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[22];
            
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
            messageBody[0].oContent = "";

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[1].eName = C_Global.CEnum.TagName.SDO_WeekDay;
            messageBody[1].oContent = cbxDay.SelectedIndex;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[2].eName = C_Global.CEnum.TagName.SDO_MatPtHR;
            messageBody[2].oContent = int.Parse(DptGametime.Value.Hour.ToString());

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[3].eName = C_Global.CEnum.TagName.SDO_MatPtMin;
            messageBody[3].oContent = int.Parse(DptGametime.Value.Minute.ToString());

            messageBody[4].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[4].eName = C_Global.CEnum.TagName.SDO_StPtHR;
            messageBody[4].oContent = int.Parse(Convert.ToDateTime(DptStart.Text).Hour.ToString());

            messageBody[5].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[5].eName = C_Global.CEnum.TagName.SDO_StPtMin;
            messageBody[5].oContent = int.Parse(Convert.ToDateTime(DptStart.Text).Minute.ToString());

            messageBody[6].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[6].eName = C_Global.CEnum.TagName.SDO_EdPtHR;
            messageBody[6].oContent = int.Parse(Convert.ToDateTime(DptEnd.Text).Hour.ToString());

            messageBody[7].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[7].eName = C_Global.CEnum.TagName.SDO_EdPtMin;
            messageBody[7].oContent = int.Parse(Convert.ToDateTime(DptEnd.Text).Minute.ToString());

            messageBody[8].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[8].eName = C_Global.CEnum.TagName.SDO_GCash;
            messageBody[8].oContent = int.Parse(txtGCash.Text);

            messageBody[9].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[9].eName = C_Global.CEnum.TagName.SDO_MCash;
            messageBody[9].oContent = int.Parse(txtMCash.Text);

            int __senceID = 0;
            for (int i = 0; i < senceResult.GetLength(0); i++)
            {
                if (cbxScene.Text.Trim().Equals(senceResult[i, 1].oContent.ToString().Trim()))
                {
                    __senceID = int.Parse(senceResult[i, 0].oContent.ToString());
                }
            }
            messageBody[10].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[10].eName = C_Global.CEnum.TagName.SDO_Sence;
            messageBody[10].oContent = __senceID;

            messageBody[11].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[11].eName = C_Global.CEnum.TagName.SDO_MusicID1;
            messageBody[11].oContent = GetMusicIndex(cbxSong1.Text);

            messageBody[12].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[12].eName = C_Global.CEnum.TagName.SDO_LV1;
            messageBody[12].oContent = cbxLevel1.SelectedIndex;

            messageBody[13].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[13].eName = C_Global.CEnum.TagName.SDO_MusicID2;
            messageBody[13].oContent = GetMusicIndex(cbxSong2.Text);

            messageBody[14].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[14].eName = C_Global.CEnum.TagName.SDO_LV2;
            messageBody[14].oContent = cbxLevel2.SelectedIndex;

            messageBody[15].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[15].eName = C_Global.CEnum.TagName.SDO_MusicID3;
            messageBody[15].oContent = GetMusicIndex(cbxSong3.Text);

            messageBody[16].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[16].eName = C_Global.CEnum.TagName.SDO_LV3;
            messageBody[16].oContent = cbxLevel3.SelectedIndex;

            messageBody[17].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[17].eName = C_Global.CEnum.TagName.SDO_MusicID4;
            messageBody[17].oContent = GetMusicIndex(cbxSong4.Text);

            messageBody[18].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[18].eName = C_Global.CEnum.TagName.SDO_LV4;
            messageBody[18].oContent = cbxLevel4.SelectedIndex;

            messageBody[19].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[19].eName = C_Global.CEnum.TagName.SDO_MusicID5;
            messageBody[19].oContent = GetMusicIndex(cbxSong5.Text);

            messageBody[20].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[20].eName = C_Global.CEnum.TagName.SDO_LV5;
            messageBody[20].oContent = cbxLevel5.SelectedIndex;

            messageBody[21].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[21].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[21].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            this.backgroundWorkAdd.RunWorkerAsync(messageBody);
            //addResult = m_ClientEvent.GetSocket(m_ClientEvent, this.ServerIP).RequestResult(C_Global.CEnum.ServiceKey.SDO_CHALLENGE_INSERT, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

            //if (addResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            //{
     
            //    MessageBox.Show(addResult[0, 0].oContent.ToString());
            //    return;
            //}

            //if (addResult[0, 0].oContent.ToString().Equals("FAILURE"))
            //{

            //    MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgopFail"));
            //    return;
            //}

            //if (addResult[0, 0].oContent.ToString().Equals("SUCESS"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "ME_Code_MsgopSucces"));
 
            //}
        }

        private void backgroundWorkAdd_DoWork(object sender, DoWorkEventArgs e)
        {
            ipAddress.Clear();
            ipAddress = ReturnSeverip();
            lock (typeof(C_Event.CSocketEvent))
            {
                for (int i = 0; i < ipAddress.Count; i++)
                {
                    ((CEnum.Message_Body[])e.Argument)[0].oContent = ipAddress[i].ToString();
                    ServerIP = ipAddress[i].ToString();
                    addResult = m_ClientEvent.GetSocket(m_ClientEvent, this.ServerIP).RequestResult(C_Global.CEnum.ServiceKey.SDO_CHALLENGE_INSERTALL, C_Global.CEnum.Msg_Category.SDO_ADMIN, (CEnum.Message_Body[])e.Argument);
                    this.backgroundWorkAdd.ReportProgress(i);
                }
            }
            
        }

        private void backgroundWorkAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnConfirm.Enabled = true;
        }

        private void backgroundWorkAdd_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.progressBar2.Value = ((float)e.ProgressPercentage+1)/((float)ipAddress.Count)*100;
            if (addResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(addResult[0, 0].oContent.ToString());
                return;
            }

            else
            {
                MessageBox.Show(addResult[0, 0].oContent.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    for()
        //    {
        //        messageBody[0].oContent = Arrange[i].tostring();
        //        ServerIP = Arrange[i].tostring();
        //    }

        //}

        //private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{

        //}
    }
}