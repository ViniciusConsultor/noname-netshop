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
    public class ProductMultiImageRule
    {
        private static ProductMultiImageSection config = (ProductMultiImageSection)ConfigurationManager.GetSection("productImage/productMultiImage");


        public static string[] GetMultiImageName(int ProductID, string FileSuffix)
        {
            ArrayList MultiImageFileNames = new ArrayList();
            string guid = Guid.NewGuid().ToString();

            foreach (ProductMainImageElement ImageType in config.ImageTypes)
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
                foreach (string FileName in FileNames)
                {
                    //缩小图片为设置尺寸
                    OriginalFile.SaveAs(config.PathRoot + FileName);
                }

                ProcessResult = true;
            }

            return ProcessResult;
        }


        public ProductImageModel GetMultiImageUrl(ProductImageModel MultiImage)
        {
            MultiImage.SmallImage = config.UrlRoot + MultiImage.SmallImage;
            MultiImage.LargeImage = config.UrlRoot + MultiImage.LargeImage;
            MultiImage.OriginImage = config.UrlRoot + MultiImage.OriginImage;

            return MultiImage;
        }

    }
}
