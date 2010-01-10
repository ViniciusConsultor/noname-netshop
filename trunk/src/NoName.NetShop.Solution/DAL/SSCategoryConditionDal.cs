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
	/// 数据访问类CategoryCondition。
	/// </summary>
	public class CategoryCondition
	{
		public CategoryCondition()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(CateId)+1 from slCategoryCondition";
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
		public bool Exists(int CateId,int SenceId,string RuleName)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slCategoryCondition_Exists");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);
			db.AddInParameter(dbCommand, "SenceId", DbType.Int32,SenceId);
			db.AddInParameter(dbCommand, "RuleName", DbType.AnsiString,RuleName);
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
		public void Add(NoName.NetShop.Solution.SSCategoryConditionModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slCategoryCondition_ADD");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "SenceId", DbType.Int32, model.SenceId);
			db.AddInParameter(dbCommand, "RuleName", DbType.AnsiString, model.RuleName);
			db.AddInParameter(dbCommand, "RuleValue", DbType.AnsiString, model.RuleValue);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Solution.SSCategoryConditionModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slCategoryCondition_Update");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "SenceId", DbType.Int32, model.SenceId);
			db.AddInParameter(dbCommand, "RuleName", DbType.AnsiString, model.RuleName);
			db.AddInParameter(dbCommand, "RuleValue", DbType.AnsiString, model.RuleValue);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CateId,int SenceId,string RuleName)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slCategoryCondition_Delete");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);
			db.AddInParameter(dbCommand, "SenceId", DbType.Int32,SenceId);
			db.AddInParameter(dbCommand, "RuleName", DbType.AnsiString,RuleName);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SSCategoryConditionModel GetModel(int CateId,int SenceId,string RuleName)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slCategoryCondition_GetModel");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);
			db.AddInParameter(dbCommand, "SenceId", DbType.Int32,SenceId);
			db.AddInParameter(dbCommand, "RuleName", DbType.AnsiString,RuleName);

			NoName.NetShop.Solution.SSCategoryConditionModel model=null;
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
			strSql.Append("select CateId,SenceId,RuleName,RuleValue ");
			strSql.Append(" FROM slCategoryCondition ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "slCategoryCondition");
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
		public List<NoName.NetShop.Solution.SSCategoryConditionModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CateId,SenceId,RuleName,RuleValue ");
			strSql.Append(" FROM slCategoryCondition ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Solution.SSCategoryConditionModel> list = new List<NoName.NetShop.Solution.SSCategoryConditionModel>();
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
		public NoName.NetShop.Solution.SSCategoryConditionModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Solution.SSCategoryConditionModel model=new NoName.NetShop.Solution.SSCategoryConditionModel();
			object ojb; 
			ojb = dataReader["CateId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateId=(int)ojb;
			}
			ojb = dataReader["SenceId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SenceId=(int)ojb;
			}
			model.RuleName=dataReader["RuleName"].ToString();
			model.RuleValue=dataReader["RuleValue"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

