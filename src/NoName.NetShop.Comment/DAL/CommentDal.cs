using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NoName.NetShop.Comment.Model;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.Comment.DAL
{
    public class CommentDal
    {
        private Database dbw = DBFacroty.DbWriter;
        private Database dbr = DBFacroty.DbReader;

        public void Add(CommentModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_qaComment_Add");

            dbw.AddInParameter(Command, "@CommentID", DbType.Int32, model.CommentID);
            dbw.AddInParameter(Command, "@AppType", DbType.Int32, model.AppType);
            dbw.AddInParameter(Command, "@TargetID", DbType.Int32, model.TargetID);
            dbw.AddInParameter(Command, "@UserID", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@Content", DbType.String, model.Content);
            dbw.AddInParameter(Command, "@CreateTime", DbType.DateTime, model.CreateTime);

            dbw.ExecuteNonQuery(Command);
        }

        public void Delete(int CommentID)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_qaComment_Delete");

            dbw.AddInParameter(Command, "@CommentID", DbType.Int32, CommentID);

            dbw.ExecuteNonQuery(Command);
        }

        public void Update(CommentModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_qaComment_Update");

            dbw.AddInParameter(Command, "@CommentID", DbType.Int32, model.CommentID);
            dbw.AddInParameter(Command, "@AppType", DbType.Int32, model.AppType);
            dbw.AddInParameter(Command, "@TargetID", DbType.Int32, model.TargetID);
            dbw.AddInParameter(Command, "@UserID", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@Content", DbType.String, model.Content);
            dbw.AddInParameter(Command, "@CreateTime", DbType.DateTime, model.CreateTime);

            dbw.ExecuteNonQuery(Command);
        }

        public DataTable GetList(int AppType, int TargetID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_qaComment_Update");

            dbr.AddInParameter(Command, "@AppType", DbType.Int32, AppType);
            dbr.AddInParameter(Command, "@TargetID", DbType.Int32, TargetID);

            return dbr.ExecuteDataSet(Command).Tables[0];
        }

        public CommentModel GetModel(int CommentID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_qaComment_Get");

            dbw.AddInParameter(Command, "@CommentID", DbType.Int32, CommentID);

            DataTable dt = dbr.ExecuteDataSet(Command).Tables[0];
            CommentModel model=null;
            if (dt.Rows.Count > 0)
            {
                model = GetModel(dt.Rows[0]);
            }
            return model;
        }

        private CommentModel GetModel(DataRow row)
        {
            CommentModel model = new CommentModel();

            model.AppType = Convert.ToInt32(row["apptype"]);
            model.CommentID = Convert.ToInt32(row["commentid"]);
            model.Content = Convert.ToString(row["content"]);
            model.CreateTime = Convert.ToDateTime(row["createtime"]);
            model.TargetID = Convert.ToInt32(row["targetid"]);
            model.UserID = Convert.ToString(row["userid"]);

            return model;
        }
    }
}
