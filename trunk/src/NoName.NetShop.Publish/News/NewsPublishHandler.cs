using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using log4net;
using NoName.NetShop.Publish.News.DataAccess;
using System.Configuration;
using NoName.NetShop.Publish.News.PageCreators;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;

namespace NoName.NetShop.Publish.News
{
    public class NewsPublishHandler : IPublishHandler
    {
        private NewsConfigurationSection config;
        private ILog Logger;
        private NewsPageParameter PageParameter = null;
        private NewsDataAccess dal;

        public string PageFileName
        {
            get;
            set;
        }

        public NewsPublishHandler(string Url)
        {
            config = (NewsConfigurationSection)ConfigurationManager.GetSection("publish/newsPublish");
            Logger = LogManager.GetLogger(config.Logger);
            dal = new NewsDataAccess(config);
            PageParameter = GetParameter(Url);
            PageFileName = GetPageFileName();
        }


        public bool HasStaticPage(out string StaticUrl)
        {
            StaticUrl = "";
            return false;
        }

        public string GetPageFileName()
        {
            string RootPath = config.RootPath;

            string RelativePath = "News\\";

            string EndPath = String.Empty;
            switch (PageParameter.PageType)
            {
                case 1:
                    EndPath += String.Format("List\\List-{0}{1}.html",PageParameter.CategoryID,PageParameter.PageIndex<=1?String.Empty:"-"+PageParameter.PageIndex);
                    break;
                case 2:
                    EndPath += String.Format("Detail\\Detail-{0}.html",PageParameter.NewsID);
                    break;
                default:
                    break;
            }

            if (EndPath != String.Empty)
            {
                return RootPath + RelativePath + EndPath;
            }
            else
            {
                throw new PublishException("获取路径错误", true);
            }
        }

        public bool ValidatePageFile()
        {
            try
            {
                File.Delete(PageFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CreatePageFile()
        {
            if (PageParameter != null)
            {
                PageCreatorFactory factory = PageCreatorFactory.Instance();

                PageCreator creator = factory.GetPageCreator(PageParameter, config);

                if (creator != null)
                {
                    creator.Create(PageFileName);
                }
            }
        }

        public bool DeletePageFile()
        {
            throw new NotImplementedException();
        }

        private NewsPageParameter GetParameter(string Url)
        {
            NewsPageParameter parm = null;

            string NewsDetailPattern = @"news(_|-)+(?<newsid>\d+)";
            string NewsListPattern = @"newslist(_|-)+(?<categoryid>\d+)((_|-)+(?<pageIndex>\d+))?";

            if (Url.EndsWith("news"))
            {
                Regex reg = new Regex(NewsDetailPattern, RegexOptions.IgnoreCase);
                Match match = reg.Match(Url);

                if (match.Success)
                {
                    parm = new NewsPageParameter();
                    parm.NewsID = Convert.ToInt32(match.Groups["newsid"].Value);
                    parm.PageType = 2;

                    DataTable dt = dal.GetNewsCategoryInfo(parm.NewsID);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        parm.CategoryID = Convert.ToInt32(row["cateid"]);
                        parm.CategoryPath = Convert.ToString(row["catepath"]);
                    }
                    else
                    {
                        throw new PublishException("新闻不存在");
                    }
                }
                else
                {
                    throw new PublishException("地址不正确");
                } 
            }
            if (Url.EndsWith("newslist"))
            {
                Regex reg = new Regex(NewsListPattern, RegexOptions.IgnoreCase);
                Match match = reg.Match(Url);

                if (match.Success)
                {
                    parm = new NewsPageParameter();
                    parm.CategoryID = Convert.ToInt32(match.Groups["categoryid"].Value);
                    parm.PageIndex = 1;
                    if (match.Groups["pageIndex"].Success)
                    {
                        parm.PageIndex = Convert.ToInt32(match.Groups["pageIndex"].Value);
                        if (parm.PageIndex <= 0) parm.PageIndex = 1;
                    }
                    parm.PageType = 1;

                    DataTable dt = dal.GetCategoryInfo(parm.CategoryID);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        parm.CategoryPath = Convert.ToString(row["catepath"]);
                    }
                    else
                    {
                        throw new PublishException("分类不存在");
                    }
                }
                else
                {
                    throw new PublishException("地址不正确");
                }
            }


            return parm;
        }
    }

    public class NewsPageParameter
    {
        private int _CategoryID;
        private string _CategoryPath;
        private int _PageIndex;
        private int _NewsID;
        private int _PageType;

        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        public string CategoryPath
        {
            get { return _CategoryPath; }
            set { _CategoryPath = value; }
        }
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }
        public int NewsID
        {
            get { return _NewsID; }
            set { _NewsID = value; }
        }
        public int PageType
        {
            get { return _PageType; }
            set { _PageType = value; }
        }
    }
}
