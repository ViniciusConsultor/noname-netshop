using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Auction.DAL;
using NoName.NetShop.Auction.Model;

namespace NoName.NetShop.Auction.BLL
{
	/// <summary>
	/// ҵ���߼���AuctionLogModelBll ��ժҪ˵����
	/// </summary>
	public class AuctionLogModelBll
	{
		private readonly AuctionLogModelDal dal=new AuctionLogModelDal();

		public AuctionLogModelBll()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(AuctionLogModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(AuctionLogModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			dal.Delete();
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public AuctionLogModel GetModel()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.GetModel();
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
        //public AuctionLogModel GetModelByCache()
        //{
        //    //�ñ���������Ϣ�����Զ�������/�����ֶ�
        //    string CacheKey = "AuctionLogModelModel-" ;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel();
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (AuctionLogModel)objModel;
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
		public List<AuctionLogModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<AuctionLogModel> modelList = new List<AuctionLogModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				AuctionLogModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new AuctionLogModel();
					if(ds.Tables[0].Rows[n]["AuctionId"].ToString()!="")
					{
						model.AuctionID=int.Parse(ds.Tables[0].Rows[n]["AuctionId"].ToString());
					}
					model.UserName=ds.Tables[0].Rows[n]["UserName"].ToString();
					if(ds.Tables[0].Rows[n]["AuctionTime"].ToString()!="")
					{
						model.AuctionTime=DateTime.Parse(ds.Tables[0].Rows[n]["AuctionTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AutionPrice"].ToString()!="")
					{
						model.AutionPrice=decimal.Parse(ds.Tables[0].Rows[n]["AutionPrice"].ToString());
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

