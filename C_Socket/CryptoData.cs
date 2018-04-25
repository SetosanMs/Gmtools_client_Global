using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
namespace C_Socket
{
	/// <summary>
	/// CryptoData ��ժҪ˵����
	/// </summary>
	public class CryptoData
	{
		private SymmetricAlgorithm mobjCryptoService;
		private string Key;
		public CryptoData(string md5)
		{
			mobjCryptoService = new RijndaelManaged();
			Key = "Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7";
		}
		/// <summary>
		/// �����Կ
		/// </summary>
		/// <returns>��Կ</returns>
		private byte[] GetLegalKey()
		{
			string sTemp = Key;
			mobjCryptoService.GenerateKey();
			byte[] bytTemp = mobjCryptoService.Key;
			int KeyLength = bytTemp.Length;
			if (sTemp.Length > KeyLength)
				sTemp = sTemp.Substring(0, KeyLength);
			else if (sTemp.Length < KeyLength)
				sTemp = sTemp.PadRight(KeyLength, ' ');
            return Encoding.Default.GetBytes(sTemp);
		}
		/// <summary>
		/// ��ó�ʼ����IV
		/// </summary>
		/// <returns>��������IV</returns>
		private byte[] GetLegalIV()
		{
			string sTemp = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
			mobjCryptoService.GenerateIV();
			byte[] bytTemp = mobjCryptoService.IV;
			int IVLength = bytTemp.Length;
			if (sTemp.Length > IVLength)
				sTemp = sTemp.Substring(0, IVLength);
			else if (sTemp.Length < IVLength)
				sTemp = sTemp.PadRight(IVLength, ' ');
			return Encoding.Default.GetBytes(sTemp);
		}

		public byte[] Decrypto(byte[] dest)
		{
			MemoryStream ms = new MemoryStream(dest, 0, dest.Length);
			mobjCryptoService.Key = GetLegalKey();
			mobjCryptoService.IV = GetLegalIV();
			ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
			CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
			StreamReader sr = new StreamReader(cs);
			return System.Text.Encoding.Default.GetBytes(sr.ReadToEnd());
		}
		/// <summary>
		/// ���ܷ���
		/// </summary>
		/// <param name="Source">�����ܵĴ�</param>
		/// <returns>�������ܵĴ�</returns>
		public byte[] Encrypto(byte[] Source)
		{
			MemoryStream ms = new MemoryStream();
			mobjCryptoService.Key = GetLegalKey();
			mobjCryptoService.IV = GetLegalIV();
			ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
			CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
			cs.Write(Source, 0, Source.Length);
			cs.FlushFinalBlock();
			ms.Close();
			byte[] bytOut = ms.ToArray();
			return bytOut;
		}
	}
}
