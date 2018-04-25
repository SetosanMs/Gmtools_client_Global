using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using C_Global;
using C_Event;
using Language;
namespace M_Audition
{
    [C_Global.CModuleAttribute("商城购物记录", "FrmShopBuylog", "商城购物记录[充值消费]", "AU Group")] 
    public partial class FrmShopBuylog : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iSort = 0;
        private int iPageCount = 0;
        private bool bFirst = false;
        private string result;

        private string AUServerIP = null;
        private string AuShopItemTable = null;
        private string AuShopReceiveSN = null;
        private string AuShopPresentID = null;
        private string AuShopItemName = null;
        private string AuShopBuytime = null;
        private string AuShopBuyzone = null;
        private string strorderID = null;
        private string strReciver = null;
        private string strPcode = null;
        private CEnum.Message_Body[,] ItemResult = null;
        private CEnum.Message_Body[,] ItemBuyResult = null;
        private CEnum.Message_Body[,] ItemDbResult = null;

        DataTable dgTable = new DataTable();
        DataTable dgTableDetail = new DataTable();
        DataTable dgTableWarehouse = new DataTable();

        DataTable dgSpacailItem = new DataTable();
        DataTable dgSpacaildbItem = new DataTable();
        DataTable dgUseitemInfo = new DataTable();

        public FrmShopBuylog()
        {
            InitializeComponent();
        }
        #region 自定义调用事件
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            //创建登录窗体
            FrmShopBuylog mModuleFrm = new FrmShopBuylog();
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
            this.Text = config.ReadConfigValue("MAU", "FSB_UI_FrmShopBuylog");
            this.BtnReset.Text = config.ReadConfigValue("MAU", "XF_UI_BtnReset");
            this.LblPage.Text = config.ReadConfigValue("MAU", "XF_UI_LblPage");
            this.GrpResult.Text = config.ReadConfigValue("MAU", "XF_UI_GrpResult");
            this.BtnSearch.Text = config.ReadConfigValue("MAU", "XF_UI_BtnSearch");
            this.LblName.Text = config.ReadConfigValue("MAU", "XF_UI_LblName");

            this.GrpSearch.Text = config.ReadConfigValue("MAU", "XF_UI_GrpSearch");
            this.lblstarttime.Text = config.ReadConfigValue("MAU", "XF_UI_lblstarttime");
            this.lblendtime.Text = config.ReadConfigValue("MAU", "XF_UI_lblendtime");
            this.LblSort.Text = config.ReadConfigValue("MAU", "FSB_UI_LblSort");
            this.labelDescription.Text = config.ReadConfigValue("MAU", "FSC_UI_labelDescription");
            this.textBoxDetail.Text = config.ReadConfigValue("MAU", "FSB_UI_textBoxDetail");


            this.CmbSort.Items.AddRange(new object[] {
            config.ReadConfigValue("MAU", "XF_Code_TypeS"),
            config.ReadConfigValue("MAU", "XF_Code_TypeR")
            });

        }


        #endregion
        private void FrmShopBuylog_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            CmbSort.SelectedIndex = 0;
            GrdResult.DataSource = null;
            PnlPage.Visible = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtName.Text.Trim().Length <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "CL_Code_msg1"));
                return;
            }
            GrdResult.DataSource = null;
            PnlPage.Visible = false;
            bFirst = false;

            //起始时间必须小于结束时间
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FSC_CODE_Msg1"));
                return;
            }
            ////开始时间不允许早于2007年4月21日
            //if (dateTimePickerStart.Value < DateTime.Parse("2007-4-21"))
            //{
            //    MessageBox.Show(config.ReadConfigValue("MAU", "FSB_CODE_Msg"));
            //    return;
            //}

            if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_Code_TypeS"))
                iSort = 1;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_Code_TypeR"))
                iSort = 2;


            CmbPage.Items.Clear();
            BtnSearch.Enabled = false;

            //构造查询条件
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.AuShop_pcategory;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = iSort;

            mContent[1].eName = CEnum.TagName.AuShop_username;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = TxtName.Text.Trim();

            mContent[2].eName = CEnum.TagName.AuShop_BeginDate;
            mContent[2].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[2].oContent = dateTimePickerStart.Value;

            mContent[3].eName = CEnum.TagName.AuShop_EndDate;
            mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[3].oContent = dateTimePickerEnd.Value;

            mContent[4].eName = CEnum.TagName.Index;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = 1;

            mContent[5].eName = CEnum.TagName.PageSize;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = Operation_Shop.iPageSize;

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_USERMPURCHASE_QUERY, (CEnum.Message_Body[])e.Argument);
               
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Shop.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
            LblSum.Text = config.ReadConfigValue("MAU", "CL_Code_sum") + Operation_Shop.Total;
            if (iPageCount <= 0)
            {
                PnlPage.Visible = false;
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }

                CmbPage.SelectedIndex = 0;
                bFirst = true;
                PnlPage.Visible = true;
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            CmbSort.SelectedIndex = 0;
            GrdResult.DataSource = null;
            
            TxtName.Clear();

        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {

                CmbPage.Enabled = false;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.AuShop_pcategory;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = iSort;

                mContent[1].eName = CEnum.TagName.AuShop_username;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtName.Text.Trim();

                mContent[2].eName = CEnum.TagName.AuShop_BeginDate;
                mContent[2].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[2].oContent = dateTimePickerStart.Value;

                mContent[3].eName = CEnum.TagName.AuShop_EndDate;
                mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[3].oContent = dateTimePickerEnd.Value;

                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Shop.iPageSize + 1; ;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_Shop.iPageSize;

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);
            }
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_USERMPURCHASE_QUERY, (CEnum.Message_Body[])e.Argument);

            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbPage.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }


            Operation_Shop.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
        }

        private void GrdResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && GrdResult.DataSource != null)
            {
                DataTable dt = ((DataTable)GrdResult.DataSource);

                strorderID = dt.Rows[e.RowIndex][0].ToString();
                strReciver = dt.Rows[e.RowIndex][3].ToString();
                AuShopItemName = dt.Rows[e.RowIndex][1].ToString();
                AuShopBuytime = dt.Rows[e.RowIndex][7].ToString();
                AuShopBuyzone = dt.Rows[e.RowIndex][8].ToString();
                TbcResult.SelectedIndex = 1;
                Readinfo();

            }
            else
            {
                return;
            }
        }

        private void Readinfo()
        {
            DataBuyresult.DataSource = null;
            DataBuyDetail.DataSource = null;
            dataGridView2.DataSource = null;
            BtnRefundment.Enabled = false;
            BtnRepeat.Enabled = false;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

            mContent[0].eName = CEnum.TagName.AuShop_orderid;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = int.Parse(strorderID);

            mContent[1].eName = CEnum.TagName.AuShop_RECVUSER;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = strReciver;


            lock (typeof(C_Event.CSocketEvent))
            {
                ItemResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_USERINTERGRAL_QUERY, mContent);

            }

            if (ItemResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(ItemResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                dgTableDetail = new DataTable();


                dgTableDetail.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Senduser"), typeof(string));
                dgTableDetail.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Reciveuser"), typeof(string));
                dgTableDetail.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ItemName"), typeof(string));
                dgTableDetail.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ItemPrice"), typeof(string));
                dgTableDetail.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Itemtimes"), typeof(string));
                dgTableDetail.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_gameBuytime"), typeof(string));
                dgTableDetail.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_PlayerGettime"), typeof(string));
                //dgTableDetail.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_RecDate"), typeof(string));

                dgTableWarehouse = new DataTable();

                dgTableWarehouse.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ReciveuserID"), typeof(string));
                dgTableWarehouse.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ItemName"), typeof(string));
                dgTableWarehouse.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Itemtimesout"), typeof(string));

                dgSpacailItem = new DataTable();
                dgSpacailItem.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Reciveuser"), typeof(string));
                dgSpacailItem.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ItemName"), typeof(string));
                dgSpacailItem.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ItemPrice"), typeof(string));
                dgSpacailItem.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Jine"), typeof(string));
                dgSpacailItem.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_gameBuytime"), typeof(string));

                dgSpacaildbItem = new DataTable();
                dgSpacaildbItem.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Reciveuser"), typeof(string));
                dgSpacaildbItem.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Msgshenyu"), typeof(string));
                dgSpacaildbItem.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Msgbuytotal"), typeof(string));
                dgSpacaildbItem.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Msgspelltotal"), typeof(string));


                dgUseitemInfo = new DataTable();
                dgUseitemInfo.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Reciveuser"), typeof(string));
                dgUseitemInfo.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ItemName"), typeof(string));
                dgUseitemInfo.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_MsgtotalBuytimes"), typeof(string));
                dgUseitemInfo.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_info"), typeof(string));
                dgUseitemInfo.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_infotime"), typeof(string));
                dgUseitemInfo.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_infoexptime"), typeof(string));

                if (ItemResult[0, 1].oContent.ToString() == "10001" && ItemResult[0, 1].eName == CEnum.TagName.AuShop_PCODE)
                {
                    CEnum.Message_Body[] mContentSpecialItem = new CEnum.Message_Body[5];

                    mContentSpecialItem[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                    mContentSpecialItem[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentSpecialItem[0].oContent = int.Parse(ItemResult[0, 14].oContent.ToString());

                    mContentSpecialItem[1].eName = CEnum.TagName.AuShop_ReceiveSN;
                    mContentSpecialItem[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentSpecialItem[1].oContent = int.Parse(ItemResult[0, 11].oContent.ToString());

                    mContentSpecialItem[2].eName = CEnum.TagName.AuShop_price;
                    mContentSpecialItem[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentSpecialItem[2].oContent = int.Parse(ItemResult[0, 2].oContent.ToString());

                    mContentSpecialItem[3].eName = CEnum.TagName.AuShop_PCODE;
                    mContentSpecialItem[3].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentSpecialItem[3].oContent = int.Parse(ItemResult[0, 1].oContent.ToString());

                    mContentSpecialItem[4].eName = CEnum.TagName.AuShop_buytime;
                    mContentSpecialItem[4].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                    mContentSpecialItem[4].oContent = DateTime.Parse(AuShopBuytime);


                    lock (typeof(C_Event.CSocketEvent))
                    {
                        ItemBuyResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_SPECIALAVATITEM_QUERY, mContentSpecialItem);

                    }

                    if (ItemBuyResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
        
                       // return;
                    }

                    try
                    {
                        DataRow dgRow = dgSpacailItem.NewRow();
                        dgRow[config.ReadConfigValue("MAU", "BD_Code_Reciveuser")] = ItemResult[0, 9].oContent.ToString();
                        dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemName")] = AuShopItemName;
                        dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemPrice")] = ItemResult[0, 2].oContent.ToString();
                        dgRow[config.ReadConfigValue("MAU", "BD_Code_Jine")] = ItemResult[0, 2].oContent.ToString();
                        dgRow[config.ReadConfigValue("MAU", "BD_Code_gameBuytime")] = AuShopBuytime;

                        dgSpacailItem.Rows.Add(dgRow);


                        DataRow dgRow1 = dgSpacaildbItem.NewRow();
                        dgRow1[config.ReadConfigValue("MAU", "BD_Code_Reciveuser")] = ItemBuyResult[0, 0].oContent.ToString();
                        dgRow1[config.ReadConfigValue("MAU", "BD_Code_Msgshenyu")] = ItemBuyResult[0, 5].oContent.ToString();
                        dgRow1[config.ReadConfigValue("MAU", "BD_Code_Msgbuytotal")] = ItemBuyResult[0, 4].oContent.ToString();
                        dgRow1[config.ReadConfigValue("MAU", "BD_Code_Msgspelltotal")] = ItemBuyResult[0, 6].oContent.ToString();

                        dgSpacaildbItem.Rows.Add(dgRow1);

                    }
                    catch
                    {
                    }
                    DataBuyresult.DataSource = BrowsePartResultInfo(ItemResult);
                    DataBuyDetail.DataSource = dgSpacailItem;
                    dataGridView2.DataSource = dgSpacaildbItem;
                    BtnSupply.Enabled = false;
                }
                else if (ItemResult[0, 1].oContent.ToString() == "2000" || ItemResult[0, 1].oContent.ToString() == "1999" || ItemResult[0, 1].oContent.ToString() == "3043" || 
                    ItemResult[0, 1].oContent.ToString() == "2721" || ItemResult[0, 1].oContent.ToString() == "1703" || ItemResult[0, 1].oContent.ToString() == "2396" ||
                    ItemResult[0, 1].oContent.ToString() == "1418" || ItemResult[0, 1].oContent.ToString() == "1809" && ItemResult[0, 1].eName == CEnum.TagName.AuShop_PCODE)
                {


                    AUServerIP = ItemResult[0, 14].oContent.ToString();
                    AuShopItemTable = ItemResult[0, 13].oContent.ToString();
                    AuShopReceiveSN = ItemResult[0, 11].oContent.ToString();
                    AuShopPresentID = ItemResult[0, 12].oContent.ToString();

                    //购买道具记录
                    CEnum.Message_Body[] mContentItem = new CEnum.Message_Body[3];

                    mContentItem[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                    mContentItem[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentItem[0].oContent = int.Parse(AUServerIP);

                    mContentItem[1].eName = CEnum.TagName.AuShop_ReceiveSN;
                    mContentItem[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentItem[1].oContent = int.Parse(AuShopReceiveSN);

                    mContentItem[2].eName = CEnum.TagName.AuShop_PresentID;
                    mContentItem[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentItem[2].oContent = int.Parse(AuShopPresentID);

                    lock (typeof(C_Event.CSocketEvent))
                    {
                        ItemBuyResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_AVATARECOVER_DETAIL_QUERY, mContentItem);

                    }

                    if (ItemBuyResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        // MessageBox.Show(ItemBuyResult[0, 0].oContent.ToString());

                    }

                    try
                    {
                            DataRow dgRow = dgTableDetail.NewRow();

                            dgRow[config.ReadConfigValue("MAU", "BD_Code_Senduser")] = ItemBuyResult[0, 2].oContent.ToString() + "(" + ItemBuyResult[0, 1].oContent.ToString() + ")";
                            dgRow[config.ReadConfigValue("MAU", "BD_Code_Reciveuser")] = ItemBuyResult[0, 4].oContent.ToString() + "(" + ItemBuyResult[0, 3].oContent.ToString() + ")";
                            dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemName")] = AuShopItemName + "(" + ItemBuyResult[0, 7].oContent.ToString() + ")";
                            dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemPrice")] = ItemResult[0, 2].oContent.ToString();
                            if (ItemResult[0, 3].eName == CEnum.TagName.AuShop_status && ItemResult[0, 3].oContent.ToString() == "0")
                            {
                                dgRow[config.ReadConfigValue("MAU", "BD_Code_Itemtimes")] = ItemResult[0, 4].oContent.ToString() + "+1";
                            }
                            else
                            {
                                dgRow[config.ReadConfigValue("MAU", "BD_Code_Itemtimes")] = ItemResult[0, 4].oContent.ToString();
                            }
                            dgRow[config.ReadConfigValue("MAU", "BD_Code_gameBuytime")] = ItemBuyResult[0, 6].oContent.ToString();


                            if (ItemBuyResult[0, 10].eName == CEnum.TagName.AuShop_udmark && ItemBuyResult[0, 10].oContent.ToString() == "1")
                            {
                                dgRow[config.ReadConfigValue("MAU", "BD_Code_PlayerGettime")] = "已领取";
                            }
                            else
                            {
                                dgRow[config.ReadConfigValue("MAU", "BD_Code_PlayerGettime")] = "未领取" + ItemBuyResult[0, 10].oContent.ToString();
                            }

                            //dgRow[config.ReadConfigValue("MAU", "BD_Code_RecDate")] = ItemBuyResult[j, 8].oContent.ToString();

                            dgTableDetail.Rows.Add(dgRow);

                    }
                    catch
                    { }


                    CEnum.Message_Body[] mContentOtherSpecialItem = new CEnum.Message_Body[4];

                    mContentOtherSpecialItem[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                    mContentOtherSpecialItem[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentOtherSpecialItem[0].oContent = int.Parse(ItemResult[0, 14].oContent.ToString());

                    mContentOtherSpecialItem[1].eName = CEnum.TagName.AuShop_ReceiveSN;
                    mContentOtherSpecialItem[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentOtherSpecialItem[1].oContent = int.Parse(ItemResult[0, 11].oContent.ToString());

                    mContentOtherSpecialItem[2].eName = CEnum.TagName.AuShop_PCODE;
                    mContentOtherSpecialItem[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentOtherSpecialItem[2].oContent = int.Parse(ItemResult[0, 1].oContent.ToString());

                    mContentOtherSpecialItem[3].eName = CEnum.TagName.AuShop_ItemTable;
                    mContentOtherSpecialItem[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContentOtherSpecialItem[3].oContent = ItemResult[0, 13].oContent.ToString();

                    lock (typeof(C_Event.CSocketEvent))
                    {
                        ItemDbResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_OTHERSPECIALAVATITEM_QUERY, mContentOtherSpecialItem);

                    }

                    if (ItemDbResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        //MessageBox.Show(ItemDbResult[0, 0].oContent.ToString());

                    }
                    else
                    {
                        try
                        {
                            if (ItemDbResult.GetLength(1) == 3)
                            {
                                DataRow dgRow1 = dgUseitemInfo.NewRow();
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_Reciveuser")] = "";
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_ItemName")] = AuShopItemName;
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_MsgtotalBuytimes")] = ItemDbResult[0, 1].oContent.ToString();
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_info")] = ItemDbResult[0, 2].oContent.ToString();
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_infotime")] = "";
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_infoexptime")] = "";
                                dgUseitemInfo.Rows.Add(dgRow1);

                            }
                            else
                            {
                                DataRow dgRow1 = dgUseitemInfo.NewRow();
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_Reciveuser")] = ItemDbResult[0, 0].oContent.ToString();
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_ItemName")] = AuShopItemName;
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_MsgtotalBuytimes")] = ItemDbResult[0, 4].oContent.ToString();
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_info")] = ItemDbResult[0, 3].oContent.ToString();
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_infotime")] = ItemDbResult[0, 9].oContent.ToString();
                                dgRow1[config.ReadConfigValue("MAU", "BD_Code_infoexptime")] = ItemDbResult[0, 6].oContent.ToString();

                                dgUseitemInfo.Rows.Add(dgRow1);
                            }
                        }

                        catch
                        {
 
                        }
                    }

                    DataBuyresult.DataSource = BrowsePartResultInfo(ItemResult);
                    DataBuyDetail.DataSource = dgTableDetail;
                    dataGridView2.DataSource = dgUseitemInfo;
                    BtnSupply.Enabled = false;
                }
                else
                {
                    #region 普通道具
                    for (int i = 0; i < ItemResult.GetLength(0); i++)
                    {
                        AUServerIP = ItemResult[i, 14].oContent.ToString();
                        AuShopItemTable = ItemResult[i, 13].oContent.ToString();
                        AuShopReceiveSN = ItemResult[i, 11].oContent.ToString();
                        AuShopPresentID = ItemResult[i, 12].oContent.ToString();

                        //购买道具记录
                        CEnum.Message_Body[] mContentItem = new CEnum.Message_Body[3];

                        mContentItem[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                        mContentItem[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[0].oContent = int.Parse(AUServerIP);

                        mContentItem[1].eName = CEnum.TagName.AuShop_ReceiveSN;
                        mContentItem[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[1].oContent = int.Parse(AuShopReceiveSN);

                        mContentItem[2].eName = CEnum.TagName.AuShop_PresentID;
                        mContentItem[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[2].oContent = int.Parse(AuShopPresentID);

                        lock (typeof(C_Event.CSocketEvent))
                        {
                            ItemBuyResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_AVATARECOVER_DETAIL_QUERY, mContentItem);

                        }

                        if (ItemBuyResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            // MessageBox.Show(ItemBuyResult[0, 0].oContent.ToString());

                        }
                        try
                        {
                            for (int j = 0; j < ItemBuyResult.GetLength(0); j++)
                            {

                                DataRow dgRow = dgTableDetail.NewRow();

                                dgRow[config.ReadConfigValue("MAU", "BD_Code_Senduser")] = ItemBuyResult[j, 2].oContent.ToString() + "(" + ItemBuyResult[j, 1].oContent.ToString() + ")";
                                dgRow[config.ReadConfigValue("MAU", "BD_Code_Reciveuser")] = ItemBuyResult[j, 4].oContent.ToString() + "(" + ItemBuyResult[j, 3].oContent.ToString() + ")";
                                dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemName")] = AuShopItemName + "(" + ItemBuyResult[j, 7].oContent.ToString() + ")";
                                dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemPrice")] = ItemResult[j, 2].oContent.ToString();
                                if (ItemResult[j, 3].eName == CEnum.TagName.AuShop_status && ItemResult[j, 3].oContent.ToString() == "0")
                                {
                                    dgRow[config.ReadConfigValue("MAU", "BD_Code_Itemtimes")] = ItemResult[j, 4].oContent.ToString() + "+1";
                                }
                                else
                                {
                                    dgRow[config.ReadConfigValue("MAU", "BD_Code_Itemtimes")] = ItemResult[j, 4].oContent.ToString();
                                }
                                dgRow[config.ReadConfigValue("MAU", "BD_Code_gameBuytime")] = ItemBuyResult[j, 6].oContent.ToString();


                                if (ItemBuyResult[j, 10].eName == CEnum.TagName.AuShop_udmark && ItemBuyResult[j, 10].oContent.ToString() != "1" && ItemBuyResult[j, 8].oContent.ToString() == "0000-00-00 00:00:00")
                                {
                                    dgRow[config.ReadConfigValue("MAU", "BD_Code_PlayerGettime")] = "未领取"+ ItemBuyResult[j, 10].oContent.ToString();
                                }
                                else
                                {
                                    dgRow[config.ReadConfigValue("MAU", "BD_Code_PlayerGettime")] = "已领取";
                                }

                                //dgRow[config.ReadConfigValue("MAU", "BD_Code_RecDate")] = ItemBuyResult[j, 8].oContent.ToString();

                                dgTableDetail.Rows.Add(dgRow);

                            }
                        }
                        catch
                        { }


                    }


                    for (int m = 0; m < ItemResult.GetLength(0); m++)
                    {
                        AUServerIP = ItemResult[m, 14].oContent.ToString();
                        AuShopItemTable = ItemResult[m, 13].oContent.ToString();
                        AuShopReceiveSN = ItemResult[m, 11].oContent.ToString();
                        AuShopPresentID = ItemResult[m, 12].oContent.ToString();
                        strPcode = ItemResult[m, 1].oContent.ToString();

                        CEnum.Message_Body[] mContentItemWare = new CEnum.Message_Body[5];

                        mContentItemWare[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                        mContentItemWare[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItemWare[0].oContent = int.Parse(AUServerIP);

                        mContentItemWare[1].eName = CEnum.TagName.AuShop_ReceiveSN;
                        mContentItemWare[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItemWare[1].oContent = int.Parse(AuShopReceiveSN);

                        mContentItemWare[2].eName = CEnum.TagName.AuShop_PresentID;
                        mContentItemWare[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItemWare[2].oContent = int.Parse(AuShopPresentID);

                        mContentItemWare[3].eName = CEnum.TagName.AuShop_ItemTable;
                        mContentItemWare[3].eTag = CEnum.TagFormat.TLV_STRING;
                        mContentItemWare[3].oContent = AuShopItemTable;

                        mContentItemWare[4].eName = CEnum.TagName.AuShop_PCODE;
                        mContentItemWare[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItemWare[4].oContent = int.Parse(strPcode);


                        lock (typeof(C_Event.CSocketEvent))
                        {
                            ItemDbResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_WAREHOUSE_QUERY, mContentItemWare);

                        }
                        if (ItemDbResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            //MessageBox.Show(ItemDbResult[0, 0].oContent.ToString());

                        }

                        try
                        {
                            for (int k = 0; k < ItemDbResult.GetLength(0); k++)
                            {

                                DataRow dgRow = dgTableWarehouse.NewRow();

                                dgRow[config.ReadConfigValue("MAU", "BD_Code_ReciveuserID")] = ItemDbResult[k, 0].oContent.ToString();
                                dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemName")] = AuShopItemName + "(" + ItemDbResult[k, 1].oContent.ToString() + ")";
                                dgRow[config.ReadConfigValue("MAU", "BD_Code_Itemtimesout")] = ItemDbResult[k, 3].oContent.ToString();


                                dgTableWarehouse.Rows.Add(dgRow);

                            }


                            if (dgTableDetail.Rows.Count <= 0)
                            {
                                BtnRefundment.Enabled = true;
                            }
                            else
                            {
                                BtnRefundment.Enabled = false;
                            }

                            if (ItemResult[0, 4].oContent.ToString() == "365")
                            {
                                BtnRepeat.Enabled = true;
                            }
                            else
                            {
                                BtnRepeat.Enabled = false;
                            }
                        }
                        catch
                        { }


                    }

                    DataBuyresult.DataSource = BrowsePartResultInfo(ItemResult);
                    DataBuyDetail.DataSource = dgTableDetail;
                    dataGridView2.DataSource = dgTableWarehouse;

                    if (ItemBuyResult[0, 10].eName == CEnum.TagName.AuShop_udmark && ItemBuyResult[0, 10].oContent.ToString() == "999" && ItemBuyResult[0, 8].oContent.ToString() == "0000-00-00 00:00:00")
                    {
                        BtnSupply.Enabled = true;
                    }
                    else
                    {
                        BtnSupply.Enabled = false;
                    }

                }

                #endregion 普通道具

            }

 
            



        }

        private DataTable BrowsePartResultInfo(CEnum.Message_Body[,] mResult)
        {
            try
            {
                dgTable = new DataTable();


                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Senduser"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Reciveuser"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ItemName"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ItemPrice"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Itemtimes"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Buytime"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Buyzone"), typeof(string));

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_Senduser")] = mResult[i, 6].oContent.ToString() + "(" + mResult[i, 8].oContent.ToString() + ")";
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_Reciveuser")] = mResult[i, 9].oContent.ToString() + "(" + mResult[i, 11].oContent.ToString() + ")";
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemName")] = AuShopItemName + "(" + mResult[i, 1].oContent.ToString() + ")"; ;
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemPrice")] = mResult[i, 2].oContent.ToString();
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_Itemtimes")] = mResult[i, 4].oContent.ToString();
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_Buytime")] = AuShopBuytime;
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_Buyzone")] = AuShopBuyzone;


                    dgTable.Rows.Add(dgRow);
                }
                return dgTable;
            }
            catch
            {
                return null;
            }
        }

        private void BtnRefundment_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确认是否要对这笔交易进行退款操作并且删除Present记录\n一旦确认，数据将不可恢复", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.AuShop_orderid;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = int.Parse(strorderID);

                mContent[1].eName = CEnum.TagName.AuShop_RECVUSER;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = strReciver;

                mContent[2].eName = CEnum.TagName.UserByID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                CEnum.Message_Body[,] mResult;

                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_USEROPERLOG_CREATE, mContent);

                }
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    CEnum.Message_Body[,] myResult = null;
                    for (int i = 0; i < ItemResult.GetLength(0); i++)
                    {
                        AUServerIP = ItemResult[i, 14].oContent.ToString();
                        AuShopItemTable = ItemResult[i, 13].oContent.ToString();
                        AuShopReceiveSN = ItemResult[i, 11].oContent.ToString();
                        AuShopPresentID = ItemResult[i, 12].oContent.ToString();
                        strPcode = ItemResult[i, 1].oContent.ToString();
                        //购买道具记录
                        CEnum.Message_Body[] mContentItem = new CEnum.Message_Body[6];

                        mContentItem[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                        mContentItem[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[0].oContent = int.Parse(AUServerIP);

                        mContentItem[1].eName = CEnum.TagName.AuShop_ReceiveSN;
                        mContentItem[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[1].oContent = int.Parse(AuShopReceiveSN);

                        mContentItem[2].eName = CEnum.TagName.AuShop_PresentID;
                        mContentItem[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[2].oContent = int.Parse(AuShopPresentID);

                        mContentItem[3].eName = CEnum.TagName.AuShop_ItemTable;
                        mContentItem[3].eTag = CEnum.TagFormat.TLV_STRING;
                        mContentItem[3].oContent = AuShopItemTable;

                        mContentItem[4].eName = CEnum.TagName.UserByID;
                        mContentItem[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                        mContentItem[5].eName = CEnum.TagName.AuShop_PCODE;
                        mContentItem[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[5].oContent = int.Parse(strPcode);



                        lock (typeof(C_Event.CSocketEvent))
                        {
                            myResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_ERRBUY_REFUND, mContentItem);

                        }


                    }
                    if (myResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(myResult[0, 0].oContent.ToString());
                        return;
                    }
                    if (myResult[0, 0].eName == CEnum.TagName.Status && myResult[0, 0].oContent.ToString() == "操作成功")
                    {
                        MessageBox.Show(myResult[0, 0].oContent.ToString());

                    }
                    else
                    {
                        MessageBox.Show("操作失败");

                    }
                }
            }
            else
            {
                return;
            }
        }

        private void BtnRepeat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确认是否要对这笔交易进行退款操作并且删除Present记录\n一旦确认，数据将不可恢复", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.AuShop_orderid;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = int.Parse(strorderID);

                mContent[1].eName = CEnum.TagName.AuShop_RECVUSER;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = strReciver;


                mContent[2].eName = CEnum.TagName.UserByID;
                mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                CEnum.Message_Body[,] mResult;

                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_USEROPERLOG_CREATE, mContent);

                }
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {

                    CEnum.Message_Body[,] myResult = null;
                    for (int i = 0; i < ItemResult.GetLength(0); i++)
                    {
                        AUServerIP = ItemResult[i, 14].oContent.ToString();
                        AuShopPresentID = ItemResult[i, 12].oContent.ToString();
                        //购买道具记录
                        CEnum.Message_Body[] mContentItem = new CEnum.Message_Body[3];

                        mContentItem[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                        mContentItem[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[0].oContent = int.Parse(AUServerIP);

                        mContentItem[1].eName = CEnum.TagName.AuShop_PresentID;
                        mContentItem[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[1].oContent = int.Parse(AuShopPresentID);

                        mContentItem[2].eName = CEnum.TagName.UserByID;
                        mContentItem[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                        mContentItem[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());





                        lock (typeof(C_Event.CSocketEvent))
                        {
                            myResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_REPEATBuy_REFUND, mContentItem);

                        }


                    }
                    if (myResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(myResult[0, 0].oContent.ToString());
                        return;
                    }
                    if (myResult[0, 0].eName == CEnum.TagName.Status && myResult[0, 0].oContent.ToString() == "操作成功")
                    {
                        MessageBox.Show(myResult[0, 0].oContent.ToString());

                    }
                    else
                    {
                        MessageBox.Show("操作失败");

                    }
                }
            }
            else
            {
                return;
            }
        }

        private void BtnSupply_Click(object sender, EventArgs e)
        {
            CEnum.Message_Body[,] myResult = null;
            for (int i = 0; i < ItemResult.GetLength(0); i++)
            {
                AUServerIP = ItemResult[i, 14].oContent.ToString();
                AuShopPresentID = ItemResult[i, 12].oContent.ToString();
                //购买道具记录
                CEnum.Message_Body[] mContentItem = new CEnum.Message_Body[3];

                mContentItem[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                mContentItem[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContentItem[0].oContent = int.Parse(AUServerIP);

                mContentItem[1].eName = CEnum.TagName.AuShop_PresentID;
                mContentItem[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContentItem[1].oContent = int.Parse(AuShopPresentID);

                mContentItem[2].eName = CEnum.TagName.UserByID;
                mContentItem[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContentItem[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());



                lock (typeof(C_Event.CSocketEvent))
                {
                    myResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_REPEATGet_REFUND, mContentItem);

                }
                if (myResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(myResult[0, 0].oContent.ToString());

                }
            }

            if (myResult[0, 0].eName == CEnum.TagName.Status && myResult[0, 0].oContent.ToString() == "操作成功")
            {
                MessageBox.Show(myResult[0, 0].oContent.ToString());

            }
            else
            {
                MessageBox.Show("操作失败");

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Austatus = ItemResult[0, 3].oContent.ToString();
                string strTimeType = ItemResult[0, 4].oContent.ToString();
                int intTimeType = 0;
                if (strTimeType == "7")
                {
                    intTimeType = 1;

                }
                else if (strTimeType == "30")
                {
                    intTimeType = 2;

                }
                else if (strTimeType == "365")
                {
                    intTimeType = 3;

                }
                CEnum.Message_Body[,] myResult = null;
                for (int i = 0; i < ItemResult.GetLength(0); i++)
                {
                    AUServerIP = ItemResult[i, 14].oContent.ToString();
                    AuShopItemTable = ItemResult[i, 13].oContent.ToString();
                    AuShopReceiveSN = ItemResult[i, 11].oContent.ToString();
                    AuShopPresentID = ItemResult[i, 12].oContent.ToString();
                    strPcode = ItemResult[i, 1].oContent.ToString();


                    //购买道具记录
                    CEnum.Message_Body[] mContentItem = new CEnum.Message_Body[8];

                    mContentItem[0].eName = CEnum.TagName.ServerInfo_GameDBID;
                    mContentItem[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentItem[0].oContent = int.Parse(AUServerIP);

                    mContentItem[1].eName = CEnum.TagName.AuShop_ReceiveSN;
                    mContentItem[1].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentItem[1].oContent = int.Parse(AuShopReceiveSN);

                    mContentItem[2].eName = CEnum.TagName.AuShop_PresentID;
                    mContentItem[2].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentItem[2].oContent = int.Parse(AuShopPresentID);

                    mContentItem[3].eName = CEnum.TagName.AuShop_ItemTable;
                    mContentItem[3].eTag = CEnum.TagFormat.TLV_STRING;
                    mContentItem[3].oContent = AuShopItemTable;

                    mContentItem[4].eName = CEnum.TagName.UserByID;
                    mContentItem[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentItem[4].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

                    mContentItem[5].eName = CEnum.TagName.AuShop_PCODE;
                    mContentItem[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentItem[5].oContent = int.Parse(strPcode);

                    mContentItem[6].eName = CEnum.TagName.AuShop_status;
                    mContentItem[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentItem[6].oContent = int.Parse(Austatus);

                    mContentItem[7].eName = CEnum.TagName.AuShop_ExpireType;
                    mContentItem[7].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContentItem[7].oContent = intTimeType;

                    lock (typeof(C_Event.CSocketEvent))
                    {
                        myResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_FillBuy_REFUND, mContentItem);

                    }


                }
                if (myResult[0, 0].eName == CEnum.TagName.Status && myResult[0, 0].oContent.ToString() == "操作成功")
                {
                    MessageBox.Show(myResult[0, 0].oContent.ToString());

                }
                else
                {
                    MessageBox.Show("操作失败");

                }
            }

            catch
            { }
        }

    }
}