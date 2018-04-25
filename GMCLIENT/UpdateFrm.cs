using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using Language;



namespace GMCLIENT
{
    public partial class UpdateFrm : Form
    {
        C_Global.CEnum.Message_Body[,] MustUpdateFileMsg = null;
        ConfigValue config = null;

        public UpdateFrm()
        {
            InitializeComponent();
        }

        public UpdateFrm(C_Global.CEnum.Message_Body[,] MustUpdateFileMsg)
        {
            this.MustUpdateFileMsg = MustUpdateFileMsg;
            InitializeComponent();
        }

        private void UpdateFrm_Load(object sender, EventArgs e)
        {
            /////////////////////////////////////////
            // 获取语言文字库                      //
            /////////////////////////////////////////
            config = (ConfigValue)m_ClientEvent.GetInfo("INI");
            /////////////////////////////////////////
            // 初始化界面文字                      //
            /////////////////////////////////////////
            IntiUI();
            Form.CheckForIllegalCrossThreadCalls = false;

            Thread thread = new Thread(new ThreadStart(DownloadFile));
            thread.Start();
           
        }

        public void DownloadFile()
        {
            int fileSize = 0;

            string fileAddress = null;
            string[] fileAddressSplit = null;
            C_Socket.Query_Structure[] structList = new C_Socket.Query_Structure[1];
            C_Socket.Query_Structure strut = null;
            byte[] bytes = null;

            this.Invoke(new EventHandler(RefreshUpdateInfo));
            //C_Global.CEnum.Message_Body[,] updateResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GMTOOLS_UPDATELIST_QUERY, C_Global.CEnum.Msg_Category.COMMON, null);

            //textBoxUpdateInfo.Text = "更新信息如下："+"\n";
            //for (int i = 1; i <= updateResult.GetLength(0); i++)
            //{
            //    textBoxUpdateInfo.Text += "（" + i.ToString() + "）" + updateResult[i - 1, 1].oContent.ToString() + "：" + updateResult[i - 1, 2].oContent.ToString();
            //}
            //拉文件
            for (int i = 0; i < MustUpdateFileMsg.GetLength(0); i++)
            {
                
                int iLangIndex = MustUpdateFileMsg[i, 2].oContent.ToString().IndexOf("Lang");

                if (iLangIndex != -1)
                {

                    fileName = MustUpdateFileMsg[i, 0].oContent.ToString();
                    fileSize = int.Parse(MustUpdateFileMsg[i, 3].oContent.ToString());
                    fileAddress = MustUpdateFileMsg[i, 2].oContent.ToString().Substring(iLangIndex);

                    string file_path = @".\Temp\" + MustUpdateFileMsg[i, 2].oContent.ToString().Substring(iLangIndex);

                    strut = new C_Socket.Query_Structure(2);

                    bytes = C_Socket.TLV_Structure.ValueToByteArray(C_Global.CEnum.TagFormat.TLV_STRING, fileName);
                    strut.AddTagKey(C_Global.CEnum.TagName.UpdateFileName, C_Global.CEnum.TagFormat.TLV_STRING, (uint)bytes.Length, bytes);

                    bytes = C_Socket.TLV_Structure.ValueToByteArray(C_Global.CEnum.TagFormat.TLV_STRING, fileAddress);
                    strut.AddTagKey(C_Global.CEnum.TagName.UpdateFilePath, C_Global.CEnum.TagFormat.TLV_STRING, (uint)bytes.Length, bytes);

                    structList[0] = strut;

                    byte[] ss = C_Event.CSocketEvent.COMMON_MES_RESP(structList, C_Global.CEnum.Msg_Category.COMMON, C_Global.CEnum.ServiceKey.CLIENT_PATCH_UPDATE, 2).bMsgBuffer;
                    byte[] abc = m_ClientEvent.RequestResult(ss, fileSize);


                    

                    if (!Directory.Exists(file_path))
                    {
                        Directory.CreateDirectory(file_path);
                    }



                    string file_address = file_path + @"\" + fileName;
                    FileStream fs = new FileStream(file_address, FileMode.Create, FileAccess.Write, FileShare.Write, 1024);
                    fs.Write(abc, 0, abc.Length);
                    fs.Close();

                }
                else
                {
                    //非INI文件

                    fileName = MustUpdateFileMsg[i, 0].oContent.ToString();
                    fileSize = int.Parse(MustUpdateFileMsg[i, 3].oContent.ToString());
                    fileAddressSplit = MustUpdateFileMsg[i, 2].oContent.ToString().Split(new char[] { '\\' });
                    fileAddress = fileAddressSplit[fileAddressSplit.Length - 1];

                    strut = new C_Socket.Query_Structure(2);

                    bytes = C_Socket.TLV_Structure.ValueToByteArray(C_Global.CEnum.TagFormat.TLV_STRING, fileName);
                    strut.AddTagKey(C_Global.CEnum.TagName.UpdateFileName, C_Global.CEnum.TagFormat.TLV_STRING, (uint)bytes.Length, bytes);

                    bytes = C_Socket.TLV_Structure.ValueToByteArray(C_Global.CEnum.TagFormat.TLV_STRING, fileAddress);
                    strut.AddTagKey(C_Global.CEnum.TagName.UpdateFilePath, C_Global.CEnum.TagFormat.TLV_STRING, (uint)bytes.Length, bytes);

                    structList[0] = strut;

                    byte[] ss = C_Event.CSocketEvent.COMMON_MES_RESP(structList, C_Global.CEnum.Msg_Category.COMMON, C_Global.CEnum.ServiceKey.CLIENT_PATCH_UPDATE, 2).bMsgBuffer;
                    byte[] abc = m_ClientEvent.RequestResult(ss, fileSize);


                    if (fileAddress.Equals("root"))
                    {
                        fileAddress = "";
                        //查看目录并创建
                        if (!Directory.Exists(@".\Temp"))
                        {
                            Directory.CreateDirectory(@".\Temp");
                        }
                    }
                    else
                    {
                        if (!Directory.Exists(@".\Temp\Modules"))
                        {
                            Directory.CreateDirectory(@".\Temp\Modules");
                        }
                        if (!Directory.Exists(@".\Temp\Lang"))
                        {
                            Directory.CreateDirectory(@".\Temp\Lang");
                        }
                        if (!Directory.Exists(@".\Temp\Schmem"))
                        {
                            Directory.CreateDirectory(@".\Temp\Schmem");
                        }
                    }

                    fileAddress = @".\Temp\" + fileAddress + @".\" + fileName;
                    FileStream fso = new FileStream(fileAddress, FileMode.Create, FileAccess.Write, FileShare.Write, 1024);
                    fso.Write(abc, 0, abc.Length);
                    fso.Close();
                }


                this.UdProgressBar.Value = (int)((float)(i + 1) / (float)MustUpdateFileMsg.GetLength(0) * 100);
                this.Invoke(new EventHandler(RefreshUILoading));
            }
            this.Invoke(new EventHandler(RefreshUIFinish));
        }

        public void RefreshUpdateInfo(object sender, System.EventArgs e)
        {
            C_Global.CEnum.Message_Body[,] updateResult = m_ClientEvent.RequestResult(C_Global.CEnum.ServiceKey.GMTOOLS_UPDATELIST_QUERY, C_Global.CEnum.Msg_Category.COMMON, null);

            textBoxUpdateInfo.Text = config.ReadConfigValue("MAIN", "Update_Info") + "\r\n";

            if (updateResult[0, 0].eName == C_Global.CEnum.TagName.ERROR_Msg)
            {
                textBoxUpdateInfo.Text += updateResult[0, 0].oContent.ToString();
            }
            else
            {
                for (int i = 1; i <= updateResult.GetLength(0); i++)
                {
                    textBoxUpdateInfo.Text += "（" + i.ToString() + "）" + updateResult[i - 1, 1].oContent.ToString() + "：" + updateResult[i - 1, 2].oContent.ToString() + "\r\n";
                }
            }
        }

        public void RefreshUILoading(object sender, System.EventArgs e)
        {
            //this.UdProgressBar.Value = 0;
            this.UdLabel.Text = config.ReadConfigValue("MAIN","Update_Code_Downloading") + fileName + " ...";
            //for (int i = 0; i <= 100; i++)
            //{
            //    this.UdProgressBar.Value = i;
            //}
        }

        public void RefreshUIFinish(object sender, System.EventArgs e)
        {
            this.UdLabel.Text = config.ReadConfigValue("MAIN","Update_Code_Finish");
            this.checkBoxAutoLogin.Enabled = true;
            this.buttonDone.Enabled = true;
            //this.timer1.Enabled = true;
        }

        public void CloseWindow(object sender, System.EventArgs e)
        {
            int closeSeconds = 5;
            int leftSeconds = closeSeconds - Seconds;
            this.label2.Text = config.ReadConfigValue("MAIN", "Update_Code_ToCloseApplication").Replace("{Second}", leftSeconds.ToString());
            if (leftSeconds == 0)
            {
                this.timer1.Enabled = false;
                    #region 重起
                    string lApplicationName = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Run.exe";
                    StringBuilder lpApplicationName = new StringBuilder(1000);
                    lpApplicationName.Append(lApplicationName);

                    STARTUPINFO sInfo = new STARTUPINFO();
                    PROCESS_INFORMATION pInfo = new PROCESS_INFORMATION();


                    if (!CreateProcess(lpApplicationName, null, null, null, false, 0, null, null, ref sInfo, ref pInfo))
                    {
                        MessageBox.Show("调用程序" + lApplicationName + "失败");
                    }
                    //WaitForSingleObject(pInfo.hProcess, 600000000);
                    CloseHandle(pInfo.hProcess);
                    CloseHandle(pInfo.hThread);
                    Process.GetCurrentProcess().Kill();
                    #endregion
            }
               
            
        }

        private void IntiUI()
        {
            this.Text = config.ReadConfigValue("MAIN", "Update_UI_Caption");
            this.label1.Text = config.ReadConfigValue("MAIN", "Update_UI_Description");
            this.checkBoxAutoLogin.Text = config.ReadConfigValue("MAIN", "Update_UI_checkBoxAutoLogin");
            this.buttonDone.Text = config.ReadConfigValue("MAIN", "Update_UI_buttonDone");
        }


        #region 调用函数
        /// <summary>
        /// 创建类库中的窗体
        /// </summary>
        /// <param name="oParent">MDI 程序的父窗体</param>
        /// <param name="oSocket">Socket</param>
        /// <returns>类库中的窗体</returns>
        public Form CreateModule(object oParent, object oEvent)
        {
            this.m_ClientEvent = (C_Event.CSocketEvent)oEvent;

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
        private C_Event.CSocketEvent m_ClientEvent = null;
        private string fileName = null;
        private int Seconds = 0;
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            Seconds += 1;
            this.Invoke(new EventHandler(CloseWindow));
        }

        #region DllImport
        [DllImport("Kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern bool CreateProcess(StringBuilder lpApplicationName, StringBuilder lpCommandLine,
                                                                    SECURITY_ATTRIBUTES lpProcessAttributes,
                                                                    SECURITY_ATTRIBUTES lpThreadAttributes,
                                                                    bool bInheritHandles,
                                                                    int dwCreationFlags,
                                                                    StringBuilder lpEnvironment,
                                                                    StringBuilder lpCurrentDirectory,
                                                                    ref STARTUPINFO lpStartupInfo,
                                                                    ref PROCESS_INFORMATION lpProcessInformation
                                                                    );

        [DllImport("Kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("Kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern int WaitForSingleObject(IntPtr hHandle, int dwMilliseconds);
        #endregion

        #region 类
        [StructLayout(LayoutKind.Sequential)]
        public class SECURITY_ATTRIBUTES
        {
            public int nLength;
            public string lpSecurityDescriptor;
            public bool bInheritHandle;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct STARTUPINFO
        {
            public int cb;
            public string lpReserved;
            public string lpDesktop;
            public int lpTitle;
            public int dwX;
            public int dwY;
            public int dwXSize;
            public int dwYSize;
            public int dwXCountChars;
            public int dwYCountChars;
            public int dwFillAttribute;
            public int dwFlags;
            public int wShowWindow;
            public int cbReserved2;
            public byte lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }
        #endregion

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (checkBoxAutoLogin.Checked)
            {
                #region 重起
                string lApplicationName = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\Run.exe";
                StringBuilder lpApplicationName = new StringBuilder(1000);
                lpApplicationName.Append(lApplicationName);

                STARTUPINFO sInfo = new STARTUPINFO();
                PROCESS_INFORMATION pInfo = new PROCESS_INFORMATION();


                if (!CreateProcess(lpApplicationName, null, null, null, false, 0, null, null, ref sInfo, ref pInfo))
                {
                    MessageBox.Show("调用程序" + lApplicationName + "失败");
                }
                //WaitForSingleObject(pInfo.hProcess, 600000000);
                CloseHandle(pInfo.hProcess);
                CloseHandle(pInfo.hThread);
                Process.GetCurrentProcess().Kill();
                #endregion
            }
            else
            {
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}