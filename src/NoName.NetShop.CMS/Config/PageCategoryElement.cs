using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class PageCategoryElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty _Key = new ConfigurationProperty("key", typeof(string), String.Empty, ConfigurationPropertyOptions.IsKey);
        private static readonly ConfigurationProperty _Template = new ConfigurationProperty("template", typeof(string), String.Empty, ConfigurationPropertyOptions.IsRequired);
        private static readonly ConfigurationProperty _PhysicalPath = new ConfigurationProperty("physicalPath", typeof(string), String.Empty, ConfigurationPropertyOptions.IsRequired);
        private static ConfigurationPropertyCollection _Properties = new ConfigurationPropertyCollection();

        static PageCategoryElement()
        {
            _Properties.Add(_Key);
            _Properties.Add(_Template);
            _Properties.Add(_PhysicalPath);
        }

        public string Key { get { return (string)base[_Key]; } }
        public string Template { get { return (string)base[_Template]; } }
        public string PhysicalPath { get { return (string)base[_PhysicalPath]; } }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _Properties; }
        }
    }
}
