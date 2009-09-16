using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// 业务逻辑类SuitProductModelBll 的摘要说明。
	/// </summary>
	public class SuitProductModelBll
	{
		private readonly SuitProductModelDal dal=new SuitProductModelDal();
		public SuitProductModelBll()
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
		public bool Exists(int SuitProductId)
		{
			return dal.Exists(SuitProductId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(SuitProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SuitProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SuitProductId)
		{
			
			dal.Delete(SuitProductId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SuitProductModel GetModel(int SuitProductId)
		{
			
			return dal.GetModel(SuitProductId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public SuitProductModel GetModelByCache(int SuitProductId)
        //{
			
        //    string CacheKey = "SuitProductModelModel-" + SuitProductId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(SuitProductId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (SuitProductModel)objModel;
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
		public List<SuitProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<SuitProductModel> modelList = new List<SuitProductModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				SuitProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SuitProductModel();
					if(ds.Tables[0].Rows[n]["SuitProductId"].ToString()!="")
					{
						model.SuitProductId=int.Parse(ds.Tables[0].Rows[n]["SuitProductId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					model.SuitName=ds.Tables[0].Rows[n]["SuitName"].ToString();
					if(ds.Tables[0].Rows[n]["MerchantPrice"].ToString()!="")
					{
						model.MerchantPrice=decimal.Parse(ds.Tables[0].Rows[n]["MerchantPrice"].ToString());
					}
					if(ds.Tables[0].Rows[n]["TradePrice"].ToString()!="")
					{
						model.TradePrice=decimal.Parse(ds.Tables[0].Rows[n]["TradePrice"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
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

