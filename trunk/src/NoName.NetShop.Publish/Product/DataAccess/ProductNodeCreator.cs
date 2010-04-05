﻿using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using System.Xml;
using NoName.Utility;
using System.Data;
using NoName.NetShop.Product.Facade;

namespace NoName.NetShop.Publish.Product.DataAccess
{
    public class ProductNodeCreator
    {
        private ProductPageParameter Parameter;
        private ProductConfigurationSection Config;
        private ProductDataAccess dal;
        private XmlDocument xdoc;

        public ProductNodeCreator(ProductPageParameter parameter, ProductConfigurationSection config, ProductDataAccess DAL, XmlDocument document) 
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

        public XmlNode GetProductInfo()
        {
            XmlNode ProductInfoNode = xdoc.CreateElement("productinfo");

            //产品信息节点
            XmlNode ProductNode = XmlUtility.AddNewNode(ProductInfoNode, "product", null);

            DataTable dt = dal.GetProductInfo(Parameter.ProductID);

            if (dt == null || dt.Rows == null || dt.Rows.Count <= 0)
                throw new PublishException("商品不存在");
            if (Convert.ToInt32(dt.Rows[0]["status"]) != 1)
                throw new PublishException("商品已下架");

            DataRow row =  dt.Rows[0];

            XmlUtility.AddNewNode(ProductNode, "productid", Convert.ToString(row["ProductId"]));
            XmlUtility.AddNewNode(ProductNode, "productname", Convert.ToString(row["ProductName"]));
            XmlUtility.AddNewNode(ProductNode, "productcode", Convert.ToString(row["ProductCode"]));
            XmlUtility.AddNewNode(ProductNode, "categorypath", Convert.ToString(row["CatePath"]));
            XmlUtility.AddNewNode(ProductNode, "categoryid", Convert.ToString(row["CateId"]));
            XmlUtility.AddNewNode(ProductNode, "tradeprice", Convert.ToString(row["TradePrice"]));
            XmlUtility.AddNewNode(ProductNode, "merchantprice", Convert.ToString(row["MerchantPrice"]));
            XmlUtility.AddNewNode(ProductNode, "actualprice", Convert.ToString(Convert.ToDecimal(row["MerchantPrice"]) - Convert.ToDecimal(row["reduceprice"])));
            XmlUtility.AddNewNode(ProductNode, "tradeprice", Convert.ToString(row["ReducePrice"]));
            XmlUtility.AddNewNode(ProductNode, "stock", Convert.ToString(row["Stock"]));
            XmlUtility.AddNewNode(ProductNode, "smallimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["SmallImage"])));
            XmlUtility.AddNewNode(ProductNode, "mediumimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["MediumImage"])));
            XmlUtility.AddNewNode(ProductNode, "largeimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["LargeImage"])));
            XmlUtility.AddNewNode(ProductNode, "keywords", Convert.ToString(row["Keywords"]));
            XmlUtility.AddCDataNode(ProductNode, "brief", Convert.ToString(row["Brief"]));
            XmlUtility.AddNewNode(ProductNode, "pageview", Convert.ToString(row["PageView"]));
            XmlUtility.AddNewNode(ProductNode, "inserttime", Convert.ToString(row["InsertTime"]));
            XmlUtility.AddNewNode(ProductNode, "changetime", Convert.ToString(row["ChangeTime"]));
            XmlUtility.AddNewNode(ProductNode, "score", Convert.ToString(row["Score"]));

            XmlUtility.AddCDataNode(ProductNode, "packinglist", Convert.ToString(row["packinglist"]));
            XmlUtility.AddCDataNode(ProductNode, "saleservice", Convert.ToString(row["aftersaleservice"]));
            XmlUtility.AddCDataNode(ProductNode, "offerset", Convert.ToString(row["offerset"]));

            XmlNode MultiImagesNode = XmlUtility.AddNewNode(ProductNode,"multiimages",null);
            XmlNode MainImageNode = XmlUtility.AddNewNode(MultiImagesNode, "image", null);
            XmlUtility.AddNewNode(MainImageNode, "smallimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["SmallImage"])));
            XmlUtility.AddNewNode(MainImageNode, "largeimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["MediumImage"])));
            XmlUtility.AddNewNode(MainImageNode, "originimage", ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["LargeImage"])));

            foreach (DataRow imageRow in dal.GetProductMultiImage(Parameter.ProductID).Rows)
            {
                XmlNode MultiImageNode = XmlUtility.AddNewNode(MultiImagesNode, "image", null);

                XmlUtility.AddNewNode(MultiImageNode, "smallimage", ProductMultiImageRule.GetMultiImageUrl(Convert.ToString(imageRow["smallimage"])));
                XmlUtility.AddNewNode(MultiImageNode, "largeimage", ProductMultiImageRule.GetMultiImageUrl(Convert.ToString(imageRow["largeimage"])));
                XmlUtility.AddNewNode(MultiImageNode, "originimage", ProductMultiImageRule.GetMultiImageUrl(Convert.ToString(imageRow["originimage"])));
            }

            return ProductInfoNode;

            //多图节点


            //商品属性节点
        }

        public XmlNode GetCategoryPathList()
        {
            XmlNode CategoryPathListNode = xdoc.CreateElement("categorypath");

            DataTable dt = dal.GetCategoryPathList(Parameter.CategoryPath);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode CategoryNode = XmlUtility.AddNewNode(CategoryPathListNode, "category", null);

                XmlUtility.AddNewNode(CategoryNode, "categoryid", Convert.ToString(row["cateid"]));
                XmlUtility.AddNewNode(CategoryNode, "categoryname", Convert.ToString(row["catename"]));
            }

            return CategoryPathListNode;
        }

        public XmlNode GetProductSpecificationList()
        {
            XmlNode SpecificationListNode = xdoc.CreateElement("specifications");

            DataTable dt = dal.GetProductSpecificationList(Parameter.ProductID,Parameter.CategoryID);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode CategoryNode = XmlUtility.AddNewNode(SpecificationListNode, "specification", null);

                XmlUtility.AddNewNode(CategoryNode, "paraname", Convert.ToString(row["paraname"]));
                XmlUtility.AddNewNode(CategoryNode, "paravalue", Convert.ToString(row["paravalue"]));
            }            

            return SpecificationListNode;
        }

        public XmlNode GetProductQuestionList()
        {
            XmlNode QuestionListNode = xdoc.CreateElement("questions");

            foreach (DataRow row in dal.GetProductQuestionList(Parameter.ProductID).Rows)
            {
                XmlNode QuestionNode = XmlUtility.AddNewNode(QuestionListNode, "question", null);

                XmlUtility.AddNewNode(QuestionNode, "userid", Convert.ToString(row["userid"]));
                XmlUtility.AddNewNode(QuestionNode, "questioncontent", Convert.ToString(row["content"]));
                XmlUtility.AddNewNode(QuestionNode, "questiontime", Convert.ToDateTime(row["inserttime"]).ToString("yyyy-MM-dd"));
                XmlUtility.AddNewNode(QuestionNode, "answercontent", Convert.ToString(row["answercontent"]));
                XmlUtility.AddNewNode(QuestionNode, "answertime", row["answertime"].ToString()==""?"":Convert.ToDateTime(row["answertime"]).ToString("yyyy-MM-dd"));
            }

            return QuestionListNode;
        }

        public XmlNode GetProductCommentList()
        {
            int RecordCount = 0;
            DataTable dt = dal.GetProductCommentList(Parameter.ProductID,out RecordCount);
            XmlNode CommentListNode = xdoc.CreateElement("comments");
            XmlUtility.SetAtrributeValue(CommentListNode, "count", RecordCount.ToString());

            foreach (DataRow row in dt.Rows)
            {
                XmlNode CommentNode = XmlUtility.AddNewNode(CommentListNode, "comment", null);

                XmlUtility.AddNewNode(CommentNode, "userid", Convert.ToString(row["userid"]));
                XmlUtility.AddNewNode(CommentNode, "content", Convert.ToString(row["content"]));
                XmlUtility.AddNewNode(CommentNode, "createtime", Convert.ToDateTime(row["createtime"]).ToString("yyyy-MM-dd"));
            }

            return CommentListNode;
        }

        public XmlNode GetProductTopicList()
        {
            XmlNode TopicListNode = xdoc.CreateElement("topics");

            foreach (DataRow row in dal.GetProductTopicList(Parameter.ProductID).Rows)
            {
                XmlNode TopicNode = XmlUtility.AddNewNode(TopicListNode, "topic", null);

                XmlUtility.AddNewNode(TopicNode, "userid", Convert.ToString(row["userid"]));
                XmlUtility.AddNewNode(TopicNode, "title", Convert.ToString(row["title"]));
                XmlUtility.AddNewNode(TopicNode, "inserttime", Convert.ToDateTime(row["inserttime"]).ToString("yyyy-MM-dd"));
                XmlUtility.AddNewNode(TopicNode, "replynumber", Convert.ToString(row["replynum"]));
            }

            return TopicListNode;
        }

        public XmlNode GetSameBrandProductList()
        {
            XmlNode BrandProductsNode = xdoc.CreateElement("samebrandproducts");

            DataTable dt = dal.GetSameBrandProduct(Parameter.ProductID);

            foreach (DataRow row in dt.Rows)
            {
                XmlNode ProductNode = XmlUtility.AddNewNode(BrandProductsNode, "product", null);

                XmlUtility.AddNewNode(ProductNode, "productid", Convert.ToString(row["productid"]));
                XmlUtility.AddNewNode(ProductNode, "productname", Convert.ToString(row["productname"]));
                XmlUtility.AddNewNode(ProductNode, "productnameshort", Convert.ToString(row["productname"]).Length > 10 ? Convert.ToString(row["productname"]).Substring(0, 10) + ".." : Convert.ToString(row["productname"]));
                XmlUtility.AddNewNode(ProductNode, "price", Convert.ToDecimal(Convert.ToDecimal(row["MerchantPrice"]) - Convert.ToDecimal(row["reduceprice"])).ToString("00"));
            }

            return BrandProductsNode;
        }

        public XmlNode GetHotSaleProductList()
        {
            XmlNode HotSaleProductsNode = xdoc.CreateElement("hotsale");

            DataTable dt = dal.GetHotSaleProduct(Parameter.CategoryPath);

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
