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
using System.Text.RegularExpressions;
namespace M_Audition
{
    [C_Global.CModuleAttribute("密保状态修改", "FrmModifyUser", "9you密保", "pwd")]
    public partial class FrmModifyUser : Form
    {
        public FrmModifyUser()
        {
            InitializeComponent();
        }
        private CSocketEvent m_ClientEvent = null;


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
        private void FrmModifyUser_Load(object sender, EventArgs e)
        {

        }

        private void Txtesn_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = Txtesn.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            Txtesn.Text = rx.Replace(txt, "");
        }

        private void Txtesn_MouseUp(object sender, MouseEventArgs e)
        {
            string txt = Txtesn.Text.Trim();
            Regex rx = new Regex(@"[^\d]");
            Txtesn.Text = rx.Replace(txt, "");
        }

        private void BtnLock_Click(object sender, EventArgs e)
        {
            LblStatus.Text = "";
            if (txtUser.Text.Trim().Length > 0 && Txtesn.Text.Trim().Length > 0)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.TOKEN_service;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = "lockUser";

                mContent[1].eName = CEnum.TagName.TOKEN_esn;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Txtesn.Text.Trim();

                mContent[2].eName = CEnum.TagName.TOKEN_username;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = txtUser.Text.Trim();

                CEnum.Message_Body[,] mResult = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.TOKEN_MODIFYUSER_QUERY, mContent);
                }
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                if (mResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    LblStatus.Text = "操作失败";
                    // LblStatus.Text = config.ReadConfigValue("MSOCCER", "FAA_Code_lbltxtsuccess").Replace("{user}", TxtAccount.Text.Trim()).Replace("{server}", CmbServer.Text.Trim());
                }
                else
                {
                    LblStatus.Text = mResult[0, 0].oContent.ToString();
                    //LblStatus.Text = config.ReadConfigValue("MSOCCER", "FAA_Code_lbltxtfailed").Replace("{user}", TxtAccount.Text.Trim()).Replace("{server}", CmbServer.Text.Trim());
                }
            }
            else
            {
                MessageBox.Show("请输入用户名或ESN序列号");
            }
        }

        private void BtnUnlock_Click(object sender, EventArgs e)
        {
            LblStatus.Text = "";
            if (txtUser.Text.Trim().Length > 0 && Txtesn.Text.Trim().Length > 0)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.TOKEN_service;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = "unlockUser";

                mContent[1].eName = CEnum.TagName.TOKEN_esn;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Txtesn.Text.Trim();

                mContent[2].eName = CEnum.TagName.TOKEN_username;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = txtUser.Text.Trim();

                CEnum.Message_Body[,] mResult = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.TOKEN_MODIFYUSER_QUERY, mContent);
                }
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                if (mResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    LblStatus.Text = "操作失败";
                    // LblStatus.Text = config.ReadConfigValue("MSOCCER", "FAA_Code_lbltxtsuccess").Replace("{user}", TxtAccount.Text.Trim()).Replace("{server}", CmbServer.Text.Trim());
                }
                else
                {
                    LblStatus.Text = mResult[0, 0].oContent.ToString();
                    //LblStatus.Text = config.ReadConfigValue("MSOCCER", "FAA_Code_lbltxtfailed").Replace("{user}", TxtAccount.Text.Trim()).Replace("{server}", CmbServer.Text.Trim());
                }
            }
            else
            {
                MessageBox.Show("请输入用户名或ESN序列号");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            LblStatus.Text = "";
            if (txtUser.Text.Trim().Length > 0 && Txtesn.Text.Trim().Length > 0)
            {
                CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

                mContent[0].eName = CEnum.TagName.TOKEN_service;
                mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[0].oContent = "deleteUser";

                mContent[1].eName = CEnum.TagName.TOKEN_esn;
                mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[1].oContent = Txtesn.Text.Trim();

                mContent[2].eName = CEnum.TagName.TOKEN_username;
                mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
                mContent[2].oContent = txtUser.Text.Trim();

                CEnum.Message_Body[,] mResult = null;
                lock (typeof(C_Event.CSocketEvent))
                {
                    mResult = Operation_Card.GetResult(m_ClientEvent, CEnum.ServiceKey.TOKEN_MODIFYUSER_QUERY, mContent);
                }
                if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
                {
                    MessageBox.Show(mResult[0, 0].oContent.ToString());
                    return;
                }

                if (mResult[0, 0].oContent.ToString().Equals("FAILURE"))
                {
                    LblStatus.Text = "操作失败";
                    // LblStatus.Text = config.ReadConfigValue("MSOCCER", "FAA_Code_lbltxtsuccess").Replace("{user}", TxtAccount.Text.Trim()).Replace("{server}", CmbServer.Text.Trim());
                }
                else
                {
                    LblStatus.Text = mResult[0, 0].oContent.ToString();
                    //LblStatus.Text = config.ReadConfigValue("MSOCCER", "FAA_Code_lbltxtfailed").Replace("{user}", TxtAccount.Text.Trim()).Replace("{server}", CmbServer.Text.Trim());
                }
            }
            else
            {
                MessageBox.Show("请输入用户名或ESN序列号");
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}