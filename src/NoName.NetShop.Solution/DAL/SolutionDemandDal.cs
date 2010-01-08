using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Solution.Model;
using System.Data.Common;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace NoName.NetShop.Solution.DAL
{
    public class SolutionDemandDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(SolutionDemandModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_slDemand_Add");

            dbw.AddInParameter(Command,"@demandid",DbType.Int32,model.DemandID);
            dbw.AddInParameter(Command,"@demanddetail",DbType.String,model.DemandDetail);
            dbw.AddInParameter(Command,"@fieldphotoes",DbType.String,model.FieldPhotoes);
            dbw.AddInParameter(Command,"@fieldsituation",DbType.String,model.FieldSituation);
            dbw.AddInParameter(Command,"@effectsituation",DbType.String,model.EffectSituation);
            dbw.AddInParameter(Command,"@budget",DbType.Decimal,model.Budget);
            dbw.AddInParameter(Command,"@contactor",DbType.String,model.Contactor);
            dbw.AddInParameter(Command,"@contactphone",DbType.String,model.ContactPhone);
            dbw.AddInParameter(Command,"@postcode",DbType.String,model.Postcode);
            dbw.AddInParameter(Command,"@region",DbType.String,model.Region);
            dbw.AddInParameter(Command,"@address",DbType.String,model.Address);
            dbw.AddInParameter(Command,"@userid",DbType.String,model.UserID);
            dbw.AddInParameter(Command,"@createtime",DbType.DateTime,model.CreateTime);
            dbw.AddInParameter(Command,"@updatetime",DbType.DateTime,model.UpdateTime);
            dbw.AddInParameter(Command,"@status",DbType.Int16,model.Status);

            dbw.ExecuteNonQuery(Command);
        }

        public void Update(SolutionDemandModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_slDemand_Update");

            dbw.AddInParameter(Command, "@demandid", DbType.Int32, model.DemandID);
            dbw.AddInParameter(Command, "@demanddetail", DbType.String, model.DemandDetail);
            dbw.AddInParameter(Command, "@fieldphotoes", DbType.String, model.FieldPhotoes);
            dbw.AddInParameter(Command, "@fieldsituation", DbType.String, model.FieldSituation);
            dbw.AddInParameter(Command, "@effectsituation", DbType.String, model.EffectSituation);
            dbw.AddInParameter(Command, "@budget", DbType.Decimal, model.Budget);
            dbw.AddInParameter(Command, "@contactor", DbType.String, model.Contactor);
            dbw.AddInParameter(Command, "@contactphone", DbType.String, model.ContactPhone);
            dbw.AddInParameter(Command, "@postcode", DbType.String, model.Postcode);
            dbw.AddInParameter(Command, "@region", DbType.String, model.Region);
            dbw.AddInParameter(Command, "@address", DbType.String, model.Address);
            dbw.AddInParameter(Command, "@userid", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@createtime", DbType.DateTime, model.CreateTime);
            dbw.AddInParameter(Command, "@updatetime", DbType.DateTime, model.UpdateTime);
            dbw.AddInParameter(Command, "@status", DbType.Int16, model.Status);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int DemandID)
        {
            string sql = "delete from slDemand where demandid=" + DemandID;
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        public SolutionDemandModel GetModel(int DemandID)
        {
            string sql = "select * from [slDemand] where demandid="+DemandID;
            SolutionDemandModel model = null;

            DataTable dt = dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
            if(dt.Rows.Count>0)
            {
                model = GetModel(dt.Rows[0]);
            }

            return model;
        }

        public DataTable GetList(int PageIndex, int PageSize, string Condititon, out int RecordCount)
        {
            int PageLowerBound = 0, PageUpperBount = 0;
            PageLowerBound = (PageIndex - 1) * PageSize;
            PageUpperBount = PageLowerBound + PageSize;

            string sqlCount = "select count(0) from slDemand where 1=1 " + Condititon;
            string sqlData = @" select * from (
	                                select row_number() over(order by demandid desc) as nid,* from slDemand
	                                where 1=1 {0}) as sp
                                where nid>{1} and nid<={2}";

            RecordCount = Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text,sqlCount));
            return dbr.ExecuteDataSet(CommandType.Text, String.Format(sqlData, Condititon, PageLowerBound, PageUpperBount)).Tables[0];
        }

        private SolutionDemandModel GetModel(DataRow row)
        {
            SolutionDemandModel model = new SolutionDemandModel()
            {
                Address = Convert.ToString(row["Address"]),
                Budget = Convert.ToDecimal(row["Budget"]),
                Contactor = Convert.ToString(row["Contactor"]),
                ContactPhone = Convert.ToString(row["ContactPhone"]),
                CreateTime = Convert.ToDateTime(row["CreateTime"]),
                DemandDetail = Convert.ToString(row["DemandDetail"]),
                DemandID = Convert.ToInt32(row["DemandID"]),
                EffectSituation = Convert.ToString(row["EffectSituation"]),
                FieldPhotoes = Convert.ToString(row["FieldPhotoes"]),
                FieldSituation = Convert.ToString(row["FieldSituation"]),
                Postcode = Convert.ToString(row["Postcode"]),
                Region = Convert.ToString(row["Region"]),
                Status = Convert.ToInt16(row["Status"]),
                UpdateTime = Convert.ToDateTime(row["UpdateTime"]),
                UserID = Convert.ToString(row["UserID"])
            };



            return model;
        }
    }
}
