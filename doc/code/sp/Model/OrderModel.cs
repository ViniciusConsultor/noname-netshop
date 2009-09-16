using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类OrderModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class OrderModel
	{
		public OrderModel()
		{}
		#region Model
		private int? _userid;
		private int _orderid;
		private int? _orderstatus;
		private int? _paymethod;
		private int? _shipmethod;
		private int? _paystatus;
		private decimal? _paysum;
		private decimal? _shipfee;
		private decimal? _productfee;
		private decimal? _deratefee;
		private int? _addressid;
		private string _recievername;
		private string _recieveremail;
		private string _recieverphone;
		private string _postalcode;
		private string _recievercity;
		private string _recieverprovince;
		private string _addressdetial;
		private DateTime? _changetime;
		private DateTime? _paytime;
		private DateTime? _createtime;
		private int? _ordertype;
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
		public int OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderStatus
		{
			set{ _orderstatus=value;}
			get{return _orderstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PayMethod
		{
			set{ _paymethod=value;}
			get{return _paymethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShipMethod
		{
			set{ _shipmethod=value;}
			get{return _shipmethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PayStatus
		{
			set{ _paystatus=value;}
			get{return _paystatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Paysum
		{
			set{ _paysum=value;}
			get{return _paysum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ShipFee
		{
			set{ _shipfee=value;}
			get{return _shipfee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ProductFee
		{
			set{ _productfee=value;}
			get{return _productfee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DerateFee
		{
			set{ _deratefee=value;}
			get{return _deratefee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AddressId
		{
			set{ _addressid=value;}
			get{return _addressid;}
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
		public string RecieverEmail
		{
			set{ _recieveremail=value;}
			get{return _recieveremail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecieverPhone
		{
			set{ _recieverphone=value;}
			get{return _recieverphone;}
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
		public string RecieverCity
		{
			set{ _recievercity=value;}
			get{return _recievercity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecieverProvince
		{
			set{ _recieverprovince=value;}
			get{return _recieverprovince;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddressDetial
		{
			set{ _addressdetial=value;}
			get{return _addressdetial;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ChangeTime
		{
			set{ _changetime=value;}
			get{return _changetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PayTime
		{
			set{ _paytime=value;}
			get{return _paytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderType
		{
			set{ _ordertype=value;}
			get{return _ordertype;}
		}
		#endregion Model

	}
}

