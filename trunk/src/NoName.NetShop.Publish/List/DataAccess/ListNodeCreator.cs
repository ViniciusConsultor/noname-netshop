﻿using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using System.Xml;
using System.Data;
using NoName.Utility;
using NoName.NetShop.Product.Facade;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Publish.List.DataAccess
{
    public class ListNodeCreator
    {        
        private ListPageParameter Parameter;
        private ListConfigurationSection Config;
        private ListDataAccess dal;
        private XmlDocument xdoc;

        public ListNodeCreator(ListPageParameter parameter, ListConfigurationSection config, ListDataAccess DAL, XmlDocument document) 
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

        public XmlNode GetCategoryInfo()
        {
            XmlNode CategoryInfoNode = xdoc.CreateElement("categoryinfo");

            DataRow row = dal.GetCategoryInfo(Parameter.CategoryID);

            XmlUtility.AddNewNode(CategoryInfoNode, "categoryid", Convert.ToString(row["cateid"]));
            XmlUtility.AddNewNode(CategoryInfoNode, "categoryname", Convert.ToString(row["catename"]));
            XmlUtility.AddNewNode(CategoryInfoNode, "isendclass", (!(dal.GetCategorySonList(Parameter.CategoryID).Rows.Count > 0)).ToString()); 

            return CategoryInfoNode;
        }


        public XmlNode GetCategoryPathList()
        {
            XmlNode CategoryPathListNode = xdoc.CreateElement("categorypath");

            DataTable dt = dal.GetCategoryPathList(Parameter.CategoryID);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode CategoryNode = XmlUtility.AddNewNode(CategoryPathListNode, "category", null);

                XmlUtility.AddNewNode(CategoryNode, "categoryid", Convert.ToString(row["cateid"]));
                XmlUtility.AddNewNode(CategoryNode, "categoryname", Convert.ToString(row["catename"])); 
            }

            return CategoryPathListNode;
        }

        public XmlNode GetCategoryList()
        {
            XmlNode CategoryListNode = xdoc.CreateElement("categorylist");

            int AncestorID = new CategoryModelBll().GetAncestorID(Parameter.CategoryID);

            XmlNode AncestorInfoNode = XmlUtility.AddNewNode(CategoryListNode, "ancestorinfo", null);
            CategoryModel AncestorCategory = new CategoryModelBll().GetModel(AncestorID);

            XmlUtility.AddNewNode(AncestorInfoNode, "categoryid", Convert.ToString(AncestorID));
            XmlUtility.AddNewNode(AncestorInfoNode, "categoryname", AncestorCategory.CateName);

            XmlNode CategoriesNode = XmlUtility.AddNewNode(CategoryListNode, "categories", null);

            DataTable RootCategories = dal.GetCategorySonList(AncestorID);

            foreach (DataRow row in RootCategories.Rows)
            {
                XmlNode FatherNode = XmlUtility.AddNewNode(CategoriesNode, "fathercategory", null);

                XmlUtility.SetAtrributeValue(FatherNode, "categoryid", Convert.ToString(row["cateid"]));
                XmlUtility.SetAtrributeValue(FatherNode, "categoryname", Convert.ToString(row["catename"]));

                int CategoryID = Convert.ToInt32(row["cateid"]);

                DataTable SonCategories = dal.GetCategorySonList(CategoryID);

                if (SonCategories.Rows.Count > 0) foreach (DataRow srow in SonCategories.Rows)
                {
                        XmlNode SonNode = XmlUtility.AddNewNode(FatherNode, "soncategory", null);

                        XmlUtility.SetAtrributeValue(SonNode, "categoryid", Convert.ToString(srow["cateid"]));
                        XmlUtility.SetAtrributeValue(SonNode, "categoryname", Convert.ToString(srow["catename"])); 
                }

            }

            return CategoryListNode;
        }        

        public XmlNode GetProductList()
        {
            XmlNode ProductListNode = xdoc.CreateElement("productlist");

            int RecordCount = 0, PageCount=0;

            DataTable dt;
            if (Parameter.Properities == null)
                dt = dal.GetProductList(Parameter.CategoryID, Parameter.PageIndex,Parameter.OrderValue, out RecordCount, out PageCount);
            else
                dt = dal.GetProductList(Parameter.CategoryID, Parameter.PageIndex, Parameter.OrderValue, Parameter.Properities, out RecordCount, out PageCount);

            //商品列表节点
            XmlNode ProductsNode = XmlUtility.AddNewNode(ProductListNode, "products", null);


            foreach (DataRow row in dt.Rows)
            {
                XmlNode ProductNode = XmlUtility.AddNewNode(ProductsNode, "product", null);

                XmlUtility.AddNewNode(ProductNode, "productid", Convert.ToString(row["productid"]));
                XmlUtility.AddNewNode(ProductNode, "productname", Convert.ToString(row["productname"]));
                XmlUtility.AddNewNode(ProductNode, "smallimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["smallimage"])));
                XmlUtility.AddNewNode(ProductNode, "mediumimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["mediumimage"])));
                XmlUtility.AddNewNode(ProductNode, "tradeprice", Convert.ToString(row["tradeprice"]));
                XmlUtility.AddNewNode(ProductNode, "merchantprice", Convert.ToString(row["merchantprice"]));
            }

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

        public XmlNode GetCategoryProperityList()
        {
            XmlNode ProperityListNode = xdoc.CreateElement("properitylist");
            DataTable dt = dal.GetCategoryProperityList(Parameter.CategoryID);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode ProperityNode = XmlUtility.AddNewNode(ProperityListNode, "prop", null);

                XmlUtility.AddNewNode(ProperityNode, "propid", row["paraid"].ToString());
                XmlUtility.AddNewNode(ProperityNode, "propname", row["paraname"].ToString());
                XmlNode ProperityValueNode = XmlUtility.AddNewNode(ProperityNode, "values", null);

                string[] values = row["paravalues"].ToString().Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    XmlNode ValueNode = XmlUtility.AddNewNode(ProperityValueNode, "value", null);

                    XmlUtility.AddNewNode(ValueNode, "valueid", i.ToString());
                    XmlUtility.AddNewNode(ValueNode, "value", values[i]);
                }
            }
            return ProperityListNode;
        }

        public XmlNode GetCategoryBrandList()
        {
            XmlNode BrandListNode = xdoc.CreateElement("brandlist");

            foreach(DataRow row in dal.GetCategoryBrand(Parameter.CategoryID).Rows)
            {
                XmlNode BrandNode = XmlUtility.AddNewNode(BrandListNode, "brand", null);

                XmlUtility.AddNewNode(BrandNode, "brandid", Convert.ToString(row["brandid"]));
                XmlUtility.AddNewNode(BrandNode, "brandid", Convert.ToString(row["brandname"]));
            }

            return BrandListNode;
        }

        public XmlNode GetHotSaleProductList()
        {
            XmlNode HotSaleProductsNode = xdoc.CreateElement("hotsaleproduct");

            DataTable dt = dal.GetHotSaleProduct(new CategoryModelBll().GetCategoryPath(Parameter.CategoryID));

            foreach (DataRow row in dt.Rows)
            {
                XmlNode ProductNode = XmlUtility.AddNewNode(HotSaleProductsNode, "product", null);

                XmlUtility.AddNewNode(ProductNode, "productid", Convert.ToString(row["productid"]));
                XmlUtility.AddNewNode(ProductNode, "productname", Convert.ToString(row["productname"]));
                XmlUtility.AddNewNode(ProductNode, "productimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["smallimage"])));
                XmlUtility.AddNewNode(ProductNode, "price", Convert.ToDecimal(Convert.ToDecimal(row["MerchantPrice"]) - Convert.ToDecimal(row["reduceprice"])).ToString("00"));
            }

            return HotSaleProductsNode;
        }
    }
}
