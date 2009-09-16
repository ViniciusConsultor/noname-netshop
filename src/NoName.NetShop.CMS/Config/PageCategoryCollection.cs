using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class PageCategoryCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PageCategoryElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PageCategoryElement)element).Key;
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public PageCategoryElement this[int index]
        {
            get
            {
                return (PageCategoryElement)BaseGet(index);
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


        new public PageCategoryElement this[string Name]
        {
            get
            {
                return (PageCategoryElement)BaseGet(Name);
            }
        }


        public int IndexOf(PageCategoryElement element)
        {
            return BaseIndexOf(element);
        }


        public void Add(PageCategoryElement element)
        {
            BaseAdd(element);
        }


        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(PageCategoryElement element)
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
