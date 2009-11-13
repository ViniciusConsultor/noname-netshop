using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Publish.Configuration;

namespace NoName.NetShop.Publish.News.PageCreators
{
    public class PageCreatorFactory
    {
        private PageCreatorFactory() { }

        private static PageCreatorFactory Factory;

        public static PageCreatorFactory Instance()
        {
            if (Factory == null)
                Factory = new PageCreatorFactory();
            return Factory;
        }



        public PageCreator GetPageCreator(NewsPageParameter Parameter, NewsConfigurationSection config)
        {
            PageCreator creator = null;

            switch (Parameter.PageType)
            {
                case 1:
                    creator = (PageCreator)new PageCreatorNewsList(Parameter, config);
                    break;
                case 2:
                    creator = (PageCreator)new PageCreatorNewsDetail(Parameter, config);
                    break;
            }

            return creator;
        }


    }
}
