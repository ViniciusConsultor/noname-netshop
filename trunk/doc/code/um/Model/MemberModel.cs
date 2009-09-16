using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类MemberModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MemberModel
	{
		public MemberModel()
		{}
		#region Model
		private int _userid;
		private string _useremail;
		private string _password;
		private string _nickname;
		private int? _allscore;
		private int? _curscore;
		private DateTime? _lastlogin;
		private string _loginip;
		private DateTime? _registertime;
		private DateTime? _modifytime;
		/// <summary>
		/// 
		/// </summary>
		public int UserId
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
		public int? AllScore
		{
			set{ _allscore=value;}
			get{return _allscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CurScore
		{
			set{ _curscore=value;}
			get{return _curscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastLogin
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
		public DateTime? RegisterTime
		{
			set{ _registertime=value;}
			get{return _registertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		#endregion Model

	}
}

