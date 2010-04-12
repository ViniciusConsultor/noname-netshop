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

namespace NoName.NetShop.CMS.DataAccess.TagDataProviders
{
    public class TagDataProvider_C : ITagDataProvider
    {
        public XmlDocument GetData(NameValueCollection TagParameter)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><tag />");
            XmlNode rootNode = xdoc.SelectSingleNode("/tag");


            NewsModelBll bll = new NewsModelBll();

            DataTable dt = bll.GetTopSplendidNews(8);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode NewsNode = XmlUtility.AddNewNode(rootNode, "news", null);

                XmlUtility.AddNewNode(NewsNode, "newsid", row["newsid"].ToString());
                XmlUtility.AddNewNode(NewsNode, "title", row["title"].ToString());
            }

            return xdoc;
        }
    }
}
