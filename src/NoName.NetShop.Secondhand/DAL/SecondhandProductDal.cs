using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Secondhand.Model;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Common;
using System.Data;

namespace NoName.NetShop.Secondhand.DAL
{
    public class SecondhandProductDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(SecondhandProductModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_seSecondhandProduct_ADD");

            dbw.AddInParameter(Command, "@SeProductID", DbType.Int32, model.SecondhandProductID);
            dbw.AddInParameter(Command, "@SeProductName", DbType.String, model.SecondhandProductName);
            dbw.AddInParameter(Command, "@UserID", DbType.Int32, model.UserID);
            dbw.AddInParameter(Command, "@Price", DbType.Decimal, model.Price);
            dbw.AddInParameter(Command, "@CateID", DbType.Int32, model.CateID);
            dbw.AddInParameter(Command, "@CatePath", DbType.String, model.CatePath);
            dbw.AddInParameter(Command, "@Stock", DbType.Int32, model.Stock);
            dbw.AddInParameter(Command, "@SmallImage", DbType.String, model.SmallImage);
            dbw.AddInParameter(Command, "@MediumImage", DbType.String, model.MediumImage);
            dbw.AddInParameter(Command, "@LargeImage", DbType.String, model.LargeImage);
            dbw.AddInParameter(Command, "@Keywords", DbType.String, model.Keywords);
            dbw.AddInParameter(Command, "@Brief", DbType.String, model.Brief);
            dbw.AddInParameter(Command, "@InsertTime", DbType.DateTime, model.InsertTime);
            dbw.AddInParameter(Command, "@UpdateTime", DbType.DateTime, model.UpdateTime);
            dbw.AddInParameter(Command, "@Status", DbType.Int32, model.Status);
            dbw.AddInParameter(Command, "@SortValue", DbType.Int32, model.SortValue);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int SecondhandProductID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_seSecondhandProduct_Delete");

            dbw.AddInParameter(Command, "@SeProductID", DbType.Int32, SecondhandProductID);


            dbw.ExecuteNonQuery(Command);
        }

        public void Update(SecondhandProductModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_seSecondhandProduct_Update");

            dbw.AddInParameter(Command, "@SeProductID", DbType.Int32, model.SecondhandProductID);
            dbw.AddInParameter(Command, "@SeProductName", DbType.String, model.SecondhandProductName);
            dbw.AddInParameter(Command, "@UserID", DbType.Int32, model.UserID);
            dbw.AddInParameter(Command, "@Price", DbType.Decimal, model.Price);
            dbw.AddInParameter(Command, "@CateID", DbType.Int32, model.CateID);
            dbw.AddInParameter(Command, "@CatePath", DbType.String, model.CatePath);
            dbw.AddInParameter(Command, "@Stock", DbType.Int32, model.Stock);
            dbw.AddInParameter(Command, "@SmallImage", DbType.String, model.SmallImage);
            dbw.AddInParameter(Command, "@MediumImage", DbType.String, model.MediumImage);
            dbw.AddInParameter(Command, "@LargeImage", DbType.String, model.LargeImage);
            dbw.AddInParameter(Command, "@Keywords", DbType.String, model.Keywords);
            dbw.AddInParameter(Command, "@Brief", DbType.String, model.Brief);
            dbw.AddInParameter(Command, "@InsertTime", DbType.DateTime, model.InsertTime);
            dbw.AddInParameter(Command, "@UpdateTime", DbType.DateTime, model.UpdateTime);
            dbw.AddInParameter(Command, "@Status", DbType.Int32, model.Status);
            dbw.AddInParameter(Command, "@SortValue", DbType.Int32, model.SortValue);

            dbw.ExecuteNonQuery(Command);
        }


        public SecondhandProductModel GetModel(int SecondhandProductID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_seSecondhandProduct_GetModel");

            dbr.AddInParameter(Command,"@SeProductID",DbType.Int32,SecondhandProductID);

            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];

            SecondhandProductModel model = null;
            if(dt.Rows.Count>0)
                model = BindModel(dt.Rows[0]);
            return model;            
        }

        public DataTable GetList()
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_seSecondhandProduct_GetList");
            return dbr.ExecuteDataSet(Command).Tables[0];
        }

        public bool Exists(int SecondhandProductID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_seSecondhandProduct_Exists");

            dbr.AddInParameter(Command, "@SeProductID", DbType.Int32, SecondhandProductID);

            return Convert.ToInt32(dbr.ExecuteScalar(Command)) == 1;
        }


        private SecondhandProductModel BindModel(DataRow row)
        {
            SecondhandProductModel model = new SecondhandProductModel();

            model.SecondhandProductID = Convert.ToInt32(row["SeProductID"]);
            model.SecondhandProductName = Convert.ToString(row["SeProductName"]);
            model.CateID = Convert.ToInt32(row["CateID"]);
            model.CatePath = Convert.ToString(row["CatePath"]);
            model.Keywords = Convert.ToString(row["Keywords"]);
            model.Stock = Convert.ToInt32(row["Stock"]);
            model.Price = Convert.ToInt32(row["Price"]);
            model.UserID = Convert.ToInt32(row["UserID"]);
            model.Brief = Convert.ToString(row["Brief"]);
            model.SmallImage = Convert.ToString(row["SmallImage"]);
            model.MediumImage = Convert.ToString(row["MediumImage"]);
            model.LargeImage = Convert.ToString(row["LargeImage"]);
            model.InsertTime = Convert.ToDateTime(row["InsertTime"]);
            model.UpdateTime = Convert.ToDateTime(row["UpdateTime"]);
            model.SortValue = Convert.ToInt32(row["SortValue"]);
            model.Status = Convert.ToInt32(row["Status"]);

            return model;
        }
    }
}
