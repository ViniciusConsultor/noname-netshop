using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class PageCategoryElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PageCategoryElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PageCategoryElement)element).Key;
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

        public PageCategoryElement this[int index]
        {
            get
            {
                return (PageCategoryElement)BaseGet(index);
            }
        }
        public PageCategoryElement this[string key]
        {
            get
            {
                return (PageCategoryElement)BaseGet(key);
            }
        }
    }
}
