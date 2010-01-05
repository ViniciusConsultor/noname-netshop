using System;
using System.Collections.Generic;
namespace NoName.NetShop.Vote.Model
{
	/// <summary>
	/// ʵ����VoteRemark ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        private string _ItemIds; // ����ѡ�е�ͶƱ
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
        /// ѡ�е�ͶƱ���ݣ���ʽΪҪ��Ϊ��^(\d+,)*\d+$
        /// </summary>
        public string ItemIds
        {
            set { _ItemIds = value; }
            get { return _ItemIds; }
        }
		#endregion Model

	}
}

