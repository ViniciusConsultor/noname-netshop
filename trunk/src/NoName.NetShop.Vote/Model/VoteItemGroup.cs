using System;
namespace NoName.NetShop.Vote.Model
{
	/// <summary>
	/// 实体类VoteItemGroup 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class VoteItemGroup
	{
		public VoteItemGroup()
		{}
		#region Model
		private int _itemgroupid;
		private int _voteid;
		private string _subject;
		private string _content;
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
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		#endregion Model

	}
}

