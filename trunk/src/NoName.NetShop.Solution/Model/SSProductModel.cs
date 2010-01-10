using System;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 实体类Product 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SSProductModel
	{
		public SSProductModel()
		{}
		#region Model
		private int _suiteid;
		private int _productid;
		private decimal _price;
		private int _quantity;
		/// <summary>
		/// 
		/// </summary>
		public int SuiteId
		{
			set{ _suiteid=value;}
			get{return _suiteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 该商品在套装中的价格
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 套装中该商品需要的数量
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		#endregion Model

	}
}

