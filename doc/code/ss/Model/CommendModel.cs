using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类CommendModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class CommendModel
	{
		public CommendModel()
		{}
		#region Model
		private int _schemeid;
		private int _cateid;
		private int _productid;
		private int? _quantity;
		/// <summary>
		/// 
		/// </summary>
		public int SchemeId
		{
			set{ _schemeid=value;}
			get{return _schemeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CateId
		{
			set{ _cateid=value;}
			get{return _cateid;}
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
		/// 
		/// </summary>
		public int? Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		#endregion Model

	}
}

