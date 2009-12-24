using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.CMS.Model;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.CMS.DataAccess
{
    public class TagDataAccess : DataAccess
    {
        public static void Insert(TagModel tag)
        {
            DbCommand Command = db.GetStoredProcCommand("UP_cmsTag_Add");

            db.AddInParameter(Command, "@tagname", DbType.String, tag.TagName);
            db.AddInParameter(Command, "@xslttemplate", DbType.String, tag.XsltTemplate);
            db.AddInParameter(Command, "@defaultparameter", DbType.String, tag.DefaultParameter);
            db.AddInParameter(Command, "@dataprovider", DbType.String, tag.DataProvider);
            db.AddInParameter(Command, "@editcontrol", DbType.String, tag.EditControl);
            db.AddInParameter(Command, "@examplepicture", DbType.String, tag.ExamplePicture);
            db.AddInParameter(Command, "@ispublic", DbType.Boolean, tag.IsPublic);
            db.AddInParameter(Command, "@tagtype", DbType.Int16, tag.TagType);

            db.ExecuteNonQuery(Command);
        }

        public static void Update(TagModel tag)
        {
            DbCommand Command = db.GetStoredProcCommand("UP_cmsTag_Add");

            db.AddInParameter(Command, "@tagid", DbType.Int32, tag.TagID);
            db.AddInParameter(Command, "@tagname", DbType.String, tag.TagName);
            db.AddInParameter(Command, "@xslttemplate", DbType.String, tag.XsltTemplate);
            db.AddInParameter(Command, "@defaultparameter", DbType.String, tag.DefaultParameter);
            db.AddInParameter(Command, "@dataprovider", DbType.String, tag.DataProvider);
            db.AddInParameter(Command, "@editcontrol", DbType.String, tag.EditControl);
            db.AddInParameter(Command, "@examplepicture", DbType.String, tag.ExamplePicture);
            db.AddInParameter(Command, "@ispublic", DbType.Boolean, tag.IsPublic);
            db.AddInParameter(Command, "@tagtype", DbType.Int16, tag.TagType);

            db.ExecuteNonQuery(Command);
        }

        public static DataTable Get(int TagID)
        {
            string sql = String.Format("select * from cmstag where tagid={0}",TagID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }
        
        public static void TagContentImport(TagContentModel tagContent)
        {
            DbCommand Command = db.GetStoredProcCommand("UP_cmsTagContent_Import");
            
            db.AddInParameter(Command,"@pageid",DbType.Int32,tagContent.PageID);
            db.AddInParameter(Command,"@tagid",DbType.Int32,tagContent.TagID);
            db.AddInParameter(Command,"@serverid",DbType.String,tagContent.ServerID);
            db.AddInParameter(Command,"@content",DbType.String,tagContent.Content);

            db.ExecuteNonQuery(Command);
        }
        
        public static void TagParameterImport(TagParameterModel tagParameter)
        {
            DbCommand Command = db.GetStoredProcCommand("UP_cmsTagParameter_Import");
            
            db.AddInParameter(Command,"@pageid",DbType.Int32,tagParameter.PageID);
            db.AddInParameter(Command,"@tagid",DbType.Int32,tagParameter.TagID);
            db.AddInParameter(Command,"@serverid",DbType.String,tagParameter.ServerID);
            db.AddInParameter(Command,"@parameter",DbType.String,tagParameter.Parameter);

            db.ExecuteNonQuery(Command);
        }

        public static string TagContentGet(int PageID,int TagID,string ServerID)
        {
            string sql = "select content from [cmsTagContent] WHERE [pageid]={0} AND [tagid]={1} AND [serverid]='{2}'";
            sql = String.Format(sql,PageID,TagID,ServerID);
            return Convert.ToString(db.ExecuteScalar(CommandType.Text,sql));
        }
        
        public static string TagParameterGet(int PageID,int TagID,string ServerID)
        {
            string sql = "select content from [cmsTagParameter] WHERE [pageid]={0} AND [tagid]={1} AND [serverid]='{2}'";
            sql = String.Format(sql,PageID,TagID,ServerID);
            return Convert.ToString(db.ExecuteScalar(CommandType.Text,sql));
        }
    }
}
