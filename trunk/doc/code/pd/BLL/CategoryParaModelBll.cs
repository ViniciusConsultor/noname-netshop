using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// ҵ���߼���CategoryParaModelBll ��ժҪ˵����
	/// </summary>
	public class CategoryParaModelBll
	{
		private readonly NoName.NetShop.DAL.CategoryParaModelDal dal=new NoName.NetShop.DAL.CategoryParaModelDal();
		public CategoryParaModelBll()
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
		public bool Exists(int ParaId)
		{
			return dal.Exists(ParaId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Model.CategoryParaModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.CategoryParaModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ParaId)
		{
			
			dal.Delete(ParaId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.CategoryParaModel GetModel(int ParaId)
		{
			
			return dal.GetModel(ParaId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public NoName.NetShop.Model.CategoryParaModel GetModelByCache(int ParaId)
		{
			
			string CacheKey = "CategoryParaModelModel-" + ParaId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ParaId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.CategoryParaModel)objModel;
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
		public List<NoName.NetShop.Model.CategoryParaModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.CategoryParaModel> modelList = new List<NoName.NetShop.Model.CategoryParaModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.CategoryParaModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.CategoryParaModel();
					if(ds.Tables[0].Rows[n]["ParaId"].ToString()!="")
					{
						model.ParaId=int.Parse(ds.Tables[0].Rows[n]["ParaId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CateId"].ToString()!="")
					{
						model.CateId=int.Parse(ds.Tables[0].Rows[n]["CateId"].ToString());
					}
					model.ParaName=ds.Tables[0].Rows[n]["ParaName"].ToString();
					if(ds.Tables[0].Rows[n]["ParaType"].ToString()!="")
					{
						model.ParaType=int.Parse(ds.Tables[0].Rows[n]["ParaType"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ParaGroupId"].ToString()!="")
					{
						model.ParaGroupId=int.Parse(ds.Tables[0].Rows[n]["ParaGroupId"].ToString());
					}
					model.ParaValues=ds.Tables[0].Rows[n]["ParaValues"].ToString();
					model.DefaultValue=ds.Tables[0].Rows[n]["DefaultValue"].ToString();
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
