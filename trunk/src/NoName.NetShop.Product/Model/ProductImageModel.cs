using System;
namespace NoName.NetShop.Product.Model
{
	/// <summary>
	/// ʵ����ProductImageModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class ProductImageModel
	{
		public ProductImageModel()
		{}
		#region Model
		private int _imageid;
		private int _productid;
		private string _smallimage;
		private string _largeimage;
		private string _originimage;
		private string _title;
		/// <summary>
		/// 
		/// </summary>
		public int ImageId
		{
			set{ _imageid=value;}
			get{return _imageid;}
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
		public string SmallImage
		{
			set{ _smallimage=value;}
			get{return _smallimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LargeImage
		{
			set{ _largeimage=value;}
			get{return _largeimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OriginImage
		{
			set{ _originimage=value;}
			get{return _originimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		#endregion Model

	}
}

