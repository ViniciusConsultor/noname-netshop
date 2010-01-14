using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Search.Config;
using NoName.NetShop.Search.Entities;

namespace NoName.NetShop.Search.DataIndexer
{
    public class DataIndexerNews : IDataIndexer
    {
        private SearchElement ConfigElement;
        public DataIndexerNews(SearchElement Element)
        {
            ConfigElement = Element;
        }
        
        public void CreateIndex(List<ISearchEntity> CreateEntities)
        {
            throw new NotImplementedException();
        }


        public void DeleteIndex(List<ISearchEntity> DeleteEntities)
        {
            throw new NotImplementedException();
        }
    }
}
