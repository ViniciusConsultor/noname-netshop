using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.News.Model;
using System.Data.Common;
using System.Data;
using NoName.NetShop.Common;

namespace NoName.NetShop.News.DAL
{
    public class NewsCategoryModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public NewsCategoryModelDal()
        {}

        public void Add(NewsCategoryModel Model)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_neCategory_ADD");

            dbw.AddInParameter(command, "@cateid", DbType.Int32, Model.CateID);
            dbw.AddInParameter(command, "@catename", DbType.String, Model.CateName);
            dbw.AddInParameter(command, "@status", DbType.Int16, Model.Status);
            dbw.AddInParameter(command, "@ishide", DbType.Boolean, Model.IsHide);
            dbw.AddInParameter(command, "@catelevel", DbType.Int32, Model.CateLevel);
            dbw.AddInParameter(command, "@parentid", DbType.Int32, Model.ParentID);
            dbw.AddInParameter(command, "@showorder", DbType.Int32, Model.ShowOrder);

            dbw.ExecuteNonQuery(command);
        }

        public void Delete(int CategoryID)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_neCategory_Delete");

            dbw.AddInParameter(command, "@cateid", DbType.Int32, CategoryID);

            dbw.ExecuteNonQuery(command);
        }

        public void Update(NewsCategoryModel Model)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_neCategory_Update");

            dbw.AddInParameter(command, "@cateid", DbType.Int32, Model.CateID);
            dbw.AddInParameter(command, "@catename", DbType.String, Model.CateName);
            dbw.AddInParameter(command, "@status", DbType.Int16, Model.Status);
            dbw.AddInParameter(command, "@ishide", DbType.Boolean, Model.IsHide);
            dbw.AddInParameter(command, "@catelevel", DbType.Int32, Model.CateLevel);
            dbw.AddInParameter(command, "@parentid", DbType.Int32, Model.ParentID);
            dbw.AddInParameter(command, "@showorder", DbType.Int32, Model.ShowOrder);

            dbw.ExecuteNonQuery(command);
        }

        public bool Exists(int CategoryID)
        {
            DbCommand command = dbr.GetStoredProcCommand("UP_neCategory_Exists");

            dbr.AddInParameter(command, "@cateid", DbType.Int32, CategoryID);

            return Convert.ToInt32(dbr.ExecuteScalar(command)) == 1;
        }

        public DataTable GetList(int ParentID)
        {
            DbCommand command = dbr.GetStoredProcCommand("UP_neCategory_GetList");

            dbr.AddInParameter(command, "@parentid", DbType.Int32, ParentID);

            return dbr.ExecuteDataSet(command).Tables[0];
        }

        public NewsCategoryModel GetModel(int CateID)
        {
            DbCommand command = dbr.GetStoredProcCommand("UP_neCategory_GetModel");

            dbr.AddInParameter(command, "@cateid", DbType.Int32, CateID);

            return ReaderBind(dbr.ExecuteReader(command));
        }

        private NewsCategoryModel ReaderBind(IDataReader dataReader)
        {
            NewsCategoryModel model = new NewsCategoryModel();

            model.CateID = Convert.ToInt32(dataReader["cateid"]);
            model.CateLevel = Convert.ToInt32(dataReader["catelevel"]);
            model.CateName = Convert.ToString(dataReader["catename"]);
            model.IsHide = Convert.ToBoolean(dataReader["ishide"]);
            model.ParentID = Convert.ToInt32(dataReader["parentid"]);
            model.ShowOrder = Convert.ToInt32(dataReader["showorder"]);
            model.Status = Convert.ToInt16(dataReader["status"]);

            return model;
        }


    }
}
