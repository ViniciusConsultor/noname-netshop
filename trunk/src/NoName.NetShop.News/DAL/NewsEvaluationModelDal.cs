using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Common;
using NoName.NetShop.News.Model;
using System.Data;
using System.Data.Common;

namespace NoName.NetShop.News.DAL
{
    public class NewsEvaluationModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(NewsEvaluationModel model)
        {
            string SpName = "UP_neNewsEvaluation_Add";

            DbCommand Command = dbw.GetStoredProcCommand(SpName);

            dbw.AddInParameter(Command, "@newsid", DbType.Int32, model.NewsID);
            dbw.AddInParameter(Command, "@userid", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@evaluation", DbType.Int32, model.Evaluation);
            dbw.AddInParameter(Command, "@inserttime", DbType.DateTime, model.InsertTime);

            dbw.ExecuteNonQuery(Command);
        }

        public void Update(NewsEvaluationModel model)
        {
            string SpName = "UP_neNewsEvaluation_Update";

            DbCommand Command = dbw.GetStoredProcCommand(SpName);

            dbw.AddInParameter(Command, "@newsid", DbType.Int32, model.NewsID);
            dbw.AddInParameter(Command, "@userid", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@evaluation", DbType.Int32, model.Evaluation);
            dbw.AddInParameter(Command, "@inserttime", DbType.DateTime, model.InsertTime);

            dbw.ExecuteNonQuery(Command);

        }
        public void Delete(int NewsID,string UserID)
        {
            string SpName = "UP_neNewsEvaluation_Delete";

            DbCommand Command = dbw.GetStoredProcCommand(SpName);

            dbw.AddInParameter(Command, "@newsid", DbType.Int32, NewsID);
            dbw.AddInParameter(Command, "@userid", DbType.String, UserID);

            dbw.ExecuteNonQuery(Command);
        }
        public NewsEvaluationModel GetModel(int NewsID,string UserID)
        {
            string SpName = "UP_neNewsEvaluation_Get";

            DbCommand Command = dbr.GetStoredProcCommand(SpName);

            dbr.AddInParameter(Command, "@newsid", DbType.Int32, NewsID);
            dbr.AddInParameter(Command, "@userid", DbType.String, UserID);

            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];
            NewsEvaluationModel model = null;

            if (dt.Rows.Count > 0)
            {
                model = GetModel(dt.Rows[0]);
            }

            return model;
        }

        public DataTable StatisticList(int NewsID)
        {
            string SpName = "UP_neNewsEvaluation_GetList";

            DbCommand Command = dbr.GetStoredProcCommand(SpName);

            dbr.AddInParameter(Command, "@newsid", DbType.Int32, NewsID);

            return dbr.ExecuteDataSet(Command).Tables[0];
        }

        public bool Exists(int NewsID, string UserID)
        {
            string SpName = "UP_neNewsEvaluation_Get";

            DbCommand Command = dbr.GetStoredProcCommand(SpName);

            dbr.AddInParameter(Command, "@newsid", DbType.Int32, NewsID);
            dbr.AddInParameter(Command, "@userid", DbType.String, UserID);

            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];

            return dt.Rows.Count > 0;
        }

        public DataTable GetListOfNews(int NewsID)
        {
            string SpName = "UP_neNewsEvaluation_GetListNews";

            DbCommand Command = dbr.GetStoredProcCommand(SpName);

            dbr.AddInParameter(Command, "@newsid", DbType.Int32, NewsID);

            return dbr.ExecuteDataSet(Command).Tables[0];
        }

        public NewsEvaluationModel GetModel(DataRow row)
        {
            return new NewsEvaluationModel()
            {
                Evaluation = String.IsNullOrEmpty(Convert.ToString(row["Evaluation"])) ? 1 : Convert.ToInt32(row["Evaluation"]),
                InsertTime = String.IsNullOrEmpty(Convert.ToString(row["InsertTime"])) ? new DateTime(1900, 01, 01) : Convert.ToDateTime(row["InsertTime"]),
                NewsID = String.IsNullOrEmpty(Convert.ToString(row["NewsID"])) ? 0 : Convert.ToInt32(row["NewsID"]),
                UserID = Convert.ToString(row["UserID"])
            };
        }
    }
}