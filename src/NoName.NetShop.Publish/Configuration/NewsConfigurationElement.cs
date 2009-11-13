using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Publish.Configuration
{
    public class NewsConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("type", IsKey = true)]
        public string Type
        {
            get { return (string)base["type"]; }
        }

        [ConfigurationProperty("template", IsRequired = true)]
        public string Template
        {
            get { return (string)base["template"]; }
        }

        [ConfigurationProperty("creatorType", IsRequired = true)]
        public string CreatorType
        {
            get { return (string)base["creatorType"]; }
        }
    }
}
