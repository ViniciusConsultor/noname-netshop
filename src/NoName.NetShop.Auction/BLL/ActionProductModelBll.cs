using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类ActionProductModelBll 的摘要说明。
	/// </summary>
	public class ActionProductModelBll
	{
		private readonly NoName.NetShop.DAL.ActionProductModelDal dal=new NoName.NetShop.DAL.ActionProductModelDal();
		public ActionProductModelBll()
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
		public bool Exists(int AuctionId)
		{
			return dal.Exists(AuctionId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.ActionProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.ActionProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AuctionId)
		{
			
			dal.Delete(AuctionId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.ActionProductModel GetModel(int AuctionId)
		{
			
			return dal.GetModel(AuctionId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.ActionProductModel GetModelByCache(int AuctionId)
		{
			
			string CacheKey = "ActionProductModelModel-" + AuctionId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AuctionId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.ActionProductModel)objModel;
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
		public List<NoName.NetShop.Model.ActionProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.ActionProductModel> modelList = new List<NoName.NetShop.Model.ActionProductModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.ActionProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.ActionProductModel();
					if(ds.Tables[0].Rows[n]["AuctionId"].ToString()!="")
					{
						model.AuctionId=int.Parse(ds.Tables[0].Rows[n]["AuctionId"].ToString());
					}
					model.ProductName=ds.Tables[0].Rows[n]["ProductName"].ToString();
					model.SmallIamge=ds.Tables[0].Rows[n]["SmallIamge"].ToString();
					model.MediumImage=ds.Tables[0].Rows[n]["MediumImage"].ToString();
					model.OutLinkUrl=ds.Tables[0].Rows[n]["OutLinkUrl"].ToString();
					if(ds.Tables[0].Rows[n]["StartPrice"].ToString()!="")
					{
						model.StartPrice=decimal.Parse(ds.Tables[0].Rows[n]["StartPrice"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AddPrices"].ToString()!="")
					{
						model.AddPrices=decimal.Parse(ds.Tables[0].Rows[n]["AddPrices"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CurPrice"].ToString()!="")
					{
						model.CurPrice=decimal.Parse(ds.Tables[0].Rows[n]["CurPrice"].ToString());
					}
					model.Brief=ds.Tables[0].Rows[n]["Brief"].ToString();
					if(ds.Tables[0].Rows[n]["StartTime"].ToString()!="")
					{
						model.StartTime=DateTime.Parse(ds.Tables[0].Rows[n]["StartTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["EndTime"].ToString()!="")
					{
						model.EndTime=DateTime.Parse(ds.Tables[0].Rows[n]["EndTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
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

