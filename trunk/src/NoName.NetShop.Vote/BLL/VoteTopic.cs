using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Vote.Model;
namespace NoName.NetShop.Vote.BLL
{
	/// <summary>
	/// ҵ���߼���VoteTopic ��ժҪ˵����
	/// </summary>
	public class VoteTopic
	{
		private readonly NoName.NetShop.Vote.DAL.VoteTopic dal=new NoName.NetShop.Vote.DAL.VoteTopic();
		public VoteTopic()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Save(NoName.NetShop.Vote.Model.VoteTopic model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int VoteId)
		{
			
			dal.Delete(VoteId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteTopic GetModel(int VoteId)
		{
			
			return dal.GetModel(VoteId);
		}

		#endregion  ��Ա����
	}
}

