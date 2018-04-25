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
                 *获取需要隐藏的字段 
                 */
                string[] needHideField = GetNeedHideField(null);
                //FormatTagName format = new FormatTagName();

                for (int i = 0; i < dg.Columns.Count; i++)
                {
                    //设置所有列都为不可排序
                    dg.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;

                    //检索隐藏字段
                    if (needHideField != null)
                    {
                        for (int j = 0; j < needHideField.Length; j++)
                        {
                            if (dg.Columns[i].Name.Equals(needHideField[j]))
                            {
                                dg.Columns[i].Visible = false;
                            }
                            if (dg.Columns[i].Name.Equals("主题"))
                            {
                                dg.Columns[i].Width = 200;
                                //dg.Columns[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            if (dg.Columns[i].Name.Equals("时间"))
                            {
                                dg.Columns[i].Width = 150;
                            }
                            if (dg.Columns[i].Name.Equals("收件人"))
                            {
                                dg.Columns[i].Width = 200;
                            }
                        }
                    }

                }
            }
                //                dgTable.Columns.Add("NOTES_ID");
                //dgTable.Columns.Add("NOTES_UID");
                //dgTable.Columns.Add("主题");
                //dgTable.Columns.Add("收件人");
                //dgTable.Columns.Add("时间");
                //dgTable.Columns.Add("内容");
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
                    //设置所有列都为不可排序
                    dg.Columns[i].SortMode= DataGridViewColumnSortMode.Automatic;

                    //检索隐藏字段
                    if (needHideField != null)
                    {
                        for (int j = 0; j < needHideField.Length; j++)
                        {
                            if (dg.Columns[i].Name.Equals(needHideField[j]))
                            {
                                dg.Columns[i].Visible = false;
                            }
                            //if (dg.Columns[i].Name.Equals("警报信息描述"))
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
                 *获取需要隐藏的字段 
                 */
                string[] needHideField = GetNeedHideField(sTableName);


                for (int i = 0; i < dg.Columns.Count; i++)
                {
                    //设置所有列都为不可排序
                    dg.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;

                    //检索隐藏字段
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
        /// 不显示在datagrid中的字段
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
                    "抄送人",
                    "内容"                                 //                dgTable.Columns.Add("NOTES_ID");
                //dgTable.Columns.Add("NOTES_UID");
                //dgTable.Columns.Add("主题");
                //dgTable.Columns.Add("收件人");
                //dgTable.Columns.Add("时间");
                //dgTable.Columns.Add("内容");
                    

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
