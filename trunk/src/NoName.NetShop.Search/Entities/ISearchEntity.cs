using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Search.Entities
{
    public interface ISearchEntity
    {
        int EntityIdentity { get; set; }
        EntityProcessType ProcessType { get; set; }
    }

    public enum EntityProcessType
    {
        insert = 1,
        update = 2,
        delete = 3,
    }
}
