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

            dbw.AddInParameter(Command, "@RentorderID", DbType.Int32, model.RentLogID);
            dbw.AddInParameter(Command, "@RentID", DbType.Int32, model.RentID);
            dbw.AddInParameter(Command, "@UserID", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@PaySum", DbType.Decimal, model.PaySum);
            dbw.AddInParameter(Command, "@rentmonths", DbType.Int32, model.RentMonths);
            dbw.AddInParameter(Command, "@ApplyInfo", DbType.String, model.ApplyInfo);
            dbw.AddInParameter(Command, "@ApplyTime", DbType.DateTime, model.ApplyTime);
            dbw.AddInParameter(Command, "@StartTime", DbType.DateTime, model.StartTime);
            dbw.AddInParameter(Command, "@EndTime", DbType.DateTime, model.EndTime);
            dbw.AddInParameter(Command, "@Status", DbType.Int16, model.Status);
            dbw.AddInParameter(Command, "@truename", DbType.String, model.Truename);
            dbw.AddInParameter(Command, "@phone", DbType.String, model.Phone);
            dbw.AddInParameter(Command, "@cellphone", DbType.String, model.Cellphone);
            dbw.AddInParameter(Command, "@postcode", DbType.String, model.Postcode);
            dbw.AddInParameter(Command, "@region", DbType.String, model.Region);
            dbw.AddInParameter(Command, "@address", DbType.String, model.Address);

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

            dbw.AddInParameter(Command, "@RentorderID", DbType.Int32, model.RentLogID);
            dbw.AddInParameter(Command, "@RentID", DbType.Int32, model.RentID);
            dbw.AddInParameter(Command, "@UserID", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@PaySum", DbType.Decimal, model.PaySum);
            dbw.AddInParameter(Command, "@ApplyInfo", DbType.String, model.ApplyInfo);
            dbw.AddInParameter(Command, "@rentmonths", DbType.Int32, model.RentMonths);
            dbw.AddInParameter(Command, "@ApplyTime", DbType.DateTime, model.ApplyTime);
            dbw.AddInParameter(Command, "@StartTime", DbType.DateTime, model.StartTime);
            dbw.AddInParameter(Command, "@EndTime", DbType.DateTime, model.EndTime);
            dbw.AddInParameter(Command, "@Status", DbType.Int16, model.Status);
            dbw.AddInParameter(Command, "@truename", DbType.String, model.Truename);
            dbw.AddInParameter(Command, "@phone", DbType.String, model.Phone);
            dbw.AddInParameter(Command, "@cellphone", DbType.String, model.Cellphone);
            dbw.AddInParameter(Command, "@postcode", DbType.String, model.Postcode);
            dbw.AddInParameter(Command, "@region", DbType.String, model.Region);
            dbw.AddInParameter(Command, "@address", DbType.String, model.Address);

            dbw.ExecuteNonQuery(Command);
        }

        public void UpdateStatus(int RentLogID,int Status)
        {
            string sql = "UPDATE [mwRentLog] SET [status] = {0} WHERE [rentorderid] = {1}";
            sql = String.Format(sql,Status,RentLogID);
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        public int GetLogCount(int RentID)
        {
            string sql = "select count(0) from [mwRentLog] where [rentid]={0}";
            return Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text, String.Format(sql, RentID)));
        }

        public RentLogModel GetModel(int RentID, string UserID)
        {
            string sql = "SELECT * FROM [mwRentLog] WHERE [rentid]={0} AND [userid]='{1}'";
            sql = String.Format(sql,RentID,UserID);

            DataTable dt = dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return GetModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
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

        public DataTable GetListOfProduct(int PageIndex, int PageSize, int RentID, out int RecordCount)
        {
            int PageLowerBound = 0, PageUpperBount = 0;
            PageLowerBound = (PageIndex - 1) * PageSize;
            PageUpperBount = PageLowerBound + PageSize;

            string sqlCount = @"select count(0) from [mwRentLog] l
                                inner join [mwRentProduct] p on p.rentid=l.rentid
                                where l.rentid={0}";
            RecordCount = Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text, String.Format(sqlCount, RentID)));

            string sqlData = @" select * from
                                    (select row_number() over(order by l.applytime desc) as nid,
                                            l.*,p.rentname
                                        from [mwRentLog] l
                                        inner join [mwRentProduct] p on p.rentid=l.rentid
                                    where l.rentid={0}) 
                                as sp
                                where sp.nid>{1} and sp.nid<={2}";
            return dbr.ExecuteDataSet(CommandType.Text, String.Format(sqlData, RentID, PageLowerBound, PageUpperBount)).Tables[0];
        }

        public DataTable GetListOfUser(int PageIndex, int PageSize, string UserID, out int RecordCount)
        {
            int PageLowerBound = 0, PageUpperBount = 0;
            PageLowerBound = (PageIndex - 1) * PageSize;
            PageUpperBount = PageLowerBound + PageSize;

            string sqlCount = @"select count(0) from [mwRentLog] l
                                inner join [mwRentProduct] p on p.rentid=l.rentid
                                where userid='{0}'";
            RecordCount = Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text,String.Format(sqlCount,UserID)));

            string sqlData = @"select * from
                                (select row_number() over(order by l.applytime desc) as nid,l.*,p.rentname,p.cashpledge from [mwRentLog] l
                                inner join [mwRentProduct] p on p.rentid=l.rentid
                                where userid='{0}') as sp
                                where sp.nid>{1} and sp.nid<={2}";
            return dbr.ExecuteDataSet(CommandType.Text, String.Format(sqlData,UserID,PageLowerBound,PageUpperBount)).Tables[0];
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
            model.RentMonths = Convert.ToInt32(row["rentmonths"]);
            model.Truename = Convert.ToString(row["truename"]);
            model.Phone = Convert.ToString(row["phone"]);
            model.Cellphone = Convert.ToString(row["cellphone"]);
            model.Postcode = Convert.ToString(row["postcode"]);
            model.Region = Convert.ToString(row["region"]);
            model.Address = Convert.ToString(row["address"]);

            return model;
        }



    }
}
