using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.GroupShopping.Config
{
    public class GroupShoppingImageElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new GroupShoppingImageElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((GroupShoppingImageElement)element).Key;
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public GroupShoppingImageElement this[int index]
        {
            get
            {
                return (GroupShoppingImageElement)BaseGet(index);
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

        new public GroupShoppingImageElement this[string Name]
        {
            get
            {
                return (GroupShoppingImageElement)BaseGet(Name);
            }
        }

        public int IndexOf(GroupShoppingImageElement element)
        {
            return BaseIndexOf(element);
        }

        public void Add(GroupShoppingImageElement element)
        {
            BaseAdd(element);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(GroupShoppingImageElement element)
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
