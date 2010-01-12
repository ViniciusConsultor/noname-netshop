using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Search.Config
{
    public class SearchSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public SearchElementCollection Searches
        {
            get
            {
                return (SearchElementCollection)base[""];
            }
        }
    }
}
