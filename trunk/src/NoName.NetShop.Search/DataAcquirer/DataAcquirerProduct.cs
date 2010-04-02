using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using NoName.NetShop.Search.Config;
using NoName.NetShop.Product.Facade;

namespace NoName.NetShop.Search.DataAcquirer
{
    public class DataAcquirerProduct : IDataAcquirer
    {
        private Database db = CommDataAccess.DbReader;
        private SearchElement ConfigElement;

        public DataAcquirerProduct(SearchElement Element)
        {
            ConfigElement = Element;
        }

        public List<ISearchEntity> GetData()
        {
            // configuration element ConfigElement contains time and frequence settings
            // sync time and frequence will be decided here by your preference

            DataTable dt = GetChangedProduct(DateTime.Now.AddMonths(-6), DateTime.Now);

            var query = from q in dt.AsEnumerable()
                        select new ProductModel()
                        {
                            EntityIdentity = q.Field<int>("productid"),
                            ProductName = q.Field<string>("productname"),
                            CategoryID = q.Field<int>("cateid"),
                            CategoryPath = q.Field<string>("catepath").Replace('/', ' '),
                            Keywords = q.Field<string>("keywords"),
                            Price = q.Field<decimal>("merchantprice"),
                            Description = q.Field<string>("brief"),
                            CreateTime = q.Field<DateTime>("inserttime"),
                            UpdateTime = q.Field<DateTime>("changetime"),
                            ProcessType = (EntityProcessType)Enum.Parse(typeof(EntityProcessType), q.Field<Int16>("changetype").ToString()),
                            ProductImage = q.Field<string>("mediumimage")
                        };

            List<ISearchEntity> ProductList = new List<ISearchEntity>();
            foreach (var o in query)
            {
                ProductList.Add((ISearchEntity)o); 
            }

            return ProductList;
        }

        private DataTable GetChangedProduct(DateTime FromTime,DateTime ToTime)
        {
            DbCommand Command = db.GetStoredProcCommand("UP_shProductChanged_GetChangedList");

            db.AddInParameter(Command, "@fromtime", DbType.DateTime, FromTime);
            db.AddInParameter(Command, "@totime", DbType.DateTime, ToTime);

            return db.ExecuteDataSet(Command).Tables[0]; 
        }
    }
}
