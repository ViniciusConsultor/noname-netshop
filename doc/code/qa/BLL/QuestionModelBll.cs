using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// 业务逻辑类QuestionModelBll 的摘要说明。
	/// </summary>
	public class QuestionModelBll
	{
		private readonly NoName.NetShop.DAL.QuestionModelDal dal=new NoName.NetShop.DAL.QuestionModelDal();
		public QuestionModelBll()
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
		public bool Exists(int QuestionId)
		{
			return dal.Exists(QuestionId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.QuestionModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.QuestionModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int QuestionId)
		{
			
			dal.Delete(QuestionId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.QuestionModel GetModel(int QuestionId)
		{
			
			return dal.GetModel(QuestionId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public NoName.NetShop.Model.QuestionModel GetModelByCache(int QuestionId)
		{
			
			string CacheKey = "QuestionModelModel-" + QuestionId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(QuestionId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.QuestionModel)objModel;
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
		public List<NoName.NetShop.Model.QuestionModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.QuestionModel> modelList = new List<NoName.NetShop.Model.QuestionModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.QuestionModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.QuestionModel();
					if(ds.Tables[0].Rows[n]["QuestionId"].ToString()!="")
					{
						model.QuestionId=int.Parse(ds.Tables[0].Rows[n]["QuestionId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(ds.Tables[0].Rows[n]["UserId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ContentType"].ToString()!="")
					{
						model.ContentType=int.Parse(ds.Tables[0].Rows[n]["ContentType"].ToString());
					}
					model.ContentId=ds.Tables[0].Rows[n]["ContentId"].ToString();
					model.Title=ds.Tables[0].Rows[n]["Title"].ToString();
					model.Content=ds.Tables[0].Rows[n]["Content"].ToString();
					model.Brief=ds.Tables[0].Rows[n]["Brief"].ToString();
					if(ds.Tables[0].Rows[n]["InsertTime"].ToString()!="")
					{
						model.InsertTime=DateTime.Parse(ds.Tables[0].Rows[n]["InsertTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["LastAnswerTime"].ToString()!="")
					{
						model.LastAnswerTime=DateTime.Parse(ds.Tables[0].Rows[n]["LastAnswerTime"].ToString());
					}
					model.LastAnswerId=ds.Tables[0].Rows[n]["LastAnswerId"].ToString();
					if(ds.Tables[0].Rows[n]["AnswerNum"].ToString()!="")
					{
						model.AnswerNum=int.Parse(ds.Tables[0].Rows[n]["AnswerNum"].ToString());
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

