﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace NoName.NetShop.CMS.Config
{
    public class PageCategorySection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public PageCategoryElementCollection PageCategories
        {
            get
            {
                return (PageCategoryElementCollection)base[""];
            }
        }
    }
}
