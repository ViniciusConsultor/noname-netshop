using System;
namespace NoName.NetShop.UserManager.Model
{
	/// <summary>
	/// 实体类MemberPerson 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class MemberPerson
	{
		public MemberPerson()
		{}
		#region Model
		private int _userid;
		private string _truename;
		private string _idcard;
		private string _mobile;
		private string _telephone;
		private string _email;
		private int? _userlevel;
		/// <summary>
		/// 
		/// </summary>
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string truename
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IdCard
		{
			set{ _idcard=value;}
			get{return _idcard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TelePhone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserLevel
		{
			set{ _userlevel=value;}
			get{return _userlevel;}
		}
		#endregion Model

	}
}

