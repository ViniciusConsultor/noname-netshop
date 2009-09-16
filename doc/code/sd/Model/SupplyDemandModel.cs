using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类SupplyDemandModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SupplyDemandModel
	{
		public SupplyDemandModel()
		{}
		#region Model
		private int _sdid;
		private int? _sdtype;
		private int? _userid;
		private string _title;
		private string _content;
		private DateTime? _inserttime;
		private DateTime? _modifytime;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int sdId
		{
			set{ _sdid=value;}
			get{return _sdid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sdType
		{
			set{ _sdtype=value;}
			get{return _sdtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
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
		public DateTime? InsertTime
		{
			set{ _inserttime=value;}
			get{return _inserttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

