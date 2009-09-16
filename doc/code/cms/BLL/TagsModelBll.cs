using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// ҵ���߼���TagsModelBll ��ժҪ˵����
	/// </summary>
	public class TagsModelBll
	{
		private readonly NoName.NetShop.DAL.TagsModelDal dal=new NoName.NetShop.DAL.TagsModelDal();
		public TagsModelBll()
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
		public bool Exists(int CmsTagId)
		{
			return dal.Exists(CmsTagId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Model.TagsModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.TagsModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CmsTagId)
		{
			
			dal.Delete(CmsTagId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.TagsModel GetModel(int CmsTagId)
		{
			
			return dal.GetModel(CmsTagId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public NoName.NetShop.Model.TagsModel GetModelByCache(int CmsTagId)
		{
			
			string CacheKey = "TagsModelModel-" + CmsTagId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CmsTagId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.TagsModel)objModel;
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
		public List<NoName.NetShop.Model.TagsModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.TagsModel> modelList = new List<NoName.NetShop.Model.TagsModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.TagsModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.TagsModel();
					if(ds.Tables[0].Rows[n]["CmsTagId"].ToString()!="")
					{
						model.CmsTagId=int.Parse(ds.Tables[0].Rows[n]["CmsTagId"].ToString());
					}
					model.CmsTagName=ds.Tables[0].Rows[n]["CmsTagName"].ToString();
					model.TagBrief=ds.Tables[0].Rows[n]["TagBrief"].ToString();
					model.DefaultContent=ds.Tables[0].Rows[n]["DefaultContent"].ToString();
					model.TagType=ds.Tables[0].Rows[n]["TagType"].ToString();
					model.TagParas=ds.Tables[0].Rows[n]["TagParas"].ToString();
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

