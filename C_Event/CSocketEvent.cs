using System;
using System.Reflection;
using System.Collections;

using C_Global;
using C_Socket;
using System.Windows.Forms;

namespace C_Event
{
    /// <summary>
    /// CSocketEvent Socket事件。
    /// </summary>
    public class CSocketEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strAddress">服务器地址</param>
        /// <param name="iServerPort">服务器端口</param>
        public CSocketEvent(string strAddress, int iServerPort)
        {
            mSocketClient = new CSocketClient();

            if (!mSocketClient.Init(strAddress, iServerPort))
            {
                throw new Exception("无法找到服务器!");
            }

            mSockData = new CSocketData();
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~CSocketEvent()
        {
            try
            {
                /*
                Message_Body[] mExitBody = new Message_Body[1];
                mExitBody[0].eName = C_Global.TagName.UserByID;
                mExitBody[0].eTag = C_Global.TagFormat.TLV_INTEGER;
                mExitBody[0].oContent = GetInfo("UserID");

                RequestResult(C_Global.ServiceKey.DISCONNECT, C_Global.Msg_Category.COMMON, mExitBody);
                */

                mSocketClient.finallize();
            }
            catch (Exception)
            {

            }
        }

        // <summary>
        /// 封装数据集的消息包
        /// </summary>
        /// <param name="queryList">输入数据列表</param>
        /// <param name="colCnt">输入列数</param>
        /// <returns>返回数据集的消息包</returns>
        public static C_Socket.CSocketData COMMON_MES_RESP(Query_Structure[] queryList, C_Global.CEnum.Msg_Category category, C_Global.CEnum.ServiceKey service, int colCnt)
        {
            uint iPos = 0;
            TLV_Structure[] tlv = new TLV_Structure[queryList.Length * colCnt];
            int pos = 0;

            for (int i = 0; i < queryList.Length; i++)
            {
                for (int j = 0; j < colCnt; j++)
                {
                    //消息元素格式
                    C_Global.CEnum.TagFormat format_ = queryList[i].m_tagList[j].format;
                    //消息元素名称
                    C_Global.CEnum.TagName key_ = queryList[i].m_tagList[j].tag;
                    //消息元素的值
                    byte[] bgMsg_Value = queryList[i].m_tagList[j].tag_buf;
                    //消息的结构体
                    TLV_Structure Msg_Value = new C_Socket.TLV_Structure(key_, format_, (uint)bgMsg_Value.Length, bgMsg_Value);
                    tlv[pos++] = Msg_Value;
                    iPos += Msg_Value.m_uiValueLen;
                }
                if (iPos + 20 >= 7192)
                {
                    pos = i;
                    break;
                }
            }
            //封装消息体
            Packet_Body body = new C_Socket.Packet_Body(tlv, (uint)tlv.Length, (uint)colCnt);
            //封装消息头
            Packet_Head head = new C_Socket.Packet_Head(C_Socket.SeqId_Generator.Instance().GetNewSeqID(), category, service, body.m_uiBodyLen);
            return new C_Socket.CSocketData(new C_Socket.Packet(head, body));
        }

        /// <summary>
        /// 保存指定键的信息
        /// </summary>
        /// <param name="Key">键名</param>
        /// <param name="Data">数据</param>
        /// <returns>T：成功；F：失败</returns>
        public bool SaveInfo(object Key, object Data)
        {
            bool bSuccess = false;

            try
            {
                int iInfoCount = 0;
                bool bNewInfo = false;

                //对象是否存在
                if (this.mSaveInfo == null)
                {
                    this.mSaveInfo = new TSaveInfo[1];
                    this.mSaveInfo[0].oKey = Key;
                    this.mSaveInfo[0].oData = Data;
                }
                else
                {
                    iInfoCount = mSaveInfo.GetLength(0);

                    //检查已有键的值
                    for (int i = 0; i < iInfoCount; i++)
                    {
                        if (this.mSaveInfo[i].oKey.Equals(Key))
                        {
                            //替换
                            bNewInfo = false;

                            this.mSaveInfo[i].oData = Data;
                        }
                        else
                        {
                            //添加
                            bNewInfo = true;

                            this.mTempInfo = new TSaveInfo[iInfoCount + 1];


                            for (int j = 0; j < iInfoCount; j++)
                            {
                                this.mTempInfo[j].oKey = this.mSaveInfo[j].oKey;
                                this.mTempInfo[j].oData = this.mSaveInfo[j].oData;
                            }


                            this.mTempInfo[i].oKey = this.mSaveInfo[i].oKey;
                            this.mTempInfo[i].oData = this.mSaveInfo[i].oData;
                        }
                    }

                    //保存最终结果
                    if (bNewInfo)
                    {
                        //添加新键值
                        this.mTempInfo[iInfoCount].oKey = Key;
                        this.mTempInfo[iInfoCount].oData = Data;

                        //保存最新内容
                        this.mSaveInfo = this.mTempInfo;
                    }
                }

                bSuccess = true;
            }
            catch (Exception e)
            {
                bSuccess = false;

                CEnum.TLogData tLogData = new CEnum.TLogData();

                tLogData.iSort = 5;
                tLogData.strDescribe = "保存关键字内容失败!";
                tLogData.strException = e.Message;
            }

            return bSuccess;
        }

        /// <summary>
        /// 获取保存内容
        /// </summary>
        /// <param name="Key">键名</param>
        /// <returns>指定键的数据</returns>
        public object GetInfo(object Key)
        {
            object oResult = null;

            for (int i = 0; i < this.mSaveInfo.GetLength(0); i++)
            {
                if (this.mSaveInfo[i].oKey.Equals(Key))
                {
                    oResult = this.mSaveInfo[i].oData;
                }
            }

            return oResult;
        }

        /// <summary>
        /// 取得消息结果
        /// </summary>
        /// <param name="mClient">Socket 连接</param>
        /// <param name="eServerKey"></param>
        /// <param name="eMsgCategory"></param>
        /// <param name="tSendContent">发送的消息</param>
        /// <returns>消息结果</returns>
        public CEnum.Message_Body[,] RequestResult(CEnum.ServiceKey eServerKey, CEnum.Msg_Category eMsgCategory, CEnum.Message_Body[] tSendContent)
        {
            CEnum.Message_Body[,] pReturnBody = null;

            try
            {
                CSocketData pSendata = mSockData.SocketSend(eServerKey, eMsgCategory, tSendContent);

                if (mSocketClient.Status())
                {
                    if (this.mSocketClient.SendDate(pSendata.bMsgBuffer))
                    {
                        pReturnBody = this.ReciveMessage(this.mSocketClient);
                    }
                    else
                    {
                        pReturnBody = new CEnum.Message_Body[1, 1];
                        pReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                        pReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
                        pReturnBody[0, 0].oContent = "失去服务器连接";

                        CEnum.TLogData tLogData = new CEnum.TLogData();

                        tLogData.iSort = 4;
                        tLogData.strDescribe = "失去服务器连接!";
                        tLogData.strException = "N/A";
                    }
                }
                else
                {
                    pReturnBody = new CEnum.Message_Body[1, 1];
                    pReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                    pReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
                    pReturnBody[0, 0].oContent = "失去服务器连接";

                    CEnum.TLogData tLogData = new CEnum.TLogData();

                    tLogData.iSort = 4;
                    tLogData.strDescribe = "失去服务器连接!";
                    tLogData.strException = "N/A";
                }
            }
            catch (Exception e)
            {
                pReturnBody = new CEnum.Message_Body[1, 1];
                pReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                pReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
                pReturnBody[0, 0].oContent = e.Message;//"失去服务器连接";

                CEnum.TLogData tLogData = new CEnum.TLogData();

                tLogData.iSort = 5;
                tLogData.strDescribe = "发送或接收Socket消息失败!";
                tLogData.strException = e.Message;
            }

            return pReturnBody;
        }

        public byte[] RequestResult(byte[] val, int fileSize)
        {
            if (this.mSocketClient.SendDate(val))
            {
                return mSocketClient.ReceiveData(fileSize);
            }

            return null;
        }


        /// <summary>
        ///  字段名称
        /// </summary>
        /// <param name="eTagName">TagName</param>
        /// <returns>TagName 对应字段名称</returns>
        public string DecodeFieldName(CEnum.TagName eTagName)
        {
            string strReturn = null;

            #region 解析字段名称
            switch (eTagName)
            {
                case CEnum.TagName.UserName:// 0x0101 Format:STRING
                    strReturn = "用户名称";
                    break;
                case CEnum.TagName.PassWord:// 0x0102 Format:STRING
                    strReturn = "用户口令";
                    break;
                case CEnum.TagName.MAC:// 0x0103 Format:STRING
                    strReturn = "MAC地址";
                    break;
                case CEnum.TagName.Limit:// 0x0104Format:DateTime
                    strReturn = "使用时效";
                    break;
                case CEnum.TagName.Status:// 0x0105 Format:STRING 状态信息
                    strReturn = "状态信息";
                    break;
                case CEnum.TagName.UserByID:// 0x0200 Format:NUMBER
                    strReturn = "操作员ID";
                    break;
                case CEnum.TagName.GameID:// 0x0200 Format:NUMBER
                    strReturn = "游戏ID";
                    break;
                case CEnum.TagName.ModuleName:// 0x0201 Format:STRING
                    strReturn = "模块名称";
                    break;
                case CEnum.TagName.ModuleClass:// 0x0202 Format:STRING
                    strReturn = "模块分类";
                    break;
                case CEnum.TagName.ModuleContent:// 0x0203 Format:STRING
                    strReturn = "模块描述";
                    break;
                case CEnum.TagName.Module_ID:// 0x0301 Format:INTEGER
                    strReturn = "模块ID";
                    break;
                case CEnum.TagName.User_ID:// 0x0302 Format:INTEGER
                    strReturn = "用户ID";
                    break;
                case CEnum.TagName.ModuleList:// 0x0302 Format:INTEGER
                    strReturn = "模块列表";
                    break;
                case CEnum.TagName.GameName:// 0x0302 Format:INTEGER
                    strReturn = "游戏名称";
                    break;
                case CEnum.TagName.GameContent:// 0x0302 Format:INTEGER
                    strReturn = "消息描述";
                    break;
                case CEnum.TagName.Letter_ID://0x0602, //Format: String
                    strReturn = "信件ID";
                    break;
                case CEnum.TagName.Letter_Sender://0x0602, //Format: String
                    strReturn = "发送人";
                    break;
                case CEnum.TagName.Letter_Receiver://0x0603, //Format String
                    strReturn = "接收人";
                    break;
                case CEnum.TagName.Letter_Subject://0x0604, //Format: String
                    strReturn = "主题";
                    break;
                case CEnum.TagName.Letter_Text://0x0605, //Format: String
                    strReturn = "内容";
                    break;
                case CEnum.TagName.Send_Date://0x0606, //Format: Date
                    strReturn = "发送日期";
                    break;
                case CEnum.TagName.Process_Man://0x0607, //Format:String
                    strReturn = "处理人";
                    break;
                case CEnum.TagName.Process_Date://0x0608, //Format:Date
                    strReturn = "处理日期";
                    break;
                case CEnum.TagName.Transmit_Man://0x0609, //Format:String
                    strReturn = "周转人";
                    break;
                case CEnum.TagName.Is_Process://0x060A, //Format:Integer
                    strReturn = "是否处理";
                    break;
                case CEnum.TagName.Host_Addr:// 0x0401 Format:STRING
                    strReturn = "主机地址";
                    break;
                case CEnum.TagName.Host_Port:// 0x0402 Format:STRING
                    strReturn = "主机端口";
                    break;
                case CEnum.TagName.Host_Pat:// 0x0403  Format:STRING
                    strReturn = "aaa";
                    break;
                case CEnum.TagName.Conn_Time:// 0x0404 Format:DateTime
                    strReturn = "连接时间";
                    break;
                case CEnum.TagName.Connect_Msg:// 0x0405 Format:STRING
                    strReturn = "连接网络消息";
                    break;
                case CEnum.TagName.DisConnect_Msg:// 0x0406	Format:STRING
                    strReturn = "断开网络消息";
                    break;
                case CEnum.TagName.Author_Msg: // 0x0407 Format: tring 
                    strReturn = "验证信息";
                    break;
                case CEnum.TagName.Index:
                    strReturn = "记录索引";
                    break;
                case CEnum.TagName.PageSize:
                    strReturn = "每页显示数据个数";
                    break;
                case CEnum.TagName.ERROR_Msg:
                    strReturn = "系统错误";
                    break;
                case CEnum.TagName.RealName:
                    strReturn = "姓名";
                    break;
                case CEnum.TagName.DepartID:
                    strReturn = "部门ID";
                    break;
                case CEnum.TagName.DepartName:
                    strReturn = "部门名称";
                    break;
                case CEnum.TagName.DepartRemark:
                    strReturn = "部门描述";
                    break;
                case CEnum.TagName.PageCount:
                    strReturn = "总页数";
                    break;
                case CEnum.TagName.SDO_ChargeSum:
                    strReturn = "合计";
                    break;
                case CEnum.TagName.MJ_Level: // 0x0701, //Format:Integer
                case CEnum.TagName.MJ_Account: // 0x0702, //Format:String
                case CEnum.TagName.MJ_CharName: // 0x0703, //Format:String
                case CEnum.TagName.MJ_Exp: // 0x0704, //Format:Integer
                case CEnum.TagName.MJ_Exp_Next_Level: // 0x0705, //Format:Integer
                case CEnum.TagName.MJ_HP: // 0x0706, //Format:Integer
                case CEnum.TagName.MJ_HP_Max: // 0x0707, //Format:Integer 
                case CEnum.TagName.MJ_MP: // 0x0708, //Format:Integer
                case CEnum.TagName.MJ_MP_Max: // 0x0709, //Format:Integer 
                case CEnum.TagName.MJ_DP: // 0x0710, //Format:Integer
                case CEnum.TagName.MJ_DP_Increase_Ratio: // 0x0711, //Format:Integer 
                case CEnum.TagName.MJ_Exception_Dodge: // 0x0712, //Format:Integer 
                case CEnum.TagName.MJ_Exception_Recovery: // 0x0713, //Format:Integer
                case CEnum.TagName.MJ_Physical_Ability_Max: // 0x0714, //Format:Integer 
                case CEnum.TagName.MJ_Physical_Ability_Min: // 0x0715, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Ability_Max: // 0x0716, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Ability_Min: // 0x0717, //Format:Integer 
                case CEnum.TagName.MJ_Tao_Ability_Max: // 0x0718, //Format:Integer 
                case CEnum.TagName.MJ_Tao_Ability_Min: // 0x0719, //Format:Integer 
                case CEnum.TagName.MJ_Physical_Defend_Max: // 0x0720, //Format:Integer 
                case CEnum.TagName.MJ_Physical_Defend_Min: // 0x0721, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Defend_Max: // 0x0722, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Defend_Min: // 0x0723, //Format:Integer 
                case CEnum.TagName.MJ_Accuracy: // 0x0724, //Format:Integer 
                case CEnum.TagName.MJ_Phisical_Dodge: // 0x0725, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Dodge: // 0x0726, //Format:Integer 
                case CEnum.TagName.MJ_Move_Speed: // 0x0727, //Format:Integer 
                case CEnum.TagName.MJ_Attack_speed: // 0x0728, //Format:Integer 
                case CEnum.TagName.MJ_Max_Beibao: // 0x0729, //Format:Integer 
                case CEnum.TagName.MJ_Max_Wanli: // 0x0730, //Format:Integer 
                case CEnum.TagName.MJ_Max_Fuzhong: // 0x0731, //Format:Integer
                case CEnum.TagName.MJ_ActionType: // = 0x0740,//Format:Integer 玩家ID
                case CEnum.TagName.MJ_Time: // = 0x0741,//Format:TimeStamp  操作时间
                case CEnum.TagName.MJ_CharIndex: // 0x0742,//玩家索引号
                case CEnum.TagName.MJ_CharName_Prefix: // 0x0743,//玩家帮会名称
                case CEnum.TagName.MJ_Exploit_Value: // 0x0744,//玩家功勋值
                case CEnum.TagName.MJ_ServerIP:
                    strReturn = "猛将游戏";
                    break;
                case CEnum.TagName.SDO_ServerIP:  //0x0801,//Format:String 大区IP
                    strReturn = "服务器IP";
                    break;
                case CEnum.TagName.SDO_UserIndexID:  //0x0802,//Format:Integer 玩家用户ID
                    strReturn = "玩家用户ID";
                    break;
                case CEnum.TagName.SDO_Account:  //0x0803,//Format:String 玩家的帐号
                    strReturn = "玩家的帐号";
                    break;
                case CEnum.TagName.SDO_Level:  //0x0804,//Format:Integer 玩家的等级
                    strReturn = "玩家的等级";
                    break;
                case CEnum.TagName.SDO_Exp:  //0x0805,//Format:Integer 玩家的当前经验值
                    strReturn = "当前经验值";
                    break;
                case CEnum.TagName.SDO_GameTotal:  //0x0806,//Format:Integer 总局数
                    strReturn = "总  局  数";
                    break;
                case CEnum.TagName.SDO_GameWin:  //0x0807,//Format:Integer 胜局数
                    strReturn = "胜  局  数";
                    break;
                case CEnum.TagName.SDO_DogFall:  //0x0808,//Format:Integer 平局数
                    strReturn = "平  局  数";
                    break;
                case CEnum.TagName.SDO_GameFall:  //0x0809,//Format:Integer 负局数
                    strReturn = "负  局  数";
                    break;
                case CEnum.TagName.SDO_Reputation:  //0x0810,//Format:Integer 声望值
                    strReturn = "声  望  值";
                    break;
                case CEnum.TagName.SDO_GCash:  //0x0811,//Format:Integer G币
                    strReturn = "玩家G币数量";
                    break;
                case CEnum.TagName.SDO_MCash:  //0x0812,//Format:Integer M币
                    strReturn = "玩家M币数量";
                    break;
                case CEnum.TagName.SDO_Address:  //0x0813,//Format:Integer 地址
                    strReturn = "玩家的地址";
                    break;
                case CEnum.TagName.SDO_Age:  //0x0814,//Format:Integer 年龄
                    strReturn = "玩家的年龄";
                    break;
                case CEnum.TagName.SDO_ProductID:  //0x0815,//Format:Integer 商品编号
                    strReturn = "商品编号";
                    break;
                case CEnum.TagName.SDO_ProductName:  //0x0816,//Format:String 商品名称
                    strReturn = "商品名称";
                    break;
                case CEnum.TagName.SDO_ItemCode:  //0x0817,//Format:Integer 道具编号
                    strReturn = "道具编号";
                    break;
                case CEnum.TagName.SDO_ItemName:  //0x0818,//Format:String 道具名称
                    strReturn = "道具名称";
                    break;
                case CEnum.TagName.SDO_MoneyType:  //0x0819,//Format:Integer 货币类型
                    strReturn = "货币类型";
                    break;
                case CEnum.TagName.SDO_MoneyCost:  //0x0820,//Format:Integer 道具的价格
                    strReturn = "道具价格";
                    break;
                case CEnum.TagName.SDO_ShopTime:  //0x0821,//Format:DateTime 消费时间
                    strReturn = "消费时间";
                    break;
                case CEnum.TagName.SDO_MAINCH:  //0x0822,//Format:Integer 服务器
                    strReturn = "服  务  器";
                    break;
                case CEnum.TagName.SDO_SUBCH:  //0x0823,//Format:Integer 房间
                    strReturn = "房      间";
                    break;
                case CEnum.TagName.SDO_Online:  //0x0824,//Format:Integer 是否在线
                    strReturn = "是否在线";
                    break;
                case CEnum.TagName.SDO_LoginTime:  //0x0825,//Format:DateTime 上线时间
                    strReturn = "上线时间";
                    break;
                case CEnum.TagName.SDO_LogoutTime:  //0x0826,//Format:DateTime 下线时间
                    strReturn = "下线时间";
                    break;
                case CEnum.TagName.SDO_AREANAME:  //0x0827,//Format tring 大区名字
                    strReturn = "服务器名称";
                    break;
                case CEnum.TagName.SDO_NickName:  //0x0836,//呢称
                    strReturn = "呢　　　称";
                    break;
                case CEnum.TagName.SDO_9YouAccount:  //0x0837,//9you的帐
                    strReturn = "９ＹＯＵ帐号";
                    break;
                case CEnum.TagName.SDO_SEX:  //0x0838,//性别
                    strReturn = "性　　别";
                    break;
                case CEnum.TagName.SDO_RegistDate:  //0x0839,//注册日期
                    strReturn = "注册日期";
                    break;
                case CEnum.TagName.SDO_FirstLogintime:  //0x0840,//第一次登录时间
                    strReturn = "第一次登录时间";
                    break;
                case CEnum.TagName.SDO_LastLogintime:  //0x0841,//最后一次登录时间
                    strReturn = "最后一次登录时间";
                    break;
                case CEnum.TagName.SDO_Ispad:  //0x0842,//是否已注册跳舞毯
                    strReturn = "跳舞毯状态";
                    break;
                case CEnum.TagName.SDO_Desc:// = 0x0843,//道具描述
                    strReturn = "道具描述";
                    break;
                case CEnum.TagName.SDO_Postion:// = 0x0844,//道具位置
                    strReturn = "道具位置";
                    break;
                case CEnum.TagName.SDO_MinLevel:// = 0x0843,//道具描述
                    strReturn = "所需等级";
                    break;
                case CEnum.TagName.SDO_DateLimit:// = 0x0844,//道具位置
                    strReturn = "日期期限";
                    break;
                case CEnum.TagName.SDO_TimesLimit:// = 0x0844,//道具位置
                    strReturn = "使用次数";
                    break;
                case CEnum.TagName.SDO_City:
                    strReturn = "所在城市";
                    break;
                case CEnum.TagName.SDO_BeginTime: //0x0845,//Format:Date 消费记录开始时间
                    strReturn = "消费记录开始时间";
                    break;
                case CEnum.TagName.SDO_EndTime: //0x0846,//Format:Date 消费记录结束时间
                    strReturn = "消费记录结束时间";
                    break;
                case CEnum.TagName.SDO_SendTime: //0x0847,//Format:Date 道具送人日期
                    strReturn = "道具送人日期";
                    break;
                case CEnum.TagName.SDO_SendIndexID: //0x0848,//Format:Integer 发送人的ID
                    strReturn = "发送人的ID";
                    break;
                case CEnum.TagName.SDO_SendUserID: //0x0849,//Format:String 发送人帐号
                    strReturn = "发送人帐号";
                    break;
                case CEnum.TagName.SDO_ReceiveNick: //0x0850,//Format:String 接受人呢称
                    strReturn = "接受人呢称";
                    break;
                case CEnum.TagName.SDO_BigType: //0x0851,//Format:Integer 道具大类
                    strReturn = "道具大类";
                    break;
                case CEnum.TagName.SDO_SmallType: // 0x0852,//Format:Integer 道具小类
                    strReturn = "道具小类";
                    break;
                case CEnum.TagName.SP_Name: //0x0412,//Format:String 存储过程名
                    strReturn = "存储过程名";
                    break;
                case CEnum.TagName.Real_ACT: //0x0413,//Format:String 操作的内容
                    strReturn = "操作的内容";
                    break;
                case CEnum.TagName.ACT_Time: //0x0414,//Format:TimeStamp 操作时间
                    strReturn = "操作时间";
                    break;
                case CEnum.TagName.BeginTime:// = 0x0415,//Format:Date 开始日期
                    strReturn = "开始日期";
                    break;
                case CEnum.TagName.EndTime:// = 0x0416,//Format:Date 结束日期
                    strReturn = "结束日期";
                    break;
                case CEnum.TagName.SDO_Title:
                    strReturn = "标    题";
                    break;
                case CEnum.TagName.SDO_Context:
                    strReturn = "内　　容";
                    break;
                case CEnum.TagName.SDO_Email:
                    strReturn = "Ｅ－ｍａｉｌ";
                    break;
                case CEnum.TagName.SDO_StopTime:
                    strReturn = "停封时间";
                    break;
                case CEnum.TagName.AU_ACCOUNT:// = 0x1001,//玩家帐号
                    strReturn = "玩家帐号";
                    break;
                case CEnum.TagName.AU_UserNick:// = 0x1002,//玩家呢称
                    strReturn = "玩家呢称";
                    break;
                case CEnum.TagName.AU_Sex:// = 0x1003,//玩家性别
                    strReturn = "玩家性别";
                    break;
                case CEnum.TagName.AU_State:// = 0x1004,//玩家状态
                    strReturn = "玩家状态";
                    break;
                case CEnum.TagName.AU_STOPSTATUS:// = 0x1005,//劲舞者封停状态
                    strReturn = "劲舞者封停状态";
                    break;
                case CEnum.TagName.AU_Reason:// 0x1006,//封停理由
                    strReturn = "封停理由";
                    break;
                case CEnum.TagName.AU_BanDate:// = 0x1007,//封停日期
                    strReturn = "封停日期";
                    break;
                case CEnum.TagName.AU_ServerIP:// = 0x1008,//劲舞团游戏服务器 Format:String
                    strReturn = "劲舞团游戏服务器";
                    break;
                case CEnum.TagName.CR_ServerIP://0x1101,//服务器IP
                    strReturn = "服务器";
                    break;
                case CEnum.TagName.CR_ACCOUNT://0x1102,//玩家帐号 Format:String
                    strReturn = "玩家帐号";
                    break;
                case CEnum.TagName.CR_Passord://0x1103,//玩家密码 Format:String
                    strReturn = "玩家密码";
                    break;
                case CEnum.TagName.CR_NUMBER://0x1104,//激活码 Format:String
                    strReturn = "激活码";
                    break;
                case CEnum.TagName.CR_ISUSE://0x1105,//是否被使用
                    strReturn = "是否被使用";
                    break;
                case CEnum.TagName.CR_STATUS://0x1106,//玩家状态 Format:Integer
                    strReturn = "玩家状态";
                    break;
                case CEnum.TagName.CR_ActiveIP://0x1107,//激活服务器IP Format:String
                    strReturn = "激活服务器";
                    break;
                case CEnum.TagName.CR_ActiveDate://0x1108,//激活日期 Format:TimeStamp
                    strReturn = "激活日期";
                    break;
                case CEnum.TagName.CR_BoardID://0x1109,//公告ID Format:Integer
                    strReturn = "公告ID";
                    break;
                case CEnum.TagName.CR_BoardContext://0x1110,//公告内容 Format:String
                    strReturn = "公告内容";
                    break;
                case CEnum.TagName.CR_BoardColor://0x1111,//公告颜色 Format:String
                    strReturn = "公告颜色";
                    break;
                case CEnum.TagName.CR_ValidTime://0x1112,//生效时间 Format:TimeStamp
                    strReturn = "生效时间";
                    break;
                case CEnum.TagName.CR_InValidTime://0x1113,//失效时间 Format:TimeStamp
                    strReturn = "失效时间";
                    break;
                case CEnum.TagName.CR_Valid://0x1114,//是否有效 Format:Integer
                    strReturn = "是否有效";
                    break;
                case CEnum.TagName.CR_PublishID://0x1115,//发布人ID Format:Integer
                    strReturn = "发布人ID";
                    break;
                case CEnum.TagName.CR_DayLoop://0x1116,//每天播放 Format:Integer
                    strReturn = "每天播放";
                    break;
                case CEnum.TagName.CR_SPEED:
                    strReturn = "播放速度";
                    break;
                case CEnum.TagName.CR_Mode:
                    strReturn = "播放方式";
                    break;
                case CEnum.TagName.CR_Channel:
                    strReturn = "频道ID";
                    break;
                case CEnum.TagName.CR_ACTION:
                    strReturn = "使用状态";
                    break;
                case CEnum.TagName.CR_Expire:
                    strReturn = "是否有效";
                    break;
                case CEnum.TagName.CR_BoardContext1:
                    strReturn = "是否有效2";
                    break;
                case CEnum.TagName.CR_BoardContext2:
                    strReturn = "是否有效3";
                    break;
                case CEnum.TagName.CARD_PDID:// 0x1202,
                    strReturn = "充值ID";
                    break;
                case CEnum.TagName.CARD_PDkey:// 0x1203,
                    strReturn = "交易号";
                    break;
                case CEnum.TagName.CARD_PDCardType:// 0x1204,
                    strReturn = "充值点卡类型";
                    break;
                case CEnum.TagName.CARD_PDFrom:// 0x1205,
                    strReturn = "充值来源";
                    break;
                case CEnum.TagName.CARD_PDCardNO:// 0x1206,
                    strReturn = "充值卡号";
                    break;
                case CEnum.TagName.CARD_PDCardPASS:// 0x1207,
                    strReturn = "充值卡密码";
                    break;
                case CEnum.TagName.CARD_PDCardPrice:// 0x1208,
                    strReturn = "充值卡面值";
                    break;
                case CEnum.TagName.CARD_PDaction:// 0x1209,
                    strReturn = "充值方式";
                    break;
                case CEnum.TagName.CARD_PDuserid:// 0x1210,
                    strReturn = "充值人ID";
                    break;
                case CEnum.TagName.CARD_PDusername:// 0x1211,
                    strReturn = "充值人";
                    break;
                case CEnum.TagName.CARD_PDgetuserid:// 0x1212,
                    strReturn = "被充值人ID";
                    break;
                case CEnum.TagName.CARD_PDgetusername:// 0x1213,
                    strReturn = "充值对象";
                    break;
                case CEnum.TagName.CARD_PDdate:// 0x1214,
                    strReturn = "操作时间";
                    break;
                case CEnum.TagName.CARD_PDip:// 0x1215,
                    strReturn = "操作者IP";
                    break;
                case CEnum.TagName.CARD_PDstatus:// 0x1216,
                    strReturn = "本次操作状态";
                    break;
                case CEnum.TagName.CARD_UDID:// 0x1217,
                    strReturn = "充值ID";
                    break;
                case CEnum.TagName.CARD_UDkey:// 0x1218,
                    strReturn = "交易号";
                    break;
                case CEnum.TagName.CARD_UDusedo:// 0x1219,
                    strReturn = "消费目的";
                    break;
                case CEnum.TagName.CARD_UDdirect:// 0x1220,
                    strReturn = "是否直充游戏";
                    break;
                case CEnum.TagName.CARD_UDuserid:// 0x1221,
                    strReturn = "使用人ID";
                    break;
                case CEnum.TagName.CARD_UDusername:// 0x1222,
                    strReturn = "消费人";
                    break;
                case CEnum.TagName.CARD_UDgetuserid:// 0x1223,
                    strReturn = "被使用人ID";
                    break;
                case CEnum.TagName.CARD_UDgetusername:// 0x1224,
                    strReturn = "消费对象";
                    break;
                case CEnum.TagName.CARD_UDcoins:// 0x1225,
                    strReturn = "金额";
                    break;
                case CEnum.TagName.CARD_UDtype:// 0x1226,
                    strReturn = "消费方式";
                    break;
                case CEnum.TagName.CARD_UDtargetvalue:// 0x1227,
                    strReturn = "消费随机码";
                    break;
                case CEnum.TagName.CARD_UDzone1:// 0x1228,
                    strReturn = "使用服务器参数1";
                    break;
                case CEnum.TagName.CARD_UDzone2:// 0x1229,
                    strReturn = "使用服务器参数2";
                    break;
                case CEnum.TagName.CARD_UDdate:// 0x1230,
                    strReturn = "操作时间";
                    break;
                case CEnum.TagName.CARD_UDip:// 0x1231,
                    strReturn = "操作者IP";
                    break;
                case CEnum.TagName.CARD_UDstatus:// 0x1232,
                    strReturn = "本次操作状态";
                    break;
                case CEnum.TagName.CARD_cardnum:// 0x1233,
                    strReturn = "卡号";
                    break;
                case CEnum.TagName.CARD_cardpass:// 0x1234,
                    strReturn = "密码";
                    break;
                case CEnum.TagName.CARD_serial:// 0x1235,
                    strReturn = "点卡序号";
                    break;
                case CEnum.TagName.CARD_draft:// 0x1236,
                    strReturn = "批号";
                    break;
                //case CEnum.TagName.CARD_type1:// 0x1237,
                //    strReturn = "类型1";
                //    break;
                //case CEnum.TagName.CARD_type2:// 0x1238,
                //    strReturn = "类型2";
                //    break;
                //case CEnum.TagName.CARD_type3:// 0x1239,
                //    strReturn = "类型3";
                //    break;
                //case CEnum.TagName.CARD_type4:// 0x1240,
                //    strReturn = "类型4";
                //    break;
                case CEnum.TagName.CARD_price:// 0x1241,
                    strReturn = "金额";
                    break;
                case CEnum.TagName.CARD_valid_date:// 0x1242,
                    strReturn = "有效期";
                    break;
                case CEnum.TagName.CARD_use_status:// 0x1243,
                    strReturn = "是否使用";
                    break;
                case CEnum.TagName.CARD_cardsent:// 0x1244,
                    strReturn = "Ｓｅｎｔ";
                    break;
                case CEnum.TagName.CARD_create_date:// 0x1245,
                    strReturn = "使用时间";
                    break;
                case CEnum.TagName.CARD_use_userid:// 0x1246,
                    strReturn = "使用者ID";
                    break;
                case CEnum.TagName.CARD_use_username:// 0x1247,
                    strReturn = "使用者用户名";
                    break;
                case CEnum.TagName.CARD_partner:// 0x1248,
                    strReturn = "合作厂商ID";
                    break;
                case CEnum.TagName.CARD_skey:// 0x1249,
                    strReturn = "明细帐ID";
                    break;
                case CEnum.TagName.CARD_ActionType:
                    strReturn = "操作类型";
                    break;
                case CEnum.TagName.CARD_id:// 0x1251 ,//TLV_STRING 久之游注册卡号
                    strReturn = "身份证号码";
                    break;
                case CEnum.TagName.CARD_username:// 0x1252,//TLV_STRING 久之游注册用户名
                    strReturn = "注册用户名";
                    break;
                case CEnum.TagName.CARD_nickname:// 0x1253,//TLV_STRING 久之游注册呢称
                    strReturn = "注册呢称";
                    break;
                case CEnum.TagName.CARD_password:// 0x1254,//TLV_STRING 久之游注册密码
                    strReturn = "注册密码";
                    break;
                case CEnum.TagName.CARD_sex:// 0x1255,//TLV_STRING 久之游注册性别
                    strReturn = "注册性别";
                    break;
                case CEnum.TagName.CARD_rdate:// 0x1256,//TLV_Date 久之游注册日期
                    strReturn = "注册日期";
                    break;
                case CEnum.TagName.CARD_rtime:// 0x1257,//TLV_Time 久之游注册时间
                    strReturn = "注册时间";
                    break;
                case CEnum.TagName.CARD_securecode:// 0x1258,//TLV_STRING 安全码
                    strReturn = "安全码";
                    break;
                case CEnum.TagName.CARD_vis:// 0x1259,//TLV_INTEGER
                    strReturn = "~~~";
                    break;
                case CEnum.TagName.CARD_logdate:// 0x1260,//TLV_TimeStamp 日期
                    strReturn = "日期";
                    break;
                case CEnum.TagName.CARD_realname:// 0x1263,//TLV_STRING 真实姓名
                    strReturn = "真实姓名";
                    break;
                case CEnum.TagName.CARD_birthday:// 0x1264,//TLV_Date 出生日期
                    strReturn = "出生日期";
                    break;
                case CEnum.TagName.CARD_cardtype:// 0x1265,//TLV_STRING
                    strReturn = "类型";
                    break;
                case CEnum.TagName.CARD_email:// 0x1267,//TLV_STRING 邮件
                    strReturn = "邮件";
                    break;
                case CEnum.TagName.CARD_occupation:// 0x1268,//TLV_STRING 职业
                    strReturn = "职业";
                    break;
                case CEnum.TagName.CARD_education:// 0x1269,//TLV_STRING 教育程度
                    strReturn = "教育程度";
                    break;
                case CEnum.TagName.CARD_marriage:// 0x1270,//TLV_STRING 婚否
                    strReturn = "婚否";
                    break;
                case CEnum.TagName.CARD_constellation:// 0x1271,//TLV_STRING 星座
                    strReturn = "星座";
                    break;
                case CEnum.TagName.CARD_shx:// 0x1272,//TLV_STRING 生肖
                    strReturn = "生肖";
                    break;
                case CEnum.TagName.CARD_city:// 0x1273,//TLV_STRING 城市
                    strReturn = "城市";
                    break;
                case CEnum.TagName.CARD_address:// 0x1274,//TLV_STRING 联系地址
                    strReturn = "联系地址";
                    break;
                case CEnum.TagName.CARD_phone:// 0x1275,//TLV_STRING 联系电话
                    strReturn = "联系电话";
                    break;
                case CEnum.TagName.CARD_qq:// 0x1276,//TLV_STRING QQ
                    strReturn = "QQ号";
                    break;
                case CEnum.TagName.CARD_intro:// 0x1277,//TLV_STRING 介绍
                    strReturn = "介绍";
                    break;
                case CEnum.TagName.CARD_msn:// 0x1278,//TLV_STRING MSN
                    strReturn = "MSN地址";
                    break;
                case CEnum.TagName.CARD_mobilephone:// 0x1279,//TLV_STRING 移动电话
                    strReturn = "移动电话";
                    break;
                case CEnum.TagName.CARD_SumTotal:
                    strReturn = "合计";
                    break;
                case CEnum.TagName.AuShop_orderid://=0x1301,//int(11)
                    strReturn = "编号";
                    break;

                case CEnum.TagName.AuShop_udmark://=0x1302,//int(8)
                    strReturn = "udmark";
                    break;

                case CEnum.TagName.AuShop_bkey://=0x1303,//varchar(40)
                    strReturn = "bkey";
                    break;

                case CEnum.TagName.AuShop_pkey://=0x1304,//varchar(18)
                    strReturn = "pkey";
                    break;

                case CEnum.TagName.AuShop_userid://=0x1305,//int(11)
                    strReturn = "玩家编号";
                    break;

                case CEnum.TagName.AuShop_username://=0x1306,//varchar(20)
                    strReturn = "用户名";
                    break;

                case CEnum.TagName.AuShop_getuserid://=0x1307,//int(11)
                    strReturn = "获赠玩家编号";
                    break;

                case CEnum.TagName.AuShop_getusername://=0x1308,//varchar(20)
                    strReturn = "赠送给";
                    break;

                case CEnum.TagName.AuShop_pcategory://=0x1309,//smallint(4)
                    strReturn = "种类";
                    break;

                case CEnum.TagName.AuShop_pisgift://=0x1310,//enum('y','n')
                    strReturn = "礼物";
                    break;

                case CEnum.TagName.AuShop_islover://=0x1311,//enum('y','n')
                    strReturn = "情人";
                    break;

                case CEnum.TagName.AuShop_ispresent://=0x1312,//enum('y','n')
                    strReturn = "赠送品";
                    break;

                case CEnum.TagName.AuShop_isbuysong://=0x1313,//enum('y','n')
                    strReturn = "购买歌曲";
                    break;

                case CEnum.TagName.AuShop_prule://=0x1314,//tinyint(1)
                    strReturn = "规则";
                    break;

                case CEnum.TagName.AuShop_psex://=0x1315,//enum('all','m','f')
                    strReturn = "性别";
                    break;

                case CEnum.TagName.AuShop_pbuytimes://=0x1316,//int(11)
                    strReturn = "购买时限";
                    break;

                case CEnum.TagName.AuShop_allprice://=0x1317,//int(11)
                    strReturn = "计价";
                    break;

                case CEnum.TagName.AuShop_allaup://=0x1318,//int(11)
                    strReturn = "商城积分";
                    break;

                case CEnum.TagName.AuShop_buytime://=0x1319,//int(10)
                    strReturn = "道具时限";
                    break;

                case CEnum.TagName.AuShop_buytime2://=0x1320,//datetime
                    strReturn = "购买时间";
                    break;

                case CEnum.TagName.AuShop_buyip://=0x1321,//varchar(15)
                    strReturn = "购买人IP";
                    break;

                case CEnum.TagName.AuShop_zone://=0x1322,//tinyint(2)
                    strReturn = "地区";
                    break;

                case CEnum.TagName.AuShop_status://=0x1323,//tinyint(1)
                    strReturn = "状态";
                    break;

                case CEnum.TagName.AuShop_pid://=0x1324,//int(11)
                    strReturn = "ID";
                    break;

                case CEnum.TagName.AuShop_pname://=0x1326,//varchar(20)
                    strReturn = "道具名称";
                    break;

                case CEnum.TagName.AuShop_pgift://=0x1328,//enum('y','n')
                    strReturn = "礼物";
                    break;

                case CEnum.TagName.AuShop_pscash://=0x1330,//tinyint(2)
                    strReturn = "现金";
                    break;

                case CEnum.TagName.AuShop_pgamecode://=0x1331,//varchar(200)
                    strReturn = "游戏代码";
                    break;

                case CEnum.TagName.AuShop_pnew://=0x1332,//enum('y','n')
                    strReturn = "新";
                    break;

                case CEnum.TagName.AuShop_phot://=0x1333,//enum('y','n')
                    strReturn = "热";
                    break;

                case CEnum.TagName.AuShop_pcheap://=0x1334,//enum('y','n')
                    strReturn = "便宜";
                    break;

                case CEnum.TagName.AuShop_pchstarttime://=0x1335,//int(10)
                    strReturn = "开始时间";
                    break;

                case CEnum.TagName.AuShop_pchstoptime://=0x1336,//int(10)
                    strReturn = "停止时间";
                    break;

                case CEnum.TagName.AuShop_pstorage://=0x1337,//smallint(5)
                    strReturn = "仓库";
                    break;

                case CEnum.TagName.AuShop_pautoprice://=0x1339,//enum('y','n')
                    strReturn = "自定义价格";
                    break;

                case CEnum.TagName.AuShop_price://=0x1340,//int(8)
                    strReturn = "价格";
                    break;

                case CEnum.TagName.AuShop_chprice://=0x1341,//int(8)
                    strReturn = "价格";
                    break;

                case CEnum.TagName.AuShop_aup://=0x1342,//int(8)
                    strReturn = "商城积分";
                    break;

                case CEnum.TagName.AuShop_chaup://=0x1343,//int(8)
                    strReturn = "chaup";
                    break;

                case CEnum.TagName.AuShop_ptimeitem://=0x1344,//varchar(200)
                    strReturn = "ptimeitem";
                    break;

                case CEnum.TagName.AuShop_pricedetail://=0x1345,//varchar(254)
                    strReturn = "价格说明";
                    break;

                case CEnum.TagName.AuShop_pdesc://=0x1347,//text
                    strReturn = "pdesc";
                    break;

                case CEnum.TagName.AuShop_pbuys://=0x1348,//int(8)
                    strReturn = "购买";
                    break;

                case CEnum.TagName.AuShop_pfocus://=0x1349,//tinyint(1)
                    strReturn = "位置";
                    break;

                case CEnum.TagName.AuShop_pmark1://=0x1350,//enum('y','n')
                    strReturn = "标志";
                    break;

                case CEnum.TagName.AuShop_pmark2://=0x1351,//enum('y','n')
                    strReturn = "标志";
                    break;

                case CEnum.TagName.AuShop_pmark3://=0x1352,//enum('y','n')
                    strReturn = "标志";
                    break;

                case CEnum.TagName.AuShop_pinttime://=0x1353,//int(10)
                    strReturn = "兑换时间";
                    break;

                case CEnum.TagName.AuShop_pdate://=0x1354,//int(10)
                    strReturn = "pdate";
                    break;

                case CEnum.TagName.AuShop_pisuse://=0x1355,//enum('y','n')
                    strReturn = "是否使用";
                    break;

                case CEnum.TagName.AuShop_ppic://=0x1356,//varchar(36)
                    strReturn = "形象图片";
                    break;

                case CEnum.TagName.AuShop_ppic1://=0x1357,//varchar(36)
                    strReturn = "形象图片";
                    break;

                case CEnum.TagName.AuShop_usefeesum://=0x1358,//int
                    strReturn = "使用积分总额";
                    break;

                case CEnum.TagName.AuShop_useaupsum://=0x1359,//int
                    strReturn = "使用商城积分总额";
                    break;

                case CEnum.TagName.AuShop_buyitemsum://=0x1360,//int
                    strReturn = "购买道具总额";
                    break;

                case CEnum.TagName.AuShop_BeginDate://=0x1361,//date
                    strReturn = "开始时间";
                    break;

                case CEnum.TagName.AuShop_EndDate://=0x1362,//date
                    strReturn = "结束时间";
                    break;

                case CEnum.TagName.AuShop_GCashSum:// = 0x1363,
                    strReturn = "G币总和";
                    break;

                case CEnum.TagName.AuShop_MCashSum:// = 0x1364,
                    strReturn = "M币总和";
                    break;
                case CEnum.TagName.SDO_DaysLimit:
                    strReturn = "天数限制";
                    break;
                default:
                    strReturn = "未知";
                    break;
            }
            #endregion

            return strReturn;
        }



        /// <summary>
        /// 获取CSocketEvent中已存的ServersCount、IpForServer + i、(CSocketEvent)(Server + i)
        /// 
        /// </summary>
        /// <param name="m_ClientEvent"></param>
        /// <returns></returns>
        public CSocketEvent GetSocket(CSocketEvent m_ClientEvent, string sCurrServerIp)
        {
            CSocketEvent returnValue = null;

            if (sCurrServerIp == null)
            {
                return m_ClientEvent;
            }

            int ServersCount = int.Parse(m_ClientEvent.GetInfo("ServersCount").ToString());

            for (int i = 1; i <= ServersCount; i++)
            {
                if ((m_ClientEvent.GetInfo("IpForServer" + i).ToString()).IndexOf(sCurrServerIp) != -1)
                {
                    returnValue = (CSocketEvent)m_ClientEvent.GetInfo("Server" + i);
                    break;
                }
            }

            if (returnValue == null)
                returnValue = m_ClientEvent;

            if (m_ClientEvent.mSaveInfo != null && m_ClientEvent != returnValue)
            {
                returnValue.mSaveInfo = null;
                for (int i = 0; i < m_ClientEvent.mSaveInfo.GetLength(0); i++)
                {
                    returnValue.SaveInfo(m_ClientEvent.mSaveInfo[i].oKey, m_ClientEvent.mSaveInfo[i].oData);
                }


            }



            return returnValue;

        }

        #region 私有变量
        private struct TSaveInfo
        {
            public object oKey;
            public object oData;
        }
        private TSaveInfo[] mSaveInfo = null;
        private TSaveInfo[] mTempInfo = null;
        private CSocketClient mSocketClient = null;
        private CSocketData mSockData = null;

        /// <summary>
        /// 解析字段内容
        /// </summary>
        /// <param name="iRow">行标签</param>
        /// <param name="iField">字段标签</param>
        /// <param name="tTlv">消息体</param>
        /// <param name="tBody">消息内容</param>
        /// <returns>消息内容</returns>
        private CEnum.Message_Body[,] DecodeRecive(int iRow, int iField, TLV_Structure tTlv, CEnum.Message_Body[,] tBody)
        {
            #region 解析字段内容
            switch (tTlv.m_Tag)
            {
                case CEnum.TagName.UserName:// 0x0101 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.PassWord:// 0x0102 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.MAC:// 0x0103 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Limit:// 0x0104Format:DateTime
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_DATE;
                    tBody[iRow, iField].oContent = tTlv.toDate();
                    break;
                case CEnum.TagName.User_Status:// 0x0103 Format:INT
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.UserByID:// 0x0104Format:DateTime
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.GameID:// 0x0200 Format:INT
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.ModuleName:// 0x0201 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.ModuleClass:// 0x0202 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.ModuleContent:// 0x0203 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Module_ID:// 0x0301 Format:INTEGER
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.User_ID:// 0x0302 Format:INTEGER
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.ModuleList:// 0x0302 Format:INTEGER
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.GameName:// 0x0302 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.GameContent:// 0x0302 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Letter_ID://0x0602, //Format: String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.Letter_Sender://0x0602, //Format: String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Letter_Receiver://0x0603, //Format String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Letter_Subject://0x0604, //Format: String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Letter_Text://0x0605, //Format: String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Send_Date://0x0606, //Format: Date
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_DATE;
                    tBody[iRow, iField].oContent = tTlv.toDate();
                    break;
                case CEnum.TagName.Process_Man://0x0607, //Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Process_Date://0x0608, //Format:Date
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_DATE;
                    tBody[iRow, iField].oContent = tTlv.toDate();
                    break;
                case CEnum.TagName.Transmit_Man://0x0609, //Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Is_Process://0x060A, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.Host_Addr:// 0x0401 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Host_Port:// 0x0402 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Host_Pat:// 0x0403  Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Conn_Time:// 0x0404 Format:DateTime
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_DATE;
                    tBody[iRow, iField].oContent = tTlv.toDate();
                    break;
                case CEnum.TagName.Connect_Msg:// 0x0405 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.DisConnect_Msg:// 0x0406	Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Status://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Index:
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.PageSize:
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.RealName://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.DepartID://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.DepartName://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.DepartRemark://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.Author_Msg:// 0x0407	Format:STRING
                case CEnum.TagName.ERROR_Msg:	//0xFFFF Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.PageCount://0x0408 Format:STRING
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Level: // 0x0701, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Account: // 0x0702, //Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.MJ_CharName: // 0x0703, //Format:String
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();
                    break;
                case CEnum.TagName.MJ_Exp: // 0x0704, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Exp_Next_Level: // 0x0705, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_HP: // 0x0706, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_HP_Max: // 0x0707, //Format:Integer 
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_MP: // 0x0708, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_MP_Max: // 0x0709, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_DP: // 0x0710, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_DP_Increase_Ratio: // 0x0711, //Format:Integer 
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Exception_Dodge: // 0x0712, //Format:Integer 
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Exception_Recovery: // 0x0713, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Physical_Ability_Max: // 0x0714, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Physical_Ability_Min: // 0x0715, //Format:Integer 
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Magic_Ability_Max: // 0x0716, //Format:Integer
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_Magic_Ability_Min: // 0x0717, //Format:Integer 
                case CEnum.TagName.MJ_Tao_Ability_Max: // 0x0718, //Format:Integer 
                case CEnum.TagName.MJ_Tao_Ability_Min: // 0x0719, //Format:Integer 
                case CEnum.TagName.MJ_Physical_Defend_Max: // 0x0720, //Format:Integer 
                case CEnum.TagName.MJ_Physical_Defend_Min: // 0x0721, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Defend_Max: // 0x0722, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Defend_Min: // 0x0723, //Format:Integer 
                case CEnum.TagName.MJ_Accuracy: // 0x0724, //Format:Integer 
                case CEnum.TagName.MJ_Phisical_Dodge: // 0x0725, //Format:Integer 
                case CEnum.TagName.MJ_Magic_Dodge: // 0x0726, //Format:Integer 
                case CEnum.TagName.MJ_Move_Speed: // 0x0727, //Format:Integer 
                case CEnum.TagName.MJ_Attack_speed: // 0x0728, //Format:Integer 
                case CEnum.TagName.MJ_Max_Beibao: // 0x0729, //Format:Integer 
                case CEnum.TagName.MJ_Max_Wanli: // 0x0730, //Format:Integer 
                case CEnum.TagName.MJ_Max_Fuzhong: // 0x0731, //Format:Integer
                case CEnum.TagName.MJ_TypeID:
                case CEnum.TagName.MJ_Money:
                case CEnum.TagName.MJ_ActionType: // = 0x0740,//Format:Integer 玩家ID
                case CEnum.TagName.SDO_9YouAccount://0x0837,//9you的帐号
                case CEnum.TagName.MJ_CharIndex: // 0x0742,//玩家索引号
                case CEnum.TagName.MJ_Exploit_Value: // 0x0744,//玩家功勋值
                case CEnum.TagName.CR_SPEED:// = 0x1129,//播放速度Format:Integer

                case CEnum.TagName.CR_PSTID:// = 0x1117,//注册号 Format:Integer
                case CEnum.TagName.CR_SEX:// = 0x1118,//性别 Format:Integer
                case CEnum.TagName.CR_LEVEL:// = 0x1119,//等级 Format:Integer
                case CEnum.TagName.CR_EXP:// = 0x1120,//经验 Format:Integer
                case CEnum.TagName.CR_License:// = 0x1121,//驾照Format:Integer
                case CEnum.TagName.CR_Money:// = 0x1122,//金钱Format:Integer
                case CEnum.TagName.CR_RMB:// = 0x1123,//人民币Format:Integer
                case CEnum.TagName.CR_RaceTotal:// = 0x1124,//比赛总数Format:Integer
                case CEnum.TagName.CR_RaceWon:// = 0x1125,//胜利场数Format:Integer
                case CEnum.TagName.CR_ExpOrder:// = 0x1126,//经验排名Format:Integer
                case CEnum.TagName.CR_WinRateOrder:// = 0x1127,//胜率排名Format:Integer
                case CEnum.TagName.CR_WinNumOrder:// = 0x1128,//胜利场数排名Format:Integer
                case CEnum.TagName.CR_Channel:// = 0x1133,//频道ID
                case CEnum.TagName.CR_Expire:// = 0x1137,//生效格式
                case CEnum.TagName.CR_ChannelID:
                ////////////////////////////
                case CEnum.TagName.UpdateFileSize:// = 0x0115//Format:Integer 文件大小]
                case CEnum.TagName.AuShop_GCashSum:// = 0x1363,
                case CEnum.TagName.AuShop_MCashSum:// = 0x1364,
                case CEnum.TagName.CARD_use_userid:// 0x1246
                ///

                case CEnum.TagName.o2jam_SenderIndexID://=0x1410,//int
                case CEnum.TagName.o2jam_ReceiverIndexID://=0x1413,//int




                case CEnum.TagName.o2jam_GEM://=0x1422,//int
                case CEnum.TagName.o2jam_MCASH://=0x1423,//int
                case CEnum.TagName.o2jam_O2CASH://=0x1424,//int
                case CEnum.TagName.o2jam_MUSICCASH://=0x1425,//int
                case CEnum.TagName.o2jam_ITEMCASH://=0x1426,//int
                case CEnum.TagName.o2jam_USER_INDEX_ID://=0x1427,//int
                case CEnum.TagName.o2jam_ITEM_INDEX_ID://=0x1428,//int
                case CEnum.TagName.o2jam_USED_COUNT://=0x1429,//int

                case CEnum.TagName.o2jam_OLD_USED_COUNT://=0x1431,//int
                case CEnum.TagName.o2jam_CURRENT_CASH://=0x1433,//int
                case CEnum.TagName.o2jam_CHARGED_CASH://=0x1434,//int

                case CEnum.TagName.o2jam_KIND://=0x1438,//int
                case CEnum.TagName.o2jam_PLANET://=0x1439,//int
                case CEnum.TagName.o2jam_VAL://=0x1440,//int
                case CEnum.TagName.o2jam_EFFECT://=0x1441,//int
                case CEnum.TagName.o2jam_JUSTICE://=0x1442,//int
                case CEnum.TagName.o2jam_LIFE://=0x1443,//int
                case CEnum.TagName.o2jam_PRICE_KIND://=0x1444,//int
                case CEnum.TagName.o2jam_Exp://=0x1445,//Int
                case CEnum.TagName.o2jam_Battle://=0x1446,//Int
                case CEnum.TagName.o2jam_POSITION://=0x1448,//int
                case CEnum.TagName.o2jam_COMPANY_ID://=0x1449,//int

                case CEnum.TagName.o2jam_ITEM_USE_COUNT://=0x1454,//int
                case CEnum.TagName.o2jam_ITEM_ATTR_KIND://=0x1455,//int
                case CEnum.TagName.O2JAM_BuyType:// = 0x1509,//TLV_INTEGER

                case CEnum.TagName.O2JAM_EQUIP1://=0x1463,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP2://=0x1464,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP3://=0x1465,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP4://=0x1466,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP5://=0x1467,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP6://=0x1468,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP7://=0x1469,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP8://=0x1470,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP9://=0x1471,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP10://=0x1472,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP11://=0x1473,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP12://=0x1474,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP13://=0x1475,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP14://=0x1476,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP15://=0x1477,//TLV_STRING,
                case CEnum.TagName.O2JAM_EQUIP16://=0x1478,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG1://=0x1479,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG2://=0x1480,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG3://=0x1481,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG4://=0x1482,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG5://=0x1483,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG6://=0x1484,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG7://=0x1485,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG8://=0x1486,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG9://=0x1487,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG10://=0x1488,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG11://=0x1489,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG12://=0x1490,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG13://=0x1491,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG14://=0x1492,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG15://=0x1493,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG16://=0x1494,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG17://=0x1495,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG18://=0x1496,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG19://=0x1497,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG20://=0x1498,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG21://=0x1499,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG22://=0x1500,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG23://=0x1501,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG24://=0x1502,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG25://=0x1503,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG26://=0x1504,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG27://=0x1505,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG28://=0x1506,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG29://=0x1507,//TLV_STRING,
                case CEnum.TagName.O2JAM_BAG30://=0x1508,//TLV_STRING


                case CEnum.TagName.O2JAM2_Rdate:// = 0x1606,//TLV_Date
                case CEnum.TagName.O2JAM2_IsUse:// = 0x1607,//TLV_Integer
                case CEnum.TagName.O2JAM2_Status:// = 0x1608,//TLV_Integer
                case CEnum.TagName.SysAdmin:

                case CEnum.TagName.SDO_SenceID://= 0x0858,
                case CEnum.TagName.SDO_WeekDay://= 0x0859,
                case CEnum.TagName.SDO_MatPtHR://= 0x0860,
                case CEnum.TagName.SDO_MatPtMin://= 0x0861,
                case CEnum.TagName.SDO_StPtHR://= 0x0862,
                case CEnum.TagName.SDO_StPtMin://= 0x0863,
                case CEnum.TagName.SDO_EdPtHR://= 0x0864,
                case CEnum.TagName.SDO_EdPtMin://= 0x0865,
                case CEnum.TagName.SDO_GCash://= 0x0866,
                case CEnum.TagName.SDO_MCash://= 0x0867,

                case CEnum.TagName.SDO_MusicID1://= 0x0869,

                case CEnum.TagName.SDO_LV1://= 0x0871,
                case CEnum.TagName.SDO_MusicID2://= 0x0872,

                case CEnum.TagName.SDO_LV2://= 0x0874,
                case CEnum.TagName.SDO_MusicID3://= 0x0875,

                case CEnum.TagName.SDO_LV3://= 0x0877,
                case CEnum.TagName.SDO_MusicID4://= 0x0878,

                case CEnum.TagName.SDO_LV4://= 0x0880,
                case CEnum.TagName.SDO_MusicID5://= 0x0881,

                case CEnum.TagName.SDO_LV5://= 0x0883,

                case CEnum.TagName.SDO_Precent:// = 0x0884,

                case CEnum.TagName.O2JAM2_UserIndexID://= 0x1609,//TLV_Integer
                case CEnum.TagName.O2JAM2_Level://= 0x1612,//Format:TLV_INTEGER 等级
                case CEnum.TagName.O2JAM2_Win://= 0x1613,//Format:TLV_INTEGER 胜
                case CEnum.TagName.O2JAM2_Draw://= 0x1614,//Format:TLV_INTEGER 平
                case CEnum.TagName.O2JAM2_Lose://= 0x1615,//Format:TLV_INTEGER 负
                case CEnum.TagName.O2JAM2_Exp://= 0x1616,//Format:TLV_INTEGER 经验
                case CEnum.TagName.O2JAM2_TOTAL://= 0x1617,//Format:TLV_INTEGER 总局数
                case CEnum.TagName.O2JAM2_GCash://= 0x1618,//Format:TLV_INTEGER G币
                case CEnum.TagName.O2JAM2_MCash://= 0x1619,//Format:TLV_INTEGER M币
                case CEnum.TagName.O2JAM2_ItemCode://= 0x1620,//Format:TLV_INTEGER
                case CEnum.TagName.O2JAM2_Position://= 0x1625,//int
                case CEnum.TagName.O2JAM2_MoneyType://= 0x1628,//int
                case CEnum.TagName.O2JAM2_ItemSource://= 0x1624,//int
                case CEnum.TagName.O2JAM2_DayLimit:
                case CEnum.TagName.O2JAM2_StopStatus:// = 0x1635,//int

                case CEnum.TagName.SDO_wPlanetID:// = 0x0893, 
                case CEnum.TagName.SDO_wChannelID:// = 0x0894,
                case CEnum.TagName.SDO_iLimitUser:// = 0x0895, 
                case CEnum.TagName.SDO_iCurrentUser:// = 0x0896,
                case CEnum.TagName.Soccer_charidx://角色序列号 (ExSoccer.dbo.t_character[idx])
                case CEnum.TagName.Soccer_charexp: //经验值
                case CEnum.TagName.Soccer_charlevel://等级
                case CEnum.TagName.Soccer_charpoint://G点数 
                case CEnum.TagName.Soccer_match://比赛数
                case CEnum.TagName.Soccer_win://
                case CEnum.TagName.Soccer_lose://失败
                case CEnum.TagName.Soccer_draw://平局
                case CEnum.TagName.Soccer_drop://平局		
                case CEnum.TagName.Soccer_charpos://位置
                case CEnum.TagName.Soccer_idx:
                case CEnum.TagName.Soccer_account_idx:
                case CEnum.TagName.Soccer_class:
                case CEnum.TagName.Bug_ID:// = 0x0117,//Format:Integer bugID
                case CEnum.TagName.AU_Pcash:
                case CEnum.TagName.SDO_Type:

                case CEnum.TagName.NOTES_PUID:
                case CEnum.TagName.NOTES_AttachmentCount:
                case CEnum.TagName.NOTES_View:
                case CEnum.TagName.NOTES_ID:
                case CEnum.TagName.NOTES_Status:
                case CEnum.TagName.AU_StopCode:
                case CEnum.TagName.AU_NightDiscount:
                case CEnum.TagName.AU_UsedCount:
                case CEnum.TagName.AU_MaxCount:
                case CEnum.TagName.AU_ExpRate:
                case CEnum.TagName.AU_MoneyRate:
                case CEnum.TagName.AU_Status:
                case CEnum.TagName.AU_Interval:

                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.MJ_CharName_Prefix: // 0x0743,//玩家帮会名称
                case CEnum.TagName.SDO_ServerIP:  //0x0801,//Format:String 大区IP
                case CEnum.TagName.SDO_Account:  //0x0803,//Format:String 玩家的帐号
                case CEnum.TagName.SDO_ProductName:  //0x0816,//Format:String 商品名称
                case CEnum.TagName.SDO_ItemName:  //0x0818,//Format:String 道具名称
                case CEnum.TagName.SDO_AREANAME:  //0x0827,//Format:String 大区名字
                case CEnum.TagName.SDO_NickName:  //0x0836,//呢称
                case CEnum.TagName.SDO_Address:  //0x0813,//Format:Integer 地址
                case CEnum.TagName.SDO_Desc:    // = 0x0843,//道具描述
                case CEnum.TagName.SDO_City:
                case CEnum.TagName.SDO_SendUserID: //0x0849,//Format:String 发送人帐号
                case CEnum.TagName.SDO_ReceiveNick: //0x0850,//Format:String 接受人呢称
                case CEnum.TagName.SDO_Title:
                case CEnum.TagName.SDO_Context:
                case CEnum.TagName.SDO_REASON:// = 0x0853,//Format:String 停封理由
                case CEnum.TagName.SDO_Email:
                ////////
                case CEnum.TagName.ServerInfo_IP:// = 0x0901,//Format tring 服务器IP
                case CEnum.TagName.ServerInfo_City:// = 0x0902,//Format tring 城市
                case CEnum.TagName.ServerInfo_GameName:// = 0x0904,//Format tring 游戏名
                ///////
                case CEnum.TagName.SP_Name: //0x0412,//Format:String 存储过程名
                case CEnum.TagName.Real_ACT: //0x0413,//Format:String 操作的内容
                case CEnum.TagName.MJ_Reason://0x0745,//停封理由
                case CEnum.TagName.MJ_ServerIP:
                ///
                case CEnum.TagName.UpdateFileName:// = 0x0112,//Format:String 文件名
                case CEnum.TagName.UpdateFileVersion:// = 0x0113,//Format:String 文件版本
                case CEnum.TagName.UpdateFilePath:// = 0x0114,//Format:String 文件路径
                //////////
                case CEnum.TagName.CR_ServerIP:// = 0x1101,//服务器IP
                case CEnum.TagName.CR_ACCOUNT:// = 0x1102,//玩家帐号 Format tring
                case CEnum.TagName.CR_Passord:// = 0x1103,//玩家密码 Format tring
                case CEnum.TagName.CR_NUMBER:// = 0x1104,//激活码 Format tring
                case CEnum.TagName.CR_ISUSE:// = 0x1105,//是否被使用
                case CEnum.TagName.CR_ActiveIP:// = 0x1107,//激活服务器IP Format:String
                case CEnum.TagName.CR_BoardContext:// = 0x1110,//公告内容 Format:String
                case CEnum.TagName.CR_BoardColor:// = 0x1111,//公告颜色 Format:String
                case CEnum.TagName.CR_NickName:// = 0x1132://,//呢称 Format:String
                case CEnum.TagName.CR_BoardContext1:// = 0x1135,//内容1
                case CEnum.TagName.CR_BoardContext2:// = 0x1136,//内容2
                case CEnum.TagName.CR_ChannelName:
                case CEnum.TagName.CR_UserName:// = 0x1636,//string  
                ///////
                case CEnum.TagName.AU_ACCOUNT://=0x1001://,//玩家帐号Format:String
                case CEnum.TagName.AU_UserNick://=0x1002://,//玩家呢称Format:String
                case CEnum.TagName.AU_Reason://=0x1006://,//封停理由Format:String
                case CEnum.TagName.AU_ServerIP://=0x1008://,//劲舞团游戏服务器Format:String
                case CEnum.TagName.AU_EquipState://=0x1011://,//Format:String
                case CEnum.TagName.AU_BuyNick://=0x1013://,//Format:String购买呢称
                case CEnum.TagName.AU_SendNick://=0x1019://,//Format:String赠送呢称

                case CEnum.TagName.AU_RecvNick://=0x1021://,//Format:String接受人呢称
                case CEnum.TagName.AU_Memo://=0x1029://,//Format:String备注
                case CEnum.TagName.AU_UserID://=0x1030://,//Format:String玩家ID
                case CEnum.TagName.AU_Password://=0x1040://,//Format:String密码
                case CEnum.TagName.AU_UserName://=0x1041://,//Format:String用户名
                case CEnum.TagName.AU_UserGender://=0x1042://,//Format:String
                case CEnum.TagName.AU_UserRegion://=0x1044://,//Format:String
                case CEnum.TagName.AU_UserEMail://=0x1045://,//Format:String用户电子邮件
                case CEnum.TagName.AU_ItemName:// = 0x1047,//道具名
                case CEnum.TagName.AU_ItemStyle:// = 0x1048,//道具类型
                case CEnum.TagName.AU_Demo:// = 0x1049,//描述 
                case CEnum.TagName.AU_SendUserID:// = 0x1052,//发送人帐号
                case CEnum.TagName.AU_RecvUserID:// = 0x1053,//接受人帐号 
                case CEnum.TagName.AU_Sex://=0x1003://,//玩家性别Format:Integer

                ///////
                ///////
                case CEnum.TagName.CARD_PDkey:// 0x1203
                case CEnum.TagName.CARD_PDCardType:// 0x1204　
                case CEnum.TagName.CARD_PDFrom:// 0x1205
                case CEnum.TagName.CARD_PDCardNO:// 0x1206
                case CEnum.TagName.CARD_PDCardPASS:// 0x1207
                case CEnum.TagName.CARD_PDaction:// 0x1209
                case CEnum.TagName.CARD_PDuserid:// 0x1210
                case CEnum.TagName.CARD_PDusername:// 0x1211
                case CEnum.TagName.CARD_PDgetusername:// 0x1213

                case CEnum.TagName.CARD_PDip:// 0x1215
                case CEnum.TagName.CARD_PDstatus:// 0x1216
                case CEnum.TagName.CARD_UDkey:// 0x1218 
                case CEnum.TagName.CARD_UDusedo:// 0x1219
                case CEnum.TagName.CARD_UDdirect:// 0x1220
                case CEnum.TagName.CARD_UDusername:// 0x1222 
                case CEnum.TagName.CARD_UDgetuserid:// 0x1223 //TLV_STRING
                case CEnum.TagName.CARD_UDgetusername:// 0x1224 //TLV_STRING
                case CEnum.TagName.CARD_UDtype:// 0x1226 //TLV_STRING
                case CEnum.TagName.CARD_UDtargetvalue:// 0x1227
                case CEnum.TagName.CARD_UDzone1:// 0x1228
                case CEnum.TagName.CARD_UDzone2:// 0x1229
                case CEnum.TagName.CARD_UDip:// 0x1231
                case CEnum.TagName.CARD_UDstatus:// 0x1232
                case CEnum.TagName.CARD_cardnum:// 0x1233
                case CEnum.TagName.CARD_cardpass:// 0x1234
                case CEnum.TagName.CARD_serial:// 0x1235
                case CEnum.TagName.CARD_draft:// 0x1236
                //case CEnum.TagName.CARD_type1:// 0x1237
                //case CEnum.TagName.CARD_type2:// 0x1238
                //case CEnum.TagName.CARD_type3:// 0x1239
                //case CEnum.TagName.CARD_type4:// 0x1240
                case CEnum.TagName.CARD_use_status:// 0x1243
                case CEnum.TagName.CARD_cardsent:// 0x1244
                //case CEnum.TagName.CARD_create_date:// 0x1245

                case CEnum.TagName.CARD_use_username:// 0x1247
                case CEnum.TagName.CARD_partner:// 0x1248
                case CEnum.TagName.CARD_skey:// 0x1249
                ////////
                case CEnum.TagName.CARD_id:// 0x1251 ,//TLV_STRING 久之游注册卡号
                case CEnum.TagName.CARD_username:// 0x1252,//TLV_STRING 久之游注册用户名
                case CEnum.TagName.CARD_nickname:// 0x1253,//TLV_STRING 久之游注册呢称
                case CEnum.TagName.CARD_password:// 0x1254,//TLV_STRING 久之游注册密码
                case CEnum.TagName.CARD_sex:// 0x1255,//TLV_STRING 久之游注册性别
                case CEnum.TagName.CARD_securecode:// 0x1258,//TLV_STRING 安全码
                case CEnum.TagName.CARD_vis:// 0x1259,//TLV_INTEGER
                case CEnum.TagName.CARD_realname:// 0x1263,//TLV_STRING 真实姓名
                case CEnum.TagName.CARD_cardtype:// 0x1265,//TLV_STRING
                case CEnum.TagName.CARD_email:// 0x1267,//TLV_STRING 邮件
                case CEnum.TagName.CARD_occupation:// 0x1268,//TLV_STRING 职业
                case CEnum.TagName.CARD_education:// 0x1269,//TLV_STRING 教育程度
                case CEnum.TagName.CARD_marriage:// 0x1270,//TLV_STRING 婚否
                case CEnum.TagName.CARD_constellation:// 0x1271,//TLV_STRING 星座
                case CEnum.TagName.CARD_shx:// 0x1272,//TLV_STRING 生肖
                case CEnum.TagName.CARD_city:// 0x1273,//TLV_STRING 城市
                case CEnum.TagName.CARD_address:// 0x1274,//TLV_STRING 联系地址
                case CEnum.TagName.CARD_phone:// 0x1275,//TLV_STRING 联系电话
                case CEnum.TagName.CARD_qq:// 0x1276,//TLV_STRING QQ
                case CEnum.TagName.CARD_intro:// 0x1277,//TLV_STRING 介绍
                case CEnum.TagName.CARD_msn:// 0x1278,//TLV_STRING MSN
                case CEnum.TagName.CARD_mobilephone:// 0x1279,//TLV_STRING 移动电话
                case CEnum.TagName.CARD_BalancePrice:// 0x1283,//当前用户休闲币余额
                ///
                case CEnum.TagName.AuShop_bkey://=0x1303,//varchar(40)
                case CEnum.TagName.AuShop_pkey://=0x1304,//varchar(18)

                case CEnum.TagName.AuShop_username://=0x1306,//varchar(20)

                case CEnum.TagName.AuShop_getusername://=0x1308,//varchar(20)

                case CEnum.TagName.AuShop_pisgift://=0x1310,//enum('y','n')
                case CEnum.TagName.AuShop_islover://=0x1311,//enum('y','n')
                case CEnum.TagName.AuShop_ispresent://=0x1312,//enum('y','n')
                case CEnum.TagName.AuShop_isbuysong://=0x1313,//enum('y','n')
                case CEnum.TagName.AuShop_psex://=0x1315,//enum('all','m','f')

                case CEnum.TagName.AuShop_zone://=0x1322,//tinyint(2)
                case CEnum.TagName.AuShop_buyip://=0x1321,//varchar(15)
                case CEnum.TagName.AuShop_pname://=0x1326,//varchar(20)
                case CEnum.TagName.AuShop_pgift://=0x1328,//enum('y','n')
                case CEnum.TagName.AuShop_pgamecode://=0x1331,//varchar(200)
                case CEnum.TagName.AuShop_pnew://=0x1332,//enum('y','n')
                case CEnum.TagName.AuShop_phot://=0x1333,//enum('y','n')
                case CEnum.TagName.AuShop_pcheap://=0x1334,//enum('y','n')
                case CEnum.TagName.AuShop_pautoprice://=0x1339,//enum('y','n')
                case CEnum.TagName.AuShop_ptimeitem://=0x1344,//varchar(200)
                case CEnum.TagName.AuShop_pricedetail://=0x1345,//varchar(254)
                case CEnum.TagName.AuShop_pdesc://=0x1347,//text
                case CEnum.TagName.AuShop_pmark1://=0x1350,//enum('y','n')
                case CEnum.TagName.AuShop_pmark2://=0x1351,//enum('y','n')
                case CEnum.TagName.AuShop_pmark3://=0x1352,//enum('y','n')
                case CEnum.TagName.AuShop_pisuse://=0x1355,//enum('y','n')
                case CEnum.TagName.AuShop_ppic://=0x1356,//varchar(36)
                case CEnum.TagName.AuShop_ppic1://=0x1357,//varchar(36)
                case CEnum.TagName.CARD_price:// 0x1241
                //////
                case CEnum.TagName.o2jam_ServerIP://=0x1401,//Format:TLV_STRINGIP
                case CEnum.TagName.o2jam_UserID://=0x1402,//Format:TLV_STRING用户帐号
                case CEnum.TagName.o2jam_UserNick://=0x1403,//Format:TLV_STRING用户呢称







                case CEnum.TagName.o2jam_USER_ID://=0x1457,//varchar
                case CEnum.TagName.o2jam_USER_NICKNAME://=0x1458,//varchar

                case CEnum.TagName.o2jam_SenderID://=0x1409,//varchar

                case CEnum.TagName.o2jam_SenderNickName://=0x1411,//varchar
                case CEnum.TagName.o2jam_ReceiverID://=0x1412,//varchar

                case CEnum.TagName.o2jam_ReceiverNickName://=0x1414,//varchar
                case CEnum.TagName.o2jam_Title://=0x1415,//varchar
                case CEnum.TagName.o2jam_Content://=0x1416,//varchar

                case CEnum.TagName.o2jam_ReadFlag://=0x1419,//char
                case CEnum.TagName.o2jam_TypeFlag://=0x1420,//char
                case CEnum.TagName.o2jam_KIND_CASH://=0x1435,//char
                case CEnum.TagName.o2jam_NAME://=0x1437,//varchar
                case CEnum.TagName.o2jam_DESCRIBE://=0x1450,//varchar

                case CEnum.TagName.o2jam_ITEM_NAME://=0x1453,//varchar

                case CEnum.TagName.AuShop_buytime://=0x1319,//int(10)

                case CEnum.TagName.Process_Reason:// = 0x060B,//Format tring

                case CEnum.TagName.O2JAM2_ServerIP:// = 0x1601,//TLV_STRING
                case CEnum.TagName.O2JAM2_UserID:// = 0x1602,//TLV_STRING
                case CEnum.TagName.O2JAM2_UserName:// = 0x1603,//TLV_STRING
                case CEnum.TagName.O2JAM2_Id1:// = 0x1604,//TLV_Integer
                case CEnum.TagName.O2JAM2_Id2:// = 0x1605,//TLV_Integer
                case CEnum.TagName.o2jam2_consumetype:// = 0x1631

                ///////
                case CEnum.TagName.SDO_MusicName1:// = 0x0870,
                case CEnum.TagName.SDO_MusicName2:// = 0x0873,
                case CEnum.TagName.SDO_MusicName3:// = 0x0876,
                case CEnum.TagName.SDO_MusicName4:// = 0x0879,
                case CEnum.TagName.SDO_MusicName5:// = 0x0882,

                case CEnum.TagName.SDO_Sence://= 0x0868,
                case CEnum.TagName.SDO_KeyID:// = 0x0885,
                case CEnum.TagName.SDO_KeyWord:// = 0x0886,
                case CEnum.TagName.SDO_MasterID:// = 0x0887,
                case CEnum.TagName.SDO_Master:// = 0x0888,
                case CEnum.TagName.SDO_SlaverID:// = 0x0889,
                case CEnum.TagName.SDO_Slaver:// = 0x0890,


                case CEnum.TagName.O2JAM2_UserNick://= 0x1610,//Format:TLV_STRING 用户呢称
                case CEnum.TagName.O2JAM2_ItemName://= 0x1621,//Format:TLV_String
                case CEnum.TagName.O2JAM2_Title://= 0x1629,
                case CEnum.TagName.O2JAM2_Context://= 0x1630,
                case CEnum.TagName.O2JAM2_REASON:// = 0x1636,//string
                case CEnum.TagName.SDO_ChannelList:
                case CEnum.TagName.SDO_BoardMessage:
                case CEnum.TagName.SDO_ipaddr:// = 0x0897,
                case CEnum.TagName.SDO_Punish_Status:
                case CEnum.TagName.Soccer_charname: //角色名

                case CEnum.TagName.Soccer_Type: //查询类型
                case CEnum.TagName.Soccer_String: //查询值 
                case CEnum.TagName.Soccer_deleted_date://删除日期
                case CEnum.TagName.Soccer_status://状态
                case CEnum.TagName.Soccer_ServerIP:
                case CEnum.TagName.Soccer_loginId: //Login ID
                case CEnum.TagName.Soccer_charsex:// 
                case CEnum.TagName.Soccer_admid:
                case CEnum.TagName.Soccer_regDate://玩家注册日期 string 
                case CEnum.TagName.Soccer_c_date://角色创建日期 string 
                case CEnum.TagName.Soccer_kind:
                case CEnum.TagName.Soccer_SenderUserName://string 道具赠送人
                case CEnum.TagName.Soccer_ReceiveUserName://string 道具接受人
                case CEnum.TagName.Soccer_i_name://string 道具名称
                case CEnum.TagName.Soccer_body_part://string 身体部分
                case CEnum.TagName.CARD_PDCardPrice:// 0x1208
                case CEnum.TagName.Bug_Subject:// = 0x0118,//Format:String bug 标题
                case CEnum.TagName.Bug_Type:// = 0x0119,//Format:String 类型
                case CEnum.TagName.Bug_Context:// = 0x0120,//Format:String 内容
                case CEnum.TagName.Bug_Result:// = 0x0124,//Format:String 
                case CEnum.TagName.Update_Module:// = 0x0126,//Format:String
                case CEnum.TagName.Update_Context:// = 0x0127,//Format:String
                case CEnum.TagName.Soccer_Ban_Reason:
                case CEnum.TagName.SDO_Passwd:
                case CEnum.TagName.TOKEN_username: //TLV_STRING 密宝用户名
                case CEnum.TagName.TOKEN_esn://TLV_STRING 密宝ESN
                case CEnum.TagName.TOKEN_dpsw://TLV_STRING 密宝动态密码
                case CEnum.TagName.TOKEN_spsw: //TLV_STRING 密宝固定密码
                case CEnum.TagName.TOKEN_authType: //TLV_STRING 密宝验证类型
                case CEnum.TagName.TOKEN_provide: //TLV_STRING 密宝服务提供商
                case CEnum.TagName.TOKEN_service: //TLV_STRING 密宝请求服务名称
                case CEnum.TagName.TOKEN_certificate: //TLV_STRING 密宝信任验证
                case CEnum.TagName.TOKEN_code: //TLV_STRING 密宝响应状态码
                case CEnum.TagName.TOKEN_description: //TLV_STRING 密宝响应描述 
                case CEnum.TagName.SDO_FirstPadTime://舞毯第一次使用时间
                case CEnum.TagName.SDO_BanDate: //停封多少天
                case CEnum.TagName.AU_UserTitle://称号 
                case CEnum.TagName.SDO_CoupleNickName:// = 0x08113,
                case CEnum.TagName.SDO_OnlineTime:
                case CEnum.TagName.CARD_Douser:// = 0x1295,//操作人
                case CEnum.TagName.CARD_Wantdouser:// = 0x1296,//提交申请人
                case CEnum.TagName.CARD_Salename:
                case CEnum.TagName.CARD_Lockinfo:
                case CEnum.TagName.CARD_Locktype:
                case CEnum.TagName.TOKEN_Type:
                case CEnum.TagName.CARD_UserID:// = 0x1294,
                case CEnum.TagName.TOKEN_Operater:// = 0x1200,
                case CEnum.TagName.TOKEN_STATE://=  0x1201,
                case CEnum.TagName.SDO_Padstatus:
                case CEnum.TagName.SDO_Area:
                case CEnum.TagName.AU_City:
                case CEnum.TagName.SDO_expcash:
                case CEnum.TagName.SDO_usecash: 
                case CEnum.TagName. CARD_Username:
                case CEnum.TagName. CARD_Getusername:
           
                case CEnum.TagName.CARD_Zone:
                case CEnum.TagName.CARD_Buyip:
                case CEnum.TagName.TOEKN_BindDate:
                case CEnum.TagName.CARD_SecQA:
                case CEnum.TagName.CARD_SecEmail:
                case CEnum.TagName.CARD_securecode1:
                case CEnum.TagName.SDO_PunishTimes:
                case CEnum.TagName.SDO_DelTimes:
                case CEnum.TagName.CARD_is_Use:
                case CEnum.TagName.LINKER_NAME:
                case CEnum.TagName.LINKER_CONTENT:
                case CEnum.TagName.NOTES_UID:
                case CEnum.TagName.NOTES_SUBJECT:
                case CEnum.TagName.NOTES_FROM:
              
                case CEnum.TagName.NOTES_SUPERVISORS:
                case CEnum.TagName.NOTES_CONTENT:
                case CEnum.TagName.NOTES_SCRETVISORS:
                case CEnum.TagName.NOTES_RECEIVER:
                case CEnum.TagName.NOTES_Sender:
                case CEnum.TagName.Notes_AttachmentName:

                case CEnum.TagName.AU_Postion:
                case CEnum.TagName.AU_hair:
                case CEnum.TagName.AU_face:
                case CEnum.TagName.AU_sets1:
                case CEnum.TagName.AU_sets2:
                case CEnum.TagName.AU_pet:
                case CEnum.TagName.AU_jacket:
                case CEnum.TagName.AU_pants:
                case CEnum.TagName.AU_shoes:
                case CEnum.TagName.NOTES_Category:

                case CEnum.TagName.CARD_GetTime:
                case CEnum.TagName.CARD_uplog_date:
                case CEnum.TagName.CARD_CRTIME:
                case CEnum.TagName.CARD_RemainDate:
                case CEnum.TagName.CARD_ItemID:
                case CEnum.TagName.CARD_GetItemTime:
                case CEnum.TagName.CARD_Area:
                case CEnum.TagName.FJ_UserID:
                case CEnum.TagName.FJ_UserNick:
                case CEnum.TagName.FJ_Occupation:
                case CEnum.TagName.FJ_ItemName:
                case CEnum.TagName.FJ_ServerIP:
                case CEnum.TagName.FJ_Map:

                case CEnum.TagName.AU_PcIP:
                case CEnum.TagName.CARD_REG://TLV_STRING 请求类型(取用户数据)getMyData
                case CEnum.TagName.CARD_TYPE:
                case CEnum.TagName.CARD_REGIP://TLV_STRING 
                case CEnum.TagName.CARD_REGS://TLV_STRING 32位验证码

                case CEnum.TagName.CARD_VALUE://TLV_STRING
                case CEnum.TagName.FJ_UseActiveCode:
                case CEnum.TagName.FJ_UseAccount:
                case CEnum.TagName.FJ_GoldAccount:
                case CEnum.TagName.FJ_isUse:
                case CEnum.TagName.FJ_isActive:
                case CEnum.TagName.TOKEN_ACTIVEDATE:
                case CEnum.TagName.FJ_Skill:
                case CEnum.TagName.FJ_RelateCHarName:
                case CEnum.TagName.FJ_Reason:
                case CEnum.TagName.FJ_Message:
                case CEnum.TagName.FJ_GuildName:
                case CEnum.TagName.FJ_Pwd:
                case CEnum.TagName.FJ_XPosition:
                case CEnum.TagName.FJ_YPosition:
                case CEnum.TagName.FJ_icurrank:
                case CEnum.TagName.FJ_Quest_id:
                case CEnum.TagName.FJ_Quest_state:
                case CEnum.TagName.FJ_Content:
                case CEnum.TagName.FJ_LoginIP:
                case CEnum.TagName.FJ_GSName://Format TRING gs 服务器
                case CEnum.TagName.FJ_MsgContent://Format TRING 公告内容
                case CEnum.TagName.FJ_StartTime:
                case CEnum.TagName.FJ_EndTime:
                case CEnum.TagName.FJ_Style:
                case CEnum.TagName.RC_isPlatinum:
                case CEnum.TagName.RC_isUse:
                case CEnum.TagName.RC_ServerIP:
                case CEnum.TagName.RC_Account:
                case CEnum.TagName.RC_CharName:
                case CEnum.TagName.RC_Rank:
                case CEnum.TagName.RC_LoginIP:
                case CEnum.TagName.AuShop_SENDUSER://购买人
                case CEnum.TagName.AuShop_RECVUSER://获赠人
                
                case CEnum.TagName.AuShop_ITEMTYPE://道具类型
                case CEnum.TagName.AuShop_PCODE://道具代码
                case CEnum.TagName.AuShop_SendNick:
                case CEnum.TagName.AuShop_ReceiverNick:
                case CEnum.TagName.AuShop_ItemTable:
                case CEnum.TagName.RC_ActiveCode:
                case CEnum.TagName.RC_UseDate:
                case CEnum.TagName.AuShop_PERIOD://道具时限
                case CEnum.TagName.FJ_StyleDesc://道具分类的说明 s
                case CEnum.TagName.FJ_Color://s
                case CEnum.TagName.FJ_Embed_GuID: 
                case CEnum.TagName.FJ_Item_GuID:
                case CEnum.TagName.FJ_AppendItem_GuID:
                case CEnum.TagName.FJ_Title:
                case CEnum.TagName.FJ_Min:
                case CEnum.TagName.FJ_Inst_Desc://s
                case CEnum.TagName.FJ_GType:
                case CEnum.TagName.FJ_FStr:
                case CEnum.TagName.FJ_FDex:
                case CEnum.TagName.FJ_FCon:
                case CEnum.TagName.FJ_FInt:
                case CEnum.TagName.FJ_FWit:
                case CEnum.TagName.FJ_FSpi:
                case CEnum.TagName.FJ_FSpeed:
                case CEnum.TagName.FJ_FSwordMaster:
                case CEnum.TagName.FJ_FBluntMaster:
                case CEnum.TagName.FJ_FDaggerMaster:
                case CEnum.TagName.FJ_FLanceMaster:
                case CEnum.TagName.FJ_FMagWeaponMaster:
                case CEnum.TagName.FJ_FBowMovingShoot:
                case CEnum.TagName.FJ_FBowAttackDist:
                case CEnum.TagName.FJ_FBowMaster:
                case CEnum.TagName.FJ_FLightArmorMaster:
                case CEnum.TagName.FJ_FHeavyArmorMaster:
                case CEnum.TagName.FJ_FMagArmorMaster:
                case CEnum.TagName.FJ_FShieldMaster:
                case CEnum.TagName.FJ_FDualMaster:
                case CEnum.TagName.FJ_FHPMax:
                case CEnum.TagName.FJ_FHPReg:
                case CEnum.TagName.FJ_FMPMax:
                case CEnum.TagName.FJ_FMPReg:
                case CEnum.TagName.FJ_FPhyAttack:
                case CEnum.TagName.FJ_FPhyDefend:
                case CEnum.TagName.FJ_FPhyHit:
                case CEnum.TagName.FJ_FPhyAvoid:
                case CEnum.TagName.FJ_FPhyAttackSpeed: 
                case CEnum.TagName.FJ_FPhyCritical: 
                case CEnum.TagName.FJ_FPhyCriticalPower: 
                case CEnum.TagName.FJ_FPhyHPAbsorb: 
                case CEnum.TagName.FJ_FPhyMPAbsorb:
                case CEnum.TagName.FJ_FPhyAttackDist:
                case CEnum.TagName.FJ_FMagAttack:
                case CEnum.TagName.FJ_FMagDefend:
                case CEnum.TagName.FJ_FMagCritical:
                case CEnum.TagName.FJ_FMagCriticalPower:
                case CEnum.TagName.FJ_FMagIntent :
                case CEnum.TagName.FJ_FMagSpeed :
                case CEnum.TagName.FJ_FHealPower:
                case CEnum.TagName.FJ_FHealEff: 
                case CEnum.TagName.FJ_FThorn :
                case CEnum.TagName.FJ_FCDScale:
                case CEnum.TagName.FJ_FASI_0:
                case CEnum.TagName.FJ_FASI_1:
                case CEnum.TagName.FJ_FASI_2:
                case CEnum.TagName.FJ_FASI_3:
                case CEnum.TagName.FJ_FASI_4:
                case CEnum.TagName.FJ_FASI_5:
                case CEnum.TagName.FJ_FASI_6:
                case CEnum.TagName.FJ_FASI_7:
                case CEnum.TagName.FJ_FASI_8:
                case CEnum.TagName.FJ_FASI_9:
                case CEnum.TagName.FJ_FManaShield:
                case CEnum.TagName.FJ_FJumpMaster:
                case CEnum.TagName.FJ_FExpScale:
                case CEnum.TagName.FJ_FSPScale:
                case CEnum.TagName.FJ_FDamage2MP:
                case CEnum.TagName.FJ_FPhyDefScale:
                case CEnum.TagName.FJ_FMagDefScale :
                case CEnum.TagName.FJ_FMagIceAttack:
                case CEnum.TagName.FJ_FMagFireAttack:
                case CEnum.TagName.FJ_FMagThunderAttack:
                case CEnum.TagName.FJ_FMagPoisonAttack:
                case CEnum.TagName.FJ_FMagIceDefend:
                case CEnum.TagName.FJ_FMagFireDefend:
                case CEnum.TagName.FJ_FMagThunderDefend:
                case CEnum.TagName.FJ_FMagPoisonDefend:
                case CEnum.TagName.FJ_FCBRate:
                case CEnum.TagName.FJ_FCBPer:
                case CEnum.TagName.FJ_ItemMark:
                case CEnum.TagName.CARD_Coins:
                case CEnum.TagName.CARD_Awardcoin:
                case CEnum.TagName.AU_RecvDate://=0x1028://,//Format:TimeStamp接受日期
                case CEnum.TagName.AuShop_sTime:
                case CEnum.TagName.FJ_ZPosition:
                case CEnum.TagName.AU_BoardMessage:
                case CEnum.TagName.AU_ChannelList:
               
                case CEnum.TagName.AU_GSName:
                case CEnum.TagName.AU_GSServerIP:
                
                case CEnum.TagName.FJ_SlotMax:
                case CEnum.TagName.SDO_MarriageApp_Date:// = 0x08116,
                case CEnum.TagName.SDO_DivorceApp_Date:// = 0x08117,
                case CEnum.TagName.SDO_Marriage_Date:// = 0x08118,
                case CEnum.TagName.SDO_Divorce_Date:// = 0x08119,
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = tTlv.toString();

                    break;
                case CEnum.TagName.SDO_UserIndexID:  //0x0802,//Format:Integer 玩家用户ID
                case CEnum.TagName.SDO_Level:  //0x0804,//Format:Integer 玩家的等级
                case CEnum.TagName.SDO_Exp:  //0x0805,//Format:Integer 玩家的当前经验值
                case CEnum.TagName.SDO_GameTotal:  //0x0806,//Format:Integer 总局数
                case CEnum.TagName.SDO_GameWin:  //0x0807,//Format:Integer 胜局数
                case CEnum.TagName.SDO_DogFall:  //0x0808,//Format:Integer 平局数
                case CEnum.TagName.SDO_GameFall:  //0x0809,//Format:Integer 负局数
                case CEnum.TagName.SDO_Reputation:  //0x0810,//Format:Integer 声望值
                case CEnum.TagName.SDO_Status:
                case CEnum.TagName.SDO_Age:  //0x0814,//Format:Integer 年龄
                case CEnum.TagName.SDO_ProductID:  //0x0815,//Format:Integer 商品编号
                case CEnum.TagName.SDO_ItemCode:  //0x0817,//Format:Integer 道具编号
                case CEnum.TagName.SDO_MoneyType:  //0x0819,//Format:Integer 货币类型
                case CEnum.TagName.SDO_MoneyCost:  //0x0820,//Format:Integer 道具的价格
                case CEnum.TagName.SDO_MAINCH:  //0x0822,//Format:Integer 服务器
                case CEnum.TagName.SDO_SUBCH:  //0x0823,//Format:Integer 房间
                case CEnum.TagName.SDO_Online:  //0x0824,//Format:Integer 是否在线
                case CEnum.TagName.SDO_ActiveStatus:
                case CEnum.TagName.SDO_SEX:  //0x0838,//性别
                case CEnum.TagName.SDO_Ispad:  //0x0842,//是否已注册跳舞毯
                case CEnum.TagName.SDO_Postion:// = 0x0844,//道具位置
                case CEnum.TagName.SDO_MinLevel:
                case CEnum.TagName.SDO_TimesLimit:
                case CEnum.TagName.SDO_SendIndexID: //0x0848,//Format:Integer 发送人的ID
                case CEnum.TagName.SDO_BigType: //0x0851,//Format:Integer 道具大类
                case CEnum.TagName.SDO_SmallType: // 0x0852,//Format:Integer 道具小类
                case CEnum.TagName.SDO_StopStatus:
                case CEnum.TagName.SDO_DaysLimit:// = 0x0855,//Format:Integer 使用天数
                case CEnum.TagName.SDO_ChargeSum:
                case CEnum.TagName.SDO_Interval:
                case CEnum.TagName.SDO_TaskID:
                

                ///
                case CEnum.TagName.ServerInfo_GameID:// = 0x0903,//Format:Integer 游戏ID
                case CEnum.TagName.ServerInfo_GameDBID:// = 0x0905,//Format:Integer 游戏数据库类型
                case CEnum.TagName.ServerInfo_GameFlag:// = 0x0906,//Format:Integer 游戏服务器状态
                case CEnum.TagName.ServerInfo_Idx:// = 0x0907,//format:Integer
                ///
                case CEnum.TagName.OnlineActive:
                /////

                case CEnum.TagName.CR_STATUS:// = 0x1106,//玩家状态 Format:Integer
                case CEnum.TagName.CR_BoardID:// = 0x1109,//公告ID Format:Integer
                case CEnum.TagName.CR_Valid:// = 0x1114,//是否有效 Format:Integer
                case CEnum.TagName.CR_PublishID:// = 0x1115,//发布人ID Format:Integer
                case CEnum.TagName.CR_DayLoop:// = 0x1116,//每天播放 Format:Integer
                case CEnum.TagName.CR_Mode://= 0x1130,//播放方式 Format:Integer
                case CEnum.TagName.CR_ACTION:// = 0x1131,//查询动作　Format:Integer
                case CEnum.TagName.CR_UserID:// = 0x1134,//用户ID
                case CEnum.TagName.CR_Last_Playing_Time:
                case CEnum.TagName.CR_Total_Time:
                ///

                case CEnum.TagName.AU_State://=0x1004://,//玩家状态Format:Integer
                case CEnum.TagName.AU_STOPSTATUS://=0x1005://,//劲舞者封停状态Format:Integer
                case CEnum.TagName.AU_Id9you://=0x1009://,//Format:Integer9youID
                case CEnum.TagName.AU_UserSN://=0x1010://,//Format:Integer用户序列号
                case CEnum.TagName.AU_AvatarItem://=0x1012://,//Format:Integer
                case CEnum.TagName.AU_BuyType://=0x1016://,//Format:Integer购买类型
                case CEnum.TagName.AU_PresentID://=0x1017://,//Format:Integer赠送ID
                case CEnum.TagName.AU_SendSN://=0x1018://,//Format:Integer赠送SN
                case CEnum.TagName.AU_RecvSN://=0x1020://,//Format:String接受人SN
                case CEnum.TagName.AU_Kind://=0x1022://,//Format:Integer类型
                case CEnum.TagName.AU_ItemID://=0x1023://,//Format:Integer道具ID
                case CEnum.TagName.AU_Period://=0x1024://,//Format:Integer期间
                case CEnum.TagName.AU_BeforeCash://=0x1025://,//Format:Integer消费之前金额
                case CEnum.TagName.AU_AfterCash://=0x1026://,//Format:Integer消费之后金额
                case CEnum.TagName.AU_Exp://=0x1031://,//Format:Integer玩家经验
                case CEnum.TagName.AU_Point://=0x1032://,//Format:Integer玩家位置
                case CEnum.TagName.AU_Money://=0x1033://,//Format:Integer金钱
                case CEnum.TagName.AU_Cash://=0x1034://,//Format:Integer现金
                case CEnum.TagName.AU_Level://=0x1035://,//Format:Integer等级
                case CEnum.TagName.AU_Ranking://=0x1036://,//Format:Integer银行
                case CEnum.TagName.AU_IsAllowMsg://=0x1037://,//Format:Integer允许发消息
                case CEnum.TagName.AU_IsAllowInvite://=0x1038://,//Format:Integer允许邀请
                case CEnum.TagName.AU_UserPower://=0x1043://,//Format:Integer
                case CEnum.TagName.AU_SexIndex:// = 0x1054,//性别
                ///
                case CEnum.TagName.CARD_PDID:// 0x1202
                case CEnum.TagName.CARD_PDgetuserid:// 0x1212
                case CEnum.TagName.CARD_UDID:// 0x1217 //TLV_INTEGER
                case CEnum.TagName.CARD_UDuserid:// 0x1221 //TLV_INTEGER
                case CEnum.TagName.CARD_UDcoins:// 0x1225 //TLV_INTEGER
                case CEnum.TagName.CARD_ActionType://int
                ///
                case CEnum.TagName.AuShop_orderid://=0x1301,//int(11)
                case CEnum.TagName.AuShop_udmark://=0x1302,//int(8)
                case CEnum.TagName.AuShop_userid://=0x1305,//int(11)
                case CEnum.TagName.AuShop_getuserid://=0x1307,//int(11)
                case CEnum.TagName.AuShop_pcategory://=0x1309,//smallint(4)
                case CEnum.TagName.AuShop_prule://=0x1314,//tinyint(1)
                case CEnum.TagName.AuShop_pbuytimes://=0x1316,//int(11)
                case CEnum.TagName.AuShop_allprice://=0x1317,//int(11)
                case CEnum.TagName.AuShop_allaup://=0x1318,//int(11)

                case CEnum.TagName.AuShop_status://=0x1323,//tinyint(1)
                case CEnum.TagName.AuShop_pid://=0x1324,//int(11)
                case CEnum.TagName.AuShop_pscash://=0x1330,//tinyint(2)
                case CEnum.TagName.AuShop_pchstarttime://=0x1335,//int(10)
                case CEnum.TagName.AuShop_pchstoptime://=0x1336,//int(10)
                case CEnum.TagName.AuShop_pstorage://=0x1337,//smallint(5)
                case CEnum.TagName.AuShop_price://=0x1340,//int(8)
                case CEnum.TagName.AuShop_chprice://=0x1341,//int(8)
                case CEnum.TagName.AuShop_aup://=0x1342,//int(8)
                case CEnum.TagName.AuShop_chaup://=0x1343,//int(8)
                case CEnum.TagName.AuShop_pbuys://=0x1348,//int(8)
                case CEnum.TagName.AuShop_pfocus://=0x1349,//tinyint(1)
                case CEnum.TagName.AuShop_pdate://=0x1354,//int(10)

                case CEnum.TagName.AuShop_usefeesum://=0x1358,//int
                case CEnum.TagName.AuShop_useaupsum://=0x1359,//int
                case CEnum.TagName.AuShop_buyitemsum://=0x1360,//int

                case CEnum.TagName.o2jam_Level://=0x1405,//Format:TLV_STRING等级

                case CEnum.TagName.o2jam_Sex://=0x1404,//Format:TLV_INTEGER性别

                case CEnum.TagName.o2jam_Win://=0x1406,//Format:TLV_STRING胜
                case CEnum.TagName.o2jam_Draw://=0x1407,//Format:TLV_STRING平
                case CEnum.TagName.o2jam_Lose://=0x1408,//Format:TLV_STRING负
                case CEnum.TagName.o2jam_SEX://=0x1459,//char
                case CEnum.TagName.o2jam_WriteDate://=0x1417,//datetime
                case CEnum.TagName.O2JAM2_ComsumeCode:// = 0x1632,
                case CEnum.TagName.O2JAM2_Timeslimt://= 0x1622,
                case CEnum.TagName.Soccer_m_id://玩家序列号 int
                case CEnum.TagName.Soccer_m_auth://玩家是否被停封 int
                case CEnum.TagName.Soccer_char_max:
                case CEnum.TagName.Soccer_char_cnt:
                case CEnum.TagName.Soccer_ret:
                case CEnum.TagName.Soccer_item_type://int 道具类型
                case CEnum.TagName.Soccer_item_equip://int 道具是否装备
                case CEnum.TagName.Bug_Sender:// = 0x0122,//Format:Integer
                case CEnum.TagName.Bug_Process:// = 0x0123,//Format:Integer
                case CEnum.TagName.Update_ID:// = 0x0125,//Format:Integer
                case CEnum.TagName.SDO_LevPercent:
                case CEnum.TagName.SDO_fragment_num:
                case CEnum.TagName.SDO_fragment_id:
                case CEnum.TagName.SDO_BuyTimes:// = 0x08111,
                case CEnum.TagName.SDO_CoupleIndexID://= 0x08112,
                case CEnum.TagName.SDO_RingLevel:// = 0x08114,
                case CEnum.TagName.SDO_NewRingLevel:// = 0x08115,
                case CEnum.TagName.NOTES_Flag:// 0x1241
                case CEnum.TagName.AU_UserItem:
                case CEnum.TagName.AU_RemainCount:
           
                case CEnum.TagName.FJ_Sex: //TLV_INTEGER
                case CEnum.TagName.FJ_Level:  //TLV_INTEGER
                
	    
                case CEnum.TagName.FJ_TotalSP://TLV_INTEGER
                case CEnum.TagName.FJ_ItemCode: //TLV_INTEGER
                case CEnum.TagName.FJ_isDel: //TLV_STRING
                case CEnum.TagName.FJ_Position:  //TLV_INTEGER
                case CEnum.TagName.FJ_GCash: //TLV_INTEGER
                case CEnum.TagName.FJ_MCash: //TLV_INTEGER
                //case CEnum.TagName.FJ_ServerIP: //TLV_STRING
                case CEnum.TagName.FJ_MinLevel: //TLV_INTEGER
                case CEnum.TagName.FJ_ItemLimit: //TLV_INTEGER
                case CEnum.TagName.FJ_ItemCount://TLV_INTEGER
                case CEnum.TagName.FJ_isBind://TLV_INTEGER
                case CEnum.TagName.FJ_UserIndexID://TLV_INTEGER
                case CEnum.TagName.FJ_RemainCredit:
                case CEnum.TagName.FJ_Max:
                case CEnum.TagName.FJ_GuidID:
                case CEnum.TagName.FJ_SkillID:
                case CEnum.TagName.FJ_Relate:
                case CEnum.TagName.FJ_ihonor:
                case CEnum.TagName.FJ_Type://Format:INT 关系类型            
                case CEnum.TagName.FJ_BoardFlag://Format:INT 状态
                case CEnum.TagName.FJ_Interval://Format:INT 发送间隔
                case CEnum.TagName.FJ_MsgID:
                case CEnum.TagName.FJ_Occupation_id:
                case CEnum.TagName.FJ_TotalExp:
                case CEnum.TagName.FJ_IsOnline:
                case CEnum.TagName.RC_Sex:
                case CEnum.TagName.RC_Vehicle:
                case CEnum.TagName.RC_Level:
                case CEnum.TagName.RC_MatchNum:
                case CEnum.TagName.RC_9YOUPointer:
                case CEnum.TagName.RC_IGroup:
                case CEnum.TagName.RC_Money:
                case CEnum.TagName.RC_PlayCounter:
                case CEnum.TagName.RC_UserIndexID:
                case CEnum.TagName.AuShop_UseCount:
                case CEnum.TagName.AuShop_ReceiveSN:
                case CEnum.TagName.AuShop_PresentID:
                case CEnum.TagName.AuShop_SendSN:
                case CEnum.TagName.FJ_color_level:
                case CEnum.TagName.FJ_SlotItemNum:
                case CEnum.TagName.FJ_SlotStoneNum:
                case CEnum.TagName.AuShop_ExpireType:
                case CEnum.TagName.FJ_StockMax:
                case CEnum.TagName.AU_GSPort:
                case CEnum.TagName.AU_TaskID:
                case CEnum.TagName.SDO_PCash:
                ///
                tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_INTEGER;
                tBody[iRow, iField].oContent = tTlv.toInteger();
                break;
                case CEnum.TagName.MJ_Time: // = 0x0741,//Format:TimeStamp  操作时间
                case CEnum.TagName.AuShop_sDate:

                tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_DATE;
                tBody[iRow, iField].oContent = tTlv.toDate();
                break;
                
                case CEnum.TagName.SDO_DateLimit:
                case CEnum.TagName.SDO_LoginTime:  //0x0825,//Format:DateTime 上线时间
                case CEnum.TagName.SDO_LogoutTime:  //0x0826,//Format:DateTime 下线时间
                case CEnum.TagName.SDO_ShopTime:  //0x0821,//Format:DateTime 消费时间
                case CEnum.TagName.SDO_StopTime:// = 0x0854,//Format:TimeStamp 停封时间
                ///////
                case CEnum.TagName.ACT_Time: //0x0414,//Format:TimeStamp 操作时间
                ///
                case CEnum.TagName.CR_ActiveDate:// = 0x1108,//激活日期 Format:TimeStamp        
                case CEnum.TagName.CR_ValidTime:// = 0x1112,//生效时间 Format:TimeStamp
                case CEnum.TagName.CR_InValidTime:// = 0x1113,//失效时间 Format:TimeStamp
                ///
                case CEnum.TagName.AU_BanDate://=0x1007://,//封停日期Format:TimeStamp
                case CEnum.TagName.AU_BuyDate://=0x1014://,//Format:Timestamp购买日期
                case CEnum.TagName.AU_ExpireDate://=0x1015://,//Format:TimesStamp过期日期
                case CEnum.TagName.AU_SendDate://=0x1027://,//Format:TimeStamp发送日期
                
                case CEnum.TagName.AU_LastLoginTime://=0x1039://,//Format:TimeStamp最后登录时间
                case CEnum.TagName.AU_RegistedTime://=0x1046://,//Format:TimeStamp注册时间
                case CEnum.TagName.AuShop_buytime2://=0x1320,//datetime
                ///
                case CEnum.TagName.CARD_UDdate:// 0x1230 timestamp
                case CEnum.TagName.AuShop_pinttime://=0x1353,//int(10)
                case CEnum.TagName.o2jam_ReadDate://=0x1418,//datetime
                case CEnum.TagName.o2jam_Ban_Date://=0x1421,//datetime
                case CEnum.TagName.o2jam_REG_DATE://=0x1430,//datetime
                case CEnum.TagName.o2jam_CREATE_TIME://=0x1460,//datetime
                case CEnum.TagName.o2jam_UPDATE_TIME://=0x1451,//datetime
                case CEnum.TagName.o2jam_BeginDate:// = 0x1461,
                case CEnum.TagName.o2jam_EndDate:// = 0x1462,
                case CEnum.TagName.CARD_PDdate:// 0x1214

                case CEnum.TagName.BeginTime:// = 0x0415,//Format:Date 开始日期
                case CEnum.TagName.EndTime:// = 0x0416,//Format:Date 结束日期
                case CEnum.TagName.SDO_RegistDate:  //0x0839,//注册日期
                case CEnum.TagName.SDO_FirstLogintime:  //0x0840,//第一次登录时间
                case CEnum.TagName.SDO_LastLogintime:  //0x0841,//最后一次登录时间
                case CEnum.TagName.SDO_BeginTime: //0x0845,//Format:Date 消费记录开始时间
                case CEnum.TagName.SDO_EndTime: //0x0846,//Format:Date 消费记录结束时间
                case CEnum.TagName.SDO_SendTime: //0x0847,//Format:Date 道具送人日期
                ///
                case CEnum.TagName.CARD_rdate:// 0x1256,//TLV_Date 久之游注册日期
                case CEnum.TagName.CARD_birthday:// 0x1264,//TLV_Date 出生日期
                ///
                case CEnum.TagName.AuShop_BeginDate://=0x1361,//date
                case CEnum.TagName.AuShop_EndDate://=0x1362,//
                ///
                ///
                case CEnum.TagName.CARD_create_date:// 0x1245
                case CEnum.TagName.O2JAM2_DateLimit://= 0x1623,
                case CEnum.TagName.O2JAM2_BeginDate://= 0x1626,
                case CEnum.TagName.O2JAM2_ENDDate://= 0x1627,
                case CEnum.TagName.O2JAM2_StopTime:// = 0x1634,//date
                case CEnum.TagName.CR_Last_Login:// = 0x1634,//date
                case CEnum.TagName.CR_Last_Logout:// = 0x1634,//date
                case CEnum.TagName.Bug_Date:// = 0x0121,//Format:TimeStamp 日期
                case CEnum.TagName.Update_Date:// = 0x0128//Format:TimeStamp
                case CEnum.TagName.CARD_valid_date:// 0x1242

                case CEnum.TagName.CARD_Locktime:
                case CEnum.TagName.TOKEN_Start:// = 0x1238,
                case CEnum.TagName.TOKEN_End:// = 0x1239,
                case CEnum.TagName.SDO_Usedate:
                case CEnum.TagName.AU_WeddingDate:
                case CEnum.TagName.CARD_Buytime:
                case CEnum.TagName.CARD_PayStartDate:
                case CEnum.TagName.CARD_PayStopDate:
                case CEnum.TagName.SDO_RewardItemTime:
                case CEnum.TagName.CARD_rtime:
                case CEnum.TagName.NOTES_DATE:
                case CEnum.TagName.FJ_OfflineTime:
                case CEnum.TagName.FJ_LoginTime:

                case CEnum.TagName.AU_OpenDate:
                case CEnum.TagName.AU_CloseDate:
     
                case CEnum.TagName.CARD_START_DATE://开始日期
                case CEnum.TagName.CARD_END_DATE://结束日期
                case CEnum.TagName.CARD_UPDATE_TIME://
                case CEnum.TagName.FJ_UseTime:
                case CEnum.TagName.FJ_ActiveTime:
                case CEnum.TagName.FJ_LastOfflineTime:
                case CEnum.TagName.FJ_CreateTime:
                case CEnum.TagName.FJ_BanDate:
                case CEnum.TagName.SDO_DATE:
                case CEnum.TagName.RC_OnlineTime:
                case CEnum.TagName.RC_OfflineTime:
                case CEnum.TagName.RC_BeginDate:
                case CEnum.TagName.RC_EndDate:

                case CEnum.TagName.AU_BeginTime:// = 0x1050,//开始时间
                case CEnum.TagName.AU_EndTime:// = 0x1051,//结束时间
                
                    ///
                tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_TIMESTAMP;
                tBody[iRow, iField].oContent = tTlv.toTimeStamp();
                break;
                //case CEnum.TagName.CARD_PDCardPrice:// 0x1208

                case CEnum.TagName.CARD_SumTotal:
                case CEnum.TagName.FJ_CurSP:
                case CEnum.TagName.FJ_CurExp:  //TLV_INTEGER
                
                case CEnum.TagName.RC_Exp:
                case CEnum.TagName.FJ_Inst_Cur://耐久正确值 f
                case CEnum.TagName.FJ_Inst_Max://耐久最大值 f
                
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_MONEY;
                    tBody[iRow, iField].oContent = tTlv.toMoney();
                    break;

                case CEnum.TagName.O2JAM2_Sex://= 0x1611,//Format:TLV_BOOLEAN 性别
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_BOOLEAN;
                    tBody[iRow, iField].oContent = tTlv.toInteger();
                    break;
                case CEnum.TagName.NOTES_Attachment:
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_EXTEND;
                    tBody[iRow, iField].oContent = tTlv.m_bValueBuffer;
                    //tBody[iRow, iField].oContent = tTlv.toExtend();

                    break;
                default:
                    tBody[iRow, iField].eTag = CEnum.TagFormat.TLV_STRING;
                    tBody[iRow, iField].oContent = "无法获得标签";
                    break;
            }
            #endregion

            return tBody;
        }
        /// <summary>
        /// 接收消息
        /// </summary>
        private CEnum.Message_Body[,] ReciveMessage(CSocketClient pSocketClient)
        {
            int iField = 0;
            CEnum.Message_Body[,] p_ReturnBody = null;

            Packet mPacket = null;
            Packet_Head mPacketHead = null;
            Packet_Body mPacketbody = null;

            try
            {
                CSocketData mReciveData = new CSocketData();

                mReciveData = mSockData.SocketRecive(pSocketClient.ReceiveData());

                if (System.Text.Encoding.Default.GetString(mReciveData.bMsgBuffer).Equals("FAILURE"))
                {
                    p_ReturnBody = new CEnum.Message_Body[1, 1];
                    p_ReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                    p_ReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
                    p_ReturnBody[0, 0].oContent = "服务器超时";

                    return p_ReturnBody;
                }

                if (!mReciveData.bValidMsag)
                {
                    p_ReturnBody = new CEnum.Message_Body[1, 1];
                    p_ReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                    p_ReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
                    p_ReturnBody[0, 0].oContent = "数据解析异常";


                    return p_ReturnBody;
                }

                mPacket = mReciveData.m_Packet;
                mPacketHead = mReciveData.m_Packet.m_Head;
                mPacketbody = mReciveData.m_Packet.m_Body;

                #region 解析 MessageID
                switch (mReciveData.GetMessageID())
                {
                    #region ---
                    /*
                    case CEnum.Message_Tag_ID.CONNECT: //0x800001,
                    case CEnum.Message_Tag_ID.CONNECT_RESP: //0x808001,
                    case CEnum.Message_Tag_ID.DISCONNECT: //0x800002,
                    case CEnum.Message_Tag_ID.DISCONNECT_RESP: //0x808002,
                    case CEnum.Message_Tag_ID.ACCOUNT_AUTHOR: //0x800003,
                    case CEnum.Message_Tag_ID.ACCOUNT_AUTHOR_RESP: //0x808003,
                    case CEnum.Message_Tag_ID.USER_CREATE: //0x810001,
                    case CEnum.Message_Tag_ID.USER_CREATE_RESP: //0x818001,
                    case CEnum.Message_Tag_ID.USER_UPDATE: //0x810002,
                    case CEnum.Message_Tag_ID.USER_UPDATE_RESP: //0x818002,
                    case CEnum.Message_Tag_ID.USER_DELETE: //0x810003,
                    case CEnum.Message_Tag_ID.USER_DELETE_RESP: //0x818003,
                    case CEnum.Message_Tag_ID.USER_QUERY: //0x810004,
                    case CEnum.Message_Tag_ID.USER_PASSWD_MODIF: //0x810005
                    case CEnum.Message_Tag_ID.USER_PASSWD_MODIF_RESP: //0x818005
                    case CEnum.Message_Tag_ID.MODULE_CREATE: //0x820001,
                    case CEnum.Message_Tag_ID.MDDULE_CREATE_RESP: //0x828001,
                    case CEnum.Message_Tag_ID.MODULE_UPDATE: //0x820002,
                    case CEnum.Message_Tag_ID.MODULE_UPDATE_RESP: //0x828002,
                    case CEnum.Message_Tag_ID.MODULE_DELETE: //0x820003,
                    case CEnum.Message_Tag_ID.MODULE_DELETE_RESP: //0x828003,
                    case CEnum.Message_Tag_ID.MODULE_QUERY: //0x820004,
                    case CEnum.Message_Tag_ID.USER_MODULE_CREATE: //0x830001,
                    case CEnum.Message_Tag_ID.USER_MODULE_CREATE_RESP: //0x838001,
                    case CEnum.Message_Tag_ID.USER_MODULE_UPDATE: //0x830002,
                    case CEnum.Message_Tag_ID.USER_MODULE_UPDATE_RESP: //0x838002,
                    case CEnum.Message_Tag_ID.USER_MODULE_DELETE: //0x830003,
                    case CEnum.Message_Tag_ID.USER_MODULE_DELETE_RESP: //0x838003,
                    case CEnum.Message_Tag_ID.GAME_CREATE: //0x840001,//创建GM帐号请求
                    case CEnum.Message_Tag_ID.GAME_CREATE_RESP: //0x848001,//创建GM帐号响应
                    case CEnum.Message_Tag_ID.GAME_UPDATE: //0x840002,//更新GM帐号信息请求
                    case CEnum.Message_Tag_ID.GAME_UPDATE_RESP: //0x848002,//更新GM帐号信息响应
                    case CEnum.Message_Tag_ID.GAME_DELETE: //0x840003,//删除GM帐号信息请求
                    case CEnum.Message_Tag_ID.GAME_DELETE_RESP: //0x848003,//删除GM帐号信息响应
                    case CEnum.Message_Tag_ID.GAME_QUERY:
                    case CEnum.Message_Tag_ID.GAME_MODULE_QUERY:
                    case CEnum.Message_Tag_ID.NOTDEFINED: //0x0,
                    case CEnum.Message_Tag_ID.NOTES_LETTER_PROCESS://  0x850002, //邮件处理
                    case CEnum.Message_Tag_ID.NOTES_LETTER_PROCESS_RESP://  0x858002,//邮件处理
                    case CEnum.Message_Tag_ID.ERROR: //0xFFFFFFFF
                    case CEnum.Message_Tag_ID.UPDATE_ACTIVEUSER://更新在线用户状态
                    case CEnum.Message_Tag_ID.UPDATE_ACTIVEUSER_RESP://更新在线用户状态响应
                    case CEnum.Message_Tag_ID.LINK_SERVERIP_CREATE:// = 0x0007,
                    case CEnum.Message_Tag_ID.LINK_SERVERIP_CREATE_RESP:// = 0x8007,
                    
                    ////////////////////////游戏管理消息 -- 猛将////////////////////////
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_UPDATE: //0x860002,//修改玩家状态
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_UPDATE_RESP: //0x868002,//修改玩家状态响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_EXPLOIT_UPDATE: //0x860004,//修改功勋值
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_EXPLOIT_UPDATE_RESP: //0x868004,//修改功勋值响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_CREATE: //0x860006,//添加好友
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_CREATE_RESP: //0x868006,//添加好友响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_DELETE: //0x860007,//删除好友
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_DELETE_RESP: //0x868007,//删除好友响应
                    case CEnum.Message_Tag_ID.MJ_GUILDTABLE_UPDATE: //0x860008,//修改服务器所有已存在帮会
                    case CEnum.Message_Tag_ID.MJ_GUILDTABLE_UPDATE_RESP: //0x868008,//修改服务器所有已存在帮会响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_CREATE: //0x860009,//将服务器上的account表里的玩家信息保存到本地服务器的
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_CREATE_RESP: //0x868009,//将服务器上的account表里的玩家信息保存到本地服务器的响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_DELETE: //0x860009,//永久封停帐号
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_DELETE_RESP: //0x868009,//永久封停帐号的响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_RESTORE: //0x860010,//解封帐号
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_RESTORE_RESP: //0x868010,//解封帐号响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LIMIT_RESTORE: //0x860011,//有时限的封停
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LIMIT_RESTORE_RESP: //0x868011,//有时限的封停响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_LOCAL_CREATE: //0x860012,//保存玩家密码到本地 
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_LOCAL_CREATE_RESP: //0x868012,//保存玩家密码到本地
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_UPDATE: //0x860013,//修改玩家密码 
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_UPDATE_RESP: //0x868013,//修改玩家密码
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_RESTORE: //0x860014,//恢复玩家密码
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_RESTORE_RESP: //0x868014,//恢复玩家密码
                    
                    ////////////////////////游戏管理消息 -- 超级舞者////////////////////////
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_CLOSE:  //0x870028,//封停帐户的权限信息
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_CLOSE_RESP:  //0x878028,//封停帐户的权限信息响应
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_OPEN:  //0x870029,//解封帐户的权限信息
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_OPEN_RESP:  //0x878029,//解封帐户的权限信息响应
                    case CEnum.Message_Tag_ID.SDO_PASSWORD_RECOVERY:  //0x870030,//玩家找回密码
                    case CEnum.Message_Tag_ID.SDO_PASSWORD_RECOVERY_RESP:  //0x878030,//玩家找回密码响应
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_UPDATE:  //0x870034,//修改玩家的账号信息
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_UPDATE_RESP:  //0x878034,//修改玩家的账号信息响应

						iField = 1;
                        p_ReturnBody = new CEnum.Message_Body[mPacketbody.TLVCount, iField];
						
						for (int i=0; i<mPacketbody.TLVCount; i++)
						{
							TLV_Structure mStruct = new TLV_Structure(mPacketbody.getTLVByIndex(i).m_Tag, mPacketbody.getTLVByIndex(i).m_uiValueLen, mPacketbody.getTLVByIndex(i).m_bValueBuffer);
							
							p_ReturnBody[i,0].eName = mPacketbody.getTLVByIndex(i).m_Tag;
							p_ReturnBody = DecodeRecive(i, iField - 1, mStruct, p_ReturnBody);
						}					
						break;
                    case CEnum.Message_Tag_ID.MODULE_QUERY_RESP: //0x828004,
                    case CEnum.Message_Tag_ID.USER_MODULE_QUERY:// 0x830004:查询用户所对应模块请求
                    case CEnum.Message_Tag_ID.USER_MODULE_QUERY_RESP://0x838004:查询用户所对应模块响应
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSFER: //0x850001, //取得邮件列表
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSFER_RESP: //0x858001,//取得邮件列表的响应
                    case CEnum.Message_Tag_ID.USER_QUERY_RESP: //0x818004,
                    case CEnum.Message_Tag_ID.GAME_QUERY_RESP: //0x818004,
                    case CEnum.Message_Tag_ID.GAME_MODULE_QUERY_RESP: //0x848005,
                    case CEnum.Message_Tag_ID.USER_QUERY_ALL: //0x818004,
                    case CEnum.Message_Tag_ID.USER_QUERY_ALL_RESP: //0x848005,
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSMIT: //0x818004,
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSMIT_RESP: //0x848005,
                    case CEnum.Message_Tag_ID.DEPART_QUERY: //0x818004,
                    case CEnum.Message_Tag_ID.DEPART_QUERY_RESP: //0x848005,
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_QUERY:
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_ALL_QUERY:// = 0x0006,//查询所有游戏服务IP
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_ALL_QUERY_RESP:// = 0x8006,//查询所有游戏服务IP响应
                    ////////////////////////游戏管理消息 -- 猛将////////////////////////
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_QUERY: //0x860001,//检查玩家状态
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_QUERY_RESP: //0x868001,//检查玩家状态响应
                    case CEnum.Message_Tag_ID.MJ_LOGINTABLE_QUERY: //0x860003,//检查玩家是否在线
                    case CEnum.Message_Tag_ID.MJ_LOGINTABLE_QUERY_RESP: //0x868003,//检查玩家是否在线响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_QUERY: //0x860005,//列出好友名单
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_QUERY_RESP: //0x868005,//列出好有名单响应
                    case CEnum.Message_Tag_ID.MJ_ITEMLOG_QUERY: //0x860015,//检查该用户交易记录
                    case CEnum.Message_Tag_ID.MJ_ITEMLOG_QUERY_RESP: //0x868015,//检查该用户交易记录
                    case CEnum.Message_Tag_ID.MJ_GMTOOLS_LOG_QUERY: //0x860016,//检查使用者操作记录
                    case CEnum.Message_Tag_ID.MJ_GMTOOLS_LOG_QUERY_RESP: //0x868016,//检查使用者操作记录
                    case CEnum.Message_Tag_ID.MJ_MONEYFIGHTERSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_MONEYFIGHTERSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_MONEYRABBISORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_MONEYRABBISORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_MONEYSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_MONEYSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_MONEYTAOISTSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_MONEYTAOISTSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_LEVELFIGHTERSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_LEVELFIGHTERSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_LEVELRABBISORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_LEVELRABBISORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_LEVELSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_LEVELSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_LEVELTAOISTSORT_QUERY:
                    case CEnum.Message_Tag_ID.MJ_LEVELTAOISTSORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_QUERY:// = 0x860027,//查询猛将本地帐号
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_QUERY_RESP:// = 0x868027,//查询猛将本地帐号响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_QUERY:// = 0x0026,//猛将帐号查询
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_QUERY_RESP:// = 0x8026,//猛将帐号查询响应
                    ////////////////////////游戏管理消息 -- 超级舞者////////////////////////
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_QUERY:  //0x870026,//查看玩家的帐号信息
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_QUERY_RESP:  //0x878026,//查看玩家的帐号信息响应
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_QUERY:  //0x870027,//查看任务资料的信息
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_QUERY_RESP:  //0x878027,//查看人物资料的信息响应
                    case CEnum.Message_Tag_ID.SDO_CONSUME_QUERY:  //0x870031,//查看玩家的消费记录
                    case CEnum.Message_Tag_ID.SDO_CONSUME_QUERY_RESP:  //0x878031,//查看玩家的消费记录响应
                    case CEnum.Message_Tag_ID.SDO_USERONLINE_QUERY:  //0x870032,//查看玩家上下线状态
                    case CEnum.Message_Tag_ID.SDO_USERONLINE_QUERY_RESP:  //0x878032,//查看玩家上下线状态响应
                    case CEnum.Message_Tag_ID.SDO_USERTRADE_QUERY:  //0x870033,//查看玩家交易状态
                    case CEnum.Message_Tag_ID.SDO_USERTRADE_QUERY_RESP:  //0x878033,//查看玩家交易状态响应
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_QUERY:  //0x870033,//查看玩家交易状态
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_QUERY_RESP:  //0x878033,//查看玩家交易状态响应
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_CREATE:
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_CREATE_RESP:
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_DELETE:
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_DELETE_RESP:
                    case CEnum.Message_Tag_ID.SDO_USERLOGIN_STATUS_QUERY:
                    case CEnum.Message_Tag_ID.SDO_USERLOGIN_STATUS_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_BYOWNER_QUERY:
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_BYOWNER_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_TRADE_QUERY:// 0x870040,//查看玩家交易记录信息
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_TRADE_QUERY_RESP:// 0x878040,//查看玩家交易记录信息的响应
                    case CEnum.Message_Tag_ID.SDO_MEMBERSTOPSTATUS_QUERY:// = 0x870041,//查看该帐号状态
                    case CEnum.Message_Tag_ID.SDO_MEMBERSTOPSTATUS_QUERY_RESP:// = 0x878041,///查看该帐号状态的响应
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_QUERY:// = 0x870042,//查看玩家礼物盒的道具
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_QUERY_RESP:// = 0x878042,//查看玩家礼物盒的道具响应
                    case CEnum.Message_Tag_ID.SDO_MEMBERBANISHMENT_QUERY: //0x870044,//查看所有停封的帐号
                    case CEnum.Message_Tag_ID.SDO_MEMBERBANISHMENT_QUERY_RESP: //0x878044,//查看所有停封的帐号响应
                    case CEnum.Message_Tag_ID.SDO_USERMCASH_QUERY: //0x870045,//玩家充值记录查询
                    case CEnum.Message_Tag_ID.SDO_USERMCASH_QUERY_RESP: //0x878045,//玩家充值记录查询响应
                    case CEnum.Message_Tag_ID.SDO_USERGCASH_UPDATE: //0x870046,//补偿玩家G币
                    case CEnum.Message_Tag_ID.SDO_USERGCASH_UPDATE_RESP: //0x878046,//补偿玩家G币的响应
                    case CEnum.Message_Tag_ID.SDO_MEMBERLOCAL_BANISHMENT://= 0x870047,//本地保存停封信息
                    case CEnum.Message_Tag_ID.SDO_MEMBERLOCAL_BANISHMENT_RESP: //0x878047,//本地保存停封信息响应
                    //////////////////////////GM 操作日志///////////////////////////////////
                    case CEnum.Message_Tag_ID.GMTOOLS_OperateLog_Query:// 0x800005,//查看工具操作记录
                    case CEnum.Message_Tag_ID.GMTOOLS_OperateLog_Query_RESP:// 0x808005,//查看工具操作记录响应
                    //////////////////////////升级//////////////////////////////////////////
	                case CEnum.Message_Tag_ID.CLIENT_PATCH_COMPARE:// = 0x0008,//客户端版本升级
                    case CEnum.Message_Tag_ID.CLIENT_PATCH_COMPARE_RESP:// = 0x8008,//客户端版本升级
                    */
                    #endregion
                    /// <summary>
                    /// 公共模块(0x80)
                    /// </summary>
                    case CEnum.Message_Tag_ID.CONNECT:// 0x800001://连接请求
                    case CEnum.Message_Tag_ID.CONNECT_RESP:// 0x808001://连接响应
                    case CEnum.Message_Tag_ID.DISCONNECT:// 0x800002://断开请求
                    case CEnum.Message_Tag_ID.DISCONNECT_RESP:// 0x808002://断开响应
                    case CEnum.Message_Tag_ID.ACCOUNT_AUTHOR:// 0x800003://用户身份验证请求
                    case CEnum.Message_Tag_ID.ACCOUNT_AUTHOR_RESP:// 0x808003://用户身份验证响应
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_QUERY:// 0x800004:
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_QUERY_RESP:// 0x808004:
                    case CEnum.Message_Tag_ID.LINK_SERVERIP_DELETE: //= 0x800010,
                    case CEnum.Message_Tag_ID.LINK_SERVERIP_DELETE_RESP: //= 0x808010,
                    case CEnum.Message_Tag_ID.GMTOOLS_OperateLog_Query:// 0x800005://查看工具操作记录
                    case CEnum.Message_Tag_ID.GMTOOLS_OperateLog_Query_RESP:// 0x808005://查看工具操作记录响应
                    case CEnum.Message_Tag_ID.GMTOOLS_BUGLIST_QUERY:// = 0x810016://Bug报告
                    case CEnum.Message_Tag_ID.GMTOOLS_BUGLIST_QUERY_RESP:// = 0x818016:
                    case CEnum.Message_Tag_ID.GMTOOLS_BUGLIST_INSERT:// = 0x810017:
                    case CEnum.Message_Tag_ID.GMTOOLS_BUGLIST_INSERT_RESP:// = 0x818017:
                    case CEnum.Message_Tag_ID.GMTOOLS_BUGLIST_UPDATE:// = 0x810018:
                    case CEnum.Message_Tag_ID.GMTOOLS_BUGLIST_UPDATE_RESP:// = 0x818018:
                    case CEnum.Message_Tag_ID.GMTOOLS_UPDATELIST_QUERY:// = 0x810019://版本更新信息
                    case CEnum.Message_Tag_ID.GMTOOLS_UPDATELIST_QUERY_RESP:// = 0x818019:
                    case CEnum.Message_Tag_ID.GMTOOLS_RESETSTATICS_QUERY:// = 0x800015,
                    case CEnum.Message_Tag_ID.GMTOOLS_RESETSTATICS_QUERY_RESP:// = 0x808015,
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_ALL_QUERY:// 0x800006:
                    case CEnum.Message_Tag_ID.SERVERINFO_IP_ALL_QUERY_RESP:// 0x808006:
                    case CEnum.Message_Tag_ID.LINK_SERVERIP_CREATE:// 0x800007:
                    case CEnum.Message_Tag_ID.LINK_SERVERIP_CREATE_RESP:// 0x808007:
                    case CEnum.Message_Tag_ID.CLIENT_PATCH_COMPARE:// 0x800008:
                    case CEnum.Message_Tag_ID.CLIENT_PATCH_COMPARE_RESP:// 0x808008:
                    case CEnum.Message_Tag_ID.CLIENT_PATCH_UPDATE:// 0x800009:
                    case CEnum.Message_Tag_ID.CLIENT_PATCH_UPDATE_RESP:// 0x808009:

                    /// <summary>
                    /// 用户管理模块(0x81)
                    /// </summary>
                    case CEnum.Message_Tag_ID.USER_CREATE:// 0x810001://创建GM帐号请求
                    case CEnum.Message_Tag_ID.USER_CREATE_RESP:// 0x818001://创建GM帐号响应
                    case CEnum.Message_Tag_ID.USER_UPDATE:// 0x810002://更新GM帐号信息请求
                    case CEnum.Message_Tag_ID.USER_UPDATE_RESP:// 0x818002://更新GM帐号信息响应
                    case CEnum.Message_Tag_ID.USER_DELETE:// 0x810003://删除GM帐号信息请求
                    case CEnum.Message_Tag_ID.USER_DELETE_RESP:// 0x818003://删除GM帐号信息响应
                    case CEnum.Message_Tag_ID.USER_QUERY:// 0x810004://查询GM帐号信息请求
                    case CEnum.Message_Tag_ID.USER_QUERY_RESP:// 0x818004://查询GM帐号信息响应
                    case CEnum.Message_Tag_ID.USER_PASSWD_MODIF:// 0x810005://密码修改请求
                    case CEnum.Message_Tag_ID.USER_PASSWD_MODIF_RESP:// 0x818005: //密码修改信息响应
                    case CEnum.Message_Tag_ID.USER_QUERY_ALL:// 0x810006://查询所有GM帐号信息
                    case CEnum.Message_Tag_ID.USER_QUERY_ALL_RESP:// 0x818006://查询所有GM帐号信息响应
                    case CEnum.Message_Tag_ID.DEPART_QUERY:// 0x810007: //查询部门列表
                    case CEnum.Message_Tag_ID.DEPART_QUERY_RESP:// 0x818007://查询部门列表响应
                    case CEnum.Message_Tag_ID.UPDATE_ACTIVEUSER:// 0x810008://更新在线用户状态
                    case CEnum.Message_Tag_ID.UPDATE_ACTIVEUSER_RESP:// 0x818008://更新在线用户状态响应

                    /// <summary>
                    /// 模块管理(0x82)
                    /// </summary>
                    case CEnum.Message_Tag_ID.MODULE_CREATE:// 0x820001://创建模块信息请求
                    case CEnum.Message_Tag_ID.MDDULE_CREATE_RESP:// 0x828001://创建模块信息响应
                    case CEnum.Message_Tag_ID.MODULE_UPDATE://0x820002://更新模块信息请求
                    case CEnum.Message_Tag_ID.MODULE_UPDATE_RESP:// 0x828002://更新模块信息响应
                    case CEnum.Message_Tag_ID.MODULE_DELETE:// 0x820003://删除模块请求
                    case CEnum.Message_Tag_ID.MODULE_DELETE_RESP:// 0x828003://删除模块响应
                    case CEnum.Message_Tag_ID.MODULE_QUERY:// 0x820004://查询模块信息的请求
                    case CEnum.Message_Tag_ID.MODULE_QUERY_RESP:// 0x828004://查询模块信息的响应

                    /// <summary>
                    /// 用户与模块管理(0x83)
                    /// </summary>
                    case CEnum.Message_Tag_ID.USER_MODULE_CREATE:// 0x830001://创建用户与模块请求
                    case CEnum.Message_Tag_ID.USER_MODULE_CREATE_RESP:// 0x838001://创建用户与模块响应
                    case CEnum.Message_Tag_ID.USER_MODULE_UPDATE:// 0x830002://更新用户与模块的请求
                    case CEnum.Message_Tag_ID.USER_MODULE_UPDATE_RESP:// 0x838002://更新用户与模块的响应
                    case CEnum.Message_Tag_ID.USER_MODULE_DELETE:// 0x830003://删除用户与模块请求
                    case CEnum.Message_Tag_ID.USER_MODULE_DELETE_RESP:// 0x838003://删除用户与模块响应
                    case CEnum.Message_Tag_ID.USER_MODULE_QUERY:// 0x830004://查询用户所对应模块请求
                    case CEnum.Message_Tag_ID.USER_MODULE_QUERY_RESP:// 0x838004://查询用户所对应模块响应

                    /// <summary>
                    /// 游戏管理(0x84)
                    /// </summary>
                    case CEnum.Message_Tag_ID.GAME_CREATE:// 0x840001://创建GM帐号请求
                    case CEnum.Message_Tag_ID.GAME_CREATE_RESP:// 0x848001://创建GM帐号响应
                    case CEnum.Message_Tag_ID.GAME_UPDATE:// 0x840002://更新GM帐号信息请求
                    case CEnum.Message_Tag_ID.GAME_UPDATE_RESP:// 0x848002://更新GM帐号信息响应
                    case CEnum.Message_Tag_ID.GAME_DELETE:// 0x840003://删除GM帐号信息请求
                    case CEnum.Message_Tag_ID.GAME_DELETE_RESP:// 0x848003://删除GM帐号信息响应
                    case CEnum.Message_Tag_ID.GAME_QUERY:// 0x840004://查询GM帐号信息请求
                    case CEnum.Message_Tag_ID.GAME_QUERY_RESP:// 0x848004://查询GM帐号信息响应
                    case CEnum.Message_Tag_ID.GAME_MODULE_QUERY:// 0x840005://查询游戏的模块列表
                    case CEnum.Message_Tag_ID.GAME_MODULE_QUERY_RESP:// 0x848005://查询游戏的模块列表响应


                    /// <summary>
                    /// NOTES管理(0x85)
                    /// </summary>
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSFER:// 0x850001: //取得邮件列表
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSFER_RESP:// 0x858001://取得邮件列表的响应
                    case CEnum.Message_Tag_ID.NOTES_LETTER_PROCESS:// 0x850002: //邮件处理
                    case CEnum.Message_Tag_ID.NOTES_LETTER_PROCESS_RESP:// 0x858002://邮件处理
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSMIT:// 0x850003: //邮件转发列表
                    case CEnum.Message_Tag_ID.NOTES_LETTER_TRANSMIT_RESP:// 0x858003://邮件转发列表
                    case CEnum.Message_Tag_ID.NOTES_LINKER_GET:
                    case CEnum.Message_Tag_ID.NOTES_LINKER_GET_RESP:
                    case CEnum.Message_Tag_ID.NOTES_CONTENT_GET:
                    case CEnum.Message_Tag_ID.NOTES_CONTENT_GET_RESP:
                    case CEnum.Message_Tag_ID.NOTES_CONTENT_SEND:
                    case CEnum.Message_Tag_ID.NOTES_CONTENT_SEND_RESP:
                    case CEnum.Message_Tag_ID.NOTES_CONTENT_REPLAY:
                    case CEnum.Message_Tag_ID.NOTES_CONTENT_REPLAY_RESP:
                    case CEnum.Message_Tag_ID.NOTES_ATTACHMENT_GET:
                    case CEnum.Message_Tag_ID.NOTES_ATTACHMENT_GET_RESP:
                    case CEnum.Message_Tag_ID.NOTES_CONTENT_UPDATE:
                    case CEnum.Message_Tag_ID.NOTES_CONTENT_UPDATE_RESP:

                    /// <summary>
                    /// 猛将GM工具(0x86)
                    /// </summary>
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_QUERY:// 0x860001://检查玩家状态
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_QUERY_RESP:// 0x868001://检查玩家状态响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_UPDATE:// 0x860002://修改玩家状态
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_UPDATE_RESP:// 0x868002://修改玩家状态响应
                    case CEnum.Message_Tag_ID.MJ_LOGINTABLE_QUERY:// 0x860003://检查玩家是否在线
                    case CEnum.Message_Tag_ID.MJ_LOGINTABLE_QUERY_RESP:// 0x868003://检查玩家是否在线响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_EXPLOIT_UPDATE:// 0x860004://修改功勋值
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_EXPLOIT_UPDATE_RESP:// 0x868004://修改功勋值响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_QUERY:// 0x860005://列出好友名单
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_QUERY_RESP:// 0x868005://列出好有名单响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_CREATE:// 0x860006://添加好友
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_CREATE_RESP:// 0x868006://添加好友响应
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_DELETE:// 0x860007://删除好友
                    case CEnum.Message_Tag_ID.MJ_CHARACTERINFO_FRIEND_DELETE_RESP:// 0x868007://删除好友响应
                    case CEnum.Message_Tag_ID.MJ_GUILDTABLE_UPDATE:// 0x860008://修改服务器所有已存在帮会
                    case CEnum.Message_Tag_ID.MJ_GUILDTABLE_UPDATE_RESP:// 0x868008://修改服务器所有已存在帮会响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_CREATE:// 0x860009://将服务器上的account表里的玩家信息保存到本地服务器的
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_CREATE_RESP:// 0x868009://将服务器上的account表里的玩家信息保存到本地服务器的响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_DELETE:// 0x860010://永久封停帐号
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_DELETE_RESP:// 0x868010://永久封停帐号的响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_RESTORE:// 0x860011://解封帐号
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_REMOTE_RESTORE_RESP:// 0x868011://解封帐号响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LIMIT_RESTORE:// 0x860012://有时限的封停
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LIMIT_RESTORE_RESP:// 0x868012://有时限的封停响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_LOCAL_CREATE:// 0x860013://保存玩家密码到本地 
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_LOCAL_CREATE_RESP:// 0x868013://保存玩家密码到本地
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_UPDATE:// 0x860014://修改玩家密码 
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_UPDATE_RESP:// 0x868014://修改玩家密码
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_RESTORE:// 0x860015://恢复玩家密码
                    case CEnum.Message_Tag_ID.MJ_ACCOUNTPASSWD_REMOTE_RESTORE_RESP:// 0x868015://恢复玩家密码
                    case CEnum.Message_Tag_ID.MJ_ITEMLOG_QUERY:// 0x860016://检查该用户交易记录
                    case CEnum.Message_Tag_ID.MJ_ITEMLOG_QUERY_RESP:// 0x868016://检查该用户交易记录
                    case CEnum.Message_Tag_ID.MJ_GMTOOLS_LOG_QUERY:// 0x860017://检查使用者操作记录
                    case CEnum.Message_Tag_ID.MJ_GMTOOLS_LOG_QUERY_RESP:// 0x868017://检查使用者操作记录
                    case CEnum.Message_Tag_ID.MJ_MONEYSORT_QUERY:// 0x860018://根据金钱排序
                    case CEnum.Message_Tag_ID.MJ_MONEYSORT_QUERY_RESP:// 0x868018://根据金钱排序的响应
                    case CEnum.Message_Tag_ID.MJ_LEVELSORT_QUERY:// 0x860019://根据等级排序
                    case CEnum.Message_Tag_ID.MJ_LEVELSORT_QUERY_RESP:// 0x868019://根据等级排序的响应
                    case CEnum.Message_Tag_ID.MJ_MONEYFIGHTERSORT_QUERY:// 0x860020://根据不同职业金钱排序
                    case CEnum.Message_Tag_ID.MJ_MONEYFIGHTERSORT_QUERY_RESP:// 0x868020://根据不同职业金钱排序的响应
                    case CEnum.Message_Tag_ID.MJ_LEVELFIGHTERSORT_QUERY:// 0x860021://根据不同职业等级排序
                    case CEnum.Message_Tag_ID.MJ_LEVELFIGHTERSORT_QUERY_RESP:// 0x868021://根据不同职业等级排序的响应
                    case CEnum.Message_Tag_ID.MJ_MONEYTAOISTSORT_QUERY:// 0x860022://根据道士金钱排序
                    case CEnum.Message_Tag_ID.MJ_MONEYTAOISTSORT_QUERY_RESP:// 0x868022://根据道士金钱排序的响应
                    case CEnum.Message_Tag_ID.MJ_LEVELTAOISTSORT_QUERY:// 0x860023://根据道士等级排序
                    case CEnum.Message_Tag_ID.MJ_LEVELTAOISTSORT_QUERY_RESP:// 0x868023://根据道士等级排序的响应
                    case CEnum.Message_Tag_ID.MJ_MONEYRABBISORT_QUERY:// 0x860024://根据法师金钱排序
                    case CEnum.Message_Tag_ID.MJ_MONEYRABBISORT_QUERY_RESP:// 0x868024://根据法师金钱排序的响应
                    case CEnum.Message_Tag_ID.MJ_LEVELRABBISORT_QUERY:// 0x860025://根据法师等级排序
                    case CEnum.Message_Tag_ID.MJ_LEVELRABBISORT_QUERY_RESP:// 0x868025://根据法师等级排序的响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_QUERY://  0x860026://猛将帐号查询
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_QUERY_RESP:// 0x868026://猛将帐号查询响应
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_QUERY:// 0x860027://查询猛将本地帐号
                    case CEnum.Message_Tag_ID.MJ_ACCOUNT_LOCAL_QUERY_RESP:// 0x868027://查询猛将本地帐号响应
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_QUERY:// 0x870026://查看玩家的帐号信息
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_QUERY_RESP:// 0x878026://查看玩家的帐号信息响应
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_QUERY:// 0x870027://查看任务资料的信息
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_QUERY_RESP:// 0x878027://查看人物资料的信息响应
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_CLOSE:// 0x870028://封停帐户的权限信息
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_CLOSE_RESP:// 0x878028://封停帐户的权限信息响应
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_OPEN:// 0x870029://解封帐户的权限信息
                    case CEnum.Message_Tag_ID.SDO_ACCOUNT_OPEN_RESP:// 0x878029://解封帐户的权限信息响应
                    case CEnum.Message_Tag_ID.SDO_PASSWORD_RECOVERY:// 0x870030://玩家找回密码
                    case CEnum.Message_Tag_ID.SDO_PASSWORD_RECOVERY_RESP:// 0x878030://玩家找回密码响应
                    case CEnum.Message_Tag_ID.SDO_CONSUME_QUERY:// 0x870031://查看玩家的消费记录
                    case CEnum.Message_Tag_ID.SDO_CONSUME_QUERY_RESP:// 0x878031://查看玩家的消费记录响应
                    case CEnum.Message_Tag_ID.SDO_USERONLINE_QUERY:// 0x870032://查看玩家上下线状态
                    case CEnum.Message_Tag_ID.SDO_USERONLINE_QUERY_RESP:// 0x878032://查看玩家上下线状态响应
                    case CEnum.Message_Tag_ID.SDO_USERTRADE_QUERY:// 0x870033://查看玩家交易状态
                    case CEnum.Message_Tag_ID.SDO_USERTRADE_QUERY_RESP:// 0x878033://查看玩家交易状态响应
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_UPDATE:// 0x870034://修改玩家的账号信息
                    case CEnum.Message_Tag_ID.SDO_CHARACTERINFO_UPDATE_RESP:// 0x878034://修改玩家的账号信息响应
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_QUERY:// 0x870035://查看游戏里面所有道具信息
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_QUERY_RESP:// 0x878035://查看游戏里面所有道具信息响应
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_DELETE:// 0x870036://删除玩家道具信息
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_DELETE_RESP:// 0x878036://删除玩家道具信息响应
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_CREATE:// 0x870037://添加玩家礼物盒道具信息
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_CREATE_RESP:// 0x878037://添加玩家礼物盒道具信息响应
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_QUERY:// 0x870038://查看玩家礼物盒的道具
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_QUERY_RESP:// 0x878038://查看玩家礼物盒的道具响应
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_DELETE:// 0x870039://删除玩家礼物盒的道具
                    case CEnum.Message_Tag_ID.SDO_GIFTBOX_DELETE_RESP:// 0x878039://删除玩家礼物盒的道具响应
                    case CEnum.Message_Tag_ID.SDO_USERLOGIN_STATUS_QUERY:// 0x870040://查看玩家登录状态
                    case CEnum.Message_Tag_ID.SDO_USERLOGIN_STATUS_QUERY_RESP:// 0x878040://查看玩家登录状态响应
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_BYOWNER_QUERY:// 0x870041:////查看玩家身上道具信息
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_BYOWNER_QUERY_RESP:// 0x878041:////查看玩家身上道具信息
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_TRADE_QUERY:// 0x870042://查看玩家交易记录信息
                    case CEnum.Message_Tag_ID.SDO_ITEMSHOP_TRADE_QUERY_RESP:// 0x878042://查看玩家交易记录信息的响应
                    case CEnum.Message_Tag_ID.SDO_MEMBERSTOPSTATUS_QUERY:// 0x870043://查看该帐号状态
                    case CEnum.Message_Tag_ID.SDO_MEMBERSTOPSTATUS_QUERY_RESP:// 0x878043:///查看该帐号状态的响应
                    case CEnum.Message_Tag_ID.SDO_MEMBERBANISHMENT_QUERY:// 0x870044://查看所有停封的帐号
                    case CEnum.Message_Tag_ID.SDO_MEMBERBANISHMENT_QUERY_RESP:// 0x878044://查看所有停封的帐号响应
                    case CEnum.Message_Tag_ID.SDO_USERMCASH_QUERY:// 0x870045://玩家充值记录查询
                    case CEnum.Message_Tag_ID.SDO_USERMCASH_QUERY_RESP:// 0x878045://玩家充值记录查询响应
                    case CEnum.Message_Tag_ID.SDO_USERGCASH_UPDATE:// 0x870046://补偿玩家G币
                    case CEnum.Message_Tag_ID.SDO_USERGCASH_UPDATE_RESP:// 0x878046://补偿玩家G币的响应
                    case CEnum.Message_Tag_ID.SDO_MEMBERLOCAL_BANISHMENT:// = 0x870047://本地保存停封信息
                    case CEnum.Message_Tag_ID.SDO_MEMBERLOCAL_BANISHMENT_RESP:// 0x878047://本地保存停封信息响应
                    case CEnum.Message_Tag_ID.SDO_EMAIL_QUERY:// 0x870048://得到玩家的EMAIL
                    case CEnum.Message_Tag_ID.SDO_EMAIL_QUERY_RESP:// 0x878048://得到玩家的EMAIL响应
                    case CEnum.Message_Tag_ID.SDO_USERCHARAGESUM_QUERY:// 0x870049://得到充值记录总和
                    case CEnum.Message_Tag_ID.SDO_USERCHARAGESUM_QUERY_RESP:// 0x878049://得到充值记录总和响应
                    case CEnum.Message_Tag_ID.SDO_USERCONSUMESUM_QUERY:// 0x870050://得到消费记录总和
                    case CEnum.Message_Tag_ID.SDO_USERCONSUMESUM_QUERY_RESP:// 0x878050://得到消费记录总和响应
                    case CEnum.Message_Tag_ID.SDO_USERGCASH_QUERY:// = 0x870051,//玩家Ｇ币记录查询
                    case CEnum.Message_Tag_ID.SDO_USERGCASH_QUERY_RESP:// = 0x878051,//玩家Ｇ币记录查询响应
                    case CEnum.Message_Tag_ID.SDO_USERNICK_UPDATE:// =0x870069, 
                    case CEnum.Message_Tag_ID.SDO_USERNICK_UPDATE_RESP:// =0x878069, 
                    case CEnum.Message_Tag_ID.SDO_BOARDMESSAGE_REQ:// = 0x870071,
                    case CEnum.Message_Tag_ID.SDO_BOARDMESSAGE_REQ_RESP:// = 0x878071,
                    case CEnum.Message_Tag_ID.SDO_CHANNELLIST_QUERY:// =  0x870072,
                    case CEnum.Message_Tag_ID.SDO_CHANNELLIST_QUERY_RESP:// = 0x878072,
                    case CEnum.Message_Tag_ID.SDO_ALIVE_REQ:// = 0x870073,
                    case CEnum.Message_Tag_ID.SDO_ALIVE_REQ_RESP:// = 0x878073,
                    case CEnum.Message_Tag_ID.SDO_BOARDTASK_INSERT:
                    case CEnum.Message_Tag_ID.SDO_BOARDTASK_INSERT_RESP:
                    case CEnum.Message_Tag_ID.SDO_USERLOGIN_DEL:// = 0x870078,
                    case CEnum.Message_Tag_ID.SDO_USERLOGIN_DEL_RESP:// = 0x878078,
                    case CEnum.Message_Tag_ID.SDO_GATEWAY_QUERY: //= 0x870079,
                    case CEnum.Message_Tag_ID.SDO_GATEWAY_QUERY_RESP:// = 0x878079,
                    case CEnum.Message_Tag_ID.SDO_USERLOGIN_CLEAR:// = 0x870079,
                    case CEnum.Message_Tag_ID.SDO_USERLOGIN_CLEAR_RESP:// = 0x878079,
                    case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_QUERY:
                    case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_QUERY_RESP:// = 0x878084,
		            case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_CREATE:// = 0x870085,
		            case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_CREATE_RESP:// = 0x878085,
		            case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_UPDATE:// = 0x870086,
		            case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_UPDATE_RESP:// = 0x878086,
		            case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_DELETE:// = 0x870087,
                    case CEnum.Message_Tag_ID.SDO_YYHAPPYITEM_DELETE_RESP:// = 0x878087,
                    case CEnum.Message_Tag_ID.SDO_USERONLINETIME_QUERY:
                    case CEnum.Message_Tag_ID.SDO_USERONLINETIME_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_PFUNCTIONITEM_QUERY:// = 0x870094,
                    case CEnum.Message_Tag_ID.SDO_PFUNCTIONITEM_QUERY_RESP:// = 0x878094,
                    case CEnum.Message_Tag_ID.CR_ACCOUNT_QUERY:
                    case CEnum.Message_Tag_ID.CR_ACCOUNT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.CR_ACCOUNTACTIVE_QUERY:
                    case CEnum.Message_Tag_ID.CR_ACCOUNTACTIVE_QUERY_RESP:
                    case CEnum.Message_Tag_ID.CR_CALLBOARD_QUERY:// = 0x890003,//公告信息查询
                    case CEnum.Message_Tag_ID.CR_CALLBOARD_QUERY_RESP:// = 0x898003,//公告信息查询响应
                    case CEnum.Message_Tag_ID.CR_CALLBOARD_CREATE:// = 0x890003,//发布公告
                    case CEnum.Message_Tag_ID.CR_CALLBOARD_CREATE_RESP:// = 0x898003,//发布公告响应
                    case CEnum.Message_Tag_ID.CR_CALLBOARD_UPDATE:// = 0x890004,//更新公告信息
                    case CEnum.Message_Tag_ID.CR_CALLBOARD_UPDATE_RESP:// = 0x898004,//更新公告信息的响应
                    case CEnum.Message_Tag_ID.CR_CALLBOARD_DELETE:// = 0x890005,//删除公告信息
                    case CEnum.Message_Tag_ID.CR_CALLBOARD_DELETE_RESP:// = 0x898005,//删除公告信息的响应
                    case CEnum.Message_Tag_ID.CR_CHARACTERINFO_QUERY:// = 0x890007,//玩家角色信息查询
                    case CEnum.Message_Tag_ID.CR_CHARACTERINFO_QUERY_RESP:// = 0x898007,//玩家角色信息查询的响应
                    case CEnum.Message_Tag_ID.CR_CHARACTERINFO_UPDATE:// = 0x890008,//玩家角色信息查询
                    case CEnum.Message_Tag_ID.CR_CHARACTERINFO_UPDATE_RESP:// = 0x898008,//玩家角色信息查询的响应
                    case CEnum.Message_Tag_ID.CR_CHANNEL_QUERY:// = 0x890009,//公告频道查询
                    case CEnum.Message_Tag_ID.CR_CHANNEL_QUERY_RESP:// = 0x898009,//公告频道查询的响应
                    case CEnum.Message_Tag_ID.CR_NICKNAME_QUERY:// = 0x890009,//公告频道查询
                    case CEnum.Message_Tag_ID.CR_NICKNAME_QUERY_RESP:// = 0x898009,//公告频道查询的响应
                    case CEnum.Message_Tag_ID.CR_LOGIN_LOGOUT_QUERY:// = 0x890009,//公告频道查询
                    case CEnum.Message_Tag_ID.CR_LOGIN_LOGOUT_QUERY_RESP:// = 0x898009,//公告频道查询的响应
                    case CEnum.Message_Tag_ID.CR_ERRORCHANNEL_QUERY://补充错误公告频道查询
                    case CEnum.Message_Tag_ID.CR_ERRORCHANNEL_QUERY_RESP://补充错误公告频道查询的响应

                    case CEnum.Message_Tag_ID.AU_ACCOUNT_QUERY://=0x880001,//玩家帐号信息查询
                    case CEnum.Message_Tag_ID.AU_ACCOUNT_QUERY_RESP://=0x888001,//玩家帐号信息查询响应
                    case CEnum.Message_Tag_ID.AU_ACCOUNTREMOTE_QUERY://=0x880002,//游戏服务器封停的玩家帐号查询
                    case CEnum.Message_Tag_ID.AU_ACCOUNTREMOTE_QUERY_RESP://=0x888002,//游戏服务器封停的玩家帐号查询响应
                    case CEnum.Message_Tag_ID.AU_ACCOUNTLOCAL_QUERY://=0x880003,//本地封停的玩家帐号查询
                    case CEnum.Message_Tag_ID.AU_ACCOUNTLOCAL_QUERY_RESP://=0x888003,//本地封停的玩家帐号查询响应
                    case CEnum.Message_Tag_ID.AU_ACCOUNT_CLOSE://=0x880004,//封停的玩家帐号
                    case CEnum.Message_Tag_ID.AU_ACCOUNT_CLOSE_RESP://=0x888004,//封停的玩家帐号响应
                    case CEnum.Message_Tag_ID.AU_ACCOUNT_OPEN://=0x880005,//解封的玩家帐号
                    case CEnum.Message_Tag_ID.AU_ACCOUNT_OPEN_RESP://=0x888005,//解封的玩家帐号响应
                    case CEnum.Message_Tag_ID.AU_ACCOUNT_BANISHMENT_QUERY://=0x880006,//玩家封停帐号查询
                    case CEnum.Message_Tag_ID.AU_ACCOUNT_BANISHMENT_QUERY_RESP://=0x888006,//玩家封停帐号查询响应
                    case CEnum.Message_Tag_ID.AU_CHARACTERINFO_QUERY://=0x880007,//查询玩家的账号信息
                    case CEnum.Message_Tag_ID.AU_CHARACTERINFO_QUERY_RESP://=0x888007,//查询玩家的账号信息响应
                    case CEnum.Message_Tag_ID.AU_CHARACTERINFO_UPDATE://=0x880008,//修改玩家的账号信息
                    case CEnum.Message_Tag_ID.AU_CHARACTERINFO_UPDATE_RESP://=0x888008,//修改玩家的账号信息响应
                    case CEnum.Message_Tag_ID.AU_ITEMSHOP_QUERY://=0x880009,//查看游戏里面所有道具信息
                    case CEnum.Message_Tag_ID.AU_ITEMSHOP_QUERY_RESP://=0x888009,//查看游戏里面所有道具信息响应
                    case CEnum.Message_Tag_ID.AU_ITEMSHOP_DELETE://=0x880010,//删除玩家道具信息
                    case CEnum.Message_Tag_ID.AU_ITEMSHOP_DELETE_RESP://=0x888010,//删除玩家道具信息响应
                    case CEnum.Message_Tag_ID.AU_ITEMSHOP_BYOWNER_QUERY://=0x880011,////查看玩家身上道具信息
                    case CEnum.Message_Tag_ID.AU_ITEMSHOP_BYOWNER_QUERY_RESP://=0x888011,////查看玩家身上道具信息
                    case CEnum.Message_Tag_ID.AU_ITEMSHOP_TRADE_QUERY://=0x880012,//查看玩家交易记录信息
                    case CEnum.Message_Tag_ID.AU_ITEMSHOP_TRADE_QUERY_RESP://=0x888012,//查看玩家交易记录信息的响应
                    case CEnum.Message_Tag_ID.AU_ITEMSHOP_CREATE://=0x880013,//添加玩家礼物盒道具信息
                    case CEnum.Message_Tag_ID.AU_ITEMSHOP_CREATE_RESP://=0x888013,//添加玩家礼物盒道具信息响应
                    case CEnum.Message_Tag_ID.AU_LEVELEXP_QUERY://=0x880014,//查看玩家等级经验
                    case CEnum.Message_Tag_ID.AU_LEVELEXP_QUERY_RESP://=0x888014,////查看玩家等级经验响应
                    case CEnum.Message_Tag_ID.AU_USERLOGIN_STATUS_QUERY://=0x880015,//查看玩家登录状态
                    case CEnum.Message_Tag_ID.AU_USERLOGIN_STATUS_QUERY_RESP://=0x888015,//查看玩家登录状态响应
                    case CEnum.Message_Tag_ID.AU_USERCHARAGESUM_QUERY://=0x880016,//得到充值记录总和
                    case CEnum.Message_Tag_ID.AU_USERCHARAGESUM_QUERY_RESP://=0x888016,//得到充值记录总和响应
                    case CEnum.Message_Tag_ID.AU_CONSUME_QUERY://=0x880017,//查看玩家的消费记录
                    case CEnum.Message_Tag_ID.AU_CONSUME_QUERY_RESP://=0x888017,//查看玩家的消费记录响应
                    case CEnum.Message_Tag_ID.AU_USERCONSUMESUM_QUERY://=0x880018,//得到消费记录总和
                    case CEnum.Message_Tag_ID.AU_USERCONSUMESUM_QUERY_RESP://=0x888018,//得到消费记录总和响应
                    case CEnum.Message_Tag_ID.AU_USERMCASH_QUERY://=0x880019,//玩家充值记录查询
                    case CEnum.Message_Tag_ID.AU_USERMCASH_QUERY_RESP://=0x888019,//玩家充值记录查询响应
                    case CEnum.Message_Tag_ID.AU_USERGCASH_QUERY://=0x880020,//玩家Ｇ币记录查询
                    case CEnum.Message_Tag_ID.AU_USERGCASH_QUERY_RESP://=0x888020,//玩家Ｇ币记录查询响应
                    case CEnum.Message_Tag_ID.AU_USERGCASH_UPDATE://=0x880021,//补偿玩家G币
                    case CEnum.Message_Tag_ID.AU_USERGCASH_UPDATE_RESP://=0x888021,//补偿玩家G币的响应
                    case CEnum.Message_Tag_ID.AU_MESSENGER_QUERY:
                    case CEnum.Message_Tag_ID.AU_MESSENGER_QUERY_RESP:
                    case CEnum.Message_Tag_ID.AU_MESSENGER_UPDATE:
                    case CEnum.Message_Tag_ID.AU_MESSENGER_UPDATE_RESP:
                    case CEnum.Message_Tag_ID.AU_WEDDING_QUERY:
                    case CEnum.Message_Tag_ID.AU_WEDDING_QUERY_RESP:
                    case CEnum.Message_Tag_ID.AU_WEDDINGGROUND_QUERY:
                    case CEnum.Message_Tag_ID.AU_WEDDINGGROUND_QUERY_RESP:
            		case CEnum.Message_Tag_ID.AU_GOODS_QUERY:
                    case CEnum.Message_Tag_ID.AU_GOODS_QUERY_RESP:
                    case CEnum.Message_Tag_ID.AU_JOINPCIP_QUERY:
                    case CEnum.Message_Tag_ID.AU_JOINPCIP_QUERY_RESP:
                    case CEnum.Message_Tag_ID.AU_JOINPCIP_Insert:
                    case CEnum.Message_Tag_ID.AU_JOINCPIP_Insert_RESP:
                    case CEnum.Message_Tag_ID.AU_JOINPCIP_Delete:
                    case CEnum.Message_Tag_ID.AU_JOINPCIP_Delete_RESP:
                    case CEnum.Message_Tag_ID.AU_MEMBERACTIVE_CREATE:
                    case CEnum.Message_Tag_ID.AU_MEMBERACTIVE_CREATE_RESP:

                    case CEnum.Message_Tag_ID.AU_BOARDMESSAGE_REQ:
                    case CEnum.Message_Tag_ID.AU_BOARDMESSAGE_REQ_RESP:
                    case CEnum.Message_Tag_ID.AU_BOARDTASK_INSERT:
                    case CEnum.Message_Tag_ID.AU_BOARDTASK_INSERT_RESP:
                    case CEnum.Message_Tag_ID.AU_BOARDTASK_QUERY:
                    case CEnum.Message_Tag_ID.AU_BOARDTASK_QUERY_RESP:
                    case CEnum.Message_Tag_ID.AU_BOARDTASK_UPDATE:
                    case CEnum.Message_Tag_ID.AU_BOARDTASK_UPDATE_RESP:
                    case CEnum.Message_Tag_ID.AU_GS_QUERY:
                    case CEnum.Message_Tag_ID.AU_GS_QUERY_RESP:

                    case CEnum.Message_Tag_ID.NOTES_CONTENT_DELETE:
                    case CEnum.Message_Tag_ID.NOTES_CONTENT_DELETE_RESP:
                    case CEnum.Message_Tag_ID.CARD_USERCHARGEDETAIL_QUERY:// 0x900001,// 卡通查询
                    case CEnum.Message_Tag_ID.CARD_USERCHARGEDETAIL_QUERY_RESP:// 0x908001,// 卡通查询响应
                    case CEnum.Message_Tag_ID.CARD_USERCONSUME_QUERY:// = 0x900003,//休闲币消费查询
                    case CEnum.Message_Tag_ID.CARD_USERCONSUME_QUERY_RESP:// = 0x908003,//休闲币消费查询响应
                    case CEnum.Message_Tag_ID.CARD_VNETCHARGE_QUERY:// 0x900005,//互联星空充值查询
                    case CEnum.Message_Tag_ID.CARD_VNETCHARGE_QUERY_RESP:// 0x908005,//互联星空充值查询响应
                    case CEnum.Message_Tag_ID.CARD_USERDETAIL_SUM_QUERY:// = 0x900005,//充值合计查询
                    case CEnum.Message_Tag_ID.CARD_USERDETAIL_SUM_QUERY_RESP:// = 0x908005,//充值合计查询响应
                    case CEnum.Message_Tag_ID.CARD_USERCONSUME_SUM_QUERY:// = 0x900006,//消费合计查询
                    case CEnum.Message_Tag_ID.CARD_USERCONSUME_SUM_QUERY_RESP:// = 0x908006,//消费合计响应
                    case CEnum.Message_Tag_ID.CARD_USERINFO_QUERY:// = 0x900007,//玩家注册信息查询
                    case CEnum.Message_Tag_ID.CARD_USERINFO_QUERY_RESP:// = 0x908007,//玩家注册信息查询响应
                    case CEnum.Message_Tag_ID.CARD_USERINFO_CLEAR:// = 0x900008,
                    case CEnum.Message_Tag_ID.CARD_USERINFO_CLEAR_RESP:// = 0x908008,
                    case CEnum.Message_Tag_ID.CARD_USERNICK_QUERY:// = 0x0010,
                    case CEnum.Message_Tag_ID.CARD_USERNICK_QUERY_RESP:// = 0x8010,
                    case CEnum.Message_Tag_ID.CARD_USERLOCK_UPDATE:// = 0x0011,
                    case CEnum.Message_Tag_ID.CARD_USERLOCK_UPDATE_RESP:// = 0x8011,
                    case CEnum.Message_Tag_ID.AU_USERNICK_UPDATE:// = 0x900011,
                    case CEnum.Message_Tag_ID.AU_USERNICK_UPDATE_RESP:// = 0x908011,
                    case CEnum.Message_Tag_ID.CARD_BALANCE_QUERY: //= 0x900012://用户余额查询
                    case CEnum.Message_Tag_ID.CARD_BALANCE_QUERY_RESP:// = 0x908012:
                    case CEnum.Message_Tag_ID.CARD_USERNUM_QUERY: //= 0x900013://点卡查询
                    case CEnum.Message_Tag_ID.CARD_USERNUM_QUERY_RESP:// = 0x908013: 
                    case CEnum.Message_Tag_ID.CARD_USERHISTORYPWD_QUERY:// = 0x0014,//历史密码
                    case CEnum.Message_Tag_ID.CARD_USERHISTORYPWD_QUERY_RESP:// = 0x8014,
                    case CEnum.Message_Tag_ID.CARD_USERINITACTIVE_QUERY:// = 0x0015,//激活游戏
                    case CEnum.Message_Tag_ID.CARD_USERINITACTIVE_QUERY_RESP:// = 0x8015,
                    case CEnum.Message_Tag_ID.TOKEN_TOKENSTATUS_QUERY://显示令牌的当前状态
                    case CEnum.Message_Tag_ID.TOKEN_TOKENSTATUS_QUERY_RESP:
                    case CEnum.Message_Tag_ID.TOKEN_MODIFYUSER_QUERY: //锁定用户令牌
                    case CEnum.Message_Tag_ID.TOKEN_MODIFYUSER_QUERY_RESP:
                    case CEnum.Message_Tag_ID.CARD_USERLOCK_QUERY:// = 0x900019,
                    case CEnum.Message_Tag_ID.CARD_USERLOCK_QUERY_RESP:// = 0x908019,
                    case CEnum.Message_Tag_ID.CARD_USERCARDLOCK_QUERY:// = 0x0020,
                    case CEnum.Message_Tag_ID.CARD_USERCARDLOCK_QUERY_RESP:// = 0x8020, 
                    case CEnum.Message_Tag_ID.CARD_USERTOKEN_QUERY:// = 0x900021,
                    case CEnum.Message_Tag_ID.CARD_USERTOKEN_QUERY_RESP:// = 0x908021,
		            case CEnum.Message_Tag_ID.CARD_USERTOKEN_OPEN:// = 0x900022,
		            case CEnum.Message_Tag_ID.CARD_USERTOKEN_OPEN_RESP:// = 0x908022,
		            case CEnum.Message_Tag_ID.CARD_USERTOKEN_CLOSE:// = 0x900023,
                    case CEnum.Message_Tag_ID.CARD_USERTOKEN_CLOSE_RESP:// = 0x908023,
                    case CEnum.Message_Tag_ID.CARD_USERTOKEN_RELEASE:// = 0x900024,
                    case CEnum.Message_Tag_ID.CARD_USERTOKEN_RELEASE_RESP:// = 0x908024,
            		case CEnum.Message_Tag_ID.CARD_DanceItem_QUERY:
                    case CEnum.Message_Tag_ID.CARD_DanceItem_QUERY_RESP:
                    case CEnum.Message_Tag_ID.CARD_RESETHISTORY_QUERY:
                    case CEnum.Message_Tag_ID.CARD_RESETHISTORY_QUERY_RESP:
                    case CEnum.Message_Tag_ID.AUSHOP_USERGPURCHASE_QUERY:// = 0x910001,//用户G币购买记录
                    case CEnum.Message_Tag_ID.AUSHOP_USERGPURCHASE_QUERY_RESP:// = 0x918001,//用户G币购买记录
                    case CEnum.Message_Tag_ID.AUSHOP_USERMPURCHASE_QUERY:// = 0x910002,//用户M币购买记录
                    case CEnum.Message_Tag_ID.AUSHOP_USERMPURCHASE_QUERY_RESP:// = 0x918002,//用户M币购买记录
                    case CEnum.Message_Tag_ID.AUSHOP_AVATARECOVER_QUERY:// = 0x910003,//道具回收兑换记
                    case CEnum.Message_Tag_ID.AUSHOP_AVATARECOVER_QUERY_RESP:// = 0x918003,//道具回收兑换记
                    case CEnum.Message_Tag_ID.AUSHOP_USERINTERGRAL_QUERY:// = 0x910004,//用户积分记录
                    case CEnum.Message_Tag_ID.AUSHOP_USERINTERGRAL_QUERY_RESP:// = 0x918004,//用户积分记录
                    case CEnum.Message_Tag_ID.AUSHOP_USEROPERLOG_CREATE:// = 0x0005,//用户G币购买记录合计
                    case CEnum.Message_Tag_ID.AUSHOP_USEROPERLOG_CREATE_RESP:// = 0x8005,//用户G币购买记录合计响应
                    case CEnum.Message_Tag_ID.AUSHOP_USERMPURCHASE_SUM_QUERY:// = 0x0006,//用户M币购买记录合计
                    case CEnum.Message_Tag_ID.AUSHOP_USERMPURCHASE_SUM_QUERY_RESP:// = 0x8006,//用户M币购买记录合计响应
                    case CEnum.Message_Tag_ID.AUSHOP_AVATARECOVER_DETAIL_QUERY:// = 0x910007,// 具回收兑换详细记录
                    case CEnum.Message_Tag_ID.AUSHOP_AVATARECOVER_DETAIL_QUERY_RESP:// = 0x918007,// 具回收兑换详细记录
                    case CEnum.Message_Tag_ID.AUSHOP_WAREHOUSE_QUERY://玩家游戏里面仓库里面的道具
                    case CEnum.Message_Tag_ID.AUSHOP_WAREHOUSE_QUERY_RESP://玩家游戏里面仓库里面的道具
                    case CEnum.Message_Tag_ID.AUSHOP_ERRBUY_REFUND://劲舞团商城 - 错误购买退款 
                    case CEnum.Message_Tag_ID.AUSHOP_ERRBUY_REFUND_RESP://劲舞团商城 - 错误购买退款 
                    case CEnum.Message_Tag_ID.AUSHOP_REPEATBuy_REFUND://劲舞团商城 - 重复购买退款 
                    case CEnum.Message_Tag_ID.AUSHOP_REPEATBuy_REFUND_RESP://劲舞团商城 - 重复购买退款 
                    case CEnum.Message_Tag_ID.AUSHOP_FillBuy_REFUND: //劲舞团商城 - 补发
                    case CEnum.Message_Tag_ID.AUSHOP_FillBuy_REFUND_RESP://劲舞团商城 - 补发
                    case CEnum.Message_Tag_ID.AUSHOP_REPEATGet_REFUND://劲舞团商城 - 允许用户重新领取
                    case CEnum.Message_Tag_ID.AUSHOP_REPEATGet_REFUND_RESP://劲舞团商城 - 允许用户重新领取
                    case CEnum.Message_Tag_ID.AUSHOP_SPECIALAVATITEM_QUERY://小喇叭
                    case CEnum.Message_Tag_ID.AUSHOP_SPECIALAVATITEM_QUERY_RESP://小喇叭
                    case CEnum.Message_Tag_ID.AUSHOP_OTHERSPECIALAVATITEM_QUERY://其他的特殊道具
                    case CEnum.Message_Tag_ID.AUSHOP_OTHERSPECIALAVATITEM_QUERY_RESP://其他的特殊道具

                    case CEnum.Message_Tag_ID.DEPARTMENT_CREATE:// = 0x810009,//部门创建
                    case CEnum.Message_Tag_ID.DEPARTMENT_CREATE_RESP:// = 0x818009,//部门创建响应
                    case CEnum.Message_Tag_ID.DEPARTMENT_UPDATE:// = 0x810010,//部门修改
                    case CEnum.Message_Tag_ID.DEPARTMENT_UPDATE_RESP:// = 0x818010,//部门修改响应
                    case CEnum.Message_Tag_ID.DEPARTMENT_DELETE:// = 0x810011,//部门删除
                    case CEnum.Message_Tag_ID.DEPARTMENT_DELETE_RESP:// = 0x818011,//部门删除响应
                    case CEnum.Message_Tag_ID.DEPARTMENT_ADMIN:// = 0x810012,//部门管理
                    case CEnum.Message_Tag_ID.DEPARTMENT_ADMIN_RESP:// = 0x818012,//部门管理响应
                    case CEnum.Message_Tag_ID.DEPARTMENT_RELATE_QUERY:// = 0x810013,//部门关联查询
                    case CEnum.Message_Tag_ID.DEPARTMENT_RELATE_QUERY_RESP:// = 0x818013,//部门关联查询

                    case CEnum.Message_Tag_ID.O2JAM_CHARACTERINFO_QUERY://= 0x920001,//玩家角色信息查询
                    case CEnum.Message_Tag_ID.O2JAM_CHARACTERINFO_QUERY_RESP://= 0x928001,//玩家角色信息查询
                    case CEnum.Message_Tag_ID.O2JAM_CHARACTERINFO_UPDATE://= 0x920002,//玩家角色信息更新
                    case CEnum.Message_Tag_ID.O2JAM_CHARACTERINFO_UPDATE_RESP://= 0x928002,//玩家角色信息更新
                    case CEnum.Message_Tag_ID.O2JAM_ITEM_QUERY://= 0x920001,//玩家道具信息查询
                    case CEnum.Message_Tag_ID.O2JAM_ITEM_QUERY_RESP://= 0x928001,//玩家角色信息查询
                    case CEnum.Message_Tag_ID.O2JAM_ITEM_UPDATE://= 0x920002,//玩家道具信息更新
                    case CEnum.Message_Tag_ID.O2JAM_ITEM_UPDATE_RESP://= 0x928002,//玩家道具信息更新
                    case CEnum.Message_Tag_ID.O2JAM_CONSUME_QUERY://= 0x920001,//玩家消费信息查询
                    case CEnum.Message_Tag_ID.O2JAM_CONSUME_QUERY_RESP://= 0x928001,//玩家消费信息查询
                    case CEnum.Message_Tag_ID.O2JAM_ITEMDATA_QUERY://= 0x920001,//玩家交易信息查询
                    case CEnum.Message_Tag_ID.O2JAM_ITEMDATA_QUERY_RESP://= 0x928001,//玩家交易信息查询
                    case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_QUERY:// = 0x920007://,//玩家礼物盒查询
                    case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_QUERY_RESP:// = 0x928007,//玩家礼物盒查询
                    case CEnum.Message_Tag_ID.O2JAM_USERGCASH_UPDATE:// = 0x920008,//补偿玩家G币
                    case CEnum.Message_Tag_ID.O2JAM_USERGCASH_UPDATE_RESP:// = 0x928008,//补偿玩家G币的响应
                    case CEnum.Message_Tag_ID.O2JAM_CONSUME_SUM_QUERY://= 0x920009,//玩家消费信息查询
                    case CEnum.Message_Tag_ID.O2JAM_CONSUME_SUM_QUERY_RESP://= 0x928009,//玩家消费信息查询
                    case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_CREATE_QUERY://= 0x920010,//玩家交易信息查询
                    case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_CREATE_QUERY_RESP://= 0x928010,//玩家交易信息查询
                    case CEnum.Message_Tag_ID.O2JAM_ITEMNAME_QUERY:// = 0x920011,
                    case CEnum.Message_Tag_ID.O2JAM_ITEMNAME_QUERY_RESP:// = 0x928011,
                    case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_DELETE:// = 0x920012,
                    case CEnum.Message_Tag_ID.O2JAM_GIFTBOX_DELETE_RESP://  =0x928012,
                    case CEnum.Message_Tag_ID.O2JAM_USERLOGIN_DEL:
                    case CEnum.Message_Tag_ID.O2JAM_USERLOGIN_DEL_RESP:

                    case CEnum.Message_Tag_ID.CARD_DanceItem_Qualification_QUERY:
                    case CEnum.Message_Tag_ID.CARD_DanceItem_Qualification_QUERY_RESP:
                    case CEnum.Message_Tag_ID.DEPART_RELATE_GAME_QUERY:// = 0x810014,
                    case CEnum.Message_Tag_ID.DEPART_RELATE_GAME_QUERY_RESP:// = 0x818014,
                    case CEnum.Message_Tag_ID.USER_SYSADMIN_QUERY:// = 0x810015,
                    case CEnum.Message_Tag_ID.USER_SYSADMIN_QUERY_RESP:// = 0x818015,

                    case CEnum.Message_Tag_ID.CARD_USERSECURE_CLEAR:// = 0x900009,//重置玩家安全码信息
                    case CEnum.Message_Tag_ID.CARD_USERSECURE_CLEAR_RESP:// = 0x908009,//重置玩家安全码信息响应


                    case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_QUERY:// = 0x930001,//玩家帐号信息查询
                    case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_QUERY_RESP:// = 0x938001,//玩家帐号信息查询响应
                    case CEnum.Message_Tag_ID.O2JAM2_ACCOUNTACTIVE_QUERY:// = 0x930002,//玩家帐号激活信息
                    case CEnum.Message_Tag_ID.O2JAM2_ACCOUNTACTIVE_QUERY_RESP:// = 0x938002,//玩家帐号激活响应


                    case CEnum.Message_Tag_ID.O2JAM2_CHARACTERINFO_QUERY://= 0x930003,//用户信息查询
                    case CEnum.Message_Tag_ID.O2JAM2_CHARACTERINFO_QUERY_RESP://= 0x938003,
                    case CEnum.Message_Tag_ID.O2JAM2_CHARACTERINFO_UPDATE://= 0x930004,//用户信息修改
                    case CEnum.Message_Tag_ID.O2JAM2_CHARACTERINFO_UPDATE_RESP://= 0x938004,
                    case CEnum.Message_Tag_ID.O2JAM2_ITEMSHOP_QUERY://= 0x930005,
                    case CEnum.Message_Tag_ID.O2JAM2_ITEMSHOP_QUERY_RESP://= 0x938005,
                    case CEnum.Message_Tag_ID.O2JAM2_ITEMSHOP_DELETE://= 0x930006,
                    case CEnum.Message_Tag_ID.O2JAM2_ITEMSHOP_DELETE_RESP://= 0x938006,
                    case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_QUERY://= 0x930007,
                    case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_QUERY_RESP://= 0x938007,
                    case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_CREATE://= 0x930008,
                    case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_CREATE_RESP://= 0x938008,
                    case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_DELETE://= 0x930009,
                    case CEnum.Message_Tag_ID.O2JAM2_MESSAGE_DELETE_RESP://= 0x938009,
                    case CEnum.Message_Tag_ID.O2JAM2_CONSUME_QUERY://= 0x930010,
                    case CEnum.Message_Tag_ID.O2JAM2_CONUMSE_QUERY_RESP://= 0x938010,
                    case CEnum.Message_Tag_ID.O2JAM2_CONSUME_SUM_QUERY://= 0x930011,
                    case CEnum.Message_Tag_ID.O2JAM2_CONUMSE_QUERY_SUM_RESP://= 0x938011,
                    case CEnum.Message_Tag_ID.O2JAM2_TRADE_QUERY://= 0x930012,
                    case CEnum.Message_Tag_ID.O2JAM2_TRADE_QUERY_RESP://= 0x938012,
                    case CEnum.Message_Tag_ID.O2JAM2_TRADE_SUM_QUERY://= 0x930013,
                    case CEnum.Message_Tag_ID.O2JAM2_TRADE_QUERY_SUM_RESP://= 0x938013,
                    case CEnum.Message_Tag_ID.O2JAM2_AVATORLIST_QUERY:// = 0x930014,
                    case CEnum.Message_Tag_ID.O2JAM2_AVATORLIST_QUERY_RESP:// = 0x938014,
                    case CEnum.Message_Tag_ID.O2JAM2_LEVELEXP_QUERY:
                    case CEnum.Message_Tag_ID.O2JAM2_LEVELEXP_QUERY_RESP:


                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_QUERY:// = 0x870052,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_QUERY_RESP:// = 0x878052,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_INSERT:// = 0x870053,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_INSERT_RESP:// = 0x878053,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_UPDATE:// = 0x870054,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_UPDATE_RESP:// = 0x878054,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_DELETE:// = 0x870055,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_DELETE_RESP:// = 0x878055,
                    case CEnum.Message_Tag_ID.SDO_MUSICDATA_QUERY:// = 0x870056,
                    case CEnum.Message_Tag_ID.SDO_MUSICDATA_QUERY_RESP:// = 0x878056,

                    case CEnum.Message_Tag_ID.SDO_MUSICDATA_OWN_QUERY:// = 0x870057,
                    case CEnum.Message_Tag_ID.SDO_MUSICDATA_OWN_QUERY_RESP:// = 0x878057,

                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_QUERY:// = 0x870058,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_QUERY_RESP://  = 0x878058,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_CREATE://  = 0x870059,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_CREATE_RESP://  = 0x878059,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_UPDATE://  = 0x870060,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_UPDATE_RESP://  = 0x878060,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_DELETE://  = 0x870061,
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_SCENE_DELETE_RESP://  = 0x878061,


                    case CEnum.Message_Tag_ID.SDO_MEDALITEM_CREATE:// = 0x870062://,
                    case CEnum.Message_Tag_ID.SDO_MEDALITEM_CREATE_RESP:// = 0x878062://,
                    case CEnum.Message_Tag_ID.SDO_MEDALITEM_UPDATE:// = 0x870063://,
                    case CEnum.Message_Tag_ID.SDO_MEDALITEM_UPDATE_RESP:// = 0x878063://,
                    case CEnum.Message_Tag_ID.SDO_MEDALITEM_DELETE:// = 0x870064://,
                    case CEnum.Message_Tag_ID.SDO_MEDALITEM_DELETE_RESP:// = 0x878064://,
                    case CEnum.Message_Tag_ID.SDO_MEDALITEM_QUERY:// = 0x870065,
                    case CEnum.Message_Tag_ID.SDO_MEDALITEM_QUERY_RESP:// = 0x878065,

                    case CEnum.Message_Tag_ID.SDO_MEDALITEM_OWNER_QUERY:// = 0x870066,
                    case CEnum.Message_Tag_ID.SDO_MEDALITEM_OWNER_QUERY_RESP:// = 0x878066,

                    case CEnum.Message_Tag_ID.SDO_MEMBERDANCE_OPEN:// = 0x870067,
                    case CEnum.Message_Tag_ID.SDO_MEMBERDANCE_OPEN_RESP:// = 0x878067,
                    case CEnum.Message_Tag_ID.SDO_MEMBERDANCE_CLOSE:// = 0x870068,
                    case CEnum.Message_Tag_ID.SDO_MEMBERDANCE_CLOSE_RESP:// = 0x878068,

                    case CEnum.Message_Tag_ID.SDO_PADKEYWORD_QUERY:// = 0x870070,
                    case CEnum.Message_Tag_ID.SDO_PADKEYWORD_QUERY_RESP:// = 0x878070,
                    case CEnum.Message_Tag_ID.SDO_BOARDTASK_QUERY:
                    case CEnum.Message_Tag_ID.SDO_BOARDTASK_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_BOARDTASK_UPDATE:
                    case CEnum.Message_Tag_ID.SDO_BOARDTASK_UPDATE_RESP:
                    case CEnum.Message_Tag_ID.SDO_DAYSLIMIT_QUERY:
                    case CEnum.Message_Tag_ID.SDO_DAYSLIMIT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_INSERTALL:
                    case CEnum.Message_Tag_ID.SDO_CHALLENGE_INSERTALL_RESP:
                    case CEnum.Message_Tag_ID.SDO_USER_PUNISH:
                    case CEnum.Message_Tag_ID.SDO_USER_PUNISH_RESP:
                    case CEnum.Message_Tag_ID.SDO_PUNISHUSER_IMPORT_QUERY:
                    case CEnum.Message_Tag_ID.SDO_PUNISHUSER_IMPORT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_PUNISHUSER_IMPORT:
                    case CEnum.Message_Tag_ID.SDO_PUNISHUSER_IMPORT_RESP:
                    case CEnum.Message_Tag_ID.SDO_USER_PUNISHALL:
                    case CEnum.Message_Tag_ID.SDO_USER_PUNISHALL_RESP:
                    case CEnum.Message_Tag_ID.SDO_FRAGMENT_QUERY:
                    case CEnum.Message_Tag_ID.SDO_FRAGMENT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_FRAGMENT_UPDATE:
                    case CEnum.Message_Tag_ID.SDO_FRAGMENT_UPDATE_RESP:
                    case CEnum.Message_Tag_ID.SDO_USERMARRIAGE_QUERY:// = 0x870095,
                    case CEnum.Message_Tag_ID.SDO_USERMARRIAGEQUERY_RESP:// = 0x878095,
                    case CEnum.Message_Tag_ID.SDO_PUNISH_UPDATE_QUERY:
                    case CEnum.Message_Tag_ID.SDO_PUNISH_UPDATE_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_REMAINCASH_QUERY:// = 0x870097,
                    case CEnum.Message_Tag_ID.SDO_REMAINCASH_QUERY_RESP:// = 0x878097,
                    case CEnum.Message_Tag_ID.CARD_UserCashExp_Query:
                    case CEnum.Message_Tag_ID.CARD_UserCashExp_Query_RESP:
                    case CEnum.Message_Tag_ID.SDO_RewardItem_QUERY:
                    case CEnum.Message_Tag_ID.SDO_RewardItem_QUERY_RESP:
                    case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_CLOSE:// = 0x930015,//封停帐户的权限信息
                    case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_CLOSE_RESP:// = 0x938015,//封停帐户的权限信息响应
                    case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_OPEN:// = 0x930016,//解封帐户的权限信息
                    case CEnum.Message_Tag_ID.O2JAM2_ACCOUNT_OPEN_RESP:// = 0x938016,//解封帐户的权限信息响应
                    case CEnum.Message_Tag_ID.O2JAM2_MEMBERBANISHMENT_QUERY:
                    case CEnum.Message_Tag_ID.O2JAM2_MEMBERBANISHMENT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.O2JAM2_MEMBERSTOPSTATUS_QUERY:
                    case CEnum.Message_Tag_ID.O2JAM2_MEMBERSTOPSTATUS_QUERY_RESP:
                    case CEnum.Message_Tag_ID.O2JAM2_MEMBERLOCAL_BANISHMENT:
                    case CEnum.Message_Tag_ID.O2JAM2_MEMBERLOCAL_BANISHMENT_RESP:
                    case CEnum.Message_Tag_ID.O2JAM2_USERLOGIN_DELETE:
                    case CEnum.Message_Tag_ID.O2JAM2_USERLOGIN_DELETE_RESP:
                    case CEnum.Message_Tag_ID.SDO_USERPASSWD_QUERY:// = 0x870082,
                    case CEnum.Message_Tag_ID.SDO_USERPASSWD_QUERY_RESP:// = 0x878082,
                    case CEnum.Message_Tag_ID.SDO_QueryDeleteItem_QUERY:
                    case CEnum.Message_Tag_ID.SDO_QueryDeleteItem_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_NotReachMoney_Query:
                    case CEnum.Message_Tag_ID.SDO_NotReachMoney_Query_RESP:
                    case CEnum.Message_Tag_ID.CARD_USERNUM_ADVANCE_QUERY:
                    case CEnum.Message_Tag_ID.CARD_USERNUM_ADVANCE_QUERY_RESP:

                    case CEnum.Message_Tag_ID.SOCCER_CHARACTERINFO_QUERY:
                    case CEnum.Message_Tag_ID.SOCCER_CHARACTERINFO_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_CHARCHECK_QUERY:
                    case CEnum.Message_Tag_ID.SOCCER_CHARCHECK_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_CHARITEMS_RECOVERY_QUERY:
                    case CEnum.Message_Tag_ID.SOCCER_CCHARITEMS_RECOVERY_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_CHARPOINT_QUERY:
                    case CEnum.Message_Tag_ID.SOCCER_CHARPOINT_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_DELETEDCHARACTERINFO_QUERY:
                    case CEnum.Message_Tag_ID.SOCCER_DELETEDCHARACTERINFO_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_CHARACTERSTATE_MODIFY://停封角色
                    case CEnum.Message_Tag_ID.SOCCER_CHARACTERSTATE_MODIFY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_ACCOUNTSTATE_MODIFY://停封玩家
                    case CEnum.Message_Tag_ID.SOCCER_ACCOUNTSTATE_MODIFY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_CHARACTERSTATE_QUERY://停封角色查询
                    case CEnum.Message_Tag_ID.SOCCER_CHARACTERSTATE_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_ACCOUNTSTATE_QUERY://停封玩家查询
                    case CEnum.Message_Tag_ID.SOCCER_ACCOUNTSTATE_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_ACCOUNTACTIVE_QUERY://玩家激活查询		
                    case CEnum.Message_Tag_ID.SOCCER_ACCOUNTACTIVE_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_USERTRADE_QUERY://玩家道具购买记录，赠送记录
                    case CEnum.Message_Tag_ID.SOCCER_USERTRADE_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SOCCER_ITEM_SKILL_MODIFY://删除角色道具、技能
                    case CEnum.Message_Tag_ID.SOCCER_ITEM_SKILL_MODIFY_RESP://删除角色道具、技能
                    case CEnum.Message_Tag_ID.SOCCER_ACCOUNT_ITEMSKILL_QUERY://玩家身上的道具、技能
                    case CEnum.Message_Tag_ID.SOCCER_ACCOUNT_ITEMSKILL_QUER_RESPY://玩家身上的道具、技能 
                    case CEnum.Message_Tag_ID.SOCCER_CHARINFO_MODIFY: //玩家角色信息修改
                    case CEnum.Message_Tag_ID.SOCCER_CHARINFO_MODIFY_RESPY: //玩家角色信息修改
                        
                    case CEnum.Message_Tag_ID.SOCCER_ITEMSHOP_INSERT://给玩家赠送道具
                    case CEnum.Message_Tag_ID.SOCCER_ITEMSHOP_INSERT_RESPY://给玩家赠送道具
                    case CEnum.Message_Tag_ID.CARD_USER_QUERY://玩家基本信息查询
                    case CEnum.Message_Tag_ID.CARD_USER_QUERY_RESP:

                    case CEnum.Message_Tag_ID.SOCCER_ITEM_SKILL_QUERY://获得角色道具、技能
                    case CEnum.Message_Tag_ID.SOCCER_ITEM_SKILL_QUERY_RESP://获得角色道具、技能
                    case CEnum.Message_Tag_ID.SOCCER_ITEM_SKILL_BLUR_QUERY:// = 0x940017,//获得角色道具、技能
                    case CEnum.Message_Tag_ID.SOCCER_ITEM_SKILL_BLUR_QUERY_RESP:// = 0x948017,//获得角色道具、技能

                    case CEnum.Message_Tag_ID.FJ_CharacterInfo_Query:
                    case CEnum.Message_Tag_ID.FJ_CharacterInfo_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_ItemShop_Query:
                    case CEnum.Message_Tag_ID.FJ_ItemShop_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_Message_Query:
                    case CEnum.Message_Tag_ID.FJ_Message_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_WareHouse_Query:
                    case CEnum.Message_Tag_ID.FJ_WareHouse_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_Login_Query:
                    case CEnum.Message_Tag_ID.FJ_Login_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_Login_Out_Update:
                    case CEnum.Message_Tag_ID.FJ_Login_Out_Update_Resp:
                    case CEnum.Message_Tag_ID.FJ_PlayPosition_Query:
                    case CEnum.Message_Tag_ID.FJ_PlayPosition_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_ItemShop_Del:
                    case CEnum.Message_Tag_ID.FJ_ItemShop_Del_Resp:
                    case CEnum.Message_Tag_ID.FJ_AccountActive_Query:
                    case CEnum.Message_Tag_ID.FJ_AccountActive_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_ActiveCode_Query:
                    case CEnum.Message_Tag_ID.FJ_ActiveCode_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_ItemShop_Insert:
		            case CEnum.Message_Tag_ID.FJ_ItemShop_Insert_Resp:
		            case CEnum.Message_Tag_ID.FJ_Wedding_Query:
		            case CEnum.Message_Tag_ID.FJ_Wedding_Query_Resp:
		            case CEnum.Message_Tag_ID.FJ_Wedding_Create:
		            case CEnum.Message_Tag_ID.FJ_Wedding_Create_Resp:
		            case CEnum.Message_Tag_ID.FJ_Wedding_Delete:
		            case CEnum.Message_Tag_ID.FJ_Wedding_Delete_Resp:
		            case CEnum.Message_Tag_ID.FJ_Task_Query:
		            case CEnum.Message_Tag_ID.FJ_Task_Query_Resp:
		            case CEnum.Message_Tag_ID.FJ_PlayerLevelMoney_Query:
		            case CEnum.Message_Tag_ID.FJ_PlayerLevelMoney_Query_Resp:
		            case CEnum.Message_Tag_ID.FJ_Guild_Query:
		            case CEnum.Message_Tag_ID.FJ_Guild_Query_Resp:
		            case CEnum.Message_Tag_ID.FJ_Guild_Create:
                    case CEnum.Message_Tag_ID.FJ_Guild_Create_Resp:
		            case CEnum.Message_Tag_ID.FJ_Guild_Delete:
		            case CEnum.Message_Tag_ID.FJ_Guild_Delete_Resp:
		            case CEnum.Message_Tag_ID.FJ_SocialRelate_Query:
		            case CEnum.Message_Tag_ID.FJ_SocialRelate_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_SocialRelate_Create:
		            case CEnum.Message_Tag_ID.FJ_SocialRelate_Create_Resp:
		            case CEnum.Message_Tag_ID.FJ_SocialRelate_Delete:
		            case CEnum.Message_Tag_ID.FJ_SocialRelate_Delete_Resp:
		            case CEnum.Message_Tag_ID.FJ_UserBan_Query:
		            case CEnum.Message_Tag_ID.FJ_UserBan_Query_Resp:
		            case CEnum.Message_Tag_ID.FJ_UserBan_Close:
		            case CEnum.Message_Tag_ID.FJ_UserBan_Close_Resp:
		            case CEnum.Message_Tag_ID.FJ_UserBan_Open:
		            case CEnum.Message_Tag_ID.FJ_UserBan_Open_Resp:
		            case CEnum.Message_Tag_ID.FJ_PlayerSkill_Insert:
		            case CEnum.Message_Tag_ID.FJ_PlayerSkill_Insert_Resp:
		            case CEnum.Message_Tag_ID.FJ_PlayerSkill_Update:
		            case CEnum.Message_Tag_ID.FJ_PlayerSkill_Update_Resp:
		            case CEnum.Message_Tag_ID.FJ_PlayerSkill_Delete:
		            case CEnum.Message_Tag_ID.FJ_PlayerSkill_Delete_Resp:
		            case CEnum.Message_Tag_ID.FJ_CharacterInfo_Update:
		            case CEnum.Message_Tag_ID.FJ_CharacterInfo_Update_Resp:
                    case CEnum.Message_Tag_ID.FJ_ShortCut_Query:
                    case CEnum.Message_Tag_ID.FJ_ShortCut_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_Message_Batch_Insert:
                    case CEnum.Message_Tag_ID.FJ_Message_Batch_Insert_Resp:
                    case CEnum.Message_Tag_ID.FJ_PlayerPwd_Update:
                    case CEnum.Message_Tag_ID.FJ_PlayerPwd_Update_Resp:
                    case CEnum.Message_Tag_ID.FJ_Task_Insert:
                    case CEnum.Message_Tag_ID.FJ_Task_Insert_Resp:
                    case CEnum.Message_Tag_ID.FJ_Task_Delete:
                    case CEnum.Message_Tag_ID.FJ_Task_Delete_Resp:
                    case CEnum.Message_Tag_ID.FJ_Task_Update:
                    case CEnum.Message_Tag_ID.FJ_Task_Update_Resp:
                    case CEnum.Message_Tag_ID.FJ_Delete_Character:
                    case CEnum.Message_Tag_ID.FJ_Delete_Character_Resp:
                    case CEnum.Message_Tag_ID.FJ_Recovery_Character:
                    case CEnum.Message_Tag_ID.FJ_Recovery_Character_Resp:
                    case CEnum.Message_Tag_ID.FJ_Guild_QueryAll:
                    case CEnum.Message_Tag_ID.FJ_Guild_QueryAll_RESP:
                    case CEnum.Message_Tag_ID.FJ_PlayerSkill_Query:
                    case CEnum.Message_Tag_ID.FJ_PlayerSkill_Query_Resp:
            		case CEnum.Message_Tag_ID.FJ_PWD_Recover:
                    case CEnum.Message_Tag_ID.FJ_PWD_Recover_Resp:
                    case CEnum.Message_Tag_ID.NOTDEFINED:// 0x0:
                    case CEnum.Message_Tag_ID.ERROR:// 0xFFFFFF:		
                    case CEnum.Message_Tag_ID.FJ_GS_Query:
		            case CEnum.Message_Tag_ID.FJ_GS_Query_Resp:
		            case CEnum.Message_Tag_ID.FJ_BoardList_Query:
		            case CEnum.Message_Tag_ID.FJ_BoardList_Query_Resp:
		            case CEnum.Message_Tag_ID.FJ_BoardList_Insert:
		            case CEnum.Message_Tag_ID.FJ_BoardList_Insert_Resp:
		            case CEnum.Message_Tag_ID.FJ_BoardList_Delete:
                    case CEnum.Message_Tag_ID.FJ_BoardList_Delete_Resp:
                    case CEnum.Message_Tag_ID.FJ_SkillList_Query:
                    case CEnum.Message_Tag_ID.FJ_SkillList_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_TempPassword_Query:
                    case CEnum.Message_Tag_ID.FJ_TempPassword_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_Currank_Query:
                    case CEnum.Message_Tag_ID.FJ_Currank_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_MAP_Query:
                    case CEnum.Message_Tag_ID.FJ_MAP_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_PlayPosition_Update:
                    case CEnum.Message_Tag_ID.FJ_PlayPosition_Update_Resp:
                    case CEnum.Message_Tag_ID.FJ_QuestTable_Query:
                    case CEnum.Message_Tag_ID.FJ_QuestTable_Query_Resp:
            		case CEnum.Message_Tag_ID.FJ_ItemShop_Style_Query:
                    case CEnum.Message_Tag_ID.FJ_ItemShop_Style_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_ItemShop_QueryAll:
                    case CEnum.Message_Tag_ID.FJ_ItemShop_QueryAll_Resp:
                    case CEnum.Message_Tag_ID.FJ_ItemAppend_Style_Query:
                    case CEnum.Message_Tag_ID.FJ_ItemAppend_Style_Query_Resp:
                    case CEnum.Message_Tag_ID.FJ_ItemAppend_Query:
                    case CEnum.Message_Tag_ID.FJ_ItemAppend_Query_Resp:

                    case CEnum.Message_Tag_ID.FJ_ItemAppendList_Query:
                    case CEnum.Message_Tag_ID.FJ_ItemAppendList_Query_Resp:

                    case CEnum.Message_Tag_ID.FJ_ItemLog_Query:
                    case CEnum.Message_Tag_ID.FJ_ItemLog_Query_Resp:

                    case CEnum.Message_Tag_ID.FJ_ItemLogType_Query:
                    case CEnum.Message_Tag_ID.FJ_ItemLogType_Query_Resp:
                    case CEnum.Message_Tag_ID.RC_Character_Query:
                    case CEnum.Message_Tag_ID.RC_Character_Query_Resp:
                    case CEnum.Message_Tag_ID.RC_UserLoginOut_Query :
                    case CEnum.Message_Tag_ID.RC_UserLoginOut_Query_Resp:
                    case CEnum.Message_Tag_ID.RC_UserLogin_Del:
                    case CEnum.Message_Tag_ID.RC_UserLogin_Del_Resp:
                    case CEnum.Message_Tag_ID.RC_RcCode_Query:
                    case CEnum.Message_Tag_ID.RC_RcCode_Query_Resp:

    		        case CEnum.Message_Tag_ID.RC_RcUser_Query:
                    case CEnum.Message_Tag_ID.RC_RcUser_Query_Resp:
                    case CEnum.Message_Tag_ID.SDO_PADREGIST_QUERY:
                    case CEnum.Message_Tag_ID.SDO_PADREGIST_QUERY_RESP:
                    case CEnum.Message_Tag_ID.SDO_MiniDancerTime_QUERY:
                    case CEnum.Message_Tag_ID.SDO_MiniDancerTime_QUERY_RESP:
                    case CEnum.Message_Tag_ID.CARD_QueryUseDetailExp_Query:
                    case CEnum.Message_Tag_ID.CARD_QueryUseDetailExp_RESP:
                    case CEnum.Message_Tag_ID.SDO_QueryPunishusertimes_QUERY:
                    case CEnum.Message_Tag_ID.SDO_QueryPunishusertimes_QUERY_RESP:
                    case CEnum.Message_Tag_ID.CARD_MOBILEINFO_QUERY:
                    case CEnum.Message_Tag_ID.CARD_MOBILEINFO_QUERY_RESP:
                    case CEnum.Message_Tag_ID.CARD_TOKENPASSWD_SYNC:
                    case CEnum.Message_Tag_ID.CARD_TOKENPASSWD_SYNC_RESP:
                    case CEnum.Message_Tag_ID.CARD_MOBILEINFO_UPDATE:
                    case CEnum.Message_Tag_ID.CARD_MOBILEINFO_UPDATE_RESP:
                    case CEnum.Message_Tag_ID.CARD_USERCARDHISTORY_QUERY:
                    case CEnum.Message_Tag_ID.CARD_USERCARDHISTORY_QUERY_RESP:
                    case CEnum.Message_Tag_ID.CARD_USERACTIVETOKEN_QUERY:
                    case CEnum.Message_Tag_ID.CARD_USERACTIVETOKEN_QUERY_RESP:



                        #region 解析数据行和字段
                        int iCount = 0;		//重复个数

                        System.Collections.ArrayList t_StructCount = mPacketbody.m_TLVList;
                        System.Collections.ArrayList t_StructUsed = (System.Collections.ArrayList)t_StructCount.Clone();

                        for (int i = 0; i < t_StructCount.Count; i++)
                        {
                            for (int j = i + 1; j < t_StructCount.Count; j++)
                            {
                                if (((TLV_Structure)t_StructCount[i]).m_Tag != ((TLV_Structure)t_StructCount[j]).m_Tag)
                                {
                                    iCount++;
                                    t_StructCount.RemoveAt(j);
                                    j--;
                                }
                            }
                        }

                        //无记录判断
                        if (t_StructCount.Count == 0)
                        {
                            p_ReturnBody = new CEnum.Message_Body[1, 1];
                            p_ReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                            p_ReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
                            p_ReturnBody[0, 0].oContent = "无数据!";

                            return p_ReturnBody;
                        }
                        iField = t_StructUsed.Count / t_StructCount.Count;
                        #endregion

                        p_ReturnBody = new CEnum.Message_Body[t_StructUsed.Count - iCount, iField];

                        #region 消息解析 -- 数组消息
                        int iTemp = 0;
                        for (int i = 0; i < t_StructCount.Count; i++)
                        {
                            for (int j = i * iField; j < t_StructUsed.Count; j++)
                            {
                                //设置字段标签
                                if (iTemp == iField)
                                {
                                    iTemp = 0;
                                    break;
                                }

                                TLV_Structure mStruct = (TLV_Structure)t_StructUsed[j];

                                p_ReturnBody[i, iTemp].eName = mStruct.m_Tag;
                                p_ReturnBody = DecodeRecive(i, iTemp, mStruct, p_ReturnBody);

                                iTemp++;
                            }
                        }
                        #endregion

                        break;
                }
                #endregion

                return p_ReturnBody;
            }
            catch (Exception e)
            {
                p_ReturnBody = new CEnum.Message_Body[1, 1];
                p_ReturnBody[0, 0].eName = CEnum.TagName.ERROR_Msg;
                p_ReturnBody[0, 0].eTag = CEnum.TagFormat.TLV_STRING;
                p_ReturnBody[0, 0].oContent = "数据解析异常";

                CEnum.TLogData tLogData = new CEnum.TLogData();

                tLogData.iSort = 5;
                tLogData.strDescribe = "解析Socket消息失败!";
                tLogData.strException = e.Message;

                return p_ReturnBody;
            }

        }
        #endregion
    }
}
