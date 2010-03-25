using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using log4net;
using NoName.NetShop.Publish.List.DataAccess;
using System.Xml;
using System.IO;
using System.Xml.Xsl;
using NoName.Utility;

namespace NoName.NetShop.Publish.List.PageCreator
{
    public class ListPageCreator
    {
        private ListPageParameter Parameter;
        private ListConfigurationSection Config;
        private ILog Logger;
        private ListDataAccess dal;

        public ListPageCreator(ListPageParameter parameter, ListConfigurationSection config)
        {
            Parameter = parameter;
            Config = config;

            Logger = LogManager.GetLogger(config.Logger);
            dal = new ListDataAccess(config);
        }


        protected XmlDocument GetPageData()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><listpage/>");

            XmlNode rootNode = xdoc.SelectSingleNode("/listpage");
            
            ListNodeCreator helper = new ListNodeCreator(Parameter, Config, dal, xdoc);

            rootNode.AppendChild(helper.GetHeaderContent());
            rootNode.AppendChild(helper.GetFooterContent());
            rootNode.AppendChild(helper.GetCategoryInfo());
            rootNode.AppendChild(helper.GetCategoryPathList());
            rootNode.AppendChild(helper.GetCategoryProperityList());
            rootNode.AppendChild(helper.GetCategoryList());
            rootNode.AppendChild(helper.GetProductList());

            xdoc.Save(@"d:\dingding_category.xml");
            return xdoc;
        }

        public void Create(string PageFileName)
        {
            FileInfo ListFile = new FileInfo(PageFileName);

            if (!ListFile.Directory.Exists)
            {
                ListFile.Directory.Create();
            }

            XmlDocument xdoc = GetPageData();

            XslCompiledTransform xslTrans = new XslCompiledTransform();
            xslTrans.Load(Config.Template);

            //将转换的结果保存在内存流中，然后返回文件名

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(ListFile.FullName, false, Encoding.GetEncoding("UTF-8"));
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
