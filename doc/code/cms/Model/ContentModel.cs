using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类ContentModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ContentModel
	{
		public ContentModel()
		{}
		#region Model
		private int _cmstagid;
		private string _content;
		private DateTime? _lastmodifytime;
		/// <summary>
		/// 
		/// </summary>
		public int CmsTagId
		{
			set{ _cmstagid=value;}
			get{return _cmstagid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastModifyTime
		{
			set{ _lastmodifytime=value;}
			get{return _lastmodifytime;}
		}
		#endregion Model

	}
}

