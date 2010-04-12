using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.CMS.Data;
using System.Collections.Specialized;
using System.Xml;
using NoName.NetShop.News.BLL;
using System.Data;
using NoName.Utility;

namespace NoName.NetShop.CMS.DataAccess.TagDataProviders
{
    public class TagDataProvider_A : ITagDataProvider
    {
        public XmlDocument GetData(NameValueCollection TagParameter)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><tag />");
            XmlNode rootNode = xdoc.SelectSingleNode("/tag");


            NewsCategoryModelBll bll = new NewsCategoryModelBll();

            DataTable dt = bll.GetList(0);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode CategoryNode = XmlUtility.AddNewNode(rootNode, "category", null);

                XmlUtility.AddNewNode(CategoryNode, "categoryid", row["cateid"].ToString());
                XmlUtility.AddNewNode(CategoryNode, "categoryname", row["catename"].ToString()); 
            }


            return xdoc;
        }
    }
}
