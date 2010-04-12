using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.CMS.Data;
using System.Collections.Specialized;
using System.Xml;
using System.Data;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Facade;

namespace NoName.NetShop.CMS.DataAccess.TagDataProviders
{
    public class TagDataProvider_L : ITagDataProvider
    {
        public XmlDocument GetData(NameValueCollection TagParameter)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><tag />");
            XmlNode rootNode = xdoc.SelectSingleNode("/tag");

            DataTable dt = new SecondhandProductBll().GetNewestList(9);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode DealProductNode = XmlUtility.AddNewNode(rootNode, "deal", null);

                XmlUtility.AddNewNode(DealProductNode, "pid", row["pid"].ToString());
                XmlUtility.AddNewNode(DealProductNode, "pname", row["pname"].ToString());
                XmlUtility.AddNewNode(DealProductNode, "price", row["price"].ToString());
                XmlUtility.AddNewNode(DealProductNode, "ptype", row["ptype"].ToString());
                XmlUtility.AddNewNode(DealProductNode, "mediumimage", MagicWorldImageRule.GetMainImageUrl(row["mediumimage"].ToString()));
                XmlUtility.AddNewNode(DealProductNode, "inserttime", Convert.ToDateTime(row["inserttime"]).ToString("yyyy-MM-dd"));
            }


            return xdoc;
        }
    }
}
