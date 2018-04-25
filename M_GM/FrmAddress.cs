using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Strategy;
using C_Global;
using C_Event;
using Language;
namespace M_GM
{
    [C_Global.CModuleAttribute("notes地址", "FrmAddress", "notes地址", "User Group")]
    public partial class FrmAddress : Form
    {
        public FrmAddress()
        {
            InitializeComponent();
        }

        #region 调用函数
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent, object oReturnValue)
        {
            this.m_ClientEvent = (CSocketEvent)oEvent;

            if (oParent != null)
            {
                this.MdiParent = (Form)oParent;
                this.Show();
            }
            else
            {
                if (oReturnValue != null)
                {
                    this._returnValue = (Strategy.Betweenness)oReturnValue;
                }
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterParent;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.ShowInTaskbar = false;
                this.ShowDialog();
            }

            return this;

        }
        #endregion
        bool isRedirect = false;
        #region 变量
        private CSocketEvent m_ClientEvent = null;
        //ArrayList moduleIDs = new ArrayList();
        //private C_Global.CEnum.Message_Body[,] departmentMsg = null;
        private C_Global.CEnum.Message_Body[,] userInfos = null;

        private Strategy.Betweenness _returnValue = null;
        #endregion

        public List<string> Group(CEnum.Message_Body[,] _msg)
        {
            List<string> __groups = null;

            try
            {
                if (_msg != null)
                {
                    __groups = new List<string>();
                    for (int i = 0; i < _msg.GetLength(0); i++)
                    {
                        __groups.Add(_msg[i, 0].oContent.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return __groups;
        }

        /// <summary>
        /// 查询组内人员NOTES地址
        /// </summary>
        /// <param name="__group_name"></param>
        /// <param name="__msg"></param>
        /// <returns></returns>
        public List<string> ListGroup(string __group_name, CEnum.Message_Body[,] __msg)
        {
            List<string> __users = null;

            try
            {
                if (__group_name == null)
                {
                    throw new Exception("组名不能为空");
                }
                else if (__msg == null)
                {
                    throw new Exception("NOTES用户列表不能为空");
                }
                else
                {
                    for (int i = 0; i < __msg.GetLength(0); i++)
                    {
                        if (__msg[i, 0].oContent.ToString() == __group_name)
                        {
                            __users = new List<string>();
                            string __user_string = __msg[i, 1].oContent.ToString();
                            string[] __user_array = __user_string.Split(new char[] { ';' });
                            for (int j = 0; j < __user_array.Length; j++)
                            {
                                __users.Add(__user_array[j]);
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return __users;
        }

        private void FrmAddress_Load(object sender, EventArgs e)
        {
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[1];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            
            lock (typeof(C_Event.CSocketEvent))
            {
                userInfos = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.NOTES_LINKER_GET, C_Global.CEnum.Msg_Category.NOTES_ADMIN, mContent);
            }
            if (userInfos[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(userInfos[0, 0].oContent.ToString());
                return;
            }

             if (userInfos != null)
            {
                for (int i = 0; i < userInfos.GetLength(0); i++)
                {
                   // List<string> __user_mail_list = __linker.ListGroup(__linker_msg[i, 0].oContent.ToString(), __linker_msg);
                    List<string> __user_mail_list = Group(userInfos);

                    for (int j = 0; j < __user_mail_list.Count; j++)
                    {
                        comboBox1.Items.Add(__user_mail_list[j]);
                        //listBox1.Items.Add(__user_mail_list[j]);
                    }
                }
                comboBox1.SelectedIndex = 0;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            try
            {
                if (isRedirect)
                {
                    listBox1.Items.Clear();

                    //Linker __linker = new Linker(m_ClientEvent);
                    List<string> __users = ListGroup(comboBox1.Text, userInfos);

                    if (__users != null)
                    {
                        for (int i = 0; i < __users.Count; i++)
                        {
                            listBox1.Items.Add(__users[i]);
                        }
                    }
                }
                else
                {
                    isRedirect = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Add(listBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex != -1)
                    listBox2.Items.Add(listBox1.SelectedItem.ToString());
                else
                    MessageBox.Show("请选择邮件地址");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox2.SelectedIndex != -1)
                    listBox2.Items.Remove(listBox2.SelectedItem.ToString());
                else
                    MessageBox.Show("请选择邮件地址");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _returnValue.RESULT = Strategy.BetweennessValue.FAILURE;
            Close(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable _hash = new Hashtable();

                if (listBox2.Items.Count > 0)
                {
                    string __receiver = null;
                    for (int i = 0; i < listBox2.Items.Count; i++)
                    {
                        __receiver += listBox2.Items[i].ToString() + ";";
                    }

                    _hash.Add("RECEIVER", __receiver);
                }



                _returnValue.HASHTABLE = _hash;
                _returnValue.RESULT = Strategy.BetweennessValue.SUCESS;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}