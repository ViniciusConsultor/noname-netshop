using System;
namespace NoName.NetShop.Product.Model
{
	/// <summary>
	/// 实体类ProductModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ProductModel
	{
		public ProductModel()
		{}

		#region Model
		private int _productid;
		private string _productname;
		private string _productcode;
		private string _catepath;
		private int _cateid;
		private decimal _tradeprice;
		private decimal _merchantprice;
		private decimal _reduceprice;
		private int _stock;
		private string _smallimage;
		private string _mediumimage;
		private string _largeimage;
		private string _keywords;
		private string _brief;
		private int _pageview;
		private DateTime _inserttime;
		private DateTime _changetime;
		private int _status;
		private int _sortvalue;
		private int _score;
        private int _brandid;
		private string _Specifications;
		private string _PackingList;
        private string _AfterSaleService;
        private string _OfferSet;
        private decimal _Weight;
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
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductCode
		{
			set{ _productcode=value;}
			get{return _productcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CatePath
		{
			set{ _catepath=value;}
			get{return _catepath;}
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
		public decimal TradePrice
		{
			set{ _tradeprice=value;}
			get{return _tradeprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal MerchantPrice
		{
			set{ _merchantprice=value;}
			get{return _merchantprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ReducePrice
		{
			set{ _reduceprice=value;}
			get{return _reduceprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Stock
		{
			set{ _stock=value;}
			get{return _stock;}
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
		public string MediumImage
		{
			set{ _mediumimage=value;}
			get{return _mediumimage;}
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
		public string Keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Brief
		{
			set{ _brief=value;}
			get{return _brief;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PageView
		{
			set{ _pageview=value;}
			get{return _pageview;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime InsertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ChangeTime
		{
			set{ _changetime=value;}
			get{return _changetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SortValue
		{
			set{ _sortvalue=value;}
			get{return _sortvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Score
		{
			set{ _score=value;}
			get{return _score;}
		}
        public int BrandID
        {
            get { return _brandid; }
            set { _brandid = value; }
        }
        public string Specifications
        {
            get { return _Specifications; }
            set { _Specifications = value; }
        }
        public string PackingList
        {
            get { return _PackingList; }
            set { _PackingList = value; }
        }
        public string AfterSaleService
        {
            get { return _AfterSaleService; }
            set { _AfterSaleService = value; }
        }
        public string OfferSet
        {
            get { return _OfferSet; }
            set { _OfferSet = value; }
        }
        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
		#endregion Model

	}

    public enum ProductStatus
    {
        上架 = 1,
        下架 = 2,
    }
}

