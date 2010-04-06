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

            int PageCount = (int)(RecordCount / Config.ListPageSize) + 1;


            //分页信息节点
            XmlNode PageInfoNode = XmlUtility.AddNewNode(ProductListNode, "pageinfo", null);

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



            return ProductListNode;
        }

        public XmlNode GetSalesProductList()
        {
            XmlNode SalesProductListNode = xdoc.CreateElement("salesproducts");

            DataTable dt = dal.GetBrandHotSaleProductList(Parameter.BrandID);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode ProductNode = XmlUtility.AddNewNode(SalesProductListNode, "product", null);

                XmlUtility.AddNewNode(ProductNode, "productid", Convert.ToString(row["productid"]));
                XmlUtility.AddNewNode(ProductNode, "productname", Convert.ToString(row["productname"]));
                XmlUtility.AddNewNode(ProductNode, "productimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["smallimage"])));
                XmlUtility.AddNewNode(ProductNode, "price", Convert.ToDecimal(Convert.ToDecimal(row["MerchantPrice"]) - Convert.ToDecimal(row["reduceprice"])).ToString("00"));

            }
            
            return SalesProductListNode;
        }
    }
}
