using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Product.Config;
using System.Configuration;
using System.Web;
using System.IO;

namespace NoName.NetShop.Product.Facade
{
    public class ProductDescriptionImageRule
    {
        private static ProductDescriptionImageSection config = (ProductDescriptionImageSection)ConfigurationManager.GetSection("productImage/productDescriptionImage");

        public static string GetDescriptionImageName(string FileSuffix)
        {
            string guid = Guid.NewGuid().ToString();
            return String.Format(config.Rule,guid,FileSuffix); 
        }

        public static bool SaveDescriptionImage(HttpPostedFile OriginalFile)
        {
            string FileSuffix = Path.GetExtension(OriginalFile.FileName).Substring(1);
            bool ProcessResult = false;

            string FileName = GetDescriptionImageName(FileSuffix);

            if (config.AllowedFormat.ToLower().Contains(FileSuffix.ToLower()) && config.MaxSize * 1024 >= OriginalFile.ContentLength)
            {
                OriginalFile.SaveAs(config.PathRoot + FileName);
                ProcessResult = true; 
            }

            return ProcessResult; 
        }
    }
}
