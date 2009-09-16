using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// ҵ���߼���SalesInfoModelBll ��ժҪ˵����
	/// </summary>
	public class SalesInfoModelBll
	{
		private readonly SalesInfoModelDal dal=new SalesInfoModelDal();
		public SalesInfoModelBll()
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
		public bool Exists(int SalesType,int ProductId,int RuleType)
		{
			return dal.Exists(SalesType,ProductId,RuleType);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(SalesInfoModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SalesInfoModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SalesType,int ProductId,int RuleType)
		{
			
			dal.Delete(SalesType,ProductId,RuleType);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SalesInfoModel GetModel(int SalesType,int ProductId,int RuleType)
		{
			
			return dal.GetModel(SalesType,ProductId,RuleType);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
        //public SalesInfoModel GetModelByCache(int SalesType,int ProductId,int RuleType)
        //{
			
        //    string CacheKey = "SalesInfoModelModel-" + SalesType+ProductId+RuleType;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(SalesType,ProductId,RuleType);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (SalesInfoModel)objModel;
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
		public List<SalesInfoModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<SalesInfoModel> modelList = new List<SalesInfoModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				SalesInfoModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SalesInfoModel();
					if(ds.Tables[0].Rows[n]["SalesType"].ToString()!="")
					{
						model.SalesType=int.Parse(ds.Tables[0].Rows[n]["SalesType"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["RuleType"].ToString()!="")
					{
						model.RuleType=int.Parse(ds.Tables[0].Rows[n]["RuleType"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SortValue"].ToString()!="")
					{
						model.SortValue=int.Parse(ds.Tables[0].Rows[n]["SortValue"].ToString());
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

