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


namespace M_Audition
{
    public partial class FrmMBuyLogDetail : Form
    {
        public FrmMBuyLogDetail(CSocketEvent m_event, string strord,string _strReciver,string _Itemname,string _Buytime,string _Buyzone)
        {
            InitializeComponent();
            this.m_ClientEvent = m_event;
            strorderID = strord;
            strReciver = _strReciver;
            AuShopItemName = _Itemname;
            AuShopBuytime = _Buytime;
            AuShopBuyzone = _Buyzone;
            
        }


        private CSocketEvent m_ClientEvent = null;

        private string strorderID = null;
        private string strReciver = null;
        private CEnum.Message_Body[,] ItemResult = null;
        private CEnum.Message_Body[,] ItemBuyResult = null;
        private CEnum.Message_Body[,] ItemDbResult = null;
        private string AUServerIP = null;
        private string AuShopItemTable = null;
        private string AuShopReceiveSN = null;
        private string AuShopPresentID = null;
        private string AuShopItemName = null;
        private string AuShopBuytime = null;
        private string AuShopBuyzone = null;

        private int iPageCount = 0;
        private int iPageCount1 = 0;
        private int iPageCount2 = 0;
        DataTable dgTable = new DataTable();

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
            //this.Text = config.ReadConfigValue("MAU", "FSB_UI_FrmShopBuylog");

        }


        #endregion


        private void FrmMBuyLogDetail_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

            mContent[0].eName = CEnum.TagName.AuShop_orderid;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = int.Parse(strorderID);

            mContent[1].eName = CEnum.TagName.AuShop_RECVUSER;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = strReciver;

            this.backgroundWorkerLoad.RunWorkerAsync(mContent);

            

        }

        private void backgroundWorkerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                ItemResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_USERINTERGRAL_QUERY, (CEnum.Message_Body[])e.Argument);

            }

            if (ItemResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(ItemResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                AUServerIP=ItemResult[0, 14].oContent.ToString();
                AuShopItemTable=ItemResult[0, 13].oContent.ToString();
                AuShopReceiveSN=ItemResult[0, 11].oContent.ToString();
                AuShopPresentID = ItemResult[0, 12].oContent.ToString();
            }
            //¹ºÂòµÀ¾ß¼ÇÂ¼
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = int.Parse(AUServerIP);

            mContent[1].eName = CEnum.TagName.AuShop_ReceiveSN;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = int.Parse(AuShopReceiveSN);

            mContent[2].eName = CEnum.TagName.AuShop_PresentID;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = int.Parse(AuShopPresentID);

            lock (typeof(C_Event.CSocketEvent))
            {
                ItemBuyResult = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_AVATARECOVER_DETAIL_QUERY, mContent);

            }
            if (ItemBuyResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(ItemBuyResult[0, 0].oContent.ToString());
                return;
            }
        }

        private void backgroundWorkerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            GrdResult.DataSource = BrowsePartResultInfo(ItemResult);

            DataBuyDetail.DataSource = BrowseBuyInfo(ItemBuyResult);


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

        private DataTable BrowseBuyInfo(CEnum.Message_Body[,] mResult)
        {
            try
            {
                dgTable = new DataTable();


                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Senduser"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Reciveuser"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ItemName"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_ItemPrice"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_Itemtimes"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_gameBuytime"), typeof(string));
                dgTable.Columns.Add(config.ReadConfigValue("MAU", "BD_Code_PlayerGettime"), typeof(string));

                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow dgRow = dgTable.NewRow();
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_Senduser")] = mResult[i, 2].oContent.ToString() + "(" + mResult[i, 1].oContent.ToString() + ")";
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_Reciveuser")] = mResult[i, 4].oContent.ToString() + "(" + mResult[i, 3].oContent.ToString() + ")";
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemName")] = mResult[i, 9].oContent.ToString() + "(" + mResult[i, 7].oContent.ToString() + ")";
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemPrice")] = mResult[i, 10].oContent.ToString();
                    if (ItemResult[i, 3].eName == CEnum.TagName.AuShop_status && ItemResult[i, 3].oContent.ToString() == "0")
                    {
                        dgRow[config.ReadConfigValue("MAU", "BD_Code_Itemtimes")] = ItemResult[i, 4].oContent.ToString() + "+1";
                    }
                    else
                    {
                        dgRow[config.ReadConfigValue("MAU", "BD_Code_Itemtimes")] = ItemResult[i, 4].oContent.ToString();
                    }
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_gameBuytime")] = mResult[i, 6].oContent.ToString();
                    dgRow[config.ReadConfigValue("MAU", "BD_Code_PlayerGettime")] = mResult[i, 8].oContent.ToString();


                    dgTable.Rows.Add(dgRow);
                }
                return dgTable;
            }
            catch
            {
                return null;
            }
        }

        private DataTable BrowseDbInfo(CEnum.Message_Body[,] mResult)
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
                dgRow[config.ReadConfigValue("MAU", "BD_Code_Senduser")] = mResult[i, 0].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "BD_Code_Reciveuser")] = mResult[i, 0].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemName")] = mResult[i, 0].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "BD_Code_ItemPrice")] = mResult[i, 0].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "BD_Code_Itemtimes")] = mResult[i, 0].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "BD_Code_Buytime")] = mResult[i, 0].oContent.ToString();
                dgRow[config.ReadConfigValue("MAU", "BD_Code_Buyzone")] = mResult[i, 0].oContent.ToString();


                dgTable.Rows.Add(dgRow);
            }
            return dgTable;
        }

        private void dividerPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}