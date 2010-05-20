using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using NoName.NetShop.Publish.Configuration;
using NoName.NetShop.Publish.Product.DataAccess;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
using NoName.NetShop.Publish.Product.PageCreator;
using System.IO;

namespace NoName.NetShop.Publish.Product
{
    public class ProductPublishHandler : IPublishHandler
    {
        private ProductConfigurationSection config;
        private ILog Logger;
        private ProductPageParameter PageParameter = null;
        private ProductDataAccess dal;
        public string PageFileName
        {
            get;
            set;
        }

        public ProductPublishHandler(string Url)
        {
            config = (ProductConfigurationSection)ConfigurationManager.GetSection("publish/productPublish");
            dal = new ProductDataAccess(config);
            Logger = LogManager.GetLogger(config.Logger);
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
                string ClassificationPath = PageParameter.CategoryPath;

                if (!String.IsNullOrEmpty(ClassificationPath))
                {
                    string RelativePath = ClassificationPath.Replace("/", "\\") + "\\";

                    string PageName = PageParameter.ProductID + ".html";

                    return config.RootPath + RelativePath + PageName;
                }
                else
                {
                    throw new PublishException("该商品不存在", true);
                }
            }
            else
            {
                throw new PublishException("页面参数错误", true);
            } 
        }

        public bool ValidatePageFile()
        {
            return false;
        }

        public void CreatePageFile()
        {
            ProductPageCreator creator = new ProductPageCreator(PageParameter, config);
            creator.Create(PageFileName);
        }

        public bool DeletePageFile()
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


        private ProductPageParameter GetParameter(string Url)
        {
            Regex newProductPattern = new Regex(@"/product(_|-)+(?<productid>\d+)\.product$", RegexOptions.IgnoreCase);//新产品页URL格式

            ProductPageParameter parm = null;
            Match match = newProductPattern.Match(Url);
            if (match.Success)
            {
                parm = new ProductPageParameter();

                parm.ProductID = int.Parse(match.Groups["productid"].Value);

            }

            DataTable dt = dal.GetProductCategoryPath(parm.ProductID);

            if (dt.Rows.Count > 0)
            {
                parm.CategoryPath = dt.Rows[0]["catepath"].ToString();
                parm.CategoryID = int.Parse(dt.Rows[0]["cateid"].ToString());
            }

            return parm;
        }
    }


    public class ProductPageParameter
    {
        private int _ProductID;
        private int _CategoryID;
        private string _CategoryPath;


        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
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
    }
}
