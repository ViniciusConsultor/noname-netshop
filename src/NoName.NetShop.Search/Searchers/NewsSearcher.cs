using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Search.Config;

namespace NoName.NetShop.Search.Searchers
{
    public class NewsSearcher : Searcher
    {
        public NewsSearcher(string qString, SearchElement element)
        {
            QueryString = qString;
            ConfigElement = element;
        }

        public override List<ISearchEntity> GetSearchResult()
        {
            throw new NotImplementedException();
        }
    }
}
