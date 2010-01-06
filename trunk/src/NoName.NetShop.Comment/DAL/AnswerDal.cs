using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using NoName.NetShop.Common;

namespace NoName.NetShop.Comment
{
	/// <summary>
	/// 数据访问类AnswerDal。
	/// </summary>
	public class AnswerDal
	{
		public AnswerDal()
		{}
		#region  成员方法
		/// <summary>
		///  增加一条数据
		/// </summary>
        public void Save(NoName.NetShop.Comment.AnswerModel model)
		{
            if (model.AnswerId == 0)
                model.AnswerId = NoName.NetShop.Common.CommDataHelper.GetNewSerialNum(AppType.Other);
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_qaAnswer_Save");
			db.AddInParameter(dbCommand, "QuestionId", DbType.Int32, model.QuestionId);
			db.AddInParameter(dbCommand, "AnswerId", DbType.Int32, model.AnswerId);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.AddInParameter(dbCommand, "Content", DbType.String, model.Content);
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
        public NoName.NetShop.Comment.AnswerModel GetModel(int AnswerId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaAnswer_GetModel");
			db.AddInParameter(dbCommand, "AnswerId", DbType.Int32,AnswerId);

			NoName.NetShop.Comment.AnswerModel model=null;
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
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
        public List<NoName.NetShop.Comment.AnswerModel> GetListArray(int questionId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select QuestionId,AnswerId,Title,Content,AnswerTime ");
            strSql.Append(" FROM qaAnswer where QuestionId=" + questionId);

            List<NoName.NetShop.Comment.AnswerModel> list = new List<NoName.NetShop.Comment.AnswerModel>();
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
        public NoName.NetShop.Comment.AnswerModel ReaderBind(IDataReader dataReader)
		{
            NoName.NetShop.Comment.AnswerModel model = new NoName.NetShop.Comment.AnswerModel();
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
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["AnswerTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AnswerTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}}
