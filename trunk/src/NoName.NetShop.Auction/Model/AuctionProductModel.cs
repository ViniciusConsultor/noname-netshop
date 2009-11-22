using System;
namespace NoName.NetShop.Auction.Model
{
	/// <summary>
	/// 实体类ActionProductModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class AuctionProductModel
	{
        public AuctionProductModel()
		{}

		#region Model
		private int _auctionid;
		private string _productname;
		private string _smalliamge;
		private string _mediumimage;
		private string _outlinkurl;
		private decimal _startprice;
		private decimal _addprices;
		private decimal _curprice;
		private string _brief;
		private DateTime _starttime;
		private DateTime _endtime;
		private int _status;
		/// <summary>
		/// 
		/// </summary>
		public int AuctionId
		{
			set{ _auctionid=value;}
			get{return _auctionid;}
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
		public string SmallImage
		{
			set{ _smalliamge=value;}
			get{return _smalliamge;}
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
		public string OutLinkUrl
		{
			set{ _outlinkurl=value;}
			get{return _outlinkurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal StartPrice
		{
			set{ _startprice=value;}
			get{return _startprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal AddPrices
		{
			set{ _addprices=value;}
			get{return _addprices;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CurPrice
		{
			set{ _curprice=value;}
			get{return _curprice;}
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
		public DateTime StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

