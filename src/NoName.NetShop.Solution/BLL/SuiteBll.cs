using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// ҵ���߼���Suite ��ժҪ˵����
	/// </summary>
	public class SuiteBll
	{
		private readonly NoName.NetShop.Solution.SuiteDal dal=new NoName.NetShop.Solution.SuiteDal();
		public SuiteBll()
		{}
		#region  ��Ա����

        /// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int SuiteId)
		{
			return dal.Exists(SuiteId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Save(NoName.NetShop.Solution.SuiteModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SuiteId)
		{
			
			dal.Delete(SuiteId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Solution.SuiteModel GetModel(int SuiteId)
		{
			
			return dal.GetModel(SuiteId);
		}

		#endregion  ��Ա����
	}
}

