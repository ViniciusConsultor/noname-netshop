using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using NoName.NetShop.GroupShopping.Config;
using System.Collections;
using System.Web;
using System.IO;
using NoName.Utility;
using NoName.NetShop.GroupShopping.Model;

namespace NoName.NetShop.GroupShopping.Facade
{
    public class GroupShoppingImageRule
    {
        private static GroupShoppingImageSection config = (GroupShoppingImageSection)ConfigurationManager.GetSection("productImage/groupShoppingImage");

        /// <summary>
        /// Returns destination product main image names
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="FileSuffix">Image file suffix without "."</param>
        /// <returns></returns>
        public static string[] GetImageName(int GroupProductID, string FileSuffix)
        {
            ArrayList MainImageFileNames = new ArrayList();

            foreach (GroupShoppingImageElement ImageType in config.ImageTypes)
            {
                MainImageFileNames.Add(string.Format(config.Rule, GroupProductID, ImageType.Suffix, FileSuffix));
            }

            return (string[])MainImageFileNames.ToArray(typeof(string));
        }

        public static bool SaveImage(int ProductID, HttpPostedFile OriginalFile, out string[] FileNames)
        {
            string FileSuffix = Path.GetExtension(OriginalFile.FileName).Substring(1);
            bool ProcessResult = false;
            FileNames = GetImageName(ProductID, FileSuffix);

            if (config.AllowedFormat.ToLower().Contains(FileSuffix.ToLower()) && config.MaxSize * 1024 >= OriginalFile.ContentLength)
            {
                ImageHelper ih = new ImageHelper();

                ih.LoadImage(OriginalFile.InputStream);

                for (int i = 2; i >= 0; i--)
                {
                    if (config.ImageTypes[i].Width > 0 && config.ImageTypes[i].Height > 0)
                    {
                        ih.ScaleImageByFixSize(config.ImageTypes[i].Width, config.ImageTypes[i].Height, true);
                    }
                    FileInfo tempFile = new FileInfo(config.PathRoot + FileNames[i].Replace("/", "\\"));
                    if (!tempFile.Directory.Exists) tempFile.Directory.Create();

                    ih.SaveImage(tempFile.FullName);
                }

                ih.Dispose();

                ProcessResult = true;
            }

            return ProcessResult;
        }


        public static bool SaveProductMainImage(int ProductID, FileInfo OriginalFile, out string[] FileNames)
        {
            string FileSuffix = Path.GetExtension(OriginalFile.FullName).Substring(1);
            bool ProcessResult = false;
            FileNames = GetImageName(ProductID, FileSuffix);

            if (config.AllowedFormat.ToLower().Contains(FileSuffix.ToLower()) && config.MaxSize * 1024 >= OriginalFile.Length)
            {
                ImageHelper ih = new ImageHelper();

                ih.LoadImage(new FileStream(OriginalFile.FullName, FileMode.Open));

                for (int i = 2; i >= 0; i--)
                {
                    if (config.ImageTypes[i].Width > 0 && config.ImageTypes[i].Height > 0)
                    {
                        ih.ScaleImageByFixSize(config.ImageTypes[i].Width, config.ImageTypes[i].Height, true);
                    }
                    FileInfo tempFile = new FileInfo(config.PathRoot + FileNames[i].Replace("/", "\\"));
                    if (!tempFile.Directory.Exists) tempFile.Directory.Create();

                    ih.SaveImage(tempFile.FullName);
                }

                ih.Dispose();

                ProcessResult = true;
            }

            return ProcessResult;
        }

        public static GroupProductModel GetImageUrl(GroupProductModel Product)
        {
            Product.SmallImage = config.UrlRoot + Product.SmallImage;
            Product.MediumImage = config.UrlRoot + Product.MediumImage;
            Product.LargeImage = config.UrlRoot + Product.LargeImage;

            return Product;
        }

        public static string GetImageUrl(string ImageShortUrl)
        {
            return config.UrlRoot + ImageShortUrl;

            
        }

    }
}
