using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.UI.WebControls;
using System.IO;
using NoName.NetShop.Common.Configuration;

namespace NoName.NetShop.Common
{
    public class CommonImageUpload
    {
        private static CommonImageUploadSection Config = (CommonImageUploadSection)ConfigurationManager.GetSection("commonImage");

        public static bool Upload(FileUpload control,out string ImageUrl,out string ImageShortUrl,out string Message)
        {
            string RootPath = Config.RootPath;
            bool Result = false;

            ImageUrl = String.Empty;
            ImageShortUrl = String.Empty;
            Message = String.Empty;

            if (!String.IsNullOrEmpty(control.FileName))
            {
                //用日期作为分割子文件夹的依据，防止文件在同一个文件夹下堆积过多导致IO效率降低
                string RelativePath = DateTime.Today.ToString("yyyy-MM") + "\\";
                string FileExtension = Path.GetExtension(control.FileName).ToLower();
                string FileName = Guid.NewGuid().ToString() + FileExtension;

                if (control.PostedFile.ContentLength <= Config.MaxSize && Config.AllowedFormat.Contains(FileExtension.Substring(1)))
                {
                    if (!Directory.Exists(RootPath + RelativePath)) Directory.CreateDirectory(RootPath + RelativePath);
                    control.SaveAs(RootPath + RelativePath + FileName);
                    ImageUrl = (Config.RootUrl + RelativePath + FileName).Replace("\\","/");
                    ImageShortUrl = ImageUrl.Replace(Config.UrlPrefix,String.Empty);
                    Result = true;
                }
                else
                {
                    Message = String.Format("只允许上传{0}格式的图片，且大小不可超过{1}kb",Config.AllowedFormat,Config.MaxSize/1024);
                }
            }
            else
            {
                Message = "上传文件不能为空";
            }



            return Result;
        }

        public static string GetCommonImageFullUrl(string ShortUrl)
        {
            return ConfigurationManager.AppSettings["foreFlatRootUrl"] + ShortUrl;
        }
    }
}
