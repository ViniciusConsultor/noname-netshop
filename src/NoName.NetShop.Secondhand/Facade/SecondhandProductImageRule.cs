using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NoName.NetShop.Secondhand.Config;
using System.Configuration;
using System.IO;
using NoName.NetShop.Secondhand.Model;
using System.Web;

namespace NoName.NetShop.Secondhand.Facade
{
    public class SecondhandProductImageRule
    {
        private static SecondhandImageSection config = (SecondhandImageSection)ConfigurationManager.GetSection("productImage/secondhandImage");



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

            foreach (SecondhandImageElement ImageType in config.ImageSets)
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

        public static SecondhandProductModel GetMainImageUr(SecondhandProductModel model)
        {
            model.SmallImage = config.UrlRoot + model.SmallImage;
            model.MediumImage = config.UrlRoot + model.MediumImage;
            model.LargeImage = config.UrlRoot + model.LargeImage;

            return model;
        }

        public static string GetMainImageUrl(string ImageRelativePath)
        {
            return config.UrlRoot + ImageRelativePath;
        }
    }
}
