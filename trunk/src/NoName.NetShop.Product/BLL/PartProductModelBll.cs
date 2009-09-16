using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// ҵ���߼���PartProductModelBll ��ժҪ˵����
	/// </summary>
	public class PartProductModelBll
	{
		private readonly PartProductModelDal dal=new PartProductModelDal();
		public PartProductModelBll()
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
		public bool Exists(int ProductId,int PartProductId)
		{
			return dal.Exists(ProductId,PartProductId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(PartProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(PartProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProductId,int PartProductId)
		{
			
			dal.Delete(ProductId,PartProductId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public PartProductModel GetModel(int ProductId,int PartProductId)
		{
			
			return dal.GetModel(ProductId,PartProductId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
        //public PartProductModel GetModelByCache(int ProductId,int PartProductId)
        //{
			
        //    string CacheKey = "PartProductModelModel-" + ProductId+PartProductId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ProductId,PartProductId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (PartProductModel)objModel;
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
		public List<PartProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<PartProductModel> modelList = new List<PartProductModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				PartProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new PartProductModel();
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PartProductId"].ToString()!="")
					{
						model.PartProductId=int.Parse(ds.Tables[0].Rows[n]["PartProductId"].ToString());
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
         ///</summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            return dal.GetList(PageSize,PageIndex,strWhere);
        }

		#endregion  ��Ա����
	}
}

