﻿using System;
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

        public DataTable GetProductSpecificationList(int ProductID,int CategoryID)
        {
            string sql = @" select cp.paraid,cp.cateid,cp.paraname,pp.productid,pp.paravalue from pdcategorypara cp
	                            inner join pdproductpara pp on pp.paraid=cp.paraid
                            where cp.paratype=2 and cp.status=1 and pp.productid={0} and cp.cateid={1}";

            return db.ExecuteDataSet(CommandType.Text, String.Format(sql, ProductID, CategoryID)).Tables[0];
        }
    }
}
