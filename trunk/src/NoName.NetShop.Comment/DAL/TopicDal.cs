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
    public class TopicDal
    {
        		/// <summary>
		/// 增加一条数据
		/// </summary>
        public void Add(NoName.NetShop.Comment.TopicModel model)
		{
            Database db = CommDataAccess.DbReader;
            if (model.TopicId == 0)
                model.TopicId = NetShop.Common.CommDataHelper.GetNewSerialNum(AppType.Other);

            DbCommand dbCommand = db.GetStoredProcCommand("UP_qaTopic_ADD");
            db.AddInParameter(dbCommand, "@TopicId", DbType.Int32, model.TopicId);
            db.AddInParameter(dbCommand, "UserId", DbType.AnsiString, model.UserId);
            db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
            db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
            db.AddInParameter(dbCommand, "ContentId", DbType.Int32, model.ContentId);
            db.AddInParameter(dbCommand, "@contentType", DbType.Int16, (int)model.ContentType);
           db.ExecuteNonQuery(dbCommand);

        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int topicId)
		{
            Database db = CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_qaTopic_Delete");
            db.AddInParameter(dbCommand, "TopicId", DbType.Int32, topicId);
            db.ExecuteNonQuery(dbCommand);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public NoName.NetShop.Comment.TopicModel GetModel(int TopicId)
		{
            Database db = CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_qaTopic_GetModel");
            db.AddInParameter(dbCommand, "TopicId", DbType.Int32, TopicId);

            NoName.NetShop.Comment.TopicModel model = null;
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
        public List<NoName.NetShop.Comment.TopicModel> GetListArray(int top, string strWhere)
		{
            StringBuilder strSql = new StringBuilder();
            if (top > 0)
            {
                strSql.Append("select top " + top + " TopicId,UserId,ContentType,ContentId,Title,Content,InsertTime,LastReplyTime,LastReplyId,ReplyNum,Status ");
            }
            else
            {
                strSql.Append("select TopicId,UserId,ContentType,ContentId,Title,Content,InsertTime,LastReplyTime,LastReplyId,ReplyNum,Status ");
            }

            strSql.Append(" FROM qaTopic ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<NoName.NetShop.Comment.TopicModel> list = new List<NoName.NetShop.Comment.TopicModel>();
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

            string sqlCount = @"select count(0) from [qaTopic] where contentid={0} and contenttype={1}";
            string sqlData = @"select * from 
                                (select row_number() over(order by topicid desc) as nid,* from [qaTopic] where contentid={0} and contenttype={1}) as sp
                               where nid>{2} and nid<={3}";

            RecordCount = Convert.ToInt32(CommDataAccess.DbReader.ExecuteScalar(CommandType.Text,String.Format(sqlCount,TargetID,(int)contentType)));
            return CommDataAccess.DbReader.ExecuteDataSet(CommandType.Text, String.Format(sqlData, TargetID, (int)contentType, PageLowerBound, PageUpperBound)).Tables[0]; 
        }


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
        public NoName.NetShop.Comment.TopicModel ReaderBind(IDataReader dataReader)
		{
            NoName.NetShop.Comment.TopicModel model = new NoName.NetShop.Comment.TopicModel();
            object ojb;
            ojb = dataReader["TopicId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TopicId = (int)ojb;
            }
            model.UserId = dataReader["UserId"].ToString();
            ojb = dataReader["ContentType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ContentType = (ContentType)(Convert.ToInt32(ojb));
            }
            ojb = dataReader["ContentId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ContentId = (int)ojb;
            }
            model.Title = dataReader["Title"].ToString();
            model.Content = dataReader["Content"].ToString();
            ojb = dataReader["InsertTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.InsertTime = (DateTime)ojb;
            }
            ojb = dataReader["LastReplyTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastReplyTime = (DateTime)ojb;
            }
            ojb = dataReader["LastReplyId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastReplyId = (int)ojb;
            }
            ojb = dataReader["ReplyNum"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ReplyNum = (int)ojb;
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = (bool)ojb;
            }
            return model;
        }


        internal void ToggleStatus(int topicId)
        {
            string sql = "update qatopic set Status=case status when 1 then 0 else 1 end where topicId=" + topicId;
            Database db = CommDataAccess.DbWriter;
            db.ExecuteNonQuery(CommandType.Text, sql);
        }
    }
}
