using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// ҵ���߼���CategoryCondition ��ժҪ˵����
	/// </summary>
	public class SSCategoryConditionBll
	{
		private readonly NoName.NetShop.Solution.CategoryCondition dal=new NoName.NetShop.Solution.CategoryCondition();
		public SSCategoryConditionBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Save(NoName.NetShop.Solution.SSCategoryConditionModel model)
		{
			dal.Save(model);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Solution.SSCategoryConditionModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}
		#endregion  ��Ա����
	}
}

