using System;
using System.Collections.Generic;
using System.Collections;
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
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("用户充值记录", "Frm_Shop_CardList", "用户充值记录[充值消费]", "AU Group")] 
    public partial class Frm_Shop_CardList : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iSort = 1;
        private int iPageCount = 0;
        private bool bFirst = false;

        public Frm_Shop_CardList()
        {
            InitializeComponent();
        }

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
            this.Text = config.ReadConfigValue("MAU", "FSC_UI_Frm_Shop_CardList ");
            this.GrpSearch.Text = config.ReadConfigValue("MAU", "FSC_UI_GrpSearch");
            this.labelStartDate.Text = config.ReadConfigValue("MAU", "FSC_UI_labelStartDate");
            this.labelEndDate.Text = config.ReadConfigValue("MAU", "FSC_UI_labelEndDate");
            this.BtnReset.Text = config.ReadConfigValue("MAU", "FSC_UI_BtnReset");
            this.BtnSearch.Text = config.ReadConfigValue("MAU", "FSC_UI_BtnSearch");
            this.LblName.Text = config.ReadConfigValue("MAU", "FSC_UI_LblName");
            this.LblSort.Text = config.ReadConfigValue("MAU", "FSC_UI_LblSort");

            this.GrpResult.Text = config.ReadConfigValue("MAU", "FSC_UI_GrpResult");
            this.LblPage.Text = config.ReadConfigValue("MAU", "FSC_UI_LblPage");
            this.labelDescription.Text = config.ReadConfigValue("MAU", "FSC_UI_labelDescription");
            this.textBoxDetail.Text = config.ReadConfigValue("MAU", "FSC_UI_textBoxDetail");


            this.CmbSort.Items.AddRange(new object[] {
            config.ReadConfigValue("MAU", "FSC_UI_CardType4"),
                config.ReadConfigValue("MAU", "FSC_UI_CardType1"),
            config.ReadConfigValue("MAU", "FSC_UI_CardType2"),
            config.ReadConfigValue("MAU", "FSC_UI_CardType3")
            });

        }


        #endregion

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
            Frm_Shop_CardList mModuleFrm = new Frm_Shop_CardList();
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

        private void Frm_Shop_CardList_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            CmbSort.SelectedIndex = 0;
            GrdResult.DataSource = null;
            PnlPage.Visible = false;
            LblSum.Text = "";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorkerPageChanged.IsBusy)
            {
                return;
            }
            bFirst = false;
            GrdResult.DataSource = null;
            PnlPage.Visible = false;
            LblSum.Text = "";
            //条件限制
            if (TxtName.Text.Trim().Length <= 0 || CmbSort.Text.Trim().Length <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "CL_Code_Msginput"));
                return;
            }

            //起始时间必须小于结束时间
            if(dateTimePickerStart.Value>dateTimePickerEnd.Value)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FSC_CODE_Msg1"));
                return;
            }

            //起始时间必须大于2005年
            if (dateTimePickerStart.Value.Year < 2005)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FSC_CODE_Msg2"));
                return;
            }

            //查询的时间间隔不得大于1个月
            if (dateTimePickerStart.Value.AddDays(93) < dateTimePickerEnd.Value)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FSC_CODE_Msg4"));
                return;
            }



            CmbPage.Items.Clear();

            LblSum.Text = "";
            //获取查询类型

            //switch (CmbSort.Text)
            //{
                
            //    case config.ReadConfigValue("MAU", "CL_Code_yika"):
            //        iSort = 1;
            //        break;
            //    case config.ReadConfigValue("MAU", "CL_Code_xiuxian"):
            //        iSort = 2;
            //        break;
            //    default:
            //        iSort = 1;
            //        break;
            //}

            if (CmbSort.Text == config.ReadConfigValue("MAU", "FSC_UI_CardType1"))
                iSort = 1;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "FSC_UI_CardType2"))
                iSort = 2;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "FSC_UI_CardType3"))
                iSort = 3;
            else iSort = 0;

            BtnSearch.Enabled = false;
            Cursor = Cursors.AppStarting;
            
            //构造查询条件
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.CARD_username;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtName.Text.Trim();

            mContent[1].eName = CEnum.TagName.CARD_PayStartDate;
            mContent[1].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[1].oContent = dateTimePickerStart.Value;

            mContent[2].eName = CEnum.TagName.CARD_PayStopDate;
            mContent[2].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[2].oContent = dateTimePickerEnd.Value;

            mContent[3].eName = CEnum.TagName.CARD_ActionType;
            mContent[3].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[3].oContent = iSort;

            mContent[4].eName = CEnum.TagName.PageSize;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = Operation_Card.iPageSize;

            mContent[5].eName = CEnum.TagName.Index;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = 1;

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);

            //CEnum.Message_Body[,] mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCHARGEDETAIL_QUERY, mContent);

            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

            //if (iPageCount <= 0)
            //{
            //    PnlPage.Visible = false;
            //}
            //else
            //{
            //    for (int i = 0; i < iPageCount; i++)
            //    {
            //        CmbPage.Items.Add(i + 1);
            //    }

            //    CmbPage.SelectedIndex = 0;
            //    bFirst = true;
            //    PnlPage.Visible = true;
            //}

            //CEnum.Message_Body[,] mResultSum = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERDETAIL_SUM_QUERY, mContent);

            //if (mResultSum[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //LblSum.Text = config.ReadConfigValue("MAU", "CL_Code_sum") + mResultSum[0, 0].oContent.ToString();
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bFirst)
            {
                CmbPage.Enabled = false;
                GrdResult.DataSource = null;
                Cursor = Cursors.AppStarting;
                //构造查询条件
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

                mContent[0].eName = CEnum.TagName.CARD_ActionType;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = iSort;

                mContent[1].eName = CEnum.TagName.CARD_PayStartDate;
                mContent[1].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[1].oContent = dateTimePickerStart.Value;

                mContent[2].eName = CEnum.TagName.CARD_username;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = TxtName.Text;

                mContent[3].eName = CEnum.TagName.CARD_PayStopDate;
                mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[3].oContent = dateTimePickerEnd.Value;

                mContent[4].eName = CEnum.TagName.Index;
                mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[4].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Card.iPageSize + 1;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = Operation_Card.iPageSize;

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);

                //CEnum.Message_Body[,] mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCHARGEDETAIL_QUERY, mContent);

                //Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
            }
        }


        private void BtnReset_Click(object sender, EventArgs e)
        {
            GrdResult.DataSource = null;

            CmbSort.SelectedIndex = 0;
            //TxtCard.Clear();
            TxtName.Clear();
            //TxtPwd.Clear();
            CmbPage.Items.Clear();
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList resultList = new ArrayList();
            lock (typeof(C_Event.CSocketEvent))
            {
                resultList.Add(Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCHARGEDETAIL_QUERY, (CEnum.Message_Body[])e.Argument));
                //resultList.Add(Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERDETAIL_SUM_QUERY, (CEnum.Message_Body[])e.Argument));
                e.Result = resultList;

               
            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])(((ArrayList)e.Result)[0]);
            //CEnum.Message_Body[,] mResultSum = (CEnum.Message_Body[,])(((ArrayList)e.Result)[1]);
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);

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
            //if (mResultSum[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            LblSum.Text = config.ReadConfigValue("MAU", "CL_Code_sum") + Operation_Card.Total;
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCHARGEDETAIL_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbPage.Enabled = true;
            Cursor = Cursors.Default;

            Operation_Card.BuildDataTable(this.m_ClientEvent, (CEnum.Message_Body[,])e.Result, GrdResult, out iPageCount);
        }

    }
}