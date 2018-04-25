using System;
using System.Management;
using System.Windows.Forms;

using C_Global;
using C_Event;

namespace M_GM
{
	/// <summary>
	/// Functions ��ժҪ˵����
	/// </summary>
	public class Functions
	{
		public Functions()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ��ȡ���ػ�����mac��
		/// </summary>
		/// <returns></returns>
		public string getMac()
		{
			string mac =null;
			ManagementClass mc;
			mc=new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc=mc.GetInstances();
			foreach(ManagementObject mo in moc)
			{
				if(mo["IPEnabled"].ToString()=="True")
					mac=mo["MacAddress"].ToString();                    
			}
			return mac;
		}

		/// <summary>
		/// ���RequestResult���صĽ��
		/// </summary>
		public static void ChkServer(C_Global.CEnum.Message_Body[,] mResult)
		{
			//���״̬
			if (mResult[0,0].eName == C_Global.CEnum.TagName.ERROR_Msg)
			{
				MessageBox.Show(mResult[0,0].oContent.ToString());
				//Application.Exit();
			}
		}


	}
}
