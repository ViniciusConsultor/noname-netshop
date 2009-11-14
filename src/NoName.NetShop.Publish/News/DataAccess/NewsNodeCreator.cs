using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using System.Xml;
using System.Data;
using NoName.Utility;

namespace NoName.NetShop.Publish.News.DataAccess
{
    public class NewsNodeCreator 
    {        
        private NewsPageParameter Parameter;
        private NewsConfigurationSection Config;
        private NewsDataAccess dal;
        private XmlDocument xdoc;

        public NewsNodeCreator(NewsPageParameter parameter, NewsConfigurationSection config, NewsDataAccess DAL, XmlDocument document) 
        {
            Parameter = parameter;
            Config = config;
            dal = DAL;
            xdoc = document;
        }

        public XmlNode GetNewsCategory()
        {
            XmlNode CategoryListNode = xdoc.CreateElement("categorylist");

            DataTable dt = dal.GetCategoryList(0);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode CagegoryNode = XmlUtility.AddNewNode(CategoryListNode, "category", null);

                XmlUtility.AddNewNode(CagegoryNode, "categoryid", Convert.ToString(row["cateid"]));
                XmlUtility.AddNewNode(CagegoryNode, "categoryname", Convert.ToString(row["catename"]));
            }

            return CategoryListNode;
        }

        public XmlNode GetNewsList()
        {
            XmlNode NewsListNode = xdoc.CreateElement("newslist");

            XmlNode ListNode = XmlUtility.AddNewNode(NewsListNode, "list", null);
            int RecordCount = 0,PageCount=0;
            DataTable dt = dal.GetNewsList(Parameter.PageIndex, Config.ListPageSize, Parameter.CategoryID, out RecordCount,out PageCount);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode NewsNode = XmlUtility.AddNewNode(ListNode,"news",null);

                XmlUtility.AddNewNode(NewsNode, "newsid", Convert.ToString(row["newsid"]));
                XmlUtility.AddNewNode(NewsNode, "title", Convert.ToString(row["title"]));
                XmlUtility.AddNewNode(NewsNode, "brief", Convert.ToString(row["brief"]));
                XmlUtility.AddNewNode(NewsNode, "imageurl", Convert.ToString(row["imageurl"]));
            }

            XmlNode PageNode = XmlUtility.AddNewNode(NewsListNode, "pageinfo", null);

            XmlUtility.SetAtrributeValue(PageNode, "recordcount", Convert.ToString(RecordCount));
            XmlUtility.SetAtrributeValue(PageNode, "pagecount", Convert.ToString(PageCount));

            return NewsListNode;
        }

        public XmlNode GetNewsDetail()
        {
            XmlNode NewsDetailNode = xdoc.CreateElement("newsdetail");

            DataTable dt = dal.GetNewDetail(Parameter.NewsID);
            //c.cateid,c.catename,
            //n.newsid,n.title,n.subtitle,n.brief,n.newscontent,
            //n.smallimageurl,n.author,n.newsfrom,n.videourl,n.imageurl,n.productid,n.inserttime,n.tags 
            if(dt.Rows.Count>0)
            {
                DataRow row =dt.Rows[0];
                XmlUtility.AddNewNode(NewsDetailNode, "newsid", Convert.ToString(row["newsid"]));
                XmlUtility.AddNewNode(NewsDetailNode, "title", Convert.ToString(row["title"]));
                XmlUtility.AddNewNode(NewsDetailNode, "subtitle", Convert.ToString(row["subtitle"]));
                XmlUtility.AddNewNode(NewsDetailNode, "cateid", Convert.ToString(row["cateid"]));
                XmlUtility.AddNewNode(NewsDetailNode, "catename", Convert.ToString(row["catename"]));
                XmlUtility.AddCDataNode(NewsDetailNode, "brief", Convert.ToString(row["brief"]));
                XmlUtility.AddCDataNode(NewsDetailNode, "newscontent", Convert.ToString(row["newscontent"]));
                XmlUtility.AddNewNode(NewsDetailNode, "smallimageurl", Convert.ToString(row["smallimageurl"]));
                XmlUtility.AddNewNode(NewsDetailNode, "author", Convert.ToString(row["author"]));
                XmlUtility.AddNewNode(NewsDetailNode, "newsfrom", Convert.ToString(row["newsfrom"]));
                XmlUtility.AddNewNode(NewsDetailNode, "videourl", Convert.ToString(row["videourl"]));
                XmlUtility.AddNewNode(NewsDetailNode, "imageurl", Convert.ToString(row["imageurl"]));
                XmlUtility.AddNewNode(NewsDetailNode, "productid", Convert.ToString(row["productid"]));
                XmlUtility.AddNewNode(NewsDetailNode, "inserttime", Convert.ToDateTime(row["inserttime"]).ToString("yyyy-MM-dd hh:mm:ss"));
                XmlUtility.AddNewNode(NewsDetailNode, "tags", Convert.ToString(row["tags"]));
            }

            return NewsDetailNode;
        }


    }
}
