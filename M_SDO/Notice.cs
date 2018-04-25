using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using C_Global;
using C_Event;
using System.Collections;

using GM_Server.SDOAPI;

namespace M_SDO
{
    [C_Global.CModuleAttribute("Ƶ������", "Notice", "", "SDO Group")]
    public partial class Notice : Form
    {
        #region ���ú���
        /// <summary>
        /// ��������еĴ���
        /// </summary>
        /// <param name="oParent">MDI ����ĸ�����</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>����еĴ���</returns>
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

        #region ����
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] serverIPResult = null; //�������ѯ���
        C_Global.CEnum.Message_Body[,] channelResult = null; //�������ѯ���
        C_Global.CEnum.Message_Body[,] aLiveResult = null; //�������ѯ���


        private string _ServerIP = null;

        ArrayList alChannels = new ArrayList();

        #endregion

        #region ����
        /// <summary>
        /// ��ʼ����Ϸ�������б�
        /// </summary>
        public void InitializeServerIP()
        {
            try
            {
                this.cbxServerIP.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[2];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[0].eName = C_Global.CEnum.TagName.ServerInfo_GameID;
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_SDO");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 2;

                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //���״̬
                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    return;
                }

                //��ʾ���ݵ��б�
                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }

                cbxServerIP.SelectedIndex = 0;
            }
            catch
            {
            }
        }


        public void GetChannel()
        {
            try
            {
                this.listView1.Items.Clear();

                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[1];

                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
                messageBody[0].oContent = _ServerIP;

                channelResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_CHANNELLIST_QUERY, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);

                //���״̬
                if (channelResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(channelResult[0, 0].oContent.ToString());
                    return;
                }

                //��ʾ���ݵ��б�
                for (int i = 0; i < channelResult.GetLength(0); i++)
                {
                    this.listView1.Items.Add(channelResult[i, 0].oContent.ToString() + "/" + channelResult[i, 1].oContent.ToString() + "    --    " + channelResult[i, 4].oContent.ToString() + "        User:" + channelResult[i, 2].oContent.ToString() + "/" + channelResult[i, 3].oContent.ToString());
                    this.listView1.Items[i].Tag = channelResult[i, 0].oContent.ToString() + "/" + channelResult[i, 1].oContent.ToString() + "/" + channelResult[i, 2].oContent.ToString() + "/" + channelResult[i, 3].oContent.ToString() + "/" + channelResult[i, 4].oContent.ToString();
                }

                //ThreadStart wokerStart = new ThreadStart(ReadThreadFunc);
                //Thread workThread = new Thread(wokerStart);
                //workThread.Start();
            }
            catch
            {
            }
        }


        public void ReadThreadFunc()
        {
            while (true)
            {

                aLiveResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_ALIVE_REQ, C_Global.CEnum.Msg_Category.SDO_ADMIN, null);


                //if (aLiveResult[0, 0].oContent == "1")
                //{

                //}

                Thread.Sleep(10);
            }
        }



        //public void ToLoadChannel(int iItemIndex, short sPlanetID, short sChannelID, int iLimitUser, int iCurrentUser, string sAddr, System.Windows.Forms.Form _form)
        //{
        //    ReLoadChannel(iItemIndex, sPlanetID, sChannelID, iLimitUser, iCurrentUser, sAddr);
        //    //MessageBox.Show(iItemIndex.ToString());
        //    //this.listView1.Items.Add(iItemIndex.ToString());
        //    //this.listView1.Items.Add(sPlanetID.ToString() + "/" + sChannelID.ToString() + "/" + iLimitUser.ToString() + "/" + iCurrentUser.ToString() + "/" + sAddr);
        //    //this.listView1.Items[iItemIndex].Tag = sPlanetID.ToString() + "/" + sChannelID.ToString() + "/" + iLimitUser.ToString() + "/" + iCurrentUser.ToString() + "/" + sAddr;
        //}

        //private void ReLoadChannel1(object sender, System.EventArgs e)
        //{
        //    this.listView1.Items.Add("bbbcc");
        //}

        //public void ReLoadChannel(int iItemIndex, short sPlanetID, short sChannelID, int iLimitUser, int iCurrentUser, string sAddr)
        //{
        //    //MessageBox.Show(iItemIndex.ToString());
        //    //this.listView1.h
        //    this.listView1.Items.Add(iItemIndex.ToString());

        //    //_listView.Items.Add("a");
        //    //this.textBox1.Text = iItemIndex.ToString();
        //    //this.listView1.Items.Add(iItemIndex.ToString());
        //    //this.listView1.Items.Add(sPlanetID.ToString() + "/" + sChannelID.ToString() + "/" + iLimitUser.ToString() + "/" + iCurrentUser.ToString() + "/" + sAddr);
        //    //this.listView1.Items[iItemIndex].Tag = sPlanetID.ToString() + "/" + sChannelID.ToString() + "/" + iLimitUser.ToString() + "/" + iCurrentUser.ToString() + "/" + sAddr;
        //}

        #endregion

        public Notice()
        {
            InitializeComponent();
        }

        private void Notice_Load(object sender, EventArgs e)
        {
            InitializeServerIP();
            //ToLoadChannel(1, 2, 3, 4, 5, "192.168.0.1",this.listView1);

            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                #region ����
                if (cbxServerIP.Text == null || cbxServerIP.Text == "")
                {
                    MessageBox.Show("��ѡ�������");
                    return;
                }
                #endregion

                #region IP����
                for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
                {
                    if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                    {
                        this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                    }
                }
                #endregion

                GetChannel();

                //SDONoticeInfoAPI sdoApi = new SDONoticeInfoAPI(this,listView1);
                //sdoApi.ChannelList_Query(_ServerIP);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string[] _tempChannels = null;

            //int[,] iA_PC = new int[alChannels.Count, 2];

            //string sChannelIDs = "";

            //for (int i = 0; i < alChannels.Count; i++)
            //{
            //    int itemPosID = int.Parse(alChannels[i].ToString());
            //    _tempChannels = this.listView1.Items[itemPosID].Tag.ToString().Split(new char[] { '/' });
            //    iA_PC[i, 0] = int.Parse(_tempChannels[0]);
            //    iA_PC[i, 1] = int.Parse(_tempChannels[1]);
            //}

            //GM_Server.SDOAPI.SDONoticeInfoAPI sdoApi = new SDONoticeInfoAPI();
            //sdoApi.sendBoardMsg_Req(iA_PC, textBox1.Text);

            if (alChannels.Count == 0)
            {
                MessageBox.Show("��ѡ��Ƶ��");
                return;
            }
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("�����빫������");
                textBox1.Focus();
                return;
            }

            string _sChannelList = null;
            for (int i = 0; i < alChannels.Count; i++)
            {
                _sChannelList += alChannels[i].ToString() + ";";
            }
            _sChannelList = _sChannelList.Substring(0, _sChannelList.Length - 1);




            //��־����
            //for (int i = 0; i < alChannels.Count; i++)
            //{
            //    int itemPosID = int.Parse(alChannels[i].ToString());
            //    sChannelIDs += this.listView1.Items[itemPosID].Tag.ToString() + "\n";
            //}

            C_Global.CEnum.Message_Body[,] resultMsgBody = null;

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.SDO_ServerIP;
            messageBody[0].oContent = _ServerIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[1].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[1].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.SDO_ChannelList;
            messageBody[2].oContent = _sChannelList;

            messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[3].eName = C_Global.CEnum.TagName.SDO_BoardMessage;
            messageBody[3].oContent = textBox1.Text;

            resultMsgBody = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SDO_BOARDMESSAGE_REQ, C_Global.CEnum.Msg_Category.SDO_ADMIN, messageBody);
            //���״̬
            if (resultMsgBody[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(resultMsgBody[0, 0].oContent.ToString());
                //Application.Exit();
                return;
            }
            if (resultMsgBody[0, 0].oContent.ToString().ToUpper().Equals("SUCESS"))
            {
                MessageBox.Show("�ɹ�!");
                this.listView1.Items.Clear();
                this.textBox1.Text = null;
                this.alChannels = null;
            }
            else
            {
                MessageBox.Show("ʧ��");
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                int iChannelID = int.Parse(e.Index.ToString());

                //ѡ���¼�
                if (e.CurrentValue.ToString().ToLower().Equals("unchecked"))
                {
                    if (alChannels.IndexOf(listView1.Items[iChannelID].Tag.ToString()) == -1)
                    {
                        alChannels.Add(listView1.Items[iChannelID].Tag.ToString());
                    }
                }
                else//����ѡ��
                {
                    alChannels.Remove(listView1.Items[iChannelID].Tag.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            this.textBox1.Text = null;
            this.alChannels = null;
        }
    }
}