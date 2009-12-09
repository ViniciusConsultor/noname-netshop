using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using NoName.NetShop.Common;

namespace NoName.NetShop.MagicWorld.DAL
{
    /// <summary>
    /// 数据访问类AuctionLogDal
    /// </summary>
    public class AuctionLogDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public AuctionLogDal()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(AuctionLogModel model)
		{
            DbCommand dbCommand = dbw.GetStoredProcCommand("UP_mwAuctionLog_ADD");
            dbw.AddInParameter(dbCommand, "logid", DbType.Int32, model.LogID);
            dbw.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionID);
            dbw.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
            dbw.AddInParameter(dbCommand, "AuctionTime", DbType.DateTime, model.AuctionTime);
            dbw.AddInParameter(dbCommand, "AutionPrice", DbType.Decimal, model.AutionPrice);
            dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(AuctionLogModel model)
		{
            DbCommand dbCommand = dbw.GetStoredProcCommand("UP_mwAuctionLog_Update");
            dbw.AddInParameter(dbCommand, "logid", DbType.Int32, model.LogID);
            dbw.AddInParameter(dbCommand, "AuctionId", DbType.Int32, model.AuctionID);
            dbw.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
            dbw.AddInParameter(dbCommand, "AuctionTime", DbType.DateTime, model.AuctionTime);
            dbw.AddInParameter(dbCommand, "AutionPrice", DbType.Decimal, model.AutionPrice);
            dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
            DbCommand dbCommand = dbw.GetStoredProcCommand("UP_mwAuctionLog_Delete");

            dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AuctionLogModel GetModel()
		{
            DbCommand dbCommand = dbr.GetStoredProcCommand("UP_mwAuctionLog_GetModel");

			AuctionLogModel model=null;
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
			strSql.Append("select logid,AuctionId,UserName,AuctionTime,AutionPrice ");
			strSql.Append(" FROM mwAuctionLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return dbr.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}


		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<AuctionLogModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select logid,AuctionId,UserName,AuctionTime,AutionPrice ");
			strSql.Append(" FROM mwAuctionLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<AuctionLogModel> list = new List<AuctionLogModel>();
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
		public AuctionLogModel ReaderBind(IDataReader dataReader)
		{
			AuctionLogModel model=new AuctionLogModel();
            object ojb;
            ojb = dataReader["logid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LogID = (int)ojb;
            }
			ojb = dataReader["AuctionId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuctionID=(int)ojb;
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
