using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类OrderModelBll 的摘要说明。
	/// </summary>
	public class OrderModelBll
	{
		private readonly NoName.NetShop.DAL.OrderModelDal dal=new NoName.NetShop.DAL.OrderModelDal();
		public OrderModelBll()
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
		public bool Exists(int OrderId)
		{
			return dal.Exists(OrderId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.OrderModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.OrderModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int OrderId)
		{
			
			dal.Delete(OrderId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.OrderModel GetModel(int OrderId)
		{
			
			return dal.GetModel(OrderId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.OrderModel GetModelByCache(int OrderId)
		{
			
			string CacheKey = "OrderModelModel-" + OrderId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(OrderId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.OrderModel)objModel;
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
		public List<NoName.NetShop.Model.OrderModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.OrderModel> modelList = new List<NoName.NetShop.Model.OrderModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.OrderModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.OrderModel();
					if(ds.Tables[0].Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(ds.Tables[0].Rows[n]["UserId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["OrderId"].ToString()!="")
					{
						model.OrderId=int.Parse(ds.Tables[0].Rows[n]["OrderId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["OrderStatus"].ToString()!="")
					{
						model.OrderStatus=int.Parse(ds.Tables[0].Rows[n]["OrderStatus"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PayMethod"].ToString()!="")
					{
						model.PayMethod=int.Parse(ds.Tables[0].Rows[n]["PayMethod"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ShipMethod"].ToString()!="")
					{
						model.ShipMethod=int.Parse(ds.Tables[0].Rows[n]["ShipMethod"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PayStatus"].ToString()!="")
					{
						model.PayStatus=int.Parse(ds.Tables[0].Rows[n]["PayStatus"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Paysum"].ToString()!="")
					{
						model.Paysum=decimal.Parse(ds.Tables[0].Rows[n]["Paysum"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ShipFee"].ToString()!="")
					{
						model.ShipFee=decimal.Parse(ds.Tables[0].Rows[n]["ShipFee"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ProductFee"].ToString()!="")
					{
						model.ProductFee=decimal.Parse(ds.Tables[0].Rows[n]["ProductFee"].ToString());
					}
					if(ds.Tables[0].Rows[n]["DerateFee"].ToString()!="")
					{
						model.DerateFee=decimal.Parse(ds.Tables[0].Rows[n]["DerateFee"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AddressId"].ToString()!="")
					{
						model.AddressId=int.Parse(ds.Tables[0].Rows[n]["AddressId"].ToString());
					}
					model.RecieverName=ds.Tables[0].Rows[n]["RecieverName"].ToString();
					model.RecieverEmail=ds.Tables[0].Rows[n]["RecieverEmail"].ToString();
					model.RecieverPhone=ds.Tables[0].Rows[n]["RecieverPhone"].ToString();
					model.Postalcode=ds.Tables[0].Rows[n]["Postalcode"].ToString();
					model.RecieverCity=ds.Tables[0].Rows[n]["RecieverCity"].ToString();
					model.RecieverProvince=ds.Tables[0].Rows[n]["RecieverProvince"].ToString();
					model.AddressDetial=ds.Tables[0].Rows[n]["AddressDetial"].ToString();
					if(ds.Tables[0].Rows[n]["ChangeTime"].ToString()!="")
					{
						model.ChangeTime=DateTime.Parse(ds.Tables[0].Rows[n]["ChangeTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PayTime"].ToString()!="")
					{
						model.PayTime=DateTime.Parse(ds.Tables[0].Rows[n]["PayTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[n]["CreateTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["OrderType"].ToString()!="")
					{
						model.OrderType=int.Parse(ds.Tables[0].Rows[n]["OrderType"].ToString());
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

