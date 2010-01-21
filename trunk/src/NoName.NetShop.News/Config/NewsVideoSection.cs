using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.News.Config
{
    public class NewsVideoSection : ConfigurationSection
    {
        //allowedFormat="avi|wmv|rmvb" 
        [ConfigurationProperty("allowedFormat", IsRequired = true)]
        public string AllowedFormat
        {
            get { return (string)base["allowedFormat"]; }
        }

        //maxSize="1073741824" 
        [ConfigurationProperty("maxSize", IsRequired = true)]
        public int MaxSize
        {
            get { return (int)base["maxSize"]; }
        }

        //rule="news-{0}--{1}.{2}" 
        [ConfigurationProperty("rule", IsRequired = true)]
        public string Rule
        {
            get { return (string)base["rule"]; }
        }

        //pathRoot="E:\works\project\NetShop\src\NoName.NetShop.ForeFlat\Upload\News\Videos\" 
        [ConfigurationProperty("pathRoot", IsRequired = true)]
        public string PathRoot
        {
            get { return (string)base["pathRoot"]; }
        }

        //tempFolder="E:\works\project\NetShop\src\NoName.NetShop.ForeFlat\Upload\News\Temp\" 
        [ConfigurationProperty("tempFolder", IsRequired = true)]
        public string TempFolder
        {
            get { return (string)base["tempFolder"]; }
        }

        //urlRoot="http://localhost/Upload/News/Videos/"/>
        [ConfigurationProperty("urlRoot", IsRequired = true)]
        public string UrlRoot
        {
            get { return (string)base["urlRoot"]; }
        }
    }
}
