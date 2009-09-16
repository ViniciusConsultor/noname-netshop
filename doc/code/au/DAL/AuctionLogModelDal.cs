using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using Maticsoft.DBUtility;//请先添加引用
namespace NoName.NetShop.DAL
{
	/// <summary>
	/// 数据访问类AuctionLogModelDal。
	/// </summary>
	public class AuctionLogModelDal
	{
		public AuctionLogModelDal()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.AuctionLogModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auAuctionLog_ADD");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionId);
			db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
			db.AddInParameter(dbCommand, "AuctionTime", DbType.DateTime, model.AuctionTime);
			db.AddInParameter(dbCommand, "AutionPrice", DbType.Decimal, model.AutionPrice);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.AuctionLogModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auAuctionLog_Update");
			db.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionId);
			db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
			db.AddInParameter(dbCommand, "AuctionTime", DbType.DateTime, model.AuctionTime);
			db.AddInParameter(dbCommand, "AutionPrice", DbType.Decimal, model.AutionPrice);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auAuctionLog_Delete");

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.AuctionLogModel GetModel()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_auAuctionLog_GetModel");

			NoName.NetShop.Model.AuctionLogModel model=null;
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
			strSql.Append("select AuctionId,UserName,AuctionTime,AutionPrice ");
			strSql.Append(" FROM auAuctionLog ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "auAuctionLog");
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
		public List<NoName.NetShop.Model.AuctionLogModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AuctionId,UserName,AuctionTime,AutionPrice ");
			strSql.Append(" FROM auAuctionLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.AuctionLogModel> list = new List<NoName.NetShop.Model.AuctionLogModel>();
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
		public NoName.NetShop.Model.AuctionLogModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.AuctionLogModel model=new NoName.NetShop.Model.AuctionLogModel();
			object ojb; 
			ojb = dataReader["AuctionId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuctionId=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			ojb = dataReader["AuctionTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuctionTime=(DateTime)ojb;
			}
			ojb = dataReader["AutionPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AutionPrice=(decimal)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

