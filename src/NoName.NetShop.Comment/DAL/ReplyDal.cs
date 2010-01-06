using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.Comment
{
	/// <summary>
	/// 数据访问类AnswerDal。
	/// </summary>
	public class ReplyDal
	{
        public ReplyDal()
		{}
		#region  成员方法
		/// <summary>
		///  增加一条数据
		/// </summary>
        public void Add(NoName.NetShop.Comment.ReplyModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaReply_ADD");
			db.AddInParameter(dbCommand, "TopicId", DbType.Int32, model.TopicId);
			db.AddInParameter(dbCommand, "ReplyId", DbType.Int32, model.ReplyId);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.AddInParameter(dbCommand, "Content", DbType.String, model.Content);
            db.AddInParameter(dbCommand, "UserId", DbType.String, model.UserId);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AnswerId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaReply_Delete");
			db.AddInParameter(dbCommand, "ReplyId", DbType.Int32,AnswerId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public NoName.NetShop.Comment.ReplyModel GetModel(int AnswerId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_qaReply_GetModel");
			db.AddInParameter(dbCommand, "ReplyId", DbType.Int32,AnswerId);

			NoName.NetShop.Comment.ReplyModel model=null;
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
        public List<NoName.NetShop.Comment.ReplyModel> GetListArray(int topicId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ReplyId,TopicId,Title,Content,ReplyTime,UserId ");
			strSql.Append(" FROM qaReply where replyId=" + topicId);

            List<NoName.NetShop.Comment.ReplyModel> list = new List<NoName.NetShop.Comment.ReplyModel>();
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
        public NoName.NetShop.Comment.ReplyModel ReaderBind(IDataReader dataReader)
		{
            NoName.NetShop.Comment.ReplyModel model = new NoName.NetShop.Comment.ReplyModel();
			object ojb; 
			ojb = dataReader["topicid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TopicId=(int)ojb;
			}
			ojb = dataReader["ReplyId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ReplyId=(int)ojb;
			}
			model.Title=dataReader["Title"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["ReplyTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.ReplyTime = (DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}}
