using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Product.Config
{
    public class ProductMainImageElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty _Key = new ConfigurationProperty("key", typeof(string), String.Empty, ConfigurationPropertyOptions.IsKey);
        private static readonly ConfigurationProperty _Width = new ConfigurationProperty("width", typeof(int), String.Empty, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _Height = new ConfigurationProperty("height", typeof(int), String.Empty, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _Suffix = new ConfigurationProperty("suffix", typeof(string), String.Empty, ConfigurationPropertyOptions.IsRequired);


        private static ConfigurationPropertyCollection _Properties = new ConfigurationPropertyCollection();

        public ProductMainImageElement()
        {
            _Properties.Add(_Key);
            _Properties.Add(_Width);
            _Properties.Add(_Height);
            _Properties.Add(_Suffix);
        }

        public string Key
        {
            get { return (string)base[_Key]; }
        }
        public int Width 
        {
            get { return (int)base[_Width]; }
        }
        public int Height
        {
            get { return (int)base[_Height];}
        }
        public string Suffix
        {
            get { return (string)base[_Suffix];}
        }


        protected override ConfigurationPropertyCollection Properties
        {
            get { return _Properties; }
        }
    }
}
