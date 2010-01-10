using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// ҵ���߼���Sence ��ժҪ˵����
	/// </summary>
	public class SenceBll
	{
		private readonly NoName.NetShop.Solution.SenceDal dal=new NoName.NetShop.Solution.SenceDal();
		public SenceBll()
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
		public bool Exists(int ScenceId)
		{
			return dal.Exists(ScenceId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Solution.SenceModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Solution.SenceModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ScenceId)
		{
			
			dal.Delete(ScenceId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Solution.SenceModel GetModel(int ScenceId)
		{
			
			return dal.GetModel(ScenceId);
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
		public List<NoName.NetShop.Solution.SenceModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Solution.SenceModel> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.Solution.SenceModel> modelList = new List<NoName.NetShop.Solution.SenceModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Solution.SenceModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Solution.SenceModel();
					if(dt.Rows[n]["ScenceId"].ToString()!="")
					{
						model.ScenceId=int.Parse(dt.Rows[n]["ScenceId"].ToString());
					}
					model.ScenceName=dt.Rows[n]["ScenceName"].ToString();
					model.Remark=dt.Rows[n]["Remark"].ToString();
					model.SenceImg=dt.Rows[n]["SenceImg"].ToString();
					if(dt.Rows[n]["SenceType"].ToString()!="")
					{
						model.SenceType=int.Parse(dt.Rows[n]["SenceType"].ToString());
					}
					if(dt.Rows[n]["IsActive"].ToString()!="")
					{
						if((dt.Rows[n]["IsActive"].ToString()=="1")||(dt.Rows[n]["IsActive"].ToString().ToLower()=="true"))
						{
						model.IsActive=true;
						}
						else
						{
							model.IsActive=false;
						}
					}
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

