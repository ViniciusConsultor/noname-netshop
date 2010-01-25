using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Publish.Brand.DataAccess;
using log4net;
using NoName.NetShop.Publish.Configuration;
using System.Configuration;
using System.IO;
using NoName.NetShop.Publish.Brand.PageCreator;
using System.Text.RegularExpressions;
using System.Data;

namespace NoName.NetShop.Publish.Brand
{
    public class BrandPublishHandler : IPublishHandler
    {

        private BrandConfigurationSection config;
        private ILog Logger;
        private BrandPageParameter PageParameter = null;
        private BrandDataAccess dal;
        public string PageFileName
        {
            get;
            set;
        }

        public BrandPublishHandler(string Url)
        {
            config = (BrandConfigurationSection)ConfigurationManager.GetSection("publish/brandPublish");
            Logger = LogManager.GetLogger(config.Logger);
            dal = new BrandDataAccess(config);
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
                DataTable dt = dal.GetBrandInfo(PageParameter.BrandID);

                if (dt.Rows.Count > 0)
                {
                    DataRow BrandInfo = dt.Rows[0];

                    string FileName = "brand-{0}{1}{2}{3}.html";

                    FileName = String.Format(FileName,
                        PageParameter.BrandID,
                        PageParameter.PageIndex == 1 ? "" : "-" + PageParameter.PageIndex,
                        PageParameter.CategoryID == 0 ? "" : "-c" + PageParameter.CategoryID,
                        PageParameter.OrderType == 1 ? "" : "-o" + PageParameter.OrderType);

                    return config.RootPath + FileName;
                }
                else
                {
                    throw new PublishException("该品牌不存在", true);
                }
            }
            else
            {
                throw new PublishException("页面参数错误",true);
            }
        }


        public bool ValidatePageFile()
        {
            bool IsValidate = false;

            return IsValidate;
        }

        public void CreatePageFile()
        {
            BrandPageCreator creator = new BrandPageCreator(PageParameter, config);
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

        private BrandPageParameter GetParameter(string Url)
        {
            BrandPageParameter parm = null;

            string pattern = @"brand(_|-)+(?<brandid>\d+)((_|-)+(?<pageIndex>\d+))?((_|-)+c(?<cateid>\d+))?((_|-)+o(?<order>\d+))?";

            Match match = Regex.Match(Url, pattern);

            if (match.Success)
            {
                parm = new BrandPageParameter();

                parm.BrandID = Convert.ToInt32(match.Groups["brandid"].Value);

                if (match.Groups["pageIndex"].Success)
                    parm.PageIndex = Convert.ToInt32(match.Groups["pageIndex"].Value);       
                if (match.Groups["cateid"].Success)
                    parm.CategoryID = Convert.ToInt32(match.Groups["cateid"].Value);
                if (match.Groups["order"].Success)
                    parm.OrderType = Convert.ToInt32(match.Groups["order"].Value);                 
            }

            if (parm.PageIndex == 0) parm.PageIndex = 1;
            if (parm.OrderType == 0) parm.OrderType = 1;

            return parm; 
        }
    }

    public class BrandPageParameter
    {
        public int BrandID { get; set; }
        public int PageIndex { get; set; }
        public int CategoryID { get; set; }
        public int OrderType { get; set; } 
    }
}
