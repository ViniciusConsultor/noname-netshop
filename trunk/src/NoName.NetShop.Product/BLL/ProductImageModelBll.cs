using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// 业务逻辑类ProductImageModelBll 的摘要说明。
	/// </summary>
	public class ProductImageModelBll
	{
		private readonly ProductImageModelDal dal=new ProductImageModelDal();
		public ProductImageModelBll()
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
		public bool Exists(int ImageId)
		{
			return dal.Exists(ImageId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ProductImageModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ProductImageModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ImageId)
		{
			
			dal.Delete(ImageId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProductImageModel GetModel(int ImageId)
		{
			
			return dal.GetModel(ImageId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public ProductImageModel GetModelByCache(int ImageId)
        //{
			
        //    string CacheKey = "ProductImageModelModel-" + ImageId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ImageId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (ProductImageModel)objModel;
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
		public List<ProductImageModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ProductImageModel> modelList = new List<ProductImageModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ProductImageModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ProductImageModel();
					if(ds.Tables[0].Rows[n]["ImageId"].ToString()!="")
					{
						model.ImageId=int.Parse(ds.Tables[0].Rows[n]["ImageId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					model.SmallImage=ds.Tables[0].Rows[n]["SmallImage"].ToString();
					model.LargeImage=ds.Tables[0].Rows[n]["LargeImage"].ToString();
					model.OriginImage=ds.Tables[0].Rows[n]["OriginImage"].ToString();
					model.Title=ds.Tables[0].Rows[n]["Title"].ToString();
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


        public DataSet GetList(int ProductID)
        {
            return dal.GetList(" productid = "+ProductID);
        }


		#endregion  成员方法
	}
}

