using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����UserModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class UserModel
	{
		public UserModel()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _useremail;
		private string _password;
		private DateTime? _lastlogintime;
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
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
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
		public DateTime? LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		#endregion Model

	}
}

