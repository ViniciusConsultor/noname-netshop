using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;
using NoName.NetShop.Product.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace NoName.NetShop.Product.DAL
{
    public class ProductNewsDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(ProductNewsModel model)
        {
            string sql = "insert into [pdproductnews] ([productid],[newsid]) values ({0},{1})";
            sql = String.Format(sql, model.ProdutID, model.NewsID);
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        public void Update(ProductNewsModel model)
        {
            string sql = "update [pdproductnews] set [newsid]={0} where [productid]={1}";
            sql = String.Format(sql, model.ProdutID, model.NewsID);
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        public void Delete(ProductNewsModel model)
        {
            string sql = "delete from [pdproductnews] where [productid]={0} and [newsid]={1}";
            sql = String.Format(sql, model.ProdutID, model.NewsID);
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        public bool Exists(int ProductID)
        {
            string sql = "select count(0) from [pdproductnews] where [productid]={0}";
            sql = String.Format(sql, ProductID);
            return Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text, sql)) == 1;
        }

        public ProductNewsModel GetModel(int ProductID)
        {
            string sql = "select * from [pdproductnews] where [productid]={0}";
            sql = String.Format(sql, ProductID);
            ProductNewsModel model = null;
            DataTable dt = dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model = new ProductNewsModel() { ProdutID = Convert.ToInt32(dt.Rows[0]["productid"]), NewsID = Convert.ToInt32(dt.Rows[0]["newsid"]) };
            }
            return model;
        }
    }
}
