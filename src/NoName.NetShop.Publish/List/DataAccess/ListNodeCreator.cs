using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using System.Xml;
using System.Data;
using NoName.Utility;

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

            DataTable RootCategories = dal.GetRootCategoryList();

            foreach (DataRow row in RootCategories.Rows)
            {
                XmlNode FatherNode = XmlUtility.AddNewNode(CategoryListNode,"fathercategory",null);

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
                XmlUtility.AddNewNode(ProductNode, "smallimage", "http://dingding.uncc.cn/upload/productmain/" + Convert.ToString(row["smallimage"]));
                XmlUtility.AddNewNode(ProductNode, "mediumimage", "http://dingding.uncc.cn/upload/productmain/" + Convert.ToString(row["mediumimage"]));
                XmlUtility.AddNewNode(ProductNode, "tradeprice", Convert.ToString(row["tradeprice"]));
                XmlUtility.AddNewNode(ProductNode, "merchantprice", Convert.ToString(row["merchantprice"]));
            }

            //分页信息节点
            XmlNode PageInfoNode = XmlUtility.AddNewNode(ProductListNode, "pageinfo", null);

            XmlUtility.SetAtrributeValue(PageInfoNode, "recordcount", RecordCount.ToString());
            XmlUtility.SetAtrributeValue(PageInfoNode, "pagecount", PageCount.ToString());

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
    }
}
