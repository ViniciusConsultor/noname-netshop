using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;


namespace NoName.NetShop.ShopFlow
{
    public class CommOrderItemDal
    {
        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<CommOrderItemModel> GetOrderItems(string orderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.OrderId,a.ProductId,b.productname,a.TypeCode,a.Quantity,a.ProductSum,a.TypeInfo,a.Score,a.FactPrice,a.MerchantPrice,a.TradePrice,a.ReducePrice ");
            strSql.Append(" FROM spOrderItem as a join pdProduct as b on a.productid=b.productid where orderId=@orderId");

            List<CommOrderItemModel> list = new List<CommOrderItemModel>();
            Database db = NoName.NetShop.Common.DBFactory.DbReader;
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
        public CommOrderItemModel ReaderBind(IDataReader dataReader)
        {
            CommOrderItemModel model = new CommOrderItemModel();
            object ojb;
            model.OrderId = dataReader["OrderId"].ToString();
            ojb = dataReader["ProductId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductId = (int)ojb;
            }
            ojb = dataReader["TypeCode"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TypeCode = (int)ojb;
            }
            ojb = dataReader["Quantity"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Quantity = (int)ojb;
            }
            ojb = dataReader["ProductSum"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ProductSum = (decimal)ojb;
            }
            model.TypeInfo = dataReader["TypeInfo"].ToString();
            ojb = dataReader["Score"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Score = (int)ojb;
            }
            ojb = dataReader["FactPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.FactPrice = (decimal)ojb;
            }
            ojb = dataReader["MerchantPrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.MerchantPrice = (decimal)ojb;
            }
            ojb = dataReader["TradePrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TradePrice = (decimal)ojb;
            }
            ojb = dataReader["ReducePrice"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ReducePrice = (decimal)ojb;
            }
            model.ProductName = dataReader["productname"].ToString();
            return model;
        }

    }
}
