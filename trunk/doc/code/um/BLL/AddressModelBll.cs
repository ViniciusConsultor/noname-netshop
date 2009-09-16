using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类AddressModelBll 的摘要说明。
	/// </summary>
	public class AddressModelBll
	{
		private readonly NoName.NetShop.DAL.AddressModelDal dal=new NoName.NetShop.DAL.AddressModelDal();
		public AddressModelBll()
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
		public bool Exists(int AddressId)
		{
			return dal.Exists(AddressId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.AddressModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.AddressModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AddressId)
		{
			
			dal.Delete(AddressId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.AddressModel GetModel(int AddressId)
		{
			
			return dal.GetModel(AddressId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.AddressModel GetModelByCache(int AddressId)
		{
			
			string CacheKey = "AddressModelModel-" + AddressId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AddressId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.AddressModel)objModel;
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
		public List<NoName.NetShop.Model.AddressModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.AddressModel> modelList = new List<NoName.NetShop.Model.AddressModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.AddressModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.AddressModel();
					if(ds.Tables[0].Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(ds.Tables[0].Rows[n]["UserId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AddressId"].ToString()!="")
					{
						model.AddressId=int.Parse(ds.Tables[0].Rows[n]["AddressId"].ToString());
					}
					model.Province=ds.Tables[0].Rows[n]["Province"].ToString();
					model.City=ds.Tables[0].Rows[n]["City"].ToString();
					model.AddressDetail=ds.Tables[0].Rows[n]["AddressDetail"].ToString();
					model.RecieverName=ds.Tables[0].Rows[n]["RecieverName"].ToString();
					model.Mobile=ds.Tables[0].Rows[n]["Mobile"].ToString();
					model.Telephone=ds.Tables[0].Rows[n]["Telephone"].ToString();
					model.Postalcode=ds.Tables[0].Rows[n]["Postalcode"].ToString();
					if(ds.Tables[0].Rows[n]["IsDefault"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["IsDefault"].ToString()=="1")||(ds.Tables[0].Rows[n]["IsDefault"].ToString().ToLower()=="true"))
						{
						model.IsDefault=true;
						}
						else
						{
							model.IsDefault=false;
						}
					}
					if(ds.Tables[0].Rows[n]["InsertTime"].ToString()!="")
					{
						model.InsertTime=DateTime.Parse(ds.Tables[0].Rows[n]["InsertTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ModifyTime"].ToString()!="")
					{
						model.ModifyTime=DateTime.Parse(ds.Tables[0].Rows[n]["ModifyTime"].ToString());
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

