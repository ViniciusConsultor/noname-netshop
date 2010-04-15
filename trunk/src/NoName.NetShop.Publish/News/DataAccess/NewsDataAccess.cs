using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using NoName.NetShop.Common;
using NoName.NetShop.Comment;

namespace NoName.NetShop.Publish.News.DataAccess
{
    public class NewsDataAccess
    {
        private NewsConfigurationSection Config;
        private Database db;

        public NewsDataAccess(NewsConfigurationSection config)
        {
            Config = config;
            db = DatabaseFactory.CreateDatabase(config.Database); 
        }

        public DataTable GetCategoryInfo(int CategoryID)
        {
            string sql = @" select cateid,parentid,dbo.GetNewsCategoryPath(cateid) as catepath 
                            from necategory 
                            where cateid={0} and ishide=0";
            sql = string.Format(sql, CategoryID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];  
        }

        public DataTable GetNewsCategoryInfo(int NewsID)
        {
            string sql = @" select n.newsid,c.cateid,c.parentid,dbo.GetNewsCategoryPath(c.cateid) as catepath from nenews n
                                inner join necategory c on n.cateid=c.cateid
                            where n.newsid={0} and c.ishide=0";
            sql = string.Format(sql,NewsID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
        }

        public DataTable GetNewsList(int PageIndex, int PageSize, int CategoryID, out int RecordCount,out int PageCount)
        {
            SearchPageInfo pageinfo = new SearchPageInfo();

            string where = String.Format(" dbo.GetNewsCategoryPath(cateid)+'/' like dbo.GetNewsCategoryPath({0})+'/%'", CategoryID);

            pageinfo.FieldNames = "*";
            pageinfo.OrderType = "newsid desc";
            pageinfo.PageIndex = PageIndex;
            pageinfo.PageSize = PageSize;
            pageinfo.PriKeyName = "newsid";
            pageinfo.StrWhere = where;
            pageinfo.TableName = "nenews";
            pageinfo.TotalFieldStr = "";
            pageinfo.TotalItem = 0;
            pageinfo.TotalPage = 0;

            DataTable dt = CommDataHelper.GetDataFromSingleTableByPage(pageinfo).Tables[0];
            RecordCount = pageinfo.TotalItem;
            PageCount = pageinfo.TotalPage;

            return dt;
        }

        public DataTable GetNewDetail(int NewsID)
        {
            string sql = @" select c.cateid,c.catename,n.newsid,n.title,n.subtitle,n.brief,n.newscontent,n.smallimageurl,n.author,n.newsfrom,n.videourl,n.imageurl,n.productid,n.inserttime,n.tags 
                            from nenews n 
                                inner join necategory c on n.cateid=c.cateid
                            where n.newsid={0}";
            sql = String.Format(sql,NewsID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public DataTable GetCategoryList(int ParentID)
        {
            string sql = String.Format("select * from neCategory where parentid={0}",ParentID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public DataTable GetNewsComments(int NewsID)
        {
            CommentBll bll = new CommentBll();
            return bll.GetList(AppType.News, NewsID); 
        }

        public DataTable GetRankingNewsList(int CategoryID)
        {
            string sql = "select top 10 * from nenews order by pageview desc";
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];  
        }

        public DataTable GetSplendidNewsList(int CategoryID)
        {
            string sql = "select top 10 * from nenews where issplendid=1";
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
        }

        public DataTable GetCategoryPathList(string CategoryPath)
        {
            //string CategoryPath = Convert.ToString(db.ExecuteScalar(CommandType.Text, "select dbo.GetNewsCategoryPath(" + CategoryID + ")")); //GetNewsCategoryInfo(CategoryID).Rows[0]["catepath"].ToString();

            string sql = "select * from necategory where cateid in ({0}) order by catelevel";
            sql = String.Format(sql, CategoryPath.Replace("/", ","));

            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0]; 
        }
    }
}
