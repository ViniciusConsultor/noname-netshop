using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����RelaProductModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

