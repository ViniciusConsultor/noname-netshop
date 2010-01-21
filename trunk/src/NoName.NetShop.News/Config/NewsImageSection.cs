using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.News.Config
{
    public class NewsImageSection : ConfigurationSection
    {
        //allowedFormat="jpg|jpeg|gif|bmp" 
        [ConfigurationProperty("allowedFormat", IsRequired = true)]
        public string AllowedFormat
        {
            get { return (string)base["allowedFormat"]; }
        }

        //maxSize="10240" 
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

        //pathRoot="E:\works\project\NetShop\src\NoName.NetShop.ForeFlat\Upload\News\Images" 
        [ConfigurationProperty("pathRoot", IsRequired = true)]
        public string PathRoot
        {
            get { return (string)base["pathRoot"]; }
        }

        //urlRoot="http://localhost/Upload/News/Images/"
        [ConfigurationProperty("urlRoot", IsRequired = true)]
        public string UrlRoot
        {
            get { return (string)base["urlRoot"]; }
        }

    }
}
