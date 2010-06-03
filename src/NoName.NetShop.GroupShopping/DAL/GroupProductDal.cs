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
    public class GroupProductDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public bool Exists(int ProductID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_gsProduct_Exists");
            
            dbr.AddInParameter(Command,"@ProductID",DbType.Int32,ProductID);

            int Result = 0;

            int.TryParse(dbr.ExecuteScalar(Command).ToString(), out Result);

            return Result == 1;
        }

        public void Add(GroupProductModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_gsProduct_ADD");
            
            dbw.AddInParameter(Command,"@ProductID",DbType.Int32,model.ProductID);
            dbw.AddInParameter(Command,"@ProductName",DbType.String,model.ProductName);
            dbw.AddInParameter(Command, "@ProductCode", DbType.String, model.ProductCode);
            dbw.AddInParameter(Command, "@MarketPrice", DbType.Decimal, model.MarketPrice);
            dbw.AddInParameter(Command,"@GroupPrice",DbType.Decimal,model.GroupPrice);
            dbw.AddInParameter(Command, "@PrePaidPrice", DbType.Decimal, model.PrePaidPrice);
            dbw.AddInParameter(Command, "@succedline", DbType.Int32, model.SuccedLine);
            dbw.AddInParameter(Command,"@SmallImage",DbType.String,model.SmallImage);
            dbw.AddInParameter(Command,"@MediumImage",DbType.String,model.MediumImage);
            dbw.AddInParameter(Command,"@LargeImage",DbType.String,model.LargeImage);
            dbw.AddInParameter(Command,"@Detail",DbType.String,model.Detail);
            dbw.AddInParameter(Command,"@Description",DbType.String,model.Description);
            dbw.AddInParameter(Command,"@InsertTime",DbType.DateTime,model.InsertTime);
            dbw.AddInParameter(Command,"@ChangeTime",DbType.DateTime,model.ChangeTime);
            dbw.AddInParameter(Command,"@Status",DbType.Int16,model.Status);
            dbw.AddInParameter(Command, "@ProductType", DbType.Int16, model.ProductType);
            dbw.AddInParameter(Command, "@isrecommend", DbType.Boolean, model.IsRecommend);

            dbw.ExecuteNonQuery(Command);
        }

        public void Update(GroupProductModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_gsProduct_Update");

            dbw.AddInParameter(Command, "@ProductID", DbType.Int32, model.ProductID);
            dbw.AddInParameter(Command, "@ProductName", DbType.String, model.ProductName);
            dbw.AddInParameter(Command, "@ProductCode", DbType.String, model.ProductCode);
            dbw.AddInParameter(Command, "@MarketPrice", DbType.Decimal, model.MarketPrice);
            dbw.AddInParameter(Command, "@GroupPrice", DbType.Decimal, model.GroupPrice);
            dbw.AddInParameter(Command, "@PrePaidPrice", DbType.Decimal, model.PrePaidPrice);
            dbw.AddInParameter(Command, "@succedline", DbType.Int32, model.SuccedLine);
            dbw.AddInParameter(Command, "@SmallImage", DbType.String, model.SmallImage);
            dbw.AddInParameter(Command, "@MediumImage", DbType.String, model.MediumImage);
            dbw.AddInParameter(Command, "@LargeImage", DbType.String, model.LargeImage);
            dbw.AddInParameter(Command, "@Detail", DbType.String, model.Detail);
            dbw.AddInParameter(Command, "@Description", DbType.String, model.Description);
            dbw.AddInParameter(Command, "@InsertTime", DbType.DateTime, model.InsertTime);
            dbw.AddInParameter(Command, "@ChangeTime", DbType.DateTime, model.ChangeTime);
            dbw.AddInParameter(Command, "@Status", DbType.Int16, model.Status);
            dbw.AddInParameter(Command, "@ProductType", DbType.Int16, model.ProductType);
            dbw.AddInParameter(Command, "@isrecommend", DbType.Boolean, model.IsRecommend);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int ProductID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_gsProduct_Delete");
            
            dbw.AddInParameter(Command, "@ProductID", DbType.Int32, ProductID);
            
            dbw.ExecuteNonQuery(Command);
        }

        public GroupProductModel GetModel(int ProductID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_gsProduct_GetModel");
            
            dbw.AddInParameter(Command, "@ProductID", DbType.Int32, ProductID);

            GroupProductModel model = null;

            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];
            if (dt.Rows.Count > 0) model = GetModel(dt.Rows[0]);

            return model;
        }

        public DataTable GetList()
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_gsProduct_GetList");
            return dbr.ExecuteDataSet(Command).Tables[0];
        }

        public DataTable GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            int PageLowerBound = 0, PageUpperBount = 0;
            PageLowerBound = (PageIndex - 1) * PageSize;
            PageUpperBount = PageLowerBound + PageSize;

            string sqlCount = "select count(0) from gsproduct where 1=1 " + Condition;
            string sqlData = @" select * from 
                                (
                                    select row_number() over(order by productid desc) as id,* from gsproduct where 1=1 "+Condition+@"
                                ) as sp
                                where sp.id>" + PageLowerBound + " and sp.id<=" + PageUpperBount;

            RecordCount = Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text,sqlCount));
            return dbr.ExecuteDataSet(CommandType.Text, sqlData).Tables[0];
        }

        public List<GroupProductModel> GetIList()
        {
            List<GroupProductModel> List = new List<GroupProductModel>();

            foreach (DataRow row in GetList().Rows)
            {
                List.Add(GetModel(row));
            }

            return List;
        }

        public void SetRecommend(int ProductID, bool IsRecommend)
        {
            DbCommand Command = dbw.GetSqlStringCommand("update [gsproduct] set [isrecommend] = @isrecommend");

            dbw.AddInParameter(Command, "@isrecommend", DbType.Boolean, IsRecommend);

            dbw.ExecuteNonQuery(Command);
        }

        public void Freeze(int ProductID,int Status)
        {
            DbCommand Command = dbw.GetSqlStringCommand("update [gsproduct] set [status] = @status");

            dbw.AddInParameter(Command, "@status", DbType.Int16, Status);

            dbw.ExecuteNonQuery(Command);
        }

        private GroupProductModel GetModel(DataRow row)
        {
            GroupProductModel model = new GroupProductModel();

            model.ProductID = Convert.ToInt32(row["ProductID"]);
            model.ProductName = Convert.ToString(row["ProductName"]);
            model.ProductCode = Convert.ToString(row["ProductCode"]);
            model.Description = Convert.ToString(row["Description"]);
            model.Detail = Convert.ToString(row["Detail"]);
            model.PrePaidPrice = Convert.ToDecimal(row["PrePaidPrice"]);
            model.GroupPrice = Convert.ToDecimal(row["GroupPrice"]);
            model.InsertTime = Convert.ToDateTime(row["InsertTime"]);
            model.ChangeTime = Convert.ToDateTime(row["ChangeTime"]);
            model.SmallImage = Convert.ToString(row["SmallImage"]);
            model.MediumImage = Convert.ToString(row["MediumImage"]);
            model.LargeImage = Convert.ToString(row["LargeImage"]);
            model.ProductType = Convert.ToInt16(row["ProductType"]);
            model.Status = Convert.ToInt16(row["Status"]);
            model.MarketPrice = Convert.ToDecimal(row["MarketPrice"]);
            model.SuccedLine = Convert.ToInt32(row["SuccedLine"]);
            model.IsRecommend = Convert.ToBoolean(row["IsRecommend"]);

            return model;
        }
    }
}
