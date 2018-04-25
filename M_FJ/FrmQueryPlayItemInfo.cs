using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using C_Global;
using C_Event;
using Language;
using System.IO;
using System.Collections;
namespace M_FJ
{
    /// <summary>
    /// 
    /// </summary>
    [C_Global.CModuleAttribute("玩家道具信息", "Frm_FJ_Item", " 玩家道具信息", "FJ_Group")]
    public partial class Frm_FJ_Item : Form
    {
        private CEnum.Message_Body[,] mServerInfo = null;
        private CSocketEvent m_ClientEvent = null;
        private CSocketEvent tmp_ClientEvent = null;
        private int iPageCount = 0;
        private bool bFirst = false;
        private string _ServerIP;
        string userAccount = null; //玩家角色名称
        private CEnum.Message_Body[,] mItemSubClass = null;
        private CEnum.Message_Body[,] mApplyProperty = null;
        private CEnum.Message_Body[,] mPlayItem = null;
        private CEnum.Message_Body[,] mApplyPropertyName = null;
        private CEnum.Message_Body[,] mStonePlayItem = null;
        private CEnum.Message_Body[,] mApplyPropertyList = null;

        private CEnum.Message_Body[,] ItemBClass = null;
        private CEnum.Message_Body[,] ItemAClass = null;

        private ShortStringDictionary ssdPlayItem = new ShortStringDictionary();
        private ShortStringDictionary ssdApplyPropertyName = new ShortStringDictionary();
        private ShortStringDictionary ssdStonePlayItem = new ShortStringDictionary();
        private ShortStringDictionary ssbListbox = new ShortStringDictionary();
        private ShortStringDictionary ssbListbox2 = new ShortStringDictionary();
        private ShortStringDictionary ssbListbox3 = new ShortStringDictionary();
        private ShortStringDictionary ssbListbox4 = new ShortStringDictionary();
        
        private ShortStringDictionary ssdItemNum1 = new ShortStringDictionary();//道具数量shortstringDirectionary
        private ShortStringDictionary ssdItemNum2 = new ShortStringDictionary();
        //private ShortStringDictionary ssdNum3 = new ShortStringDictionary();

        //private ShortStringDictionary ssdStoneNum1 = new ShortStringDictionary();//石头数量shortstringDirectionary
        //private ShortStringDictionary ssdStoneNum2 = new ShortStringDictionary();
        //private ShortStringDictionary ssdNum6 = new ShortStringDictionary();

        private ShortStringDictionary ssdItemSlot1 = new ShortStringDictionary();//道具槽数shortstringDirectionary
        private ShortStringDictionary ssdItemSlot2 = new ShortStringDictionary();

        //private ShortStringDictionary ssdStoneSlot1 = new ShortStringDictionary();//石头槽数shortstringDirectionary
        //private ShortStringDictionary ssdStoneSlot2 = new ShortStringDictionary();

        private ShortStringDictionary ssdItemLevel1 = new ShortStringDictionary();//道具等级shortstringDirectionary
        private ShortStringDictionary ssdItemLevel2 = new ShortStringDictionary();

        //private ShortStringDictionary ssdStoneLevel1 = new ShortStringDictionary();//石头等级shortstringDirectionary
        //private ShortStringDictionary ssdStonelevel2 = new ShortStringDictionary();

        private ShortStringDictionary ssdTimeLevel1 = new ShortStringDictionary();
        private ShortStringDictionary ssdTimeLevel2 = new ShortStringDictionary();

        private ShortStringArrayDictionary ssadStone = new ShortStringArrayDictionary();
        public Frm_FJ_Item()
        {
            InitializeComponent();
            Frm_FJ_Item.CheckForIllegalCrossThreadCalls = false;
        }

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
            Frm_FJ_Item mModuleFrm = new Frm_FJ_Item();
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


        private void Frm_FJ_Item_Load(object sender, EventArgs e)
        {
            IntiFontLib();
            //button5.Enabled = false;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[2];
            mContent[0].eName = CEnum.TagName.ServerInfo_GameDBID;
            mContent[0].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[0].oContent = 1;

            mContent[1].eName = CEnum.TagName.ServerInfo_GameID;
            mContent[1].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[1].oContent = m_ClientEvent.GetInfo("GameID_FJ");

            this.backgroundWorkerServerLoad.RunWorkerAsync(mContent);
            //初始化折叠按钮
            this.BtnHideShow1.Enabled=true;
            this.BtnHideShow2.Enabled=false;
            this.BtnHideShow3.Enabled=true;
            this.BtnHideShow4.Enabled = false;
            this.ClbItemName.ColumnWidth = 1000;

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

            this.Text = config.ReadConfigValue("MFj", "FJ_UI_FjPlayerItemInfo");
            this.BtnInsert.Text = config.ReadConfigValue("MFj", "FJ_UI_FjInsert");
            this.BtnClose.Text = config.ReadConfigValue("MFj", "FJ_UI_FjClose");
            this.LblServer.Text = config.ReadConfigValue("MFj", "FJ_UI_LblServer");
            this.LblAccount.Text = config.ReadConfigValue("MFj", "FJ_UI_LblPlayAccount");
            this.LblItemSubClass.Text = config.ReadConfigValue("MFj", "FJ_UI_LblItemSubClass");
            this.LblItemNameList.Text = config.ReadConfigValue("MFj", "FJ_UI_LblItemNameList");
            this.LblItemAppendProperty.Text = config.ReadConfigValue("MFj", "FJ_UI_LblItemApplyProperty");
            this.LblApplyPropertyValue.Text = config.ReadConfigValue("MFj", "FJ_UI_LblItemApplyPropertyValue");
            this.LblEmbedItemNameList.Text = config.ReadConfigValue("MFj", "LblEmbedItemNameList");
            this.LblSelectedEmbedItemNameList.Text = config.ReadConfigValue("MFj", "FJ_UI_LblSelectedItemList");
            this.LblSelectedItemApplyPropetyList.Text = config.ReadConfigValue("MFj", "FJ_UI_LblSelectedItemApplyPropetyList");
            this.LblSelectedEmbedItemNameList.Text = config.ReadConfigValue("MFj", "FJ_UI_LblSelectedEmbedItemNameList");
            this.LblTitle.Text = config.ReadConfigValue("MFj", "FJ_UI_LblTitle");
            this.LblContent.Text = config.ReadConfigValue("MFj", "FJ_UI_LblContent");
            this.LblApplyItemPropertyCondition.Text = config.ReadConfigValue("MFj", "FJ_UI_LblApplyItemPropertyCondition");
            this.BtnSelectedItemList.Text = config.ReadConfigValue("MFj", "FJ_UI_BtnSelectedItemList");
            this.BtnSelectedStoneItemList.Text = config.ReadConfigValue("MFj", "FJ_UI_BtnSelectedStoneItemList");
        }


        #endregion

        private void BtnSearch_Click(object sender, EventArgs e)
        {

            if (this.TxtCharinfo.Text == "" || this.TxtCharinfo.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgInputCharin"));
                return;
            }

            if (this.ClbItemName.CheckedItems.Count <= 0)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FJ_UI_ListItemProperty"));
                return;
            }

            //if (this.ClbStoreItemName.CheckedItems.Count <= 0)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MFj", "FJ_UI_ListStoneProperty"));
            //    return;
            //}


            if (this.txtTitle.Text == "" || this.txtTitle.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgInputTitle"));
                return;
            }
            if (this.txtContent.Text == "" || this.txtContent.Text == null)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FB_Code_MsgInputConet"));
                return;
            }

            //if (this.checkedListBox1.CheckedItems.Count <= 0)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MFj", "FJ_UI_ListApplyProperty"));
            //    return;
            //}
            if (checkedListBox1.CheckedItems.Count >5)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FJ_UI_ApplyPropertyError"));
                return;
            
            
            
            }
            //StringBuilder sItem = new StringBuilder();
            //if (ClbItemName.CheckedItems.Count % this.numericUpDownItemSlot.Value != 0)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MFj", "FJ_UI_ItemSlot"));
            //    return;
            //}
         
            //else
            //{
                //for (int x = 0; x <= ClbItemName.CheckedItems.Count - 1; x++)

                //    sItem.Append(ClbItemName.CheckedItems[x].ToString().Substring(0,ClbItemName.CheckedItems[x].ToString().IndexOf("-")).ToString());

            //}


            //StringBuilder sStone = new StringBuilder();
            //if (ClbStoreItemName.CheckedItems.Count % this.numericUpDownStoneSlot.Value != 0)
            //{
            //    MessageBox.Show(config.ReadConfigValue("MFj", "FJ_UI_StoneSlot"));
            //    return;
            //}
            //else
            //{
                //for (int x = 0; x <= ClbStoreItemName.CheckedItems.Count - 1; x++)

                //    sStone.Append(ClbStoreItemName.CheckedItems[x].ToString().Substring(0,ClbStoreItemName.CheckedItems[x].ToString().IndexOf("-")).ToString());

            //}

            CEnum.Message_Body[,] mResult = null;

            CEnum.Message_Body[] mContent = new CEnum.Message_Body[8];

            mContent[0].eName = CEnum.TagName.FJ_UserNick;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtCharinfo.Text.Trim();

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.UserByID;
            mContent[2].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[2].oContent = int.Parse(m_ClientEvent.GetInfo("USERID").ToString());

            mContent[3].eName = CEnum.TagName.FJ_Item_GuID;
            mContent[3].eTag = CEnum.TagFormat.TLV_STRING;
            //mContent[3].oContent = ReturnmItemSubClassID2(ClbItemName, ssbListbox3,ssdItemNum2);
            mContent[3].oContent = ReturnmItemSubClassID2(ClbItemName, ssbListbox3, ssbListbox4,ssadStone);
            //mContent[4].eName = CEnum.TagName.FJ_Embed_GuID;//石头
            //mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
            //mContent[4].oContent = ReturnmItemSubClassID(ClbStoreItemName, ssbListbox4);

            mContent[4].eName = CEnum.TagName.FJ_AppendItem_GuID;//附加属性
            mContent[4].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[4].oContent = ReturnmID(checkedListBox1);

            mContent[5].eName = CEnum.TagName.FJ_Title;
            mContent[5].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[5].oContent = txtTitle.Text.Trim();

            mContent[6].eName = CEnum.TagName.FJ_Message;
            mContent[6].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[6].oContent = txtContent.Text.Trim();

            mContent[7].eName = CEnum.TagName.FJ_SlotItemNum;//附加属性
            mContent[7].eTag = CEnum.TagFormat.TLV_INTEGER;
            mContent[7].oContent = int.Parse(numericUpDownItemSlot.Value.ToString());

            //mContent[9].eName = CEnum.TagName.FJ_SlotStoneNum;
            //mContent[9].eTag = CEnum.TagFormat.TLV_INTEGER;
            //mContent[9].oContent = int.Parse(numericUpDownStoneSlot.Value.ToString());

            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_ItemShop_Insert, mContent);
            }
             if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                return;
            }
            if (mResult[0, 0].eName == CEnum.TagName.Status && mResult[0, 0].oContent.ToString() == "SUCESS")
            {
                MessageBox.Show("操作成功");

            }
            else
            {
                MessageBox.Show("操作失败");
            }

        }

        /// <summary>
        /// 返回用","分割GUID
        /// </summary>
        /// <returns>GUID</returns>
        private string ReturnmItemSubClassID(CheckedListBox Cl, ShortStringDictionary ssd)
        {
            ArrayList ServerNames = new ArrayList();
            ArrayList Serverips = new ArrayList();
            string Strseverip = null;

            for (int i = 0; i < Cl.CheckedItems.Count; i++)
            {

                ServerNames.Add(Cl.CheckedItems[i].ToString());
        
                
            }
            for (int i = 0; i < ServerNames.Count; i++)
            {
                Serverips.Add(ssd[ServerNames[i].ToString()]);
               
            }
           

            for (int i = 0; i < Serverips.Count; i++)
            {
                Strseverip += ","+Serverips[i].ToString() ;
                
            }
            string strid = Strseverip.Remove(0, 1);
            return strid;
        }


        /// <summary>
        /// 返回用","分割GUID
        /// </summary>
        /// <returns>GUID</returns>
        private string ReturnmItemSubClassID2(CheckedListBox Cl, ShortStringDictionary ssd, ShortStringDictionary ssd2,ShortStringArrayDictionary ssad)
        {
            ArrayList ServerNames = new ArrayList();
            ArrayList Serverips = new ArrayList();
            ArrayList Serverips2=new ArrayList();
            string Strseverip = null;
            string Strseverip2=null;

            ArrayList ssadtemp=new ArrayList();

            for (int i = 0; i < Cl.CheckedItems.Count; i++)
            {

                ServerNames.Add(Cl.CheckedItems[i].ToString().Substring(0,Cl.CheckedItems[i].ToString().IndexOf("-")).ToString());
                //ServerNames.Add(Cl.CheckedItems[i].ToString().Substring(Cl.CheckedItems[i].ToString().IndexOf("-"), Cl.CheckedItems[i].ToString().LastIndexOf("-")).ToString());


            }
            for (int i = 0; i < ServerNames.Count; i++)
            {
                Serverips.Clear();
                Strseverip = "";
                Serverips.Add(ssd[ServerNames[i].ToString()]);
                Serverips.Add(";");
                Serverips.Add(Cl.CheckedItems[i].ToString().Substring(Cl.CheckedItems[i].ToString().IndexOf("-")+1,1));
                Serverips.Add(";");
                if (int.Parse(Cl.CheckedItems[i].ToString().Substring(Cl.CheckedItems[i].ToString().IndexOf("-") + 1, 1)) > 0) //开过槽选择石头
                {
                    ssadtemp = (ArrayList)ssad[Cl.CheckedItems[i].ToString().Substring(0,Cl.CheckedItems[i].ToString().IndexOf("-"))];
                    if (ssadtemp != null)
                    {
                        for (int k = 0; k < ssadtemp.Count; k++)
                        {
                            Serverips.Add(ssd2[ssadtemp[k].ToString()]);
                            if (k != ssadtemp.Count - 1)
                                Serverips.Add(":");
                        }
                    }
                    else Serverips.Add("0");//有槽数 没有石头
                }
                  else Serverips.Add("0");
                
                Serverips.Add(";");
                Serverips.Add(Cl.CheckedItems[i].ToString().Substring(Cl.CheckedItems[i].ToString().LastIndexOf("-")+1,1));
                Serverips.Add(";");
                Serverips.Add(Cl.CheckedItems[i].ToString().Substring(Cl.CheckedItems[i].ToString().IndexOf("*")+1, 1));
                Serverips.Add(";");
                Serverips.Add(Cl.CheckedItems[i].ToString().Substring(Cl.CheckedItems[i].ToString().LastIndexOf("*")+1));
                for (int j = 0; j < Serverips.Count; j++)
                {
                Strseverip=Strseverip+Serverips[j];
                
                
                }
                Serverips2.Add(Strseverip);
            
            }


            for (int i = 0; i < Serverips2.Count; i++)
            {
                Strseverip2 += "," + Serverips2[i].ToString() ;

            }
            string strid = Strseverip2.Remove(0, 1);
            return strid;
        }

        private string ReturnmID(CheckedListBox Cl)
        {
            try
            {
                ArrayList ServerNames = new ArrayList();
                ArrayList Serverips = new ArrayList();
                string Strseverip = "";

                for (int i = 0; i < Cl.CheckedItems.Count; i++)
                {

                    ServerNames.Add(Cl.CheckedItems[i].ToString());


                }

                for (int i = 0; i < ServerNames.Count; i++)
                {
                    Strseverip += "," + ServerNames[i].ToString();
                }

                string strid = Strseverip.Remove(0, 1);

                return strid;
            }
            catch
            {
                string Strseverip = "0";
                return Strseverip;
            }
        }

        private void backgroundWorkerFormLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mServerInfo = Operation_FJ.GetServerList(this.m_ClientEvent, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerFormLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // CmbServer = Operation_FJ.BuildCombox(mServerInfo, CmbServer);
            CmbServer.Items.Clear();
            for (int i = 0; i < mServerInfo.GetLength(0); i++)
            {
                CmbServer.Items.Add(mServerInfo[i, 1].oContent);
            }

            CmbServer.SelectedIndex = 0;
            bFirst = true;


        }

    
        private void backgroundWorkerSubClassLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mItemSubClass = Operation_FJ.GetResult(this.m_ClientEvent, CEnum.ServiceKey.FJ_ItemShop_Style_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerSubClassLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.CmbItemSubClass = Operation_FJ.BuildCombox(mItemSubClass, CmbItemSubClass);


            CEnum.Message_Body[] mApplyProperty = new CEnum.Message_Body[1];
            mApplyProperty[0].eName = CEnum.TagName.FJ_ServerIP;
            mApplyProperty[0].eTag = CEnum.TagFormat.TLV_STRING;
            mApplyProperty[0].oContent = this.CmbServer.Text.ToString();

            this.backgroundWorkerApplyPropertyLoad.RunWorkerAsync(mApplyProperty);
        
        }

     


        private void backgroundWorkerApplyPropertyLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mApplyProperty = Operation_FJ.GetResult(this.m_ClientEvent, CEnum.ServiceKey.FJ_ItemAppend_Style_Query, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerApplyPropertyLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.CmbAppendProperty = Operation_FJ.BuildRevShortStringDictionary(mApplyProperty, CmbAppendProperty, ssbListbox);

            button5.Enabled = true;
        
        }
    

    
      
        //private void backgroundWorkerPlayItem_DoWork_1(object sender, DoWorkEventArgs e)
        //{
        //    lock (typeof(C_Event.CSocketEvent))
        //    {
        //        mPlayItem = Operation_FJ.GetResult(this.m_ClientEvent, CEnum.ServiceKey.FJ_ItemShop_QueryAll, (CEnum.Message_Body[])e.Argument);
        //    }
        //}

        //private void backgroundWorkerPlayItem_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    this.CmbItemName = Operation_FJ.BuildCombox(mPlayItem, CmbItemName);
        //}

        
        //private void backgroundWorkerApplyProperty_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    lock (typeof(C_Event.CSocketEvent))
        //    {
        //        mApplyPropertyName = Operation_FJ.GetResult(this.m_ClientEvent, CEnum.ServiceKey.FJ_ItemAppend_Query, (CEnum.Message_Body[])e.Argument);
        //    }
        //}

        //private void backgroundWorkerApplyProperty_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
            
        //    this.CmbApplyProperty = Operation_FJ.BuildCombox(mApplyPropertyName, CmbApplyProperty);
        //}

      

        private void backgroundWorkerStonePlayItem_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (typeof(C_Event.CSocketEvent))
            {
                mStonePlayItem = Operation_FJ.GetResult(this.m_ClientEvent, CEnum.ServiceKey.FJ_ItemShop_QueryAll, (CEnum.Message_Body[])e.Argument);
            }
        }

        private void backgroundWorkerStonePlayItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.CmbStoreItemName = Operation_FJ.BuildCombox(mStonePlayItem, CmbStoreItemName);
        }

       

      
        private void CmbItemSubClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ssdApplyPropertyName.Clear();
            ssdStonePlayItem.Clear();
            if (bFirst)
            {
                CEnum.Message_Body[] mPlayItem = new CEnum.Message_Body[2];

                mPlayItem[0].eName = CEnum.TagName.FJ_ItemName;
                mPlayItem[0].eTag = CEnum.TagFormat.TLV_STRING;
                mPlayItem[0].oContent = "";

                mPlayItem[1].eName = CEnum.TagName.FJ_Style;
                mPlayItem[1].eTag = CEnum.TagFormat.TLV_STRING;
                mPlayItem[1].oContent = Operation_FJ.GetItemStyleName(mItemSubClass, this.CmbItemSubClass.Text.Trim());
                ItemAClass = m_ClientEvent.RequestResult(CEnum.ServiceKey.FJ_ItemShop_QueryAll, C_Global.CEnum.Msg_Category.FJ_ADMIN, mPlayItem);

                //this.CmbItemName = Operation_FJ.BuildComboxShortStringDictionary(itemResult, CmbItemName, ssdPlayItem);
                this.CmbItemName = Operation_FJ.BuildComboxShortStringDictionaryNum(ItemAClass, CmbItemName, ssdPlayItem,ssdItemNum1,ssdItemSlot1,ssdItemLevel1,ssdTimeLevel1);
                //this.backgroundWorkerPlayItem.RunWorkerAsync(mPlayItem);

             
            }   
        }

               private void CmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BtnModify.Enabled = false;
                  //槽初始化
            if (ssdItemSlot1[this.CmbItemName.Text.ToString()] != "")
            {
                
                CmbStoreItemName.Enabled = true;
                this.numericUpDownItemSlot.Enabled = true;
                this.BtnSelectedStoneItemList.Enabled = true;
                this.numericUpDownItemLevel.Enabled = true;
                this.numericUpDownItemSlot.Maximum = int.Parse(ssdItemSlot1[this.CmbItemName.Text.ToString()].ToString());
                this.numericUpDownItemSlot.Value = 1;
                this.numericUpDownItemSlot.Minimum = 1;

                //刷新石头列表
                CEnum.Message_Body[] mStonePlayItem = new CEnum.Message_Body[2];

                mStonePlayItem[0].eName = CEnum.TagName.FJ_ItemName;
                mStonePlayItem[0].eTag = CEnum.TagFormat.TLV_STRING;
                mStonePlayItem[0].oContent = "";

                mStonePlayItem[1].eName = CEnum.TagName.FJ_Style;
                mStonePlayItem[1].eTag = CEnum.TagFormat.TLV_STRING;
                mStonePlayItem[1].oContent = "ISC_Embed";

                ItemBClass = m_ClientEvent.RequestResult(CEnum.ServiceKey.FJ_ItemShop_QueryAll, C_Global.CEnum.Msg_Category.FJ_ADMIN, mStonePlayItem);

                //this.CmbStoreItemName = Operation_FJ.BuildComboxShortStringDictionary(itemResult, CmbStoreItemName, ssdStonePlayItem);

                this.CmbStoreItemName = Operation_FJ.BuildComboxShortStringDictionaryChecked(ItemBClass, CmbStoreItemName, ssdStonePlayItem);
            

            }
            else
            {
                this.numericUpDownItemSlot.Enabled = false;
                this.BtnSelectedStoneItemList.Enabled = false;
                CmbStoreItemName.Enabled = false;
            }

            this.numericUpDownItemLevel.Maximum = int.Parse(ssdItemLevel1[this.CmbItemName.Text.ToString()].ToString());
            this.numericUpDownItemLevel.Value = 0;
            this.numericUpDownItemLevel.Minimum = 0;

            if (int.Parse(ssdTimeLevel1[this.CmbItemName.Text.ToString()]) > 1)
            {
                this.dateTimePickerTimeLevel.Enabled = false;
              
            }
            else
            {
               

                this.dateTimePickerTimeLevel.Enabled = true;
            }
            if (int.Parse(ssdItemNum1[this.CmbItemName.Text.ToString()]) < 1)
                this.numericUpDownItemNum.Enabled = false;
            else
            {
                //数量初始化
                this.numericUpDownItemNum.Enabled = true;
                this.numericUpDownItemNum.Maximum = int.Parse(ssdItemNum1[this.CmbItemName.Text.ToString()].ToString());
                this.numericUpDownItemNum.Value = 0;
                this.numericUpDownItemNum.Minimum = 0;
            }
        }

       
        private void CmbStoreItemName_SelectedIndexChanged(object sender, EventArgs e)
        {//道具数量
            //this.numericUpDownItemNum2.Maximum = int.Parse(ssdStoneNum1[this.CmbStoreItemName.Text.ToString()].ToString());
            //this.numericUpDownItemNum2.Value = 1;
            //this.numericUpDownItemNum2.Minimum = 1;
         //槽数
            //this.numericUpDownStoneSlot.Maximum = int.Parse(ssdStoneSlot1[this.CmbStoreItemName.Text.ToString()].ToString());
            //this.numericUpDownStoneSlot.Value = 0;
            //this.numericUpDownStoneSlot.Minimum = 0;

            //int i = 0;
           // this.ClbStoreItemName.MultiColumn = true;
           // this.ClbStoreItemName.SelectionMode = SelectionMode.MultiExtended;
            //this.ClbStoreItemName.BeginUpdate();
           // for (int x = 0; x < this.CmbStoreItemName.Items.Count; x++)
                     
            //this.ClbStoreItemName.SetSelected(x, true);


            //for (int x = 0; x < ClbItemName.Items.Count; x++)
            //{
            //    if (ClbItemName.SelectedItems[x].ToString() == this.CmbAppendProperty.Text.ToString() + "=" + this.numericUpDownValue.Value)
            //    {

            //        i = 1;
            //        break;
            //    }


            //}
            //if (i == 0)
            //{

            //this.ClbStoreItemName.Items.Add(this.CmbStoreItemName.Text.ToString());

            //for (int j = 0; j < ssdStonePlayItem.Count; j++)
            //{
            //    if (ssdStonePlayItem.contains(this.CmbStoreItemName.Text.ToString()))
            //    {
            //        ssbListbox4.Add(this.CmbStoreItemName.Text.ToString(), ssdStonePlayItem[this.CmbStoreItemName.Text.ToString()].ToString());
            //        break;
            //    }

            //}
            //}

            //this.ClbStoreItemName.EndUpdate(); 
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ClbItemName.Items.Clear();
            ClbStoreItemName.Items.Clear();
            checkedListBox1.Items.Clear();
            
        }

        private void LblItemAppendProperty_Click(object sender, EventArgs e)
        {

        }

        private void CmbAppendProperty_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            decimal mMax=0;
            decimal mMin=0;
            ComboBox senderComboBox = (ComboBox)sender;
            if (bFirst)
            {
                CEnum.Message_Body[] mApplyPropertyName = new CEnum.Message_Body[1];

                mApplyPropertyName[0].eName = CEnum.TagName.FJ_Style;
                mApplyPropertyName[0].eTag = CEnum.TagFormat.TLV_STRING;
                mApplyPropertyName[0].oContent = Operation_FJ.GetItemStyleName(mApplyProperty, this.CmbAppendProperty.Text.Trim());


                CEnum.Message_Body[,] itemResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.FJ_ItemAppend_Query, C_Global.CEnum.Msg_Category.FJ_ADMIN, mApplyPropertyName);

              
                mMax =Convert.ToDecimal(itemResult[0,0].oContent.ToString());
                mMin = Convert.ToDecimal(itemResult[0, 1].oContent.ToString());
                
                this.numericUpDownValue.Maximum=mMax;
                this.numericUpDownValue.Minimum=mMin;

            }
        }

        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.dataGridViewInsert.DataSource = null;
                string mMapString = "";
                Regex r = new Regex("(=)"); // Split on hyphens.

                CEnum.Message_Body[] mApplyPropertyList = new CEnum.Message_Body[2];

                mApplyPropertyList[0].eName = CEnum.TagName.FJ_Style;
                mApplyPropertyList[0].eTag = CEnum.TagFormat.TLV_STRING;
                mApplyPropertyList[0].oContent = Operation_FJ.GetItemStyleName(mApplyProperty, this.CmbAppendProperty.Text.Trim());

                for (int x = 0; x < listBox1.Items.Count; x++)

                    listBox1.SetSelected(x, true);

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string[] s = r.Split(listBox1.Items[i].ToString());
                    if (s[2].Length == 1)
                        s[2] = s[2].ToString() + ".00";
                    else if (s[2].Length == 3)
                        s[2] = s[2].ToString() + "0";
                    mMapString = mMapString + ssbListbox2[listBox1.Items[i].ToString()].ToString() + s[1].ToString() + "'" + s[2].ToString() + "'";

                    if (listBox1.Items.Count - 1 != i)
                    {
                        mMapString += " and ";
                    }
                }
                mApplyPropertyList[1].eName = CEnum.TagName.FJ_Map;
                mApplyPropertyList[1].eTag = CEnum.TagFormat.TLV_STRING;
                mApplyPropertyList[1].oContent = mMapString;
                CEnum.Message_Body[,] itemResult = m_ClientEvent.RequestResult(CEnum.ServiceKey.FJ_ItemAppendList_Query, C_Global.CEnum.Msg_Category.FJ_ADMIN, mApplyPropertyList);
                dataGridViewInsert.DataSource = null;
                Operation_FJ.BuildDataTableItemAdd(this.m_ClientEvent, itemResult, dataGridViewInsert, out iPageCount);

            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int i = 0;
            listBox1.MultiColumn = true;
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox1.BeginUpdate();
            for(int x=0;x<listBox1.Items.Count;x++)
                listBox1.SetSelected(x, true);
            for (int x = 0; x<listBox1.Items.Count; x++)
            {
                if (listBox1.SelectedItems[x].ToString()== this.CmbAppendProperty.Text.ToString() + "=" + this.numericUpDownValue.Value)
                {
                    i = 1;
                    break;
                }
                    
            }
            if (i == 0)
            {
                listBox1.Items.Add(this.CmbAppendProperty.Text.ToString() + "=" + this.numericUpDownValue.Value);
                for (int j = 0; j < ssbListbox.Count; j++)
                {
                    if (ssbListbox.contains(this.CmbAppendProperty.Text.ToString()))
                    {
                        ssbListbox2.Add(this.CmbAppendProperty.Text.ToString() + "=" + this.numericUpDownValue.Value,ssbListbox[this.CmbAppendProperty.Text.ToString()].ToString());
                        break;
                    }
                }
            }

            listBox1.EndUpdate(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.ClearSelected();
            }
            for (int j = 0; j < ssbListbox.Count; j++)
            {
                if (ssbListbox2.contains(this.listBox1.Text.ToString()))
                {
                    ssbListbox2.Remove(this.listBox1.Text.ToString());
                   
                }
                if(ssbListbox.contains(this.listBox1.Text.ToString()))
                {
                   ssbListbox.Remove(this.listBox1.Text.ToString());
                
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (CmbServer.Text == "")
            {
                return;
            }
            //清除控件

            TbcResult.SelectedTab = TabCharinfo;

            this.RoleInfoView.DataSource = null;

            if (TxtAncont.Text.Trim().Length > 0 || TxtNick.Text.Trim().Length > 0)
            {
                this.button5.Enabled = false;
                PartInfo();
            }
            else
            {
                MessageBox.Show(config.ReadConfigValue("MSDO", "CI_Code_inPutAccont"));
                return;
            }
        }

        private void PartInfo()
        {
            this.RoleInfoView.DataSource = null;
            CEnum.Message_Body[,] mResult = null;
            CEnum.Message_Body[] mContent = new CEnum.Message_Body[3];

            mContent[0].eName = CEnum.TagName.FJ_UserID;
            mContent[0].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[0].oContent = TxtAncont.Text;

            mContent[1].eName = CEnum.TagName.FJ_ServerIP;
            mContent[1].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[1].oContent = Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text);

            mContent[2].eName = CEnum.TagName.FJ_UserNick;
            mContent[2].eTag = CEnum.TagFormat.TLV_STRING;
            mContent[2].oContent = TxtNick.Text;

            lock (typeof(C_Event.CSocketEvent))
            {
                mResult = Operation_FJ.GetResult(tmp_ClientEvent, CEnum.ServiceKey.FJ_CharacterInfo_Query, mContent);
            }

            
            if (mResult[0, 0].eName == CEnum.TagName.ERROR_Msg)
            {
                MessageBox.Show(mResult[0, 0].oContent.ToString());
                button5.Enabled = true;
                return;
            }

            Operation_FJ.BuildDataTable(this.m_ClientEvent, mResult, RoleInfoView, out iPageCount);
            this.button5.Enabled = true;
        }

       private void RoleInfoView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && RoleInfoView.DataSource != null)
            {
                DataTable dt = ((DataTable)RoleInfoView.DataSource);
                userAccount = dt.Rows[e.RowIndex][1].ToString();
                TbcResult.SelectedIndex = 1;
                TxtCharinfo.Text = userAccount;
            }
            else
            {
                return;
            }
        }

        private void CmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
        }

        private void dataGridViewInsert_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewInsert.DataSource != null)
            {


                DataTable dt = ((DataTable)dataGridViewInsert.DataSource);
                string GUID = dt.Rows[e.RowIndex][0].ToString();

                for (int x = 0; x < this.checkedListBox1.Items.Count; x++)
                    if (GUID == this.checkedListBox1.Items[x].ToString())
                        return;
                this.checkedListBox1.Items.Add(GUID);
            }
            else
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.ClbItemName.SelectedIndex != -1)
            {
                ClbItemName.Items.RemoveAt(this.ClbItemName.SelectedIndex);
                ClbItemName.ClearSelected();
                //ssbListbox3.Remove(this.ClbItemName.Text.Substring(0,this.ClbItemName.Text.IndexOf("-")).ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.ClbStoreItemName.SelectedIndex != -1)
            {
                if (this.ClbItemName.SelectedIndex != -1)
                {
                    ArrayList Al = new ArrayList();

                    Al = (ArrayList)ssadStone[ClbItemName.Items[ClbItemName.SelectedIndex].ToString().Substring(0,ClbItemName.Items[ClbItemName.SelectedIndex].ToString().IndexOf("-")).ToString()];
                    Al.Remove(this.ClbStoreItemName.Items[this.ClbStoreItemName.SelectedIndex].ToString());
                }
                else
                {
                    MessageBox.Show(config.ReadConfigValue("MFj", "FJ_UI_NoSelectItem"));
                }
                ClbStoreItemName.Items.RemoveAt(this.ClbStoreItemName.SelectedIndex);
                ClbStoreItemName.ClearSelected();
                //ssbListbox4.Remove(this.ClbStoreItemName.Text.Substring(0,this.ClbStoreItemName.Text.IndexOf("-")).ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            for (int x = 0; x < this.ClbItemName.Items.Count; x++)
                if (this.CmbItemName.Text.ToString() == this.ClbItemName.Items[x].ToString().Substring(0, this.ClbItemName.Items[x].ToString().IndexOf("-")).ToString())
                    return;
            this.ClbItemName.MultiColumn = true;
            // this.ClbItemName.SelectionMode = SelectionMode.MultiExtended;
            this.ClbItemName.BeginUpdate();
            //for (int x = 0; x < this.ClbItemName.Items.Count; x++)
            //    this.ClbItemName.SetSelected(x, true);


            //for (int x = 0; x < ClbItemName.Items.Count; x++)
            //{
            //    if (ClbItemName.SelectedItems[x].ToString() == this.CmbAppendProperty.Text.ToString() + "=" + this.numericUpDownValue.Value)
            //    {

            //        i = 1;
            //        break;
            //    }
            string clbstring=this.CmbItemName.Text.ToString();
           

            if (ssdItemSlot1[this.CmbItemName.Text.ToString()] != "")
            {
                this.ssdItemSlot2.Add(this.CmbItemName.Text.ToString(), numericUpDownItemSlot.Value.ToString());
                clbstring = clbstring + "-" + numericUpDownItemSlot.Value.ToString();
            }
            else
            {
                this.ssdItemSlot2.Add(this.CmbItemName.Text.ToString(), "");
                clbstring = clbstring + "-" + "0";
            }
           
            //增加道具数量

            if (int.Parse(ssdTimeLevel1[this.CmbItemName.Text.ToString()]) < 1)
            {
                this.ssdItemNum2.Add(this.CmbItemName.Text.ToString(), "0");
                clbstring = clbstring + "[数量]" + "-" + "0";
            }
            else
            {
                this.ssdItemNum2.Add(this.CmbItemName.Text.ToString(), this.numericUpDownItemNum.Value.ToString());
                clbstring = clbstring + "[数量]" + "-" + this.numericUpDownItemNum.Value.ToString();
            }

            clbstring = clbstring + "[等级]" + "*" + this.numericUpDownItemLevel.Value.ToString();

            if (int.Parse(ssdTimeLevel1[this.CmbItemName.Text.ToString()]) < 1)
            {
                this.ssdTimeLevel2.Add(this.CmbItemName.Text.ToString(), "0");
                clbstring = clbstring + "[期限]" + "*" + "0";
            }
            else
            {
               this.ssdTimeLevel2.Add(this.CmbItemName.Text.ToString(), this.dateTimePickerTimeLevel.Value.ToString());
               TimeSpan ts = new TimeSpan();
                ts=this.dateTimePickerTimeLevel.Value.Date - System.DateTime.Now.Date;
               clbstring = clbstring + "[期限]" + "*" +ts.Days;
            }
            this.ClbItemName.Items.Add(clbstring);
            
            //this.numericUpDownItemSlot.Enabled = false;
            //this.numericUpDownItemNum.Enabled = false;
            //this.numericUpDownItemLevel.Enabled = false;
            //this.dateTimePickerTimeLevel.Enabled = false;
            //增加道具槽数
            
        
            //MessageBox("添加了" + this.numericUpDownItemNum.Value.ToString() + "件" + this.CmbItemName.Text.ToString() + "的道具");



            //}
            //if (i == 0)
            //{
            //获得数量最大值
            //int indexnum=this.CmbItemName.Text.ToString().IndexOf("-", 1);
            //int MaxNum = int.Parse(this.CmbItemName.Text.ToString().Substring(indexnum+1));
            //this.numericUpDownItemNum.Maximum = MaxNum;

            for (int j = 0; j < ssdPlayItem.Count; j++)
            {
                if (ssdPlayItem.contains(this.CmbItemName.Text.ToString()))
                {
                    ssbListbox3.Add(this.CmbItemName.Text.ToString(), ssdPlayItem[this.CmbItemName.Text.ToString()].ToString());
                    break;
                }

            }
            //}

            this.ClbItemName.EndUpdate(); 
        }

        private void button8_Click(object sender, EventArgs e)
        {
             ArrayList AlStone=new ArrayList();
            //效验是否重复添加以及和对应道具的槽数相同
            if (this.ClbItemName.SelectedIndex == -1)
            {

                //没有选择道具
                MessageBox.Show(config.ReadConfigValue("MFj", "FJ_UI_NoSelectItem"));
                return;
            
            }
            else if (this.ClbStoreItemName.Items.Count < int.Parse(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-")+1, 1)))
            {
                 for (int x = 0; x < this.ClbStoreItemName.Items.Count; x++)
                //if (this.CmbStoreItemName.Text == this.ClbStoreItemName.Items[x].ToString().Substring(0, this.ClbStoreItemName.Items[x].ToString().IndexOf("-")).ToString())
                if (this.CmbStoreItemName.Text == this.ClbStoreItemName.Items[x].ToString())
                    //不能添加重复石头

                    return;
                       
            }
            else
                //石头镶嵌个数已经达到道具槽数
                return;
            if (ssadStone.contains(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(0, this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-"))))
            {
                AlStone = (ArrayList)ssadStone[this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(0, this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-"))];
            
            }
            
            AlStone.Add(this.CmbStoreItemName.Text.ToString());
            ssadStone.Add(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(0, this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-")), AlStone);

            //this.ClbStoreItemName.Items.Add(this.CmbStoreItemName.Text.ToString());
            //增加石头数量
            //this.ssdStoneNum2.Add(this.CmbStoreItemName.Text.ToString(), this.numericUpDownItemNum2.Value.ToString());

            //增加石头槽数
            //this.ssdStoneSlot2.Add(this.CmbStoreItemName.Text.ToString(), this.numericUpDownStoneSlot.Value.ToString());

            //this.ssdStonelevel2.Add(this.CmbStoreItemName.Text.ToString(), this.numericUpDownStoneLevel.Value.ToString());

            //this.ClbStoreItemName.Items.Add(this.CmbStoreItemName.Text.ToString() + "-" + this.numericUpDownItemNum2.Value.ToString()+"-"+this.numericUpDownStoneSlot.Value.ToString()+"*"+this.numericUpDownStoneLevel.ToString());
            this.ClbStoreItemName.Items.Add(this.CmbStoreItemName.Text.ToString());
            for (int j = 0; j < ssdStonePlayItem.Count; j++)
            {
                if (ssdStonePlayItem.contains(this.CmbStoreItemName.Text.ToString()))
                {
                    ssbListbox4.Add(this.CmbStoreItemName.Text.ToString(), ssdStonePlayItem[this.CmbStoreItemName.Text.ToString()].ToString());
                    break;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (GrpSearch.Visible== true)
            {
                this.GrpSearch.Visible = false;
           
                this.BtnHideShow3.Enabled = false;
                this.BtnHideShow4.Enabled = true;
            }
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
                this.dataGridViewInsert.Visible = true;
            }
          
        }

        private void BtnHideShow2_Click(object sender, EventArgs e)
        {
            if (this.panel2.Visible == false)
            {
                this.panel2.Visible = true;
                this.dataGridViewInsert.Visible = true;
                this.BtnHideShow1.Enabled = true;
                this.BtnHideShow2.Enabled = false;
                this.BtnHideShow3.Enabled = true;
                this.BtnHideShow4.Enabled = false;
            }
          
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
                this.dataGridViewInsert.Visible = false;
                this.BtnHideShow2.Enabled = true;
                this.BtnHideShow1.Enabled = false;
                this.GrpSearch.Height = 450;
            }
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.GrpSearch.Visible == false)
            {
                this.GrpSearch.Visible = true;
                this.BtnHideShow1.Enabled = true;
                this.BtnHideShow2.Enabled = false;
                this.BtnHideShow3.Enabled = true;
                this.BtnHideShow4.Enabled = false;
            }
         
           
        }

        private void ClbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ClbItemName.SelectedIndex == -1)
            {
                //没有选择道具
                return;

            }
            else if (int.Parse(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-") + 1, 1)) > 0)
            {
                ArrayList AlStone = new ArrayList();
                this.ClbStoreItemName.Items.Clear();


                if ((ArrayList)ssadStone[this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(0, this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-"))] != null)
                {
                    AlStone = (ArrayList)ssadStone[this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(0, this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-"))];
                    for (int i = 0; i < AlStone.Count; i++)
                        this.ClbStoreItemName.Items.Add(AlStone[i]);
                }
                this.CmbStoreItemName.Enabled = true;
                this.BtnSelectedStoneItemList.Enabled = true;
                

                //刷新石头列表
                //CEnum.Message_Body[] mStonePlayItem = new CEnum.Message_Body[2];

                //mStonePlayItem[0].eName = CEnum.TagName.FJ_ItemName;
                //mStonePlayItem[0].eTag = CEnum.TagFormat.TLV_STRING;
                //mStonePlayItem[0].oContent = "";

                //mStonePlayItem[1].eName = CEnum.TagName.FJ_Style;
                //mStonePlayItem[1].eTag = CEnum.TagFormat.TLV_STRING;
                //mStonePlayItem[1].oContent = "ISC_Embed";

                //ItemBClass = m_ClientEvent.RequestResult(CEnum.ServiceKey.FJ_ItemShop_QueryAll, C_Global.CEnum.Msg_Category.FJ_ADMIN, mStonePlayItem);

                //this.CmbStoreItemName = Operation_FJ.BuildComboxShortStringDictionary(itemResult, CmbStoreItemName, ssdStonePlayItem);

                //this.CmbStoreItemName = Operation_FJ.BuildComboxShortStringDictionaryChecked(ItemBClass, CmbStoreItemName, ssdStonePlayItem);

            }
            else
                ClbStoreItemName.Items.Clear();
            //回显在控件上
            if (int.Parse(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-") + 1, 1)) != 0)
            {
                this.numericUpDownItemSlot.Enabled = true;
                this.numericUpDownItemSlot.Maximum = 6;
                this.numericUpDownItemSlot.Minimum = 1;
                this.numericUpDownItemSlot.Value = int.Parse(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-") + 1, 1));


            }
            else
                this.numericUpDownItemSlot.Enabled = false;

            this.numericUpDownItemNum.Maximum = int.Parse(ssdItemNum1[this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(0, this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-"))].ToString());
            this.numericUpDownItemNum.Minimum = 0;
            this.numericUpDownItemNum.Value = int.Parse(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().LastIndexOf("-") + 1, 1));
           

            this.numericUpDownItemLevel.Maximum = int.Parse(ssdItemLevel1[this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(0, this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-"))].ToString());
            this.numericUpDownItemLevel.Minimum = 0;
            this.numericUpDownItemLevel.Value = int.Parse(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("*") + 1, 1));
           

            DateTime Dt = DateTime.Now;
            TimeSpan Ts = new TimeSpan();
            Ts = TimeSpan.Parse(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().LastIndexOf("*") + 1, 1));
            Dt=Dt.Add(Ts);
            this.dateTimePickerTimeLevel.Value = Dt;
            this.BtnModify.Enabled = true;
            //if (this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-"), this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().LastIndexOf("-"))>0)
            //{
           

            //}
        //    if(this.numericUpDownItemNum.Value > int.Parse(ssdNum2[this.ClbItemName.Text.ToString()].ToString()))
        //    {
        //        MessageBox.Show("数值发生错误");
        //        this.numericUpDownItemNum.Value = 0;
        //        return;
        //    }
        //    if(ssdNum3.contains(this.ClbItemName..Text.ToString()))
        //        ssdNum3[this.ClbItemName.Text.ToString()]=this.numericUpDownItemNum.Value.ToString();
        //    else
        //    ssdNum3.Add(this.ClbItemName.Text.ToString(),this.numericUpDownItemNum.Value.ToString());

        //this.numericUpDownItemNum.Value = int.Parse(ssdNum3[this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString()].ToString());

                         
        }

        private void TbcResult_SelectedIndexChanged(object sender, EventArgs e)
        {
         if(TbcResult.SelectedIndex==1)
            {
                this.TxtCharinfo.Text = userAccount;
                tmp_ClientEvent = m_ClientEvent.GetSocket(m_ClientEvent, Operation_FJ.GetItemAddr(mServerInfo, CmbServer.Text));
                //PnlPage.Visible = false;

                CEnum.Message_Body[] mItemSubClass = new CEnum.Message_Body[1];
                mItemSubClass[0].eName = CEnum.TagName.FJ_ServerIP;
                mItemSubClass[0].eTag = CEnum.TagFormat.TLV_STRING;
                mItemSubClass[0].oContent = this.CmbServer.Text.ToString();

                this.backgroundWorkerSubClassLoad.RunWorkerAsync(mItemSubClass);
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
             string clbstring=this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().Substring(0, this.ClbItemName.Items[this.ClbItemName.SelectedIndex].ToString().IndexOf("-"));
           

            if (ssdItemSlot1[this.CmbItemName.Text.ToString()] != "")
            {
               // this.ssdItemSlot2.Add(this.CmbItemName.Text.ToString(), numericUpDownItemSlot.Value.ToString());
                clbstring = clbstring + "-" + numericUpDownItemSlot.Value.ToString();
            }
            else
            {
               // this.ssdItemSlot2.Add(this.CmbItemName.Text.ToString(), "");
                clbstring = clbstring + "-" + "0";
            }
           
            //增加道具数量

            if (int.Parse(ssdTimeLevel1[this.CmbItemName.Text.ToString()]) < 1)
            {
              //  this.ssdItemNum2.Add(this.CmbItemName.Text.ToString(), "0");
                clbstring = clbstring + "[数量]" + "-" + "0";
            }
            else
            {
               // this.ssdItemNum2.Add(this.CmbItemName.Text.ToString(), this.numericUpDownItemNum.Value.ToString());
                clbstring = clbstring + "[数量]" + "-" + this.numericUpDownItemNum.Value.ToString();
            }

            clbstring = clbstring + "[等级]" + "*" + this.numericUpDownItemLevel.Value.ToString();

            if (int.Parse(ssdTimeLevel1[this.CmbItemName.Text.ToString()]) < 1)
            {
              //  this.ssdTimeLevel2.Add(this.CmbItemName.Text.ToString(), "0");
                clbstring = clbstring + "[期限]" + "*" + "0";
            }
            else
            {
             //  this.ssdTimeLevel2.Add(this.CmbItemName.Text.ToString(), this.dateTimePickerTimeLevel.Value.ToString());
               TimeSpan ts = new TimeSpan();
                ts=this.dateTimePickerTimeLevel.Value.Date - System.DateTime.Now.Date;
               clbstring = clbstring + "[期限]" + "*" +ts.Days;
            }
            this.ClbItemName.Items.Remove(this.ClbItemName.SelectedItem);
            this.ClbItemName.Items.Add(clbstring);
            for (int x = 0; x < this.ClbItemName.Items.Count; x++)
                this.ClbItemName.SetSelected(x, true);


        }

        private void dateTimePickerTimeLevel_Leave(object sender, EventArgs e)
        {
            if (this.dateTimePickerTimeLevel.Value < DateTime.Now)
            {
                MessageBox.Show(config.ReadConfigValue("MFj", "FJ_UI_TimeLevel"));
                this.dateTimePickerTimeLevel.Value = DateTime.Now;
            }
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                StreamReader din = new StreamReader("b.txt", System.Text.Encoding.Default);

                string strall = null;
                string str = null;
                while ((str = din.ReadLine()) != null)
                {
                    strall = strall + str + ",";

                }

                userAccount = strall.Substring(0, strall.LastIndexOf(","));
                //userAccount = "敏敏,测试";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            ofd.RestoreDirectory = true;
            ofd.FilterIndex = 1;
            if(ofd.ShowDialog()==DialogResult.OK)

                txtFileName.Text= ofd.FileName;

            
        }

        

   
    }
}
