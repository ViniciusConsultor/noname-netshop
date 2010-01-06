using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Auction.DAL;
using NoName.NetShop.Auction.Model;

namespace NoName.NetShop.Auction.BLL
{
	/// <summary>
	/// 业务逻辑类AuctionLogModelBll 的摘要说明。
	/// </summary>
	public class AuctionLogModelBll
	{
		private readonly AuctionLogModelDal dal=new AuctionLogModelDal();

		public AuctionLogModelBll()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(AuctionLogModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(AuctionLogModel model)
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
		public AuctionLogModel GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public AuctionLogModel GetModelByCache()
        //{
        //    //该表无主键信息，请自定义主键/条件字段
        //    string CacheKey = "AuctionLogModelModel-" ;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel();
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (AuctionLogModel)objModel;
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
		public List<AuctionLogModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<AuctionLogModel> modelList = new List<AuctionLogModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				AuctionLogModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new AuctionLogModel();
					if(ds.Tables[0].Rows[n]["AuctionId"].ToString()!="")
					{
						model.AuctionID=int.Parse(ds.Tables[0].Rows[n]["AuctionId"].ToString());
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

