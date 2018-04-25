using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Global;
using C_Event;
using C_Controls.LabelTextBox;

using Language;

namespace M_Audition
{
    public partial class UserstatFrm : Form
    {
        public UserstatFrm()
        {
            InitializeComponent();
        }

        public UserstatFrm(CEnum.Message_Body[,] val, CSocketEvent m_ClientEvent)
        {
            
            InitializeComponent();
            ConfigValue config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            this.Text = config.ReadConfigValue("MAUDITION", "UF_UI_UserstatFrm");
            PnlDetail.Controls.Clear();

            for (int i = 0; i < val.GetLength(1); i++)
            {
                LabelTextBox mDisplay = new LabelTextBox();
                mDisplay.Parent = PnlDetail;
                mDisplay.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;
                mDisplay.Width = 222;

                mDisplay.Top = 20 * i + 30;
                mDisplay.Left = 44;

                mDisplay.LabelText = config.ReadConfigValue("GLOBAL", val[0, i].eName.ToString()) + "��";
                //mDisplay.LabelText = m_ClientEvent.DecodeFieldName(val[0, i].eName) + "��";
                mDisplay.TextBoxText = val[0, i].oContent.ToString();
            }
        }

        private void UserstatFrm_Load(object sender, EventArgs e)
        {
            

            //
        }
    }
}