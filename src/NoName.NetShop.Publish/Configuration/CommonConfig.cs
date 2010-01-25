using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Xml;

namespace NoName.NetShop.Publish.Configuration
{
    public class CommonConfig
    {
        private CommonConfig() { }


        private static CommonConfig c;


        public static CommonConfig Instance()
        {
            if (c != null)
            {
                return c;
            }
            else
            {
                return new CommonConfig();
            }
        }

        public bool IsStandardHeaderChanged(FileInfo HeaderFile, string ValidateXmlFileName)
        {
            object o = new object();

            lock (o)
            {
                bool validate = false;

                XmlDocument TempData = new XmlDocument();
                TempData.Load(ValidateXmlFileName);

                DateTime HeaderFileLastModified = DateTime.Parse(TempData.SelectSingleNode("commonpagelastmodifiedtime/headerlastmodified").InnerText);

                if (HeaderFile.LastWriteTime.ToString() == HeaderFileLastModified.ToString())
                {
                    validate = true;
                }
                else
                {
                    if (HeaderFile.LastWriteTime != HeaderFileLastModified)
                    {
                        TempData.SelectSingleNode("commonpagelastmodifiedtime/headerlastmodified").InnerText = HeaderFile.LastWriteTime.ToString();
                        TempData.Save(ValidateXmlFileName);
                    }
                }

                return validate;
            }
        }

        public bool IsStandardFooterChanged(FileInfo FooterFile, string ValidateXmlFileName)
        {
            object o = new object();

            lock (o)
            {
                bool validate = false;

                XmlDocument TempData = new XmlDocument();
                TempData.Load(ValidateXmlFileName);

                DateTime FooterFileLastModified = DateTime.Parse(TempData.SelectSingleNode("commonpagelastmodifiedtime/footerlastmodified").InnerText);

                if (FooterFile.LastWriteTime.ToString() == FooterFileLastModified.ToString())
                {
                    validate = true;
                }
                else
                {
                    if (FooterFile.LastWriteTime != FooterFileLastModified)
                    {
                        TempData.SelectSingleNode("commonpagelastmodifiedtime/footerlastmodified").InnerText = FooterFile.LastWriteTime.ToString();
                        TempData.Save(ValidateXmlFileName);
                    }
                }

                return validate;
            }
        }



        public string GetStandardHeaderContent(string HeaderFileName, string ValidateXmlFileName)
        {
            object o = new object();
            string Key = "STANDARD-HEADER-CONTENT-CACHE";

            lock (o)
            {
                if (HttpRuntime.Cache[Key] == null || IsStandardHeaderChanged(new FileInfo(HeaderFileName), ValidateXmlFileName))
                {
                    StreamReader sr = new StreamReader(HeaderFileName);

                    HttpRuntime.Cache.Insert(Key, sr.ReadToEnd(), null, DateTime.Now.AddDays(1), TimeSpan.Zero);
                    sr.Close();
                }
            }
            return HttpRuntime.Cache[Key].ToString();
        }

        public string GetStandardFooterContent(string FooterFileName, string ValidateXmlFileName)
        {
            object o = new object();
            string Key = "STANDARD-FOOTER-CONTENT-CACHE";

            lock (o)
            {
                if (HttpRuntime.Cache[Key] == null || IsStandardFooterChanged(new FileInfo(FooterFileName), ValidateXmlFileName))
                {
                    StreamReader sr = new StreamReader(FooterFileName);

                    HttpRuntime.Cache.Insert(Key, sr.ReadToEnd(), null, DateTime.Now.AddDays(1), TimeSpan.Zero);
                    sr.Close();
                }
            }
            return HttpRuntime.Cache[Key].ToString();
        }
    }
}
