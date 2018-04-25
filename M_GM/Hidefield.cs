using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

//using C_Global;


namespace Strategy
{
    public class HideField
    {

        public void HideSomeFiled(DataGridView dg)
        {
            try
            {
                /*
                 *��ȡ��Ҫ���ص��ֶ� 
                 */
                string[] needHideField = GetNeedHideField(null);
                //FormatTagName format = new FormatTagName();

                for (int i = 0; i < dg.Columns.Count; i++)
                {
                    //���������ж�Ϊ��������
                    dg.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;

                    //���������ֶ�
                    if (needHideField != null)
                    {
                        for (int j = 0; j < needHideField.Length; j++)
                        {
                            if (dg.Columns[i].Name.Equals(needHideField[j]))
                            {
                                dg.Columns[i].Visible = false;
                            }
                            if (dg.Columns[i].Name.Equals("����"))
                            {
                                dg.Columns[i].Width = 200;
                                //dg.Columns[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            if (dg.Columns[i].Name.Equals("ʱ��"))
                            {
                                dg.Columns[i].Width = 150;
                            }
                            if (dg.Columns[i].Name.Equals("�ռ���"))
                            {
                                dg.Columns[i].Width = 200;
                            }
                        }
                    }

                }
            }
                //                dgTable.Columns.Add("NOTES_ID");
                //dgTable.Columns.Add("NOTES_UID");
                //dgTable.Columns.Add("����");
                //dgTable.Columns.Add("�ռ���");
                //dgTable.Columns.Add("ʱ��");
                //dgTable.Columns.Add("����");
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void HideSomeFiled(DataGridView dg, string[] needHideField)
        {
            try
            {



                for (int i = 0; i < dg.Columns.Count; i++)
                {
                    //���������ж�Ϊ��������
                    dg.Columns[i].SortMode= DataGridViewColumnSortMode.Automatic;

                    //���������ֶ�
                    if (needHideField != null)
                    {
                        for (int j = 0; j < needHideField.Length; j++)
                        {
                            if (dg.Columns[i].Name.Equals(needHideField[j]))
                            {
                                dg.Columns[i].Visible = false;
                            }
                            //if (dg.Columns[i].Name.Equals("������Ϣ����"))
                            //{
                            //    dg.Columns[i].Width = 700;
                            //}
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void HideSomeFiled(DataGridView dg, string sTableName)
        {
            try
            {
                /*
                 *��ȡ��Ҫ���ص��ֶ� 
                 */
                string[] needHideField = GetNeedHideField(sTableName);


                for (int i = 0; i < dg.Columns.Count; i++)
                {
                    //���������ж�Ϊ��������
                    dg.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;

                    //���������ֶ�
                    if (needHideField != null)
                    {
                        for (int j = 0; j < needHideField.Length; j++)
                        {
                            if (dg.Columns[i].Name.Equals(needHideField[j]))
                            {
                                dg.Columns[i].Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// ����ʾ��datagrid�е��ֶ�
        /// </summary>
        /// <returns></returns>
        public string[] GetNeedHideField(string sTableName)
        {
            //FormatTagName format = new FormatTagName();
            String[] hideField = null;

            if (sTableName == null)
            {
                hideField = new string[]
                {
                    
                    "NOTES_ID",
                    "NOTES_UID",
                    "AttachmentCount",
                    "NOTES_Status",
                    "������",
                    "����"                                 //                dgTable.Columns.Add("NOTES_ID");
                //dgTable.Columns.Add("NOTES_UID");
                //dgTable.Columns.Add("����");
                //dgTable.Columns.Add("�ռ���");
                //dgTable.Columns.Add("ʱ��");
                //dgTable.Columns.Add("����");
                    

                };
            }
            //else if (sTableName == "FireWall")
            //{
            //    hideField = new string[]
            //    {

            //        format.DecodeFieldName(TagName.Record_ID),
            //        format.DecodeFieldName(TagName.Record_Parent),
            //        //format.DecodeFieldName(TagName.Record_Layer),
            //        format.DecodeFieldName(TagName.Page_Count),
            //        format.DecodeFieldName(TagName.Record_Sort),
            //        format.DecodeFieldName(TagName.Report_Write),
            //        format.DecodeFieldName(TagName.Verify_Pwd),
            //        format.DecodeFieldName(TagName.Report_Source)



            //    };
            //}
            //else
            //{
            //    hideField = new string[]
            //    {
                    
            //        format.DecodeFieldName(TagName.Page_Count, sTableName),
            //        format.DecodeFieldName(TagName.Log_Remark04,sTableName)
                    

            //    };

            //}

            return hideField;
        }
    }
}
