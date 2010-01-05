using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Vote.Model;
namespace NoName.NetShop.Vote.BLL
{
	/// <summary>
	/// 业务逻辑类VoteItems 的摘要说明。
	/// </summary>
	public class VoteItem
	{
		private readonly NoName.NetShop.Vote.DAL.VoteItem dal=new NoName.NetShop.Vote.DAL.VoteItem();
		public VoteItem()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Vote.Model.VoteItem model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ItemId)
		{
			dal.Delete(ItemId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteItem GetModel(int ItemId)
		{
			
			return dal.GetModel(ItemId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Vote.Model.VoteItem> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<NoName.NetShop.Vote.Model.VoteItem> GetItemsOfGroup(int groupId)
        {
            return dal.GetListArray("ItemGroupId=" + groupId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<NoName.NetShop.Vote.Model.VoteItem> GetItemsOfVote(int voteId)
        {
            return dal.GetListArray("voteId=" + voteId);
        }

		#endregion  成员方法
	}
}

