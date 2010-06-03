using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.GroupShopping.Model
{
    public class GroupProductModel
    {
        public GroupProductModel()
		{}

		#region Model

		private int _productid;
		private string _productname;
		private string _productcode;
		private decimal _groupprice;
		private decimal _prepaidprice;
        private decimal _marketprice;
		private string _smallimage;
		private string _mediumimage;
		private string _largeimage;
		private string _detail;
		private string _description;
		private DateTime _inserttime;
		private DateTime _changetime;
		private int _status;
		private int _producttype;
        private int _succedline;
        private bool _isrecommend;
		/// <summary>
		/// 
		/// </summary>
		public int ProductID
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
        public decimal MarketPrice
        {
            set { _marketprice = value; }
            get { return _marketprice; }
        }
		/// <summary>
		/// 
		/// </summary>
		public decimal GroupPrice
		{
			set{ _groupprice=value;}
			get{return _groupprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal PrePaidPrice
		{
			set{ _prepaidprice=value;}
			get{return _prepaidprice;}
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
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
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
		public int ProductType
		{
			set{ _producttype=value;}
			get{return _producttype;}
		}

        public int SuccedLine
        {
            set { _succedline = value; }
            get { return _succedline; }
        }

        public bool IsRecommend
        {
            get { return _isrecommend; }
            set { _isrecommend = value; }
        }

		#endregion Model

	}

    public enum GroupShoppingProductType
    {
        普通商品 = 1,
        解决方案 = 2
    }

    public enum GroupShoppingProductStatus
    {
        冻结=1,
        正在团购 = 2,
        团购成功 = 3,
        团购结束 = 4
    }
}