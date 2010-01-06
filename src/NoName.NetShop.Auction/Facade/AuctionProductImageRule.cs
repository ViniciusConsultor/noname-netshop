using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Auction.Config;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using NoName.NetShop.Auction.Model;

namespace NoName.NetShop.Auction.Facade
{
    public class AuctionProductImageRule
    {
        private static AuctionImageSection config = (AuctionImageSection)ConfigurationManager.GetSection("productImage/auctionImage");



        /// <summary>
        /// Returns destination product main image names
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="FileSuffix">Image file suffix without "."</param>
        /// <returns></returns>
        public static string[] GetMainImageName(int ProductID, string FileSuffix)
        {
            ArrayList MainImageFileNames = new ArrayList();
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            foreach (AuctionImageElement ImageType in config.ImageSets)
            {
                MainImageFileNames.Add(string.Format(config.Rule, ProductID, guid, ImageType.Suffix, FileSuffix));
            }

            return (string[])MainImageFileNames.ToArray(typeof(string));
        }

        public static bool SaveProductMainImage(int ProductID, HttpPostedFile OriginalFile, out string[] FileNames)
        {
            string FileSuffix = Path.GetExtension(OriginalFile.FileName).Substring(1);
            bool ProcessResult = false;
            FileNames = GetMainImageName(ProductID, FileSuffix);
            if (!Directory.Exists(config.PathRoot)) Directory.CreateDirectory(config.PathRoot);

            if (config.AllowedFormat.ToLower().Contains(FileSuffix.ToLower()) && config.MaxSize * 1024 >= OriginalFile.ContentLength)
            {
                foreach (string FileName in FileNames)
                {
                    //缩小图片为设置尺寸注意图片尺寸与名称对应
                    OriginalFile.SaveAs(config.PathRoot + FileName);
                }

                ProcessResult = true;
            }

            return ProcessResult;
        }

        public static AuctionProductModel GetMainImageUr(AuctionProductModel model)
        {
            model.SmallImage = config.UrlRoot + model.SmallImage;
            model.MediumImage = config.UrlRoot + model.MediumImage;

            return model;
        }

        public static string GetMainImageUrl(string ImageRelativePath)
        {
            return config.UrlRoot + ImageRelativePath;
        }
    }
}
