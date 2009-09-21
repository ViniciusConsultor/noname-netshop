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
        /// 关键词
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
		/// 为空时，仅为一个展开用节点；如果有值则为从应用路径起的url地址
        /// 所有的输入url将被替换为由 ~/ 起头，即从应用程序的根路径开始的url
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
        /// 菜单名称
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
		/// <summary>
		/// 提示信息
		/// </summary>
		public string Title
		{
		set{ _title=value;}
		get{return _title;}
		}
		/// <summary>
		/// 父路径id，如果为0表示为顶级菜单节点
		/// </summary>
		public int FatherId
		{
		set{ _fatherid=value;}
		get{return _fatherid;}
		}
		/// <summary>
		/// 便于检索用的菜单路径，格式为 1/2/3/
		/// </summary>
		public string Path
		{
		set{ _path=value;}
		get{return _path;}
		}
		/// <summary>
		/// 菜单类型 0 菜单项 1 功能项
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
        /// 授权类型：
        /// </summary>
        public int AuthType
        {
            set { _authtype = value; }
            get { return _authtype; }
        }

		#endregion Model
    }
}
