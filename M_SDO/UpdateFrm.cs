using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using C_Controls.LabelTextBox;
using C_Global;
using C_Event;
using Language;
namespace M_SDO
{
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("SDO��ҵ��߹���", "Frm_SDO_Update", "SDO������ -- ��ҵ��߹���", "SDO Group")]   
    public partial class Frm_SDO_Update : Form
    {
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        DataTable mSelectTable = null;
        string strSelect = null;
        int iOutPage = 0;

        private bool bItemFirst = false;
        private bool bGiftFirst = false;
        private int iPageCount = 0;
        private int iSex = 0;
        private int iUserIndexID = 0;
        private int iItemIndex = 0;
        private int iType = 0;
        private int iSort = 0;
        private int iSelectIndex = 0;
        private int iEditCount = 0;
        private DataTable mItemTable = null;
        private int iIndex = -1;

        private CEnum.Message_Body[,] mServerInfo = null;
        private CEnum.Message_Body[,] mGetResult = null;
        private CEnum.Message_Body[,] mItemInfo = null;
        private CEnum.Message_Body[,] mGiftResult = null;

        public Frm_SDO_Update()
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
            Frm_SDO_Update mModuleFrm = new Frm_SDO_Update();
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
            this.Text = config.ReadConfigValue("MSDO", "IC_UI_SdoUpdate");
            this.GrpSearch.Text = config.ReadConfigValue("MSDO", "IC_UI_GrpSearch");
            this.LblServer.Text = config.ReadConfigValue("MSDO", "IC_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MSDO", "IC_UI_LblAccount");
            this.BtnSearch.Text = config.ReadConfigValue("MSDO", "IC_UI_BtnSearch");
            this.BtnClose.Text = config.ReadConfigValue("MSDO", "IC_UI_BtnClose");
            this.TpgCharacter.Text = config.ReadConfigValue("MSDO", "IC_UI_TpgCharacter");
            this.TpgGift.Text = config.ReadConfigValue("MSDO", "IC_UI_TpgGift");
            this.TbpGift.Text = config.ReadConfigValue("MSDO", "IC_UI_TbpGift");
            this.TpgAddGift.Text = config.ReadConfigValue("MSDO", "IC_UI_TpgAddGift");
            this.LblItemPage.Text = config.ReadConfigValue("MSDO", "IC_UI_LblItemPage");
            this.button2.Text = config.ReadConfigValue("MSDO", "IC_UI_button2");
            this.LblGiftPage.Text = config.ReadConfigValue("MSDO", "IC_UI_LblGiftPage");
            this.groupBox1.Text = config.ReadConfigValue("MSDO", "IC_UI_groupBox1");
            this.LblType.Text = config.ReadConfigValue("MSDO", "IC_UI_LblType");
            this.LblSort.Text = config.ReadConfigValue("MSDO", "IC_UI_LblSort");
            this.LblItem.Text = config.ReadConfigValue("MSDO", "IC_UI_LblItem");

            this.groupBox2.Text = config.ReadConfigValue("MSDO", "IC_UI_groupBox2");
            this.label2.Text = config.ReadConfigValue("MSDO", "IC_UI_label2");
            this.button1.Text = config.ReadConfigValue("MSDO", "IC_UI_button1");
            this.groupBox3.Text = config.ReadConfigValue("MSDO", "IC_UI_groupBox3");
            this.LblDate.Text = config.ReadConfigValue("MSDO", "IC_UI_LblDate");
            this.LblCount.Text = config.ReadConfigValue("MSDO", "IC_UI_LblCount");
            this.LblTitle.Text = config.ReadConfigValue("MSDO", "IC_UI_LblTitle");
            this.LblMemo.Text = config.ReadConfigValue("MSDO", "IC_UI_LblMemo");
            this.radioButton1.Text = config.ReadConfigValue("MSDO", "IC_UI_radioButton1");
            this.radioButton2.Text = config.ReadConfigValue("MSDO", "IC_UI_radioButton2");
            this.BtnAdd.Text = config.ReadConfigValue("MSDO", "IC_UI_BtnAdd");
            this.BtnClear.Text = config.ReadConfigValue("MSDO", "IC_UI_BtnClear");
            this.LblAddUser.Text = config.ReadConfigValue("MSDO", "IC_UI_LblAddUser");
            this.label1.Text = config.ReadConfigValue("MSDO", "IC_UI_label1");
            this.label3.Text = config.ReadConfigValue("MSDO", "IC_UI_label3");
            this.label4.Text = config.ReadConfigValue("MSDO", "IC_UI_label4");
            this.label5.Text = config.ReadConfigValue("MSDO", "IC_UI_label5");

            this.BtnBaseSave.Text = config.ReadConfigValue("MSDO", "IC_Code_save");
            this.BtnCancel.Text = config.ReadConfigValue("MSDO", "IC_Code_cannel");
            this.BtnItemDelete.Text = config.ReadConfigValue("MSDO", "IC_Code_BtnItemDelete");
        }


        #endregion
        /// <summary>
        /// ����Ĭ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_SDO_Update_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem"));
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem1"));
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem2"));
            CmbType.Items.Add(config.ReadConfigValue("MSDO", "IC_Code_comItem3"));
            radioButton1.Checked = true;
            radioButton2.Checked = false;

            groupBox1.Enabled = true;
            groupBox2.Enabled = false;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_SDO");

            this.backgroundWorkerFormLoad.RunWorkerAsync(mContent);

            //mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, mContent);

            //CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            //PnlInputCharacter.Visible = false;
            //PnlnfoCharacter.Visible = false;
            //PnlItemDelete.Visible = false;
            //PnlAddGift.Visible = false;
            //GrdAddGift.Visible = false;
            //BtnClear.Enabled = false;
            //PnlItemPage.Visible = false;
            //PnlGiftPage.Visible = false;
            //TbcResult.Visible = false;

            ////��ӵ����б�
            //mItemTable = new DataTable();
            //mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo7"), typeof(string));
            //mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo"), typeof(string));
            //mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo1"), typeof(string));
            //mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo2"), typeof(string));
            //mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo3"), typeof(string));
            //mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo4"), typeof(string));
            //mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo5"), typeof(string));
            //mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo6"), typeof(string)); 
        }

        /// <summary>
        /// �����ʺ���Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            radioButton1.Checked = true;    
            radioButton2.Checked = false;

            groupBox1.Enabled = true;
            groupBox2.Enabled = false;

            PnlnfoCharacter.Controls.Clear();
            //��ʾ����
            PnlInputCharacter.Visible = false;
            PnlnfoCharacter.Visible = false;
            PnlItemDelete.Visible = false;
            PnlAddGift.Visible = false;
            GrdAddGift.Visible = false;
            BtnClear.Enabled = false;

            iUserIndexID = -1;

            //�������
            //GrdCharacter.DataSource = null;
            GrdAddGift.DataSource = null;
            GrdItem.DataSource = null;
            GrdGift.DataSource = null;
            //TbcResult.SelectedTab = TpgCharacter;
            TbcResult.Visible = false;


            foreach (Control m in PnlnfoCharacter.Controls.Find("LabelTextBox", true))
            {
                m.Dispose();
            }            

            if (TxtAccount.Text.Trim().Length > 0)
            {
                this.BtnSearch.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                //��ѯ��Ϣ
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

                mContent[0].eName = CEnum.TagName.SDO_Account;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = TxtAccount.Text;

                mContent[1].eName = CEnum.TagName.SDO_NickName;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = "";

                mContent[2].eName = CEnum.TagName.SDO_ServerIP;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[3].eName = CEnum.TagName.Index;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = 1;

                mContent[4].eName = CEnum.TagName.PageSize;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = 10;

                this.backgroundWorkerSearch.RunWorkerAsync(mContent);

                //mGetResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_CHARACTERINFO_QUERY, mContent);

                ////��������ʾ
                //if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    TbcResult.Visible = false;
                //    //GrdCharacter.DataSource = null;
                //    MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                //    return;
                //}

                //CmbServer.Enabled = false;
                //TxtAccount.Enabled = false;


                //TbcResult.Visible = true;

                //iIndex = 0; //Ĭ��ѡ�е���

                //CharacterInfo();
                //Operation_SDO.BuildDataTable(this.m_ClientEvent, mGetResult, GrdCharacter, out iPageCount);

                //TbcResult.Visible = true;

                //GrdCharacter.Columns[GrdCharacter.ColumnCount - 1].Visible = false;
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgAccont"));
            }
        }

        /// <summary>
        /// ���߷�ҳ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbItemPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            iOutPage = 0;

            if (bItemFirst)
            {
                CmbItemPage.Enabled = false;
                Cursor = Cursors.AppStarting;
                strSelect = CmbItemPage.Text;

                //GetItemBox(iUserIndexID, (int.Parse(CmbItemPage.Text) - 1) * Operation_SDO.iPageSize + 1, out iOutPage);

                GrdItem.DataSource = null;

 

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
                mContent[0].eName = CEnum.TagName.SDO_UserIndexID;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = iUserIndexID;

                mContent[1].eName = CEnum.TagName.SDO_ServerIP;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mContent[2].eName = CEnum.TagName.Index;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = (int.Parse(CmbItemPage.Text) - 1) * Operation_SDO.iPageSize + 1;

                mContent[3].eName = CEnum.TagName.PageSize;
                mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[3].oContent = Operation_SDO.iPageSize;

                this.backgroundWorkerItemPageChanged.RunWorkerAsync(mContent);

                //lock (typeof(C_Event.CSocketEvent))
                //{
                //    CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_BYOWNER_QUERY, mContent);
                //}
                //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                //{
                //    MessageBox.Show(mResult[0, 0].oContent.ToString());
                //    return;
                //}
                //else
                //{
                //    Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdItem, out iOutPage);
                //}
                
                
                //if (iOutPage <= 0)
                //{
                //    PnlItemPage.Visible = false;
                //}
                //else
                //{
                //    CmbItemPage.Items.Clear();

                //    for (int i = 0; i < iOutPage; i++)
                //    {
                //        CmbItemPage.Items.Add(i + 1);
                //    }

                //    CmbItemPage.Text = strSelect;
                //    PnlItemPage.Visible = true;
                //    bItemFirst = false;
                //}
                //if (iOutPage > 0)
                //{
                //    bGiftFirst = true;
                //}
            }

            
        }

        /// <summary>
        /// ����з�ҳ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbGiftPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iOutPage = 0;

            if (bGiftFirst)
            {
                string strSelect = CmbGiftPage.Text;

                GetGiftBox(iUserIndexID, (int.Parse(CmbGiftPage.Text) - 1) * Operation_SDO.iPageSize + 1, out iOutPage);

                if (iOutPage <= 0)
                {
                    PnlGiftPage.Visible = false;
                }
                else
                {
                    CmbGiftPage.Items.Clear();

                    for (int i = 0; i < iOutPage; i++)
                    {
                        CmbGiftPage.Items.Add(i + 1);
                    }

                    bGiftFirst = false;
                    CmbGiftPage.Text = strSelect;
                    PnlGiftPage.Visible = true; 
                }
            }

            if (iOutPage > 0)
            {
                bGiftFirst = true;
            }
        }

        /// <summary>
        /// ѡȡɾ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable mItemInfo = (DataTable)GrdItem.DataSource;

                if (mItemInfo.Rows.Count > 0)
                {
                    PnlItemDelete.Visible = true;
                    iItemIndex = int.Parse(mItemInfo.Rows[e.RowIndex][0].ToString());

                    LblItemDelete.Text = config.ReadConfigValue("MSDO", "IC_Code_MsgAccont1").Replace("{item}", mItemInfo.Rows[e.RowIndex][1].ToString());
                        
                }            
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgchooseItem"));
            }
        }

        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnItemDelete_Click(object sender, EventArgs e)
        {
            if (iItemIndex == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgchooseItem"));
            }
            else
            {
                if (MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgItem"), config.ReadConfigValue("MSDO", "IC_Code_MsgItem1"), MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    PnlItemPage.Visible = false;
                    CEnum.Message_Body[] mItemDelete = new CEnum.Message_Body[4];
                    mItemDelete[0].eName = CEnum.TagName.SDO_UserIndexID;
                    mItemDelete[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mItemDelete[0].oContent = iUserIndexID;

                    mItemDelete[1].eName = CEnum.TagName.SDO_ServerIP;
                    mItemDelete[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mItemDelete[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mItemDelete[2].eName = CEnum.TagName.SDO_ItemCode;
                    mItemDelete[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mItemDelete[2].oContent = iItemIndex;

                    mItemDelete[3].eName = CEnum.TagName.UserByID;
                    mItemDelete[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mItemDelete[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());
                    CEnum.Message_Body[,] mDeleteResult = null;
                    lock (typeof(C_Event.CSocketEvent))
                    {
                        mDeleteResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_DELETE, mItemDelete);
                    }

                    if (mDeleteResult[0, 0].oContent.Equals("SUCESS"))
                    {
                        int iItemPage = 0;

                        GetItemBox(iUserIndexID, 1, out iItemPage);

                        bItemFirst = false;

                        if (iItemPage <= 0)
                        {
                            PnlItemPage.Visible = false;
                        }
                        else
                        {
                            CmbItemPage.Items.Clear();

                            for (int i = 0; i < iItemPage; i++)
                            {
                                CmbItemPage.Items.Add(i + 1);
                            }

                            CmbItemPage.SelectedIndex = 0;
                            bItemFirst = true;
                            PnlItemPage.Visible = true;
                        }

                        MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_delSuc"));
                    }
                    else
                    {
                        MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_delFail"));
                    }
                }
                else
                {
                    LblItemDelete.Text = "";
                    PnlItemDelete.Visible = false;
                }
            }
        }

        /// <summary>
        /// ��ӵ��ߡ�--  �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbSort.Items.Clear();
            CmbSort.Text = "";
            CmbSort.Enabled = true;
            CmbItem.Items.Clear();
            CmbItem.Text = "";
            if (CmbType.Text == config.ReadConfigValue("MSDO", "IC_Code_Dress"))
            {
                iType = 0;
                if (iSex == 1)
                    CmbSort.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "IC_Code_head"), config.ReadConfigValue("MSDO", "IC_Code_hair"), config.ReadConfigValue("MSDO", "IC_Code_body"), config.ReadConfigValue("MSDO", "IC_Code_leg"), config.ReadConfigValue("MSDO", "IC_Code_hand"), config.ReadConfigValue("MSDO", "IC_Code_feet"), config.ReadConfigValue("MSDO", "IC_Code_face"), config.ReadConfigValue("MSDO", "IC_Code_glass"), config.ReadConfigValue("MSDO", "IC_Code_taozhuang") });
                else
                    CmbSort.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "IC_Code_head"), config.ReadConfigValue("MSDO", "IC_Code_hair"), config.ReadConfigValue("MSDO", "IC_Code_body"), config.ReadConfigValue("MSDO", "IC_Code_leg"), config.ReadConfigValue("MSDO", "IC_Code_hand"), config.ReadConfigValue("MSDO", "IC_Code_feet"), config.ReadConfigValue("MSDO", "IC_Code_face"), config.ReadConfigValue("MSDO", "IC_Code_glass"), config.ReadConfigValue("MSDO", "IC_Code_onedress") });
                //    CmbSort.Items.AddRange(new object[] { "ͷ", "ͷ��", "����", "��", "��", "��", "����", "�۾�", "[��װ]" });
                //else
                //    CmbSort.Items.AddRange(new object[] { "ͷ", "ͷ��", "����", "��", "��", "��", "����", "�۾�", "����ȹ"});
            }
            else if (CmbType.Text == config.ReadConfigValue("MSDO", "IC_Code_Item"))
            {
                iType = 1;
                CmbSort.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "IC_Code_eff"), config.ReadConfigValue("MSDO", "IC_Code_fitem") });
            }
            else if (CmbType.Text == config.ReadConfigValue("MSDO", "IC_Code_xunzhang"))
            {
                iType = 3;
                CmbSort.Enabled = false;

                CEnum.Message_Body[] mItemContent = new CEnum.Message_Body[4];
                mItemContent[0].eName = CEnum.TagName.SDO_ServerIP;
                mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mItemContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mItemContent[1].eName = CEnum.TagName.SDO_BigType;
                mItemContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[1].oContent = iType;

                mItemContent[2].eName = CEnum.TagName.SDO_SmallType;
                mItemContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mItemContent[2].oContent = 0;

                mItemContent[3].eName = CEnum.TagName.SDO_ItemName;
                mItemContent[3].eTag = CEnum.TagFormat.TLV_STRING;
                mItemContent[3].oContent = "";

                mItemInfo = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_QUERY, mItemContent);
                CmbItem = Operation_SDO.BuildComboxs(this.m_ClientEvent,mItemInfo, CmbItem);
            }
            else
            {
                iType = 2;
                CmbSort.Items.AddRange(new object[] { config.ReadConfigValue("MSDO", "IC_Code_taozhuang1"), config.ReadConfigValue("MSDO", "IC_Code_present") });
            }
        }

        /// <summary>
        /// ��ӵ���  --  С�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbItem.Items.Clear();
            CmbItem.Text = "";

            if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_head").Trim())
            {
                iSort = 0;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_hair").Trim())
            {
                iSort = 1;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_body").Trim())
            {
                iSort = 2;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_leg").Trim())
            {
                iSort = 3;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_hand").Trim())
            {
                iSort = 4;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_feet").Trim())
            {
                iSort = 5;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_face").Trim())
            {
                iSort = 6;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_glass").Trim())
            {
                iSort = 7;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_onedress").Trim())
            {
                iSort = 50;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_taozhuang").Trim())
            {
                iSort = 50;
            }
            //��Ʒ����
            //switch (CmbSort.Text)
            //{
            //    case "ͷ":
            //        iSort = 0;
            //        break;
            //    case "ͷ��":
            //        iSort = 1;
            //        break;
            //    case "����":
            //        iSort = 2;
            //        break;
            //    case "��":
            //        iSort = 3;
            //        break;
            //    case "��":
            //        iSort = 4;
            //        break;
            //    case "��":
            //        iSort = 5;
            //        break;
            //    case "����":
            //        iSort = 6;
            //        break;
            //    case "�۾�":
            //        iSort = 7;
            //        break;
            //    case "����ȹ":
            //    case "[��װ]":
            //        iSort = 50;
            //        break;
            //}

            if (iSex == 0)
            {
                iSort = iSort + 100;
            }


            if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_eff").Trim())
            {
                iSort = 0;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_fitem").Trim())
            {
                iSort = 0;
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_taozhuang1").Trim())
            {
                if (iSex == 0)
                {
                    iSort = 200;
                }
                else
                {
                    iSort = 201;
                }
            }
            else if (CmbSort.Text.Trim() == config.ReadConfigValue("MSDO", "IC_Code_present").Trim())
            {
                iSort = 202;
            }
            //switch (CmbSort.Text)
            //{
            //    case "��Ч":
            //    case "���ܵ���":
            //        iSort = 0;
            //        break;
            //    case "��װ":
            //        if (iSex == 0)
            //        {
            //            iSort = 200;
            //        }
            //        else
            //        {
            //            iSort = 201;
            //        }
            //        break;
            //    case "���":
            //        iSort = 202;
            //        break;
            //}

            CEnum.Message_Body[] mItemContent = new CEnum.Message_Body[4];
            mItemContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mItemContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mItemContent[1].eName = CEnum.TagName.SDO_BigType;
            mItemContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[1].oContent = iType;

            mItemContent[2].eName = CEnum.TagName.SDO_SmallType;
            mItemContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[2].oContent = iSort;

            mItemContent[3].eName = CEnum.TagName.SDO_ItemName;
            mItemContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mItemContent[3].oContent = "";

            mItemInfo = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_QUERY, mItemContent);
            CmbItem = Operation_SDO.BuildComboxs(this.m_ClientEvent, mItemInfo, CmbItem);

            if (CmbItem.Tag != null)
            {
                if (((ArrayList)((ArrayList)CmbItem.Tag)[0])[0].ToString() == "0")
                {
                    DtpDate.Value = new DateTime(2050, 1, 1);
                }
                else
                {
                    DtpDate.Value = DateTime.Now.AddDays(Convert.ToInt32(((ArrayList)((ArrayList)CmbItem.Tag)[0])[0].ToString()));
                }
            } 
        }

        /// <summary>
        /// ��ӵ���  --  ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbItem_SelectedIndexChanged(object sender, EventArgs e)

        {            
            //try
            //{
            //    TxtCount.Value = 1;
            //    //TxtCount.Value = int.Parse(CmbItem.Text.Split(Convert.ToChar("("))[1].ToString().Split(Convert.ToChar(")"))[0].ToString());
            //    //TxtCount.Value = int.Parse(Operation_SDO.GetTimes(mItemInfo, Operation_SDO.GetItemID(mItemInfo, CmbItem.SelectedIndex).ToString()).ToString());
            //    if (CmbItem.Text.IndexOf('(') != -1)
            //    {
            //        int limitDay = int.Parse(CmbItem.Text.Split(new char[] { '(' })[1].ToString().Replace(")", ""));
            //        DtpDate.Value = DateTime.Now.AddDays(limitDay);
            //    }
            //    else
            //    {
            //        DtpDate.Value = DateTime.Now.AddDays(int.Parse(Operation_SDO.GetLimit(mItemInfo, Operation_SDO.GetItemID(mItemInfo, CmbItem.Text.Split(Convert.ToChar("("))[0].ToString()).ToString()).ToString()));

            //    }
            //}
            //catch
            //{
            //    TxtCount.Value = 1;
            //}

            try
            {
                TxtCount.Value = 1;
                ArrayList daylimitlist = (ArrayList)(((ArrayList)CmbItem.Tag)[0]);
                ArrayList itemCodeList = (ArrayList)(((ArrayList)CmbItem.Tag)[1]);
                //TxtCount.Value = int.Parse(CmbItem.Text.Split(Convert.ToChar("("))[1].ToString().Split(Convert.ToChar(")"))[0].ToString());
                //TxtCount.Value = int.Parse(Operation_SDO.GetTimes(mItemInfo, Operation_SDO.GetItemID(mItemInfo, CmbItem.SelectedIndex).ToString()).ToString());
                //if (CmbItem.Text.IndexOf('(') != -1)
                //{
                //    int limitDay = int.Parse(CmbItem.Text.Split(new char[] { '(' })[1].ToString().Replace(")", ""));
                //    DtpDate.Value = DateTime.Now.AddDays(limitDay);
                //}
                //else
                //{
                //    DtpDate.Value = DateTime.Now.AddDays(int.Parse(Operation_SDO.GetLimit(mItemInfo, Operation_SDO.GetItemID(mItemInfo, CmbItem.Text.Split(Convert.ToChar("("))[0].ToString()).ToString()).ToString()));

                //}
                if (daylimitlist[CmbItem.SelectedIndex].ToString() == "0")
                {
                    DtpDate.Value = new DateTime(2050, 1, 1);
                }
                else
                {
                    DtpDate.Value = DateTime.Now.AddDays(Convert.ToInt32(daylimitlist[CmbItem.SelectedIndex].ToString()));
                }

            }
            catch
            {
                TxtCount.Value = 1;
            } 
        }

        /// <summary>
        /// ѡ����ӵĵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdAddGift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                iSelectIndex = e.RowIndex;
                mSelectTable = (DataTable)GrdAddGift.DataSource;

                CmbType.Text = mSelectTable.Rows[e.RowIndex][1].ToString();
                CmbSort.Text = mSelectTable.Rows[e.RowIndex][2].ToString();
                CmbItem.Text = mSelectTable.Rows[e.RowIndex][3].ToString();
                DtpDate.Value = Convert.ToDateTime(mSelectTable.Rows[e.RowIndex][4].ToString());
                TxtCount.Value = Convert.ToInt32(mSelectTable.Rows[e.RowIndex][5].ToString());
                TxtTitle.Text = mSelectTable.Rows[e.RowIndex][6].ToString();
                TxtMemo.Text = mSelectTable.Rows[e.RowIndex][7].ToString();

                BtnClear.Enabled = true;
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_Msgchoosepresent"));
            }
        }

        /// <summary>
        /// ��ӵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TxtTitle.Text.Trim().Length == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_Msgtitle"));
                return;
            }

            if (TxtMemo.Text.Trim().Length == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgConet"));
                return;
            }

            if (radioButton2.Checked && lstItem.SelectedIndex == -1)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgSendpresent"));
                return;
            }

            /*
            for (int i = 0; i < mItemTable.Rows.Count; i++)
            {
                if (mItemTable.Rows[i]["��Ʒ����"].Equals(CmbItem.Text))
                {
                    MessageBox.Show("�����ظ�����ͬһ����Ʒ��");
                    return;
                }
            }
            */

            DataTable mGiftTable = (DataTable)GrdGift.DataSource;
            try
            {

                for (int i = 0; i < mGiftTable.Rows.Count; i++)
                {
                    if (mGiftTable.Rows[i][config.ReadConfigValue("MSDO", "IC_Code_ItemName")].Equals(CmbItem.Text))
                    {
                        MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_Msgpresent"));
                        return;
                    }
                }
            }
            catch
            { 
                //
            }

            this.BtnAdd.Enabled = false;
            this.Cursor = Cursors.AppStarting;
            CEnum.Message_Body[] mSend = new CEnum.Message_Body[8];

            mSend[0].eName = CEnum.TagName.SDO_UserIndexID;
            mSend[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mSend[0].oContent = iUserIndexID;

            if (radioButton2.Checked)
            {
                mSend[1].eName = CEnum.TagName.SDO_ItemCode;
                mSend[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mSend[1].oContent = int.Parse(mItemInfo[lstItem.SelectedIndex, 2].oContent.ToString());
            }
            else
            {
                mSend[1].eName = CEnum.TagName.SDO_ItemCode;
                mSend[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mSend[1].oContent = int.Parse(((ArrayList)(((ArrayList)CmbItem.Tag)[1]))[CmbItem.SelectedIndex].ToString()); 
                //mSend[1].oContent = Operation_SDO.GetItemID(mItemInfo, CmbItem.Text.Split(Convert.ToChar("("))[0].ToString());
            }
            

            mSend[2].eName = CEnum.TagName.SDO_DateLimit;
            mSend[2].eTag = CEnum.TagFormat.TLV_DATE;
            mSend[2].oContent = DtpDate.Value.Date;

            mSend[3].eName = CEnum.TagName.SDO_TimesLimit;
            mSend[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mSend[3].oContent = int.Parse(TxtCount.Value.ToString());

            mSend[4].eName = CEnum.TagName.SDO_Title;
            mSend[4].eTag = CEnum.TagFormat.TLV_STRING;
            mSend[4].oContent = TxtTitle.Text;

            mSend[5].eName = CEnum.TagName.SDO_Context;
            mSend[5].eTag = CEnum.TagFormat.TLV_STRING;
            mSend[5].oContent = TxtMemo.Text;

            mSend[6].eName = CEnum.TagName.SDO_ServerIP;
            mSend[6].eTag = CEnum.TagFormat.TLV_STRING;
            mSend[6].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mSend[7].eName = CEnum.TagName.UserByID;
            mSend[7].eTag = CEnum.TagFormat.TLV_INTEGER;
            mSend[7].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());


            //mSend[8].eName = CEnum.TagName.SDO_Desc;
            //mSend[8].eTag = CEnum.TagFormat.TLV_STRING;
            //mSend[8].oContent = "sdo";

            this.backgroundWorkerAdd.RunWorkerAsync(mSend);

            //CEnum.Message_Body[,] mSendResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_GIFTBOX_CREATE, mSend);

            //if (mSendResult[0, 0].oContent.Equals("FAILURE") || mSendResult == null)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgAddFail"));
            //    return;
            //}
            //else
            //{
            //    mItemTable.Clear();

            //    DataRow mItemRow = null;

            //    mItemRow = mItemTable.NewRow();
            //    if (radioButton1.Checked)
            //    {
            //        mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo7")] = ((ArrayList)(((ArrayList)CmbItem.Tag)[1]))[CmbItem.SelectedIndex].ToString(); 
            //        mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo")] = CmbType.Text;
            //        mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo1")] = CmbSort.Text;
            //        mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo2")] = CmbItem.Text;
            //    }
            //    else if (radioButton2.Checked)
            //    {
            //        mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo7")] = ((ArrayList)(((ArrayList)lstItem.Tag)[0]))[this.lstItem.SelectedIndex].ToString();
            //        mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo")] = "N/A";
            //        mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo1")] = "N/A";
            //        mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo2")] = mItemInfo[lstItem.SelectedIndex, 3].oContent.ToString();

            //        //mItemRow["��Ʒ���"] = "N/A";
            //        //mItemRow["��Ʒ����"] = "N/A";
            //        //mItemRow["��Ʒ����"] = mItemInfo[lstItem.SelectedIndex, 3].oContent.ToString();
            //    }
            //    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo3")] = DtpDate.Value.ToString();
            //    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo4")] = TxtCount.Value.ToString();
            //    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo5")] = TxtTitle.Text;
            //    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo6")] = TxtMemo.Text;

            //    mItemTable.Rows.Add(mItemRow);

            //    GrdAddGift.DataSource = mItemTable;

            //    int iGiftPage = 0;

            //    GetGiftBox(iUserIndexID, 1, out iGiftPage);

            //    bGiftFirst = false;

            //    if (iGiftPage <= 0)
            //    {
            //        PnlGiftPage.Visible = false;
            //    }
            //    else
            //    {
            //        CmbGiftPage.Items.Clear();

            //        for (int i = 0; i < iGiftPage; i++)
            //        {
            //            CmbGiftPage.Items.Add(i + 1);
            //        }

            //        CmbGiftPage.SelectedIndex = 0;
            //        bGiftFirst = true;
            //        PnlGiftPage.Visible = true;
            //    }

            //    MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgAddSucces"));
                //TbcResult.SelectedTab = TpgGift;
            //}
        }

        /// <summary>
        /// ɾ����ӵĵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgItem"), config.ReadConfigValue("MSDO", "IC_Code_MsgItem1"), MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                this.BtnClear.Enabled = false;
                this.Cursor = Cursors.AppStarting;
                CEnum.Message_Body[] mSend = new CEnum.Message_Body[8];

                mSend[0].eName = CEnum.TagName.SDO_UserIndexID;
                mSend[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mSend[0].oContent = iUserIndexID;

                mSend[1].eName = CEnum.TagName.SDO_ItemCode;
                mSend[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                //mSend[1].oContent = Operation_SDO.GetItemID(mItemInfo, mSelectTable.Rows[iSelectIndex][2].ToString());
                mSend[1].oContent = Convert.ToInt32(mSelectTable.Rows[iSelectIndex][0].ToString()); 

                mSend[2].eName = CEnum.TagName.SDO_DateLimit;
                mSend[2].eTag = CEnum.TagFormat.TLV_DATE;
                mSend[2].oContent = DtpDate.Value.Date;

                mSend[3].eName = CEnum.TagName.SDO_TimesLimit;
                mSend[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                mSend[3].oContent = int.Parse(TxtCount.Value.ToString());

                mSend[4].eName = CEnum.TagName.SDO_Title;
                mSend[4].eTag = CEnum.TagFormat.TLV_STRING;
                mSend[4].oContent = TxtTitle.Text;

                mSend[5].eName = CEnum.TagName.SDO_Context;
                mSend[5].eTag = CEnum.TagFormat.TLV_STRING;
                mSend[5].oContent = TxtMemo.Text;

                mSend[6].eName = CEnum.TagName.SDO_ServerIP;
                mSend[6].eTag = CEnum.TagFormat.TLV_STRING;
                mSend[6].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                mSend[7].eName = CEnum.TagName.UserByID;
                mSend[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                mSend[7].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                this.backgroundWorkerDeleteItem.RunWorkerAsync(mSend);
                //CEnum.Message_Body[,] mSendResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_GIFTBOX_DELETE, mSend);

                //if (mSendResult[0, 0].oContent.Equals("FAILURE"))
                //{
                //    MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_delFail"));
                //}
                //else
                //{
                //    mSelectTable = (DataTable)GrdAddGift.DataSource;

                //    mSelectTable.Rows[iSelectIndex].Delete();

                //    GrdAddGift.DataSource = mSelectTable;

                //    TxtCount.Value = 1;
                //    TxtTitle.Clear();
                //    TxtMemo.Clear();

                //    int iGiftPage = 0;

                //    GetGiftBox(iUserIndexID, 1, out iGiftPage);

                //    bGiftFirst = false;

                //    if (iGiftPage <= 0)
                //    {
                //        PnlGiftPage.Visible = false;
                //    }
                //    else
                //    {
                //        CmbGiftPage.Items.Clear();

                //        for (int i = 0; i < iGiftPage; i++)
                //        {
                //            CmbGiftPage.Items.Add(i + 1);
                //        }

                //        CmbGiftPage.SelectedIndex = 0;
                //        bGiftFirst = true;
                //        PnlGiftPage.Visible = true;
                //    }
                //}
            }
        }

        /// <summary>
        /// ��ɫ���Ա���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBaseSave_Click(object sender, EventArgs e)
        {
            int iIndex = 0;
            int intMCash = 0;
            CEnum.Message_Body[] mEdit = new CEnum.Message_Body[iEditCount + 4];

            for (int i = 0; i < PnlnfoCharacter.Controls.Count; i++)
            {
                if (PnlnfoCharacter.Controls[i].GetType() == typeof(LabelTextBox))
                {
                    LabelTextBox mControls = (LabelTextBox)PnlnfoCharacter.Controls[i];
                    if (mControls.TagName == CEnum.TagName.SDO_MCash)
                    {
                        intMCash = int.Parse(mControls.TextBoxText);
                    }
                    if (!mControls.ReadOnly)
                    {
                        mEdit[iIndex].eName = mControls.TagName;
                        mEdit[iIndex].eTag = mControls.TagFmt;
                        mEdit[iIndex].oContent = Operation_SDO.DecodeContent(mControls.TagFmt, mControls.TextBoxText);

                        iIndex++;
                    }

                }
            }

            mEdit[iIndex].eName = CEnum.TagName.SDO_Account;
            mEdit[iIndex].eTag = CEnum.TagFormat.TLV_STRING;
            mEdit[iIndex].oContent = TxtAccount.Text;

            mEdit[iIndex + 1].eName = CEnum.TagName.SDO_ServerIP;
            mEdit[iIndex + 1].eTag = CEnum.TagFormat.TLV_STRING;
            mEdit[iIndex + 1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mEdit[iIndex + 2].eName = CEnum.TagName.UserByID;
            mEdit[iIndex + 2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mEdit[iIndex + 2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mEdit[iIndex + 3].eName = CEnum.TagName.SDO_MCash;
            mEdit[iIndex + 3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mEdit[iIndex + 3].oContent = intMCash;

            BtnBaseSave.Enabled = false;
            Cursor = Cursors.AppStarting;
            this.backgroundWorkerSaveBase.RunWorkerAsync(mEdit);
            //CEnum.Message_Body[,] mPostResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_CHARACTERINFO_UPDATE, mEdit);

            //if (mPostResult[0, 0].oContent.Equals("FAILURE"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_UpdateMsgf"));
            //}
            //else
            //{
            //    MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_UpdateMsgs"));
            //}

            //this.BtnSearch_Click(sender, e);
        }

        /// <summary>
        /// ��ɫ���Ա���ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.BtnSearch_Click(sender, e);
        }

        /// <summary>
        /// ����Ԫ�ش�С
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_SDO_Update_Resize(object sender, EventArgs e)
        {
            PnlnfoCharacter.Height = TpgCharacter.Height - 200;
        }

        /// <summary>
        /// �رմ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;

            groupBox1.Enabled = true;
            groupBox2.Enabled = false;

            CmbServer.Enabled = true;
            TxtAccount.Enabled = true;

            PnlnfoCharacter.Controls.Clear();
            //��ʾ����
            PnlInputCharacter.Visible = false;
            PnlnfoCharacter.Visible = false;
            PnlItemDelete.Visible = false;
            PnlAddGift.Visible = false;
            GrdAddGift.Visible = false;
            BtnClear.Enabled = false;

            iUserIndexID = -1;

            //�������
            //GrdCharacter.DataSource = null;
            GrdAddGift.DataSource = null;
            GrdItem.DataSource = null;
            GrdGift.DataSource = null;
            //TbcResult.SelectedTab = TpgCharacter;
            TbcResult.Visible = false;
        }

        #region �Զ����¼�
        private void GetItemBox(int iIndex, int iPage, out int iNow)
        {
            GrdItem.DataSource = null;

            iNow = 0;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
            mContent[0].eName = CEnum.TagName.SDO_UserIndexID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = iIndex;

            mContent[1].eName = CEnum.TagName.SDO_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.Index;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = iPage;

            mContent[3].eName = CEnum.TagName.PageSize;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_SDO.iPageSize;
            
            ArrayList paramList = new ArrayList();
            paramList.Add("GetItemBox");
            paramList.Add(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)));
            paramList.Add(CEnum.ServiceKey.SDO_ITEMSHOP_BYOWNER_QUERY);
            paramList.Add(mContent);
            this.backgroundWorkerTabChanged.RunWorkerAsync(paramList);

           
            //    CEnum.Message_Body[,] mResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_BYOWNER_QUERY, mContent);
            
            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}
            //else
            //{
            //    Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdItem, out iNow);
            //}
        }
        private void GetGiftBox(int iIndex, int iPage, out int iNow)
        {
            GrdGift.DataSource = null;
            iNow = 0;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[4];
            mContent[0].eName = CEnum.TagName.SDO_UserIndexID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = iIndex;

            mContent[1].eName = CEnum.TagName.SDO_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.Index;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = iPage;

            mContent[3].eName = CEnum.TagName.PageSize;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = Operation_SDO.iPageSize;

            ArrayList paramList = new ArrayList();
            paramList.Add("GetGiftBox");
            paramList.Add(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)));
            paramList.Add(CEnum.ServiceKey.SDO_GIFTBOX_QUERY);
            paramList.Add(mContent);
            this.backgroundWorkerTabChanged.RunWorkerAsync(paramList);

            //mGiftResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent,Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_GIFTBOX_QUERY, mContent);

            //if (mGiftResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mGiftResult[0, 0].oContent.ToString());
            //    return;
            //}
            //else
            //{
            //    Operation_SDO.BuildDataTable(this.m_ClientEvent, mGiftResult, GrdGift, out iNow);
            //}
        }

        //Ԥ���й�
        private delegate void CharacterDelegat();
        private void DelegatInfo()
        {
            try
            {
                BeginInvoke(new BuildCharacter(CharacterInfo));
            }
            catch
            {

            }
        }

        //������Ϣ
        private delegate void BuildCharacter();
        private void CharacterInfo()
        {
            try
            {
                PnlnfoCharacter.Controls.Clear();
                //��ɫ��Ϣ
                for (int i = 0; i < mGetResult.GetLength(1); i++)
                {
                    if (mGetResult[0, i].eName == CEnum.TagName.PageCount) continue;
                    LabelTextBox mDisplay = new LabelTextBox();
                    mDisplay.Parent = PnlnfoCharacter;
                    mDisplay.Position = C_Controls.LabelTextBox.LabelTextBox.ELABELPOSITION.LEFT;

                    if (i % 2 == 0)
                    {
                        mDisplay.Top = 20 * i + 10;
                        mDisplay.Left = 10;
                    }
                    else
                    {
                        mDisplay.Top = 20 * (i - 1) + 10;
                        mDisplay.Left = mDisplay.Width + 111;
                    }

                    mDisplay.Name = mGetResult[0, i].eName.ToString();
                    mDisplay.TagName = mGetResult[0, i].eName;
                    mDisplay.TagFmt = mGetResult[0, i].eTag;
                    mDisplay.LabelText = config.ReadConfigValue("GLOBAL", mGetResult[iIndex, i].eName.ToString()) + ":";
                        //this.m_ClientEvent.DecodeFieldName(mGetResult[iIndex, i].eName);


                    if (mGetResult[0, i].oContent == null)
                    {
                        mDisplay.TextBoxText = "";
                    }
                    else
                    {
                        mDisplay.TextBoxText = mGetResult[iIndex, i].oContent.ToString();
                    }

                    if (mGetResult[iIndex, i].eName == CEnum.TagName.SDO_SEX)
                    {
                        try
                        {
                            iSex = int.Parse(mGetResult[iIndex, i].oContent.ToString());
                        }
                        catch
                        {

                        }

                        //mDisplay.Visible = false;
                    }

                    if (mGetResult[0, i].eName == CEnum.TagName.SDO_Account)
                    {
                        LblAddUser.Text = config.ReadConfigValue("MSDO", "IC_Code_SendText").Replace("{Nickname}", mGetResult[0, i].oContent.ToString().Trim());
                           // "��Ŀǰ����׼����" + mGetResult[0, i].oContent.ToString().Trim() + "���͵��ߣ�";
                    }

                    if (mGetResult[0, i].eName == CEnum.TagName.SDO_UserIndexID)
                    {
                        iUserIndexID = int.Parse(mGetResult[0, i].oContent.ToString());
                    }

                    if (mGetResult[0, i].eName == CEnum.TagName.SDO_SEX)
                    {
                        if (mGetResult[0, i].oContent.ToString().Equals("0"))
                            mDisplay.TextBoxText = config.ReadConfigValue("MSDO", "IC_Code_Fsex1");
                        else
                            mDisplay.TextBoxText = config.ReadConfigValue("MSDO", "IC_Code_Msex1");
                    }
                }

                //�޸�����
                iEditCount = 0;

                for (int i = 0; i < PnlnfoCharacter.Controls.Count; i++)
                {
                    if (PnlnfoCharacter.Controls[i].GetType() == typeof(LabelTextBox))
                    {
                        LabelTextBox mControls = (LabelTextBox)PnlnfoCharacter.Controls[i];

                        if (mControls.Name.Equals(CEnum.TagName.SDO_Level.ToString())
                                    || mControls.Name.Equals(CEnum.TagName.SDO_GCash.ToString()) || mControls.Name.Equals(CEnum.TagName.SDO_Exp.ToString())
                                    || mControls.Name.Equals(CEnum.TagName.SDO_GameTotal.ToString()) || mControls.Name.Equals(CEnum.TagName.SDO_GameWin.ToString())
                                    || mControls.Name.Equals(CEnum.TagName.SDO_DogFall.ToString()) || mControls.Name.Equals(CEnum.TagName.SDO_GameFall.ToString())
                                    || mControls.Name.Equals(CEnum.TagName.SDO_Reputation.ToString()) || mControls.Name.Equals(CEnum.TagName.SDO_Reputation.ToString())
                            )
                        {
                            mControls.ReadOnly = false;
                            iEditCount++;
                        }
                    }
                }

                //��ɫ��Ϣ���
                PnlnfoCharacter.Visible = true;
                PnlInputCharacter.Visible = true;
                PnlnfoCharacter.Height = TpgCharacter.Height - 200;

                /*
                //��ҳ��Ϣ
                int iItemPage = 0;
                int iGiftPage = 0;

                GetItemBox(iUserIndexID, 1, out iItemPage);
                GetGiftBox(iUserIndexID, 1, out iGiftPage);

                bItemFirst = false;
                bGiftFirst = false;

                if (iItemPage <= 0)
                {
                    PnlItemPage.Visible = false;
                }
                else
                {
                    CmbItemPage.Items.Clear();

                    for (int i = 0; i < iItemPage; i++)
                    {
                        CmbItemPage.Items.Add(i + 1);
                    }

                    CmbItemPage.SelectedIndex = 0;
                    bItemFirst = true;
                    PnlItemPage.Visible = true;
                }

                if (iGiftPage <= 0)
                {
                    PnlGiftPage.Visible = false;
                }
                else
                {
                    CmbGiftPage.Items.Clear();

                    for (int i = 0; i < iGiftPage; i++)
                    {
                        CmbGiftPage.Items.Add(i + 1);
                    }

                    CmbGiftPage.SelectedIndex = 0;
                    bGiftFirst = true;
                    PnlGiftPage.Visible = true;
                }
                */

                //������ʾ����
                PnlAddGift.Visible = true;
                GrdAddGift.Visible = true;
                TbcResult.SelectedTab = TpgCharacter;
            }
            catch
            {

            }
        }
        
        #endregion

        private void TbcResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                switch (TbcResult.SelectedTab.Name)
                {
                    case "TpgGift":   //����װ��
                        /*
                        if (iUserIndexID <= 0)
                        {
                            MessageBox.Show("��ѡ��һ����ɫ���ٳ��ԣ�");
                            return;
                        }
                        */

                        iOutPage = 0;
                        this.TbcResult.Enabled = false;
                        this.Cursor = Cursors.AppStarting;
                        GetItemBox(iUserIndexID, 1, out iOutPage);

                        //bItemFirst = false;

                        //if (iItemPage <= 0)
                        //{
                        //    PnlItemPage.Visible = false;
                        //}
                        //else
                        //{
                        //    CmbItemPage.Items.Clear();

                        //    for (int i = 0; i < iItemPage; i++)
                        //    {
                        //        CmbItemPage.Items.Add(i + 1);
                        //    }

                        //    CmbItemPage.SelectedIndex = 0;
                        //    bItemFirst = true;
                        //    PnlItemPage.Visible = true;
                        //}
                        break;
                    case "TbpGift"://�����
                        /*
                        if (iUserIndexID <= 0)
                        {
                            MessageBox.Show("��ѡ��һ����ɫ���ٳ��ԣ�");
                            return;
                        }
                        */

                        iOutPage = 0;
                        this.TbcResult.Enabled = false;
                        this.Cursor = Cursors.AppStarting;
                        GetGiftBox(iUserIndexID, 1, out iOutPage);

                        //bGiftFirst = false;

                        //if (iGiftPage <= 0)
                        //{
                        //    PnlGiftPage.Visible = false;
                        //}
                        //else
                        //{
                        //    CmbGiftPage.Items.Clear();

                        //    for (int i = 0; i < iGiftPage; i++)
                        //    {
                        //        CmbGiftPage.Items.Add(i + 1);
                        //    }

                        //    CmbGiftPage.SelectedIndex = 0;
                        //    bGiftFirst = true;
                        //    PnlGiftPage.Visible = true;
                        //}
                        break;

                    case "TpgUseStatus":
                        this.TbcResult.Enabled = false;
                        this.Cursor = Cursors.WaitCursor;
                        GetItemStatus();
                        break;
                }
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgRentry"));
            }
        }

        private void PnlnfoCharacter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstItem.Items.Clear();

            string _type_name = null;

            CEnum.Message_Body[] mItemContent = new CEnum.Message_Body[4];
            mItemContent[0].eName = CEnum.TagName.SDO_ServerIP;
            mItemContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mItemContent[0].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            mItemContent[1].eName = CEnum.TagName.SDO_BigType;
            mItemContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[1].oContent = 0;

            mItemContent[2].eName = CEnum.TagName.SDO_SmallType;
            mItemContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mItemContent[2].oContent = 0;

            mItemContent[3].eName = CEnum.TagName.SDO_ItemName;
            mItemContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            mItemContent[3].oContent = txtItemName.Text;

            lock (typeof(C_Event.CSocketEvent))
            {
                mItemInfo = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_ITEMSHOP_QUERY, mItemContent);
            }

            if (mItemInfo[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mItemInfo[0, 0].oContent.ToString());
                return;
            }

            ArrayList ItemCodeList = new ArrayList();
            ArrayList DayLimitList = new ArrayList();
            ArrayList All = new ArrayList();

            for (int i = 0; i < mItemInfo.GetLength(0); i++)
            {
                 _type_name = mItemInfo[i, 3].oContent.ToString() + (mItemInfo[i, 5].oContent.ToString() == "0" ? config.ReadConfigValue("MSDO", "IC_Code_Itemlimit") : "(" + mItemInfo[i, 5].oContent.ToString() + config.ReadConfigValue("MSDO", "IC_Code_Itemdays"));

                if (int.Parse(mItemInfo[i, 0].oContent.ToString()) == 0)
                {
                    if (int.Parse(mItemInfo[i, 1].oContent.ToString()) < 100)
                    {
                        _type_name += config.ReadConfigValue("MSDO", "IC_Code_Msex");
                    }
                    else
                    {
                        _type_name += config.ReadConfigValue("MSDO", "IC_Code_Fsex");
                    }
                }

                ItemCodeList.Add(mItemInfo[i, 2].oContent.ToString());
                DayLimitList.Add(mItemInfo[i, 5].oContent.ToString());
                lstItem.Items.Add(_type_name);
            }
            All.Add(ItemCodeList);
            All.Add(DayLimitList);
            lstItem.Tag = All;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void lstItem_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (lstItem.Tag != null)
            {
                ArrayList daylimitlist = (ArrayList)(((ArrayList)lstItem.Tag)[1]);
                if (daylimitlist[lstItem.SelectedIndex].ToString() == "0")
                {
                    DtpDate.Value = new DateTime(2050, 1, 1);
                }
                else
                {
                    DtpDate.Value = DateTime.Now.AddDays(Convert.ToInt32(daylimitlist[lstItem.SelectedIndex].ToString()));
                }
            }


        }

        private void TxtAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void GrdGift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int aaaa = 1;
            try
            {
                DataTable mItemInfo = (DataTable)GrdGift.DataSource;

                if (mItemInfo.Rows.Count > 0)
                {
                    PnlItemDelete.Visible = true;
                    iItemIndex = int.Parse(mItemInfo.Rows[e.RowIndex][7].ToString());

                    LblItemDelete.Text = config.ReadConfigValue("MSDO", "IC_Code_MsgAccont1").Replace("{item}", mItemInfo.Rows[e.RowIndex][1].ToString());
                        //"��ѡ����" + mItemInfo.Rows[e.RowIndex][1].ToString() + "��Ʒ";
                }
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgchooseItem"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (iItemIndex == 0)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgchooseItem"));
            }
            else
            {
                if (MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgItem"), config.ReadConfigValue("MSDO", "IC_Code_MsgItem1"), MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    PnlGiftPage.Visible = false;
                    CEnum.Message_Body[] mItemDelete = new CEnum.Message_Body[4];
                    mItemDelete[0].eName = CEnum.TagName.SDO_UserIndexID;
                    mItemDelete[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mItemDelete[0].oContent = iUserIndexID;

                    mItemDelete[1].eName = CEnum.TagName.SDO_ServerIP;
                    mItemDelete[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mItemDelete[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

                    mItemDelete[2].eName = CEnum.TagName.SDO_ItemCode;
                    mItemDelete[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mItemDelete[2].oContent = iItemIndex;

                    mItemDelete[3].eName = CEnum.TagName.UserByID;
                    mItemDelete[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mItemDelete[3].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    this.backgroundWorkerDeleteGift.RunWorkerAsync(mItemDelete);

                    //CEnum.Message_Body[,] mDeleteResult = Operation_SDO.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text)), CEnum.ServiceKey.SDO_GIFTBOX_DELETE, mItemDelete);

                    //if (mDeleteResult[0, 0].oContent.Equals("SUCESS"))
                    //{
                    //    int iGiftPage = 0;

                    //    GetGiftBox(iUserIndexID, 1, out iGiftPage);

                    //    bGiftFirst = false;

                    //    if (iGiftPage <= 0)
                    //    {
                    //        PnlGiftPage.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        CmbGiftPage.Items.Clear();

                    //        for (int i = 0; i < iGiftPage; i++)
                    //        {
                    //            CmbGiftPage.Items.Add(i + 1);
                    //        }

                    //        CmbGiftPage.SelectedIndex = 0;
                    //        bGiftFirst = true;
                    //        PnlGiftPage.Visible = true;
                    //    }

                    //    MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgDels"));
                    //}
                    //else
                    //{
                    //    MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgDelf"));
                    //}
                }
                else
                {
                    LblItemDelete.Text = "";
                    PnlItemDelete.Visible = false;
                }
            }
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_SDO.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbServer = Operation_SDO.BuildCombox(mServerInfo, CmbServer);

            PnlInputCharacter.Visible = false;
            PnlnfoCharacter.Visible = false;
            PnlItemDelete.Visible = false;
            PnlAddGift.Visible = false;
            GrdAddGift.Visible = false;
            BtnClear.Enabled = false;
            PnlItemPage.Visible = false;
            PnlGiftPage.Visible = false;
            TbcResult.Visible = false;

            //��ӵ����б�
            mItemTable = new DataTable();
            mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo7"), typeof(string));
            mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo"), typeof(string));
            mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo1"), typeof(string));
            mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo2"), typeof(string));
            mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo3"), typeof(string));
            mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo4"), typeof(string));
            mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo5"), typeof(string));
            mItemTable.Columns.Add(config.ReadConfigValue("MSDO", "IC_Code_iteminfo6"), typeof(string));
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mGetResult = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_CHARACTERINFO_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnSearch.Enabled = true;
            this.Cursor = Cursors.Default;

            //��������ʾ
            if (mGetResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                TbcResult.Visible = false;
                //GrdCharacter.DataSource = null;
                MessageBox.Show(mGetResult[0, 0].oContent.ToString());
                return;
            }

            CmbServer.Enabled = false;
            TxtAccount.Enabled = false;


            TbcResult.Visible = true;

            iIndex = 0; //Ĭ��ѡ�е���

            CharacterInfo();
        }

        private void backgroundWorkerTabChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList paramList = (ArrayList)e.Argument;
            ArrayList resultList = new ArrayList();
            switch (paramList[0].ToString())
            {
                case "GetItemBox":
                    resultList.Clear();
                    resultList.Add("GetItemBox");
                    break;
                case "GetGiftBox":
                    resultList.Clear();
                    resultList.Add("GetGiftBox");
                    break;
                default:
                    e.Result = null;
                    return;
            }
            lock (typeof(C_Event.CSocketEvent))
            {
                resultList.Add(Operation_SDO.GetResult(tmp_ClientEvent, (CEnum.ServiceKey)paramList[2], (CEnum.Message_Body[])paramList[3]));
            }
            e.Result = resultList;
        }

        private void backgroundWorkerTabChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TbcResult.Enabled = true;
            this.Cursor = Cursors.Default;

            ArrayList resultList = (ArrayList)e.Result;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])resultList[1];
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            if (e.Result == null) return;
            lock (typeof(Operation_SDO))
            {
                int iPage = 0;
                switch (resultList[0].ToString())
                {
                    case "GetItemBox":
                        Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdItem, out iPage);
                        bItemFirst = false;

                        if (iPage <= 0)
                        {
                            PnlItemPage.Visible = false;
                        }
                        else
                        {
                            CmbItemPage.Items.Clear();

                            for (int i = 0; i < iPage; i++)
                            {
                                CmbItemPage.Items.Add(i + 1);
                            }

                            CmbItemPage.SelectedIndex = 0;
                            bItemFirst = true;
                            PnlItemPage.Visible = true;
                            
                        }
                        break;
                    case "GetGiftBox":
                        Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdGift, out iPage);
                        bGiftFirst = false;

                        if (iPage <= 0)
                        {
                            PnlGiftPage.Visible = false;
                        }
                        else
                        {
                            CmbGiftPage.Items.Clear();

                            for (int i = 0; i < iPage; i++)
                            {
                                CmbGiftPage.Items.Add(i + 1);
                            }

                            CmbGiftPage.SelectedIndex = 0;
                            bGiftFirst = true;
                            PnlGiftPage.Visible = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void backgroundWorkerAdd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_GIFTBOX_CREATE, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mSendResult = (CEnum.Message_Body[,])e.Result;
            if (mSendResult[0, 0].oContent.Equals("FAILURE") || mSendResult == null)
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgAddFail"));
                this.BtnAdd.Enabled = true;
                this.Cursor = Cursors.Default;
                return;
            }
            else
            {
                mItemTable.Clear();

                DataRow mItemRow = null;

                mItemRow = mItemTable.NewRow();
                if (radioButton1.Checked)
                {
                    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo7")] = ((ArrayList)(((ArrayList)CmbItem.Tag)[1]))[CmbItem.SelectedIndex].ToString();
                    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo")] = CmbType.Text;
                    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo1")] = CmbSort.Text;
                    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo2")] = CmbItem.Text;
                }
                else if (radioButton2.Checked)
                {
                    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo7")] = ((ArrayList)(((ArrayList)lstItem.Tag)[0]))[this.lstItem.SelectedIndex].ToString();
                    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo")] = "N/A";
                    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo1")] = "N/A";
                    mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo2")] = mItemInfo[lstItem.SelectedIndex, 3].oContent.ToString();
                }
                mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo3")] = DtpDate.Value.ToString();
                mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo4")] = TxtCount.Value.ToString();
                mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo5")] = TxtTitle.Text;
                mItemRow[config.ReadConfigValue("MSDO", "IC_Code_iteminfo6")] = TxtMemo.Text;

                mItemTable.Rows.Add(mItemRow);

                GrdAddGift.DataSource = mItemTable;

                int iGiftPage = 0;

                GetGiftBox(iUserIndexID, 1, out iGiftPage);

                bGiftFirst = false;

                if (iGiftPage <= 0)
                {
                    PnlGiftPage.Visible = false;
                }
                else
                {
                    CmbGiftPage.Items.Clear();

                    for (int i = 0; i < iGiftPage; i++)
                    {
                        CmbGiftPage.Items.Add(i + 1);
                    }

                    CmbGiftPage.SelectedIndex = 0;
                    bGiftFirst = true;
                    PnlGiftPage.Visible = true;
                }

                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgAddSucces"));
                //TbcResult.SelectedTab = TpgGift;
                this.BtnAdd.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void backgroundWorkerDeleteItem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_GIFTBOX_DELETE, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerDeleteItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mSendResult = (CEnum.Message_Body[,])e.Result;
            if (mSendResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_delFail"));
                this.BtnClear.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            else
            {
                mSelectTable = (DataTable)GrdAddGift.DataSource;

                mSelectTable.Rows[iSelectIndex].Delete();

                GrdAddGift.DataSource = mSelectTable;

                TxtCount.Value = 1;
                TxtTitle.Clear();
                TxtMemo.Clear();

                int iGiftPage = 0;

                GetGiftBox(iUserIndexID, 1, out iGiftPage);

                bGiftFirst = false;

                if (iGiftPage <= 0)
                {
                    PnlGiftPage.Visible = false;
                }
                else
                {
                    CmbGiftPage.Items.Clear();

                    for (int i = 0; i < iGiftPage; i++)
                    {
                        CmbGiftPage.Items.Add(i + 1);
                    }

                    CmbGiftPage.SelectedIndex = 0;
                    bGiftFirst = true;
                    PnlGiftPage.Visible = true;
                }
                this.BtnClear.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void backgroundWorkerDeleteGift_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_GIFTBOX_DELETE, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerDeleteGift_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mDeleteResult = (CEnum.Message_Body[,])e.Result;
            if (mDeleteResult[0, 0].oContent.Equals("SUCESS"))
            {
                this.TbcResult_SelectedIndexChanged(null, null);

                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgDels"));
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_MsgDelf"));
            }
        }

        private void backgroundWorkerSaveBase_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_CHARACTERINFO_UPDATE, (CEnum.Message_Body[])e.Argument);  
            } 
        }

        private void backgroundWorkerSaveBase_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnBaseSave.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] mPostResult = (CEnum.Message_Body[,])e.Result;

            if (mPostResult[0, 0].oContent.Equals("FAILURE"))
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_UpdateMsgf"));
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "IC_Code_UpdateMsgs"));
            }

            this.BtnSearch_Click(sender, e);
        }

        private void backgroundWorkerItemPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock(typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_ITEMSHOP_BYOWNER_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerItemPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbItemPage.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
         if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
         {
             MessageBox.Show(mResult[0, 0].oContent.ToString());
             return;
         }
         else
         {
             Operation_SDO.BuildDataTable(this.m_ClientEvent, mResult, GrdItem, out iOutPage);
         }


         //if (iOutPage <= 0)
         //{
         //    PnlItemPage.Visible = false;
         //}
         //else
         //{
         //    CmbItemPage.Items.Clear();

         //    for (int i = 0; i < iOutPage; i++)
         //    {
         //        CmbItemPage.Items.Add(i + 1);
         //    }

         //    bItemFirst = false;
         //    CmbItemPage.Text = strSelect;
         //    PnlItemPage.Visible = true;
             
         //}
         //if (iOutPage > 0)
         //{
         //    bItemFirst = true;
         //}
        }

        private void GetItemStatus()
        {
            dgvStatus.DataSource = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

            mContent[0].eName = CEnum.TagName.SDO_Account;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAccount.Text.Trim();

            mContent[1].eName = CEnum.TagName.SDO_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_SDO.GetItemAddr(mServerInfo, CmbServer.Text);

            this.backgroundWorkerStatusQuery.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerStatusQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_SDO.GetResult(tmp_ClientEvent, CEnum.ServiceKey.SDO_PFUNCTIONITEM_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerStatusQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TbcResult.Enabled = true;
            Cursor = Cursors.Default;
            int pg = 0;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                Operation_SDO.BuildDataTable(tmp_ClientEvent, mResult, dgvStatus, out pg);
            }
        }
    }
}