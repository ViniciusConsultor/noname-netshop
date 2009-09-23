using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Product.Config
{
    public class ProductMainImageElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProductMainImageElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProductMainImageElement)element).Key;
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public ProductMainImageElement this[int index]
        {
            get
            {
                return (ProductMainImageElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public ProductMainImageElement this[string Name]
        {
            get
            {
                return (ProductMainImageElement)BaseGet(Name);
            }
        }

        public int IndexOf(ProductMainImageElement element)
        {
            return BaseIndexOf(element);
        }

        public void Add(ProductMainImageElement element)
        {
            BaseAdd(element);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(ProductMainImageElement element)
        {
            if (BaseIndexOf(element) >= 0)
                BaseRemove(element.Key);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}
