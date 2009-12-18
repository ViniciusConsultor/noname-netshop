using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.ShopFlow
{
    public class OrderChangeLogDal
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(OrderChangeLogModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into spOrderChangeLog(");
            strSql.Append("OrderId,ChangeTime,Remark,Operator,actinfo)");
            strSql.Append(" values (@OrderId,getdate(),@Remark,@Operator,@actinfo)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrderId", DbType.AnsiString, model.OrderId);
            db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
            db.AddInParameter(dbCommand, "Operator", DbType.AnsiString, model.Operator);
            db.AddInParameter(dbCommand, "actinfo", DbType.AnsiString, model.ActInfo);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<OrderChangeLogModel> GetOrderLogs(string orderId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OrderId,ChangeTime,Remark,Operator,actinfo ");
			strSql.Append(" FROM spOrderChangeLog where orderId=@orderId");

			List<OrderChangeLogModel> list = new List<OrderChangeLogModel>();
            Database db = NoName.NetShop.Common.DBFacotry.DbReader;
            DbCommand comm = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(comm, "orderId", DbType.String, orderId);

			using (IDataReader dataReader = db.ExecuteReader(comm))
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
		private OrderChangeLogModel ReaderBind(IDataReader dataReader)
		{
			OrderChangeLogModel model=new OrderChangeLogModel();
			object ojb; 
			model.OrderId=dataReader["OrderId"].ToString();
			ojb = dataReader["ChangeTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ChangeTime=(DateTime)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			model.Operator=dataReader["Operator"].ToString();
            model.ActInfo = dataReader["actinfo"].ToString();
			return model;
		}

    }
}
