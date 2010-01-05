using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Vote.Model;
namespace NoName.NetShop.Vote.BLL
{
	/// <summary>
	/// ҵ���߼���VoteRemark ��ժҪ˵����
	/// </summary>
	public class VoteRemark
	{
		private readonly NoName.NetShop.Vote.DAL.VoteRemark dal=new NoName.NetShop.Vote.DAL.VoteRemark();
		public VoteRemark()
		{}
		#region  ��Ա����


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Vote.Model.VoteRemark model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ɾ��һ������
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
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteRemark GetModel(int LogId)
		{
			return dal.GetModel(LogId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Vote.Model.VoteRemark> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

		#endregion  ��Ա����
	}
}

