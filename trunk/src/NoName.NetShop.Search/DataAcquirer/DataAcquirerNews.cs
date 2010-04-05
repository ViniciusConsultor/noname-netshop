using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Search.Config;
using System.Data;

namespace NoName.NetShop.Search.DataAcquirer
{
    public class DataAcquirerNews : IDataAcquirer
    {
        private Database db = CommDataAccess.DbReader;
        private SearchElement ConfigElement;

        public DataAcquirerNews(SearchElement Element)
        {
            ConfigElement = Element;
        }

        public List<ISearchEntity> GetData()
        {
            string sql = "select * from nenews";

            var query = from q in db.ExecuteDataSet(CommandType.Text, sql).Tables[0].AsEnumerable()
                        select new NewsModel()
                        {
                            EntityIdentity = q.Field<int>("newsid"),
                            Title = q.Field<string>("title"),
                            Keywords = q.Field<string>("tags"),
                            Content = q.Field<string>("newscontent"),
                            ProcessType = EntityProcessType.insert,
                            CategoryPath = new News.BLL.NewsCategoryModelBll().GetPath(q.Field<int>("cateid")),
                            CreateTime = q.Field<DateTime>("inserttime")
                        };

            List<ISearchEntity> NewsList = new List<ISearchEntity>();
            foreach (var o in query)
            {
                NewsList.Add((ISearchEntity)o);
            }

            return NewsList;
        }
    }
}
