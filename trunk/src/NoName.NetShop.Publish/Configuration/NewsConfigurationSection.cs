using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Publish.Configuration
{
    public class NewsConfigurationSection : ConfigurationSection
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

        [ConfigurationProperty("logger", IsRequired = true)]
        public string Logger
        {
            get { return (string)base["logger"]; }
        }


        [ConfigurationProperty("", IsDefaultCollection = true)]
        public NewsConfigurationElementCollection PageCreators
        {
            get
            {
                return (NewsConfigurationElementCollection)base[""];
            }
        }
    }
}
