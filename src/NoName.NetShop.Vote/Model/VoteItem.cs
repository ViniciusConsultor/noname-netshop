using System;
namespace NoName.NetShop.Vote.Model
{
	/// <summary>
	/// 实体类VoteItems 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class VoteItem
	{
		public VoteItem()
		{}
		#region Model
		private int _itemgroupid;
		private int _voteid;
		private int _itemid;
		private string _itemcontent;
		private int _votecount;
        public int VoteTotalCount { get; set; }
        public int Percent
        {
            get
            {
                if (VoteTotalCount == 0)
                    return 0;
                return (VoteCount * 100) / VoteTotalCount;
            }
        }
		/// <summary>
		/// 
		/// </summary>
		public int ItemGroupId
		{
			set{ _itemgroupid=value;}
			get{return _itemgroupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int VoteId
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
		public int VoteCount
		{
			set{ _votecount=value;}
			get{return _votecount;}
		}

		#endregion Model

	}
}

