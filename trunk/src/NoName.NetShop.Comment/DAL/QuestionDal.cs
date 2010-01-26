using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Common;
using System.Data;
using System.Data.Common;

namespace NoName.NetShop.Comment
{
    public class QuestionDal
    {
        		/// <summary>
		/// 增加一条数据
		/// </summary>
        public void Add(NoName.NetShop.Comment.QuestionModel model)
		{
            Database db = CommDataAccess.DbReader;
            if (model.QuestionId == 0)
                model.QuestionId = CommDataHelper.GetNewSerialNum(AppType.Other);
            DbCommand dbCommand = db.GetStoredProcCommand("UP_qaQuestion_ADD");
            db.AddInParameter(dbCommand, "QuestionId", DbType.Int32, model.QuestionId);
            db.AddInParameter(dbCommand, "UserId", DbType.AnsiString, model.UserId);
            db.AddInParameter(dbCommand, "ContentId", DbType.Int32, model.ContentId);
            db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
            db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
            db.AddInParameter(dbCommand, "@contentType", DbType.Int16, (int)model.ContentType);
           db.ExecuteNonQuery(dbCommand);

        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int QuestionId)
		{
            Database db = CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_qaQuestion_Delete");
            db.AddInParameter(dbCommand, "QuestionId", DbType.Int32, QuestionId);

            db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public NoName.NetShop.Comment.QuestionModel GetModel(int QuestionId)
		{
            Database db = CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_qaQuestion_GetModel");
            db.AddInParameter(dbCommand, "QuestionId", DbType.Int32, QuestionId);

            NoName.NetShop.Comment.QuestionModel model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
        public List<NoName.NetShop.Comment.QuestionModel> GetListArray(int top, string strWhere)
		{
            StringBuilder strSql = new StringBuilder();
            if (top > 0)
            {
                strSql.Append("select top " + top + " QuestionId,UserId,ContentId,Title,Content,Brief,InsertTime,LastAnswerTime,LastAnswerId,AnswerNum ");
            }
            else
            {
                strSql.Append("select QuestionId,UserId,ContentId,Title,Content,InsertTime,LastAnswerTime,LastAnswerId,AnswerNum ");
            }

            strSql.Append(" FROM qaQuestion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<NoName.NetShop.Comment.QuestionModel> list = new List<NoName.NetShop.Comment.QuestionModel>();
            Database db = CommDataAccess.DbReader;
            using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
		}

        public DataTable GetList(int PageIndex,int PageSize,int TargetID,ContentType contentType,out int RecordCount)
        {
            int PageLowerBound = PageSize * (PageIndex - 1);
            int PageUpperBound = PageLowerBound + PageSize;

            string sqlCount = @"select count(0) from [qaQuestion] where contentid=(0) and contenttype={1}";
            string sqlData = @"select * from 
                                (select row_number() over(order by QuestionId desc) as nid,* from [qaQuestion] where contentid=(0) and contenttype={1}) as sp
                               where nid>{2} and nid<={3} ";

            RecordCount = Convert.ToInt32(CommDataAccess.DbReader.ExecuteScalar(CommandType.Text,String.Format(sqlCount,TargetID,(int)contentType)));
            return CommDataAccess.DbReader.ExecuteDataSet(CommandType.Text, String.Format(sqlData, TargetID, (int)contentType, PageLowerBound, PageUpperBound)).Tables[0]; 
        }


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
        public NoName.NetShop.Comment.QuestionModel ReaderBind(IDataReader dataReader)
		{
            NoName.NetShop.Comment.QuestionModel model = new NoName.NetShop.Comment.QuestionModel();
			object ojb; 
			ojb = dataReader["QuestionId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.QuestionId=(int)ojb;
			}
			model.UserId=dataReader["UserId"].ToString();
			ojb = dataReader["ContentId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ContentId=(int)ojb;
			}
			model.Title=dataReader["Title"].ToString();
			model.Content=dataReader["Content"].ToString();
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
            ojb = dataReader["LastAnswerId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastAnswerId = (int)ojb;
            }
			ojb = dataReader["AnswerNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AnswerNum=(int)ojb;
			}
            ojb = dataReader["ContentType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ContentType = (ContentType)(Convert.ToInt32(ojb));
            }
            return model;
		}

    }
}
