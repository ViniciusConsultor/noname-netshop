using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.Config;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using NoName.Utility;

namespace NoName.NetShop.MagicWorld.Facade
{
    public class MagicWorldImageRule
    {
        private static MagicWorldImageSection config = (MagicWorldImageSection)ConfigurationManager.GetSection("productImage/magicWorldImage");

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

            foreach (MagicWorldImageElement ImageType in config.ImageSets)
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
                ImageHelper ih = new ImageHelper();

                ih.LoadImage(OriginalFile.InputStream);

                for (int i = 2; i >= 0; i--)
                {
                    if (config.ImageSets[i].Width > 0 && config.ImageSets[i].Height > 0)
                    {
                        ih.ScaleImageByFixSize(config.ImageSets[i].Width, config.ImageSets[i].Height, true);
                    }
                    ih.SaveImage(config.PathRoot + FileNames[i]);
                }

                ih.Dispose();
                //foreach (string FileName in FileNames)
                //{
                //    //缩小图片为设置尺寸注意图片尺寸与名称对应
                //    OriginalFile.SaveAs(config.PathRoot + FileName);
                //}

                ProcessResult = true;
            }

            return ProcessResult;
        }

        public static string GetMainImageUrl(string ImageRelativePath)
        {
            return config.UrlRoot + ImageRelativePath;
        }
    }
}
