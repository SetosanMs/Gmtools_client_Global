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

namespace M_AU
{
    public partial class SendReasion : Form
    {
        SendAboutInfo about = null;
        private CSocketEvent m_ClientEvent = null;
        public bool canceled = false;
        public SendReasion()
        {
            InitializeComponent();
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
            
            this.label1.Text = config.ReadConfigValue("MAU", "SR_UI_label1");
            this.label2.Text = config.ReadConfigValue("MAU", "SR_UI_label2");
            this.button1.Text = config.ReadConfigValue("MAU", "SR_UI_button1");
            this.cbxExpire.Items.AddRange(new object[] { config.ReadConfigValue("MAU", "SR_Code_30day"), 
                config.ReadConfigValue("MAU", "SR_Code_90day") });
            
        }


        #endregion

        public SendReasion(SendAboutInfo about,C_Event.CSocketEvent mEvent)
        {
            this.about = about;
            this.m_ClientEvent = mEvent;
            InitializeComponent();
        }

        private void SendReasion_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbxExpire.Text == null || cbxExpire.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "SR_Code_Msg"));
                return;
            }

            about.REASON = (this.txtReason.Text == "" || txtReason.Text == null) ? "" : txtReason.Text.ToString();

            //switch (cbxExpire.Text)
            //{
            //    case "1个月":
            //        about.EXPIRE = 30;
            //        break;
            //    case "3个月":
            //        about.EXPIRE = 90;
            //        break;
            //    default:
            //        about.EXPIRE = 30;
            //        break;
            //}
            if (cbxExpire.Text == config.ReadConfigValue("MAU", "SR_Code_30day"))
                about.EXPIRE = 30;
            else if (cbxExpire.Text == config.ReadConfigValue("MAU", "SR_Code_90day"))
                about.EXPIRE = 90;
            else about.EXPIRE = 30;

            this.Close();

            this.canceled = false;

        }

        private void SendReasion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.canceled = true;
        }

    }
}