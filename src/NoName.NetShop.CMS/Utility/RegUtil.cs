using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

namespace NoName.NetShop.CMS.Utility
{
    public class RegUtil
    {
        public static string GetBodyContent(string Html)
        {
            if (Html.Contains("<body>") && Html.Contains("</body>"))
            {
                string[] a = Regex.Split(Html, "<body>");
                string[] b = Regex.Split(a[1], "</body>");

                return b[0];
            }
            else
            {
                return String.Empty;
            }
        }

        public static string GetBodyContent(StreamReader sr)
        {
            string html = sr.ReadToEnd();
            return GetBodyContent(html);
        }

        public static string GetBodyContent(string FileName, Encoding encode)
        {
            StreamReader sr = new StreamReader(FileName, encode);
            return GetBodyContent(sr.ReadToEnd());
        }


        public static DataTable GetLinkKeyValue(string Input)
        {
            DataTable dt = new DataTable();

            DataColumnCollection column = dt.Columns;
            column.Add("word");
            column.Add("link");

            string[] vs = Regex.Split(Input, @"(\r\n)|(\n)|(\r)");

            foreach (string v in vs)
            {
                if (!String.IsNullOrEmpty(v) && v.Contains("|"))
                {
                    DataRow nrow = dt.NewRow();

                    nrow["word"] = v.Split('|')[0].Replace("[", "");
                    nrow["link"] = v.Split('|')[1].Replace("]", "").Replace("{$}", "=").Replace("{^}", "&");

                    dt.Rows.Add(nrow);
                }
            }

            return dt;
        }

        public static DataTable GetTitleTextLinkTable(string Input)
        {
            DataTable dt = new DataTable();

            DataColumnCollection column = dt.Columns;
            column.Add("title");
            column.Add("word");
            column.Add("link");

            string[] vs = Regex.Split(Input, @"\r\n");

            foreach (string v in vs)
            {
                if (!String.IsNullOrEmpty(v) && v.Contains("|"))
                {
                    DataRow nrow = dt.NewRow();

                    nrow["title"] = v.Split('|')[0].Replace("[", "");
                    nrow["word"] = v.Split('|')[1].Replace("[", "");
                    nrow["link"] = v.Split('|')[2].Replace("]", "").Replace("{$}", "=").Replace("{^}", "&");

                    dt.Rows.Add(nrow);
                }
            }

            return dt;
        }
    }
}
