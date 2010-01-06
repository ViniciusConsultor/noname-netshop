using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;

namespace NoName.NetShop.BackFlat.MagicWorld.Rent
{
    public partial class List : System.Web.UI.Page
    {
        private RentProductBll bll = new RentProductBll();
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
            GridView1.DataSource = bll.GetList(PageIndex, AspNetPager.PageSize, "","", out RecordCount);
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
                int RentID = Convert.ToInt32(e.CommandArgument);
                bll.Delete(RentID);
            }
 
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    LinkButton DeleteButton = (LinkButton)e.Row.Cells[5].FindControl("Button_Delete");
                    string ScriptString = String.Format("javascript:return confirm('你确认要删除：\"{0}\"吗?')", e.Row.Cells[1].Text.Trim());
                    DeleteButton.Attributes.Add("onclick", ScriptString);
                }
            }
        }
    }
}
