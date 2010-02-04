using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Product.Model;
using System.Data;
using System.Data.Common;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace NoName.NetShop.Product.DAL
{
    public class BrandCategoryRelationDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Add(BrandCategoryRelationModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_pdBrandCategoryRelation_Add");

            dbw.AddInParameter(Command, "@brandid", DbType.Int32, model.BrandID);
            dbw.AddInParameter(Command, "@cateid", DbType.Int32, model.CategoryID);
            dbw.AddInParameter(Command, "@catepath", DbType.String, model.CategoryPath);

            dbw.ExecuteNonQuery(Command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BrandID"></param>
        /// <param name="CategoryID"></param>
        public void Delete(int BrandID,int CategoryID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_pdBrandCategoryRelation_Delete");

            dbw.AddInParameter(Command, "@brandid", DbType.Int32, BrandID);
            dbw.AddInParameter(Command, "@cateid", DbType.Int32, CategoryID);

            dbw.ExecuteNonQuery(Command);
        }


        public void Delete(int CategoryID)
        {
            string sql = "delete from pdbrandcategoryrelation where cateid="+CategoryID;
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public DataTable GetCategoryBrandList(int CategoryID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_pdBrandCategoryRelation_GetCategoryBrandList");

            dbr.AddInParameter(Command, "@cateid", DbType.Int32, CategoryID);

            return dbr.ExecuteDataSet(Command).Tables[0];
        }
    }
}
