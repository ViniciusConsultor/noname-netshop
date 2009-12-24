using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using NoName.NetShop.CMS.Model;
using System.Configuration;

namespace NoName.NetShop.CMS.Controler
{
    public class TemplateControler
    {
        public static DataTable GetTagList(int PageID)
        {
            PageModel page = PageControler.GetModel(PageID);

            StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath(page.TempatePath), Encoding.UTF8);

            MatchCollection matches = Regex.Matches(sr.ReadToEnd(), "(?<tag>(<dd:CMSTag.+/>))", RegexOptions.Multiline);
            sr.Close();


            DataTable dt = new DataTable();
            DataColumnCollection columns = dt.Columns;
            columns.Add("serverid", typeof(string));
            columns.Add("Description", typeof(string));
            columns.Add("TagID", typeof(string));
            columns.Add("examplepicture", typeof(string));
            columns.Add("ispublic", typeof(bool));
            columns.Add("tagname", typeof(string));

            foreach (Match match in matches)
                if (match.Success)
                {
                    string reg = "<dd:CMSTag ID=\"(?<serverid>(\\w+))\" Description=\"(?<des>(\\w+))\" TagID=\"(?<tagid>(\\d+))\" ";
                    Match m = Regex.Match(match.Groups[0].Value, reg, RegexOptions.IgnoreCase);
                    if (m.Groups["serverid"].Success && m.Groups["des"].Success && m.Groups["tagid"].Success)
                    {
                        DataRow row = dt.NewRow();
                        row["serverid"] = m.Groups["serverid"].Value;
                        row["Description"] = m.Groups["des"].Value;
                        row["TagID"] = m.Groups["tagid"].Value;

                        TagModel tag = TagControler.GetModel(Convert.ToInt32(m.Groups["tagid"].Value));

                        row["examplepicture"] = tag.ExamplePicture;
                        row["ispublic"] = tag.IsPublic;
                        row["tagname"] = tag.TagName;

                        dt.Rows.Add(row);
                    }
                }



            return dt;
        }

        public static DataTable GetTemplateList(PageCategory pageCate)
        {
            /* 建立模板时的命名规则 */
            // Template_HomePage_Index.aspx
            // Template_{PageCategoryName}_{TemplateName}.aspx

            string TemplateRootPath = ConfigurationManager.AppSettings["templateRootPath"];

            Regex reg = new Regex(@"Template_(?<cate>\w+)_(?<page>\w+).aspx");

            DataTable dt = new DataTable(); dt.Columns.Add("fullname");dt.Columns.Add("cate");dt.Columns.Add("name");

            foreach (string f in Directory.GetFiles(TemplateRootPath))
            {
                Match match = reg.Match(f);

                if (match.Success)
                {
                    DataRow row = dt.NewRow();

                    row["fullname"] = "\\cms" + Regex.Split(f, "cms",RegexOptions.IgnoreCase)[1];
                    row["cate"] = match.Groups["cate"].Value;
                    row["name"] = f.Substring(f.LastIndexOf("\\")+1);

                    dt.Rows.Add(row);
                }
            }

            DataTable newTable = dt.Clone();
            foreach(DataRow row in dt.Select("cate = '"+pageCate.ToString()+"'")) newTable.ImportRow(row);

            return newTable;
        }
    }
}
