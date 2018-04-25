using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace C_Global
{
    public class CEnum
    {
        #region Socket ��Ϣ����
        /// <summary>
        /// �������ݱ�ǩ
        /// </summary>
        public enum TagName : ushort
        {
            ///////////////////////////////////////////////////////////////////////
            UserName = 0x0101, //Format:STRING �û���
            PassWord = 0x0102, //Format:STRING ����
            MAC = 0x0103, //Format:STRING  MAC��
            Limit = 0x0104,//Format:DateTime GM�ʺ�ʹ��ʱЧ
            User_Status = 0x0105,//Format:INT ״̬��Ϣ
            UserByID = 0x0106,//Format:INT ����ԱID
            RealName = 0x0107,//Format:STRING ������
            DepartID = 0x0108,//Format:INT ����ID
            DepartName = 0x0109,//Format:STRING ��������
            DepartRemark = 0x0110,//Format:STRING ��������
            OnlineActive = 0x0111,//Format:Integer ����״̬
            UpdateFileName = 0x0112,//Format:String �ļ���
            UpdateFileVersion = 0x0113,//Format:String �ļ��汾
            UpdateFilePath = 0x0114,//Format:String �ļ�·��
            UpdateFileSize = 0x0115,//Format:Integer �ļ���С

            Process_Reason = 0x060B,//Format tring
            ///////////////////////////////////////////////////////////////////////
            GameID = 0x0200, //Format:INTEGER ��ϢID
            ModuleName = 0x0201, //Format:STRING ģ������
            ModuleClass = 0x0202, //Format:STRING ģ�����
            ModuleContent = 0x0203, //Format:STRING ģ������
            ///////////////////////////////////////////////////////////////////////
            Module_ID = 0x0301, //Format:INTEGER ģ��ID
            User_ID = 0x0302, //Format:INTEGER �û�ID
            ModuleList = 0x0303, //Format:String ģ���б�
            SysAdmin = 0x0116,//Format:Integer �Ƿ���ϵͳ����Ա
            ///////////////////////////////////////////////////////////////////////
            Host_Addr = 0x0401, //Format:STRING
            Host_Port = 0x0402, //Format:STRING
            Host_Pat = 0x0403,  //Format:STRING
            Conn_Time = 0x0404, //Format:DateTime �������Ӧʱ��
            Connect_Msg = 0x0405,//Format:STRING ����������Ϣ
            DisConnect_Msg = 0x0406,//Format:STRING	 ����˿���Ϣ
            Author_Msg = 0x0407, //Format:STRING ��֤�û�����Ϣ
            Status = 0x0408,//Format:STRING �������
            Index = 0x0409, //Format:Integer ��¼�����
            PageSize = 0x0410,//Format:Integer ��¼ҳ��ʾ����
            PageCount = 0x0411,//Format:Integer ��ʾ��ҳ��
            SP_Name = 0x0412,//Format:Integer �洢������
            Real_ACT = 0x0413,//Format:String ����������
            ACT_Time = 0x0414,//Format:TimeStamp ����ʱ��
            BeginTime = 0x0415,//Format:Date ��ʼ����
            EndTime = 0x0416,//Format:Date ��������
            ///////////////////////////////////////////////////////////////////////
            GameName = 0x0501, //Format:STRING ��Ϸ����
            GameContent = 0x0502, //Format:STRING ��Ϣ����
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
            MJ_Level = 0x0701, //Format:Integer ��ҵȼ�
            MJ_Account = 0x0702, //Format:String ����ʺ�
            MJ_CharName = 0x0703, //Format:String ����س�
            MJ_Exp = 0x0704, //Format:Integer ��ҵ�ǰ����
            MJ_Exp_Next_Level = 0x0705, //Format:Integer ����´������ľ��� 
            MJ_HP = 0x0706, //Format:Integer ���HPֵ
            MJ_HP_Max = 0x0707, //Format:Integer �������HPֵ
            MJ_MP = 0x0708, //Format:Integer ���MPֵ
            MJ_MP_Max = 0x0709, //Format:Integer �������MPֵ
            MJ_DP = 0x0710, //Format:Integer ���DPֵ
            MJ_DP_Increase_Ratio = 0x0711, //Format:Integer �������DPֵ
            MJ_Exception_Dodge = 0x0712, //Format:Integer �쳣״̬�ر�
            MJ_Exception_Recovery = 0x0713, //Format:Integer �쳣״̬�ظ�
            MJ_Physical_Ability_Max = 0x0714, //Format:Integer �����������ֵ
            MJ_Physical_Ability_Min = 0x0715, //Format:Integer ����������Сֵ
            MJ_Magic_Ability_Max = 0x0716, //Format:Integer ħ���������ֵ
            MJ_Magic_Ability_Min = 0x0717, //Format:Integer ħ��������Сֵ
            MJ_Tao_Ability_Max = 0x0718, //Format:Integer �����������ֵ
            MJ_Tao_Ability_Min = 0x0719, //Format:Integer ����������Сֵ
            MJ_Physical_Defend_Max = 0x0720, //Format:Integer ������ֵ
            MJ_Physical_Defend_Min = 0x0721, //Format:Integer �����Сֵ
            MJ_Magic_Defend_Max = 0x0722, //Format:Integer ħ�����ֵ
            MJ_Magic_Defend_Min = 0x0723, //Format:Integer ħ����Сֵ
            MJ_Accuracy = 0x0724, //Format:Integer ������
            MJ_Phisical_Dodge = 0x0725, //Format:Integer ����ر���
            MJ_Magic_Dodge = 0x0726, //Format:Integer ħ���ر���
            MJ_Move_Speed = 0x0727, //Format:Integer �ƶ��ٶ�
            MJ_Attack_speed = 0x0728, //Format:Integer �����ٶ�
            MJ_Max_Beibao = 0x0729, //Format:Integer ��������
            MJ_Max_Wanli = 0x0730, //Format:Integer ��������
            MJ_Max_Fuzhong = 0x0731, //Format:Integer ��������
            MJ_PASSWD = 0x0732,//Format:String �������
            MJ_ServerIP = 0x0733,//Format:String ������ڷ�����
            MJ_TongID = 0x0734,//Format:Integer ���ID
            MJ_TongName = 0x0735,//Format:String �������
            MJ_TongLevel = 0x0736,//Format:Integer ���ȼ�
            MJ_TongMemberCount = 0x0737,//Format:Integer �������
            MJ_Money = 0x0738,//Format:Money ��ҽ�Ǯ
            MJ_TypeID = 0x0739,//Format:Integer ��ҽ�ɫ����ID
            MJ_ActionType = 0x0740,//Format:Integer ���ID
            MJ_Time = 0x0741,//Format:TimeStamp  ����ʱ��
            MJ_CharIndex = 0x0742,//���������
            MJ_CharName_Prefix = 0x0743,//��Ұ������
            MJ_Exploit_Value = 0x0744,//��ҹ�ѫֵ
            MJ_Reason = 0x0745,//ͣ������
            CARD_CRTIME = 0x2312,

            ///////////////////////////////////////////////////////////////////////
            SDO_ServerIP = 0x0801,//Format:String ����IP
            SDO_UserIndexID = 0x0802,//Format:Integer ����û�ID
            SDO_Account = 0x0803,//Format:String ��ҵ��ʺ�
            SDO_Level = 0x0804,//Format:Integer ��ҵĵȼ�
            SDO_Exp = 0x0805,//Format:Integer ��ҵĵ�ǰ����ֵ
            SDO_GameTotal = 0x0806,//Format:Integer �ܾ���
            SDO_GameWin = 0x0807,//Format:Integer ʤ����
            SDO_DogFall = 0x0808,//Format:Integer ƽ����
            SDO_GameFall = 0x0809,//Format:Integer ������
            SDO_Reputation = 0x0810,//Format:Integer ����ֵ
            SDO_GCash = 0x0811,//Format:Integer G��
            SDO_MCash = 0x0812,//Format:Integer M��
            SDO_Address = 0x0813,//Format:Integer ��ַ
            SDO_Age = 0x0814,//Format:Integer ����
            SDO_ProductID = 0x0815,//Format:Integer ��Ʒ���
            SDO_ProductName = 0x0816,//Format:String ��Ʒ����
            SDO_ItemCode = 0x0817,//Format:Integer ���߱��
            SDO_ItemName = 0x0818,//Format:String ��������
            SDO_TimesLimit = 0x0819,//Format:Integer ʹ�ô���
            SDO_DateLimit = 0x0820,//Format:Integer ʹ��ʱЧ
            SDO_MoneyType = 0x0821,//Format:Integer ��������
            SDO_MoneyCost = 0x0822,//Format:Integer ���ߵļ۸�
            SDO_ShopTime = 0x0823,//Format:DateTime ����ʱ��
            SDO_MAINCH = 0x0824,//Format:Integer ������
            SDO_SUBCH = 0x0825,//Format:Integer ����
            SDO_Online = 0x0826,//Format:Integer �Ƿ�����
            SDO_LoginTime = 0x0827,//Format:DateTime ����ʱ��
            SDO_LogoutTime = 0x0828,//Format:DateTime ����ʱ��
            SDO_AREANAME = 0x0829,//Format:String ��������
            SDO_City = 0x0830,//Format:String �����ס����
            SDO_Title = 0x0831,//Format:String ��������
            SDO_Context = 0x0832,//Format:String ��������
            SDO_MinLevel = 0x0833,//Format:Integer �������ߵ���С�ȼ�
            SDO_ActiveStatus = 0x0834,//Format:Integer ����״̬
            SDO_StopStatus = 0x0835,//Format:Integer ��ͣ״̬
            SDO_NickName = 0x0836,//Format:String �س�
            SDO_9YouAccount = 0x0837,//Format:Integer 9you���ʺ�
            SDO_SEX = 0x0838,//Format:Integer �Ա�
            SDO_RegistDate = 0x0839,//Format:Date ע������
            SDO_FirstLogintime = 0x0840,//Format:Date ��һ�ε�¼ʱ��
            SDO_LastLogintime = 0x0841,//Format:Date ���һ�ε�¼ʱ��
            SDO_Ispad = 0x0842,//Format:Integer �Ƿ���ע������̺
            SDO_Desc = 0x0843,//Format:String ��������
            SDO_Postion = 0x0844,//Format:Integer ����λ��
            SDO_BeginTime = 0x0845,//Format:Date ���Ѽ�¼��ʼʱ��
            SDO_EndTime = 0x0846,//Format:Date ���Ѽ�¼����ʱ��
            SDO_SendTime = 0x0847,//Format:Date ������������
            SDO_SendIndexID = 0x0848,//Format:Integer �����˵�ID
            SDO_SendUserID = 0x0849,//Format:String �������ʺ�
            SDO_ReceiveNick = 0x0850,//Format:String �������س�
            SDO_BigType = 0x0851,//Format:Integer ���ߴ���
            SDO_SmallType = 0x0852,//Format:Integer ����С��
            SDO_REASON = 0x0853,//Format:String ͣ������
            SDO_StopTime = 0x0854,//Format:TimeStamp ͣ��ʱ��
            SDO_DaysLimit = 0x0855,//Format:Integer ʹ������
            SDO_Email = 0x0856,//Format:String �ʼ�
            SDO_ChargeSum = 0x0857,//Format:String ��ֵ�ϼ�
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
            SDO_Score = 0x08101,//����
            SDO_FirstPadTime = 0x08102,//����̺��һ��ʹ��ʱ��
            SDO_BanDate = 0x08103,//ͣ�������
            SDO_Passwd = 0x08104,
            SDO_OnlineTime = 0x08105,//����ʱ��string
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

            ServerInfo_IP = 0x0901,//Format:String ������IP
            ServerInfo_City = 0x0902,//Format:String ����
            ServerInfo_GameID = 0x0903,//Format:Integer ��ϷID
            ServerInfo_GameName = 0x0904,//Format:String ��Ϸ��
            ServerInfo_GameDBID = 0x0905,//Format:Integer ��Ϸ���ݿ�����
            ServerInfo_GameFlag = 0x0906,//Format:Integer ��Ϸ������״̬
            ServerInfo_Idx = 0x0907,
            ServerInfo_DBName = 0x0908,
            SDO_PunishTimes = 0x08127,
            SDO_DelTimes = 0x08128,
            SDO_DATE = 0x08129,
            ///////////////////////////////////////////////////////////////////////
            /// <summary>
            /// �����Ŷ���
            /// </summary>
            AU_ACCOUNT = 0x1001,//����ʺ� Format:String
            AU_UserNick = 0x1002,//����س� Format:String
            AU_Sex = 0x1003,//����Ա� Format:Integer
            AU_State = 0x1004,//���״̬ Format:Integer
            AU_STOPSTATUS = 0x1005,//�����߷�ͣ״̬ Format:Integer
            AU_Reason = 0x1006,//��ͣ���� Format:String
            AU_BanDate = 0x1007,//��ͣ���� Format:TimeStamp
            AU_ServerIP = 0x1008,//��������Ϸ������ Format:String
            AU_Id9you = 0x1009, //Format:Integer 9youID
            AU_UserSN = 0x1010, //Format:Integer �û����к�
            AU_EquipState = 0x1011, //Format:String 
            AU_AvatarItem = 0x1012, //Format:Integer
            AU_BuyNick = 0x1013, //Format:String �����س�
            AU_BuyDate = 0x1014,//Format:Timestamp ��������
            AU_ExpireDate = 0x1015,//Format:TimesStamp  ��������
            AU_BuyType = 0x1016, // Format:Integer ��������

            AU_PresentID = 0x1017, //Format:Integer ����ID
            AU_SendSN = 0x1018, //Format:Integer  ����SN
            AU_SendNick = 0x1019, //Format:String �����س�
            AU_RecvSN = 0x1020, //Format:String ������SN
            AU_RecvNick = 0x1021, //Format:String �������س�
            AU_Kind = 0x1022, //Format:Integer ����
            AU_ItemID = 0x1023, //Format:Integer ����ID
            AU_Period = 0x1024, //Format:Integer �ڼ�
            AU_BeforeCash = 0x1025, //Format:Integer ����֮ǰ���
            AU_AfterCash = 0x1026, //Format:Integer ����֮����
            AU_SendDate = 0x1027, //Format:TimeStamp ��������
            AU_RecvDate = 0x1028,//Format:TimeStamp ��������
            AU_Memo = 0x1029,//Format:String ��ע
            AU_UserID = 0x1030, //Format:String ���ID
            AU_Exp = 0x1031, //Format:Integer ��Ҿ���
            AU_Point = 0x1032, //Format:Integer ���λ��
            AU_Money = 0x1033, //Format:Integer ��Ǯ
            AU_Cash = 0x1034, //Format:Integer �ֽ�
            AU_Level = 0x1035, //Format:Integer �ȼ�
            AU_Ranking = 0x1036, //Format:Integer ����
            AU_IsAllowMsg = 0x1037, //Format:Integer ������Ϣ
            AU_IsAllowInvite = 0x1038, //Format:Integer ��������
            AU_LastLoginTime = 0x1039, //Format:TimeStamp ����¼ʱ��
            AU_Password = 0x1040, //Format:String ����
            AU_UserName = 0x1041, //Format:String �û���
            AU_UserGender = 0x1042, //Format:String 
            AU_UserPower = 0x1043, //Format:Integer
            AU_UserRegion = 0x1044, //Format:String 
            AU_UserEMail = 0x1045, //Format:String �û������ʼ�
            AU_RegistedTime = 0x1046, //Format:TimeStamp ע��ʱ��


            AU_ItemName = 0x1047,//������
            AU_ItemStyle = 0x1048,//��������
            AU_Demo = 0x1049,//���� 
            AU_BeginTime = 0x1050,//��ʼʱ��
            AU_EndTime = 0x1051,//����ʱ��
            AU_SendUserID = 0x1052,//�������ʺ�
            AU_RecvUserID = 0x1053,//�������ʺ� 
            AU_SexIndex = 0x1054,//�Ա�
            AU_UserTitle = 0x1055,//�ƺ� 
            AU_Pcash = 0x1056,//�ƺ�
            AU_WeddingDate = 0x1057,//Format:TimesStamp;   ����
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
            /// ��񿨶�������
            /// </summary>
            CR_ServerIP = 0x1101,//������IP
            CR_ACCOUNT = 0x1102,//����ʺ� Format tring
            CR_Passord = 0x1103,//������� Format tring
            CR_NUMBER = 0x1104,//������ Format tring
            CR_ISUSE = 0x1105,//�Ƿ�ʹ��
            CR_STATUS = 0x1106,//���״̬ Format:Integer
            CR_ActiveIP = 0x1107,//���������IP Format:String
            CR_ActiveDate = 0x1108,//�������� Format:TimeStamp
            CR_BoardID = 0x1109,//����ID Format:Integer
            CR_BoardContext = 0x1110,//�������� Format:String
            CR_BoardColor = 0x1111,//������ɫ Format:String
            CR_ValidTime = 0x1112,//��Чʱ�� Format:TimeStamp
            CR_InValidTime = 0x1113,//ʧЧʱ�� Format:TimeStamp
            CR_Valid = 0x1114,//�Ƿ���Ч Format:Integer
            CR_PublishID = 0x1115,//������ID Format:Integer
            CR_DayLoop = 0x1116,//ÿ�첥�� Format:Integer
            CR_PSTID = 0x1117,//ע��� Format:Integer
            CR_SEX = 0x1118,//�Ա� Format:Integer
            CR_LEVEL = 0x1119,//�ȼ� Format:Integer
            CR_EXP = 0x1120,//���� Format:Integer
            CR_License = 0x1121,//����Format:Integer
            CR_Money = 0x1122,//��ǮFormat:Integer
            CR_RMB = 0x1123,//�����Format:Integer
            CR_RaceTotal = 0x1124,//��������Format:Integer
            CR_RaceWon = 0x1125,//ʤ������Format:Integer
            CR_ExpOrder = 0x1126,//��������Format:Integer
            CR_WinRateOrder = 0x1127,//ʤ������Format:Integer
            CR_WinNumOrder = 0x1128,//ʤ����������Format:Integer
            CR_SPEED = 0x1129,//�����ٶ�Format:Integer
            CR_Mode = 0x1130,//���ŷ�ʽ Format:Integer
            CR_ACTION = 0x1131,//��ѯ������Format:Integer
            CR_NickName = 0x1132,//�س� Format:String
            CR_Channel = 0x1133,//Ƶ��ID
            CR_UserID = 0x1134,//�û�ID
            CR_BoardContext1 = 0x1135,//����1
            CR_BoardContext2 = 0x1136,//����2
            CR_Expire = 0x1137,//��Ч��ʽ
            CR_ChannelID = 0x1138,//Ƶ��ID
            CR_ChannelName = 0x1139,//Ƶ������
            CR_Last_Login = 0x1140,//�ϴε���ʱ��		
            CR_Last_Logout = 0x1141,//�ϴεǳ�ʱ��		
            CR_Last_Playing_Time = 0x1142,//�ϴ���Ϸʱ��		
            CR_Total_Time = 0x1143,//�ܵ���Ϸʱ��    
            CR_UserName = 0x1144,//�������
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
            CARD_id = 0x1251,//TLV_STRING ��֮��ע�Ῠ��
            CARD_username = 0x1252,//TLV_STRING ��֮��ע���û���
            CARD_nickname = 0x1253,//TLV_STRING ��֮��ע���س�
            CARD_password = 0x1254,//TLV_STRING ��֮��ע������
            CARD_sex = 0x1255,//TLV_STRING ��֮��ע���Ա�
            CARD_rdate = 0x1256,//TLV_Date ��֮��ע������
            CARD_rtime = 0x1257,//TLV_Time ��֮��ע��ʱ��
            CARD_securecode = 0x1258,//TLV_STRING ��ȫ��
            CARD_vis = 0x1259,//TLV_INTEGER
            CARD_logdate = 0x1260,//TLV_TimeStamp ����
            CARD_realname = 0x1263,//TLV_STRING ��ʵ����
            CARD_birthday = 0x1264,//TLV_Date ��������
            CARD_cardtype = 0x1265,//TLV_STRING
            CARD_email = 0x1267,//TLV_STRING �ʼ�
            CARD_occupation = 0x1268,//TLV_STRING ְҵ
            CARD_education = 0x1269,//TLV_STRING �����̶�
            CARD_marriage = 0x1270,//TLV_STRING ���
            CARD_constellation = 0x1271,//TLV_STRING ����
            CARD_shx = 0x1272,//TLV_STRING ��Ф
            CARD_city = 0x1273,//TLV_STRING ����
            CARD_address = 0x1274,//TLV_STRING ��ϵ��ַ
            CARD_phone = 0x1275,//TLV_STRING ��ϵ�绰
            CARD_qq = 0x1276,//TLV_STRING QQ
            CARD_intro = 0x1277,//TLV_STRING ����
            CARD_msn = 0x1278,//TLV_STRING MSN
            CARD_mobilephone = 0x1279,//TLV_STRING �ƶ��绰
            CARD_SumTotal = 0x1280,//TLV_INTEGER �ϼ�
            CARD_PayStartDate = 0x1281,//��ʼʱ��
            CARD_PayStopDate = 0x1282,//����ʱ��
            CARD_BalancePrice = 0x1283,//��ǰ�û����б����
            CARD_Douser = 0x1295,//������
            CARD_Wantdouser = 0x1296,//�ύ������
            CARD_Locktype = 0x1297,///��ͣ����  1�����ӵ��� 2������ڵ� 3����ȡ����

            CARD_Salename = 0x1298,//�漰������
            CARD_Locktime = 0x1299,//��ͣʱ��
            CARD_Lockinfo = 0x1240, //��ͣ������Ϣ
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
            CARD_REG = 0x2319,//TLV_STRING ��������(ȡ�û�����)getMyData
            CARD_TYPE = 0x2320,//TLV_STRING ������ʷresetHistory
            CARD_START_DATE = 0x2321,//��ʼ����
            CARD_END_DATE = 0x2322,//��������
            CARD_REGIP = 0x2323,//TLV_STRING 
            CARD_REGS = 0x2324,//TLV_STRING 32λ��֤��

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

            AuShop_PCODE = 0x1365,//���ߴ���
            AuShop_SENDUSER = 0x1366,//������
            AuShop_RECVUSER = 0x1367,//������
            AuShop_ITEMTYPE = 0x1368,//��������
            AuShop_PERIOD = 0x1369,//����ʱ��
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
            /// ������
            /// </summary>
            o2jam_ServerIP = 0x1401,//Format:TLV_STRING IP
            o2jam_UserID = 0x1402,//Format:TLV_STRING �û��ʺ�
            o2jam_UserNick = 0x1403,//Format:TLV_STRING �û��س�
            o2jam_Sex = 0x1404,//Format:TLV_INTEGER �Ա�
            o2jam_Level = 0x1405,//Format:TLV_STRING �ȼ�
            o2jam_Win = 0x1406,//Format:TLV_STRING ʤ
            o2jam_Draw = 0x1407,//Format:TLV_STRING ƽ
            o2jam_Lose = 0x1408,//Format:TLV_STRING ��
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
            /// ������II
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
            O2JAM2_UserNick = 0x1610,//Format:TLV_STRING �û��س�
            O2JAM2_Sex = 0x1611,//Format:TLV_BOOLEAN �Ա�
            O2JAM2_Level = 0x1612,//Format:TLV_INTEGER �ȼ�
            O2JAM2_Win = 0x1613,//Format:TLV_INTEGER ʤ
            O2JAM2_Draw = 0x1614,//Format:TLV_INTEGER ƽ
            O2JAM2_Lose = 0x1615,//Format:TLV_INTEGER ��
            O2JAM2_Exp = 0x1616,//Format:TLV_INTEGER ����
            O2JAM2_TOTAL = 0x1617,//Format:TLV_INTEGER �ܾ���
            O2JAM2_GCash = 0x1618,//Format:TLV_INTEGER G��
            O2JAM2_MCash = 0x1619,//Format:TLV_INTEGER M��
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
            Soccer_charidx = 0x1704,//��ɫ���к� (ExSoccer.dbo.t_character[idx])
            Soccer_charexp = 0x1705,//����ֵ
            Soccer_charlevel = 0x1706,//�ȼ�
            Soccer_charpoint = 0x1707,//G���� 
            Soccer_match = 0x1708,//������
            Soccer_win = 0x1709,//
            Soccer_lose = 0x1710,//ʧ��
            Soccer_draw = 0x1711,//ƽ��
            Soccer_drop = 0x1712,//ƽ��		
            Soccer_charname = 0x1713,//��ɫ��
            Soccer_charpos = 0x1714,//λ��
            Soccer_Type = 0x1715,//��ѯ����
            Soccer_String = 0x1716,//��ѯֵ 
            Soccer_admid = 0x1717,//������ID
            Soccer_deleted_date = 0x1718,//ɾ������
            Soccer_status = 0x1719,//״̬
            Soccer_m_id = 0x1720,//������к� int
            Soccer_m_auth = 0x1721,//����Ƿ�ͣ�� int
            Soccer_regDate = 0x1722,//���ע������ string 
            Soccer_c_date = 0x1723,//��ɫ�������� string 
            Soccer_char_max = 0x1724,//tinyint
            Soccer_char_cnt = 0x1725,//int
            Soccer_ret = 0x1726,//int
            Soccer_kind = 0x1727,//socket,name string
            Soccer_SenderUserName = 0x1728,//string ����������
            Soccer_ReceiveUserName = 0x1729,//string ���߽�����
            Soccer_i_name = 0x1730,//string ��������
            Soccer_item_type = 0x1731,//int ��������
            Soccer_item_equip = 0x1732,//int �����Ƿ�װ��
            Soccer_Ban_Reason = 0x1733,//string ��ͣ����
            Soccer_idx = 0x1734,//int ���ߣ�����code
            Soccer_account_idx = 0x1735,//������к�
            Soccer_title = 0x1736,//string ̧ͷ
            Soccer_content = 0x1737,//string ����
            Soccer_class = 0x1738,//tinyint ����
            Soccer_body_part = 0x1739,//string ���岿��

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
            FJ_Quest_id = 0x1850,//Format TRING ����ID 
            FJ_Quest_state = 0x1851,//Format TRING ����״̬
            FJ_Content = 0x1852,//Format TRING ��������
            FJ_ihonor = 0x1848,//����ֵ
            FJ_icurrank = 0x1849,//�ƺ�
            FJ_RemainCredit = 0x1853,//Format:INT ��Ϸ���̳Ǳ�����
            FJ_LoginIP = 0x1854,//Format TRING ��¼IP
            FJ_Type = 0x1855,//Format:INT ��ϵ����
            FJ_GSName = 0x1856,//Format TRING gs ������
            FJ_MsgContent = 0x1857,//Format TRING ��������
            FJ_BoardFlag = 0x1858,//Format:INT ״̬
            FJ_Interval = 0x1859,//Format:INT ���ͼ��
            FJ_MsgID = 0x1860,
            FJ_Occupation_id = 0x1861,
            FJ_Style = 0x1862,
            FJ_TotalExp = 0x1863,
            FJ_IsOnline = 0x1864,
            FJ_StyleDesc = 0x1865,//���߷����˵�� s
		    FJ_Color = 0x1866,//s
		    FJ_Inst_Cur = 0x1867,//�;���ȷֵ f
		    FJ_Inst_Max = 0x1868,//�;����ֵ f
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
            /// ���쮳�
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



            ERROR_Msg = 0xFFFF,//Format:STRING  ��֤�û�����Ϣ

            Bug_ID = 0x0117,//Format:Integer bugID
            Bug_Subject = 0x0118,//Format:String bug ����
            Bug_Type = 0x0119,//Format:String ����
            Bug_Context = 0x0120,//Format:String ����
            Bug_Date = 0x0121,//Format:TimeStamp ����
            Bug_Sender = 0x0122,//Format:Integer
            Bug_Process = 0x0123,//Format:Integer
            Bug_Result = 0x0124,//Format:String 
            Update_ID = 0x0125,//Format:Integer
            Update_Module = 0x0126,//Format:String
            Update_Context = 0x0127,//Format:String
            Update_Date = 0x0128,//Format:TimeStamp
            CARD_RemainDate = 0x2315,
            TOKEN_username = 0x1284,//TLV_STRING �ܱ��û���
	        TOKEN_esn = 0x1285,//TLV_STRING �ܱ�ESN
	        TOKEN_dpsw = 0x1286,//TLV_STRING �ܱ���̬����
	        TOKEN_spsw = 0x1287,//TLV_STRING �ܱ��̶�����
	        TOKEN_authType = 0x1288,//TLV_STRING �ܱ���֤����
	        TOKEN_provide = 0x1289,//TLV_STRING �ܱ������ṩ��
	        TOKEN_service = 0x1290,//TLV_STRING �ܱ������������
	        TOKEN_certificate = 0x1291,//TLV_STRING �ܱ�������֤
	        TOKEN_code = 0x1292,//TLV_STRING �ܱ���Ӧ״̬��
	        TOKEN_description = 0x1293,//TLV_STRING �ܱ���Ӧ����
            TOKEN_ACTIVEDATE = 0x2327

            
        }
        /// <summary>
        /// �������ͱ�ǩ
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
        /// ���������ǩ
        /// </summary>
        public enum ServiceKey : ushort
        {
            /// <summary>
            /// ����ģ��(0x80)
            /// </summary>
            CONNECT = 0x0001,
            CONNECT_RESP = 0x8001,
            DISCONNECT = 0x0002,
            DISCONNECT_RESP = 0x8002,
            ACCOUNT_AUTHOR = 0x0003,
            ACCOUNT_AUTHOR_RESP = 0x8003,

            SERVERINFO_IP_QUERY = 0x0004,
            SERVERINFO_IP_QUERY_RESP = 0x8004,
            GMTOOLS_OperateLog_Query = 0x0005,//�鿴���߲�����¼
            GMTOOLS_OperateLog_Query_RESP = 0x8005,//�鿴���߲�����¼��Ӧ 
            SERVERINFO_IP_ALL_QUERY = 0x0006,//�鿴������Ϸ��������ַ
            SERVERINFO_IP_ALL_QUERY_RESP = 0x8006,//�鿴������Ϸ��������ַ��Ӧ
            LINK_SERVERIP_CREATE = 0x0007,//�����Ϸ�������ݿ�
            LINK_SERVERIP_CREATE_RESP = 0x8007,//�����Ϸ�������ݿ���Ӧ
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
            ///�û�����ģ��(0x81) 
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
            UPDATE_ACTIVEUSER = 0x0008,//���������û�״̬
            UPDATE_ACTIVEUSER_RESP = 0x8008,//���������û�״̬��Ӧ

            /// <summary>
            /// ģ�����(0x82)
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
            /// �û���ģ��(0x83) 
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
            /// ��Ϸ����(0x84) 
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
            /// NOTES����(0x85) 
            /// </summary>
            NOTES_LETTER_TRANSFER = 0x0001,
            NOTES_LETTER_TRANSFER_RESP = 0x8001,
            NOTES_LETTER_PROCESS = 0x0002, //�ʼ�����
            NOTES_LETTER_PROCESS_RESP = 0x8002,//�ʼ�����
            NOTES_LETTER_TRANSMIT = 0x0003,//�ʼ�ת��
            NOTES_LETTER_TRANSMIT_RESP = 0x8003,//�ʼ�ת����Ӧ

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
            /// �ͽ�GM���߹���(0x86)
            /// </summary>
            MJ_CHARACTERINFO_QUERY = 0x0001,//������״̬
            MJ_CHARACTERINFO_QUERY_RESP = 0x8001,//������״̬��Ӧ
            MJ_CHARACTERINFO_UPDATE = 0x0002,//�޸����״̬
            MJ_CHARACTERINFO_UPDATE_RESP = 0x8002,//�޸����״̬��Ӧ
            MJ_LOGINTABLE_QUERY = 0x0003,//�������Ƿ�����
            MJ_LOGINTABLE_QUERY_RESP = 0x8003,//�������Ƿ�������Ӧ
            MJ_CHARACTERINFO_EXPLOIT_UPDATE = 0x0004,//�޸Ĺ�ѫֵ
            MJ_CHARACTERINFO_EXPLOIT_UPDATE_RESP = 0x8004,//�޸Ĺ�ѫֵ��Ӧ
            MJ_CHARACTERINFO_FRIEND_QUERY = 0x0005,//�г���������
            MJ_CHARACTERINFO_FRIEND_QUERY_RESP = 0x8005,//�г�����������Ӧ
            MJ_CHARACTERINFO_FRIEND_CREATE = 0x0006,//��Ӻ���
            MJ_CHARACTERINFO_FRIEND_CREATE_RESP = 0x8006,//��Ӻ�����Ӧ
            MJ_CHARACTERINFO_FRIEND_DELETE = 0x0007,//ɾ������
            MJ_CHARACTERINFO_FRIEND_DELETE_RESP = 0x8007,//ɾ��������Ӧ
            MJ_GUILDTABLE_UPDATE = 0x0008,//�޸ķ����������Ѵ��ڰ��
            MJ_GUILDTABLE_UPDATE_RESP = 0x8008,//�޸ķ����������Ѵ��ڰ����Ӧ
            MJ_ACCOUNT_LOCAL_CREATE = 0x0009,//���������ϵ�account����������Ϣ���浽���ط�������
            MJ_ACCOUNT_LOCAL_CREATE_RESP = 0x8009,//���������ϵ�account����������Ϣ���浽���ط���������Ӧ
            MJ_ACCOUNT_REMOTE_DELETE = 0x0010,//���÷�ͣ�ʺ�
            MJ_ACCOUNT_REMOTE_DELETE_RESP = 0x8010,//���÷�ͣ�ʺŵ���Ӧ
            MJ_ACCOUNT_REMOTE_RESTORE = 0x0011,//����ʺ�
            MJ_ACCOUNT_REMOTE_RESTORE_RESP = 0x8011,//����ʺ���Ӧ
            MJ_ACCOUNT_LIMIT_RESTORE = 0x0012,//��ʱ�޵ķ�ͣ
            MJ_ACCOUNT_LIMIT_RESTORE_RESP = 0x8012,//��ʱ�޵ķ�ͣ��Ӧ
            MJ_ACCOUNTPASSWD_LOCAL_CREATE = 0x0013,//����������뵽���� 
            MJ_ACCOUNTPASSWD_LOCAL_CREATE_RESP = 0x8013,//����������뵽����
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE = 0x0014,//�޸�������� 
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE_RESP = 0x8014,//�޸��������
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE = 0x0015,//�ָ��������
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE_RESP = 0x8015,//�ָ��������
            MJ_ITEMLOG_QUERY = 0x0016,//�����û����׼�¼
            MJ_ITEMLOG_QUERY_RESP = 0x8016,//�����û����׼�¼
            MJ_GMTOOLS_LOG_QUERY = 0x0017,//���ʹ���߲�����¼
            MJ_GMTOOLS_LOG_QUERY_RESP = 0x8017,//���ʹ���߲�����¼
            MJ_MONEYSORT_QUERY = 0x0018,//���ݽ�Ǯ����
            MJ_MONEYSORT_QUERY_RESP = 0x8018,//���ݽ�Ǯ�������Ӧ
            MJ_LEVELSORT_QUERY = 0x0019,//���ݵȼ�����
            MJ_LEVELSORT_QUERY_RESP = 0x8019,//���ݵȼ��������Ӧ
            MJ_MONEYFIGHTERSORT_QUERY = 0x0020,//���ݲ�ְͬҵ��Ǯ����
            MJ_MONEYFIGHTERSORT_QUERY_RESP = 0x8020,//���ݲ�ְͬҵ��Ǯ�������Ӧ
            MJ_LEVELFIGHTERSORT_QUERY = 0x0021,//���ݲ�ְͬҵ�ȼ�����
            MJ_LEVELFIGHTERSORT_QUERY_RESP = 0x8021,//���ݲ�ְͬҵ�ȼ��������Ӧ
            MJ_MONEYTAOISTSORT_QUERY = 0x0022,//���ݵ�ʿ��Ǯ����
            MJ_MONEYTAOISTSORT_QUERY_RESP = 0x8022,//���ݵ�ʿ��Ǯ�������Ӧ
            MJ_LEVELTAOISTSORT_QUERY = 0x0023,//���ݵ�ʿ�ȼ�����
            MJ_LEVELTAOISTSORT_QUERY_RESP = 0x8023,//���ݵ�ʿ�ȼ��������Ӧ
            MJ_MONEYRABBISORT_QUERY = 0x0024,//���ݷ�ʦ��Ǯ����
            MJ_MONEYRABBISORT_QUERY_RESP = 0x8024,//���ݷ�ʦ��Ǯ�������Ӧ
            MJ_LEVELRABBISORT_QUERY = 0x0025,//���ݷ�ʦ�ȼ�����
            MJ_LEVELRABBISORT_QUERY_RESP = 0x8025,//���ݷ�ʦ�ȼ��������Ӧ
            MJ_ACCOUNT_QUERY = 0x0026,//�ͽ��ʺŲ�ѯ
            MJ_ACCOUNT_QUERY_RESP = 0x8026,//�ͽ��ʺŲ�ѯ��Ӧ
            MJ_ACCOUNT_LOCAL_QUERY = 0x0027,//��ѯ�ͽ������ʺ�
            MJ_ACCOUNT_LOCAL_QUERY_RESP = 0x8027,//��ѯ�ͽ������ʺ���Ӧ

            /// <summary>
            /// SDO_ADMIN �������߹��߲�����Ϣ��
            /// </summary>
            SDO_ACCOUNT_QUERY = 0x0026,//�鿴��ҵ��ʺ���Ϣ
            SDO_ACCOUNT_QUERY_RESP = 0x8026,//�鿴��ҵ��ʺ���Ϣ��Ӧ
            SDO_CHARACTERINFO_QUERY = 0x0027,//�鿴�������ϵ���Ϣ
            SDO_CHARACTERINFO_QUERY_RESP = 0x8027,//�鿴�������ϵ���Ϣ��Ӧ
            SDO_ACCOUNT_CLOSE = 0x0028,//��ͣ�ʻ���Ȩ����Ϣ
            SDO_ACCOUNT_CLOSE_RESP = 0x8028,//��ͣ�ʻ���Ȩ����Ϣ��Ӧ
            SDO_ACCOUNT_OPEN = 0x0029,//����ʻ���Ȩ����Ϣ
            SDO_ACCOUNT_OPEN_RESP = 0x8029,//����ʻ���Ȩ����Ϣ��Ӧ
            SDO_PASSWORD_RECOVERY = 0x0030,//����һ�����
            SDO_PASSWORD_RECOVERY_RESP = 0x8030,//����һ�������Ӧ
            SDO_CONSUME_QUERY = 0x0031,//�鿴��ҵ����Ѽ�¼
            SDO_CONSUME_QUERY_RESP = 0x8031,//�鿴��ҵ����Ѽ�¼��Ӧ
            SDO_USERONLINE_QUERY = 0x0032,//�鿴���������״̬
            SDO_USERONLINE_QUERY_RESP = 0x8032,//�鿴���������״̬��Ӧ
            SDO_USERTRADE_QUERY = 0x0033,//�鿴��ҽ���״̬
            SDO_USERTRADE_QUERY_RESP = 0x8033,//�鿴��ҽ���״̬��Ӧ
            SDO_CHARACTERINFO_UPDATE = 0x0034,//�޸���ҵ��˺���Ϣ
            SDO_CHARACTERINFO_UPDATE_RESP = 0x8034,//�޸���ҵ��˺���Ϣ��Ӧ
            SDO_ITEMSHOP_QUERY = 0x0035,//�鿴��Ϸ�������е�����Ϣ
            SDO_ITEMSHOP_QUERY_RESP = 0x8035,//�鿴��Ϸ�������е�����Ϣ��Ӧ
            SDO_ITEMSHOP_DELETE = 0x0036,//ɾ����ҵ�����Ϣ
            SDO_ITEMSHOP_DELETE_RESP = 0x8036,//ɾ����ҵ�����Ϣ��Ӧ
            SDO_GIFTBOX_CREATE = 0x0037,//����������е�����Ϣ
            SDO_GIFTBOX_CREATE_RESP = 0x8037,//����������е�����Ϣ��Ӧ
            SDO_GIFTBOX_QUERY = 0x0038,//�鿴�������еĵ���
            SDO_GIFTBOX_QUERY_RESP = 0x8038,//�鿴�������еĵ�����Ӧ
            SDO_GIFTBOX_DELETE = 0x0039,//ɾ���������еĵ���
            SDO_GIFTBOX_DELETE_RESP = 0x8039,//ɾ���������еĵ�����Ӧ
            SDO_USERLOGIN_STATUS_QUERY = 0x0040,//�鿴��ҵ�¼״̬
            SDO_USERLOGIN_STATUS_QUERY_RESP = 0x8040,//�鿴��ҵ�¼״̬��Ӧ
            SDO_ITEMSHOP_BYOWNER_QUERY = 0x0041,////�鿴������ϵ�����Ϣ
            SDO_ITEMSHOP_BYOWNER_QUERY_RESP = 0x8041,////�鿴������ϵ�����Ϣ
            SDO_ITEMSHOP_TRADE_QUERY = 0x0042,//�鿴��ҽ��׼�¼��Ϣ
            SDO_ITEMSHOP_TRADE_QUERY_RESP = 0x8042,//�鿴��ҽ��׼�¼��Ϣ����Ӧ
            SDO_MEMBERSTOPSTATUS_QUERY = 0x0043,//�鿴���ʺ�״̬
            SDO_MEMBERSTOPSTATUS_QUERY_RESP = 0x8043,///�鿴���ʺ�״̬����Ӧ
            SDO_MEMBERBANISHMENT_QUERY = 0x0044,//�鿴����ͣ����ʺ�
            SDO_MEMBERBANISHMENT_QUERY_RESP = 0x8044,//�鿴����ͣ����ʺ���Ӧ
            SDO_USERMCASH_QUERY = 0x0045,//��ҳ�ֵ��¼��ѯ
            SDO_USERMCASH_QUERY_RESP = 0x8045,//��ҳ�ֵ��¼��ѯ��Ӧ
            SDO_USERGCASH_UPDATE = 0x0046,//�������G��
            SDO_USERGCASH_UPDATE_RESP = 0x8046,//�������G�ҵ���Ӧ
            SDO_MEMBERLOCAL_BANISHMENT = 0x0047,//���ر���ͣ����Ϣ
            SDO_MEMBERLOCAL_BANISHMENT_RESP = 0x8047,//���ر���ͣ����Ϣ��Ӧ
            SDO_EMAIL_QUERY = 0x0048,//�õ���ҵ�EMAIL
            SDO_EMAIL_QUERY_RESP = 0x8048,//�õ���ҵ�EMAIL��Ӧ
            SDO_USERCHARAGESUM_QUERY = 0x0049,//�õ���ֵ��¼�ܺ�
            SDO_USERCHARAGESUM_QUERY_RESP = 0x8049,//�õ���ֵ��¼�ܺ���Ӧ
            SDO_USERCONSUMESUM_QUERY = 0x0050,//�õ����Ѽ�¼�ܺ�
            SDO_USERCONSUMESUM_QUERY_RESP = 0x8050,//�õ����Ѽ�¼�ܺ���Ӧ
            SDO_USERGCASH_QUERY = 0x0051,//��ңǱҼ�¼��ѯ
            SDO_USERGCASH_QUERY_RESP = 0x8051,//��ңǱҼ�¼��ѯ��Ӧ
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
            SDO_DAYSLIMIT_QUERY = 0x0077,//��Ч�ڲ�ѯ
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
            SDO_USER_PUNISH_RESP = 0x8088,//�����ͷ�
            SDO_PUNISHUSER_IMPORT_QUERY = 0x0089,
            SDO_PUNISHUSER_IMPORT_QUERY_RESP = 0x8089,//������ѯ
            SDO_PUNISHUSER_IMPORT = 0x0090,
            SDO_PUNISHUSER_IMPORT_RESP = 0x8090,//��������
            SDO_USER_PUNISHALL = 0x0091,
            SDO_USER_PUNISHALL_RESP = 0x8091, //�����ͷ�
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
            /// AU_ADMIN �����Ź��߲�����Ϣ��
            /// </summary>
            AU_ACCOUNT_QUERY = 0x0001,//����ʺ���Ϣ��ѯ
            AU_ACCOUNT_QUERY_RESP = 0x8001,//����ʺ���Ϣ��ѯ��Ӧ
            AU_ACCOUNTREMOTE_QUERY = 0x0002,//��Ϸ��������ͣ������ʺŲ�ѯ
            AU_ACCOUNTREMOTE_QUERY_RESP = 0x8002,//��Ϸ��������ͣ������ʺŲ�ѯ��Ӧ
            AU_ACCOUNTLOCAL_QUERY = 0x0003,//���ط�ͣ������ʺŲ�ѯ
            AU_ACCOUNTLOCAL_QUERY_RESP = 0x8003,//���ط�ͣ������ʺŲ�ѯ��Ӧ
            AU_ACCOUNT_CLOSE = 0x0004,//��ͣ������ʺ�
            AU_ACCOUNT_CLOSE_RESP = 0x8004,//��ͣ������ʺ���Ӧ
            AU_ACCOUNT_OPEN = 0x0005,//��������ʺ�
            AU_ACCOUNT_OPEN_RESP = 0x8005,//��������ʺ���Ӧ
            AU_ACCOUNT_BANISHMENT_QUERY = 0x0006,//��ҷ�ͣ�ʺŲ�ѯ
            AU_ACCOUNT_BANISHMENT_QUERY_RESP = 0x8006,//��ҷ�ͣ�ʺŲ�ѯ��Ӧ
            AU_CHARACTERINFO_QUERY = 0x0007,//��ѯ��ҵ��˺���Ϣ
            AU_CHARACTERINFO_QUERY_RESP = 0x8007,//��ѯ��ҵ��˺���Ϣ��Ӧ
            AU_CHARACTERINFO_UPDATE = 0x0008,//�޸���ҵ��˺���Ϣ
            AU_CHARACTERINFO_UPDATE_RESP = 0x8008,//�޸���ҵ��˺���Ϣ��Ӧ
            AU_ITEMSHOP_QUERY = 0x0009,//�鿴��Ϸ�������е�����Ϣ
            AU_ITEMSHOP_QUERY_RESP = 0x8009,//�鿴��Ϸ�������е�����Ϣ��Ӧ
            AU_ITEMSHOP_DELETE = 0x0010,//ɾ����ҵ�����Ϣ
            AU_ITEMSHOP_DELETE_RESP = 0x8010,//ɾ����ҵ�����Ϣ��Ӧ
            AU_ITEMSHOP_BYOWNER_QUERY = 0x0011,////�鿴������ϵ�����Ϣ
            AU_ITEMSHOP_BYOWNER_QUERY_RESP = 0x8011,////�鿴������ϵ�����Ϣ
            AU_ITEMSHOP_TRADE_QUERY = 0x0012,//�鿴��ҽ��׼�¼��Ϣ
            AU_ITEMSHOP_TRADE_QUERY_RESP = 0x8012,//�鿴��ҽ��׼�¼��Ϣ����Ӧ
            AU_ITEMSHOP_CREATE = 0x0013,//����������е�����Ϣ
            AU_ITEMSHOP_CREATE_RESP = 0x8013,//����������е�����Ϣ��Ӧ
            AU_LEVELEXP_QUERY = 0x0014,//�鿴��ҵȼ�����
            AU_LEVELEXP_QUERY_RESP = 0x8014,////�鿴��ҵȼ�������Ӧ
            AU_USERLOGIN_STATUS_QUERY = 0x0015,//�鿴��ҵ�¼״̬
            AU_USERLOGIN_STATUS_QUERY_RESP = 0x8015,//�鿴��ҵ�¼״̬��Ӧ
            AU_USERCHARAGESUM_QUERY = 0x0016,//�õ���ֵ��¼�ܺ�
            AU_USERCHARAGESUM_QUERY_RESP = 0x8016,//�õ���ֵ��¼�ܺ���Ӧ
            AU_CONSUME_QUERY = 0x0017,//�鿴��ҵ����Ѽ�¼
            AU_CONSUME_QUERY_RESP = 0x8017,//�鿴��ҵ����Ѽ�¼��Ӧ
            AU_USERCONSUMESUM_QUERY = 0x0018,//�õ����Ѽ�¼�ܺ�
            AU_USERCONSUMESUM_QUERY_RESP = 0x8018,//�õ����Ѽ�¼�ܺ���Ӧ
            AU_USERMCASH_QUERY = 0x0019,//��ҳ�ֵ��¼��ѯ
            AU_USERMCASH_QUERY_RESP = 0x8019,//��ҳ�ֵ��¼��ѯ��Ӧ
            AU_USERGCASH_QUERY = 0x0020,//��ңǱҼ�¼��ѯ
            AU_USERGCASH_QUERY_RESP = 0x8020,//��ңǱҼ�¼��ѯ��Ӧ
            AU_USERGCASH_UPDATE = 0x0021,//�������G��
            AU_USERGCASH_UPDATE_RESP = 0x8021,//�������G�ҵ���Ӧ
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
            /// CR_ADMIN ��񿨶������߲�����Ϣ��
            /// </summary>
            CR_ACCOUNT_QUERY = 0x0001,//����ʺ���Ϣ��ѯ
            CR_ACCOUNT_QUERY_RESP = 0x8001,//����ʺ���Ϣ��ѯ��Ӧ
            CR_ACCOUNTACTIVE_QUERY = 0x0002,//����ʺż�����Ϣ
            CR_ACCOUNTACTIVE_QUERY_RESP = 0x8002,//����ʺż�����Ӧ
            CR_CALLBOARD_QUERY = 0x0003,//������Ϣ��ѯ
            CR_CALLBOARD_QUERY_RESP = 0x8003,//������Ϣ��ѯ��Ӧ
            CR_CALLBOARD_CREATE = 0x0004,//��������
            CR_CALLBOARD_CREATE_RESP = 0x8004,//����������Ӧ
            CR_CALLBOARD_UPDATE = 0x0005,//���¹�����Ϣ
            CR_CALLBOARD_UPDATE_RESP = 0x8005,//���¹�����Ϣ����Ӧ
            CR_CALLBOARD_DELETE = 0x0006,//ɾ��������Ϣ
            CR_CALLBOARD_DELETE_RESP = 0x8006,//ɾ��������Ϣ����Ӧ

            CR_CHARACTERINFO_QUERY = 0x0007,//��ҽ�ɫ��Ϣ��ѯ
            CR_CHARACTERINFO_QUERY_RESP = 0x8007,//��ҽ�ɫ��Ϣ��ѯ����Ӧ
            CR_CHARACTERINFO_UPDATE = 0x0008,//��ҽ�ɫ��Ϣ��ѯ
            CR_CHARACTERINFO_UPDATE_RESP = 0x8008,//��ҽ�ɫ��Ϣ��ѯ����Ӧ
            CR_CHANNEL_QUERY = 0x0009,//����Ƶ����ѯ
            CR_CHANNEL_QUERY_RESP = 0x8009,//����Ƶ����ѯ����Ӧ
            CR_NICKNAME_QUERY = 0x0010,//����ǳƲ�ѯ
            CR_NICKNAME_QUERY_RESP = 0x8010,//����ǳƵ���Ӧ
            CR_LOGIN_LOGOUT_QUERY = 0x0011,//������ߡ�����ʱ���ѯ
            CR_LOGIN_LOGOUT_QUERY_RESP = 0x8011,//������ߡ�����ʱ���ѯ����Ӧ
            CR_ERRORCHANNEL_QUERY = 0x0012,//������󹫸�Ƶ����ѯ
            CR_ERRORCHANNEL_QUERY_RESP = 0x8012,//������󹫸�Ƶ����ѯ����Ӧ


            /// <summary>
            /// ��ֵ����GM����(0x90)
            /// </summary>
            CARD_USERCHARGEDETAIL_QUERY = 0x0001,//һ��ͨ��ѯ
            CARD_USERCHARGEDETAIL_QUERY_RESP = 0x8001,//һ��ͨ��ѯ��Ӧ
            CARD_USERDETAIL_QUERY = 0x0002,//��֮���û�ע����Ϣ��ѯ
            CARD_USERDETAIL_QUERY_RESP = 0x8002,//��֮���û�ע����Ϣ��ѯ��Ӧ
            CARD_USERCONSUME_QUERY = 0x0003,//���б����Ѳ�ѯ
            CARD_USERCONSUME_QUERY_RESP = 0x8003,//���б����Ѳ�ѯ��Ӧ
            CARD_VNETCHARGE_QUERY = 0x0004,//�����ǿճ�ֵ��ѯ
            CARD_VNETCHARGE_QUERY_RESP = 0x8004,//�����ǿճ�ֵ��ѯ��Ӧ
            CARD_USERDETAIL_SUM_QUERY = 0x0005,//��ֵ�ϼƲ�ѯ
            CARD_USERDETAIL_SUM_QUERY_RESP = 0x8005,//��ֵ�ϼƲ�ѯ��Ӧ
            CARD_USERCONSUME_SUM_QUERY = 0x0006,//���ѺϼƲ�ѯ
            CARD_USERCONSUME_SUM_QUERY_RESP = 0x8006,//���Ѻϼ���Ӧ
            CARD_USERINFO_QUERY = 0x0007,//���ע����Ϣ��ѯ
            CARD_USERINFO_QUERY_RESP = 0x8007,//���ע����Ϣ��ѯ��Ӧ
            CARD_USERINFO_CLEAR = 0x0008,
            CARD_USERINFO_CLEAR_RESP = 0x8008,
            CARD_USERSECURE_CLEAR = 0x0009,//������Ұ�ȫ����Ϣ
            CARD_USERSECURE_CLEAR_RESP = 0x8009,//������Ұ�ȫ����Ϣ��Ӧ
            CARD_USERNICK_QUERY = 0x0010,
            CARD_USERNICK_QUERY_RESP = 0x8010,
            CARD_USERLOCK_UPDATE = 0x0011,
            CARD_USERLOCK_UPDATE_RESP = 0x8011,
            CARD_BALANCE_QUERY = 0x0012,//�û�����ѯ
            CARD_BALANCE_QUERY_RESP = 0x8012,
            CARD_USERNUM_QUERY = 0x0013,//�㿨��ѯ
            CARD_USERNUM_QUERY_RESP = 0x8013,
            CARD_USERHISTORYPWD_QUERY = 0x0014,//��ʷ����
            CARD_USERHISTORYPWD_QUERY_RESP = 0x8014,
            CARD_USERINITACTIVE_QUERY = 0x0015,//������Ϸ
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
            /// �������̳�(0x91)
            /// </summary>
            AUSHOP_USERGPURCHASE_QUERY = 0x0001,//�û�G�ҹ����¼
            AUSHOP_USERGPURCHASE_QUERY_RESP = 0x8001,//�û�G�ҹ����¼
            AUSHOP_USERMPURCHASE_QUERY = 0x0002,//�û�M�ҹ����¼
            AUSHOP_USERMPURCHASE_QUERY_RESP = 0x8002,//�û�M�ҹ����¼
            AUSHOP_AVATARECOVER_QUERY = 0x0003,//���߻��նһ���
            AUSHOP_AVATARECOVER_QUERY_RESP = 0x8003,//���߻��նһ���
            AUSHOP_USERINTERGRAL_QUERY = 0x0004,//�û����ּ�¼
            AUSHOP_USERINTERGRAL_QUERY_RESP = 0x8004,//�û����ּ�¼
            AUSHOP_USEROPERLOG_CREATE = 0x0005,//�û�G�ҹ����¼�ϼ�
            AUSHOP_USEROPERLOG_CREATE_RESP = 0x8005,//�û�G�ҹ����¼�ϼ���Ӧ
            AUSHOP_USERMPURCHASE_SUM_QUERY = 0x0006,//�û�M�ҹ����¼�ϼ�
            AUSHOP_USERMPURCHASE_SUM_QUERY_RESP = 0x8006,//�û�M�ҹ����¼�ϼ���Ӧ
            AUSHOP_AVATARECOVER_DETAIL_QUERY = 0x0007,// �߻��նһ���ϸ��¼
            AUSHOP_AVATARECOVER_DETAIL_QUERY_RESP = 0x8007,// �߻��նһ���ϸ��¼
            AUSHOP_WAREHOUSE_QUERY = 0x0008,//�����Ϸ����ֿ�����ĵ���
            AUSHOP_WAREHOUSE_QUERY_RESP = 0x8008,//�����Ϸ����ֿ�����ĵ���
            AUSHOP_REPEATGet_REFUND = 0x0012,//�������̳� - �����û�������ȡ
            AUSHOP_REPEATGet_REFUND_RESP = 0x8012,//�������̳� - �����û�������ȡ
            AUSHOP_SPECIALAVATITEM_QUERY = 0x0013,//С����
            AUSHOP_SPECIALAVATITEM_QUERY_RESP = 0x8013,//С����
            AUSHOP_OTHERSPECIALAVATITEM_QUERY = 0x0014,//�������������
            AUSHOP_OTHERSPECIALAVATITEM_QUERY_RESP = 0x8014,//�������������

            DEPARTMENT_CREATE = 0x0009,//���Ŵ���
            DEPARTMENT_CREATE_RESP = 0x8009,//���Ŵ�����Ӧ
            DEPARTMENT_UPDATE = 0x0010,//�����޸�
            DEPARTMENT_UPDATE_RESP = 0x8010,//�����޸���Ӧ
            DEPARTMENT_DELETE = 0x0011,//����ɾ��
            DEPARTMENT_DELETE_RESP = 0x8011,//����ɾ����Ӧ
            DEPARTMENT_ADMIN = 0x0012,//���Ź���
            DEPARTMENT_ADMIN_RESP = 0x8012,//���Ź�����Ӧ

            /// <summary>
            /// �����Ź���(0x92)
            /// </summary>
            O2JAM_CHARACTERINFO_QUERY = 0x0001,//��ҽ�ɫ��Ϣ��ѯ
            O2JAM_CHARACTERINFO_QUERY_RESP = 0x8001,//��ҽ�ɫ��Ϣ��ѯ
            O2JAM_CHARACTERINFO_UPDATE = 0x0002,//��ҽ�ɫ��Ϣ����
            O2JAM_CHARACTERINFO_UPDATE_RESP = 0x8002,//��ҽ�ɫ��Ϣ����
            O2JAM_ITEM_QUERY = 0x0003,//��ҵ�����Ϣ��ѯ
            O2JAM_ITEM_QUERY_RESP = 0x8003,//��ҽ�ɫ��Ϣ��ѯ
            O2JAM_ITEM_UPDATE = 0x0004,//��ҵ�����Ϣ����
            O2JAM_ITEM_UPDATE_RESP = 0x8004,//��ҵ�����Ϣ����
            O2JAM_CONSUME_QUERY = 0x0005,//���������Ϣ��ѯ
            O2JAM_CONSUME_QUERY_RESP = 0x8005,//���������Ϣ��ѯ
            O2JAM_ITEMDATA_QUERY = 0x0006,// ���б��ѯ
            O2JAM_ITEMDATA_QUERY_RESP = 0x8006,// ���б���Ϣ��ѯ
            O2JAM_GIFTBOX_QUERY = 0x0007,//�������в�ѯ
            O2JAM_GIFTBOX_QUERY_RESP = 0x8007,//�������в�ѯ
            O2JAM_USERGCASH_UPDATE = 0x0008,//�������G��
            O2JAM_USERGCASH_UPDATE_RESP = 0x8008,//�������G�ҵ���Ӧ
            O2JAM_CONSUME_SUM_QUERY = 0x0009,//���������Ϣ��ѯ
            O2JAM_CONSUME_SUM_QUERY_RESP = 0x8009,//���������Ϣ��ѯ
            O2JAM_GIFTBOX_CREATE_QUERY = 0x0010,//����������� ��
            O2JAM_GIFTBOX_CREATE_QUERY_RESP = 0x8010,//����������� ��
            O2JAM_ITEMNAME_QUERY = 0x0011,
            O2JAM_ITEMNAME_QUERY_RESP = 0x8011,

            O2JAM_GIFTBOX_DELETE = 0x0012,
            O2JAM_GIFTBOX_DELETE_RESP = 0x8012,

            DEPARTMENT_RELATE_QUERY = 0x0013,//���Ź�����ѯ
            DEPARTMENT_RELATE_QUERY_RESP = 0x8013,//���Ź�����ѯ


            DEPART_RELATE_GAME_QUERY = 0x0014,
            DEPART_RELATE_GAME_QUERY_RESP = 0x8014,
            USER_SYSADMIN_QUERY = 0x0015,
            USER_SYSADMIN_QUERY_RESP = 0x8015,

            O2JAM_USERLOGIN_DEL = 0x0013,
            O2JAM_USERLOGIN_DEL_RESP = 0x8013,

            /// <summary>
            /// ������IIGM����(0x93)
            /// </summary>
            O2JAM2_ACCOUNT_QUERY = 0x0001,//����ʺ���Ϣ��ѯ
            O2JAM2_ACCOUNT_QUERY_RESP = 0x8001,//����ʺ���Ϣ��ѯ��Ӧ
            O2JAM2_ACCOUNTACTIVE_QUERY = 0x0002,//����ʺż�����Ϣ
            O2JAM2_ACCOUNTACTIVE_QUERY_RESP = 0x8002,//����ʺż�����Ӧ

            O2JAM2_CHARACTERINFO_QUERY = 0x0003,//�û���Ϣ��ѯ
            O2JAM2_CHARACTERINFO_QUERY_RESP = 0x8003,
            O2JAM2_CHARACTERINFO_UPDATE = 0x0004,//�û���Ϣ�޸�
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

            O2JAM2_ACCOUNT_CLOSE = 0x0015,//��ͣ�ʻ���Ȩ����Ϣ
            O2JAM2_ACCOUNT_CLOSE_RESP = 0x8015,//��ͣ�ʻ���Ȩ����Ϣ��Ӧ

            O2JAM2_ACCOUNT_OPEN = 0x0016,//����ʻ���Ȩ����Ϣ
            O2JAM2_ACCOUNT_OPEN_RESP = 0x8016,//����ʻ���Ȩ����Ϣ��Ӧ
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
            /// ��������
            /// </summary>
            SOCCER_CHARACTERINFO_QUERY = 0x0001,//�û���Ϣ��ѯ
            SOCCER_CHARACTERINFO_QUERY_RESP = 0x8001,
            SOCCER_CHARCHECK_QUERY = 0x0002,//�û�NameCheck,SocketCheck
            SOCCER_CHARCHECK_QUERY_RESP = 0x8002,
            SOCCER_CHARITEMS_RECOVERY_QUERY = 0x0003,//�û�����
            SOCCER_CCHARITEMS_RECOVERY_QUERY_RESP = 0x8003,
            SOCCER_CHARPOINT_QUERY = 0x0004,//�û�G���޸�
            SOCCER_CHARPOINT_QUERY_RESP = 0x8004,
            SOCCER_DELETEDCHARACTERINFO_QUERY = 0x0005,//ɾ���û���ѯ
            SOCCER_DELETEDCHARACTERINFO_QUERY_RESP = 0x8005,

            SOCCER_CHARACTERSTATE_MODIFY = 0x0006,//ͣ���ɫ
            SOCCER_CHARACTERSTATE_MODIFY_RESP = 0x8006,
            SOCCER_ACCOUNTSTATE_MODIFY = 0x0007,//ͣ�����
            SOCCER_ACCOUNTSTATE_MODIFY_RESP = 0x8007,
            SOCCER_CHARACTERSTATE_QUERY = 0x0008,//ͣ���ɫ��ѯ
            SOCCER_CHARACTERSTATE_QUERY_RESP = 0x8008,
            SOCCER_ACCOUNTSTATE_QUERY = 0x0009,//ͣ����Ҳ�ѯ
            SOCCER_ACCOUNTSTATE_QUERY_RESP = 0x8009,
            SOCCER_ACCOUNTACTIVE_QUERY = 0x0010,//��Ҽ����ѯ		
            SOCCER_ACCOUNTACTIVE_QUERY_RESP = 0x8010,
            SOCCER_USERTRADE_QUERY = 0x0011,//��ҵ��߹����¼�����ͼ�¼
            SOCCER_USERTRADE_QUERY_RESP = 0x8011,

            SOCCER_ITEM_SKILL_MODIFY = 0x0012,//ɾ����ɫ���ߡ�����
            SOCCER_ITEM_SKILL_MODIFY_RESP = 0x8012,//ɾ����ɫ���ߡ�����

            SOCCER_ACCOUNT_ITEMSKILL_QUERY = 0x0013,//������ϵĵ��ߡ�����
            SOCCER_ACCOUNT_ITEMSKILL_QUER_RESPY = 0x8013,//������ϵĵ��ߡ����� 

            SOCCER_CHARINFO_MODIFY = 0x0014,//��ҽ�ɫ��Ϣ�޸�
            SOCCER_CHARINFO_MODIFY_RESPY = 0x8014,//��ҽ�ɫ��Ϣ�޸�

            SOCCER_ITEMSHOP_INSERT = 0x0015,//��������͵���
            SOCCER_ITEMSHOP_INSERT_RESPY = 0x8015,//��������͵���

            SOCCER_ITEM_SKILL_QUERY = 0x0016,//��ý�ɫ���ߡ�����
            SOCCER_ITEM_SKILL_QUERY_RESP = 0x8016,//��ý�ɫ���ߡ�����

            SOCCER_ITEM_SKILL_BLUR_QUERY = 0x0017,//��ý�ɫ���ߡ�����
            SOCCER_ITEM_SKILL_BLUR_QUERY_RESP = 0x8017,//��ý�ɫ���ߡ�����
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

            TOKEN_TOKENSTATUS_QUERY = 0x0016,//��ʾ���Ƶĵ�ǰ״̬
            TOKEN_TOKENSTATUS_QUERY_RESP = 0x8016,
            TOKEN_MODIFYUSER_QUERY = 0x0017,//�û������޸�
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

            AUSHOP_ERRBUY_REFUND = 0x0009,//�������̳� - �������˿� 
            AUSHOP_ERRBUY_REFUND_RESP = 0x8009,//�������̳� - �������˿� 
            AUSHOP_REPEATBuy_REFUND = 0x0010,//�������̳� - �ظ������˿� 
            AUSHOP_REPEATBuy_REFUND_RESP = 0x8010,//�������̳� - �ظ������˿� 
            AUSHOP_FillBuy_REFUND = 0x0011,//�������̳� - ����
            AUSHOP_FillBuy_REFUND_RESP = 0x8011,//�������̳� - ����
            ERROR = 0xFFFF
        }

        /// <summary>
        /// ��Ϣ���ͱ�ǩ
        /// </summary>
        public enum Msg_Category : byte
        {
            COMMON = 0x80,//������Ϣ��
            USER_ADMIN = 0x81,//GM�ʺŲ�����Ϣ��
            MODULE_ADMIN = 0x82,//ģ�������Ϣ��
            USER_MODULE_ADMIN = 0x83,//�û���ģ�������Ϣ��
            GAME_ADMIN = 0x84, //��Ϸģ�������Ϣ��
            NOTES_ADMIN = 0x85,//NOTESģ�������Ϣ��
            MJ_ADMIN = 0x86,//�ͽ���ϷGM���߲�����Ϣ��
            SDO_ADMIN = 0x87,//�������߲�����Ϣ��
            AU_ADMIN = 0x88,//������
            CR_ADMIN = 0x89,//��񿨶���������Ϣ��
            CARD_ADMIN = 0x90,
            AUSHOP_ADMIN = 0x91,
            O2JAM_ADMIN = 0x92,
            O2JAM2_ADMIN = 0x93,
            SOCCER_ADMIN = 0x94,//���������¼��Ϣ��
            FJ_ADMIN = 0x95,
            RC_ADMIN = 0x96,
            ERROR = 0xFF
        }

        /// <summary>
        /// ��Ϣ״̬��ǩ
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
        /// ��Ϣͷ��ǩ
        /// </summary>
        public enum Message_Tag_ID : uint
        {
            /// <summary>
            /// ����ģ��(0x80)
            /// </summary>
            CONNECT = 0x800001,//��������
            CONNECT_RESP = 0x808001,//������Ӧ
            DISCONNECT = 0x800002,//�Ͽ�����
            DISCONNECT_RESP = 0x808002,//�Ͽ���Ӧ
            ACCOUNT_AUTHOR = 0x800003,//�û������֤����
            ACCOUNT_AUTHOR_RESP = 0x808003,//�û������֤��Ӧ
            SERVERINFO_IP_QUERY = 0x800004,
            SERVERINFO_IP_QUERY_RESP = 0x808004,
            GMTOOLS_OperateLog_Query = 0x800005,//�鿴���߲�����¼
            GMTOOLS_OperateLog_Query_RESP = 0x808005,//�鿴���߲�����¼��Ӧ


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
            /// �û�����ģ��(0x81)
            /// </summary>
            USER_CREATE = 0x810001,//����GM�ʺ�����
            USER_CREATE_RESP = 0x818001,//����GM�ʺ���Ӧ
            USER_UPDATE = 0x810002,//����GM�ʺ���Ϣ����
            USER_UPDATE_RESP = 0x818002,//����GM�ʺ���Ϣ��Ӧ
            USER_DELETE = 0x810003,//ɾ��GM�ʺ���Ϣ����
            USER_DELETE_RESP = 0x818003,//ɾ��GM�ʺ���Ϣ��Ӧ
            USER_QUERY = 0x810004,//��ѯGM�ʺ���Ϣ����
            USER_QUERY_RESP = 0x818004,//��ѯGM�ʺ���Ϣ��Ӧ
            USER_PASSWD_MODIF = 0x810005,//�����޸�����
            USER_PASSWD_MODIF_RESP = 0x818005, //�����޸���Ϣ��Ӧ
            USER_QUERY_ALL = 0x810006,//��ѯ����GM�ʺ���Ϣ
            USER_QUERY_ALL_RESP = 0x818006,//��ѯ����GM�ʺ���Ϣ��Ӧ
            DEPART_QUERY = 0x810007, //��ѯ�����б�
            DEPART_QUERY_RESP = 0x818007,//��ѯ�����б���Ӧ
            UPDATE_ACTIVEUSER = 0x810008,//���������û�״̬
            UPDATE_ACTIVEUSER_RESP = 0x818008,//���������û�״̬��Ӧ

            /// <summary>
            /// ģ�����(0x82)
            /// </summary>
            MODULE_CREATE = 0x820001,//����ģ����Ϣ����
            MDDULE_CREATE_RESP = 0x828001,//����ģ����Ϣ��Ӧ
            MODULE_UPDATE = 0x820002,//����ģ����Ϣ����
            MODULE_UPDATE_RESP = 0x828002,//����ģ����Ϣ��Ӧ
            MODULE_DELETE = 0x820003,//ɾ��ģ������
            MODULE_DELETE_RESP = 0x828003,//ɾ��ģ����Ӧ
            MODULE_QUERY = 0x820004,//��ѯģ����Ϣ������
            MODULE_QUERY_RESP = 0x828004,//��ѯģ����Ϣ����Ӧ

            /// <summary>
            /// �û���ģ�����(0x83)
            /// </summary>
            USER_MODULE_CREATE = 0x830001,//�����û���ģ������
            USER_MODULE_CREATE_RESP = 0x838001,//�����û���ģ����Ӧ
            USER_MODULE_UPDATE = 0x830002,//�����û���ģ�������
            USER_MODULE_UPDATE_RESP = 0x838002,//�����û���ģ�����Ӧ
            USER_MODULE_DELETE = 0x830003,//ɾ���û���ģ������
            USER_MODULE_DELETE_RESP = 0x838003,//ɾ���û���ģ����Ӧ
            USER_MODULE_QUERY = 0x830004,//��ѯ�û�����Ӧģ������
            USER_MODULE_QUERY_RESP = 0x838004,//��ѯ�û�����Ӧģ����Ӧ

            /// <summary>
            /// ��Ϸ����(0x84)
            /// </summary>
            GAME_CREATE = 0x840001,//����GM�ʺ�����
            GAME_CREATE_RESP = 0x848001,//����GM�ʺ���Ӧ
            GAME_UPDATE = 0x840002,//����GM�ʺ���Ϣ����
            GAME_UPDATE_RESP = 0x848002,//����GM�ʺ���Ϣ��Ӧ
            GAME_DELETE = 0x840003,//ɾ��GM�ʺ���Ϣ����
            GAME_DELETE_RESP = 0x848003,//ɾ��GM�ʺ���Ϣ��Ӧ
            GAME_QUERY = 0x840004,//��ѯGM�ʺ���Ϣ����
            GAME_QUERY_RESP = 0x848004,//��ѯGM�ʺ���Ϣ��Ӧ
            GAME_MODULE_QUERY = 0x840005,//��ѯ��Ϸ��ģ���б�
            GAME_MODULE_QUERY_RESP = 0x848005,//��ѯ��Ϸ��ģ���б���Ӧ


            /// <summary>
            /// NOTES����(0x85)
            /// </summary>
            NOTES_LETTER_TRANSFER = 0x850001, //ȡ���ʼ��б�
            NOTES_LETTER_TRANSFER_RESP = 0x858001,//ȡ���ʼ��б����Ӧ
            NOTES_LETTER_PROCESS = 0x850002, //�ʼ�����
            NOTES_LETTER_PROCESS_RESP = 0x858002,//�ʼ�����
            NOTES_LETTER_TRANSMIT = 0x850003, //�ʼ�ת���б�
            NOTES_LETTER_TRANSMIT_RESP = 0x858003,//�ʼ�ת���б�
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
            /// �ͽ�GM����(0x86)
            /// </summary>
            MJ_CHARACTERINFO_QUERY = 0x860001,//������״̬
            MJ_CHARACTERINFO_QUERY_RESP = 0x868001,//������״̬��Ӧ
            MJ_CHARACTERINFO_UPDATE = 0x860002,//�޸����״̬
            MJ_CHARACTERINFO_UPDATE_RESP = 0x868002,//�޸����״̬��Ӧ
            MJ_LOGINTABLE_QUERY = 0x860003,//�������Ƿ�����
            MJ_LOGINTABLE_QUERY_RESP = 0x868003,//�������Ƿ�������Ӧ
            MJ_CHARACTERINFO_EXPLOIT_UPDATE = 0x860004,//�޸Ĺ�ѫֵ
            MJ_CHARACTERINFO_EXPLOIT_UPDATE_RESP = 0x868004,//�޸Ĺ�ѫֵ��Ӧ
            MJ_CHARACTERINFO_FRIEND_QUERY = 0x860005,//�г���������
            MJ_CHARACTERINFO_FRIEND_QUERY_RESP = 0x868005,//�г�����������Ӧ
            MJ_CHARACTERINFO_FRIEND_CREATE = 0x860006,//��Ӻ���
            MJ_CHARACTERINFO_FRIEND_CREATE_RESP = 0x868006,//��Ӻ�����Ӧ
            MJ_CHARACTERINFO_FRIEND_DELETE = 0x860007,//ɾ������
            MJ_CHARACTERINFO_FRIEND_DELETE_RESP = 0x868007,//ɾ��������Ӧ
            MJ_GUILDTABLE_UPDATE = 0x860008,//�޸ķ����������Ѵ��ڰ��
            MJ_GUILDTABLE_UPDATE_RESP = 0x868008,//�޸ķ����������Ѵ��ڰ����Ӧ
            MJ_ACCOUNT_LOCAL_CREATE = 0x860009,//���������ϵ�account����������Ϣ���浽���ط�������
            MJ_ACCOUNT_LOCAL_CREATE_RESP = 0x868009,//���������ϵ�account����������Ϣ���浽���ط���������Ӧ
            MJ_ACCOUNT_REMOTE_DELETE = 0x860010,//���÷�ͣ�ʺ�
            MJ_ACCOUNT_REMOTE_DELETE_RESP = 0x868010,//���÷�ͣ�ʺŵ���Ӧ
            MJ_ACCOUNT_REMOTE_RESTORE = 0x860011,//����ʺ�
            MJ_ACCOUNT_REMOTE_RESTORE_RESP = 0x868011,//����ʺ���Ӧ
            MJ_ACCOUNT_LIMIT_RESTORE = 0x860012,//��ʱ�޵ķ�ͣ
            MJ_ACCOUNT_LIMIT_RESTORE_RESP = 0x868012,//��ʱ�޵ķ�ͣ��Ӧ
            MJ_ACCOUNTPASSWD_LOCAL_CREATE = 0x860013,//����������뵽���� 
            MJ_ACCOUNTPASSWD_LOCAL_CREATE_RESP = 0x868013,//����������뵽����
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE = 0x860014,//�޸�������� 
            MJ_ACCOUNTPASSWD_REMOTE_UPDATE_RESP = 0x868014,//�޸��������
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE = 0x860015,//�ָ��������
            MJ_ACCOUNTPASSWD_REMOTE_RESTORE_RESP = 0x868015,//�ָ��������
            MJ_ITEMLOG_QUERY = 0x860016,//�����û����׼�¼
            MJ_ITEMLOG_QUERY_RESP = 0x868016,//�����û����׼�¼
            MJ_GMTOOLS_LOG_QUERY = 0x860017,//���ʹ���߲�����¼
            MJ_GMTOOLS_LOG_QUERY_RESP = 0x868017,//���ʹ���߲�����¼
            MJ_MONEYSORT_QUERY = 0x860018,//���ݽ�Ǯ����
            MJ_MONEYSORT_QUERY_RESP = 0x868018,//���ݽ�Ǯ�������Ӧ
            MJ_LEVELSORT_QUERY = 0x860019,//���ݵȼ�����
            MJ_LEVELSORT_QUERY_RESP = 0x868019,//���ݵȼ��������Ӧ
            MJ_MONEYFIGHTERSORT_QUERY = 0x860020,//���ݲ�ְͬҵ��Ǯ����
            MJ_MONEYFIGHTERSORT_QUERY_RESP = 0x868020,//���ݲ�ְͬҵ��Ǯ�������Ӧ
            MJ_LEVELFIGHTERSORT_QUERY = 0x860021,//���ݲ�ְͬҵ�ȼ�����
            MJ_LEVELFIGHTERSORT_QUERY_RESP = 0x868021,//���ݲ�ְͬҵ�ȼ��������Ӧ
            MJ_MONEYTAOISTSORT_QUERY = 0x860022,//���ݵ�ʿ��Ǯ����
            MJ_MONEYTAOISTSORT_QUERY_RESP = 0x868022,//���ݵ�ʿ��Ǯ�������Ӧ
            MJ_LEVELTAOISTSORT_QUERY = 0x860023,//���ݵ�ʿ�ȼ�����
            MJ_LEVELTAOISTSORT_QUERY_RESP = 0x868023,//���ݵ�ʿ�ȼ��������Ӧ
            MJ_MONEYRABBISORT_QUERY = 0x860024,//���ݷ�ʦ��Ǯ����
            MJ_MONEYRABBISORT_QUERY_RESP = 0x868024,//���ݷ�ʦ��Ǯ�������Ӧ
            MJ_LEVELRABBISORT_QUERY = 0x860025,//���ݷ�ʦ�ȼ�����
            MJ_LEVELRABBISORT_QUERY_RESP = 0x868025,//���ݷ�ʦ�ȼ��������Ӧ
            MJ_ACCOUNT_QUERY = 0x860026,//�ͽ��ʺŲ�ѯ
            MJ_ACCOUNT_QUERY_RESP = 0x868026,//�ͽ��ʺŲ�ѯ��Ӧ
            MJ_ACCOUNT_LOCAL_QUERY = 0x860027,//��ѯ�ͽ������ʺ�
            MJ_ACCOUNT_LOCAL_QUERY_RESP = 0x868027,//��ѯ�ͽ������ʺ���Ӧ
            SDO_ACCOUNT_QUERY = 0x870026,//�鿴��ҵ��ʺ���Ϣ
            SDO_ACCOUNT_QUERY_RESP = 0x878026,//�鿴��ҵ��ʺ���Ϣ��Ӧ
            SDO_CHARACTERINFO_QUERY = 0x870027,//�鿴�������ϵ���Ϣ
            SDO_CHARACTERINFO_QUERY_RESP = 0x878027,//�鿴�������ϵ���Ϣ��Ӧ
            SDO_ACCOUNT_CLOSE = 0x870028,//��ͣ�ʻ���Ȩ����Ϣ
            SDO_ACCOUNT_CLOSE_RESP = 0x878028,//��ͣ�ʻ���Ȩ����Ϣ��Ӧ
            SDO_ACCOUNT_OPEN = 0x870029,//����ʻ���Ȩ����Ϣ
            SDO_ACCOUNT_OPEN_RESP = 0x878029,//����ʻ���Ȩ����Ϣ��Ӧ
            SDO_PASSWORD_RECOVERY = 0x870030,//����һ�����
            SDO_PASSWORD_RECOVERY_RESP = 0x878030,//����һ�������Ӧ
            SDO_CONSUME_QUERY = 0x870031,//�鿴��ҵ����Ѽ�¼
            SDO_CONSUME_QUERY_RESP = 0x878031,//�鿴��ҵ����Ѽ�¼��Ӧ
            SDO_USERONLINE_QUERY = 0x870032,//�鿴���������״̬
            SDO_USERONLINE_QUERY_RESP = 0x878032,//�鿴���������״̬��Ӧ
            SDO_USERTRADE_QUERY = 0x870033,//�鿴��ҽ���״̬
            SDO_USERTRADE_QUERY_RESP = 0x878033,//�鿴��ҽ���״̬��Ӧ
            SDO_CHARACTERINFO_UPDATE = 0x870034,//�޸���ҵ��˺���Ϣ
            SDO_CHARACTERINFO_UPDATE_RESP = 0x878034,//�޸���ҵ��˺���Ϣ��Ӧ
            SDO_ITEMSHOP_QUERY = 0x870035,//�鿴��Ϸ�������е�����Ϣ
            SDO_ITEMSHOP_QUERY_RESP = 0x878035,//�鿴��Ϸ�������е�����Ϣ��Ӧ
            SDO_ITEMSHOP_DELETE = 0x870036,//ɾ����ҵ�����Ϣ
            SDO_ITEMSHOP_DELETE_RESP = 0x878036,//ɾ����ҵ�����Ϣ��Ӧ
            SDO_GIFTBOX_CREATE = 0x870037,//����������е�����Ϣ
            SDO_GIFTBOX_CREATE_RESP = 0x878037,//����������е�����Ϣ��Ӧ
            SDO_GIFTBOX_QUERY = 0x870038,//�鿴�������еĵ���
            SDO_GIFTBOX_QUERY_RESP = 0x878038,//�鿴�������еĵ�����Ӧ
            SDO_GIFTBOX_DELETE = 0x870039,//ɾ���������еĵ���
            SDO_GIFTBOX_DELETE_RESP = 0x878039,//ɾ���������еĵ�����Ӧ
            SDO_USERLOGIN_STATUS_QUERY = 0x870040,//�鿴��ҵ�¼״̬
            SDO_USERLOGIN_STATUS_QUERY_RESP = 0x878040,//�鿴��ҵ�¼״̬��Ӧ
            SDO_ITEMSHOP_BYOWNER_QUERY = 0x870041,////�鿴������ϵ�����Ϣ
            SDO_ITEMSHOP_BYOWNER_QUERY_RESP = 0x878041,////�鿴������ϵ�����Ϣ
            SDO_ITEMSHOP_TRADE_QUERY = 0x870042,//�鿴��ҽ��׼�¼��Ϣ
            SDO_ITEMSHOP_TRADE_QUERY_RESP = 0x878042,//�鿴��ҽ��׼�¼��Ϣ����Ӧ
            SDO_MEMBERSTOPSTATUS_QUERY = 0x870043,//�鿴���ʺ�״̬
            SDO_MEMBERSTOPSTATUS_QUERY_RESP = 0x878043,///�鿴���ʺ�״̬����Ӧ
            SDO_MEMBERBANISHMENT_QUERY = 0x870044,//�鿴����ͣ����ʺ�
            SDO_MEMBERBANISHMENT_QUERY_RESP = 0x878044,//�鿴����ͣ����ʺ���Ӧ
            SDO_USERMCASH_QUERY = 0x870045,//��ҳ�ֵ��¼��ѯ
            SDO_USERMCASH_QUERY_RESP = 0x878045,//��ҳ�ֵ��¼��ѯ��Ӧ
            SDO_USERGCASH_UPDATE = 0x870046,//�������G��
            SDO_USERGCASH_UPDATE_RESP = 0x878046,//�������G�ҵ���Ӧ
            SDO_MEMBERLOCAL_BANISHMENT = 0x870047,//���ر���ͣ����Ϣ
            SDO_MEMBERLOCAL_BANISHMENT_RESP = 0x878047,//���ر���ͣ����Ϣ��Ӧ
            SDO_EMAIL_QUERY = 0x870048,//�õ���ҵ�EMAIL
            SDO_EMAIL_QUERY_RESP = 0x878048,//�õ���ҵ�EMAIL��Ӧ
            SDO_USERCHARAGESUM_QUERY = 0x870049,//�õ���ֵ��¼�ܺ�
            SDO_USERCHARAGESUM_QUERY_RESP = 0x878049,//�õ���ֵ��¼�ܺ���Ӧ
            SDO_USERCONSUMESUM_QUERY = 0x870050,//�õ����Ѽ�¼�ܺ�
            SDO_USERCONSUMESUM_QUERY_RESP = 0x878050,//�õ����Ѽ�¼�ܺ���Ӧ
            SDO_USERGCASH_QUERY = 0x870051,//��ңǱҼ�¼��ѯ
            SDO_USERGCASH_QUERY_RESP = 0x878051,//��ңǱҼ�¼��ѯ��Ӧ

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
            /// ������GM����(0x88)
            /// </summary>
            AU_ACCOUNT_QUERY = 0x880001,//����ʺ���Ϣ��ѯ
            AU_ACCOUNT_QUERY_RESP = 0x888001,//����ʺ���Ϣ��ѯ��Ӧ
            AU_ACCOUNTREMOTE_QUERY = 0x880002,//��Ϸ��������ͣ������ʺŲ�ѯ
            AU_ACCOUNTREMOTE_QUERY_RESP = 0x888002,//��Ϸ��������ͣ������ʺŲ�ѯ��Ӧ
            AU_ACCOUNTLOCAL_QUERY = 0x880003,//���ط�ͣ������ʺŲ�ѯ
            AU_ACCOUNTLOCAL_QUERY_RESP = 0x888003,//���ط�ͣ������ʺŲ�ѯ��Ӧ
            AU_ACCOUNT_CLOSE = 0x880004,//��ͣ������ʺ�
            AU_ACCOUNT_CLOSE_RESP = 0x888004,//��ͣ������ʺ���Ӧ
            AU_ACCOUNT_OPEN = 0x880005,//��������ʺ�
            AU_ACCOUNT_OPEN_RESP = 0x888005,//��������ʺ���Ӧ
            AU_ACCOUNT_BANISHMENT_QUERY = 0x880006,//��ҷ�ͣ�ʺŲ�ѯ
            AU_ACCOUNT_BANISHMENT_QUERY_RESP = 0x888006,//��ҷ�ͣ�ʺŲ�ѯ��Ӧ
            AU_CHARACTERINFO_QUERY = 0x880007,//��ѯ��ҵ��˺���Ϣ
            AU_CHARACTERINFO_QUERY_RESP = 0x888007,//��ѯ��ҵ��˺���Ϣ��Ӧ
            AU_CHARACTERINFO_UPDATE = 0x880008,//�޸���ҵ��˺���Ϣ
            AU_CHARACTERINFO_UPDATE_RESP = 0x888008,//�޸���ҵ��˺���Ϣ��Ӧ
            AU_ITEMSHOP_QUERY = 0x880009,//�鿴��Ϸ�������е�����Ϣ
            AU_ITEMSHOP_QUERY_RESP = 0x888009,//�鿴��Ϸ�������е�����Ϣ��Ӧ
            AU_ITEMSHOP_DELETE = 0x880010,//ɾ����ҵ�����Ϣ
            AU_ITEMSHOP_DELETE_RESP = 0x888010,//ɾ����ҵ�����Ϣ��Ӧ
            AU_ITEMSHOP_BYOWNER_QUERY = 0x880011,////�鿴������ϵ�����Ϣ
            AU_ITEMSHOP_BYOWNER_QUERY_RESP = 0x888011,////�鿴������ϵ�����Ϣ
            AU_ITEMSHOP_TRADE_QUERY = 0x880012,//�鿴��ҽ��׼�¼��Ϣ
            AU_ITEMSHOP_TRADE_QUERY_RESP = 0x888012,//�鿴��ҽ��׼�¼��Ϣ����Ӧ
            AU_ITEMSHOP_CREATE = 0x880013,//����������е�����Ϣ
            AU_ITEMSHOP_CREATE_RESP = 0x888013,//����������е�����Ϣ��Ӧ
            AU_LEVELEXP_QUERY = 0x880014,//�鿴��ҵȼ�����
            AU_LEVELEXP_QUERY_RESP = 0x888014,////�鿴��ҵȼ�������Ӧ
            AU_USERLOGIN_STATUS_QUERY = 0x880015,//�鿴��ҵ�¼״̬
            AU_USERLOGIN_STATUS_QUERY_RESP = 0x888015,//�鿴��ҵ�¼״̬��Ӧ
            AU_USERCHARAGESUM_QUERY = 0x880016,//�õ���ֵ��¼�ܺ�
            AU_USERCHARAGESUM_QUERY_RESP = 0x888016,//�õ���ֵ��¼�ܺ���Ӧ
            AU_CONSUME_QUERY = 0x880017,//�鿴��ҵ����Ѽ�¼
            AU_CONSUME_QUERY_RESP = 0x888017,//�鿴��ҵ����Ѽ�¼��Ӧ
            AU_USERCONSUMESUM_QUERY = 0x880018,//�õ����Ѽ�¼�ܺ�
            AU_USERCONSUMESUM_QUERY_RESP = 0x888018,//�õ����Ѽ�¼�ܺ���Ӧ
            AU_USERMCASH_QUERY = 0x880019,//��ҳ�ֵ��¼��ѯ
            AU_USERMCASH_QUERY_RESP = 0x888019,//��ҳ�ֵ��¼��ѯ��Ӧ
            AU_USERGCASH_QUERY = 0x880020,//��ңǱҼ�¼��ѯ
            AU_USERGCASH_QUERY_RESP = 0x888020,//��ңǱҼ�¼��ѯ��Ӧ
            AU_USERGCASH_UPDATE = 0x880021,//�������G��
            AU_USERGCASH_UPDATE_RESP = 0x888021,//�������G�ҵ���Ӧ
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
            /// ��񿨶���GM����(0x89)
            /// </summary>
            CR_ACCOUNT_QUERY = 0x890001,//����ʺ���Ϣ��ѯ
            CR_ACCOUNT_QUERY_RESP = 0x898001,//����ʺ���Ϣ��ѯ��Ӧ
            CR_ACCOUNTACTIVE_QUERY = 0x890002,//����ʺż�����Ϣ
            CR_ACCOUNTACTIVE_QUERY_RESP = 0x898002,//����ʺż�����Ӧ
            CR_CALLBOARD_QUERY = 0x890003,//������Ϣ��ѯ
            CR_CALLBOARD_QUERY_RESP = 0x898003,//������Ϣ��ѯ��Ӧ
            CR_CALLBOARD_CREATE = 0x890004,//��������
            CR_CALLBOARD_CREATE_RESP = 0x898004,//����������Ӧ
            CR_CALLBOARD_UPDATE = 0x890005,//���¹�����Ϣ
            CR_CALLBOARD_UPDATE_RESP = 0x898005,//���¹�����Ϣ����Ӧ
            CR_CALLBOARD_DELETE = 0x890006,//ɾ��������Ϣ
            CR_CALLBOARD_DELETE_RESP = 0x898006,//ɾ��������Ϣ����Ӧ

            CR_CHARACTERINFO_QUERY = 0x890007,//��ҽ�ɫ��Ϣ��ѯ
            CR_CHARACTERINFO_QUERY_RESP = 0x898007,//��ҽ�ɫ��Ϣ��ѯ����Ӧ
            CR_CHARACTERINFO_UPDATE = 0x890008,//��ҽ�ɫ��Ϣ��ѯ
            CR_CHARACTERINFO_UPDATE_RESP = 0x898008,//��ҽ�ɫ��Ϣ��ѯ����Ӧ
            CR_CHANNEL_QUERY = 0x890009,//����Ƶ����ѯ
            CR_CHANNEL_QUERY_RESP = 0x898009,//����Ƶ����ѯ����Ӧ
            CR_NICKNAME_QUERY = 0x890010,//����ǳƲ�ѯ
            CR_NICKNAME_QUERY_RESP = 0x898010,//����ǳƵ���Ӧ
            CR_LOGIN_LOGOUT_QUERY = 0x890011,//������ߡ�����ʱ���ѯ
            CR_LOGIN_LOGOUT_QUERY_RESP = 0x898011,//������ߡ�����ʱ���ѯ����Ӧ
            CR_ERRORCHANNEL_QUERY = 0x890012,//������󹫸�Ƶ����ѯ
            CR_ERRORCHANNEL_QUERY_RESP = 0x898012,//������󹫸�Ƶ����ѯ����Ӧ


            /// <summary>
            /// ��ֵ����GM����(0x90)
            /// </summary>
            CARD_USERCHARGEDETAIL_QUERY = 0x900001,//һ��ͨ��ѯ
            CARD_USERCHARGEDETAIL_QUERY_RESP = 0x908001,//һ��ͨ��ѯ��Ӧ
            CARD_USERDETAIL_QUERY = 0x900002,//��֮���û�ע����Ϣ��ѯ
            CARD_USERDETAIL_QUERY_RESP = 0x908002,////��֮���û�ע����Ϣ��ѯ��Ӧ
            CARD_USERCONSUME_QUERY = 0x900003,//���б����Ѳ�ѯ
            CARD_USERCONSUME_QUERY_RESP = 0x908003,//���б����Ѳ�ѯ��Ӧ
            CARD_VNETCHARGE_QUERY = 0x900004,//�����ǿճ�ֵ��ѯ
            CARD_VNETCHARGE_QUERY_RESP = 0x908004,//�����ǿճ�ֵ��ѯ��Ӧ
            CARD_USERDETAIL_SUM_QUERY = 0x900005,//��ֵ�ϼƲ�ѯ
            CARD_USERDETAIL_SUM_QUERY_RESP = 0x908005,//��ֵ�ϼƲ�ѯ��Ӧ
            CARD_USERCONSUME_SUM_QUERY = 0x900006,//���ѺϼƲ�ѯ
            CARD_USERCONSUME_SUM_QUERY_RESP = 0x908006,//���Ѻϼ���Ӧ
            CARD_USERINFO_QUERY = 0x900007,//���ע����Ϣ��ѯ
            CARD_USERINFO_QUERY_RESP = 0x908007,//���ע����Ϣ��ѯ��Ӧ��˹�� 26��21:00 �С��� 3
            CARD_USERINFO_CLEAR = 0x900008,
            CARD_USERINFO_CLEAR_RESP = 0x908008,
            CARD_USERLOCK_UPDATE = 0x900011,
            CARD_USERLOCK_UPDATE_RESP = 0x908011,
            CARD_BALANCE_QUERY = 0x900012,//�û�����ѯ
            CARD_BALANCE_QUERY_RESP = 0x908012,
            CARD_USERNUM_QUERY = 0x900013,//�㿨��ѯ
            CARD_USERNUM_QUERY_RESP = 0x908013,
            CARD_USERHISTORYPWD_QUERY = 0x900014,//��ʷ����
            CARD_USERHISTORYPWD_QUERY_RESP = 0x908014,
            CARD_USERINITACTIVE_QUERY = 0x900015,//������Ϸ
            CARD_USERINITACTIVE_QUERY_RESP = 0x908015,
            TOKEN_TOKENSTATUS_QUERY = 0x900016,//��ʾ���Ƶĵ�ǰ״̬
            TOKEN_TOKENSTATUS_QUERY_RESP = 0x908016,
            TOKEN_MODIFYUSER_QUERY = 0x900017,//�û������޸�
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
            /// �������̳�(0x91)
            /// </summary>
            AUSHOP_USERGPURCHASE_QUERY = 0x910001,//�û�G�ҹ����¼
            AUSHOP_USERGPURCHASE_QUERY_RESP = 0x918001,//�û�G�ҹ����¼
            AUSHOP_USERMPURCHASE_QUERY = 0x910002,//�û�M�ҹ����¼
            AUSHOP_USERMPURCHASE_QUERY_RESP = 0x918002,//�û�M�ҹ����¼
            AUSHOP_AVATARECOVER_QUERY = 0x910003,//���߻��նһ���
            AUSHOP_AVATARECOVER_QUERY_RESP = 0x918003,//���߻��նһ���
            AUSHOP_USERINTERGRAL_QUERY = 0x910004,//�û����ּ�¼
            AUSHOP_USERINTERGRAL_QUERY_RESP = 0x918004,//�û����ּ�¼
            AUSHOP_USEROPERLOG_CREATE = 0x910005,//�û�G�ҹ����¼�ϼ�
            AUSHOP_USEROPERLOG_CREATE_RESP = 0x918005,//�û�G�ҹ����¼�ϼ���Ӧ
            AUSHOP_USERMPURCHASE_SUM_QUERY = 0x910006,//�û�M�ҹ����¼�ϼ�
            AUSHOP_USERMPURCHASE_SUM_QUERY_RESP = 0x918006,//�û�M�ҹ����¼�ϼ���Ӧ
            AUSHOP_AVATARECOVER_DETAIL_QUERY = 0x910007,// �߻��նһ���ϸ��¼
            AUSHOP_AVATARECOVER_DETAIL_QUERY_RESP = 0x918007,// �߻��նһ���ϸ��¼
            AUSHOP_WAREHOUSE_QUERY = 0x910008,//�����Ϸ����ֿ�����ĵ���
            AUSHOP_WAREHOUSE_QUERY_RESP = 0x918008,//�����Ϸ����ֿ�����ĵ���
            AUSHOP_ERRBUY_REFUND = 0x910009,//�������̳� - �������˿� 
            AUSHOP_ERRBUY_REFUND_RESP = 0x918009,//�������̳� - �������˿� 
            AUSHOP_REPEATBuy_REFUND = 0x910010,//�������̳� - �ظ������˿� 
            AUSHOP_REPEATBuy_REFUND_RESP = 0x918010,//�������̳� - �ظ������˿� 
            AUSHOP_FillBuy_REFUND = 0x910011,//�������̳� - ����
            AUSHOP_FillBuy_REFUND_RESP = 0x918011,//�������̳� - ����
            AUSHOP_REPEATGet_REFUND = 0x910012,//�������̳� - �����û�������ȡ
            AUSHOP_REPEATGet_REFUND_RESP = 0x918012,//�������̳� - �����û�������ȡ
            AUSHOP_SPECIALAVATITEM_QUERY = 0x910013,//С����
            AUSHOP_SPECIALAVATITEM_QUERY_RESP = 0x918013,//С����
            AUSHOP_OTHERSPECIALAVATITEM_QUERY = 0x910014,//�������������
            AUSHOP_OTHERSPECIALAVATITEM_QUERY_RESP = 0x918014,//�������������


            DEPARTMENT_CREATE = 0x810009,//���Ŵ���
            DEPARTMENT_CREATE_RESP = 0x818009,//���Ŵ�����Ӧ
            DEPARTMENT_UPDATE = 0x810010,//�����޸�
            DEPARTMENT_UPDATE_RESP = 0x818010,//�����޸���Ӧ
            DEPARTMENT_DELETE = 0x810011,//����ɾ��
            DEPARTMENT_DELETE_RESP = 0x818011,//����ɾ����Ӧ
            DEPARTMENT_ADMIN = 0x810012,//���Ź���
            DEPARTMENT_ADMIN_RESP = 0x818012,//���Ź�����Ӧ

            DEPARTMENT_RELATE_QUERY = 0x810013,//���Ź�����ѯ
            DEPARTMENT_RELATE_QUERY_RESP = 0x818013,//���Ź�����ѯ

            /// <summary>
            /// �����Ź���(0x92)
            /// </summary>
            O2JAM_CHARACTERINFO_QUERY = 0x920001,//��ҽ�ɫ��Ϣ��ѯ
            O2JAM_CHARACTERINFO_QUERY_RESP = 0x928001,//��ҽ�ɫ��Ϣ��ѯ
            O2JAM_CHARACTERINFO_UPDATE = 0x920002,//��ҽ�ɫ��Ϣ����
            O2JAM_CHARACTERINFO_UPDATE_RESP = 0x928002,//��ҽ�ɫ��Ϣ����
            O2JAM_ITEM_QUERY = 0x920003,//��ҵ�����Ϣ��ѯ
            O2JAM_ITEM_QUERY_RESP = 0x928003,//��ҽ�ɫ��Ϣ��ѯ
            O2JAM_ITEM_UPDATE = 0x920004,//��ҵ�����Ϣ����
            O2JAM_ITEM_UPDATE_RESP = 0x928004,//��ҵ�����Ϣ����
            O2JAM_CONSUME_QUERY = 0x920005,//���������Ϣ��ѯ
            O2JAM_CONSUME_QUERY_RESP = 0x928005,//���������Ϣ��ѯ
            O2JAM_ITEMDATA_QUERY = 0x920006,// ���б��ѯ
            O2JAM_ITEMDATA_QUERY_RESP = 0x928006,// ���б���Ϣ��ѯ
            O2JAM_GIFTBOX_QUERY = 0x920007,//�������в�ѯ
            O2JAM_GIFTBOX_QUERY_RESP = 0x928007,//�������в�ѯ
            O2JAM_USERGCASH_UPDATE = 0x920008,//�������G��
            O2JAM_USERGCASH_UPDATE_RESP = 0x928008,//�������G�ҵ���Ӧ
            O2JAM_CONSUME_SUM_QUERY = 0x920009,//���������Ϣ��ѯ
            O2JAM_CONSUME_SUM_QUERY_RESP = 0x928009,//���������Ϣ��ѯ
            O2JAM_GIFTBOX_CREATE_QUERY = 0x920010,//�����������d��
            O2JAM_GIFTBOX_CREATE_QUERY_RESP = 0x928010,//�����������d��
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
            CARD_USERSECURE_CLEAR = 0x900009,//������Ұ�ȫ����Ϣ
            CARD_USERSECURE_CLEAR_RESP = 0x908009,//������Ұ�ȫ����Ϣ��Ӧ


            /// <summary>
            /// ������IIGM����(0x93)
            /// </summary>
            O2JAM2_ACCOUNT_QUERY = 0x930001,//����ʺ���Ϣ��ѯ
            O2JAM2_ACCOUNT_QUERY_RESP = 0x938001,//����ʺ���Ϣ��ѯ��Ӧ
            O2JAM2_ACCOUNTACTIVE_QUERY = 0x930002,//����ʺż�����Ϣ
            O2JAM2_ACCOUNTACTIVE_QUERY_RESP = 0x938002,//����ʺż�����Ӧ

            O2JAM2_CHARACTERINFO_QUERY = 0x930003,//�û���Ϣ��ѯ
            O2JAM2_CHARACTERINFO_QUERY_RESP = 0x938003,
            O2JAM2_CHARACTERINFO_UPDATE = 0x930004,//�û���Ϣ�޸�
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

            O2JAM2_ACCOUNT_CLOSE = 0x930015,//��ͣ�ʻ���Ȩ����Ϣ
            O2JAM2_ACCOUNT_CLOSE_RESP = 0x938015,//��ͣ�ʻ���Ȩ����Ϣ��Ӧ
            O2JAM2_ACCOUNT_OPEN = 0x930016,//����ʻ���Ȩ����Ϣ
            O2JAM2_ACCOUNT_OPEN_RESP = 0x938016,//����ʻ���Ȩ����Ϣ��Ӧ
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
            /// �������� (0x94)Add by KeHuaQing 2006-09-14
            /// </summary>
            SOCCER_CHARACTERINFO_QUERY = 0x940001,//�û���Ϣ��ѯ
            SOCCER_CHARACTERINFO_QUERY_RESP = 0x948001,
            SOCCER_CHARCHECK_QUERY = 0x940002,//�û�NameCheck,SocketCheck
            SOCCER_CHARCHECK_QUERY_RESP = 0x948002,
            SOCCER_CHARITEMS_RECOVERY_QUERY = 0x940003,//�û�����
            SOCCER_CCHARITEMS_RECOVERY_QUERY_RESP = 0x948003,
            SOCCER_CHARPOINT_QUERY = 0x940004,//�û�G���޸�
            SOCCER_CHARPOINT_QUERY_RESP = 0x948004,
            SOCCER_DELETEDCHARACTERINFO_QUERY = 0x940005,//ɾ���û���ѯ
            SOCCER_DELETEDCHARACTERINFO_QUERY_RESP = 0x948005,

            SOCCER_CHARACTERSTATE_MODIFY = 0x940006,//ͣ���ɫ
            SOCCER_CHARACTERSTATE_MODIFY_RESP = 0x948006,
            SOCCER_ACCOUNTSTATE_MODIFY = 0x940007,//ͣ�����
            SOCCER_ACCOUNTSTATE_MODIFY_RESP = 0x948007,
            SOCCER_CHARACTERSTATE_QUERY = 0x940008,//ͣ���ɫ��ѯ
            SOCCER_CHARACTERSTATE_QUERY_RESP = 0x948008,
            SOCCER_ACCOUNTSTATE_QUERY = 0x940009,//ͣ����Ҳ�ѯ
            SOCCER_ACCOUNTSTATE_QUERY_RESP = 0x948009,
            SOCCER_ACCOUNTACTIVE_QUERY = 0x940010,//��Ҽ����ѯ		
            SOCCER_ACCOUNTACTIVE_QUERY_RESP = 0x948010,
            SOCCER_USERTRADE_QUERY = 0x940011,//��ҵ��߹����¼�����ͼ�¼
            SOCCER_USERTRADE_QUERY_RESP = 0x948011,

            SOCCER_ITEM_SKILL_MODIFY = 0x940012,//ɾ����ɫ���ߡ�����
            SOCCER_ITEM_SKILL_MODIFY_RESP = 0x948012,//ɾ����ɫ���ߡ�����

            SOCCER_ACCOUNT_ITEMSKILL_QUERY = 0x940013,//������ϵĵ��ߡ�����
            SOCCER_ACCOUNT_ITEMSKILL_QUER_RESPY = 0x948013,//������ϵĵ��ߡ����� 

            SOCCER_CHARINFO_MODIFY = 0x940014,//��ҽ�ɫ��Ϣ�޸�
            SOCCER_CHARINFO_MODIFY_RESPY = 0x948014,//��ҽ�ɫ��Ϣ�޸�

            SOCCER_ITEMSHOP_INSERT = 0x940015,//��������͵���
            SOCCER_ITEMSHOP_INSERT_RESPY = 0x948015,//��������͵���

            SOCCER_ITEM_SKILL_QUERY = 0x940016,//��ý�ɫ���ߡ�����
            SOCCER_ITEM_SKILL_QUERY_RESP = 0x948016,//��ý�ɫ���ߡ�����

            SOCCER_ITEM_SKILL_BLUR_QUERY = 0x940017,//��ý�ɫ���ߡ�����
            SOCCER_ITEM_SKILL_BLUR_QUERY_RESP = 0x948017,//��ý�ɫ���ߡ�����

            CARD_USERNICK_QUERY = 0x900010,
            CARD_USERNICK_QUERY_RESP = 0x908010,
            CARD_USER_QUERY = 0x900018,//�û�������Ϣ��ѯ
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
        /// Socket ��Ϣ��
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
        /// ��־����
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
