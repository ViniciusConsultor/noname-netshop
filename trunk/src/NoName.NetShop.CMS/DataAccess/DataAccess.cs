using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using NoName.NetShop.CMS.Model;
using NoName.Utility;
using NoName.NetShop.Common;

namespace NoName.NetShop.CMS.DataAccess
{
    public abstract class DataAccess
    {
        public static Database db = CommDataAccess.DbReader;


        #region 弃用代码
//        private static Database db = CommDataAccess.DbReader;

//        public static DataSet GetPageByID(int PageID)
//        {
//            string sql = "select * from cmspage where id=" + PageID;

//            return db.ExecuteDataSet(CommandType.Text, sql);
//        }
//        public static DataSet GetTagByID(int TagID)
//        {
//            string sql = "select * from cmstag where id=" + TagID;
//            return db.ExecuteDataSet(CommandType.Text, sql);
//        }

//        public static bool TagContentImport(int PageID, int TagID, string ServerID, string Content)
//        {
//            string SpName = "UP_cmsTagContent_CheckIn";

//            DbCommand Command = db.GetStoredProcCommand(SpName);

//            db.AddInParameter(Command, "@pageid", DbType.Int64, PageID);
//            db.AddInParameter(Command, "@tagid", DbType.Int32, TagID);
//            db.AddInParameter(Command, "@serverid", DbType.String, ServerID);
//            db.AddInParameter(Command, "@content", DbType.String, Content);

//            return db.ExecuteNonQuery(Command) == 1 ? true : false;
//        }
//        public static bool TagParameterImport(TagParameterInfo parm)
//        {
//            string SpName = "UP_cmsTagParameter_CheckIn";

//            DbCommand Command = db.GetStoredProcCommand(SpName);

//            db.AddInParameter(Command, "@pageid", DbType.Int64, parm.PageID);
//            db.AddInParameter(Command, "@tagid", DbType.Int32, parm.TagID);
//            db.AddInParameter(Command, "@serverid", DbType.String, parm.ServerID);
//            db.AddInParameter(Command, "@usedefault", DbType.Boolean, parm.IsUseDefault);
//            db.AddInParameter(Command, "@parameters", DbType.String, HttpUtil.GetParameterString(parm.Parameters));

//            return db.ExecuteNonQuery(Command) == 1 ? true : false;
//        }

//        public static bool PageInsert(PageInfo page)
//        {
//            string SpName = "UP_cmsPage_Insert";

//            DbCommand Command = db.GetStoredProcCommand(SpName);

//            db.AddInParameter(Command, "@pagename", DbType.String, page.PageName);
//            db.AddInParameter(Command, "@pagetitle", DbType.String, page.PageTitle);
//            db.AddInParameter(Command, "@createtime", DbType.DateTime, page.CreateTime);
//            db.AddInParameter(Command, "@updatetime", DbType.DateTime, page.UpdateTime);
//            db.AddInParameter(Command, "@template", DbType.String, page.TemplatePath);
//            db.AddInParameter(Command, "@physicalpath", DbType.String, page.PhysicalPath);
//            db.AddInParameter(Command, "@author", DbType.String, page.Author);
//            db.AddInParameter(Command, "@lastmodify", DbType.String, page.LastModify);
//            db.AddInParameter(Command, "@category", DbType.Int32, page.Category);

//            return db.ExecuteNonQuery(Command) == 1 ? true : false;
//        }
//        public static bool PageUpdateTitle(int PageID, string PageTitle)
//        {
//            string sql = "update cmspage set pagetitle = '" + PageTitle + "' where id=" + PageID;

//            return db.ExecuteNonQuery(CommandType.Text, sql) == 1 ? true : false;
//        }
//        public static bool PageUpdateModify(int PageID, string UserName)
//        {
//            string sql = "update cmspage set lastmodify='" + UserName + "',updatetime='" + DateTime.Now + "' where id=" + PageID;
//            return db.ExecuteNonQuery(CommandType.Text, sql) == 1 ? true : false;
//        }
//        public static bool PageDelete(int PageID)
//        {
//            string sql = "delete from cmspage where id=" + PageID;
//            return db.ExecuteNonQuery(CommandType.Text, sql) == 1 ? true : false;
//        }

//        public static string TagContentGet(int PageID, int TagID, string ServerID)
//        {
//            string SpName = "UP_cmsTagContent_Get";

//            DbCommand Command = db.GetStoredProcCommand(SpName);

//            db.AddInParameter(Command, "@pageid", DbType.Int64, PageID);
//            db.AddInParameter(Command, "@tagid", DbType.Int32, TagID);
//            db.AddInParameter(Command, "@serverid", DbType.String, ServerID);

//            return db.ExecuteScalar(Command).ToString();
//        }
//        public static TagParameterInfo TagParameterGet(int PageID, int TagID, string ServerID)
//        {
//            TagParameterInfo parm = null;

//            string sql = "select * from CMSTagParameter where pageid=" + PageID + " and tagid=" + TagID + " and serverid='" + ServerID + "'";

//            DataTable dt = db.ExecuteDataSet(CommandType.Text, sql).Tables[0];

//            if (dt.Rows.Count > 0)
//            {
//                DataRow row = dt.Rows[0];
//                parm = new TagParameterInfo();

//                parm.PageID = Convert.ToInt32(row["pageid"]);
//                parm.TagID = Convert.ToInt32(row["tagid"]);
//                parm.ServerID = Convert.ToString(row["serverid"]);
//                parm.IsUseDefault = Convert.ToBoolean(row["usedefault"]);
//                parm.Parameters = HttpUtil.GetParameters(row["parameters"].ToString());
//            }

//            return parm;
//        }

//        public static DataTable GetPageList(PageCategory category)
//        {
//            int pageCat = 0;

//            switch (category)
//            {
//                case PageCategory.Index:
//                    pageCat = 1;
//                    break;
//                case PageCategory.SecondaryPage:
//                    pageCat = 2;
//                    break;
//                case PageCategory.TopicPage:
//                    pageCat = 3;
//                    break;
//                default:
//                    break;
//            }

//            string sql = "select * from cmspage where category=" + pageCat;

//            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
//        }
//        public static DataTable GetTagList()
//        {
//            string sql = "select * from CMSTag";
//            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
//        }

//        public static int NewTag(int TagType, string Template, string DefaultPara, string DataProvider)
//        {
//            string sql = @"INSERT INTO [CMSTag]
//                               ([template]
//                               ,[tagtype]
//                               ,[defaultpara]
//                               ,[dataprovider])
//                           VALUES
//                               ('{0}',{1},'{2}','{3}')";
//            sql = String.Format(sql, Template, TagType, DefaultPara, DataProvider);

//            return db.ExecuteNonQuery(CommandType.Text, sql);
//        }

#endregion
    }
}
