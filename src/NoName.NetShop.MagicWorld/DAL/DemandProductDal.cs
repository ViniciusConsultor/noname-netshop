using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.Model;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Common;
using System.Data;

namespace NoName.NetShop.MagicWorld.DAL
{
    public class DemandProductDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(DemandProductModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwDemand_Add");

            dbw.AddInParameter(Command,"@demandid",DbType.Int32,model.DemandID);
            dbw.AddInParameter(Command,"@demandname",DbType.String,model.DemandName);
            dbw.AddInParameter(Command,"@smallimage",DbType.String,model.SmallImage);
            dbw.AddInParameter(Command,"@mediumimage",DbType.String,model.MediumImage);
            dbw.AddInParameter(Command,"@categoryid",DbType.Int32,model.CategoryID);
            dbw.AddInParameter(Command,"@categorypath",DbType.String,model.CategoryPath);
            dbw.AddInParameter(Command,"@price",DbType.Decimal,model.Price);
            dbw.AddInParameter(Command,"@count",DbType.Int32,model.Count);
            dbw.AddInParameter(Command,"@usagecondition",DbType.Int16,model.UsageCondition);
            dbw.AddInParameter(Command,"@expirationtime",DbType.DateTime,model.ExpirationTime);
            dbw.AddInParameter(Command,"@brief",DbType.String,model.Brief);
            dbw.AddInParameter(Command,"@userid",DbType.String,model.UserID);
            dbw.AddInParameter(Command,"@truename",DbType.String,model.TrueName);
            dbw.AddInParameter(Command,"@phone",DbType.String,model.Phone);
            dbw.AddInParameter(Command,"@cellphone",DbType.String,model.CellPhone);
            dbw.AddInParameter(Command,"@postcode",DbType.String,model.PostCode);
            dbw.AddInParameter(Command,"@region",DbType.String,model.Region);
            dbw.AddInParameter(Command,"@address",DbType.String,model.Address);
            dbw.AddInParameter(Command, "@status", DbType.Int16, model.Status);
            dbw.AddInParameter(Command,"@inserttime",DbType.DateTime,model.InsertTime);
            dbw.AddInParameter(Command,"@updatetime",DbType.DateTime,model.UpdateTime);

            dbw.ExecuteNonQuery(Command);
        }

        
        public void Update(DemandProductModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwDemand_Update");

            dbw.AddInParameter(Command,"@demandid",DbType.Int32,model.DemandID);
            dbw.AddInParameter(Command,"@demandname",DbType.String,model.DemandName);
            dbw.AddInParameter(Command,"@smallimage",DbType.String,model.SmallImage);
            dbw.AddInParameter(Command,"@mediumimage",DbType.String,model.MediumImage);
            dbw.AddInParameter(Command,"@categoryid",DbType.Int32,model.CategoryID);
            dbw.AddInParameter(Command,"@categorypath",DbType.String,model.CategoryPath);
            dbw.AddInParameter(Command,"@price",DbType.Decimal,model.Price);
            dbw.AddInParameter(Command,"@count",DbType.Int32,model.Count);
            dbw.AddInParameter(Command,"@usagecondition",DbType.Int16,model.UsageCondition);
            dbw.AddInParameter(Command,"@expirationtime",DbType.DateTime,model.ExpirationTime);
            dbw.AddInParameter(Command,"@brief",DbType.String,model.Brief);
            dbw.AddInParameter(Command,"@userid",DbType.String,model.UserID);
            dbw.AddInParameter(Command,"@truename",DbType.String,model.TrueName);
            dbw.AddInParameter(Command,"@phone",DbType.String,model.Phone);
            dbw.AddInParameter(Command,"@cellphone",DbType.String,model.CellPhone);
            dbw.AddInParameter(Command,"@postcode",DbType.String,model.PostCode);
            dbw.AddInParameter(Command,"@region",DbType.String,model.Region);
            dbw.AddInParameter(Command,"@address",DbType.String,model.Address);
            dbw.AddInParameter(Command,"@status",DbType.Int16,model.Status);
            dbw.AddInParameter(Command,"@inserttime",DbType.DateTime,model.InsertTime);
            dbw.AddInParameter(Command,"@updatetime",DbType.DateTime,model.UpdateTime);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int DemandID)
        {
            string sql = "delete from mwdemand where demandid=" + DemandID;
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        public void UpdateStatus(int DemandID, int Status)
        {
            string sql = "update mwdemand set status = " + Status + " where demandid=" + DemandID;
            dbw.ExecuteNonQuery(CommandType.Text,sql);
        }


        public DemandProductModel GetModel(int DemandID)
        {
            string sql = "select * from mwdemand where demandid="+DemandID;
            DemandProductModel model = null;

            DataTable dt = dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
            if (dt.Rows.Count > 0) model = GetModel(dt.Rows[0]);

            return model;
        }


        private DemandProductModel GetModel(DataRow row)
        {
            return new DemandProductModel()
            {
                Address = Convert.ToString(row["Address"]),
                Brief = Convert.ToString(row["Brief"]),
                CategoryID = Convert.ToInt32(row["CategoryID"]),
                CategoryPath = Convert.ToString(row["CategoryPath"]),
                CellPhone = Convert.ToString(row["CellPhone"]),
                Count = Convert.ToInt32(row["Count"]),
                DemandID = Convert.ToInt32(row["DemandID"]),
                DemandName = Convert.ToString(row["DemandName"]),
                ExpirationTime = Convert.ToDateTime(row["ExpirationTime"]),
                InsertTime = Convert.ToDateTime(row["InsertTime"]),
                MediumImage = Convert.ToString(row["MediumImage"]),
                Phone = Convert.ToString(row["Phone"]),
                PostCode = Convert.ToString(row["PostCode"]),
                Price = Convert.ToDecimal(row["Price"]),
                Region = Convert.ToString(row["Region"]),
                SmallImage = Convert.ToString(row["SmallImage"]),
                Status = Convert.ToInt16(row["Status"]),
                TrueName = Convert.ToString(row["TrueName"]),
                UpdateTime = Convert.ToDateTime(row["UpdateTime"]),
                UsageCondition = Convert.ToInt32(row["UsageCondition"]),
                UserID = Convert.ToString(row["UserID"])
            };
        }
    }
}
