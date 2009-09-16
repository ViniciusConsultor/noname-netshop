using System;
namespace NoName.NetShop.Model
{
	/// <summary>
	/// 实体类VoteRemarkModel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class VoteRemarkModel
	{
		public VoteRemarkModel()
		{}
		#region Model
		private int _voteid;
		private int _userid;
		private string _remark;
		private DateTime? _votetime;
		private string _voteip;
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
		public int UserId
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
		public DateTime? VoteTime
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
		#endregion Model

	}
}

