using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

using C_Global;
using C_Event;

using Language;

namespace M_Audition
{
    class Operation_Audition
    {
        public static int iPageSize = 50;
        private static ConfigValue config = null;


        /// <summary>
        /// ��ȡ��������ַ�б�
        /// </summary>
        /// <param name="mEvent">Socket�¼�</param>
        /// <param name="mContent">��Ϣ����</param>
        /// <returns>������</returns>
        public static CEnum.Message_Body[,] GetServerList(CSocketEvent mEvent, CEnum.Message_Body[] mContent)
        {
            CEnum.Message_Body[,] mReturn = null;

            mReturn =
                mEvent.RequestResult(CEnum.ServiceKey.SERVERINFO_IP_QUERY, CEnum.Msg_Category.COMMON, mContent);

            return mReturn;
        }

        //#region ���Կ�
        ///// <summary>
        /////�����ֿ�
        ///// </summary>
        //ConfigValue config = null;

        ///// <summary>
        ///// ��ʼ�����������Կ�
        ///// </summary>
        //private void IntiFontLib()
        //{
        //    config = (ConfigValue)m_ClientEvent.GetInfo("INI");
        //}

        //#endregion


        public static object DecodeContent(CEnum.TagFormat mFormat, string mContent)
        {
            object mObject = null;

            switch (mFormat)
            { 
                case CEnum.TagFormat.TLV_BOOLEAN:
                    mObject = Convert.ToBoolean(mContent);
                    break;
                case CEnum.TagFormat.TLV_INTEGER:
                    mObject = Convert.ToInt32(mContent);
                    break;
                case CEnum.TagFormat.TLV_DATE:
                    mObject = Convert.ToDateTime(mContent).Date;
                    break;
                case CEnum.TagFormat.TLV_TIME:
                    mObject = Convert.ToDateTime(mContent).TimeOfDay;
                    break;
                case CEnum.TagFormat.TLV_EXTEND:
                case CEnum.TagFormat.TLV_MONEY:
                    mObject = Convert.ToDouble(mContent);
                    break;
                case CEnum.TagFormat.TLV_NUMBER:
                    mObject = Convert.ToInt32(mContent);
                    break;
                case CEnum.TagFormat.TLV_STRING:
                    mObject = mContent;
                    break;
                case CEnum.TagFormat.TLV_TIMESTAMP:
                    mObject = Convert.ToDateTime(mContent);
                    break;
            }

            return mObject;
        }

        /// <summary>
        /// ��ȡ��Ϣ�б�
        /// </summary>
        /// <param name="mEvent">Socket�¼�</param>
        /// <param name="mKey">������</param>
        /// <param name="mContent">��Ϣ����</param>
        /// <returns>������</returns>
        public static CEnum.Message_Body[,] GetResult(CSocketEvent mEvent, CEnum.ServiceKey mKey, CEnum.Message_Body[] mContent)
        {
            CEnum.Message_Body[,] mReturn = null;

            mReturn =
                mEvent.RequestResult(mKey, CEnum.Msg_Category.AU_ADMIN, mContent);

            return mReturn;
        }
        
        /// <summary>
        /// ���� ComboBox ����
        /// </summary>
        /// <param name="val">ComboBox ����</param>
        /// <param name="mCmbBox">ComboBox �ؼ�</param>
        /// <returns>ComboBox �ؼ�</returns>
        public static System.Windows.Forms.ComboBox BuildCombox(CEnum.Message_Body[,] val, System.Windows.Forms.ComboBox mCmbBox)
        {
            try
            {
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    mCmbBox.Items.Add(val[i, 1].oContent);
                }

                mCmbBox.SelectedIndex = 0;
            }
            catch
            {

            }

            return mCmbBox;
        }

        public static DataTable BuildDataTable(CSocketEvent mEvent, CEnum.Message_Body[,] val, System.Windows.Forms.DataGridView mGrid, out int PageCount)
        {
            config = (ConfigValue)mEvent.GetInfo("INI"); 
            DataTable mDataTable = BuildColumn(mEvent, val);

            if (mGrid.Name == "GrdGift")
            {
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    for (int j = 0; j < val.GetLength(1); j++)
                    {
                        if (val[i, j].eName == CEnum.TagName.SDO_BigType)
                        {
                            if (val[i, j].oContent.ToString() == "0")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_dress");
                            if (val[i, j].oContent.ToString() == "1")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_item");
                        }

                        if (val[i, j].eName == CEnum.TagName.SDO_SmallType)
                        {
                            if (val[i, j].oContent.ToString() == "0")
                            {
                                if (val[i, j-1].eName == CEnum.TagName.SDO_BigType && val[i, j-1].oContent.ToString() == "0")
                                    val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_head");
                                else
                                    val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_item");
                            }

                            if (val[i, j].oContent.ToString() == "100")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_head"); ;
                                
                            if (val[i, j].oContent.ToString() == "1" || val[i, j].oContent.ToString() == "101")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_hair");
                            if (val[i, j].oContent.ToString() == "2" || val[i, j].oContent.ToString() == "102")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_body");
                            if (val[i, j].oContent.ToString() == "3" || val[i, j].oContent.ToString() == "103")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_leg");
                            if (val[i, j].oContent.ToString() == "4" || val[i, j].oContent.ToString() == "104")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_hand");
                            if (val[i, j].oContent.ToString() == "5" || val[i, j].oContent.ToString() == "105")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_feet");
                            if (val[i, j].oContent.ToString() == "6" || val[i, j].oContent.ToString() == "106")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_face");
                            if (val[i, j].oContent.ToString() == "150")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_onedress");
                        }
                    }
                }
            }

            mGrid.DataSource = BuildRow(mEvent, val, mDataTable, out PageCount);

            /*
            DataRow mDataRow = null;
            DataTable mDataTable = new DataTable();

            //������ʽ
            mDataTable.Columns.Add("����", typeof(int));
            mDataTable.Columns.Add("����������", typeof(string));
            mDataTable.Columns.Add("��ɫ����", typeof(string));
            mDataTable.Columns.Add("����״̬", typeof(bool));
            mDataTable.Columns.Add("����״̬", typeof(bool));
            mDataTable.Columns.Add("��ͣ״̬", typeof(bool));
            mDataTable.Columns.Add("������", typeof(string));
            mDataTable.Columns.Add("��  ��", typeof(string));

            //������¼
            mDataRow = mDataTable.NewRow();
            mDataRow["����"] = 0;
            mDataRow["����������"] = "����";
            mDataRow["��ɫ����"] = "3G";
            mDataRow["����״̬"] = 0;
            mDataRow["����״̬"] = 0;
            mDataRow["��ͣ״̬"] = 0;
            mDataRow["������"] = 0;
            mDataRow["��  ��"] = 0;

            mDataTable.Rows.Add(mDataRow);

            mDataRow = mDataTable.NewRow();
            mDataRow["����"] = 0;
            mDataRow["����������"] = "����2";
            mDataRow["��ɫ����"] = "3G2";
            mDataRow["����״̬"] = 0;
            mDataRow["����״̬"] = 0;
            mDataRow["��ͣ״̬"] = 0;
            mDataRow["������"] = 0;
            mDataRow["��  ��"] = 0;

            mDataTable.Rows.Add(mDataRow);
            * */
            //return mDataTable;
             
            return null;
        }

        public static object GetTimes(CEnum.Message_Body[,] val, string iItemID)
        {
            object oResult = null;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (iItemID.Equals(val[i, 0].oContent.ToString()))
                {
                    oResult = val[i, 2].oContent;
                    break;
                }
            }

            return oResult;
        }

        public static object GetLimit(CEnum.Message_Body[,] val, string iItemID)
        {
            object oResult = null;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (iItemID.Equals(val[i, 0].oContent.ToString()))
                {
                    oResult = val[i, 3].oContent;
                    break;
                }
            }

            return oResult;
        }

        #region ˽�к���
        /// <summary>
        /// ���� DataGridView ��
        /// </summary>
        /// <param name="val">����</param>
        /// <param name="mDataTable">DataTable</param>
        /// <returns>DataTable</returns>
        private static DataTable BuildColumn(CSocketEvent mEvent, CEnum.Message_Body[,] val)
        {
            config = (ConfigValue)mEvent.GetInfo("INI");
            DataTable mDataTable = new DataTable();

            for (int i = 0; i < val.GetLength(1); i++)
            {
               
                if (val[0, i].eName != CEnum.TagName.PageCount)
                {
                    //mDataTable.Columns.Add((string)mEvent.DecodeFieldName(val[0, i].eName), typeof(string));
                    mDataTable.Columns.Add((string)config.ReadConfigValue("GLOBAL", val[0, i].eName.ToString()), typeof(string));
                }
                
            }

            return mDataTable;
        }

        /// <summary>
        /// ���� DataGridView ��
        /// </summary>
        /// <param name="val">����</param>
        /// <param name="mDataRow">DataRow</param>
        /// <returns>DataRow</returns>
        private static DataTable BuildRow(CSocketEvent mEvent, CEnum.Message_Body[,] val, DataTable mTable, out int PageCount)
        {
            try
            {
                config = (ConfigValue)mEvent.GetInfo("INI");
                PageCount = 0;
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    DataRow mRow = mTable.NewRow();

                    for (int j = 0; j < val.GetLength(1); j++)
                    {
                        if (val[i, j].eName != CEnum.TagName.PageCount)
                        {
                            if (val[i, j].eName == CEnum.TagName.AU_Status)
                            {
                                if (val[i, j].oContent.ToString() == "2")
                                {
                                    val[i, j].oContent = "������";
                                }
                                else if (val[i, j].oContent.ToString() == "1")
                                {
                                    val[i, j].oContent = "�ѷ���";
                                }
                                else if (val[i, j].oContent.ToString() == "0")
                                {
                                    val[i, j].oContent = "δ����";
                                }
                            }

                            if (val[i, j].eName == CEnum.TagName.SDO_SEX)
                            {
                                if (val[i, j].oContent.ToString().Equals("0"))
                                    //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = config.ReadConfigValue("MAU", "OP_Code_Fsex");
                                    val[i, j].oContent = config.ReadConfigValue("MSDO", "OP_Code_Fsex");
                                else
                                    val[i, j].oContent = config.ReadConfigValue("MSDO", "OP_Code_Msex");
                            }

                            if (val[i, j].oContent == null)
                            {
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = "N/A";
                                mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = "N/A";
                            }
                            else
                            {
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = val[i, j].oContent;
                                mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString().Trim();
                            }
                        }
                        else
                        {
                            PageCount = int.Parse(val[i, j].oContent.ToString());
                        }
                    }

                    mTable.Rows.Add(mRow);
                }

                return mTable;
            }
            catch (Exception ex)
            {
                PageCount = 0;
                return null;
            }

        }

        /// <summary>
        /// ��ȡ ComboBox ѡ��������
        /// </summary>
        /// <param name="val">��¼��</param>
        /// <param name="Condition">��������</param>
        /// <returns></returns>
        public static string GetItemAddr(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.ServerInfo_IP && val[i, j + 1].oContent.Equals(Condition))
                    {
                        strResult = val[i, j].oContent.ToString();
                    }
                }
            }

            return strResult;
        }


        public static string GetGsip(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.AU_GSName && val[i, j].oContent.Equals(Condition))
                    {
                        strResult = val[i, j+1].oContent.ToString();
                    }
                }
            }

            return strResult;
        }


        public static string GetItemName(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.ServerInfo_IP && val[i, j].oContent.Equals(Condition))
                    {
                        strResult = val[i, j+1].oContent.ToString();
                    }
                }
            }

            return strResult;
        }

        public static int GetItemID(CEnum.Message_Body[,] val, string Condition)
        {
            int iResult = 0;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.SDO_ItemCode && val[i, j + 1].oContent.Equals(Condition))
                    {
                        iResult = int.Parse(val[i, j].oContent.ToString());
                    }
                }
            }

            return iResult;
        }

        public static void SaveTxt(ConfigValue config, CEnum.Message_Body[,] mResult, string name, string ini)
        {
            try
            {
                string result = "";
                for (int i = 0; i < mResult.GetLength(1); i++)
                {
                    result += config.ReadConfigValue(ini, mResult[0, i].eName.ToString()) + ":";
                    result += mResult[0, i].oContent.ToString();
                    result += "\r\n";
                }
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + name + ".txt", FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(result);
                sw.Close();
                fs.Close();
            }
            catch
            {

            }
        }
        #endregion
    }

    class Operation_Card
    {
        private static ConfigValue config = null;
        public static int iPageSize = 50;
        public static string Total = "";
        /// <summary>
        /// ��ȡ��������ַ�б�
        /// </summary>
        /// <param name="mEvent">Socket�¼�</param>
        /// <param name="mContent">��Ϣ����</param>
        /// <returns>������</returns>
        public static CEnum.Message_Body[,] GetServerList(CSocketEvent mEvent, CEnum.Message_Body[] mContent)
        {
            CEnum.Message_Body[,] mReturn = null;

            mReturn =
                mEvent.RequestResult(CEnum.ServiceKey.SERVERINFO_IP_QUERY, CEnum.Msg_Category.COMMON, mContent);

            return mReturn;
        }

        public static object DecodeContent(CEnum.TagFormat mFormat, string mContent)
        {
            object mObject = null;

            switch (mFormat)
            {
                case CEnum.TagFormat.TLV_BOOLEAN:
                    mObject = Convert.ToBoolean(mContent);
                    break;
                case CEnum.TagFormat.TLV_INTEGER:
                    mObject = Convert.ToInt32(mContent);
                    break;
                case CEnum.TagFormat.TLV_DATE:
                    mObject = Convert.ToDateTime(mContent).Date;
                    break;
                case CEnum.TagFormat.TLV_TIME:
                    mObject = Convert.ToDateTime(mContent).TimeOfDay;
                    break;
                case CEnum.TagFormat.TLV_EXTEND:
                case CEnum.TagFormat.TLV_MONEY:
                    mObject = Convert.ToDouble(mContent);
                    break;
                case CEnum.TagFormat.TLV_NUMBER:
                    mObject = Convert.ToInt32(mContent);
                    break;
                case CEnum.TagFormat.TLV_STRING:
                    mObject = mContent;
                    break;
                case CEnum.TagFormat.TLV_TIMESTAMP:
                    mObject = Convert.ToDateTime(mContent);
                    break;
            }

            return mObject;
        }

        /// <summary>
        /// ��ȡ��Ϣ�б�
        /// </summary>
        /// <param name="mEvent">Socket�¼�</param>
        /// <param name="mKey">������</param>
        /// <param name="mContent">��Ϣ����</param>
        /// <returns>������</returns>
        public static CEnum.Message_Body[,] GetResult(CSocketEvent mEvent, CEnum.ServiceKey mKey, CEnum.Message_Body[] mContent)
        {
            CEnum.Message_Body[,] mReturn = null;

            mReturn =
                mEvent.RequestResult(mKey, CEnum.Msg_Category.CARD_ADMIN, mContent);

            return mReturn;
        }

        /// <summary>
        /// ���� ComboBox ����
        /// </summary>
        /// <param name="val">ComboBox ����</param>
        /// <param name="mCmbBox">ComboBox �ؼ�</param>
        /// <returns>ComboBox �ؼ�</returns>
        public static System.Windows.Forms.ComboBox BuildCombox(CEnum.Message_Body[,] val, System.Windows.Forms.ComboBox mCmbBox)
        {
            try
            {
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    mCmbBox.Items.Add(val[i, 1].oContent);
                }

                mCmbBox.SelectedIndex = 0;
            }
            catch
            {

            }

            return mCmbBox;
        }

        public static DataTable BuildDataTable(CSocketEvent mEvent, CEnum.Message_Body[,] val, System.Windows.Forms.DataGridView mGrid, out int PageCount)
        {
            config = (ConfigValue)mEvent.GetInfo("INI"); 
            DataTable mDataTable = BuildColumn(mEvent, val);

            if (mGrid.Name == "GrdGift")
            {
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    for (int j = 0; j < val.GetLength(1); j++)
                    {
                        if (val[i, j].eName == CEnum.TagName.SDO_BigType)
                        {
                            if (val[i, j].oContent.ToString() == "0")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_dress");
                            if (val[i, j].oContent.ToString() == "1")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_item");
                        }

                        if (val[i, j].eName == CEnum.TagName.SDO_SmallType)
                        {
                            if (val[i, j].oContent.ToString() == "0")
                            {
                                if (val[i, j - 1].eName == CEnum.TagName.SDO_BigType && val[i, j - 1].oContent.ToString() == "0")
                                    val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_head");
                                else
                                    val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_item");
                            }

                            if (val[i, j].oContent.ToString() == "100")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_head");

                            if (val[i, j].oContent.ToString() == "1" || val[i, j].oContent.ToString() == "101")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_hair");
                            if (val[i, j].oContent.ToString() == "2" || val[i, j].oContent.ToString() == "102")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_body");
                            if (val[i, j].oContent.ToString() == "3" || val[i, j].oContent.ToString() == "103")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_leg");
                            if (val[i, j].oContent.ToString() == "4" || val[i, j].oContent.ToString() == "104")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_hand");
                            if (val[i, j].oContent.ToString() == "5" || val[i, j].oContent.ToString() == "105")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_feet");
                            if (val[i, j].oContent.ToString() == "6" || val[i, j].oContent.ToString() == "106")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_face");
                            if (val[i, j].oContent.ToString() == "150")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_onedress");
                        }
                    }
                }
            }

            mGrid.DataSource = BuildRow(mEvent, val, mDataTable, out PageCount);

            /*
            DataRow mDataRow = null;
            DataTable mDataTable = new DataTable();

            //������ʽ
            mDataTable.Columns.Add("����", typeof(int));
            mDataTable.Columns.Add("����������", typeof(string));
            mDataTable.Columns.Add("��ɫ����", typeof(string));
            mDataTable.Columns.Add("����״̬", typeof(bool));
            mDataTable.Columns.Add("����״̬", typeof(bool));
            mDataTable.Columns.Add("��ͣ״̬", typeof(bool));
            mDataTable.Columns.Add("������", typeof(string));
            mDataTable.Columns.Add("��  ��", typeof(string));

            //������¼
            mDataRow = mDataTable.NewRow();
            mDataRow["����"] = 0;
            mDataRow["����������"] = "����";
            mDataRow["��ɫ����"] = "3G";
            mDataRow["����״̬"] = 0;
            mDataRow["����״̬"] = 0;
            mDataRow["��ͣ״̬"] = 0;
            mDataRow["������"] = 0;
            mDataRow["��  ��"] = 0;

            mDataTable.Rows.Add(mDataRow);

            mDataRow = mDataTable.NewRow();
            mDataRow["����"] = 0;
            mDataRow["����������"] = "����2";
            mDataRow["��ɫ����"] = "3G2";
            mDataRow["����״̬"] = 0;
            mDataRow["����״̬"] = 0;
            mDataRow["��ͣ״̬"] = 0;
            mDataRow["������"] = 0;
            mDataRow["��  ��"] = 0;

            mDataTable.Rows.Add(mDataRow);
            
            return mDataTable;
             * */
            return null;
        }

        public static object GetTimes(CEnum.Message_Body[,] val, string iItemID)
        {
            object oResult = null;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (iItemID.Equals(val[i, 0].oContent.ToString()))
                {
                    oResult = val[i, 2].oContent;
                    break;
                }
            }

            return oResult;
        }

        public static object GetLimit(CEnum.Message_Body[,] val, string iItemID)
        {
            object oResult = null;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (iItemID.Equals(val[i, 0].oContent.ToString()))
                {
                    oResult = val[i, 3].oContent;
                    break;
                }
            }

            return oResult;
        }

        #region ˽�к���
        /// <summary>
        /// ���� DataGridView ��
        /// </summary>
        /// <param name="val">����</param>
        /// <param name="mDataTable">DataTable</param>
        /// <returns>DataTable</returns>
        private static DataTable BuildColumn(CSocketEvent mEvent, CEnum.Message_Body[,] val)
        {
            DataTable mDataTable = new DataTable();

            for (int i = 0; i < val.GetLength(1); i++)
            {
                if (val[0, i].eName == CEnum.TagName.CARD_SumTotal)
                {
                    Operation_Card.Total = val[0, i].oContent.ToString();
                    continue;
                }
                if (val[0, i].eName != CEnum.TagName.PageCount)
                {
                    //mDataTable.Columns.Add((string)mEvent.DecodeFieldName(val[0, i].eName), typeof(string));
                    mDataTable.Columns.Add((string)config.ReadConfigValue("GLOBAL", val[0, i].eName.ToString()), typeof(string));
                }


            }
            //mDataTable.Columns.Add("��ֵ����", typeof(string));
            //mDataTable.Columns.Add("�㿨����", typeof(string));
            //mDataTable.Columns.Add("�㿨����", typeof(string));
            //mDataTable.Columns.Add("�㿨�۸�", typeof(string));
            //mDataTable.Columns.Add("��ֵ��", typeof(string));
            //mDataTable.Columns.Add("������", typeof(string));
            //mDataTable.Columns.Add("��ֵʱ��", typeof(string));
            //mDataTable.Columns.Add("��ֵ��IP", typeof(string));


            return mDataTable;
        }

        /// <summary>
        /// ���� DataGridView ��
        /// </summary>
        /// <param name="val">����</param>
        /// <param name="mDataRow">DataRow</param>
        /// <returns>DataRow</returns>
        private static DataTable BuildRow(CSocketEvent mEvent, CEnum.Message_Body[,] val, DataTable mTable, out int PageCount)
        {
            config = (ConfigValue)mEvent.GetInfo("INI"); 
            PageCount = 0;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                DataRow mRow = mTable.NewRow();

                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName != CEnum.TagName.PageCount)
                    {
                        if (val[i, j].eName == CEnum.TagName.SDO_MoneyType)
                        {
                            if (val[i, j].oContent.ToString() == "1")
                            {
                                val[i, j].oContent = "M";
                            }
                            else
                            {
                                val[i, j].oContent = "G";
                            }
                        }

                        if (val[i, j].eName == C_Global.CEnum.TagName.CARD_UDdirect)
                        {
                            if (val[i, j].oContent.ToString() == "n")
                            {
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_no");
                            }
                            else
                            {
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_yes");
                            }
                        }
                        if (val[i, j].eName == CEnum.TagName.CARD_SumTotal)
                        {
                            continue;
                        }
                        if (val[i, j].eName == CEnum.TagName.SDO_SEX)
                        {
                            if (val[i, j].oContent.ToString().Equals("0"))
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = config.ReadConfigValue("MAU", "OP_Code_Fsex");
                                 mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = config.ReadConfigValue("MSDO", "OP_Code_Fsex");
                            else
                                 mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = config.ReadConfigValue("MSDO", "OP_Code_Msex");
                        }

                        if (val[i, j].oContent == null)
                        {
                            //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = "N/A";
                            mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = "N/A";
                        }
                        else
                        {
                            //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = val[i, j].oContent;
                            mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString().Trim();
                        }
                    }
                    else
                    {
                        PageCount = int.Parse(val[i, j].oContent.ToString());
                    }
                }

                mTable.Rows.Add(mRow);
            }

            return mTable;
        }

        /// <summary>
        /// ��ȡ ComboBox ѡ��������
        /// </summary>
        /// <param name="val">��¼��</param>
        /// <param name="Condition">��������</param>
        /// <returns></returns>
        public static string GetItemAddr(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.ServerInfo_IP && val[i, j + 1].oContent.Equals(Condition))
                    {
                        strResult = val[i, j].oContent.ToString();
                    }
                }
            }

            return strResult;
        }

        public static int GetItemID(CEnum.Message_Body[,] val, string Condition)
        {
            int iResult = 0;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.SDO_ItemCode && val[i, j + 1].oContent.Equals(Condition))
                    {
                        iResult = int.Parse(val[i, j].oContent.ToString());
                    }
                }
            }

            return iResult;
        }

        public static string ReturnClientIp()
        {
            string ClientIp = "";
            System.Net.IPAddress[] addressList = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList; 
            ClientIp = addressList[0].ToString();
            return ClientIp;
        }

        public static void SaveTxt(ConfigValue config, CEnum.Message_Body[,] mResult, string name,string ini)
        {
            try
            {
                string result = "";
                for (int i = 0; i < mResult.GetLength(1); i++)
                {
                        result += config.ReadConfigValue(ini, mResult[0, i].eName.ToString()) + ":";
                        result += mResult[0, i].oContent.ToString();
                        result += "\r\n";
                }
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + name + ".txt", FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(result);
                sw.Close();
                fs.Close();
            }
            catch
            {

            }
        }
        #endregion


    }

    class Operation_Shop
    {
        private static ConfigValue config = null;
        public static int iPageSize = 50;
        public static string Total = "";
        /// <summary>
        /// ��ȡ��������ַ�б�
        /// </summary>
        /// <param name="mEvent">Socket�¼�</param>
        /// <param name="mContent">��Ϣ����</param>
        /// <returns>������</returns>
        public static CEnum.Message_Body[,] GetServerList(CSocketEvent mEvent, CEnum.Message_Body[] mContent)
        {
            CEnum.Message_Body[,] mReturn = null;

            mReturn =
                mEvent.RequestResult(CEnum.ServiceKey.SERVERINFO_IP_QUERY, CEnum.Msg_Category.COMMON, mContent);

            return mReturn;
        }

        public static object DecodeContent(CEnum.TagFormat mFormat, string mContent)
        {
            object mObject = null;

            switch (mFormat)
            {
                case CEnum.TagFormat.TLV_BOOLEAN:
                    mObject = Convert.ToBoolean(mContent);
                    break;
                case CEnum.TagFormat.TLV_INTEGER:
                    mObject = Convert.ToInt32(mContent);
                    break;
                case CEnum.TagFormat.TLV_DATE:
                    mObject = Convert.ToDateTime(mContent).Date;
                    break;
                case CEnum.TagFormat.TLV_TIME:
                    mObject = Convert.ToDateTime(mContent).TimeOfDay;
                    break;
                case CEnum.TagFormat.TLV_EXTEND:
                case CEnum.TagFormat.TLV_MONEY:
                    mObject = Convert.ToDouble(mContent);
                    break;
                case CEnum.TagFormat.TLV_NUMBER:
                    mObject = Convert.ToInt32(mContent);
                    break;
                case CEnum.TagFormat.TLV_STRING:
                    mObject = mContent;
                    break;
                case CEnum.TagFormat.TLV_TIMESTAMP:
                    mObject = Convert.ToDateTime(mContent);
                    break;
            }

            return mObject;
        }

        /// <summary>
        /// ��ȡ��Ϣ�б�
        /// </summary>
        /// <param name="mEvent">Socket�¼�</param>
        /// <param name="mKey">������</param>
        /// <param name="mContent">��Ϣ����</param>
        /// <returns>������</returns>
        public static CEnum.Message_Body[,] GetResult(CSocketEvent mEvent, CEnum.ServiceKey mKey, CEnum.Message_Body[] mContent)
        {
            CEnum.Message_Body[,] mReturn = null;

            mReturn =
                mEvent.RequestResult(mKey, CEnum.Msg_Category.AUSHOP_ADMIN, mContent);

            return mReturn;
        }

        /// <summary>
        /// ���� ComboBox ����
        /// </summary>
        /// <param name="val">ComboBox ����</param>
        /// <param name="mCmbBox">ComboBox �ؼ�</param>
        /// <returns>ComboBox �ؼ�</returns>
        public static System.Windows.Forms.ComboBox BuildCombox(CEnum.Message_Body[,] val, System.Windows.Forms.ComboBox mCmbBox)
        {
            try
            {
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    mCmbBox.Items.Add(val[i, 1].oContent);
                }

                mCmbBox.SelectedIndex = 0;
            }
            catch
            {

            }

            return mCmbBox;
        }

        public static DataTable BuildDataTable(CSocketEvent mEvent, CEnum.Message_Body[,] val, System.Windows.Forms.DataGridView mGrid, out int PageCount)
        {
            config = (ConfigValue)mEvent.GetInfo("INI");
            DataTable mDataTable = BuildColumn(mEvent, val);

            if (mGrid.Name == "GrdGift")
            {
                for (int i = 0; i < val.GetLength(0); i++)
                {
                    for (int j = 0; j < val.GetLength(1); j++)
                    {
                        if (val[i, j].eName == CEnum.TagName.SDO_BigType)
                        {
                            if (val[i, j].oContent.ToString() == "0")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_dress");
                            if (val[i, j].oContent.ToString() == "1")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_item");
                        }

                        if (val[i, j].eName == CEnum.TagName.SDO_SmallType)
                        {
                            if (val[i, j].oContent.ToString() == "0")
                            {
                                if (val[i, j - 1].eName == CEnum.TagName.SDO_BigType && val[i, j - 1].oContent.ToString() == "0")
                                    val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_head");
                                else
                                    val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_item");
                            }

                            if (val[i, j].oContent.ToString() == "100")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_head");

                            if (val[i, j].oContent.ToString() == "1" || val[i, j].oContent.ToString() == "101")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_hair");
                            if (val[i, j].oContent.ToString() == "2" || val[i, j].oContent.ToString() == "102")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_body");
                            if (val[i, j].oContent.ToString() == "3" || val[i, j].oContent.ToString() == "103")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_leg");
                            if (val[i, j].oContent.ToString() == "4" || val[i, j].oContent.ToString() == "104")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_hand");
                            if (val[i, j].oContent.ToString() == "5" || val[i, j].oContent.ToString() == "105")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_feet");
                            if (val[i, j].oContent.ToString() == "6" || val[i, j].oContent.ToString() == "106")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_face");
                            if (val[i, j].oContent.ToString() == "150")
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_onedress");
                        }
                    }
                }
            }

            mGrid.DataSource = BuildRow(mEvent, val, mDataTable, out PageCount);


            return null;
        }

        public static object GetTimes(CEnum.Message_Body[,] val, string iItemID)
        {
            object oResult = null;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (iItemID.Equals(val[i, 0].oContent.ToString()))
                {
                    oResult = val[i, 2].oContent;
                    break;
                }
            }

            return oResult;
        }

        public static object GetLimit(CEnum.Message_Body[,] val, string iItemID)
        {
            object oResult = null;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                if (iItemID.Equals(val[i, 0].oContent.ToString()))
                {
                    oResult = val[i, 3].oContent;
                    break;
                }
            }

            return oResult;
        }

        #region ˽�к���
        /// <summary>
        /// ���� DataGridView ��
        /// </summary>
        /// <param name="val">����</param>
        /// <param name="mDataTable">DataTable</param>
        /// <returns>DataTable</returns>
        private static DataTable BuildColumn(CSocketEvent mEvent, CEnum.Message_Body[,] val)
        {
            try
            {
                DataTable mDataTable = new DataTable();

                for (int i = 0; i < val.GetLength(1); i++)
                {
                    if (val[0, i].eName == CEnum.TagName.CARD_SumTotal)
                    {
                        Operation_Shop.Total = val[0, i].oContent.ToString();
                        continue;
                    }
                    if (val[0, i].eName != CEnum.TagName.PageCount)
                    {
                        //mDataTable.Columns.Add((string)mEvent.DecodeFieldName(val[0, i].eName), typeof(string));
                        mDataTable.Columns.Add((string)config.ReadConfigValue("GLOBAL", val[0, i].eName.ToString()), typeof(string));
                    }


                }

                return mDataTable;
            }
            catch
            {
                 DataTable mDataTable = new DataTable();
                 return mDataTable;
            }


            
        }

        /// <summary>
        /// ���� DataGridView ��
        /// </summary>
        /// <param name="val">����</param>
        /// <param name="mDataRow">DataRow</param>
        /// <returns>DataRow</returns>
        private static DataTable BuildRow(CSocketEvent mEvent, CEnum.Message_Body[,] val, DataTable mTable, out int PageCount)
        {
            config = (ConfigValue)mEvent.GetInfo("INI");
            PageCount = 0;
            for (int i = 0; i < val.GetLength(0); i++)
            {
                DataRow mRow = mTable.NewRow();

                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName != CEnum.TagName.PageCount)
                    {
                        if (val[i, j].eName == CEnum.TagName.SDO_MoneyType)
                        {
                            if (val[i, j].oContent.ToString() == "1")
                            {
                                val[i, j].oContent = "M";
                            }
                            else
                            {
                                val[i, j].oContent = "G";
                            }
                        }

                        if (val[i, j].eName == C_Global.CEnum.TagName.CARD_UDdirect)
                        {
                            if (val[i, j].oContent.ToString() == "n")
                            {
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_no");
                            }
                            else
                            {
                                val[i, j].oContent = config.ReadConfigValue("MAU", "OP_Code_yes");
                            }
                        }
                        if (val[i, j].eName == CEnum.TagName.CARD_SumTotal)
                        {
                            continue;
                        }
                        if (val[i, j].eName == CEnum.TagName.SDO_SEX)
                        {
                            if (val[i, j].oContent.ToString().Equals("0"))
                                //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = config.ReadConfigValue("MAU", "OP_Code_Fsex");
                                mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = config.ReadConfigValue("MSDO", "OP_Code_Fsex");
                            else
                                mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = config.ReadConfigValue("MSDO", "OP_Code_Msex");
                        }

                        if (val[i, j].oContent == null)
                        {
                            //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = "N/A";
                            mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = "N/A";
                        }
                        else
                        {
                            //mRow[(string)mEvent.DecodeFieldName(val[i, j].eName)] = val[i, j].oContent;
                            mRow[(string)config.ReadConfigValue("GLOBAL", val[i, j].eName.ToString())] = val[i, j].oContent.ToString().Trim();
                        }
                    }
                    else
                    {
                        PageCount = int.Parse(val[i, j].oContent.ToString());
                    }
                }

                mTable.Rows.Add(mRow);
            }

            return mTable;
        }

        /// <summary>
        /// ��ȡ ComboBox ѡ��������
        /// </summary>
        /// <param name="val">��¼��</param>
        /// <param name="Condition">��������</param>
        /// <returns></returns>
        public static string GetItemAddr(CEnum.Message_Body[,] val, string Condition)
        {
            string strResult = null;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.ServerInfo_IP && val[i, j + 1].oContent.Equals(Condition))
                    {
                        strResult = val[i, j].oContent.ToString();
                    }
                }
            }

            return strResult;
        }

        public static int GetItemID(CEnum.Message_Body[,] val, string Condition)
        {
            int iResult = 0;

            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    if (val[i, j].eName == CEnum.TagName.SDO_ItemCode && val[i, j + 1].oContent.Equals(Condition))
                    {
                        iResult = int.Parse(val[i, j].oContent.ToString());
                    }
                }
            }

            return iResult;
        }

        public static string ReturnClientIp()
        {
            string ClientIp = "";
            System.Net.IPAddress[] addressList = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList;
            ClientIp = addressList[0].ToString();
            return ClientIp;
        }

        public static void SaveTxt(ConfigValue config, CEnum.Message_Body[,] mResult, string name, string ini)
        {
            try
            {
                string result = "";
                for (int i = 0; i < mResult.GetLength(1); i++)
                {
                    result += config.ReadConfigValue(ini, mResult[0, i].eName.ToString()) + ":";
                    result += mResult[0, i].oContent.ToString();
                    result += "\r\n";
                }
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + name + ".txt", FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(result);
                sw.Close();
                fs.Close();
            }
            catch
            {

            }
        }
        #endregion

        //����tagName����ȡ��������ֵ
        public static int findIdx(CEnum.Message_Body[,] val,CEnum.TagName tagName)
        {
            int idx = 0;
            for (int i = 0; i < val.GetLength(1); i++)
            {
                if (val[0, i].eName == tagName)
                {
                    idx = i;
                    break;
                }
                idx = -1;//û�д�tagName
            }
            return idx;
        }

    }
}
