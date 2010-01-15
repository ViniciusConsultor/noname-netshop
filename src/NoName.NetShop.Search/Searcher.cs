using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NoName.NetShop.Search.Config;
using NoName.NetShop.Search.Entities;

namespace NoName.NetShop.Search
{
    public abstract class Searcher
    {
        protected SearchInfo searchInfo;

        public abstract List<ISearchEntity> GetSearchResult(out int MatchCount);
    }

    public class SearchInfo
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string QueryString { get; set; }
        public SearchElement ConfigElement { get; set; }
    }
}
