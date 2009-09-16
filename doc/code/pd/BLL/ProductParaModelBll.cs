using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类ProductParaModelBll 的摘要说明。
	/// </summary>
	public class ProductParaModelBll
	{
		private readonly NoName.NetShop.DAL.ProductParaModelDal dal=new NoName.NetShop.DAL.ProductParaModelDal();
		public ProductParaModelBll()
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
		public bool Exists(int ProductId,int ParaId)
		{
			return dal.Exists(ProductId,ParaId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.ProductParaModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.ProductParaModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductId,int ParaId)
		{
			
			dal.Delete(ProductId,ParaId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.ProductParaModel GetModel(int ProductId,int ParaId)
		{
			
			return dal.GetModel(ProductId,ParaId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.ProductParaModel GetModelByCache(int ProductId,int ParaId)
		{
			
			string CacheKey = "ProductParaModelModel-" + ProductId+ParaId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductId,ParaId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.ProductParaModel)objModel;
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
		public List<NoName.NetShop.Model.ProductParaModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.ProductParaModel> modelList = new List<NoName.NetShop.Model.ProductParaModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.ProductParaModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.ProductParaModel();
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ParaId"].ToString()!="")
					{
						model.ParaId=int.Parse(ds.Tables[0].Rows[n]["ParaId"].ToString());
					}
					model.ParaValue=ds.Tables[0].Rows[n]["ParaValue"].ToString();
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

