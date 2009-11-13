using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Publish.Configuration;
using System.Configuration;
using log4net;
using NoName.NetShop.Publish.List.DataAccess;
using System.Data;
using System.IO;
using NoName.NetShop.Publish.List.PageCreator;
using System.Text.RegularExpressions;

namespace NoName.NetShop.Publish.List
{
    public class ListPublishHandler : IPublishHandler
    {

        private ListConfigurationSection config;
        private ILog Logger;
        private ListPageParameter PageParameter = null;
        private ListDataAccess dal;

        public string PageFileName
        {
            get;
            set;
        }

        public ListPublishHandler(string Url)
        {
            config = (ListConfigurationSection)ConfigurationManager.GetSection("publish/listPublish");
            Logger = LogManager.GetLogger(config.Logger);
            dal = new ListDataAccess(config);
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
            if (PageParameter != null)
            {
                DataRow row = dal.GetCategoryInfo(PageParameter.CategoryID);

                if (row != null)
                {
                    string FatherClassificationPath = row["fatherpath"].ToString();

                    string RelativePath = String.Empty;

                    if (FatherClassificationPath != String.Empty)
                        RelativePath = FatherClassificationPath.Replace("/", "\\") + "\\";

                    string PageName = String.Format("list_{0}{1}.html", PageParameter.CategoryID, PageParameter.PageIndex <= 1 ? "" : "_" + PageParameter.PageIndex.ToString());

                    return config.RootPath + RelativePath + PageName;
                }
                else
                {
                    throw new PublishException("该分类不存在", true);
                }
            }
            else
            {
                throw new PublishException("页面参数错误", true);
            }
        }

        public bool ValidatePageFile()
        {
            bool IsValidate = false;
            //FileInfo ListFile = new FileInfo(PageFileName);

            //if (ListFile.Exists && ListFile.LastWriteTime.AddMinutes(config.CacheTime) > DateTime.Now)
            //    IsValidate = true;

            //CommonConfig common = CommonConfig.Instance();            

            //FileInfo ListFile = new FileInfo(PageFileName);

            //IsValidate = ListFile.Exists;

            //IsValidate = IsValidate && (common.IsStandardHeaderChanged(new FileInfo(config.MallHeader), config.PageValidateTempXml) && common.IsStandardFooterChanged(new FileInfo(config.MallFooter), config.PageValidateTempXml));

            return IsValidate;
        }

        public void CreatePageFile()
        {
            ListPageCreator creator = new ListPageCreator(PageParameter, config);
            creator.Create(PageFileName);
        }

        public bool DeletePageFile()
        {
            FileInfo BrandFile = new FileInfo(PageFileName);
            try
            {
                BrandFile.Delete();
                return true;
            }
            catch { return false; }
        }

        private ListPageParameter GetParameter(string Url)
        {
            ListPageParameter parm = null;

            string pattern = @"list(_|-)+(?<cfid>\d+)((_|-)+(?<pageIndex>\d+))?";

            Match match = Regex.Match(Url, pattern);

            if (match.Success)
            {
                parm = new ListPageParameter();
                parm.CategoryID = int.Parse(match.Groups["cfid"].Value);

                if (match.Groups["pageIndex"].Success)
                    parm.PageIndex = int.Parse(match.Groups["pageIndex"].Value);
            }

            if (parm.PageIndex == 0) parm.PageIndex = 1;

            return parm;
        }
    }

    public class ListPageParameter
    {
        private int _CategoryID;
        private int _PageIndex;

        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }
    }
}
