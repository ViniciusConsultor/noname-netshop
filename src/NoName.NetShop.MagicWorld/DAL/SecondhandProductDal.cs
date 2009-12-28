using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.Model;
using System.Data.Common;
using System.Data;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace NoName.NetShop.MagicWorld.DAL
{
    public class SecondhandProductDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(SecondhandProductModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwSecondhandProduct_ADD");
            
            dbw.AddInParameter(Command, "@SeProductID", DbType.Int32, model.SecondhandProductID);
            dbw.AddInParameter(Command, "@SeProductName", DbType.String, model.SecondhandProductName);
            dbw.AddInParameter(Command, "@SmallImage", DbType.String, model.SmallImage);
            dbw.AddInParameter(Command, "@MediumImage", DbType.String, model.MediumImage);
            dbw.AddInParameter(Command, "@CateID", DbType.Int32, model.CateID);
            dbw.AddInParameter(Command, "@CatePath", DbType.String, model.CatePath);
            dbw.AddInParameter(Command, "@Price", DbType.Decimal, model.Price);
            dbw.AddInParameter(Command, "@Stock", DbType.Int32, model.Stock);
            dbw.AddInParameter(Command, "@usagecondition", DbType.Int32, model.UsageCondition);
            dbw.AddInParameter(Command, "@Brief", DbType.String, model.Brief);
            dbw.AddInParameter(Command, "@UserID", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@Status", DbType.Int32, model.Status);
            dbw.AddInParameter(Command, "@SortValue", DbType.Int32, model.SortValue);
            dbw.AddInParameter(Command, "@truename", DbType.String, model.TrueName);
            dbw.AddInParameter(Command, "@phone", DbType.String, model.Phone);
            dbw.AddInParameter(Command, "@cellphone", DbType.String, model.CellPhone);
            dbw.AddInParameter(Command, "@postcode", DbType.String, model.PostCode);
            dbw.AddInParameter(Command, "@region", DbType.String, model.Region);
            dbw.AddInParameter(Command, "@address", DbType.String, model.Address);
            dbw.AddInParameter(Command, "@InsertTime", DbType.DateTime, model.InsertTime);
            dbw.AddInParameter(Command, "@UpdateTime", DbType.DateTime, model.UpdateTime);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int SecondhandProductID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwSecondhandProduct_Delete");

            dbw.AddInParameter(Command, "@SeProductID", DbType.Int32, SecondhandProductID);


            dbw.ExecuteNonQuery(Command);
        }

        public void Update(SecondhandProductModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwSecondhandProduct_Update");

            dbw.AddInParameter(Command, "@SeProductID", DbType.Int32, model.SecondhandProductID);
            dbw.AddInParameter(Command, "@SeProductName", DbType.String, model.SecondhandProductName);
            dbw.AddInParameter(Command, "@SmallImage", DbType.String, model.SmallImage);
            dbw.AddInParameter(Command, "@MediumImage", DbType.String, model.MediumImage);
            dbw.AddInParameter(Command, "@CateID", DbType.Int32, model.CateID);
            dbw.AddInParameter(Command, "@CatePath", DbType.String, model.CatePath);
            dbw.AddInParameter(Command, "@Price", DbType.Decimal, model.Price);
            dbw.AddInParameter(Command, "@Stock", DbType.Int32, model.Stock);
            dbw.AddInParameter(Command, "@usagecondition", DbType.Int32, model.UsageCondition);
            dbw.AddInParameter(Command, "@Brief", DbType.String, model.Brief);
            dbw.AddInParameter(Command, "@UserID", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@Status", DbType.Int32, model.Status);
            dbw.AddInParameter(Command, "@SortValue", DbType.Int32, model.SortValue);
            dbw.AddInParameter(Command, "@truename", DbType.String, model.TrueName);
            dbw.AddInParameter(Command, "@phone", DbType.String, model.Phone);
            dbw.AddInParameter(Command, "@cellphone", DbType.String, model.CellPhone);
            dbw.AddInParameter(Command, "@postcode", DbType.String, model.PostCode);
            dbw.AddInParameter(Command, "@region", DbType.String, model.Region);
            dbw.AddInParameter(Command, "@address", DbType.String, model.Address);
            dbw.AddInParameter(Command, "@InsertTime", DbType.DateTime, model.InsertTime);
            dbw.AddInParameter(Command, "@UpdateTime", DbType.DateTime, model.UpdateTime);

            dbw.ExecuteNonQuery(Command);
        }

        public void UpdateStatus(int SecondhandProductID, int Status)
        {
            string sql = "update mwsecondhandproduct set status={0} where seproductid={1}";
            sql = String.Format(sql, Status, SecondhandProductID);
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }


        public SecondhandProductModel GetModel(int SecondhandProductID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_mwSecondhandProduct_GetModel");

            dbr.AddInParameter(Command, "@SeProductID", DbType.Int32, SecondhandProductID);

            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];

            SecondhandProductModel model = null;
            if (dt.Rows.Count > 0)
                model = BindModel(dt.Rows[0]);
            return model;
        }

        public DataTable GetList()
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_mwSecondhandProduct_GetList");
            return dbr.ExecuteDataSet(Command).Tables[0];
        }

        public bool Exists(int SecondhandProductID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_mwSecondhandProduct_Exists");

            dbr.AddInParameter(Command, "@SeProductID", DbType.Int32, SecondhandProductID);

            return Convert.ToInt32(dbr.ExecuteScalar(Command)) == 1;
        }


        private SecondhandProductModel BindModel(DataRow row)
        {
            SecondhandProductModel model = new SecondhandProductModel()
            {
                Address = Convert.ToString(row["Address"]),
                Brief = Convert.ToString(row["Brief"]),
                CateID = Convert.ToInt32(row["CateID"]),
                CatePath = Convert.ToString(row["CatePath"]),
                CellPhone = Convert.ToString(row["CellPhone"]),
                InsertTime = Convert.ToDateTime(row["InsertTime"]),
                MediumImage = Convert.ToString(row["MediumImage"]),
                Phone = Convert.ToString(row["Phone"]),
                PostCode = Convert.ToString(row["PostCode"]),
                Price = Convert.ToDecimal(row["Price"]),
                Region = Convert.ToString(row["region"]),
                SecondhandProductID = Convert.ToInt32(row["SeProductID"]),
                SecondhandProductName = Convert.ToString(row["SeProductName"]),
                SmallImage = Convert.ToString(row["SmallImage"]),
                SortValue = Convert.ToInt32(row["SortValue"]),
                Status = Convert.ToInt32(row["Status"]),
                Stock = Convert.ToInt32(row["Stock"]),
                TrueName = Convert.ToString(row["truename"]),
                UpdateTime = Convert.ToDateTime(row["UpdateTime"]),
                UsageCondition = Convert.ToInt32(row["usagecondition"]),
                UserID = Convert.ToString(row["UserID"])
            };


            return model;
        }
    }
}
