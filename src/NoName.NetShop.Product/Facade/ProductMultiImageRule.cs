using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Product.Config;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using NoName.NetShop.Product.Model;
using NoName.Utility;

namespace NoName.NetShop.Product.Facade
{
    public class ProductMultiImageRule
    {
        private static ProductMultiImageSection config = (ProductMultiImageSection)ConfigurationManager.GetSection("productImage/productMultiImage");

        public static string[] GetMultiImageName(int ProductID, string FileSuffix)
        {
            ArrayList MultiImageFileNames = new ArrayList();
            string guid = Guid.NewGuid().ToString();

            foreach (ProductMultiImageElement ImageType in config.ImageTypes)
            {
                MultiImageFileNames.Add(string.Format(config.Rule, ProductID, ImageType.Suffix,guid, FileSuffix));
            }

            return (string[])MultiImageFileNames.ToArray(typeof(string));
        }

        public static bool SaveProductMultiImage(int ProductID, HttpPostedFile OriginalFile, out string[] FileNames)
        {
            string FileSuffix = Path.GetExtension(OriginalFile.FileName).Substring(1);
            bool ProcessResult = false;
            FileNames = GetMultiImageName(ProductID, FileSuffix);

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
                    ih.SaveImage(config.PathRoot + FileNames[i]);
                }

                ih.Dispose();

                ProcessResult = true;
            }

            return ProcessResult;
        }

        public static bool SaveProductMultiImage(int ProductID, FileInfo OriginalFile, out string[] FileNames)
        {
            string FileSuffix = Path.GetExtension(OriginalFile.FullName).Substring(1);
            bool ProcessResult = false;
            FileNames = GetMultiImageName(ProductID, FileSuffix);

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
                    ih.SaveImage(config.PathRoot + FileNames[i]);
                }

                ih.Dispose();

                ProcessResult = true;
            }

            return ProcessResult;
        }

        public static bool DeleteMultiImage(string  FileName)
        {
            try
            {
                File.Delete(config.PathRoot + FileName);
            }
            catch(Exception e)
            {}
            return true;
        }

        public static string GetMultiImageUrl(string ImageShortUrl)
        {
            return config.UrlRoot + ImageShortUrl;
        }

        public static ProductImageModel GetMultiImageUrl(ProductImageModel MultiImage)
        {
            MultiImage.SmallImage = config.UrlRoot + MultiImage.SmallImage;
            MultiImage.LargeImage = config.UrlRoot + MultiImage.LargeImage;
            MultiImage.OriginImage = config.UrlRoot + MultiImage.OriginImage;

            return MultiImage;
        }
    }
}
