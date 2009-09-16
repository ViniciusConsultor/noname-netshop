using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类AnswerModelBll 的摘要说明。
	/// </summary>
	public class AnswerModelBll
	{
		private readonly NoName.NetShop.DAL.AnswerModelDal dal=new NoName.NetShop.DAL.AnswerModelDal();
		public AnswerModelBll()
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
		public bool Exists(int AnswerId)
		{
			return dal.Exists(AnswerId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.AnswerModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.AnswerModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AnswerId)
		{
			
			dal.Delete(AnswerId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.AnswerModel GetModel(int AnswerId)
		{
			
			return dal.GetModel(AnswerId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.AnswerModel GetModelByCache(int AnswerId)
		{
			
			string CacheKey = "AnswerModelModel-" + AnswerId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AnswerId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.AnswerModel)objModel;
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
		public List<NoName.NetShop.Model.AnswerModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.AnswerModel> modelList = new List<NoName.NetShop.Model.AnswerModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.AnswerModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.AnswerModel();
					if(ds.Tables[0].Rows[n]["QuestionId"].ToString()!="")
					{
						model.QuestionId=int.Parse(ds.Tables[0].Rows[n]["QuestionId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AnswerId"].ToString()!="")
					{
						model.AnswerId=int.Parse(ds.Tables[0].Rows[n]["AnswerId"].ToString());
					}
					model.Title=ds.Tables[0].Rows[n]["Title"].ToString();
					model.Brief=ds.Tables[0].Rows[n]["Brief"].ToString();
					model.Content=ds.Tables[0].Rows[n]["Content"].ToString();
					if(ds.Tables[0].Rows[n]["AnswerTime"].ToString()!="")
					{
						model.AnswerTime=DateTime.Parse(ds.Tables[0].Rows[n]["AnswerTime"].ToString());
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

