using System;
namespace NoName.NetShop.Product.Model
{
	/// <summary>
	/// 实体类PartProductModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PartProductModel
	{
		public PartProductModel()
		{}
		#region Model
		private int _productid;
		private int _partproductid;
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
		public int PartProductId
		{
			set{ _partproductid=value;}
			get{return _partproductid;}
		}
		#endregion Model

	}
}

