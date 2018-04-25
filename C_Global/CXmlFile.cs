using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace C_Global
{
    /// <summary>
    /// CXmlFile ��д XML �ļ���
    /// </summary>       
    class CXmlFile
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="strPath">�����ļ�·��</param>
        public CXmlFile(string strPath)
        {
            this.strPathOfXml = strPath;
        }

        public string ReadValue(string strSection, string strKey)
        {
            string strContent = null;

            XmlDocument mXml = new XmlDocument();
            mXml.Load(this.strPathOfXml);

            XmlNodeList mNode = mXml.GetElementsByTagName(strSection);

            for (int i = 0; i < mNode.Count; i++)
            {
                for (int j = 0; j < mNode.Item(i).ChildNodes.Count; j++)
                {
                    if (mNode.Item(i).ChildNodes.Item(j).Name == strKey)
                    {
                        strContent = mNode.Item(i).ChildNodes.Item(j).InnerText;
                    }
                }
            }

            return strContent;
        }

        public void WriteValue(string strSection, string strKey, string strValue)
        {
            //XmlNodeList mNode = mXml.GetElementsByTagName(strSection);
            XmlTextWriter mXmlWrite = new System.Xml.XmlTextWriter(this.strPathOfXml, System.Text.UTF8Encoding.UTF8);
            mXmlWrite.Formatting = Formatting.Indented;
            mXmlWrite.WriteStartDocument();
            mXmlWrite.WriteStartElement("property");
            mXmlWrite.WriteStartElement(strSection);
            mXmlWrite.WriteElementString(strKey, strValue);
            mXmlWrite.WriteEndElement();
            mXmlWrite.WriteEndElement();
            mXmlWrite.WriteEndDocument();
            mXmlWrite.Flush();
            mXmlWrite.Close();
        }

        #region ˽����Ϣ
        string strPathOfXml = null;
        #endregion
    }
}
