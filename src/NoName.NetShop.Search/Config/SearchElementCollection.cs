using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Search.Config
{
    public class SearchElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SearchElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SearchElement)element).Name;
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

        public SearchElement this[int index]
        {
            get
            {
                return (SearchElement)BaseGet(index);
            }
        }
        public SearchElement this[string key]
        {
            get
            {
                return (SearchElement)BaseGet(key);
            }
        }
    }
}
