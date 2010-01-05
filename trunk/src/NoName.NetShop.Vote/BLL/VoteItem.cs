using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Vote.Model;
namespace NoName.NetShop.Vote.BLL
{
	/// <summary>
	/// ҵ���߼���VoteItems ��ժҪ˵����
	/// </summary>
	public class VoteItem
	{
		private readonly NoName.NetShop.Vote.DAL.VoteItem dal=new NoName.NetShop.Vote.DAL.VoteItem();
		public VoteItem()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Save(NoName.NetShop.Vote.Model.VoteItem model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ItemId)
		{
			dal.Delete(ItemId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteItem GetModel(int ItemId)
		{
			
			return dal.GetModel(ItemId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Vote.Model.VoteItem> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<NoName.NetShop.Vote.Model.VoteItem> GetItemsOfGroup(int groupId)
        {
            return dal.GetListArray("ItemGroupId=" + groupId);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<NoName.NetShop.Vote.Model.VoteItem> GetItemsOfVote(int voteId)
        {
            return dal.GetListArray("voteId=" + voteId);
        }

		#endregion  ��Ա����
	}
}

