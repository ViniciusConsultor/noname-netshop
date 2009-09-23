using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Product.Config
{
    public class ProductDescriptionImageSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty _AllowedFormat = new ConfigurationProperty("allowedFormat", typeof(string), String.Empty, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _MaxSize = new ConfigurationProperty("maxSize", typeof(int), 1000, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _Rule = new ConfigurationProperty("rule", typeof(string), String.Empty, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _PathRoot = new ConfigurationProperty("pathRoot", typeof(string), String.Empty, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _UrlRoot = new ConfigurationProperty("urlRoot", typeof(string), String.Empty, ConfigurationPropertyOptions.IsRequired);


        private static ConfigurationPropertyCollection _Properties = new ConfigurationPropertyCollection();

        public ProductDescriptionImageSection()
        {
            _Properties.Add(_AllowedFormat);
            _Properties.Add(_MaxSize);
            _Properties.Add(_Rule);
            _Properties.Add(_PathRoot);
            _Properties.Add(_UrlRoot);
        }

        public string AllowedFormat
        {
            get { return (string)base[_AllowedFormat];}
        }
        public int MaxSize
        {
            get {return (int)base[_MaxSize]; }
        }
        public string Rule
        {
            get { return (string)base[_Rule]; }
        }
        public string PathRoot 
        {
            get { return (string)base[_PathRoot]; }
        }
        public string UrlRoot
        {
            get { return (string)base[_UrlRoot]; }
        }


        protected override ConfigurationPropertyCollection Properties
        {
            get { return _Properties; }
        }
    }
}
