using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.DAL;
namespace NoName.NetShop.Solution.Bll
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
		#endregion  ��Ա����
	}
}

