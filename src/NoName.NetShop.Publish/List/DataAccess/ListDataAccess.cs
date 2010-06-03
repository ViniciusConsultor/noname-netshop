﻿using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using NoName.NetShop.Common;
using System.Collections;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.BLL;
using System.Data.Common;

namespace NoName.NetShop.Publish.List.DataAccess
{
    public class ListDataAccess
    {
        private ListConfigurationSection Config;
        private Database db;

        public ListDataAccess(ListConfigurationSection config)
        {
            Config = config;
            db = DatabaseFactory.CreateDatabase(config.Database); 
        }

        public DataRow GetCategoryInfo(int CategoryID)
        {
            string sql = "select c1.cateid,c1.catename,c1.catepath,c1.searchpricerange,c2.catepath as fatherpath from pdcategory c1 left join pdcategory c2 on c1.parentid=c2.cateid where c1.cateid={0}";
            sql = String.Format(sql, CategoryID);

            DataRow row = null;
            DataTable dt = db.ExecuteDataSet(CommandType.Text,sql).Tables[0];
            if(dt.Rows.Count>0) row = dt.Rows[0];
            return row;
        }

        public DataTable GetProductList(int CategoryID, int PageIndex,int BrandID,decimal[] PriceRange,int OrderType,Hashtable Parameters, out int RecordCount, out int PageCount)
        {
            string where = String.Empty;

            int i = 0;

            if(Parameters!=null)
                foreach (string key in Parameters.Keys)
                {
                    CategoryParaModel para = new CategoryParaModelBll().GetModel(Convert.ToInt32(key), CategoryID);
                    if (i == Parameters.Count - 1) where += String.Format(" and (pdproductpara.paraid = {0} and pdproductpara.paravalue like '%{1}%') ", key, para.ParaValues.Split(',')[Convert.ToInt32(Parameters[key])]);
                    else where += String.Format(" and (pdproductpara.paraid = {0} and pdproductpara.paravalue like '%{1}%') ", key, para.ParaValues.Split(',')[Convert.ToInt32(Parameters[key])]);
                    i++;
                }
            if (BrandID != 0)
                where += " and pdproduct.brandid=" + BrandID;
            if (PriceRange != null && PriceRange.Length == 2)
                where += String.Format(" and pdproduct.merchantprice >= {0} and pdproduct.merchantprice <= {1}", PriceRange[0], PriceRange[1] + 0.99M);

            string CategoryPath = Convert.ToString(GetCategoryInfo(CategoryID)["catepath"]);
            where += String.Format(" and pdproduct.catepath like '{0}%'", CategoryPath);
            where += " and pdproduct.status = 1";
            
            SearchPageInfo pageInfo = new SearchPageInfo();

            pageInfo.TableName = "pdproductpara";
            pageInfo.PriKeyName = "productid";
            pageInfo.FieldNames = "pdproduct.productid,paraid,paravalue,productname,pdcategory.cateid,pdcategory.catepath,tradeprice,merchantprice,reduceprice,stock,smallimage,mediumimage,largeimage,keywords,brief,pageview,inserttime,changetime,pdproduct.status,score";
            pageInfo.TotalFieldStr = "";
            pageInfo.PageSize = Config.ListPageSize;
            pageInfo.PageIndex = PageIndex;
            pageInfo.OrderType = GetOrderString(OrderType);
            pageInfo.StrWhere = "1=1 " + where;
            pageInfo.StrJoin = " inner join pdproduct on pdproduct.productid=pdproductpara.productid inner join pdcategory on pdproduct.cateid=pdcategory.cateid ";

            DataTable dt = CommDataHelper.GetDataFromMultiTablesByPage(pageInfo).Tables[0];
            RecordCount = pageInfo.TotalItem;
            PageCount = pageInfo.TotalPage;

            return dt;
        }

        public DataTable GetProductList(int CategoryID, int PageIndex, int BrandID, decimal[] PriceRange, int OrderType, out int RecordCount, out int PageCount)
        {
            SearchPageInfo pageinfo = new SearchPageInfo();

            string CategoryPath = Convert.ToString(GetCategoryInfo(CategoryID)["catepath"]);

            string where = String.Format(" catepath like '{0}%'", CategoryPath);
            where += " and status = " + (int)ProductStatus.上架;

            if (BrandID != 0)
                where += " and pdproduct.brandid=" + BrandID;
            if (PriceRange != null && PriceRange.Length == 2)
                where += String.Format(" and pdproduct.merchantprice >= {0} and pdproduct.merchantprice <= {1}", PriceRange[0], PriceRange[1] + 0.99M);


            pageinfo.FieldNames = "[ProductId],[ProductName],[ProductCode],[CatePath],[CateId],[TradePrice],[MerchantPrice],[ReducePrice],[Stock],[SmallImage],[MediumImage],[LargeImage],[Keywords],[Brief],[PageView],[InsertTime],[ChangeTime],[Status],[SortValue],[Score]";
            pageinfo.OrderType = "SortValue asc";
            pageinfo.PageIndex = PageIndex;
            pageinfo.PageSize = Config.ListPageSize;
            pageinfo.PriKeyName = "ProductId";
            pageinfo.StrWhere = where;
            pageinfo.TableName = "pdproduct";
            pageinfo.OrderType = GetOrderString(OrderType);
            pageinfo.TotalFieldStr = "";
            pageinfo.TotalItem = 0;
            pageinfo.TotalPage = 0;

            DataTable dt = CommDataHelper.GetDataFromSingleTableByPage(pageinfo).Tables[0];
            RecordCount = pageinfo.TotalItem;
            PageCount = pageinfo.TotalPage;

            return dt;
        }

        public DataTable GetCategoryPathList(int CategoryID)
        {
            DataRow CategoryInfo = GetCategoryInfo(CategoryID);

            DataTable dt = new DataTable();

            if (CategoryInfo != null)
            {
                string CategoryPath = CategoryInfo["catepath"].ToString();
                string sql = String.Format("select * from pdcategory where cateid in ({0}) order by catelevel", CategoryPath.Substring(0, CategoryPath.Length - 1).Replace("/", ","));
                dt = db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
            }

            return dt;
        }

        public DataTable GetCategoryBrotherList(int CategoryID)
        {
            string sql = "select * from pdcategory where parentid=(select parentid from pdcategory where cateid={0})";
            sql = String.Format(sql, CategoryID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
        }


        public DataTable GetCategoryFatherList(int CategoryID)
        {            
            string sql = "select * from pdcategory where parentid=(select top 1 parentid from pdcategory where cateid=(select parentid from pdcategory where cateid={0}))";
            sql = String.Format(sql, CategoryID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
        }

        public DataTable GetRootCategoryList()
        {
            string sql = "select * from pdcategory where parentid=0";
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
        }

        public DataTable GetCategorySonList(int CategoryID)
        {
            string sql = String.Format("select * from pdcategory where parentid={0}", CategoryID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
        }

        public DataTable GetCategoryProperityList(int CategoryID)
        {
            string sql = String.Format("select * from pdcategorypara where cateid="+CategoryID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public DataTable GetCategoryBrand(int CategoryID)
        {
            return new BrandCategoryRelationBll().GetCategoryBrandList(CategoryID);
        }

        public DataTable GetHotSaleProduct(string CategoryPath)
        {
            string sql = @" select top 4 * FROM [pdProduct] p
	                            inner join [pdSalesProduct] sp on sp.productid=p.productid
                            where 
	                            sp.saletype=1 and 
	                            sp.siteid=0 and
	                            p.catepath like '" + CategoryPath + @"%'
                            order by sp.timestamp desc";

            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public DataTable GetBrandList(int CategoryID)
        {
            string sql = @" select distinct b.brandid,b.brandname from pdbrandcategoryrelation br
                                inner join pdbrand b on br.brandid = b.brandid
                            where br.cateid=@cateid";

            DbCommand Command = db.GetSqlStringCommand(sql);
            db.AddInParameter(Command, "@cateid", DbType.Int32, CategoryID);
            return db.ExecuteDataSet(Command).Tables[0];
        }

        private string GetOrderString(int OrderType)
        {
            string OrderString = String.Empty;
            switch (OrderType)
            {
                case 1:
                    OrderString = " changetime desc";
                    break;
                case 2:
                    OrderString = " changetime asc";
                    break;
                case 3:
                    OrderString = " pageview asc";
                    break;
                case 4:
                    OrderString = " pageview desc";
                    break;
                case 5:
                    OrderString = " merchantprice asc";
                    break;
                case 6:
                    OrderString = " merchantprice desc";
                    break;
                case 7:
                    OrderString = " pageview asc";
                    break;
                case 8:
                    OrderString = " pageview desc";
                    break;
                default:
                    break;
            }
            return OrderString;
        }
        
    }
}
