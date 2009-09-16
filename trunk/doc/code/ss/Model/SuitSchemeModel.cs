using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类SuitSchemeModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SuitSchemeModel
	{
		public SuitSchemeModel()
		{}
		#region Model
		private int _schemeid;
		private string _schemename;
		private DateTime? _createtime;
		private int? _status;
		private string _schemedesc;
		/// <summary>
		/// 
		/// </summary>
		public int SchemeId
		{
			set{ _schemeid=value;}
			get{return _schemeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SchemeName
		{
			set{ _schemename=value;}
			get{return _schemename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SchemeDesc
		{
			set{ _schemedesc=value;}
			get{return _schemedesc;}
		}
		#endregion Model

	}
}

