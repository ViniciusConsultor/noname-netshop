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
	/// 数据访问类Suite。
	/// </summary>
	public class SuiteDal
	{
		public SuiteDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(SuiteId)+1 from slSuite";
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
		public bool Exists(int SuiteId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSuite_Exists");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);
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
		public void Add(NoName.NetShop.Solution.SuiteModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSuite_ADD");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32, model.SuiteId);
			db.AddInParameter(dbCommand, "ScenceId", DbType.Int32, model.ScenceId);
			db.AddInParameter(dbCommand, "SuiteName", DbType.AnsiString, model.SuiteName);
			db.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			db.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			db.AddInParameter(dbCommand, "Price", DbType.Decimal, model.Price);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "Score", DbType.Int32, model.Score);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Solution.SuiteModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSuite_Update");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32, model.SuiteId);
			db.AddInParameter(dbCommand, "ScenceId", DbType.Int32, model.ScenceId);
			db.AddInParameter(dbCommand, "SuiteName", DbType.AnsiString, model.SuiteName);
			db.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			db.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			db.AddInParameter(dbCommand, "Price", DbType.Decimal, model.Price);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "Score", DbType.Int32, model.Score);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SuiteId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSuite_Delete");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SuiteModel GetModel(int SuiteId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSuite_GetModel");
			db.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);

			NoName.NetShop.Solution.SuiteModel model=null;
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
			strSql.Append("select SuiteId,ScenceId,SuiteName,SmallImage,MediumImage,Price,Remark,Score ");
			strSql.Append(" FROM slSuite ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "slSuite");
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
		public List<NoName.NetShop.Solution.SuiteModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SuiteId,ScenceId,SuiteName,SmallImage,MediumImage,Price,Remark,Score ");
			strSql.Append(" FROM slSuite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Solution.SuiteModel> list = new List<NoName.NetShop.Solution.SuiteModel>();
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
		public NoName.NetShop.Solution.SuiteModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Solution.SuiteModel model=new NoName.NetShop.Solution.SuiteModel();
			object ojb; 
			ojb = dataReader["SuiteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SuiteId=(int)ojb;
			}
			ojb = dataReader["ScenceId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ScenceId=(int)ojb;
			}
			model.SuiteName=dataReader["SuiteName"].ToString();
			model.SmallImage=dataReader["SmallImage"].ToString();
			model.MediumImage=dataReader["MediumImage"].ToString();
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Score"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Score=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

