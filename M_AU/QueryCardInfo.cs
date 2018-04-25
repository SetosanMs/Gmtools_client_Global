using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using C_Controls.LabelTextBox;
using C_Global;
using C_Event;

using Language;

namespace M_Audition
{
    [C_Global.CModuleAttribute("点卡查询记录", "QueryCardInfo", "点卡查询记录[充值消费]", "AU Group")]
    public partial class QueryCardInfo : Form
    {
        private CSocketEvent m_ClientEvent = null;
        private bool isBat = false;
        private DataTable dataResult;
        private DataTable dataErr;
        private ArrayList paramList = new ArrayList();
        private string result;

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
                    this.Text = config.ReadConfigValue("MAU", "QC_UI_QueryCardInfo");
                    this.GrpResult.Text = config.ReadConfigValue("MAU", "QC_UI_GrpResult");
                    this.GrpSearch.Text = config.ReadConfigValue("MAU", "QC_UI_GrpSearch");
                    this.button1.Text = config.ReadConfigValue("MAU", "QC_UI_button1");
                    this.LblCardnum.Text = config.ReadConfigValue("MAU", "QC_UI_LblCardnum");
                    this.BtnSearch.Text = config.ReadConfigValue("MAU", "QC_UI_BtnSearch");
                    this.LblPwd.Text = config.ReadConfigValue("MAU", "QC_UI_LblPwd");
                    this.buttonSaveAS.Text = config.ReadConfigValue("MAU", "QC_UI_buttonSaveAS");
                    this.labelPath.Text = config.ReadConfigValue("MAU", "QC_UI_labelPath");
                    this.buttonBrowse.Text = config.ReadConfigValue("MAU", "QC_UI_buttonBrowse");
                    this.labelProcess.Text = config.ReadConfigValue("MAU", "QC_UI_labelProcess");
                    this.tabPageList.Text = config.ReadConfigValue("MAU", "QC_UI_tabPageList");
                    this.tabPageErr.Text = config.ReadConfigValue("MAU", "QC_UI_tabPageErr");
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
            QueryCardInfo mModuleFrm = new QueryCardInfo();
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
        
        public QueryCardInfo()
        {
            InitializeComponent();
        }

        private void QueryCardInfo_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewResult.DataSource = null;
            dataGridViewError.DataSource = null;
            this.progressBar1.Value = 0;
            TpgResult.SelectedIndex = 0;
            paramList.Clear();
            if (!checkBoxBat.Checked)
            {
                //条件限制
                if (txtcardnum.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "QC_CODE_Msg"));
                    return;
                }
                isBat = false;
                BtnSearch.Enabled = false;
                Cursor = Cursors.AppStarting;
                buttonSaveAS.Enabled = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
                mContent[0].eName = CEnum.TagName.CARD_cardnum;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = txtcardnum.Text.Trim();


                mContent[1].eName = CEnum.TagName.CARD_cardpass;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = TxtPwd.Text.Trim();

                this.backgroundWorkerSearch.RunWorkerAsync(mContent);
            }
            else
            {
                this.isBat = true;
                //条件限制
                if (this.textBoxPath.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "QC_CODE_Msg1"));
                    return;
                }
                BtnSearch.Enabled = false;
                Cursor = Cursors.AppStarting;
                buttonSaveAS.Enabled = false;
                try
                {
                    StreamReader sr = new StreamReader(this.textBoxPath.Text);
                    while (!sr.EndOfStream)
                    {
                        string tmp = sr.ReadLine();
                        if (tmp != "")
                        {
                            paramList.Add(tmp);
                        }
                    }
                    if (paramList.Count == 0)
                    {
                        MessageBox.Show(config.ReadConfigValue("MAU", "QC_CODE_Msg2"));
                        return;
                    }
                    
                }
                catch
                {
                    MessageBox.Show(config.ReadConfigValue("MAU","QC_CODE_Msg2"));
                }
                this.backgroundWorkerSearch.RunWorkerAsync();
            }

        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!isBat)
                {
                    lock (typeof(C_Event.CSocketEvent))
                    {
                        e.Result = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERNUM_QUERY, (CEnum.Message_Body[])e.Argument);
                    }
                }
                else
                {
                    CEnum.Message_Body[,] mResult;
                    result = "";
                    dataErr = new DataTable();
                    dataResult = new DataTable();
                    dataErr.Columns.Add(config.ReadConfigValue("MAU","CARD_cardnum"));
                    dataErr.Columns.Add(config.ReadConfigValue("MAU","QC_CODE_Msg3"));
                    dataResult.Columns.Add(config.ReadConfigValue("MAU","CARD_PDCardPASS"));
                    dataResult.Columns.Add(config.ReadConfigValue("MAU","CARD_cardnum"));
                    dataResult.Columns.Add(config.ReadConfigValue("MAU","CARD_cardtype"));
                    dataResult.Columns.Add(config.ReadConfigValue("MAU","CARD_price"));
                    dataResult.Columns.Add(config.ReadConfigValue("MAU", "CARD_use_status"));
                    dataResult.Columns.Add(config.ReadConfigValue("MAU", "CARD_Locktype"));
                    dataResult.Columns.Add(config.ReadConfigValue("MAU","CARD_use_username"));
                    dataResult.Columns.Add(config.ReadConfigValue("MAU", "TOEKN_BindDate"));
                    dataResult.Columns.Add(config.ReadConfigValue("MAU","CARD_PDgetusername"));

                    dataResult.Columns.Add(config.ReadConfigValue("MAU", "CARD_PDip"));
                    for (int i = 0; i < paramList.Count; i++)
                    {
                        CEnum.Message_Body[] mContent;
                        string[] tmp = paramList[i].ToString().Split(' ');
                        if (tmp.GetLength(0) < 2)
                        {
                            mContent = new CEnum.Message_Body[2];
                            mContent[0].eName = CEnum.TagName.CARD_cardnum;
                            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[0].oContent = tmp[0].Trim();


                            mContent[1].eName = CEnum.TagName.CARD_cardpass;
                            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[1].oContent = "";
                        }
                        else
                        {
                            mContent = new CEnum.Message_Body[2];
                            mContent[0].eName = CEnum.TagName.CARD_cardnum;
                            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[0].oContent = tmp[0].Trim();


                            mContent[1].eName = CEnum.TagName.CARD_cardpass;
                            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[1].oContent = tmp[1].Trim();
                        }
                        lock (typeof(C_Event.CSocketEvent))
                        {
                            mResult = Operation_Card.GetResult(this.m_ClientEvent, CEnum.ServiceKey.CARD_USERNUM_QUERY, mContent);
                        }
                        if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                        {
                            DataRow dr = dataErr.NewRow();
                            dr[0] = tmp[0].Trim();
                            dr[1] = mResult[0, 0].oContent.ToString();
                            dataErr.Rows.Add(dr);
                        }
                        else
                        {
                                for (int j = 0; j < mResult.GetLength(1); j++)
                                {
                                    if (tmp.GetLength(0) < 2 && mResult[0, j].eName == CEnum.TagName.CARD_PDgetusername && mResult[0, j].oContent.ToString() == "" && Operation_Shop.findIdx(mResult, CEnum.TagName.TOEKN_BindDate) != -1 && DateTime.Parse(mResult[0, Operation_Shop.findIdx(mResult, CEnum.TagName.TOEKN_BindDate)].oContent.ToString()).Date >= DateTime.Parse("2006-6-1").Date)
                                    {
                                        result += config.ReadConfigValue("MAU", mResult[0,j].eName.ToString()) + ":";
                                        result += config.ReadConfigValue("MAU", "CARD_ERROR");
                                        result += "\r\n";
                                    }
                                    else
                                    {
                                        if (mResult[0, j].eName != CEnum.TagName.CARD_PDip)
                                        {
                                            result += config.ReadConfigValue("MAU", mResult[0, j].eName.ToString()) + ":";
                                            result += mResult[0, j].oContent.ToString();
                                            result += "\r\n";
                                        }
                                    }
                                }
                                result += "\r\n";

                                DataRow dr = dataResult.NewRow();
                                for (int k = 0; k < mResult.GetLength(1); k++)
                                {

                                    if (tmp.GetLength(0) < 2 && mResult[0, k].eName == CEnum.TagName.CARD_PDgetusername && mResult[0, k].oContent.ToString() == "" && Operation_Shop.findIdx(mResult, CEnum.TagName.TOEKN_BindDate) != -1 && DateTime.Parse(mResult[0, Operation_Shop.findIdx(mResult, CEnum.TagName.TOEKN_BindDate)].oContent.ToString()).Date >= DateTime.Parse("2006-6-1").Date)
                                    {
                                        dr[config.ReadConfigValue("MAU", mResult[0,k].eName.ToString())] = config.ReadConfigValue("MAU", "CARD_ERROR");
                                    }
                                    else
                                    {
                                        dr[config.ReadConfigValue("MAU", mResult[0, k].eName.ToString())] = mResult[0, k].oContent.ToString();
                                    }
                                }
                                dataResult.Rows.Add(dr);
                           
                            
                        }
                        this.backgroundWorkerSearch.ReportProgress((int)(((float)(i + 1)) / ((float)paramList.Count) * 100));    
                    }
                }
                
            }
            catch(Exception ex)
            {

            }
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (!isBat)
                {
                    this.BtnSearch.Enabled = true;
                    this.Cursor = Cursors.Default;
                    CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;
                    if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                    {
                        MessageBox.Show(mResult[0, 0].oContent.ToString());
                        return;
                    }

                    buttonSaveAS.Enabled = true;
                    result = "";
                    for (int j = 0; j < mResult.GetLength(0); j++)
                    {
                        for (int i = 0; i < mResult.GetLength(1); i++)
                        {
                            if (TxtPwd.Text.Trim() == "" && mResult[j, i].eName == CEnum.TagName.CARD_PDgetusername && mResult[j, i].oContent.ToString() == "" && Operation_Shop.findIdx(mResult, CEnum.TagName.TOEKN_BindDate) != -1 && DateTime.Parse(mResult[j, Operation_Shop.findIdx(mResult, CEnum.TagName.TOEKN_BindDate)].oContent.ToString()).Date >= DateTime.Parse("2006-6-1").Date)
                            {
                                result += config.ReadConfigValue("MAU", mResult[j, i].eName.ToString()) + ":";
                                result += config.ReadConfigValue("MAU", "CARD_ERROR");
                                result += "\r\n";
                            }
                            else
                            {
                                if (mResult[j, i].eName != CEnum.TagName.CARD_PDip)
                                {
                                    result += config.ReadConfigValue("MAU", mResult[j, i].eName.ToString()) + ":";
                                    result += mResult[j, i].oContent.ToString();
                                    result += "\r\n";
                                }
                            }
                        }
                    }
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + this.Name + ".txt", FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(result);
                    sw.Close();
                    fs.Close();
                    DataTable dt = new DataTable();
                    for (int i = 0; i < mResult.GetLength(1); i++)
                    {
                        dt.Columns.Add(config.ReadConfigValue("MAU", mResult[0, i].eName.ToString()));
                    }

                    for (int j = 0; j < mResult.GetLength(0); j++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < mResult.GetLength(1); i++)
                        {

                            if (TxtPwd.Text.Trim() == "" && mResult[0, i].eName == CEnum.TagName.CARD_PDgetusername && mResult[0, i].oContent.ToString() == "" && DateTime.Parse(mResult[0, Operation_Shop.findIdx(mResult, CEnum.TagName.TOEKN_BindDate)].oContent.ToString()).Date >= DateTime.Parse("2006-6-1").Date)
                            {
                                dr[config.ReadConfigValue("MAU", mResult[0, i].eName.ToString())] = config.ReadConfigValue("MAU", "CARD_ERROR");
                            }
                            else
                            {
                                dr[config.ReadConfigValue("MAU", mResult[0, i].eName.ToString())] = mResult[0, i].oContent.ToString();
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                    dataGridViewResult.DataSource = dt;
                }
                else
                {
                    this.BtnSearch.Enabled = true;
                    this.Cursor = Cursors.Default;
                    buttonSaveAS.Enabled = true;
                    dataGridViewResult.DataSource = dataResult;
                    dataGridViewError.DataSource = dataErr;
                    FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + this.Name + ".txt", FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(result);
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

       }

        private void button1_Click(object sender, EventArgs e)
        {
            txtcardnum.Text = "";
            TxtPwd.Text = "";
            buttonSaveAS.Enabled = false;
            dataGridViewError.DataSource = null;
            dataGridViewResult.DataSource = null;
        }

        private void buttonSaveAS_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad", AppDomain.CurrentDomain.SetupInformation.ApplicationBase+this.Name + ".txt");
            }
            catch
            {

            }
        }

        private void checkBoxBat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBat.Checked)
            {
                txtcardnum.Enabled = false;
                TxtPwd.Enabled = false;
                textBoxPath.Enabled = true;
                buttonBrowse.Enabled = true;
                progressBar1.Enabled = true;
            }
            else
            {
                txtcardnum.Enabled = true;
                TxtPwd.Enabled = true;
                textBoxPath.Enabled = false;
                buttonBrowse.Enabled = false;
                progressBar1.Enabled = false;
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBoxPath.Text = openFileDialog1.FileName;
            }
        }

        private void backgroundWorkerSearch_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }
    }
}