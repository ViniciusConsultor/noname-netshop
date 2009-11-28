using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.ShopFlow.Config
{
    class ShopStepInfoCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ShopStepInfoElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ShopStepInfoElement)element).Key;
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public ShopStepInfoElement this[int index]
        {
            get
            {
                return (ShopStepInfoElement)BaseGet(index);
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


        new public ShopStepInfoElement this[string Name]
        {
            get
            {
                return (ShopStepInfoElement)BaseGet(Name);
            }
        }


        public int IndexOf(ShopStepInfoElement element)
        {
            return BaseIndexOf(element);
        }


        public void Add(ShopStepInfoElement element)
        {
            BaseAdd(element);
        }


        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }



        public void Remove(ShopStepInfoElement element)
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
