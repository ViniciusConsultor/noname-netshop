using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NoName.NetShop.Search.DataAcquirer;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Search.DataIndexer;
using NoName.NetShop.Search.Config;
using System.Configuration;

namespace NoName.NetShop.Search
{
    public class DataProcessor
    {        
        private static IDataAcquirer dataAcquirer = null;
        private static IDataIndexer dataIndexer = null;
        private static SearchSection Config = (SearchSection)ConfigurationManager.GetSection("searches");


        public static void Process(string SearchName)
        {
            /* determin which dataacquirer and which dataindexer to be instantiated with "Arg" argument */
            SearchElement search = Config.Searches[SearchName];

            Type AcquirerType = Type.GetType(search.DataAcquirer);
            Type IndexerType = Type.GetType(search.DataIndexer);


            dataAcquirer = (IDataAcquirer)Activator.CreateInstance(AcquirerType, new object[] { search });
            dataIndexer = (IDataIndexer)Activator.CreateInstance(IndexerType, new object[] { search });
            /* end */

            List<ISearchEntity> data = dataAcquirer.GetData();

            List<ISearchEntity> CreateEntities = new List<ISearchEntity>();
            List<ISearchEntity> DeleteEntities = new List<ISearchEntity>();

            foreach (ISearchEntity entity in data)
            {
                if (entity.ProcessType == EntityProcessType.insert)
                    AddCreateIndex(CreateEntities, entity);
                else if (entity.ProcessType == EntityProcessType.update)
                    AddCreateIndex(CreateEntities, entity);
                else if (entity.ProcessType == EntityProcessType.delete)
                    DeleteEntities.Add(entity);
                else
                    continue;                    
            }

            dataIndexer.CreateIndex(CreateEntities);
            dataIndexer.DeleteIndex(DeleteEntities);

            Console.Read();
        }

        private static void AddCreateIndex(List<ISearchEntity> CreateEntities, ISearchEntity entity)
        {
            var query = from e in CreateEntities
                        where e.EntityIdentity == entity.EntityIdentity
                        select e;

            List<ISearchEntity> temp = new List<ISearchEntity>();

            foreach (var q in query)
                temp.Add(q);

            foreach (ISearchEntity e in temp)
                CreateEntities.Remove(e);

            CreateEntities.Add(entity);
        }

    }
}
