using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Common;
using NoName.NetShop.MagicWorld.Model;
using System.Data;
using System.Data.Common;

namespace NoName.NetShop.MagicWorld.DAL
{
    public class RentProductDal
    {        
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(RentProductModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwRentProduct_Add");
            
            dbw.AddInParameter(Command,"@rentid",DbType.Int32,model.RentID);
            dbw.AddInParameter(Command,"@rentname",DbType.String,model.RentName);
            dbw.AddInParameter(Command,"@smallimage",DbType.String,model.SmallImage);
            dbw.AddInParameter(Command,"@mediumimage",DbType.String,model.MediumImage);
            dbw.AddInParameter(Command,"@stock",DbType.Int32,model.Stock);
            dbw.AddInParameter(Command,"@keywords",DbType.String,model.Keywords);
            dbw.AddInParameter(Command,"@categoryid",DbType.Int32,model.CategoryID);
            dbw.AddInParameter(Command,"@categorypath",DbType.String,model.CategoryPath);
            dbw.AddInParameter(Command,"@rentprice",DbType.Decimal,model.RentPrice);
            dbw.AddInParameter(Command,"@cashpledge",DbType.Decimal,model.CashPledge);
            dbw.AddInParameter(Command,"@maxrenttime",DbType.Int32,model.MaxRentTime);
            dbw.AddInParameter(Command,"@brief",DbType.String,model.Brief);
            dbw.AddInParameter(Command,"@status",DbType.Int16,model.Status);
            dbw.AddInParameter(Command,"@createtime",DbType.DateTime,model.CreateTime);
            dbw.AddInParameter(Command,"@updatetime",DbType.DateTime,model.UpdateTime);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int RentID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwRentProduct_Delete");

            dbw.AddInParameter(Command, "@rentid", DbType.Int32, RentID);

            dbw.ExecuteNonQuery(Command);
        }

        public void Update(RentProductModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_mwRentProduct_Update");

            dbw.AddInParameter(Command, "@rentid", DbType.Int32, model.RentID);
            dbw.AddInParameter(Command, "@rentname", DbType.String, model.RentName);
            dbw.AddInParameter(Command, "@smallimage", DbType.String, model.SmallImage);
            dbw.AddInParameter(Command, "@mediumimage", DbType.String, model.MediumImage);
            dbw.AddInParameter(Command, "@stock", DbType.Int32, model.Stock);
            dbw.AddInParameter(Command, "@keywords", DbType.String, model.Keywords);
            dbw.AddInParameter(Command, "@categoryid", DbType.Int32, model.CategoryID);
            dbw.AddInParameter(Command, "@categorypath", DbType.String, model.CategoryPath);
            dbw.AddInParameter(Command, "@rentprice", DbType.Decimal, model.RentPrice);
            dbw.AddInParameter(Command, "@cashpledge", DbType.Decimal, model.CashPledge);
            dbw.AddInParameter(Command, "@maxrenttime", DbType.Int32, model.MaxRentTime);
            dbw.AddInParameter(Command, "@brief", DbType.String, model.Brief);
            dbw.AddInParameter(Command, "@status", DbType.Int16, model.Status);
            dbw.AddInParameter(Command, "@createtime", DbType.DateTime, model.CreateTime);
            dbw.AddInParameter(Command, "@updatetime", DbType.DateTime, model.UpdateTime);

            dbw.ExecuteNonQuery(Command);
        }

        public void UpdateStatus(int RentID, int Status)
        {
            string sql = "update mwRentProduct set status = {0} where rentid={1}";
            dbw.ExecuteNonQuery(CommandType.Text, String.Format(sql, Status, RentID));
        }

        public RentProductModel GetModel(int RentID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_mwRentProduct_Get");

            dbr.AddInParameter(Command, "@rentid", DbType.Int32, RentID);

            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];

            RentProductModel model = null;

            if (dt.Rows.Count > 0)
            {
                model = GetModel(dt.Rows[0]);
            }

            return model;
        }

        public DataTable GetList(int PageIndex,int PageSize,string Condition,string Order,out int RecordCount)
        {
            int PageLowerBound = 0, PageUpperBount = 0;
            PageLowerBound = (PageIndex - 1) * PageSize;
            PageUpperBount = PageLowerBound + PageSize;

            string sqlCount = @"select count(0) from [mwRentProduct]";
            string sqlData = @" select * from
                                (select row_number() over (order by createtime desc) as id,* from [mwRentProduct])
                                as sp
                                where id > " + PageLowerBound + " and id<" + PageUpperBount + " " + Condition + (String.IsNullOrEmpty(Order) ? String.Empty : " order by " + Order);

            RecordCount = Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text,sqlCount));

            return dbr.ExecuteDataSet(CommandType.Text, sqlData).Tables[0];
        }

        public DataTable GetNewestList(int TopCount)
        {
            string sql = "select top {0} * from mwrentproduct where status=0 order by rentid desc";
            sql = String.Format(sql,TopCount);
            return dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        private RentProductModel GetModel(DataRow row)
        {
            RentProductModel model = new RentProductModel();

            model.Brief=Convert.ToString(row["brief"]);
            model.CategoryID=Convert.ToInt32(row["categoryid"]);
            model.CategoryPath=Convert.ToString(row["categorypath"]);
            model.CreateTime=Convert.ToDateTime(row["createtime"]);
            model.Keywords=Convert.ToString(row["keywords"]);
            model.MaxRentTime=Convert.ToInt32(row["maxrenttime"]);
            model.MediumImage=Convert.ToString(row["mediumimage"]);
            model.RentID=Convert.ToInt32(row["rentid"]);
            model.RentName=Convert.ToString(row["rentname"]);
            model.RentPrice=Convert.ToDecimal(row["rentprice"]);
            model.CashPledge = Convert.ToDecimal(row["cashpledge"]);
            model.SmallImage=Convert.ToString(row["smallimage"]);
            model.Status=Convert.ToInt16(row["status"]);
            model.Stock=Convert.ToInt32(row["stock"]);
            model.UpdateTime=Convert.ToDateTime(row["updatetime"]);

            return model;
        }


        



        

        
    }
}
