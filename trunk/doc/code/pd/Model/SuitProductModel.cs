using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����SuitProductModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SuitProductModel
	{
		public SuitProductModel()
		{}
		#region Model
		private int _suitproductid;
		private int? _productid;
		private string _suitname;
		private decimal? _merchantprice;
		private decimal? _tradeprice;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int SuitProductId
		{
			set{ _suitproductid=value;}
			get{return _suitproductid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SuitName
		{
			set{ _suitname=value;}
			get{return _suitname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MerchantPrice
		{
			set{ _merchantprice=value;}
			get{return _merchantprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TradePrice
		{
			set{ _tradeprice=value;}
			get{return _tradeprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

