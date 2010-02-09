using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class FileManagementElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)base["key"]; }
        }

        [ConfigurationProperty("pathRoot", IsRequired = true)]
        public string PathRoot
        {
            get { return (string)base["pathRoot"]; }
        }

        [ConfigurationProperty("urlRoot", IsRequired = true)]
        public string UrlRoot
        {
            get { return (string)base["urlRoot"]; }
        }

        [ConfigurationProperty("allowedFormats", IsRequired = true)]
        public string AllowedFormats
        {
            get { return (string)base["allowedFormats"]; }
        }

        [ConfigurationProperty("maxSize", IsRequired = true)]
        public int MaxSize
        {
            get { return (int)base["maxSize"]; }
        }

        [ConfigurationProperty("fileNameFormat", IsRequired = true)]
        public string FileNameFormat
        {
            get { return (string)base["fileNameFormat"]; }
        }
    }
}
