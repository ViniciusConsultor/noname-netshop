using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Product.Model;
using System.Data;
using System.Data.Common;

namespace NoName.NetShop.Product.DAL
{
    public class ProductSpecificationDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public bool Exists(int SpecificationID)
        {
            string SpName = "UP_pdProductSpecification_Exists";
            DbCommand Command = dbr.GetStoredProcCommand(SpName);

            dbr.AddInParameter(Command, "@SpecificationID", DbType.Int32, SpecificationID);

            return Convert.ToInt32(dbr.ExecuteScalar(Command)) == 1;
        }


        public void Insert(ProductSpecificationModel Model)
        {
            string SpName = "UP_pdProductSpecification_ADD";
            DbCommand Command = dbw.GetStoredProcCommand(SpName);


            dbw.AddInParameter(Command, "@SpecificationID", DbType.Int32, Model.SpecificationID);
            dbw.AddInParameter(Command, "@Title", DbType.String, Model.Title);
            dbw.AddInParameter(Command, "@Content", DbType.String, Model.Content);
            dbw.AddInParameter(Command, "@CategoryID", DbType.Int32, Model.CategoryID);
            dbw.AddInParameter(Command, "@CategoryPath", DbType.String, Model.CategoryPath);
            dbw.AddInParameter(Command, "@CreateTime", DbType.DateTime, Model.CreateTime);

            dbw.ExecuteNonQuery(Command);
        }


        public void Update(ProductSpecificationModel Model)
        {
            string SpName = "UP_pdProductSpecification_Update";
            DbCommand Command = dbw.GetStoredProcCommand(SpName);

            dbw.AddInParameter(Command, "@SpecificationID", DbType.Int32, Model.SpecificationID);
            dbw.AddInParameter(Command, "@Title", DbType.String, Model.Title);
            dbw.AddInParameter(Command, "@Content", DbType.String, Model.Content);
            dbw.AddInParameter(Command, "@CategoryID", DbType.Int32, Model.CategoryID);
            dbw.AddInParameter(Command, "@CategoryPath", DbType.String, Model.CategoryPath);
            dbw.AddInParameter(Command, "@CreateTime", DbType.DateTime, Model.CreateTime);

            dbw.ExecuteNonQuery(Command);
        }



        public void Delete(int SpecificationID)
        {
            string SpName = "UP_pdProductSpecification_Delete";
            DbCommand Command = dbw.GetStoredProcCommand(SpName);

            dbw.AddInParameter(Command, "@SpecificationID", DbType.Int32, SpecificationID);

            dbw.ExecuteNonQuery(Command);
        }


        public ProductSpecificationModel GetModel(int SpecificationID)
        {
            string SpName = "UP_pdProductSpecification_GetModel";
            DbCommand Command = dbr.GetStoredProcCommand(SpName);

            dbr.AddInParameter(Command, "@SpecificationID", DbType.Int32, SpecificationID);

            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];
            ProductSpecificationModel model = null;

            if (dt.Rows.Count > 0)
            {
                model = new ProductSpecificationModel(dt.Rows[0]);
            }

            return model;
        }


        public DataTable GetList()
        {
            string SpName = "UP_pdProductSpecification_GetList";
            DbCommand Command = dbr.GetStoredProcCommand(SpName);
            return dbr.ExecuteDataSet(Command).Tables[0];
        }

    }
}
