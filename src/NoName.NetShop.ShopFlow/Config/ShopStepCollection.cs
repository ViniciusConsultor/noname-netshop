using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.ShopFlow.Config
{
    class ShopStepCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ShopStepElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ShopStepElement)element).Key;
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public ShopStepElement this[int index]
        {
            get
            {
                return (ShopStepElement)BaseGet(index);
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


        new public ShopStepElement this[string Name]
        {
            get
            {
                return (ShopStepElement)BaseGet(Name);
            }
        }


        public int IndexOf(ShopStepElement element)
        {
            return BaseIndexOf(element);
        }


        public void Add(ShopStepElement element)
        {
            BaseAdd(element);
        }


        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }



        public void Remove(ShopStepElement element)
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

        protected override string ElementName
        {
            get
            {
                return "step";
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

    }
}
