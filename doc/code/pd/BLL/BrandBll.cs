using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类BrandModelBll 的摘要说明。
	/// </summary>
	public class BrandModelBll
	{
		private readonly NoName.NetShop.DAL.BrandModelDal dal=new NoName.NetShop.DAL.BrandModelDal();
		public BrandModelBll()
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
		public bool Exists(int BrandId)
		{
			return dal.Exists(BrandId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.BrandModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.BrandModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int BrandId)
		{
			
			dal.Delete(BrandId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.BrandModel GetModel(int BrandId)
		{
			
			return dal.GetModel(BrandId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.BrandModel GetModelByCache(int BrandId)
		{
			
			string CacheKey = "BrandModelModel-" + BrandId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BrandId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.BrandModel)objModel;
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
		public List<NoName.NetShop.Model.BrandModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.BrandModel> modelList = new List<NoName.NetShop.Model.BrandModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.BrandModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.BrandModel();
					if(ds.Tables[0].Rows[n]["BrandId"].ToString()!="")
					{
						model.BrandId=int.Parse(ds.Tables[0].Rows[n]["BrandId"].ToString());
					}
					model.BrandName=ds.Tables[0].Rows[n]["BrandName"].ToString();
					if(ds.Tables[0].Rows[n]["CateId"].ToString()!="")
					{
						model.CateId=int.Parse(ds.Tables[0].Rows[n]["CateId"].ToString());
					}
					model.CatePath=ds.Tables[0].Rows[n]["CatePath"].ToString();
					model.BrandLogo=ds.Tables[0].Rows[n]["BrandLogo"].ToString();
					model.Brief=ds.Tables[0].Rows[n]["Brief"].ToString();
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

