using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using NoName.NetShop.CMS.Model;

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

            foreach (Match match in matches)
                if (match.Success)
                {
                    string reg = "<SinaEC:CMSTag ID=\"(?<serverid>(\\w+))\" Description=\"(?<des>(\\w+))\" TagID=\"(?<tagid>(\\w+))\" ";
                    Match m = Regex.Match(match.Groups[0].Value, reg, RegexOptions.IgnoreCase);
                    if (m.Groups["serverid"].Success && m.Groups["des"].Success && m.Groups["tagid"].Success)
                    {
                        DataRow row = dt.NewRow();
                        row["serverid"] = m.Groups["serverid"].Value;
                        row["Description"] = m.Groups["des"].Value;
                        row["TagID"] = m.Groups["tagid"].Value;
                        row["examplepicture"] = TagControler.GetModel(Convert.ToInt32(m.Groups["tagid"].Value)).ExamplePicture;

                        dt.Rows.Add(row);
                    }
                }

            return dt;
        }
    }
}
