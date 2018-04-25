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
    [C_Global.CModuleAttribute("9YOU令牌查看资料", "FrmTokenView", "9YOU令牌查看资料", "9YOU Group")]
    public partial class FrmTokenView : Form
    {
        public FrmTokenView()
        {
            InitializeComponent();
        }
        private CSocketEvent m_ClientEvent = null;
        private int iPage = 0;
        private int pagesize = 50;
        private bool iFirst = false;
        private bool iFirst1 = false;

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
            FrmTokenView mModuleFrm = new FrmTokenView();
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
            this.Text = config.ReadConfigValue("MAU", "FTV_UI_Text");
            this.TpgView.Text = config.ReadConfigValue("MAU", "FT_UI_TpgView");

            this.GroupView.Text = config.ReadConfigValue("MAU", "FT_UI_GroupLock");
            this.labelType.Text = config.ReadConfigValue("MAU", "FT_UI_labelType");
            this.labelSort.Text = config.ReadConfigValue("MAU", "FT_UI_labelSort");
            this.labelStart.Text = config.ReadConfigValue("MAU", "FT_UI_labelStart");
            this.labelEnd.Text = config.ReadConfigValue("MAU", "FT_UI_labelEnd");
            this.buttonView.Text = config.ReadConfigValue("MAU", "FT_UI_buttonView");
            this.button2.Text = config.ReadConfigValue("MAU", "FT_UI_buttonCancel");
            this.comboBoxType.Items.Clear();
            this.comboBoxSort.Items.Clear();
            this.comboBoxType.Items.AddRange(new object[] {
            config.ReadConfigValue("MAU", "FT_UI_comboBoxType1"),
            config.ReadConfigValue("MAU", "FT_UI_comboBoxType2")});
            this.comboBoxSort.Items.AddRange(new object[] {
            config.ReadConfigValue("MAU", "FT_UI_comboBoxSort1"),
            config.ReadConfigValue("MAU", "FT_UI_comboBoxSort2"),
            config.ReadConfigValue("MAU", "FT_UI_comboBoxSort3"),
            config.ReadConfigValue("MAU", "FT_UI_comboBoxSort4")});

            groupBox1.Text = GroupView.Text;
            label6.Text = labelSort.Text;
            label5.Text = labelStart.Text;
            label4.Text = labelEnd.Text;
            button4.Text = buttonView.Text;
            button3.Text = button2.Text;
            TpgUserData.Text = config.ReadConfigValue("MAU", "FT_UI_TpgUserData");
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new object[] {
            config.ReadConfigValue("MAU", "FT_UI_comboBoxSort1"),
            config.ReadConfigValue("MAU", "FT_UI_comboBoxSort2"),
            config.ReadConfigValue("MAU", "FT_UI_comboBoxSort3"),
            config.ReadConfigValue("MAU", "FT_UI_comboBoxSort4")});
        }
        #endregion


        
        private void FrmToken_Load(object sender, EventArgs e)
        {
            IntiFontLib();
        }



       

        private void button2_Click(object sender, EventArgs e)
        {
            this.comboBoxType.Text = "";
            this.comboBoxSort.Text = "";
            this.textBoxValue.Text = "";
            this.dataGridView1.DataSource = null;
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            this.comboBoxPage.Items.Clear();
            this.comboBoxPage.Visible = false;
            if (comboBoxSort.Text != "" &&
                comboBoxType.Text != "" &&
                textBoxValue.Text.Trim() != "")
            {
                if (this.dateTimePickerEnd.Value >= this.dateTimePickerStart.Value)
                {
                    buttonView.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    dataGridView1.DataSource = null;
                    iFirst = false;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.TOKEN_provide;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    switch (this.comboBoxType.SelectedIndex)
                    {
                        case 0:
                            mContent[0].oContent = "viewToken";
                            mContent[7].eName = CEnum.TagName.TOKEN_authType;
                            mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[7].oContent = "history";
                            break;
                        case 1:
                            mContent[0].oContent = "viewTokenUser";
                            mContent[7].eName = CEnum.TagName.TOKEN_authType;
                            mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[7].oContent = "";
                            break;
                        default:
                            mContent[0].oContent = "viewToken";
                            mContent[7].eName = CEnum.TagName.TOKEN_authType;
                            mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                            mContent[7].oContent = "history";
                            break;
                    }

                    mContent[1].eName = CEnum.TagName.TOKEN_Type;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    switch (this.comboBoxSort.SelectedIndex)
                    {
                        case 0:
                            mContent[1].oContent = "username";
                            break;
                        case 1:
                            mContent[1].oContent = "serviceNo";
                            break;
                        case 2:
                            mContent[1].oContent = "esn";
                            break;
                        case 3:
                            mContent[1].oContent = "idCard";
                            break;
                        default:
                            mContent[1].oContent = "username";
                            break;
                    }

                    mContent[2].eName = CEnum.TagName.TOKEN_code;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = textBoxValue.Text.Trim();

                    mContent[3].eName = CEnum.TagName.TOKEN_Start;
                    mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                    mContent[3].oContent = dateTimePickerStart.Value.Date;

                    mContent[4].eName = CEnum.TagName.TOKEN_End;
                    mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                    mContent[4].oContent = dateTimePickerEnd.Value.Date;

                    mContent[5].eName = CEnum.TagName.PageSize;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = pagesize;

                    mContent[6].eName = CEnum.TagName.Index;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = 1;

                    this.backgroundWorkerView.RunWorkerAsync(mContent);
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg2"));
                    return;
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg1"));
                return;
            }
        }

        private void backgroundWorkerView_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERTOKEN_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonView.Enabled = true;
            Cursor = Cursors.Default;
            comboBoxPage.Enabled = true;
            CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            else
            {
                comboBoxPage.Visible = true;
                if (this.comboBoxPage.Items.Count == 0)
                {
                    iPage = Convert.ToInt32(mResult[0, 10].oContent);
                    for (int i = 1; i <= iPage; i++)
                    {
                        this.comboBoxPage.Items.Add(i);
                    }
                    if (!iFirst)
                    {
                        comboBoxPage.SelectedIndex = 0;
                        iFirst = true;
                    }
                }
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column1")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column2")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column3")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column5")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column6")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column7")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column8")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column9")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column10")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column11"))
                });
                for (int i = 0; i < mResult.GetLength(0); i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < mResult.GetLength(1) - 1; j++)
                    {
                        if (mResult[i, j].eName == CEnum.TagName.CARD_vis)
                        {
                            if (mResult[i, j].oContent.ToString() == "true")
                                dr[j] = config.ReadConfigValue("MAU", "FT_UI_Chief");
                            else
                                dr[j] = config.ReadConfigValue("MAU", "FT_UI_Sub");
                        }
                        else
                            dr[j] = mResult[i, j].oContent;
                    }
                    dt.Rows.Add(dr);
                }
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBoxPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iFirst)
            {
                buttonView.Enabled = false;
                Cursor = Cursors.WaitCursor;
                dataGridView1.DataSource = null;
                comboBoxPage.Enabled = false;

                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.TOKEN_provide;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                switch (this.comboBoxType.SelectedIndex)
                {
                    case 0:
                        mContent[0].oContent = "viewToken";
                        mContent[7].eName = CEnum.TagName.TOKEN_authType;
                        mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[7].oContent = "history";
                        break;
                    case 1:
                        mContent[0].oContent = "viewTokenUser";
                        mContent[7].eName = CEnum.TagName.TOKEN_authType;
                        mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[7].oContent = "";
                        break;
                    default:
                        mContent[0].oContent = "viewToken";
                        mContent[7].eName = CEnum.TagName.TOKEN_authType;
                        mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                        mContent[7].oContent = "history";
                        break;
                }

                mContent[1].eName = CEnum.TagName.TOKEN_Type;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                switch (this.comboBoxSort.SelectedIndex)
                {
                    case 0:
                        mContent[1].oContent = "username";
                        break;
                    case 1:
                        mContent[1].oContent = "serviceNo";
                        break;
                    case 2:
                        mContent[1].oContent = "esn";
                        break;
                    case 3:
                        mContent[1].oContent = "idCard";
                        break;
                    default:
                        mContent[1].oContent = "username";
                        break;
                }

                mContent[2].eName = CEnum.TagName.TOKEN_code;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = textBoxValue.Text.Trim();

                mContent[3].eName = CEnum.TagName.TOKEN_Start;
                mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[3].oContent = dateTimePickerStart.Value.Date;

                mContent[4].eName = CEnum.TagName.TOKEN_End;
                mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[4].oContent = dateTimePickerEnd.Value.Date;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = pagesize;

                mContent[6].eName = CEnum.TagName.Index;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = (comboBoxPage.SelectedIndex) * pagesize + 1;

                this.backgroundWorkerView.RunWorkerAsync(mContent);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Visible = false;
            if (this.comboBox2.Text != "" &&
                this.textBox7.Text.Trim() != "")
            {
                if (this.dateTimePicker1.Value >= this.dateTimePicker2.Value)
                {
                    button4.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    dataGridView2.DataSource = null;
                    iFirst1 = false;
                    CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                    mContent[0].eName = CEnum.TagName.TOKEN_provide;
                    mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[0].oContent = "viewToken";


                    mContent[1].eName = CEnum.TagName.TOKEN_Type;
                    mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                    switch (this.comboBox2.SelectedIndex)
                    {
                        case 0:
                            mContent[1].oContent = "username";
                            break;
                        case 1:
                            mContent[1].oContent = "serviceNo";
                            break;
                        case 2:
                            mContent[1].oContent = "esn";
                            break;
                        case 3:
                            mContent[1].oContent = "idCard";
                            break;
                        default:
                            mContent[1].oContent = "username";
                            break;
                    }

                    mContent[2].eName = CEnum.TagName.TOKEN_code;
                    mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[2].oContent = this.textBox7.Text.Trim();

                    mContent[3].eName = CEnum.TagName.TOKEN_Start;
                    mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                    mContent[3].oContent = dateTimePicker2.Value.Date;

                    mContent[4].eName = CEnum.TagName.TOKEN_End;
                    mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                    mContent[4].oContent = dateTimePicker1.Value.Date;

                    mContent[5].eName = CEnum.TagName.PageSize;
                    mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[5].oContent = pagesize;

                    mContent[6].eName = CEnum.TagName.Index;
                    mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                    mContent[6].oContent = 1;

                    mContent[7].eName = CEnum.TagName.TOKEN_authType;
                    mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                    mContent[7].oContent = "current";

                    this.backgroundWorkerCurrent.RunWorkerAsync(mContent);
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg2"));
                    return;
                }
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MAU", "FT_UI_Msg1"));
                return;
            }
        }

        private void backgroundWorkerCurrent_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                e.Result = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.CARD_USERTOKEN_QUERY, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerCurrent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                button4.Enabled = true;
                Cursor = Cursors.Default;
                comboBox1.Enabled = true;
                CEnum.Message_Body[,] mResult = (CEnum.Message_Body[,])e.Result;

                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }
                else
                {
                    comboBox1.Visible = true;
                    if (this.comboBox1.Items.Count == 0)
                    {
                        iPage = Convert.ToInt32(mResult[0, 9].oContent);
                        for (int i = 1; i <= iPage; i++)
                        {
                            this.comboBox1.Items.Add(i);
                        }
                        if (!iFirst1)
                        {
                            comboBox1.SelectedIndex = 0;
                            iFirst1 = true;
                        }
                    }
                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column1")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column2")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column3")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column5")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column6")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column7")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column8")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column9")),
                    new DataColumn(config.ReadConfigValue("MAU","FT_UI_column11"))
                });
                    for (int i = 0; i < mResult.GetLength(0); i++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < mResult.GetLength(1) - 1; j++)
                        {
                            if (mResult[i, j].eName == CEnum.TagName.CARD_vis)
                            {
                                if (mResult[i, j].oContent.ToString() == "true")
                                    dr[j] = config.ReadConfigValue("MAU", "FT_UI_Chief");
                                else
                                    dr[j] = config.ReadConfigValue("MAU", "FT_UI_Sub");
                            }
                            else
                                dr[j] = mResult[i, j].oContent;
                        }
                        dt.Rows.Add(dr);
                    }
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.comboBox2.Text = "";
            this.textBox7.Text = "";
            this.dataGridView2.DataSource = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iFirst1)
            {
                button4.Enabled = false;
                Cursor = Cursors.WaitCursor;
                dataGridView2.DataSource = null;
                iFirst1 = false;
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

                mContent[0].eName = CEnum.TagName.TOKEN_provide;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = "viewToken";


                mContent[1].eName = CEnum.TagName.TOKEN_Type;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                switch (this.comboBox2.SelectedIndex)
                {
                    case 0:
                        mContent[1].oContent = "username";
                        break;
                    case 1:
                        mContent[1].oContent = "serviceNo";
                        break;
                    case 2:
                        mContent[1].oContent = "esn";
                        break;
                    case 3:
                        mContent[1].oContent = "idCard";
                        break;
                    default:
                        mContent[1].oContent = "username";
                        break;
                }

                mContent[2].eName = CEnum.TagName.TOKEN_code;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = this.textBox7.Text.Trim();

                mContent[3].eName = CEnum.TagName.TOKEN_Start;
                mContent[3].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[3].oContent = dateTimePicker2.Value.Date;

                mContent[4].eName = CEnum.TagName.TOKEN_End;
                mContent[4].eTag = CEnum.TagFormat.TLV_DATE;
                mContent[4].oContent = dateTimePicker1.Value.Date;

                mContent[5].eName = CEnum.TagName.PageSize;
                mContent[5].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[5].oContent = pagesize;

                mContent[6].eName = CEnum.TagName.Index;
                mContent[6].eTag = CEnum.TagFormat.TLV_INTEGER;
                mContent[6].oContent = (comboBox1.SelectedIndex) * pagesize + 1; ;

                mContent[7].eName = CEnum.TagName.TOKEN_authType;
                mContent[7].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[7].oContent = "current";

                this.backgroundWorkerCurrent.RunWorkerAsync(mContent);
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.Text == "查看令牌")
            {
                comboBoxSort.Items.Clear();
                comboBoxSort.Items.Add("用户名");
                comboBoxSort.Items.Add("服务号");
                comboBoxSort.Items.Add("序列号");
                comboBoxSort.Items.Add("身份证");
            }
            else
            {
                comboBoxSort.Items.Clear();
                comboBoxSort.Items.Add("用户名");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }



    }
}