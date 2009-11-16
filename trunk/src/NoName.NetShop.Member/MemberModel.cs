using System;
using NoName.NetShop.Member.Model;
namespace NoName.NetShop.Member.Model
{
	/// <summary>
	/// 实体类Member 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class MemberModel
	{
        public MemberModel()
		{}
		#region Model
		private int _userid;
		private string _useremail;
		private string _password;
		private string _nickname;
		private int _allscore;
		private int _curscore;
		private DateTime _lastlogin;
		private string _loginip;
		private DateTime _registertime;
		private MemberType _usertype;
        private MemberStatus _status;
		/// <summary>
		/// 
		/// </summary>
		public int userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserEmail
		{
			set{ _useremail=value;}
			get{return _useremail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AllScore
		{
			set{ _allscore=value;}
			get{return _allscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CurScore
		{
			set{ _curscore=value;}
			get{return _curscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LastLogin
		{
			set{ _lastlogin=value;}
			get{return _lastlogin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginIP
		{
			set{ _loginip=value;}
			get{return _loginip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RegisterTime
		{
			set{ _registertime=value;}
			get{return _registertime;}
		}

		/// <summary>
		/// 0 未设定 1 个人会员 2 家庭会员 3 学校会员 4 企业会员
		/// </summary>
        public MemberType UserType
        {
			set{ _usertype=value;}
			get{return _usertype;}
		}

        public MemberStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

		#endregion Model

	}
}

