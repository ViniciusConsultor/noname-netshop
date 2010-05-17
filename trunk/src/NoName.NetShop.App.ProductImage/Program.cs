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
            //string sql = "select productid,productphoto,productphoto01,productphoto02,productphoto03 from my_products where productid in (230,231,232,233,234,241,243,244,246,247)";
            string sql = "select productid,productphoto,productphoto01,productphoto02,productphoto03 from my_products";

            IDataReader reader = db.ExecuteReader(CommandType.Text, sql);

            while (reader.Read())
            {
                try
                {
                    Console.WriteLine(reader["productid"]);
                    int ProductID = Convert.ToInt32(reader["productid"]);

                    string CatePath = GetProductCategoryPath(ProductID);
                    if (!String.IsNullOrEmpty(CatePath))
                    {
                        AddProductMainImage(ProductID, CatePath, reader["productphoto"].ToString());

                        for (int i = 1; i <= 3; i++)
                        {
                            string key = "productphoto0" + i;
                            AddProductMultiImage(ProductID, CatePath, reader[key].ToString());
                        }

                        UpdateImageFlag(ProductID);
                        Console.WriteLine("succ!");
                    }
                }
                catch
                {
                    continue;
                    Console.WriteLine("fail!");
                }
            }

            Console.Read();
        }



        private static void AddProductMainImage(int ProductID, string CatePath, string ImageRelativeURL)
        {
            string ImageFullURL = UrlPrefix + ImageRelativeURL;
            FileInfo ImageFile = DownloadImage(ImageFullURL);
            if (!ImageFile.Directory.Exists) Directory.CreateDirectory(ImageFile.Directory.FullName);
            string[] MainImages;
            ProductMainImageRule.SaveProductMainImage(ProductID, CatePath, ImageFile, out MainImages);

            pbll.UpdateProductMainImage(ProductID, MainImages);
        }

        private static void AddProductMultiImage(int ProductID, string CatePath, string ImageRelativeURL)
        {
            string ImageFullURL = UrlPrefix + ImageRelativeURL;
            FileInfo ImageFile = DownloadImage(ImageFullURL);
            if (!ImageFile.Directory.Exists) Directory.CreateDirectory(ImageFile.Directory.FullName);
            string[] MultiImages;

            ProductMultiImageRule.SaveProductMultiImage(ProductID, CatePath, ImageFile, out MultiImages);

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

        private static void UpdateImageFlag(int ProductID)
        {
            string sql = "update my_products set imageflag=1 where productid="+ProductID;
            db.ExecuteNonQuery(CommandType.Text,sql);
        }

        private static string GetProductCategoryPath(int ProductID)
        {
            string sql = "select catepath from pdproduct where productid="+ProductID;

            return Convert.ToString(db.ExecuteScalar(CommandType.Text, sql));
        }
    }
}
