﻿using System;
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
            DbCommand comm = DBFacotry.DbReader.GetStoredProcCommand(sql);
            DBFacotry.DbReader.AddInParameter(comm, "ProductId", DbType.Int32, productId);
            using (IDataReader reader = DBFacotry.DbReader.ExecuteReader(comm))
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
            DbCommand comm = DBFacotry.DbWriter.GetStoredProcCommand(sql);
            DBFacotry.DbWriter.AddInParameter(comm,"orderId",DbType.String,OrderId );
            DBFacotry.DbWriter.AddInParameter(comm,"productid",DbType.Int32, this.ProductID);
            DBFacotry.DbWriter.AddInParameter(comm, "typecode", DbType.Int32, this.TypeCode);
            DBFacotry.DbWriter.AddInParameter(comm, "typeinfo", DbType.Int32, this.TypeInfo);

            DBFacotry.DbWriter.AddInParameter(comm, "quantity", DbType.Int32, this.Quantity);
            DBFacotry.DbWriter.AddInParameter(comm, "productsum", DbType.Decimal, this.ProductSum);
            DBFacotry.DbWriter.AddInParameter(comm, "score", DbType.Int32, this.TotalScore);

            DBFacotry.DbWriter.AddInParameter(comm, "factprice", DbType.Decimal, this.FactPrice);
            DBFacotry.DbWriter.AddInParameter(comm, "tradeprice", DbType.Decimal, this.TradePrice);
            DBFacotry.DbWriter.AddInParameter(comm, "merchantprice", DbType.Decimal, this.MerchantPrice);
            DBFacotry.DbWriter.AddInParameter(comm, "reduceprice", DbType.Decimal, this.ReducePrice);

            DBFacotry.DbWriter.ExecuteNonQuery(comm);
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
