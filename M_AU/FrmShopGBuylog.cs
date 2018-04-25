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
    [C_Global.CModuleAttribute("商城购物记录", "FrmShopGBuylog", "商城购物记录[充值消费]", "AU Group")] 
    public partial class FrmShopGBuylog : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iSort = 0;
        private int iPageCount = 0;
        private bool bFirst = false;
        private string result;

        public FrmShopGBuylog()
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
            FrmShopGBuylog mModuleFrm = new FrmShopGBuylog();
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
            this.Text = config.ReadConfigValue("MAU", "FSB_UI_FrmGShopBuylog");
            this.BtnReset.Text = config.ReadConfigValue("MAU", "XF_UI_BtnReset");
            this.LblPage.Text = config.ReadConfigValue("MAU", "XF_UI_LblPage");
            this.GrpResult.Text = config.ReadConfigValue("MAU", "XF_UI_GrpResult");
            this.BtnSearch.Text = config.ReadConfigValue("MAU", "XF_UI_BtnSearch");
            this.LblName.Text = config.ReadConfigValue("MAU", "XF_UI_LblName");

            this.GrpSearch.Text = config.ReadConfigValue("MAU", "XF_UI_GrpSearch");
            this.lblstarttime.Text = config.ReadConfigValue("MAU", "XF_UI_lblstarttime");
            this.lblendtime.Text = config.ReadConfigValue("MAU", "XF_UI_lblendtime");
            this.LblSort.Text = config.ReadConfigValue("MAU", "FSB_UI_LblSort");
            //this.labelDescription.Text = config.ReadConfigValue("MAU", "FSC_UI_labelDescription");
            //this.textBoxDetail.Text = config.ReadConfigValue("MAU", "FSB_UI_textBoxDetail");


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
                e.Result = Operation_Shop.GetResult(this.m_ClientEvent, CEnum.ServiceKey.AUSHOP_USERGPURCHASE_QUERY, (CEnum.Message_Body[])e.Argument);
               
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

        private void GrdResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}