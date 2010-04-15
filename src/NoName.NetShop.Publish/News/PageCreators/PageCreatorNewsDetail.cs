using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using log4net;
using NoName.NetShop.Publish.News.DataAccess;
using System.Xml;

namespace NoName.NetShop.Publish.News.PageCreators
{
    public class PageCreatorNewsDetail : PageCreator
    {
        public PageCreatorNewsDetail(NewsPageParameter parameter, NewsConfigurationSection config)
        {
            Parameter = parameter;
            Config = config;
            CreatorElement = config.PageCreators["detail"];

            Logger = LogManager.GetLogger(config.Logger);
            dal = new NewsDataAccess(config); 
        }


        protected override XmlDocument GetPageData()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><newspage/>");

            NewsNodeCreator helper = new NewsNodeCreator(Parameter, Config, dal, xdoc);

            XmlNode rootNode = xdoc.SelectSingleNode("/newspage");

            rootNode.AppendChild(helper.GetHeaderContent());
            rootNode.AppendChild(helper.GetFooterContent());
            rootNode.AppendChild(helper.GetNewsCategory());
            rootNode.AppendChild(helper.GetCategoryPathList());
            rootNode.AppendChild(helper.GetNewsDetail());
            rootNode.AppendChild(helper.GetNewsCommentList());
            rootNode.AppendChild(helper.GetRankingNewsList());

            //xdoc.Save(@"d:\dingding-news-" + Parameter.NewsID + ".xml");
            return xdoc;
        }

        public override void Create(string PageFileName)
        {
            CreateHelper(PageFileName, CreatorElement.Template);
        }
    }
}
