using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.ShopFlow.Config
{
    class ShopStepElement : ConfigurationElement
    {
        #region 变量定义
        private static readonly ConfigurationProperty _key = new ConfigurationProperty("key", typeof(string),String.Empty, ConfigurationPropertyOptions.IsKey);
        private static readonly ConfigurationProperty _description = new ConfigurationProperty("description", typeof(string), null, ConfigurationPropertyOptions.None);
        private static readonly ConfigurationProperty _stepCount = new ConfigurationProperty("stepCount", typeof(int), 0, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _type = new ConfigurationProperty("type", typeof(string), String.Empty, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _stepinfos = new ConfigurationProperty(null, typeof(ShopStepInfoCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
        private static ConfigurationPropertyCollection _properties = new ConfigurationPropertyCollection();
        #endregion

        #region 构造函数
        static ShopStepElement()
        {
            _properties.Add(_key);
            _properties.Add(_description);
            _properties.Add(_stepCount);
            _properties.Add(_stepinfos);
            _properties.Add(_type);            
        }

        public ShopStepElement()
        { }
        #endregion

        #region 属性定义
        public string Key
        {
            set { base[_key] = value; }
            get { return (string)base[_key]; }
        }

        public string Description
        {
            set { base[_description] = value; }
            get { return (string)base[_description]; }
        }

        public ShopStepInfoCollection StepInfos
        { 
            set { base[_stepinfos] = value; }
            get { return (ShopStepInfoCollection)base[_stepinfos]; }
        }

        public int StepCount
        {
            set { base[_stepCount] = value; }
            get { return (int)base[_stepCount]; }
        }

        public string Type
        {
            set { base[_type] = value; }
            get { return (string)base[_type]; }
        }

        #endregion

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }
    }
}
