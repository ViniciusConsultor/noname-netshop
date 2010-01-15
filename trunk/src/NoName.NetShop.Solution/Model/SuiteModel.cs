using System;
namespace NoName.NetShop.Solution.Model
{
	/// <summary>
	/// 实体类Suite 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SuiteModel
	{
		public SuiteModel()
		{}
		#region Model
		private int _suiteid;
		private int _scenceid;
		private string _suitename;
		private string _smallimage;
		private string _mediumimage;
		private decimal _price;
		private string _remark;
		private int _score;

        public string LargeImage { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int SuiteId
		{
			set{ _suiteid=value;}
			get{return _suiteid;}
		}
		/// <summary>
		/// 场景ID
		/// </summary>
		public int ScenceId
		{
			set{ _scenceid=value;}
			get{return _scenceid;}
		}
		/// <summary>
		/// 套装名称
		/// </summary>
		public string SuiteName
		{
			set{ _suitename=value;}
			get{return _suitename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SmallImage
		{
			set{ _smallimage=value;}
			get{return _smallimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MediumImage
		{
			set{ _mediumimage=value;}
			get{return _mediumimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 套装描述
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 套装积分
		/// </summary>
		public int Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		#endregion Model

	}
}

