using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// ʵ����AuctionLogModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class AuctionLogModel
	{
		public AuctionLogModel()
		{}


		private int? _AuctionID;
		private string _UserName;
		private DateTime? _AuctionTime;
		private decimal? _AutionPrice;
		/// <summary>
		/// 
		/// </summary>
		public int? AuctionID
		{
			set{ _AuctionID=value;}
			get{return _AuctionID;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _UserName=value;}
			get{return _UserName;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AuctionTime
		{
			set{ _AuctionTime=value;}
			get{return _AuctionTime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? AutionPrice
		{
			set{ _AutionPrice=value;}
			get{return _AutionPrice;}
		}

	}
}

