using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

namespace NoName.NetShop.CMS.Utility
{
    public class XsltHelper
    {
        public static string TransformToHtml(string XsltFile, string XmlFile, Encoding encode)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(XmlFile);

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(XsltFile);

            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms, encode);

            xslt.Transform(xdoc, null, sw);
            sw.Flush();
            sw.Close();
            sw.Dispose();

            StreamReader sr = new StreamReader(ms, encode);
            string html = sr.ReadToEnd();
            ms.Close();
            sr.Close();

            return html;
        }


        public static string TransformToHtml(string XsltFile, XmlDocument xdoc, Encoding encode)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(XsltFile);

            //将转换的结果保存在内存流中，然后返回文件名
            MemoryStream ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms, Encoding.GetEncoding("utf-8"));
            xslt.Transform(xdoc, null, writer);
            writer.Flush();

            byte[] bt = ms.ToArray();
            ms.Write(bt, 0, Convert.ToInt32(ms.Length));

            return Encoding.UTF8.GetString(bt);
        }
    }
}
