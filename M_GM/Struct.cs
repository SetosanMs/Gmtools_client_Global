using System;

namespace M_GM
{
	#region ���û�����Ϸ����ϷȨ�ޣ��ṹ

	/// <summary>
	/// �û�
	/// </summary>
	public struct _USERACCOUNT
	{
		public string Name;			//����
		public string fullName;		//ȫ��
		public string description;	//����
		public string mac;			//��֤��
		public string pwd;			//����
		public bool mustModiPwd;	//�û��´ε�½ʱ�����������
		public bool cantModiPwd;	//�û����ܸ�������
		public bool isStop;			//�ʻ�ͣ�ñ��
		public int[,] gameRole;		//��ϷȨ�ޡ���һά�����Ϸid���ڶ�άΪ���飨int������Ÿ���Ϸ�пɲ�������Ϸ��id
	}

	/// <summary>
	/// ��Ϸ
	/// </summary>
	public struct _GAMELIST
	{
		public int gameID;		//��Ϸid
		public string Name;		//��Ϸ����
		public string description;//��Ϸ����
		
	}

	/// <summary>
	///	Ȩ��
	/// </summary>
	public struct _ROLE
	{
		public int[] userID;	//�ֿɲ�����ģ����û�id
		public int gameID;		//������Ϸid
		public int roleID;		//ģ��id
		public string roleName;	//ģ������
		public string roleClass;//ģ������
		public string roleContent;//����
	}


	#endregion

	

	

}
