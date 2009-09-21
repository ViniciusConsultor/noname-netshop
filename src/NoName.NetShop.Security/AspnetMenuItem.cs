using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NoName.Security
{
    public class AspnetMenuItem
    {
        public AspnetMenuItem()
		{}
		#region Model
		private int _menuid;
		private string _url;
		private string _title;
		private int _fatherid;
		private string _path;
		private int _itemtype;
		private string _description;
        private string[] _roles;
        private string _keywords;
        private int _authtype;

        /// <summary>
        /// �ؼ���
        /// </summary>
        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int MenuId
		{
		set{ _menuid=value;}
		get{return _menuid;}
		}
		/// <summary>
		/// Ϊ��ʱ����Ϊһ��չ���ýڵ㣻�����ֵ��Ϊ��Ӧ��·�����url��ַ
        /// ���е�����url�����滻Ϊ�� ~/ ��ͷ������Ӧ�ó���ĸ�·����ʼ��url
		/// </summary>
        public string Url
        {
            set {
                _url = value;
            }
            get
            {
                if (_url == "")
                    return null;
                return _url;
            }
        }

        /// <summary>
        /// �˵�����
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
		/// <summary>
		/// ��ʾ��Ϣ
		/// </summary>
		public string Title
		{
		set{ _title=value;}
		get{return _title;}
		}
		/// <summary>
		/// ��·��id�����Ϊ0��ʾΪ�����˵��ڵ�
		/// </summary>
		public int FatherId
		{
		set{ _fatherid=value;}
		get{return _fatherid;}
		}
		/// <summary>
		/// ���ڼ����õĲ˵�·������ʽΪ 1/2/3/
		/// </summary>
		public string Path
		{
		set{ _path=value;}
		get{return _path;}
		}
		/// <summary>
		/// �˵����� 0 �˵��� 1 ������
		/// </summary>
		public int ItemType
		{
            set { _itemtype = value; }
		get{return _itemtype;}
		}

        public string[] Roles
        {
            set { _roles = value; }
            get { return _roles; }
        }
        /// <summary>
        /// ��Ȩ���ͣ�
        /// </summary>
        public int AuthType
        {
            set { _authtype = value; }
            get { return _authtype; }
        }

		#endregion Model
    }
}
