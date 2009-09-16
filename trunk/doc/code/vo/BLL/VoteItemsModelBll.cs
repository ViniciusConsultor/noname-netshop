using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类VoteItemsModelBll 的摘要说明。
	/// </summary>
	public class VoteItemsModelBll
	{
		private readonly NoName.NetShop.DAL.VoteItemsModelDal dal=new NoName.NetShop.DAL.VoteItemsModelDal();
		public VoteItemsModelBll()
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
		public bool Exists(int ItemId)
		{
			return dal.Exists(ItemId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.VoteItemsModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.VoteItemsModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ItemId)
		{
			
			dal.Delete(ItemId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.VoteItemsModel GetModel(int ItemId)
		{
			
			return dal.GetModel(ItemId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.VoteItemsModel GetModelByCache(int ItemId)
		{
			
			string CacheKey = "VoteItemsModelModel-" + ItemId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ItemId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.VoteItemsModel)objModel;
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
		public List<NoName.NetShop.Model.VoteItemsModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.VoteItemsModel> modelList = new List<NoName.NetShop.Model.VoteItemsModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.VoteItemsModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.VoteItemsModel();
					if(ds.Tables[0].Rows[n]["VoteGroupId"].ToString()!="")
					{
						model.VoteGroupId=int.Parse(ds.Tables[0].Rows[n]["VoteGroupId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["VoteId"].ToString()!="")
					{
						model.VoteId=int.Parse(ds.Tables[0].Rows[n]["VoteId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ItemId"].ToString()!="")
					{
						model.ItemId=int.Parse(ds.Tables[0].Rows[n]["ItemId"].ToString());
					}
					model.ItemContent=ds.Tables[0].Rows[n]["ItemContent"].ToString();
					if(ds.Tables[0].Rows[n]["VoteCount"].ToString()!="")
					{
						model.VoteCount=int.Parse(ds.Tables[0].Rows[n]["VoteCount"].ToString());
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

