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

namespace M_CrazyRace
{
    [C_Global.CModuleAttribute("��ҽ�ɫ��Ϣ", "FrmQueryPlayerID", "��ҽ�ɫ��Ϣ", "���쮳�")]        
    public partial class FrmQueryPlayerID : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;

        public FrmQueryPlayerID()
        {
            InitializeComponent();
        }

        #region �Զ�������¼�
        /// <summary>
        /// ��������еĴ���
        /// </summary>
        /// <param name="oParent">MDI ����ĸ�����</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>����еĴ���</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //������¼����
            FrmQueryPlayerID mModuleFrm = new FrmQueryPlayerID();
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

        #region ���Կ�
        /// <summary>
        ///�����ֿ�
        /// </summary>
        ConfigValue config = null;

        /// <summary>
        /// ��ʼ�����������Կ�
        /// </summary>
        private void IntiFontLib()
        {
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            IntiUI();
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MCs", "FQP_UI_Text");

        }


        #endregion

        private void FrmQueryPlayerID_Load(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}