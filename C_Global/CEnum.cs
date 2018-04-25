using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace C_Global
{
    public class CEnum
    {
        #region Socket 消息定义
        /// <summary>
        /// 参数内容标签
        /// </summary>
        public enum TagName : ushort
        {
            ///////////////////////////////////////////////////////////////////////
            UserName = 0x0101, //Format:STRING 用户名
            PassWord = 0x0102, //Format:STRING 密码
            MAC = 0x0103, //Format:STRING  MAC码
            Limit = 0x0104,//Format:DateTime GM帐号使用时效
            User_Status = 0x0105,//Format:INT 状态信息
            UserByID = 0x0106,//Format:INT 操作员ID
            RealName = 0x0107,//Format:STRING 中文名
            DepartID = 0x0108,//Format:INT 部门ID
            DepartName = 0x0109,//Format:STRING 部门名称
            DepartRemark = 0x0110,//Format:STRING 部门描述
            OnlineActive = 0x0111,//Format:Integer 在线状态
            UpdateFileName = 0x0112,//Format:String 文件名
            UpdateFileVersion = 0x0113,//Format:String 文件版本
            UpdateFilePath = 0x0114,//Format:String 文件路径
            UpdateFileSize = 0x0115,//Format:Integer 文件大小

            Process_Reason = 0x060B,//Format tring
            ///////////////////////////////////////////////////////////////////////
            GameID = 0x0200, //Format:INTEGER 消息ID
            ModuleName = 0x0201, //Format:STRING 模块名称
            ModuleClass = 0x0202, //Format:STRING 模块分类
            ModuleContent = 0x0203, //Format:STRING 模块描述
            ///////////////////////////////////////////////////////////////////////
            Module_ID = 0x0301, //Format:INTEGER 模块ID
            User_ID = 0x0302, //Format:INTEGER 用户ID
            ModuleList = 0x0303, //Format:String 模块列表
            SysAdmin = 0x0116,//Format:Integer 是否是系统管理员
            ///////////////////////////////////////////////////////////////////////
            Host_Addr = 0x0401, //Format:STRING
            Host_Port = 0x0402, //Format:STRING
            Host_Pat = 0x0403,  //Format:STRING
            Conn_Time = 0x0404, //Format:DateTime 请求和响应时间
            Connect_Msg = 0x0405,//Format:STRING 请求连接信息
            DisConnect_Msg = 0x0406,//Format:STRING	 请求端开信息
            Author_Msg = 0x0407, //Format:STRING 验证用户的信息
            Status = 0x0408,//Format:STRING 操作结果
            Index = 0x0409, //Format:Integer 记录集序号
            PageSize = 0x0410,//Format:Integer 记录页显示长度
            PageCount = 0x0411,//Format:Integer 显示总页数
            SP_Name = 0x0412,//Format:Integer 存储过程名
            Real_ACT = 0x0413,//Format:String 操作的内容
            ACT_Time = 0x0414,//Format:TimeStamp 操作时间
            BeginTime = 0x0415,//Format:Date 开始日期
            EndTime = 0x0416,//Format:Date 结束日期
            ///////////////////////////////////////////////////////////////////////
            GameName = 0x0501, //Format:STRING 游戏名称
            GameContent = 0x0502, //Format:STRING 消息描述
            ///////////////////////////////////////////////////////////////////////
            Letter_ID = 0x0601, //Format:Integer 
            Letter_Sender = 0x0602, //Format:String
            Letter_Receiver = 0x0603, //Format:String
            Letter_Subject = 0x0604, //Format:String
            Letter_Text = 0x0605, //Format:String
            Send_Date = 0x0606, //Format:Date
            Process_Man = 0x0607, //Format:Integer
            Process_Date = 0x0608, //Format:Date
            Transmit_Man = 0x0609, //Format:Integer
            Is_Process = 0x060A, //Format:Integer
            LINKER_NAME = 0x0613,
            LINKER_CONTENT = 0x0614,
            NOTES_UID = 0x0615,
            NOTES_SUBJECT = 0x0616,
            NOTES_FROM = 0x0617,
            NOTES_DATE = 0x0618,
            NOTES_SUPERVISORS = 0x0619,
            NOTES_CONTENT = 0x0620,
            NOTES_SCRETVISORS = 0x0621,
            NOTES_RECEIVER = 0x0622,
            NOTES_Sender = 0x0623,
            NOTES_PUID = 0x0624,
            NOTES_AttachmentCount = 0x0625,
            NOTES_View = 0x0626,
            NOTES_ID = 0x0627,
            NOTES_Category = 0x0628,
            Notes_AttachmentName = 0x0629,
            NOTES_Attachment = 0x0630,
            NOTES_Flag = 0x0631,
            NOTES_Status = 0x0632,
            ///////////////////////////////////////////////////////////////////////
            MJ_Level = 0x0701, //Format:Integer 玩家等级
            MJ_Account = 0x0702, //Format:String 玩家帐号
            MJ_CharName = 0x0703, //Format:String 玩家呢称
            MJ_Exp = 0x0704, //Format:Integer 玩家当前经验
            MJ_Exp_Next_Level = 0x0705, //Format:Integer 玩家下次升级的经验 
            MJ_HP = 0x0706, //Format:Integer 玩家HP值
            MJ_HP_Max = 0x0707, //Format:Integer 玩家最大的HP值
            MJ_MP = 0x0708, //Format:Integer 玩家MP值
            MJ_MP_Max = 0x0709, //Format:Integer 玩家最大的MP值
            MJ_DP = 0x0710, //Format:Integer 玩家DP值
            MJ_DP_Increase_Ratio = 0x0711, //Format:Integer 玩家最大的DP值
            MJ_Exception_Dodge = 0x0712, //Format:Integer 异常状态回避
            MJ_Exception_Recovery = 0x0713, //Format:Integer 异常状态回复
            MJ_Physical_Ability_Max = 0x0714, //Format:Integer 物理能力最大值
            MJ_Physical_Ability_Min = 0x0715, //Format:Integer 物理能力最小值
            MJ_Magic_Ability_Max = 0x0716, //Format:Integer 魔法能力最大值
            MJ_Magic_Ability_Min = 0x0717, //Format:Integer 魔法能力最小值
            MJ_Tao_Ability_Max = 0x0718, //Format:Integer 道术能力最大值
            MJ_Tao_Ability_Min = 0x0719, //Format:Integer 道术能力最小值
            MJ_Physical_Defend_Max = 0x0720, //Format:Integer 物防最大值
            MJ_Physical_Defend_Min = 0x0721, //Format:Integer 物防最小值
            MJ_Magic_Defend_Max = 0x0722, //Format:Integer 魔防最大值
            MJ_Magic_Defend_Min = 0x0723, //Format:Integer 魔防最小值
            MJ_Accuracy = 0x0724, //Format:Integer 命中率
            MJ_Phisical_Dodge = 0x0725, //Format:Integer 物理回避率
            MJ_Magic_Dodge = 0x0726, //Format:Integer 魔法回避率
            MJ_Move_Speed = 0x0727, //Format:Integer 移动速度
            MJ_Attack_speed = 0x0728, //Format:Integer 攻击速度
            MJ_Max_Beibao = 0x0729, //Format:Integer 背包上限
            MJ_Max_Wanli = 0x0730, //Format:Integer 腕力上限
            MJ_Max_Fuzhong = 0x0731, //Format:Integer 负重上限
            MJ_PASSWD = 0x0732,//Format:String 玩家密码
            MJ_ServerIP = 0x0733,//Format:String 玩家所在服务器
            MJ_TongID = 0x0734,//Format:Integer 帮会ID
            MJ_TongName = 0x0735,//Format:String 帮会名称
            MJ_TongLevel = 0x0736,//Format:Integer 帮会等级
            MJ_TongMemberCount = 0x0737,//Format:Integer 帮会人数
            MJ_Money = 0x0738,//Format:Money 玩家金钱
            MJ_TypeID = 0x0739,//Format:Integer 玩家角色类型ID
            MJ_ActionType = 0x0740,//Format:Integer 玩家ID
            MJ_Time = 0x0741,//Format:TimeStamp  操作时间
            MJ_CharIndex = 0x0742,//玩家索引号
            MJ_CharName_Prefix = 0x0743,//玩家帮会名称
            MJ_Exploit_Value = 0x0744,//玩家功勋值
            MJ_Reason = 0x0745,//停封理由
            CARD_CRTIME = 0x2312,

            ///////////////////////////////////////////////////////////////////////
            SDO_ServerIP = 0x0801,//Format:String 大区IP
            SDO_UserIndexID = 0x0802,//Format:Integer 玩家用户ID
            SDO_Account = 0x0803,//Format:String 玩家的帐号
            SDO_Level = 0x0804,//Format:Integer 玩家的等级
            SDO_Exp = 0x0805,//Format:Integer 玩家的当前经验值
            SDO_GameTotal = 0x0806,//Format:Integer 总局数
            SDO_GameWin = 0x0807,//Format:Integer 胜局数
            SDO_DogFall = 0x0808,//Format:Integer 平局数
            SDO_GameFall = 0x0809,//Format:Integer 负局数
            SDO_Reputation = 0x0810,//Format:Integer 声望值
            SDO_GCash = 0x0811,//Format:Integer G币
            SDO_MCash = 0x0812,//Format:Integer M币
            SDO_Address = 0x0813,//Format:Integer 地址
            SDO_Age = 0x0814,//Format:Integer 年龄
            SDO_ProductID = 0x0815,//Format:Integer 商品编号
            SDO_ProductName = 0x0816,//Format:String 商品名称
            SDO_ItemCode = 0x0817,//Format:Integer 道具编号
            SDO_ItemName = 0x0818,//Format:String 道具名称
            SDO_TimesLimit = 0x0819,//Format:Integer 使用次数
            SDO_DateLimit = 0x0820,//Format:Integer 使用时效
            SDO_MoneyType = 0x0821,//Format:Integer 货币类型
            SDO_MoneyCost = 0x0822,//Format:Integer 道具的价格
            SDO_ShopTime = 0x0823,//Format:DateTime 消费时间
            SDO_MAINCH = 0x0824,//Format:Integer 服务器
            SDO_SUBCH = 0x0825,//Format:Integer 房间
            SDO_Online = 0x0826,//Format:Integer 是否在线
            SDO_LoginTime = 0x0827,//Format:DateTime 上线时间
            SDO_LogoutTime = 0x0828,//Format:DateTime 下线时间
            SDO_AREANAME = 0x0829,//Format:String 大区名字
            SDO_City = 0x0830,//Format:String 玩家所住城市
            SDO_Title = 0x0831,//Format:String 道具主题
            SDO_Context = 0x0832,//Format:String 道具描述
            SDO_MinLevel = 0x0833,//Format:Integer 所带道具的最小等级
            SDO_ActiveStatus = 0x0834,//Format:Integer 激活状态
            SDO_StopStatus = 0x0835,//Format:Integer 封停状态
            SDO_NickName = 0x0836,//Format:String 呢称
            SDO_9YouAccount = 0x0837,//Format:Integer 9you的帐号
            SDO_SEX = 0x0838,//Format:Integer 性别
            SDO_RegistDate = 0x0839,//Format:Date 注册日期
            SDO_FirstLogintime = 0x0840,//Format:Date 第一次登录时间
            SDO_LastLogintime = 0x0841,//Format:Date 最后一次登录时间
            SDO_Ispad = 0x0842,//Format:Integer 是否已注册跳舞毯
            SDO_Desc = 0x0843,//Format:String 道具描述
            SDO_Postion = 0x0844,//Format:Integer 道具位置
            SDO_BeginTime = 0x0845,//Format:Date 消费记录开始时间
            SDO_EndTime = 0x0846,//Format:Date 消费记录结束时间
            SDO_SendTime = 0x0847,//Format:Date 道具送人日期
            SDO_SendIndexID = 0x0848,//Format:Integer 发送人的ID
            SDO_SendUserID = 0x0849,//Format:String 发送人帐号
            SDO_ReceiveNick = 0x0850,//Format:String 接受人呢称
            SDO_BigType = 0x0851,//Format:Integer 道具大类
            SDO_SmallType = 0x0852,//Format:Integer 道具小类
            SDO_REASON = 0x0853,//Format:String 停封理由
            SDO_StopTime = 0x0854,//Format:TimeStamp 停封时间
            SDO_DaysLimit = 0x0855,//Format:Integer 使用天数
            SDO_Email = 0x0856,//Format:String 邮件
            SDO_ChargeSum = 0x0857,//Format:String 充值合计
            SDO_KeyID = 0x0885,
            SDO_KeyWord = 0x0886,
            SDO_MasterID = 0x0887,
            SDO_Master = 0x0888,
            SDO_SlaverID = 0x0889,
            SDO_Slaver = 0x0890,
            SDO_ChannelList = 0x0891,
            SDO_BoardMessage = 0x0892,

            SDO_wPlanetID = 0x0893,
            SDO_wChannelID = 0x0894,
            SDO_iLimitUser = 0x0895,
            SDO_iCurrentUser = 0x0896,
            SDO_ipaddr = 0x0897,
            SDO_Interval = 0x0898,
            SDO_TaskID = 0x0899,
            SDO_Status = 0x08100,
            SDO_Score = 0x08101,//积分
            SDO_FirstPadTime = 0x08102,//跳舞毯第一次使用时间
            SDO_BanDate = 0x08103,//停封多少天
            SDO_Passwd = 0x08104,
            SDO_OnlineTime = 0x08105,//在线时间string
            SDO_LevPercent = 0x08106,
            SDO_ItemCodeBy = 0x08107,
            SDO_Punish_Status = 0x08108,
            SDO_fragment_num = 0x08110,
            SDO_fragment_id = 0x08109,// 
            SDO_BuyTimes = 0x08111,
            SDO_CoupleIndexID = 0x08112,
            SDO_CoupleNickName = 0x08113,
            SDO_RingLevel = 0x08114,
            SDO_NewRingLevel = 0x08115,
            SDO_MarriageApp_Date = 0x08116,
            SDO_DivorceApp_Date = 0x08117,
            SDO_Marriage_Date = 0x08118,
            SDO_Divorce_Date = 0x08119,
            SDO_RewardItemTime = 0x08126,
            SDO_PCash = 0x08130,

            ServerInfo_IP = 0x0901,//Format:String 服务器IP
            ServerInfo_City = 0x0902,//Format:String 城市
            ServerInfo_GameID = 0x0903,//Format:Integer 游戏ID
            ServerInfo_GameName = 0x0904,//Format:String 游戏名
            ServerInfo_GameDBID = 0x0905,//Format:Integer 游戏数据库类型
            ServerInfo_GameFlag = 0x0906,//Format:Integer 游戏服务器状态
            ServerInfo_Idx = 0x0907,
            ServerInfo_DBName = 0x0908,
            SDO_PunishTimes = 0x08127,
            SDO_DelTimes = 0x08128,
            SDO_DATE = 0x08129,
            ///////////////////////////////////////////////////////////////////////
            /// <summary>
            /// 劲舞团定义
            /// </summary>
            AU_ACCOUNT = 0x1001,//玩家帐号 Format:String
            AU_UserNick = 0x1002,//玩家呢称 Format:String
            AU_Sex = 0x1003,//玩家性别 Format:Integer
            AU_State = 0x1004,//玩家状态 Format:Integer
            AU_STOPSTATUS = 0x1005,//劲舞者封停状态 Format:Integer
            AU_Reason = 0x1006,//封停理由 Format:String
            AU_BanDate = 0x1007,//封停日期 Format:TimeStamp
            AU_ServerIP = 0x1008,//劲舞团游戏服务器 Format:String
            AU_Id9you = 0x1009, //Format:Integer 9youID
            AU_UserSN = 0x1010, //Format:Integer 用户序列号
            AU_EquipState = 0x1011, //Format:String 
            AU_AvatarItem = 0x1012, //Format:Integer
            AU_BuyNick = 0x1013, //Format:String 购买呢称
            AU_BuyDate = 0x1014,//Format:Timestamp 购买日期
            AU_ExpireDate = 0x1015,//Format:TimesStamp  过期日期
            AU_BuyType = 0x1016, // Format:Integer 购买类型

            AU_PresentID = 0x1017, //Format:Integer 赠送ID
            AU_SendSN = 0x1018, //Format:Integer  赠送SN
            AU_SendNick = 0x1019, //Format:String 赠送呢称
            AU_RecvSN = 0x1020, //Format:String 接受人SN
            AU_RecvNick = 0x1021, //Format:String 接受人呢称
            AU_Kind = 0x1022, //Format:Integer 类型
            AU_ItemID = 0x1023, //Format:Integer 道具ID
            AU_Period = 0x1024, //Format:Integer 期间
            AU_BeforeCash = 0x1025, //Format:Integer 消费之前金额
            AU_AfterCash = 0x1026, //Format:Integer 消费之后金额
            AU_SendDate = 0x1027, //Format:TimeStamp 发送日期
            AU_RecvDate = 0x1028,//Format:TimeStamp 接受日期
            AU_Memo = 0x1029,//Format:String 备注
            AU_UserID = 0x1030, //Format:String 玩家ID
            AU_Exp = 0x1031, //Format:Integer 玩家经验
            AU_Point = 0x1032, //Format:Integer 玩家位置
            AU_Money = 0x1033, //Format:Integer 金钱
            AU_Cash = 0x1034, //Format:Integer 现金
            AU_Level = 0x1035, //Format:Integer 等级
            AU_Ranking = 0x1036, //Format:Integer 银行
            AU_IsAllowMsg = 0x1037, //Format:Integer 允许发消息
            AU_IsAllowInvite = 0x1038, //Format:Integer 允许邀请
            AU_LastLoginTime = 0x1039, //Format:TimeStamp 最后登录时间
            AU_Password = 0x1040, //Format:String 密码
            AU_UserName = 0x1041, //Format:String 用户名
            AU_UserGender = 0x1042, //Format:String 
            AU_UserPower = 0x1043, //Format:Integer
            AU_UserRegion = 0x1044, //Format:String 
            AU_UserEMail = 0x1045, //Format:String 用户电子邮件
            AU_RegistedTime = 0x1046, //Format:TimeStamp 注册时间


            AU_ItemName = 0x1047,//道具名
            AU_ItemStyle = 0x1048,//道具类型
            AU_Demo = 0x1049,//描述 
            AU_BeginTime = 0x1050,//开始时间
            AU_EndTime = 0x1051,//结束时间
            AU_SendUserID = 0x1052,//发送人帐号
            AU_RecvUserID = 0x1053,//接受人帐号 
            AU_SexIndex = 0x1054,//性别
            AU_UserTitle = 0x1055,//称号 
            AU_Pcash = 0x1056,//称号
            AU_WeddingDate = 0x1057,//Format:TimesStamp;   日期
            AU_City = 0x1058,//
            AU_UserItem = 0x1059,
            AU_RemainCount = 0x1060,
            AU_Postion = 0x1061,
            AU_hair = 0x1062,
            AU_face = 0x1063,
            AU_sets1 = 0x1064,
            AU_sets2 = 0x1065,
            AU_pet = 0x1066,
            AU_jacket = 0x1067,
            AU_pants = 0x1068,
            AU_shoes = 0x1069,

            AU_PcIP = 0x1070,
            AU_OpenDate = 0x1071,
            AU_CloseDate = 0x1072,
            AU_StopCode = 0x1073,
            AU_NightDiscount = 0x1074,
            AU_UsedCount = 0x1075,
            AU_MaxCount = 0x1076,
            AU_ExpRate = 0x1077,
            AU_MoneyRate = 0x1078,
                AU_BoardMessage = 0x1079,
                AU_ChannelList = 0x1080,
                AU_TaskID=  0x1081,
                AU_Status = 0x1082,
                AU_Interval= 0x1083,
                AU_GSName = 0x1084,
                AU_GSServerIP = 0x1085,
                AU_GSPort = 0x1086,
            /// <summary>
            /// 疯狂卡丁车定义
            /// </summary>
            CR_ServerIP = 0x1101,//服务器IP
            CR_ACCOUNT = 0x1102,//玩家帐号 Format tring
            CR_Passord = 0x1103,//玩家密码 Format tring
            CR_NUMBER = 0x1104,//激活码 Format tring
            CR_ISUSE = 0x1105,//是否被使用
            CR_STATUS = 0x1106,//玩家状态 Format:Integer
            CR_ActiveIP = 0x1107,//激活服务器IP Format:String
            CR_ActiveDate = 0x1108,//激活日期 Format:TimeStamp
            CR_BoardID = 0x1109,//公告ID Format:Integer
            CR_BoardContext = 0x1110,//公告内容 Format:String
            CR_BoardColor = 0x1111,//公告颜色 Format:String
            CR_ValidTime = 0x1112,//生效时间 Format:TimeStamp
            CR_InValidTime = 0x1113,//失效时间 Format:TimeStamp
            CR_Valid = 0x1114,//是否有效 Format:Integer
            CR_PublishID = 0x1115,//发布人ID Format:Integer
            CR_DayLoop = 0x1116,//每天播放 Format:Integer
            CR_PSTID = 0x1117,//注册号 Format:Integer
            CR_SEX = 0x1118,//性别 Format:Integer
            CR_LEVEL = 0x1119,//等级 Format:Integer
            CR_EXP = 0x1120,//经验 Format:Integer
            CR_License = 0x1121,//驾照Format:Integer
            CR_Money = 0x1122,//金钱Format:Integer
            CR_RMB = 0x1123,//人民币Format:Integer
            CR_RaceTotal = 0x1124,//比赛总数Format:Integer
            CR_RaceWon = 0x1125,//胜利场数Format:Integer
            CR_ExpOrder = 0x1126,//经验排名Format:Integer
            CR_WinRateOrder = 0x1127,//胜率排名Format:Integer
            CR_WinNumOrder = 0x1128,//胜利场数排名Format:Integer
            CR_SPEED = 0x1129,//播放速度Format:Integer
            CR_Mode = 0x1130,//播放方式 Format:Integer
            CR_ACTION = 0x1131,//查询动作　Format:Integer
            CR_NickName = 0x1132,//呢称 Format:String
            CR_Channel = 0x1133,//频道ID
            CR_UserID = 0x1134,//用户ID
            CR_BoardContext1 = 0x1135,//内容1
            CR_BoardContext2 = 0x1136,//内容2
            CR_Expire = 0x1137,//生效格式
            CR_ChannelID = 0x1138,//频道ID
            CR_ChannelName = 0x1139,//频道名称
            CR_Last_Login = 0x1140,//上次登入时间		
            CR_Last_Logout = 0x1141,//上次登出时间		
            CR_Last_Playing_Time = 0x1142,//上次游戏时长		
            CR_Total_Time = 0x1143,//总的游戏时长    
            CR_UserName = 0x1144,//玩家姓名
            /// <summary>
            /// 
            /// </summary>
            TOKEN_STATE = 0x1201,
            CARD_PDID = 0x1202,
            CARD_PDkey = 0x1203,
            CARD_PDCardType = 0x1204,
            CARD_PDFrom = 0x1205,
            CARD_PDCardNO = 0x1206,
            CARD_PDCardPASS = 0x1207,
            CARD_PDCardPrice = 0x1208,
            CARD_PDaction = 0x1209,
            CARD_PDuserid = 0x1210,
            CARD_PDusername = 0x1211,
            CARD_PDgetuserid = 0x1212,
            CARD_PDgetusername = 0x1213,
            CARD_PDdate = 0x1214,
            CARD_PDip = 0x1215,
            CARD_PDstatus = 0x1216,
            CARD_UDID = 0x1217,
            CARD_UDkey = 0x1218,
            CARD_UDusedo = 0x1219,
            CARD_UDdirect = 0x1220,
            CARD_UDuserid = 0x1221,
            CARD_UDusername = 0x1222,
            CARD_UDgetuserid = 0x1223,
            CARD_UDgetusername = 0x1224,
            CARD_UDcoins = 0x1225,
            CARD_UDtype = 0x1226,
            CARD_UDtargetvalue = 0x1227,
            CARD_UDzone1 = 0x1228,
            CARD_UDzone2 = 0x1229,
            CARD_UDdate = 0x1230,
            CARD_UDip = 0x1231,
            CARD_UDstatus = 0x1232,
            CARD_cardnum = 0x1233,
            CARD_cardpass = 0x1234,
            CARD_serial = 0x1235,
            CARD_draft = 0x1236,
            TOKEN_Type = 0x1237,
            TOKEN_Start = 0x1238,
            TOKEN_End = 0x1239,
            CARD_price = 0x1241,
            CARD_valid_date = 0x1242,
            CARD_use_status = 0x1243,
            CARD_cardsent = 0x1244,
            CARD_create_date = 0x1245,
            CARD_use_userid = 0x1246,
            CARD_use_username = 0x1247,
            CARD_partner = 0x1248,
            CARD_skey = 0x1249,
            CARD_ActionType = 0x1250,
            CARD_id = 0x1251,//TLV_STRING 久之游注册卡号
            CARD_username = 0x1252,//TLV_STRING 久之游注册用户名
            CARD_nickname = 0x1253,//TLV_STRING 久之游注册呢称
            CARD_password = 0x1254,//TLV_STRING 久之游注册密码
            CARD_sex = 0x1255,//TLV_STRING 久之游注册性别
            CARD_rdate = 0x1256,//TLV_Date 久之游注册日期
            CARD_rtime = 0x1257,//TLV_Time 久之游注册时间
            CARD_securecode = 0x1258,//TLV_STRING 安全码
            CARD_vis = 0x1259,//TLV_INTEGER
            CARD_logdate = 0x1260,//TLV_TimeStamp 日期
            CARD_realname = 0x1263,//TLV_STRING 真实姓名
            CARD_birthday = 0x1264,//TLV_Date 出生日期
            CARD_cardtype = 0x1265,//TLV_STRING
            CARD_email = 0x1267,//TLV_STRING 邮件
            CARD_occupation = 0x1268,//TLV_STRING 职业
            CARD_education = 0x1269,//TLV_STRING 教育程度
            CARD_marriage = 0x1270,//TLV_STRING 婚否
            CARD_constellation = 0x1271,//TLV_STRING 星座
            CARD_shx = 0x1272,//TLV_STRING 生肖
            CARD_city = 0x1273,//TLV_STRING 城市
            CARD_address = 0x1274,//TLV_STRING 联系地址
            CARD_phone = 0x1275,//TLV_STRING 联系电话
            CARD_qq = 0x1276,//TLV_STRING QQ
            CARD_intro = 0x1277,//TLV_STRING 介绍
            CARD_msn = 0x1278,//TLV_STRING MSN
            CARD_mobilephone = 0x1279,//TLV_STRING 移动电话
            CARD_SumTotal = 0x1280,//TLV_INTEGER 合计
            CARD_PayStartDate = 0x1281,//开始时间
            CARD_PayStopDate = 0x1282,//结束时间
            CARD_BalancePrice = 0x1283,//当前用户休闲币余额
            CARD_Douser = 0x1295,//操作人
            CARD_Wantdouser = 0x1296,//提交申请人
            CARD_Locktype = 0x1297,///封停类型  1：涉嫌盗卡 2：购买黑点 3：盗取密码

            CARD_Salename = 0x1298,//涉及经销商
            CARD_Locktime = 0x1299,//封停时间
            CARD_Lockinfo = 0x1240, //封停附加信息
            CARD_UserID = 0x1294,
            TOKEN_Operater = 0x1200,

            CARD_Username = 0x2300,
            CARD_Getusername = 0x2301,
            CARD_Buytime = 0x2302,
            CARD_Zone = 0x2303,
            CARD_Buyip = 0x2304,
            TOEKN_BindDate = 0x2305,
            CARD_SecQA = 0x2306,
            CARD_SecEmail = 0x2307,
            CARD_securecode1 = 0x2308,
            CARD_is_Use = 0x2309,
            CARD_uplog_date = 0x2310,
            CARD_GetTime = 0x2311,
            CARD_Coins = 0x2313,
            CARD_Awardcoin = 0x2314,

            CARD_ItemID = 0x2316,
            CARD_GetItemTime = 0x2317,
            CARD_Area = 0x2318,
            CARD_REG = 0x2319,//TLV_STRING 请求类型(取用户数据)getMyData
            CARD_TYPE = 0x2320,//TLV_STRING 重置历史resetHistory
            CARD_START_DATE = 0x2321,//开始日期
            CARD_END_DATE = 0x2322,//结束日期
            CARD_REGIP = 0x2323,//TLV_STRING 
            CARD_REGS = 0x2324,//TLV_STRING 32位验证码

            CARD_VALUE = 0x2325,//TLV_STRING
            CARD_UPDATE_TIME = 0x2326,//
            /// <summary>
            /// 
            /// </summary>
            AuShop_orderid = 0x1301,//int(11) 
            AuShop_udmark = 0x1302,//int(8) 
            AuShop_bkey = 0x1303,//varchar(40) 
            AuShop_pkey = 0x1304,//varchar(18) 
            AuShop_userid = 0x1305,//int(11) 
            AuShop_username = 0x1306,//varchar(20) 
            AuShop_getuserid = 0x1307,//int(11) 
            AuShop_getusername = 0x1308,//varchar(20) 
            AuShop_pcategory = 0x1309,//smallint(4) 
            AuShop_pisgift = 0x1310,//enum('y','n') 
            AuShop_islover = 0x1311,//enum('y','n') 
            AuShop_ispresent = 0x1312,//enum('y','n') 
            AuShop_isbuysong = 0x1313,//enum('y','n') 
            AuShop_prule = 0x1314,//tinyint(1) 
            AuShop_psex = 0x1315,//enum('all','m','f') 
            AuShop_pbuytimes = 0x1316,//int(11) 
            AuShop_allprice = 0x1317,//int(11) 
            AuShop_allaup = 0x1318,//int(11)
            AuShop_buytime = 0x1319,//int(10) 
            AuShop_buytime2 = 0x1320,//datetime 
            AuShop_buyip = 0x1321,//varchar(15) 
            AuShop_zone = 0x1322,//tinyint(2) 
            AuShop_status = 0x1323,//tinyint(1) 
            AuShop_pid = 0x1324,//int(11) 
            AuShop_pname = 0x1326,//varchar(20) 
            AuShop_pgift = 0x1328,//enum('y','n') 
            AuShop_pscash = 0x1330,//tinyint(2) 
            AuShop_pgamecode = 0x1331,//varchar(200) 
            AuShop_pnew = 0x1332,//enum('y','n') 
            AuShop_phot = 0x1333,//enum('y','n') 
            AuShop_pcheap = 0x1334,//enum('y','n') 
            AuShop_pchstarttime = 0x1335,//int(10) 
            AuShop_pchstoptime = 0x1336,//int(10) 
            AuShop_pstorage = 0x1337,//smallint(5) 
            AuShop_pautoprice = 0x1339,//enum('y','n') 
            AuShop_price = 0x1340,//int(8) 
            AuShop_chprice = 0x1341,//int(8) 
            AuShop_aup = 0x1342,//int(8) 
            AuShop_chaup = 0x1343,//int(8) 
            AuShop_ptimeitem = 0x1344,//varchar(200) 
            AuShop_pricedetail = 0x1345,//varchar(254) 
            AuShop_pdesc = 0x1347,//text
            AuShop_pbuys = 0x1348,//int(8) 
            AuShop_pfocus = 0x1349,//tinyint(1) 
            AuShop_pmark1 = 0x1350,//enum('y','n') 
            AuShop_pmark2 = 0x1351,//enum('y','n') 
            AuShop_pmark3 = 0x1352,//enum('y','n') 
            AuShop_pinttime = 0x1353,//int(10) 
            AuShop_pdate = 0x1354,//int(10) 
            AuShop_pisuse = 0x1355,//enum('y','n') 
            AuShop_ppic = 0x1356,//varchar(36) 
            AuShop_ppic1 = 0x1357,//varchar(36) 
            AuShop_usefeesum = 0x1358,//int
            AuShop_useaupsum = 0x1359,//int
            AuShop_buyitemsum = 0x1360,//int
            AuShop_BeginDate = 0x1361,//date
            AuShop_EndDate = 0x1362,//

            AuShop_GCashSum = 0x1363,//int
            AuShop_MCashSum = 0x1364,//int

            AuShop_PCODE = 0x1365,//道具代码
            AuShop_SENDUSER = 0x1366,//购买人
            AuShop_RECVUSER = 0x1367,//获赠人
            AuShop_ITEMTYPE = 0x1368,//道具类型
            AuShop_PERIOD = 0x1369,//道具时限
            AuShop_UseCount = 0x1370,
            AuShop_SendNick = 0x1371,
            AuShop_ReceiverNick = 0x1372,
            AuShop_ReceiveSN = 0x1373,
            AuShop_PresentID = 0x1374,
            AuShop_SendSN = 0x1375,
            AuShop_ItemTable = 0x1376,
            AuShop_ExpireType = 0x1377,
            AuShop_sDate = 0x1378,
            AuShop_sTime = 0x1379,
            /// <summary>
            /// 
            /// </summary>
            /// <summary>
            /// 劲乐团
            /// </summary>
            o2jam_ServerIP = 0x1401,//Format:TLV_STRING IP
            o2jam_UserID = 0x1402,//Format:TLV_STRING 用户帐号
            o2jam_UserNick = 0x1403,//Format:TLV_STRING 用户呢称
            o2jam_Sex = 0x1404,//Format:TLV_INTEGER 性别
            o2jam_Level = 0x1405,//Format:TLV_STRING 等级
            o2jam_Win = 0x1406,//Format:TLV_STRING 胜
            o2jam_Draw = 0x1407,//Format:TLV_STRING 平
            o2jam_Lose = 0x1408,//Format:TLV_STRING 负
            o2jam_SenderID = 0x1409,				//varchar
            o2jam_SenderIndexID = 0x1410,				//int
            o2jam_SenderNickName = 0x1411,				//varchar
            o2jam_ReceiverID = 0x1412,				//varchar
            o2jam_ReceiverIndexID = 0x1413,				//int
            o2jam_ReceiverNickName = 0x1414,				//varchar
            o2jam_Title = 0x1415,				//varchar
            o2jam_Content = 0x1416,				//varchar
            o2jam_WriteDate = 0x1417,				//datetime
            o2jam_ReadDate = 0x1418,				//datetime
            o2jam_ReadFlag = 0x1419,				//char
            o2jam_TypeFlag = 0x1420,				//char
            o2jam_Ban_Date = 0x1421,				//datetime
            o2jam_GEM = 0x1422,				//int
            o2jam_MCASH = 0x1423,				//int
            o2jam_O2CASH = 0x1424,				//int
            o2jam_MUSICCASH = 0x1425,				//int
            o2jam_ITEMCASH = 0x1426,				//int
            o2jam_USER_INDEX_ID = 0x1427,				//int
            o2jam_ITEM_INDEX_ID = 0x1428,				//int
            o2jam_USED_COUNT = 0x1429,				//int
            o2jam_REG_DATE = 0x1430,				//datetime
            o2jam_OLD_USED_COUNT = 0x1431,				//int
            o2jam_CURRENT_CASH = 0x1433,				//int
            o2jam_CHARGED_CASH = 0x1434,				//int
            o2jam_KIND_CASH = 0x1435,				//char
            o2jam_NAME = 0x1437,				//varchar
            o2jam_KIND = 0x1438,				//int
            o2jam_PLANET = 0x1439,				//int
            o2jam_VAL = 0x1440,				//int
            o2jam_EFFECT = 0x1441,				//int
            o2jam_JUSTICE = 0x1442,				//int
            o2jam_LIFE = 0x1443,				//int
            o2jam_PRICE_KIND = 0x1444,				//int
            o2jam_Exp = 0x1445, //Int
            o2jam_Battle = 0x1446,//Int
            o2jam_POSITION = 0x1448,				//int
            o2jam_COMPANY_ID = 0x1449,				//int
            o2jam_DESCRIBE = 0x1450,				//varchar
            o2jam_UPDATE_TIME = 0x1451,				//datetime
            o2jam_ITEM_NAME = 0x1453,				//varchar
            o2jam_ITEM_USE_COUNT = 0x1454,				//int
            o2jam_ITEM_ATTR_KIND = 0x1455,				//int
            o2jam_USER_ID = 0x1457,				//varchar
            o2jam_USER_NICKNAME = 0x1458,				//varchar
            o2jam_SEX = 0x1459,				//char
            o2jam_CREATE_TIME = 0x1460,				//datetime
            o2jam_BeginDate = 0x1461,
            o2jam_EndDate = 0x1462,
            O2JAM_BuyType = 0x1509,//TLV_INTEGER


            O2JAM_EQUIP1 = 0x1463,		//TLV_STRING,
            O2JAM_EQUIP2 = 0x1464,	//TLV_STRING,
            O2JAM_EQUIP3 = 0x1465,	//TLV_STRING,
            O2JAM_EQUIP4 = 0x1466,	//TLV_STRING,
            O2JAM_EQUIP5 = 0x1467,	//TLV_STRING,
            O2JAM_EQUIP6 = 0x1468,	//TLV_STRING,
            O2JAM_EQUIP7 = 0x1469,	//TLV_STRING,
            O2JAM_EQUIP8 = 0x1470,	//TLV_STRING,
            O2JAM_EQUIP9 = 0x1471,	//TLV_STRING,
            O2JAM_EQUIP10 = 0x1472,		//TLV_STRING,
            O2JAM_EQUIP11 = 0x1473,	//TLV_STRING,
            O2JAM_EQUIP12 = 0x1474,	//TLV_STRING,
            O2JAM_EQUIP13 = 0x1475,	//TLV_STRING,
            O2JAM_EQUIP14 = 0x1476,	//TLV_STRING,
            O2JAM_EQUIP15 = 0x1477,	//TLV_STRING,
            O2JAM_EQUIP16 = 0x1478,		//TLV_STRING,
            O2JAM_BAG1 = 0x1479,		//TLV_STRING,
            O2JAM_BAG2 = 0x1480,	//TLV_STRING,
            O2JAM_BAG3 = 0x1481,	//TLV_STRING,
            O2JAM_BAG4 = 0x1482,	//TLV_STRING,
            O2JAM_BAG5 = 0x1483,		//TLV_STRING,
            O2JAM_BAG6 = 0x1484,	//TLV_STRING,
            O2JAM_BAG7 = 0x1485,	//TLV_STRING,
            O2JAM_BAG8 = 0x1486,	//TLV_STRING,
            O2JAM_BAG9 = 0x1487,	//TLV_STRING,
            O2JAM_BAG10 = 0x1488,	//TLV_STRING,
            O2JAM_BAG11 = 0x1489,	//TLV_STRING,
            O2JAM_BAG12 = 0x1490,	//TLV_STRING,
            O2JAM_BAG13 = 0x1491,	//TLV_STRING,
            O2JAM_BAG14 = 0x1492,	//TLV_STRING,
            O2JAM_BAG15 = 0x1493,	//TLV_STRING,
            O2JAM_BAG16 = 0x1494,	//TLV_STRING,
            O2JAM_BAG17 = 0x1495,	//TLV_STRING,
            O2JAM_BAG18 = 0x1496,	//TLV_STRING,
            O2JAM_BAG19 = 0x1497,	//TLV_STRING,
            O2JAM_BAG20 = 0x1498,	//TLV_STRING,
            O2JAM_BAG21 = 0x1499,	//TLV_STRING,
            O2JAM_BAG22 = 0x1500,	//TLV_STRING,
            O2JAM_BAG23 = 0x1501,	//TLV_STRING,
            O2JAM_BAG24 = 0x1502,	//TLV_STRING,
            O2JAM_BAG25 = 0x1503,	//TLV_STRING,
            O2JAM_BAG26 = 0x1504,	//TLV_STRING,
            O2JAM_BAG27 = 0x1505,	//TLV_STRING,
            O2JAM_BAG28 = 0x1506,	//TLV_STRING,
            O2JAM_BAG29 = 0x1507,	//TLV_STRING,
            O2JAM_BAG30 = 0x1508,	//TLV_STRING



            /// <summary>
            /// 劲乐团II
            /// </summary>
            O2JAM2_ServerIP = 0x1601,//TLV_STRING
            O2JAM2_UserID = 0x1602,//TLV_STRING
            O2JAM2_UserName = 0x1603,//TLV_STRING
            O2JAM2_Id1 = 0x1604,//TLV_Integer
            O2JAM2_Id2 = 0x1605,//TLV_Integer
            O2JAM2_Rdate = 0x1606,//TLV_Date
            O2JAM2_IsUse = 0x1607,//TLV_Integer
            O2JAM2_Status = 0x1608,//TLV_Integer


            O2JAM2_UserIndexID = 0x1609,//TLV_Integer
            O2JAM2_UserNick = 0x1610,//Format:TLV_STRING 用户呢称
            O2JAM2_Sex = 0x1611,//Format:TLV_BOOLEAN 性别
            O2JAM2_Level = 0x1612,//Format:TLV_INTEGER 等级
            O2JAM2_Win = 0x1613,//Format:TLV_INTEGER 胜
            O2JAM2_Draw = 0x1614,//Format:TLV_INTEGER 平
            O2JAM2_Lose = 0x1615,//Format:TLV_INTEGER 负
            O2JAM2_Exp = 0x1616,//Format:TLV_INTEGER 经验
            O2JAM2_TOTAL = 0x1617,//Format:TLV_INTEGER 总局数
            O2JAM2_GCash = 0x1618,//Format:TLV_INTEGER G币
            O2JAM2_MCash = 0x1619,//Format:TLV_INTEGER M币
            O2JAM2_ItemCode = 0x1620,//Format:TLV_INTEGER
            O2JAM2_ItemName = 0x1621,//Format:TLV_String
            O2JAM2_Timeslimt = 0x1622,
            O2JAM2_DateLimit = 0x1623,
            O2JAM2_ItemSource = 0x1624,
            O2JAM2_Position = 0x1625,//int
            O2JAM2_BeginDate = 0x1626,
            O2JAM2_ENDDate = 0x1627,
            O2JAM2_MoneyType = 0x1628,//int
            O2JAM2_Title = 0x1629,
            O2JAM2_Context = 0x1630,
            o2jam2_consumetype = 0x1631,//int
            O2JAM2_ComsumeCode = 0x1632,//int
            O2JAM2_DayLimit = 0x1633,//int

            O2JAM2_StopTime = 0x1634,//date
            O2JAM2_StopStatus = 0x1635,//int
            O2JAM2_REASON = 0x1636,//string




            SDO_SenceID = 0x0858,
            SDO_WeekDay = 0x0859,
            SDO_MatPtHR = 0x0860,
            SDO_MatPtMin = 0x0861,
            SDO_StPtHR = 0x0862,
            SDO_StPtMin = 0x0863,
            SDO_EdPtHR = 0x0864,
            SDO_EdPtMin = 0x0865,

            SDO_Sence = 0x0868,
            SDO_MusicID1 = 0x0869,
            SDO_MusicName1 = 0x0870,
            SDO_LV1 = 0x0871,
            SDO_MusicID2 = 0x0872,
            SDO_MusicName2 = 0x0873,
            SDO_LV2 = 0x0874,
            SDO_MusicID3 = 0x0875,
            SDO_MusicName3 = 0x0876,
            SDO_LV3 = 0x0877,
            SDO_MusicID4 = 0x0878,
            SDO_MusicName4 = 0x0879,
            SDO_LV4 = 0x0880,
            SDO_MusicID5 = 0x0881,
            SDO_MusicName5 = 0x0882,
            SDO_LV5 = 0x0883,
            SDO_Precent = 0x0884,

            SDO_Type = 0x08120,                
            SDO_Usedate = 0x08121,
            SDO_Area = 0x08122,
            SDO_Padstatus = 0x08123,
            SDO_expcash = 0x08124,
            SDO_usecash = 0x08125,

            Soccer_ServerIP = 0x1701,
            Soccer_loginId = 0x1702,//Login ID
            Soccer_charsex = 0x1703,// 
            Soccer_charidx = 0x1704,//角色序列号 (ExSoccer.dbo.t_character[idx])
            Soccer_charexp = 0x1705,//经验值
            Soccer_charlevel = 0x1706,//等级
            Soccer_charpoint = 0x1707,//G点数 
            Soccer_match = 0x1708,//比赛数
            Soccer_win = 0x1709,//
            Soccer_lose = 0x1710,//失败
            Soccer_draw = 0x1711,//平局
            Soccer_drop = 0x1712,//平局		
            Soccer_charname = 0x1713,//角色名
            Soccer_charpos = 0x1714,//位置
            Soccer_Type = 0x1715,//查询类型
            Soccer_String = 0x1716,//查询值 
            Soccer_admid = 0x1717,//管理者ID
            Soccer_deleted_date = 0x1718,//删除日期
            Soccer_status = 0x1719,//状态
            Soccer_m_id = 0x1720,//玩家序列号 int
            Soccer_m_auth = 0x1721,//玩家是否被停封 int
            Soccer_regDate = 0x1722,//玩家注册日期 string 
            Soccer_c_date = 0x1723,//角色创建日期 string 
            Soccer_char_max = 0x1724,//tinyint
            Soccer_char_cnt = 0x1725,//int
            Soccer_ret = 0x1726,//int
            Soccer_kind = 0x1727,//socket,name string
            Soccer_SenderUserName = 0x1728,//string 道具赠送人
            Soccer_ReceiveUserName = 0x1729,//string 道具接受人
            Soccer_i_name = 0x1730,//string 道具名称
            Soccer_item_type = 0x1731,//int 道具类型
            Soccer_item_equip = 0x1732,//int 道具是否装备
            Soccer_Ban_Reason = 0x1733,//string 封停理由
            Soccer_idx = 0x1734,//int 道具，技能code
            Soccer_account_idx = 0x1735,//玩家序列号
            Soccer_title = 0x1736,//string 抬头
            Soccer_content = 0x1737,//string 内容
            Soccer_class = 0x1738,//tinyint 人物
            Soccer_body_part = 0x1739,//string 身体部分

            FJ_UserIndexID = 0x1800,
            FJ_UserID = 0x1801,
            FJ_UserNick = 0x1802,
            FJ_Sex = 0x1803,
            FJ_Level = 0x1804,
            FJ_Occupation = 0x1805,
            FJ_CurExp = 0x1806,
            FJ_CurSP = 0x1807,
            FJ_TotalSP = 0x1808,
            FJ_ItemCode = 0x1809,
            FJ_ItemName = 0x1810,
            FJ_Position = 0x1811,
            FJ_GCash = 0x1812,
            FJ_MCash = 0x1813,
            FJ_ServerIP = 0x1814,
            FJ_MinLevel = 0x1815,
            FJ_ItemLimit = 0x1816,
            FJ_XPosition = 0x1817,
            FJ_YPosition = 0x1818,
            FJ_ZPosition = 0x1819,
            FJ_Map = 0x1820,
            FJ_OfflineTime = 0x1821,
            FJ_ItemCount = 0x1822,
            FJ_isBind = 0x1823,
            FJ_LoginTime = 0x1824,
            FJ_StartTime = 0x1825,
            FJ_EndTime = 0x1826,
            FJ_isDel = 0x1827,
            FJ_isUse = 0x1828,
            FJ_UseTime = 0x1829,
            FJ_UseAccount = 0x1830,
            FJ_ActiveTime = 0x1831,
            FJ_isActive = 0x1832,
            FJ_UseActiveCode = 0x1833,
            FJ_GoldAccount = 0x1834,

            FJ_Reason = 0x1835,
            FJ_GuidID = 0x1836,
            FJ_SkillID = 0x1837,
            FJ_Skill = 0x1838,
            FJ_RelateCHarName = 0x1839,
            FJ_Relate = 0x1840,
            FJ_Max = 0x1841,
            FJ_Message = 0x1842,
            FJ_GuildName = 0x1843,
            FJ_LastOfflineTime = 0x1844,
            FJ_CreateTime = 0x1845,
            FJ_Pwd = 0x1846,
            FJ_BanDate = 0x1847,
            FJ_Quest_id = 0x1850,//Format TRING 任务ID 
            FJ_Quest_state = 0x1851,//Format TRING 任务状态
            FJ_Content = 0x1852,//Format TRING 任务内容
            FJ_ihonor = 0x1848,//荣誉值
            FJ_icurrank = 0x1849,//称号
            FJ_RemainCredit = 0x1853,//Format:INT 游戏内商城币数量
            FJ_LoginIP = 0x1854,//Format TRING 登录IP
            FJ_Type = 0x1855,//Format:INT 关系类型
            FJ_GSName = 0x1856,//Format TRING gs 服务器
            FJ_MsgContent = 0x1857,//Format TRING 公告内容
            FJ_BoardFlag = 0x1858,//Format:INT 状态
            FJ_Interval = 0x1859,//Format:INT 发送间隔
            FJ_MsgID = 0x1860,
            FJ_Occupation_id = 0x1861,
            FJ_Style = 0x1862,
            FJ_TotalExp = 0x1863,
            FJ_IsOnline = 0x1864,
            FJ_StyleDesc = 0x1865,//道具分类的说明 s
		    FJ_Color = 0x1866,//s
		    FJ_Inst_Cur = 0x1867,//耐久正确值 f
		    FJ_Inst_Max = 0x1868,//耐久最大值 f
		    FJ_Inst_Desc = 0x1869,//s
            FJ_Embed_GuID = 0x1870, 
            FJ_Item_GuID = 0x1871,
            FJ_AppendItem_GuID = 0x1872, 
            FJ_Title = 0x1873,
            FJ_Min = 0x1874,

            FJ_color_level = 0x1875,

            FJ_GType = 0x1876,
            FJ_FStr = 0x1877,
            FJ_FDex = 0x1878,
            FJ_FCon = 0x1879,
            FJ_FInt = 0x1880,
            FJ_FWit = 0x1881,
            FJ_FSpi = 0x1882,
            FJ_FSpeed = 0x1883,
            FJ_FSwordMaster = 0x1884,
            FJ_FBluntMaster = 0x1885,
            FJ_FDaggerMaster = 0x1886,
            FJ_FLanceMaster = 0x1887,
            FJ_FMagWeaponMaster = 0x1888,
            FJ_FBowMovingShoot = 0x1889,
            FJ_FBowAttackDist = 0x1890,
            FJ_FBowMaster = 0x1891,
            FJ_FLightArmorMaster = 0x1892,
            FJ_FHeavyArmorMaster = 0x1893,
            FJ_FMagArmorMaster = 0x1894,
            FJ_FShieldMaster = 0x1895,
            FJ_FDualMaster = 0x1896,
            FJ_FHPMax = 0x1897,
            FJ_FHPReg = 0x1898,
            FJ_FMPMax = 0x1899,
            FJ_FMPReg = 0x1900,
            FJ_FPhyAttack = 0x1901,
            FJ_FPhyDefend = 0x1902,
            FJ_FPhyHit = 0x1903,
            FJ_FPhyAvoid = 0x1904,
            FJ_FPhyAttackSpeed = 0x1905,
            FJ_FPhyCritical = 0x1906,
            FJ_FPhyCriticalPower = 0x1907,
            FJ_FPhyHPAbsorb = 0x1908,
            FJ_FPhyMPAbsorb = 0x1909,
            FJ_FPhyAttackDist = 0x1910,
            FJ_FMagAttack = 0x1911,
            FJ_FMagDefend = 0x1912,
            FJ_FMagCritical = 0x1913,
            FJ_FMagCriticalPower = 0x1914,
            FJ_FMagIntent = 0x1915,
            FJ_FMagSpeed = 0x1916,
            FJ_FHealPower = 0x1917,
            FJ_FHealEff = 0x1918,
            FJ_FThorn = 0x1919,
            FJ_FCDScale = 0x1920,
            FJ_FASI_0 = 0x1921,
            FJ_FASI_1 = 0x1922,
            FJ_FASI_2 = 0x1923,
            FJ_FASI_3 = 0x1924,
            FJ_FASI_4 = 0x1925,
            FJ_FASI_5 = 0x1926,
            FJ_FASI_6 = 0x1927,
            FJ_FASI_7 = 0x1928,
            FJ_FASI_8 = 0x1929,
            FJ_FASI_9 = 0x1930,
            FJ_FManaShield = 0x1931,
            FJ_FJumpMaster = 0x1932,
            FJ_FExpScale = 0x1933,
            FJ_FSPScale = 0x1934,
            FJ_FDamage2MP = 0x1935,
            FJ_FPhyDefScale = 0x1936,
            FJ_FMagDefScale = 0x1937,
            FJ_FMagIceAttack = 0x1938,
            FJ_FMagFireAttack = 0x1939,
            FJ_FMagThunderAttack = 0x1940,
            FJ_FMagPoisonAttack = 0x1941,
            FJ_FMagIceDefend = 0x1942,
            FJ_FMagFireDefend = 0x1943,
            FJ_FMagThunderDefend = 0x1944,
            FJ_FMagPoisonDefend = 0x1945,
            FJ_FCBRate = 0x1946,
            FJ_FCBPer = 0x1947,
            FJ_SlotItemNum = 0x1948,
            FJ_SlotStoneNum = 0x1949,
            FJ_StockMax = 0x1950,
            FJ_SlotMax = 0x1951,
            FJ_ItemMark = 0x1952,

            /// <summary>
            /// 疯狂飚车
            /// </summary>
            RC_ServerIP = 0x0001,//TLV_String
            RC_Account = 0x0002,//TLV_String
            RC_CharName = 0x0003,//TLV_String
            RC_Sex = 0x0004,//TLV_INTEGER
            RC_Rank = 0x0005,//TLV_String
            RC_Vehicle = 0x0006,//TLV_INTEGER
            RC_Level = 0x0007,//TLV_INTEGER
            RC_Exp = 0x0008,//TLV_Money
            RC_MatchNum = 0x0009,//TLV_INTEGER
            RC_9YOUPointer = 0x0010,//TLV_INTEGER
            RC_IGroup = 0x0011,//TLV_INTEGER
            RC_Money = 0x0012,//TLV_INTEGER
            RC_OnlineTime = 0x0013,//TLV_TimeStamp
            RC_OfflineTime = 0x0014,//TLV_TimeStamp
            RC_PlayCounter = 0x0015,//TLV_INTEGER
            RC_UserIndexID = 0x0016,//TLV_INTEGER
            RC_LoginIP = 0x0017,//TLV_String
            RC_BeginDate = 0x0018,//TLV_TimeStamp
            RC_EndDate = 0x0019,//TLV_TimeStamp
            RC_isPlatinum = 0x0020,//TLV_String
            RC_isUse = 0x0021,//TLV_String
            RC_ActiveCode = 0x0022,
            RC_UseDate = 0x0023,



            ERROR_Msg = 0xFFFF,//Format:STRING  验证用户的信息

            Bug_ID = 0x0117,//Format:Integer bugID
            Bug_Subject = 0x0118,//Format:String bug 标题
            Bug_Type = 0x0119,//Format:String 类型
            Bug_Context = 0x0120,//Format:String 内容
            Bug_Date = 0x0121,//Format:TimeStamp 日期
            Bug_Sender = 0x0122,//Format:Integer
            Bug_Process = 0x0123,//Format:Integer
            Bug_Result = 0x0124,//Format:String 
            Update_ID = 0x0125,//Format:Integer
            Update_Module = 0x0126,//Format:String
            Update_Context = 0x0127,//Format:String
            Update_Date = 0x0128,//Format:TimeStamp
            CARD_RemainDate = 0x2315,
            TOKEN_username = 0x1284,//TLV_STRING 密宝用户名
	        TOKEN_esn = 0x1285,//TLV_STRING 密宝ESN
	        TOKEN_dpsw = 0x1286,//TLV_STRING 密宝动态密码
	        TOKEN_spsw = 0x1287,//TLV_STRING 密宝固定密码
	        TOKEN_authType = 0x1288,//TLV_STRING 密宝验证类型
	        TOKEN_provide = 0x1289,//TLV_STRING 密宝服务提供商
	        TOKEN_service = 0x1290,//TLV_STRING 密宝请求服务名称
	        TOKEN_certificate = 0x1291,//TLV_STRING 密宝信任验证
	        TOKEN_code = 0x1292,//TLV_STRING 密宝响应状态码
	        TOKEN_description = 0x1293,//TLV_STRING 密宝响应描述
            TOKEN_ACTIVEDATE = 0x2327

            
        }
        /// <summary>
        /// 参数类型标签
        /// </summary>
        public enum TagFormat : byte
        {
            TLV_STRING = 0,
            TLV_MONEY = 1,
            TLV_DATE = 2,
            TLV_INTEGER = 3,
            TLV_EXTEND = 4,
            TLV_NUMBER = 5,
            TLV_TIME = 6,
            TLV_TIMESTAMP = 7,
            TLV_BOOLEAN = 8
        }
        /// <summary>
        /// 操作命令标签
        /// </summary>
        public enum ServiceKey : ushort
        {
            /// <summary>
            /// 公共模块(0x80)
            /// </summary>
            CONNECT = 0x0001,
            CONNECT_RESP = 0x8001,
            DISCONNECT = 0x0002,
            DISCONNECT_RESP = 0x8002,
            ACCOUNT_AUTHOR = 0x0003,
            ACCOUNT_AUTHOR_RESP = 0x8003,

            SERVERINFO_IP_QUERY = 0x0004,
            SERVERINFO_IP_QUERY_RESP = 0x8004,
            GMTOOLS_OperateLog_Query = 0x0005,//查看工具操作记录
            GMTOOLS_OperateLog_Query_RESP = 0x8005,//查看工具操作记录响应 
            SERVERINFO_IP_ALL_QUERY = 0x0006,//查看所有游戏服务器地址
            SERVERINFO_IP_ALL_QUERY_RESP = 0x8006,//查看所有游戏服务器地址响应
            LINK_SERVERIP_CREATE = 0x0007,//添加游戏链接数据库
            LINK_SERVERIP_CREATE_RESP = 0x8007,//添加游戏链接数据库响应
            CLIENT_PATCH_COMPARE = 0x0008,
            CLIENT_PATCH_COMPARE_RESP = 0x8008,
            CLIENT_PATCH_UPDATE = 0x0009,
            CLIENT_PATCH_UPDATE_RESP = 0x8009,

            GMTOOLS_BUGLIST_QUERY = 0x0011,
            GMTOOLS_BUGLIST_QUERY_RESP = 0x8011,
            GMTOOLS_BUGLIST_INSERT = 0x0012,
            GMTOOLS_BUGLIST_INSERT_RESP = 0x8012,
            GMTOOLS_BUGLIST_UPDATE = 0x0013,
            GMTOOLS_BUGLIST_UPDATE_RESP = 0x8013,
            GMTOOLS_UPDATELIST_QUERY = 0x0014,
            GMTOOLS_UPDATELIST_QUERY_RESP = 0x8014,
            GMTOOLS_RESETSTATICS_QUERY = 0x0015,
            GMTOOLS_RESETSTATICS_QUERY_RESP = 0x8015,


            /// <summary>
            ///用户管理模块(0x81) 
            /// </summary>
            USER_CREATE = 0x0001,
            USER_CREATE_RESP = 0x8001,
            USER_UPDATE = 0x0002,
            USER_UPDATE_RESP = 0x8002,
            USER_DELETE = 0x0003,
            USER_DELETE_RESP = 0x8003,
            USER_QUERY = 0x0004,
            USER_QUERY_RESP = 0x8004,
            USER_PASSWD_MODIF = 0x0005,
            USER_PASSWD_MODIF_RESP = 0x8005,
            USER_QUERY_ALL = 0x0006,
            USER_QUERY_ALL_RESP = 0x8006,
            DEPART_QUERY = 0x0007,
            DEPART_QUERY_RESP = 0x8007,
            UPDATE_ACTIVEUSER = 0x0008,//更新在线用户状态
            UPDATE_ACTIVEUSER_RESP = 0x8008,//更新在线用户状态响应

            /// <summary>
            /// 模块管理(0x82)
            /// </summary>
            MODULE_CREATE = 0x0001,
            MODULE_CREATE_RESP = 0x8001,
            MODULE_UPDATE = 0x0002,
            MODULE_UPDATE_RESP = 0x8002,
            MODULE_DELETE = 0x0003,
            MODULE_DELETE_RESP = 0x8003,
            MODULE_QUERY = 0x0004,
            MODULE_QUERY_RESP = 0x8004,

            /// <summary>
            /// 用户与模块(0x83) 
            /// </summary>
            USER_MODULE_CREATE = 0x0001,
            USER_MODULE_CREATE_RESP = 0x8001,
            USER_MODULE_UPDATE = 0x0002,
            USER_MODULE_UPDATE_RESP = 0x8002,
            USER_MODULE_DELETE = 0x0003,
            USER_MODULE_DELETE_RESP = 0x8003,
            USER_MODULE_QUERY = 0x0004,
            USER_MODULE_QUERY_RESP = 0x8004,

            /// <summary>
            /// 游戏管理(0x84) 
            /// </summary>
            GAME_CREATE = 0x0001,
            GAME_CREATE_RESP = 0x8001,
            GAME_UPDATE = 0x0002,
            GAME_UPDATE_RESP = 0x8002,
            GAME_DELETE = 0x0003,
            GAME_DELETE_RESP = 0x8003,
            GAME_QUERY = 0x0004,
            GAME_QUERY_RESP = 0x8004,
            GAME_MODULE_QUERY = 0x0005,
            GAME_MODULE_QUERY_RESP = 0x8005,

            /// <summary>
            /// NOTES管理(0x85) 
            /// </summary>
            NOTES_LETTER_TRANSFER = 0x0001,
            NOTES_LETTER_TRANSFER_RESP = 0x8001,
            NOTES_LETTER_PROCESS = 0x0002, //邮件处理
            NOTES_LETTER_PROCESS_RESP = 0x8002,//邮件处理
            NOTES_LETTER_TRANSMIT = 0x0003,//邮件转发
            NOTES_LETTER_TRANSMIT_RESP = 0x8003,//邮件转发响应

            NOTES_LINKER_GET = 0x0004,
            NOTES_LINKER_GET_RESP = 0x8004,
            NOTES_CONTENT_GET = 0x0005,
            NOTES_CONTENT_GET_RESP = 0x8005,
            NOTES_CONTENT_SEND = 0x0006,
            NOTES_CONTENT_SEND_RESP = 0x8006,
            NOTES_CONTENT_REPLAY = 0x0007,
            NOTES_CONTENT_REPLAY_RESP = 0x8007,
            NOTES_ATTACHMENT_GET = 0x0008,
            NOTES_ATTACHMENT_GET_RESP = 0x8008,
            NOTES_CONTENT_UPDATE = 0x0009,
            NOTES_CONTENT_UPDATE_RESP = 0x8009,
            NOTES_CONTENT_DELETE = 0x0010,
            NOTES_CONTENT_DELETE_RESP = 0x8010,

            /// <summary>
            /// 猛将GM工具管理(0x86)
            /// </summary>
            MJ_CHARACTERINFO_QUERY = 0x0001,//检查玩家状态
            MJ_CHARACTERINFO_QUERY_RESP = 0x8001,//检查玩家状态响应
            MJ_CHARACTERINFO_UPDATE = 0x0002,//修改玩家状态
            MJ_CHARACTERINFO_UPDATE_RESP = 0x8002,//修改玩家状态响应
            MJ_LOGINTABLE_QUERY = 0x0003,//检查玩家是否在线
            MJ_LOGINTABLE_QUERY_RESP = 0x8003,//检查玩家是否在线响应
            MJ_CHARACTERINFO_EXPLOIT_UPDATE = 0x0004,//修改功勋值
            MJ_CHARACTERINFO_EXPLOIT_UPDATE_RESP = 0x8004,//修改功勋值响应
            MJ_CHARACTERINFO_FRIEND_QUERY = 0x0005,//列出好友名单
            MJ_CHARACTERINFO_FRIEND_QUERY_RESP = 0x8005,//列出好有名单响应
            MJ_CHARACTERINFO_FRIEND_CREATE = 0x0006,//添加好友
            MJ_CHARACTERINFO_FRIEND_CREATE_RESP = 0x8006,//添加好友响应
            MJ_CHARACTERINFO_FRIEND_DELETE = 0x0007,//删除好友
            MJ_CHARACTERINFO_FRIEND_DELETE_RESP = 0x8007,//删除好友响应
            MJ_GUILDTABLE_UPDATE = 0x0008,//修改服务器所有已存在帮会
            MJ_GUILDTABLE_UPDATE_RESP = 0x8008,//修改服务器所有已存在帮会响应
            MJ_ACCOUNT_LOCAL_CREATE = 0x0009,//将服务器上的account表里的玩家信息保存到本地服务器的
            MJ_ACCOUNT_LOCAL_CREATE_RESP = 0x8009,//将服务器上的account表里的玩家信息保存到本地服务器的响应
            MJ_ACCOUNT_REMOTE_DELETE = 0x0010,//永久封停帐号
            MJ_ACCOUNT_REMOTE_DELETE_RESP = 0x8010,//永久封停帐号的响应
            MJ_ACCOUNT_REMOTE_RESTORE = 0x0011,//解封帐号
            MJ_ACCOUNT_REMOTE_RESTORE_RESP = 0x8011,//解封帐号响应
            MJ_ACCOUNT_LIMIT_RESTORE = 0x0012,//有时限的封停
            MJ_ACCOUNT_LIMIT_RESTORE_RESP = 0x8012,//有时限的封停响应
            MJ_ACCOUNTPASSWD_LOCAL_CREATE = 0x0013,//保存玩家密码到本地 
            MJ_ACCOUNTPASSWD_LOCAL_CREATE_RESP = 0x8013,//保存玩家密码到本地
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE = 0x0014,//修改玩家密码 
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE_RESP = 0x8014,//修改玩家密码
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE = 0x0015,//恢复玩家密码
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE_RESP = 0x8015,//恢复玩家密码
            MJ_ITEMLOG_QUERY = 0x0016,//检查该用户交易记录
            MJ_ITEMLOG_QUERY_RESP = 0x8016,//检查该用户交易记录
            MJ_GMTOOLS_LOG_QUERY = 0x0017,//检查使用者操作记录
            MJ_GMTOOLS_LOG_QUERY_RESP = 0x8017,//检查使用者操作记录
            MJ_MONEYSORT_QUERY = 0x0018,//根据金钱排序
            MJ_MONEYSORT_QUERY_RESP = 0x8018,//根据金钱排序的响应
            MJ_LEVELSORT_QUERY = 0x0019,//根据等级排序
            MJ_LEVELSORT_QUERY_RESP = 0x8019,//根据等级排序的响应
            MJ_MONEYFIGHTERSORT_QUERY = 0x0020,//根据不同职业金钱排序
            MJ_MONEYFIGHTERSORT_QUERY_RESP = 0x8020,//根据不同职业金钱排序的响应
            MJ_LEVELFIGHTERSORT_QUERY = 0x0021,//根据不同职业等级排序
            MJ_LEVELFIGHTERSORT_QUERY_RESP = 0x8021,//根据不同职业等级排序的响应
            MJ_MONEYTAOISTSORT_QUERY = 0x0022,//根据道士金钱排序
            MJ_MONEYTAOISTSORT_QUERY_RESP = 0x8022,//根据道士金钱排序的响应
            MJ_LEVELTAOISTSORT_QUERY = 0x0023,//根据道士等级排序
            MJ_LEVELTAOISTSORT_QUERY_RESP = 0x8023,//根据道士等级排序的响应
            MJ_MONEYRABBISORT_QUERY = 0x0024,//根据法师金钱排序
            MJ_MONEYRABBISORT_QUERY_RESP = 0x8024,//根据法师金钱排序的响应
            MJ_LEVELRABBISORT_QUERY = 0x0025,//根据法师等级排序
            MJ_LEVELRABBISORT_QUERY_RESP = 0x8025,//根据法师等级排序的响应
            MJ_ACCOUNT_QUERY = 0x0026,//猛将帐号查询
            MJ_ACCOUNT_QUERY_RESP = 0x8026,//猛将帐号查询响应
            MJ_ACCOUNT_LOCAL_QUERY = 0x0027,//查询猛将本地帐号
            MJ_ACCOUNT_LOCAL_QUERY_RESP = 0x8027,//查询猛将本地帐号响应

            /// <summary>
            /// SDO_ADMIN 超级舞者工具操作消息集
            /// </summary>
            SDO_ACCOUNT_QUERY = 0x0026,//查看玩家的帐号信息
            SDO_ACCOUNT_QUERY_RESP = 0x8026,//查看玩家的帐号信息响应
            SDO_CHARACTERINFO_QUERY = 0x0027,//查看任务资料的信息
            SDO_CHARACTERINFO_QUERY_RESP = 0x8027,//查看人物资料的信息响应
            SDO_ACCOUNT_CLOSE = 0x0028,//封停帐户的权限信息
            SDO_ACCOUNT_CLOSE_RESP = 0x8028,//封停帐户的权限信息响应
            SDO_ACCOUNT_OPEN = 0x0029,//解封帐户的权限信息
            SDO_ACCOUNT_OPEN_RESP = 0x8029,//解封帐户的权限信息响应
            SDO_PASSWORD_RECOVERY = 0x0030,//玩家找回密码
            SDO_PASSWORD_RECOVERY_RESP = 0x8030,//玩家找回密码响应
            SDO_CONSUME_QUERY = 0x0031,//查看玩家的消费记录
            SDO_CONSUME_QUERY_RESP = 0x8031,//查看玩家的消费记录响应
            SDO_USERONLINE_QUERY = 0x0032,//查看玩家上下线状态
            SDO_USERONLINE_QUERY_RESP = 0x8032,//查看玩家上下线状态响应
            SDO_USERTRADE_QUERY = 0x0033,//查看玩家交易状态
            SDO_USERTRADE_QUERY_RESP = 0x8033,//查看玩家交易状态响应
            SDO_CHARACTERINFO_UPDATE = 0x0034,//修改玩家的账号信息
            SDO_CHARACTERINFO_UPDATE_RESP = 0x8034,//修改玩家的账号信息响应
            SDO_ITEMSHOP_QUERY = 0x0035,//查看游戏里面所有道具信息
            SDO_ITEMSHOP_QUERY_RESP = 0x8035,//查看游戏里面所有道具信息响应
            SDO_ITEMSHOP_DELETE = 0x0036,//删除玩家道具信息
            SDO_ITEMSHOP_DELETE_RESP = 0x8036,//删除玩家道具信息响应
            SDO_GIFTBOX_CREATE = 0x0037,//添加玩家礼物盒道具信息
            SDO_GIFTBOX_CREATE_RESP = 0x8037,//添加玩家礼物盒道具信息响应
            SDO_GIFTBOX_QUERY = 0x0038,//查看玩家礼物盒的道具
            SDO_GIFTBOX_QUERY_RESP = 0x8038,//查看玩家礼物盒的道具响应
            SDO_GIFTBOX_DELETE = 0x0039,//删除玩家礼物盒的道具
            SDO_GIFTBOX_DELETE_RESP = 0x8039,//删除玩家礼物盒的道具响应
            SDO_USERLOGIN_STATUS_QUERY = 0x0040,//查看玩家登录状态
            SDO_USERLOGIN_STATUS_QUERY_RESP = 0x8040,//查看玩家登录状态响应
            SDO_ITEMSHOP_BYOWNER_QUERY = 0x0041,////查看玩家身上道具信息
            SDO_ITEMSHOP_BYOWNER_QUERY_RESP = 0x8041,////查看玩家身上道具信息
            SDO_ITEMSHOP_TRADE_QUERY = 0x0042,//查看玩家交易记录信息
            SDO_ITEMSHOP_TRADE_QUERY_RESP = 0x8042,//查看玩家交易记录信息的响应
            SDO_MEMBERSTOPSTATUS_QUERY = 0x0043,//查看该帐号状态
            SDO_MEMBERSTOPSTATUS_QUERY_RESP = 0x8043,///查看该帐号状态的响应
            SDO_MEMBERBANISHMENT_QUERY = 0x0044,//查看所有停封的帐号
            SDO_MEMBERBANISHMENT_QUERY_RESP = 0x8044,//查看所有停封的帐号响应
            SDO_USERMCASH_QUERY = 0x0045,//玩家充值记录查询
            SDO_USERMCASH_QUERY_RESP = 0x8045,//玩家充值记录查询响应
            SDO_USERGCASH_UPDATE = 0x0046,//补偿玩家G币
            SDO_USERGCASH_UPDATE_RESP = 0x8046,//补偿玩家G币的响应
            SDO_MEMBERLOCAL_BANISHMENT = 0x0047,//本地保存停封信息
            SDO_MEMBERLOCAL_BANISHMENT_RESP = 0x8047,//本地保存停封信息响应
            SDO_EMAIL_QUERY = 0x0048,//得到玩家的EMAIL
            SDO_EMAIL_QUERY_RESP = 0x8048,//得到玩家的EMAIL响应
            SDO_USERCHARAGESUM_QUERY = 0x0049,//得到充值记录总和
            SDO_USERCHARAGESUM_QUERY_RESP = 0x8049,//得到充值记录总和响应
            SDO_USERCONSUMESUM_QUERY = 0x0050,//得到消费记录总和
            SDO_USERCONSUMESUM_QUERY_RESP = 0x8050,//得到消费记录总和响应
            SDO_USERGCASH_QUERY = 0x0051,//玩家Ｇ币记录查询
            SDO_USERGCASH_QUERY_RESP = 0x8051,//玩家Ｇ币记录查询响应
            SDO_USERNICK_UPDATE = 0x0069,
            SDO_USERNICK_UPDATE_RESP = 0x8069,
            SDO_PADKEYWORD_QUERY = 0x0070,
            SDO_PADKEYWORD_QUERY_RESP = 0x8070,
            SDO_BOARDMESSAGE_REQ = 0x0071,
            SDO_BOARDMESSAGE_REQ_RESP = 0x8071,
            SDO_CHANNELLIST_QUERY = 0x0072,
            SDO_CHANNELLIST_QUERY_RESP = 0x8072,
            SDO_ALIVE_REQ = 0x0073,
            SDO_ALIVE_REQ_RESP = 0x8073,
            SDO_BOARDTASK_QUERY = 0x0074,
            SDO_BOARDTASK_QUERY_RESP = 0x8074,
            SDO_BOARDTASK_UPDATE = 0x0075,
            SDO_BOARDTASK_UPDATE_RESP = 0x8075,
            SDO_BOARDTASK_INSERT = 0x0076,
            SDO_BOARDTASK_INSERT_RESP = 0x8076,
            SDO_DAYSLIMIT_QUERY = 0x0077,//有效期查询
            SDO_DAYSLIMIT_QUERY_RESP = 0x8077,
            SDO_CHALLENGE_INSERTALL = 0x0081,
            SDO_CHALLENGE_INSERTALL_RESP = 0x8081,
            SDO_USERPASSWD_QUERY = 0x0082,
            SDO_USERPASSWD_QUERY_RESP = 0x8082,
            SDO_YYHAPPYITEM_QUERY = 0x0084,
            SDO_YYHAPPYITEM_QUERY_RESP = 0x8084,
            SDO_YYHAPPYITEM_CREATE = 0x0085,
            SDO_YYHAPPYITEM_CREATE_RESP = 0x8085,
            SDO_YYHAPPYITEM_UPDATE = 0x0086,
            SDO_YYHAPPYITEM_UPDATE_RESP = 0x8086,
            SDO_YYHAPPYITEM_DELETE = 0x0087,
            SDO_YYHAPPYITEM_DELETE_RESP = 0x8087,
            SDO_USERONLINETIME_QUERY = 0x0083,
            SDO_USERONLINETIME_QUERY_RESP = 0x8083,
            SDO_USER_PUNISH = 0x0088,
            SDO_USER_PUNISH_RESP = 0x8088,//单个惩罚
            SDO_PUNISHUSER_IMPORT_QUERY = 0x0089,
            SDO_PUNISHUSER_IMPORT_QUERY_RESP = 0x8089,//导入后查询
            SDO_PUNISHUSER_IMPORT = 0x0090,
            SDO_PUNISHUSER_IMPORT_RESP = 0x8090,//导入数据
            SDO_USER_PUNISHALL = 0x0091,
            SDO_USER_PUNISHALL_RESP = 0x8091, //批量惩罚
            SDO_FRAGMENT_QUERY = 0x0092,
            SDO_FRAGMENT_QUERY_RESP = 0x8092,
            SDO_FRAGMENT_UPDATE = 0x0093,
            SDO_FRAGMENT_UPDATE_RESP = 0x8093,
            SDO_PFUNCTIONITEM_QUERY = 0x0094,
            SDO_PFUNCTIONITEM_QUERY_RESP = 0x8094,
            SDO_USERMARRIAGE_QUERY = 0x0095,
            SDO_USERMARRIAGEQUERY_RESP = 0x8095,
            SDO_REMAINCASH_QUERY = 0x0097,
            SDO_REMAINCASH_QUERY_RESP = 0x8097,
            SDO_PADREGIST_QUERY = 0x0098,
            SDO_PADREGIST_QUERY_RESP = 0x8098,
            SDO_MiniDancerTime_QUERY = 0x0099,
            SDO_MiniDancerTime_QUERY_RESP = 0x8099,
            SDO_RewardItem_QUERY = 0x0100,
            SDO_RewardItem_QUERY_RESP = 0x8100,
            SDO_QueryPunishusertimes_QUERY = 0x0101,
            SDO_QueryPunishusertimes_QUERY_RESP = 0x8101,
            SDO_QueryDeleteItem_QUERY = 0x0102,
            SDO_QueryDeleteItem_QUERY_RESP = 0x8102,
            /// <summary>
            /// AU_ADMIN 劲舞团工具操作消息集
            /// </summary>
            AU_ACCOUNT_QUERY = 0x0001,//玩家帐号信息查询
            AU_ACCOUNT_QUERY_RESP = 0x8001,//玩家帐号信息查询响应
            AU_ACCOUNTREMOTE_QUERY = 0x0002,//游戏服务器封停的玩家帐号查询
            AU_ACCOUNTREMOTE_QUERY_RESP = 0x8002,//游戏服务器封停的玩家帐号查询响应
            AU_ACCOUNTLOCAL_QUERY = 0x0003,//本地封停的玩家帐号查询
            AU_ACCOUNTLOCAL_QUERY_RESP = 0x8003,//本地封停的玩家帐号查询响应
            AU_ACCOUNT_CLOSE = 0x0004,//封停的玩家帐号
            AU_ACCOUNT_CLOSE_RESP = 0x8004,//封停的玩家帐号响应
            AU_ACCOUNT_OPEN = 0x0005,//解封的玩家帐号
            AU_ACCOUNT_OPEN_RESP = 0x8005,//解封的玩家帐号响应
            AU_ACCOUNT_BANISHMENT_QUERY = 0x0006,//玩家封停帐号查询
            AU_ACCOUNT_BANISHMENT_QUERY_RESP = 0x8006,//玩家封停帐号查询响应
            AU_CHARACTERINFO_QUERY = 0x0007,//查询玩家的账号信息
            AU_CHARACTERINFO_QUERY_RESP = 0x8007,//查询玩家的账号信息响应
            AU_CHARACTERINFO_UPDATE = 0x0008,//修改玩家的账号信息
            AU_CHARACTERINFO_UPDATE_RESP = 0x8008,//修改玩家的账号信息响应
            AU_ITEMSHOP_QUERY = 0x0009,//查看游戏里面所有道具信息
            AU_ITEMSHOP_QUERY_RESP = 0x8009,//查看游戏里面所有道具信息响应
            AU_ITEMSHOP_DELETE = 0x0010,//删除玩家道具信息
            AU_ITEMSHOP_DELETE_RESP = 0x8010,//删除玩家道具信息响应
            AU_ITEMSHOP_BYOWNER_QUERY = 0x0011,////查看玩家身上道具信息
            AU_ITEMSHOP_BYOWNER_QUERY_RESP = 0x8011,////查看玩家身上道具信息
            AU_ITEMSHOP_TRADE_QUERY = 0x0012,//查看玩家交易记录信息
            AU_ITEMSHOP_TRADE_QUERY_RESP = 0x8012,//查看玩家交易记录信息的响应
            AU_ITEMSHOP_CREATE = 0x0013,//添加玩家礼物盒道具信息
            AU_ITEMSHOP_CREATE_RESP = 0x8013,//添加玩家礼物盒道具信息响应
            AU_LEVELEXP_QUERY = 0x0014,//查看玩家等级经验
            AU_LEVELEXP_QUERY_RESP = 0x8014,////查看玩家等级经验响应
            AU_USERLOGIN_STATUS_QUERY = 0x0015,//查看玩家登录状态
            AU_USERLOGIN_STATUS_QUERY_RESP = 0x8015,//查看玩家登录状态响应
            AU_USERCHARAGESUM_QUERY = 0x0016,//得到充值记录总和
            AU_USERCHARAGESUM_QUERY_RESP = 0x8016,//得到充值记录总和响应
            AU_CONSUME_QUERY = 0x0017,//查看玩家的消费记录
            AU_CONSUME_QUERY_RESP = 0x8017,//查看玩家的消费记录响应
            AU_USERCONSUMESUM_QUERY = 0x0018,//得到消费记录总和
            AU_USERCONSUMESUM_QUERY_RESP = 0x8018,//得到消费记录总和响应
            AU_USERMCASH_QUERY = 0x0019,//玩家充值记录查询
            AU_USERMCASH_QUERY_RESP = 0x8019,//玩家充值记录查询响应
            AU_USERGCASH_QUERY = 0x0020,//玩家Ｇ币记录查询
            AU_USERGCASH_QUERY_RESP = 0x8020,//玩家Ｇ币记录查询响应
            AU_USERGCASH_UPDATE = 0x0021,//补偿玩家G币
            AU_USERGCASH_UPDATE_RESP = 0x8021,//补偿玩家G币的响应
            AU_MESSENGER_QUERY = 0x0023,
            AU_MESSENGER_QUERY_RESP = 0x8023,
            AU_MESSENGER_UPDATE = 0x0024,
            AU_MESSENGER_UPDATE_RESP = 0x8024,
            AU_WEDDING_QUERY = 0x0025,
            AU_WEDDING_QUERY_RESP = 0x8025,
            AU_WEDDINGGROUND_QUERY = 0x0026,
            AU_WEDDINGGROUND_QUERY_RESP = 0x8026,
            AU_GOODS_QUERY = 0x0027,
            AU_GOODS_QUERY_RESP = 0x8027,
            AU_JOINPCIP_QUERY = 0x0028,
            AU_JOINPCIP_QUERY_RESP = 0x8028,
            AU_JOINPCIP_Insert = 0x0029,
            AU_JOINCPIP_Insert_RESP = 0x8029,
            AU_JOINPCIP_Delete = 0x0030,
            AU_JOINPCIP_Delete_RESP = 0x8030,
            AU_MEMBERACTIVE_CREATE = 0x0031,
            AU_MEMBERACTIVE_CREATE_RESP = 0x8031,

            AU_BOARDMESSAGE_REQ = 0x0032,
            AU_BOARDMESSAGE_REQ_RESP = 0x8032,
            AU_BOARDTASK_INSERT = 0x0033,
            AU_BOARDTASK_INSERT_RESP = 0x8033,
            AU_BOARDTASK_QUERY = 0x0034,
            AU_BOARDTASK_QUERY_RESP = 0x8034,
            AU_BOARDTASK_UPDATE = 0x0035,
            AU_BOARDTASK_UPDATE_RESP = 0x8035,
            AU_GS_QUERY = 0x0036,
            AU_GS_QUERY_RESP = 0x8036,
            /// <summary>
            /// CR_ADMIN 疯狂卡丁车工具操作消息集
            /// </summary>
            CR_ACCOUNT_QUERY = 0x0001,//玩家帐号信息查询
            CR_ACCOUNT_QUERY_RESP = 0x8001,//玩家帐号信息查询响应
            CR_ACCOUNTACTIVE_QUERY = 0x0002,//玩家帐号激活信息
            CR_ACCOUNTACTIVE_QUERY_RESP = 0x8002,//玩家帐号激活响应
            CR_CALLBOARD_QUERY = 0x0003,//公告信息查询
            CR_CALLBOARD_QUERY_RESP = 0x8003,//公告信息查询响应
            CR_CALLBOARD_CREATE = 0x0004,//发布公告
            CR_CALLBOARD_CREATE_RESP = 0x8004,//发布公告响应
            CR_CALLBOARD_UPDATE = 0x0005,//更新公告信息
            CR_CALLBOARD_UPDATE_RESP = 0x8005,//更新公告信息的响应
            CR_CALLBOARD_DELETE = 0x0006,//删除公告信息
            CR_CALLBOARD_DELETE_RESP = 0x8006,//删除公告信息的响应

            CR_CHARACTERINFO_QUERY = 0x0007,//玩家角色信息查询
            CR_CHARACTERINFO_QUERY_RESP = 0x8007,//玩家角色信息查询的响应
            CR_CHARACTERINFO_UPDATE = 0x0008,//玩家角色信息查询
            CR_CHARACTERINFO_UPDATE_RESP = 0x8008,//玩家角色信息查询的响应
            CR_CHANNEL_QUERY = 0x0009,//公告频道查询
            CR_CHANNEL_QUERY_RESP = 0x8009,//公告频道查询的响应
            CR_NICKNAME_QUERY = 0x0010,//玩家昵称查询
            CR_NICKNAME_QUERY_RESP = 0x8010,//玩家昵称的响应
            CR_LOGIN_LOGOUT_QUERY = 0x0011,//玩家上线、下线时间查询
            CR_LOGIN_LOGOUT_QUERY_RESP = 0x8011,//玩家上线、下线时间查询的响应
            CR_ERRORCHANNEL_QUERY = 0x0012,//补充错误公告频道查询
            CR_ERRORCHANNEL_QUERY_RESP = 0x8012,//补充错误公告频道查询的响应


            /// <summary>
            /// 充值消费GM工具(0x90)
            /// </summary>
            CARD_USERCHARGEDETAIL_QUERY = 0x0001,//一卡通查询
            CARD_USERCHARGEDETAIL_QUERY_RESP = 0x8001,//一卡通查询响应
            CARD_USERDETAIL_QUERY = 0x0002,//久之游用户注册信息查询
            CARD_USERDETAIL_QUERY_RESP = 0x8002,//久之游用户注册信息查询响应
            CARD_USERCONSUME_QUERY = 0x0003,//休闲币消费查询
            CARD_USERCONSUME_QUERY_RESP = 0x8003,//休闲币消费查询响应
            CARD_VNETCHARGE_QUERY = 0x0004,//互联星空充值查询
            CARD_VNETCHARGE_QUERY_RESP = 0x8004,//互联星空充值查询响应
            CARD_USERDETAIL_SUM_QUERY = 0x0005,//充值合计查询
            CARD_USERDETAIL_SUM_QUERY_RESP = 0x8005,//充值合计查询响应
            CARD_USERCONSUME_SUM_QUERY = 0x0006,//消费合计查询
            CARD_USERCONSUME_SUM_QUERY_RESP = 0x8006,//消费合计响应
            CARD_USERINFO_QUERY = 0x0007,//玩家注册信息查询
            CARD_USERINFO_QUERY_RESP = 0x8007,//玩家注册信息查询响应
            CARD_USERINFO_CLEAR = 0x0008,
            CARD_USERINFO_CLEAR_RESP = 0x8008,
            CARD_USERSECURE_CLEAR = 0x0009,//重置玩家安全码信息
            CARD_USERSECURE_CLEAR_RESP = 0x8009,//重置玩家安全码信息响应
            CARD_USERNICK_QUERY = 0x0010,
            CARD_USERNICK_QUERY_RESP = 0x8010,
            CARD_USERLOCK_UPDATE = 0x0011,
            CARD_USERLOCK_UPDATE_RESP = 0x8011,
            CARD_BALANCE_QUERY = 0x0012,//用户余额查询
            CARD_BALANCE_QUERY_RESP = 0x8012,
            CARD_USERNUM_QUERY = 0x0013,//点卡查询
            CARD_USERNUM_QUERY_RESP = 0x8013,
            CARD_USERHISTORYPWD_QUERY = 0x0014,//历史密码
            CARD_USERHISTORYPWD_QUERY_RESP = 0x8014,
            CARD_USERINITACTIVE_QUERY = 0x0015,//激活游戏
            CARD_USERINITACTIVE_QUERY_RESP = 0x8015,
            CARD_USERLOCK_QUERY = 0x0019,
            CARD_USERLOCK_QUERY_RESP = 0x8019,
            CARD_USERCARDLOCK_QUERY = 0x0020,
            CARD_USERCARDLOCK_QUERY_RESP = 0x8020,
            CARD_USERTOKEN_QUERY = 0x0021,
            CARD_USERTOKEN_QUERY_RESP = 0x8021,
            CARD_USERTOKEN_OPEN = 0x0022,
            CARD_USERTOKEN_OPEN_RESP = 0x8022,
            CARD_USERTOKEN_CLOSE = 0x0023,
            CARD_USERTOKEN_CLOSE_RESP = 0x8023,
            CARD_USERTOKEN_RELEASE = 0x0024,
            CARD_USERTOKEN_RELEASE_RESP = 0x8024,
            CARD_UserCashExp_Query = 0x0025,
            CARD_UserCashExp_Query_RESP = 0x8025,
            CARD_QueryUseDetailExp_Query = 0x0026,
            CARD_QueryUseDetailExp_RESP = 0x8026,
            CARD_USERNUM_ADVANCE_QUERY = 0x0027,
            CARD_USERNUM_ADVANCE_QUERY_RESP = 0x8027,
            CARD_USERCARDHISTORY_QUERY = 0x0031,
            CARD_USERCARDHISTORY_QUERY_RESP = 0x8031,
            CARD_DanceItem_QUERY = 0x0032,
            CARD_DanceItem_QUERY_RESP = 0x8032,
            CARD_RESETHISTORY_QUERY = 0x0033,
            CARD_RESETHISTORY_QUERY_RESP = 0x8033,
            /// <summary>
            /// 劲舞团商城(0x91)
            /// </summary>
            AUSHOP_USERGPURCHASE_QUERY = 0x0001,//用户G币购买记录
            AUSHOP_USERGPURCHASE_QUERY_RESP = 0x8001,//用户G币购买记录
            AUSHOP_USERMPURCHASE_QUERY = 0x0002,//用户M币购买记录
            AUSHOP_USERMPURCHASE_QUERY_RESP = 0x8002,//用户M币购买记录
            AUSHOP_AVATARECOVER_QUERY = 0x0003,//道具回收兑换记
            AUSHOP_AVATARECOVER_QUERY_RESP = 0x8003,//道具回收兑换记
            AUSHOP_USERINTERGRAL_QUERY = 0x0004,//用户积分记录
            AUSHOP_USERINTERGRAL_QUERY_RESP = 0x8004,//用户积分记录
            AUSHOP_USEROPERLOG_CREATE = 0x0005,//用户G币购买记录合计
            AUSHOP_USEROPERLOG_CREATE_RESP = 0x8005,//用户G币购买记录合计响应
            AUSHOP_USERMPURCHASE_SUM_QUERY = 0x0006,//用户M币购买记录合计
            AUSHOP_USERMPURCHASE_SUM_QUERY_RESP = 0x8006,//用户M币购买记录合计响应
            AUSHOP_AVATARECOVER_DETAIL_QUERY = 0x0007,// 具回收兑换详细记录
            AUSHOP_AVATARECOVER_DETAIL_QUERY_RESP = 0x8007,// 具回收兑换详细记录
            AUSHOP_WAREHOUSE_QUERY = 0x0008,//玩家游戏里面仓库里面的道具
            AUSHOP_WAREHOUSE_QUERY_RESP = 0x8008,//玩家游戏里面仓库里面的道具
            AUSHOP_REPEATGet_REFUND = 0x0012,//劲舞团商城 - 允许用户重新领取
            AUSHOP_REPEATGet_REFUND_RESP = 0x8012,//劲舞团商城 - 允许用户重新领取
            AUSHOP_SPECIALAVATITEM_QUERY = 0x0013,//小喇叭
            AUSHOP_SPECIALAVATITEM_QUERY_RESP = 0x8013,//小喇叭
            AUSHOP_OTHERSPECIALAVATITEM_QUERY = 0x0014,//其他的特殊道具
            AUSHOP_OTHERSPECIALAVATITEM_QUERY_RESP = 0x8014,//其他的特殊道具

            DEPARTMENT_CREATE = 0x0009,//部门创建
            DEPARTMENT_CREATE_RESP = 0x8009,//部门创建响应
            DEPARTMENT_UPDATE = 0x0010,//部门修改
            DEPARTMENT_UPDATE_RESP = 0x8010,//部门修改响应
            DEPARTMENT_DELETE = 0x0011,//部门删除
            DEPARTMENT_DELETE_RESP = 0x8011,//部门删除响应
            DEPARTMENT_ADMIN = 0x0012,//部门管理
            DEPARTMENT_ADMIN_RESP = 0x8012,//部门管理响应

            /// <summary>
            /// 劲乐团工具(0x92)
            /// </summary>
            O2JAM_CHARACTERINFO_QUERY = 0x0001,//玩家角色信息查询
            O2JAM_CHARACTERINFO_QUERY_RESP = 0x8001,//玩家角色信息查询
            O2JAM_CHARACTERINFO_UPDATE = 0x0002,//玩家角色信息更新
            O2JAM_CHARACTERINFO_UPDATE_RESP = 0x8002,//玩家角色信息更新
            O2JAM_ITEM_QUERY = 0x0003,//玩家道具信息查询
            O2JAM_ITEM_QUERY_RESP = 0x8003,//玩家角色信息查询
            O2JAM_ITEM_UPDATE = 0x0004,//玩家道具信息更新
            O2JAM_ITEM_UPDATE_RESP = 0x8004,//玩家道具信息更新
            O2JAM_CONSUME_QUERY = 0x0005,//玩家消费信息查询
            O2JAM_CONSUME_QUERY_RESP = 0x8005,//玩家消费信息查询
            O2JAM_ITEMDATA_QUERY = 0x0006,// 具列表查询
            O2JAM_ITEMDATA_QUERY_RESP = 0x8006,// 具列表信息查询
            O2JAM_GIFTBOX_QUERY = 0x0007,//玩家礼物盒查询
            O2JAM_GIFTBOX_QUERY_RESP = 0x8007,//玩家礼物盒查询
            O2JAM_USERGCASH_UPDATE = 0x0008,//补偿玩家G币
            O2JAM_USERGCASH_UPDATE_RESP = 0x8008,//补偿玩家G币的响应
            O2JAM_CONSUME_SUM_QUERY = 0x0009,//玩家消费信息查询
            O2JAM_CONSUME_SUM_QUERY_RESP = 0x8009,//玩家消费信息查询
            O2JAM_GIFTBOX_CREATE_QUERY = 0x0010,//添加玩家礼物盒 具
            O2JAM_GIFTBOX_CREATE_QUERY_RESP = 0x8010,//添加玩家礼物盒 具
            O2JAM_ITEMNAME_QUERY = 0x0011,
            O2JAM_ITEMNAME_QUERY_RESP = 0x8011,

            O2JAM_GIFTBOX_DELETE = 0x0012,
            O2JAM_GIFTBOX_DELETE_RESP = 0x8012,

            DEPARTMENT_RELATE_QUERY = 0x0013,//部门关联查询
            DEPARTMENT_RELATE_QUERY_RESP = 0x8013,//部门关联查询


            DEPART_RELATE_GAME_QUERY = 0x0014,
            DEPART_RELATE_GAME_QUERY_RESP = 0x8014,
            USER_SYSADMIN_QUERY = 0x0015,
            USER_SYSADMIN_QUERY_RESP = 0x8015,

            O2JAM_USERLOGIN_DEL = 0x0013,
            O2JAM_USERLOGIN_DEL_RESP = 0x8013,

            /// <summary>
            /// 劲乐团IIGM工具(0x93)
            /// </summary>
            O2JAM2_ACCOUNT_QUERY = 0x0001,//玩家帐号信息查询
            O2JAM2_ACCOUNT_QUERY_RESP = 0x8001,//玩家帐号信息查询响应
            O2JAM2_ACCOUNTACTIVE_QUERY = 0x0002,//玩家帐号激活信息
            O2JAM2_ACCOUNTACTIVE_QUERY_RESP = 0x8002,//玩家帐号激活响应

            O2JAM2_CHARACTERINFO_QUERY = 0x0003,//用户信息查询
            O2JAM2_CHARACTERINFO_QUERY_RESP = 0x8003,
            O2JAM2_CHARACTERINFO_UPDATE = 0x0004,//用户信息修改
            O2JAM2_CHARACTERINFO_UPDATE_RESP = 0x8004,
            O2JAM2_ITEMSHOP_QUERY = 0x0005,
            O2JAM2_ITEMSHOP_QUERY_RESP = 0x8005,
            O2JAM2_ITEMSHOP_DELETE = 0x0006,
            O2JAM2_ITEMSHOP_DELETE_RESP = 0x8006,
            O2JAM2_MESSAGE_QUERY = 0x0007,
            O2JAM2_MESSAGE_QUERY_RESP = 0x8007,
            O2JAM2_MESSAGE_CREATE = 0x0008,
            O2JAM2_MESSAGE_CREATE_RESP = 0x8008,
            O2JAM2_MESSAGE_DELETE = 0x0009,
            O2JAM2_MESSAGE_DELETE_RESP = 0x8009,
            O2JAM2_CONSUME_QUERY = 0x0010,
            O2JAM2_CONUMSE_QUERY_RESP = 0x8010,
            O2JAM2_CONSUME_SUM_QUERY = 0x0011,
            O2JAM2_CONUMSE_QUERY_SUM_RESP = 0x8011,
            O2JAM2_TRADE_QUERY = 0x0012,
            O2JAM2_TRADE_QUERY_RESP = 0x8012,
            O2JAM2_TRADE_SUM_QUERY = 0x0013,
            O2JAM2_TRADE_QUERY_SUM_RESP = 0x8013,
            O2JAM2_AVATORLIST_QUERY = 0x0014,
            O2JAM2_AVATORLIST_QUERY_RESP = 0x8014,

            O2JAM2_ACCOUNT_CLOSE = 0x0015,//封停帐户的权限信息
            O2JAM2_ACCOUNT_CLOSE_RESP = 0x8015,//封停帐户的权限信息响应

            O2JAM2_ACCOUNT_OPEN = 0x0016,//解封帐户的权限信息
            O2JAM2_ACCOUNT_OPEN_RESP = 0x8016,//解封帐户的权限信息响应
            O2JAM2_MEMBERBANISHMENT_QUERY = 0x0017,
            O2JAM2_MEMBERBANISHMENT_QUERY_RESP = 0x8017,
            O2JAM2_MEMBERSTOPSTATUS_QUERY = 0x0018,
            O2JAM2_MEMBERSTOPSTATUS_QUERY_RESP = 0x8018,
            O2JAM2_MEMBERLOCAL_BANISHMENT = 0x0019,
            O2JAM2_MEMBERLOCAL_BANISHMENT_RESP = 0x8019,
            O2JAM2_USERLOGIN_DELETE = 0x0020,
            O2JAM2_USERLOGIN_DELETE_RESP = 0x8020,
            O2JAM2_LEVELEXP_QUERY = 0x0021,
            O2JAM2_LEVELEXP_QUERY_RESP = 0x8021,




            SDO_CHALLENGE_QUERY = 0x0052,
            SDO_CHALLENGE_QUERY_RESP = 0x8052,
            SDO_CHALLENGE_INSERT = 0x0053,
            SDO_CHALLENGE_INSERT_RESP = 0x8053,
            SDO_CHALLENGE_UPDATE = 0x0054,
            SDO_CHALLENGE_UPDATE_RESP = 0x8054,
            SDO_CHALLENGE_DELETE = 0x0055,
            SDO_CHALLENGE_DELETE_RESP = 0x8055,
            SDO_MUSICDATA_QUERY = 0x0056,
            SDO_MUSICDATA_QUERY_RESP = 0x8056,

            SDO_MUSICDATA_OWN_QUERY = 0x0057,
            SDO_MUSICDATA_OWN_QUERY_RESP = 0x8057,


            SDO_CHALLENGE_SCENE_QUERY = 0x0058,
            SDO_CHALLENGE_SCENE_QUERY_RESP = 0x8058,
            SDO_CHALLENGE_SCENE_CREATE = 0x0059,
            SDO_CHALLENGE_SCENE_CREATE_RESP = 0x8059,
            SDO_CHALLENGE_SCENE_UPDATE = 0x0060,
            SDO_CHALLENGE_SCENE_UPDATE_RESP = 0x8060,
            SDO_CHALLENGE_SCENE_DELETE = 0x0061,
            SDO_CHALLENGE_SCENE_DELETE_RESP = 0x8061,


            SDO_MEDALITEM_CREATE = 0x0062,
            SDO_MEDALITEM_CREATE_RESP = 0x8062,
            SDO_MEDALITEM_UPDATE = 0x0063,
            SDO_MEDALITEM_UPDATE_RESP = 0x8063,
            SDO_MEDALITEM_DELETE = 0x0064,
            SDO_MEDALITEM_DELETE_RESP = 0x8064,
            SDO_MEDALITEM_QUERY = 0x0065,
            SDO_MEDALITEM_QUERY_RESP = 0x8065,

            SDO_MEDALITEM_OWNER_QUERY = 0x0066,
            SDO_MEDALITEM_OWNER_QUERY_RESP = 0x8066,


            SDO_MEMBERDANCE_OPEN = 0x0067,
            SDO_MEMBERDANCE_OPEN_RESP = 0x8067,
            SDO_MEMBERDANCE_CLOSE = 0x0068,
            SDO_MEMBERDANCE_CLOSE_RESP = 0x8068,
            SDO_PUNISH_UPDATE_QUERY = 0x0096,
            SDO_PUNISH_UPDATE_QUERY_RESP = 0x8096,
            SDO_NotReachMoney_Query = 0x0103,
            SDO_NotReachMoney_Query_RESP = 0x8103,

            /// <summary>
            /// 劲爆足球
            /// </summary>
            SOCCER_CHARACTERINFO_QUERY = 0x0001,//用户信息查询
            SOCCER_CHARACTERINFO_QUERY_RESP = 0x8001,
            SOCCER_CHARCHECK_QUERY = 0x0002,//用户NameCheck,SocketCheck
            SOCCER_CHARCHECK_QUERY_RESP = 0x8002,
            SOCCER_CHARITEMS_RECOVERY_QUERY = 0x0003,//用户启用
            SOCCER_CCHARITEMS_RECOVERY_QUERY_RESP = 0x8003,
            SOCCER_CHARPOINT_QUERY = 0x0004,//用户G币修改
            SOCCER_CHARPOINT_QUERY_RESP = 0x8004,
            SOCCER_DELETEDCHARACTERINFO_QUERY = 0x0005,//删除用户查询
            SOCCER_DELETEDCHARACTERINFO_QUERY_RESP = 0x8005,

            SOCCER_CHARACTERSTATE_MODIFY = 0x0006,//停封角色
            SOCCER_CHARACTERSTATE_MODIFY_RESP = 0x8006,
            SOCCER_ACCOUNTSTATE_MODIFY = 0x0007,//停封玩家
            SOCCER_ACCOUNTSTATE_MODIFY_RESP = 0x8007,
            SOCCER_CHARACTERSTATE_QUERY = 0x0008,//停封角色查询
            SOCCER_CHARACTERSTATE_QUERY_RESP = 0x8008,
            SOCCER_ACCOUNTSTATE_QUERY = 0x0009,//停封玩家查询
            SOCCER_ACCOUNTSTATE_QUERY_RESP = 0x8009,
            SOCCER_ACCOUNTACTIVE_QUERY = 0x0010,//玩家激活查询		
            SOCCER_ACCOUNTACTIVE_QUERY_RESP = 0x8010,
            SOCCER_USERTRADE_QUERY = 0x0011,//玩家道具购买记录，赠送记录
            SOCCER_USERTRADE_QUERY_RESP = 0x8011,

            SOCCER_ITEM_SKILL_MODIFY = 0x0012,//删除角色道具、技能
            SOCCER_ITEM_SKILL_MODIFY_RESP = 0x8012,//删除角色道具、技能

            SOCCER_ACCOUNT_ITEMSKILL_QUERY = 0x0013,//玩家身上的道具、技能
            SOCCER_ACCOUNT_ITEMSKILL_QUER_RESPY = 0x8013,//玩家身上的道具、技能 

            SOCCER_CHARINFO_MODIFY = 0x0014,//玩家角色信息修改
            SOCCER_CHARINFO_MODIFY_RESPY = 0x8014,//玩家角色信息修改

            SOCCER_ITEMSHOP_INSERT = 0x0015,//给玩家赠送道具
            SOCCER_ITEMSHOP_INSERT_RESPY = 0x8015,//给玩家赠送道具

            SOCCER_ITEM_SKILL_QUERY = 0x0016,//获得角色道具、技能
            SOCCER_ITEM_SKILL_QUERY_RESP = 0x8016,//获得角色道具、技能

            SOCCER_ITEM_SKILL_BLUR_QUERY = 0x0017,//获得角色道具、技能
            SOCCER_ITEM_SKILL_BLUR_QUERY_RESP = 0x8017,//获得角色道具、技能
            CARD_DanceItem_Qualification_QUERY = 0x0034,
            CARD_DanceItem_Qualification_QUERY_RESP = 0x8034,
            AU_USERNICK_UPDATE = 0x0022,
            AU_USERNICK_UPDATE_RESP = 0x8022,

            LINK_SERVERIP_DELETE = 0x0010,
            LINK_SERVERIP_DELETE_RESP = 0x8010,

            CARD_USER_QUERY = 0x0018,
            CARD_USER_QUERY_RESP = 0x8018,

            SDO_USERLOGIN_DEL = 0x0078,
            SDO_USERLOGIN_DEL_RESP = 0x8078,
            SDO_GATEWAY_QUERY = 0x0079,
            SDO_GATEWAY_QUERY_RESP = 0x8079,
            SDO_USERLOGIN_CLEAR = 0x0080,
            SDO_USERLOGIN_CLEAR_RESP = 0x8080,

            TOKEN_TOKENSTATUS_QUERY = 0x0016,//显示令牌的当前状态
            TOKEN_TOKENSTATUS_QUERY_RESP = 0x8016,
            TOKEN_MODIFYUSER_QUERY = 0x0017,//用户令牌修改
            TOKEN_MODIFYUSER_QUERY_RESP = 0x8017,

            CARD_MOBILEINFO_QUERY = 0x0028,
            CARD_MOBILEINFO_QUERY_RESP = 0x8028,
            CARD_TOKENPASSWD_SYNC = 0x0029,
            CARD_TOKENPASSWD_SYNC_RESP = 0x8029,
            CARD_MOBILEINFO_UPDATE = 0x0030,
            CARD_MOBILEINFO_UPDATE_RESP = 0x8030,

            CARD_USERACTIVETOKEN_QUERY = 0x0035,
            CARD_USERACTIVETOKEN_QUERY_RESP = 0x8035,

            FJ_CharacterInfo_Query = 0x0001,
            FJ_CharacterInfo_Query_Resp = 0x8001,
            FJ_ItemShop_Query = 0x0002,
            FJ_ItemShop_Query_Resp = 0x8002,
            FJ_Message_Query = 0x0003,
            FJ_Message_Query_Resp = 0x8003,
            FJ_WareHouse_Query = 0x0004,
            FJ_WareHouse_Query_Resp = 0x8004,
            FJ_Login_Query = 0x0005,
            FJ_Login_Query_Resp = 0x8005,
            FJ_Login_Out_Update = 0x0006,
            FJ_Login_Out_Update_Resp = 0x8006,
            FJ_PlayPosition_Query = 0x0007,
            FJ_PlayPosition_Query_Resp = 0x8007,
            FJ_ItemShop_Del = 0x0008,
            FJ_ItemShop_Del_Resp = 0x8008,
            FJ_AccountActive_Query = 0x0009,
            FJ_AccountActive_Query_Resp = 0x8009,
            FJ_ActiveCode_Query = 0x0010,
            FJ_ActiveCode_Query_Resp = 0x8010,

            FJ_ItemShop_Insert = 0x0011,
            FJ_ItemShop_Insert_Resp = 0x8011,
            FJ_Wedding_Query = 0x0012,
            FJ_Wedding_Query_Resp = 0x8012,
            FJ_Wedding_Create = 0x0013,
            FJ_Wedding_Create_Resp = 0x8013,
            FJ_Wedding_Delete = 0x0014,
            FJ_Wedding_Delete_Resp = 0x8014,
            FJ_Task_Query = 0x0015,
            FJ_Task_Query_Resp = 0x8015,
            FJ_PlayerLevelMoney_Query = 0x0016,
            FJ_PlayerLevelMoney_Query_Resp = 0x8016,
            FJ_Guild_Query = 0x0017,
            FJ_Guild_Query_Resp = 0x8017,
            FJ_Guild_Create = 0x0018,
            FJ_Guild_Create_Resp = 0x8018,
            FJ_Guild_Delete = 0x0019,
            FJ_Guild_Delete_Resp = 0x8019,
            FJ_SocialRelate_Query = 0x0020,
            FJ_SocialRelate_Query_Resp = 0x8020,
            FJ_SocialRelate_Create = 0x0021,
            FJ_SocialRelate_Create_Resp = 0x8021,
            FJ_SocialRelate_Delete = 0x0022,
            FJ_SocialRelate_Delete_Resp = 0x8022,
            FJ_UserBan_Query = 0x0023,
            FJ_UserBan_Query_Resp = 0x8023,
            FJ_UserBan_Close = 0x0024,
            FJ_UserBan_Close_Resp = 0x8024,
            FJ_UserBan_Open = 0x0025,
            FJ_UserBan_Open_Resp = 0x8025,
            FJ_PlayerSkill_Insert = 0x0026,
            FJ_PlayerSkill_Insert_Resp = 0x8026,
            FJ_PlayerSkill_Update = 0x0027,
            FJ_PlayerSkill_Update_Resp = 0x8027,
            FJ_PlayerSkill_Delete = 0x0028,
            FJ_PlayerSkill_Delete_Resp = 0x8028,
            FJ_CharacterInfo_Update = 0x0029,
            FJ_CharacterInfo_Update_Resp = 0x8029,
            FJ_ShortCut_Query = 0x0030,
            FJ_ShortCut_Query_Resp = 0x8030,
            FJ_Message_Batch_Insert = 0x0031,
            FJ_Message_Batch_Insert_Resp = 0x8031,
            FJ_PlayerPwd_Update = 0x0032,
            FJ_PlayerPwd_Update_Resp = 0x8032,
            FJ_Task_Insert = 0x0033,
            FJ_Task_Insert_Resp = 0x8033,
            FJ_Task_Delete = 0x0034,
            FJ_Task_Delete_Resp = 0x8034,
            FJ_Task_Update = 0x0035,
            FJ_Task_Update_Resp = 0x8035,
            FJ_Delete_Character = 0x0036,
            FJ_Delete_Character_Resp = 0x8036,
            FJ_Recovery_Character = 0x0037,
            FJ_Recovery_Character_Resp = 0x8037,
            FJ_Guild_QueryAll = 0x0038,
            FJ_Guild_QueryAll_RESP = 0x8038,
            FJ_GS_Query = 0x0039,
            FJ_GS_Query_Resp = 0x8039,
            FJ_BoardList_Query = 0x0040,
            FJ_BoardList_Query_Resp = 0x8040,
            FJ_BoardList_Insert = 0x0041,
            FJ_BoardList_Insert_Resp = 0x8041,
            FJ_BoardList_Delete = 0x0042,
            FJ_BoardList_Delete_Resp = 0x8042,
            FJ_PlayerSkill_Query = 0x0044,
            FJ_PlayerSkill_Query_Resp = 0x8044,
            FJ_SkillList_Query = 0x0045,
            FJ_SkillList_Query_Resp = 0x8045,
            FJ_TempPassword_Query = 0x0046,
            FJ_TempPassword_Query_Resp = 0x8046,
            FJ_Currank_Query = 0x0047,
            FJ_Currank_Query_Resp = 0x8047,
            FJ_PWD_Recover = 0x0048,
            FJ_PWD_Recover_Resp = 0x0048,

            FJ_MAP_Query = 0x0049,
            FJ_MAP_Query_Resp = 0x8049,
            FJ_PlayPosition_Update = 0x0050,
            FJ_PlayPosition_Update_Resp = 0x8050,
            FJ_QuestTable_Query = 0x0051,
            FJ_QuestTable_Query_Resp = 0x8051,

            FJ_ItemShop_Style_Query = 0x0052,
            FJ_ItemShop_Style_Query_Resp = 0x8052,

            FJ_ItemShop_QueryAll = 0x0053,
            FJ_ItemShop_QueryAll_Resp = 0x8053,

            FJ_ItemAppend_Style_Query = 0x0054,
            FJ_ItemAppend_Style_Query_Resp = 0x8054,
           
            FJ_ItemAppend_Query = 0x0055,
            FJ_ItemAppend_Query_Resp = 0x8055,

            FJ_ItemAppendList_Query = 0x0056,
            FJ_ItemAppendList_Query_Resp = 0x8056,

            FJ_ItemShop_Delete = 0x0057,
		    FJ_ItemShop_Delete_Resp = 0x8057,

            FJ_ItemLog_Query = 0x0058,
            FJ_ItemLog_Query_Resp = 0x8058,

            FJ_ItemLogType_Query = 0x0059,
            FJ_ItemLogType_Query_Resp = 0x8059,

            RC_Character_Query = 0x0001,
            RC_Character_Query_Resp = 0x8001,
            RC_UserLoginOut_Query = 0x0002,
            RC_UserLoginOut_Query_Resp = 0x8002,
            RC_UserLogin_Del = 0x0003,
            RC_UserLogin_Del_Resp = 0x8003,
            RC_RcCode_Query = 0x0004,
            RC_RcCode_Query_Resp = 0x8004,
            RC_RcUser_Query = 0x0005,
            RC_RcUser_Query_Resp = 0x8005,

            AUSHOP_ERRBUY_REFUND = 0x0009,//劲舞团商城 - 错误购买退款 
            AUSHOP_ERRBUY_REFUND_RESP = 0x8009,//劲舞团商城 - 错误购买退款 
            AUSHOP_REPEATBuy_REFUND = 0x0010,//劲舞团商城 - 重复购买退款 
            AUSHOP_REPEATBuy_REFUND_RESP = 0x8010,//劲舞团商城 - 重复购买退款 
            AUSHOP_FillBuy_REFUND = 0x0011,//劲舞团商城 - 补发
            AUSHOP_FillBuy_REFUND_RESP = 0x8011,//劲舞团商城 - 补发
            ERROR = 0xFFFF
        }

        /// <summary>
        /// 消息类型标签
        /// </summary>
        public enum Msg_Category : byte
        {
            COMMON = 0x80,//公用消息集
            USER_ADMIN = 0x81,//GM帐号操作消息集
            MODULE_ADMIN = 0x82,//模块操作消息集
            USER_MODULE_ADMIN = 0x83,//用户和模块操作消息集
            GAME_ADMIN = 0x84, //游戏模块操作消息集
            NOTES_ADMIN = 0x85,//NOTES模块操作消息集
            MJ_ADMIN = 0x86,//猛将游戏GM工具操作消息集
            SDO_ADMIN = 0x87,//超级舞者操作消息集
            AU_ADMIN = 0x88,//劲舞团
            CR_ADMIN = 0x89,//疯狂卡丁车操作消息集
            CARD_ADMIN = 0x90,
            AUSHOP_ADMIN = 0x91,
            O2JAM_ADMIN = 0x92,
            O2JAM2_ADMIN = 0x93,
            SOCCER_ADMIN = 0x94,//劲爆足球记录消息集
            FJ_ADMIN = 0x95,
            RC_ADMIN = 0x96,
            ERROR = 0xFF
        }

        /// <summary>
        /// 消息状态标签
        /// </summary>
        public enum Body_Status : ushort
        {
            MSG_STRUCT_OK = 0,
            MSG_STRUCT_ERROR = 1,
            ILLEGAL_SOURCE_ADDR = 2,
            AUTHEN_ERROR = 3,
            OTHER_ERROR = 4
        }
        /// <summary>
        /// 消息头标签
        /// </summary>
        public enum Message_Tag_ID : uint
        {
            /// <summary>
            /// 公共模块(0x80)
            /// </summary>
            CONNECT = 0x800001,//连接请求
            CONNECT_RESP = 0x808001,//连接响应
            DISCONNECT = 0x800002,//断开请求
            DISCONNECT_RESP = 0x808002,//断开响应
            ACCOUNT_AUTHOR = 0x800003,//用户身份验证请求
            ACCOUNT_AUTHOR_RESP = 0x808003,//用户身份验证响应
            SERVERINFO_IP_QUERY = 0x800004,
            SERVERINFO_IP_QUERY_RESP = 0x808004,
            GMTOOLS_OperateLog_Query = 0x800005,//查看工具操作记录
            GMTOOLS_OperateLog_Query_RESP = 0x808005,//查看工具操作记录响应


            SERVERINFO_IP_ALL_QUERY = 0x800006,
            SERVERINFO_IP_ALL_QUERY_RESP = 0x808006,
            LINK_SERVERIP_CREATE = 0x800007,
            LINK_SERVERIP_CREATE_RESP = 0x808007,
            CLIENT_PATCH_COMPARE = 0x800008,
            CLIENT_PATCH_COMPARE_RESP = 0x808008,
            CLIENT_PATCH_UPDATE = 0x800009,
            CLIENT_PATCH_UPDATE_RESP = 0x808009,

            GMTOOLS_BUGLIST_QUERY = 0x800011,
            GMTOOLS_BUGLIST_QUERY_RESP = 0x808011,
            GMTOOLS_BUGLIST_INSERT = 0x800012,
            GMTOOLS_BUGLIST_INSERT_RESP = 0x808012,
            GMTOOLS_BUGLIST_UPDATE = 0x800013,
            GMTOOLS_BUGLIST_UPDATE_RESP = 0x808013,
            GMTOOLS_UPDATELIST_QUERY = 0x800014,
            GMTOOLS_UPDATELIST_QUERY_RESP = 0x808014,
            GMTOOLS_RESETSTATICS_QUERY = 0x800015,
            GMTOOLS_RESETSTATICS_QUERY_RESP = 0x808015,

            /// <summary>
            /// 用户管理模块(0x81)
            /// </summary>
            USER_CREATE = 0x810001,//创建GM帐号请求
            USER_CREATE_RESP = 0x818001,//创建GM帐号响应
            USER_UPDATE = 0x810002,//更新GM帐号信息请求
            USER_UPDATE_RESP = 0x818002,//更新GM帐号信息响应
            USER_DELETE = 0x810003,//删除GM帐号信息请求
            USER_DELETE_RESP = 0x818003,//删除GM帐号信息响应
            USER_QUERY = 0x810004,//查询GM帐号信息请求
            USER_QUERY_RESP = 0x818004,//查询GM帐号信息响应
            USER_PASSWD_MODIF = 0x810005,//密码修改请求
            USER_PASSWD_MODIF_RESP = 0x818005, //密码修改信息响应
            USER_QUERY_ALL = 0x810006,//查询所有GM帐号信息
            USER_QUERY_ALL_RESP = 0x818006,//查询所有GM帐号信息响应
            DEPART_QUERY = 0x810007, //查询部门列表
            DEPART_QUERY_RESP = 0x818007,//查询部门列表响应
            UPDATE_ACTIVEUSER = 0x810008,//更新在线用户状态
            UPDATE_ACTIVEUSER_RESP = 0x818008,//更新在线用户状态响应

            /// <summary>
            /// 模块管理(0x82)
            /// </summary>
            MODULE_CREATE = 0x820001,//创建模块信息请求
            MDDULE_CREATE_RESP = 0x828001,//创建模块信息响应
            MODULE_UPDATE = 0x820002,//更新模块信息请求
            MODULE_UPDATE_RESP = 0x828002,//更新模块信息响应
            MODULE_DELETE = 0x820003,//删除模块请求
            MODULE_DELETE_RESP = 0x828003,//删除模块响应
            MODULE_QUERY = 0x820004,//查询模块信息的请求
            MODULE_QUERY_RESP = 0x828004,//查询模块信息的响应

            /// <summary>
            /// 用户与模块管理(0x83)
            /// </summary>
            USER_MODULE_CREATE = 0x830001,//创建用户与模块请求
            USER_MODULE_CREATE_RESP = 0x838001,//创建用户与模块响应
            USER_MODULE_UPDATE = 0x830002,//更新用户与模块的请求
            USER_MODULE_UPDATE_RESP = 0x838002,//更新用户与模块的响应
            USER_MODULE_DELETE = 0x830003,//删除用户与模块请求
            USER_MODULE_DELETE_RESP = 0x838003,//删除用户与模块响应
            USER_MODULE_QUERY = 0x830004,//查询用户所对应模块请求
            USER_MODULE_QUERY_RESP = 0x838004,//查询用户所对应模块响应

            /// <summary>
            /// 游戏管理(0x84)
            /// </summary>
            GAME_CREATE = 0x840001,//创建GM帐号请求
            GAME_CREATE_RESP = 0x848001,//创建GM帐号响应
            GAME_UPDATE = 0x840002,//更新GM帐号信息请求
            GAME_UPDATE_RESP = 0x848002,//更新GM帐号信息响应
            GAME_DELETE = 0x840003,//删除GM帐号信息请求
            GAME_DELETE_RESP = 0x848003,//删除GM帐号信息响应
            GAME_QUERY = 0x840004,//查询GM帐号信息请求
            GAME_QUERY_RESP = 0x848004,//查询GM帐号信息响应
            GAME_MODULE_QUERY = 0x840005,//查询游戏的模块列表
            GAME_MODULE_QUERY_RESP = 0x848005,//查询游戏的模块列表响应


            /// <summary>
            /// NOTES管理(0x85)
            /// </summary>
            NOTES_LETTER_TRANSFER = 0x850001, //取得邮件列表
            NOTES_LETTER_TRANSFER_RESP = 0x858001,//取得邮件列表的响应
            NOTES_LETTER_PROCESS = 0x850002, //邮件处理
            NOTES_LETTER_PROCESS_RESP = 0x858002,//邮件处理
            NOTES_LETTER_TRANSMIT = 0x850003, //邮件转发列表
            NOTES_LETTER_TRANSMIT_RESP = 0x858003,//邮件转发列表
            NOTES_LINKER_GET = 0x850004,
            NOTES_LINKER_GET_RESP = 0x858004,
            NOTES_CONTENT_GET = 0x850005,
            NOTES_CONTENT_GET_RESP = 0x858005,
            NOTES_CONTENT_SEND = 0x850006,
            NOTES_CONTENT_SEND_RESP = 0x858006,
            NOTES_CONTENT_REPLAY = 0x850007,
            NOTES_CONTENT_REPLAY_RESP = 0x858007,
            NOTES_ATTACHMENT_GET = 0x850008,
            NOTES_ATTACHMENT_GET_RESP = 0x858008,
            NOTES_CONTENT_UPDATE = 0x850009,
            NOTES_CONTENT_UPDATE_RESP = 0x858009,
            NOTES_CONTENT_DELETE = 0x850010,
            NOTES_CONTENT_DELETE_RESP = 0x858010,

            /// <summary>
            /// 猛将GM工具(0x86)
            /// </summary>
            MJ_CHARACTERINFO_QUERY = 0x860001,//检查玩家状态
            MJ_CHARACTERINFO_QUERY_RESP = 0x868001,//检查玩家状态响应
            MJ_CHARACTERINFO_UPDATE = 0x860002,//修改玩家状态
            MJ_CHARACTERINFO_UPDATE_RESP = 0x868002,//修改玩家状态响应
            MJ_LOGINTABLE_QUERY = 0x860003,//检查玩家是否在线
            MJ_LOGINTABLE_QUERY_RESP = 0x868003,//检查玩家是否在线响应
            MJ_CHARACTERINFO_EXPLOIT_UPDATE = 0x860004,//修改功勋值
            MJ_CHARACTERINFO_EXPLOIT_UPDATE_RESP = 0x868004,//修改功勋值响应
            MJ_CHARACTERINFO_FRIEND_QUERY = 0x860005,//列出好友名单
            MJ_CHARACTERINFO_FRIEND_QUERY_RESP = 0x868005,//列出好有名单响应
            MJ_CHARACTERINFO_FRIEND_CREATE = 0x860006,//添加好友
            MJ_CHARACTERINFO_FRIEND_CREATE_RESP = 0x868006,//添加好友响应
            MJ_CHARACTERINFO_FRIEND_DELETE = 0x860007,//删除好友
            MJ_CHARACTERINFO_FRIEND_DELETE_RESP = 0x868007,//删除好友响应
            MJ_GUILDTABLE_UPDATE = 0x860008,//修改服务器所有已存在帮会
            MJ_GUILDTABLE_UPDATE_RESP = 0x868008,//修改服务器所有已存在帮会响应
            MJ_ACCOUNT_LOCAL_CREATE = 0x860009,//将服务器上的account表里的玩家信息保存到本地服务器的
            MJ_ACCOUNT_LOCAL_CREATE_RESP = 0x868009,//将服务器上的account表里的玩家信息保存到本地服务器的响应
            MJ_ACCOUNT_REMOTE_DELETE = 0x860010,//永久封停帐号
            MJ_ACCOUNT_REMOTE_DELETE_RESP = 0x868010,//永久封停帐号的响应
            MJ_ACCOUNT_REMOTE_RESTORE = 0x860011,//解封帐号
            MJ_ACCOUNT_REMOTE_RESTORE_RESP = 0x868011,//解封帐号响应
            MJ_ACCOUNT_LIMIT_RESTORE = 0x860012,//有时限的封停
            MJ_ACCOUNT_LIMIT_RESTORE_RESP = 0x868012,//有时限的封停响应
            MJ_ACCOUNTPASSWD_LOCAL_CREATE = 0x860013,//保存玩家密码到本地 
            MJ_ACCOUNTPASSWD_LOCAL_CREATE_RESP = 0x868013,//保存玩家密码到本地
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE = 0x860014,//修改玩家密码 
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE_RESP = 0x868014,//修改玩家密码
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE = 0x860015,//恢复玩家密码
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE_RESP = 0x868015,//恢复玩家密码
            MJ_ITEMLOG_QUERY = 0x860016,//检查该用户交易记录
            MJ_ITEMLOG_QUERY_RESP = 0x868016,//检查该用户交易记录
            MJ_GMTOOLS_LOG_QUERY = 0x860017,//检查使用者操作记录
            MJ_GMTOOLS_LOG_QUERY_RESP = 0x868017,//检查使用者操作记录
            MJ_MONEYSORT_QUERY = 0x860018,//根据金钱排序
            MJ_MONEYSORT_QUERY_RESP = 0x868018,//根据金钱排序的响应
            MJ_LEVELSORT_QUERY = 0x860019,//根据等级排序
            MJ_LEVELSORT_QUERY_RESP = 0x868019,//根据等级排序的响应
            MJ_MONEYFIGHTERSORT_QUERY = 0x860020,//根据不同职业金钱排序
            MJ_MONEYFIGHTERSORT_QUERY_RESP = 0x868020,//根据不同职业金钱排序的响应
            MJ_LEVELFIGHTERSORT_QUERY = 0x860021,//根据不同职业等级排序
            MJ_LEVELFIGHTERSORT_QUERY_RESP = 0x868021,//根据不同职业等级排序的响应
            MJ_MONEYTAOISTSORT_QUERY = 0x860022,//根据道士金钱排序
            MJ_MONEYTAOISTSORT_QUERY_RESP = 0x868022,//根据道士金钱排序的响应
            MJ_LEVELTAOISTSORT_QUERY = 0x860023,//根据道士等级排序
            MJ_LEVELTAOISTSORT_QUERY_RESP = 0x868023,//根据道士等级排序的响应
            MJ_MONEYRABBISORT_QUERY = 0x860024,//根据法师金钱排序
            MJ_MONEYRABBISORT_QUERY_RESP = 0x868024,//根据法师金钱排序的响应
            MJ_LEVELRABBISORT_QUERY = 0x860025,//根据法师等级排序
            MJ_LEVELRABBISORT_QUERY_RESP = 0x868025,//根据法师等级排序的响应
            MJ_ACCOUNT_QUERY = 0x860026,//猛将帐号查询
            MJ_ACCOUNT_QUERY_RESP = 0x868026,//猛将帐号查询响应
            MJ_ACCOUNT_LOCAL_QUERY = 0x860027,//查询猛将本地帐号
            MJ_ACCOUNT_LOCAL_QUERY_RESP = 0x868027,//查询猛将本地帐号响应
            SDO_ACCOUNT_QUERY = 0x870026,//查看玩家的帐号信息
            SDO_ACCOUNT_QUERY_RESP = 0x878026,//查看玩家的帐号信息响应
            SDO_CHARACTERINFO_QUERY = 0x870027,//查看任务资料的信息
            SDO_CHARACTERINFO_QUERY_RESP = 0x878027,//查看人物资料的信息响应
            SDO_ACCOUNT_CLOSE = 0x870028,//封停帐户的权限信息
            SDO_ACCOUNT_CLOSE_RESP = 0x878028,//封停帐户的权限信息响应
            SDO_ACCOUNT_OPEN = 0x870029,//解封帐户的权限信息
            SDO_ACCOUNT_OPEN_RESP = 0x878029,//解封帐户的权限信息响应
            SDO_PASSWORD_RECOVERY = 0x870030,//玩家找回密码
            SDO_PASSWORD_RECOVERY_RESP = 0x878030,//玩家找回密码响应
            SDO_CONSUME_QUERY = 0x870031,//查看玩家的消费记录
            SDO_CONSUME_QUERY_RESP = 0x878031,//查看玩家的消费记录响应
            SDO_USERONLINE_QUERY = 0x870032,//查看玩家上下线状态
            SDO_USERONLINE_QUERY_RESP = 0x878032,//查看玩家上下线状态响应
            SDO_USERTRADE_QUERY = 0x870033,//查看玩家交易状态
            SDO_USERTRADE_QUERY_RESP = 0x878033,//查看玩家交易状态响应
            SDO_CHARACTERINFO_UPDATE = 0x870034,//修改玩家的账号信息
            SDO_CHARACTERINFO_UPDATE_RESP = 0x878034,//修改玩家的账号信息响应
            SDO_ITEMSHOP_QUERY = 0x870035,//查看游戏里面所有道具信息
            SDO_ITEMSHOP_QUERY_RESP = 0x878035,//查看游戏里面所有道具信息响应
            SDO_ITEMSHOP_DELETE = 0x870036,//删除玩家道具信息
            SDO_ITEMSHOP_DELETE_RESP = 0x878036,//删除玩家道具信息响应
            SDO_GIFTBOX_CREATE = 0x870037,//添加玩家礼物盒道具信息
            SDO_GIFTBOX_CREATE_RESP = 0x878037,//添加玩家礼物盒道具信息响应
            SDO_GIFTBOX_QUERY = 0x870038,//查看玩家礼物盒的道具
            SDO_GIFTBOX_QUERY_RESP = 0x878038,//查看玩家礼物盒的道具响应
            SDO_GIFTBOX_DELETE = 0x870039,//删除玩家礼物盒的道具
            SDO_GIFTBOX_DELETE_RESP = 0x878039,//删除玩家礼物盒的道具响应
            SDO_USERLOGIN_STATUS_QUERY = 0x870040,//查看玩家登录状态
            SDO_USERLOGIN_STATUS_QUERY_RESP = 0x878040,//查看玩家登录状态响应
            SDO_ITEMSHOP_BYOWNER_QUERY = 0x870041,////查看玩家身上道具信息
            SDO_ITEMSHOP_BYOWNER_QUERY_RESP = 0x878041,////查看玩家身上道具信息
            SDO_ITEMSHOP_TRADE_QUERY = 0x870042,//查看玩家交易记录信息
            SDO_ITEMSHOP_TRADE_QUERY_RESP = 0x878042,//查看玩家交易记录信息的响应
            SDO_MEMBERSTOPSTATUS_QUERY = 0x870043,//查看该帐号状态
            SDO_MEMBERSTOPSTATUS_QUERY_RESP = 0x878043,///查看该帐号状态的响应
            SDO_MEMBERBANISHMENT_QUERY = 0x870044,//查看所有停封的帐号
            SDO_MEMBERBANISHMENT_QUERY_RESP = 0x878044,//查看所有停封的帐号响应
            SDO_USERMCASH_QUERY = 0x870045,//玩家充值记录查询
            SDO_USERMCASH_QUERY_RESP = 0x878045,//玩家充值记录查询响应
            SDO_USERGCASH_UPDATE = 0x870046,//补偿玩家G币
            SDO_USERGCASH_UPDATE_RESP = 0x878046,//补偿玩家G币的响应
            SDO_MEMBERLOCAL_BANISHMENT = 0x870047,//本地保存停封信息
            SDO_MEMBERLOCAL_BANISHMENT_RESP = 0x878047,//本地保存停封信息响应
            SDO_EMAIL_QUERY = 0x870048,//得到玩家的EMAIL
            SDO_EMAIL_QUERY_RESP = 0x878048,//得到玩家的EMAIL响应
            SDO_USERCHARAGESUM_QUERY = 0x870049,//得到充值记录总和
            SDO_USERCHARAGESUM_QUERY_RESP = 0x878049,//得到充值记录总和响应
            SDO_USERCONSUMESUM_QUERY = 0x870050,//得到消费记录总和
            SDO_USERCONSUMESUM_QUERY_RESP = 0x878050,//得到消费记录总和响应
            SDO_USERGCASH_QUERY = 0x870051,//玩家Ｇ币记录查询
            SDO_USERGCASH_QUERY_RESP = 0x878051,//玩家Ｇ币记录查询响应

            SDO_USERNICK_UPDATE = 0x870069,
            SDO_USERNICK_UPDATE_RESP = 0x878069,

            SDO_PADKEYWORD_QUERY = 0x870070,
            SDO_PADKEYWORD_QUERY_RESP = 0x878070,

            SDO_BOARDMESSAGE_REQ = 0x870071,
            SDO_BOARDMESSAGE_REQ_RESP = 0x878071,

            SDO_CHANNELLIST_QUERY = 0x870072,
            SDO_CHANNELLIST_QUERY_RESP = 0x878072,
            SDO_ALIVE_REQ = 0x870073,
            SDO_ALIVE_REQ_RESP = 0x878073,

            SDO_BOARDTASK_QUERY = 0x870074,
            SDO_BOARDTASK_QUERY_RESP = 0x878074,

            SDO_BOARDTASK_UPDATE = 0x870075,
            SDO_BOARDTASK_UPDATE_RESP = 0x878075,

            SDO_BOARDTASK_INSERT = 0x870076,
            SDO_BOARDTASK_INSERT_RESP = 0x878076,

            SDO_DAYSLIMIT_QUERY = 0x870077,
            SDO_DAYSLIMIT_QUERY_RESP = 0x878077,

            SDO_USERLOGIN_DEL = 0x870078,
            SDO_USERLOGIN_DEL_RESP = 0x878078,
            SDO_GATEWAY_QUERY = 0x870079,
            SDO_GATEWAY_QUERY_RESP = 0x878079,
            SDO_USERLOGIN_CLEAR = 0x870080,
            SDO_USERLOGIN_CLEAR_RESP = 0x878080,
            SDO_CHALLENGE_INSERTALL = 0x870081,
            SDO_CHALLENGE_INSERTALL_RESP = 0x878081,
            SDO_USERPASSWD_QUERY = 0x870082,
            SDO_USERPASSWD_QUERY_RESP = 0x878082,
            SDO_USERONLINETIME_QUERY = 0x870083,
            SDO_USERONLINETIME_QUERY_RESP = 0x878083,
            SDO_USER_PUNISH = 0x870088,
            SDO_USER_PUNISH_RESP = 0x878088,
            SDO_PUNISHUSER_IMPORT_QUERY = 0x870089,
            SDO_PUNISHUSER_IMPORT_QUERY_RESP = 0x878089,
            SDO_PUNISHUSER_IMPORT = 0x870090,
            SDO_PUNISHUSER_IMPORT_RESP = 0x878090,
            SDO_USER_PUNISHALL = 0x870091,
            SDO_USER_PUNISHALL_RESP = 0x878091,

            SDO_FRAGMENT_QUERY = 0x870092,
            SDO_FRAGMENT_QUERY_RESP = 0x878092,
            SDO_FRAGMENT_UPDATE = 0x870093,
            SDO_FRAGMENT_UPDATE_RESP = 0x878093,
            SDO_PFUNCTIONITEM_QUERY = 0x870094,
            SDO_PFUNCTIONITEM_QUERY_RESP = 0x878094,
            SDO_USERMARRIAGE_QUERY = 0x870095,
            SDO_USERMARRIAGEQUERY_RESP = 0x878095,
            SDO_PUNISH_UPDATE_QUERY = 0x870096,
            SDO_PUNISH_UPDATE_QUERY_RESP = 0x878096,
            SDO_REMAINCASH_QUERY = 0x870097,
            SDO_REMAINCASH_QUERY_RESP = 0x878097,
            SDO_PADREGIST_QUERY = 0x870098,
            SDO_PADREGIST_QUERY_RESP = 0x878098,
            SDO_MiniDancerTime_QUERY = 0x870099,
            SDO_MiniDancerTime_QUERY_RESP = 0x878099,
            SDO_RewardItem_QUERY = 0x870100,
            SDO_RewardItem_QUERY_RESP = 0x878100,
            SDO_QueryPunishusertimes_QUERY = 0x870101,
            SDO_QueryPunishusertimes_QUERY_RESP = 0x878101,
            /// <summary>
            /// 劲舞团GM工具(0x88)
            /// </summary>
            AU_ACCOUNT_QUERY = 0x880001,//玩家帐号信息查询
            AU_ACCOUNT_QUERY_RESP = 0x888001,//玩家帐号信息查询响应
            AU_ACCOUNTREMOTE_QUERY = 0x880002,//游戏服务器封停的玩家帐号查询
            AU_ACCOUNTREMOTE_QUERY_RESP = 0x888002,//游戏服务器封停的玩家帐号查询响应
            AU_ACCOUNTLOCAL_QUERY = 0x880003,//本地封停的玩家帐号查询
            AU_ACCOUNTLOCAL_QUERY_RESP = 0x888003,//本地封停的玩家帐号查询响应
            AU_ACCOUNT_CLOSE = 0x880004,//封停的玩家帐号
            AU_ACCOUNT_CLOSE_RESP = 0x888004,//封停的玩家帐号响应
            AU_ACCOUNT_OPEN = 0x880005,//解封的玩家帐号
            AU_ACCOUNT_OPEN_RESP = 0x888005,//解封的玩家帐号响应
            AU_ACCOUNT_BANISHMENT_QUERY = 0x880006,//玩家封停帐号查询
            AU_ACCOUNT_BANISHMENT_QUERY_RESP = 0x888006,//玩家封停帐号查询响应
            AU_CHARACTERINFO_QUERY = 0x880007,//查询玩家的账号信息
            AU_CHARACTERINFO_QUERY_RESP = 0x888007,//查询玩家的账号信息响应
            AU_CHARACTERINFO_UPDATE = 0x880008,//修改玩家的账号信息
            AU_CHARACTERINFO_UPDATE_RESP = 0x888008,//修改玩家的账号信息响应
            AU_ITEMSHOP_QUERY = 0x880009,//查看游戏里面所有道具信息
            AU_ITEMSHOP_QUERY_RESP = 0x888009,//查看游戏里面所有道具信息响应
            AU_ITEMSHOP_DELETE = 0x880010,//删除玩家道具信息
            AU_ITEMSHOP_DELETE_RESP = 0x888010,//删除玩家道具信息响应
            AU_ITEMSHOP_BYOWNER_QUERY = 0x880011,////查看玩家身上道具信息
            AU_ITEMSHOP_BYOWNER_QUERY_RESP = 0x888011,////查看玩家身上道具信息
            AU_ITEMSHOP_TRADE_QUERY = 0x880012,//查看玩家交易记录信息
            AU_ITEMSHOP_TRADE_QUERY_RESP = 0x888012,//查看玩家交易记录信息的响应
            AU_ITEMSHOP_CREATE = 0x880013,//添加玩家礼物盒道具信息
            AU_ITEMSHOP_CREATE_RESP = 0x888013,//添加玩家礼物盒道具信息响应
            AU_LEVELEXP_QUERY = 0x880014,//查看玩家等级经验
            AU_LEVELEXP_QUERY_RESP = 0x888014,////查看玩家等级经验响应
            AU_USERLOGIN_STATUS_QUERY = 0x880015,//查看玩家登录状态
            AU_USERLOGIN_STATUS_QUERY_RESP = 0x888015,//查看玩家登录状态响应
            AU_USERCHARAGESUM_QUERY = 0x880016,//得到充值记录总和
            AU_USERCHARAGESUM_QUERY_RESP = 0x888016,//得到充值记录总和响应
            AU_CONSUME_QUERY = 0x880017,//查看玩家的消费记录
            AU_CONSUME_QUERY_RESP = 0x888017,//查看玩家的消费记录响应
            AU_USERCONSUMESUM_QUERY = 0x880018,//得到消费记录总和
            AU_USERCONSUMESUM_QUERY_RESP = 0x888018,//得到消费记录总和响应
            AU_USERMCASH_QUERY = 0x880019,//玩家充值记录查询
            AU_USERMCASH_QUERY_RESP = 0x888019,//玩家充值记录查询响应
            AU_USERGCASH_QUERY = 0x880020,//玩家Ｇ币记录查询
            AU_USERGCASH_QUERY_RESP = 0x888020,//玩家Ｇ币记录查询响应
            AU_USERGCASH_UPDATE = 0x880021,//补偿玩家G币
            AU_USERGCASH_UPDATE_RESP = 0x888021,//补偿玩家G币的响应
            AU_MESSENGER_QUERY = 0x880023,
            AU_MESSENGER_QUERY_RESP = 0x888023,
            AU_MESSENGER_UPDATE = 0x880024,
            AU_MESSENGER_UPDATE_RESP = 0x888024,
            AU_WEDDING_QUERY = 0x880025,
            AU_WEDDING_QUERY_RESP = 0x888025,
            AU_WEDDINGGROUND_QUERY = 0x880026,
            AU_WEDDINGGROUND_QUERY_RESP = 0x888026,
            AU_GOODS_QUERY = 0x880027,
            AU_GOODS_QUERY_RESP = 0x888027,
            AU_JOINPCIP_QUERY = 0x880028,
            AU_JOINPCIP_QUERY_RESP = 0x888028,
            AU_JOINPCIP_Insert = 0x880029,
            AU_JOINCPIP_Insert_RESP = 0x888029,
            AU_JOINPCIP_Delete = 0x880030,
            AU_JOINPCIP_Delete_RESP = 0x888030,
            AU_MEMBERACTIVE_CREATE = 0x880031,
            AU_MEMBERACTIVE_CREATE_RESP = 0x888031,

            AU_BOARDMESSAGE_REQ = 0x880032,
            AU_BOARDMESSAGE_REQ_RESP = 0x888032,
            AU_BOARDTASK_INSERT = 0x880033,
            AU_BOARDTASK_INSERT_RESP = 0x888033,
            AU_BOARDTASK_QUERY = 0x880034,
            AU_BOARDTASK_QUERY_RESP = 0x888034,
            AU_BOARDTASK_UPDATE = 0x880035,
            AU_BOARDTASK_UPDATE_RESP = 0x888035,
            AU_GS_QUERY = 0x880036,
            AU_GS_QUERY_RESP = 0x888036,
            /// <summary>
            /// 疯狂卡丁车GM工具(0x89)
            /// </summary>
            CR_ACCOUNT_QUERY = 0x890001,//玩家帐号信息查询
            CR_ACCOUNT_QUERY_RESP = 0x898001,//玩家帐号信息查询响应
            CR_ACCOUNTACTIVE_QUERY = 0x890002,//玩家帐号激活信息
            CR_ACCOUNTACTIVE_QUERY_RESP = 0x898002,//玩家帐号激活响应
            CR_CALLBOARD_QUERY = 0x890003,//公告信息查询
            CR_CALLBOARD_QUERY_RESP = 0x898003,//公告信息查询响应
            CR_CALLBOARD_CREATE = 0x890004,//发布公告
            CR_CALLBOARD_CREATE_RESP = 0x898004,//发布公告响应
            CR_CALLBOARD_UPDATE = 0x890005,//更新公告信息
            CR_CALLBOARD_UPDATE_RESP = 0x898005,//更新公告信息的响应
            CR_CALLBOARD_DELETE = 0x890006,//删除公告信息
            CR_CALLBOARD_DELETE_RESP = 0x898006,//删除公告信息的响应

            CR_CHARACTERINFO_QUERY = 0x890007,//玩家角色信息查询
            CR_CHARACTERINFO_QUERY_RESP = 0x898007,//玩家角色信息查询的响应
            CR_CHARACTERINFO_UPDATE = 0x890008,//玩家角色信息查询
            CR_CHARACTERINFO_UPDATE_RESP = 0x898008,//玩家角色信息查询的响应
            CR_CHANNEL_QUERY = 0x890009,//公告频道查询
            CR_CHANNEL_QUERY_RESP = 0x898009,//公告频道查询的响应
            CR_NICKNAME_QUERY = 0x890010,//玩家昵称查询
            CR_NICKNAME_QUERY_RESP = 0x898010,//玩家昵称的响应
            CR_LOGIN_LOGOUT_QUERY = 0x890011,//玩家上线、下线时间查询
            CR_LOGIN_LOGOUT_QUERY_RESP = 0x898011,//玩家上线、下线时间查询的响应
            CR_ERRORCHANNEL_QUERY = 0x890012,//补充错误公告频道查询
            CR_ERRORCHANNEL_QUERY_RESP = 0x898012,//补充错误公告频道查询的响应


            /// <summary>
            /// 充值消费GM工具(0x90)
            /// </summary>
            CARD_USERCHARGEDETAIL_QUERY = 0x900001,//一卡通查询
            CARD_USERCHARGEDETAIL_QUERY_RESP = 0x908001,//一卡通查询响应
            CARD_USERDETAIL_QUERY = 0x900002,//久之游用户注册信息查询
            CARD_USERDETAIL_QUERY_RESP = 0x908002,////久之游用户注册信息查询响应
            CARD_USERCONSUME_QUERY = 0x900003,//休闲币消费查询
            CARD_USERCONSUME_QUERY_RESP = 0x908003,//休闲币消费查询响应
            CARD_VNETCHARGE_QUERY = 0x900004,//互联星空充值查询
            CARD_VNETCHARGE_QUERY_RESP = 0x908004,//互联星空充值查询响应
            CARD_USERDETAIL_SUM_QUERY = 0x900005,//充值合计查询
            CARD_USERDETAIL_SUM_QUERY_RESP = 0x908005,//充值合计查询响应
            CARD_USERCONSUME_SUM_QUERY = 0x900006,//消费合计查询
            CARD_USERCONSUME_SUM_QUERY_RESP = 0x908006,//消费合计响应
            CARD_USERINFO_QUERY = 0x900007,//玩家注册信息查询
            CARD_USERINFO_QUERY_RESP = 0x908007,//玩家注册信息查询响应阿斯科 26日21:00 切　沃 3
            CARD_USERINFO_CLEAR = 0x900008,
            CARD_USERINFO_CLEAR_RESP = 0x908008,
            CARD_USERLOCK_UPDATE = 0x900011,
            CARD_USERLOCK_UPDATE_RESP = 0x908011,
            CARD_BALANCE_QUERY = 0x900012,//用户余额查询
            CARD_BALANCE_QUERY_RESP = 0x908012,
            CARD_USERNUM_QUERY = 0x900013,//点卡查询
            CARD_USERNUM_QUERY_RESP = 0x908013,
            CARD_USERHISTORYPWD_QUERY = 0x900014,//历史密码
            CARD_USERHISTORYPWD_QUERY_RESP = 0x908014,
            CARD_USERINITACTIVE_QUERY = 0x900015,//激活游戏
            CARD_USERINITACTIVE_QUERY_RESP = 0x908015,
            TOKEN_TOKENSTATUS_QUERY = 0x900016,//显示令牌的当前状态
            TOKEN_TOKENSTATUS_QUERY_RESP = 0x908016,
            TOKEN_MODIFYUSER_QUERY = 0x900017,//用户令牌修改
            TOKEN_MODIFYUSER_QUERY_RESP = 0x908017,
            CARD_USERLOCK_QUERY = 0x900019,
            CARD_USERLOCK_QUERY_RESP = 0x908019,
            CARD_USERCARDLOCK_QUERY = 0x900020,
            CARD_USERCARDLOCK_QUERY_RESP = 0x908020,
            CARD_USERTOKEN_QUERY = 0x900021,
            CARD_USERTOKEN_QUERY_RESP = 0x908021,
            CARD_USERTOKEN_OPEN = 0x900022,
            CARD_USERTOKEN_OPEN_RESP = 0x908022,
            CARD_USERTOKEN_CLOSE = 0x900023,
            CARD_USERTOKEN_CLOSE_RESP = 0x908023,
            CARD_USERTOKEN_RELEASE = 0x900024,
            CARD_USERTOKEN_RELEASE_RESP = 0x908024,
            CARD_UserCashExp_Query = 0x900025,
            CARD_UserCashExp_Query_RESP = 0x908025,
            CARD_QueryUseDetailExp_Query = 0x900026,
            CARD_QueryUseDetailExp_RESP = 0x908026,
            CARD_USERNUM_ADVANCE_QUERY = 0x900027,
            CARD_USERNUM_ADVANCE_QUERY_RESP = 0x908027,
            CARD_MOBILEINFO_QUERY = 0x900028,
            CARD_MOBILEINFO_QUERY_RESP = 0x908028,
            CARD_DanceItem_QUERY = 0x900032,
		    CARD_DanceItem_QUERY_RESP = 0x908032,
            CARD_RESETHISTORY_QUERY = 0x900033,
            CARD_RESETHISTORY_QUERY_RESP = 0x908033,
            CARD_DanceItem_Qualification_QUERY = 0x900034,
            CARD_DanceItem_Qualification_QUERY_RESP = 0x908034,
            CARD_USERACTIVETOKEN_QUERY = 0x900035,
            CARD_USERACTIVETOKEN_QUERY_RESP = 0x908035,
            /// <summary>
            /// 劲舞团商城(0x91)
            /// </summary>
            AUSHOP_USERGPURCHASE_QUERY = 0x910001,//用户G币购买记录
            AUSHOP_USERGPURCHASE_QUERY_RESP = 0x918001,//用户G币购买记录
            AUSHOP_USERMPURCHASE_QUERY = 0x910002,//用户M币购买记录
            AUSHOP_USERMPURCHASE_QUERY_RESP = 0x918002,//用户M币购买记录
            AUSHOP_AVATARECOVER_QUERY = 0x910003,//道具回收兑换记
            AUSHOP_AVATARECOVER_QUERY_RESP = 0x918003,//道具回收兑换记
            AUSHOP_USERINTERGRAL_QUERY = 0x910004,//用户积分记录
            AUSHOP_USERINTERGRAL_QUERY_RESP = 0x918004,//用户积分记录
            AUSHOP_USEROPERLOG_CREATE = 0x910005,//用户G币购买记录合计
            AUSHOP_USEROPERLOG_CREATE_RESP = 0x918005,//用户G币购买记录合计响应
            AUSHOP_USERMPURCHASE_SUM_QUERY = 0x910006,//用户M币购买记录合计
            AUSHOP_USERMPURCHASE_SUM_QUERY_RESP = 0x918006,//用户M币购买记录合计响应
            AUSHOP_AVATARECOVER_DETAIL_QUERY = 0x910007,// 具回收兑换详细记录
            AUSHOP_AVATARECOVER_DETAIL_QUERY_RESP = 0x918007,// 具回收兑换详细记录
            AUSHOP_WAREHOUSE_QUERY = 0x910008,//玩家游戏里面仓库里面的道具
            AUSHOP_WAREHOUSE_QUERY_RESP = 0x918008,//玩家游戏里面仓库里面的道具
            AUSHOP_ERRBUY_REFUND = 0x910009,//劲舞团商城 - 错误购买退款 
            AUSHOP_ERRBUY_REFUND_RESP = 0x918009,//劲舞团商城 - 错误购买退款 
            AUSHOP_REPEATBuy_REFUND = 0x910010,//劲舞团商城 - 重复购买退款 
            AUSHOP_REPEATBuy_REFUND_RESP = 0x918010,//劲舞团商城 - 重复购买退款 
            AUSHOP_FillBuy_REFUND = 0x910011,//劲舞团商城 - 补发
            AUSHOP_FillBuy_REFUND_RESP = 0x918011,//劲舞团商城 - 补发
            AUSHOP_REPEATGet_REFUND = 0x910012,//劲舞团商城 - 允许用户重新领取
            AUSHOP_REPEATGet_REFUND_RESP = 0x918012,//劲舞团商城 - 允许用户重新领取
            AUSHOP_SPECIALAVATITEM_QUERY = 0x910013,//小喇叭
            AUSHOP_SPECIALAVATITEM_QUERY_RESP = 0x918013,//小喇叭
            AUSHOP_OTHERSPECIALAVATITEM_QUERY = 0x910014,//其他的特殊道具
            AUSHOP_OTHERSPECIALAVATITEM_QUERY_RESP = 0x918014,//其他的特殊道具


            DEPARTMENT_CREATE = 0x810009,//部门创建
            DEPARTMENT_CREATE_RESP = 0x818009,//部门创建响应
            DEPARTMENT_UPDATE = 0x810010,//部门修改
            DEPARTMENT_UPDATE_RESP = 0x818010,//部门修改响应
            DEPARTMENT_DELETE = 0x810011,//部门删除
            DEPARTMENT_DELETE_RESP = 0x818011,//部门删除响应
            DEPARTMENT_ADMIN = 0x810012,//部门管理
            DEPARTMENT_ADMIN_RESP = 0x818012,//部门管理响应

            DEPARTMENT_RELATE_QUERY = 0x810013,//部门关联查询
            DEPARTMENT_RELATE_QUERY_RESP = 0x818013,//部门关联查询

            /// <summary>
            /// 劲乐团工具(0x92)
            /// </summary>
            O2JAM_CHARACTERINFO_QUERY = 0x920001,//玩家角色信息查询
            O2JAM_CHARACTERINFO_QUERY_RESP = 0x928001,//玩家角色信息查询
            O2JAM_CHARACTERINFO_UPDATE = 0x920002,//玩家角色信息更新
            O2JAM_CHARACTERINFO_UPDATE_RESP = 0x928002,//玩家角色信息更新
            O2JAM_ITEM_QUERY = 0x920003,//玩家道具信息查询
            O2JAM_ITEM_QUERY_RESP = 0x928003,//玩家角色信息查询
            O2JAM_ITEM_UPDATE = 0x920004,//玩家道具信息更新
            O2JAM_ITEM_UPDATE_RESP = 0x928004,//玩家道具信息更新
            O2JAM_CONSUME_QUERY = 0x920005,//玩家消费信息查询
            O2JAM_CONSUME_QUERY_RESP = 0x928005,//玩家消费信息查询
            O2JAM_ITEMDATA_QUERY = 0x920006,// 具列表查询
            O2JAM_ITEMDATA_QUERY_RESP = 0x928006,// 具列表信息查询
            O2JAM_GIFTBOX_QUERY = 0x920007,//玩家礼物盒查询
            O2JAM_GIFTBOX_QUERY_RESP = 0x928007,//玩家礼物盒查询
            O2JAM_USERGCASH_UPDATE = 0x920008,//补偿玩家G币
            O2JAM_USERGCASH_UPDATE_RESP = 0x928008,//补偿玩家G币的响应
            O2JAM_CONSUME_SUM_QUERY = 0x920009,//玩家消费信息查询
            O2JAM_CONSUME_SUM_QUERY_RESP = 0x928009,//玩家消费信息查询
            O2JAM_GIFTBOX_CREATE_QUERY = 0x920010,//添加玩家礼物盒d具
            O2JAM_GIFTBOX_CREATE_QUERY_RESP = 0x928010,//添加玩家礼物盒d具
            O2JAM_ITEMNAME_QUERY = 0x920011,
            O2JAM_ITEMNAME_QUERY_RESP = 0x928011,

            O2JAM_GIFTBOX_DELETE = 0x920012,
            O2JAM_GIFTBOX_DELETE_RESP = 0x928012,
            O2JAM_USERLOGIN_DEL = 0x920013,
            O2JAM_USERLOGIN_DEL_RESP = 0x928013,

            DEPART_RELATE_GAME_QUERY = 0x810014,
            DEPART_RELATE_GAME_QUERY_RESP = 0x818014,
            USER_SYSADMIN_QUERY = 0x810015,
            USER_SYSADMIN_QUERY_RESP = 0x818015,
            CARD_USERSECURE_CLEAR = 0x900009,//重置玩家安全码信息
            CARD_USERSECURE_CLEAR_RESP = 0x908009,//重置玩家安全码信息响应


            /// <summary>
            /// 劲乐团IIGM工具(0x93)
            /// </summary>
            O2JAM2_ACCOUNT_QUERY = 0x930001,//玩家帐号信息查询
            O2JAM2_ACCOUNT_QUERY_RESP = 0x938001,//玩家帐号信息查询响应
            O2JAM2_ACCOUNTACTIVE_QUERY = 0x930002,//玩家帐号激活信息
            O2JAM2_ACCOUNTACTIVE_QUERY_RESP = 0x938002,//玩家帐号激活响应

            O2JAM2_CHARACTERINFO_QUERY = 0x930003,//用户信息查询
            O2JAM2_CHARACTERINFO_QUERY_RESP = 0x938003,
            O2JAM2_CHARACTERINFO_UPDATE = 0x930004,//用户信息修改
            O2JAM2_CHARACTERINFO_UPDATE_RESP = 0x938004,
            O2JAM2_ITEMSHOP_QUERY = 0x930005,
            O2JAM2_ITEMSHOP_QUERY_RESP = 0x938005,
            O2JAM2_ITEMSHOP_DELETE = 0x930006,
            O2JAM2_ITEMSHOP_DELETE_RESP = 0x938006,
            O2JAM2_MESSAGE_QUERY = 0x930007,
            O2JAM2_MESSAGE_QUERY_RESP = 0x938007,
            O2JAM2_MESSAGE_CREATE = 0x930008,
            O2JAM2_MESSAGE_CREATE_RESP = 0x938008,
            O2JAM2_MESSAGE_DELETE = 0x930009,
            O2JAM2_MESSAGE_DELETE_RESP = 0x938009,
            O2JAM2_CONSUME_QUERY = 0x930010,
            O2JAM2_CONUMSE_QUERY_RESP = 0x938010,
            O2JAM2_CONSUME_SUM_QUERY = 0x930011,
            O2JAM2_CONUMSE_QUERY_SUM_RESP = 0x938011,
            O2JAM2_TRADE_QUERY = 0x930012,
            O2JAM2_TRADE_QUERY_RESP = 0x938012,
            O2JAM2_TRADE_SUM_QUERY = 0x930013,
            O2JAM2_TRADE_QUERY_SUM_RESP = 0x938013,
            O2JAM2_AVATORLIST_QUERY = 0x930014,
            O2JAM2_AVATORLIST_QUERY_RESP = 0x938014,

            O2JAM2_ACCOUNT_CLOSE = 0x930015,//封停帐户的权限信息
            O2JAM2_ACCOUNT_CLOSE_RESP = 0x938015,//封停帐户的权限信息响应
            O2JAM2_ACCOUNT_OPEN = 0x930016,//解封帐户的权限信息
            O2JAM2_ACCOUNT_OPEN_RESP = 0x938016,//解封帐户的权限信息响应
            O2JAM2_MEMBERBANISHMENT_QUERY = 0x930017,
            O2JAM2_MEMBERBANISHMENT_QUERY_RESP = 0x938017,
            O2JAM2_MEMBERSTOPSTATUS_QUERY = 0x930018,
            O2JAM2_MEMBERSTOPSTATUS_QUERY_RESP = 0x938018,
            O2JAM2_MEMBERLOCAL_BANISHMENT = 0x930019,
            O2JAM2_MEMBERLOCAL_BANISHMENT_RESP = 0x938019,

            O2JAM2_USERLOGIN_DELETE = 0x930020,
            O2JAM2_USERLOGIN_DELETE_RESP = 0x938020,
            O2JAM2_LEVELEXP_QUERY = 0x930021,
            O2JAM2_LEVELEXP_QUERY_RESP = 0x938021,



            SDO_CHALLENGE_QUERY = 0x870052,
            SDO_CHALLENGE_QUERY_RESP = 0x878052,
            SDO_CHALLENGE_INSERT = 0x870053,
            SDO_CHALLENGE_INSERT_RESP = 0x878053,
            SDO_CHALLENGE_UPDATE = 0x870054,
            SDO_CHALLENGE_UPDATE_RESP = 0x878054,
            SDO_CHALLENGE_DELETE = 0x870055,
            SDO_CHALLENGE_DELETE_RESP = 0x878055,
            SDO_MUSICDATA_QUERY = 0x870056,
            SDO_MUSICDATA_QUERY_RESP = 0x878056,


            SDO_MUSICDATA_OWN_QUERY = 0x870057,
            SDO_MUSICDATA_OWN_QUERY_RESP = 0x878057,


            SDO_CHALLENGE_SCENE_QUERY = 0x870058,
            SDO_CHALLENGE_SCENE_QUERY_RESP = 0x878058,
            SDO_CHALLENGE_SCENE_CREATE = 0x870059,
            SDO_CHALLENGE_SCENE_CREATE_RESP = 0x878059,
            SDO_CHALLENGE_SCENE_UPDATE = 0x870060,
            SDO_CHALLENGE_SCENE_UPDATE_RESP = 0x878060,
            SDO_CHALLENGE_SCENE_DELETE = 0x870061,
            SDO_CHALLENGE_SCENE_DELETE_RESP = 0x878061,


            SDO_MEDALITEM_CREATE = 0x870062,
            SDO_MEDALITEM_CREATE_RESP = 0x878062,
            SDO_MEDALITEM_UPDATE = 0x870063,
            SDO_MEDALITEM_UPDATE_RESP = 0x878063,
            SDO_MEDALITEM_DELETE = 0x870064,
            SDO_MEDALITEM_DELETE_RESP = 0x878064,
            SDO_MEDALITEM_QUERY = 0x870065,
            SDO_MEDALITEM_QUERY_RESP = 0x878065,


            SDO_MEDALITEM_OWNER_QUERY = 0x870066,
            SDO_MEDALITEM_OWNER_QUERY_RESP = 0x878066,

            SDO_MEMBERDANCE_OPEN = 0x870067,
            SDO_MEMBERDANCE_OPEN_RESP = 0x878067,
            SDO_MEMBERDANCE_CLOSE = 0x870068,
            SDO_MEMBERDANCE_CLOSE_RESP = 0x878068,

            SDO_YYHAPPYITEM_QUERY = 0x870084,
            SDO_YYHAPPYITEM_QUERY_RESP = 0x878084,
            SDO_YYHAPPYITEM_CREATE = 0x870085,
            SDO_YYHAPPYITEM_CREATE_RESP = 0x878085,
            SDO_YYHAPPYITEM_UPDATE = 0x870086,
            SDO_YYHAPPYITEM_UPDATE_RESP = 0x878086,
            SDO_YYHAPPYITEM_DELETE = 0x870087,
            SDO_YYHAPPYITEM_DELETE_RESP = 0x878087,
            SDO_UserCashExp_Query = 0x870099,
            SDO_UserCashExp_Query_RESP = 0x878099,
            SDO_QueryDeleteItem_QUERY = 0x870102,
            SDO_QueryDeleteItem_QUERY_RESP = 0x878102,
            SDO_NotReachMoney_Query = 0x870103,
            SDO_NotReachMoney_Query_RESP = 0x878103,

            /// <summary>
            /// 劲爆足球 (0x94)Add by KeHuaQing 2006-09-14
            /// </summary>
            SOCCER_CHARACTERINFO_QUERY = 0x940001,//用户信息查询
            SOCCER_CHARACTERINFO_QUERY_RESP = 0x948001,
            SOCCER_CHARCHECK_QUERY = 0x940002,//用户NameCheck,SocketCheck
            SOCCER_CHARCHECK_QUERY_RESP = 0x948002,
            SOCCER_CHARITEMS_RECOVERY_QUERY = 0x940003,//用户启用
            SOCCER_CCHARITEMS_RECOVERY_QUERY_RESP = 0x948003,
            SOCCER_CHARPOINT_QUERY = 0x940004,//用户G币修改
            SOCCER_CHARPOINT_QUERY_RESP = 0x948004,
            SOCCER_DELETEDCHARACTERINFO_QUERY = 0x940005,//删除用户查询
            SOCCER_DELETEDCHARACTERINFO_QUERY_RESP = 0x948005,

            SOCCER_CHARACTERSTATE_MODIFY = 0x940006,//停封角色
            SOCCER_CHARACTERSTATE_MODIFY_RESP = 0x948006,
            SOCCER_ACCOUNTSTATE_MODIFY = 0x940007,//停封玩家
            SOCCER_ACCOUNTSTATE_MODIFY_RESP = 0x948007,
            SOCCER_CHARACTERSTATE_QUERY = 0x940008,//停封角色查询
            SOCCER_CHARACTERSTATE_QUERY_RESP = 0x948008,
            SOCCER_ACCOUNTSTATE_QUERY = 0x940009,//停封玩家查询
            SOCCER_ACCOUNTSTATE_QUERY_RESP = 0x948009,
            SOCCER_ACCOUNTACTIVE_QUERY = 0x940010,//玩家激活查询		
            SOCCER_ACCOUNTACTIVE_QUERY_RESP = 0x948010,
            SOCCER_USERTRADE_QUERY = 0x940011,//玩家道具购买记录，赠送记录
            SOCCER_USERTRADE_QUERY_RESP = 0x948011,

            SOCCER_ITEM_SKILL_MODIFY = 0x940012,//删除角色道具、技能
            SOCCER_ITEM_SKILL_MODIFY_RESP = 0x948012,//删除角色道具、技能

            SOCCER_ACCOUNT_ITEMSKILL_QUERY = 0x940013,//玩家身上的道具、技能
            SOCCER_ACCOUNT_ITEMSKILL_QUER_RESPY = 0x948013,//玩家身上的道具、技能 

            SOCCER_CHARINFO_MODIFY = 0x940014,//玩家角色信息修改
            SOCCER_CHARINFO_MODIFY_RESPY = 0x948014,//玩家角色信息修改

            SOCCER_ITEMSHOP_INSERT = 0x940015,//给玩家赠送道具
            SOCCER_ITEMSHOP_INSERT_RESPY = 0x948015,//给玩家赠送道具

            SOCCER_ITEM_SKILL_QUERY = 0x940016,//获得角色道具、技能
            SOCCER_ITEM_SKILL_QUERY_RESP = 0x948016,//获得角色道具、技能

            SOCCER_ITEM_SKILL_BLUR_QUERY = 0x940017,//获得角色道具、技能
            SOCCER_ITEM_SKILL_BLUR_QUERY_RESP = 0x948017,//获得角色道具、技能

            CARD_USERNICK_QUERY = 0x900010,
            CARD_USERNICK_QUERY_RESP = 0x908010,
            CARD_USER_QUERY = 0x900018,//用户基本信息查询
            CARD_USER_QUERY_RESP = 0x908018,
            CARD_TOKENPASSWD_SYNC = 0x900029,
            CARD_TOKENPASSWD_SYNC_RESP = 0x908029,
            CARD_MOBILEINFO_UPDATE = 0x900030,
            CARD_MOBILEINFO_UPDATE_RESP = 0x908030,
            AU_USERNICK_UPDATE = 0x880022,
            AU_USERNICK_UPDATE_RESP = 0x888022,
            CARD_USERCARDHISTORY_QUERY = 0x900031,
            CARD_USERCARDHISTORY_QUERY_RESP = 0x908031,

            LINK_SERVERIP_DELETE = 0x800010,
            LINK_SERVERIP_DELETE_RESP = 0x808010,


            FJ_CharacterInfo_Query = 0x950001,
            FJ_CharacterInfo_Query_Resp = 0x958001,
            FJ_ItemShop_Query = 0x950002,
            FJ_ItemShop_Query_Resp = 0x958002,
            FJ_Message_Query = 0x950003,
            FJ_Message_Query_Resp = 0x958003,
            FJ_WareHouse_Query = 0x950004,
            FJ_WareHouse_Query_Resp = 0x958004,
            FJ_Login_Query = 0x950005,
            FJ_Login_Query_Resp = 0x958005,
            FJ_Login_Out_Update = 0x950006,
            FJ_Login_Out_Update_Resp = 0x958006,
            FJ_PlayPosition_Query = 0x950007,
            FJ_PlayPosition_Query_Resp = 0x958007,
            FJ_ItemShop_Del = 0x950008,
            FJ_ItemShop_Del_Resp = 0x958008,
            FJ_AccountActive_Query = 0x950009,
            FJ_AccountActive_Query_Resp = 0x958009,
            FJ_ActiveCode_Query = 0x950010,
            FJ_ActiveCode_Query_Resp = 0x958010,
            FJ_ItemShop_Insert = 0x950011,
            FJ_ItemShop_Insert_Resp = 0x958011,
            FJ_Wedding_Query = 0x950012,
            FJ_Wedding_Query_Resp = 0x958012,
            FJ_Wedding_Create = 0x950013,
            FJ_Wedding_Create_Resp = 0x958013,
            FJ_Wedding_Delete = 0x950014,
            FJ_Wedding_Delete_Resp = 0x958014,
            FJ_Task_Query = 0x950015,
            FJ_Task_Query_Resp = 0x958015,
            FJ_PlayerLevelMoney_Query = 0x950016,
            FJ_PlayerLevelMoney_Query_Resp = 0x958016,
            FJ_Guild_Query = 0x950017,
            FJ_Guild_Query_Resp = 0x958017,
            FJ_Guild_Create = 0x950018,
            FJ_Guild_Create_Resp = 0x958018,
            FJ_Guild_Delete = 0x950019,
            FJ_Guild_Delete_Resp = 0x958019,
            FJ_SocialRelate_Query = 0x950020,
            FJ_SocialRelate_Query_Resp = 0x958020,
            FJ_SocialRelate_Create = 0x950021,
            FJ_SocialRelate_Create_Resp = 0x958021,
            FJ_SocialRelate_Delete = 0x950022,
            FJ_SocialRelate_Delete_Resp = 0x958022,
            FJ_UserBan_Query = 0x950023,
            FJ_UserBan_Query_Resp = 0x958023,
            FJ_UserBan_Close = 0x950024,
            FJ_UserBan_Close_Resp = 0x958024,
            FJ_UserBan_Open = 0x950025,
            FJ_UserBan_Open_Resp = 0x958025,
            FJ_PlayerSkill_Insert = 0x950026,
            FJ_PlayerSkill_Insert_Resp = 0x958026,
            FJ_PlayerSkill_Update = 0x950027,
            FJ_PlayerSkill_Update_Resp = 0x958027,
            FJ_PlayerSkill_Delete = 0x950028,
            FJ_PlayerSkill_Delete_Resp = 0x958028,
            FJ_CharacterInfo_Update = 0x950029,
            FJ_CharacterInfo_Update_Resp = 0x958029,
            FJ_ShortCut_Query = 0x950030,
            FJ_ShortCut_Query_Resp = 0x958030,
            FJ_Message_Batch_Insert = 0x950031,
            FJ_Message_Batch_Insert_Resp = 0x958031,
            FJ_PlayerPwd_Update = 0x950032,
            FJ_PlayerPwd_Update_Resp = 0x958032,
            FJ_Task_Insert = 0x950033,
            FJ_Task_Insert_Resp = 0x958033,
            FJ_Task_Delete = 0x950034,
            FJ_Task_Delete_Resp = 0x958034,
            FJ_Task_Update = 0x950035,
            FJ_Task_Update_Resp = 0x958035,
            FJ_Delete_Character = 0x950036,
            FJ_Delete_Character_Resp = 0x958036,
            FJ_Recovery_Character = 0x950037,
            FJ_Recovery_Character_Resp = 0x958037,
            FJ_Guild_QueryAll = 0x950038,
            FJ_Guild_QueryAll_RESP = 0x958038,
            FJ_GS_Query = 0x950039,
            FJ_GS_Query_Resp = 0x958039,
            FJ_BoardList_Query = 0x950040,
            FJ_BoardList_Query_Resp = 0x958040,
            FJ_BoardList_Insert = 0x950041,
            FJ_BoardList_Insert_Resp = 0x958041,
            FJ_BoardList_Delete = 0x950042,
            FJ_BoardList_Delete_Resp = 0x958042,
            FJ_PlayerSkill_Query = 0x950044,
            FJ_PlayerSkill_Query_Resp = 0x958044,
            FJ_SkillList_Query = 0x950045,
            FJ_SkillList_Query_Resp = 0x958045,
            FJ_TempPassword_Query = 0x950046,
            FJ_TempPassword_Query_Resp = 0x958046,
            FJ_Currank_Query = 0x950047,
            FJ_Currank_Query_Resp = 0x958047,
            FJ_PWD_Recover = 0x950048,
            FJ_PWD_Recover_Resp = 0x958048,
            FJ_MAP_Query = 0x950049,
            FJ_MAP_Query_Resp = 0x958049,
            FJ_PlayPosition_Update = 0x950050,
            FJ_PlayPosition_Update_Resp = 0x958050,
            FJ_QuestTable_Query = 0x950051,
            FJ_QuestTable_Query_Resp = 0x958051,
            FJ_ItemShop_Style_Query = 0x950052,
            FJ_ItemShop_Style_Query_Resp = 0x958052,
            FJ_ItemShop_QueryAll = 0x950053,
            FJ_ItemShop_QueryAll_Resp = 0x958053,
            FJ_ItemAppend_Style_Query = 0x950054,
            FJ_ItemAppend_Style_Query_Resp = 0x958054,
            FJ_ItemAppend_Query = 0x950055,
            FJ_ItemAppend_Query_Resp = 0x958055,
            FJ_ItemAppendList_Query = 0x950056,
            FJ_ItemAppendList_Query_Resp = 0x958056,
            FJ_ItemShop_Delete = 0x950057,
		    FJ_ItemShop_Delete_Resp = 0x958057,
            FJ_ItemLog_Query = 0x950058,
            FJ_ItemLog_Query_Resp = 0x958058,
            FJ_ItemLogType_Query = 0x950059,
            FJ_ItemLogType_Query_Resp = 0x958059,

            RC_Character_Query = 0x960001,
            RC_Character_Query_Resp = 0x968001,
            RC_UserLoginOut_Query = 0x960002,
            RC_UserLoginOut_Query_Resp = 0x968002,
            RC_UserLogin_Del = 0x960003,
            RC_UserLogin_Del_Resp = 0x968003,
            RC_RcCode_Query = 0x960004,
            RC_RcCode_Query_Resp = 0x968004,
            RC_RcUser_Query = 0x960005,
            RC_RcUser_Query_Resp = 0x968005,
            NOTDEFINED = 0x0,
            ERROR = 0xFFFFFF
        }
        #endregion

        /// <summary>
        /// Socket 消息体
        /// </summary>
        [Serializable()]
        [StructLayout(LayoutKind.Sequential)]
        public struct Message_Body
        {
            public TagFormat eTag;
            public TagName eName;
            public object oContent;
        }

        /// <summary>
        /// 日志内容
        /// </summary>
        [Serializable()]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TLogData
        {
            public int iSort;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 255)]
            public string strDescribe;
            //[MarshalAs(UnmanagedType.LPStr)]
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 255)]
            public string strException;
        }
    }
}
