using System;
namespace NoName.NetShop.Product.Model
{
	/// <summary>
	/// ʵ����SalesProductModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SalesProductModel
	{
		public SalesProductModel()
		{}
		#region Model
		private int _productid;
		private int _saletype;
		private int _siteid;
        private DateTime _TimeStamp;
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
		public int SaleType
		{
			set{ _saletype=value;}
			get{return _saletype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SiteId
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}

        public DateTime TimeStamp
        {
            get { return _TimeStamp; }
            set { _TimeStamp = value; }
        }
		#endregion Model

	}
}

