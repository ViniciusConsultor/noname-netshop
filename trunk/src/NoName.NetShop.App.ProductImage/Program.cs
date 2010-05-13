using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using NoName.NetShop.Product.Facade;
using System.IO;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Common;
using NoName.Utility;
using System.Net;
using System.Data;

namespace NoName.NetShop.App.ProductImage
{
    class Program
    {
        private static Database db = Common.CommDataAccess.DbReader;
        private static string UrlPrefix = ConfigurationManager.AppSettings["urlPrefix"];
        private static string TempPath = ConfigurationManager.AppSettings["tempPath"];
        private static ProductModelBll pbll = new ProductModelBll();
        private static ProductImageModelBll imgBll = new ProductImageModelBll();

        static void Main(string[] args)
        {
            string sql = "select productid,productphoto,productphoto01,productphoto02,productphoto03 from my_products where productid in (230,231,232,233,234,241,243,244,246,247)";

            IDataReader reader = db.ExecuteReader(CommandType.Text, sql);

            while (reader.Read())
            {
                Console.WriteLine(reader["productid"]);
                int ProductID = Convert.ToInt32(reader["productid"]);

                AddProductMainImage(ProductID, reader["productphoto"].ToString());

                for (int i = 1; i <= 3; i++)
                {
                    string key = "productphoto0" + i;
                    AddProductMultiImage(ProductID, reader[key].ToString());
                }
            }

            Console.Read();
        }



        private static void AddProductMainImage(int ProductID, string ImageRelativeURL)
        {
            string ImageFullURL = UrlPrefix + ImageRelativeURL;
            FileInfo ImageFile = DownloadImage(ImageFullURL);
            string[] MainImages;

            ProductMainImageRule.SaveProductMainImage(ProductID, ImageFile, out MainImages);

            pbll.UpdateProductMainImage(ProductID,MainImages);
        }

        private static void AddProductMultiImage(int ProductID, string ImageRelativeURL)
        {
            string ImageFullURL = UrlPrefix + ImageRelativeURL;
            FileInfo ImageFile = DownloadImage(ImageFullURL);
            string[] MultiImages;

            ProductMultiImageRule.SaveProductMultiImage(ProductID, ImageFile, out MultiImages);

            ProductImageModel model = new ProductImageModel();

            model.ImageId = CommDataHelper.GetNewSerialNum("pd");
            model.ProductId = ProductID;
            model.LargeImage = MultiImages[1];
            model.OriginImage = MultiImages[2];
            model.SmallImage = MultiImages[0];
            model.Title = String.Empty;

            imgBll.Add(model); 
        }

        private static FileInfo DownloadImage(string ImageURL)
        {
            string FileName = TempPath + Guid.NewGuid() + ImageURL.Substring(ImageURL.Length - 4);

            WebClient client = new WebClient();
            client.DownloadFile(ImageURL, FileName);

            return new FileInfo(FileName);
        }
    }
}
