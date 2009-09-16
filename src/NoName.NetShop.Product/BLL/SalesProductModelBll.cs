using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// 业务逻辑类SalesProductModelBll 的摘要说明。
	/// </summary>
	public class SalesProductModelBll
	{
		private readonly SalesProductModelDal dal=new SalesProductModelDal();
		public SalesProductModelBll()
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
		public bool Exists(int ProductId,int SaleType,int SiteId)
		{
			return dal.Exists(ProductId,SaleType,SiteId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(SalesProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SalesProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductId,int SaleType,int SiteId)
		{
			
			dal.Delete(ProductId,SaleType,SiteId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SalesProductModel GetModel(int ProductId,int SaleType,int SiteId)
		{
			
			return dal.GetModel(ProductId,SaleType,SiteId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public SalesProductModel GetModelByCache(int ProductId,int SaleType,int SiteId)
        //{
			
        //    string CacheKey = "SalesProductModelModel-" + ProductId+SaleType+SiteId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ProductId,SaleType,SiteId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (SalesProductModel)objModel;
        //}

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
		public List<SalesProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<SalesProductModel> modelList = new List<SalesProductModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				SalesProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SalesProductModel();
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SaleType"].ToString()!="")
					{
						model.SaleType=int.Parse(ds.Tables[0].Rows[n]["SaleType"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SiteId"].ToString()!="")
					{
						model.SiteId=int.Parse(ds.Tables[0].Rows[n]["SiteId"].ToString());
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

		#endregion  成员方法
	}
}

