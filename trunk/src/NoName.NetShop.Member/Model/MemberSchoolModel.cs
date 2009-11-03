using System;
namespace NoName.NetShop.Member.Model
{
	/// <summary>
	/// 实体类MemberSchool 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class MemberSchool
	{
		public MemberSchool()
		{}
		#region Model
		private int _userid;
		private string _truename;
		private int? _duty;
		private string _school;
		private string _province;
		private string _city;
		private string _county;
		private string _mobile;
		private string _telephone;
		private string _fax;
		private string _email;
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
		public int? duty
		{
			set{ _duty=value;}
			get{return _duty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string school
		{
			set{ _school=value;}
			get{return _school;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string county
		{
			set{ _county=value;}
			get{return _county;}
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
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		#endregion Model

	}
}

