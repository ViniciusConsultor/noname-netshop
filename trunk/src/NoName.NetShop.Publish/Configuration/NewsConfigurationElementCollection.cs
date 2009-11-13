using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Publish.Configuration
{
    public class NewsConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new NewsConfigurationElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NewsConfigurationElement)element).Type;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
        protected override string ElementName
        {
            get
            {
                return "page";
            }
        }

        public NewsConfigurationElement this[int index]
        {
            get
            {
                return (NewsConfigurationElement)BaseGet(index);
            }
        }
        public NewsConfigurationElement this[string key]
        {
            get
            {
                return (NewsConfigurationElement)BaseGet(key);
            }
        }
    }
}
