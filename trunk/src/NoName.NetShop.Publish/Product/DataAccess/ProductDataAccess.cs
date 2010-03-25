﻿using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using NoName.NetShop.Common;

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

        public DataTable GetSameBrandProduct(int ProductID)
        {
            string sql = "select top 10 * from pdproduct where brandid = (select brandid from pdproduct where productid={0})";
            return db.ExecuteDataSet(CommandType.Text, String.Format(sql, ProductID)).Tables[0];
        }

        public DataTable GetProductQuestionList(int ProductID)
        {
            string sql = @" select top 3 q.*,a.[content] as answercontent, a.answertime from qaquestion q
	                            left join qaanswer a on q.questionid=a.questionid
                            where q.contentid={0} and q.contenttype={1}";
            sql = String.Format(sql, ProductID, ContentType.Product);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public DataTable GetProductCommentList(int ProductID)
        {
            string sql = "select top 5 * from qacomment where apptype={0} and targetid={1}";
            sql = String.Format(sql,AppType.Product,ProductID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public DataTable GetProductTopicList(int ProductID)
        {
            string sql = "select top 3 * from qatopic where contenttype={0} and contentid={1}";
            sql = String.Format(sql, ContentType.Product, ProductID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
        }
    }
}
