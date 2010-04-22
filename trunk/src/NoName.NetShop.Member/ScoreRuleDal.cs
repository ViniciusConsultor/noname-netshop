using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Common;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.Member
{
    class ScoreRuleDal
    {
        #region  成员方法

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Save(ScoreRuleModel model)
        {
            Database db = CommDataAccess.DbWriter;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_ScoreRule_Save");
            db.AddInParameter(dbCommand, "actiontype", DbType.AnsiString, model.ActionType);
            db.AddInParameter(dbCommand, "score", DbType.Int32, model.Score);
            db.AddInParameter(dbCommand, "remark", DbType.AnsiString, model.Remark);
            db.ExecuteNonQuery(dbCommand);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string actiontype)
        {
            Database db = CommDataAccess.DbWriter;
            string sql = "delete umScoreRule where actiontype=@actiontype";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "actiontype", DbType.AnsiString, actiontype);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ScoreRuleModel GetModel(string actiontype)
        {
            Database db = CommDataAccess.DbReader;
            string sql = "select actiontype,score,remark,inserttime,updatetime from umscorerule where actiontype=@actiontype";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "actiontype", DbType.AnsiString, actiontype);

            ScoreRuleModel model = null;
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
        public List<ScoreRuleModel> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select actiontype,score,remark,inserttime,updatetime ");
            strSql.Append(" FROM umScoreRule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<ScoreRuleModel> list = new List<ScoreRuleModel>();
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
        public ScoreRuleModel ReaderBind(IDataReader dataReader)
        {
            ScoreRuleModel model = new ScoreRuleModel();
            object ojb;
            model.ActionType = dataReader["actiontype"].ToString();
            ojb = dataReader["score"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Score = Convert.ToInt32(ojb);
            }
            model.Remark = dataReader["remark"].ToString();
            ojb = dataReader["inserttime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.InsertTime = Convert.ToDateTime(ojb);
            }
            ojb = dataReader["updatetime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UpdateTime = Convert.ToDateTime(ojb);
            }
            return model;
        }

        #endregion  成员方法
    }
}
