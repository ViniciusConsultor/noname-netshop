using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.CMS.Controler;
using NoName.NetShop.CMS.Config;
using System.Configuration;
using System.Data;
using NoName.NetShop.CMS.Model;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.CMS.Page.HelpCenter
{
    public partial class List : System.Web.UI.Page
    {
        private PageCategorySection Config = (PageCategorySection)ConfigurationManager.GetSection("pageCategorySection");

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
            DataTable dt = PageControler.GetList(PageIndex, AspNetPager.PageSize, PageCategory.HelpCenter, out RecordCount);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            AspNetPager.RecordCount = RecordCount;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "d")
            {
                int PageID = Convert.ToInt32(e.CommandArgument);
                PageControler.Delete(PageID);
                BindData(AspNetPager.CurrentPageIndex);
            }
        }

        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    LinkButton DeleteButton = (LinkButton)e.Row.Cells[5].FindControl("Button_Delete");
                    string ScriptString = String.Format("javascript:return confirm('是否确认删除页面\"{0}\"？')", e.Row.Cells[1].Text);
                    DeleteButton.Attributes.Add("onclick", ScriptString);
                }
            }
        }
    }
}
