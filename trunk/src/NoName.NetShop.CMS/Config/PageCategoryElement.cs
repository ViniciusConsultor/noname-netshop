using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class PageCategoryElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)base["key"]; }
        }

        [ConfigurationProperty("rootPath", IsRequired = true)]
        public string PhysicalPathRoot
        {
            get { return (string)base["rootPath"]; }
        }

        [ConfigurationProperty("rootUrl", IsRequired = true)]
        public string RootUrl
        {
            get { return (string)base["rootUrl"]; }
        }
        
        [ConfigurationProperty("nameRule", IsRequired = true)]
        public string NameRule
        {
            get { return (string)base["nameRule"]; }
        }
    }
}
