using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NoName.Utility;
using NoName.NetShop.News.BLL;

namespace NoName.NetShop.BackFlat.News.Detail
{
    public partial class List : System.Web.UI.Page
    {
        private NewsModelBll bll = new NewsModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(1);
            }
        }

        private void BindData(int PageIndex)
        {
            int RecordCount = 0;

            DataTable dt = bll.GetList(PageIndex,AspNetPager.PageSize, "",out RecordCount);

            GridView1.DataSource = ProcessCategory(dt);
            GridView1.DataBind();

            AspNetPager.RecordCount = RecordCount; 
        }


        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "d")
            {
                int NewsID = Convert.ToInt32(e.CommandArgument);
                bll.Delete(NewsID);
                MessageBox.Show(this,"删除成功！");
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName == "ss")
            {
                int NewsID = Convert.ToInt32(e.CommandArgument);
                bll.SetSplendid(NewsID, true);
                BindData(AspNetPager.CurrentPageIndex);
            }
            if (e.CommandName == "ds")
            {
                int NewsID = Convert.ToInt32(e.CommandArgument);
                bll.SetSplendid(NewsID, false);
                BindData(AspNetPager.CurrentPageIndex);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[5].FindControl("LinkButton_Delete")).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text.Trim() + "\"吗?')");
                }
            }
        }

        private DataTable ProcessCategory(DataTable dt)
        {
            string ForeFlatRootUrl = ConfigurationManager.AppSettings["foreFlatRootUrl"];

            dt.Columns.Add("catename");
            dt.Columns.Add("fronturl");

            foreach (DataRow row in dt.Rows)
            {
                row["catename"] = new NewsCategoryModelBll().GetModel(Convert.ToInt32(row["cateid"])).CateName;
                row["fronturl"] = String.Format("{0}news-{1}.html", ForeFlatRootUrl.EndsWith("/") ? ForeFlatRootUrl : ForeFlatRootUrl + "/", row["newsid"]);
            }
            return dt;
        }
    }
}
