using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using NoName.NetShop.Common;

namespace NoName.NetShop.ShopFlow
{
    public class OrderInfo
    {
        public static DataTable GetOrderItem(string orderId)
        {
            string sql = "spOrder_GetOrderItems";
            DbCommand comm = Common.DBFactory.DbReader.GetStoredProcCommand(sql);
            DBFactory.DbReader.AddInParameter(comm, "OrderId", DbType.String, orderId);
            return DBFactory.DbReader.ExecuteDataSet(comm).Tables[0];
        }

        public static DataTable GetGiftOrderItem(string orderId)
        {
            string sql = "spGiftOrder_GetOrderItems";
            DbCommand comm = Common.DBFactory.DbReader.GetStoredProcCommand(sql);
            DBFactory.DbReader.AddInParameter(comm, "OrderId", DbType.String, orderId);
            return DBFactory.DbReader.ExecuteDataSet(comm).Tables[0];
        }
    }
}
