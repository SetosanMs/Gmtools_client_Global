using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C_Global;
using C_Event;

namespace M_CR
{
    [C_Global.CModuleAttribute("��ҵ�½ʱ���ѯ", "FrmPlayerLoginTime", "��񿨶���--ʱ���ѯ", "CR")]
    public partial class FrmPlayerLoginTime : Form
    {
        public FrmPlayerLoginTime()
        {
            InitializeComponent();
        }
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

        C_Global.CEnum.Message_Body[,] serverIPResult = null;   //ip�б���Ϣ
        C_Global.CEnum.Message_Body[,] accountResult = null;   //�ʺż������

        string _ServerIP = null;    //������ip
        DataTable dgTable = new DataTable();
        #endregion

        #region �Զ��庯��


        /// <summary>
        /// �ʺŲ�ѯ����ʽʧЧ
        /// </summary>
        private void DisableAccountSearch()
        {
            txtAccount.Clear();
            txtAccount.Enabled = false;
            chkAccount.Checked = false;
            txtAccount.Focus();
        }

        /// <summary>
        /// �ǳƲ�ѯ����ʽʧЧ
        /// </summary>
        private void DisableNickSearch()
        {
            txtAccount.Clear();
            txtAccount.Enabled = false;
            chkNick.Checked = false;
            txtAccount.Focus();
        }

        /// <summary>
        /// ���á��ʺŲ�ѯ��ʽ
        /// </summary>
        private void EnableAccountSearch()
        {
            lblIDOrNick.Text = "����ʺ�:";
            chkAccount.Checked = true;
            chkNick.Checked = false;
            chkAllPlayer.Checked = false;
            txtAccount.Enabled = true;
            txtAccount.Focus();
        }

        /// <summary>
        /// ���á��ǳƲ�ѯ
        /// </summary>
        private void EnableNickSearch()
        {
            lblIDOrNick.Text = "����ǳ�:";
            chkAccount.Checked = false;
            chkNick.Checked = true;
            chkAllPlayer.Checked = false;
            txtAccount.Enabled = true;
            txtAccount.Focus();
        }

        #endregion

       

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
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_CR");

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[1].eName = C_Global.CEnum.TagName.ServerInfo_GameDBID;
                messageBody[1].oContent = 2;

                serverIPResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SERVERINFO_IP_QUERY, C_Global.CEnum.Msg_Category.COMMON, messageBody);

                //���״̬

                if (serverIPResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(serverIPResult[0, 0].oContent.ToString());
                    //Application.Exit();
                    return;
                }

                //��ʾ���ݵ��б�

                for (int i = 0; i < serverIPResult.GetLength(0); i++)
                {
                    this.cbxServerIP.Items.Add(serverIPResult[i, 1].oContent.ToString());
                }

                this.cbxServerIP.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmPlayerLoginTime_Load(object sender, EventArgs e)
        {
            EnableAccountSearch();              //�ʺŲ�ѯ����
            InitializeServerIP();               //��ʼ�����ݿ��б�
            dpDGAccountInfo.Visible = false;    //����datagrid����
            txtAccount.Focus();

        }
        /// <summary>
        /// ���ز�����š�
        /// 1  �ʺŲ�ѯ
        /// 2  �ǳƲ�ѯ
        /// 3  �������
        /// 4  δ�������
        /// </summary>
        /// <returns></returns>
        private int GetCRAction()
        {
            int returnValue = 0;
            if (chkAccount.Checked)
                returnValue = 1;
            if (chkNick.Checked)
                returnValue = 2;
            if (chkAllPlayer.Checked)
                returnValue = 3;

            return returnValue;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region ����
            if (!chkAccount.Checked && !chkNick.Checked && !chkAllPlayer.Checked)
            {
                MessageBox.Show("��ѡ��һ�ֲ�ѯ��ʽ");
                return;
            }
            if (cbxServerIP.Text == null || cbxServerIP.Text == "")
            {
                MessageBox.Show("��ѡ�������");
                return;
            }
            if ((chkAccount.Checked || chkNick.Checked) && (txtAccount.Text == null || txtAccount.Text == ""))
            {
                if (chkNick.Checked)
                {
                    MessageBox.Show("����������ǳ�");
                    return;
                }
                if (chkAccount.Checked)
                {
                    MessageBox.Show("����������ʺ�");
                    return;
                }
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

            dpDGAccountInfo.Visible = false;    //����datagrid����
            dgAccountInfo.DataSource = null;    //����datagridΪ��
            ReadFromAccount();                  //��ѯ��Ϣ
            txtAccount.Clear();
            txtAccount.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAccount.Clear();
            EnableAccountSearch();
            dpDGAccountInfo.Visible = false;    //����datagrid����
            dgAccountInfo.DataSource = null;    //����datagridΪ��
            txtAccount.Focus();
        }

        /// <summary>
        /// ��ȡ�ʺż�¼
        /// </summary>
        private void ReadFromAccount()
        {
            try
            {
                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.CR_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.CR_UserID;
                messageBody[1].oContent = chkAccount.Checked ? txtAccount.Text.Trim() : "";

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.CR_NickName;
                messageBody[2].oContent = chkNick.Checked ? txtAccount.Text.Trim() : "";

                messageBody[3].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].eName = C_Global.CEnum.TagName.CR_ACTION;
                messageBody[3].oContent = GetCRAction();

                accountResult = m_ClientEvent.GetSocket(m_ClientEvent, _ServerIP).RequestResult(C_Global.CEnum.ServiceKey.CR_LOGIN_LOGOUT_QUERY, C_Global.CEnum.Msg_Category.CR_ADMIN, messageBody);

                if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(accountResult[0, 0].oContent.ToString());
                    return;
                }

                if (accountResult[0, 0].oContent.ToString().Equals("0"))
                {
                    MessageBox.Show("û���ҵ�ƥ���¼");
                    return;
                }

                dpDGAccountInfo.Visible = true;                 //��ʾdatagrid����
                dgAccountInfo.DataSource = BrowseResultInfo();  //����datagrid��ϢԴ

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ����������תװ��DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BrowseResultInfo()
        {
            try
            {
                dgTable = new DataTable();
                    //dgTable.Columns.Clear();                            //���ͷ��Ϣ
                    //dgTable.Rows.Clear();                              //����м�¼

                    dgTable.Columns.Add("����ʺ�", typeof(string));
                    dgTable.Columns.Add("����ǳ�", typeof(string));
                    dgTable.Columns.Add("��½ʱ��", typeof(string));
                    dgTable.Columns.Add("�ǳ�ʱ��", typeof(string));
                    dgTable.Columns.Add("�����Ϸʱ��", typeof(string));
                    dgTable.Columns.Add("ƽ����Ϸʱ��", typeof(string));

                    for (int i = 0; i < accountResult.GetLength(0); i++)
                    {
                        DataRow dgRow = dgTable.NewRow();
                        dgRow["����ʺ�"] = accountResult[i, 0].oContent.ToString();
                        dgRow["����ǳ�"] = accountResult[i, 1].oContent.ToString();
                        dgRow["��½ʱ��"] = accountResult[i, 2].oContent.ToString();
                        dgRow["�ǳ�ʱ��"] = accountResult[i, 3].oContent.ToString();
                        dgRow["�����Ϸʱ��"] = transHour(int.Parse(accountResult[i, 4].oContent.ToString()));
                        dgRow["ƽ����Ϸʱ��"] = transHour(int.Parse(accountResult[i, 5].oContent.ToString()));
                        dgTable.Rows.Add(dgRow);
                    }

                
                return dgTable;
            }
            catch
            {
                DataTable ds = new DataTable();

                ds.Columns.Add("����ʺ�", typeof(string));
                ds.Columns.Add("����ǳ�", typeof(string));
                ds.Columns.Add("��½ʱ��", typeof(string));
                ds.Columns.Add("�ǳ�ʱ��", typeof(string));
                ds.Columns.Add("�����Ϸʱ��", typeof(string));
                ds.Columns.Add("ƽ����Ϸʱ��", typeof(string));

                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = ds.NewRow();
                    dgRow["����ʺ�"] = accountResult[i, 0].oContent.ToString();
                    dgRow["����ǳ�"] = accountResult[i, 1].oContent.ToString();
                    dgRow["��½ʱ��"] = accountResult[i, 2].oContent.ToString();
                    dgRow["�ǳ�ʱ��"] = accountResult[i, 3].oContent.ToString();
                    dgRow["�����Ϸʱ��"] = transHour(int.Parse(accountResult[i, 4].oContent.ToString()));
                    dgRow["ƽ����Ϸʱ��"] = transHour(int.Parse(accountResult[i, 5].oContent.ToString()));
                    ds.Rows.Add(dgRow);
                }
                return ds;
            }
            
        }

        private void chkNick_Click(object sender, EventArgs e)
        {
            if (chkNick.Checked)
            {
                EnableNickSearch();
            }
            else
            {
                DisableNickSearch();
            }
        }

        private void chkAccount_Click(object sender, EventArgs e)
        {
            if (chkAccount.Checked)
            {
                EnableAccountSearch();
            }
            else
            {
                DisableAccountSearch();
            }
        }

        private void chkAllPlayer_Click(object sender, EventArgs e)
        {
            DisableAccountSearch();
            DisableNickSearch();
        }
        private string transHour(int num)
        {
            string strtime = null;
            int inthour;
            int intmin;
            int intsec;
            inthour = num / 3600;
            intmin = num % 3600 / 60;
            intsec = num % 3600 % 60;

            strtime = inthour.ToString() + "Сʱ" + intmin.ToString() + "��" + intsec.ToString() + "��";
            return strtime;
        }

        private void FrmPlayerLoginTime_Activated(object sender, EventArgs e)
        {
            this.txtAccount.Focus();
        }
    }
}