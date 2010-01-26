using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Common;


namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// ҵ���߼���BrandModelBll ��ժҪ˵����
	/// </summary>
	public class BrandModelBll
	{
		private readonly BrandModelDal dal=new BrandModelDal();

		public BrandModelBll()
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
		public bool Exists(int BrandId)
		{
			return dal.Exists(BrandId);
		}

        public bool Exists(string BrandName)
        {
            return dal.Exists(BrandName);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(BrandModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(BrandModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int BrandId)
		{
			
			dal.Delete(BrandId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public BrandModel GetModel(int BrandId)
		{
			
			return dal.GetModel(BrandId);
		}

        ///// <summary>
        ///// �õ�һ������ʵ�壬�ӻ����С�
        ///// </summary>
        //public BrandModel GetModelByCache(int BrandId)
        //{
			
        //    string CacheKey = "BrandModelModel-" + BrandId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(BrandId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (BrandModel)objModel;
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
		public List<BrandModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<BrandModel> modelList = new List<BrandModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				BrandModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BrandModel();
					if(ds.Tables[0].Rows[n]["BrandId"].ToString()!="")
					{
						model.BrandId=int.Parse(ds.Tables[0].Rows[n]["BrandId"].ToString());
					}
					model.BrandName=ds.Tables[0].Rows[n]["BrandName"].ToString();
					if(ds.Tables[0].Rows[n]["CateId"].ToString()!="")
					{
						model.CateId=int.Parse(ds.Tables[0].Rows[n]["CateId"].ToString());
					}
					model.CatePath=ds.Tables[0].Rows[n]["CatePath"].ToString();
					model.BrandLogo=ds.Tables[0].Rows[n]["BrandLogo"].ToString();
					model.Brief=ds.Tables[0].Rows[n]["Brief"].ToString();
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

        public DataSet GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            SearchPageInfo info = new SearchPageInfo();

            info.FieldNames = "*";
            info.OrderType = " showorder desc";
            info.PageIndex = PageIndex;
            info.PageSize = PageSize;
            info.PriKeyName = "brandid";
            info.StrJoin = "";
            info.StrWhere = "";
            info.TableName = "pdbrand";
            info.TotalFieldStr = "";

            DataSet ds = CommDataHelper.GetDataFromSingleTableByPage(info);

            RecordCount = info.TotalItem;

            return ds;
        }

        public int SwitchOrder(int InitialBrandID, int ReplacedBrandID)
        {
            return dal.SwitchOrder(InitialBrandID, ReplacedBrandID);
        }

		#endregion  ��Ա����
	}
}

