using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Web;
using NoName.NetShop.CMS.Model;
using NoName.NetShop.CMS.DataAccess;

namespace NoName.NetShop.CMS.Controler
{
    public class PageControler
    {
        public static PageModel GetModel(int PageID)
        {
            PageModel model = null;

            DataTable dt = PageDataAccess.Get(PageID);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                model = new PageModel();

                model.PageID = Convert.ToInt32(row["pageid"]);
                model.PageName = Convert.ToString(row["pagename"]);
                model.PageTitle = Convert.ToString(row["pagetitle"]);
                model.Category = Convert.ToInt32(row["category"]);
                model.Author = Convert.ToString(row["author"]);
                model.CreateTime = Convert.ToDateTime(row["createtime"]);
                model.LastModify = Convert.ToString(row["lastmodify"]);
                model.TempatePath = Convert.ToString(row["templatepath"]);
                model.PhysicalPath = Convert.ToString(row["physicalpath"]);
                model.UpdateTime = Convert.ToDateTime(row["updatetime"]);
                model.SelfClassid = Convert.ToInt32(row["selfclassid"]);
                model.ExtendPageInfo = Convert.ToString(row["extendpageinfo"]);
            }

            return model;
        }

    }
}
