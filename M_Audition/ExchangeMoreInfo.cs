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

namespace M_Audition
{
    public partial class ExchangeMoreInfo : Form
    {
        private int iPageCount = 0;
        public ExchangeMoreInfo()
        {
            InitializeComponent();
        }



        public ExchangeMoreInfo(string sss,CEnum.Message_Body[,] val, CSocketEvent m_ClientEvent)
        {
            ConfigValue config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            this.Text = config.ReadConfigValue("MAUDITION", "EMI_UI_ExchangeMoreInfo");
            InitializeComponent();

            LblUser.Text = config.ReadConfigValue("MAUDITION", "EMI_Code_LblUser").Replace("{user}",sss);
            //LblUser.Text = "玩家 " + sss + " 的兑换记录详细信息：";

            Operation_Shop.BuildDataTable(m_ClientEvent, val, GrdInfo, out iPageCount);
        }

    }
}