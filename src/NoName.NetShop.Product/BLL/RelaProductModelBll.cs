using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// ҵ���߼���RelaProductModelBll ��ժҪ˵����
	/// </summary>
	public class RelaProductModelBll
	{
		private readonly RelaProductModelDal dal=new RelaProductModelDal();
		public RelaProductModelBll()
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
		public bool Exists(int ProductId,int RelaProductId)
		{
			return dal.Exists(ProductId,RelaProductId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(RelaProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(RelaProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProductId,int RelaProductId)
		{
			
			dal.Delete(ProductId,RelaProductId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public RelaProductModel GetModel(int ProductId,int RelaProductId)
		{
			
			return dal.GetModel(ProductId,RelaProductId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
        //public RelaProductModel GetModelByCache(int ProductId, int RelaProductId)
        //{

        //    string CacheKey = "RelaProductModelModel-" + ProductId + RelaProductId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ProductId, RelaProductId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (RelaProductModel)objModel;
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
		public List<RelaProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<RelaProductModel> modelList = new List<RelaProductModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				RelaProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RelaProductModel();
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["RelaProductId"].ToString()!="")
					{
						model.RelaProductId=int.Parse(ds.Tables[0].Rows[n]["RelaProductId"].ToString());
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

		#endregion  ��Ա����
	}
}

