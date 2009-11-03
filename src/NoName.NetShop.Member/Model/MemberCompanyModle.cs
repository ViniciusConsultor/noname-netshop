using System;
namespace NoName.NetShop.Member.Model
{
	/// <summary>
	/// 实体类MemberCompany 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class MemberCompany
	{
		public MemberCompany()
		{}
		#region Model
		private int _userid;
		private string _truename;
		private string _idcard;
		private string _companyname;
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
		public string idcard
		{
			set{ _idcard=value;}
			get{return _idcard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string companyname
		{
			set{ _companyname=value;}
			get{return _companyname;}
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

