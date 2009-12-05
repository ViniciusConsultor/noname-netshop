using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.MagicWorld.Config
{
    public class SecondhandImageElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SecondhandImageElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SecondhandImageElement)element).Key;
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

        public SecondhandImageElement this[int index]
        {
            get
            {
                return (SecondhandImageElement)BaseGet(index);
            }
        }
        public SecondhandImageElement this[string key]
        {
            get
            {
                return (SecondhandImageElement)BaseGet(key);
            }
        }
    }
}
