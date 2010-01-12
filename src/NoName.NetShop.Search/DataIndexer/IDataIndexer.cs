using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NoName.NetShop.Search.Entities;

namespace NoName.NetShop.Search.DataIndexer
{
    public interface IDataIndexer
    {
        void CreateIndex(List<ISearchEntity> CreateEntities);
        void DeleteIndex(List<ISearchEntity> DeleteEntities);
    }
}
