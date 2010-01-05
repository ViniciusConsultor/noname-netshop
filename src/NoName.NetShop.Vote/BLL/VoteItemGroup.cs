using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Vote.Model;
namespace NoName.NetShop.Vote.BLL
{
	/// <summary>
	/// ҵ���߼���VoteItemGroup ��ժҪ˵����
	/// </summary>
	public class VoteItemGroup
	{
		private readonly NoName.NetShop.Vote.DAL.VoteItemGroup dal=new NoName.NetShop.Vote.DAL.VoteItemGroup();
		public VoteItemGroup()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Save(NoName.NetShop.Vote.Model.VoteItemGroup model)
		{
            dal.Save(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ItemGroupId)
		{
			dal.Delete(ItemGroupId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteItemGroup GetModel(int ItemGroupId)
		{
			
			return dal.GetModel(ItemGroupId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Vote.Model.VoteItemGroup> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<NoName.NetShop.Vote.Model.VoteItemGroup> GetModelList(int voteId)
        {
            return dal.GetListArray("voteId="+voteId);
        }
		#endregion  ��Ա����
	}
}

