using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Strategy
{
    public enum BetweennessValue
    {
        SUCESS,
        FAILURE
    }

    public class Betweenness
    {
        /// <summary>
        /// ��������������
        /// ���ڿ����Ƿ�Ҫˢ��datagrid�ؼ����б�
        /// </summary>
        private BetweennessValue _result = BetweennessValue.FAILURE;

        /// <summary>
        /// ������ʱֵ
        /// ���ڴ�������ø�����ĸ�����
        /// </summary>
        private int _tempValue = 0;

        /// <summary>
        /// hashtable����ʱ����
        /// </summary>
        private Hashtable _htTempValue = new Hashtable();


        public BetweennessValue RESULT
        {
            set
            {
                _result = value;
            }
            get
            {
                return _result;
            }
        }

        public int TEMPVALUE
        {
            set
            {
                _tempValue = value;
            }
            get
            {
                return _tempValue;
            }
        }

        public Hashtable HASHTABLE
        {
            set
            {
                _htTempValue = value;
            }
            get
            {
                return _htTempValue;
            }
        }
    }
}
