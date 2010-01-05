using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Vote.Model;
namespace NoName.NetShop.Vote.BLL
{
	/// <summary>
	/// 业务逻辑类VoteTopic 的摘要说明。
	/// </summary>
	public class VoteTopic
	{
		private readonly NoName.NetShop.Vote.DAL.VoteTopic dal=new NoName.NetShop.Vote.DAL.VoteTopic();
		public VoteTopic()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Vote.Model.VoteTopic model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int VoteId)
		{
			
			dal.Delete(VoteId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteTopic GetModel(int VoteId)
		{
			
			return dal.GetModel(VoteId);
		}

		#endregion  成员方法
	}
}

