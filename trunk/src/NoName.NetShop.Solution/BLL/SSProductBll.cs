using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Solution.Model;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 业务逻辑类Product 的摘要说明。
	/// </summary>
	public class SSProductBll
	{
		private readonly NoName.NetShop.Solution.SSProductDal dal=new NoName.NetShop.Solution.SSProductDal();
		public SSProductBll()
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
		public bool Exists(int SuiteId,int ProductId)
		{
			return dal.Exists(SuiteId,ProductId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Solution.SSProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Solution.SSProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SuiteId,int ProductId)
		{
			
			dal.Delete(SuiteId,ProductId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SSProductModel GetModel(int SuiteId,int ProductId)
		{
			
			return dal.GetModel(SuiteId,ProductId);
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
		public List<NoName.NetShop.Solution.SSProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<NoName.NetShop.Solution.SSProductModel> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.Solution.SSProductModel> modelList = new List<NoName.NetShop.Solution.SSProductModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Solution.SSProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Solution.SSProductModel();
					if(dt.Rows[n]["SuiteId"].ToString()!="")
					{
						model.SuiteId=int.Parse(dt.Rows[n]["SuiteId"].ToString());
					}
					if(dt.Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(dt.Rows[n]["ProductId"].ToString());
					}
					if(dt.Rows[n]["Price"].ToString()!="")
					{
						model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
					}
					if(dt.Rows[n]["Quantity"].ToString()!="")
					{
						model.Quantity=int.Parse(dt.Rows[n]["Quantity"].ToString());
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

