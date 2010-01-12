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
        protected string QueryString;
        protected SearchElement ConfigElement;


        public abstract List<ISearchEntity> GetSearchResult();
    }
}
