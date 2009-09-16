using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类FavoriteModelBll 的摘要说明。
	/// </summary>
	public class FavoriteModelBll
	{
		private readonly NoName.NetShop.DAL.FavoriteModelDal dal=new NoName.NetShop.DAL.FavoriteModelDal();
		public FavoriteModelBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.FavoriteModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.FavoriteModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.FavoriteModel GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.FavoriteModel GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "FavoriteModelModel-" ;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.FavoriteModel)objModel;
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
		public List<NoName.NetShop.Model.FavoriteModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.FavoriteModel> modelList = new List<NoName.NetShop.Model.FavoriteModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.FavoriteModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.FavoriteModel();
					if(ds.Tables[0].Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(ds.Tables[0].Rows[n]["UserId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["FavoriteId"].ToString()!="")
					{
						model.FavoriteId=int.Parse(ds.Tables[0].Rows[n]["FavoriteId"].ToString());
					}
					model.FavoriteUrl=ds.Tables[0].Rows[n]["FavoriteUrl"].ToString();
					model.FavoriteName=ds.Tables[0].Rows[n]["FavoriteName"].ToString();
					if(ds.Tables[0].Rows[n]["InsertTime"].ToString()!="")
					{
						model.InsertTime=DateTime.Parse(ds.Tables[0].Rows[n]["InsertTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ContentId"].ToString()!="")
					{
						model.ContentId=int.Parse(ds.Tables[0].Rows[n]["ContentId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ContentType"].ToString()!="")
					{
						model.ContentType=int.Parse(ds.Tables[0].Rows[n]["ContentType"].ToString());
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

