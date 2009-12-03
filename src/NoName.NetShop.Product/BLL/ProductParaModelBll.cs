using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// ҵ���߼���ProductParaModelBll ��ժҪ˵����
	/// </summary>
	public class ProductParaModelBll
	{
		private readonly ProductParaModelDal dal=new ProductParaModelDal();
		public ProductParaModelBll()
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
		public bool Exists(int ProductId,int ParaId)
		{
			return dal.Exists(ProductId,ParaId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ProductParaModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ProductParaModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProductId,int ParaId)
		{			
			dal.Delete(ProductId,ParaId);
		}

        public void Delete(int ProductID)
        {
            dal.Delete(ProductID);
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ProductParaModel GetModel(int ProductId,int ParaId)
		{
			
			return dal.GetModel(ProductId,ParaId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
        //public ProductParaModel GetModelByCache(int ProductId,int ParaId)
        //{
			
        //    string CacheKey = "ProductParaModelModel-" + ProductId+ParaId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ProductId,ParaId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (ProductParaModel)objModel;
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
		public List<ProductParaModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ProductParaModel> modelList = new List<ProductParaModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ProductParaModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ProductParaModel();
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ParaId"].ToString()!="")
					{
						model.ParaId=int.Parse(ds.Tables[0].Rows[n]["ParaId"].ToString());
					}
					model.ParaValue=ds.Tables[0].Rows[n]["ParaValue"].ToString();
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

