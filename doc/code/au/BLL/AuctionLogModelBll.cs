using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类AuctionLogModelBll 的摘要说明。
	/// </summary>
	public class AuctionLogModelBll
	{
		private readonly NoName.NetShop.DAL.AuctionLogModelDal dal=new NoName.NetShop.DAL.AuctionLogModelDal();
		public AuctionLogModelBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.AuctionLogModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.AuctionLogModel model)
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
		public NoName.NetShop.Model.AuctionLogModel GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.AuctionLogModel GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "AuctionLogModelModel-" ;
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
			return (NoName.NetShop.Model.AuctionLogModel)objModel;
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
		public List<NoName.NetShop.Model.AuctionLogModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.AuctionLogModel> modelList = new List<NoName.NetShop.Model.AuctionLogModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.AuctionLogModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.AuctionLogModel();
					if(ds.Tables[0].Rows[n]["AuctionId"].ToString()!="")
					{
						model.AuctionId=int.Parse(ds.Tables[0].Rows[n]["AuctionId"].ToString());
					}
					model.UserName=ds.Tables[0].Rows[n]["UserName"].ToString();
					if(ds.Tables[0].Rows[n]["AuctionTime"].ToString()!="")
					{
						model.AuctionTime=DateTime.Parse(ds.Tables[0].Rows[n]["AuctionTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AutionPrice"].ToString()!="")
					{
						model.AutionPrice=decimal.Parse(ds.Tables[0].Rows[n]["AutionPrice"].ToString());
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

