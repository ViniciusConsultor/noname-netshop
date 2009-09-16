using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类TagsModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class TagsModel
	{
		public TagsModel()
		{}
		#region Model
		private int _cmstagid;
		private string _cmstagname;
		private string _tagbrief;
		private string _defaultcontent;
		private string _tagtype;
		private string _tagparas;
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
		public string CmsTagName
		{
			set{ _cmstagname=value;}
			get{return _cmstagname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TagBrief
		{
			set{ _tagbrief=value;}
			get{return _tagbrief;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DefaultContent
		{
			set{ _defaultcontent=value;}
			get{return _defaultcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TagType
		{
			set{ _tagtype=value;}
			get{return _tagtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TagParas
		{
			set{ _tagparas=value;}
			get{return _tagparas;}
		}
		#endregion Model

	}
}

