using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;
namespace NoName.NetShop.Solution.BLL
{
	/// <summary>
	/// ҵ���߼���Category ��ժҪ˵����
	/// </summary>
	public class SolutionCategoryBll
	{
        private readonly SolutionCategoryDal dal = new SolutionCategoryDal();
        public SolutionCategoryBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
        public void Save(SolutionCategoryModel model)
		{
			dal.Save(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SenceId,int CateId)
		{
			
			dal.Delete(SenceId,CateId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public SolutionCategoryModel GetModel(int SenceId, int CateId)
		{
			
			return dal.GetModel(SenceId,CateId);
		}

        /// <summary>
		/// ��������б�
		/// </summary>
        public List<SolutionCategoryModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

		#endregion  ��Ա����
	}
}

