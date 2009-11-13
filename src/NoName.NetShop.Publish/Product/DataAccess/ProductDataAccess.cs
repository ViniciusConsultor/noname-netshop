using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace NoName.NetShop.Publish.Product.DataAccess
{
    public class ProductDataAccess
    {
        private ProductConfigurationSection Config;
        private Database db;

        public ProductDataAccess(ProductConfigurationSection config)
        {
            Config = config;
            db = DatabaseFactory.CreateDatabase(config.Database);
        }

        public DataTable GetProductCategoryPath(int ProductID)
        {
            string sql = "select cateid,catepath from pdproduct where productid={0}";
            sql = String.Format(sql,ProductID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public DataTable GetProductInfo(int ProductID)
        {
            string sql = "select * from pdproduct where productid={0}";
            sql = String.Format(sql, ProductID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];           
        }

        public DataTable GetCategoryPathList(string CategoryPath)
        {
            string sql = String.Format("select * from pdcategory where cateid in ({0}) order by catelevel", CategoryPath.Substring(0, CategoryPath.Length - 1).Replace("/", ","));
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }
    }
}
