using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// ҵ���߼���SuitSchemeModelBll ��ժҪ˵����
	/// </summary>
	public class SuitSchemeModelBll
	{
		private readonly NoName.NetShop.DAL.SuitSchemeModelDal dal=new NoName.NetShop.DAL.SuitSchemeModelDal();
		public SuitSchemeModelBll()
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
		public bool Exists(int SchemeId)
		{
			return dal.Exists(SchemeId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Model.SuitSchemeModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.SuitSchemeModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SchemeId)
		{
			
			dal.Delete(SchemeId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.SuitSchemeModel GetModel(int SchemeId)
		{
			
			return dal.GetModel(SchemeId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public NoName.NetShop.Model.SuitSchemeModel GetModelByCache(int SchemeId)
		{
			
			string CacheKey = "SuitSchemeModelModel-" + SchemeId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SchemeId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.SuitSchemeModel)objModel;
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
		public List<NoName.NetShop.Model.SuitSchemeModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.SuitSchemeModel> modelList = new List<NoName.NetShop.Model.SuitSchemeModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.SuitSchemeModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.SuitSchemeModel();
					if(ds.Tables[0].Rows[n]["SchemeId"].ToString()!="")
					{
						model.SchemeId=int.Parse(ds.Tables[0].Rows[n]["SchemeId"].ToString());
					}
					model.SchemeName=ds.Tables[0].Rows[n]["SchemeName"].ToString();
					if(ds.Tables[0].Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[n]["CreateTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
					}
					model.SchemeDesc=ds.Tables[0].Rows[n]["SchemeDesc"].ToString();
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

