using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����UserInRoleModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class UserInRoleModel
	{
		public UserInRoleModel()
		{}
		#region Model
		private int _userid;
		private int _roleid;
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
		public int RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		#endregion Model

	}
}

