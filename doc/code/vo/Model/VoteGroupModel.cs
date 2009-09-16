using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类VoteGroupModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class VoteGroupModel
	{
		public VoteGroupModel()
		{}
		#region Model
		private int _votegroupid;
		private int? _voteid;
		private int? _grouptype;
		private string _subject;
		private string _content;
		/// <summary>
		/// 
		/// </summary>
		public int VoteGroupId
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
		public int? GroupType
		{
			set{ _grouptype=value;}
			get{return _grouptype;}
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

