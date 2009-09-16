using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using Maticsoft.DBUtility;//请先添加引用
namespace NoName.NetShop.DAL
{
	/// <summary>
	/// 数据访问类RuleModelDal。
	/// </summary>
	public class RuleModelDal
	{
		public RuleModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(SchemeId)+1 from ssRule";
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
		public bool Exists(int SchemeId,int CateId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_ssRule_Exists");
			db.AddInParameter(dbCommand, "SchemeId", DbType.Int32,SchemeId);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);
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
		public void Add(NoName.NetShop.Model.RuleModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_ssRule_ADD");
			db.AddInParameter(dbCommand, "SchemeId", DbType.Int32, model.SchemeId);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "Rule", DbType.AnsiString, model.Rule);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.RuleModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_ssRule_Update");
			db.AddInParameter(dbCommand, "SchemeId", DbType.Int32, model.SchemeId);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "Rule", DbType.AnsiString, model.Rule);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SchemeId,int CateId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_ssRule_Delete");
			db.AddInParameter(dbCommand, "SchemeId", DbType.Int32,SchemeId);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.RuleModel GetModel(int SchemeId,int CateId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_ssRule_GetModel");
			db.AddInParameter(dbCommand, "SchemeId", DbType.Int32,SchemeId);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);

			NoName.NetShop.Model.RuleModel model=null;
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
			strSql.Append("select SchemeId,CateId,Rule ");
			strSql.Append(" FROM ssRule ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "ssRule");
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
		public List<NoName.NetShop.Model.RuleModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SchemeId,CateId,Rule ");
			strSql.Append(" FROM ssRule ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.RuleModel> list = new List<NoName.NetShop.Model.RuleModel>();
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
		public NoName.NetShop.Model.RuleModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.RuleModel model=new NoName.NetShop.Model.RuleModel();
			object ojb; 
			ojb = dataReader["SchemeId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SchemeId=(int)ojb;
			}
			ojb = dataReader["CateId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateId=(int)ojb;
			}
			model.Rule=dataReader["Rule"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

