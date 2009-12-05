using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.MagicWorld.Config
{
    public class PawnProductImageElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PawnProductImageElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PawnProductImageElement)element).Key;
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

        public PawnProductImageElement this[int index]
        {
            get
            {
                return (PawnProductImageElement)BaseGet(index);
            }
        }
        public PawnProductImageElement this[string key]
        {
            get
            {
                return (PawnProductImageElement)BaseGet(key);
            }
        }
    }
}
