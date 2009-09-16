using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类OrderItemModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class OrderItemModel
	{
		public OrderItemModel()
		{}
		#region Model
		private int? _orderid;
		private int _orderitem;
		private int? _productid;
		private decimal? _productfee;
		private int? _quantity;
		private decimal? _deratefee;
		private decimal? _merchantprice;
		private decimal? _totalfee;
		/// <summary>
		/// 
		/// </summary>
		public int? OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderItem
		{
			set{ _orderitem=value;}
			get{return _orderitem;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
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
		public int? Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
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
		public decimal? MerchantPrice
		{
			set{ _merchantprice=value;}
			get{return _merchantprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalFee
		{
			set{ _totalfee=value;}
			get{return _totalfee;}
		}
		#endregion Model

	}
}

