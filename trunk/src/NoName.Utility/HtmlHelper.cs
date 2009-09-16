using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Specialized;

namespace NoName.Utility
{
    public class HtmlHelper
    {
        public static string GetBodyContent(string Html)
        {
            Match match = Regex.Match(Html, @"(.|\r|\n)+<body>(?<content>(.|\r|\n)+)</body>(.|\r|\n)+", RegexOptions.Multiline);

            if (match.Success)
                return match.Groups["content"].Value;
            else
                return String.Empty;
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

        public static StringCollection GetTemplateTags(string Content)
        {
            Match match = Regex.Match(Content, "(?<tag>(<NetShop:CMSTag.+/>))", RegexOptions.Multiline);
            StringCollection sc = new StringCollection();

            if (match.Success)
            {
                foreach (Group gc in match.Groups)
                {
                    sc.Add(gc.Value);
                }
                return sc;
            }
            else return null;
        }
    }
}
