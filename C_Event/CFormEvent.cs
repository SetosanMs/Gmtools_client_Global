using System;
using System.Reflection;
using System.Collections;
using System.ComponentModel;

using C_Global;

namespace C_Event
{
	/// <summary>
	/// CForms ����ģ�鴰�塣
	/// </summary>
	public class CFormEvent
	{
		public CFormEvent(Hashtable hApps)
		{
			this.p_Apps = hApps;
		}
		
		/// <summary>
		/// ������¼����
		/// </summary>
		/// <param name="oParent">������</param>
		/// <param name="oSender">��������</param>
		/// <param name="oEvent">Socket�¼�</param>
		/// <returns>��֤���</returns>
		public bool CallLogin(object oParent, object oSender, object oEvent)
		{
			//ִ�н��
			bool bResult = false;
			//�ж�����
			string strItem = (string)oSender;
			//ģ����ڵ�
			string strEntrance = "CreateModule";

			if( p_Apps.ContainsKey(strItem) )
			{
				CModuleForms mModuleForm = (CModuleForms)p_Apps[strItem];
				Assembly asm = Assembly.LoadFile(mModuleForm.Path);
				Type[] types = asm.GetTypes();

				foreach (Type tCheckType in types)
				{
					if (tCheckType.IsSubclassOf(typeof(System.Windows.Forms.Form)) && tCheckType.Name == strItem)
					{
						object o = Activator.CreateInstance(tCheckType);
							
						try
						{
							MethodInfo mi = tCheckType.GetMethod(strEntrance, new Type[] {typeof(object), typeof(object)});
							bResult = (bool)mi.Invoke(o,new Object[] {oParent, oEvent});
						}
						catch (Exception e)
						{
							bResult = false;

                            CEnum.TLogData tLogData = new CEnum.TLogData();
							
							tLogData.strDescribe = "����ģ����Ϣ����!";
							tLogData.strException = e.Message;
							
							//throw new Exception("����ģ����Ϣ����!");								
						}
					}
				}
			}
			else
			{
				bResult = false;

                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 2;
				tLogData.strDescribe = "δ�ҵ���Ӧģ����Ϣ!";
				tLogData.strException = "N/A";
					
				//throw new Exception("δ�ҵ���Ӧģ����Ϣ!");
			}			
			
			return bResult;
		}

		/// <summary>
		/// ����ģ�鴰�� -- Ĭ�Ϸ���
		/// </summary>
		/// <param name="oParent">������</param>
		/// <param name="oSender">������</param>
		/// ����ʾ����
		///		1��ģ�鴰������������
		///				[C_Global.CModuleAttribute("��ʾ����", "��������", "��������", "������Χ")]
		///		2����������������������ֵ��������Ҫ����˽�л򹫹����ͱ�������
		///				Hashtable m_Apps = C_Global.CModule.Module(ģ������·��,ģ����չ��);
		///		2������Ӧ�ó���ģʽ��
		///			SDIģʽ��
		///				oParent ����Ϊ NULL ���գ�
		///				oSender ����Ϊ m_Apps�����ԣ����ݺ��������ж�ѡ����Ӧ���ԣ�
		///			MDIģʽ
		///				����������˽�о�̬������private static ���������� �������� = null;
		///				���߳��д����������� �������� = new ����������();
		///				�޸�Ĭ�Ϸ��� Application.Run(��������);
		///				oParent ����Ϊ ��������
		///				oSender ����Ϊ m_Apps�����ԣ����ݺ��������ж�ѡ����Ӧ���ԣ�
		public void CallForm(object oParent, object oSender)
		{
			string strItem = (string)oSender;
			if( p_Apps.ContainsKey(strItem) )
			{
				if( ((CModuleForms)p_Apps[strItem]).Form == null )
				{
					CModuleForms mModuleForm = (CModuleForms)p_Apps[strItem];
					Assembly asm = Assembly.LoadFile(mModuleForm.Path);
					Type[] types = asm.GetTypes();

					foreach (Type tCheckType in types)
					{
						//����p_Apps���Խ����ж�
						if (tCheckType.Name == strItem)
						{
							System.Windows.Forms.Form FrmChild = (System.Windows.Forms.Form)Activator.CreateInstance(tCheckType);
							if (oParent != null)
							{
								FrmChild.MdiParent = (System.Windows.Forms.Form)oParent;
							}
							FrmChild.Name = strItem;
							FrmChild.Show();

							FrmChild.Closing += new CancelEventHandler(CloseForm);

							((CModuleForms)p_Apps[strItem]).Form = FrmChild;
						}
					}
				}
				else
				{
					((CModuleForms)p_Apps[strItem]).Form.Activate();
				}
			}
			else
			{
                CEnum.TLogData tLogData = new CEnum.TLogData();

				tLogData.iSort = 2;
				tLogData.strDescribe = "δ�ҵ���Ӧģ����Ϣ!";
				tLogData.strException = "N/A";

				//throw new Exception("δ�ҵ���Ӧģ����Ϣ!");
			}
		}

		/// <summary>
		/// ����ģ�鴰�� -- �� CSocketEvent ����
		/// </summary>
		/// <param name="oParent">������</param>
		/// <param name="oSender">������</param>
		/// <param name="oEvent">CSocketEvent ��</param>
		/// ����ʾ����
		///			ʹ�÷���ͬĬ�Ϸ�������һ�£�����Ҫ��ģ�鴰������������
		///			��������������
		///				public static Form CreateModule(object oParent, object oEvent)
		///				{
		///					ModuleFrm mModuleFrm = new ModuleFrm();
		///					mModuleFrm.m_ClientEvent = (CSocketEvent)oEvent;��ģ�鴰���������ı�����
		///					
		///					//MDIģʽ
		///					if (oParent != null)
		///					{
		///						mModuleFrm.MdiParent = (Form)oParent;
		///						mModuleFrm.Show();
		///					}
		///					//SDIģʽ
		///					else
		///					{
		///						mModuleFrm.ShowDialog();
		///					}
		///					
		///					return mModuleFrm;
		///				}
		public void CallForm(object oParent, object oSender, object oEvent)
		{
			//MDI ����
			bool bDisplay = false;
			//�ж�����
			string strItem = (string)oSender;
			//ģ����ڵ�
			string strEntrance = "CreateModule";

			//MDIģʽ
			if (oParent != null)
			{
				//��֤�Ӵ���Ψһ��
				if ( ((System.Windows.Forms.Form)oParent).MdiChildren.GetLength(0) > 0)
				{
					for (int i=0; i<((System.Windows.Forms.Form)oParent).MdiChildren.GetLength(0); i++)
					{
						if ( ((System.Windows.Forms.Form)oParent).MdiChildren[i].Name == strItem)
						{
							bDisplay = true;
							((System.Windows.Forms.Form)oParent).MdiChildren[i].Activate();
							return;
						}
						else
						{
							bDisplay = false;
						}
					}

					if (!bDisplay)
					{
						((CModuleForms)p_Apps[strItem]).Form = null;
						
						if( p_Apps.ContainsKey(strItem) )
						{
							if( ((CModuleForms)p_Apps[strItem]).Form == null )
							{
								CModuleForms mModuleForm = (CModuleForms)p_Apps[strItem];
								Assembly asm = Assembly.LoadFile(mModuleForm.Path);
								Type[] types = asm.GetTypes();

								foreach (Type tCheckType in types)
								{
									if (tCheckType.IsSubclassOf(typeof(System.Windows.Forms.Form)) && tCheckType.Name == strItem)
									{
										object o = Activator.CreateInstance(tCheckType);
							
										try
										{
											MethodInfo mi = tCheckType.GetMethod(strEntrance, new Type[] {typeof(object), typeof(object)});
											((CModuleForms)p_Apps[strItem]).Form = (System.Windows.Forms.Form)mi.Invoke(o,new Object[] {oParent, oEvent});                                            
										}
										catch (Exception e)
										{
                                            CEnum.TLogData tLogData = new CEnum.TLogData();

											tLogData.iSort = 5;
											tLogData.strDescribe = "����ģ����Ϣ����!";
											tLogData.strException = e.Message;

											//throw new Exception("����ģ����Ϣ����!");
										}
									}
								}
							}
							else
							{
								((CModuleForms)p_Apps[strItem]).Form.Activate();
							}
						}
						else
						{
                            CEnum.TLogData tLogData = new CEnum.TLogData();

							tLogData.iSort = 2;
							tLogData.strDescribe = "δ�ҵ���Ӧģ����Ϣ!";
							tLogData.strException = "N/A";				
							
							//throw new Exception("δ�ҵ���Ӧģ����Ϣ!");
						}						
					}
				}
				else
				{
					if( p_Apps.ContainsKey(strItem) )
					{
						((CModuleForms)p_Apps[strItem]).Form = null;
					
						if( ((CModuleForms)p_Apps[strItem]).Form == null )
						{
							CModuleForms mModuleForm = (CModuleForms)p_Apps[strItem];
							Assembly asm = Assembly.LoadFile(mModuleForm.Path);
							Type[] types = asm.GetTypes();

							foreach (Type tCheckType in types)
							{
								if (tCheckType.IsSubclassOf(typeof(System.Windows.Forms.Form)) && tCheckType.Name == strItem)
								{
									object o = Activator.CreateInstance(tCheckType);
							
									try
									{
										MethodInfo mi = tCheckType.GetMethod(strEntrance, new Type[] {typeof(object), typeof(object)});
										((CModuleForms)p_Apps[strItem]).Form = (System.Windows.Forms.Form)mi.Invoke(o,new Object[] {oParent, oEvent});
									}
									catch (Exception e)
									{
                                        CEnum.TLogData tLogData = new CEnum.TLogData();

										tLogData.iSort = 5;
										tLogData.strDescribe = "����ģ����Ϣ����!";
										tLogData.strException = e.Message;

										//throw new Exception("����ģ����Ϣ����!");									
									}
								}
							}
						}
						else
						{
							((CModuleForms)p_Apps[strItem]).Form.Activate();
						}
					}
					else
					{
                        CEnum.TLogData tLogData = new CEnum.TLogData();

						tLogData.iSort = 2;
						tLogData.strDescribe = "δ�ҵ���Ӧģ����Ϣ!";
						tLogData.strException = "N/A";

						//throw new Exception("δ�ҵ���Ӧģ����Ϣ!");
					}				
				}
			}
			//SDIģʽ
			else
			{
				if( p_Apps.ContainsKey(strItem) )
				{
					((CModuleForms)p_Apps[strItem]).Form = null;
					
					if( ((CModuleForms)p_Apps[strItem]).Form == null )
					{
						CModuleForms mModuleForm = (CModuleForms)p_Apps[strItem];
						Assembly asm = Assembly.LoadFile(mModuleForm.Path);
						Type[] types = asm.GetTypes();

						foreach (Type tCheckType in types)
						{
							if (tCheckType.IsSubclassOf(typeof(System.Windows.Forms.Form)) && tCheckType.Name == strItem)
							{
								object o = Activator.CreateInstance(tCheckType);
							
								try
								{
									MethodInfo mi = tCheckType.GetMethod(strEntrance, new Type[] {typeof(object), typeof(object)});
									((CModuleForms)p_Apps[strItem]).Form = (System.Windows.Forms.Form)mi.Invoke(o,new Object[] {oParent, oEvent});
								}
								catch (Exception e)
								{
                                    CEnum.TLogData tLogData = new CEnum.TLogData();

									tLogData.iSort = 5;
									tLogData.strDescribe = "����ģ����Ϣ����!";
									tLogData.strException = e.Message;

									//throw new Exception("����ģ����Ϣ����!");								
								}
							}
						}
					}
					else
					{
						((CModuleForms)p_Apps[strItem]).Form.Activate();
					}
				}
				else
				{
                    CEnum.TLogData tLogData = new CEnum.TLogData();

					tLogData.iSort = 2;
					tLogData.strDescribe = "δ�ҵ���Ӧģ����Ϣ!";
					tLogData.strException = "N/A";
					
					//throw new Exception("δ�ҵ���Ӧģ����Ϣ!");
				}
			}
		}


		/// <summary>
		/// ��ȡģ������
		/// </summary>
		/// <param name="Index">����</param>
		/// <param name="Key">��ֵ</param>
		/// <param name="MenuBody">�˵�����</param>
		/// <returns>����</returns>
        public string GetModuleClass(int Index, string Key, CEnum.Message_Body[,] MenuBody)
		{
			string strClass = null;

			for (int i=0; i<MenuBody.GetLength(0); i++)
			{
				for (int j=0; j<MenuBody.GetLength(1); j++)
				{
					if (MenuBody[i, j].oContent.Equals(Key))
					{
						strClass = MenuBody[i, Index].oContent.ToString();
						break;
					}				
				}
			}

			return strClass;
		}

		#region ˽�б���
		private Hashtable p_Apps;

		private void CloseForm(object sender, CancelEventArgs e)
		{
			string strName = ((System.Windows.Forms.Form)sender).Name;

			if( p_Apps.ContainsKey(strName) )
			{
				((CModuleForms)p_Apps[strName]).Form = null;
			}
		}
		#endregion
	}
}
