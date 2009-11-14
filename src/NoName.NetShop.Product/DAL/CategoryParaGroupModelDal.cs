using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Common;
using NoName.NetShop.Product.Model;
using System.Data;
using System.Data.Common;

namespace NoName.NetShop.Product.DAL
{
    public class CategoryParaGroupModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(CategoryParaGroupModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_pdCategoryParaGroup_Add");

            dbw.AddInParameter(Command, "@groupid", DbType.Int32, model.GroupID);
            dbw.AddInParameter(Command, "@groupname", DbType.String, model.GroupName);
            dbw.AddInParameter(Command, "@ordervalue", DbType.Int32, model.OrderValue);
            dbw.AddInParameter(Command, "@categoryid", DbType.Int32, model.CategoryID);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int GroupID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_pdCategoryParaGroup_Delete");

            dbw.AddInParameter(Command, "@groupid", DbType.Int32, GroupID);

            dbw.ExecuteNonQuery(Command);
        }

        public void Update(CategoryParaGroupModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_pdCategoryParaGroup_Update");
            
            dbw.AddInParameter(Command, "@groupid", DbType.Int32, model.GroupID);
            dbw.AddInParameter(Command, "@groupname", DbType.String, model.GroupName);
            dbw.AddInParameter(Command, "@categoryid", DbType.Int32, model.CategoryID);

            dbw.ExecuteNonQuery(Command);
        }

        public void SwichOrder(int GroupID,int SwitchGroupID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_pdCategoryParaGroup_SwitchOrder");

            dbw.AddInParameter(Command, "@groupid", DbType.Int32, GroupID);
            dbw.AddInParameter(Command, "@switchgroupid", DbType.Int32, SwitchGroupID);

            dbw.ExecuteNonQuery(Command);
        }


        public CategoryParaGroupModel GetModel(int GroupID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_pdCategoryParaGroup_Get");
            dbr.AddInParameter(Command, "@groupid", DbType.Int32, GroupID);
            return ReaderBind(dbr.ExecuteReader(Command));
        }

        public DataTable GetList(int CategoryID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_pdCategoryParaGroup_GetListByCategory");

            dbr.AddInParameter(Command, "@categoryid", DbType.Int32, CategoryID);

            return dbr.ExecuteDataSet(Command).Tables[0];
        }

        public CategoryParaGroupModel ReaderBind(IDataReader dataReader)
        {
            CategoryParaGroupModel model = new CategoryParaGroupModel();

            model.CategoryID = Convert.ToInt32(dataReader["categoryid"]);
            model.GroupID = Convert.ToInt32(dataReader["groupid"]);
            model.GroupName = Convert.ToString(dataReader["groupname"]);
            model.OrderValue = Convert.ToInt32(dataReader["ordervalue"]);

            return model;
        }
    }
}
