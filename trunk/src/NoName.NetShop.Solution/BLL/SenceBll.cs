using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 业务逻辑类Sence 的摘要说明。
	/// </summary>
	public class SenceBll
	{
		private readonly NoName.NetShop.Solution.SenceDal dal=new NoName.NetShop.Solution.SenceDal();
		public SenceBll()
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
		public bool Exists(int ScenceId)
		{
			return dal.Exists(ScenceId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Solution.SenceModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Solution.SenceModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ScenceId)
		{
			
			dal.Delete(ScenceId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SenceModel GetModel(int ScenceId)
		{
			
			return dal.GetModel(ScenceId);
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
		public List<NoName.NetShop.Solution.SenceModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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

