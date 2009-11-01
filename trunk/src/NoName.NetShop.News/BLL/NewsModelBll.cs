using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类NewsModelBll 的摘要说明。
	/// </summary>
	public class NewsModelBll
	{
		private readonly NoName.NetShop.DAL.NewsModelDal dal=new NoName.NetShop.DAL.NewsModelDal();
		public NewsModelBll()
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
		public bool Exists(int NewsId)
		{
			return dal.Exists(NewsId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.NewsModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.NewsModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int NewsId)
		{
			
			dal.Delete(NewsId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.NewsModel GetModel(int NewsId)
		{
			
			return dal.GetModel(NewsId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.NewsModel GetModelByCache(int NewsId)
		{
			
			string CacheKey = "NewsModelModel-" + NewsId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(NewsId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.NewsModel)objModel;
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
		public List<NoName.NetShop.Model.NewsModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.NewsModel> modelList = new List<NoName.NetShop.Model.NewsModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.NewsModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.NewsModel();
					if(ds.Tables[0].Rows[n]["NewsId"].ToString()!="")
					{
						model.NewsId=int.Parse(ds.Tables[0].Rows[n]["NewsId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["NewsType"].ToString()!="")
					{
						model.NewsType=int.Parse(ds.Tables[0].Rows[n]["NewsType"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
					}
					model.Title=ds.Tables[0].Rows[n]["Title"].ToString();
					model.SubTitle=ds.Tables[0].Rows[n]["SubTitle"].ToString();
					model.Brief=ds.Tables[0].Rows[n]["Brief"].ToString();
					model.Content=ds.Tables[0].Rows[n]["Content"].ToString();
					model.SmallImageUrl=ds.Tables[0].Rows[n]["SmallImageUrl"].ToString();
					model.Author=ds.Tables[0].Rows[n]["Author"].ToString();
					model.From=ds.Tables[0].Rows[n]["From"].ToString();
					model.VideoUrl=ds.Tables[0].Rows[n]["VideoUrl"].ToString();
					model.ImageUrl=ds.Tables[0].Rows[n]["ImageUrl"].ToString();
					model.ProductId=ds.Tables[0].Rows[n]["ProductId"].ToString();
					if(ds.Tables[0].Rows[n]["InsertTime"].ToString()!="")
					{
						model.InsertTime=DateTime.Parse(ds.Tables[0].Rows[n]["InsertTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ModifyTime"].ToString()!="")
					{
						model.ModifyTime=DateTime.Parse(ds.Tables[0].Rows[n]["ModifyTime"].ToString());
					}
					model.Tags=ds.Tables[0].Rows[n]["Tags"].ToString();
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

