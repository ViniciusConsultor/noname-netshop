using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 数据访问类Product。
	/// </summary>
	public class SSProductDal
	{
		public SSProductDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(SuiteId)+1 from slProduct";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SuiteId,int ProductId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slProduct_Exists");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
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
		public void Add(NoName.NetShop.Solution.SSProductModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slProduct_ADD");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32, model.SuiteId);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			db.AddInParameter(dbCommand, "Price", DbType.Decimal, model.Price);
			db.AddInParameter(dbCommand, "Quantity", DbType.Int32, model.Quantity);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Solution.SSProductModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slProduct_Update");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32, model.SuiteId);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			db.AddInParameter(dbCommand, "Price", DbType.Decimal, model.Price);
			db.AddInParameter(dbCommand, "Quantity", DbType.Int32, model.Quantity);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SuiteId,int ProductId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slProduct_Delete");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SSProductModel GetModel(int SuiteId,int ProductId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slProduct_GetModel");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);

			NoName.NetShop.Solution.SSProductModel model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
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
			strSql.Append("select SuiteId,ProductId,Price,Quantity ");
			strSql.Append(" FROM slProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "slProduct");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<NoName.NetShop.Solution.SSProductModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SuiteId,ProductId,Price,Quantity ");
			strSql.Append(" FROM slProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Solution.SSProductModel> list = new List<NoName.NetShop.Solution.SSProductModel>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
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
		public NoName.NetShop.Solution.SSProductModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Solution.SSProductModel model=new NoName.NetShop.Solution.SSProductModel();
			object ojb; 
			ojb = dataReader["SuiteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SuiteId=(int)ojb;
			}
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			ojb = dataReader["Quantity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Quantity=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

