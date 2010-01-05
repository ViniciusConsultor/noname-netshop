using System;
namespace NoName.NetShop.Vote.Model
{
	/// <summary>
	/// 实体类VoteTopic 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class VoteTopic
	{
		public VoteTopic()
		{}
		#region Model
		private int _voteid;
		private string _topic;
		private string _remark;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private int _voteusernum;
		private bool _isreguser;
        private bool _status;
        public bool IsMulti { get; set; }

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
		public int VoteUserNum
		{
			set{ _voteusernum=value;}
			get{return _voteusernum;}
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
        /// 状态：启用或禁用，初始为禁用
        /// </summary>
        public bool Status
        {
            set { _status = value; }
            get { return _status; }
        }
		#endregion Model

	}
}

