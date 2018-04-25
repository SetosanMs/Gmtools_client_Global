using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using C_Global;
using C_Event;

using Language;

namespace M_o2jam_2
{
    [C_Global.CModuleAttribute("激活码/帐号查询[超级乐者]", "ActivationSearchByo22", "超级乐者", "CR")]
    public partial class ActivationSearchByo22 : Form
    {
        public ActivationSearchByo22()
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
            this.Text = config.ReadConfigValue("MBAF", "AS_UI_ActivationSearchByo22");
            this.label1.Text = config.ReadConfigValue("MBAF", "AS_UI_Label1");
            this.label2.Text = config.ReadConfigValue("MBAF", "AS_UI_Label2");
            this.label3.Text = config.ReadConfigValue("MBAF", "AS_UI_Label3");
            this.chkbxActivation.Text = config.ReadConfigValue("MBAF", "AS_UI_chkbxActivation");
            this.chkbxAccount.Text = config.ReadConfigValue("MBAF", "AS_UI_chkbxAccount");
            this.btnSearch.Text = config.ReadConfigValue("MBAF", "AS_UI_btnSearch");
            this.btnCancel.Text = config.ReadConfigValue("MBAF", "AS_UI_btnCancel");
            this.lblContent.Text = config.ReadConfigValue("MBAF", "AS_UI_lblContent");
            this.lblResult.Text = config.ReadConfigValue("MBAF", "AS_UI_lblResult");
        }


        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            HideResultLabel();
            DisableAccountSearch();
            chkbxActivation.Checked = true;
        }

        #region 状态信息
        private void WriteSearchText(object sender, System.EventArgs e)
        {
            Status.WriteStatusText(this.MdiParent, config.ReadConfigValue("MBAF", "AS_CODE_StatusText"));
        }
        #endregion

        #region 自定义函数

        /// <summary>
        /// 使显示查询结果的label不可见
        /// </summary>
        private void HideResultLabel()
        {
            lblResult.Visible = false;
            lblContent.Visible = false;
            lblContent.Text = "";
        }

        /// <summary>
        /// 使显示查询结果的label可见
        /// </summary>
        private void ShowResultLabel()
        {
            lblResult.Visible = true;
            lblContent.Visible = true;
        }

        /// <summary>
        /// 使激活码查询的相关元素不可用
        /// </summary>
        private void DisableActivationSearch()
        {
            txtActivationCode.Clear();
            txtPwd.Clear();
            txtActivationCode.Enabled = false;
            txtPwd.Enabled = false;
            HideResultLabel();
        }

        /// <summary>
        /// 使帐号查询的相关元素不可用
        /// </summary>
        private void DisableAccountSearch()
        {
            txtAccount.Enabled = false;
            txtAccount.Clear();
            HideResultLabel();
        }

        /// <summary>
        /// 使激活码查询的相关元素可用
        /// </summary>
        private void EnableActivationSearch()
        {
            txtActivationCode.Enabled = true;
            txtPwd.Enabled = true;
        }

        /// <summary>
        /// 使帐号查询的相关元素可用
        /// </summary>
        private void EnableAccountSearch()
        {
            txtAccount.Enabled = true ;
        }

        /// <summary>
        /// 激活码查询
        /// </summary>
        private void ChkActivation(object sender, System.EventArgs e)
        {
            try
            {
                C_Global.CEnum.Message_Body[] msgBody = new C_Global.CEnum.Message_Body[2];

                msgBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                msgBody[0].eName = C_Global.CEnum.TagName.O2JAM2_Id1;
                msgBody[0].oContent = txtActivationCode.Text.Trim();

                msgBody[1].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                msgBody[1].eName = C_Global.CEnum.TagName.O2JAM2_Id2;
                msgBody[1].oContent = txtPwd.Text.Trim();

                lock (typeof(C_Event.CSocketEvent))
                {
                    activationResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.O2JAM2_ACCOUNTACTIVE_QUERY, C_Global.CEnum.Msg_Category.O2JAM2_ADMIN, msgBody);
                }

                switch (activationResult[0, 0].oContent.ToString())
                {
                    case "1":
                        lblContent.Text = config.ReadConfigValue("MBAF", "AS_CODE_CodeNotExist").Replace("{ActiveCode}", txtActivationCode.Text);   
                    //lblContent.Text = "激活码 " + txtActivationCode.Text + " 不存在";
                        break;
                    case "2":
                        lblContent.Text = config.ReadConfigValue("MBAF", "AS_CODE_ErrorPassword").Replace("{Password}", activationResult[0, 1].oContent.ToString());  
                    //lblContent.Text = "输入的密码错误，正确的密码应为：" + activationResult[0, 1].oContent.ToString();
                        break;
                    case "3":
                        lblContent.Text = config.ReadConfigValue("MBAF", "AS_CODE_CodeNotUsed").Replace("{ActiveCode}", txtActivationCode.Text);  
                        //lblContent.Text = "激活码 " + txtActivationCode.Text + " 暂未使用";
                        break;
                    case "4":
                        lblContent.Text = config.ReadConfigValue("MBAF", "AS_CODE_CodeUsed").Replace("{ActiveCode}", txtActivationCode.Text).Replace("{UserID}", activationResult[0, 1].oContent.ToString());  
                        //lblContent.Text = "激活码 " + txtActivationCode.Text + " 已被使用，使用者ID：" + activationResult[0, 1].oContent.ToString();
                        break;
                    default:
                        lblContent.Text = activationResult[0, 0].oContent.ToString();
                        break;
                }
                ShowResultLabel();
                Status.WriteStatusText(this.MdiParent, config.ReadConfigValue("MBAF", "AS_CODE_StatusText"));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 帐号查询
        /// </summary>
        private void ChkAccount(object sender, System.EventArgs e)
        {
            try
            {
                C_Global.CEnum.Message_Body[] msgBody = new C_Global.CEnum.Message_Body[2];

                msgBody[0].eTag = C_Global.CEnum.TagFormat.TLV_STRING;
                msgBody[0].eName = C_Global.CEnum.TagName.CR_ACCOUNT;
                msgBody[0].oContent = txtAccount.Text.Trim();

                msgBody[1].eTag = C_Global.CEnum.TagFormat.TLV_INTEGER;
                msgBody[1].eName = C_Global.CEnum.TagName.CR_ACTION;
                msgBody[1].oContent = 1;

                lock (typeof(C_Event.CSocketEvent))
                {
                    accountResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.CR_ACCOUNT_QUERY, C_Global.CEnum.Msg_Category.CR_ADMIN, msgBody);
                }

                switch (accountResult[0, 0].oContent.ToString())
                {
                    case "0":
                        lblContent.Text = config.ReadConfigValue("MBAF", "AS_CODE_AccountNotExist").Replace("{Account}", txtAccount.Text);  
                    //lblContent.Text = "帐号 " + txtAccount.Text + " 不存在";
                        break;
                    default:
                        if (accountResult[0, 1].oContent.ToString().Equals("y"))
                        {
                            lblContent.Text = config.ReadConfigValue("MBAF", "AS_CODE_AccountIsActive").Replace("{Account}", txtAccount.Text).Replace("{ActiveCode}", accountResult[0, 0].oContent.ToString()).Replace("{Password}", accountResult[0, 0].oContent.ToString());  
                            //lblContent.Text = "帐号 " + txtAccount.Text + " 已激活，使用激活码：" + accountResult[0, 3].oContent.ToString() + "、密码：" + accountResult[0, 0].oContent.ToString();
                        }
                        else if (accountResult[0, 1].oContent.ToString().Equals("n"))
                        {
                            lblContent.Text = config.ReadConfigValue("MBAF", "AS_CODE_AccountNotActive").Replace("{Account}", txtAccount.Text);  
                            //lblContent.Text = "帐号 " + txtAccount.Text + " 暂未激活";
                        }
                        else
                        {
                            lblContent.Text = config.ReadConfigValue("MBAF", "AS_CODE_AccountNotExist").Replace("{Account}", txtAccount.Text);  
                            //lblContent.Text = "帐号 " + txtAccount.Text + " 不存在";
                        }
                        break;
                }
                ShowResultLabel();
                Status.WriteStatusText(this.MdiParent, config.ReadConfigValue("MBAF", "AS_CODE_StatusText"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 线程
        /// <summary>
        /// 激活码查询
        /// </summary>
        private void InvokeChkActivation()
        {
            Invoke(new EventHandler(ChkActivation));
        }
        /// <summary>
        /// 帐号查询
        /// </summary>
        private void InvokeChkAccount()
        {
            Invoke(new EventHandler(ChkAccount));
        }
        #endregion

        #region 调用函数
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            this.m_ClientEvent = (CSocketEvent)oEvent;
            if (oParent != null)
            {
                this.MdiParent = (Form)oParent;
                this.Show();
            }
            else
            {
                this.ShowDialog();
            }
            return this;
        }
        #endregion

        #region 变量
        private CSocketEvent m_ClientEvent = null;

        C_Global.CEnum.Message_Body[,] activationResult = null; //激活码查询结果
        C_Global.CEnum.Message_Body[,] accountResult = null;    //帐号查询结果
        #endregion

        #region 线程
        private void InvokeWriteSearchText()
        {
            Invoke(new EventHandler(WriteSearchText));
        }
        #endregion

        private void chkbxActivation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxActivation.Checked)
            {
                EnableActivationSearch();
                if (chkbxAccount.Checked)
                {
                    chkbxAccount.Checked = false;
                    DisableAccountSearch();
                }
            }
            else
            {
                DisableActivationSearch();
            }
        }

        private void chkbxAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxAccount.Checked)
            {
                EnableAccountSearch();
                if (chkbxActivation.Checked)
                {
                    chkbxActivation.Checked = false;
                    DisableActivationSearch();
                } 
            }
            else
            {
                DisableAccountSearch();
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (chkbxActivation.Checked)
            {
                txtActivationCode.Clear();
                txtPwd.Clear();
            }
            if (chkbxAccount.Checked)
            {
                txtAccount.Clear();
            }
            HideResultLabel();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            HideResultLabel();

            #region 内容检测
            if (chkbxActivation.Checked)
            {
                if (txtActivationCode.Text == "" || txtActivationCode.Text == null)
                {
                    txtActivationCode.Focus();
                    MessageBox.Show(config.ReadConfigValue("MBAF", "AS_CODE_InputActiveCode"));
                    return;
                }
                if (txtPwd.Text == "" || txtPwd.Text == null)
                {
                    txtPwd.Focus();
                    MessageBox.Show(config.ReadConfigValue("MBAF", "AS_CODE_InputPassword"));
                    return;
                }
            }
            if (chkbxAccount.Checked)
            {
                if (txtAccount.Text == "" || txtAccount.Text == null)
                {
                    txtAccount.Focus();
                    MessageBox.Show(config.ReadConfigValue("MBAF", "AS_CODE_InputAccount"));
                    return;
                }
            }
            #endregion

            Thread thdStatus = new Thread(new ThreadStart(InvokeWriteSearchText));
            thdStatus.Start();

            if (chkbxActivation.Checked)
            {
                Thread thdChk = new Thread(new ThreadStart(InvokeChkActivation));
                thdChk.Start();
            }
            if (chkbxAccount.Checked)
            {
                Thread thdChk = new Thread(new ThreadStart(InvokeChkAccount));
                thdChk.Start();
            }
            
        }
    }
}