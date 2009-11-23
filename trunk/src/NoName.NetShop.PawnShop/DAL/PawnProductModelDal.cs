using System;
using System.Collections.Generic;
using System.Text;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.PawnShop.Model;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.PawnShop.DAL
{
    public class PawnProductModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public PawnProductModelDal()
		{}

        public void Add(PawnProductModel model)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_pwPawnProduct_Insert");
            
            dbw.AddInParameter(command,"@pawnproductid",DbType.Int32,model.PawnProductID);
            dbw.AddInParameter(command,"@pawnproductname",DbType.String,model.PawnProductName);
            dbw.AddInParameter(command,"@userid",DbType.Int32,model.UserID);
            dbw.AddInParameter(command,"@pawnprice",DbType.Decimal,model.PawnPrice);
            dbw.AddInParameter(command,"@cateid",DbType.Int32,model.CateID);
            dbw.AddInParameter(command,"@catepath",DbType.String,model.CatePath);
            dbw.AddInParameter(command,"@stock",DbType.Int32,model.Stock);
            dbw.AddInParameter(command,"@smallimage",DbType.String,model.SmallImage);
            dbw.AddInParameter(command,"@mediumimage",DbType.String,model.MediumImage);
            dbw.AddInParameter(command,"@largeimage",DbType.String,model.LargeImage);
            dbw.AddInParameter(command,"@keywords",DbType.String,model.Keywords);
            dbw.AddInParameter(command,"@brief",DbType.String,model.Brief);
            dbw.AddInParameter(command,"@inserttime",DbType.DateTime,model.InsertTime);
            dbw.AddInParameter(command,"@changetime",DbType.DateTime,model.ChangeTime);
            dbw.AddInParameter(command,"@status",DbType.Int32,model.Status);
            dbw.AddInParameter(command,"@sortvalue",DbType.Int32,model.SortValue);

            dbw.ExecuteNonQuery(command);
        }

        public void Delete(int PawnProductID)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_pwPawnProduct_Delete");

            dbw.AddInParameter(command,"@pawnproductid",DbType.Int32,PawnProductID);

            dbw.ExecuteNonQuery(command);
        }

        public void Update(PawnProductModel model)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_pwPawnProduct_Update");

            dbw.AddInParameter(command, "@pawnproductid", DbType.Int32, model.PawnProductID);
            dbw.AddInParameter(command, "@pawnproductname", DbType.String, model.PawnProductName);
            dbw.AddInParameter(command, "@userid", DbType.Int32, model.UserID);
            dbw.AddInParameter(command, "@pawnprice", DbType.Decimal, model.PawnPrice);
            dbw.AddInParameter(command, "@cateid", DbType.Int32, model.CateID);
            dbw.AddInParameter(command, "@catepath", DbType.String, model.CatePath);
            dbw.AddInParameter(command, "@stock", DbType.Int32, model.Stock);
            dbw.AddInParameter(command, "@smallimage", DbType.String, model.SmallImage);
            dbw.AddInParameter(command, "@mediumimage", DbType.String, model.MediumImage);
            dbw.AddInParameter(command, "@largeimage", DbType.String, model.LargeImage);
            dbw.AddInParameter(command, "@keywords", DbType.String, model.Keywords);
            dbw.AddInParameter(command, "@brief", DbType.String, model.Brief);
            dbw.AddInParameter(command, "@inserttime", DbType.DateTime, model.InsertTime);
            dbw.AddInParameter(command, "@changetime", DbType.DateTime, model.ChangeTime);
            dbw.AddInParameter(command, "@status", DbType.Int32, model.Status);
            dbw.AddInParameter(command, "@sortvalue", DbType.Int32, model.SortValue);

            dbw.ExecuteNonQuery(command);
        }

        public void ChangeStatus(int PawnProductID, int Status)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_pwPawnProduct_ChangeStatus");

            dbw.AddInParameter(command, "@pawnproductid", DbType.Int32, PawnProductID);
            dbw.AddInParameter(command, "@status", DbType.Int16, Status);
            dbw.AddInParameter(command, "@changetime", DbType.DateTime, DateTime.Now);

            dbw.ExecuteNonQuery(command);
        }

        public PawnProductModel GetModel(int PawnProductID)
        {
            DbCommand command = dbr.GetStoredProcCommand("UP_pwPawnProduct_Get");
            dbr.AddInParameter(command,"@pawnproductid",DbType.Int32,PawnProductID);
            DataTable dt = dbr.ExecuteDataSet(command).Tables[0];
            PawnProductModel model = null;
            if (dt != null && dt.Rows!=null && dt.Rows.Count>0)
            {
                model = BindModel(dt.Rows[0]); 
            }
            return model;
        }




        private PawnProductModel BindModel(DataRow row)
        {
            PawnProductModel model = new PawnProductModel();

            model.Brief = Convert.ToString(row["brief"]);
            model.CateID = Convert.ToInt32(row["cateid"]);
            model.CatePath = Convert.ToString(row["catepath"]);
            model.ChangeTime = Convert.ToDateTime(row["changetime"]);
            model.InsertTime = Convert.ToDateTime(row["inserttime"]);
            model.Keywords = Convert.ToString(row["keywords"]);
            model.LargeImage = Convert.ToString(row["largeimage"]);
            model.MediumImage = Convert.ToString(row["mediumimage"]);
            model.PawnPrice = Convert.ToInt32(row["pawnprice"]);
            model.PawnProductID = Convert.ToInt32(row["pawnproductid"]);
            model.PawnProductName = Convert.ToString(row["pawnproductname"]);
            model.SmallImage = Convert.ToString(row["smallimage"]);
            model.SortValue = Convert.ToInt32(row["sortvalue"]);
            model.Status = Convert.ToInt16(row["status"]);
            model.Stock = Convert.ToInt32(row["stock"]);
            model.UserID = Convert.ToInt32(row["userid"]);

            return model;
        }

    }
}
