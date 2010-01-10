using System;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 实体类Category 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SSCategoryModel
	{
		public SSCategoryModel()
		{}
		#region Model
		private int _senceid;
		private int _cateid;
		private string _cateimage;
		private string _remark;
		private string _position;
		private bool _isshow;
		/// <summary>
		/// 
		/// </summary>
		public int SenceId
		{
			set{ _senceid=value;}
			get{return _senceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CateId
		{
			set{ _cateid=value;}
			get{return _cateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CateImage
		{
			set{ _cateimage=value;}
			get{return _cateimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 是否显示在场景中，如果不显示，则remark、cateImage、position可以为空
		/// </summary>
		public bool IsShow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		#endregion Model

	}
}

