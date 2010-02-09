using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class FileManagementSection : ConfigurationSection
    {
        [ConfigurationProperty("decompressionProgram", IsRequired = true)]
        public string DecompressionProgram
        {
            get { return (string)base["decompressionProgram"]; }
        }


        [ConfigurationProperty("", IsDefaultCollection = true)]
        public FileManagementElementCollection FileCategories
        {
            get
            {
                return (FileManagementElementCollection)base[""];
            }
        }
    }
}
