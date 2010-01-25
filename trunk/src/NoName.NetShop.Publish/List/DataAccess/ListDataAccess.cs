using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using NoName.NetShop.Common;
using System.Collections;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.BLL;

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
            string sql = "select c1.cateid,c1.catename,c1.catepath,c2.catepath as fatherpath from pdcategory c1 left join pdcategory c2 on c1.parentid=c2.cateid where c1.cateid={0}";
            sql = String.Format(sql, CategoryID);

            DataRow row = null;
            DataTable dt = db.ExecuteDataSet(CommandType.Text,sql).Tables[0];
            if(dt.Rows.Count>0) row = dt.Rows[0];
            return row;
        }

        public DataTable GetProductList(int CategoryID, int PageIndex,Hashtable Parameters, out int RecordCount, out int PageCount)
        {
            string where = String.Empty; 
            int i = 0;

            if(Parameters!=null)
                foreach (string key in Parameters.Keys)
                {
                    CategoryParaModel para = new CategoryParaModelBll().GetModel(Convert.ToInt32(key), CategoryID);
                    if (i == Parameters.Count - 1) where += String.Format(" and (pdproductpara.paraid = {0} and pdproductpara.paravalue like '%{1}%') ", key, para.ParaValues.Split(',')[Convert.ToInt32(Parameters[key])]);
                    else where += String.Format(" and (pdproductpara.paraid = {0} and pdproductpara.paravalue like '%{1}%') or ", key, para.ParaValues.Split(',')[Convert.ToInt32(Parameters[key])]);
                    i++;
                }

            string CategoryPath = Convert.ToString(GetCategoryInfo(CategoryID)["catepath"]);
            where += String.Format(" and pdproduct.catepath like '{0}%'", CategoryPath);
            
            SearchPageInfo pageInfo = new SearchPageInfo();

            pageInfo.TableName = "pdproductpara";
            pageInfo.PriKeyName = "productid";
            pageInfo.FieldNames = "pdproduct.productid,paraid,paravalue,productname,pdcategory.cateid,pdcategory.catepath,tradeprice,merchantprice,reduceprice,stock,smallimage,mediumimage,largeimage,keywords,brief,pageview,inserttime,changetime,pdproduct.status,score";
            pageInfo.TotalFieldStr = "";
            pageInfo.PageSize = Config.ListPageSize;
            pageInfo.PageIndex = PageIndex;
            pageInfo.OrderType = "";
            pageInfo.StrWhere = "1=1 " + where;
            pageInfo.StrJoin = " inner join pdproduct on pdproduct.productid=pdproductpara.productid inner join pdcategory on pdproduct.cateid=pdcategory.cateid ";

            DataTable dt = CommDataHelper.GetDataFromMultiTablesByPage(pageInfo).Tables[0];
            RecordCount = pageInfo.TotalItem;
            PageCount = pageInfo.TotalPage;

            return dt;
        }

        public DataTable GetProductList(int CategoryID, int PageIndex,out int RecordCount,out int PageCount)
        {
            SearchPageInfo pageinfo = new SearchPageInfo();

            string CategoryPath = Convert.ToString(GetCategoryInfo(CategoryID)["catepath"]);

            string where = String.Format(" catepath like '{0}%'", CategoryPath);

            pageinfo.FieldNames = "[ProductId],[ProductName],[ProductCode],[CatePath],[CateId],[TradePrice],[MerchantPrice],[ReducePrice],[Stock],[SmallImage],[MediumImage],[LargeImage],[Keywords],[Brief],[PageView],[InsertTime],[ChangeTime],[Status],[SortValue],[Score]";
            pageinfo.OrderType = "SortValue asc";
            pageinfo.PageIndex = PageIndex;
            pageinfo.PageSize = Config.ListPageSize;
            pageinfo.PriKeyName = "ProductId";
            pageinfo.StrWhere = where;
            pageinfo.TableName = "pdproduct";
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

        
    }
}
