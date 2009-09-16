using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// ҵ���߼���CategoryParaModelBll ��ժҪ˵����
	/// </summary>
	public class CategoryParaModelBll
	{
		private readonly CategoryParaModelDal dal=new CategoryParaModelDal();
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
		public void Add(CategoryParaModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(CategoryParaModel model)
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
		public CategoryParaModel GetModel(int ParaId)
		{
			
			return dal.GetModel(ParaId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
        //public CategoryParaModel GetModelByCache(int ParaId)
        //{
			
        //    string CacheKey = "CategoryParaModelModel-" + ParaId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ParaId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (CategoryParaModel)objModel;
        //}

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
		public List<CategoryParaModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<CategoryParaModel> modelList = new List<CategoryParaModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				CategoryParaModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CategoryParaModel();
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

		#endregion  ��Ա����
	}
}

