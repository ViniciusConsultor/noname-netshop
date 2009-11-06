using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Publish.Configuration
{
    public class ProductConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("database", IsRequired = true)]
        public string Database
        {
            get { return (string)base["database"]; }
        }
        
        [ConfigurationProperty("rootPath", IsRequired = true)]
        public string RootPath
        {
            get { return (string)base["rootPath"]; }
        }

        [ConfigurationProperty("cacheTime", IsRequired = true)]
        public int CacheTime
        {
            get { return (int)base["cacheTime"]; }
        }


        [ConfigurationProperty("logger", IsRequired = true)]
        public string Logger
        {
            get { return (string)base["logger"]; }
        }


        [ConfigurationProperty("template", IsRequired = true)]
        public string Template
        {
            get { return (string)base["template"]; }
        }
    }
}
