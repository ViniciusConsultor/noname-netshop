using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.MagicWorld.Config
{
        public class AuctionImageSection : ConfigurationSection
        {
            [ConfigurationProperty("allowedFormat", IsRequired = true)]
            public string AllowedFormat
            {
                get { return (string)base["allowedFormat"]; }
            }

            [ConfigurationProperty("maxSize", IsRequired = true)]
            public int MaxSize
            {
                get { return (int)base["maxSize"]; }
            }
            [ConfigurationProperty("rule", IsRequired = true)]
            public string Rule
            {
                get { return (string)base["rule"]; }
            }
            [ConfigurationProperty("pathRoot", IsRequired = true)]
            public string PathRoot
            {
                get { return (string)base["pathRoot"]; }
            }
            [ConfigurationProperty("urlRoot", IsRequired = true)]
            public string UrlRoot
            {
                get { return (string)base["urlRoot"]; }
            }

            [ConfigurationProperty("", IsDefaultCollection = true)]
            public AuctionImageElementCollection ImageSets
            {
                get
                {
                    return (AuctionImageElementCollection)base[""];
                }
            }
        }
}
