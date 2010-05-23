using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.GroupShopping.Model;
using System.Data;
using System.Data.Common;

namespace NoName.NetShop.GroupShopping.DAL
{
    public class GroupApplyDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public bool Exists(int GroupApplyID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_gsApply_Exists");

            dbr.AddInParameter(Command, "@GroupApplyID", DbType.Int32, GroupApplyID);

            int Result = 0;

            int.TryParse(dbr.ExecuteScalar(Command).ToString(), out Result);

            return Result == 1;
        }

        public void Add(GroupApplyModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_gsApply_ADD");

            dbw.AddInParameter(Command, "@GroupApplyID", DbType.Int32, model.GroupApplyID);
            dbw.AddInParameter(Command, "@GroupProductID", DbType.Int32, model.GroupProductID);
            dbw.AddInParameter(Command, "@UserID", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@ApplyStatus", DbType.Int16, model.ApplyStatus);
            dbw.AddInParameter(Command, "@ApplyBrief", DbType.String, model.ApplyBrief);
            dbw.AddInParameter(Command, "@ApplyTime", DbType.DateTime, model.ApplyTime);
            dbw.AddInParameter(Command, "@ConfirmTime", DbType.DateTime, model.ConfirmTime);

            dbw.ExecuteNonQuery(Command);
        }

        public void Update(GroupApplyModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_gsApply_Update");
            dbw.AddInParameter(Command, "@GroupApplyID", DbType.Int32, model.GroupApplyID);
            dbw.AddInParameter(Command, "@GroupProductID", DbType.Int32, model.GroupProductID);
            dbw.AddInParameter(Command, "@UserID", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@ApplyStatus", DbType.Int16, model.ApplyStatus);
            dbw.AddInParameter(Command, "@ApplyBrief", DbType.String, model.ApplyBrief);
            dbw.AddInParameter(Command, "@ApplyTime", DbType.DateTime, model.ApplyTime);
            dbw.AddInParameter(Command, "@ConfirmTime", DbType.DateTime, model.ConfirmTime);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int GroupApplyID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_gsApply_Delete");

            dbw.AddInParameter(Command, "@GroupApplyID", DbType.Int32, GroupApplyID);

            dbw.ExecuteNonQuery(Command);
        }

        public GroupApplyModel GetModel(int GroupApplyID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_gsApply_GetModel");
            dbr.AddInParameter(Command, "@GroupApplyID", DbType.Int32, GroupApplyID);
            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];

            GroupApplyModel model = null;
            if (dt.Rows.Count > 0)
            {
                model = GetModel(dt.Rows[0]);
            }
            return model;
        }

        public DataTable GetList(int ProductID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_gsApply_GetList");

            dbr.AddInParameter(Command, "@ProductID", DbType.Int32, ProductID);

            return dbr.ExecuteDataSet(Command).Tables[0];
        }

        public List<GroupApplyModel> GetIList(int ProductID)
        {
            List<GroupApplyModel> List = new List<GroupApplyModel>();

            DataTable dt = GetList(ProductID);

            foreach (DataRow row in dt.Rows)
            {
                List.Add(GetModel(row));
            }

            return List;
        }

        private GroupApplyModel GetModel(DataRow row)
        {
            GroupApplyModel model = new GroupApplyModel();

            model.ApplyBrief = Convert.ToString(row["ApplyBrief"]);
            model.ApplyStatus = Convert.ToInt16(row["ApplyStatus"]);
            model.ApplyTime = Convert.ToDateTime(row["ApplyTime"]);
            model.ConfirmTime = Convert.ToDateTime(row["ConfirmTime"]);
            model.GroupApplyID = Convert.ToInt32(row["GroupApplyID"]);
            model.GroupProductID = Convert.ToInt32(row["GroupProductID"]);
            model.UserID = Convert.ToString(row["UserID"]);

            return model;
        }
    }
}


