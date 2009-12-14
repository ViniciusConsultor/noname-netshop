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
using System.Collections;

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

                    string ProperityString = "p";
                    foreach (string key in PageParameter.Properities.Keys)
                    {
                        ProperityString += key + "-" + PageParameter.Properities[key] + ",";
                    }
                    ProperityString += ProperityString.Substring(0, ProperityString.Length - 1) + "e";

                    string PageName = String.Format("list_{0}{1}{2}{3}.html",
                        PageParameter.CategoryID, PageParameter.PageIndex <= 1 ? "" : "_" + PageParameter.PageIndex.ToString(),
                        PageParameter.OrderValue == 0 ? "" : "-o"+PageParameter.OrderValue.ToString()/*order*/,
                        PageParameter.Properities == null ? "" : "-"+ProperityString/*properity*/);

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

            string pattern = @"list(_|-)+(?<cfid>\d+)((_|-)+(?<pageIndex>\d+))?((_|-)+o(?<order>\d+))?((_|-)+p(?<properity>.+)e)";

            Match match = Regex.Match(Url, pattern);

            if (match.Success)
            {
                parm = new ListPageParameter();
                parm.Properities = null;
                parm.OrderValue = 0;
                parm.CategoryID = int.Parse(match.Groups["cfid"].Value);

                if (match.Groups["pageIndex"].Success)
                    parm.PageIndex = int.Parse(match.Groups["pageIndex"].Value);
                if (match.Groups["order"].Success)
                    parm.OrderValue = int.Parse(match.Groups["order"].Value);
                if (match.Groups["properity"].Success)
                {
                    parm.Properities = new Hashtable();
                    foreach (string pv in match.Groups["properity"].Value.Split(','))
                    {
                        parm.Properities.Add(pv.Split('-')[0],pv.Split('-')[1]);
                    }
                }
            }

            if (parm.PageIndex == 0) parm.PageIndex = 1;

            return parm;
        }
    }

    public class ListPageParameter
    {
        private int _CategoryID;
        private int _PageIndex;
        private int _OrderValue;
        private Hashtable _Properities;
        

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
        public int OrderValue
        {
            get { return _OrderValue; }
            set { _OrderValue = value; }
        }
        public Hashtable Properities
        {
            get { return _Properities; }
            set { _Properities = value; }
        }
    }
}
