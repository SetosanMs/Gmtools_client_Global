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

namespace M_FJ
{
    public partial class FrmNewMission : Form
    {
        public FrmNewMission(CSocketEvent m_event,string nickname,string serverip,string questid,string content,string state,int level)
        {
            InitializeComponent();
            this.m_ClientEvent = m_event;
            this.serverIP = serverip;
            this.nickName = nickname;
            this.questID = questid;
            this.content = content;
            this.state = state;
            this.level = level;
        }

        private CSocketEvent m_ClientEvent = null;
        private string serverIP = null;
        private string nickName = null;
        private string questID = null;
        private string content = null;
        private string state = null;
        private int level = 0;
        private CEnum.Message_Body[,] mTaskInfo = null;

        #region ÓïÑÔ¿â
        /// <summary>
        ///¡¡ÎÄ×Ö¿â
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// ³õÊ¼»¯»ªÎÄ×ÖÓïÑÔ¿â
        /// </summary>
        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MFj", "FMI_UI_FrmNewMission");
            this.labelNick.Text = config.ReadConfigValue("MFj", "FMI_UI_labelNick");
            this.labelQuestID.Text = config.ReadConfigValue("MFj", "FMI_UI_labelQuestID");
            this.label3.Text = config.ReadConfigValue("MFj", "FMI_UI_label3");
            this.labelState.Text = config.ReadConfigValue("MFj", "FMI_UI_labelState");
            this.buttonNew.Text = config.ReadConfigValue("MFj", "FMI_UI_buttonNew");
            this.buttonDel.Text = config.ReadConfigValue("MFj", "FMI_UI_buttonDel");
            this.buttonOK.Text = config.ReadConfigValue("MFj", "FMI_UI_buttonOK");

            this.comboBoxState.Items.Clear();
            this.comboBoxState.Items.AddRange(new object[] {
            config.ReadConfigValue("MFj", "FM_Code_MissionState0"),
            config.ReadConfigValue("MFj", "FM_Code_MissionState1"),
            config.ReadConfigValue("MFj", "FM_Code_MissionState2"),
            config.ReadConfigValue("MFj", "FM_Code_MissionState3")});
        }


        #endregion

        private void FrmNewMission_Load(object sender, EventArgs e)
        {
            IntiFontLib();

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];


            mContent[0].eName = CEnum.TagName.FJ_Level;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = this.level;

            this.mTaskInfo = Operation_FJ.GetResult(this.m_ClientEvent, CEnum.ServiceKey.FJ_QuestTable_Query, mContent);
            if (mTaskInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mTaskInfo[0, 0].oContent.ToString());
                this.Close();
                return;
            }
            else
            {
                this.textBoxNick.Text = this.nickName;
                this.comboBoxState.Text = this.state;
                this.comboBoxTaskID.Items.Clear();
                this.comboBoxTaskName.Items.Clear();
                for (int i = 0; i < mTaskInfo.GetLength(0); i++)
                {
                    this.comboBoxTaskID.Items.Add(mTaskInfo[i, 0].oContent.ToString());
                    this.comboBoxTaskName.Items.Add(mTaskInfo[i, 1].oContent.ToString());
                }
                this.comboBoxTaskID.Text = this.questID;
                this.comboBoxTaskName.Text = this.content;
                this.comboBoxTaskID.Tag = mTaskInfo;
                this.comboBoxTaskName.Tag = mTaskInfo;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.buttonOK.Text == config.ReadConfigValue("MFj", "FMI_UI_buttonOK"))
            {
                if (MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Modify_Info"), config.ReadConfigValue("MFj", "FM_Code_Modify_Title"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];


                    mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = this.serverIP;

                    mContent[1].eName = CEnum.TagName.FJ_UserNick;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = this.nickName;

                    mContent[2].eName = CEnum.TagName.FJ_Quest_id;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = this.questID;

                    mContent[3].eName = CEnum.TagName.FJ_Quest_state;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = this.comboBoxState.SelectedIndex.ToString();

                    mContent[4].eName = CEnum.TagName.UserByID;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    CEnum.Message_Body[,] result = Operation_FJ.GetResult(m_ClientEvent, CEnum.ServiceKey.FJ_Task_Update, mContent);

                    if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                        return;
                    }

                    if (result[0, 0].oContent.ToString() == "SUCESS")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg2"));
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg3"));
                        return;
                    }
                }
            }
            else if (this.buttonOK.Text == config.ReadConfigValue("MFj", "FMI_UI_buttonOK1"))
            {
                if (MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_ADD_Info"), config.ReadConfigValue("MFj", "FM_Code_ADD_Title"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];


                    mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = this.serverIP;

                    mContent[1].eName = CEnum.TagName.FJ_UserNick;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = this.nickName;

                    mContent[2].eName = CEnum.TagName.FJ_Quest_id;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = mTaskInfo[this.comboBoxTaskName.SelectedIndex,0].oContent.ToString();

                    mContent[3].eName = CEnum.TagName.FJ_Quest_state;
                    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[3].oContent = this.comboBoxState.SelectedIndex.ToString();

                    mContent[4].eName = CEnum.TagName.UserByID;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    CEnum.Message_Body[,] result = Operation_FJ.GetResult(m_ClientEvent, CEnum.ServiceKey.FJ_Task_Insert, mContent);

                    if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                        return;
                    }

                    if (result[0, 0].oContent.ToString() == "SUCESS")
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg6"));
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                        return;
                    }
                    this.buttonOK.Text = config.ReadConfigValue("MFj", "FMI_UI_buttonOK");
                    this.comboBoxTaskID.Enabled = false;
                    this.comboBoxTaskName.Enabled = false;
                    this.comboBoxTaskID.Text = this.questID;
                    this.comboBoxTaskName.Text = this.content;
                }
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.buttonOK.Text = config.ReadConfigValue("MFj", "FMI_UI_buttonOK1");
            this.comboBoxTaskID.Enabled = true;
            this.comboBoxTaskName.Enabled = true;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Del_Info"), config.ReadConfigValue("MFj", "FM_Code_Del_Title"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];


                mContent[0].eName = CEnum.TagName.FJ_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = this.serverIP;

                mContent[1].eName = CEnum.TagName.FJ_UserNick;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = this.nickName;

                mContent[2].eName = CEnum.TagName.FJ_Quest_id;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.questID;

                mContent[3].eName = CEnum.TagName.UserByID;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                CEnum.Message_Body[,] result = Operation_FJ.GetResult(m_ClientEvent, CEnum.ServiceKey.FJ_Task_Delete, mContent);

                if (result[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg1"));
                    return;
                }

                if (result[0, 0].oContent.ToString() == "SUCESS")
                {
                    MessageBox.Show(config.ReadConfigValue("MFj", "FM_Code_Msg4"));
                    this.Close();
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