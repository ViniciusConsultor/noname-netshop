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
	/// 数据访问类SuitProductModelDal。
	/// </summary>
	public class SuitProductModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public SuitProductModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(SuitProductId)+1 from pdSuitProduct";
			
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
		public bool Exists(int SuitProductId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdSuitProduct_Exists");
			dbr.AddInParameter(dbCommand, "SuitProductId", DbType.Int32,SuitProductId);
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
		public void Add(SuitProductModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSuitProduct_ADD");
			dbw.AddInParameter(dbCommand, "SuitProductId", DbType.Int32, model.SuitProductId);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "SuitName", DbType.AnsiString, model.SuitName);
			dbw.AddInParameter(dbCommand, "MerchantPrice", DbType.Decimal, model.MerchantPrice);
			dbw.AddInParameter(dbCommand, "TradePrice", DbType.Decimal, model.TradePrice);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(SuitProductModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSuitProduct_Update");
			dbw.AddInParameter(dbCommand, "SuitProductId", DbType.Int32, model.SuitProductId);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "SuitName", DbType.AnsiString, model.SuitName);
			dbw.AddInParameter(dbCommand, "MerchantPrice", DbType.Decimal, model.MerchantPrice);
			dbw.AddInParameter(dbCommand, "TradePrice", DbType.Decimal, model.TradePrice);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SuitProductId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdSuitProduct_Delete");
			dbw.AddInParameter(dbCommand, "SuitProductId", DbType.Int32,SuitProductId);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SuitProductModel GetModel(int SuitProductId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdSuitProduct_GetModel");
			dbr.AddInParameter(dbCommand, "SuitProductId", DbType.Int32,SuitProductId);

			SuitProductModel model=null;
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
			strSql.Append("select SuitProductId,ProductId,SuitName,MerchantPrice,TradePrice,Status ");
			strSql.Append(" FROM pdSuitProduct ");
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
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdSuitProduct");
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
		public List<SuitProductModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SuitProductId,ProductId,SuitName,MerchantPrice,TradePrice,Status ");
			strSql.Append(" FROM pdSuitProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<SuitProductModel> list = new List<SuitProductModel>();
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public SuitProductModel ReaderBind(IDataReader dataReader)
		{
			SuitProductModel model=new SuitProductModel();
			object ojb; 
			ojb = dataReader["SuitProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SuitProductId=(int)ojb;
			}
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			model.SuitName=dataReader["SuitName"].ToString();
			ojb = dataReader["MerchantPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MerchantPrice=(decimal)ojb;
			}
			ojb = dataReader["TradePrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TradePrice=(decimal)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

