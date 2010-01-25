using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using System.Xml;
using System.Data;
using NoName.Utility;
using NoName.NetShop.Product.Facade;

namespace NoName.NetShop.Publish.Brand.DataAccess
{
    public class BrandNodeCreator
    {
        private BrandPageParameter Parameter;
        private BrandConfigurationSection Config;
        private BrandDataAccess dal;
        private XmlDocument xdoc;

        public BrandNodeCreator(BrandPageParameter parameter, BrandConfigurationSection config, BrandDataAccess DAL, XmlDocument document) 
        {
            Parameter = parameter;
            Config = config;
            dal = DAL;
            xdoc = document;
        }

        public XmlNode GetBrandInfo()
        {
            XmlNode BrandInfoNode = xdoc.CreateElement("brandinfo");

            DataTable dt = dal.GetBrandInfo(Parameter.BrandID);

            if(dt.Rows.Count>0)
            {
                XmlUtility.AddNewNode(BrandInfoNode, "brandid", Convert.ToString(dt.Rows[0]["brandid"]));
                XmlUtility.AddNewNode(BrandInfoNode, "categoryid", Convert.ToString(Parameter.CategoryID));
                XmlUtility.AddNewNode(BrandInfoNode, "ordertype", Convert.ToString(Parameter.OrderType));
                XmlUtility.AddNewNode(BrandInfoNode, "brandname", Convert.ToString(dt.Rows[0]["brandname"]));
                XmlUtility.AddNewNode(BrandInfoNode, "brandlogo", Convert.ToString(dt.Rows[0]["brandlogo"]));
                XmlUtility.AddNewNode(BrandInfoNode, "brief", Convert.ToString(dt.Rows[0]["brief"]));
            }

            return BrandInfoNode;
        }


        public XmlNode GetProductList()
        {
            XmlNode ProductListNode = xdoc.CreateElement("productlist");

            int RecordCount = 0;
            DataTable dt = dal.GetBrandProductList(Parameter.PageIndex, Parameter.BrandID, Parameter.CategoryID, Parameter.OrderType, out RecordCount);

            XmlNode ProductsNode = XmlUtility.AddNewNode(ProductListNode, "products", null);
            foreach (DataRow row in dt.Rows)
            {
                XmlNode ProductNode = XmlUtility.AddNewNode(ProductsNode, "product", null);


                XmlUtility.AddNewNode(ProductNode, "productid", Convert.ToString(row["productid"]));
                XmlUtility.AddNewNode(ProductNode, "productname", Convert.ToString(row["productname"]));
                XmlUtility.AddNewNode(ProductNode, "mediumimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["mediumimage"])));
                XmlUtility.AddNewNode(ProductNode, "price", Convert.ToString(row["merchantprice"]));
                XmlUtility.AddNewNode(ProductNode, "commentcount", Convert.ToString(13));
            }

            XmlNode PageInfoNode = XmlUtility.AddNewNode(ProductListNode, "pageinfo", null);
            XmlUtility.SetAtrributeValue(PageInfoNode, "recordcount", Convert.ToString(RecordCount));
            XmlUtility.SetAtrributeValue(PageInfoNode, "pageindex", Convert.ToString(Parameter.PageIndex));

            return ProductListNode;
        }
    }
}
