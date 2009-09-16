using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// 业务逻辑类RelaProductModelBll 的摘要说明。
	/// </summary>
	public class RelaProductModelBll
	{
		private readonly RelaProductModelDal dal=new RelaProductModelDal();
		public RelaProductModelBll()
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
		public bool Exists(int ProductId,int RelaProductId)
		{
			return dal.Exists(ProductId,RelaProductId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(RelaProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(RelaProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductId,int RelaProductId)
		{
			
			dal.Delete(ProductId,RelaProductId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RelaProductModel GetModel(int ProductId,int RelaProductId)
		{
			
			return dal.GetModel(ProductId,RelaProductId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public RelaProductModel GetModelByCache(int ProductId, int RelaProductId)
        //{

        //    string CacheKey = "RelaProductModelModel-" + ProductId + RelaProductId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ProductId, RelaProductId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (RelaProductModel)objModel;
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
		public List<RelaProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<RelaProductModel> modelList = new List<RelaProductModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				RelaProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RelaProductModel();
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["RelaProductId"].ToString()!="")
					{
						model.RelaProductId=int.Parse(ds.Tables[0].Rows[n]["RelaProductId"].ToString());
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

