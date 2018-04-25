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
using M_Audition;
using System.IO;
namespace M_AU
{
    [C_Global.CModuleAttribute("添加Pcip", "FrmAddPcip", "AU管理工具", "AUGroup")] 
    public partial class FrmAddPcip : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CEnum.Message_Body[,] mChannelInfo = null;
        private CEnum.Message_Body[,] BroadInfo = null;
        private CEnum.Message_Body[,] mResult = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        DataTable dgTable = new DataTable();
        private bool ischeck = false;
        private int iIndexID = 0;
        private int iBoardID = -1;
        private DataTable dataErr;
        private ArrayList paramList = new ArrayList();
        private ArrayList ServerList = new ArrayList();
        public FrmAddPcip()
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
            //this.Text = config.ReadConfigValue("MSDO", "FN_UI_FrmSdoNotice");




        }
        #endregion


        private void GetChannelList()
        {

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_AU");
            lock (typeof(C_Event.CSocketEvent))
            {
                mChannelInfo = Operation_Audition.GetServerList(this.m_ClientEvent, mContent);
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

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBoxPath.Text = openFileDialog1.FileName;
            }
        }

        private void backgroundWorkerSearch_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            paramList.Clear();
            ServerList.Clear();
            ServerList = ReturnSeverip();
            GrdList.DataSource = null;
            this.progressBar1.Value = 0;

            if (TxtCode.CheckedItems.Count <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "FN_Code_checkip"));
                return;
            }

            if (txtExp.Text.Length <= 0)
            {
                MessageBox.Show("请输入经验倍数");
                return;
            }
            if (txtG.Text.Length <= 0)
            {
                MessageBox.Show("请输入G币倍数");
                return;
            }
            if (textBoxPath.Text.Length <= 0)
            {
                MessageBox.Show("请选择一个文件");
                return;
            }
            try
            {
                StreamReader sr = new StreamReader(this.textBoxPath.Text);
                while (!sr.EndOfStream)
                {
                    string tmp1 = sr.ReadLine();
                    string tmp = CheckIP(tmp1);
                    if (tmp != "")
                    {
                        paramList.Add(tmp);
                    }
                }
                if (paramList.Count == 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "QC_CODE_Msg2"));
                    return;
                }

            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "QC_CODE_Msg2"));
            }

            btnOk.Enabled = false;
            this.backgroundWorkerSearch.RunWorkerAsync();
        }

        private void FrmAddPcip_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            GetChannelList();
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


            for (int i = 0; i < TxtCode.CheckedItems.Count; i++)
            {

                ServerNames.Add(TxtCode.CheckedItems[i].ToString());

            }
            for (int i = 0; i < ServerNames.Count; i++)
            {
                Serverips.Add(Operation_Audition.GetItemAddr(mChannelInfo, ServerNames[i].ToString()));
            }

            return Serverips;
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            btnOk.Enabled = false;
            CEnum.Message_Body[] mContent;
                    dataErr = new DataTable();

                    dataErr.Columns.Add("大区IP");
                    dataErr.Columns.Add("状态");
            for (int i = 0; i < ServerList.Count; i++)
            {
                
                for (int j = 0; j < paramList.Count; j++)
                {
                    mContent = new CEnum.Message_Body[5];
                    mContent[0].eName = CEnum.TagName.AU_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = ServerList[i].ToString();


                    mContent[1].eName = CEnum.TagName.AU_PcIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = paramList[j].ToString();

                    mContent[2].eName = CEnum.TagName.AU_ExpRate;
                    mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[2].oContent = int.Parse(txtExp.Text.Trim());


                    mContent[3].eName = CEnum.TagName.AU_MoneyRate;
                    mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[3].oContent = int.Parse(txtG.Text.Trim());

  

                    mContent[4].eName = CEnum.TagName.UserByID;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


                    //tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, ServerList[i].ToString());
                    lock (typeof(C_Event.CSocketEvent))
                    {
                        mResult = Operation_Audition.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AU_JOINPCIP_Insert, mContent);
                    }


                    if (mResult[0, 0].oContent.ToString() == "FAILURE")
                    {
                        DataRow dr = dataErr.NewRow();
                        dr[0] = Operation_Audition.GetItemName(mChannelInfo, ServerList[i].ToString());
                        dr[1] = "操作失败";
                        dataErr.Rows.Add(dr);
                    }
                }



                this.backgroundWorkerSearch.ReportProgress((int)(((float)(i + 1)) / ((float)ServerList.Count) * 100));
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GrdList.DataSource = dataErr;
            btnOk.Enabled = true;
        }
        private string CheckIP(string strip)
        {
            try
            {
                bool isadd = false;
                System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse(strip);
                isadd = strip.StartsWith("192.168.");
                if (isadd)
                {
                    return strip = "";
                }
                else
                {
                    return strip;
                }
            }
            catch
            {
                return strip = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}