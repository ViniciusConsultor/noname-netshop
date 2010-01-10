using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// ҵ���߼���Product ��ժҪ˵����
	/// </summary>
	public class SSProductBll
	{
		private readonly NoName.NetShop.Solution.SSProductDal dal=new NoName.NetShop.Solution.SSProductDal();
		public SSProductBll()
		{}
		#region  ��Ա����


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Save(NoName.NetShop.Solution.SSProductModel model)
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
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Solution.SSProductModel GetModel(int SuiteId,int ProductId)
		{
			
			return dal.GetModel(SuiteId,ProductId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Solution.SSProductModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(strWhere);
		}
		#endregion  ��Ա����
	}
}

