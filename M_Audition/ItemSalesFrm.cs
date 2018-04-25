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
    [C_Global.CModuleAttribute("购买列表", "Frm_Shop_ItemSales", "AU Shop管理工具 -- 购买列表", "AU Group")] 
    public partial class Frm_Shop_ItemSales : Form
    {
        private CSocketEvent m_ClientEvent = null;
        private int iBuy = 0;
        private int iItem = 0;
        private string iSex = "all";
        private int iSort = 0;
        private string iGift = "n";
        private string iSend = "n";
        private int iPageCount = 0;
        private bool bFirst = false;
        public CEnum.Message_Body[,] mUserStat = null;

        public Frm_Shop_ItemSales()
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
            Frm_Shop_ItemSales mModuleFrm = new Frm_Shop_ItemSales();
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
            this.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_Frm_Shop_ItemSales");
            this.GrpSearch.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_GrpSearch");
            this.label7.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_label7");
            this.BtnReset.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_BtnReset");
            this.BtnSearch.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_BtnSearch");
            this.ChkSend.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_ChkSend");
            this.ChkGift.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_ChkGift");
            this.label6.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_label6");

            this.label5.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_label5");
            this.label3.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_label3");
            this.label2.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_label2");
            this.label1.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_label1");
            this.label10.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_label10");
            this.label9.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_label9");
            this.label8.Text = config.ReadConfigValue("MAUDITION", "FSI_UI_label8");
            this.CmbBuy.Items.AddRange(
                new object[]{
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbBuy1"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbBuy2")
                }
            );
            this.CmbSex.Items.AddRange(
                new object[]{
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSex1"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSex2"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSex3"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSex4")
                }
            );
            this.CmbSort.Items.AddRange(
                new object[]{
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSort1"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSort2")
                }
            );
            this.CmbItem.Items.AddRange(
                new object[]{
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem1"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem2"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem3"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem4"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem5"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem6"),
                    config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem7")
                    }
                    );

            
        }


        #endregion
 
        private void ItemSalesFrm_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            CmbBuy.SelectedIndex = 0;
            CmbItem.SelectedIndex = 0;
            CmbSex.SelectedIndex = 0;
            CmbSort.SelectedIndex = 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (CmbSort.Text == "" ||
                TxtName.Text == "" ||
                CmbItem.Text == "" ||
                CmbBuy.Text == "" ||
                CmbSex.Text == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAUDITION", "FSI_Code_Full"));
                return;
            }
                
            CmbPage.Items.Clear();
            //列表附值
            //switch (CmbSort.Text)
            //{
            //    case "购买者":
            //        iSort = 0;
            //        break;
            //    case "接受者":
            //        iSort = 1;
            //        break;
            //    default:
            //        iSort = 0;
            //        break;
            //}
            if (CmbSort.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSort1"))
                iSort = 0;
            else if (CmbSort.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSort2"))
                iSort = 1;
            else iSort = 0;
            //switch (CmbItem.Text)
            //{
            //    case "所有":
            //        iItem = 0;
            //        break;
            //    case "发型":
            //        iItem = 1;
            //        break;
            //    case "上衣":
            //        iItem = 2;
            //        break;
            //    case "下衣":
            //        iItem = 3;
            //        break;
            //    case "鞋子":
            //        iItem = 4;
            //        break;
            //    case "套装":
            //        iItem = 5;
            //        break;
            //    case "特殊道具":
            //        iItem = 6;
            //        break;
            //    default:
            //        iItem = 0;
            //        break;
            //}
            if (CmbItem.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem1"))
                iItem = 0;
            else if (CmbItem.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem2"))
                iItem = 1;
            else if (CmbItem.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem3"))
                iItem = 2;
            else if (CmbItem.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem4"))
                iItem = 3;
            else if (CmbItem.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem5"))
                iItem = 4;
            else if (CmbItem.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem6"))
                iItem = 5;
            else if (CmbItem.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbItem7"))
                iItem = 6;
            else iItem = 0;


            //switch (CmbBuy.Text)
            //{ 
            //    case "Ｍ币购买":
            //        iBuy = 0;
            //        break;
            //    case "Ｇ币购买":
            //        iBuy = 1;
            //        break;
            //    default:
            //        iBuy = 0;
            //        break;
            //}
            if (CmbBuy.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbBuy1"))
                iBuy = 0;
            else if (CmbBuy.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbBuy2"))
                iBuy = 1;
            else iBuy = 0;
            //switch (CmbSex.Text)
            //{
            //    case "所有":
            //        iSex = "full";
            //        break;
            //    case "男女共用":
            //        iSex = "all";
            //        break;
            //    case "男":
            //        iSex = "m";
            //        break;
            //    case "女":
            //        iSex = "f";
            //        break;
            //    default:
            //        iSex = "all";
            //        break;
            //}
            if (CmbSex.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSex1"))
                iSex = "full";
            else if (CmbSex.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSex2"))
                iSex = "all";
            else if (CmbSex.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSex3"))
                iSex = "m";
            else if (CmbSex.Text == config.ReadConfigValue("MAUDITION", "FSI_UI_CmbSex4"))
                iSex = "f";
            else iSex = "all";

            iGift = ChkGift.Checked ? "y" : "n";
            iSend = ChkSend.Checked ? "y" : "n";

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[11];

            mContent[0].eName = CEnum.TagName.AU_ServerIP;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = "61.152.150.205";

            mContent[1].eName = CEnum.TagName.AuShop_getusername;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            if (iSort == 0)
            {
                mContent[1].oContent = "";
            }
            else
            {
                mContent[1].oContent = TxtName.Text;
            }

            mContent[2].eName = CEnum.TagName.AuShop_username;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            if (iSort == 1)
            {
                mContent[2].oContent = "";
            }
            else
            {
                mContent[2].oContent = TxtName.Text;
            }

            mContent[3].eName = CEnum.TagName.AuShop_BeginDate;
            mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[3].oContent = DpkStar.Value;

            mContent[4].eName = CEnum.TagName.AuShop_EndDate;
            mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[4].oContent = DptStop.Value;

            mContent[5].eName = CEnum.TagName.AuShop_psex;
            mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[5].oContent = iSex;

            mContent[6].eName = CEnum.TagName.AuShop_ispresent;
            mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[6].oContent = iSend;

            mContent[7].eName = CEnum.TagName.AuShop_islover;
            mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[7].oContent = iGift;

            mContent[8].eName = CEnum.TagName.AuShop_pcategory;
            mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[8].oContent = iItem;

            mContent[9].eName = CEnum.TagName.Index;
            mContent[9].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[9].oContent = 1;

            mContent[10].eName = CEnum.TagName.PageSize;
            mContent[10].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[10].oContent = Operation_Shop.iPageSize;

            CEnum.Message_Body[,] mResult = null;
            CEnum.Message_Body[,] mResultSum = null;

            lock (typeof(C_Event.CSocketEvent))
            {
                //if (iBuy == 0)
                //{
                //    mResult = Operation_Shop.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, "61.152.150.205"), CEnum.ServiceKey.AUSHOP_USERMPURCHASE_QUERY, mContent);
                //    mResultSum = Operation_Shop.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, "61.152.150.205"), CEnum.ServiceKey.AUSHOP_USERMPURCHASE_SUM_QUERY, mContent);
                //}
                //else
                //{
                //    mResult = Operation_Shop.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, "61.152.150.205"), CEnum.ServiceKey.AUSHOP_USERGPURCHASE_QUERY, mContent);
                //    mResultSum = Operation_Shop.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, "61.152.150.205"), CEnum.ServiceKey.AUSHOP_USERGPURCHASE_SUM_QUERY, mContent);
                //}
            }

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            if (mResultSum[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Shop.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

            if (mResultSum[0, 0].oContent != null)
            {
                LblSum.Text = config.ReadConfigValue("MAUDITION", "FSI_Code_Total") + mResultSum[0, 0].oContent.ToString();
            }

            if (iPageCount <= 0)
            {
                PnlPage.Visible = false;
                lblPageCount.Text = "1";
            }
            else
            {
                for (int i = 0; i < iPageCount; i++)
                {
                    CmbPage.Items.Add(i + 1);
                }

                lblPageCount.Text = iPageCount.ToString();
                CmbPage.SelectedIndex = 0;
                bFirst = true;
                PnlPage.Visible = true;
            }

        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (bFirst)
            {
                lblCurrPage.Text = CmbPage.Text;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[11];

                mContent[0].eName = CEnum.TagName.AU_ServerIP;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = "61.152.150.205";

                mContent[1].eName = CEnum.TagName.AuShop_getusername;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                if (iSort == 0)
                {
                    mContent[1].oContent = "";
                }
                else
                {
                    mContent[1].oContent = TxtName.Text;
                }

                mContent[2].eName = CEnum.TagName.AuShop_username;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                if (iSort == 1)
                {
                    mContent[2].oContent = "";
                }
                else
                {
                    mContent[2].oContent = TxtName.Text;
                }

                mContent[3].eName = CEnum.TagName.AuShop_BeginDate;
                mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[3].oContent = DpkStar.Value;

                mContent[4].eName = CEnum.TagName.AuShop_EndDate;
                mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[4].oContent = DptStop.Value;

                mContent[5].eName = CEnum.TagName.AuShop_psex;
                mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[5].oContent = iSex;

                mContent[6].eName = CEnum.TagName.AuShop_ispresent;
                mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[6].oContent = iSend;

                mContent[7].eName = CEnum.TagName.AuShop_islover;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = iGift;

                mContent[8].eName = CEnum.TagName.AuShop_pcategory;
                mContent[8].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[8].oContent = iItem;

                mContent[9].eName = CEnum.TagName.Index;
                mContent[9].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[9].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Card.iPageSize + 1;

                mContent[10].eName = CEnum.TagName.PageSize;
                mContent[10].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[10].oContent = Operation_Card.iPageSize;

                CEnum.Message_Body[,] mResult = null;

                lock (typeof(C_Event.CSocketEvent))
                {
                    if (iBuy == 0)
                    {
                        mResult = Operation_Shop.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, "61.152.150.205"), CEnum.ServiceKey.AUSHOP_USERMPURCHASE_QUERY, mContent);
                    }
                    else
                    {
                        mResult = Operation_Shop.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, "61.152.150.205"), CEnum.ServiceKey.AUSHOP_USERGPURCHASE_QUERY, mContent);
                    }

                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }
                }

                Operation_Shop.BuildDataTable(m_ClientEvent.GetSocket(m_ClientEvent, "61.152.150.205"), mResult, GrdResult, out iPageCount);
            }
            else
            {
                lblCurrPage.Text = "1";
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            CmbBuy.SelectedIndex = 0;
            CmbItem.SelectedIndex = 0;
            CmbSex.SelectedIndex = 0;
            CmbSort.SelectedIndex = 0;

            CmbPage.Items.Clear();

            TxtName.Clear();
            ChkGift.Checked = false;
            ChkSend.Checked = false;
        }

        private void GrdResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            try
            {
                if (e.ColumnIndex == 4)
                {
                    DataTable mTable = (DataTable)GrdResult.DataSource;

                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];

                    mContent[0].eName = CEnum.TagName.AuShop_userid;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = mTable.Rows[e.RowIndex][4].ToString();

                    mContent[1].eName = CEnum.TagName.AU_ServerIP;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = "61.152.150.205";

                    lock (typeof(C_Event.CSocketEvent))
                    {
                        mUserStat = Operation_Shop.GetResult(m_ClientEvent.GetSocket(m_ClientEvent, "61.152.150.205"), CEnum.ServiceKey.AUSHOP_USERINTERGRAL_QUERY, mContent);
                    }

                    if (mUserStat[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mUserStat[0, 0].oContent.ToString());
                        return;
                    }

                    UserstatFrm mUserStatFrm = new UserstatFrm(mUserStat, m_ClientEvent);
                    //mUserStatFrm.MdiParent = this.MdiParent;
                    mUserStatFrm.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show(config.ReadConfigValue("MAUDITION", "FSI_Code_InputName"));
            }
        }
    }
}