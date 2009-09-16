using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类VoteRemarkModelBll 的摘要说明。
	/// </summary>
	public class VoteRemarkModelBll
	{
		private readonly NoName.NetShop.DAL.VoteRemarkModelDal dal=new NoName.NetShop.DAL.VoteRemarkModelDal();
		public VoteRemarkModelBll()
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
		public bool Exists(int VoteId,int UserId)
		{
			return dal.Exists(VoteId,UserId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.VoteRemarkModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.VoteRemarkModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int VoteId,int UserId)
		{
			
			dal.Delete(VoteId,UserId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.VoteRemarkModel GetModel(int VoteId,int UserId)
		{
			
			return dal.GetModel(VoteId,UserId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.VoteRemarkModel GetModelByCache(int VoteId,int UserId)
		{
			
			string CacheKey = "VoteRemarkModelModel-" + VoteId+UserId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(VoteId,UserId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.VoteRemarkModel)objModel;
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
		public List<NoName.NetShop.Model.VoteRemarkModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.VoteRemarkModel> modelList = new List<NoName.NetShop.Model.VoteRemarkModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.VoteRemarkModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.VoteRemarkModel();
					if(ds.Tables[0].Rows[n]["VoteId"].ToString()!="")
					{
						model.VoteId=int.Parse(ds.Tables[0].Rows[n]["VoteId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(ds.Tables[0].Rows[n]["UserId"].ToString());
					}
					model.Remark=ds.Tables[0].Rows[n]["Remark"].ToString();
					if(ds.Tables[0].Rows[n]["VoteTime"].ToString()!="")
					{
						model.VoteTime=DateTime.Parse(ds.Tables[0].Rows[n]["VoteTime"].ToString());
					}
					model.VoteIP=ds.Tables[0].Rows[n]["VoteIP"].ToString();
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

