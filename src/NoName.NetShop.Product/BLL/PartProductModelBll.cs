using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// 业务逻辑类PartProductModelBll 的摘要说明。
	/// </summary>
	public class PartProductModelBll
	{
		private readonly PartProductModelDal dal=new PartProductModelDal();
		public PartProductModelBll()
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
		public bool Exists(int ProductId,int PartProductId)
		{
			return dal.Exists(ProductId,PartProductId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(PartProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(PartProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductId,int PartProductId)
		{
			
			dal.Delete(ProductId,PartProductId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PartProductModel GetModel(int ProductId,int PartProductId)
		{
			
			return dal.GetModel(ProductId,PartProductId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public PartProductModel GetModelByCache(int ProductId,int PartProductId)
        //{
			
        //    string CacheKey = "PartProductModelModel-" + ProductId+PartProductId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ProductId,PartProductId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (PartProductModel)objModel;
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
		public List<PartProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<PartProductModel> modelList = new List<PartProductModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				PartProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new PartProductModel();
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PartProductId"].ToString()!="")
					{
						model.PartProductId=int.Parse(ds.Tables[0].Rows[n]["PartProductId"].ToString());
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
         ///</summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            return dal.GetList(PageSize,PageIndex,strWhere);
        }

		#endregion  成员方法
	}
}

