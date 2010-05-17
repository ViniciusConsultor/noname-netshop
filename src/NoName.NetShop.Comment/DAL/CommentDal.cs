using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.Comment
{
    public class CommentDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public void Add(CommentModel model)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_qaComment_Add");

            dbw.AddInParameter(Command, "@CommentID", DbType.Int32, model.CommentID);
            dbw.AddInParameter(Command, "@AppType", DbType.String, model.AppType);
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
            dbw.AddInParameter(Command, "@AppType", DbType.String, model.AppType);
            dbw.AddInParameter(Command, "@TargetID", DbType.Int32, model.TargetID);
            dbw.AddInParameter(Command, "@UserID", DbType.String, model.UserID);
            dbw.AddInParameter(Command, "@Content", DbType.String, model.Content);
            dbw.AddInParameter(Command, "@CreateTime", DbType.DateTime, model.CreateTime);

            dbw.ExecuteNonQuery(Command);
        }

        public DataTable GetList(string AppType, int TargetID)
        {
            DbCommand Command = dbr.GetStoredProcCommand("UP_qaComment_GetList");

            dbr.AddInParameter(Command, "@AppType", DbType.String, AppType);
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

        public DataTable GetList(int PageIndex,int PageSize, string TableFields, string AppType,string JoinStr, out int RecordCount)
        {
            int PageLowerBound = 0, PageUpperBount = 0;
            PageLowerBound = (PageIndex - 1) * PageSize;
            PageUpperBount = PageLowerBound + PageSize;

            string sqlCount = @"select count(0) from qacomment c " + JoinStr + " where  apptype='" + AppType + "'";

            string sqlData = @"select * from 
	                            (select row_number() OVER(ORDER BY c.createtime desc) as nid,c.*," + TableFields + @" from qacomment c " + JoinStr + @" where c.apptype='" + AppType + @"') as sp
	                            where sp.nid>" + PageLowerBound + " and sp.nid <= " + PageUpperBount;


            RecordCount = Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text, sqlCount));
            return dbr.ExecuteDataSet(CommandType.Text, sqlData).Tables[0];
        }

        private CommentModel GetModel(DataRow row)
        {
            CommentModel model = new CommentModel();

            model.AppType = Convert.ToString(row["apptype"]);
            model.CommentID = Convert.ToInt32(row["commentid"]);
            model.Content = Convert.ToString(row["content"]);
            model.CreateTime = Convert.ToDateTime(row["createtime"]);
            model.TargetID = Convert.ToInt32(row["targetid"]);
            model.UserID = Convert.ToString(row["userid"]);

            return model;
        }


    }
}
