using System;
namespace NoName.NetShop.Member.Model
{
	/// <summary>
	/// ʵ����LoginLog ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class LoginLog
	{
		public LoginLog()
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

