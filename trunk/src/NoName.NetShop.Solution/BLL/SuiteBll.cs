using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;

namespace NoName.NetShop.Solution.BLL
{
	/// <summary>
	/// ҵ���߼���Suite ��ժҪ˵����
	/// </summary>
	public class SuiteBll
	{
		private readonly SuiteDal dal=new SuiteDal();
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
		public void Save(SuiteModel model)
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
		public SuiteModel GetModel(int SuiteId)
		{
			
			return dal.GetModel(SuiteId);
		}


        public DataTable GetList(int PageIndex, int PageSize, string Condition, string Order, out int RecordCount)
        {
            return dal.GetList(PageIndex, PageSize, Condition, Order, out RecordCount);
        }

		#endregion  ��Ա����
	}
}

