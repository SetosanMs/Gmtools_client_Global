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
    [C_Global.CModuleAttribute("用户消费记录", "Frm_Shop_ConsumeList", "用户消费记录[充值消费]", "AU Group")] 
    public partial class Frm_Shop_ConsumeList : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private int iSort = 0;
        private int iPageCount = 0;
        private bool bFirst = false;
        private string result;
        public Frm_Shop_ConsumeList()
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
            this.Text = config.ReadConfigValue("MAU", "XF_UI_Frm_Shop_ConsumeList");
            this.BtnReset.Text = config.ReadConfigValue("MAU", "XF_UI_BtnReset");
            this.LblPage.Text = config.ReadConfigValue("MAU", "XF_UI_LblPage");
            this.GrpResult.Text = config.ReadConfigValue("MAU", "XF_UI_GrpResult");
            this.BtnSearch.Text = config.ReadConfigValue("MAU", "XF_UI_BtnSearch");
            this.LblName.Text = config.ReadConfigValue("MAU", "XF_UI_LblName");

            this.GrpSearch.Text = config.ReadConfigValue("MAU", "XF_UI_GrpSearch");
            this.lblstarttime.Text = config.ReadConfigValue("MAU", "XF_UI_lblstarttime");
            this.lblendtime.Text = config.ReadConfigValue("MAU", "XF_UI_lblendtime");
            this.LblSort.Text = config.ReadConfigValue("MAU", "XF_UI_LblSort");
            this.labelDescription.Text = config.ReadConfigValue("MAU", "FSC_UI_labelDescription");
            this.textBoxDetail.Text = config.ReadConfigValue("MAU", "FSC_UI_textBoxDetail");



            this.CmbSort.Items.AddRange(new object[] {
            config.ReadConfigValue("MAU", "XF_UI_Type15"),
            config.ReadConfigValue("MAU", "XF_UI_Type1"),
            config.ReadConfigValue("MAU", "XF_UI_Type2"),
            config.ReadConfigValue("MAU", "XF_UI_Type3"),
            config.ReadConfigValue("MAU", "XF_UI_Type4"),
            config.ReadConfigValue("MAU", "XF_UI_Type5"),
            config.ReadConfigValue("MAU", "XF_UI_Type6"),
            config.ReadConfigValue("MAU", "XF_UI_Type7"),
            config.ReadConfigValue("MAU", "XF_UI_Type8"),
            config.ReadConfigValue("MAU", "XF_UI_Type9"),
            config.ReadConfigValue("MAU", "XF_UI_Type10"),
            config.ReadConfigValue("MAU", "XF_UI_Type11"),
            config.ReadConfigValue("MAU", "XF_UI_Type12"),
            config.ReadConfigValue("MAU", "XF_UI_Type13"),
            config.ReadConfigValue("MAU", "XF_UI_Type14")
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
            Frm_Shop_ConsumeList mModuleFrm = new Frm_Shop_ConsumeList();
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

        private void Frm_Shop_ConsumeList_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            CmbSort.SelectedIndex = 0;
            GrdResult.DataSource = null;
            PnlPage.Visible = false;
            LblSum.Text = "";
        }
//        金币消费明细
//休闲币消费明细
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorkerPageChanged.IsBusy)
            {
                return;
            }
            if (TxtName.Text.Trim().Length <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "CL_Code_msg1"));
                return;
            }
            GrdResult.DataSource = null;
            PnlPage.Visible = false;
            LblSum.Text = "";
            bFirst = false;

            //起始时间必须小于结束时间
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
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
            if (dateTimePickerStart.Value.AddDays(31) < dateTimePickerEnd.Value)
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FSC_CODE_Msg3"));
                return;
            }


            //获取查询类型

            //switch (CmbSort.Text)
            //{
            //    case "金币消费明细":
            //        iSort = 1;
            //        break;
            //    case "休闲币消费明细":
            //        iSort = 2;
            //        break;
            //    default:
            //        iSort = 1;
            //        break;
            //}
            //if (CmbSort.Text == config.ReadConfigValue("MAU", "CL_Code_sortjinbi"))
            //    iSort = 1;
            //else if (CmbSort.Text == config.ReadConfigValue("MAU", "CL_Code_sortxiuxianbi"))
            //    iSort = 2;
            //else iSort = 1;
            if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type1"))
                iSort = 1;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type2"))
                iSort = 2;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type3"))
                iSort = 3;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type4"))
                iSort = 4;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type5"))
                iSort = 5;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type6"))
                iSort = 6;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type7"))
                iSort = 7;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type8"))
                iSort = 8;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type9"))
                iSort = 9;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type10"))
                iSort = 10;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type11"))
                iSort = 11;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type12"))
                iSort = 12;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type13"))
                iSort = 13;
            else if (CmbSort.Text == config.ReadConfigValue("MAU", "XF_UI_Type14"))
                iSort = 14;
            else iSort = 0;
            LblSum.Text = "";
            CmbPage.Items.Clear();
            BtnSearch.Enabled = false;
            Cursor = Cursors.AppStarting;

            //构造查询条件
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            mContent[0].eName = CEnum.TagName.CARD_ActionType;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = iSort;

            mContent[1].eName = CEnum.TagName.CARD_username;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = TxtName.Text.Trim();

            mContent[2].eName = CEnum.TagName.CARD_PayStartDate;
            mContent[2].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[2].oContent = dateTimePickerStart.Value;

            mContent[3].eName = CEnum.TagName.CARD_PayStopDate;
            mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
            mContent[3].oContent = dateTimePickerEnd.Value;

            mContent[4].eName = CEnum.TagName.Index;
            mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[4].oContent = 1;

            mContent[5].eName = CEnum.TagName.PageSize;
            mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[5].oContent = Operation_Card.iPageSize;

            this.backgroundWorkerSearch.RunWorkerAsync(mContent);

            //CEnum.Message_Body[,] mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCONSUME_QUERY, mContent);

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
            //CEnum.Message_Body[,] mResultSum = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCONSUME_SUM_QUERY, mContent);

            //if (mResultSum[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}

            //LblSum.Text = config.ReadConfigValue("MAU", "CL_Code_txtsum") + mResultSum[0, 0].oContent.ToString();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            CmbSort.SelectedIndex = 0;
            GrdResult.DataSource = null;
            buttonSaveAS.Enabled = false;
            TxtName.Clear();
            CmbPage.Items.Clear();
        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (bFirst)
                {
                    CmbPage.Enabled = false;
                    Cursor = Cursors.AppStarting;
                    GrdResult.DataSource = null;
                    
                    //构造查询条件
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[7];

                    mContent[0].eName = CEnum.TagName.CARD_ActionType;
                    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[0].oContent = iSort;

                    mContent[1].eName = CEnum.TagName.CARD_username;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[1].oContent = TxtName.Text.Trim();

                    mContent[2].eName = CEnum.TagName.CARD_PayStartDate;
                    mContent[2].eTag = CEnum.TagFormat.TLV_DATE;
                    mContent[2].oContent = dateTimePickerStart.Value;

                    mContent[3].eName = CEnum.TagName.CARD_PayStopDate;
                    mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                    mContent[3].oContent = dateTimePickerEnd.Value;

                    mContent[4].eName = CEnum.TagName.Index;
                    mContent[4].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[4].oContent = 1;

                    mContent[5].eName = CEnum.TagName.Index;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = (int.Parse(CmbPage.Text) - 1) * Operation_Card.iPageSize + 1;

                    mContent[6].eName = CEnum.TagName.PageSize;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = Operation_Card.iPageSize;

                    backgroundWorkerPageChanged.RunWorkerAsync(mContent);
                    //CEnum.Message_Body[,] mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCONSUME_QUERY, mContent);

                    //Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
                }
          
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList resultList = new ArrayList();
            lock (typeof(C_Event.CSocketEvent))
            {
                resultList.Add( Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCONSUME_QUERY, (CEnum.Message_Body[])e.Argument));
                //resultList.Add(Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCONSUME_SUM_QUERY, (CEnum.Message_Body[])e.Argument));
            }
            e.Result = resultList;
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnSearch.Enabled = true;
            Cursor = Cursors.Default;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])(((ArrayList)e.Result)[0]);
           // CEnum.Message_Body[,] mResultSum = (CEnum.Message_Body[,])(((ArrayList)e.Result)[1]);
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }

            Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, GrdResult, out iPageCount);
            for (int i = 0; i < mResult.GetLength(0); i++)
            {
                for (int j = 0; j < mResult.GetLength(1); j++)
                {
                    if (mResult[i, j].eName == CEnum.TagName.PageCount)
                        continue;
                    if (mResult[i, j].eName == CEnum.TagName.CARD_SumTotal)
                        continue;
                    if (mResult[i, j].eName == CEnum.TagName.CARD_UDtargetvalue)
                        continue;
                    if (mResult[i, j].eName == CEnum.TagName.CARD_UDip)
                        continue;
                    result += config.ReadConfigValue("GLOBAL", mResult[i, j].eName.ToString()) + ":";
                    result += mResult[i, j].oContent.ToString();
                    result += "\r\n";
                }
                result += "\r\n";
            }
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

            FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + this.Name + ".txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(result);
            sw.Close();
            fs.Close();
            buttonSaveAS.Enabled = true;
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {

                e.Result = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERCONSUME_QUERY,(CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbPage.Enabled = true;
            Cursor = Cursors.Default;
            
            Operation_Card.BuildDataTable(this.m_ClientEvent, (CEnum.Message_Body[,])e.Result, GrdResult, out iPageCount);
        }

        private void buttonSaveAS_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad", AppDomain.CurrentDomain.SetupInformation.ApplicationBase + this.Name + ".txt");
            }
            catch
            {

            }
        }
    }
}