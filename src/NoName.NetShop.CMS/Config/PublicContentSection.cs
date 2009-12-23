using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class PublicContentSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public PublicContentElementCollection PublicPages
        {
            get
            {
                return (PublicContentElementCollection)base[""];
            }
        }
    }
}
