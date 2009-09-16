using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类LoginLogModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class LoginLogModel
	{
		public LoginLogModel()
		{}
		#region Model
		private int _userid;
		private DateTime? _logintime;
		private string _ip;
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
		public DateTime? LoginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		#endregion Model

	}
}

