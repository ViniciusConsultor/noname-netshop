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
	/// 数据访问类AnswerModelDal。
	/// </summary>
	public class AnswerModelDal
	{
		public AnswerModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(AnswerId)+1 from qaAnswer";
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
		public bool Exists(int AnswerId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaAnswer_Exists");
			db.AddInParameter(dbCommand, "AnswerId", DbType.Int32,AnswerId);
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
		public void Add(NoName.NetShop.Model.AnswerModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaAnswer_ADD");
			db.AddInParameter(dbCommand, "QuestionId", DbType.Int32, model.QuestionId);
			db.AddInParameter(dbCommand, "AnswerId", DbType.Int32, model.AnswerId);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "Content", DbType.String, model.Content);
			db.AddInParameter(dbCommand, "AnswerTime", DbType.DateTime, model.AnswerTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.AnswerModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaAnswer_Update");
			db.AddInParameter(dbCommand, "QuestionId", DbType.Int32, model.QuestionId);
			db.AddInParameter(dbCommand, "AnswerId", DbType.Int32, model.AnswerId);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "Content", DbType.String, model.Content);
			db.AddInParameter(dbCommand, "AnswerTime", DbType.DateTime, model.AnswerTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AnswerId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaAnswer_Delete");
			db.AddInParameter(dbCommand, "AnswerId", DbType.Int32,AnswerId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.AnswerModel GetModel(int AnswerId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaAnswer_GetModel");
			db.AddInParameter(dbCommand, "AnswerId", DbType.Int32,AnswerId);

			NoName.NetShop.Model.AnswerModel model=null;
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
			strSql.Append("select QuestionId,AnswerId,Title,Brief,Content,AnswerTime ");
			strSql.Append(" FROM qaAnswer ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "qaAnswer");
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
		public List<NoName.NetShop.Model.AnswerModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select QuestionId,AnswerId,Title,Brief,Content,AnswerTime ");
			strSql.Append(" FROM qaAnswer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.AnswerModel> list = new List<NoName.NetShop.Model.AnswerModel>();
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
		public NoName.NetShop.Model.AnswerModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.AnswerModel model=new NoName.NetShop.Model.AnswerModel();
			object ojb; 
			ojb = dataReader["QuestionId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.QuestionId=(int)ojb;
			}
			ojb = dataReader["AnswerId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AnswerId=(int)ojb;
			}
			model.Title=dataReader["Title"].ToString();
			model.Brief=dataReader["Brief"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["AnswerTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AnswerTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

