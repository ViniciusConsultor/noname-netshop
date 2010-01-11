using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NoName.NetShop.Search
{
    public abstract class Searcher
    {
        public abstract DataTable GetSearchResult(string QueryString);
    }
}
