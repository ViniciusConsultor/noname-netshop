using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Auction.Model;

namespace NoName.NetShop.Auction.DAL
{
	/// <summary>
	/// 数据访问类ActionProductModelDal。
	/// </summary>
	public class AuctionProductModelDal
	{
		public AuctionProductModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(AuctionId)+1 from auActionProduct";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AuctionId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auActionProduct_Exists");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32,AuctionId);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
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
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auActionProduct_ADD");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionId);
			db.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
			db.AddInParameter(dbCommand, "SmallIamge", DbType.AnsiString, model.SmallImage);
			db.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			db.AddInParameter(dbCommand, "OutLinkUrl", DbType.AnsiString, model.OutLinkUrl);
			db.AddInParameter(dbCommand, "StartPrice", DbType.Decimal, model.StartPrice);
			db.AddInParameter(dbCommand, "AddPrices", DbType.Decimal, model.AddPrices);
			db.AddInParameter(dbCommand, "CurPrice", DbType.Decimal, model.CurPrice);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			db.AddInParameter(dbCommand, "EndTime", DbType.DateTime, model.EndTime);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(AuctionProductModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auActionProduct_Update");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionId);
			db.AddInParameter(dbCommand, "ProductName", DbType.AnsiString, model.ProductName);
			db.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			db.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			db.AddInParameter(dbCommand, "OutLinkUrl", DbType.AnsiString, model.OutLinkUrl);
			db.AddInParameter(dbCommand, "StartPrice", DbType.Decimal, model.StartPrice);
			db.AddInParameter(dbCommand, "AddPrices", DbType.Decimal, model.AddPrices);
			db.AddInParameter(dbCommand, "CurPrice", DbType.Decimal, model.CurPrice);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			db.AddInParameter(dbCommand, "EndTime", DbType.DateTime, model.EndTime);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AuctionId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auActionProduct_Delete");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32,AuctionId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AuctionProductModel GetModel(int AuctionId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auActionProduct_GetModel");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32,AuctionId);

			AuctionProductModel model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
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
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
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
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
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

