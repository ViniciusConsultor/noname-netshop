using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using NoName.NetShop.Publish.Brand.DataAccess;
using NoName.NetShop.Publish.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace NoName.NetShop.Publish.Brand.PageCreator
{
    public class BrandPageCreator
    {
        private BrandPageParameter Parameter;
        private BrandConfigurationSection Config;
        private ILog Logger;
        private BrandDataAccess dal;

        public BrandPageCreator(BrandPageParameter parameter, BrandConfigurationSection config)
        {
            Parameter = parameter;
            Config = config;

            Logger = LogManager.GetLogger(config.Logger);
            dal = new BrandDataAccess(config);
        }




        protected XmlDocument GetPageData()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><brandpage/>");

            XmlNode rootNode = xdoc.SelectSingleNode("/brandpage");

            BrandNodeCreator helper = new BrandNodeCreator(Parameter, Config, dal, xdoc);

            rootNode.AppendChild(helper.GetHeaderContent());
            rootNode.AppendChild(helper.GetFooterContent());
            rootNode.AppendChild(helper.GetBrandInfo());
            rootNode.AppendChild(helper.GetProductList());
            rootNode.AppendChild(helper.GetBrandCategoryList());


            xdoc.Save(@"d:\dingding_brand.xml");
            return xdoc;
        }

        public void Create(string PageFileName)
        {
            FileInfo BrandFile = new FileInfo(PageFileName);

            if (!BrandFile.Directory.Exists)
            {
                BrandFile.Directory.Create();
            }

            XmlDocument xdoc = GetPageData();

            XslCompiledTransform xslTrans = new XslCompiledTransform();
            xslTrans.Load(Config.Template);

            //将转换的结果保存在内存流中，然后返回文件名

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(BrandFile.FullName, false, Encoding.GetEncoding("UTF-8"));
                //writer.WriteLine("this is a list test");
                xslTrans.Transform(xdoc, null, writer);
            }
            catch (Exception e)
            {
                Logger.Info(e.Message);
                throw new PublishException("生成产品列表页面文件错误", e, false);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
