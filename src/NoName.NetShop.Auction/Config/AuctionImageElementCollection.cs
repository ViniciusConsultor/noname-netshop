using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Auction.Config
{
    public class AuctionImageElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AuctionImageElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AuctionImageElement)element).Key;
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

        public AuctionImageElement this[int index]
        {
            get
            {
                return (AuctionImageElement)BaseGet(index);
            }
        }
        public AuctionImageElement this[string key]
        {
            get
            {
                return (AuctionImageElement)BaseGet(key);
            }
        }
    }
}
