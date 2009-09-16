using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.NetShop.Common
{
    /// <summary>
    /// SearchPageInfo ��ժҪ˵����
    /// ��ҳ��ѯ��Ϣ
    /// </summary>
    [Serializable]
    public class SearchPageInfo
    {
        /// <summary>
        /// ���ݱ����������������ͳ�ƶ�����������
        /// </summary>
        public string TableName;
        /// <summary>
        /// ��������������ʾ������������������ͨ����������,
        /// ���ܴ��ϱ������磺field1
        /// </summary>
        public string PriKeyName;
        /// <summary>
        /// Ҫ��ѯ���ֶ���������ѯʱҪ�� ����.�ֶ�����
        /// ����ֶ�ʱͨ��","�ָ�
        /// �磺table1.field1,table1.field2,table2.field3
        /// </summary>
        public string FieldNames;
        /// <summary>
        /// ����ͳ�Ƶ�sql���ʽ���磺sum(field1) as field1,count(field2) as field2
        /// </summary>
        public string TotalFieldStr;
        /// <summary>
        /// ÿҳ��������С��0��ʾ����ҳ��ȡ����������
        /// </summary>
        public int PageSize;
        /// <summary>
        /// ҳ��ţ���1��ʼ
        /// </summary>
        public int PageIndex;
        /// <summary>
        /// ��������,
        /// "":û������Ҫ�� 
        /// "0"���������� 
        /// "1"���������� 
        /// �ַ������û��Զ����������,ע�ⲻҪ��"order by"
        /// </summary>
        public string OrderType;
        /// <summary>
        /// ��ѯ����,ע�ⲻҪ��"where"
        /// </summary>
        public string StrWhere;
        /// <summary>
        /// ���������ַ���
        /// ע�⽨������ֻ��������ʹӱ�֮��,�ӱ�֮�䲻�ܽ�������
        /// </summary>
        public string StrJoin;
        /// <summary>
        /// ��������,���ϲ�ѯ�������ܵ���Ŀ��
        /// </summary>
        public int TotalItem;
        /// <summary>
        /// ��������,�����������ܵ�ҳ��
        /// </summary>
        public int TotalPage;
    }
}
