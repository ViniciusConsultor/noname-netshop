using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.News.Config;
using System.Configuration;
using System.IO;
using System.Web;
using NoName.NetShop.News.Model;

namespace NoName.NetShop.News.Facade
{
    public class NewsVideoRule
    {
        static NewsVideoSection Config = (NewsVideoSection)ConfigurationManager.GetSection("newsUpload/newsVideo");

        public static bool SaveNewsVideo(int NewsID, HttpPostedFile OriginalFile, out string VideoFileName)
        {
            string FileSuffix = Path.GetExtension(OriginalFile.FileName).Substring(1);
            bool ProcessResult = false;

            string FileName = String.Format(Config.Rule, NewsID, Guid.NewGuid(), FileSuffix);

            if (Config.AllowedFormat.ToLower().Contains(FileSuffix.ToLower()) && Config.MaxSize * 1024 >= OriginalFile.ContentLength)
            {
                OriginalFile.SaveAs(Config.PathRoot + FileName);

                //处理视频文件

                ProcessResult = true;
            }

            VideoFileName = FileName;
            return ProcessResult;
        }

        public static NewsModel GetVideoUrl(NewsModel model)
        {
            model.VideoUrl = Config.UrlRoot + model.VideoUrl;

            return model;
        }

        public static string GetVideoUrl(string VideoShortUrl)
        {
            return String.IsNullOrEmpty(VideoShortUrl) ? String.Empty : Config.UrlRoot + VideoShortUrl;
        }
    }
}
