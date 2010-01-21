using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.News.Config;
using System.Configuration;
using NoName.NetShop.News.Model;
using System.Web;
using System.IO;

namespace NoName.NetShop.News.Facade
{
    public class NewsImageRule
    {
        static NewsImageSection Config = (NewsImageSection)ConfigurationManager.GetSection("newsUpload/newsImage");

        public static bool SaveNewsImage(int NewsID, HttpPostedFile OriginalFile, out string ImageFileName)
        {
            string FileSuffix = Path.GetExtension(OriginalFile.FileName).Substring(1);
            bool ProcessResult = false;

            string FileName = String.Format(Config.Rule, NewsID, Guid.NewGuid(), FileSuffix);

            if (Config.AllowedFormat.ToLower().Contains(FileSuffix.ToLower()) && Config.MaxSize * 1024 >= OriginalFile.ContentLength)
            {
                OriginalFile.SaveAs(Config.PathRoot + FileName);
                ProcessResult = true;
            }

            ImageFileName = FileName;
            return ProcessResult;
        }

        public static NewsModel GetImageUrl(NewsModel model)
        {
            model.ImageUrl = Config.UrlRoot + model.ImageUrl;

            return model;
        }

        public static string GetImageUrl(string ImageShortUrl)
        {
            return Config.UrlRoot + ImageShortUrl;
        }
    }
}

