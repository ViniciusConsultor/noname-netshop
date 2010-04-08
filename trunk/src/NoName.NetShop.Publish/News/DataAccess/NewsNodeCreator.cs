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


        public XmlNode GetHeaderContent()
        {
            CommonConfig common = CommonConfig.Instance();
            XmlNode HeaderNode = xdoc.CreateElement("standardheader");

            XmlCDataSection CData = xdoc.CreateCDataSection(common.GetStandardHeaderContent(Config.HeaderFile, Config.PageValidateTempXml));

            HeaderNode.AppendChild((XmlNode)CData);

            return HeaderNode;
        }

        public XmlNode GetFooterContent()
        {
            CommonConfig common = CommonConfig.Instance();
            XmlNode FooterNode = xdoc.CreateElement("standardfooter");

            XmlCDataSection CData = xdoc.CreateCDataSection(common.GetStandardFooterContent(Config.FooterFile, Config.PageValidateTempXml));

            FooterNode.AppendChild((XmlNode)CData);

            return FooterNode;
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

            //分页信息节点
            XmlNode PageInfoNode = XmlUtility.AddNewNode(NewsListNode, "pageinfo", null);

            XmlUtility.SetAtrributeValue(PageInfoNode, "recordcount", RecordCount.ToString());
            XmlUtility.SetAtrributeValue(PageInfoNode, "pagecount", PageCount.ToString());
            XmlUtility.SetAtrributeValue(PageInfoNode, "currentpage", Parameter.PageIndex.ToString());


            if (PageCount <= 11) //小于最大显示数目，全部显示即可
            {
                for (int i = 1; i <= PageCount; i++)
                {
                    XmlNode PageNode = XmlUtility.AddNewNode(PageInfoNode, "page", "");
                    XmlUtility.SetAtrributeValue(PageNode, "pageindex", i.ToString());
                    if (i == Parameter.PageIndex) XmlUtility.SetAtrributeValue(PageNode, "isselected", "true");
                }
            }
            else                //大于最大显示数据，需要根据pageindex决定显示页码
            {
                XmlNode PageNodeS = XmlUtility.AddNewNode(PageInfoNode, "page", "");
                XmlUtility.SetAtrributeValue(PageNodeS, "pageindex", 1.ToString());
                if (Parameter.PageIndex == 1) XmlUtility.SetAtrributeValue(PageNodeS, "isselected", "true");

                if (Parameter.PageIndex < 10)
                {
                    for (int i = 2; i <= 10; i++)
                    {
                        XmlNode PageNode = XmlUtility.AddNewNode(PageInfoNode, "page", "");
                        XmlUtility.SetAtrributeValue(PageNode, "pageindex", i.ToString());
                        if (i == Parameter.PageIndex) XmlUtility.SetAtrributeValue(PageNode, "isselected", "true");
                    }
                    XmlNode PageNodeME = XmlUtility.AddNewNode(PageInfoNode, "page", "");
                    XmlUtility.SetAtrributeValue(PageNodeME, "pageindex", "...");
                }
                else
                {
                    if (Parameter.PageIndex >= 10 && Parameter.PageIndex <= PageCount - 10)
                    {
                        XmlNode PageNodeMS = XmlUtility.AddNewNode(PageInfoNode, "page", "");
                        XmlUtility.SetAtrributeValue(PageNodeMS, "pageindex", "...");

                        for (int i = Parameter.PageIndex - 5; i < Parameter.PageIndex + 5; i++)
                        {
                            XmlNode PageNode = XmlUtility.AddNewNode(PageInfoNode, "page", "");
                            XmlUtility.SetAtrributeValue(PageNode, "pageindex", i.ToString());
                            if (i == Parameter.PageIndex) XmlUtility.SetAtrributeValue(PageNode, "isselected", "true");
                        }

                        XmlNode PageNodeME = XmlUtility.AddNewNode(PageInfoNode, "page", "");
                        XmlUtility.SetAtrributeValue(PageNodeME, "pageindex", "...");
                    }
                    else
                    {
                        if (Parameter.PageIndex > PageCount - 10)
                        {
                            XmlNode PageNodeMS = XmlUtility.AddNewNode(PageInfoNode, "page", "");
                            XmlUtility.SetAtrributeValue(PageNodeMS, "pageindex", "...");

                            for (int i = PageCount - 10; i <= PageCount - 1; i++)
                            {
                                XmlNode PageNode = XmlUtility.AddNewNode(PageInfoNode, "page", "");
                                XmlUtility.SetAtrributeValue(PageNode, "pageindex", i.ToString());
                                if (i == Parameter.PageIndex) XmlUtility.SetAtrributeValue(PageNode, "isselected", "true");
                            }
                        }
                    }
                }

                XmlNode PageNodeE = XmlUtility.AddNewNode(PageInfoNode, "page", "");
                XmlUtility.SetAtrributeValue(PageNodeE, "pageindex", PageCount.ToString());
                if (Parameter.PageIndex == PageCount) XmlUtility.SetAtrributeValue(PageNodeE, "isselected", "true");
            }

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

        public XmlNode GetNewsCommentList()
        {
            XmlNode CommentListNode = xdoc.CreateElement("comments");
            DataTable dt = dal.GetNewsComments(Parameter.NewsID);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode CommentNode = XmlUtility.AddNewNode(CommentListNode, "comment", null);

                XmlUtility.AddNewNode(CommentNode, "commentid", row["commentid"].ToString());
                XmlUtility.AddNewNode(CommentNode, "userid", row["userid"].ToString());
                XmlUtility.AddNewNode(CommentNode, "createtime", Convert.ToDateTime(row["createtime"]).ToString("yyyy-MM-dd"));
                XmlUtility.AddNewNode(CommentNode, "content", row["content"].ToString());
            }

            return CommentListNode;
        }

        public XmlNode GetRankingNewsList()
        {
            XmlNode RankingNewsListNode = xdoc.CreateElement("rankinglist");
            DataTable dt = dal.GetRankingNewsList(0);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode NewsNode = XmlUtility.AddNewNode(RankingNewsListNode, "news", null);

                XmlUtility.AddNewNode(NewsNode, "newsid", Convert.ToString(row["newsid"]));
                XmlUtility.AddNewNode(NewsNode, "title", Convert.ToString(row["title"]));
                XmlUtility.AddNewNode(NewsNode, "brief", Convert.ToString(row["brief"]));
                XmlUtility.AddNewNode(NewsNode, "imageurl", Convert.ToString(row["imageurl"]));
            }

            return RankingNewsListNode;
        }



        public XmlNode GetSplendidNewsList()
        {
            XmlNode SplendidNewsListNode = xdoc.CreateElement("splendidnewslist");
            DataTable dt = dal.GetSplendidNewsList(0);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode NewsNode = XmlUtility.AddNewNode(SplendidNewsListNode, "news", null);

                XmlUtility.AddNewNode(NewsNode, "newsid", Convert.ToString(row["newsid"]));
                XmlUtility.AddNewNode(NewsNode, "title", Convert.ToString(row["title"]));
                XmlUtility.AddNewNode(NewsNode, "brief", Convert.ToString(row["brief"]));
                XmlUtility.AddNewNode(NewsNode, "imageurl", Convert.ToString(row["imageurl"]));
            }

            return SplendidNewsListNode;
        }
    }
}
