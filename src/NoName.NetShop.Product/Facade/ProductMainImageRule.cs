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

namespace NoName.NetShop.Product.Facade
{
    public class ProductMainImageRule
    {
        private static ProductMainImageSection config = (ProductMainImageSection)ConfigurationManager.GetSection("productImage/productMainImage");

        /// <summary>
        /// Returns destination product main image names
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="FileSuffix">Image file suffix without "."</param>
        /// <returns></returns>
        public static string[] GetMainImageName(int ProductID, string FileSuffix)
        {
            ArrayList MainImageFileNames = new ArrayList();

            foreach (ProductMainImageElement ImageType in config.ImageTypes)
            {
                MainImageFileNames.Add(string.Format(config.Rule, ProductID, ImageType.Suffix, FileSuffix));
            }

            return (string[])MainImageFileNames.ToArray(typeof(string));
        }

        public static bool SaveProductMainImage(int ProductID, HttpPostedFile OriginalFile,out string[] FileNames)
        {
            string FileSuffix = Path.GetExtension(OriginalFile.FileName).Substring(1);
            bool ProcessResult = false;
            FileNames = GetMainImageName(ProductID, FileSuffix);

            if (config.AllowedFormat.ToLower().Contains(FileSuffix.ToLower()) && config.MaxSize*1024 >= OriginalFile.ContentLength)
            {
                foreach (string FileName in FileNames)
                {
                    //缩小图片为设置尺寸
                    OriginalFile.SaveAs(config.PathRoot + FileName);
                }

                ProcessResult = true;
            }

            return ProcessResult;
        }

        public static ProductModel GetMainImageUr(ProductModel Product)
        {
            Product.SmallImage = config.UrlRoot + Product.SmallImage;
            Product.MediumImage = config.UrlRoot + Product.MediumImage;
            Product.LargeImage = config.UrlRoot + Product.LargeImage;

            return Product;
        }






    }
}
