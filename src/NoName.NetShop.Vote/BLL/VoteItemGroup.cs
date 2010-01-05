using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Vote.Model;
namespace NoName.NetShop.Vote.BLL
{
	/// <summary>
	/// 业务逻辑类VoteItemGroup 的摘要说明。
	/// </summary>
	public class VoteItemGroup
	{
		private readonly NoName.NetShop.Vote.DAL.VoteItemGroup dal=new NoName.NetShop.Vote.DAL.VoteItemGroup();
		public VoteItemGroup()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Vote.Model.VoteItemGroup model)
		{
            dal.Save(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ItemGroupId)
		{
			dal.Delete(ItemGroupId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteItemGroup GetModel(int ItemGroupId)
		{
			
			return dal.GetModel(ItemGroupId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Vote.Model.VoteItemGroup> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<NoName.NetShop.Vote.Model.VoteItemGroup> GetModelList(int voteId)
        {
            return dal.GetListArray("voteId="+voteId);
        }
		#endregion  成员方法
	}
}

