using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.CMS.Model;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.CMS.DataAccess
{
    public class PageDataAccess : DataAccess
    {
        public static void Insert(PageModel page)
        {
            DbCommand Command = db.GetStoredProcCommand("UP_cmsPage_Add");

            db.AddInParameter(Command, "@pagename", DbType.Int32, page.PageName);
            db.AddInParameter(Command, "@pagetitle", DbType.String, page.PageTitle);
            db.AddInParameter(Command, "@createtime", DbType.DateTime, page.CreateTime);
            db.AddInParameter(Command, "@updatetime", DbType.DateTime, page.UpdateTime);
            db.AddInParameter(Command, "@physicalpath", DbType.String, page.PhysicalPath);
            db.AddInParameter(Command, "@author", DbType.String, page.Author);
            db.AddInParameter(Command, "@lastmodify", DbType.String, page.LastModify);
            db.AddInParameter(Command, "@category", DbType.Int32, page.Category);
            db.AddInParameter(Command, "@selfclassid", DbType.Int32, page.SelfClassid);
            db.AddInParameter(Command, "@extendpageinfo", DbType.String, page.ExtendPageInfo);
            db.AddInParameter(Command, "@templatepath", DbType.String, page.TempatePath);

            db.ExecuteNonQuery(Command);
        }


        public static void Update(PageModel page)
        {
            DbCommand Command = db.GetStoredProcCommand("UP_cmsTag_Update");

            db.AddInParameter(Command, "@pageid", DbType.Int32, page.PageID);
            db.AddInParameter(Command, "@pagename", DbType.Int32, page.PageName);
            db.AddInParameter(Command, "@pagetitle", DbType.String, page.PageTitle);
            db.AddInParameter(Command, "@createtime", DbType.DateTime, page.CreateTime);
            db.AddInParameter(Command, "@updatetime", DbType.DateTime, page.UpdateTime);
            db.AddInParameter(Command, "@physicalpath", DbType.String, page.PhysicalPath);
            db.AddInParameter(Command, "@author", DbType.String, page.Author);
            db.AddInParameter(Command, "@lastmodify", DbType.String, page.LastModify);
            db.AddInParameter(Command, "@category", DbType.Int32, page.Category);
            db.AddInParameter(Command, "@selfclassid", DbType.Int32, page.SelfClassid);
            db.AddInParameter(Command, "@extendpageinfo", DbType.String, page.ExtendPageInfo);
            db.AddInParameter(Command, "@templatepath", DbType.String, page.TempatePath);

            db.ExecuteNonQuery(Command);
        }

        public static DataTable Get(int PageID)
        {
            string sql = String.Format("select * from [cmspage] where pageid={0}", PageID);
            return db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public static DataTable GetList(int PageIndex,int PageSize,PageCategory pageCate,out int RecordCount)
        {
            int PageLowerBound = 0, PageUpperBount = 0;
            PageLowerBound = (PageIndex - 1) * PageSize;
            PageUpperBount = PageLowerBound + PageSize;

            string sqlCount = String.Format("select * from cmspage where category={0}", (int)pageCate);
            string sqlData = @" select * from (select row_number() over(order by pageid desc) as nid,* from cmspage where category={0}) as sp
                                where sp.nid>{1} and sp.nid<={2}";

            RecordCount = Convert.ToInt32(db.ExecuteScalar(CommandType.Text,sqlCount));
            return db.ExecuteDataSet(CommandType.Text, sqlData).Tables[0];
        }
    }
}
