using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类UserInRoleModel 。(属性说明自动提取数据库字段的描述信息)
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

