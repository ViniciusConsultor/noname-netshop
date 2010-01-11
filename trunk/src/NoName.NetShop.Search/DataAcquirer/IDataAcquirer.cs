using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NoName.NetShop.Search.Entities;

namespace NoName.NetShop.Search.DataAcquirer
{
    public interface IDataAcquirer
    {
        List<ISearchEntity> GetData();        
    }
}
