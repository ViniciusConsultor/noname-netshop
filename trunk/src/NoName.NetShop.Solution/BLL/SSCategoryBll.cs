using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// ҵ���߼���Category ��ժҪ˵����
	/// </summary>
	public class CategoryBll
	{
		private readonly NoName.NetShop.Solution.SSCategoryDal dal=new NoName.NetShop.Solution.SSCategoryDal();
		public CategoryBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Save(NoName.NetShop.Solution.SSCategoryModel model)
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
		public NoName.NetShop.Solution.SSCategoryModel GetModel(int SenceId,int CateId)
		{
			
			return dal.GetModel(SenceId,CateId);
		}

        /// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Solution.SSCategoryModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}

		#endregion  ��Ա����
	}
}

