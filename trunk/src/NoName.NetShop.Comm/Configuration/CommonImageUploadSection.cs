using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Common.Configuration
{
    public class CommonImageUploadSection : ConfigurationSection
    {
        [ConfigurationProperty("pathRoot", IsRequired = true)]
        public string RootPath
        {
            get { return (string)base["pathRoot"]; }
        }

        [ConfigurationProperty("allowedFormat", IsRequired = true)]
        public string AllowedFormat
        {
            get { return (string)base["allowedFormat"]; }
        }

        [ConfigurationProperty("imageFileMaxSize", IsRequired = true)]
        public int MaxSize
        {
            get { return (int)base["imageFileMaxSize"]; }
        }

        [ConfigurationProperty("urlRoot", IsRequired = true)]
        public string RootUrl
        {
            get { return (string)base["urlRoot"]; }
        }

        [ConfigurationProperty("urlPrefix", IsRequired = true)]
        public string UrlPrefix
        {
            get { return (string)base["urlPrefix"]; }
        }
        
    }
}
