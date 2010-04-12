using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.CMS.Data;
using System.Collections.Specialized;
using System.Xml;
using System.Data;
using NoName.Utility;
using NoName.NetShop.News.BLL;
using NoName.NetShop.News.Model;
using NoName.NetShop.News.Facade;

namespace NoName.NetShop.CMS.DataAccess.TagDataProviders
{
    public class TagDataProvider_D : ITagDataProvider
    {
        public XmlDocument GetData(NameValueCollection TagParameter)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><tag />");
            XmlNode rootNode = xdoc.SelectSingleNode("/tag");

            NewsModelBll bll = new NewsModelBll();

            XmlNode CategoryNodel1 = XmlUtility.AddNewNode(rootNode, "category1", null);

            NewsCategoryModel Category1Model = new NewsCategoryModelBll().GetModel(3);
            DataTable dt1 = bll.GetTopCategoryNews(6, 3);

            XmlNode NewsCategoryNode1 = XmlUtility.AddNewNode(CategoryNodel1, "category", null);
            XmlNode NewsListNode1 = XmlUtility.AddNewNode(CategoryNodel1, "newslist", null);


            XmlUtility.AddNewNode(NewsCategoryNode1, "categoryid", Category1Model.CateID.ToString());
            XmlUtility.AddNewNode(NewsCategoryNode1, "categoryname", Category1Model.CateName);


            foreach (DataRow row in dt1.Rows)
            {
                XmlNode NewsNode = XmlUtility.AddNewNode(NewsListNode1, "news", null);

                XmlUtility.AddNewNode(NewsNode, "newsid", row["newsid"].ToString());
                XmlUtility.AddNewNode(NewsNode, "title", row["title"].ToString());
                XmlUtility.AddNewNode(NewsNode, "image", NewsImageRule.GetImageUrl(row["imageurl"].ToString()));
                XmlUtility.AddNewNode(NewsNode, "video", NewsVideoRule.GetVideoUrl(row["videourl"].ToString()));
            }




            XmlNode CategoryNode2 = XmlUtility.AddNewNode(rootNode, "category2", null);


            NewsCategoryModel CategoryModel2 = new NewsCategoryModelBll().GetModel(6);
            DataTable dt2 = bll.GetTopCategoryNews(6, 6);

            XmlNode NewsCategoryNode2 = XmlUtility.AddNewNode(CategoryNode2, "category", null);
            XmlNode NewsListNode2 = XmlUtility.AddNewNode(CategoryNode2, "newslist", null);

            XmlUtility.AddNewNode(NewsCategoryNode2, "categoryid", CategoryModel2.CateID.ToString());
            XmlUtility.AddNewNode(NewsCategoryNode2, "categoryname", CategoryModel2.CateName);

            foreach (DataRow row in dt2.Rows)
            {
                XmlNode NewsNode = XmlUtility.AddNewNode(NewsListNode2, "news", null);

                XmlUtility.AddNewNode(NewsNode, "newsid", row["newsid"].ToString());
                XmlUtility.AddNewNode(NewsNode, "title", row["title"].ToString());
                XmlUtility.AddNewNode(NewsNode, "image", NewsImageRule.GetImageUrl(row["imageurl"].ToString()));
                XmlUtility.AddNewNode(NewsNode, "video", NewsVideoRule.GetVideoUrl(row["videourl"].ToString()));
            }

            return xdoc;
        }
    }
}
