using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Publish.Product.DataAccess;
using log4net;
using NoName.NetShop.Publish.Configuration;
using System.Xml;
using System.IO;
using System.Xml.Xsl;

namespace NoName.NetShop.Publish.Product.PageCreator
{
    public class ProductPageCreator
    {
        private ProductPageParameter Parameter;
        private ProductConfigurationSection Config;
        private ILog Logger;
        private ProductDataAccess dal;


        public ProductPageCreator(ProductPageParameter parameter, ProductConfigurationSection config)
        {
            Parameter = parameter;
            Config = config;

            Logger = LogManager.GetLogger(config.Logger);
            dal = new ProductDataAccess(config);
        }

        protected XmlDocument GetPageData()
        {
            XmlDocument xdoc = new XmlDocument();

            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><productpage/>");

            XmlNode rootNode = xdoc.SelectSingleNode("/productpage");

            ProductNodeCreator helper = new ProductNodeCreator(Parameter, Config, dal, xdoc);

            rootNode.AppendChild(helper.GetHeaderContent());
            rootNode.AppendChild(helper.GetFooterContent());
            rootNode.AppendChild(helper.GetProductInfo());
            rootNode.AppendChild(helper.GetCategoryPathList());
            rootNode.AppendChild(helper.GetProductCommentList());

            //xdoc.Save(@"d:\dingding_product.xml");


            return xdoc;
        }


        public void Create(string PageFileName)
        {
            FileInfo ProductFile = new FileInfo(PageFileName);

            if (!ProductFile.Directory.Exists)
            {
                ProductFile.Directory.Create();
            }

            XmlDocument xdoc = GetPageData();

            XslCompiledTransform xslTrans = new XslCompiledTransform();
            xslTrans.Load(Config.Template);

            //将转换的结果保存在内存流中，然后返回文件名

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(ProductFile.FullName, false, Encoding.GetEncoding("UTF-8"));
                //writer.WriteLine("this is a product test");
                xslTrans.Transform(xdoc, null, writer);
            }
            catch (Exception e)
            {
                Logger.Info(e.Message);
                throw new PublishException("生成产品页面文件错误", e, false);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
