using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.CMS.Data;
using System.Xml;
using System.Collections.Specialized;
using NoName.NetShop.News.Facade;
using NoName.NetShop.News.BLL;
using NoName.NetShop.News.Model;
using System.Data;
using NoName.Utility;

namespace NoName.NetShop.CMS.DataAccess.TagDataProviders
{
    public class TagDataProvider_F1 : ITagDataProvider
    {
        public XmlDocument GetData(NameValueCollection TagParameter)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><tag />");
            XmlNode rootNode = xdoc.SelectSingleNode("/tag");

            rootNode.AppendChild(GetNode(7, xdoc));
            rootNode.AppendChild(GetNode(41, xdoc));

            return xdoc;
        }

        private XmlNode GetNode(int CategoryID, XmlDocument xdoc)
        {
            XmlNode TempNode = xdoc.CreateElement("categorynode");

            NewsModelBll bll = new NewsModelBll();
            NewsCategoryModel CategoryModel = new NewsCategoryModelBll().GetModel(CategoryID);
            DataTable dt = bll.GetTopCategoryNews(6, CategoryID);

            XmlNode NewsCategoryNode = XmlUtility.AddNewNode(TempNode, "category", null);

            if (CategoryModel != null)
            {
                XmlUtility.AddNewNode(NewsCategoryNode, "categoryid", CategoryModel.CateID.ToString());
                XmlUtility.AddNewNode(NewsCategoryNode, "categoryname", CategoryModel.CateName);


                XmlNode NewsListNode = XmlUtility.AddNewNode(TempNode, "newslist", null);
                foreach (DataRow row in dt.Rows)
                {
                    XmlNode NewsNode = XmlUtility.AddNewNode(NewsListNode, "news", null);

                    XmlUtility.AddNewNode(NewsNode, "newsid", row["newsid"].ToString());
                    XmlUtility.AddNewNode(NewsNode, "title", row["title"].ToString());
                    XmlUtility.AddNewNode(NewsNode, "image", NewsImageRule.GetImageUrl(row["imageurl"].ToString()));
                    XmlUtility.AddNewNode(NewsNode, "video", NewsVideoRule.GetVideoUrl(row["videourl"].ToString()));
                }
            }

            return TempNode;
        }
    }
}
