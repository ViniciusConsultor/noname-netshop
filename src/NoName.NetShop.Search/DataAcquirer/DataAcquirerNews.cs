using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Search.Config;

namespace NoName.NetShop.Search.DataAcquirer
{
    public class DataAcquirerNews
    {
        private Database db = CommDataAccess.DbReader;
        private SearchElement ConfigElement;

        public DataAcquirerNews(SearchElement Element)
        {
            ConfigElement = Element;
        }

        public List<ISearchEntity> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
