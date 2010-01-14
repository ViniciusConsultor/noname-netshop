using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Search.Entities
{
    public class NewsModel : ISearchEntity
    {
        public int EntityIdentity { get; set; }
        public EntityProcessType ProcessType { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}
