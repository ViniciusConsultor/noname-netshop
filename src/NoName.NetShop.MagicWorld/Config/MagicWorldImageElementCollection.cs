using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.MagicWorld.Config
{
    public class MagicWorldImageElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MagicWorldImageElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MagicWorldImageElement)element).Key;
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

        public MagicWorldImageElement this[int index]
        {
            get
            {
                return (MagicWorldImageElement)BaseGet(index);
            }
        }
        public MagicWorldImageElement this[string key]
        {
            get
            {
                return (MagicWorldImageElement)BaseGet(key);
            }
        }
    }
}
