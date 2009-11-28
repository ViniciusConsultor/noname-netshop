using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.ShopFlow.Config
{
    public class ShopStepInfoElement : ConfigurationElement
    {
        #region 变量定义
        private static readonly ConfigurationProperty _key = new ConfigurationProperty("key", typeof(string), null, ConfigurationPropertyOptions.IsKey);
        private static readonly ConfigurationProperty _url = new ConfigurationProperty("url", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _description = new ConfigurationProperty("description", typeof(string), String.Empty, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _index = new ConfigurationProperty("index", typeof(int), 0, ConfigurationPropertyOptions.IsRequired);

        private static ConfigurationPropertyCollection _properties = new ConfigurationPropertyCollection();
        #endregion

        #region 构造函数
        static ShopStepInfoElement()
        {
            _properties.Add(_key);
            _properties.Add(_url);
            _properties.Add(_description);
            _properties.Add(_index);
        }

        public ShopStepInfoElement()
        { }
        #endregion

        #region 属性定义
        public string Key
        {
            set { base[_key] = value; }
            get { return (string)base[_key]; }
        }

        public string Url
        {
            set { base[_url] = value; }
            get { return (string)base[_url]; }
        }
        public string Description
        {
            set { base[_description] = value; }
            get { return (string)base[_description]; }
        }

        public int Index
        {
            set { base[_index] = value; }
            get { return (int)base[_index]; }
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
