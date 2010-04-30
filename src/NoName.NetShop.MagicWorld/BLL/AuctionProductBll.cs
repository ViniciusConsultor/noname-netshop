using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.DAL;

namespace NoName.NetShop.MagicWorld.BLL
{
    public class AuctionProductBll
    {
        private readonly AuctionProductDal dal = new AuctionProductDal();
        public AuctionProductBll()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AuctionId)
		{
			return dal.Exists(AuctionId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(AuctionProductModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(AuctionProductModel model)
		{
			dal.Update(model);
		}

        public void UpdateStatus(int AuctionId, int Status)
        {
            dal.UpdateStatus(AuctionId, Status);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AuctionId)
		{
			
			dal.Delete(AuctionId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AuctionProductModel GetModel(int AuctionId)
		{
			
			return dal.GetModel(AuctionId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public DataTable GetRelatedProductList(int CategoryID)
        {
            return dal.GetRelatedProductList(CategoryID);
        }

		/// <summary>
		/// 获得数据列表
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
						model.AuctionID=int.Parse(ds.Tables[0].Rows[n]["AuctionId"].ToString());
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
						model.AddPrices= ds.Tables[0].Rows[n]["AddPrices"].ToString();
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}


        public DataTable GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            SearchPageInfo info = new SearchPageInfo();

            info.FieldNames = "*";
            info.OrderType = " auctionid desc";
            info.PageIndex = PageIndex;
            info.PageSize = PageSize;
            info.PriKeyName = "auctionid";
            info.StrJoin = "";
            info.StrWhere = " 1=1 " + Condition;
            info.TableName = "mwAuctionProduct";
            info.TotalFieldStr = "";

            DataTable dt = CommDataHelper.GetDataFromSingleTableByPage(info).Tables[0];

            RecordCount = info.TotalItem;

            return dt;
        }

		#endregion  成员方法
    }
}
