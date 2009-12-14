using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Common;
using NoName.NetShop.MagicWorld.Model;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.MagicWorld.DAL
{
    public class MagicCategoryDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(MagicCategoryModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwCategory_Add");

            dbw.AddInParameter(Command,"@CategoryID",DbType.Int32,model.CategoryID);
            dbw.AddInParameter(Command,"@CategoryName",DbType.String,model.CategoryName);
            dbw.AddInParameter(Command,"@CategoryPath",DbType.String,model.CategoryPath);
            dbw.AddInParameter(Command,"@Status",DbType.Int16,model.Status);
            dbw.AddInParameter(Command,"@IsHide",DbType.Boolean,model.IsHide);
            dbw.AddInParameter(Command,"@CategoryLevel",DbType.Int32,model.CategoryLevel);
            dbw.AddInParameter(Command,"@ParentID",DbType.Int32,model.ParentID);
            dbw.AddInParameter(Command,"@ShowOrder",DbType.Int32,model.ShowOrder);

            dbw.ExecuteNonQuery(Command);
        }

        public void Update(MagicCategoryModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwCategory_Update");

            dbw.AddInParameter(Command,"@CategoryID",DbType.Int32,model.CategoryID);
            dbw.AddInParameter(Command,"@CategoryName",DbType.String,model.CategoryName);
            dbw.AddInParameter(Command,"@CategoryPath",DbType.String,model.CategoryPath);
            dbw.AddInParameter(Command,"@Status",DbType.Int16,model.Status);
            dbw.AddInParameter(Command,"@IsHide",DbType.Boolean,model.IsHide);
            dbw.AddInParameter(Command,"@CategoryLevel",DbType.Int32,model.CategoryLevel);
            dbw.AddInParameter(Command,"@ParentID",DbType.Int32,model.ParentID);
            dbw.AddInParameter(Command,"@ShowOrder",DbType.Int32,model.ShowOrder);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int CategoryID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwCategory_Delete");

            dbw.AddInParameter(Command,"@CategoryID",DbType.Int32,CategoryID);
            
            dbw.ExecuteNonQuery(Command);
        }

        public void SwitchOrder(int OriginCateID, int SwitchCateID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwCategory_ChangeOrder");
            dbw.AddInParameter(Command,"@initialcateid",DbType.Int32,OriginCateID);
            dbw.AddInParameter(Command,"@replacedcateid",DbType.Int32,SwitchCateID);

            dbw.ExecuteNonQuery(Command);
        }

        public DataTable GetList(int ParentID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_mwCategory_GetList");

            dbr.AddInParameter(Command,"@ParentID",DbType.Int32,ParentID);

            return dbr.ExecuteDataSet(Command).Tables[0];
        }

        public MagicCategoryModel GetModel(int CategoryID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_mwCategory_Get");

            dbr.AddInParameter(Command,"@CategoryID",DbType.Int32,CategoryID);
            
            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];

            MagicCategoryModel model = null;
            if(dt.Rows.Count>0)
            {
                model = BindModel(dt.Rows[0]);
            }

            return model;

        }


        private MagicCategoryModel BindModel(DataRow row)
        {
            MagicCategoryModel model = new MagicCategoryModel();

            model.CategoryID = Convert.ToInt32(row["categoryid"]);
            model.CategoryLevel = Convert.ToInt32(row["categorylevel"]);
            model.CategoryName = Convert.ToString(row["categoryname"]);
            model.CategoryPath = Convert.ToString(row["categorypath"]);
            model.IsHide = Convert.ToBoolean(row["ishide"]);
            model.ParentID = Convert.ToInt32(row["parentid"]);
            model.ShowOrder = Convert.ToInt32(row["showorder"]);
            model.Status = Convert.ToInt32(row["status"]);

            return model;
        }

    }
}
