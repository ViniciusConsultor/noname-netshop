using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����UserActionLogModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class UserActionLogModel
	{
		public UserActionLogModel()
		{}
		#region Model
		private int _userid;
		private string _actionname;
		private DateTime? _actiontime;
		private string _remark;
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
		public string ActionName
		{
			set{ _actionname=value;}
			get{return _actionname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ActionTime
		{
			set{ _actiontime=value;}
			get{return _actiontime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

