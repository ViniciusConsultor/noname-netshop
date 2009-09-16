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
	/// 数据访问类QuestionModelDal。
	/// </summary>
	public class QuestionModelDal
	{
		public QuestionModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(QuestionId)+1 from qaQuestion";
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
		public bool Exists(int QuestionId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaQuestion_Exists");
			db.AddInParameter(dbCommand, "QuestionId", DbType.Int32,QuestionId);
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
		public void Add(NoName.NetShop.Model.QuestionModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaQuestion_ADD");
			db.AddInParameter(dbCommand, "QuestionId", DbType.Int32, model.QuestionId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "ContentType", DbType.Byte, model.ContentType);
			db.AddInParameter(dbCommand, "ContentId", DbType.AnsiString, model.ContentId);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "LastAnswerTime", DbType.DateTime, model.LastAnswerTime);
			db.AddInParameter(dbCommand, "LastAnswerId", DbType.AnsiString, model.LastAnswerId);
			db.AddInParameter(dbCommand, "AnswerNum", DbType.Int32, model.AnswerNum);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.QuestionModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaQuestion_Update");
			db.AddInParameter(dbCommand, "QuestionId", DbType.Int32, model.QuestionId);
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "ContentType", DbType.Byte, model.ContentType);
			db.AddInParameter(dbCommand, "ContentId", DbType.AnsiString, model.ContentId);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "LastAnswerTime", DbType.DateTime, model.LastAnswerTime);
			db.AddInParameter(dbCommand, "LastAnswerId", DbType.AnsiString, model.LastAnswerId);
			db.AddInParameter(dbCommand, "AnswerNum", DbType.Int32, model.AnswerNum);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int QuestionId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaQuestion_Delete");
			db.AddInParameter(dbCommand, "QuestionId", DbType.Int32,QuestionId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.QuestionModel GetModel(int QuestionId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaQuestion_GetModel");
			db.AddInParameter(dbCommand, "QuestionId", DbType.Int32,QuestionId);

			NoName.NetShop.Model.QuestionModel model=null;
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
			strSql.Append("select QuestionId,UserId,ContentType,ContentId,Title,Content,Brief,InsertTime,LastAnswerTime,LastAnswerId,AnswerNum ");
			strSql.Append(" FROM qaQuestion ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "qaQuestion");
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
		public List<NoName.NetShop.Model.QuestionModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select QuestionId,UserId,ContentType,ContentId,Title,Content,Brief,InsertTime,LastAnswerTime,LastAnswerId,AnswerNum ");
			strSql.Append(" FROM qaQuestion ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.QuestionModel> list = new List<NoName.NetShop.Model.QuestionModel>();
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
		public NoName.NetShop.Model.QuestionModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.QuestionModel model=new NoName.NetShop.Model.QuestionModel();
			object ojb; 
			ojb = dataReader["QuestionId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.QuestionId=(int)ojb;
			}
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			ojb = dataReader["ContentType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ContentType=(int)ojb;
			}
			model.ContentId=dataReader["ContentId"].ToString();
			model.Title=dataReader["Title"].ToString();
			model.Content=dataReader["Content"].ToString();
			model.Brief=dataReader["Brief"].ToString();
			ojb = dataReader["InsertTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.InsertTime=(DateTime)ojb;
			}
			ojb = dataReader["LastAnswerTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LastAnswerTime=(DateTime)ojb;
			}
			model.LastAnswerId=dataReader["LastAnswerId"].ToString();
			ojb = dataReader["AnswerNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AnswerNum=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

