using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.CMS.Data;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using NoName.NetShop.CMS.Config;
using System.Configuration;
using NoName.Utility;

namespace NoName.NetShop.CMS.Model
{
    public class PageInfo
    {
        private int _PageID;
        private string _TemplatePath;
        private string _PhysicalPath;
        private string _PageName;
        private string _PageTitle;
        private DateTime _CreateTime;
        private DateTime _UpdateTime;
        private string _Author;
        private string _LastModify;
        private PageCategory _Category;

        public int PageID
        {
            get { return _PageID; }
            set { _PageID = value; }
        }
        public string TemplatePath
        {
            get { return _TemplatePath; }
            set { _TemplatePath = value; }
        }
        public string PhysicalPath
        {
            get { return _PhysicalPath; }
            set { _PhysicalPath = value; }
        }
        public string PageName
        {
            get { return _PageName; }
            set { _PageName = value; }
        }
        public string PageTitle
        {
            get { return _PageTitle; }
            set { _PageTitle = value; }
        }
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime = value; }
        }
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }
        public string LastModify
        {
            get { return _LastModify; }
            set { _LastModify = value; }
        }
        public PageCategory Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        public static PageInfo GetPageInfo(int pageID)
        {
            DataTable dt = DataAccess.GetPageByID(pageID).Tables[0];

            PageInfo page = null;

            if (dt.Rows.Count > 0)
            {
                DataRow reader = dt.Rows[0];
                page = new PageInfo();
                page.PageID = Convert.ToInt32(reader["id"]);
                page.Author = Convert.ToString(reader["author"]);
                page.CreateTime = Convert.ToDateTime(reader["createtime"]);
                page.UpdateTime = Convert.ToDateTime(reader["updatetime"]);
                page.LastModify = Convert.ToString(reader["lastmodify"]);
                page.PageName = Convert.ToString(reader["pagename"]);
                page.PageTitle = Convert.ToString(reader["pagetitle"]);
                page.PhysicalPath = Convert.ToString(reader["physicalpath"]);
                page.TemplatePath = Convert.ToString(reader["template"]);
                int c = Convert.ToInt32(reader["category"]);
                page.Category = c == 1 ? PageCategory.Index : (c == 2 ? PageCategory.SecondaryPage : PageCategory.TopicPage);
            }

            return page;
        }

        public DataTable GetTemplateTags()
        {
            StreamReader sr = new StreamReader(TemplatePath.Substring(1,TemplatePath.Length-1).StartsWith(":\\")? TemplatePath : HttpContext.Current.Server.MapPath(TemplatePath), Encoding.UTF8);

            MatchCollection matches = Regex.Matches(sr.ReadToEnd(), "(?<tag>(<NetShop:CMSTag.+/>))", RegexOptions.Multiline);
            sr.Close();

            DataTable dt = new DataTable();
            DataColumnCollection columns = dt.Columns;
            columns.Add("serverid", typeof(string));
            columns.Add("Description", typeof(string));
            columns.Add("TagID", typeof(string));

            foreach (Match match in matches)
                if (match.Success)
                {
                    string reg = "<NetShop:CMSTag ID=\"(?<serverid>(\\w+))\" Description=\"(?<des>(\\w+))\" TagID=\"(?<tagid>(\\w+))\" ";
                    Match m = Regex.Match(match.Groups[0].Value, reg, RegexOptions.IgnoreCase);
                    if (m.Groups["serverid"].Success && m.Groups["des"].Success && m.Groups["tagid"].Success)
                    {
                        DataRow row = dt.NewRow();
                        row["serverid"] = m.Groups["serverid"].Value;
                        row["Description"] = m.Groups["des"].Value;
                        row["TagID"] = m.Groups["tagid"].Value;
                        dt.Rows.Add(row);
                    }
                }

            return dt;
        }

        public bool PublishPageFile()
        {
            string url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + this.TemplatePath + "?pageid=" + this.PageID;

            string html = HttpUtil.SendGetRequest(url);

            string FileName = this.PhysicalPath.Substring(1).StartsWith(":\\") ? this.PhysicalPath : HttpContext.Current.Server.MapPath(this.PhysicalPath);

            if (!FileName.EndsWith(".shtml") && !FileName.EndsWith(".html") && !FileName.EndsWith(".htm"))
            {
                if (!Directory.Exists(FileName)) Directory.CreateDirectory(FileName);
                FileName = FileName.EndsWith("\\") ? FileName + "index.shtml" : FileName + "\\index.shtml";
            }

            StreamWriter sw = new StreamWriter(FileName);

            sw.Write(html);
            sw.Flush();
            sw.Close();

            return true;
        }
    }

    public enum PageCategory
    {
        Index = 1,
        SecondaryPage = 2,
        TopicPage = 3
    }
}
