using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.MagicWorld.Model;
using System.Data;
using System.Data.Common;

namespace NoName.NetShop.MagicWorld.DAL
{
    public class RentLogDal
    {        
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(RentLogModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwRentLog_Add");

            dbw.AddInParameter(Command,"@RentorderID",DbType.Int32,model.RentLogID);
            dbw.AddInParameter(Command,"@RentID",DbType.Int32,model.RentID);
            dbw.AddInParameter(Command,"@UserID",DbType.String,model.UserID);
            dbw.AddInParameter(Command,"@PaySum",DbType.Decimal,model.PaySum);
            dbw.AddInParameter(Command,"@ApplyInfo",DbType.String,model.ApplyInfo);
            dbw.AddInParameter(Command,"@ApplyTime",DbType.DateTime,model.ApplyTime);
            dbw.AddInParameter(Command,"@StartTime",DbType.DateTime,model.StartTime);
            dbw.AddInParameter(Command,"@EndTime",DbType.DateTime,model.EndTime);
            dbw.AddInParameter(Command,"@Status",DbType.Int16,model.Status);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int RentLogID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwRentLog_Delete");
            
            dbw.AddInParameter(Command,"@RentorderID",DbType.Int32,RentLogID);

            dbw.ExecuteNonQuery(Command);
        }

        public void Update(RentLogModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwRentLog_Update");

            dbw.AddInParameter(Command,"@RentorderID",DbType.Int32,model.RentLogID);
            dbw.AddInParameter(Command,"@RentID",DbType.Int32,model.RentID);
            dbw.AddInParameter(Command,"@UserID",DbType.String,model.UserID);
            dbw.AddInParameter(Command,"@PaySum",DbType.Decimal,model.PaySum);
            dbw.AddInParameter(Command,"@ApplyInfo",DbType.String,model.ApplyInfo);
            dbw.AddInParameter(Command,"@ApplyTime",DbType.DateTime,model.ApplyTime);
            dbw.AddInParameter(Command,"@StartTime",DbType.DateTime,model.StartTime);
            dbw.AddInParameter(Command,"@EndTime",DbType.DateTime,model.EndTime);
            dbw.AddInParameter(Command,"@Status",DbType.Int16,model.Status);

            dbw.ExecuteNonQuery(Command);
        }

        public void UpdateStatus(int RentLogID,int Status)
        {
            string sql = "UPDATE [mwRentLog] SET [status] = {0} WHERE [rentorderid] = {1}";
            sql = String.Format(sql,Status,RentLogID);
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        public RentLogModel GetModel(int RentLogID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_mwRentLog_Get");
            
            dbr.AddInParameter(Command,"@RentorderID",DbType.Int32,RentLogID);

            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];

            if(dt.Rows.Count>0)
            {
                return GetModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public DataTable GetList(int PageIndex,int PageSize,string Condition,out int RecordCount)
        {
            throw new NotImplementedException();

        }

       
        private RentLogModel GetModel(DataRow row)
        {
            RentLogModel model = new RentLogModel();

            model.ApplyInfo = Convert.ToString(row["applyinfo"]);
            model.ApplyTime = Convert.ToDateTime(row["applytime"]);
            model.EndTime = Convert.ToDateTime(row["endtime"]);
            model.PaySum = Convert.ToDecimal(row["paysum"]);
            model.RentID = Convert.ToInt32(row["rentid"]);
            model.RentLogID = Convert.ToInt32(row["rentorderid"]);
            model.StartTime = Convert.ToDateTime(row["starttime"]);
            model.Status = Convert.ToInt16(row["status"]);
            model.UserID = Convert.ToString(row["userid"]);

            return model;
        }

    //[UP_mwRentLog_GetListByUser]
    //@UserID varchar(64)

    //    [UP_mwRentLog_GetListByProduct]
    //@RentID int


    }
}
