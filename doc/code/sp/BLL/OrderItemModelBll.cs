using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类OrderItemModelBll 的摘要说明。
	/// </summary>
	public class OrderItemModelBll
	{
		private readonly NoName.NetShop.DAL.OrderItemModelDal dal=new NoName.NetShop.DAL.OrderItemModelDal();
		public OrderItemModelBll()
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
		public bool Exists(int OrderItem)
		{
			return dal.Exists(OrderItem);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.OrderItemModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.OrderItemModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int OrderItem)
		{
			
			dal.Delete(OrderItem);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.OrderItemModel GetModel(int OrderItem)
		{
			
			return dal.GetModel(OrderItem);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.OrderItemModel GetModelByCache(int OrderItem)
		{
			
			string CacheKey = "OrderItemModelModel-" + OrderItem;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(OrderItem);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.OrderItemModel)objModel;
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
		public List<NoName.NetShop.Model.OrderItemModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.OrderItemModel> modelList = new List<NoName.NetShop.Model.OrderItemModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.OrderItemModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.OrderItemModel();
					if(ds.Tables[0].Rows[n]["OrderId"].ToString()!="")
					{
						model.OrderId=int.Parse(ds.Tables[0].Rows[n]["OrderId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["OrderItem"].ToString()!="")
					{
						model.OrderItem=int.Parse(ds.Tables[0].Rows[n]["OrderItem"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ProductFee"].ToString()!="")
					{
						model.ProductFee=decimal.Parse(ds.Tables[0].Rows[n]["ProductFee"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Quantity"].ToString()!="")
					{
						model.Quantity=int.Parse(ds.Tables[0].Rows[n]["Quantity"].ToString());
					}
					if(ds.Tables[0].Rows[n]["DerateFee"].ToString()!="")
					{
						model.DerateFee=decimal.Parse(ds.Tables[0].Rows[n]["DerateFee"].ToString());
					}
					if(ds.Tables[0].Rows[n]["MerchantPrice"].ToString()!="")
					{
						model.MerchantPrice=decimal.Parse(ds.Tables[0].Rows[n]["MerchantPrice"].ToString());
					}
					if(ds.Tables[0].Rows[n]["TotalFee"].ToString()!="")
					{
						model.TotalFee=decimal.Parse(ds.Tables[0].Rows[n]["TotalFee"].ToString());
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

