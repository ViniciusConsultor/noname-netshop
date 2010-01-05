using System;
using System.Collections.Generic;
namespace NoName.NetShop.Vote.Model
{
	/// <summary>
	/// 实体类VoteRemark 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class VoteRemark
	{
		public VoteRemark()
		{}
		#region Model
		private int _voteid;
		private string _userid;
		private string _remark;
		private DateTime _votetime;
		private string _voteip;
		private int _logid;
        private string _ItemIds; // 所有选中的投票
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
		public string UserId
		{
			set{ _userid=value;}
			get{return _userid;}
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
		public DateTime VoteTime
		{
			set{ _votetime=value;}
			get{return _votetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VoteIP
		{
			set{ _voteip=value;}
			get{return _voteip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LogId
		{
			set{ _logid=value;}
			get{return _logid;}
		}

        /// <summary>
        /// 选中的投票数据，格式为要求为：^(\d+,)*\d+$
        /// </summary>
        public string ItemIds
        {
            set { _ItemIds = value; }
            get { return _ItemIds; }
        }
		#endregion Model

	}
}

