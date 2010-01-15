using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;

namespace NoName.NetShop.Solution.BLL
{
	/// <summary>
	/// ҵ���߼���CategoryCondition ��ժҪ˵����
	/// </summary>
	public class CategoryConditionBll
	{
        private readonly CategoryConditionDal dal = new CategoryConditionDal();
        public CategoryConditionBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Save(CategoryConditionModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<CategoryConditionModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

        public List<CategoryConditionModel> GetModelList(int scenceId, int cateId)
        {
            return dal.GetListArray("SenceId=" + scenceId + " and cateId=" + cateId);
        }


        public DataTable GetCategoryProductList(int PageIndex, int PageSize, int CurrentCategoryID, out int RecordCount)
        {
            return dal.GetCategoryProductList(PageIndex, PageSize, CurrentCategoryID, out RecordCount);
        }
		#endregion  ��Ա����
	}
}

