using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// ҵ���߼���QuestionModelBll ��ժҪ˵����
	/// </summary>
	public class QuestionModelBll
	{
		private readonly NoName.NetShop.DAL.QuestionModelDal dal=new NoName.NetShop.DAL.QuestionModelDal();
		public QuestionModelBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int QuestionId)
		{
			return dal.Exists(QuestionId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Model.QuestionModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.QuestionModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int QuestionId)
		{
			
			dal.Delete(QuestionId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.QuestionModel GetModel(int QuestionId)
		{
			
			return dal.GetModel(QuestionId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

