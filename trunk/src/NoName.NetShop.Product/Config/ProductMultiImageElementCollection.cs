using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Product.Config
{
    public class ProductMultiImageElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProductMultiImageElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProductMultiImageElement)element).Key;
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public ProductMultiImageElement this[int index]
        {
            get
            {
                return (ProductMultiImageElement)BaseGet(index);
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

        new public ProductMultiImageElement this[string Name]
        {
            get
            {
                return (ProductMultiImageElement)BaseGet(Name);
            }
        }

        public int IndexOf(ProductMultiImageElement element)
        {
            return BaseIndexOf(element);
        }

        public void Add(ProductMultiImageElement element)
        {
            BaseAdd(element);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(ProductMultiImageElement element)
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
