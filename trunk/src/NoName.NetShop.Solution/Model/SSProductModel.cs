using System;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// ʵ����Product ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����Ʒ����װ�еļ۸�
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// ��װ�и���Ʒ��Ҫ������
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		#endregion Model

	}
}

