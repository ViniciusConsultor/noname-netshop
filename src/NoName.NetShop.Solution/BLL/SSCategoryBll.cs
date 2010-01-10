using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 业务逻辑类Category 的摘要说明。
	/// </summary>
	public class CategoryBll
	{
		private readonly NoName.NetShop.Solution.SSCategoryDal dal=new NoName.NetShop.Solution.SSCategoryDal();
		public CategoryBll()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SenceId,int CateId)
		{
			return dal.Exists(SenceId,CateId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Solution.SSCategoryModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Solution.SSCategoryModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SenceId,int CateId)
		{
			
			dal.Delete(SenceId,CateId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SSCategoryModel GetModel(int SenceId,int CateId)
		{
			
			return dal.GetModel(SenceId,CateId);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Solution.SSCategoryModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Solution.SSCategoryModel> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.Solution.SSCategoryModel> modelList = new List<NoName.NetShop.Solution.SSCategoryModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Solution.SSCategoryModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Solution.SSCategoryModel();
					if(dt.Rows[n]["SenceId"].ToString()!="")
					{
						model.SenceId=int.Parse(dt.Rows[n]["SenceId"].ToString());
					}
					if(dt.Rows[n]["CateId"].ToString()!="")
					{
						model.CateId=int.Parse(dt.Rows[n]["CateId"].ToString());
					}
					model.CateImage=dt.Rows[n]["CateImage"].ToString();
					model.Remark=dt.Rows[n]["Remark"].ToString();
					model.Position=dt.Rows[n]["Position"].ToString();
					if(dt.Rows[n]["IsShow"].ToString()!="")
					{
						if((dt.Rows[n]["IsShow"].ToString()=="1")||(dt.Rows[n]["IsShow"].ToString().ToLower()=="true"))
						{
						model.IsShow=true;
						}
						else
						{
							model.IsShow=false;
						}
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

