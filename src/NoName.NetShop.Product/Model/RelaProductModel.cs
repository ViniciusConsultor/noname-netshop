using System;
namespace NoName.NetShop.Product.Model
{
	/// <summary>
	/// 实体类RelaProductModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class RelaProductModel
	{
		public RelaProductModel()
		{}
		#region Model
		private int _productid;
		private int _relaproductid;
		/// <summary>
		/// 
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RelaProductId
		{
			set{ _relaproductid=value;}
			get{return _relaproductid;}
		}
		#endregion Model

	}
}

