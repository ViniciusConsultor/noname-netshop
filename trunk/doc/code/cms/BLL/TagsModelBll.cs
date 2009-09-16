using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类TagsModelBll 的摘要说明。
	/// </summary>
	public class TagsModelBll
	{
		private readonly NoName.NetShop.DAL.TagsModelDal dal=new NoName.NetShop.DAL.TagsModelDal();
		public TagsModelBll()
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
		public bool Exists(int CmsTagId)
		{
			return dal.Exists(CmsTagId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.TagsModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.TagsModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CmsTagId)
		{
			
			dal.Delete(CmsTagId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.TagsModel GetModel(int CmsTagId)
		{
			
			return dal.GetModel(CmsTagId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.TagsModel GetModelByCache(int CmsTagId)
		{
			
			string CacheKey = "TagsModelModel-" + CmsTagId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CmsTagId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.TagsModel)objModel;
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
		public List<NoName.NetShop.Model.TagsModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.TagsModel> modelList = new List<NoName.NetShop.Model.TagsModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.TagsModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.TagsModel();
					if(ds.Tables[0].Rows[n]["CmsTagId"].ToString()!="")
					{
						model.CmsTagId=int.Parse(ds.Tables[0].Rows[n]["CmsTagId"].ToString());
					}
					model.CmsTagName=ds.Tables[0].Rows[n]["CmsTagName"].ToString();
					model.TagBrief=ds.Tables[0].Rows[n]["TagBrief"].ToString();
					model.DefaultContent=ds.Tables[0].Rows[n]["DefaultContent"].ToString();
					model.TagType=ds.Tables[0].Rows[n]["TagType"].ToString();
					model.TagParas=ds.Tables[0].Rows[n]["TagParas"].ToString();
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

