using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类VoteTopicModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class VoteTopicModel
	{
		public VoteTopicModel()
		{}
		#region Model
		private int _voteid;
		private int _contentid;
		private int _contenttype;
		private string _topic;
		private string _remark;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private bool _isreguser;
		private int? _voteusernum;
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
		public int ContentId
		{
			set{ _contentid=value;}
			get{return _contentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ContentType
		{
			set{ _contenttype=value;}
			get{return _contenttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Topic
		{
			set{ _topic=value;}
			get{return _topic;}
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
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsRegUser
		{
			set{ _isreguser=value;}
			get{return _isreguser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VoteUserNum
		{
			set{ _voteusernum=value;}
			get{return _voteusernum;}
		}
		#endregion Model

	}
}

