using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// 业务逻辑类CategoryModelBll 的摘要说明。
	/// </summary>
	public class CategoryModelBll
	{
		private readonly CategoryModelDal dal=new CategoryModelDal();
		public CategoryModelBll()
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
		public bool Exists(int CateId)
		{
			return dal.Exists(CateId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CategoryModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CategoryModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CateId)
		{
			
			dal.Delete(CateId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CategoryModel GetModel(int CateId)
		{
			
			return dal.GetModel(CateId);
		}


        public string GetCategoryNamePath(int CategoryID)
        {
            return dal.GetCategoryNamePath(CategoryID);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public CategoryModel GetModelByCache(int CateId)
        //{
			
        //    string CacheKey = "CategoryModelModel-" + CateId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(CateId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (CategoryModel)objModel;
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
		public List<CategoryModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<CategoryModel> modelList = new List<CategoryModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				CategoryModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CategoryModel();
					if(ds.Tables[0].Rows[n]["CateId"].ToString()!="")
					{
						model.CateId=int.Parse(ds.Tables[0].Rows[n]["CateId"].ToString());
					}
					model.CateName=ds.Tables[0].Rows[n]["CateName"].ToString();
					model.CatePath=ds.Tables[0].Rows[n]["CatePath"].ToString();
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
					}
					model.PriceRange=ds.Tables[0].Rows[n]["PriceRange"].ToString();
					if(ds.Tables[0].Rows[n]["IsHide"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["IsHide"].ToString()=="1")||(ds.Tables[0].Rows[n]["IsHide"].ToString().ToLower()=="true"))
						{
						model.IsHide=true;
						}
						else
						{
							model.IsHide=false;
						}
					}
					if(ds.Tables[0].Rows[n]["CateLevel"].ToString()!="")
					{
						model.CateLevel=int.Parse(ds.Tables[0].Rows[n]["CateLevel"].ToString());
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

        public int SwitchOrder(int InitialCategoryID, int ReplacedCategoryID)
        {
            return dal.SwitchOrder(InitialCategoryID, ReplacedCategoryID);
        }

		#endregion  成员方法
	}
}

