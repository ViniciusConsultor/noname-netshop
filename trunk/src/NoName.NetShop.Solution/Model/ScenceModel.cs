using System;

namespace NoName.NetShop.Solution.Model
{
	/// <summary>
	/// 实体类Sence 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ScenceModel
	{
		public ScenceModel()
		{}
		#region Model
		private int _scenceid;
		private string _scencename;
		private string _remark;
		private string _senceimg;
		private int _sencetype;
		private bool _isactive;
		/// <summary>
		/// 
		/// </summary>
		public int ScenceId
		{
			set{ _scenceid=value;}
			get{return _scenceid;}
		}
		/// <summary>
		/// 场景名称
		/// </summary>
		public string ScenceName
		{
			set{ _scencename=value;}
			get{return _scencename;}
		}
		/// <summary>
		/// 场景描述
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 场景图片
		/// </summary>
		public string SenceImg
		{
			set{ _senceimg=value;}
			get{return _senceimg;}
		}
		/// <summary>
		/// 场景类型：0 推荐 1 经典 2 共用
		/// </summary>
		public int SenceType
		{
			set{ _sencetype=value;}
			get{return _sencetype;}
		}
		/// <summary>
		/// 是否激活
		/// </summary>
		public bool IsActive
		{
			set{ _isactive=value;}
			get{return _isactive;}
		}
		#endregion Model

	}
}

