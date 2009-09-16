using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类ProductExtModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ProductExtModel
	{
		public ProductExtModel()
		{}
		#region Model
		private int _productid;
		private string _productdesc;
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
		public string ProductDesc
		{
			set{ _productdesc=value;}
			get{return _productdesc;}
		}
		#endregion Model

	}
}

