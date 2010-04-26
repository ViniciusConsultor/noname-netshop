using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Common;

namespace NoName.NetShop.Product.DAL
{
	/// <summary>
	/// 数据访问类SalesProductModelDal。
	/// </summary>
	public class SalesProductModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public SalesProductModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ProductId)+1 from pdSalesProduct";
			
			object obj = dbr.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProductId,int SaleType,int SiteId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdSalesProduct_Exists");
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbr.AddInParameter(dbCommand, "SaleType", DbType.Byte,SaleType);
			dbr.AddInParameter(dbCommand, "SiteId", DbType.Int32,SiteId);
			int result;
			object obj = dbr.ExecuteScalar(dbCommand);
			int.TryParse(obj.ToString(),out result);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(SalesProductModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSalesProduct_ADD");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "SaleType", DbType.Byte, model.SaleType);
			dbw.AddInParameter(dbCommand, "SiteId", DbType.Int32, model.SiteId);
            dbw.AddInParameter(dbCommand, "timestamp", DbType.DateTime, model.TimeStamp);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(SalesProductModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSalesProduct_Update");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "SaleType", DbType.Byte, model.SaleType);
			dbw.AddInParameter(dbCommand, "SiteId", DbType.Int32, model.SiteId);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductId,int SaleType,int SiteId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSalesProduct_Delete");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbw.AddInParameter(dbCommand, "SaleType", DbType.Byte,SaleType);
			dbw.AddInParameter(dbCommand, "SiteId", DbType.Int32,SiteId);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SalesProductModel GetModel(int ProductId,int SaleType,int SiteId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdSalesProduct_GetModel");
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbr.AddInParameter(dbCommand, "SaleType", DbType.Byte,SaleType);
			dbr.AddInParameter(dbCommand, "SiteId", DbType.Int32,SiteId);

			SalesProductModel model=null;
			using (IDataReader dataReader = dbr.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProductId,SaleType,SiteId,timestamp ");
			strSql.Append(" FROM pdSalesProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			return dbr.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_GetRecordByPage");
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdSalesProduct");
			dbr.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			dbr.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			dbr.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			dbr.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return dbr.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<SalesProductModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProductId,SaleType,SiteId,timestamp ");
			strSql.Append(" FROM pdSalesProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<SalesProductModel> list = new List<SalesProductModel>();
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


        public DataTable GetProductList(int PageSize, int PageIndex, SalesProductType SalesType, out int RecordCount)
        {
            int PageLowerBound = 0, PageUpperBount = 0;
            PageLowerBound = (PageIndex - 1) * PageSize;
            PageUpperBount = PageLowerBound + PageSize;

            string sqlCount = "select count(0) from pdproduct p inner join pdsalesproduct sp on sp.productid = p.productid where saletype={0}";
            string sqlData = @" select * from 
                                (
	                                select row_number() over(order by p.productid desc) as nid,p.*,sp.saletype from pdproduct p 
	                                inner join pdsalesproduct sp on sp.productid = p.productid
	                                where saletype={0}
                                ) as h
                                where nid>{1} and nid<={2}";

            RecordCount = Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text, String.Format(sqlCount, (int)SalesType)));
            return dbr.ExecuteDataSet(CommandType.Text, String.Format(sqlData, (int)SalesType, PageLowerBound, PageUpperBount)).Tables[0];
        }

        public DataSet GetListForShoppingProcedure()
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_pdSalesProduct_GetForSP");
            return dbr.ExecuteDataSet(Command);
        }


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public SalesProductModel ReaderBind(IDataReader dataReader)
		{
			SalesProductModel model=new SalesProductModel();
			object ojb; 
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["SaleType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SaleType=(int)ojb;
			}
			ojb = dataReader["SiteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SiteId=(int)ojb;
            }
            ojb = dataReader["timestamp"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TimeStamp = Convert.ToDateTime(ojb);
            }
			return model;
		}

		#endregion  成员方法
	}
}

