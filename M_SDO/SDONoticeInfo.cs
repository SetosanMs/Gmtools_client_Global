using System;
using System.Windows.Forms;


namespace M_SDO
{
	public enum protocol:short
	{
		RET_OK = 0,
		RET_FAIL = 1,
		MONEY_GCASH = 0,
		MONEY_MCASH = 1,
		GW_BASE = 1000,
		GW_LOGIN_REQ = 1000+0,
		GW_LOGIN_ACK = 1000+1,
		GW_CHANNELLIST_REQ = 1000+2,
		GW_CHANNELLIST_ACK = 1000+3,
		EH_BASE = 10000,
		EH_ALIVE_REQ = 10000+0,
		EH_ALIVE_ACK = 10000+1,
		GM_BASE = 20000,
		GM_CHANNELLIST_REQ = 20000 + 0,
		GM_CHANNELLIST_ACK = 20000 + 1,
		GM_NOTICE_REQ = 20000 + 2,
		GM_NOTICE_ACK = 20000 + 3
	}
	/// <summary>
	/// NoticeDataInfo ��ժҪ˵����
	/// </summary>

	public class NoticeDataInfo
	{
		//������Э��

		public NoticeDataInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
	}
	public class CMsg
	{
		const int NETWORK_BUF_SIZE		=	8192;
		const int NETWORK_MSG_SIZE		=	4096;
		const int NETWORK_MSG_HEADER	=   4;
		int m_readSize = 0;
		int m_pSize = 0;
		short m_pID;
		byte[] m_pRead = new byte[NETWORK_BUF_SIZE];
		byte[] m_pWrite = new byte[NETWORK_BUF_SIZE];
		byte[] m_pBuf = new byte[NETWORK_BUF_SIZE];
		public CMsg()
		{

		}
		public CMsg(short wID)
		{
			m_pID = wID;
			m_pSize = NETWORK_MSG_HEADER;

			byte[] ret = new byte[]{
								(byte)wID,(byte)(wID>>8)
							};
			System.Array.Copy(ret,0,m_pBuf,2,ret.Length);
			//m_pBuf[2] = (byte)wID;
		    System.Array.Copy(m_pBuf,4,m_pWrite,0,NETWORK_BUF_SIZE-NETWORK_MSG_HEADER);
			System.Array.Copy(m_pBuf,4,m_pRead,0,NETWORK_BUF_SIZE-NETWORK_MSG_HEADER);
			//m_pRead = m_pWrite = m_pBuf[NETWORK_MSG_HEADER];
		}
		public void writeLength(short msglength)
		{
			byte[] ret = new byte[]{
									   (byte)msglength,(byte)(msglength>>8)
								   };
			System.Array.Copy(ret,0,m_pBuf,0,2);

		}
		public short GetSize()  
		{
			return (short)m_pSize;
		}
		public protocol	
			  ID() {return (protocol)m_pID;}

		public void Clear()
		{
			m_pBuf.Initialize();
			int ret = 0;
			for ( int i =0 ;i < ( int ) 2;i++ )
				 ret += (int)( m_pBuf[ i ] << ( i * 8 ));
			m_pSize = ret;
			uint uret = 0;
			for ( int i =0 ;i < ( int ) 2;i++ )
				uret += (uint)( m_pBuf[ i+2 ] << ( i * 8 ));
			m_pID	= (short)uret;
			m_pRead[0] = m_pWrite[0] = m_pBuf[NETWORK_MSG_HEADER];
		}
		public void WriteData(byte[] pData,int n)
		{
			if( m_pWrite.Length + n >= m_pBuf.Length + NETWORK_BUF_SIZE )
				MessageBox.Show("CMsg::ReadData > "+NETWORK_BUF_SIZE);
	
			System.Array.Copy(pData,0,m_pWrite,m_pSize,n);

			System.Array.Copy(pData,0,m_pBuf,m_pSize,n);
			m_pSize +=1;
			m_pSize += n;
		}
		public object ReadData(object pData, int n)
		{
			byte[] m_uiValue = new byte[n];
			if( m_pRead.Length + n > m_pBuf.Length + NETWORK_BUF_SIZE)
				MessageBox.Show("CMsg::ReadData >" + NETWORK_BUF_SIZE);
			if( m_pRead.Length + n > m_pBuf.Length + GetSize())
				MessageBox.Show("CMsg::ReadData > "+ GetSize());

			System.Array.Copy(m_pRead,m_readSize,m_uiValue,0,n);
			if(pData.GetType() == typeof(System.Int16) || pData.GetType() == typeof(System.Int32) )
			{
				int ret = 0;
				for ( int i =0;i < ( int ) n;i++ )
					ret += (int)( m_uiValue[ i ] << ( i * 8 ) );
				pData = ret;
			}
			else if(pData.GetType() == typeof(System.String))
			{
				int index = System.Array.IndexOf(m_uiValue,0,0,n);
				pData = System.Text.Encoding.Default.GetString(m_uiValue,0,n-1);

			}
			m_readSize += n;
			return pData;
		}
		public byte[] GetBuf()  {return m_pBuf;}
		public static uint toInteger(byte[] m_uiValue,int m_uiValueLen) 
		{
			if ( m_uiValueLen > 4 )
				return 0xffffffff;
			uint ret = 0;
			for ( int i = 0;i < ( int ) m_uiValueLen;i++ )
				ret += (uint)( m_uiValue[ i ] << ( i * 8 ) );
			return ret;
		}


	}
	
}
