using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类VoteItemsModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class VoteItemsModel
	{
		public VoteItemsModel()
		{}
		#region Model
		private int? _votegroupid;
		private int? _voteid;
		private int _itemid;
		private string _itemcontent;
		private int? _votecount;
		/// <summary>
		/// 
		/// </summary>
		public int? VoteGroupId
		{
			set{ _votegroupid=value;}
			get{return _votegroupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VoteId
		{
			set{ _voteid=value;}
			get{return _voteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ItemId
		{
			set{ _itemid=value;}
			get{return _itemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemContent
		{
			set{ _itemcontent=value;}
			get{return _itemcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VoteCount
		{
			set{ _votecount=value;}
			get{return _votecount;}
		}
		#endregion Model

	}
}

