using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NoName.NetShop.Search.DataAcquirer;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Search.DataIndexer;

namespace NoName.NetShop.Search
{
    public class DataProcessor
    {        
        private static IDataAcquirer dataAcquirer = null;
        private static IDataIndexer dataIndexer = null;

        public static void Process(string Arg)
        {
            /* determin which dataacquirer and which dataindexer to be instantiated with "Arg" argument */
            dataAcquirer = (IDataAcquirer)new DataAcquirerProduct();
            dataIndexer = (IDataIndexer)new DataIndexerProduct();
            /* end */

            List<ISearchEntity> data = dataAcquirer.GetData();

            foreach (ISearchEntity entity in data)
            {
                if (entity.ProcessType == EntityProcessType.update)
                    dataIndexer.CreateIndex(entity);
                else if (entity.ProcessType == EntityProcessType.delete)
                    dataIndexer.DeleteIndex(entity);
                else
                    continue;                    
            }
        }
    }
}
