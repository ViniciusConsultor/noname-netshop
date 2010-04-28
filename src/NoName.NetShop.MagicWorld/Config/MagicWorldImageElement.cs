using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.MagicWorld.Config
{
    public class MagicWorldImageElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)base["key"]; }
        }
        [ConfigurationProperty("width", IsRequired = true)]
        public int Width
        {
            get { return (int)base["width"]; }
        }
        [ConfigurationProperty("height", IsRequired = true)]
        public int Height
        {
            get { return (int)base["height"]; }
        }
        [ConfigurationProperty("suffix", IsRequired = true)]
        public string Suffix
        {
            get { return (string)base["suffix"]; }
        }
    }
}
