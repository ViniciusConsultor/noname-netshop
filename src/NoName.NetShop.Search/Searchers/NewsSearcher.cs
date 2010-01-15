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
        public NewsSearcher(SearchInfo info)
        {
            searchInfo = info;
        }

        public override List<ISearchEntity> GetSearchResult(out int MatchCount)
        {
            throw new NotImplementedException();
        }
    }
}
