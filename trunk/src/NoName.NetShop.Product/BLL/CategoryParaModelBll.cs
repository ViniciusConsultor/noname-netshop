using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// 业务逻辑类CategoryParaModelBll 的摘要说明。
	/// </summary>
	public class CategoryParaModelBll
	{
		private readonly CategoryParaModelDal dal=new CategoryParaModelDal();
		public CategoryParaModelBll()
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
		public bool Exists(int ParaId)
		{
			return dal.Exists(ParaId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CategoryParaModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CategoryParaModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ParaId)
		{
			
			dal.Delete(ParaId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CategoryParaModel GetModel(int ParaId)
		{
			
			return dal.GetModel(ParaId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public CategoryParaModel GetModelByCache(int ParaId)
        //{
			
        //    string CacheKey = "CategoryParaModelModel-" + ParaId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ParaId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (CategoryParaModel)objModel;
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
		public List<CategoryParaModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<CategoryParaModel> modelList = new List<CategoryParaModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				CategoryParaModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CategoryParaModel();
					if(ds.Tables[0].Rows[n]["ParaId"].ToString()!="")
					{
						model.ParaId=int.Parse(ds.Tables[0].Rows[n]["ParaId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CateId"].ToString()!="")
					{
						model.CateId=int.Parse(ds.Tables[0].Rows[n]["CateId"].ToString());
					}
					model.ParaName=ds.Tables[0].Rows[n]["ParaName"].ToString();
					if(ds.Tables[0].Rows[n]["ParaType"].ToString()!="")
					{
						model.ParaType=int.Parse(ds.Tables[0].Rows[n]["ParaType"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ParaGroupId"].ToString()!="")
					{
						model.ParaGroupId=int.Parse(ds.Tables[0].Rows[n]["ParaGroupId"].ToString());
					}
					model.ParaValues=ds.Tables[0].Rows[n]["ParaValues"].ToString();
					model.DefaultValue=ds.Tables[0].Rows[n]["DefaultValue"].ToString();
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

