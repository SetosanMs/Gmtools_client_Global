using System;

using C_Global;

namespace C_Socket
{
	/// <summary>
	/// Packet_Head ��Ϣͷ��װ
	/// </summary>
	public class Packet_Head
	{
		public const uint HEAD_LENGTH = 16;

		public byte[] m_bHeadBuffer;
		public uint m_uiHeadBufferLen = HEAD_LENGTH;
		public uint m_uiSeqID;
        public CEnum.Msg_Category m_mcCategory;
        public CEnum.ServiceKey m_skServiceKey;
		public DateTime m_dtMsgDateTime;
		public uint m_uiBodyLen;
		public bool IsValidHead = false;

		public Packet_Head()
		{
		}

        public Packet_Head(uint uiSeqID, CEnum.Msg_Category mcCategory, CEnum.ServiceKey skServiceKey, uint uiBodyLen) 
		{
			this.m_uiSeqID = uiSeqID;
			this.m_mcCategory = mcCategory;
			this.m_skServiceKey = skServiceKey;
			this.m_dtMsgDateTime = System.DateTime.Now;
			this.m_uiBodyLen = uiBodyLen;

			this.IsValidHead = this.PutToBuffer();
		}
		private bool PutToBuffer()
		{
			this.m_bHeadBuffer = new byte[HEAD_LENGTH];
			// sequence id
			for ( int i = 3;i >= 0;i-- ) 
			{
				m_bHeadBuffer[ i ] = (byte) (m_uiSeqID >> ( 8 * i )) ;
			}
			// msg category
			m_bHeadBuffer[ 4 ] = ( byte ) m_mcCategory;
			// reserved
			m_bHeadBuffer[ 5 ] = 0;
			// service key
			for ( int i = 1;i >= 0;i-- ) 
			{
				m_bHeadBuffer[ 6 + i ] = ( byte ) ( ((ushort)m_skServiceKey) >> ( 8 * i ) );
			}			
			m_bHeadBuffer[ 8 ] = ( byte ) ( m_dtMsgDateTime.Year - 1900);
			m_bHeadBuffer[ 9 ] = ( byte ) ( m_dtMsgDateTime.Month );
			m_bHeadBuffer[ 10 ] = ( byte ) ( m_dtMsgDateTime.Day );
			m_bHeadBuffer[ 11 ] = ( byte ) ( m_dtMsgDateTime.Hour );
			m_bHeadBuffer[ 12 ] = ( byte ) ( m_dtMsgDateTime.Minute );
			m_bHeadBuffer[ 13 ] = ( byte ) ( m_dtMsgDateTime.Second );
			// Body len
			for ( int i = 1;i >= 0;i-- ) 
			{
				m_bHeadBuffer[ 14 + i ] = ( byte ) ( m_uiBodyLen >> ( 8 * i ) );
			}
			return true;
		}

		public Packet_Head(byte[] bHeadBuffer, uint uiHeadBufferLen )
		{
			if (bHeadBuffer == null || bHeadBuffer.Length < HEAD_LENGTH)
				return ;
			//this.m_uiHeadBufferLen = uiHeadBufferLen;
			this.m_bHeadBuffer = new byte[this.m_uiHeadBufferLen];
			System.Array.Copy(bHeadBuffer,0,m_bHeadBuffer,0,m_uiHeadBufferLen);

			this.IsValidHead = this.Init();
		}
		
		private bool Init()
		{
			if (!this.IsValidHeadBuffer())
				return false;
			if (!this.getSequenceID(ref this.m_uiSeqID))
				return false;
			if (!this.getMsgCategory(ref this.m_mcCategory))
				return false;
			if (!this.getSeriveKey(ref this.m_skServiceKey))
				return false;
			if (!this.getMsgDateTime(ref this.m_dtMsgDateTime))
				return false;
			if (!this.getPacketBodyLen(ref this.m_uiBodyLen))
				return false;
			return true;
		}
		private bool IsValidHeadBuffer()
		{
			if ( this.m_bHeadBuffer == null || this.m_bHeadBuffer.Length != HEAD_LENGTH || this.m_uiHeadBufferLen != HEAD_LENGTH)
				return false;
			return true;
		}

		private bool getSequenceID(ref uint seqid) //ByteArrayToUInt()
		{
			if (!this.IsValidHeadBuffer())
				return false;

			byte[] temp = new byte[ 4 ];
			System.Array.Copy(this.m_bHeadBuffer,0,temp,0,4);
			seqid = charArrayToInt( temp, 4 );
			return true;
		}
        private bool getMsgCategory(ref CEnum.Msg_Category mc) 
		{
			if (!this.IsValidHeadBuffer())
				return false;
			try
			{
                mc = (CEnum.Msg_Category)this.m_bHeadBuffer[4];
				return true;
			}
			catch(System.Exception)
			{
                mc = CEnum.Msg_Category.ERROR;
				return false;
			}
		}

        private bool getSeriveKey(ref CEnum.ServiceKey sk)//test(ServiceKey_FeeRequest)(temp[0] + temp[1] << 8) 
		{
			if (!this.IsValidHeadBuffer())
				return false;

			byte[] temp = new byte[ 2 ];
			System.Array.Copy(this.m_bHeadBuffer,6,temp,0,2);
			try
			{
                sk = (CEnum.ServiceKey)((ushort)temp[0] + (ushort)(temp[1] << 8));
				return true;
			}
			catch(System.Exception)
			{
                sk = CEnum.ServiceKey.ERROR;
				return false;
			}
		}

		private bool getMsgDateTime(ref DateTime dt ) 
		{
			if (!this.IsValidHeadBuffer())
				return false;

			uint year = ( uint ) this.m_bHeadBuffer[ 8 ] + 1900;
			uint month = ( uint ) this.m_bHeadBuffer[ 9 ];
			uint day = ( uint ) this.m_bHeadBuffer[ 10 ];
			uint hour = (uint)this.m_bHeadBuffer[11];
			uint minute = (uint)this.m_bHeadBuffer[12];
			uint second = (uint)this.m_bHeadBuffer[13];

			try
			{
				dt = new DateTime((int)year,(int)month,(int)day,(int)hour,(int)minute,(int)second);
				return true;
			}
			catch(System.Exception)
			{
				dt = new DateTime();
				return false;
			}			
		}

		private bool getPacketBodyLen(ref uint len) 
		{
			if (!this.IsValidHeadBuffer())
				return false;

			byte[] temp = new byte[ 2 ];
			System.Array.Copy(this.m_bHeadBuffer,14,temp,0,2);
			len = charArrayToInt( temp, 2 );
			return true;
		}

		public uint charArrayToInt( byte[] b , int size ) 
		{
			uint value = 0;
			for ( int i = 0;i < size;i++ ) 
			{
				value += (uint)(b[ i ] << ( i * 8 )) ;
			}
			return value;
		}
		
		
		public override string ToString() 
		{
			if (!this.IsValidHead)
				return "Invalid Packet Head\r\n";
			return "Sequece Id  :" + this.m_uiSeqID.ToString("X")
				+"\r\nMsg Category:" + this.m_mcCategory.ToString("X")
				+"\r\nService Key :" + this.m_skServiceKey.ToString("X")
				+"\r\nDateTime       :" + this.m_dtMsgDateTime.ToString("yyyy-MM-dd hh:mm:ss")
				+"\r\nBody Length :" + this.m_uiBodyLen.ToString("X")
				+"\r\n";
		}
		public byte[] ToByteArray()
		{
			if (this.IsValidHead)
				return this.m_bHeadBuffer;
			else
				return new byte[0];
		}

	}	
	
	/// <summary>
	/// Packet_Body ��Ϣ���װ��
	/// </summary>
	public class Packet_Body
	{
		public TLV_Structure tlv;
		public const uint MAX_TLV_NUM = 20;
        public CEnum.Body_Status m_Status = CEnum.Body_Status.MSG_STRUCT_ERROR;  //��ʾ�����Buffer��ȷ����״̬
		public byte[] m_bBodyBuffer = new byte[0];
		public uint m_uiBodyLen = 0;
		public System.Collections.ArrayList m_TLVList = new System.Collections.ArrayList();
		public uint m_uiTLVCnt = 0;
		
		public Packet_Body()
		{
		}

		public Packet_Body( byte[] body, uint body_len ) 
		{
			if (body == null ||body.Length != (int)body_len) return;
			this.m_uiBodyLen = body_len;
			this.m_bBodyBuffer = new byte[this.m_uiBodyLen];
			body.CopyTo(this.m_bBodyBuffer,0);

			this.m_Status = this.init( );
		}

        /// <summary>
        /// ��װ��Ϣʱ����TLV�ṹ�������Ϣ������
        /// </summary>
        /// <param name="tlvs">TLV�ṹ������</param>
        /// <param name="tlv_cnt">TLV�ṹ�峤��</param>
        /// <param name="colCnt">TLV�ṹ���г���</param>
        public Packet_Body(TLV_Structure[] tlvs, uint tlv_cnt, uint colCnt)
		{
			if (tlvs == null||tlvs.Length != tlv_cnt) return;
			this.m_uiTLVCnt = tlv_cnt;
			this.m_TLVList.AddRange(tlvs);
            m_uiTLVCnt = colCnt;			
			this.m_Status = this.initTLV();			
		}

        private CEnum.Body_Status init() 
		{
			this.m_uiTLVCnt = 0;
			uint curIndex = 0;
			while (findTLVStructure(ref curIndex )) 
			{
			}
			return this.initTLV();
			//			if (curIndex != this.m_uiBodyLen)
			//				return Body_Status.MSG_STRUCT_ERROR;
			//			else
			//				return Body_Status.MSG_STRUCT_OK;
		}

		private bool findTLVStructure(ref uint index ) 
		{
            if (this.m_bBodyBuffer == null || this.m_bBodyBuffer.Length < index + 4)
                return false;
            uint tlvlen = ((uint)this.m_bBodyBuffer[index + 2]) * 255 + ((uint)this.m_bBodyBuffer[index + 3]) + 4;
            if (index + tlvlen > this.m_bBodyBuffer.Length) return false;
            byte[] tlvbuf = new byte[tlvlen];
            System.Array.Copy(this.m_bBodyBuffer, index, tlvbuf, 0, tlvlen);
            TLV_Structure tlv = new TLV_Structure(tlvbuf, tlvlen);
            this.m_TLVList.Add(tlv);
            this.m_uiTLVCnt++;
            index += tlvlen;
            return true;

            //if (this.m_bBodyBuffer == null || this.m_bBodyBuffer.Length < index + TLV_Structure.MAX_TLV_HEADLENGTH)
            //    return false;
            ////ȡ���� -- λ�����ݽṹ�����λ----�޸�
            //byte[] pLengthBuffer = new byte[4];
            //pLengthBuffer[0] = this.m_bBodyBuffer[index + TLV_Structure.MAX_TLV_HEADLENGTH - 4];
            //pLengthBuffer[1] = this.m_bBodyBuffer[index + TLV_Structure.MAX_TLV_HEADLENGTH - 3];
            //pLengthBuffer[2] = this.m_bBodyBuffer[index + TLV_Structure.MAX_TLV_HEADLENGTH - 2];
            //pLengthBuffer[3] = this.m_bBodyBuffer[index + TLV_Structure.MAX_TLV_HEADLENGTH - 1];

            //uint tlvlen = BitConverter.ToUInt32(pLengthBuffer, 0) + TLV_Structure.MAX_TLV_HEADLENGTH;
            //if (index + tlvlen > this.m_bBodyBuffer.Length) return false;
            //byte[] tlvbuf = new byte[tlvlen];
            //System.Array.Copy(this.m_bBodyBuffer, index, tlvbuf, 0, tlvlen);
            //TLV_Structure tlv = new TLV_Structure(tlvbuf, tlvlen);
            //this.m_TLVList.Add(tlv);
            //this.m_uiTLVCnt++;
            //index = index + tlvlen;
            //return true;
		}

		public Packet_Body( TLV_Structure[] tlvs, uint tlv_cnt )
		{
			if (tlvs == null||tlvs.Length != tlv_cnt) return;
			this.m_uiTLVCnt = tlv_cnt;
			this.m_TLVList.AddRange(tlvs);
			
			this.m_Status = this.initTLV();			
		}

        private CEnum.Body_Status initTLV()
		{
            uint size = 0;
            System.Collections.ArrayList bal = new System.Collections.ArrayList(), lenlist = new System.Collections.ArrayList();
            for (int i = 0; i < this.m_uiTLVCnt; i++)
            {
                TLV_Structure tlv = (TLV_Structure)this.m_TLVList[i];
                if (tlv.IsValidTLV)
                {
                    size += tlv.m_uiValueLen + 4;
                    bal.Add(tlv.ToByteArray());
                    lenlist.Add(tlv.m_uiValueLen + 4);
                }
            }
            this.m_uiBodyLen = size;
            this.m_bBodyBuffer = new byte[size];
            int index = 0;
            for (int i = 0; i < bal.Count; i++)
            {
                ((byte[])bal[i]).CopyTo(m_bBodyBuffer, index);
                index += (int)((uint)lenlist[i]);
            }
            return CEnum.Body_Status.MSG_STRUCT_OK;
            //uint size = 0;
            //System.Collections.ArrayList bal = new System.Collections.ArrayList(), lenlist = new System.Collections.ArrayList();
            //for (int i = 0; i < this.m_uiTLVCnt; i++)
            //{
            //    TLV_Structure tlv = (TLV_Structure)this.m_TLVList[i];
            //    if (tlv.IsValidTLV)
            //    {
            //        size += tlv.m_uiValueLen + TLV_Structure.MAX_TLV_HEADLENGTH;
            //        bal.Add(tlv.ToByteArray());
            //        lenlist.Add(tlv.m_uiValueLen + TLV_Structure.MAX_TLV_HEADLENGTH);
            //    }
            //}
            //this.m_uiBodyLen = size;
            //this.m_bBodyBuffer = new byte[size];
            //int index = 0;
            //for (int i = 0; i < bal.Count; i++)
            //{
            //    ((byte[])bal[i]).CopyTo(m_bBodyBuffer, index);
            //    index += (int)((uint)lenlist[i]);
            //}
            //return CEnum.Body_Status.MSG_STRUCT_OK;
		}

		
		public byte[] ToByteArray()
		{
            if (this.m_Status != CEnum.Body_Status.MSG_STRUCT_OK)
				return new byte[0];
			return this.m_bBodyBuffer;
		}

		public override string ToString()
		{
            if (this.m_Status != CEnum.Body_Status.MSG_STRUCT_OK)
				return "Invalid Packet Body\r\n";
			string sOutput = null;
			for (int i = 0;i < this.m_uiTLVCnt;i++)
				sOutput += ((TLV_Structure)this.m_TLVList[i]).ToString();
			return sOutput;
		}


        public TLV_Structure getTLVByTag(CEnum.TagName tag) 
		{
			for ( int index = 0 ; index < this.m_uiTLVCnt ; index++ )
				if ( tag == ((TLV_Structure)this.m_TLVList[ index ]).m_Tag )
					return (TLV_Structure)this.m_TLVList[ index ];
			return null;
		}

		public TLV_Structure getTLVByIndex(  int index ) 
		{
			if ( index >= m_uiTLVCnt || index < 0)
				return null;
			else
				return (TLV_Structure)this.m_TLVList[ index ];
		}

		public uint BodyLength
		{
			get
			{
				return this.m_uiBodyLen;
			}
		}
		public uint TLVCount
		{
			get
			{
				return this.m_uiTLVCnt;
			}
		}
	}


	/// <summary>
	/// Packet ��Ϣ����װ��
	/// </summary>
	public class Packet
	{
		/// <summary>
		/// ��Ϣ����󳤶�
		/// </summary>		
		public int MAX_MESSAGE_SIZE = 128;
		/// <summary>
		/// �Ƿ��ǺϷ���Ϣ��
		/// </summary>
		public bool IsValidPacket = false;
		/// <summary>
		/// ��Ϣ��Byte����
		/// </summary>
		public byte[] m_PacketBuffer;
		/// <summary>
		/// ��Ϣ������
		/// </summary>
		public uint m_uiPacketLen;
		/// <summary>
		/// ��Ϣͷ
		/// </summary>
		public Packet_Head m_Head;
		/// <summary>
		/// ��Ϣ��
		/// </summary>
		public Packet_Body m_Body;		
		
		/// <summary>
		/// ���캯��
		/// </summary>
		public Packet() {}

		/// <summary>
		/// ������Ϣ��
		/// </summary>
		/// <param name="packet">��Ϣ��</param>
		/// <param name="packet_size">��Ϣ������</param>
		public Packet( byte[] packet , uint packet_size)
		{
			if (packet == null|| packet.Length < 16||packet.Length != packet_size)
				return;
			this.m_PacketBuffer = packet;
			this.m_uiPacketLen = packet_size;
			uint headlen = Packet_Head.HEAD_LENGTH,bodylen = this.m_uiPacketLen - Packet_Head.HEAD_LENGTH;
			
			byte[] head = new byte[headlen];
			System.Array.Copy(this.m_PacketBuffer,0,head,0,headlen);
			this.m_Head = new Packet_Head(head,headlen);
			
			byte[] body = new byte[bodylen];
			if (this.m_uiPacketLen > headlen)
				System.Array.Copy(this.m_PacketBuffer,headlen,body,0,bodylen);
			this.m_Body = new Packet_Body(body,bodylen);

            if (this.m_Head.IsValidHead && this.m_Body.m_Status == CEnum.Body_Status.MSG_STRUCT_OK)
				this.IsValidPacket = true;			
		}

		/// <summary>
		/// ������Ϣ��
		/// </summary>
		/// <param name="head">��Ϣͷ</param>
		/// <param name="body">��Ϣ��</param>
		public Packet( Packet_Head head , Packet_Body body ) 
		{
			this.m_Head =  head;
			this.m_Body = body;
            if (this.m_Body.m_Status != CEnum.Body_Status.MSG_STRUCT_OK || !this.m_Head.IsValidHead)
				return;
			byte[] headbuffer = this.m_Head.ToByteArray();
			byte[] bodybuffer = this.m_Body.ToByteArray();
			this.m_PacketBuffer = new byte[headbuffer.Length+bodybuffer.Length];
			headbuffer.CopyTo(this.m_PacketBuffer,0);
			bodybuffer.CopyTo(this.m_PacketBuffer,headbuffer.Length);
			this.IsValidPacket = true;
		}

		/// <summary>
		/// ת������
		/// </summary>
		/// <returns>BYTE����</returns>
		public byte[] ToByteArray() 
		{
			if (this.IsValidPacket)
				return this.m_PacketBuffer;
			else
				return new byte[0];
		}

		/// <summary>
		/// ת������
		/// </summary>
		/// <returns>�ַ���</returns>
		public override string ToString()
		{
			if (!this.IsValidPacket)
				return "Invalid Packet\r\n";
			else
				return "-------------Packet_Head----------\r\n"
					+ this.m_Head.ToString()
					+"-------------Packet_Head----------\r\n"
					+"-------------Packet_Body----------\r\n"
					+this.m_Body.ToString()
					+"-------------Packet_Body----------\r\n";
		}

	}
}
