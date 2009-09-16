using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类VoteTopicModelBll 的摘要说明。
	/// </summary>
	public class VoteTopicModelBll
	{
		private readonly NoName.NetShop.DAL.VoteTopicModelDal dal=new NoName.NetShop.DAL.VoteTopicModelDal();
		public VoteTopicModelBll()
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
		public bool Exists(int VoteId)
		{
			return dal.Exists(VoteId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.VoteTopicModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.VoteTopicModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int VoteId)
		{
			
			dal.Delete(VoteId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.VoteTopicModel GetModel(int VoteId)
		{
			
			return dal.GetModel(VoteId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.VoteTopicModel GetModelByCache(int VoteId)
		{
			
			string CacheKey = "VoteTopicModelModel-" + VoteId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(VoteId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.VoteTopicModel)objModel;
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
		public List<NoName.NetShop.Model.VoteTopicModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.VoteTopicModel> modelList = new List<NoName.NetShop.Model.VoteTopicModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.VoteTopicModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.VoteTopicModel();
					if(ds.Tables[0].Rows[n]["VoteId"].ToString()!="")
					{
						model.VoteId=int.Parse(ds.Tables[0].Rows[n]["VoteId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ContentId"].ToString()!="")
					{
						model.ContentId=int.Parse(ds.Tables[0].Rows[n]["ContentId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ContentType"].ToString()!="")
					{
						model.ContentType=int.Parse(ds.Tables[0].Rows[n]["ContentType"].ToString());
					}
					model.Topic=ds.Tables[0].Rows[n]["Topic"].ToString();
					model.Remark=ds.Tables[0].Rows[n]["Remark"].ToString();
					if(ds.Tables[0].Rows[n]["StartTime"].ToString()!="")
					{
						model.StartTime=DateTime.Parse(ds.Tables[0].Rows[n]["StartTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["EndTime"].ToString()!="")
					{
						model.EndTime=DateTime.Parse(ds.Tables[0].Rows[n]["EndTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["IsRegUser"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["IsRegUser"].ToString()=="1")||(ds.Tables[0].Rows[n]["IsRegUser"].ToString().ToLower()=="true"))
						{
						model.IsRegUser=true;
						}
						else
						{
							model.IsRegUser=false;
						}
					}
					if(ds.Tables[0].Rows[n]["VoteUserNum"].ToString()!="")
					{
						model.VoteUserNum=int.Parse(ds.Tables[0].Rows[n]["VoteUserNum"].ToString());
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

