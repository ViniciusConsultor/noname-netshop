using System;
namespace NoName.NetShop.Product.Model
{
	/// <summary>
	/// ʵ����ProductExtModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

