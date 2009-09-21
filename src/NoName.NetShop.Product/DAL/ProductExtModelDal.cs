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
	/// 数据访问类ProductExtModelDal。
	/// </summary>
	public class ProductExtModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public ProductExtModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ProductId)+1 from pdProductExt";
			
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
		public bool Exists(int ProductId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdProductExt_Exists");
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
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
		public void Add(ProductExtModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProductExt_ADD");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "ProductDesc", DbType.String, model.ProductDesc);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(ProductExtModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProductExt_Update");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "ProductDesc", DbType.String, model.ProductDesc);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProductExt_Delete");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ProductExtModel GetModel(int ProductId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdProductExt_GetModel");
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);

			ProductExtModel model=null;
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
			strSql.Append("select ProductId,ProductDesc ");
			strSql.Append(" FROM pdProductExt ");
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
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdProductExt");
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
		public List<ProductExtModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProductId,ProductDesc ");
			strSql.Append(" FROM pdProductExt ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<ProductExtModel> list = new List<ProductExtModel>();
			
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
		public ProductExtModel ReaderBind(IDataReader dataReader)
		{
			ProductExtModel model=new ProductExtModel();
			object ojb; 
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			model.ProductDesc=dataReader["ProductDesc"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

