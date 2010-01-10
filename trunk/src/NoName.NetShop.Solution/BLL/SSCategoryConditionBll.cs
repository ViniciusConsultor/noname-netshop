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
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int CateId,int SenceId,string RuleName)
		{
			return dal.Exists(CateId,SenceId,RuleName);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Solution.SSCategoryConditionModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Solution.SSCategoryConditionModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CateId,int SenceId,string RuleName)
		{
			
			dal.Delete(CateId,SenceId,RuleName);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Solution.SSCategoryConditionModel GetModel(int CateId,int SenceId,string RuleName)
		{
			
			return dal.GetModel(CateId,SenceId,RuleName);
		}


		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Solution.SSCategoryConditionModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Solution.SSCategoryConditionModel> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.Solution.SSCategoryConditionModel> modelList = new List<NoName.NetShop.Solution.SSCategoryConditionModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Solution.SSCategoryConditionModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Solution.SSCategoryConditionModel();
					if(dt.Rows[n]["CateId"].ToString()!="")
					{
						model.CateId=int.Parse(dt.Rows[n]["CateId"].ToString());
					}
					if(dt.Rows[n]["SenceId"].ToString()!="")
					{
						model.SenceId=int.Parse(dt.Rows[n]["SenceId"].ToString());
					}
					model.RuleName=dt.Rows[n]["RuleName"].ToString();
					model.RuleValue=dt.Rows[n]["RuleValue"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

