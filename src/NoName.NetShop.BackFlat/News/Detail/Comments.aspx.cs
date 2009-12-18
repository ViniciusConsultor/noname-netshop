using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Comment.BLL;
using NoName.Utility;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.News.Detail
{
    public partial class Comments : System.Web.UI.Page
    {
        private CommentBll bll = new CommentBll();
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
            GridView1.DataSource = bll.GetList(PageIndex, AspNetPager.PageSize,"n.*", AppType.News, "inner join nenews n on c.targetid=n.newsid", out RecordCount);
            GridView1.DataBind();

            AspNetPager.RecordCount = RecordCount; 
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[4].FindControl("Button_Delete")).Attributes.Add("onclick", "javascript:return confirm('你确认要删除ID为\"" + e.Row.Cells[0].Text.Trim() + "\"的评论吗?')");
                }
            } 
        }


        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }

        protected void GridView1_RowCommand(object sender,GridViewCommandEventArgs e)
        {
            if (e.CommandName == "d")
            {
                int CommentID = Convert.ToInt32(e.CommandArgument);
                bll.Delete(CommentID);
                BindData(AspNetPager.CurrentPageIndex);
            }
 
        }
    }
}
