using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using log4net;
using NoName.NetShop.Publish.News.DataAccess;
using System.Xml;
using System.IO;
using System.Xml.Xsl;

namespace NoName.NetShop.Publish.News.PageCreators
{
    public abstract class PageCreator
    {
        protected NewsPageParameter Parameter;
        protected NewsConfigurationSection Config;
        protected ILog Logger;
        protected NewsDataAccess dal;
        protected NewsConfigurationElement CreatorElement;

        protected abstract XmlDocument GetPageData();

        public abstract void Create(string PageFileName);

        protected void CreateHelper(string PageFileName, string XsltTemplate)
        {
            FileInfo PageFile = new FileInfo(PageFileName);
            XmlDocument xdoc = GetPageData();

            lock (PageFile)
            {

                if (!PageFile.Directory.Exists)
                {
                    PageFile.Directory.Create();
                }


                XslCompiledTransform xslTrans = new XslCompiledTransform();
                xslTrans.Load(XsltTemplate);

                //将转换的结果保存在内存流中，然后返回文件名

                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(PageFile.FullName, false, Encoding.GetEncoding("UTF-8"));
                    //writer.WriteLine(content);
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
                    {
                        writer.Close();
                        writer.Dispose();
                    }
                }
            }
        }
    }
}
