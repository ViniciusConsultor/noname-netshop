using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.MagicWorld.Model;
using System.Data.Common;
using System.Data;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace NoName.NetShop.MagicWorld.DAL
{
    public class PawnProductDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public PawnProductDal()
		{}

        public void Add(PawnProductModel model)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_mwPawnProduct_Insert");
            
            dbw.AddInParameter(command, "@pawnproductid", DbType.Int32, model.PawnProductID);
            dbw.AddInParameter(command, "@pawnproductname", DbType.String, model.PawnProductName);
            dbw.AddInParameter(command, "@pawnprice", DbType.Decimal, model.PawnPrice);
            dbw.AddInParameter(command, "@sellingprice", DbType.Decimal, model.SellingPrice);
            dbw.AddInParameter(command, "@cateid", DbType.Int32, model.CateID);
            dbw.AddInParameter(command, "@catepath", DbType.String, model.CatePath);
            dbw.AddInParameter(command, "@stock", DbType.Int32, model.Stock);
            dbw.AddInParameter(command, "@smallimage", DbType.String, model.SmallImage);
            dbw.AddInParameter(command, "@mediumimage", DbType.String, model.MediumImage);
            dbw.AddInParameter(command, "@brief", DbType.String, model.Brief);
            dbw.AddInParameter(command, "@inserttime", DbType.DateTime, model.InsertTime);
            dbw.AddInParameter(command, "@changetime", DbType.DateTime, model.ChangeTime);
            dbw.AddInParameter(command, "@status", DbType.Int32, model.Status);
            dbw.AddInParameter(command, "@sortvalue", DbType.Int32, model.SortValue);
            dbw.AddInParameter(command, "@userid", DbType.String, model.UserID);
            dbw.AddInParameter(command, "@deadtime", DbType.DateTime, model.DeadTime);
            dbw.AddInParameter(command, "@truename", DbType.String, model.TrueName);
            dbw.AddInParameter(command, "@phone", DbType.String, model.Phone);
            dbw.AddInParameter(command, "@cellphone", DbType.String, model.CellPhone);
            dbw.AddInParameter(command, "@postcode", DbType.String, model.PostCode);
            dbw.AddInParameter(command, "@region", DbType.String, model.Region);
            dbw.AddInParameter(command, "@address", DbType.String, model.Address);

            dbw.ExecuteNonQuery(command);
        }

        public void Delete(int PawnProductID)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_mwPawnProduct_Delete");

            dbw.AddInParameter(command,"@pawnproductid",DbType.Int32,PawnProductID);

            dbw.ExecuteNonQuery(command);
        }

        public void Update(PawnProductModel model)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_mwPawnProduct_Update");

            dbw.AddInParameter(command, "@pawnproductid", DbType.Int32, model.PawnProductID);
            dbw.AddInParameter(command, "@pawnproductname", DbType.String, model.PawnProductName);
            dbw.AddInParameter(command, "@pawnprice", DbType.Decimal, model.PawnPrice);
            dbw.AddInParameter(command, "@sellingprice", DbType.Decimal, model.SellingPrice);
            dbw.AddInParameter(command, "@cateid", DbType.Int32, model.CateID);
            dbw.AddInParameter(command, "@catepath", DbType.String, model.CatePath);
            dbw.AddInParameter(command, "@stock", DbType.Int32, model.Stock);
            dbw.AddInParameter(command, "@smallimage", DbType.String, model.SmallImage);
            dbw.AddInParameter(command, "@mediumimage", DbType.String, model.MediumImage);
            dbw.AddInParameter(command, "@brief", DbType.String, model.Brief);
            dbw.AddInParameter(command, "@inserttime", DbType.DateTime, model.InsertTime);
            dbw.AddInParameter(command, "@changetime", DbType.DateTime, model.ChangeTime);
            dbw.AddInParameter(command, "@status", DbType.Int32, model.Status);
            dbw.AddInParameter(command, "@sortvalue", DbType.Int32, model.SortValue);
            dbw.AddInParameter(command, "@userid", DbType.String, model.UserID);
            dbw.AddInParameter(command, "@deadtime", DbType.DateTime, model.DeadTime);
            dbw.AddInParameter(command, "@truename", DbType.String, model.TrueName);
            dbw.AddInParameter(command, "@phone", DbType.String, model.Phone);
            dbw.AddInParameter(command, "@cellphone", DbType.String, model.CellPhone);
            dbw.AddInParameter(command, "@postcode", DbType.String, model.PostCode);
            dbw.AddInParameter(command, "@region", DbType.String, model.Region);
            dbw.AddInParameter(command, "@address", DbType.String, model.Address);

            dbw.ExecuteNonQuery(command);
        }

        public void ChangeStatus(int PawnProductID, int Status)
        {
            DbCommand command = dbw.GetStoredProcCommand("UP_mwPawnProduct_ChangeStatus");

            dbw.AddInParameter(command, "@pawnproductid", DbType.Int32, PawnProductID);
            dbw.AddInParameter(command, "@status", DbType.Int16, Status);
            dbw.AddInParameter(command, "@changetime", DbType.DateTime, DateTime.Now);

            dbw.ExecuteNonQuery(command);
        }

        public PawnProductModel GetModel(int PawnProductID)
        {
            DbCommand command = dbr.GetStoredProcCommand("UP_mwPawnProduct_Get");
            dbr.AddInParameter(command,"@pawnproductid",DbType.Int32,PawnProductID);
            DataTable dt = dbr.ExecuteDataSet(command).Tables[0];
            PawnProductModel model = null;
            if (dt != null && dt.Rows!=null && dt.Rows.Count>0)
            {
                model = BindModel(dt.Rows[0]); 
            }
            return model;
        }

        public DataTable GetNewestList(int TopCount,PawnProductStatus Status)
        {
            string sql = "select top {0} * from mwpawnproduct where status={1} order by pawnproductid desc";
            sql = String.Format(sql,TopCount,(int)Status);
            return dbr.ExecuteDataSet(CommandType.Text,sql).Tables[0];
        }


        private PawnProductModel BindModel(DataRow row)
        {
            PawnProductModel model = new PawnProductModel()
            {
                Address = Convert.ToString(row["address"]),
                Brief = Convert.ToString(row["brief"]),
                CateID = Convert.ToInt32(row["cateid"]),
                CatePath = Convert.ToString(row["catepath"]),
                CellPhone = Convert.ToString(row["cellphone"]),
                ChangeTime = Convert.ToDateTime(row["changetime"]),
                DeadTime = Convert.ToDateTime(row["deadtime"]),
                InsertTime = Convert.ToDateTime(row["inserttime"]),
                MediumImage = Convert.ToString(row["mediumimage"]),
                PawnPrice = Convert.ToDecimal(row["pawnprice"]),
                PawnProductID = Convert.ToInt32(row["pawnproductid"]),
                PawnProductName = Convert.ToString(row["pawnproductname"]),
                Phone = Convert.ToString(row["phone"]),
                PostCode = Convert.ToString(row["postcode"]),
                Region = Convert.ToString(row["region"]),
                SellingPrice = Convert.ToInt32(row["sellingprice"]),
                SmallImage = Convert.ToString(row["smallimage"]),
                SortValue = Convert.ToInt32(row["sortvalue"]),
                Status = Convert.ToInt16(row["status"]),
                Stock = Convert.ToInt32(row["stock"]),
                TrueName = Convert.ToString(row["truename"]),
                UserID = Convert.ToString(row["userid"])
            };

            return model;
        }
    }
}
