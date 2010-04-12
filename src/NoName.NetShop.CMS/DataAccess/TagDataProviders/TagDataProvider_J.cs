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
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;

namespace NoName.NetShop.CMS.DataAccess.TagDataProviders
{
    public class TagDataProvider_J : ITagDataProvider
    {
        public XmlDocument GetData(NameValueCollection TagParameter)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><tag />");
            XmlNode rootNode = xdoc.SelectSingleNode("/tag");

            XmlNode PawnNode = XmlUtility.AddNewNode(rootNode,"pawn",null);

            DataTable dt1 = new PawnProductBll().GetNewestList(2, PawnProductStatus.已收当);


            foreach (DataRow row in dt1.Rows)
            {
                XmlNode PawnProductNode = XmlUtility.AddNewNode(PawnNode, "pawnproduct", null);

                XmlUtility.AddNewNode(PawnProductNode, "pid", row["pawnproductid"].ToString());
                XmlUtility.AddNewNode(PawnProductNode, "productname", row["pawnproductname"].ToString());
                XmlUtility.AddNewNode(PawnProductNode, "image", MagicWorldImageRule.GetMainImageUrl(row["smallimage"].ToString()));
                XmlUtility.AddNewNode(PawnProductNode, "price", row["sellingprice"].ToString());
                XmlUtility.AddNewNode(PawnProductNode, "deadtime", Convert.ToDateTime(row["deadtime"]).ToString("yyyy-MM-dd"));
            }

            XmlNode RentNode = XmlUtility.AddNewNode(rootNode, "rent", null);

            DataTable dt2 = new RentProductBll().GetNewestList(10);

            foreach (DataRow row in dt2.Rows)
            {
                XmlNode RentProductNode = XmlUtility.AddNewNode(RentNode, "rentlist", null);

                XmlUtility.AddNewNode(RentProductNode, "rentid", row["rentid"].ToString());
                XmlUtility.AddNewNode(RentProductNode, "rentname", row["rentname"].ToString());
                XmlUtility.AddNewNode(RentProductNode, "createtime", Convert.ToDateTime(row["createtime"]).ToString("yyyy年MM月dd日"));
            }


            return xdoc;
        }
    }
}
