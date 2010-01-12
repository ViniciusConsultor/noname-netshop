using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.Search.Config
{
    public class SearchElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
        }

        [ConfigurationProperty("indexDirectory", IsRequired = true)]
        public string IndexDirectory
        {
            get { return (string)base["indexDirectory"]; }
        }

        [ConfigurationProperty("dataAcquirer", IsRequired = true)]
        public string DataAcquirer
        {
            get { return (string)base["dataAcquirer"]; }
        }

        [ConfigurationProperty("dataIndexer", IsRequired = true)]
        public string DataIndexer
        {
            get { return (string)base["dataIndexer"]; }
        }
    }
}
