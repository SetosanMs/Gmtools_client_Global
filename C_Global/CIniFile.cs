using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace C_Global
{
    /// <summary>
    /// CIniFile ��д INI �ļ���
    /// </summary>    
    public class CIniFile
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="strPath">�����ļ�·��</param>
        public CIniFile(string strPath)
        {
            this.strPathOfIni = strPath;
        }

        /// <summary>
        /// ReadValue ��ȡָ��������
        /// </summary>
        /// <param name="strSection">Ƭ������</param>
        /// <param name="strKey">������</param>
        /// <returns>������</returns>
        public string ReadValue(string strSection, string strKey)
        {
            try
            {
                StringBuilder strValue = new StringBuilder(1024*10);
                GetPrivateProfileString(strSection, strKey, "", strValue, 1024*10, this.strPathOfIni);

                return strValue.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        /// <summary>
        /// WriteValue д��ָ��������
        /// </summary>
        /// <param name="strSection">Ƭ������</param>
        /// <param name="strKey">������</param>
        /// <param name="strValue">������</param>
        public void WriteValue(string strSection, string strKey, string strValue)
        {
            WritePrivateProfileString(strSection, strKey, strValue, this.strPathOfIni);
        }

        #region �ڲ�����
        private string strPathOfIni;	//INI�ļ�·��

        #region ���� Win32 API ����
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        #endregion

        #endregion
    }
}
