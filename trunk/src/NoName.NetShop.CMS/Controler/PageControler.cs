using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Web;
using NoName.NetShop.CMS.Model;
using NoName.NetShop.CMS.DataAccess;
using NoName.Utility;
using NoName.NetShop.CMS.Config;
using System.Configuration;
using NoName.NetShop.CMS.Utility;

namespace NoName.NetShop.CMS.Controler
{
    public class PageControler
    {
        public static PageModel GetModel(int PageID)
        {
            PageModel model = null;

            DataTable dt = PageDataAccess.Get(PageID);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                model = new PageModel();

                model.PageID = Convert.ToInt32(row["pageid"]);
                model.PageName = Convert.ToString(row["pagename"]);
                model.PageTitle = Convert.ToString(row["pagetitle"]);
                model.Category = Convert.ToInt32(row["category"]);
                model.Author = Convert.ToString(row["author"]);
                model.CreateTime = Convert.ToDateTime(row["createtime"]);
                model.LastModify = Convert.ToString(row["lastmodify"]);
                model.TempatePath = Convert.ToString(row["templatepath"]);
                model.PhysicalPath = Convert.ToString(row["physicalpath"]);
                model.UpdateTime = Convert.ToDateTime(row["updatetime"]);
                model.SelfClassid = Convert.ToInt32(row["selfclassid"]);
                model.ExtendPageInfo = Convert.ToString(row["extendpageinfo"]);
            }

            return model;
        }


        public static void Insert(PageModel page)
        {
            PageDataAccess.Insert(page);
        }

        public static void Delete(int PageID)
        {
            PageDataAccess.Delete(PageID);
        }

        public static void Update(PageModel page)
        {
            PageDataAccess.Update(page);
        }

        public static DataTable Get(int PageID)
        {
            return PageDataAccess.Get(PageID);
        }

        public static DataTable GetList(int PageIndex, int PageSize, PageCategory pageCate, out int RecordCount)
        {
            return PageDataAccess.GetList(PageIndex, PageSize, pageCate, out RecordCount);
        }

        public static void Publish(int PageID)
        {
            PageModel page = GetModel(PageID);

            string url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + page.TempatePath.Replace("\\","/") + "?pageid=" + page.PageID;

            string html = PublishUtil.SendGetRequest(url, null, Encoding.UTF8, Encoding.UTF8);

            PageCategoryElement Element = ((PageCategorySection)ConfigurationManager.GetSection("pageCategorySection")).PageCategories[Enum.GetName(typeof(PageCategory),page.Category)];
            string FileName = Element.PhysicalPathRoot + (page.PhysicalPath.StartsWith("\\") ? page.PhysicalPath.Substring(1, page.PhysicalPath.Length) : page.PhysicalPath);

            if (!FileName.EndsWith(".shtml") && !FileName.EndsWith(".html") && !FileName.EndsWith(".htm"))
            {
                if (!Directory.Exists(FileName)) Directory.CreateDirectory(FileName);
                FileName = FileName.EndsWith("\\") ? FileName + "index.shtml" : FileName + "\\index.shtml";
            }

            if (!(new FileInfo(FileName).Directory).Exists) (new FileInfo(FileName).Directory).Create();
            StreamWriter sw = new StreamWriter(FileName);

            sw.Write(html);
            sw.Flush();
            sw.Close();
        }


        public static void GetPageUrl(int PageID, PageCategoryElement PageCategory, out string PreviewUrl, out string FormalUrl)
        {
            PageModel page = GetModel(PageID);


            PreviewUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + page.TempatePath.Replace("\\","/") + "?pageid=" + page.PageID;
            FormalUrl = PageCategory.RootUrl + page.PhysicalPath.Replace("\\", "/");
        }

    }
}
