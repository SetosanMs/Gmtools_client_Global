using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

using C_Global;

namespace C_Socket
{
	/// <summary>
	/// CSocketClient Socket �ͻ��ˡ�
	/// </summary>
	public class CSocketClient
	{
		public NetworkStream mStream = null;	//���紫��
		
		/// <summary>
		/// ���캯��
		/// </summary>
		public CSocketClient() {}

		/// <summary>
		/// Socket ��ʼ��
		/// </summary>
		/// <param name="strAddress">��������ַ</param>
		/// <param name="iPort">�������˿�</param>
		/// <returns>T���ɹ���F��ʧ��</returns>
		public bool Init(string strAddress, int iPort)
		{
			bool bConnect = false;
			
			try
			{
				this.strServerAddr = strAddress;
				this.iServerPort = iPort;
				
				mTCPClient = new TcpClient();
				mTCPClient.Connect(strAddress, iPort);
                mTCPClient.ReceiveBufferSize = 8192*20;
				mStream = mTCPClient.GetStream();

				bConnect = true;
			}
			catch (Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "�޷������ӷ�������������!";
				tLogData.strException = e.Message;	
				
				bConnect = false;
			}

			return bConnect;
		}

		/// <summary>
		/// Socket �ͷ�
		/// </summary>
		public void finallize()
		{
			mStream.Close();
			mTCPClient.Close();
		}
	
		/// <summary>
		/// Socket ״̬
		/// </summary>
		/// <returns></returns>
		public bool Status()
		{
			bool bCheckStatus = false;
			
			try
			{
				bCheckStatus = true;
			}
			catch(Exception e)
			{
				bCheckStatus = false;

                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "ʧȥ�����ӷ�����������!";
				tLogData.strException = e.Message;
			}
			return bCheckStatus;
		}

		/// <summary>
		/// ��������
		/// </summary>
		/// <returns></returns>
		public byte[] ReceiveData()
		{
            try
            {
                //����ѭ�� -- �ɶ�����ʱ�˳�
                DateTime mStarTime = DateTime.Now;
                for (; ; )
                {
                    DateTime mEndTime = DateTime.Now;

                    if ((mEndTime.Minute - mStarTime.Minute) > 4)
                    {
                        CEnum.TLogData tLogData = new CEnum.TLogData();

                        tLogData.iSort = 5;
                        tLogData.strDescribe = "����Socket���ݳ�ʱ!";
                        tLogData.strException = "N/A";

                        byte[] bContent = System.Text.Encoding.Default.GetBytes("FAILURE");
                        return bContent;
                    }

                    //��ֹ����ѭ������� CPU ռ���ʹ�������
                    Thread.Sleep(500);
                    

                    if (mStream.DataAvailable == true && mStream.CanRead)
                    {
                        byte[] bReturn = null;

                        int iLength = LengthOfReceive();
                        byte[] bContent = new byte[iLength];
                        mStream.Read(bContent, 0, iLength);

                        //�Ƕ�������
                        if (System.Text.Encoding.Default.GetString(bContent, 0, 5) != "BEGIN" && System.Text.Encoding.Default.GetString(bContent, 0, 3) != "END")
                        {
                            return bContent;
                        }
                        //��������
                        else
                        {
                            //ѭ����ȡ����
                            for (; ; )
                            {
                                try
                                {
                                    //��ȡ����									
                                    if (mStream.DataAvailable == true && mStream.CanRead)
                                    {
                                        int iLoopLength = LengthOfReceive();
                                        byte[] bLoopContent = new byte[iLoopLength];
                                        mStream.Read(bLoopContent, 0, iLoopLength);

                                        //�˳�ѭ��
                                        if (System.Text.Encoding.Default.GetString(bLoopContent, 0, 3) == "END")
                                        {
                                            string ssd = System.Text.Encoding.Default.GetString(bReturn);
                                            byte[] tt = RemoveNull(-1, bReturn);
                                            return tt;
                                        }

                                        //��֯��������
                                        bReturn = GetLongData(bLoopContent);

                                        //�˳�ѭ��
                                        if (System.Text.Encoding.Default.GetString(bReturn) == "FAILURE")
                                        {
                                            return bReturn;
                                        }

                                        //����CPUռ����
                                        Thread.Sleep(500);

                                        //������ɱ�־
                                        SendDate(System.Text.Encoding.Default.GetBytes("OK"));
                                    }
                                }
                                catch (Exception e)
                                {
                                    CEnum.TLogData tLogData = new CEnum.TLogData();

                                    tLogData.iSort = 5;
                                    tLogData.strDescribe = "���ն���Socket����ʧ��!";
                                    tLogData.strException = e.Message;

                                    byte[] bLoopContent = System.Text.Encoding.Default.GetBytes("FAILURE");
                                    return bLoopContent;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                CEnum.TLogData tLogData = new CEnum.TLogData();

                tLogData.iSort = 5;
                tLogData.strDescribe = "����Socket����ʧ��!";
                tLogData.strException = e.Message;

                byte[] bLoopContent = System.Text.Encoding.Default.GetBytes("FAILURE");
                return bLoopContent;
            }
            finally
            {
                
            }
		}

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public byte[] ReceiveData(int fileSize)
        {

            //ѭ����ȡ����
            //for (; ; )
           // {
                //��ȡ����									
                //if (mStream.DataAvailable == true && mStream.CanRead)
                //{
                    int iLoopLength = fileSize;
                    byte[] bLoopContent = new byte[iLoopLength];
                    mStream.Read(bLoopContent, 0, iLoopLength);
     
                    return bLoopContent;
                //}
            //}
        }

		/// <summary>
		/// �������ݰ�
		/// </summary>
		/// <param name="bContent"></param>
		/// <returns></returns>
		public bool SendDate(byte[] bContent)
		{
			try
			{
				mStream.Write(bContent, 0, bContent.GetLength(0));
				return true;
			}
			catch(Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "����Socket����ʧ��!";
				tLogData.strException = e.Message;
				
				return false;
			}		
		}


		#region ˽�б���
		private int iServerPort = 0;
		private string strServerAddr = null;
		private TcpClient mTCPClient;				//TCP ����
		private byte[] bLongData = null;
		private int iLoop = 0;

		/// <summary>
		/// Sockect �������ݵĳ���
		/// </summary>
		/// <returns></returns>
		private int LengthOfReceive()
		{
            return mTCPClient.ReceiveBufferSize;
		}

		private byte[] GetLongData(byte[] val)
		{			
			byte[] bReturn = null;
			
			try
			{
				//��һ�ζ�ȡ����
				if (this.bLongData == null)
				{
					this.iLoop = 0;
					this.bLongData = RemoveNull(iLoop, val);
				}
				else
				{				
					this.iLoop++;
				
					//��ʱ����
					byte[] bTempData = RemoveNull(iLoop, val);
				
					//�����ĳ���
					int iDataLength = this.bLongData.GetLength(0) + bTempData.GetLength(0);
					bReturn = new byte[iDataLength];

					//����ԭ������
					for (int i=0; i<this.bLongData.GetLength(0); i++)
					{
						bReturn[i] = this.bLongData[i];
					}

					//����������
					for (int i=0; i<bTempData.GetLength(0); i++)
					{
						bReturn[i+this.bLongData.GetLength(0)-1] = bTempData[i];
						
						if (bTempData[i] != 0)
						{
							//bReturn[i+this.bLongData.GetLength(0)-1] = RemoveNull(iLoop, false, bTempData)[i];
						}
					}

					this.bLongData = bReturn;
				}

				return this.bLongData;
			}
			catch (Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 5;
				tLogData.strDescribe = "���Socket����ʧ��!";
				tLogData.strException = e.Message;

				byte[] bLoopContent = System.Text.Encoding.Default.GetBytes("FAILURE");
				return bLoopContent;
			}
		}

		private byte[] RemoveNull(int Key, byte[] val)
		{
			int iIndexOfEnd = 0;
			byte[] bRetrun = null;
			
			for (int i=0; i<val.GetLength(0); i++)
			{
				if (val[i] == 0xEF)
				{
					iIndexOfEnd = i;
				}
			}

			try
			{	
				if (Key == 0)
				{
					bRetrun = new byte[iIndexOfEnd];
					System.Array.Copy(val, bRetrun, iIndexOfEnd);
				}
				else if (Key == -1)
				{
					bRetrun = new byte[val.GetLength(0) + 1];
					System.Array.Copy(val, bRetrun, val.GetLength(0));
					bRetrun[val.GetLength(0)] = 0xEF;
				}
				else
				{
					bRetrun = new byte[iIndexOfEnd +1];
					bRetrun[0] = 0xFD;
					bRetrun[1] = 0x01;
					System.Array.Copy(val, 1, bRetrun, 0, iIndexOfEnd -1);
				}

				return bRetrun;
			}
			catch (Exception e)
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

                tLogData.iSort = 5;
                tLogData.strDescribe = "���Socket����ʧ��!";
                tLogData.strException = e.Message;				
                
                return null;
			}
		}

		#endregion
	}
}
