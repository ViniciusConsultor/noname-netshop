using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Vote.Model;
namespace NoName.NetShop.Vote.BLL
{
	/// <summary>
	/// 业务逻辑类VoteRemark 的摘要说明。
	/// </summary>
	public class VoteRemark
	{
		private readonly NoName.NetShop.Vote.DAL.VoteRemark dal=new NoName.NetShop.Vote.DAL.VoteRemark();
		public VoteRemark()
		{}
		#region  成员方法


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Vote.Model.VoteRemark model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int LogId)
		{
			
			dal.Delete(LogId);
		}

        public bool Validate(int voteId, string userId, string voteIp)
        {
            return dal.Validate(voteId, userId, voteIp);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteRemark GetModel(int LogId)
		{
			return dal.GetModel(LogId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Vote.Model.VoteRemark> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

		#endregion  成员方法
	}
}

