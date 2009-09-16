using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类AuctionLogModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class AuctionLogModel
	{
		public AuctionLogModel()
		{}
		#region Model
		private int? _auctionid;
		private string _username;
		private DateTime? _auctiontime;
		private decimal? _autionprice;
		/// <summary>
		/// 
		/// </summary>
		public int? AuctionId
		{
			set{ _auctionid=value;}
			get{return _auctionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AuctionTime
		{
			set{ _auctiontime=value;}
			get{return _auctiontime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? AutionPrice
		{
			set{ _autionprice=value;}
			get{return _autionprice;}
		}
		#endregion Model

	}
}

