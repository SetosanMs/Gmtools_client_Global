using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using C_Global;
using C_Event;

namespace M_SOCCER
{
    [C_Global.CModuleAttribute("��ͣ��ɫ��Ϣ", "FrmBanCharacters", "��������", "soccer")]
    public partial class FrmBanCharacters : Form
    {
        public FrmBanCharacters()
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
        C_Global.CEnum.Message_Body[,] UnaccountResult = null;   //�ʺż������
        string currUserAccount = null;      
        int currSelectPSTID = 0; //���޸ĵ����id
      
        bool blChkAccount = false;
        bool blChkNick = false;
        string _ServerIP = null;    //������ip
        DataTable dgTable = new DataTable();
        private bool bFirst = false;

        #endregion

        /// <summary>
        /// �ʺŲ�ѯ����ʽʧЧ
        /// </summary>
        private void DisableAccountSearch()
        {
            txtAccount.Clear();
            txtAccount.Enabled = false;
            chkAccount.Checked = false;
        }

        /// <summary>
        /// �ǳƲ�ѯ����ʽʧЧ
        /// </summary>
        private void DisableNickSearch()
        {
            txtAccount.Clear();
            txtAccount.Enabled = false;
            chkNick.Checked = false;
        }

        /// <summary>
        /// ���á��ʺŲ�ѯ��ʽ
        /// </summary>
        private void EnableAccountSearch()
        {
            lblIDOrNick.Text = "����ʺţ�";
            chkAccount.Checked = true;
            chkNick.Checked = false;
            //chkAllPlayer.Checked = false;
            txtAccount.Enabled = true;
        }

        /// <summary>
        /// ���á��ǳƲ�ѯ
        /// </summary>
        private void EnableNickSearch()
        {
            lblIDOrNick.Text = "��ҽ�ɫ����";
            chkAccount.Checked = false;
            chkNick.Checked = true;
            //chkAllPlayer.Checked = false;
            txtAccount.Enabled = true;
        }

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
                messageBody[0].oContent = m_ClientEvent.GetInfo("GameID_Soccer");

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

        private void FrmBanCharacters_Load(object sender, EventArgs e)
        {
            InitializeServerIP();
            dpNoteText.Visible = false;     //������Ϣ��ʾ
            dpModi.Visible = false;         //������Ϣ�޸�
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!chkAccount.Checked && !chkNick.Checked)
            {
                MessageBox.Show("��ѡ��һ�ֲ�ѯ��ʽ");
                return;
            }
            if (checkStauas.Checked == false)
            {
                BanAccounts();
            }

            #region IP����


            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion

            //dpDGAccountInfo.Visible = false;    //����datagrid����
            //dpNoteText.Visible = false;         //������Ϣ��ʾ
            //dgAccountInfo.DataSource = null;    //����datagridΪ��

            blChkAccount = chkAccount.Checked;  //��ʾ�Ƿ�ѡ���ʺ�
            blChkNick = chkNick.Checked;        //��ʾ�Ƿ�ѡ���ǳ�
        }

        //private void ReadFromAccount()
        //{
        //    currUserAccount = txtAccount.Text.ToString();

        //    C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[3];
        //    messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
        //    messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
        //    messageBody[0].oContent = _ServerIP;

        //    messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
        //    messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
        //    messageBody[1].oContent = currUserAccount;


        //    messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
        //    messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
        //    messageBody[2].oContent = GetCRAction();

        //    accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERINFO_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

        //    if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
        //    {
        //        MessageBox.Show(accountResult[0, 0].oContent.ToString());
        //        return;
        //    }

        //    dgAccountInfo.DataSource = BrowseResultInfo();      //����datagrid����Դ


        //    //dpDataGrid.Visible = true;                          //��ʾdatagrid����
        //    dpNoteText.Visible = true;                          //��ʾ�ı���ʾ
        //}

        private void BanAccounts()
        {

            if (txtAccount.Text == null || txtAccount.Text == "")
            {
                MessageBox.Show("������Ҫ��ͣ����ʺ�");
                return;
            }
            #region IP����


            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion
            currUserAccount = txtAccount.Text.ToString();

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            messageBody[0].oContent = _ServerIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
            messageBody[1].oContent = currUserAccount;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
            messageBody[2].oContent = GetCRAction();

            messageBody[3].eName = CEnum.TagName.Index;
            messageBody[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            messageBody[3].oContent = 1;

            messageBody[4].eName = CEnum.TagName.PageSize;
            messageBody[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            messageBody[4].oContent = Operation_Soccer.iPageSize;

            messageBody[5].eName = CEnum.TagName.Soccer_deleted_date;
            messageBody[5].eTag = CEnum.TagFormat.TLV_STRING;
            messageBody[5].oContent = "";

            accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERSTATE_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);

            if (accountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(accountResult[0, 0].oContent.ToString());
                return;
            }
            dgAccountInfo.DataSource = null;
            dgAccountInfo.DataSource = BrowseResultInfo();
            dpNoteText.Visible = true;                          //��ʾ�ı���ʾ
        }
        private string GetCRAction()
        {
            string returnValue = "";
            if (chkAccount.Checked)
                returnValue = "uID";
            if (chkNick.Checked)
                returnValue = "cName";
            return returnValue;
        }

        private DataTable BrowseResultInfo()
        {
            
            try
            {
                dgTable = new DataTable();
                dgTable.Columns.Add("ID", typeof(string));
                dgTable.Columns.Add("�ʺ�", typeof(string));
                dgTable.Columns.Add("��ɫ��", typeof(string));

                dgTable.Columns.Add("�Ա�", typeof(string));
                dgTable.Columns.Add("��������", typeof(string));



                for (int i = 0; i < accountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow["ID"] = accountResult[i, 1].oContent.ToString();
                    dgRow["�ʺ�"] = accountResult[i, 0].oContent.ToString();
                    dgRow["��ɫ��"] = accountResult[i, 2].oContent.ToString();
                    dgRow["�Ա�"] = accountResult[i, 3].oContent.ToString() == "F" ? "Ů" : "��";
                    dgRow["��������"] = accountResult[i, 4].oContent.ToString();

                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        private void UnBanAccounts()
        {
            #region IP����


            for (int i = 0; i < this.serverIPResult.GetLength(0); i++)
            {
                if (serverIPResult[i, 1].oContent.ToString().Trim().Equals(this.cbxServerIP.Text.Trim()))
                {
                    this._ServerIP = serverIPResult[i, 0].oContent.ToString();
                }
            }
            #endregion
            //currUserAccount = this.txtAccount.Text.Trim();

            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];
            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            messageBody[0].oContent = _ServerIP;

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
            messageBody[1].oContent = this.txtAccount.Text;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
            messageBody[2].oContent = GetCRAction();

            messageBody[3].eName = CEnum.TagName.Index;
            messageBody[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            messageBody[3].oContent = 1;

            messageBody[4].eName = CEnum.TagName.PageSize;
            messageBody[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            messageBody[4].oContent = Operation_Soccer.iPageSize;

            messageBody[5].eName = CEnum.TagName.Soccer_deleted_date;
            messageBody[5].eTag = CEnum.TagFormat.TLV_STRING;
            messageBody[5].oContent = "gmtools";

            UnaccountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERSTATE_QUERY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);
            if (UnaccountResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(UnaccountResult[0, 0].oContent.ToString());
                return;
            }
            dgAccountInfo.DataSource = null;
            dgAccountInfo.DataSource = ResultInfo();      //����datagrid����Դ
            CmbPage.Items.Clear();
            int pageCount = int.Parse(UnaccountResult[0, 6].oContent.ToString());
            if (pageCount <= 0)
            {
                DivPage.Visible = false;
            }
            else
            {
                for (int i = 0; i < pageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }

                CmbPage.SelectedIndex = 0;
                bFirst = true;
                DivPage.Visible = true;
                dpNoteText.Visible = true;  
            }
            
        }
        private DataTable ResultInfo()
        {
            try
            {
                dgTable = new DataTable();
                dgTable.Columns.Add("ID", typeof(string));
                dgTable.Columns.Add("�ʺ�", typeof(string));
                dgTable.Columns.Add("��ɫ��", typeof(string));

                dgTable.Columns.Add("�Ա�", typeof(string));
                dgTable.Columns.Add("��������", typeof(string));
                dgTable.Columns.Add("��ͣ����", typeof(string));

                for (int i = 0; i < UnaccountResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow["ID"] = UnaccountResult[i, 1].oContent.ToString();
                    dgRow["�ʺ�"] = UnaccountResult[i, 0].oContent.ToString();
                    dgRow["��ɫ��"] = UnaccountResult[i, 2].oContent.ToString();
                    dgRow["�Ա�"] = UnaccountResult[i, 3].oContent.ToString() == "F" ? "Ů" : "��";
                    dgRow["��������"] = UnaccountResult[i, 4].oContent.ToString();
                    dgRow["��ͣ����"] = UnaccountResult[i, 5].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }
        private string Returnpostion(string postion)
        {
            string StrPostion = "";
            switch (postion)
            {
                case "0":
                    StrPostion = "�г�";
                    break;
                case "1":
                    StrPostion = "�Ž�";
                    break;
                case "2":
                    StrPostion = "ǰ��";
                    break;
                case "3":
                    StrPostion = "����";
                    break;
                default:
                    StrPostion = "����";
                    break;
            }
            return StrPostion;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //dpDataGrid.Visible = false;     //����datagrid���� 
            dpNoteText.Visible = false;     //������Ϣ��ʾ
            dpModi.Visible = false;         //������Ϣ�޸�
            dgAccountInfo.DataSource = null;
            txtAccount.Clear();
        }

        private void btnModiApply_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            dpNoteText.Visible = false;     //������Ϣ��ʾ
            dpModi.Visible = false;         //������Ϣ�޸�
            DivPage.Visible = false;        //���ط�ҳ��ʾ
            dgAccountInfo.DataSource = null;
            txtAccount.Clear();
            btnSearch.Visible = true;
            btnbanQuary.Visible = false;
            btnbanAccount.Visible = true;
            btnUnbanAccount.Visible = false;
        }


        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {


                C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[6];
                messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[0].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
                messageBody[0].oContent = _ServerIP;

                messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[1].eName = C_Global.CEnum.TagName.Soccer_String;
                messageBody[1].oContent = this.txtAccount.Text;

                messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                messageBody[2].eName = C_Global.CEnum.TagName.Soccer_Type;
                messageBody[2].oContent = GetCRAction();

                messageBody[3].eName = CEnum.TagName.Index;
                messageBody[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[3].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Soccer.iPageSize + 1;

                messageBody[4].eName = CEnum.TagName.PageSize;
                messageBody[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                messageBody[4].oContent = Operation_Soccer.iPageSize;

                messageBody[5].eName = CEnum.TagName.Soccer_deleted_date;
                messageBody[5].eTag = CEnum.TagFormat.TLV_STRING;
                messageBody[5].oContent = "gmtools";


                CEnum.Message_Body[,] mResult = null;
                mResult = Operation_Soccer.GetResult(this.m_ClientEvent, CEnum.ServiceKey.SOCCER_CHARACTERSTATE_QUERY, messageBody);

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                dgAccountInfo.DataSource = null;
                dgAccountInfo.DataSource = ReturnPageResult(mResult);

            
            }
        }
        private DataTable ReturnPageResult(CEnum.Message_Body[,] PageResult)
        {
            try
            {
                dgTable = new DataTable();
                dgTable.Columns.Add("ID", typeof(string));
                dgTable.Columns.Add("�ʺ�", typeof(string));
                dgTable.Columns.Add("��ɫ��", typeof(string));

                dgTable.Columns.Add("�Ա�", typeof(string));
                dgTable.Columns.Add("��������", typeof(string));
                dgTable.Columns.Add("��ͣ����", typeof(string));

                for (int i = 0; i < PageResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();

                    //currSelectPSTID = int.Parse(accountResult[i, 2].oContent.ToString());
                    dgRow["ID"] = PageResult[i, 1].oContent.ToString();
                    dgRow["�ʺ�"] = PageResult[i, 0].oContent.ToString();
                    dgRow["��ɫ��"] = PageResult[i, 2].oContent.ToString();
                    dgRow["�Ա�"] = PageResult[i, 3].oContent.ToString() == "F" ? "Ů" : "��";
                    dgRow["��������"] = PageResult[i, 4].oContent.ToString();
                    dgRow["��ͣ����"] = PageResult[i, 5].oContent.ToString();
                    dgTable.Rows.Add(dgRow);
                }

            }
            catch
            {
            }
            return dgTable;
        }

        private void chkNick_Click_1(object sender, EventArgs e)
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

        private void chkAccount_Click_1(object sender, EventArgs e)
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

        private void btnbanQuary_Click(object sender, EventArgs e)
        {
            UnBanAccounts();
        }

        private void checkStauas_Click_1(object sender, EventArgs e)
        {
            if (checkStauas.Checked)
            {
                btnSearch.Visible = false;
                btnbanQuary.Visible = true;
                btnbanAccount.Visible = false;
                btnUnbanAccount.Visible = true;

                dpNoteText.Visible = false;     //������Ϣ��ʾ
                dpModi.Visible = false;         //������Ϣ�޸�
                DivPage.Visible = false;        //���ط�ҳ��ʾ
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();


            }
            else
            {
                btnSearch.Visible = true;
                btnbanQuary.Visible = false;
                btnbanAccount.Visible = true;
                btnUnbanAccount.Visible = false;

                dpNoteText.Visible = false;     //������Ϣ��ʾ
                dpModi.Visible = false;         //������Ϣ�޸�
                DivPage.Visible = false;        //���ط�ҳ��ʾ
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();

            }
        }

        private void dgAccountInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //��ǰ�û�
                currSelectPSTID = int.Parse(dgTable.Rows[e.RowIndex]["ID"].ToString());
                txtPlayerID.Text = dgTable.Rows[e.RowIndex]["�ʺ�"].ToString();
                TxtCharname.Text = dgTable.Rows[e.RowIndex]["��ɫ��"].ToString();

                //��ʾ�޸�����
                dpModi.Visible = true;
            }
            catch
            {
            }
        }

        private void btnUnbanAccount_Click(object sender, EventArgs e)
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            messageBody[1].oContent = _ServerIP;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[2].eName = C_Global.CEnum.TagName.Soccer_charidx;
            messageBody[2].oContent = currSelectPSTID;

            messageBody[3].eName = CEnum.TagName.Soccer_deleted_date;
            messageBody[3].eTag = CEnum.TagFormat.TLV_STRING;
            messageBody[3].oContent = "";

            C_Global.CEnum.Message_Body[,] modiResult = null;
            modiResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERSTATE_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);
            if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show("������" + txtPlayerID.Text + "�ʺųɹ�");

                dpNoteText.Visible = false;     //������Ϣ��ʾ
                dpModi.Visible = false;         //������Ϣ�޸�
                DivPage.Visible = false;        //���ط�ҳ��ʾ
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();

            }

            if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(modiResult[0, 0].oContent.ToString());
                dpNoteText.Visible = false;     //������Ϣ��ʾ
                dpModi.Visible = false;         //������Ϣ�޸�
                DivPage.Visible = false;        //���ط�ҳ��ʾ
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();
                return;
            }
        }

        private void btnbanAccount_Click(object sender, EventArgs e)
        {
            C_Global.CEnum.Message_Body[] messageBody = new C_Global.CEnum.Message_Body[4];

            messageBody[0].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[0].eName = C_Global.CEnum.TagName.UserByID;
            messageBody[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            messageBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
            messageBody[1].eName = C_Global.CEnum.TagName.Soccer_ServerIP;
            messageBody[1].oContent = _ServerIP;

            messageBody[2].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
            messageBody[2].eName = C_Global.CEnum.TagName.Soccer_charidx;
            messageBody[2].oContent = currSelectPSTID;

            messageBody[3].eName = CEnum.TagName.Soccer_deleted_date;
            messageBody[3].eTag = CEnum.TagFormat.TLV_STRING;
            messageBody[3].oContent = "gmtools";

            C_Global.CEnum.Message_Body[,] modiResult = null;
            modiResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.SOCCER_CHARACTERSTATE_MODIFY, C_Global.CEnum.Msg_Category.SOCCER_ADMIN, messageBody);
            if (modiResult[0, 0].oContent.ToString().Equals("SUCESS"))
            {
                MessageBox.Show("��ͣ���" + txtPlayerID.Text + "�ʺųɹ�");

                dpNoteText.Visible = false;     //������Ϣ��ʾ
                dpModi.Visible = false;         //������Ϣ�޸�
                DivPage.Visible = false;        //���ط�ҳ��ʾ
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();

            }

            if (modiResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(modiResult[0, 0].oContent.ToString());
                dpNoteText.Visible = false;     //������Ϣ��ʾ
                dpModi.Visible = false;         //������Ϣ�޸�
                DivPage.Visible = false;        //���ط�ҳ��ʾ
                dgAccountInfo.DataSource = null;
                txtAccount.Clear();
                return;
            }
        }

        private void btnModiCancel_Click_1(object sender, EventArgs e)
        {
            dpNoteText.Visible = false;     //������Ϣ��ʾ
            dpModi.Visible = false;         //������Ϣ�޸�
            txtPlayerID.Clear();
            TxtCharname.Clear();
            btnSearch.Visible = true;
            btnbanQuary.Visible = false;
            btnbanAccount.Visible = true;
            btnUnbanAccount.Visible = false;
        }



    }
}
