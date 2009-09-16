using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类AddressModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class AddressModel
	{
		public AddressModel()
		{}
		#region Model
		private int? _userid;
		private int _addressid;
		private string _province;
		private string _city;
		private string _addressdetail;
		private string _recievername;
		private string _mobile;
		private string _telephone;
		private string _postalcode;
		private bool _isdefault;
		private DateTime? _inserttime;
		private DateTime? _modifytime;
		/// <summary>
		/// 
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AddressId
		{
			set{ _addressid=value;}
			get{return _addressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Province
		{
			set{ _province=value;}
			get{return _province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddressDetail
		{
			set{ _addressdetail=value;}
			get{return _addressdetail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecieverName
		{
			set{ _recievername=value;}
			get{return _recievername;}
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
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Postalcode
		{
			set{ _postalcode=value;}
			get{return _postalcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InsertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
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

