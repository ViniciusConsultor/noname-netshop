using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace NoName.NetShop.Publish.Brand.DataAccess
{
    public class BrandDataAccess
    {
        private BrandConfigurationSection Config;
        private Database db;

        public BrandDataAccess(BrandConfigurationSection config)
        {
            Config = config;
            db = DatabaseFactory.CreateDatabase(config.Database); 
        }

        public DataTable GetBrandInfo(int BrandID)
        {
            string sql = "select * from pdbrand where brandid="+BrandID;
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public DataTable GetBrandProductList(int PageIndex, int BrandID, int CategoryID, int OrderType, out int RecordCount)
        {
            string OrderString = GetOrderString(OrderType);
            string ConditionString = "brandid="+BrandID;

            if (CategoryID != 0)
            {
                string CategoryPath = Convert.ToString(db.ExecuteScalar(CommandType.Text, "select catepath from pdcategory where cateid=" + CategoryID));
                ConditionString += " and catepath+'/' like '" + CategoryPath + "%'"; 
            }

            int PageLowerBound = (PageIndex - 1) * Config.ListPageSize;
            int PageUpperBount = PageLowerBound + Config.ListPageSize;

            string sqlCount = @"select count(0) from pdproduct where {0}";

            string sqlData = @" select * from 
                                    ( select row_number() over(order by {0}) as nid,* from pdproduct where {1} ) as sp
                                where sp.nid>{2} and sp.nid<={3}";

            RecordCount = Convert.ToInt32(db.ExecuteScalar(CommandType.Text, String.Format(sqlCount, ConditionString)));
            return db.ExecuteDataSet(CommandType.Text, String.Format(sqlData, OrderString, ConditionString, PageLowerBound, PageUpperBount)).Tables[0];
        }

        public DataTable GetBrandHotSaleProductList(int BrandID)
        {
            string sql = @" select * from pdsalesproduct ps
	                            inner join pdproduct p on ps.productid=p.productid
                            where ps.saletype=1 and ps.siteid=0 and p.brandid={0}";
            sql = String.Format(sql, BrandID);

            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
        }

        public DataTable GetBrandCategoryList(int BrandID)
        {
            string sql = @" select distinct bc.cateid,c.catename from pdbrandcategoryrelation bc
	                            inner join pdcategory c on c.cateid=bc.cateid
                            where c.catelevel=3 and bc.brandid={0} and dbo.BrandCategoryExistsProduct(bc.brandid,c.cateid)=1";
            sql = String.Format(sql, BrandID);

            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
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