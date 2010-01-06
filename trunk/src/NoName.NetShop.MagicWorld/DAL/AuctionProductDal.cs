using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.Model;
using System.Data;
using System.Data.Common;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace NoName.NetShop.MagicWorld.DAL
{
    public class AuctionProductDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public AuctionProductDal()
		{}
		#region  成员方法

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(AuctionProductModel model)
        {
            DbCommand dbCommand = dbw.GetStoredProcCommand("UP_mwAuctionProduct_ADD");

            dbw.AddInParameter(dbCommand, "@AuctionId", DbType.Int32, model.AuctionID);
            dbw.AddInParameter(dbCommand, "@ProductName", DbType.AnsiString, model.ProductName);
            dbw.AddInParameter(dbCommand, "@SmallImage", DbType.AnsiString, model.SmallImage);
            dbw.AddInParameter(dbCommand, "@MediumImage", DbType.AnsiString, model.MediumImage);
            dbw.AddInParameter(dbCommand, "@OutLinkUrl", DbType.AnsiString, model.OutLinkUrl);
            dbw.AddInParameter(dbCommand, "@StartPrice", DbType.Decimal, model.StartPrice);
            dbw.AddInParameter(dbCommand, "@AddPrices", DbType.String, model.AddPrices);
            dbw.AddInParameter(dbCommand, "@CurPrice", DbType.Decimal, model.CurPrice);
            dbw.AddInParameter(dbCommand, "@Brief", DbType.AnsiString, model.Brief);
            dbw.AddInParameter(dbCommand, "@StartTime", DbType.DateTime, model.StartTime);
            dbw.AddInParameter(dbCommand, "@EndTime", DbType.DateTime, model.EndTime);
            dbw.AddInParameter(dbCommand, "@Status", DbType.Byte, model.Status);
            dbw.AddInParameter(dbCommand, "@CateID", DbType.Int32, model.CategoryID);
            dbw.AddInParameter(dbCommand, "@CatePath", DbType.String, model.CategoryPath);
            dbw.AddInParameter(dbCommand, "@userid", DbType.String, model.UserID);
            dbw.AddInParameter(dbCommand, "@truename", DbType.String, model.TrueName);
            dbw.AddInParameter(dbCommand, "@phone", DbType.String, model.Phone);
            dbw.AddInParameter(dbCommand, "@cellphone", DbType.String, model.CellPhone);
            dbw.AddInParameter(dbCommand, "@postcode", DbType.String, model.PostCode);
            dbw.AddInParameter(dbCommand, "@region", DbType.String, model.Region);
            dbw.AddInParameter(dbCommand, "@address", DbType.String, model.Address);
            dbw.AddInParameter(dbCommand, "@inserttime", DbType.String, model.InsertTime);
            dbw.AddInParameter(dbCommand, "@updatetime", DbType.String, model.UpdateTime);

            dbw.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int AuctionId)
        {

            DbCommand dbCommand = dbw.GetStoredProcCommand("UP_mwAuctionProduct_Delete");
            dbw.AddInParameter(dbCommand, "AuctionId", DbType.Int32, AuctionId);

            dbw.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(AuctionProductModel model)
        {
            DbCommand dbCommand = dbw.GetStoredProcCommand("UP_mwAuctionProduct_Update");

            dbw.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionID);
            dbw.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
            dbw.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
            dbw.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
            dbw.AddInParameter(dbCommand, "OutLinkUrl", DbType.AnsiString, model.OutLinkUrl);
            dbw.AddInParameter(dbCommand, "StartPrice", DbType.Decimal, model.StartPrice);
            dbw.AddInParameter(dbCommand, "AddPrices", DbType.String, model.AddPrices);
            dbw.AddInParameter(dbCommand, "CurPrice", DbType.Decimal, model.CurPrice);
            dbw.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
            dbw.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
            dbw.AddInParameter(dbCommand, "EndTime", DbType.DateTime, model.EndTime);
            dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            dbw.AddInParameter(dbCommand, "@CateID", DbType.Int32, model.CategoryID);
            dbw.AddInParameter(dbCommand, "@CatePath", DbType.String, model.CategoryPath);
            dbw.AddInParameter(dbCommand, "@userid", DbType.String, model.UserID);
            dbw.AddInParameter(dbCommand, "@truename", DbType.String, model.TrueName);
            dbw.AddInParameter(dbCommand, "@phone", DbType.String, model.Phone);
            dbw.AddInParameter(dbCommand, "@cellphone", DbType.String, model.CellPhone);
            dbw.AddInParameter(dbCommand, "@postcode", DbType.String, model.PostCode);
            dbw.AddInParameter(dbCommand, "@region", DbType.String, model.Region);
            dbw.AddInParameter(dbCommand, "@address", DbType.String, model.Address);
            dbw.AddInParameter(dbCommand, "@inserttime", DbType.String, model.InsertTime);
            dbw.AddInParameter(dbCommand, "@updatetime", DbType.String, model.UpdateTime);

            dbw.ExecuteNonQuery(dbCommand);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AuctionId)
		{			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_mwAuctionProduct_Exists");
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

        public void UpdateStatus(int AuctionId, int Status)
        {
            string sql = "update mwAuctionProduct set status={0} where auctionid={1}";
            sql = String.Format(sql,Status,AuctionId);
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(AuctionId)+1 from mwAuctionProduct";

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
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_mwAuctionProduct_GetModel");
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
			strSql.Append("select * ");
			strSql.Append(" FROM mwAuctionProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			return dbr.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<AuctionProductModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM mwAuctionProduct ");
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
				model.AuctionID=(int)ojb;
			}
			model.ProductName=dataReader["ProductName"].ToString();
			model.SmallImage=dataReader["SmallImage"].ToString();
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
				model.AddPrices=ojb.ToString();
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
            ojb = dataReader["cateid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CategoryID = Convert.ToInt32(ojb);
            }
            ojb = dataReader["catepath"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CategoryPath = Convert.ToString(ojb);
            }

            model.UserID = Convert.ToString(dataReader["userid"]);
            model.TrueName = Convert.ToString(dataReader["truename"]);
            model.Phone = Convert.ToString(dataReader["phone"]);
            model.CellPhone = Convert.ToString(dataReader["cellphone"]);
            model.PostCode = Convert.ToString(dataReader["postcode"]);
            model.Region = Convert.ToString(dataReader["region"]);
            model.Address = Convert.ToString(dataReader["address"]);
            model.InsertTime = Convert.ToDateTime(dataReader["inserttime"]);
            model.UpdateTime = Convert.ToDateTime(dataReader["updatetime"]);
			return model;
		}

		#endregion  成员方法
    }
}
