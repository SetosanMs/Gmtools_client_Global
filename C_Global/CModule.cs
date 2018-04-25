using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace C_Global
{
    #region CModuleAttribute��
    /// <summary>
    /// CModuleAttribute ģ������
    /// </summary>
    /// ����ϵͳģ�������,���ô����Զ�������ĸ���

    //����ģ������ֻ�������һ��ʵ��
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CModuleAttribute : Attribute
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="strName">ģ������</param>
        /// <param name="strTips">ģ������</param>
        /// <param name="strGroup">ģ��˵��</param>
        /// <param name="strDesigner">ģ��������</param>
        public CModuleAttribute(string strName, string stClass, string strTips, string strGroup)
        {
            this.strName = strName;
            this.stClass = stClass;
            this.strTips = strTips;
            this.strGroup = strGroup;
        }

        #region ������Ϣ
        /// <summary>
        /// ģ������
        /// </summary>
        public string Name
        {
            get
            {
                return strName;
            }
        }

        public string Class
        {
            get
            {
                return stClass;
            }
        }

        /// <summary>
        /// ģ��˵��
        /// </summary>
        public string Tips
        {
            get
            {
                return strTips;
            }
        }

        /// <summary>
        /// ģ������
        /// </summary>
        public string Group
        {
            get
            {
                return strGroup;
            }
        }
        #endregion

        #region ˽�б���
        private string strName;			//ģ������
        private string stClass;			//ģ������
        private string strTips;			//ģ��˵��
        private string strGroup;		//ģ��������
        #endregion
    }
    #endregion

    #region CModuleForms��
    /// <summary>
    /// CModuleForms ģ�鴰��
    /// </summary>
    public sealed class CModuleForms
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="strClass">����</param>
        /// <param name="strGroup">����</param>
        /// <param name="strName">����</param>
        /// <param name="strPath">·��</param>
        public CModuleForms(string strClass, string strGroup, string strName, string strPath)
        {
            this.strClass = strClass;
            this.strGroup = strGroup;
            this.strName = strName;
            this.strPath = strPath;
        }

        #region �ڲ�����
        public string Path
        {
            get { return strPath; }
        }

        public string Name
        {
            get { return strName; }
        }

        public string Class
        {
            get { return strClass; }
        }

        public string Group
        {
            get { return strGroup; }
        }

        public System.Windows.Forms.Form Form
        {
            set { FrmModule = value; }
            get { return FrmModule; }
        }
        #endregion

        #region ˽�б���
        private readonly string strPath;
        private readonly string strName;
        private readonly string strClass;
        private readonly string strGroup;

        private System.Windows.Forms.Form FrmModule = null;
        #endregion
    }
    #endregion

    #region CModule��
    /// <summary>
    /// CModule ��ȡģ����Ϣ��
    /// </summary>
    public class CModule
    {
        /// <summary>
        /// ��̬����
        /// </summary>
        /// <param name="strPath">ģ��·��</param>
        /// <param name="strSuffix">ģ���׺</param>
        /// <returns>ģ���ϣ��</returns>
        public static Hashtable Module(string strPath, string strSuffix)
        {
            Hashtable hHashtable = new Hashtable();
            System.IO.DirectoryInfo dDirectory = new System.IO.DirectoryInfo(strPath);

            //ö��ָ�������ļ�
            foreach (System.IO.FileInfo file in dDirectory.GetFiles("*." + strSuffix))
            {
                System.Reflection.Assembly asmAssembly = System.Reflection.Assembly.LoadFile(file.FullName);

                //ö��ģ����Ϣ
                foreach (System.Reflection.Module mod in asmAssembly.GetModules())
                {
                    //ö��������Ϣ
                    foreach (Type t in mod.GetTypes())
                    {
                        object[] oModule = t.GetCustomAttributes(typeof(CModuleAttribute), true);

                        if (oModule.Length == 1)
                        {
                            string strModuleName = ((CModuleAttribute)oModule[0]).Name;
                            string strModuleClass = ((CModuleAttribute)oModule[0]).Class;
                            string strModuleTips = ((CModuleAttribute)oModule[0]).Tips;
                            string strModuleGroup = ((CModuleAttribute)oModule[0]).Group;

                            CModuleForms mForms = new CModuleForms(t.Name, strModuleGroup, strModuleName, file.FullName);

                            if (hHashtable.ContainsKey(strModuleName))
                            {
                                throw new Exception("ϵͳģ����ش���ģ���ظ����ػ�ģ�������ظ���");
                            }
                            else
                            {
                                hHashtable.Add(t.Name, mForms);
                            }
                        }
                    }
                }
            }

            return hHashtable;
        }
    }
    #endregion
}
