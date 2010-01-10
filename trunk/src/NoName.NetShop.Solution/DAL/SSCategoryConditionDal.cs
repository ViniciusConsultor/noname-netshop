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
		///  增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Solution.SSCategoryConditionModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slCategoryCondition_Save");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "SenceId", DbType.Int32, model.SenceId);
			db.AddInParameter(dbCommand, "RuleName", DbType.AnsiString, model.RuleName);
			db.AddInParameter(dbCommand, "RuleValue", DbType.AnsiString, model.RuleValue);
			db.ExecuteNonQuery(dbCommand);
		}

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

