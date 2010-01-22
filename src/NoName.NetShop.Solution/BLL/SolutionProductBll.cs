using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;

namespace NoName.NetShop.Solution.BLL
{
	/// <summary>
	/// ҵ���߼���Product ��ժҪ˵����
	/// </summary>
	public class SolutionProductBll
	{
        private readonly SolutionProductDal dal = new SolutionProductDal();
		public SolutionProductBll()
		{}
		#region  ��Ա����


		/// <summary>
		/// ����һ������
		/// </summary>
        public void Save(SolutionProductModel model)
		{
			dal.Save(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SuiteId,int ProductId)
		{
			
			dal.Delete(SuiteId,ProductId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public List<SolutionProductModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<SolutionProductModel> GetModelList(int suiteId)
        {
            return dal.GetListArray("suiteId=" + suiteId);
        }

        public DataTable GetList(int SuiteID)
        {
            return dal.GetList(SuiteID);
        }
		#endregion  ��Ա����
	}
}
