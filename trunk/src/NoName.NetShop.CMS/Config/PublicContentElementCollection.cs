using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class PublicContentElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PublicContentElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PublicContentElement)element).Key;
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
                return "add";
            }
        }

        public PublicContentElement this[int index]
        {
            get
            {
                return (PublicContentElement)BaseGet(index);
            }
        }
        public PublicContentElement this[string key]
        {
            get
            {
                return (PublicContentElement)BaseGet(key);
            }
        }
    }
}
