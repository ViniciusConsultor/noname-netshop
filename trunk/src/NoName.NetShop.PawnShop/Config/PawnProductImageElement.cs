using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.PawnShop.Config
{
    public class PawnProductImageElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)base["key"]; }
        }
        [ConfigurationProperty("width", IsRequired = true)]
        public string Width
        {
            get { return (string)base["width"]; }
        }
        [ConfigurationProperty("height", IsRequired = true)]
        public string Height
        {
            get { return (string)base["height"]; }
        }
        [ConfigurationProperty("suffix", IsRequired = true)]
        public string Suffix
        {
            get { return (string)base["suffix"]; }
        }
    }
}
