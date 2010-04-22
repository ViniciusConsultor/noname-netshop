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

            DataTable dt = GetChangedProduct(DateTime.Now.AddMonths(-60), DateTime.Now);

            List<ISearchEntity> ProductList = new List<ISearchEntity>();
            foreach (DataRow row in dt.Rows)
            {
                ProductModel Model = new ProductModel();


                Model.EntityIdentity = Convert.ToInt32(row["productid"]);
                Model.ProductName = row["productname"].ToString();
                Model.CategoryID = row["cateid"].ToString() == String.Empty ? 0 : Convert.ToInt32(row["cateid"]);
                Model.CategoryPath = row["catepath"].ToString();
                Model.Keywords = row["keywords"].ToString();
                Model.Price = row["merchantprice"].ToString() == String.Empty ? 0 : Convert.ToDecimal(row["merchantprice"]);
                Model.Description = row["brief"].ToString();
                Model.CreateTime = row["inserttime"].ToString() == String.Empty ? DateTime.Now : Convert.ToDateTime(row["inserttime"]);
                Model.UpdateTime = row["changetime"].ToString() == String.Empty ? DateTime.Now : Convert.ToDateTime(row["changetime"]);
                Model.ProcessType = (EntityProcessType)Enum.Parse(typeof(EntityProcessType), row["changetype"].ToString());
                Model.ProductImage = row["mediumimage"].ToString();

                ProductList.Add((ISearchEntity)Model);

            }

            //var query = from q in dt.AsEnumerable()
            //            select new ProductModel()
            //            {
            //                EntityIdentity = q.Field<int>("productid"),
            //                ProductName = q.Field<string>("productname"),
            //                CategoryID = q.ItemArray[7].ToString() == String.Empty ? 0 : q.Field<int>("cateid"),
            //                CategoryPath = q.Field<string>("catepath").Replace('/', ' '),
            //                Keywords = q.Field<string>("keywords"),
            //                Price = q.ItemArray[9].ToString() == String.Empty ? 0 : q.Field<decimal>("merchantprice"),
            //                Description = q.Field<string>("brief"),
            //                CreateTime = q.ItemArray[18].ToString() == String.Empty ? DateTime.Now : q.Field<DateTime>("inserttime"),
            //                UpdateTime = q.ItemArray[19].ToString() == String.Empty ? DateTime.Now : q.Field<DateTime>("changetime"),
            //                ProcessType = (EntityProcessType)Enum.Parse(typeof(EntityProcessType), q.Field<Int16>("changetype").ToString()),
            //                ProductImage = q.Field<string>("mediumimage")
            //            };

            //foreach (var o in query)
            //{
            //    ProductList.Add((ISearchEntity)o); 
            //}

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
