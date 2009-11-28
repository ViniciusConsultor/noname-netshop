using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.ShopFlow.Config
{
    class ShopStepSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty _steps = new ConfigurationProperty(null, typeof(ShopStepCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);
        private static ConfigurationPropertyCollection _properties = new ConfigurationPropertyCollection();


        public ShopStepSection()
        {
            _properties.Add(_steps);
        }

        public ShopStepCollection Steps
        {
            get { return (ShopStepCollection)base[_steps]; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }

    }
}
