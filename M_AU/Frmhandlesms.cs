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

namespace M_Audition
{
    [C_Global.CModuleAttribute("9YOU令牌", "Frmhandlesms", "9YOU令牌", "9YOU Group")]
    public partial class Frmhandlesms : Form
    {
        public Frmhandlesms()
        {
            InitializeComponent();
        }
        private CSocketEvent m_ClientEvent = null;
        private int iPage = 0;
        private int pagesize = 50;
        private bool iFirst = false;
        private bool iFirst1 = false;
        private bool bFirst = false;
        string currSelectPSTID = "";
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
            Frmhandlesms mModuleFrm = new Frmhandlesms();
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
            this.Text = config.ReadConfigValue("MAU", "FT_UIHES_Text");
 
        }
        #endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            //if (
            //    //this.textBox1.Text.Trim().Length > 0 &&
            //    //this.textBox2.Text.Trim().Length > 0 &&
            //    //this.textBox3.Text.Trim().Length > 0 &&
            //    //(this.radioButton1.Checked || this.radioButton2.Checked)

            //    )
            //{
            //    buttonLock.Enabled = false;
            //    Cursor = Cursors.WaitCursor;
                
            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[6];

            //    mContent[0].eName = CEnum.TagName.UserByID;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            //    mContent[1].eName = CEnum.TagName.TOKEN_username;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[1].oContent = textBox1.Text.Trim();

            //    mContent[2].eName = CEnum.TagName.TOKEN_esn;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[2].oContent = textBox2.Text.Trim();

            //    mContent[3].eName = CEnum.TagName.TOKEN_service;
            //    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[3].oContent = textBox3.Text.Trim();

            //    mContent[4].eName = CEnum.TagName.TOKEN_code;
            //    mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[4].oContent = radioButton1.Checked ? "4" : "5";

            //    mContent[5].eName = CEnum.TagName.CARD_address;
            //    mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[5].oContent = Operation_Card.ReturnClientIp();

            //    this.backgroundWorkerLock.RunWorkerAsync(mContent);
            //}
            //else
            //{
            //    MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg1"));
            //    return;
            //}
        }

        private void backgroundWorkerLock_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERTOKEN_CLOSE, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerLock_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //buttonLock.Enabled = true;
            //Cursor = Cursors.Default;

            //CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}
            //else
            //{
            //    if(mResult[0,0].oContent.ToString() == "FAILURE")
            //        MessageBox.Show(config.ReadConfigValue("MAU","UD_Code_Msgopfail"));
            //    else 
            //        MessageBox.Show(config.ReadConfigValue("MAU","UD_Code_Msgopsucc"));

            //}
        }

        private void Frmhandlesms_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            DivPage.Visible = false;
            dpModi.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.textBox4.Text = "";
            //this.textBox5.Text = "";
            //this.textBox6.Text = "";
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            //if (this.textBox4.Text.Trim() != "" &&
            //    this.textBox6.Text.Trim() != "")
            //{
            //    buttonUnlock.Enabled = false;
            //    Cursor = Cursors.WaitCursor;

            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[5];

            //    mContent[0].eName = CEnum.TagName.UserByID;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            //    mContent[1].eName = CEnum.TagName.TOKEN_username;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[1].oContent = textBox6.Text.Trim();

            //    mContent[2].eName = CEnum.TagName.TOKEN_esn;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[2].oContent = textBox4.Text.Trim();

            //    mContent[3].eName = CEnum.TagName.TOKEN_dpsw;
            //    mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[3].oContent = textBox5.Text.Trim();

            //    mContent[4].eName = CEnum.TagName.CARD_address;
            //    mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[4].oContent = Operation_Card.ReturnClientIp();

            //    this.backgroundWorkerUnlock.RunWorkerAsync(mContent);
            //}
            //else
            //{
            //    MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg1"));
            //    return;
            //}
        }

        private void backgroundWorkerUnlock_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERTOKEN_OPEN, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerUnlock_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //buttonUnlock.Enabled = true;
            //Cursor = Cursors.Default;

            //CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}
            //else
            //{
            //    if (mResult[0, 0].oContent.ToString() == "FAILURE")
            //        MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopfail"));
            //    else
            //        MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopsucc"));

            //}
        }



        private void button5_Click(object sender, EventArgs e)
        {
            //this.textBox10.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //if (this.textBox10.Text.Trim() == "")
            //{
            //    MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg1"));
            //    return;
            //}
            //else
            //{
            //    button6.Enabled = false;
            //    Cursor = Cursors.WaitCursor;
            //    CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            //    mContent[0].eName = CEnum.TagName.UserByID;
            //    mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            //    mContent[0].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            //    mContent[1].eName = CEnum.TagName.TOKEN_username;
            //    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[1].oContent = textBox10.Text.Trim();

            //    mContent[2].eName = CEnum.TagName.CARD_address;
            //    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            //    mContent[2].oContent = Operation_Card.ReturnClientIp();


            //    this.backgroundWorkerUnban.RunWorkerAsync(mContent);
            //}
        }

        private void backgroundWorkerUnban_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERTOKEN_RELEASE, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerUnban_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //button6.Enabled = true;
            //Cursor = Cursors.Default;
            //CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            //if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            //{
            //    MessageBox.Show(mResult[0, 0].oContent.ToString());
            //    return;
            //}
            //else
            //{
            //    if (mResult[0, 0].oContent.ToString() == "FAILURE")
            //        MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopfail"));
            //    else
            //        MessageBox.Show(config.ReadConfigValue("MAU", "UD_Code_Msgopsucc"));

            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {   
            if (this.txtAccount.Text.Trim() == "")
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "HN_UI_Msg"));
                return;
            }
            else
            {
                btnSearch.Enabled = false;
                Cursor = Cursors.WaitCursor;
                bFirst = false;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.Index;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = 1;

                mContent[1].eName = CEnum.TagName.CARD_mobilephone;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = txtAccount.Text.Trim();

                mContent[2].eName = CEnum.TagName.CARD_ActionType;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = ReturnActionType(cbxServerIP.Text.Trim());

                this.backgroundWorkerSerch.RunWorkerAsync(mContent);
            }
            CmbPage.Items.Clear();
        }
        private string ReturnActionType(string _txt)
        {
            string _type="";
            if (_txt=="激活查询")
            {
                _type="active";
            }
            else if (_txt == "休闲查询")
            {
                _type = "xiuxian";
            }
            else if (_txt == "双倍查询")
            {
                _type = "double";
            }
            return _type;
        }

        private string ReturnEditActionType(string _txt)
        {
            string _type = "";
            if (_txt == "激活查询")
            {
                _type = "active";
            }
            else if (_txt == "休闲查询")
            {
                _type = "editxiuxian";
            }
            else if (_txt == "双倍查询")
            {
                _type = "editdouble";
            }
            return _type;
        }
        private void backgroundWorkerSerch_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_MOBILEINFO_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSerch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                btnSearch.Enabled = true;
                Cursor = Cursors.Default;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, dgAccountInfo, out iPage);

                if (iPage <= 0)
                {
                    DivPage.Visible = false;
                }
                else
                {
                    for (int i = 0; i < iPage; i++)
                    {
                        CmbPage.Items.Add(i + 1);
                    }

                    CmbPage.SelectedIndex = 0;
                    bFirst = true;
                    DivPage.Visible = true;
                }
            }
            catch { }

        }

        private void CmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (this.backgroundWorkerSerch.IsBusy)
            {
                return;
            }
            if (bFirst)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.Index;
                mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[0].oContent = int.Parse(CmbPage.Text.Trim());

                mContent[1].eName = CEnum.TagName.CARD_mobilephone;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = txtAccount.Text.Trim();

                mContent[2].eName = CEnum.TagName.CARD_ActionType;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = ReturnActionType(cbxServerIP.Text.Trim());

                this.backgroundWorkerPageChanged.RunWorkerAsync(mContent);
            }
        }

        private void dgAccountInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (cbxServerIP.Text == "激活查询")
                {
                    return;
                }
                else
                {
                    DataTable dt = (DataTable)dgAccountInfo.DataSource;
                    //当前用户
                    currSelectPSTID = dt.Rows[e.RowIndex]["用户ID"].ToString();
                    txtPlayerID.Text = dt.Rows[e.RowIndex]["手机号码"].ToString().Trim();

                    textBox1.Text = dt.Rows[e.RowIndex]["用户名"].ToString().Trim();

                    //显示修改容器
                    dpModi.Visible = true;
                }
            }
            catch
            {
            }
        }

        private void btnModiCancel_Click(object sender, EventArgs e)
        {

            dpModi.Visible = false;         //隐藏信息修改
            txtPlayerID.Clear();

        }

        private void btnModiApply_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                MessageBox.Show("用户已成功充值不能修改");
                return;
                
            }
            else
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.CARD_UserID;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = currSelectPSTID;

                mContent[1].eName = CEnum.TagName.CARD_mobilephone;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = txtAccount.Text.Trim();

                mContent[2].eName = CEnum.TagName.CARD_ActionType;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = ReturnEditActionType(cbxServerIP.Text.Trim());

                this.backgroundWorkerAdd.RunWorkerAsync(mContent);


            }
        }

        private void backgroundWorkerPageChanged_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_MOBILEINFO_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerPageChanged_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            Operation_Card.BuildDataTable(this.m_ClientEvent, mResult, dgAccountInfo, out iPage);
        }

        private void backgroundWorkerAdd_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_MOBILEINFO_UPDATE, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            if (mResult[0, 0].oContent.ToString() == "SUCCESS")
            {
                MessageBox.Show("修改成功!");
            }

            currSelectPSTID = "";
            dpModi.Visible = false;
            btnSearch_Click(null,null);


        }

        private void cbxServerIP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dpModi_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}