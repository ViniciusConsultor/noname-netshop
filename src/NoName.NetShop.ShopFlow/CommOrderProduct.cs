using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Collections.Specialized;
using NoName.NetShop.Common;

namespace NoName.NetShop.ShopFlow
{
    public class CommOrderProduct: OrderProduct
    {
        public override OrderProduct CreateOrderProduct(int productId, int quantity, OrderType opType, System.Collections.Specialized.NameValueCollection paras)
        {
            CommOrderProduct op = null;
            string sql = "Product_GetOrderProduct_Common";
            DbCommand comm = CommDataAccess.DbReader.GetStoredProcCommand(sql);
            CommDataAccess.DbReader.AddInParameter(comm, "ProductId", DbType.Int32, productId);
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
            return String.Format("{0}-{1}-{2}@{3}", _productid,(int)this.ProductType, _quantity,_typeCode);
        }

        public override System.Collections.Specialized.NameValueCollection GetParasFromCookieValue(string[] paras)
        {
            NameValueCollection nv = new NameValueCollection();
            if (paras.Length>0)
            {
                nv.Add("typecode",paras[0]);
            }
            else
            {
                nv.Add("typecode",string.Empty);
            }
            return nv;
        }

        internal override void Save()
        {
            string sql = "orderItem_save_Comm";
            DbCommand comm = CommDataAccess.DbWriter.GetStoredProcCommand(sql);
            CommDataAccess.DbWriter.AddInParameter(comm,"orderId",DbType.String,OrderId );
            CommDataAccess.DbWriter.AddInParameter(comm,"productid",DbType.Int32, this.ProductID);
            CommDataAccess.DbWriter.AddInParameter(comm, "typecode", DbType.Int32, this.TypeCode);
            CommDataAccess.DbWriter.AddInParameter(comm, "typeinfo", DbType.Int32, this.TypeInfo);

            CommDataAccess.DbWriter.AddInParameter(comm, "quantity", DbType.Int32, this.Quantity);
            CommDataAccess.DbWriter.AddInParameter(comm, "productsum", DbType.Decimal, this.ProductSum);
            CommDataAccess.DbWriter.AddInParameter(comm, "score", DbType.Int32, this.TotalScore);

            CommDataAccess.DbWriter.AddInParameter(comm, "factprice", DbType.Decimal, this.FactPrice);
            CommDataAccess.DbWriter.AddInParameter(comm, "tradeprice", DbType.Decimal, this.TradePrice);
            CommDataAccess.DbWriter.AddInParameter(comm, "merchantprice", DbType.Decimal, this.MerchantPrice);
            CommDataAccess.DbWriter.AddInParameter(comm, "reduceprice", DbType.Decimal, this.ReducePrice);

            CommDataAccess.DbWriter.ExecuteNonQuery(comm);
        }

        private CommOrderProduct BuildModel(IDataReader reader)
        {
            CommOrderProduct op = new CommOrderProduct();
            op.ProductID = Convert.ToInt32(reader["productId"]);
            op.ProductName = reader["productName"].ToString();
            op.ProductUrl = reader["producturl"].ToString();
            op.ProductImg = reader["productimg"].ToString();
            op.CatePath = reader["CatePath"].ToString();
            op.TradePrice = Convert.ToDecimal(reader["TradePrice"]);
            op.MerchantPrice = Convert.ToDecimal(reader["MerchantPrice"]);
            op.Stock = Convert.ToInt32(reader["Stock"]);
            op.ReducePrice = Convert.ToDecimal(reader["ReducePrice"]);
            op.Score = Convert.ToInt32(reader["Score"]);
            return op;
        }

    }
}
