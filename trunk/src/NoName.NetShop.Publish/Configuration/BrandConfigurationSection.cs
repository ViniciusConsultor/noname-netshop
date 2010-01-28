using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Publish.Configuration
{
    public class BrandConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("database", IsRequired = true)]
        public string Database
        {
            get { return (string)base["database"]; }
        }

        [ConfigurationProperty("cacheTime", IsRequired = true)]
        public int CacheTime
        {
            get { return (int)base["cacheTime"]; }
        }

        [ConfigurationProperty("listPageSize", IsRequired = true)]
        public int ListPageSize
        {
            get { return (int)base["listPageSize"]; }
        }

        [ConfigurationProperty("rootPath", IsRequired = true)]
        public string RootPath
        {
            get { return (string)base["rootPath"]; }
        }

        [ConfigurationProperty("template", IsRequired = true)]
        public string Template
        {
            get { return (string)base["template"]; }
        }

        [ConfigurationProperty("logger", IsRequired = true)]
        public string Logger
        {
            get { return (string)base["logger"]; }
        }

        [ConfigurationProperty("pageValidateTempXml", IsRequired = true)]
        public string PageValidateTempXml
        {
            get { return (string)base["pageValidateTempXml"]; }
        }

        [ConfigurationProperty("headerFile", IsRequired = true)]
        public string HeaderFile
        {
            get { return (string)base["headerFile"]; }
        }

        [ConfigurationProperty("footerFile", IsRequired = true)]
        public string FooterFile
        {
            get { return (string)base["footerFile"]; }
        }
    }
}
