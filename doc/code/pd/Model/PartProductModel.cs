using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����PartProductModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

