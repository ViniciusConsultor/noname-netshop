using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using NoName.NetShop.Model;
namespace NoName.NetShop.BLL
{
	/// <summary>
	/// ҵ���߼���CategoryModelBll ��ժҪ˵����
	/// </summary>
	public class CategoryModelBll
	{
		private readonly NoName.NetShop.DAL.CategoryModelDal dal=new NoName.NetShop.DAL.CategoryModelDal();
		public CategoryModelBll()
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
		public bool Exists(int CateId)
		{
			return dal.Exists(CateId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Model.CategoryModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Model.CategoryModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CateId)
		{
			
			dal.Delete(CateId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Model.CategoryModel GetModel(int CateId)
		{
			
			return dal.GetModel(CateId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public NoName.NetShop.Model.CategoryModel GetModelByCache(int CateId)
		{
			
			string CacheKey = "CategoryModelModel-" + CateId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CateId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NoName.NetShop.Model.CategoryModel)objModel;
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
		public List<NoName.NetShop.Model.CategoryModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NoName.NetShop.Model.CategoryModel> modelList = new List<NoName.NetShop.Model.CategoryModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Model.CategoryModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Model.CategoryModel();
					if(ds.Tables[0].Rows[n]["CateId"].ToString()!="")
					{
						model.CateId=int.Parse(ds.Tables[0].Rows[n]["CateId"].ToString());
					}
					model.CateName=ds.Tables[0].Rows[n]["CateName"].ToString();
					model.CatePath=ds.Tables[0].Rows[n]["CatePath"].ToString();
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
					}
					model.PriceRange=ds.Tables[0].Rows[n]["PriceRange"].ToString();
					if(ds.Tables[0].Rows[n]["IsHide"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["IsHide"].ToString()=="1")||(ds.Tables[0].Rows[n]["IsHide"].ToString().ToLower()=="true"))
						{
						model.IsHide=true;
						}
						else
						{
							model.IsHide=false;
						}
					}
					if(ds.Tables[0].Rows[n]["CateLevel"].ToString()!="")
					{
						model.CateLevel=int.Parse(ds.Tables[0].Rows[n]["CateLevel"].ToString());
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
