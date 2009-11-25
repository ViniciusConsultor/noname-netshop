using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Auction.Model;
using NoName.NetShop.Common;

namespace NoName.NetShop.Auction.DAL
{
	/// <summary>
	/// 数据访问类ActionProductModelDal。
	/// </summary>
	public class AuctionProductModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public AuctionProductModelDal()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AuctionId)
		{			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_auActionProduct_Exists");
			dbw.AddInParameter(dbCommand, "AuctionId", DbType.Int32,AuctionId);
			int result;
			object obj = dbw.ExecuteScalar(dbCommand);
			int.TryParse(obj.ToString(),out result);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(AuctionProductModel model)
		{			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_auActionProduct_ADD");
			dbw.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionId);
			dbw.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
			dbw.AddInParameter(dbCommand, "SmallIamge", DbType.AnsiString, model.SmallImage);
			dbw.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			dbw.AddInParameter(dbCommand, "OutLinkUrl", DbType.AnsiString, model.OutLinkUrl);
			dbw.AddInParameter(dbCommand, "StartPrice", DbType.Decimal, model.StartPrice);
			dbw.AddInParameter(dbCommand, "AddPrices", DbType.Decimal, model.AddPrices);
			dbw.AddInParameter(dbCommand, "CurPrice", DbType.Decimal, model.CurPrice);
			dbw.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			dbw.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			dbw.AddInParameter(dbCommand, "EndTime", DbType.DateTime, model.EndTime);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(AuctionProductModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_auActionProduct_Update");
			dbw.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionId);
			dbw.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
			dbw.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			dbw.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			dbw.AddInParameter(dbCommand, "OutLinkUrl", DbType.AnsiString, model.OutLinkUrl);
			dbw.AddInParameter(dbCommand, "StartPrice", DbType.Decimal, model.StartPrice);
			dbw.AddInParameter(dbCommand, "AddPrices", DbType.Decimal, model.AddPrices);
			dbw.AddInParameter(dbCommand, "CurPrice", DbType.Decimal, model.CurPrice);
			dbw.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			dbw.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			dbw.AddInParameter(dbCommand, "EndTime", DbType.DateTime, model.EndTime);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.ExecuteNonQuery(dbCommand);
		}

        public void UpdateStatus(int AuctionId, int Status)
        {
            string sql = "update auActionProduct set status={0} where auctionid={1}";
            sql = String.Format(sql,Status,AuctionId);
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AuctionId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_auActionProduct_Delete");
			dbw.AddInParameter(dbCommand, "AuctionId", DbType.Int32,AuctionId);

			dbw.ExecuteNonQuery(dbCommand);
		}


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(AuctionId)+1 from auActionProduct";

            object obj = dbr.ExecuteScalar(CommandType.Text, strsql);
            if (obj != null && obj != DBNull.Value)
            {
                return int.Parse(obj.ToString());
            }
            return 1;
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AuctionProductModel GetModel(int AuctionId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_auActionProduct_GetModel");
			dbr.AddInParameter(dbCommand, "AuctionId", DbType.Int32,AuctionId);

			AuctionProductModel model=null;
			using (IDataReader dataReader = dbr.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AuctionId,ProductName,SmallImage,MediumImage,OutLinkUrl,StartPrice,AddPrices,CurPrice,Brief,StartTime,EndTime,Status ");
			strSql.Append(" FROM auActionProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			return dbr.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "auActionProduct");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<AuctionProductModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AuctionId,ProductName,SmallImage,MediumImage,OutLinkUrl,StartPrice,AddPrices,CurPrice,Brief,StartTime,EndTime,Status ");
			strSql.Append(" FROM auActionProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<AuctionProductModel> list = new List<AuctionProductModel>();
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public AuctionProductModel ReaderBind(IDataReader dataReader)
		{
			AuctionProductModel model=new AuctionProductModel();
			object ojb; 
			ojb = dataReader["AuctionId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuctionId=(int)ojb;
			}
			model.ProductName=dataReader["ProductName"].ToString();
			model.SmallImage=dataReader["SmallIamge"].ToString();
			model.MediumImage=dataReader["MediumImage"].ToString();
			model.OutLinkUrl=dataReader["OutLinkUrl"].ToString();
			ojb = dataReader["StartPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StartPrice=(decimal)ojb;
			}
			ojb = dataReader["AddPrices"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddPrices=(decimal)ojb;
			}
			ojb = dataReader["CurPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CurPrice=(decimal)ojb;
			}
			model.Brief=dataReader["Brief"].ToString();
			ojb = dataReader["StartTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StartTime=(DateTime)ojb;
			}
			ojb = dataReader["EndTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EndTime=(DateTime)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  成员方法
	}
}

