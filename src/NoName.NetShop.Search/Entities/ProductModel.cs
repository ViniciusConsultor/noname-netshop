using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Search.Entities
{
    public class ProductModel : ISearchEntity
    {
        public int EntityIdentity { get; set; }
        public EntityProcessType ProcessType { get; set; }

        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryPath { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string ProductImage { get; set; }

        /* ... */
    }
}
