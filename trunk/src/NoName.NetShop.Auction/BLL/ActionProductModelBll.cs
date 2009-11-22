using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Auction.DAL;
using NoName.NetShop.Auction.Model;
using NoName.NetShop.Common;

namespace NoName.NetShop.Auction.BLL
{
	/// <summary>
	/// ҵ���߼���AuctionProductModelBll ��ժҪ˵����
	/// </summary>
	public class AuctionProductModelBll
	{
        private readonly AuctionProductModelDal dal = new AuctionProductModelDal();
		public AuctionProductModelBll()
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
		public bool Exists(int AuctionId)
		{
			return dal.Exists(AuctionId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(AuctionProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(AuctionProductModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int AuctionId)
		{
			
			dal.Delete(AuctionId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public AuctionProductModel GetModel(int AuctionId)
		{
			
			return dal.GetModel(AuctionId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
        //public AuctionProductModel GetModelByCache(int AuctionId)
        //{
			
        //    string CacheKey = "AuctionProductModelModel-" + AuctionId;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(AuctionId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (AuctionProductModel)objModel;
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
		public List<AuctionProductModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<AuctionProductModel> modelList = new List<AuctionProductModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				AuctionProductModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new AuctionProductModel();
					if(ds.Tables[0].Rows[n]["AuctionId"].ToString()!="")
					{
						model.AuctionId=int.Parse(ds.Tables[0].Rows[n]["AuctionId"].ToString());
					}
					model.ProductName=ds.Tables[0].Rows[n]["ProductName"].ToString();
					model.SmallImage=ds.Tables[0].Rows[n]["SmallImage"].ToString();
					model.MediumImage=ds.Tables[0].Rows[n]["MediumImage"].ToString();
					model.OutLinkUrl=ds.Tables[0].Rows[n]["OutLinkUrl"].ToString();
					if(ds.Tables[0].Rows[n]["StartPrice"].ToString()!="")
					{
						model.StartPrice=decimal.Parse(ds.Tables[0].Rows[n]["StartPrice"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AddPrices"].ToString()!="")
					{
						model.AddPrices=decimal.Parse(ds.Tables[0].Rows[n]["AddPrices"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CurPrice"].ToString()!="")
					{
						model.CurPrice=decimal.Parse(ds.Tables[0].Rows[n]["CurPrice"].ToString());
					}
					model.Brief=ds.Tables[0].Rows[n]["Brief"].ToString();
					if(ds.Tables[0].Rows[n]["StartTime"].ToString()!="")
					{
						model.StartTime=DateTime.Parse(ds.Tables[0].Rows[n]["StartTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["EndTime"].ToString()!="")
					{
						model.EndTime=DateTime.Parse(ds.Tables[0].Rows[n]["EndTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
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


        public DataTable GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            SearchPageInfo info = new SearchPageInfo();

            info.FieldNames = "*";
            info.OrderType = "";
            info.PageIndex = PageIndex;
            info.PageSize = PageSize;
            info.PriKeyName = "auctionid";
            info.StrJoin = "";
            info.StrWhere = " 1=1 " + Condition;
            info.TableName = "auActionProduct";
            info.TotalFieldStr = "";

            DataTable dt = CommDataHelper.GetDataFromSingleTableByPage(info).Tables[0];

            RecordCount = info.TotalItem;

            return dt;
        }

		#endregion  ��Ա����
	}
}

