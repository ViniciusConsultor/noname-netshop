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

namespace NoName.NetShop.CMS.DataAccess.TagDataProviders
{
    public class TagDataProvider_I : ITagDataProvider
    {
        public XmlDocument GetData(NameValueCollection TagParameter)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><tag />");
            XmlNode rootNode = xdoc.SelectSingleNode("/tag");

            SecondhandProductBll bll = new SecondhandProductBll();

            DataTable dt = bll.GetTopHotList(10);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode DealListNode = XmlUtility.AddNewNode(rootNode, "deal", null);

                XmlUtility.AddNewNode(DealListNode, "pid", row["seproductid"].ToString());
                XmlUtility.AddNewNode(DealListNode, "productname", row["seproductname"].ToString());

            }


            return xdoc;
        }
    }
}
