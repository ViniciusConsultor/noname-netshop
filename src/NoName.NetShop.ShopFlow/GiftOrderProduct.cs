using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.ShopFlow
{
    public class GiftOrderProduct:OrderProduct
    {
        public override OrderProduct CreateOrderProduct(int productId, int quantity, OrderType opType, System.Collections.Specialized.NameValueCollection paras)
        {
            GiftOrderProduct op = null;
            string sql = "SELECT productId,productName,Stock,SmallImage,Status,Score FROM pdGift where status=1 and stock>0 and productid=@productid";
            DbCommand comm = CommDataAccess.DbReader.GetSqlStringCommand(sql);
            CommDataAccess.DbReader.AddInParameter(comm, "productId", DbType.Int32, productId);
            using (IDataReader reader = CommDataAccess.DbReader.ExecuteReader(comm))
            {
                if (reader.Read())
                {
                    op = BuildModel(reader);
                    op.SetQuantiy(quantity);
                    op.ProductType = opType;
                    int typecode;
                    if (int.TryParse(paras["typecode"], out typecode))
                    {
                        typecode = 0;
                    }
                    op.TypeCode = typecode;
                }
            }
            return op;
        }

        public override string BuildCookieValue()
        {
            return String.Empty;
        }

        public override System.Collections.Specialized.NameValueCollection GetParasFromCookieValue(string[] paras)
        {
            return null;
        }

        internal override void Save()
        {
            string sql = "INSERT INTO spGiftOrderitem (OrderId,ProductId,Quantity,Score,TotalScore) VALUES (@OrderId,@ProductId,@Quantity,@Score,@TotalScore)";
            DbCommand comm = CommDataAccess.DbWriter.GetSqlStringCommand(sql);
            CommDataAccess.DbWriter.AddInParameter(comm, "orderId", DbType.String, OrderId);
            CommDataAccess.DbWriter.AddInParameter(comm, "productid", DbType.Int32, this.ProductID);
            CommDataAccess.DbWriter.AddInParameter(comm, "quantity", DbType.Int32, this.Quantity);
            CommDataAccess.DbWriter.AddInParameter(comm, "score", DbType.Int32, this.Score);
            CommDataAccess.DbWriter.AddInParameter(comm, "TotalScore", DbType.Int32, this.TotalScore);
            CommDataAccess.DbWriter.ExecuteNonQuery(comm);
        }

        private GiftOrderProduct BuildModel(IDataReader reader)
        {
            GiftOrderProduct op = new GiftOrderProduct();
            op.ProductID = Convert.ToInt32(reader["productId"]);
            op.ProductName = reader["productName"].ToString();
            op.ProductUrl = String.Empty;
            op.ProductImg = reader["SmallImage"].ToString();
            op.CatePath = String.Empty;
            op.TradePrice = 0m;
            op.MerchantPrice = 0m;
            op.Stock = Convert.ToInt32(reader["Stock"]);
            op.ReducePrice = 0m;
            op.Score = Convert.ToInt32(reader["Score"]);
            op.Weight = 0m;
            return op;
        }
    }
}
