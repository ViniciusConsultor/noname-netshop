using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class FileManagementElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileManagementElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileManagementElement)element).Key;
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

        public FileManagementElement this[int index]
        {
            get
            {
                return (FileManagementElement)BaseGet(index);
            }
        }
        public FileManagementElement this[string key]
        {
            get
            {
                return (FileManagementElement)BaseGet(key);
            }
        }
    }
}
