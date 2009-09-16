using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class PageCategorySection : ConfigurationSection
    {
        private static readonly ConfigurationProperty _PageCategory = new ConfigurationProperty(null, typeof(PageCategoryCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
        private static ConfigurationPropertyCollection _Properties = new ConfigurationPropertyCollection();

        public PageCategorySection()
        {
            _Properties.Add(_PageCategory);
        }

        public PageCategoryCollection PageCategory
        {
            get { return (PageCategoryCollection)base[_PageCategory]; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _Properties; }
        }

    }
}
